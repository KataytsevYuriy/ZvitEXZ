using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class KorNebezpechny:Dylyanka
    {
        public string Description { get; set; }
        public KorNebezpechny(float kmStart, float kmEnd, string description):base(kmStart,kmEnd)
        {
            Description=description;
        }
        //public override dy
    }
}
