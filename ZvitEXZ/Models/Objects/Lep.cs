using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class Lep : Zamer
    {
        public string Voltage { get; set; }
        public Lep(object[] data) : base(data)
        {
            if (data[77] == null)
            {
                Voltage = "";
            }
            else
            {
                Voltage = data[77].ToString();
            }
            Name = ProjectConstants.LepName;
        }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Voltage)) return Name;
            return $"{Name} {Voltage}кВ";
        }
    }
}
