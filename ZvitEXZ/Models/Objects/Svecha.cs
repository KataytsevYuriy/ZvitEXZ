using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Svecha : Zamer
    {
        public SvechaSpecifications.SpecificationType Specification { get; set; }
        public SvechaSpecifications.TehnicState TehnicState { get; set; }
        public double? USvechy { get; set; }
        public Svecha(object[] data) : base(data)
        {
            Name = ProjectConstants.SvechaName;
            if (data[47] == null)
            {
                Specification = SvechaSpecifications.SpecificationType.undefined;
                Logs.AddError($"км {data[1]} не задана специфікація свічі");
            }
            else
            {
                switch (data[47])
                {
                    case "витяжна":
                        Specification = SvechaSpecifications.SpecificationType.vytazhna; break;
                    case "продувочна":
                        Specification = SvechaSpecifications.SpecificationType.produvochna; break;
                    default:
                        Specification = SvechaSpecifications.SpecificationType.undefined;
                        Logs.AddError($"км {data[1]} невірно задана специфікация свічі");
                        break;

                }
            }
            if (data[48] == null)
            {
                TehnicState = SvechaSpecifications.TehnicState.undefined;
            }
            else
            {
                switch (data[48])
                {
                    case "обрізана":
                        TehnicState = SvechaSpecifications.TehnicState.obrezana; ; break;
                    case "потребує пофарбування":
                        TehnicState = SvechaSpecifications.TehnicState.needToPaint; break;
                    default:
                        TehnicState = SvechaSpecifications.TehnicState.undefined;
                        Logs.AddError($"км {data[1]} невірно задано технічний стан");
                        break;
                }
            }
            if (data[49] == null)
            {
                USvechy = null;
                Logs.AddError($"км {data[1]} не задан потенціал свічі");
            }
            else
            {
                try
                {
                    USvechy = Parse.ParseDouble(data[49]);
                }
                catch
                {
                    USvechy = null;
                    Logs.AddError($"км {data[1]} невірно задан потенціал свічі");
                }
            }
            if (data[248] == null)
            {
                NumberSvyazky = 0;
                if (Specification != SvechaSpecifications.SpecificationType.produvochna)
                    Logs.AddError($"км {data[1]} свіча є, але не прив'язана до переходу");
            }
            else
            {
                try
                {
                    NumberSvyazky = (int)Parse.ParseDouble(data[248]);
                }
                catch
                {
                    NumberSvyazky = 0;
                    Logs.AddError($"км {data[1]} перевірте номер прив'язки");
                }
            }
        }
        public override string ToString()
        {
            return ProjectConstants.SvechaName;
        }
        public override string GetCadType()
        {
            if (TehnicState == SvechaSpecifications.TehnicState.obrezana) return AcadConstants.ObjSvechaObrez;
            if (Specification == SvechaSpecifications.SpecificationType.produvochna) return AcadConstants.ObjSvechaProduv;
            return AcadConstants.ObjSvechaVytyazh;
        }
    }
}
