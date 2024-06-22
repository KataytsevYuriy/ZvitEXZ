using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertVymirKozhuhToArray
    {
        public object[,] Convert(List<RoadKozhuh> roadKozhuhs)
        {
            List<RoadKozhuh> data = new List<RoadKozhuh>();
            if (roadKozhuhs.Count > 0) data = roadKozhuhs.Where(el => el.RoadType == RoadTypes.automobile || el.RoadType == RoadTypes.train).ToList();
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 12];
            int i = 0;
            foreach (RoadKozhuh item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = ConvertToString.DoubleToString(item.Km);
                res[i, 2] = item.RoadName;
                res[i, 3] = ConvertToString.DoubleToString(item.KozhuhLength);
                res[i, 4] = item.ProtectionType;
                res[i, 5] = item.CheckPlace;
                res[i, 6] = item.UtzOn;
                res[i, 7] = item.UkozhOn;
                res[i, 8] = item.UtzOff;
                res[i, 9] = item.UkozhOff;
                res[i, 10] = item.AtestationKontakt;
                res[i, 11] = "";
                i++;
            }
            return res;
        }
    }
}
