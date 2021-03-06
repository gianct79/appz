﻿/*
* Copyleft 1979-2015 GTO Inc. All rights reversed.
*/

using System;
using System.Collections.Generic;

namespace checkBook
{
    public class Check
    {
        public string Number { get; set; }
        public Decimal Value { get; set; }
        public string PayTo { get; set; }
        public string Place { get; set; }
        public DateTime Date { get; set; }

        public Check()
        {
            this.Value = Decimal.One;
            this.Date = DateTime.Now;
        }
    }

    public class Checkbook : List<Check>
    {
    }
}
