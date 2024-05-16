using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class VyhodIsZemly : Zamer
    {
        public PerehodType Type { get; set; }
        public VyhodIsZemly(object[] data) : base(data)
        {
            Name = Constants.VyhodIsZemlyName;
            if (data[109] == null)
            {
                Type = PerehodType.undefined;
            }
            else if (data[109].ToString() == "початок")
            {
                Type = PerehodType.start;
            }
            else Type = PerehodType.finish;
        }
        public override string ToString()
        {
            if (Type == PerehodType.start) return $"{Name} початок";
            if (Type == PerehodType.finish) return $"{Name} кінець";
            return Name;
        }
    }
    public enum PerehodType { undefined, start, finish }
}
