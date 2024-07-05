using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    public class CalculationYSettings
    {
        public double UMinY { get; set; }
        public double UMaxY { get; set; }
        public double UMax { get; set; }
        public double UMin { get; set; }
        public double ShkalaStep { get; set; }
        public CalculationYSettings(double uMin, double uMax, double uMinY, double uMaxY, double shkalaStep = 1)
        {
            UMin = uMin;
            UMax = uMax;
            UMinY = uMinY;
            UMaxY = uMaxY;
            ShkalaStep = shkalaStep;
        }
    }
}
