using System.Collections.Generic;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;
using System.Linq;


namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllNezahyst
    {
        public List<Nezahyst> CalculateNezah(List<Zamer> zamers, List<NeObstegeno> neObstegenos)
        {
            double crossLine = 0.9;
            Crossing crossingNezah = new Crossing(crossLine);
            int flag = 0; //0 - Null, 1 - защищено, 2 - незахист
            double kmStart = 0;
            double? lastUtz = 0;
            double lastKm = 0;
            double? minUtz = 0;
            string gpsNMinUtz = "";
            string gpsEMinUtz = "";
            List<Nezahyst> res = new List<Nezahyst>();
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Utz == null) continue;
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
                        kmStart = crossingNezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Utz, zamer.Km);
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
                        double kmEnd = crossingNezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Utz, zamer.Km);
                        if (kmEnd > kmStart)
                        {
                            Nezahyst nezahyst = new Nezahyst(kmStart, kmEnd, (double)minUtz, gpsNMinUtz, gpsEMinUtz);
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
                if (lastKm > kmStart) res.Add(new Nezahyst(kmStart, lastKm, (double)minUtz, gpsNMinUtz, gpsEMinUtz));
            }
            res = TrimNeobstegeno(res, neObstegenos);
            res = AddPotencial(res, zamers);
            CheckEmpdyData(res);
            return res;
        }
        private List<Nezahyst> TrimNeobstegeno(List<Nezahyst> data, List<NeObstegeno> neObstegenos)
        {
            List<Nezahyst> res = new List<Nezahyst>();
            foreach (Nezahyst nezahyst in data)
            {
                List<Nezahyst> curNezah = nezahyst.TrimBylist(neObstegenos).Select(el => el as Nezahyst).ToList();
                res.AddRange(curNezah);
            }
            return res;
        }
        private List<Nezahyst> AddPotencial(List<Nezahyst> data, List<Zamer> zamers)
        {
            foreach (Nezahyst nezahyst in data)
            {
                if (nezahyst.MinUtz != 0) continue;
                double minUtz = 0;
                string gpsN = "";
                string gpsE = "";
                foreach(Zamer zamer in zamers)
                {
                    if (zamer.Ugrad == null) continue;
                    if (zamer.Km<nezahyst.KmStart) continue;
                    if(zamer.Km>nezahyst.KmEnd) break;
                    if (minUtz == 0)
                    {
                        minUtz = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        continue;
                    }
                    if (minUtz > zamer.Utz)
                    {
                        minUtz = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                    }
                }
                nezahyst.MinUtz = minUtz;
                nezahyst.MinGpsN = gpsN;
                nezahyst.MinGpsE = gpsE;
            }
            return data;
        }
        private void CheckEmpdyData(List<Nezahyst> nezahysts)
        {
            foreach(Nezahyst nezahyst in nezahysts)
            {
                if (nezahyst.MinUtz == 0) Logs.AddError($"Незахист км {nezahyst.KmStart} - км {nezahyst.KmEnd} невосможно установить минимальный защитный потренциал");
            }
        }
    }
}
