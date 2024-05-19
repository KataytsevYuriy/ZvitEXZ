using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.File
{
    public class ConvertZamersToZvedena
    {
        private List<Zamer> zamers;
        private List<KorNebezpechny> korNebezpechnies;
        public ConvertZamersToZvedena(List<Zamer> zamers, List<KorNebezpechny> korNebezpechnies)
        {
            this.korNebezpechnies = korNebezpechnies;
            this.zamers = zamers;
            //add povrezhdenya
        }
        public string[,] Convert()
        {
            if (zamers.Count == 0) return new string[0, 0];
            int cellCount = 12;
            string[,] res = new string[zamers.Count, cellCount];
            int i = 0;
            MestnostToString mestnostToString = new MestnostToString();
            foreach (Zamer item in zamers)
            {
                res[i, 0] = Math.Round(item.Km * 1000).ToString();
                if (item.Utz == null)
                {
                    res[i, 1] = "";
                }
                else
                {
                    string utz = ((float)item.Utz).ToString("0.000").Replace(".", ",");
                    res[i, 1] = $"-{utz}";

                }
                if (item.Upol == null)
                {
                    res[i, 2] = "";
                }
                else
                {
                    string upz = ((float)item.Utz).ToString("0.000").Replace(".", ",");

                    res[i, 2] = $"-{upz}";
                }
                if (item.Ugrad == null)
                {
                    res[i, 3] = "";
                }
                else
                {
                    res[i, 3] = Math.Round((float)item.Ugrad * 1000).ToString();
                }
                string prymitky = "";
                if (!string.IsNullOrEmpty(item.ToString())) prymitky = item.ToString();
                string mestnost = mestnostToString.String(item.Mestnost);
                if (!String.IsNullOrEmpty(mestnost))
                    prymitky = prymitky == "" ? mestnost : $"{prymitky}; {mestnost}";
                if (item.IsBalka)
                    prymitky = prymitky == "" ? Constants.MestnostBalka : $"{prymitky}; {Constants.MestnostBalka}";
                res[i, 4] = prymitky;
                res[i, 5] = "";//poskodgennya
                res[i, 6] = IsKornenebezpechny(item.Km);
                res[i, 7] = item.Hlub == null ? "" : item.Hlub.ToString().Replace(".", ",");
                res[i, 8] = item.Rhr == null ? "" : item.Rhr.ToString().Replace(".", ",");
                res[i, 9] = item.GpsN;
                res[i, 10] = item.GpsE;
                res[i, 11] = item.Note;
                i++;
            }
            return res;
        }
        private string IsKornenebezpechny(float km)
        {
            if (korNebezpechnies.Count == 0) return "";
            foreach (KorNebezpechny item in korNebezpechnies)
            {
                if (km >= item.KmStart && km <= item.KmFinish) return item.Description;
            }
            return "";
        }
    }
}
