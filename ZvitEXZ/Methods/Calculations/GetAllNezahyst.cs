using System.Collections.Generic;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;
using System.Linq;
using ZvitEXZ.Models.AcadModels;


namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllNezahyst
    {
        public List<Nezahyst> CalculateNezah(List<AcadZamer> zamers, List<Zamer> orientirs, List<NeObstegeno> neObstegenos, double uNezah = 0.9, double uPerezah = 2.5)
        {
            //double crossLine = 0.9;
            Crossing crossingNezah = new Crossing(uNezah);
            Crossing crossingPerezah = new Crossing(uPerezah);
            int flag = 0; //0 - Null, 1 - защищено, 2 - незахист , 3-перезахист
            double kmStart = 0;
            double? lastUtz = 0;
            double lastKm = 0;
            double? minUtz = 0;
            string gpsNMinUtz = "";
            string gpsEMinUtz = "";
            List<Nezahyst> res = new List<Nezahyst>();
            foreach (AcadZamer zamer in zamers)
            {
                if (zamer.Value == null) continue;
                if (flag == 2 && lastKm + ProjectConstants.StepVymiryvannya < zamer.Km)
                {
                    Nezahyst nezahyst = new Nezahyst(kmStart, lastKm, (double)minUtz, gpsNMinUtz, gpsEMinUtz);
                    res.Add(nezahyst);
                    flag = 0;
                }
                if (zamer.Value < uNezah) // незахист
                {
                    if (flag == 0)
                    {
                        kmStart = zamer.Km;
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (flag == 1)
                    {
                        kmStart = crossingNezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Value, zamer.Km);
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (minUtz > zamer.Value) //if flag ==2
                    {
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    flag = 2;
                }
                else if (zamer.Value > uPerezah) // перезахист
                {
                    if (flag == 0)
                    {
                        kmStart = zamer.Km;
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (flag == 1)
                    {
                        kmStart = crossingPerezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Value, zamer.Km);
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    else if (minUtz < zamer.Value) //if flag ==2
                    {
                        minUtz = zamer.Value;
                        gpsNMinUtz = zamer.GpsN;
                        gpsEMinUtz = zamer.GpsE;
                    }
                    flag = 3;
                }
                else  //защищено
                {
                    if (flag == 2)
                    {
                        double kmEnd = crossingNezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Value, zamer.Km);
                        if (kmEnd > kmStart)
                        {
                            Nezahyst nezahyst = new Nezahyst(kmStart, kmEnd, (double)minUtz, gpsNMinUtz, gpsEMinUtz);
                            res.Add(nezahyst);
                        }
                    }
                    else if (flag == 3)
                    {
                        double kmEnd = crossingPerezah.GetCrossing((double)lastUtz, lastKm, (double)zamer.Value, zamer.Km);
                        if (kmEnd > kmStart)
                        {
                            Nezahyst nezahyst = new Nezahyst(kmStart, kmEnd, (double)minUtz, gpsNMinUtz, gpsEMinUtz, true);
                            res.Add(nezahyst);
                        }
                    }
                    flag = 1;
                }
                lastUtz = zamer.Value;
                lastKm = zamer.Km;
            }
            if (flag == 2)
            {
                if (lastKm > kmStart) res.Add(new Nezahyst(kmStart, lastKm, (double)minUtz, gpsNMinUtz, gpsEMinUtz));
            }
            else if (flag == 3)
            {
                if (lastKm > kmStart) res.Add(new Nezahyst(kmStart, lastKm, (double)minUtz, gpsNMinUtz, gpsEMinUtz, true));
            }
            res = TrimNeobstegeno(res, neObstegenos);
            res = AddPotencial(res, zamers);
            CheckEmpdyData(res);
            res = AddOrientirs(res, orientirs);
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
        private List<Nezahyst> AddPotencial(List<Nezahyst> data, List<AcadZamer> zamers)
        {
            foreach (Nezahyst nezahyst in data)
            {
                if (nezahyst.MinUtz != 0) continue;
                double minUtz = 0;
                string gpsN = "";
                string gpsE = "";
                foreach (AcadZamer zamer in zamers)
                {
                    if (zamer.Value == null) continue;
                    if (zamer.Km < nezahyst.KmStart) continue;
                    if (zamer.Km > nezahyst.KmEnd) break;
                    if (minUtz == 0)
                    {
                        minUtz = zamer.Value ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        continue;
                    }
                    if (!nezahyst.IsPerezahyst && minUtz > zamer.Value)
                    {
                        minUtz = zamer.Value ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                    }
                    else if (nezahyst.IsPerezahyst && minUtz < zamer.Value)
                    {
                        minUtz = zamer.Value ?? 0;
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
            foreach (Nezahyst nezahyst in nezahysts)
            {
                if (nezahyst.MinUtz == 0) Logs.AddError($"Незахист км {nezahyst.KmStart} - км {nezahyst.KmEnd} невосможно установить минимальный защитный потренциал");
            }
        }
        private List<Nezahyst> AddOrientirs(List<Nezahyst> nezahysts, List<Zamer> zamers)
        {
            AddOrientir addOrientir = new AddOrientir();
            List<Zamer> orientirs = zamers.Where(z => z.IsOrientir == true).ToList();
            foreach (Nezahyst nezahyst in nezahysts)
            {
                nezahyst.Orientir = addOrientir.Add(orientirs, nezahyst.KmStart, nezahyst.KmEnd);
            }
            return nezahysts;
        }
    }
}
