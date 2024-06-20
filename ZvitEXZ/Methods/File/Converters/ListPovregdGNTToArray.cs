using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ListPovregdGNTToArray
    {
        public string[,] Convert(List<PovregdenyaGNT> povregdenays)
        {
            if (povregdenays.Count == 0) return new string[0, 0];
            string[,] res = new string[povregdenays.Count, 5];
            int i = 0;
            foreach (PovregdenyaGNT povr in povregdenays)
            {
                res[i, 0] = povr.Number.ToString();
                res[i, 1] = ConvertToString.DoubleToString(povr.KmStart * 1000, 0);
                res[i, 2] = ConvertToString.DoubleToString(povr.KmEnd * 1000, 0);
                res[i, 3] = ConvertToString.DoubleToString(Math.Round(povr.PovregdLenght * 1000), 0);
                res[i, 4] = povr.Bal == 0 ? "-" : ConvertToString.DoubleToString(povr.Bal);
                i++;
            }
            return res;
        }
    }
}
