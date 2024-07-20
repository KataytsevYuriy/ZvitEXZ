using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class Otvod : Zamer
    {
        public string OtvodName { get; set; }
        public Napravlenye NapravlOtvoda { get; set; }
        public Otvod(object[] data) : base(data)
        {
            Name = ProjectConstants.OtvodName;
            if (data[73] == null)
            {
                OtvodName = "";
                Logs.AddError($"км {data[1]} укажите название отвода");
            }
            else
            {
                OtvodName = data[73].ToString();
            }
            if (data[74] == null)
            {
                NapravlOtvoda = Napravlenye.undefined;
                Logs.AddError($"км {data[1]} задайте направление отвода");
            }
            else
            {
                switch (data[74])
                {
                    case "ліво": NapravlOtvoda = Napravlenye.left; break;
                    case "право": NapravlOtvoda = Napravlenye.right; break;
                    default:
                        NapravlOtvoda = Napravlenye.undefined;
                        Logs.AddError($"км {data[1]} неверно задано направление отвода");
                        break;
                }
            }
            IsOrientir = true;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(OtvodName)) return Name;
            return $"{Name} {OtvodName}";
        }
        public override string GetCadType()
        {
            if (NapravlOtvoda == Napravlenye.right) return AcadConstants.ObjOtvodRight;
            return AcadConstants.ObjOtvodLeft;
        }
        public override string GetCadSignature()
        {
            if (string.IsNullOrEmpty(OtvodName)) return base.GetCadSignature();
            return OtvodName;
        }
    }
}