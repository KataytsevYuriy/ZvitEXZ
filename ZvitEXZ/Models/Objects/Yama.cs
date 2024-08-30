using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Yama:Zamer
    {
        public float Yamalength { get; set; }
        public Yama(object[] data) : base(data)
        {
            Name = ProjectConstants.YamaName;
            if (data[21] == null)
            {
                Yamalength = 0;
                Logs.AddError($"км {data[1]} вкажіть довжину ямы");

            }
            else
            {
                try
                {
                    Yamalength = int.Parse(data[21].ToString());
                }
                catch
                {
                    Yamalength = 0;
                    Logs.AddError($"км {data[1]} Невірная довжина ямы");
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
