using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class Lep : Zamer
    {
        public string Voltage { get; set; }
        public Lep(object[] data) : base(data)
        {
            if (data[77] == null)
            {
                Voltage = "";
            }
            else
            {
                Voltage = data[77].ToString();
            }
            Name = ProjectConstants.LepName;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Voltage)) return Name;
            return $"{Name} {Voltage}кВ";
        }
        public override string GetCadType()
        {
            Double.TryParse(Voltage, out double volt);
            switch (volt)
            {
                case 0.4: return AcadConstants.ObjLep04;
                case 6: return AcadConstants.ObjLep10;
                case 10: return AcadConstants.ObjLep10;
                case 35: return AcadConstants.ObjLep35;
                case 110: return AcadConstants.ObjLep110;
                case 154: return AcadConstants.ObjLep110;
                case 220: return AcadConstants.ObjLep220;
                case 330: return AcadConstants.ObjLep330;
                case 500: return AcadConstants.ObjLep500;
                case 750: return AcadConstants.ObjLep750;
                default: return AcadConstants.ObjLep02;
            }
        }
    }
}
