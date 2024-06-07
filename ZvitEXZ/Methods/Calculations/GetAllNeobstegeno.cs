using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllNeobstegeno
    {
        public List<NeObstegeno> Get(List<Zamer> zamers, List<PovitrPerehod> povitrPerehods)
        {
            List<NeObstegeno> result = new List<NeObstegeno>();
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Name == ProjectConstants.RoadName)
                {
                    Road road = zamer as Road;
                    if (road.RoadType == RoadTypes.automobile || road.RoadType == RoadTypes.train)
                    {
                        double addToKozhuh = 0;
                        if (road.HasKozhuh && (int)road.KozhuhLength > (int)road.length)
                        {
                            addToKozhuh = Math.Round((double)(road.KozhuhLength - road.length) / 2000, 3);
                        }
                        result.Add(new NeObstegeno(road.Km - addToKozhuh,
                           Math.Round(road.Km + (double)(road.length) / 1000 + addToKozhuh, 3), road.ToString()));
                    }
                }
                if (zamer.Name == ProjectConstants.RiverName || zamer.Name == ProjectConstants.KanalName ||
                    zamer.Name == ProjectConstants.SwampName || zamer.Name == ProjectConstants.ZaroslyName ||
                    zamer.Name == ProjectConstants.NeobstegenaDylyankaName)
                {
                    Pereshkoda pereshkoda = zamer as Pereshkoda;
                    result.Add(new NeObstegeno(pereshkoda.Km, Math.Round(pereshkoda.Km + (double)pereshkoda.Length / 1000, 3),
                        pereshkoda.ToString()));
                }
            }
            foreach (PovitrPerehod povitrPerehod in povitrPerehods)
            {
                result.Add(new NeObstegeno((double)povitrPerehod.KmStart / 1000, (double)povitrPerehod.KmFinish / 1000,
                    $"повітряний перехід {povitrPerehod.OpysPereshkody}"));
            }
            result = CheckKrossing(result);
            return result;
        }
        private List<NeObstegeno> CheckKrossing(List<NeObstegeno> data)
        {
            List<NeObstegeno> result = new List<NeObstegeno>();
            NeObstegeno last = null;
            data = data.OrderBy(x => x.KmStart).ToList();
            foreach (NeObstegeno item in data)
            {
                if (last == null)
                {
                    last = item;
                    continue;
                }
                if (last.KmEnd < item.KmStart)
                {
                    result.Add(last);
                    last = item;
                }
                else
                {
                    if (last.KmStart > item.KmStart)
                        result.Add(new NeObstegeno(last.KmStart, item.KmStart, last.Description));
                    if (last.KmEnd < item.KmEnd)
                    {
                        result.Add(new NeObstegeno(item.KmStart, last.KmEnd, last.Description + item.Description));
                        last = new NeObstegeno(last.KmEnd, item.KmEnd, item.Description);
                    }
                    else if (last.KmEnd > item.KmEnd)
                    {
                        result.Add(new NeObstegeno(item.KmStart, item.KmEnd, last.Description + item.Description));
                        last = new NeObstegeno(item.KmEnd, last.KmEnd, last.Description);
                    }
                    else
                    {
                        result.Add(new NeObstegeno(item.KmStart, last.KmEnd, last.Description + item.Description));
                        last = null;
                    }
                }
            }
            if (last != null)
            {
                result.Add(last);
            }
            return result;
        }
    }
}
