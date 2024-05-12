using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class UDZ : Zamer
    {
        public UDZ(object[] data) : base(data)
        {
            Name = Constants.UDZName;
        }
        public override string ToString()
        {
            return Constants.UDZName;
        }
    }
}
