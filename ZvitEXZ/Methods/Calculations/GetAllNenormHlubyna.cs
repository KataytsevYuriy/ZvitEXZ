using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllNenormHlubyna
    {
        private List<Hlubyna> hlubynas;
        private List<NeObstegeno> neObstegenos;
        List<NenormHlubyna> nenormHlubynas;
        List<Zamer> orientirs;
        public GetAllNenormHlubyna(List<Hlubyna> hlubynas, List<NeObstegeno> neObstegenos, List<Zamer> orientirs)
        {
            this.neObstegenos = neObstegenos;
            this.hlubynas = hlubynas;
            nenormHlubynas = new List<NenormHlubyna>();
            this.orientirs = orientirs;
        }
        public List<NenormHlubyna> Get()
        {
            double kmStart = -1, kmEnd, lastKm = -1;
            List<Hlubyna> dyilyanka = new List<Hlubyna>();
            List<List<Hlubyna>> listHlubynas = new List<List<Hlubyna>>();
            bool isFirstrDilyanka = true;
            double hlMin = -1, lastHl = -1, lastHlDSTU = -1, hlMinDSTU = -1;
            string gpsN = "", gpsE = "";
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if (dyilyanka.Count > 0)
                {
                    if (hlubyna.HlubynaFakt != null)
                    {
                        dyilyanka.Add(hlubyna);
                        listHlubynas.Add(dyilyanka);
                        dyilyanka = new List<Hlubyna>();
                        dyilyanka.Add(hlubyna);
                    }
                    else
                    {
                        dyilyanka.Add(hlubyna);
                    }
                }
                else if (hlubyna.HlubynaFakt != null)
                {
                    dyilyanka.Add(hlubyna);
                }
            }
            Hlubyna fisrtHlub, lastHlub=null;
            foreach (List<Hlubyna> dilyankaHlubynas in listHlubynas)
            {
                fisrtHlub = dilyankaHlubynas.FirstOrDefault();
                lastHlub = dilyankaHlubynas.LastOrDefault();
                if (isFirstrDilyanka)
                {
                    if (!fisrtHlub.IsNormHlubyna)
                    {
                        kmStart = fisrtHlub.Km;
                        hlMin = fisrtHlub.HlubynaInterpolated;
                        gpsN = fisrtHlub.GpsN;
                        gpsE = fisrtHlub.GpsE;
                        hlMinDSTU = fisrtHlub.MinHlubynaDSTU;
                    }
                    isFirstrDilyanka = false;
                }
                if (!fisrtHlub.IsNormHlubyna && !lastHlub.IsNormHlubyna)
                {
                    if (fisrtHlub.HlubynaInterpolated > lastHlub.HlubynaInterpolated)
                    {
                        hlMin = lastHlub.HlubynaInterpolated;
                        gpsN = lastHlub.GpsN;
                        gpsE = lastHlub.GpsE;
                        hlMinDSTU = lastHlub.MinHlubynaDSTU;
                    }
                }
                if (!fisrtHlub.IsNormHlubyna && lastHlub.IsNormHlubyna)
                {
                    kmEnd = GetCrossingInList(dilyankaHlubynas);
                    nenormHlubynas.Add(new NenormHlubyna(kmStart, kmEnd, hlMin, hlMinDSTU, gpsN, gpsE, ""));
                    kmStart = -1;
                }
                if (fisrtHlub.IsNormHlubyna && !lastHlub.IsNormHlubyna)
                {
                    kmStart = GetCrossingInList(dilyankaHlubynas);
                    hlMin = lastHlub.HlubynaInterpolated;
                    gpsN = lastHlub.GpsN;
                    gpsE = lastHlub.GpsE;
                    hlMinDSTU = lastHlub.MinHlubynaDSTU;
                }
            }
            if (kmStart != -1)
            {
                nenormHlubynas.Add(new NenormHlubyna(kmStart, lastHlub.Km, hlMin, hlMinDSTU, gpsN, gpsE, ""));
            }
            TrimNeobstegeno();
            AddMinhlub();
            AddOrientirs();
            return nenormHlubynas;
        }
        private void TrimNeobstegeno()
        {
            List<NenormHlubyna> res = new List<NenormHlubyna>();
            foreach (NenormHlubyna item in nenormHlubynas)
            {
                List<NenormHlubyna> nNhrunt = item.TrimBylist(neObstegenos).Select(el => el as NenormHlubyna).ToList();
                res.AddRange(nNhrunt);
            }
            nenormHlubynas = res;
        }
        private void AddMinhlub()
        {
            foreach (NenormHlubyna nenormHlubyna in nenormHlubynas)
            {
                if (nenormHlubyna.HlubMin != -1) continue;
                Hlubyna hlubyna = hlubynas.Where(el => el.Km >= nenormHlubyna.KmStart && el.Km <= nenormHlubyna.KmEnd && el.HlubynaFakt != null)
                    .OrderBy(hl => hl.HlubynaFakt).FirstOrDefault();
                if (hlubyna == null)
                {
                    Logs.AddError($"на участке км {nenormHlubyna.KmStart} -  км {nenormHlubyna.KmEnd} невозможно найти минимальную глубину");
                }
                else
                {
                    nenormHlubyna.HlubMin = hlubyna.HlubynaFakt ?? 0;
                    nenormHlubyna.GpsN = hlubyna.GpsN;
                    nenormHlubyna.GpsE = hlubyna.GpsE;
                    nenormHlubyna.HlubNorma = hlubyna.MinHlubynaDSTU;
                    if (nenormHlubyna.HlubMin >= nenormHlubyna.HlubNorma)
                        Logs.AddError($"Проверьте ненормативную глубину на участке км {nenormHlubyna.KmStart} -  км {nenormHlubyna.KmEnd}, невозможно на участке интерполированная глубина ниже нормы, но фактичесская на проставлена");
                }
            }
        }
        private void AddOrientirs()
        {
            AddOrientir addOrientir = new AddOrientir();
            foreach (NenormHlubyna hlubyna in nenormHlubynas)
            {
                hlubyna.Description = addOrientir.Add(orientirs, hlubyna.KmStart, hlubyna.KmEnd);
            }
        }
        private double GetCrossingInList(List<Hlubyna> hlubynas)
        {
            double km = 0;
            Hlubyna first = hlubynas.First();
            Hlubyna last=null;
            foreach (Hlubyna item in hlubynas)
            {
                if (first.IsNormHlubyna == item.IsNormHlubyna)
                {
                    first = item;
                }
                else
                {
                    last = item;
                    break;
                }
            }
            if(last == null) return km;
            Crossing crossing = new Crossing(first.IsNormHlubyna?last.MinHlubynaDSTU:first.MinHlubynaDSTU);
            km = crossing.GetCrossing(first.HlubynaInterpolated, first.Km, last.HlubynaInterpolated, last.Km);
            return km;
        }
    }
}
