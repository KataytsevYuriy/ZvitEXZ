using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class DrawPline : DrawingStep
    {
        public List<double> Values { get; set; }
        public DrawPline() : base(AcadConstants.DrawingPlineName)
        {
            Values = new List<double>();
        }
        public override int CellsCount()
        {
            return 2 + Values.Count;
        }
    }
}
