using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods.Calculations
{
    internal class CalculateValueByKm
    {
        public double Calcculate(double kmStart, double? valueStart, double kmFinish, double? valueFinish, double kmCalculated)
        {
            if (kmStart == kmFinish) return (double)valueStart;
            return (double)valueStart - (kmStart - kmCalculated) * ((double)valueStart - (double)valueFinish) / (kmStart - kmFinish);
        }
    }
}
