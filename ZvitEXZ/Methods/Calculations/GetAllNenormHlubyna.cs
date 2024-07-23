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
            double hlMin = -1, lastHl = -1, lastHlDSTU = -1, hlMinDSTU = -1;
            string gpsN = "", gpsE = "";
            foreach (Hlubyna hlubyna in hlubynas)
            {
                if (hlubyna.HlubynaInterpolated == -1) continue;
                //if (hlubyna.HlubynaFakt == null) continue;
                if (hlubyna.HlubynaInterpolated < hlubyna.MinHlubynaDSTU)
                {
                    if (lastKm == -1)
                    {
                        kmStart = hlubyna.Km;
                        hlMin = hlubyna.HlubynaInterpolated;
                        gpsN = hlubyna.GpsN;
                        gpsE = hlubyna.GpsE;
                        hlMinDSTU = hlubyna.MinHlubynaDSTU;
                    }
                    else if (kmStart == -1)
                    {
                        Crossing crossing = new Crossing(hlubyna.MinHlubynaDSTU);
                        kmStart = crossing.GetCrossing(lastHl, lastKm, hlubyna.HlubynaInterpolated, hlubyna.Km);
                        hlMin = hlubyna.HlubynaInterpolated;
                        gpsN = hlubyna.GpsN;
                        gpsE = hlubyna.GpsE;
                        hlMinDSTU = hlubyna.MinHlubynaDSTU;
                    }
                    else if (hlMin > hlubyna.HlubynaInterpolated)
                    {
                        hlMin = hlubyna.HlubynaInterpolated;
                        gpsN = hlubyna.GpsN;
                        gpsE = hlubyna.GpsE;
                        hlMinDSTU = hlubyna.MinHlubynaDSTU;
                    }
                }
                else if (kmStart != -1)
                {
                    Crossing crossing = new Crossing(lastHlDSTU);
                    kmEnd = crossing.GetCrossing(lastHl, lastKm, hlubyna.HlubynaInterpolated, hlubyna.Km);
                    nenormHlubynas.Add(new NenormHlubyna(kmStart, kmEnd, hlMin, hlMinDSTU, gpsN, gpsE, ""));
                    kmStart = -1;
                }
                lastKm = hlubyna.Km;
                lastHl = hlubyna.HlubynaInterpolated;
                lastHlDSTU = hlubyna.MinHlubynaDSTU;
            }
            if (kmStart != -1)
            {
                nenormHlubynas.Add(new NenormHlubyna(kmStart, lastKm, hlMin, hlMinDSTU, gpsN, gpsE, ""));
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
            foreach(NenormHlubyna hlubyna in nenormHlubynas)
            {
                hlubyna.Description = addOrientir.Add(orientirs, hlubyna.KmStart, hlubyna.KmEnd);
            }
        }
    }
}
