
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods.Calculations
{
    public class Crossing
    {
        private double crossLine;
        public Crossing(double crossline)
        {
            crossLine = crossline;
        }
        public double GetCrossing(double uStart, double kmStart, double uEnd, double kmEnd)
        {
            if (kmStart == kmEnd) return kmStart;
            return Math.Round(kmStart - (uStart - crossLine) * (kmStart - kmEnd) / (uStart - uEnd), 3);
        }
    }
}
