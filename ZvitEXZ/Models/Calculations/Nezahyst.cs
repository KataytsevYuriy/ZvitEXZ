using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class Nezahyst : Dylyanka
    {
        public double MinUtz { get; set; }
        public string MinGpsN { get; set; }
        public string MinGpsE { get; set; }
        public Nezahyst(double kmStart, double kmEnd, double minUtz, string minGpsN, string minGpsE)
            : base(kmStart, kmEnd)
        {
            MinUtz = Math.Round(minUtz, 3);
            MinGpsN = minGpsN;
            MinGpsE = minGpsE;
        }
        public override Dylyanka Trim(Dylyanka dylyanka, ref Dylyanka ostatok)
        {
            Nezahyst result = null;
            if (KmStart < dylyanka.KmStart && KmEnd > dylyanka.KmStart)
            {
                result = new Nezahyst(ostatok.KmStart, dylyanka.KmStart, 0, "", "");
            }
            if (ostatok.KmStart < dylyanka.KmEnd && ostatok.KmEnd > dylyanka.KmEnd)
            {
                ostatok = new Nezahyst(dylyanka.KmEnd, KmEnd, 0, "", "");
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
