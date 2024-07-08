using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class DrawHruntActivities
    {
        public void AddHruntActivities(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<HruntAktivity> hruntAktivities)
        {
            foreach (HruntAktivity hruntAktivity in hruntAktivities)
            {
                if (kmStart > hruntAktivity.KmFinish) continue;
                if (kmEnd < hruntAktivity.KmStart) break;
                double start = kmStart > hruntAktivity.KmStart ? kmStart : hruntAktivity.KmStart;
                double end = kmEnd > hruntAktivity.KmFinish ? hruntAktivity.KmFinish : kmEnd;
                acadDoc.DrawingSteps.Add(new DrawBlock(GetBlockName(hruntAktivity.HruntAktivityType), X.Calkulate(start), AcadConstants.HruntActivityStartY,
                    X.Calkulate(end) - X.Calkulate(start)));
            }
        }
        private string GetBlockName(HruntAktivityTypes aktivityType)
        {
            switch (aktivityType)
            {
                case HruntAktivityTypes.low: return AcadConstants.HruntActivitiLow;
                case HruntAktivityTypes.medium: return AcadConstants.HruntActivitiMedium;
                case HruntAktivityTypes.hight: return AcadConstants.HruntActivitiHight;
                default: return "";
            }
        }
    }
}
