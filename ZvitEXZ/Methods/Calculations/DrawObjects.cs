using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    public class DrawObjects
    {
        public void AddObjects(ref AcadDoc acadDoc, List<Zamer> zamers, CalculateCoordinateX X, double kmStart, double kmEnd, double kmPerDrawing)
        {
            double thisPipeScale = (kmEnd - kmStart) * AcadConstants.LenthXByDoc / kmPerDrawing;
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerText));
            acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ThisPipe, AcadConstants.DocStartX, AcadConstants.PipeStartY, thisPipeScale));
        }
    }
}
