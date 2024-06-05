using System.Collections.Generic;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;


namespace ZvitEXZ.Methods.Calculations
{
    internal class GetNezahyst
    {
        public List<Nezahyst> CalculateNezah(List<Zamer> zamers)
        {
            float crossLine = (float)0.9;
            Crossing crossingNezah = new Crossing(crossLine);
            int flag = 0; //0 - Null, 1 - защищено, 2 - незахист
            float kmStart = 0;
            float? lastUtz = 0;
            float lastKm = 0;
            float? minUtz = 0;
            string gpsNMinUtz = "";
            string gpsEMinUtz = "";
            List<Nezahyst> res = new List<Nezahyst>();
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Utz == null) continue;
                if (zamer.Km - lastKm > ProjectConstants.StepVymiryvannya)
                {
                    if (lastKm > kmStart)
                    {
                        Nezahyst nezahyst = new Nezahyst(kmStart, lastKm, (float)minUtz, gpsNMinUtz, gpsEMinUtz);
                        res.Add(nezahyst);
                        flag = 0;
                    }
                }
                if (zamer.Utz < crossLine) // незахист
                {
                    if (flag == 0)
                    {
                        kmStart = zamer.Km;
                        minUtz = zamer.Utz;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (flag == 1)
                    {
                        kmStart = crossingNezah.GetCrossing((float)lastUtz, lastKm, (float)zamer.Utz, zamer.Km);
                        minUtz = zamer.Utz;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (minUtz > zamer.Utz) //if flag ==2
                    {
                        minUtz = zamer.Utz;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    flag = 2;
                }
                else  //защищено
                {
                    if (flag == 2)
                    {
                        float kmEnd = crossingNezah.GetCrossing((float)lastUtz, lastKm, (float)zamer.Utz, zamer.Km);
                        if (kmEnd > kmStart)
                        {
                            Nezahyst nezahyst = new Nezahyst(kmStart, kmEnd, (float)minUtz, gpsNMinUtz, gpsEMinUtz);
                            res.Add(nezahyst);
                        }
                    }
                    flag = 1;
                }
                lastUtz = zamer.Utz;
                lastKm = zamer.Km;
            }
            if (flag == 2)
            {
                if (lastKm > kmStart) res.Add(new Nezahyst(kmStart, lastKm, (float)minUtz, gpsNMinUtz, gpsEMinUtz));
            }
            return res;
        }
    }
}
