# -*- coding: utf-8 -*-
import unicodedata
import sys
from datetime import date

tbl = dict.fromkeys(i for i in xrange(sys.maxunicode)
                    if unicodedata.category(unichr(i)).startswith('P'))


def remove_punctuation(text):
    return text.translate(tbl).strip()


def count_weeks(from_date=date.today()):
    d0 = date(1999, 7, 1)
    delta = from_date - d0
    return (delta.days / 7) + 1
