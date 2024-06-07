using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Calculations
{
    public class HruntAktivity
    {
        public double KmStart { get; set; }
        public double KmFinish { get; set; }
        public HruntAktivityTypes HruntAktivityType { get; set; }
        public HruntAktivity(double kmStart, double kmFinish, HruntAktivityTypes hruntAktivity)
        {
            KmStart = kmStart;
            KmFinish = kmFinish;
            HruntAktivityType = hruntAktivity;
        }
        public HruntAktivity(double kmStart, double kmFinish, double Rhrunta)
        {
            KmStart = kmStart;
            KmFinish = kmFinish;
            if (Rhrunta == 0) { HruntAktivityType = HruntAktivityTypes.undefined; }
            else if (Rhrunta < 20) { HruntAktivityType = HruntAktivityTypes.hight; }
            else if (Rhrunta > 50) { HruntAktivityType = HruntAktivityTypes.low; }
            else { HruntAktivityType = HruntAktivityTypes.medium; }
        }
    }
    public enum HruntAktivityTypes
    {
        undefined, low, medium, hight
    }
}
