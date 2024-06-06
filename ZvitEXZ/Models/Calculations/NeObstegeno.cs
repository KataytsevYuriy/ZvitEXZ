using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class NeObstegeno : Dylyanka
    {
        public string Description { get; set; }
        public NeObstegeno(float kmStart, float kmFinish, string description = "") : base(kmStart, kmFinish)
        {
            Description = description;
        }
    }
}
