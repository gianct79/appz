/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.IO;
using System.Text;
using NLog;

namespace Com.Gt.SomSc.Common.Log
{
    public class LinqLogger : TextWriter
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private Encoding enconding;

        public LinqLogger()
        {
            NewLine = string.Empty;
        }

        public override Encoding Encoding
        {
            get
            {
                if (enconding == null)
                {
                    enconding = new UnicodeEncoding(false, false);
                }
                return enconding;
            }
        }

        public override void Write(string value)
        {
            if (!string.IsNullOrEmpty(value))
                logger.Trace(value);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Write(new String(buffer, index, count));
        }
    }
}
