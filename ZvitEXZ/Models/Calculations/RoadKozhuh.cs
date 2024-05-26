using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Calculations
{
    public class RoadKozhuh
    {
        public string RoadName { get; set; }
        public RoadTypes RoadType { get; set; }
        public float Km { get; set; }
        public int? KozhuhLength { get; set; }
        public bool HasKozhuh { get; set; }
        public string Kozhuh { get; set; }
        public string ProtectionType { get; set; }
        public string CheckPlace { get; set; }
        public string UtzOn { get; set; }
        public string UtzOff { get; set; }
        public string UkozhOn { get; set; }
        public string UkozhOff { get; set; }
        public float? UtzStart { get; set; }
        public float? UtzFinish { get; set; }
        public string AtestationKontakt { get; set; }
        public AtestationVumiruKozhuhs AtestationVumiruKozhuh { get; set; }
        public int NumberSvyazky { get; set; }
        public List<Zamer> PVsSvechas { get; set; }
        public bool IsPvStartPtovodUtz { get; set; }
        public bool IsPvEndPtovodUtz { get; set; } 
        public bool IsPvStartPtovodUkozh { get; set; }
        public bool IsPvEndPtovodUkozh { get; set; } 
        public bool IsSvechaStart { get; set; }
        public bool IsSvechaEnd { get; set; }
        public RoadKozhuh(Road road, float? lastUtz = null)
        {
            RoadName = road.ToString();
            RoadType = road.RoadType;
            Km = road.Km;
            HasKozhuh = road.HasKozhuh;
            KozhuhLength = road.KozhuhLength;
            ProtectionType = road.HasProtection();
            AtestationKontakt = road.HasKontakt();
            AtestationVumiruKozhuh = road.AtestationVumiruKozhuh;
            CheckPlace = "";
            UtzOn = "";
            UtzOff = $"-{ConvertToString.FloatToString(road.UtzStartOff)} / -{ConvertToString.FloatToString(road.UtzFinishOff)}";
            UkozhOn = "";
            UkozhOff = $"-{ConvertToString.FloatToString(road.UkzStartOff)} / -{ConvertToString.FloatToString(road.UkzFinishOff)}";
            UtzStart = lastUtz;
            NumberSvyazky = road.NumberSvyazky;
            PVsSvechas = new List<Zamer>();
            IsPvStartPtovodUkozh = false;
            IsPvStartPtovodUtz = false;
            IsPvEndPtovodUtz=false;
            IsPvEndPtovodUkozh=false;
            IsSvechaStart = false;
            IsSvechaEnd = false;
        }
    }
}
