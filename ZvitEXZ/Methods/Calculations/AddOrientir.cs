using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class AddOrientir
    {
        public string Add(List<Zamer> zamers, double kmStart, double kmEnd)
        {
            if (zamers.Count == 0) return "";
            Zamer orientir = zamers.First();
            bool isOrientirBeetwin = false;
            foreach (Zamer zamer in zamers)
            {
                if (kmStart > zamer.Km)
                {
                    orientir = zamer;
                }
                else if (zamer.Km <= kmEnd)
                {
                    orientir = zamer;
                    isOrientirBeetwin = true;
                    break;
                }
                else if ((kmStart - orientir.Km) > (zamer.Km - kmEnd))
                {
                    orientir = zamer;
                    break;
                }
                else break;
            }
            string orientirString = $"{orientir.ToString()} (км {ConvertToString.DoubleToString(orientir.Km)})";
            if (isOrientirBeetwin) return orientirString;
            string beforOrAfter;
            if (orientir.Km < kmStart) { beforOrAfter = $"{ConvertToString.DoubleToString((kmStart - orientir.Km) * 1000, 0)}м після"; }
            else { beforOrAfter = $"{ConvertToString.DoubleToString((orientir.Km - kmEnd) * 1000, 0)}м до"; }
            return $"{beforOrAfter} {orientirString}";
        }
    }
}
