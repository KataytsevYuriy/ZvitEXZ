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
            double Utz = 0;
            bool addUEnd = false;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Utz != null) Utz = (double)zamer.Utz;
                if (zamer.Name == ProjectConstants.RoadName)
                {
                    Road road = zamer as Road;
                    if (road.RoadType == RoadTypes.automobile || road.RoadType == RoadTypes.train)
                    {
                        roadKozhuhs.Add(new RoadKozhuh(road, Utz));
                        addUEnd = true;
                        continue;
                    }
                }
                else if (zamer.Name == ProjectConstants.PVName || zamer.Name == ProjectConstants.SvechaName)
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
                double? utzBefore = null, utzAfter = null, ukozBefore = null, ukozAfter = null;
                string pvBefore = "", pvAfter = "";
                foreach (Zamer pvSvecha in roadKozhuh1.PVsSvechas)
                {
                    if (pvSvecha.Km < roadKozhuh1.Km)
                    {
                        pvBefore = $"{pvBefore}{pvSvecha.Name}, ";
                        if (pvSvecha.Name == ProjectConstants.SvechaName)
                        {
                            Svecha svecha = pvSvecha as Svecha;
                            if (svecha.USvechy != null) ukozBefore = svecha.USvechy;
                            roadKozhuh1.IsSvechaStart = true;
                        }
                        if (pvSvecha.Name == ProjectConstants.PVName)
                        {
                            PV pV = pvSvecha as PV;
                            if (pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pipe ||
                                pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pointDrenazh)
                            {
                                utzBefore = pV.ProvodPotencial1;
                                roadKozhuh1.IsPvStartProvodUtz = true;
                            }
                            if (pV.ProvodTypePidklichenya2 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozBefore = pV.ProvodPotencial2;
                                roadKozhuh1.IsPvStartProvodUkozh = true;
                            }
                            if (pV.ProvodTypePidklichenya3 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozBefore = pV.ProvodPotencial3;
                                roadKozhuh1.IsPvStartProvodUkozh = true;
                            }
                        }
                    }
                    else
                    {
                        pvAfter = $"{pvAfter}{pvSvecha.Name}, ";
                        if (pvSvecha.Name == ProjectConstants.SvechaName)
                        {
                            Svecha svecha = pvSvecha as Svecha;
                            if (svecha.USvechy != null) ukozAfter = svecha.USvechy;
                            roadKozhuh1.IsSvechaEnd = true;
                        }
                        if (pvSvecha.Name == ProjectConstants.PVName)
                        {
                            PV pV = pvSvecha as PV;
                            if (pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pipe ||
                                pV.ProvodTypePidklichenya1 == ProvodTypePidklichenyas.pointDrenazh)
                            {
                                utzAfter = pV.ProvodPotencial1;
                                roadKozhuh1.IsPvEndProvodUtz = true;
                            }
                            if (pV.ProvodTypePidklichenya2 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozAfter = pV.ProvodPotencial2;
                                roadKozhuh1.IsPvEndProvodUkozh = true;
                            }
                            if (pV.ProvodTypePidklichenya3 == ProvodTypePidklichenyas.kozhuh)
                            {
                                ukozAfter = pV.ProvodPotencial3;
                                roadKozhuh1.IsPvEndProvodUkozh = true;
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
                roadKozhuh1.UtzOn = $"-{ConvertToString.DoubleToString(utzBefore)}{starBefore} / -{ConvertToString.DoubleToString(utzAfter)}{starAfter}";
                roadKozhuh1.UkozhOn = $"-{ConvertToString.DoubleToString(ukozBefore)} / -{ConvertToString.DoubleToString(ukozAfter)}";
                if (roadKozhuh1.HasKozhuh)
                {
                    roadKozhuh1.PvStartProvodUkozh = roadKozhuh1.IsPvStartProvodUkozh ? "так" : "ні";
                    roadKozhuh1.PvEndProvodUkozh = roadKozhuh1.IsPvEndProvodUkozh ? "так" : "ні";
                    roadKozhuh1.SvechaStart = roadKozhuh1.IsSvechaStart ? "так" : "ні";
                    roadKozhuh1.SvechaEnd = roadKozhuh1.IsSvechaEnd ? "так" : "ні";
                    if (!roadKozhuh1.IsPvStartProvodUkozh && !roadKozhuh1.IsPvStartProvodUtz)
                    {
                        roadKozhuh1.Atestation += "на початку переходу ПВ - відсутній; ";
                    }
                    else if (!roadKozhuh1.IsPvStartProvodUkozh)
                    {
                        roadKozhuh1.Atestation += "на початку переходу вивід від кожуху - відсутній; ";
                    }
                    else if (!roadKozhuh1.IsPvStartProvodUtz)
                    {
                        roadKozhuh1.Atestation += "на початку переходу вивід від трубопроводу - відсутній; ";
                    }

                    if (!roadKozhuh1.IsPvEndProvodUkozh && !roadKozhuh1.IsPvEndProvodUtz)
                    {
                        roadKozhuh1.Atestation += "в кінці переходу ПВ - відсутній; ";
                    }
                    else if (!roadKozhuh1.IsPvEndProvodUkozh)
                    {
                        roadKozhuh1.Atestation += "в кінці переходу вивід від кожуху - відсутній; ";
                    }
                    else if (!roadKozhuh1.IsPvEndProvodUtz)
                    {
                        roadKozhuh1.Atestation += "в кінці переходу вивід від трубопроводу - відсутній; ";
                    }
                }
                else
                {
                    roadKozhuh1.PvStartProvodUkozh = "-";
                    roadKozhuh1.PvEndProvodUkozh = "-";
                    roadKozhuh1.SvechaStart = "-";
                    roadKozhuh1.SvechaEnd = "-";
                    roadKozhuh1.Atestation = "кожух відсутній; ";
                    if (!roadKozhuh1.IsPvStartProvodUtz)
                    {
                        roadKozhuh1.Atestation += "на початку переходу ПВ - відсутній; ";
                    }
                    if (!roadKozhuh1.IsPvEndProvodUtz)
                    {
                        roadKozhuh1.Atestation += "в кінці переходу ПВ - відсутній; ";
                    }
                }
                if (!roadKozhuh1.IsSvechaEnd && !roadKozhuh1.IsSvechaStart)
                {
                    roadKozhuh1.Atestation += "захисні свічки на переході - відсутні; ";
                }
                roadKozhuh1.PvStartProvodUtz = roadKozhuh1.IsPvStartProvodUtz ? "так" : "ні";
                roadKozhuh1.PvEndProvodUtz = roadKozhuh1.IsPvEndProvodUtz ? "так" : "ні";
            }
            return roadKozhuhs;
        }
    }
}
