using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    public class AcadZamer
    {
        public double Km { get; set; }
        public double? Value { get; set; }
        public AcadZamer(double km, double? value)
        {
            Km = km;
            Value = value;
        }
    }
}
