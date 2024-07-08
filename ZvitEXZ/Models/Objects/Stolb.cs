using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class Stolb : Zamer
    {
        public StolbTypes StolbType { get; set; }
        public Stolb(object[] data) : base(data)
        {
            Name = ProjectConstants.Stolb;
            if (data[68] == null)
            {
                StolbType = StolbTypes.undefined;
            }
            else
            {
                switch (data[68])
                {
                    case "вказівний": StolbType = StolbTypes.vkazivnuy; break;
                    case "кілометровий": StolbType = StolbTypes.kilimetroviy; break;
                    default:
                        StolbType = StolbTypes.undefined;
                        Logs.AddError($"км {data[1]} неверно указан тип столба");
                        break;

                }
            }
        }
        public override string ToString()
        {
            switch (StolbType)
            {
                case StolbTypes.vkazivnuy: return "вказівний стовп";
                case StolbTypes.kilimetroviy: return "кілометровий стовп";
                default: return "стовп";
            }
        }
        public override string GetCadType()
        {
            if (StolbType == StolbTypes.kilimetroviy) return AcadConstants.ObjStolbKm;
            return AcadConstants.ObjStolbUkaz;
        }
    }
    public enum StolbTypes
    {
        undefined, kilimetroviy, vkazivnuy
    }
}
