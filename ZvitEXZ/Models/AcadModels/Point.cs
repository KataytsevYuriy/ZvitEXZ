using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
            Z = 0;
        }
    }
}
