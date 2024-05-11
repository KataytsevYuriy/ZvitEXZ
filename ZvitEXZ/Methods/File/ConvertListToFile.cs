using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models.Calculations;

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
                string pidkluchennya = item.ProvodTypePidklichenya1;
                string potencial = item.ProvodPotencial1;
                if (!string.IsNullOrEmpty(item.ProvodType2))
                {
                    kabel += $"/ {item.ProvodType2} x {item.ProvodDaymetr2}";
                    pidkluchennya += "/ " + item.ProvodTypePidklichenya2;
                    potencial += "/ " + item.ProvodPotencial2;
                }
                if (!string.IsNullOrEmpty(item.ProvodType3))
                {
                    kabel += $"/ {item.ProvodType3} x {item.ProvodDyametr3}";
                    pidkluchennya += "/ " + item.ProvodTypePidklichenya3;
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
                res[i, 1] = Math.Round(item.KmEnd * 1000).ToString();
                res[i, 2] = Math.Round((item.KmEnd - item.KmStart) * 1000).ToString();
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
    }
}
