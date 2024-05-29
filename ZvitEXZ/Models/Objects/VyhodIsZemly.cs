using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class VyhodIsZemly : Zamer
    {
        public PerehodTypes PerehodType { get; set; }
        public Flanets _Flanets { get; set; }

        public VyhodIsZemly(object[] data) : base(data)
        {
            Name = Constants.VyhodIsZemlyName;
            string flanetsPlace = "";
            if (data[109] == null)
            {
                PerehodType = PerehodTypes.undefined;
            }
            else if (data[109].ToString() == "початок")
            {
                PerehodType = PerehodTypes.start;
                flanetsPlace = "на початку переходу";
            }
            else
            {
                PerehodType = PerehodTypes.finish;
                flanetsPlace = "в кінці переходу";
            }
            _Flanets = new Flanets(Km, $"{Name} км {ConvertToString.FloatToString(Km)}", "-", data[209], data[210],
                data[110], data[111], data[123], flanetsPlace, data[211], data[224]);
        }
        public override string ToString()
        {
            if (PerehodType == PerehodTypes.start) return $"{Name} початок";
            if (PerehodType == PerehodTypes.finish) return $"{Name} кінець";
            return Name;
        }
    }
    public enum PerehodTypes { undefined, start, finish }
}
