using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class Forest : Dylyanka
    {
        public bool ToClean { get; set; }
        public Forest(double kmStart, double kmEnd, bool toClean) : base(kmStart, kmEnd)
        {
            ToClean = toClean;
        }
    }
}
