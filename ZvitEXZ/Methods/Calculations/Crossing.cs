using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods.Calculations
{
    public class Crossing
    {
        private float crossLine;
        public Crossing(float crossline)
        {
            crossLine = crossline;
        }
        public float GetCrossing(float uStart, float kmStart, float uEnd, float kmEnd)
        {
            return (float)Math.Round(kmStart - (uStart - crossLine) * (kmStart - kmEnd) / (uStart - uEnd), 3);
        }
    }
}
