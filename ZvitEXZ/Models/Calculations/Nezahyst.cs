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
        public override Dylyanka Trim(Dylyanka trimmer, ref Dylyanka ostatok)
        {
            Nezahyst result = null;
            if (KmStart < trimmer.KmStart && KmEnd > trimmer.KmStart)
            {
                result = new Nezahyst(ostatok.KmStart, trimmer.KmStart, 0, "", "");
            }
            if (ostatok.KmStart < trimmer.KmEnd && ostatok.KmEnd > trimmer.KmEnd)
            {
                ostatok = new Nezahyst(trimmer.KmEnd, KmEnd, 0, "", "");
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
