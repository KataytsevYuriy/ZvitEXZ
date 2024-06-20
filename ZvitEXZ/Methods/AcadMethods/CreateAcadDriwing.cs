using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.AcadMethods
{
    internal class CreateAcadDriwing
    {
        double kmStart;
        double xScale;
        public AcadDriwing Create(List<Zamer> zamers, double kmStart = 0, double xScale = 1)
        {
            this.kmStart = kmStart;
            this.xScale = xScale;
            double kmEnd = kmStart + xScale * AcadConstants.LenthByKm * 3;
            List<Zamer> interval = zamers.Where(z => z.Km >= kmStart && z.Km <= kmEnd).ToList();
            List<ListPotencials> listPotencials = new List<ListPotencials>();
            List<Potencial> potencials = new List<Potencial>();
            double kmLast = -1;
            foreach (Zamer zamer in interval)
            {
                if (zamer.Utz == null) continue;
                if (kmLast != -1 && kmLast > zamer.Km - ProjectConstants.StepVymiryvannya)
                {
                    listPotencials.Add(new ListPotencials(potencials));
                    potencials = new List<Potencial>();
                }
                potencials.Add(new Potencial(GetXScale(zamer.Km), zamer.Utz ?? 0));
                kmLast = zamer.Km;
            }
            if (potencials.Count > 1) listPotencials.Add(new ListPotencials(potencials));

            AcadDriwing acadDriwing = new AcadDriwing(listPotencials);
            return acadDriwing;
        }
        private double GetXScale(double value)
        {
            return (value - kmStart) * xScale;
        }
    }
}
