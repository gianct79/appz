# -*- coding: utf-8 -*-

import argparse
import os

import jsonpickle

from anp_reader import __version__, __description__, log
from anp_reader.modules.price import PriceController
from anp_reader.modules.product import FuelType
from modules.retailer import RetailerController, Retailer


def main():
    log.info("anp_reader v" + __version__)
    parser = argparse.ArgumentParser(
        description=__description__)

    parser.add_argument('-s', '--state', nargs='*',
                        help='Process prices from States',
                        required=True)

    parser.add_argument('-r', '--retailer', action='store_true',
                        help='Process retailers data',
                        required=False)

    parser.add_argument('-p', '--price', action='store_true',
                        help='Process price data',
                        required=False)

    args = parser.parse_args()
    state_set = set(args.state)

    base_dir = '/home/giancarlo/Workspace/anp_reader/data/retailer'

    if args.retailer:
        retailer_ctrl = RetailerController()

        # fuel_set = set(map(lambda x: x[0], FuelType.types.values()))
        fuel_set = [FuelType.types['GASOLINA_PRM'][0]]

        file_set = retailer_ctrl.download_data(state_set, fuel_set)
        # file_set = retailer_ctrl.download_data(['0'], ['0'])
        cnpj_set = retailer_ctrl.extract_cnpj(file_set)
        # cnpj_set = ['93489243002917']
        file_set = retailer_ctrl.download_cnpj(cnpj_set)
        # file_set = ['/tmp/93489243002917']
        retailer_set = retailer_ctrl.process_cnpj(file_set)

        retailer_ctrl.process_address_and_save(retailer_set, os.path.join(base_dir, args.state[0] + '.json'))

    if args.price:
        price_ctrl = PriceController()

        fuel_set = set(map(lambda x: x[1], FuelType.types.values()))

        file_set = price_ctrl.download_state_data(state_set, fuel_set)
        city_set = price_ctrl.process_state_data(file_set)
        file_set = price_ctrl.download_city_data(city_set, fuel_set)

        # base_dir = '/home/giancarlo/Workspace/anp_reader/tests/city'
        # file_set = []
        # for f in os.listdir(base_dir):
        # file_set.append(os.path.join(base_dir, f))

        price_set = price_ctrl.process_city_data(file_set)

        for price in price_set:
            log.info(price)

    # datafile = os.path.join(base_dir, args.state[0] + '.json')

    # with open(datafile, 'r') as infile:
    # data = jsonpickle.decode(infile.read())
    #    log.info(data)


