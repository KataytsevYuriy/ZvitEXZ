using System;
using System.Collections.Generic;
using System.Linq;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;


namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllKorNeb
    {
        List<Zamer> zamers;
        List<KorNebezpechny> korNebezpechny;
        List<Nezahyst> nezahysts;
        List<HruntAktivity> hruntAktivities;
        List<NeObstegeno> neObstegenos;
        public GetAllKorNeb(List<Zamer> zamers, List<Nezahyst> nezahysts, List<HruntAktivity> hruntAktivities, List<NeObstegeno> neObstegenos)
        {
            this.zamers = zamers;
            this.nezahysts = nezahysts;
            korNebezpechny = new List<KorNebezpechny>();
            this.hruntAktivities = hruntAktivities;
            this.neObstegenos = neObstegenos;
        }
        public List<KorNebezpechny> Calculate()
        {
            ByUtz();
            ByRhr();
            ByZabolochennyiHrunt();
            ByTruboprovod();
            BySvalka();
            ByBludy();

            SortKorNeb();
            TrimNeobstegeno();

            ByRiver();
            BySwamp();
            ByRoads();

            SortKorNeb();

            return korNebezpechny;
        }
        private void ByUtz()
        {
            if (nezahysts != null && nezahysts.Count > 0)
                foreach (Nezahyst item in nezahysts)
                {
                    korNebezpechny.Add(new KorNebezpechny(item.KmStart, item.KmEnd, ProjectConstants.KorNebNezahMessage));
                }
        }
        private void ByRhr()
        {
            if (hruntAktivities.Count > 0)
                foreach (HruntAktivity aktivity in hruntAktivities)
                {
                    if (aktivity.HruntAktivityType == HruntAktivityTypes.hight)
                        korNebezpechny.Add(new KorNebezpechny(aktivity.KmStart, aktivity.KmFinish, ProjectConstants.KorNebRhrMessage));
                }
        }
        private void ByRiver()
        {
            string filter = ProjectConstants.RiverName;
            foreach (Zamer item in zamers)
            {
                if (item.Name == filter)
                {
                    River river = item as River;
                    if (river.Length > 0)
                        korNebezpechny.Add(new KorNebezpechny(river.Km, river.Km + (double)river.Length / 1000, filter));
                }
            }
        }
        private void BySwamp()
        {
            string filter = ProjectConstants.SwampName;
            foreach (Zamer item in zamers)
            {
                if (item.Name == filter)
                {
                    Swamp river = item as Swamp;
                    korNebezpechny.Add(new KorNebezpechny(river.Km, river.Km + (double)river.Length / 1000, filter));
                }
            }
        }
        private void ByZabolochennyiHrunt()
        {
            double swampStart = -1;
            double lastZamer = -1;
            foreach (Zamer item in zamers)
            {
                if (item.Mestnost == MestnostType.ZabolHrunt)
                {
                    lastZamer = item.Km;
                    if (swampStart == -1) swampStart = item.Km;
                }
                else if (swampStart > -1)
                {
                    korNebezpechny.Add(new KorNebezpechny(swampStart, lastZamer, ProjectConstants.KorNebZabolHrMessage));
                    swampStart = -1;
                }
            }
            if (swampStart > -1)
            {
                korNebezpechny.Add(new KorNebezpechny(swampStart, lastZamer, ProjectConstants.KorNebZabolHrMessage));
                swampStart = -1;
            }
        }
        private void SortKorNeb()
        {
            if (korNebezpechny.Count < 2) return;
            List<KorNebezpechny> listByStart = korNebezpechny.OrderBy(item => item.KmStart).ToList();
            List<KorNebezpechny> listByEnd = new List<KorNebezpechny>();
            List<KorNebezpechny> res = new List<KorNebezpechny>();
            double kmStart = 0;
            double kmEnd = 0;
            foreach (KorNebezpechny item in listByStart)
            {
                if (item.KmStart == item.KmEnd) continue;
                if (listByEnd.Count == 0)
                {
                    listByEnd.Add(item);
                    kmStart = item.KmStart;
                    continue;
                }
                if (item.KmStart < listByEnd.First().KmEnd)
                {
                    while (listByEnd.Count > 0 && item.KmStart > kmStart)
                    {
                        KorNebezpechny itemEnding = listByEnd.First();
                        if (kmStart == itemEnding.KmEnd)
                        {
                            listByEnd.Remove(itemEnding);
                            continue;
                        }
                        string korNebDescription = String.Join(", ", listByEnd.Select(el => el.Description).OrderBy(t => t).ToArray());
                        kmEnd = itemEnding.KmEnd > item.KmStart ? item.KmStart : itemEnding.KmEnd;
                        if (kmEnd > kmStart)
                            res.Add(new KorNebezpechny(kmStart, kmEnd, korNebDescription));
                        kmStart = kmEnd;
                        if (itemEnding.KmEnd <= item.KmStart)
                        {
                            listByEnd.Remove(itemEnding);
                        }
                    }
                    if (listByEnd.Count == 0) kmStart = item.KmStart;
                    listByEnd.Add(item);
                    listByEnd = listByEnd.OrderBy(elem => elem.KmEnd).ToList();
                }
                else //item.KmStart >= listByEnd.First().KmEnd
                {
                    while (listByEnd.Count > 0 && item.KmStart > kmStart)
                    {
                        KorNebezpechny itemEnding = listByEnd.First();
                        string korNebDescription = String.Join(", ", listByEnd.Select(el => el.Description).OrderBy(t => t).ToArray());
                        kmEnd = itemEnding.KmEnd > item.KmStart ? item.KmStart : itemEnding.KmEnd;
                        if (kmEnd > kmStart)
                            res.Add(new KorNebezpechny(kmStart, kmEnd, korNebDescription));
                        kmStart = kmEnd;
                        if (itemEnding.KmEnd <= item.KmStart)
                        {
                            listByEnd.Remove(itemEnding);
                        }
                    }
                    if (listByEnd.Count == 0) kmStart = item.KmStart;
                    listByEnd.Add(item);
                    listByEnd = listByEnd.OrderBy(elem => elem.KmEnd).ToList();
                }
            }
            while (listByEnd.Count > 0)
            {
                KorNebezpechny itemEnding = listByEnd.First();
                if (kmStart == itemEnding.KmEnd)
                {
                    listByEnd.Remove(itemEnding);
                    continue;
                }
                string korNebDescription = String.Join(", ", listByEnd.Select(el => el.Description).OrderBy(t => t).ToArray());
                if (itemEnding.KmEnd > kmStart)
                    res.Add(new KorNebezpechny(kmStart, itemEnding.KmEnd, korNebDescription));
                kmStart = itemEnding.KmEnd;
                listByEnd.Remove(itemEnding);
            }
            korNebezpechny = res;
        }
        private void ByTruboprovod()
        {
            List<Zamer> truboprovods = zamers.Where(tr => tr.Name == ProjectConstants.TruboprovodName).ToList();
            if (truboprovods.Count == 0) return;
            double kmStart = zamers.First().Km;
            double kmEnd = zamers.LastOrDefault().Km;
            foreach (Zamer item in truboprovods)
            {
                Truboprovod truboprovod = item as Truboprovod;
                if (!truboprovod.IsKorneb) continue;
                double start = Math.Round(item.Km - ProjectConstants.TruboprovodKornebLength < kmStart ? kmStart : item.Km - ProjectConstants.TruboprovodKornebLength, 3);
                double end = Math.Round(item.Km + ProjectConstants.TruboprovodKornebLength > kmEnd ? kmEnd : item.Km + ProjectConstants.TruboprovodKornebLength, 3);
                korNebezpechny.Add(new KorNebezpechny(start, end, ProjectConstants.KorNebTruboprovodMessage));
                kmStart = end;
            }
        }
        private void BySvalka()
        {
            string filter = ProjectConstants.SvalkaName;
            foreach (Zamer item in zamers)
            {
                if (item.Name == filter)
                {
                    Svalka svalka = item as Svalka;
                    if (svalka.Svalkalength > 0)
                        korNebezpechny.Add(new KorNebezpechny(svalka.Km, svalka.Km + (double)svalka.Svalkalength / 1000, filter));
                }
            }
        }
        private void ByBludy()
        {
            double kmStartPipe = zamers.First().Km;
            double kmFinishPipe = zamers.Last().Km;
            double kmStart = 0;
            double kmFinish = 0;
            bool isBludyStarted = false;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Name != ProjectConstants.BludyName) continue;
                Bludy bludy = zamer as Bludy;
                if (bludy.Posytion == StartEnd.start)
                {
                    if (isBludyStarted) Logs.AddError($"км {kmStart} есть только начало блудов");
                    kmStart = bludy.Km;
                    if (kmStart - kmStartPipe < 0.01) kmStart = kmStartPipe;
                    isBludyStarted = true;
                }
                if (bludy.Posytion == StartEnd.end)
                {
                    kmFinish = bludy.Km;
                    if (!isBludyStarted) Logs.AddError($"км {kmFinish} есть только окончание блудов");
                    if (kmFinishPipe - kmFinish < 0.01) kmFinish = kmFinishPipe;
                    korNebezpechny.Add(new KorNebezpechny(kmStart, kmFinish, ProjectConstants.BludyName));
                }
            }
        }
        private void ByRoads()
        {
            double kmFirst = zamers.First().Km;
            double kmLast = zamers.Last().Km;
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Name != ProjectConstants.RoadName) continue;
                Road road = zamer as Road;
                if (road.RoadType == RoadTypes.automobile || road.RoadType == RoadTypes.train)
                {
                    double kmstart = road.Km - ProjectConstants.TruboprovodKornebLength < kmFirst ?
                    kmFirst : road.Km - ProjectConstants.TruboprovodKornebLength;
                    double kmfinish = road.Km + ProjectConstants.TruboprovodKornebLength + (double)road.length / 1000 > kmLast ?
                        kmLast : road.Km + ProjectConstants.TruboprovodKornebLength + (double)road.length / 1000;
                    string description = road.RoadType == RoadTypes.automobile ? $"перетин з автодорогою {road.RoadName}" : $"перетин із залізницею {road.RoadName}";
                    korNebezpechny.Add(new KorNebezpechny(kmstart, kmfinish, description));
                }
            }
        }
        private void TrimNeobstegeno()
        {
            List<KorNebezpechny> res = new List<KorNebezpechny>();
            foreach (KorNebezpechny korneb in korNebezpechny)
            {
                List<KorNebezpechny> curKorneb = korneb.TrimBylist(neObstegenos).Select(el => el as KorNebezpechny).ToList();
                res.AddRange(curKorneb);
            }
            korNebezpechny = res;
        }
    }
}
