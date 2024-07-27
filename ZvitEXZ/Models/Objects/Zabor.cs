using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class Zabor : Zamer
    {
        public string ObjectName { get; set; }

        public Zabor(object[] data) : base(data)
        {
            Name = ProjectConstants.ZaborName;
            if (data[221] == null)
            {
                ObjectName = "";
            }
            else
            {
                ObjectName = data[221].ToString();
            }
            IsOrientir = true;
        }
        public override string ToString()
        {
            string objName = string.IsNullOrEmpty(ObjectName) ? "" : " " + ObjectName;
            return $"{Name}{objName}";
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjZabor;
        }
        public override string GetCadSignature()
        {
            if (!string.IsNullOrEmpty(ObjectName))
                return $"{Name} {ObjectName}";
            return base.GetCadSignature();
        }
    }
}
