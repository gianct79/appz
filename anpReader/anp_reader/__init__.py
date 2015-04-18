# -*- coding: utf-8 -*-

import os
import logging
import getpass
import tempfile

__version__ = '0.0.1'
__author__ = 'Giancarlo Tomazelli'
__author_username__ = 'gianct79'
__author_email__ = 'gianct79@gmail.com'
__description__ = 'Brazilian ANP gas station and price processor.'

log_filename = os.path.join(tempfile.gettempdir(),
                            'anp_reader-' + getpass.getuser() + '.log')
log_format = '%(asctime)s %(levelname)-5s '
log_format += '%(filename)+12s:%(lineno)03d %(message)s (%(name)s)'

logging.basicConfig(level=logging.DEBUG,
                    format=log_format,
                    filename=log_filename,
                    filemode='a')
# define a Handler which writes INFO messages or higher to the sys.stderr
console = logging.StreamHandler()
console.setLevel(logging.INFO)
# set a format which is simpler for console use
formatter = logging.Formatter(log_format)
# tell the handler to use this format
console.setFormatter(formatter)
# add the handler to the root logger
# logging.getLogger('').addHandler(console)

log = logging.getLogger('anp_reader')


def __path(filename):
    return os.path.join(os.path.dirname(os.path.realpath(__file__)), filename)

# Jenkins
if os.getenv("BUILD_NUMBER"):
    file_ = open(__path('build.info'), 'w')
    file_.write(os.getenv("BUILD_NUMBER"))
    file_.close()

__build__ = '0'
if os.path.exists(__path('build.info')):
    __build__ = open(__path('build.info')).read().strip()

__version__ = __version__ + '.' + __build__
