using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class River:Zamer
    {
        public string RiverName { get; set; }
        public int RiverLength { get; set; }
        public River(object[] data) : base(data)
        {
            Name=Constants.RiverName;
            if (data[67] == null)
            {
                RiverName = "";
            }
            else
            {
                RiverName = data[67].ToString();
            }
            try
            {
                RiverLength = int.Parse(data[21].ToString());
            }
            catch
            {
                RiverLength = 0;
                Logs.AddError("Неверная длинна реки");// Add log - wrong river length
            }
        }
        public override string ToString()
        {
            return $"{Name} {RiverName}";
        }
    }
}
