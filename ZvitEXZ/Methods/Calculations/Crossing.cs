
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
        private bool round;
        public Crossing(double crossline, bool round = true)
        {
            crossLine = crossline;
            this.round = round;
        }
        public double GetCrossing(double uStart, double kmStart, double uEnd, double kmEnd)
        {
            if (kmStart == kmEnd) return kmStart;
            if (uStart == uEnd) return Math.Round((kmStart + kmEnd) / 2, 3);
            if (round)
                return Math.Round(kmStart - (uStart - crossLine) * (kmStart - kmEnd) / (uStart - uEnd), 3);
            return kmStart - (uStart - crossLine) * (kmStart - kmEnd) / (uStart - uEnd);
        }
    }
}
