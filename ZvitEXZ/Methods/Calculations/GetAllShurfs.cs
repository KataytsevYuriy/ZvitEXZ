using System.Collections.Generic;
using System.Linq;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllShurfs
    {
        public List<Shurf> Get(List<Zamer> zamers)
        {
            List<Shurf> shurfs = zamers.Where(el => el.Name == ProjectConstants.ShurfName).Select(sh => sh as Shurf).ToList();
            return shurfs;
        }
    }
}
