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
                        int addToKozhuh = 0;
                        if (road.HasKozhuh && (int)road.KozhuhLength > (int)road.length)
                            addToKozhuh = (int)Math.Round((double)((road.KozhuhLength ?? 0 - road.length ?? 0) / 2));
                        float
                        result.Add(new NeObstegeno(road.Km - addToKozhuh / 1000,
                            road.Km + (float)(road.length + addToKozhuh) / 1000, road.ToString()));
                    }
                }
                if (zamer.Name == ProjectConstants.RiverName || zamer.Name == ProjectConstants.KanalName ||
                    zamer.Name == ProjectConstants.SwampName || zamer.Name == ProjectConstants.ZaroslyName ||
                    zamer.Name == ProjectConstants.NeobstegenaDylyankaName)
                {
                    Pereshkoda pereshkoda = zamer as Pereshkoda;
                    result.Add(new NeObstegeno(pereshkoda.Km, pereshkoda.Km + ((float)pereshkoda.Length )/ 1000,
                        pereshkoda.ToString()));
                }
            }
            foreach (PovitrPerehod povitrPerehod in povitrPerehods)
            {
                result.Add(new NeObstegeno(povitrPerehod.KmStart / 1000, povitrPerehod.KmFinish / 1000,
                    $"повітряний перехід {povitrPerehod.OpysPereshkody}"));
            }
            return result;
        }
    }
}
