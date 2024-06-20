using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class AcadDriwing
    {
        public double XScale { get; set; }
        public double XZero { get; set; }
        public double YZero { get; set; }
        public List<ListPotencials> Utz { get; set; }
        public AcadDriwing(List<ListPotencials> utz, double yZero = 1, double xScale = 0, double xZero = 0)
        {
            Utz = utz;
            XScale = xScale;
            XZero = xZero;
            YZero = yZero;

        }
    }
}
