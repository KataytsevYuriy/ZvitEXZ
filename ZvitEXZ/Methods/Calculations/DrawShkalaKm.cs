using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawShkalaKm
    {
        public void AddShkala(ref AcadDoc acadDoc, double documentKmStart, double kmPerDrawing)
        {
            CalculateCoordinateX X = new CalculateCoordinateX(documentKmStart, kmPerDrawing);
            double km = documentKmStart;
            double scale = AcadConstants.AdocDefaultLenthKm / kmPerDrawing;
            while (km <= documentKmStart + kmPerDrawing)
            {
                if (km < documentKmStart + kmPerDrawing)
                    acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ShkalaKmBlockName, X.Calkulate(km), AcadConstants.ShkalaKmStartY, scale));
                if (km % AcadConstants.ShkalaKmDigitStep == 0)
                    acadDoc.DrawingSteps.Add(new DrawingText(ConvertToString.DoubleToString(km, 1), X.Calkulate(km) + AcadConstants.ShkalaKmDigitSdvigX,
                        AcadConstants.ShkalaKmDigitStartY, AcadConstants.ShkalaKmDigitSize));
                km = Math.Round(km + AcadConstants.ShkalaKmStep, 1);
            }
        }
    }
}
