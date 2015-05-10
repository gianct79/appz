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
