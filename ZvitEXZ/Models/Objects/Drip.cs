using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    internal class Drip:Zamer
    {
        public Drip(object[] data) : base(data)
        {
            Name = ProjectConstants.DripName; 
            IsOrientir = true;
        }
        public override string ToString()
        {
            return Name;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjDrip;
        }
    }
}
