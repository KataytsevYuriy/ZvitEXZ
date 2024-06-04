using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class River : Pereshkoda
    {
        public string RiverName { get; set; }
        public River(object[] data) : base(data)
        {
            Name = Constants.RiverName;
            if (data[67] == null)
            {
                RiverName = "";
            }
            else
            {
                RiverName = data[67].ToString();
            }
        }
        public override string ToString()
        {
            return $"{Name} {RiverName}";
        }
    }
}
