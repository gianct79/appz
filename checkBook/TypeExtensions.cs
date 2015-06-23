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
        static Dictionary<int, string> units = new Dictionary<int, string>();
        static Dictionary<int, string> d_units = new Dictionary<int, string>();
        static Dictionary<int, string> c_units = new Dictionary<int, string>();

        static Extension()
        {
            units[1] = "um"; units[2] = "dois"; units[3] = "três";
            units[4] = "quatro"; units[5] = "cinco"; units[6] = "seis";
            units[7] = "sete"; units[8] = "oito"; units[9] = "nove";

            d_units[10] = "dez"; d_units[11] = "onze"; d_units[12] = "doze";
            d_units[13] = "treze"; d_units[14] = "quatorze"; d_units[15] = "quinze";
            d_units[16] = "dezesseis"; d_units[17] = "dezessete"; d_units[18] = "dezoito";
            d_units[19] = "dezenove"; d_units[20] = "vinte"; d_units[30] = "trinta";
            d_units[40] = "quarenta"; d_units[50] = "cinquenta"; d_units[60] = "sessenta";
            d_units[70] = "setenta"; d_units[80] = "oitenta"; d_units[90] = "noventa";

            c_units[1] = "cento"; c_units[2] = "duzentos"; c_units[3] = "trezentos";
            c_units[4] = "quatrocentos"; c_units[5] = "quinhentos"; c_units[6] = "seiscentos";
            c_units[7] = "setecentos"; c_units[8] = "oitocentos"; c_units[9] = "novecentos";
        }

        public static string ToLongString(int value)
        {
            StringBuilder sb = new StringBuilder();
            int c = value / 100;
            if (c_units.ContainsKey(c))
            {
                sb.Append(c_units[c]);
                sb.Append(" e ");
            }

            int d = value % 100;
            if (d_units.ContainsKey(d))
            {
                sb.Append(d_units[d]);
            }
            else
            {
                int u;
                d = Math.DivRem(d, 10, out u) * 10;
                if (d_units.ContainsKey(d))
                {
                    sb.Append(d_units[d]);
                    sb.Append(" e ");
                }
                if (units.ContainsKey(u))
                {
                    sb.Append(units[u]);
                }
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
            if (v == 100)
                return "cem reais";

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
