using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertUKZToArray
    {
        public object[,] Convert(List<Zamer> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 27];
            int i = 0;
            foreach (Zamer zamer in data)
            {
                UKZ item = zamer as UKZ;
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = ConvertToString.DoubleToString(item.Km);
                res[i, 2] = item.Identificator;
                res[i, 3] = item.TypeUkryttya;
                res[i, 4] = item.PreobrazovatelType;
                res[i, 5] = item.StartUsing;
                res[i, 6] = item.Power.Replace(".", ",");
                res[i, 7] = ConvertToString.DoubleToString(item.Uwork);
                res[i, 8] = ConvertToString.DoubleToString(item.Iwork);
                res[i, 9] = ConvertToString.DoubleToString(item.Umax);
                res[i, 10] = ConvertToString.DoubleToString(item.Imax);
                if (item.Umax == null || item.Imax == null || item.Uwork == null || item.Iwork == null)
                {
                    res[i, 11] = "";
                }
                else
                {
                    res[i, 11] = ConvertToString.DoubleToString(item.Uwork * item.Iwork / (item.Umax * item.Imax) * 100, 1);
                }
                if (item.Imax == null || item.Iwork == null)
                {
                    res[i, 12] = "";
                }
                else
                {
                    res[i, 12] = ConvertToString.DoubleToString((float)(item.Iwork / item.Imax) * 100, 1);
                }
                res[i, 13] = item.RecomendedPower.Replace(".", ",");
                res[i, 14] = item.UtzOn.Replace(".", ",");
                res[i, 15] = item.UtzOff.Replace(".", ",");
                res[i, 16] = item.UtzRecomended.Replace(".", ",");
                res[i, 17] = item.Urecomended.Replace(".", ",");
                res[i, 18] = item.Irecomended.Replace(".", ",");
                res[i, 19] = item.Raz.Replace(".", ",");
                res[i, 20] = item.MarkaKatodProvoda + " " + item.SechenieKatodProvoda;
                res[i, 21] = item.LenghtKatodProvoda;
                res[i, 22] = item.MarkaAnodProvoda + " " + item.SechenieAnodProvoda;
                res[i, 23] = item.LenghtAnodProvoda;
                res[i, 24] = item.Rzah.Replace(".", ",");
                res[i, 25] = item.TehStan;
                res[i, 26] = item.Note;
                i++;
            }
            return res;
        }
    }
}
