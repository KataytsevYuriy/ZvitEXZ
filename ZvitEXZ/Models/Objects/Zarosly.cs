using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Zarosly : Pereshkoda
    {
        public Zarosly(object[] data) : base(data)
        {
            Name = ProjectConstants.ZaroslyName;
        }
        public override string ToString()
        {
            if (Length != 0) return $"{Name} {Length}м";
            return Name;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjZaroslyNP;
        }
    }
}
