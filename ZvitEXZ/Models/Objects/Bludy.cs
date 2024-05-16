using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Bludy : Zamer
    {
        public StartEnd Posytion { get; set; }
        public string ZnakoPeremen { get; set; }
        public Bludy(object[] data) : base(data)
        {
            Name = Constants.BludyName;

            if (data[118] == null)
            {
                Posytion = StartEnd.undefined;
            }
            else if (data[118].ToString() == "початок")
            {
                Posytion = StartEnd.start;
            }
            else if (data[118].ToString() == "кінець")
            {
                Posytion = StartEnd.end;
            }
            else
            {
                Posytion = StartEnd.undefined;
            }

            if (data[119] == null)
            {
                ZnakoPeremen = "";
            }
            else
            {
                ZnakoPeremen = data[119].ToString();
            }
        }
        public override string ToString()
        {
            if (Posytion == StartEnd.start) return $"{Name} початок";
            if (Posytion == StartEnd.end) return $"{Name} кінець";
            return Name;
        }
    }
}
