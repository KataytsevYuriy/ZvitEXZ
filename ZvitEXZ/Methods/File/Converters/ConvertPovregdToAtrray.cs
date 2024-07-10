using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertPovregdToAtrray
    {
        public object[,] Convert(List<Povregdenya> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 10];
            int i = 0;
            foreach (Povregdenya item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = Math.Round(item.KmStart * 1000).ToString();
                res[i, 2] = Math.Round(item.KmEnd * 1000).ToString();
                res[i, 3] = Math.Round((item.KmEnd - item.KmStart) * 1000).ToString();
                res[i, 4] = item.GpsN;
                res[i, 5] = item.GpsE;
                res[i, 6] = ConvertToString.DoubleToString(Math.Round(item.MaxGradient * 1000));
                res[i, 7] = $"-{ConvertToString.DoubleToString(item.UMaxGradient)}";
                res[i, 8] = item.Cherga.ToString();
                res[i, 9] = "";
                i++;
            }
            return res;
        }
    }
}
