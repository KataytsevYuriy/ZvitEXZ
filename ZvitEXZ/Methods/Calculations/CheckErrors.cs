using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class CheckErrors
    {
        public void Check(List<Zamer> zamers)
        {
            Zamer lastZamer = null;
            foreach (var zamer in zamers)
            {
                if (lastZamer != null && lastZamer is Pereshkoda)
                {
                    Pereshkoda pereshkoda = lastZamer as Pereshkoda;
                    if (pereshkoda.Km + (double)pereshkoda.Length / 1000 > zamer.Km)
                        Logs.AddError($"земер (км {ConvertToString.DoubleToString(pereshkoda.Km)}) на объекте с возможность свертки указана слишком большая длинна");
                }
                if (lastZamer != null && lastZamer.Km > zamer.Km)
                    Logs.AddError($"замеры (км {ConvertToString.DoubleToString(lastZamer.Km)}) и (км {ConvertToString.DoubleToString(zamer.Km)}) проверьте значения КМ");
                if (zamer.Utz != null && Math.Abs((double)zamer.Utz) > 5)
                    Logs.AddError($"земер (км {ConvertToString.DoubleToString(zamer.Km)}) указан слишком большой потенциал т-з");
                if (zamer.Ugrad != null && Math.Abs((double)zamer.Ugrad) > 1)
                    Logs.AddError($"земер (км {ConvertToString.DoubleToString(zamer.Km)}) указан слишком большой потенциал град");
                lastZamer = zamer;
            }
        }
    }
}
