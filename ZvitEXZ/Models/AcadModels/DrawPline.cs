using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    public class DrawPline : DrawingStep
    {
        public List<double> Values { get; set; }
        public DrawPline() : base(AcadConstants.DrawingPlineName)
        {
            Values = new List<double>();
        }
        public DrawPline(double x1, double y1, double x2, double y2) : this()
        {
            Values.Add(x1);
            Values.Add(y1);
            Values.Add(0);
            Values.Add(x2);
            Values.Add(y2);
            Values.Add(0);
        }
        public override int CellsCount()
        {
            return 2 + Values.Count;
        }
    }
}
