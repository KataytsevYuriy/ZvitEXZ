using Aspose.Cells.Pivot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class DrawingText : DrawingStep
    {
        public string Text { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Size { get; set; }
        public string Alignment { get; set; }
        public DrawingText(string text, double x, double y, double size, string alignment = "l") : base(AcadConstants.DrawingTextName)
        {
            Text = text;
            X = x;
            Y = y;
            Size = size;
            Alignment = alignment;
        }
        public override int CellsCount()
        {
            return 6;
        }

    }
}
