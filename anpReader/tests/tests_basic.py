# -*- coding: utf-8 -*-

""" Example test to check version number """

from nose.tools import assert_equals  # @UnresolvedImport
from anp_reader import __version__


def test_version():
    """ Base test to version method """

    assert_equals(type(__version__), str)
