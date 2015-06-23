/*
* Copyleft 1979-2015 GTO Inc. All rights reversed.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace checkBook
{
    public class Extension
    {
        static string[] units;
        static string[] d_units;
        static string[] c_units;

        static Extension()
        {
            units = new string[] { string.Empty, "um", "dois", "três", "quatro", "cinco",
                "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze",
                "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
            d_units = new string[] { string.Empty, string.Empty, "vinte", "trinta", "quarenta",
                "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
            c_units = new string[] { string.Empty, "cento", "duzentos", "trezentos", "quatrocentos",
                "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        }

        public static string ToLongString(int value)
        {
            if (value == 100)
                return "cem";

            StringBuilder sb = new StringBuilder();

            int d;
            int c = Math.DivRem(value, 100, out d);
            if (c > 0)
            {
                sb.Append(c_units[c]);
                if (d > 0)
                    sb.Append(" e ");
            }

            if (d < 20)
            {
                sb.Append(units[d]);
            }
            else
            {
                int u;
                d = Math.DivRem(d, 10, out u);
                if (d > 0)
                {
                    sb.Append(d_units[d]);
                    if (u > 0)
                        sb.Append(" e ");
                }
                if (u > 0)
                    sb.Append(units[u]);
            }

            return sb.ToString();
        }
    }

    public static class TypeExtensions
    {
        public static string ToLongString(this Decimal value)
        {
            if (value <= Decimal.Zero || value > new Decimal(999999.99))
                return string.Empty;

            int v = Decimal.ToInt32(value);

            if (v == 1)
                return "um real";

            StringBuilder sb = new StringBuilder();

            int r;
            int d = Math.DivRem(v, 1000, out r);
            if (d > 0)
            {
                sb.Append(Extension.ToLongString(d));
                sb.Append(" mil");
            }
            if (r > 0)
            {
                if (sb.Length > 0)
                    sb.Append(" e ");
                sb.Append(Extension.ToLongString(r));
            }

            return sb.Append(" reais").ToString();
        }

        public static bool EqualsIgnoreCase(this string str, string v)
        {
            return str.Equals(v, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
