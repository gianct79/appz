# -*- coding: utf-8 -*-

import argparse

from anp_reader import __version__, __description__, log
from anp_reader.modules.price import PriceController
from anp_reader.modules.product import PRODUCT_TYPES
from modules.retailer import RetailerController


def main():
    log.info("anp_reader v" + __version__)
    parser = argparse.ArgumentParser(
        description=__description__)

    parser.add_argument('-u', '--uf', nargs='*',
                        help='Federation units to process',
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

        # product_set = set(map(lambda x: x[0], PRODUCT_TYPES.values()))
        # product_set = [PRODUCT_TYPES[u'GASOLINA C COMUM'][0]]
        product_set = [0]

        retailer_ctrl.download_retailers(state_set, product_set)
        retailer_ctrl.process_retailers(state_set)

    if args.price:
        price_ctrl = PriceController()

        product_set = set(map(lambda x: x[1], PRODUCT_TYPES.values()))
        # product_set = [PRODUCT_TYPES[u'GASOLINA C COMUM'][1]]

        price_ctrl.download_prices(state_set, product_set)
        price_ctrl.process_prices(state_set)
