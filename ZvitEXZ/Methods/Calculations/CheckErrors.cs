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
                    if (Math.Round(pereshkoda.Km + (double)pereshkoda.Length / 1000, 3) > zamer.Km)
                    {
                        //double t = pereshkoda.Km + (double)pereshkoda.Length / 1000;
                        //double r = (double)pereshkoda.Length;
                        Logs.AddError($"вимір (км {ConvertToString.DoubleToString(pereshkoda.Km)}) на об'екті з можливістю звертання вказана дуже велика довжина");
                    }
                }
                if (lastZamer != null && lastZamer.Km > zamer.Km)
                    Logs.AddError($"вимір (км {ConvertToString.DoubleToString(lastZamer.Km)}) и (км {ConvertToString.DoubleToString(zamer.Km)}) перевірте значення КМ");
                if (lastZamer != null && lastZamer.Km == zamer.Km)
                    Logs.AddError($"присутстні 2 виміра на одному \"км\" (км {ConvertToString.DoubleToString(lastZamer.Km)})");
                if (zamer.Utz != null && Math.Abs((double)zamer.Utz) > 5)
                    Logs.AddError($"вимір (км {ConvertToString.DoubleToString(zamer.Km)}) вказан дуже великий потенциал т-з");
                if (zamer.Ugrad != null && Math.Abs((double)zamer.Ugrad) > 1)
                    Logs.AddError($"вимір (км {ConvertToString.DoubleToString(zamer.Km)}) вказан дуже великий потенциал град");
                lastZamer = zamer;
            }
        }
    }
}
