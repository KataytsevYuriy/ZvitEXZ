using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class NeObstegeno
    {
        public float KmStart { get; set; }
        public float KmFinish { get; set; }
        public string Description { get; set; }
        public NeObstegeno(float kmStart, float kmFinish, string description = "")
        {
            KmStart = kmStart;
            KmFinish = kmFinish;
            Description=description;
        }
    }
}
