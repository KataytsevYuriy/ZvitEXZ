using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertNeonrmHlubToArray
    {
        public string[,] Convert(List<NenormHlubyna> nenormHlubynas)
        {
            if (nenormHlubynas.Count == 0) return new string[0, 0];
            string[,] res = new string[nenormHlubynas.Count, 9];
            int i = 0;
            foreach (NenormHlubyna nenormHlubyna in nenormHlubynas)
            {
                res[i, 0] = ConvertToString.DoubleToString(nenormHlubyna.KmStart * 1000, 0);
                res[i, 1] = ConvertToString.DoubleToString(nenormHlubyna.KmEnd * 1000, 0);
                res[i, 2] = ConvertToString.DoubleToString((nenormHlubyna.KmEnd - nenormHlubyna.KmStart) * 1000, 0);
                res[i, 3] = ConvertToString.DoubleToString(nenormHlubyna.HlubMin);
                res[i, 4] = ConvertToString.DoubleToString(nenormHlubyna.HlubNorma);
                res[i, 5] = "";
                res[i, 6] = nenormHlubyna.GpsN;
                res[i, 7] = nenormHlubyna.GpsE;
                res[i, 8] = "";

                i++;
            }
            return res;
        }
    }
}
