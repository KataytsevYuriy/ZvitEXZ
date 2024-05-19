using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllPovregdenya
    {
        private float uFirstCherga;
        private float uSecondCherga;
        List<Povregdenya> povregdenyas;
        public GetAllPovregdenya(float UFirstChergaGradient, float USecondChergaGradient)
        {
            uFirstCherga = UFirstChergaGradient;
            uSecondCherga = USecondChergaGradient;
            povregdenyas = new List<Povregdenya>();
        }
        public List<Povregdenya> Get(List<Zamer> zamers, List<KorNebezpechny> korneb)
        {
            GetAll(zamers);
            AddKorneb(korneb);
            SplitPovregdenya();
            AddMaxGrad(zamers);

            return povregdenyas;
        }
        private void GetAll(List<Zamer> data)
        {
            int flagCherga = 0;
            float kmStart = 0;
            float lastKm = data.First().Km;
            float lastU = 1;
            float kmFinish = 0;
            float maxGrad = 0;
            float UMaxGrad = 0;
            string gpsN = "";
            string gpsE = "";
            MestnostType mestnost = MestnostType.IndefinedType;
            Crossing firstToSecondCrossing = new Crossing(uFirstCherga);
            Crossing secondCrossing = new Crossing(uSecondCherga);
            foreach (Zamer zamer in data)
            {
                if (zamer.Ugrad == null || zamer.Utz == null) continue;
                if (flagCherga == 0)
                {
                    if (zamer.Ugrad <= uSecondCherga) //to 1 and 2 cherga
                    {
                        kmStart = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                        if (zamer.Ugrad <= uFirstCherga) { flagCherga = 1; }
                        else { flagCherga = 2; }
                    }
                }
                else if (flagCherga == 2)
                {
                    if (zamer.Ugrad > uSecondCherga) //to 0 cherga
                    {
                        kmFinish = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        if (kmFinish > kmStart)
                        {
                            povregdenyas.Add(new Povregdenya(kmStart, kmFinish, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        }
                        flagCherga = 0;
                    }
                    else if (zamer.Ugrad <= uFirstCherga) //to 1 cherga
                    {
                        kmFinish = firstToSecondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        if (kmFinish > kmStart)
                        {
                            povregdenyas.Add(new Povregdenya(kmStart, kmFinish, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        }
                        flagCherga = 1;
                        kmStart = kmFinish;
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                    else if (zamer.Ugrad < UMaxGrad) //leave in 2 cherga
                    {
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                }
                else //if FlagCherga==1
                {
                    if (zamer.Ugrad > uSecondCherga) //to 0 cherga
                    {
                        kmFinish = secondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        if (kmFinish > kmStart)
                        {
                            povregdenyas.Add(new Povregdenya(kmStart, kmFinish, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        }
                        flagCherga = 0;

                    }
                    else if (zamer.Ugrad > uFirstCherga)//to 2 cherga
                    {
                        kmFinish = firstToSecondCrossing.GetCrossing(lastU, lastKm, zamer.Ugrad ?? 0, zamer.Km);
                        if (kmFinish > kmStart)
                        {
                            povregdenyas.Add(new Povregdenya(kmStart, kmFinish, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
                        }
                        flagCherga = 2;
                        kmStart = kmFinish;
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                    else if (zamer.Ugrad < UMaxGrad) //leave in 1 cherga
                    {
                        maxGrad = zamer.Ugrad ?? 0;
                        UMaxGrad = zamer.Utz ?? 0;
                        gpsN = zamer.GpsN;
                        gpsE = zamer.GpsE;
                        mestnost = zamer.Mestnost;
                    }
                }
                lastKm = zamer.Km;
                lastU = zamer.Ugrad ?? 0;
            }
            if (flagCherga > 0)
            {
                povregdenyas.Add(new Povregdenya(kmStart, lastKm, flagCherga,
                                maxGrad, UMaxGrad, gpsN, gpsE, mestnost));
            }
        }
        private void AddKorneb(List<KorNebezpechny> korneb) //2 cherga to 1
        {
            List<Povregdenya> newPovregdenya = new List<Povregdenya>();
            if (korneb.Count == 0 || povregdenyas.Count == 0) return;
            float kmStart;
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
                    if (kornebEl.KmFinish < povregd.KmStart) continue;
                    if (kornebEl.KmStart > povregd.KmFinish) break;
                    if (kornebEl.KmStart > kmStart)
                    {
                        isDelitsya = true;
                        newPovregdenya.Add(CreatePovregdenya(kmStart, kornebEl.KmStart, povregd.Cherga,
                                                 0, 0, "", "", MestnostType.IndefinedType, isDelitsya));
                        kmStart = kornebEl.KmStart;
                    }
                    if (kornebEl.KmFinish >= povregd.KmFinish)
                    {
                        newPovregdenya.Add(CreatePovregdenya(kmStart, povregd.KmFinish, 1, povregd.MaxGradient,
                            povregd.UMaxGradient, povregd.GpsN, povregd.GpsE, povregd.Mestnost, isDelitsya));
                        kmStart = povregd.KmFinish;
                    }
                    else
                    {
                        isDelitsya = true;
                        newPovregdenya.Add(CreatePovregdenya(kmStart, kornebEl.KmFinish, 1, 0, 0, "", "",
                            MestnostType.IndefinedType, isDelitsya));
                        kmStart = kornebEl.KmFinish;
                    }

                }
                if (kmStart != povregd.KmFinish)
                {
                    newPovregdenya.Add(CreatePovregdenya(kmStart, povregd.KmFinish, povregd.Cherga,
                           povregd.MaxGradient, povregd.UMaxGradient, povregd.GpsN, povregd.GpsE, povregd.Mestnost,isDelitsya));
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
                if (previousPovregd.KmFinish == item.KmStart && previousPovregd.Cherga == item.Cherga)
                {
                    if (previousPovregd.MaxGradient > item.MaxGradient)
                    {
                        previousPovregd.MaxGradient = item.MaxGradient;
                        previousPovregd.UMaxGradient = item.UMaxGradient;
                        previousPovregd.GpsN = item.GpsN;
                        previousPovregd.GpsE = item.GpsE;
                        previousPovregd.Mestnost = item.Mestnost;
                    }
                    previousPovregd.KmFinish = item.KmFinish;
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
            foreach(Povregdenya povregdenya in povregdenyas)
            {
                if (povregdenya.Mestnost != MestnostType.IndefinedType) continue;
                Zamer maxZamer = zamers.First();
                foreach (Zamer zamer in zamers)
                {
                    if (zamer.Km < povregdenya.KmStart ||zamer.Ugrad==null) continue;
                    if (zamer.Km > povregdenya.KmFinish) break;
                    if (zamer.Ugrad < maxZamer.Ugrad) maxZamer = zamer;
                }
                povregdenya.MaxGradient = (float)maxZamer.Ugrad;
                povregdenya.UMaxGradient = (float)maxZamer.Utz;
                povregdenya.GpsN = maxZamer.GpsN;
                povregdenya.GpsE = maxZamer.GpsE;
                povregdenya.Mestnost = maxZamer.Mestnost;
            }
        }
        private Povregdenya CreatePovregdenya(float kmStart, float kmFinish, int cherga,
            float maxGradient, float uMaxGradient, string GpsN, string GpsE, MestnostType mestnost, bool obnulit = true)
        {
            if (obnulit) return new Povregdenya(kmStart, kmFinish, cherga, 0, 0, "", "", MestnostType.IndefinedType);
            return new Povregdenya(kmStart, kmFinish, cherga, maxGradient, uMaxGradient, GpsN, GpsE, mestnost);
        }
    }
}
