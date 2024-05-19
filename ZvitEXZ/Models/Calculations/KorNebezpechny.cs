using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class KorNebezpechny
    {
        public float KmStart { get; set; }
        public float KmFinish { get; set; }
        public string Description { get; set; }
        public KorNebezpechny(float kmStart, float kmEnd, string description)
        {
            KmStart=kmStart;
            KmFinish=kmEnd;
            Description=description;
        }
    }
}
