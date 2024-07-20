using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class GRS : Zamer
    {
        public string NameGrs { get; set; }
        public List<Flanets> Flantsy { get; set; }
        public GRS(object[] data) : base(data)
        {
            Name = ProjectConstants.GRSName;
            NameGrs = ParseData.String(data[78]);
            Flantsy = new List<Flanets>();
            if (data[81] != null) Flantsy.Add(new Flanets(Km, $"{Name} {NameGrs}", "-", data[85], data[86], data[79],
                data[80], data[81], "на вході в ГРС", data[87], data[82]));
            if (data[91] != null) Flantsy.Add(new Flanets(Km, $"{Name} {NameGrs}", "-", data[95], data[96], data[89],
                data[90], data[91], "на виході з ГРС", data[97], data[92]));
            if (data[101] != null) Flantsy.Add(new Flanets(Km, $"{Name} {NameGrs}", "-", data[105], data[106], data[99],
                data[100], data[101], "на виході з ГРС", data[107], data[102]));
            IsOrientir = true;
        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(NameGrs)) return $"{Name} {NameGrs}";
            return Name;
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjGRS;
        }
        public override string GetCadSignature()
        {
            return $"ГРС {NameGrs}";
        }
    }
}
