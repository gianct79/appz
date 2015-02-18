# -*- coding: utf-8 -*-
import os
import tempfile
import json

from bs4 import BeautifulSoup
import requests

from anp_reader.modules.product import PRODUCT_TYPES
from anp_reader.modules.util import remove_punctuation, remove_accents


class RetailerController():
    def __init__(self):
        pass

    @staticmethod
    def download_data(state_set, product_set):
        file_set = []
        for state in state_set:
            state = state.upper()
            for product in product_set:
                headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                           'Origin': 'http://www.anp.gov.br',
                           'Content-Type': 'application/x-www-form-urlencoded',
                           'Accept-Encoding': 'gzip, deflate',
                           'Cache-Control': 'max-age=0',
                           'Connection:': 'keep-alive',
                           'Accept': 'text/html'}
                product = str(product)
                values = {'sCnpj': '',
                          'sRazaoSocial': '',
                          'sEstado': state,
                          'sMunicipio': '0',
                          'sBandeira': '0',
                          'sProduto': product,
                          'sTipodePosto': '0',
                          'hPesquisar': 'PESQUISAR'}

                r = requests.head('http://www.anp.gov.br/postos/consulta.asp', data=values, headers=headers)
                if r.status_code == requests.codes.ok:
                    headers_dw = headers
                    headers_dw['Referer'] = 'http://www.anp.gov.br/postos/consulta.asp'
                    headers_dw['Cookie'] = r.headers.get('set-cookie', None)

                    r = requests.get('http://www.anp.gov.br/postos/GeraExcel.asp', data={'Submit1': 'Exportar'},
                                     headers=headers_dw, stream=True)
                    if r.status_code == requests.codes.ok:
                        filename = os.path.join(tempfile.tempdir, state + '_' + product)
                        with open(filename, 'wb') as fd:
                            for chunk in r.iter_content(8192):
                                fd.write(chunk)
                        file_set.append(filename)

        return file_set

    @staticmethod
    def extract_cnpj(file_set):
        cnpj_set = set()
        for path in file_set:
            html_dom = BeautifulSoup(open(path))
            station_dom = html_dom.find_all('table')[1]

            if station_dom:
                for row_dom in station_dom.find_all('tr')[1:]:
                    cnpj = remove_punctuation(row_dom.contents[4].text)
                    cnpj_set.add(cnpj)

        return cnpj_set

    @staticmethod
    def download_cnpj(cnpj_set):
        file_set = []
        for cnpj in cnpj_set:
            headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                       'Origin': 'http://www.anp.gov.br',
                       'Content-Type': 'application/x-www-form-urlencoded',
                       'Accept-Encoding': 'gzip, deflate',
                       'Cache-Control': 'max-age=0',
                       'Connection:': 'keep-alive',
                       'Accept': 'text/html'}
            values = {'sCnpj': cnpj,
                      'sRazaoSocial': '',
                      'sEstado': '0',
                      'sMunicipio': '0',
                      'sBandeira': '0',
                      'sProduto': '0',
                      'sTipodePosto': '0',
                      'hPesquisar': 'PESQUISAR'}

            r = requests.get('http://www.anp.gov.br/postos/consulta.asp', data=values, headers=headers, stream=True)
            if r.status_code == requests.codes.ok:
                filename = os.path.join(tempfile.tempdir, cnpj)
                with open(filename, 'wb') as fd:
                    for chunk in r.iter_content(8192):
                        fd.write(chunk)

                html_dom = BeautifulSoup(open(filename))
                retailer_dom = html_dom.find('input', {'name': 'i1'})

                if retailer_dom:
                    headers_dw = headers
                    headers_dw['Referer'] = 'http://www.anp.gov.br/postos/consulta.asp'
                    headers_dw['Cookie'] = r.headers.get('set-cookie', None)

                    values_dw = {'Cod_inst': retailer_dom.attrs['value'],
                                 'estado': '0',
                                 'municipio': '0'}

                    r = requests.get('http://www.anp.gov.br/postos/resultado.asp', data=values_dw,
                                     headers=headers_dw, stream=True)
                    if r.status_code == requests.codes.ok:
                        filename = os.path.join(tempfile.tempdir, cnpj)
                        with open(filename, 'wb') as fd:
                            for chunk in r.iter_content(8192):
                                fd.write(chunk)
                        file_set.append(filename)

        return file_set

    @staticmethod
    def process_cnpj(file_set):
        retailer_map = dict()
        for path in file_set:
            html_dom = BeautifulSoup(open(path))
            retailer_dom = html_dom.find_all('table')[3]

            if retailer_dom:
                row_dom = retailer_dom.find_all('tr')[4:-3]

                cnpj = remove_punctuation(row_dom[0].contents[3].text)
                address = row_dom[3].contents[2].text.strip()
                address_ex = row_dom[4].contents[2].text.strip()
                if address_ex:
                    address += ' ' + address_ex

                retailer_info = {
                    'company_name': row_dom[1].contents[2].text.strip().upper(),
                    'address': address.upper(),
                    'city': remove_accents(row_dom[6].contents[2].text.strip().upper()),
                    'zip': row_dom[7].contents[2].text.strip().upper(),
                    'brand': row_dom[10].contents[2].text.strip().upper()
                }

                product_info = []
                for product_row in row_dom[14:]:
                    product = remove_accents(product_row.contents[1].text.strip().upper())
                    if product in PRODUCT_TYPES:
                        product_info.append(PRODUCT_TYPES[product][0])

                retailer_info['products'] = product_info
                retailer_map[cnpj] = retailer_info

        return retailer_map

    @staticmethod
    def process_address_and_save(retailer_map):
        for cnpj, retailer in retailer_map.iteritems():
            headers = {'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; Windows NT)',
                       'Accept-Language': 'pt-BR'}
            full_address = retailer['address'] + ', ' + retailer['city'] + ', ' + ', BRASIL'
            url = 'https://maps.googleapis.com/maps/api/geocode/json?address=%s&sensor=false' % full_address

            r = requests.get(url, headers=headers)
            if r.status_code == requests.codes.ok:
                address = r.json()
                if address['status'] == 'OK':
                    retailer['location'] = address['results'][0]['geometry']['location']
                    retailer['formatted_address'] = address['results'][0]['formatted_address']

        filename = os.path.join(tempfile.tempdir, 'retailer.json')
        with open(filename, 'w') as outfile:
            json.dump(retailer_map, outfile)
