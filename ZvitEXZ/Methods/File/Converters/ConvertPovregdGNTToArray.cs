using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertPovregdGNTToArray
    {
        public object[,] Convert(List<PovregdenyaGNT> povregdenays)
        {
            if (povregdenays.Count == 0) return new string[0, 0];
            object[,] res = new object[povregdenays.Count, 5];
            int i = 0;
            foreach (PovregdenyaGNT povr in povregdenays)
            {
                res[i, 0] = povr.Number;
                res[i, 1] = Math.Round(povr.KmStart * 1000, 0);
                res[i, 2] = Math.Round(povr.KmEnd * 1000, 0);
                res[i, 3] = Math.Round(povr.PovregdLenght * 1000);
                res[i, 4] = povr.Bal == 0 ? "-" : ConvertToString.DoubleToString(povr.Bal);
                i++;
            }
            return res;
        }
    }
}
