using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class GRS : Zamer
    {
        public string NameGrs { get; set; }
        public GRS(object[] data) : base(data)
        {
            Name = Constants.GRSName;
            NameGrs = ParseData.String(data[78]);
        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(NameGrs)) return $"{Name} {NameGrs}";
            return Name;
        }
    }
}
