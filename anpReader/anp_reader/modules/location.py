# -*- coding: utf-8 -*-

import os
import tempfile
import Queue
import threading
import json

import requests

from anp_reader import log


class LocationController:
    def __init__(self):
        self.data_dir = os.path.join(tempfile.tempdir, 'retailers')

        self.retailer_queue = Queue.Queue()

        self.retailer_map = {}
        self.retailer_lock = threading.Lock()

        self.headers = {
            'User-Agent': 'Mozilla/4.0 (compatible; MSIE 5.5; ''Windows NT)',
            'Accept-Language': 'pt-BR'}

    def process_retailers(self):
        for i in range(5):
            t = threading.Thread(target=self._process_retailer)
            t.daemon = True
            t.start()

        filename = os.path.join(self.data_dir, 'retailers.json')
        with open(filename, 'r') as infile:
            self.retailer_map = json.load(infile)

            count = 0
            for key, retailer in self.retailer_map.iteritems():
                if retailer.get('location', None) is None:
                    self.retailer_queue.put({'key': key, 'retailer': retailer})
                    count += 1
                if count == 2500:
                    break

        self.retailer_queue.join()

        filename = os.path.join(self.data_dir, 'retailers.json')
        with open(filename, 'w') as outfile:
            json.dump(self.retailer_map, outfile)

        log.info('written %d retailer(s)' % len(self.retailer_map))

    def _process_retailer(self):
        while True:
            item = self.retailer_queue.get()
            try:
                key = item['key']
                retailer = item['retailer']
                if retailer.get('location', None) is not None:
                    continue

                full_address = '%s, %s, BRASIL' % (retailer['address'].replace('\'', ''), retailer['city'].replace('\'', ''))

                url = 'https://maps.googleapis.com/maps/api/geocode/json'
                params = {'address': full_address, 'key': 'AIzaSyCs7WX-nxB0mmLmHG8mXrPRSYV-zfbXsaM'}

                r = requests.get(url, params=params, headers=self.headers)
                if r.status_code == requests.codes.ok:
                    address = r.json()
                    if address['status'] == 'OK':
                        retailer['location'] = address['results'][0]['geometry']['location']
                        retailer['formatted_address'] = address['results'][0]['formatted_address']

                    self.retailer_lock.acquire()
                    self.retailer_map[key] = retailer
                    self.retailer_lock.release()
            except Exception as ex:
                log.error(ex.message)

            finally:
                self.retailer_queue.task_done()
