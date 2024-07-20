using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawNezahyst
    {
        public void AddNezah(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<Nezahyst> nezahysts, double startY)
        {
            {
                foreach (Nezahyst nezahyst in nezahysts)
                {
                    if (kmStart > nezahyst.KmEnd) continue;
                    if (kmEnd < nezahyst.KmStart) break;
                    double start = kmStart > nezahyst.KmStart ? kmStart : nezahyst.KmStart;
                    double end = kmEnd > nezahyst.KmEnd ? nezahyst.KmEnd : kmEnd;
                    acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ZalivkaRedSmall, X.Calkulate(start), startY, X.Calkulate(end) - X.Calkulate(start)));
                }
            }
        }
    }
}
