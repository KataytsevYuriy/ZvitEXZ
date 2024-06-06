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
        public float MinUtz { get; set; }
        public string MinGpsN { get; set; }
        public string MinGpsE { get; set; }
        public Nezahyst(float kmStart, float kmEnd, float minUtz, string minGpsN, string minGpsE)
            : base(kmStart, kmEnd)
        {
            MinUtz = minUtz;
            MinGpsN = minGpsN;
            MinGpsE = minGpsE;
        }
        public override Dylyanka Trim(Dylyanka dylyanka, ref Dylyanka ostatok)
        {
            Nezahyst result;
            if (KmStart < dylyanka.KmStart && KmEnd > dylyanka.KmStart)
            {
                result = new Nezahyst(ostatok.KmStart, dylyanka.KmStart,0,"","");
            }
            else
            {
                result = null;
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
