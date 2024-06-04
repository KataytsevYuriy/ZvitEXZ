using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Pereshkoda : Zamer
    {
        public int Length { get; set; }
        public Pereshkoda(object[] data) : base(data)
        {
            if (data[21] == null)
            {
                Length = 0;
                Logs.AddError($"км {data[1]} укажите длинну преграды");

            }
            else
            {
                try
                {
                    Length = int.Parse(data[21].ToString());
                }
                catch
                {
                    Length = 0;
                    Logs.AddError("Неверная длинна преграды");
                }
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
