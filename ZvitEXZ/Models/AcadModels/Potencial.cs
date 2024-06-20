using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.AcadModels
{
    internal class Potencial
    {
        public double Km { get; set; }
        public double U { get; set; }
        public Potencial(double km, double u)
        {
            Km = km;
            U = u;
        }
    }
}
