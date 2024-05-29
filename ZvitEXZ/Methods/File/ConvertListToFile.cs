using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Methods.File.Converters;

namespace ZvitEXZ.Methods.File
{
    public class ConvertListToFile
    {
        public string[,] ConvertPV(List<Zamer> data)
        {
            if (data.Count == 0) return new string[0, 0];
            string[,] res = new string[data.Count, 11];
            int i = 0;
            foreach (PV item in data)
            {
                res[i, 0] = (item.Km * 1000).ToString();
                res[i, 1] = "спеціалізований ПВ";
                if (string.IsNullOrEmpty(item.PVDiamert)) res[i, 2] = item.PVType;
                else res[i, 2] = $"{item.PVType} Ø{item.PVDiamert}";
                string kabel = $"{item.ProvodType1} x {item.ProvodDyamert1}";
                string pidkluchennya = item.GetTypepidkluchennya(1);
                string potencial = $"-{ConvertToString.FloatToString(item.ProvodPotencial1)}";
                if (!string.IsNullOrEmpty(item.ProvodType2))
                {
                    kabel += $"/ {item.ProvodType2} x {item.ProvodDaymetr2}";
                    pidkluchennya += "/ " + item.GetTypepidkluchennya(2);
                    potencial += "/ " + item.ProvodPotencial2;
                }
                if (!string.IsNullOrEmpty(item.ProvodType3))
                {
                    kabel += $"/ {item.ProvodType3} x {item.ProvodDyametr3}";
                    pidkluchennya += "/ " + item.GetTypepidkluchennya(3);
                    potencial += "/ " + item.ProvodPotencial3;
                }
                res[i, 3] = kabel;
                res[i, 4] = pidkluchennya;
                res[i, 5] = potencial;
                res[i, 6] = "";
                res[i, 7] = item.IsBroken ? "Зламаний" : "робочий";
                res[i, 8] = item.Note;
                res[i, 9] = item.GpsN;
                res[i, 10] = item.GpsE;
                i++;
            }
            return res;
        }
        public string[,] ConvertKorneb(List<KorNebezpechny> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 4];
            int i = 0;
            foreach (KorNebezpechny item in data)
            {
                res[i, 0] = Math.Round(item.KmStart * 1000).ToString();
                res[i, 1] = Math.Round(item.KmFinish * 1000).ToString();
                res[i, 2] = Math.Round((item.KmFinish - item.KmStart) * 1000).ToString();
                res[i, 3] = item.Description;
                i++;
            }
            return res;
        }
        public string[,] ConvertNezah(List<Nezahyst> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 8];
            int i = 0;
            foreach (Nezahyst item in data)
            {
                res[i, 0] = Math.Round(item.KmStart * 1000).ToString();
                res[i, 1] = Math.Round(item.KmEnd * 1000).ToString();
                res[i, 2] = Math.Round((item.KmEnd - item.KmStart) * 1000).ToString();
                res[i, 3] = $"-{Math.Round(item.MinUtz, 3).ToString().Replace(".", ",")}";
                res[i, 4] = "";
                res[i, 5] = "";
                res[i, 6] = item.MinGpsN;
                res[i, 7] = item.MinGpsE;
                i++;
            }
            return res;
        }
        public string[,] ConvertUKZ(List<Zamer> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 25];
            int i = 0;
            foreach (Zamer zamer in data)
            {
                UKZ item = zamer as UKZ;
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = item.Km.ToString().Replace(".", ",");
                res[i, 2] = item.Identificator;
                res[i, 3] = item.TypeUkryttya;
                res[i, 4] = item.PreobrazovatelType;
                res[i, 5] = item.StartUsing;
                res[i, 6] = item.Power.Replace(".", ",");
                res[i, 7] = item.Uwork == null ? "" : item.Uwork.ToString().Replace(".", ",");
                res[i, 8] = item.Iwork == null ? "" : item.Iwork.ToString().Replace(".", ",");
                res[i, 9] = item.Umax == null ? "" : item.Umax.ToString().Replace(".", ",");
                res[i, 10] = item.Imax == null ? "" : item.Imax.ToString().Replace(".", ",");
                if (item.Umax == null || item.Imax == null || item.Uwork == null || item.Iwork == null)
                {
                    res[i, 11] = "";
                }
                else
                {
                    res[i, 11] = Math.Round((float)((item.Uwork * item.Iwork) / (item.Umax * item.Imax) * 100), 1)
                        .ToString("0.0").Replace(".", ",");
                }
                if (item.Imax == null || item.Iwork == null)
                {
                    res[i, 12] = "";
                }
                else
                {
                    res[i, 12] = Math.Round((float)(item.Iwork / item.Imax) * 100, 1).
                        ToString("0.0").Replace(".", ",");
                }
                res[i, 13] = item.RecomendedPower.Replace(".", ",");
                res[i, 14] = item.UtzOn.Replace(".", ",");
                res[i, 15] = item.UtzOff.Replace(".", ",");
                res[i, 16] = item.UtzRecomended.Replace(".", ",");
                res[i, 17] = item.Urecomended.Replace(".", ",");
                res[i, 18] = item.Irecomended.Replace(".", ",");
                res[i, 19] = item.Raz.Replace(".", ",");
                res[i, 20] = item.MarkaKatodProvoda;
                res[i, 21] = item.SecenieKatodProvoda;
                res[i, 22] = item.Raz.Replace(".", ",");
                res[i, 23] = item.TehStan;
                res[i, 24] = item.Note;
                i++;
            }
            return res;
        }
        public string[,] ConvertPovregd(List<Povregdenya> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 10];
            int i = 0;
            foreach (Povregdenya item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = Math.Round(item.KmStart * 1000).ToString();
                res[i, 2] = Math.Round(item.KmFinish * 1000).ToString();
                res[i, 3] = Math.Round((item.KmFinish - item.KmStart) * 1000).ToString();
                res[i, 4] = item.GpsN;
                res[i, 5] = item.GpsE;
                res[i, 6] = Math.Round(item.MaxGradient, 3).ToString();
                res[i, 7] = "-" + Math.Round(item.UMaxGradient, 3).ToString();
                res[i, 8] = item.Cherga.ToString();
                res[i, 9] = "";
                i++;
            }
            return res;
        }
        public string[,] ConvertUpz(List<UPZ> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 18];
            int i = 0;
            foreach (UPZ item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = Math.Round(item.Km, 3).ToString().Replace(".", ",");
                res[i, 2] = item.BuildingDate;
                res[i, 3] = Math.Round((float)item.Rhr).ToString();
                res[i, 4] = item.ProtectorType;
                res[i, 5] = item.ProtectorBuilder;
                res[i, 6] = item.ProtectorCount;
                res[i, 7] = item.DistanceToPipe;
                res[i, 8] = item.HasPV;
                res[i, 9] = item.ConnectionThruPV;
                res[i, 10] = item.ProvodToProtector.Replace(".", ",");
                res[i, 11] = item.ProvodToPipe.Replace(".", ",");
                res[i, 12] = item.IUPZKozhuh.Replace(".", ",");
                res[i, 13] = item.UUPZGround.Replace(".", ",");
                res[i, 14] = item.KozuhGroundWithoutUPZ.Replace(".", ",");
                res[i, 15] = item.KozuhGroundWithUPZ.Replace(".", ",");
                res[i, 16] = item.HasContact;
                res[i, 17] = "";
                i++;
            }
            return res;
        }
        public string[,] ConvertVymirKozhuh(List<RoadKozhuh> roadKozhuhs)
        {
            List<RoadKozhuh> data = new List<RoadKozhuh>();
            if (roadKozhuhs.Count > 0) data = roadKozhuhs.Where(el => el.RoadType == RoadTypes.automobile || el.RoadType == RoadTypes.train).ToList();
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 12];
            int i = 0;
            foreach (RoadKozhuh item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = ConvertToString.FloatToString(item.Km);
                res[i, 2] = item.RoadName;
                res[i, 3] = ConvertToString.FloatToString(item.KozhuhLength);
                res[i, 4] = item.ProtectionType;
                res[i, 5] = item.CheckPlace;
                res[i, 6] = item.UtzOn;
                res[i, 7] = item.UkozhOn;
                res[i, 8] = item.UtzOff;
                res[i, 9] = item.UkozhOff;
                res[i, 10] = item.AtestationKontakt;
                res[i, 11] = "";
                i++;
            }
            return res;
        }
        public string[,] ConvertStanNaPerehode(List<RoadKozhuh> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            string[,] res = new string[count, 11];
            int i = 0;
            foreach (RoadKozhuh item in data)
            {
                res[i, 0] = ConvertToString.FloatToString(item.Km * 1000);
                res[i, 1] = item.RoadName;
                res[i, 2] = ProvodNaPerehode(item.IsPvStartPtovodUtz,
                    item.IsPvStartPtovodUtz || item.IsPvStartPtovodUkozh, true);
                res[i, 3] = ProvodNaPerehode(item.IsPvStartPtovodUkozh,
                    item.IsPvStartPtovodUtz || item.IsPvStartPtovodUkozh, item.HasKozhuh);
                res[i, 4] = ProvodNaPerehode(item.IsPvEndPtovodUtz,
                    item.IsPvEndPtovodUtz || item.IsPvEndPtovodUkozh, true);
                res[i, 5] = ProvodNaPerehode(item.IsPvEndPtovodUkozh,
                    item.IsPvEndPtovodUtz || item.IsPvEndPtovodUkozh, item.HasKozhuh);
                res[i, 6] = SvechaNaPerehode(item.IsSvechaStart, item.HasKozhuh);
                res[i, 7] = SvechaNaPerehode(item.IsSvechaEnd, item.HasKozhuh);
                res[i, 8] = item.HasKozhuh ? "" : "кожух відсутній";
                string isSvechaNaPerehode = item.HasKozhuh && !item.IsSvechaStart && !item.IsSvechaEnd ?
                    "На переході відсутня витяжна свічка. " : "";
                res[i, 9] = item.RoadName + " км " + ConvertToString.FloatToString(item.Km) +
                    HasProvod(true, item.IsPvStartPtovodUtz, item.IsPvStartPtovodUkozh, item.HasKozhuh, out string nUse) +
                    HasProvod(false, item.IsPvEndPtovodUtz, item.IsPvEndPtovodUkozh, item.HasKozhuh, out nUse) +
                    isSvechaNaPerehode +
                    AtestationContact(item, out nUse);
                string recomendation = Recomendation(item);
                res[i, 10] = recomendation == "" ? "" : $"{item.RoadName} км {ConvertToString.FloatToString(item.Km)} - {recomendation}";
                i++;
            }
            return res;
        }
        private string ProvodNaPerehode(bool provodExist, bool pvExist, bool kozhuhExist)
        {
            if (!pvExist) return "ПВ відсутній";
            if (provodExist) return "присутній";
            if (!kozhuhExist) return "кожух відсутній";
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
            string res = startPerehoda ? " На початку переходу " : " В кінці переходу ";
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
        private string AtestationContact(RoadKozhuh roadKozhuh, out string recomendation)
        {
            recomendation = "";
            if (!roadKozhuh.HasKozhuh) return "";
            if (roadKozhuh.AtestationVumiruKozhuh == AtestationVumiruKozhuhs.noKontakt) return "Контакт відсутній";
            if (roadKozhuh.AtestationVumiruKozhuh == AtestationVumiruKozhuhs.kontakt)
            {
                recomendation = "усунути прямий контакт захисного кожуха з трубопроводом";
                return "Визначенно наявність прямого (електричного) контакту захисного кожуха з трубопроводом";
            }
            if (roadKozhuh.AtestationVumiruKozhuh == AtestationVumiruKozhuhs.elektrolitKontakt)
            {
                recomendation = "усунути електролітичний контакт захисного кожуха з трубопроводом";
                return "Визначенно наявність електролітичного контакту захисного кожуха з трубопроводом";
            }
            if (roadKozhuh.AtestationVumiruKozhuh == AtestationVumiruKozhuhs.coudNotCheck)
                return "Визначення наявності контакту захисного кожуха з трубопроводом неможливе за низьким значенням захисного потенціалу.";
            if (roadKozhuh.AtestationVumiruKozhuh == AtestationVumiruKozhuhs.noPV)
                return "Визначення наявності контакту захисного кожуха з трубопроводом неможливе за відсутнісю місць вимірювання захисного потенціалу.";
            return "";
        }
        private string Recomendation(RoadKozhuh roadKozhuh)
        {
            string res = "";
            if (!roadKozhuh.HasKozhuh)
            {
                if (!roadKozhuh.IsPvStartPtovodUtz) res = res + " Встановити ПВ на початку переходу,";
                if (!roadKozhuh.IsPvEndPtovodUtz) res = res + " Встановити ПВ в кінці переходу,";
            }
            else
            {
                HasProvod(true, roadKozhuh.IsPvStartPtovodUtz, roadKozhuh.IsPvStartPtovodUkozh, roadKozhuh.HasKozhuh, out string recomendStart);
                HasProvod(false, roadKozhuh.IsPvEndPtovodUtz, roadKozhuh.IsPvEndPtovodUkozh, roadKozhuh.HasKozhuh, out string recomendEnd);
                string recomendSvecha = "";
                if (!roadKozhuh.IsSvechaStart && !roadKozhuh.IsSvechaEnd) recomendSvecha = "обладнати захисний кожух витяжною свічкою; ";
                AtestationContact(roadKozhuh, out string recomendContact);
                res = $"{res}{recomendStart}{recomendEnd}{recomendSvecha}{recomendContact}";
            }
            return res;
        }
        public string[,] ConvertFlantsy(List<Flanets> flantsy)
        {
            ListFlanetsToMassive converter = new ListFlanetsToMassive();
            return converter.Convert(flantsy);
        }
    }
}
