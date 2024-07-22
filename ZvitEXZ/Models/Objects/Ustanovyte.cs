using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class Ustanovyte : Zamer
    {
        public UstanovytObjectTypes Ustanovyt { get; set; }
        public string TechnuculInformation { get; set; }
        public Ustanovyte(object[] data) : base(data)
        {
            Name = ProjectConstants.UstanovytName;
            if (data[256] == null)
            {
                Ustanovyt = UstanovytObjectTypes.undefined;
            }
            else
            {
                switch (data[256])
                {
                    case "ПВ кілометровий":
                    case "ПВ перех. дорогу":
                    case "ПВ водн. перешк.":
                    case "ПВ БЗК":
                    case "ПВ в ТД":
                        Ustanovyt = UstanovytObjectTypes.pv;
                        break;
                    case "столб указательный": Ustanovyt = UstanovytObjectTypes.stolb; break;
                    case "УКЗ": Ustanovyt = UstanovytObjectTypes.ukz; break;
                    case "УДЗ": Ustanovyt = UstanovytObjectTypes.udz; break;
                    case "Протектор": Ustanovyt = UstanovytObjectTypes.protector; break;
                    case "защитный кожух": Ustanovyt = UstanovytObjectTypes.kozhuh; break;
                    case "свеча вытяжная": Ustanovyt = UstanovytObjectTypes.svecha; break;
                    default:
                        Ustanovyt = UstanovytObjectTypes.undefined;
                        Logs.AddError($"км {data[1]} неверно указан тип устанавливаемого объекта");
                        break;
                }
            }
            if (data[257] == null)
            {
                TechnuculInformation = "";
            }
            else
            {
                TechnuculInformation = data[257].ToString();
            }
        }
        public override string ToString()
        {
            string add = string.IsNullOrEmpty(TechnuculInformation) ? "" : $", {TechnuculInformation}";
            switch (Ustanovyt)
            {
                case UstanovytObjectTypes.pv: return $"{Name} ПВ{add}";
                case UstanovytObjectTypes.ukz: return $"{Name} УКЗ{add}";
                case UstanovytObjectTypes.udz: return $"{Name} УДЗ{add}";
                case UstanovytObjectTypes.svecha: return $"{Name} свічу{add}";
                case UstanovytObjectTypes.protector: return $"{Name} протектор{add}";
                case UstanovytObjectTypes.kozhuh: return $"{Name} кожух{add}";
                case UstanovytObjectTypes.stolb: return $"{Name} стовп{add}";
                default: return "";
            }
        }
        public override string GetCadType()
        {
            switch (Ustanovyt)
            {
                case UstanovytObjectTypes.pv: return AcadConstants.ObjUstanovytPV;
                case UstanovytObjectTypes.ukz: return AcadConstants.ObjUstanovytUkz;
                case UstanovytObjectTypes.udz: return AcadConstants.ObjUstanovytUdz;
                case UstanovytObjectTypes.svecha: return AcadConstants.ObjUstanovytSvecha;
                case UstanovytObjectTypes.kozhuh: return AcadConstants.ObjUstanovytKozhuh;
                case UstanovytObjectTypes.stolb: return AcadConstants.ObjUstanovytStolb;
                default: return "";
            }
        }
    }
    public enum UstanovytObjectTypes
    {
        undefined, pv, ukz, udz, svecha, protector, kozhuh, stolb
    }
}
