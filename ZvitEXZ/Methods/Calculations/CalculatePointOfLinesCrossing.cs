using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.Calculations
{
    internal class CalculatePointOfLinesCrossing
    {
        public void Calculate(double xStart, double xEnd, double firstYStart, double firstYEnd, double secondYStart, double secondYEnd, out double x, out double y)
        {
            x = (xEnd - xStart) * (firstYStart - secondYStart) / (firstYStart - secondYStart + secondYEnd - firstYEnd) + xStart;
            CalculateValueByKm calculateValue = new CalculateValueByKm();

            y = calculateValue.Calcculate(xStart, firstYStart, xEnd, firstYEnd, x);
        }
    }
}
