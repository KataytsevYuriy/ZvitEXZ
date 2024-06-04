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
        public float? USvechy { get; set; }
        public Svecha(object[] data) : base(data)
        {
            Name = ProjectConstants.SvechaName;
            if (data[47] == null)
            {
                Specification = SvechaSpecifications.SpecificationType.undefined;
                Logs.AddError($"км {data[1]} не задана спецификация свечи");
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
                        Logs.AddError($"км {data[1]} неверно задана спецификация свечи");
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
                        Logs.AddError($"км {data[1]} неверно задано техничесское состояние");
                        break;
                }
            }
            if (data[49] == null)
            {
                USvechy = null;
                Logs.AddError($"км {data[1]} не задан потенциал свечи");
            }
            else
            {
                try
                {
                    USvechy = Parse.ParseFloat(data[49]);
                }
                catch
                {
                    USvechy = null;
                    Logs.AddError($"км {data[1]} неверно задан потенциал свечи");
                }
            }
            if (data[248] == null)
            {
                NumberSvyazky = 0;
            }
            else
            {
                try
                {
                    NumberSvyazky = (int)Parse.ParseFloat(data[248]);
                }
                catch
                {
                    NumberSvyazky = 0;
                    Logs.AddError($"км {data[1]} проверьте номер привязки");
                }
            }
        }
        public override string ToString()
        {
            return ProjectConstants.SvechaName;
        }
    }
}
