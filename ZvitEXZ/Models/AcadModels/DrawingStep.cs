using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class DrawingStep
    {
        public string Name { get; set; }
        public DrawingStep(string name)
        {
            Name = name;
        }
        public virtual int CellsCount()
        {
            return 3;
        }
    }
}
