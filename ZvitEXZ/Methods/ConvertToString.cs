using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods
{
    internal static class ConvertToString
    {
        public static string FloatToString(float? data)
        {
            if (data == null) return "";
            return Math.Round((float)data, 3).ToString().Replace(".", ",");
        }
    }
}
