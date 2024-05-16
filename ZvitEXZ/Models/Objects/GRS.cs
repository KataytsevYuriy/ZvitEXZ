using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class GRS:Zamer
    {
        public string NameGrs { get; set; }    
        public GRS(object[] data) : base(data)
        {
                Name=Constants.GRSName;
            if (data[78] == null)
            {
                NameGrs = "";
            } else
            {
                NameGrs = data[78].ToString();
            }
        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(NameGrs)) return $"{Name} {NameGrs}";
            return Name;
        }
    }
}
