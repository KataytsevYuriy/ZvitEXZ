using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.AcadModels
{
    public class DrawLayer : DrawingStep
    {
        public string LayerName { get; set; }
        public DrawLayer(string layerName) : base(AcadConstants.DrawingLayerName)
        {
            LayerName = layerName;
        }
        public override int CellsCount()
        {
            return 2;
        }
    }
}
