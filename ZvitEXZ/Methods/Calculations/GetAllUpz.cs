using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllUpz
    {
        public List<UPZ> Get(List<Zamer> zamers)
        {
            List<UPZ> result = new List<UPZ>();
            List<Road> roads = new List<Road>();
            foreach (Zamer zamer in zamers)
            {
                if (zamer.Name == ProjectConstants.UPZName) result.Add(zamer as UPZ);
                if (zamer.Name == ProjectConstants.RoadName) roads.Add(zamer as Road);
            }
            foreach (UPZ upz in result)
            {
                if (upz.NumberSvyazky == 0) continue;
                Road road = roads.FirstOrDefault(i => i.NumberSvyazky == upz.NumberSvyazky);
                if (road == null) continue;
                switch (road.AtestationVumiruKozhuh)
                {
                    case AtestationVumiruKozhuhs.noKontakt: upz.HasContact = "контакт відсутній"; break;
                    case AtestationVumiruKozhuhs.elektrolitKontakt: upz.HasContact = "електролітичний контакт"; break;
                    case AtestationVumiruKozhuhs.kontakt: upz.HasContact = "прямий (електричний) контакт"; break;
                    case AtestationVumiruKozhuhs.noPV: upz.HasContact = "відсутні засоби контр."; break;
                    case AtestationVumiruKozhuhs.coudNotCheck: upz.HasContact = "не можливо роз'єднати"; break;
                    default: upz.HasContact = ""; break;
                }
            }
            return result;
        }
    }
}
