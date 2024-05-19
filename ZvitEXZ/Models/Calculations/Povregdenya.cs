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
        public float KmStart { get; set; }
        public float KmFinish { get; set; }
        public float MaxGradient { get; set; }
        public float UMaxGradient { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public int Cherga { get; set; }
        public MestnostType Mestnost { get; set; }
        public Povregdenya(float kmStart, float kmFinish, int cherga,
            float maxGradient, float uMaxGradient, string GpsN, string GpsE, MestnostType mestnost)
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
