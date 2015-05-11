# -*- coding: utf-8 -*-
import unicodedata
import sys
from datetime import date

tbl = dict.fromkeys(i for i in xrange(sys.maxunicode)
                    if unicodedata.category(unichr(i)).startswith('P'))


def remove_punctuation(text):
    return unicode(text).translate(tbl)


def remove_accents(text):
    nkfd_form = unicodedata.normalize('NFKD', text)
    return u''.join([c for c in nkfd_form if not unicodedata.combining(c)])


def count_weeks(from_date=date.today()):
    d0 = date(1999, 7, 1)
    delta = from_date - d0
    return (delta.days / 7) + 1


state_map = {
    u'acre': 'AC',
    u'alagoas': 'AL',
    u'amapa': 'AP',
    u'amazonas': 'AM',
    u'bahia': 'BA',
    u'ceara': 'CE',
    u'distrito federal': 'DF',
    u'espirito santo': 'ES',
    u'goias': 'GO',
    u'maranhao': 'MA',
    u'mato grosso': 'MT',
    u'mato grosso do sul': 'MS',
    u'minas gerais': 'MG',
    u'para': 'PA',
    u'paraiba': 'PB',
    u'parana': 'PR',
    u'pernambuco': 'PE',
    u'piaui': 'PI',
    u'rio de janeiro': 'RJ',
    u'rio grande do norte': 'RN',
    u'rio grande do sul': 'RS',
    u'rondonia': 'RO',
    u'roraima': 'RR',
    u'santa catarina': 'SC',
    u'sao paulo': 'SP',
    u'sergipe': 'SE',
    u'tocantins': 'TO'
}
