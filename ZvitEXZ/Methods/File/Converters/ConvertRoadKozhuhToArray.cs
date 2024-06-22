using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertRoadKozhuhToArray
    {
        public object[,] Convert(List<RoadKozhuh> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 11];
            int i = 0;
            foreach (RoadKozhuh item in data)
            {
                res[i, 0] = ConvertToString.DoubleToString(item.Km * 1000);
                res[i, 1] = item.RoadName;
                res[i, 2] = item.PvStartProvodUtz;
                res[i, 3] = item.PvEndProvodUkozh;
                res[i, 4] = item.PvEndProvodUtz;
                res[i, 5] = item.PvEndProvodUkozh;
                res[i, 6] = item.SvechaStart;
                res[i, 7] = item.SvechaEnd;
                res[i, 8] = item.Primechanye;
                res[i, 9] = item.Atestation;
                res[i, 10] = item.Recomendation;
                i++;
            }
            return res;
        }
    }
}
