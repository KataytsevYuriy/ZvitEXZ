using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Svalka:Zamer
    {
        public float Svalkalength { get; set; }

        public Svalka(object[] data) : base(data)
        {
            Name = ProjectConstants.YamaName;
            if (data[21] == null)
            {
                Svalkalength = 0;
                Logs.AddError($"км {data[1]} укажите длинну свалки");
            }
            else
            {
                try
                {
                    Svalkalength = Parse.ParseFloat(data[21]);
                }
                catch
                {
                    Svalkalength = 0;
                    Logs.AddError($"км {data[1]} неверно указана длинна свалки");
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
