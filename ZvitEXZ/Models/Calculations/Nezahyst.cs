using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class Nezahyst
    {
        public float KmStart { get; set; }
        public float KmEnd { get; set; }
        public float MinUtz { get; set; }
        public string MinGpsN { get; set; }
        public string MinGpsE { get; set; }
        public Nezahyst(float kmStart, float kmEnd, float minUtz, string minGpsN, string minGpsE)
        {
            KmStart = kmStart;
            KmEnd = kmEnd;
            MinUtz = minUtz;
            MinGpsN = minGpsN;
            MinGpsE = minGpsE;
        }
    }
}
