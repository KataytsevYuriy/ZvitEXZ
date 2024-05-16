using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Svish:Zamer
    {
        public Svish(object[] data) : base(data)
        {
            Name=Constants.SvishName;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
