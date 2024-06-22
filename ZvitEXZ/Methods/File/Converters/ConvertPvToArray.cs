using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertPvToArray
    {
        public object[,] Convert(List<PV> data)
        {
            if (data.Count == 0) return new string[0, 0];
            object[,] res = new object[data.Count, 11];
            int i = 0;
            foreach (PV item in data)
            {
                res[i, 0] = (item.Km * 1000).ToString();
                string potencial = $"-{ConvertToString.DoubleToString(item.ProvodPotencial1)}";
                if (string.IsNullOrEmpty(item.Description))
                {
                    res[i, 1] = "спеціалізований ПВ";
                    if (string.IsNullOrEmpty(item.PVDiamert)) res[i, 2] = item.PVType;
                    else res[i, 2] = $"{item.PVType} Ø{item.PVDiamert}";
                    string kabel = $"{item.ProvodType1} x {item.ProvodDyamert1}";
                    string pidkluchennya = item.GetTypepidkluchennya(1);
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
                    res[i, 7] = item.IsBroken ? "Зламаний" : "робочий";
                }
                else
                {
                    res[i, 1] = item.Description;
                    res[i, 2] = "-";
                    res[i, 3] = "-";
                    res[i, 4] = "-";
                    res[i, 7] = "-";
                }
                res[i, 5] = potencial;
                res[i, 6] = "";
                res[i, 8] = item.Note;
                res[i, 9] = item.GpsN;
                res[i, 10] = item.GpsE;
                i++;
            }
            return res;
        }
    }
}
