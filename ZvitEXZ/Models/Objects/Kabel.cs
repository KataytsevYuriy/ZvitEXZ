using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Kabel:Zamer
    {
        public Kabel(object[] data) : base(data)
        {
            Name=ProjectConstants.KabelName;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
