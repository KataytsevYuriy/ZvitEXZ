using System.Collections.Generic;
using System.Linq;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetHruntActivity
    {
        public List<HruntAktivity> Get(List<Zamer> zamers)
        {
            List<HruntAktivity> hruntAktivities = new List<HruntAktivity>();
            double kmStart = zamers.First().Km;
            double kmLast = kmStart;
            double kmFinish = 0;
            double RhrLast = 0;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Km == kmStart)
                {
                    RhrLast = zamer.Rhr ?? 0;
                    continue;
                }
                if (zamer.Rhr == null) continue;
                if ((RhrLast < 20 && zamer.Rhr < 20) || (RhrLast > 50 && zamer.Rhr > 50) ||
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
                    RhrLast = zamer.Rhr ?? 0;
                }
            }
            if (kmFinish > kmStart)
            {
                hruntAktivities.Add(new HruntAktivity(kmStart, zamers.Last().Km, RhrLast));
            }
            return hruntAktivities;
        }
    }
}
