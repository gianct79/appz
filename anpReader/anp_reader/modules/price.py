# -*- coding: utf-8 -*-
import os
import tempfile

from bs4 import BeautifulSoup
import requests

from anp_reader.modules.util import count_weeks


class PriceController():
    def __init__(self):
        pass

    @staticmethod
    def download_state_data(state_set, fuel_set):
        file_set = []
        week_idx = count_weeks()
        for state in state_set:
            for fuel in fuel_set:
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
                          'selCombustivel': str(fuel) + '*GAA'}

                r = requests.get('http://www.anp.gov.br/preco/prc/Resumo_Por_Estado_Municipio.asp', data=values,
                                 headers=headers, stream=True)
                if r.status_code == requests.codes.ok:
                    filename = os.path.join(tempfile.tempdir, state + '_' + str(fuel))
                    with open(filename, 'wb') as fd:
                        for chunk in r.iter_content(8192):
                            fd.write(chunk)
                file_set.append(filename)

        return file_set

    @staticmethod
    def download_city_data(city_set, fuel_set):
        file_set = []
        week_idx = count_weeks()
        for city in city_set:
            for fuel in fuel_set:
                headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                           'Origin': 'http://www.anp.gov.br',
                           'Content-Type': 'application/x-www-form-urlencoded',
                           'Accept-Encoding': 'gzip, deflate',
                           'Cache-Control': 'max-age=0',
                           'Connection:': 'keep-alive',
                           'Accept': 'text/html',
                           'Referer': 'http://www.anp.gov.br/preco/prc/Resumo_Por_Estado_Municipio.asp'}
                values = {'selSemana': str(week_idx) + '*GAA',
                          'desc_Semana': 'GAA',
                          'cod_semana': str(week_idx),
                          'tipo': '1',
                          'cod_combustivel': str(fuel),
                          'desc_combustivel': 'GAA',
                          'selMunicipio': city}

                r = requests.get('http://www.anp.gov.br/preco/prc/Resumo_Semanal_Posto.asp', data=values,
                                 headers=headers, stream=True)
                if r.status_code == requests.codes.ok:
                    filename = os.path.join(tempfile.tempdir, city + '_' + str(fuel))
                    with open(filename, 'wb') as fd:
                        for chunk in r.iter_content(8192):
                            fd.write(chunk)
                file_set.append(filename)

        return file_set

    @staticmethod
    def process_state_data(file_set):
        city_set = set()
        for path in file_set:
            html_dom = BeautifulSoup(open(path))
            city_dom = html_dom.find('table')

            if city_dom:
                for row_dom in city_dom.find_all('tr')[3:]:
                    link = row_dom.contents[0].contents[0].attrs['href']
                    city_info = link[link.find('\'') + 1:-3]
                    city_set.add(city_info)
        return city_set

    @staticmethod
    def process_city_data(file_set):
        price_list = []
        for path in file_set:
            html_dom = BeautifulSoup(open(path))
            retailer_dom = html_dom.find('table')

            if retailer_dom:
                for row_dom in retailer_dom.find_all('tr')[2:]:
                    ret_info = dict()
                    ret_info['name'] = row_dom.contents[0].text.upper()
                    ret_info['brand'] = row_dom.contents[3].text.upper()
                    ret_info['sale'] = row_dom.contents[4].text
                    price_list.append(ret_info)
        return price_list
