using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class River : Pereshkoda
    {
        public string RiverName { get; set; }
        public River(object[] data) : base(data)
        {
            Name = ProjectConstants.RiverName;
            if (data[67] == null)
            {
                RiverName = "";
            }
            else
            {
                RiverName = data[67].ToString();
            }
        }
        public override string ToString()
        {
            return $"{Name} {RiverName}";
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjRiver;
        }
        public override string GetCadSignature()
        {
            if (!string.IsNullOrEmpty(RiverName)) return $"річка {RiverName}";
            return base.GetCadSignature();
        }
    }
}
