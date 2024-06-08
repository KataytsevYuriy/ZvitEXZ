using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllPovregdenya
    {
        private double uFirstCherga;
        private double uSecondCherga;
        List<Povregdenya> povregdenyas;
        List<NeObstegeno> neobstegenes;
        public GetAllPovregdenya(double UFirstChergaGradient, double USecondChergaGradient,List<NeObstegeno> neobstegeno)
        {
            uFirstCherga = UFirstChergaGradient;
            uSecondCherga = USecondChergaGradient;
            neobstegenes = neobstegeno;
            povregdenyas = new List<Povregdenya>();
        }
        public List<Povregdenya> Get(List<Zamer> zamers, List<KorNebezpechny> korneb)
        {
            GetAll(zamers);
            AddKorneb(korneb);
            SplitPovregdenya();
            TrimPovregdenya();
            AddMaxGrad(zamers);

            return povregdenyas;
        }
        private void GetAll(List<Zamer> data)
        {
            int flagCherga = -1;
            int currentCherga;
            double kmStart = 0;
            double lastKm = data.First().Km;
            double lastU = 1;
            double kmFinish = 0;
            double maxGrad = 0;
            double UMaxGrad = 0;
            string gpsN = "";
            string gpsE = "";
            MestnostType mestnost = MestnostType.IndefinedType;
            Crossing firstToSecondCrossing = new Crossing(uFirstCherga);
            Crossing secondCrossing = new Crossing(uSecondCherga);
            foreach (Zamer zamer in data)
            {
                if (zamer.Ugrad == null || zamer.Utz == null)
                {
                    continue;
                }
                currentCherga = GetCherga(zamer.Utz, zamer.Ugrad);
                if (flagCherga == -1)
                {
                    if (currentCherga > 0)
                    {
                        kmStart = zamer.Km;
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                    }
                }
                else if (flagCherga == 0)
                {
                    if (currentCherga > 0)
                    {
                        kmStart = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                }
                else if (flagCherga == 2)
                {
                    if (currentCherga == 0)
                    {
                        kmFinish = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        povregdenyas.Add(new Povregdenya(kmStart, kmFinish, 2, maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                    }
                    else if (currentCherga == 2 && maxGrad > zamer.Utz)
                    {
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                    else if (currentCherga == 1)
                    {
                        kmFinish = firstToSecondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        povregdenyas.Add(new Povregdenya(kmStart, kmFinish, 2, maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                        kmStart = kmFinish;
                    }
                }
                else if (flagCherga == 1)
                {
                    if (currentCherga == 0)
                    {
                        kmFinish = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        povregdenyas.Add(new Povregdenya(kmStart, kmFinish, 1, maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                    }
                    else if (currentCherga == 1 && maxGrad > zamer.Utz)
                    {
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                    else if (currentCherga == 2)
                    {
                        kmFinish = firstToSecondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        povregdenyas.Add(new Povregdenya(kmStart, kmFinish, 1, maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                        kmStart = kmFinish;
                    }
                }
                lastKm = zamer.Km;
                lastU = zamer.Ugrad ?? 0;
                flagCherga = currentCherga;
            }
            if (flagCherga > 0)
            {
                povregdenyas.Add(new Povregdenya(kmStart, lastKm, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
            }
        }
        private int GetCherga(double? utz, double? ugrad)
        {
            if ((double)ugrad > uSecondCherga) return 0;
            if ((double)ugrad < uFirstCherga) return 1;
            return 2;
        }
        private void AddKorneb(List<KorNebezpechny> korneb) //2 cherga to 1
        {
            List<Povregdenya> newPovregdenya = new List<Povregdenya>();
            if (korneb.Count == 0 || povregdenyas.Count == 0) return;
            double kmStart;
            foreach (Povregdenya povregd in povregdenyas)
            {
                if (povregd.Cherga == 1)
                {
                    newPovregdenya.Add(povregd);
                    continue;
                }
                kmStart = povregd.KmStart;
                bool isDelitsya = false;
                foreach (KorNebezpechny kornebEl in korneb)
                {
                    if (kornebEl.KmEnd < povregd.KmStart) continue;
                    if (kornebEl.KmStart > povregd.KmEnd) break;
                    if (kornebEl.KmStart > kmStart)
                    {
                        isDelitsya = true;
                        newPovregdenya.Add(CreatePovregdenya(kmStart, kornebEl.KmStart, povregd.Cherga,
                                                 0, 0, "", "", MestnostType.IndefinedType, isDelitsya));
                        kmStart = kornebEl.KmStart;
                    }
                    if (kornebEl.KmEnd >= povregd.KmEnd)
                    {
                        newPovregdenya.Add(CreatePovregdenya(kmStart, povregd.KmEnd, 1, povregd.MaxGradient,
                            povregd.UMaxGradient, povregd.GpsN, povregd.GpsE, povregd.Mestnost, isDelitsya));
                        kmStart = povregd.KmEnd;
                    }
                    else
                    {
                        isDelitsya = true;
                        newPovregdenya.Add(CreatePovregdenya(kmStart, kornebEl.KmEnd, 1, 0, 0, "", "",
                            MestnostType.IndefinedType, isDelitsya));
                        kmStart = kornebEl.KmEnd;
                    }

                }
                if (kmStart != povregd.KmEnd)
                {
                    newPovregdenya.Add(CreatePovregdenya(kmStart, povregd.KmEnd, povregd.Cherga,
                           povregd.MaxGradient, povregd.UMaxGradient, povregd.GpsN, povregd.GpsE, povregd.Mestnost, isDelitsya));
                }
            }
            povregdenyas = newPovregdenya;
        }
        private void SplitPovregdenya()
        {
            if (povregdenyas.Count < 2) return;
            List<Povregdenya> newPovregdenyas = new List<Povregdenya>();
            Povregdenya previousPovregd = null;
            foreach (Povregdenya item in povregdenyas)
            {
                if (previousPovregd == null)
                {
                    previousPovregd = item;
                    continue;
                }
                if (previousPovregd.KmEnd == item.KmStart && previousPovregd.Cherga == item.Cherga)
                {
                    if (previousPovregd.MaxGradient > item.MaxGradient)
                    {
                        previousPovregd.MaxGradient = item.MaxGradient;
                        previousPovregd.UMaxGradient = item.UMaxGradient;
                        previousPovregd.GpsN = item.GpsN;
                        previousPovregd.GpsE = item.GpsE;
                        previousPovregd.Mestnost = item.Mestnost;
                    }
                    previousPovregd.KmEnd = item.KmEnd;
                }
                else
                {
                    newPovregdenyas.Add(new Povregdenya(previousPovregd));
                    previousPovregd = item;
                }
            }
            newPovregdenyas.Add(new Povregdenya(previousPovregd));
            povregdenyas = newPovregdenyas;
        }
        private void AddMaxGrad(List<Zamer> zamers)
        {
            foreach (Povregdenya povregdenya in povregdenyas)
            {
                if (povregdenya.Mestnost != MestnostType.IndefinedType) continue;
                Zamer maxZamer = zamers.First();
                foreach (Zamer zamer in zamers)
                {
                    if (zamer.Km < povregdenya.KmStart || zamer.Ugrad == null) continue;
                    if (zamer.Km > povregdenya.KmEnd) break;
                    if (zamer.Ugrad < maxZamer.Ugrad) maxZamer = zamer;
                }
                povregdenya.MaxGradient = (double)maxZamer.Ugrad;
                povregdenya.UMaxGradient = (double)maxZamer.Utz;
                povregdenya.GpsN = maxZamer.GpsN;
                povregdenya.GpsE = maxZamer.GpsE;
                povregdenya.Mestnost = maxZamer.Mestnost;
            }
        }
        private Povregdenya CreatePovregdenya(double kmStart, double kmFinish, int cherga,
            double maxGradient, double uMaxGradient, string GpsN, string GpsE, MestnostType mestnost, bool obnulit = true)
        {
            if (obnulit) return new Povregdenya(kmStart, kmFinish, cherga, 0, 0, "", "", MestnostType.IndefinedType);
            return new Povregdenya(kmStart, kmFinish, cherga, maxGradient, uMaxGradient, GpsN, GpsE, mestnost);
        }
        private void TrimPovregdenya()
        {
            List<Povregdenya> res = new List<Povregdenya>();
            foreach (Povregdenya povregd in povregdenyas)
            {
                List<Povregdenya> curKorneb = povregd.TrimBylist(neobstegenes).Select(el => el as Povregdenya).ToList();
                res.AddRange(curKorneb);
            }
            povregdenyas = res;
        }
    }
}
