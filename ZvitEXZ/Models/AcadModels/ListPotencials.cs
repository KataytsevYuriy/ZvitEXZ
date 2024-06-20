using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class ListPotencials
    {
        public List<Potencial> Potencials { get; set; }
        public ListPotencials()
        {
            Potencials = new List<Potencial>();
        }
        public ListPotencials(List<Potencial> potencials) : this()
        {
            Potencials = potencials;
        }
    }
}
