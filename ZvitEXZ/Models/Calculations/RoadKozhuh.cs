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
        public double Km { get; set; }
        public int? KozhuhLength { get; set; }
        public bool HasKozhuh { get; set; }
        public string Kozhuh { get; set; }
        public string ProtectionType { get; set; }
        public string CheckPlace { get; set; }
        public string UtzOn { get; set; }
        public string UtzOff { get; set; }
        public string UkozhOn { get; set; }
        public string UkozhOff { get; set; }
        public double? UtzStart { get; set; }
        public double? UtzFinish { get; set; }
        public string AtestationKontakt { get; set; }
        public AtestationVumiruKozhuhs AtestationVumiruKozhuh { get; set; }
        public int NumberSvyazky { get; set; }
        public List<Zamer> PVsSvechas { get; set; }
        public bool IsPvStartProvodUtz { get; set; }
        public bool IsPvEndProvodUtz { get; set; }
        public bool IsPvStartProvodUkozh { get; set; }
        public bool IsPvEndProvodUkozh { get; set; }
        public bool IsSvechaStart { get; set; }
        public bool IsSvechaEnd { get; set; }
        public bool IsCalculated { get; set; }
        public string PvStartProvodUtz { get; set; }
        public string PvEndProvodUtz { get; set; }
        public string PvStartProvodUkozh { get; set; }
        public string PvEndProvodUkozh { get; set; }
        public string SvechaEnd { get; set; }
        public string SvechaStart { get; set; }
        public string Primechanye { get; set; }
        public string Atestation { get; set; }
        public string Recomendation { get; set; }
        public RoadKozhuh(Road road, double? lastUtz = null)
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
            UtzOff = $"-{ConvertToString.DoubleToString(road.UtzStartOff)} / -{ConvertToString.DoubleToString(road.UtzFinishOff)}";
            UkozhOn = "";
            UkozhOff = $"-{ConvertToString.DoubleToString(road.UkzStartOff)} / -{ConvertToString.DoubleToString(road.UkzFinishOff)}";
            UtzStart = lastUtz;
            NumberSvyazky = road.NumberSvyazky;
            PVsSvechas = new List<Zamer>();
            IsPvStartProvodUkozh = false;
            IsPvStartProvodUtz = false;
            IsPvEndProvodUtz = false;
            IsPvEndProvodUkozh = false;
            IsSvechaStart = false;
            IsSvechaEnd = false;
        }
        public void Calculate()
        {

            PvStartProvodUtz = ProvodNaPerehode(IsPvStartProvodUtz,
                IsPvStartProvodUtz || IsPvStartProvodUkozh, true);
            PvStartProvodUkozh = ProvodNaPerehode(IsPvStartProvodUkozh,
                 IsPvStartProvodUtz || IsPvStartProvodUkozh, HasKozhuh);
            PvEndProvodUtz = ProvodNaPerehode(IsPvEndProvodUtz,
                IsPvEndProvodUtz || IsPvEndProvodUkozh, true);
            PvEndProvodUkozh = ProvodNaPerehode(IsPvEndProvodUkozh,
                IsPvEndProvodUtz || IsPvEndProvodUkozh, HasKozhuh);
            SvechaStart = SvechaNaPerehode(IsSvechaStart, HasKozhuh);
            SvechaEnd = SvechaNaPerehode(IsSvechaEnd, HasKozhuh);
            Primechanye = HasKozhuh ? "" : "кожух відсутній";
            string isSvechaNaPerehode = HasKozhuh && !IsSvechaStart && !IsSvechaEnd ?
                "На переході відсутня витяжна свічка. " : "";
            Atestation = HasProvod(true, IsPvStartProvodUtz, IsPvStartProvodUkozh, HasKozhuh, out string nUse) +
                 HasProvod(false, IsPvEndProvodUtz, IsPvEndProvodUkozh, HasKozhuh, out nUse) +
                 isSvechaNaPerehode + AtestationContact( out nUse);
            Recomendation = GetRecomendation();
            IsCalculated = true;
        }
        private string ProvodNaPerehode(bool provodExist, bool pvExist, bool kozhuhExist)
        {
            if (!kozhuhExist) return "кожух відсутній";
            if (!pvExist) return "ПВ відсутній";
            if (provodExist) return "присутній";
            return "відсутній";
        }
        private string SvechaNaPerehode(bool svechaExist, bool kozhuhExist)
        {
            if (!kozhuhExist) return "кожух відсутній";
            if (!svechaExist) return "відсутня";
            return "в наявності";
        }
        private string HasProvod(bool startPerehoda, bool provodUtz, bool provodUkozh, bool hasKozhuh, out string recomeddation)
        {
            recomeddation = "";
            if (provodUtz && provodUkozh) return "";
            if (provodUtz && !hasKozhuh) return "";
            string res = startPerehoda ? " на початку переходу " : " в кінці переходу ";
            if (!provodUtz && !hasKozhuh)
            {
                recomeddation = $"встановити ПВ {res.ToLower()}; ";
                return $"{res}ПВ відсутній. ";
            }
            if (!provodUtz && !provodUkozh)
            {
                recomeddation = $"встановити ПВ з виводами від трубопроводу та кожуха {res.ToLower()}, ";
                return $"{res}ПВ відсутній. ";
            }
            if (!provodUtz && provodUkozh)
            {
                recomeddation = $" обладнати ПВ  виводом від трубопроводу  {res.ToLower()}; ";
                return $"{res} вивід від трубопроводу відсутній. ";
            }
            if (provodUtz && !provodUkozh)
            {
                recomeddation = $" обладнати ПВ  виводом від захисного кожуха  {res.ToLower()}; ";
                return $"{res} вивід від захисного кожуха відсутній. ";
            }
            return "";
        }
        private string AtestationContact( out string recomendation)
        {
            recomendation = "";
            if (!HasKozhuh) return "";
            if (AtestationVumiruKozhuh == AtestationVumiruKozhuhs.noKontakt) return "Контакт відсутній";
            if (AtestationVumiruKozhuh == AtestationVumiruKozhuhs.kontakt)
            {
                recomendation = "усунути прямий контакт захисного кожуха з трубопроводом";
                return "Визначенно наявність прямого (електричного) контакту захисного кожуха з трубопроводом";
            }
            if (AtestationVumiruKozhuh == AtestationVumiruKozhuhs.elektrolitKontakt)
            {
                recomendation = "усунути електролітичний контакт захисного кожуха з трубопроводом";
                return "Визначенно наявність електролітичного контакту захисного кожуха з трубопроводом";
            }
            if (AtestationVumiruKozhuh == AtestationVumiruKozhuhs.coudNotCheck)
                return "Визначення наявності контакту захисного кожуха з трубопроводом неможливе за низьким значенням захисного потенціалу.";
            if (AtestationVumiruKozhuh == AtestationVumiruKozhuhs.noPV)
                return "Визначення наявності контакту захисного кожуха з трубопроводом неможливе за відсутнісю місць вимірювання захисного потенціалу.";
            return "";
        }
        private string GetRecomendation()
        {
            string res = "";
            if (!HasKozhuh)
            {
                if (!IsPvStartProvodUtz) res = res + " встановити ПВ на початку переходу,";
                if (!IsPvEndProvodUtz) res = res + " встановити ПВ в кінці переходу,";
            }
            else
            {
                HasProvod(true, IsPvStartProvodUtz, IsPvStartProvodUkozh, HasKozhuh, out string recomendStart);
                HasProvod(false, IsPvEndProvodUtz, IsPvEndProvodUkozh, HasKozhuh, out string recomendEnd);
                string recomendSvecha = "";
                if (!IsSvechaStart && !IsSvechaEnd) recomendSvecha = "обладнати захисний кожух витяжною свічкою; ";
                AtestationContact( out string recomendContact);
                res = $"{res}{recomendStart}{recomendEnd}{recomendSvecha}{recomendContact}";
            }
            return res;
        }
    }
}
