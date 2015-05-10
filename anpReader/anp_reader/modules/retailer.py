# -*- coding: utf-8 -*-

import os
import tempfile
import json
import Queue
import threading

from bs4 import BeautifulSoup
import requests

from anp_reader import log
from anp_reader.modules.product import PRODUCT_TYPES
from anp_reader.modules.util import remove_punctuation, remove_accents


class RetailerController():
    def __init__(self):
        self.data_dir = os.path.join(tempfile.tempdir, 'retailers')

        self.download_queue = Queue.Queue()
        self.retailer_queue = Queue.Queue()

        self.retailer_map = {}
        self.retailer_lock = threading.Lock()

        self.headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; ''Windows NT)',
                        'Origin': 'http://www.anp.gov.br',
                        'Content-Type': 'application/x-www-form-urlencoded',
                        'Accept-Encoding': 'gzip, deflate',
                        'Cache-Control': 'max-age=0',
                        'Connection:': 'keep-alive',
                        'Accept': 'text/html'}

    def download_retailers(self, state_set, product_set):

        for i in range(50):
            t = threading.Thread(target=self._download_retailer)
            t.daemon = True
            t.start()

        for state in state_set:
            state = state.upper()
            dirname = os.path.join(self.data_dir, state)
            if not os.path.exists(dirname):
                os.makedirs(dirname)
            for product in product_set:
                product = str(product)
                values = {'sCnpj': '',
                          'sRazaoSocial': '',
                          'sEstado': state,
                          'sMunicipio': '0',
                          'sBandeira': '0',
                          'sProduto': product,
                          'sTipodePosto': '0',
                          'hPesquisar': 'PESQUISAR'}

                tot_pg = 100
                cur_pg = 1
                while cur_pg <= tot_pg:
                    values['p'] = cur_pg
                    try:
                        r = requests.get('http://www.anp.gov.br/postos/consulta.asp', data=values, headers=self.headers,
                                         stream=True)
                        if r.status_code == requests.codes.ok:
                            self.headers['Referer'] = 'http://www.anp.gov.br/postos/consulta.asp'
                            self.headers['Cookie'] = r.headers.get('set-cookie', None)

                            tmp_file = os.path.join(self.data_dir, state + '_' + product)
                            with open(tmp_file, 'wb') as fd:
                                for chunk in r.iter_content(8192):
                                    fd.write(chunk)

                            html_dom = BeautifulSoup(open(tmp_file))
                            tables = html_dom.find_all('table')
                            if cur_pg == 1:
                                count_dom = tables[3]
                                if count_dom:
                                    count_str = ''.join(x for x in count_dom.contents[5].text if x.isdigit())
                                    tot_pg = int(count_str) / 200 + 1

                            retailer_dom = tables[7]
                            if retailer_dom:
                                row_dom = retailer_dom.find_all('tr')[2:-1]
                                for row in row_dom:
                                    cnpj = remove_punctuation(row.contents[1].contents[0].contents[2].attrs['value'])
                                    cod = row.contents[1].contents[0].contents[1].attrs['value'].strip()
                                    self.download_queue.put((state, cnpj, cod))
                    except Exception as ex:
                        log.error(ex.message)

                    cur_pg += 1

        self.download_queue.join()

    def _download_retailer(self):
        while True:
            item = self.download_queue.get()
            try:
                values = {'Cod_inst': item[2],
                          'estado': '0',
                          'municipio': '0'}

                r = requests.get('http://www.anp.gov.br/postos/resultado.asp', data=values, headers=self.headers, stream=True)
                if r.status_code == requests.codes.ok:
                    filename = os.path.join(self.data_dir, item[0], item[1])
                    with open(filename, 'wb') as fd:
                        for chunk in r.iter_content(8192):
                            fd.write(chunk)
            except Exception as ex:
                log.error(ex.message)
                self.download_queue.put(item)  # check this
            finally:
                self.download_queue.task_done()

    def process_retailers(self, state_set):
        for i in range(50):
            t = threading.Thread(target=self._process_retailer)
            t.daemon = True
            t.start()

        for state in state_set:
            dirname = os.path.join(self.data_dir, state)
            files = os.listdir(dirname)
            for f in files:
                self.retailer_queue.put(os.path.join(dirname, f))

        self.retailer_queue.join()

        filename = os.path.join(self.data_dir, 'retailers.json')
        with open(filename, 'w') as outfile:
            json.dump(self.retailer_map, outfile)

        log.info('written %d retailer(s)' % len(self.retailer_map))

    def _process_retailer(self):
        headers = {
            'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; ''Windows NT)',
            'Accept-Language': 'pt-BR'}
        while True:
            item = self.retailer_queue.get()
            try:
                html_dom = BeautifulSoup(open(item))
                retailer_dom = html_dom.find_all('table')[3]
                if retailer_dom:
                    row_dom = retailer_dom.find_all('tr')
                    status = row_dom[1].text.lower()
                    if 'revoga' in status:  # revogada or revogação
                        continue
                    pending = 'pendente' in status
                    if pending:
                        row_dom.insert(0, None)

                    cnpj = remove_punctuation(row_dom[4].contents[3].text)
                    address = row_dom[7].contents[2].text.strip()
                    address_ex = row_dom[8].contents[2].text.strip()
                    if address_ex:
                        address += ' ' + address_ex
                    address_ex = row_dom[9].contents[2].text.strip()
                    address += ' ' + address_ex

                    retailer_info = {
                        'company_name': row_dom[5].contents[2].text.strip().upper(),
                        'trade_name': row_dom[6].contents[2].text.strip().upper(),
                        'address': address.upper(),
                        'city': remove_accents(row_dom[10].contents[2].text.strip().upper()),
                        'zip': row_dom[11].contents[2].text.strip(),
                        'brand': None if pending else row_dom[14].contents[2].text.strip().upper()
                    }

                    if not pending:
                        product_info = []
                        for product_row in row_dom[18:-3]:
                            product = remove_accents(product_row.contents[1].text.strip().upper())
                            if product in PRODUCT_TYPES:
                                product_info.append(
                                    PRODUCT_TYPES[product][0])
                        retailer_info['products'] = product_info

                    full_address = retailer_info['address'] + ', ' + retailer_info['city'] + ', BRASIL'
                    url = 'https://maps.googleapis.com/maps/api/geocode/json?address=%s&sensor=false&key=AIzaSyCs7WX' \
                          '-nxB0mmLmHG8mXrPRSYV-zfbXsaM' % full_address
                    try:
                        r = requests.get(url, headers=headers)
                        if r.status_code == requests.codes.ok:
                            address = r.json()
                            if address['status'] == 'OK':
                                retailer_info['location'] = address['results'][0]['geometry']['location']
                                retailer_info['formatted_address'] = address['results'][0]['formatted_address']
                    except Exception as ex:
                        log.error(ex.message)

                    self.retailer_lock.acquire()
                    self.retailer_map[cnpj] = retailer_info
                    self.retailer_lock.release()
            except Exception as ex:
                log.error(ex.message)
            finally:
                self.retailer_queue.task_done()
