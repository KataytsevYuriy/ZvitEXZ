using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    public class CalculateCoordinateX
    {
        double docKmStart;
        double kmPerDrawing;
        public CalculateCoordinateX(double documentKmStart, double kmPerDrawing)
        {
            docKmStart = documentKmStart;
            this.kmPerDrawing = kmPerDrawing;
        }
        public double Calkulate(double km)
        {
            return (AcadConstants.DocStartX + (km - docKmStart) * AcadConstants.LenthXByDoc / kmPerDrawing);
        }
    }
}
