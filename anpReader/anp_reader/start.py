# -*- coding: utf-8 -*-

import argparse
import os
import tempfile
import json

from anp_reader import __version__, __description__, log
from anp_reader.modules.price import PriceController
from anp_reader.modules.product import PRODUCT_TYPES
from modules.retailer import RetailerController


def main():
    log.info("anp_reader v" + __version__)
    parser = argparse.ArgumentParser(
        description=__description__)

    parser.add_argument('-s', '--state', nargs='*',
                        help='Process prices from states',
                        required=True)

    parser.add_argument('-r', '--retailer', action='store_true',
                        help='Process retailers data',
                        required=False)

    parser.add_argument('-p', '--price', action='store_true',
                        help='Process price data',
                        required=False)

    args = parser.parse_args()
    state_set = set(args.state)

    if args.retailer:
        retailer_ctrl = RetailerController()

        # fuel_set = set(map(lambda x: x[0], PRODUCT_TYPES.values()))
        # fuel_set = [PRODUCT_TYPES[u'GASOLINA C COMUM'][0]]
        fuel_set = [0]

        file_set = retailer_ctrl.extract_data(state_set, fuel_set)
        # cnpj_set = retailer_ctrl.extract_cnpj(file_set)
        # file_set = retailer_ctrl.download_cnpj(cnpj_set)
        # retailer_map = retailer_ctrl.process_cnpj(file_set)

        # retailer_ctrl.process_address_and_save(retailer_map)

    if args.price:
        price_ctrl = PriceController()

        fuel_set = set(map(lambda x: x[1], PRODUCT_TYPES.values()))
        # fuel_set = [PRODUCT_TYPES[u'GASOLINA C COMUM'][1]]

        price_ctrl.process_state_data_and_save(state_set, fuel_set)

    filename = os.path.join(tempfile.tempdir, 'retailer.json')
    with open(filename, 'r') as infile:
        data = json.load(infile)
        log.info(data)

    filename = os.path.join(tempfile.tempdir, 'price.json')
    with open(filename, 'r') as infile:
        data = json.load(infile)
        log.info(data)
