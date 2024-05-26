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
    internal class GetAllRoadKozhuhs
    {
        public List<RoadKozhuh> Get(List<Zamer> zamers)
        {
            List<RoadKozhuh> roadKozhuhs = new List<RoadKozhuh>();
            List<Zamer> pvsSvechas = new List<Zamer>();
            float Utz = 0;
            bool addUEnd = false;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Utz != null) Utz = (float)zamer.Utz;
                if (zamer.Name == Constants.RoadName)
                {
                    Road road = zamer as Road;
                    if (road.RoadType == RoadTypes.automobile || road.RoadType == RoadTypes.train)
                    {
                        roadKozhuhs.Add(new RoadKozhuh(road, Utz));
                        addUEnd = true;
                        continue;
                    }
                }
                else if (zamer.Name == Constants.PVName || zamer.Name == Constants.SvechaName)
                {
                    pvsSvechas.Add(zamer);
                }
                if (addUEnd && zamer.Utz != null)
                {
                    roadKozhuhs.Last().UtzFinish = zamer.Utz;
                    addUEnd = false;
                }
            }
            foreach (RoadKozhuh roadKozhuh in roadKozhuhs)//add PV and svecha to Road
            {
                if (roadKozhuh.NumberSvyazky == 0) continue;
                roadKozhuh.PVsSvechas = pvsSvechas.Where(i => i.NumberSvyazky == roadKozhuh.NumberSvyazky).ToList();
            }
            foreach (RoadKozhuh roadKozhuh1 in roadKozhuhs)
            {
                float? utzBefore = null, utzAfter = null, ukozBefore = null, ukozAfter = null;
                string pvBefore = "", pvAfter = "";
                foreach (Zamer pvSvecha in roadKozhuh1.PVsSvechas)
                {
                    if (pvSvecha.Km < roadKozhuh1.Km)
                    {
                        pvBefore = $"{pvBefore}{pvSvecha.Name}, ";
                        if (pvSvecha.Name == Constants.SvechaName)
                        {
                            Svecha svecha = pvSvecha as Svecha;
                            if (svecha.USvechy != null) ukozBefore = svecha.USvechy;
                            roadKozhuh1.IsSvechaStart = true;
                        }
                        if (pvSvecha.Name == Constants.PVName)
                        {
                            PV pV = pvSvecha as PV;
                            if (pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pipe ||
                                pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pointDrenazh)
                            {
                                utzBefore = pV.ProvodPotencial1;
                                roadKozhuh1.IsPvStartPtovodUtz = true;
                            }
                            if (pV.ProvodTypePidklichenya2 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozBefore = pV.ProvodPotencial2;
                                roadKozhuh1.IsPvStartPtovodUkozh = true;
                            }
                            if (pV.ProvodTypePidklichenya3 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozBefore = pV.ProvodPotencial3;
                                roadKozhuh1.IsPvStartPtovodUkozh = true;
                            }
                        }
                    }
                    else
                    {
                        pvAfter = $"{pvAfter}{pvSvecha.Name}, ";
                        if (pvSvecha.Name == Constants.SvechaName)
                        {
                            Svecha svecha = pvSvecha as Svecha;
                            if (svecha.USvechy != null) ukozAfter = svecha.USvechy;
                            roadKozhuh1.IsSvechaEnd = true;
                        }
                        if (pvSvecha.Name == Constants.PVName)
                        {
                            PV pV = pvSvecha as PV;
                            if (pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pipe ||
                                pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pointDrenazh)
                            {
                                utzAfter = pV.ProvodPotencial1;
                                roadKozhuh1.IsPvEndPtovodUtz = true;
                            }
                            if (pV.ProvodTypePidklichenya2 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozAfter = pV.ProvodPotencial2;
                                roadKozhuh1.IsPvEndPtovodUkozh = true;
                            }
                            if (pV.ProvodTypePidklichenya3 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozAfter = pV.ProvodPotencial3;
                                roadKozhuh1.IsPvEndPtovodUkozh = true;
                            }
                        }
                    }

                }
                if (pvBefore == "") pvBefore = "-";
                if (pvAfter == "") pvAfter = "-";
                roadKozhuh1.CheckPlace = $"{pvBefore} / {pvAfter}";
                string starBefore = utzBefore == null && roadKozhuh1.UtzStart != null ? "*" : "";
                string starAfter = utzAfter == null && roadKozhuh1.UtzFinish != null ? "*" : "";
                utzBefore = utzBefore ?? roadKozhuh1.UtzStart;
                utzAfter = utzAfter ?? roadKozhuh1.UtzFinish;
                roadKozhuh1.UtzOn = $"-{ConvertToString.FloatToString(utzBefore)}{starBefore} / -{ConvertToString.FloatToString(utzAfter)}{starAfter}";
                roadKozhuh1.UkozhOn = $"-{ConvertToString.FloatToString(ukozBefore)} / -{ConvertToString.FloatToString(ukozAfter)}";
            }
            return roadKozhuhs;
        }
    }
}
