using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertKornebToArray
    {
        public object[,] Convert(List<KorNebezpechny> kornebs)
        {
            int count = kornebs.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 4];
            int i = 0;
            foreach (KorNebezpechny korneb in kornebs)
            {
                res[i, 0] = Math.Round(korneb.KmStart * 1000);//.ToString();
                res[i, 1] = Math.Round(korneb.KmEnd * 1000);//.ToString();
                res[i, 2] = Math.Round((korneb.KmEnd - korneb.KmStart) * 1000);//.ToString();
                res[i, 3] = korneb.Description;
                i++;
            }
            return res;
        }
    }
}
