using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllHlubynas
    {
        private List<Hlubyna> hlubynas;
        private List<Zamer> zamers;
        public GetAllHlubynas(List<Zamer> zamers)
        {
            this.zamers = zamers;
        }
        public List<Hlubyna> Get()
        {
            hlubynas = new List<Hlubyna>();
            hlubynas = zamers.Select(el => new Hlubyna(el)).ToList();
            AddNormHlabByDSTYCx();
            InterpolateHlubynas();
            return hlubynas;
        }
        private void AddNormHlabByDSTYCx()
        {
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if(hlubyna.Mestnost==MestnostType.CX)
                {
                    hlubyna.MinHlubynaDSTU = 1;
                }
                else
                {
                    hlubyna.MinHlubynaDSTU = 0.8;
                }
            }
        }
        private void InterpolateHlubynas()
        {
            List<InterpolationDylyanka> dylyankas = new List<InterpolationDylyanka>();
            double kmStart = -1;
            double hlybStart = -1;
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if (hlubyna.HlubynaFakt == null) continue;
                if (kmStart == -1)
                {
                    kmStart = hlubyna.Km;
                    hlybStart = hlubyna.HlubynaFakt ?? 0;
                }
                else
                {
                    dylyankas.Add(new InterpolationDylyanka(kmStart, hlybStart, hlubyna.Km, hlubyna.HlubynaFakt ?? 0));
                    kmStart = hlubyna.Km;
                    hlybStart = hlubyna.HlubynaFakt ?? 0;
                }
            }
            foreach (Hlubyna hlubyna1 in hlubynas)
            {
                if (hlubyna1.HlubynaFakt != null)
                {
                    hlubyna1.HlubynaInterpolated = hlubyna1.HlubynaFakt ?? 0;
                    continue;
                }
                InterpolationDylyanka dylyanka = dylyankas.FirstOrDefault(el =>
                hlubyna1.Km > el.KmStart && hlubyna1.Km < el.KmEnd);
                if (dylyanka == null) continue;
                hlubyna1.HlubynaInterpolated = Math.Round(dylyanka.HlybStart - (dylyanka.HlybStart - dylyanka.HlybEnd)
                    * (dylyanka.KmStart - hlubyna1.Km) / (dylyanka.KmStart - dylyanka.KmEnd), 2);
            }
        }
        private class InterpolationDylyanka
        {
            public double KmStart { get; set; }
            public double HlybStart { get; set; }
            public double KmEnd { get; set; }
            public double HlybEnd { get; set; }
            public InterpolationDylyanka(double kmStart, double hlybStart, double kmEnd, double hlybEnd)
            {
                KmStart = kmStart;
                HlybStart = hlybStart;
                HlybEnd = hlybEnd;
                KmEnd = kmEnd;
            }
        }
    }
}