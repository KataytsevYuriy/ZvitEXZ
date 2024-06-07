using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods
{
    internal static class ConvertToString
    {
        public static string DoubleToString(double? data, int decimalCount = 3)
        {
            if (data == null) return "";
            return Math.Round((double)data, decimalCount).ToString().Replace(".", ",");
        }
    }
}
