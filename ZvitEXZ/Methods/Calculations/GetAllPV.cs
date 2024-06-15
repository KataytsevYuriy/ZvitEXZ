using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    public class GetAllPV
    {
        public List<PV> Get(List<Zamer> data)
        {
            List<PV> pvs = new List<PV>();
            foreach (Zamer zamer in data)
            {
                if (zamer.Name == ProjectConstants.PVName) { pvs.Add(zamer as PV); }
                else if (zamer.Name == ProjectConstants.KranName)
                {
                    Kran kran = zamer as Kran;
                    pvs.Add(new PV(kran.Km, kran.GpsN, kran.GpsE, kran.UKrana, kran.ToString()));
                }
                else if (zamer.Name == ProjectConstants.DripName)
                {
                    Drip drip = zamer as Drip;
                    pvs.Add(new PV(drip.Km, drip.GpsN, drip.GpsE, drip.Utz, drip.ToString()));
                }
                //return data.Where(item => item.Name == ProjectConstants.PVName).Select(el => el as PV).ToList();
            }
            return pvs;
        }
    }
}
