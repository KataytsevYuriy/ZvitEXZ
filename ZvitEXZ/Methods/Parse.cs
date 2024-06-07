using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    public static class Parse
    {
        public static double ParseDouble(object data)
        {
            return double.Parse(CorrectString(data.ToString()));
        }
        private static string CorrectString(string data)
        {
            return data.Replace(",", ".").Trim();
        }
     }
}
