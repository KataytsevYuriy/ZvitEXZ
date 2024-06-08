using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class Povregdenya : Dylyanka
    {
        public double MaxGradient { get; set; }
        public double UMaxGradient { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public int Cherga { get; set; }
        public MestnostType Mestnost { get; set; }
        public Povregdenya(double kmStart, double kmFEnd, int cherga, double maxGradient, double uMaxGradient,
            string GpsN, string GpsE, MestnostType mestnost) : base(kmStart, kmFEnd)
        {
            Cherga = cherga;
            MaxGradient = maxGradient;
            UMaxGradient = uMaxGradient;
            this.GpsN = GpsN;
            this.GpsE = GpsE;
            Mestnost = mestnost;
        }
        public Povregdenya(Povregdenya povregdenye) : base(povregdenye.KmStart, povregdenye.KmEnd)
        {
            Cherga = povregdenye.Cherga;
            MaxGradient = povregdenye.MaxGradient;
            UMaxGradient = povregdenye.UMaxGradient;
            this.GpsN = povregdenye.GpsN;
            this.GpsE = povregdenye.GpsE;
            Mestnost = povregdenye.Mestnost;
        }
        public override Dylyanka Trim(Dylyanka trimmer, ref Dylyanka ostatok)
        {
            Dylyanka result = null;
            Povregdenya povregd = ostatok as Povregdenya;
            if (KmStart < trimmer.KmStart && KmEnd >= trimmer.KmStart)
            {
                result = new Povregdenya(ostatok.KmStart, trimmer.KmStart, povregd.Cherga, 0, 0, "", "", MestnostType.IndefinedType);
            }
            if (ostatok.KmStart <= trimmer.KmEnd && ostatok.KmEnd > trimmer.KmEnd &&
                trimmer.KmEnd < KmEnd)
            {
                ostatok = new Povregdenya(trimmer.KmEnd, KmEnd, povregd.Cherga, 0, 0, "", "", MestnostType.IndefinedType);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
