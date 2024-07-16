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
            List<Hlubyna> tmp = new List<Hlubyna>();
            foreach (Zamer zamer in zamers)          // список глубин с просуском пустых в начале и в конце
            {
                if (tmp.Count == 0 && zamer.Hlub != null)
                {
                    tmp.Add(new Hlubyna(zamer));
                }
                else if (tmp.Count > 0 && zamer.Hlub == null)
                {
                    tmp.Add(new Hlubyna(zamer));
                }
                else if (tmp.Count > 0 && zamer.Hlub != null)
                {
                    hlubynas.AddRange(tmp);
                    tmp = new List<Hlubyna>();
                    tmp.Add(new Hlubyna(zamer));
                }
            }
            if (tmp.Count > 0) hlubynas.Add(tmp.First());
            // hlubynas = zamers.Select(el => new Hlubyna(el)).ToList();
            AddNormHlubByDSTYCx();
            InterpolateHlubynas();
           // AddCrossingHlubyna();
            return hlubynas;
        }
        private void AddNormHlubByDSTYCx()
        {
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if (hlubyna.Mestnost == MestnostType.CX)
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
            List<Hlubyna> dylyanka= new List<Hlubyna>();
            List<Hlubyna> res= new List<Hlubyna>();
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if(dylyanka.Count==0 && hlubyna.HlubynaFakt != null)
                {
                    dylyanka.Add(hlubyna);
                }
                else if(dylyanka.Count>0 && hlubyna.HlubynaFakt == null)
                {
                    dylyanka.Add(hlubyna);
                }
                else if (dylyanka.Count==1 && hlubyna.HlubynaFakt != null)
                {
                    res.AddRange(dylyanka);
                    dylyanka = new List<Hlubyna>();
                    dylyanka.Add(hlubyna);
                }
                else if (dylyanka.Count>1 && hlubyna.HlubynaFakt != null)
                {
                    res.AddRange(IntrpolateDylyanka(dylyanka,hlubyna));
                    dylyanka= new List<Hlubyna>();
                    dylyanka.Add(hlubyna);
                }
            }
            if (dylyanka.Count > 1)
                res.Add(dylyanka.First());
            hlubynas=res;
        }
        private List<Hlubyna> IntrpolateDylyanka(List<Hlubyna> dylyanka, Hlubyna last)
        {
            CalculateValueByKm calc = new CalculateValueByKm();
            Hlubyna first = dylyanka.First();
            foreach(Hlubyna hlubyna in dylyanka)
            {
                if (hlubyna.HlubynaFakt != null) continue;
                hlubyna.HlubynaInterpolated = calc.Calcculate(first.Km, first.HlubynaFakt, last.Km, last.HlubynaFakt, hlubyna.Km);
            }
            return dylyanka;
        }
        //    private void InterpolateHlubynas()
        //{
        //    List<InterpolationDylyanka> dylyankas = new List<InterpolationDylyanka>();
        //    double kmStart = -1;
        //    double hlybStart = -1;
        //    foreach (Hlubyna hlubyna in hlubynas)
        //    {
        //        if (hlubyna.HlubynaFakt == null) continue;
        //        if (kmStart == -1)
        //        {
        //            kmStart = hlubyna.Km;
        //            hlybStart = (double)hlubyna.HlubynaFakt;
        //        }
        //        else
        //        {
        //            dylyankas.Add(new InterpolationDylyanka(kmStart, hlybStart, hlubyna.Km, (double)hlubyna.HlubynaFakt));
        //            kmStart = hlubyna.Km;
        //            hlybStart = (double)hlubyna.HlubynaFakt;
        //        }
        //    }
        //    foreach (Hlubyna hlubyna1 in hlubynas)
        //    {
        //        if (hlubyna1.HlubynaFakt != null)
        //        {
        //            hlubyna1.HlubynaInterpolated = hlubyna1.HlubynaFakt ?? 0;
        //            continue;
        //        }
        //        InterpolationDylyanka dylyanka = dylyankas.FirstOrDefault(el =>
        //        hlubyna1.Km > el.KmStart && hlubyna1.Km < el.KmEnd);
        //        if (dylyanka == null) continue;
        //        hlubyna1.HlubynaInterpolated = Math.Round(dylyanka.HlybStart - (dylyanka.HlybStart - dylyanka.HlybEnd)
        //            * (dylyanka.KmStart - hlubyna1.Km) / (dylyanka.KmStart - dylyanka.KmEnd), 2);
        //    }
        //}
        private void AddCrossingHlubyna()
        {
            Hlubyna lastHlub = hlubynas.First();
            List<Hlubyna> res = new List<Hlubyna>();
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if (lastHlub.IsNormHlubyna != hlubyna.IsNormHlubyna)
                {
                    Crossing crossing = new Crossing(lastHlub.MinHlubynaDSTU);
                    double km = crossing.GetCrossing(lastHlub.HlubynaInterpolated, lastHlub.Km, hlubyna.HlubynaInterpolated, hlubyna.Km);
                    res.Add(new Hlubyna(km, null, lastHlub.MinHlubynaDSTU, "", "", lastHlub.Mestnost, "", lastHlub.MinHlubynaDSTU));
                }
                res.Add(hlubyna);
                lastHlub = hlubyna;
            }
            hlubynas = res;
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