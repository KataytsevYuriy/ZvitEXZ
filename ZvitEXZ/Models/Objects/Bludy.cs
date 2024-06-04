using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class Bludy : Zamer
    {
        public StartEnd Posytion { get; set; }
        public string ZnakoPeremen { get; set; }
        public Bludy(object[] data) : base(data)
        {
            Name = ProjectConstants.BludyName;
            Posytion = ParseData.StartAndEnd(data[118]);
            ZnakoPeremen = ParseData.String(data[119]);
        }
        public override string ToString()
        {
            if (Posytion == StartEnd.start) return $"{Name} початок";
            if (Posytion == StartEnd.end) return $"{Name} кінець";
            return Name;
        }
    }
}
