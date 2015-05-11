# -*- coding: utf-8 -*-

import os
import tempfile
import json
import Queue
import threading

from bs4 import BeautifulSoup
import requests

from anp_reader import log
from anp_reader.modules.product import ANP_CODES
from anp_reader.modules.util import count_weeks, remove_accents, state_map


class PriceController():
    def __init__(self):

        self.data_dir = os.path.join(tempfile.tempdir, 'prices')

        self.download_queue = Queue.Queue()
        self.price_queue = Queue.Queue()

        self.price_map = {}
        self.price_lock = threading.Lock()

        self.headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                        'Origin': 'http://www.anp.gov.br',
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'Accept-Encoding': 'gzip, deflate',
                        'Cache-Control': 'max-age=0',
                        'Connection:': 'keep-alive',
                        'Accept': 'text/html',
                        'Referer': 'http://www.anp.gov.br/preco/prc/Resumo_Semanal_Index.asp'}

    def download_prices(self, state_set, product_set):
        week_idx = count_weeks()

        if not os.path.exists(self.data_dir):
            os.makedirs(self.data_dir)

        for i in range(25):
            t = threading.Thread(target=self._download_prices)
            t.daemon = True
            t.start()

        for product in product_set:
            if product is None:
                continue

            values = {'selSemana': '%d*GAA' % week_idx,
                      'desc_Semana': 'GAA',
                      'cod_Semana': week_idx,
                      'tipo': '2',
                      'rdResumo': '2',
                      'selCombustivel': '%s*GAA' % product}
            r = requests.get('http://www.anp.gov.br/preco/prc/Resumo_Semanal_Estado.asp', data=values, headers=self.headers,
                             stream=True)
            if r.status_code == requests.codes.ok:
                self.headers['Cookie'] = r.headers.get('set-cookie', None)
                tmp_file = os.path.join(self.data_dir, product)
                with open(tmp_file, 'wb') as fd:
                    for chunk in r.iter_content(8192):
                        fd.write(chunk)

                html_dom = BeautifulSoup(open(tmp_file))
                state_dom = html_dom.find('table')
                if state_dom:
                    for row_dom in state_dom.find_all('tr')[3:]:
                        state = state_map[row_dom.contents[0].text.strip().lower()]
                        if state not in state_set:
                            continue
                        self.price_lock.acquire()
                        state_info = self.price_map.get(state, {'prices': {}})
                        price_info = {
                            'price': float(row_dom.contents[2].text.strip().replace(',', '.')),
                            'price_min': float(row_dom.contents[4].text.strip().replace(',', '.')),
                            'price_max': float(row_dom.contents[5].text.strip().replace(',', '.'))
                        }
                        state_info['prices'][ANP_CODES[product]] = price_info
                        self.price_map[state] = state_info
                        self.price_lock.release()

                        dirname = os.path.join(self.data_dir, state)
                        if not os.path.exists(dirname):
                            os.makedirs(dirname)
                        self.download_queue.put((week_idx, state, product))

        self.download_queue.join()

    def _download_prices(self):
        while True:
            item = self.download_queue.get()
            try:
                values = {'selSemana': '%d*GAA' % item[0],
                          'desc_Semana': 'GAA',
                          'cod_Semana': item[0],
                          'tipo': '1',
                          'Cod_Combustivel': 'undefined',
                          'selEstado': '%s*GAA' % item[1],
                          'selCombustivel': '%s*GAA' % item[2]}

                headers = self.headers
                headers['Referer'] = 'http://www.anp.gov.br/preco/prc/Resumo_Semanal_Estado.asp'
                r = requests.get('http://www.anp.gov.br/preco/prc/Resumo_Por_Estado_Municipio.asp', data=values,
                                 headers=headers, stream=True)
                if r.status_code == requests.codes.ok:
                    filename = os.path.join(self.data_dir, item[1], item[2])
                    with open(filename, 'wb') as fd:
                        for chunk in r.iter_content(8192):
                            fd.write(chunk)
            except Exception as ex:
                log.error(ex.message)
                self.download_queue.put(item)
            finally:
                self.download_queue.task_done()

    def process_prices(self, state_set):
        for i in range(50):
            t = threading.Thread(target=self._process_prices)
            t.daemon = True
            t.start()

        for state in state_set:
            dirname = os.path.join(self.data_dir, state)
            files = os.listdir(dirname)
            for f in files:
                self.price_queue.put((os.path.join(dirname, f), state))

        self.price_queue.join()

        filename = os.path.join(self.data_dir, 'prices.json')
        with open(filename, 'w') as outfile:
            json.dump(self.price_map, outfile)

        log.info('written %d price(s)' % len(self.price_map))

    def _process_prices(self):
        while True:
            item = self.price_queue.get()
            try:
                html_dom = BeautifulSoup(open(item[0]))

                product_dom = html_dom.find_all('input')[2]
                product = product_dom.attrs['value']

                city_dom = html_dom.find('table')
                if city_dom:
                    for row_dom in city_dom.find_all('tr')[3:]:
                        city = remove_accents(row_dom.contents[0].text.strip().upper() + '/' + item[1].upper())
                        self.price_lock.acquire()
                        city_info = self.price_map.get(city, {'prices': {}})
                        price_info = {
                            'price': float(row_dom.contents[2].text.strip().replace(',', '.')),
                            'price_min': float(row_dom.contents[4].text.strip().replace(',', '.')),
                            'price_max': float(row_dom.contents[5].text.strip().replace(',', '.'))
                        }
                        city_info['prices'][ANP_CODES[product]] = price_info
                        self.price_map[city] = city_info
                        self.price_lock.release()
            except Exception as ex:
                log.error(ex.message)
            finally:
                self.price_queue.task_done()
