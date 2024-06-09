using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class NenormHlubyna : Dylyanka
    {
        public double HlubMin { get; set; }
        public double HlubNorma { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public string Description { get; set; }
        public NenormHlubyna(double kmStart, double kmFinish, double hlubMin, double hlubNorma,
            string gpsN, string gpsE, string description) : base(kmStart, kmFinish)
        {
            HlubMin = hlubMin;
            HlubNorma = hlubNorma;
            GpsN = gpsN;
            GpsE = gpsE;
            Description = description;
        }
        public override Dylyanka Trim(Dylyanka trimmer, ref Dylyanka ostatok)
        {
            Dylyanka result = null;
            NenormHlubyna nenormHlub = ostatok as NenormHlubyna;
            if (KmStart < trimmer.KmStart && KmEnd >= trimmer.KmStart)
            {
                result = new NenormHlubyna(ostatok.KmStart, trimmer.KmStart, -1, HlubNorma, "", "", Description);
            }
            if (ostatok.KmStart <= trimmer.KmEnd && ostatok.KmEnd > trimmer.KmEnd &&
                trimmer.KmEnd < KmEnd)
            {
                ostatok = new NenormHlubyna(trimmer.KmEnd, KmEnd, -1, HlubNorma, "", "", Description);
            }
            else
            {
                ostatok = null;
            }
            return result;
        }
    }
}
