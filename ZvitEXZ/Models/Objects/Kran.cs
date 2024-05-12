using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Kran : Zamer
    {
        public string KranNumber { get; set; }
        public string UKrana { get; set; }
        public Kran(object[] data) : base(data)
        {
            Name = Constants.KranName;
            if (data[75] == null)
            {
                KranNumber = "";
                Logs.AddError($"км {Km} укажите номер крана");
            }
            else
            {
                KranNumber = data[75].ToString().Replace(".", ",");
            }
            if (data[76] == null)
            {
                UKrana = "";
                Logs.AddError($"км {Km} укажите потенциал крана");
            }
            else
            {
                UKrana = data[76].ToString().Replace(".", ",");
            }
        }
        public override string ToString()
        {
            return Constants.KranName;
        }
    }
}
