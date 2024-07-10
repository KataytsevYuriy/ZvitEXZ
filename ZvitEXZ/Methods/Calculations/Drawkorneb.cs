using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    internal class Drawkorneb
    {
        public void AddKorneb(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<KorNebezpechny> korNebezpechnies)
        {
            {
                foreach (KorNebezpechny Korneb in korNebezpechnies)
                {
                    if (kmStart > Korneb.KmEnd) continue;
                    if (kmEnd < Korneb.KmStart) break;
                    double start = kmStart > Korneb.KmStart ? kmStart : Korneb.KmStart;
                    double end = kmEnd > Korneb.KmEnd ? Korneb.KmEnd : kmEnd;
                    acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ZalivkaRed, X.Calkulate(start), AcadConstants.KornebStartY,
                        X.Calkulate(end) - X.Calkulate(start)));
                }
            }
        }
    }
}
