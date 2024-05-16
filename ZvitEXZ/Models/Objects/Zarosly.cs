using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Zarosly : Zamer
    {
        public int? Length { get; set; }
        public Zarosly(object[] data) : base(data)
        {
            Name = Constants.ZaroslyName;
            if (data[21] == null)
            {
                Length = null;
                Logs.AddError($"км {data[1]} укажите длинну зарослей");
            }
            else
            {
                try
                {
                    Length = int.Parse(data[21].ToString());
                }
                catch
                {
                    Length = null;
                    Logs.AddError("Неверная длинна зарослей");
                }
            }
        }
        public override string ToString()
        {
            if (Length != null) return $"{Name} {Length}м";
            return Name;
        }
    }
}
