using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ListFlanetsToMassive
    {
        public string[,] Convert(List<Flanets> flantsy)
        {
            if (flantsy.Count == 0) return new string[0, 0];
            string[,] res = new string[flantsy.Count, 13];
            int i = 0;
            foreach (Flanets flanets in flantsy)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = flanets.ObjectName;
                res[i, 2] = flanets.BuildingDate;
                res[i, 3] = flanets.FlanetsPlace;
                res[i, 4] = flanets.MontageType;
                res[i, 5] = "";
                res[i, 6] = ConvertToString.FloatToString(flanets.UbeforeOn);
                res[i, 7] = ConvertToString.FloatToString(flanets.UafterOn);
                res[i, 8] = ConvertToString.FloatToString(flanets.UbeforeOff);
                res[i, 9] = ConvertToString.FloatToString(flanets.UafterOff);
                res[i, 10] = "";
                res[i, 11] = flanets.GetAtestation();
                res[i, 12] = "";
                i++;
            }
            return res;
        }
    }
}
