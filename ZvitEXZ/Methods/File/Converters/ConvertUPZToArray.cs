using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertUPZToArray
    {
        public object[,] Convert(List<UPZ> data)
        {
            int count = data.Count;
            if (count == 0) return new string[0, 0];
            object[,] res = new object[count, 18];
            int i = 0;
            foreach (UPZ item in data)
            {
                res[i, 0] = (i + 1).ToString();
                res[i, 1] = ConvertToString.DoubleToString(item.Km, 3);
                res[i, 2] = item.BuildingDate;
                res[i, 3] = ConvertToString.DoubleToString(item.Rhr, 1);
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
    }
}
