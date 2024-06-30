using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    internal class AcadDrawing
    {
        public List<AcadDoc> Docs { get; set; }
        public AcadDrawing()
        {
            Docs = new List<AcadDoc>();
        }
    }
}
