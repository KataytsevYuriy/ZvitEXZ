using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertNezahToArray
    {
        public object[,] Convert(List<Nezahyst> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 8];
            int i = 0;
            foreach (Nezahyst item in data)
            {
                res[i, 0] = Math.Round(item.KmStart * 1000).ToString();
                res[i, 1] = Math.Round(item.KmEnd * 1000).ToString();
                res[i, 2] = Math.Round((item.KmEnd - item.KmStart) * 1000).ToString();
                if (item.MinUtz == 0)
                {
                    res[i, 3] = "-";
                }
                else
                {
                    res[i, 3] = $"-{ConvertToString.DoubleToString(item.MinUtz)}";
                }
                res[i, 4] = "";
                res[i, 5] = "";
                res[i, 6] = String.IsNullOrEmpty(item.MinGpsN) ? "-" : item.MinGpsN;
                res[i, 7] = String.IsNullOrEmpty(item.MinGpsE) ? "-" : item.MinGpsE;
                i++;
            }
            return res;
        }
    }
}
