using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.File.Converters
{
    public class ConvertZamersToZvedena
    {
        private List<Zamer> zamers;
        private List<KorNebezpechny> korNebezpechnies;
        private List<Povregdenya> povregdenyas;
        public ConvertZamersToZvedena(List<Zamer> zamers, List<KorNebezpechny> korNebezpechnies, List<Povregdenya> povregdenyas)
        {
            this.korNebezpechnies = korNebezpechnies;
            this.zamers = zamers;
            this.povregdenyas = povregdenyas;
            //add povrezhdenya
        }
        public object[,] Convert()
        {
            if (zamers.Count == 0) return new string[0, 0];
            int cellCount = 12;
            object[,] res = new object[zamers.Count, cellCount];
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
                    string utz = ((double)item.Utz).ToString("0.000").Replace(".", ",");
                    res[i, 1] = $"-{utz}";

                }
                if (item.Upol == null)
                {
                    res[i, 2] = "";
                }
                else
                {
                    string upz = ((double)item.Utz).ToString("0.000").Replace(".", ",");

                    res[i, 2] = $"-{upz}";
                }
                if (item.Ugrad == null)
                {
                    res[i, 3] = "";
                }
                else
                {
                    res[i, 3] = Math.Round((double)item.Ugrad * 1000).ToString();
                }
                string prymitky = "";
                if (!string.IsNullOrEmpty(item.ToString())) prymitky = item.ToString();
                string mestnost = mestnostToString.String(item.Mestnost);
                if (!String.IsNullOrEmpty(mestnost))
                    prymitky = prymitky == "" ? mestnost : $"{prymitky}; {mestnost}";
                if (item.IsBalka)
                    prymitky = prymitky == "" ? ProjectConstants.MestnostBalka : $"{prymitky}; {ProjectConstants.MestnostBalka}";
                res[i, 4] = prymitky;
                res[i, 5] = IsPovregdenya(item.Km);
                res[i, 6] = IsKornenebezpechny(item.Km);
                res[i, 7] = ConvertToString.DoubleToString(item.Hlub, 2);
                //res[i, 7] = item.Hlub == null ? "" : item.Hlub.ToString().Replace(".", ",");
                res[i, 8] = ConvertToString.DoubleToString(item.Rhr, 0);
                //res[i, 8] = item.Rhr == null ? "" : item.Rhr.ToString().Replace(".", ",");
                res[i, 9] = item.GpsN;
                res[i, 10] = item.GpsE;
                string ph = item.Ph != null ? $" Ph={ConvertToString.DoubleToString(item.Ph, 1)}" : "";
                res[i, 11] = item.Note + ph;
                i++;
            }
            return res;
        }
        private string IsKornenebezpechny(double km)
        {
            if (korNebezpechnies.Count == 0) return "";
            foreach (KorNebezpechny item in korNebezpechnies)
            {
                if (km >= item.KmStart && km <= item.KmEnd) return item.Description;
            }
            return "";
        }
        private string IsPovregdenya(double km)
        {
            Povregdenya povregdenya = povregdenyas.Where(el => el.KmStart <= km && el.KmEnd >= km).FirstOrDefault();
            if (povregdenya == null) return "";
            return povregdenya.Cherga.ToString();
        }
    }
}
