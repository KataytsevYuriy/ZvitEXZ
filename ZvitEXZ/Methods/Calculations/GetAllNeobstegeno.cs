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
                        float addToKozhuh = 0;
                        if (road.HasKozhuh && (int)road.KozhuhLength > (int)road.length)
<<<<<<< HEAD
                        {
                            addToKozhuh = (float)Math.Round((double)(road.KozhuhLength - road.length) / 2000, 3);
                        }
                        result.Add(new NeObstegeno(road.Km - addToKozhuh,
                           (float)Math.Round(road.Km + (float)(road.length) / 1000 + addToKozhuh, 3), road.ToString()));
=======
                            addToKozhuh = (int)Math.Round((double)((road.KozhuhLength ?? 0 - road.length ?? 0) / 2));
                        float
                        result.Add(new NeObstegeno(road.Km - addToKozhuh / 1000,
                            road.Km + (float)(road.length + addToKozhuh) / 1000, road.ToString()));
>>>>>>> e4a63cedf9cbb19511b582d4bc648c2ae935c48d
                    }
                }
                if (zamer.Name == ProjectConstants.RiverName || zamer.Name == ProjectConstants.KanalName ||
                    zamer.Name == ProjectConstants.SwampName || zamer.Name == ProjectConstants.ZaroslyName ||
                    zamer.Name == ProjectConstants.NeobstegenaDylyankaName)
                {
                    Pereshkoda pereshkoda = zamer as Pereshkoda;
<<<<<<< HEAD
                    result.Add(new NeObstegeno(pereshkoda.Km, (float)Math.Round(pereshkoda.Km + (float)pereshkoda.Length / 1000, 3),
=======
                    result.Add(new NeObstegeno(pereshkoda.Km, pereshkoda.Km + ((float)pereshkoda.Length )/ 1000,
>>>>>>> e4a63cedf9cbb19511b582d4bc648c2ae935c48d
                        pereshkoda.ToString()));
                }
            }
            foreach (PovitrPerehod povitrPerehod in povitrPerehods)
            {
                result.Add(new NeObstegeno((float)povitrPerehod.KmStart / 1000, (float)povitrPerehod.KmFinish / 1000,
                    $"повітряний перехід {povitrPerehod.OpysPereshkody}"));
            }
            result = CheckKrossing(result);
            return result;
        }
        private List<NeObstegeno> CheckKrossing(List<NeObstegeno> data)
        {
            List<NeObstegeno> result = new List<NeObstegeno>();
            NeObstegeno last = null;
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
