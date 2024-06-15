using System.Collections.Generic;
using System.Linq;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetHruntActivity
    {
        public List<HruntAktivity> Get(List<Zamer> zamers, List<NeObstegeno> neObstegenos)
        {
            List<HruntAktivity> hruntAktivities = new List<HruntAktivity>();
            double kmStart = -1;
            double kmLast = kmStart;
            double kmFinish = -1;
            double RhrLast = -1;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Rhr == null) continue;
                if (kmStart == -1)
                {
                    kmStart = zamer.Km;
                }
                else if ((RhrLast < 20 && zamer.Rhr < 20) || (RhrLast > 50 && zamer.Rhr > 50) ||
                     (zamer.Rhr >= 20 && zamer.Rhr <= 50 && RhrLast >= 20 && RhrLast <= 50))
                {
                    RhrLast = zamer.Rhr ?? 0;
                    kmLast = zamer.Km;
                }
                else
                {
                    double crossLine = 50;
                    if ((RhrLast < 20 && zamer.Rhr >= 20) || ((RhrLast >= 20 && zamer.Rhr < 20))) crossLine = 20;
                    Crossing crossing = new Crossing(crossLine);
                    kmFinish = crossing.GetCrossing(RhrLast, kmLast, (double)zamer.Rhr, zamer.Km);
                    hruntAktivities.Add(new HruntAktivity(kmStart, kmFinish, RhrLast));
                    kmStart = kmFinish;
                }
                RhrLast = zamer.Rhr ?? 0;
                kmLast = zamer.Km;
            }
            if (kmLast > kmStart)
            {
                hruntAktivities.Add(new HruntAktivity(kmStart, kmLast, RhrLast));
            }
            hruntAktivities = TrimNeobstegeno(hruntAktivities, neObstegenos);
            return hruntAktivities;
        }
        private List<HruntAktivity> TrimNeobstegeno(List<HruntAktivity> aktivities, List<NeObstegeno> neObstegenos)
        {
            List<HruntAktivity> res = new List<HruntAktivity>();
            foreach (HruntAktivity hruntAktivity in aktivities)
            {
                double kmStart = hruntAktivity.KmStart;
                foreach (NeObstegeno neObstegeno in neObstegenos)
                {
                    if (hruntAktivity.KmStart > neObstegeno.KmEnd) continue;
                    if (hruntAktivity.KmFinish < neObstegeno.KmStart) break;
                    if (hruntAktivity.KmStart >= hruntAktivity.KmFinish) break;
                    if (hruntAktivity.KmStart < neObstegeno.KmStart)
                    {
                        res.Add(new HruntAktivity(hruntAktivity.KmStart, neObstegeno.KmStart, hruntAktivity.HruntAktivityType));
                        hruntAktivity.KmStart = neObstegeno.KmEnd;
                    }
                    else
                    {
                        hruntAktivity.KmStart = neObstegeno.KmEnd;
                    }
                }
                if (hruntAktivity.KmStart < hruntAktivity.KmFinish) res.Add(hruntAktivity);
            }
            return res;
        }
    }
}
