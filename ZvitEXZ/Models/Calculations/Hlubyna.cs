using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Models.Calculations
{
    public class Hlubyna
    {
        public double Km { get; set; }
        public double? HlubynaFakt { get; set; }
        public double HlubynaInterpolated { get; set; }
        public double MinHlubynaDSTU { get; set; }
        public string GpsN { get; set; }
        public string GpsE { get; set; }
        public MestnostType Mestnost { get; set; }
        public string Description { get; set; }
        public Hlubyna(double km, double? hlubynaFakt, double hlabanaInterpolated, string gpsN, string gpsE, MestnostType mestnost, string description)
        {
            Km = km;
            HlubynaFakt = hlubynaFakt;
            HlubynaInterpolated = hlabanaInterpolated;
            GpsN = gpsN;
            GpsE = gpsE;
            Mestnost = mestnost;
            Description = description;
            MinHlubynaDSTU = -1;
        }
        public Hlubyna(Zamer zamer) : this(zamer.Km, zamer.Hlub, -1, zamer.GpsN, zamer.GpsE, zamer.Mestnost, "")
        {

        }
    }
}
