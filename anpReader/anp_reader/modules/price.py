# -*- coding: utf-8 -*-
import os
import tempfile
import json

from bs4 import BeautifulSoup
import requests

from anp_reader.modules.product import ANP_CODES

from anp_reader.modules.util import count_weeks, remove_accents


class PriceController():
    def __init__(self):
        pass

    @staticmethod
    def process_state_data_and_save(state_set, product_set):
        city_map = dict()
        week_idx = count_weeks()
        for state in state_set:
            state = state.upper()
            for product in product_set:
                if product is None:
                    continue
                headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                           'Origin': 'http://www.anp.gov.br',
                           'Content-Type': 'application/x-www-form-urlencoded',
                           'Accept-Encoding': 'gzip, deflate',
                           'Cache-Control': 'max-age=0',
                           'Connection:': 'keep-alive',
                           'Accept': 'text/html',
                           'Referer': 'http://www.anp.gov.br/preco/prc/Resumo_Por_Estado_Index.asp'}
                values = {'selSemana': str(week_idx) + '*GAA',
                          'desc_Semana': 'GAA',
                          'cod_Semana': str(week_idx),
                          'tipo': '1',
                          'Cod_Combustivel': 'undefined',
                          'selEstado': state + '*GAA',
                          'selCombustivel': str(product) + '*GAA'}

                r = requests.get('http://www.anp.gov.br/preco/prc/Resumo_Por_Estado_Municipio.asp', data=values,
                                 headers=headers, stream=True)
                if r.status_code == requests.codes.ok:
                    filename = os.path.join(tempfile.tempdir, state + '_' + str(product))
                    with open(filename, 'wb') as fd:
                        for chunk in r.iter_content(8192):
                            fd.write(chunk)

                    html_dom = BeautifulSoup(open(filename))
                    city_dom = html_dom.find('table')

                    if city_dom:
                        for row_dom in city_dom.find_all('tr')[3:]:
                            city = remove_accents(row_dom.contents[0].text.strip().upper() + '/'
                                                  + state.strip().upper())
                            city_info = city_map.get(city, {'prices': {}})
                            price_info = {
                                'price': float(row_dom.contents[2].text.strip().replace(',', '.')),
                                'price_min': float(row_dom.contents[4].text.strip().replace(',', '.')),
                                'price_max': float(row_dom.contents[5].text.strip().replace(',', '.'))
                            }
                            city_info['prices'][ANP_CODES[product]] = price_info
                            city_map[city] = city_info

        filename = os.path.join(tempfile.tempdir, 'price.json')
        with open(filename, 'w') as outfile:
            json.dump(city_map, outfile)
