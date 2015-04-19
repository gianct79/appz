/*
* Copyright 1979-2012 Giancarlo Tomazelli. All Rights Reserved. 
*
* Do not re-use without permission.
*/

using System;
using System.Security.Cryptography;
using System.Text;
using NLog;

namespace Com.Gt.SomSc.Common.Crypto
{
    public class HashingUtils
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static string Hash(string plain)
        {
            logger.Info("Hashing string \"{0}\"...", plain);

            if (string.IsNullOrEmpty(plain))
                return string.Empty;

            using (MD5 md5 = MD5.Create())
            {
                return Convert.ToBase64String(md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(plain)));
            }
        }
    }
}
