using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Swamp : Zamer
    {
        public int SwampLength { get; set; }
        public Swamp(object[] data) : base(data)
        {
            Name = Constants.SwampName;
            try
            {
                SwampLength = int.Parse(data[21].ToString());
            }
            catch
            {
                SwampLength = 0;
                Logs.AddError("Неверная длинна болота");// Add log - wrong swamp length
            }
        }
        public override string ToString()
        {
            return Constants.SwampName;
        }
    }
}
