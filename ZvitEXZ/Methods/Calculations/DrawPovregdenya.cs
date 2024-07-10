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
    internal class DrawPovregdenya
    {
        public void AddPovregdenyas(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<Povregdenya> povregdenyas)
        {
            foreach (Povregdenya povregd in povregdenyas)
            {
                if (kmStart > povregd.KmEnd) continue;
                if (kmEnd < povregd.KmStart) break;
                double start = kmStart > povregd.KmStart ? kmStart : povregd.KmStart;
                double end = kmEnd > povregd.KmEnd ? povregd.KmEnd : kmEnd;
                acadDoc.DrawingSteps.Add(new DrawBlock(GetBlockName(povregd.Cherga), X.Calkulate(start), AcadConstants.PovregdenyaStartY,
                    X.Calkulate(end) - X.Calkulate(start)));
            }
        }
        private string GetBlockName(int cherga)
        {
            switch (cherga)
            {
                case 1: return AcadConstants.ZalivkaRed;
                case 2: return AcadConstants.ZalivkaBlue;
                default: return "";
            }
        }
    }
}
