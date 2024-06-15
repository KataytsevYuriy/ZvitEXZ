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
            NeObstegeno previousNeobsteg = null;
            data = data.OrderBy(x => x.KmStart).ToList();
            foreach (NeObstegeno item in data)
            {
                if (previousNeobsteg == null)
                {
                    previousNeobsteg = item;
                }
                else if (previousNeobsteg.KmEnd <= item.KmStart)
                {
                    result.Add(previousNeobsteg);
                    previousNeobsteg = item;
                }
                else
                {
                    if (previousNeobsteg.KmStart < item.KmStart)
                        result.Add(new NeObstegeno(previousNeobsteg.KmStart, item.KmStart, previousNeobsteg.Description));
                    if (previousNeobsteg.KmEnd < item.KmEnd)
                    {
                        result.Add(new NeObstegeno(item.KmStart, previousNeobsteg.KmEnd, previousNeobsteg.Description + item.Description));
                        previousNeobsteg = new NeObstegeno(previousNeobsteg.KmEnd, item.KmEnd, item.Description);
                    }
                    else if (previousNeobsteg.KmEnd > item.KmEnd)
                    {
                        result.Add(new NeObstegeno(item.KmStart, item.KmEnd, previousNeobsteg.Description + item.Description));
                        previousNeobsteg = new NeObstegeno(item.KmEnd, previousNeobsteg.KmEnd, previousNeobsteg.Description);
                    }
                    else
                    {
                        result.Add(new NeObstegeno(item.KmStart, previousNeobsteg.KmEnd, previousNeobsteg.Description + item.Description));
                        previousNeobsteg = null;
                    }
                }
            }
            if (previousNeobsteg != null)
            {
                result.Add(previousNeobsteg);
            }
            return result;
        }
    }
}
