using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllFlanets
    {
        public List<Flanets> GetElektroIsolative(List<Zamer> zamers)
        {
            List<Flanets> flantsy = new List<Flanets>();
            List<Zamer> zamerWithFlanets = zamers.Where(z => z.Name == ProjectConstants.GRSName ||
              z.Name == ProjectConstants.VyhodIsZemlyName).ToList();
            foreach (Zamer zamer in zamerWithFlanets)
            {
                if (zamer.Name == ProjectConstants.GRSName)
                {
                    GRS item = zamer as GRS;
                    if (item.Flantsy.Count > 0)
                    {
                        flantsy.AddRange(item.Flantsy);
                    }
                }
                else if (zamer.Name == ProjectConstants.VyhodIsZemlyName)
                {
                    flantsy.Add((zamer as VyhodIsZemly).Flanets);
                }
            }
            return flantsy.Where(fl => fl.FlanetsType == FlanetsTypes.isolative ||
            fl.FlanetsType == FlanetsTypes.mufta).ToList();
        }
    }
}
