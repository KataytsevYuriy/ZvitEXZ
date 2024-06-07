using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class Povregdenya
    {
        public double KmStart { get; set; }
        public double KmFinish { get; set; }
        public double MaxGradient { get; set; }
        public double UMaxGradient { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public int Cherga { get; set; }
        public MestnostType Mestnost { get; set; }
        public Povregdenya(double kmStart, double kmFinish, int cherga,
            double maxGradient, double uMaxGradient, string GpsN, string GpsE, MestnostType mestnost)
        {
            KmStart=kmStart;
            KmFinish=kmFinish;
            Cherga=cherga;
            MaxGradient=maxGradient;
            UMaxGradient=uMaxGradient;
            this.GpsN = GpsN;
            this.GpsE = GpsE;
            Mestnost=mestnost;
        }
        public Povregdenya(Povregdenya povregdenye)
        {
            KmStart = povregdenye.KmStart;
            KmFinish = povregdenye.KmFinish;
            Cherga = povregdenye.Cherga;
            MaxGradient = povregdenye.MaxGradient;
            UMaxGradient = povregdenye.UMaxGradient;
            this.GpsN = povregdenye.GpsN;
            this.GpsE = povregdenye.GpsE;
            Mestnost = povregdenye.Mestnost;
        }
    }
}
