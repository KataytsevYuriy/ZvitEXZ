using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    public class GetAllUkz
    {
        public List<Zamer> Get(List<Zamer> data)
        {
            return data.Where(item => item.Name == Constants.UKZName).ToList();
        }
    }
}
