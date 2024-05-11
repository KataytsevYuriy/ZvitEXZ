using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;


namespace ZvitEXZ.Methods.Calculations
{
    internal class GetKorNeb
    {
        List<Zamer> zamers;
        List<KorNebezpechny> korNebezpechny;
        List<Nezahyst> nezahysts;
        public GetKorNeb(List<Zamer> zamers, List<Nezahyst> nezahysts)
        {
            this.zamers = zamers;
            this.nezahysts = nezahysts;
            korNebezpechny = new List<KorNebezpechny>();
        }
        public List<KorNebezpechny> Calculate()
        {
            ByUtz();
            ByRhr();
            ByZabolochennyiHrunt();
            ByRiver();
            BySwamp();

            SortKorNeb();
            return korNebezpechny;
        }
        private void ByUtz()
        {
            if (nezahysts != null && nezahysts.Count > 0)
                foreach (Nezahyst item in nezahysts)
                {
                    korNebezpechny.Add(new KorNebezpechny(item.KmStart, item.KmEnd, Constants.KorNebNezahMessage));
                }
        }
        private void ByRhr()
        {
            float crossLine = 20;
            Crossing Crossing = new Crossing(crossLine);
            float kmStart = 0;
            int flag = 0;// 0=undefined, 1 = not korNebezpechny, 2 = korNebezpechny
            float lastRhr = 0;
            float lastKm = 0;
            foreach (Zamer item in zamers)
            {
                if (item.Rhr == null) continue;
                if (flag == 0)
                {
                    if (item.Rhr < crossLine)
                    {
                        kmStart = item.Km;
                        flag = 2;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
                else if (flag == 1)
                {
                    if (item.Rhr < crossLine)
                    {
                        kmStart = Crossing.GetCrossing((float)lastRhr, lastKm, (float)item.Rhr, item.Km);
                        flag = 2;
                    }
                }
                else if (item.Rhr >= crossLine)  //flag =2
                {
                    flag = 1;
                    float kmEnd = Crossing.GetCrossing((float)lastRhr, lastKm, (float)item.Rhr, item.Km);
                    if (kmEnd > kmStart) korNebezpechny.Add(new KorNebezpechny(kmStart, kmEnd, Constants.KorNebRhrMessage));
                }
                lastKm = item.Km;
                lastRhr = (float)item.Rhr;
            }
            if (flag == 2)
            {
                if (lastKm > kmStart) korNebezpechny.Add(new KorNebezpechny(kmStart, lastKm, Constants.KorNebRhrMessage));
            }
        }
 
        private void ByRiver()
        {
            string filter = Constants.RiverName;
            foreach (Zamer item in zamers)
            {
                if (item.Name == filter)
                {
                    River river = item as River;
                    if (river.RiverLength > 0)
                        korNebezpechny.Add(new KorNebezpechny(river.Km, river.Km + (float)river.RiverLength / 1000, filter));
                }
            }
        }
        private void BySwamp()
        {
            string filter = Constants.SwampName;
            foreach (Zamer item in zamers)
            {
                if (item.Name == filter)
                {
                    Swamp river = item as Swamp;
                    korNebezpechny.Add(new KorNebezpechny(river.Km, river.Km + (float)river.SwampLength / 1000, filter));
                }
            }
        }
        private void ByZabolochennyiHrunt()
        {
            float swampStart = -1;
            float lastZamer = -1;
            foreach(Zamer item in zamers)
            {
                if (item.Mestnost == MestnostType.ZabolHrunt)
                {
                    lastZamer = item.Km;
                    if (swampStart == -1) swampStart = item.Km;
                } else if (swampStart > -1)
                {
                    korNebezpechny.Add(new KorNebezpechny(swampStart, lastZamer, Constants.KorNebZabolHrMessage));
                    swampStart = -1;
                }
            }
            if (swampStart > -1)
            {
                korNebezpechny.Add(new KorNebezpechny(swampStart, lastZamer, Constants.KorNebZabolHrMessage));
                swampStart = -1;
            }
        }
        private void SortKorNeb()
        {
            if (korNebezpechny.Count < 2) return;
            List<KorNebezpechny> listByStart = korNebezpechny.OrderBy(item => item.KmStart).ToList();
            List<KorNebezpechny> listByEnd = new List<KorNebezpechny>();
            List<KorNebezpechny> res = new List<KorNebezpechny>();
            float kmStart = 0;
            float kmEnd = 0;
            foreach (KorNebezpechny item in listByStart)
            {
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
                res.Add(new KorNebezpechny(kmStart, itemEnding.KmEnd, korNebDescription));
                kmStart = itemEnding.KmEnd;
                listByEnd.Remove(itemEnding);
            }
            korNebezpechny = res;
        }
    }
}
