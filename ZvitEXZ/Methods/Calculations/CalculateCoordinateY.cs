using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.Calculations
{
    public class CalculateCoordinateY
    {
        double UMinY;
        double UMaxY;
        double UMin;
        double UMax;
        public CalculateCoordinateY(double uMin, double uMax, double uMinY, double uMaxY)
        {
            UMax = uMax;        //Utz max значение на шкале
            UMaxY = uMaxY;      //Utz min значение на шкале
            UMinY = uMinY;      //координата Y by Utz min
            UMin = uMin;        //координата Y by Utz max
        }
        public CalculateCoordinateY(CalculationYSettings ySettings) : this(ySettings.UMin, ySettings.UMax, ySettings.UMinY, ySettings.UMaxY)
        {

        }

        public double Calculate(double? value)
        {
            return UMinY + (UMaxY - UMinY) / (UMax - UMin) * ((double)value - UMin);
        }
    }
}
