using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class Kanal : Pereshkoda
    {
        public string KanalName { get; set; }
        public string KanalState { get; set; }
        public Kanal(object[] data) : base(data)
        {
            Name = ProjectConstants.KanalName;
            if (data[112] == null)
            {
                KanalName = "";
            }
            else
            {
                KanalName = data[112].ToString();
            }
            if (data[113] == null)
            {
                KanalState = "";
            }
            else
            {
                KanalState = data[113].ToString();
            }

        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(KanalName)) return $"{Name} {KanalName}";
            return KanalName;
        }
    }
}
