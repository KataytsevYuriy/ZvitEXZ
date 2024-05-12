using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    internal class Kanal : Zamer
    {
        public string KanalName { get; set; }
        public string KanalState { get; set; }
        public int KanalLenght { get; set; }
        public Kanal(object[] data) : base(data)
        {
            Name = Constants.KanalName;
            if (data[112] == null)
            {
                KanalName = "";
            }
            else
            {
                KanalName = data[112].ToString();
            }
            if (data[113] == null)
            {
                KanalState = "";
            }
            else
            {
                KanalState = data[113].ToString();
            }
            if (data[21] == null)
            {
                KanalLenght = 0;
                Logs.AddError($"км {data[1]} укажите длинну канала");

            }
            else
            {
                try
                {
                    KanalLenght = int.Parse(data[21].ToString());
                }
                catch
                {
                    KanalLenght = 0;
                    Logs.AddError("Неверная длинна канала");
                }
            }
        }
        public override string ToString()
        {
            if (!String.IsNullOrEmpty(KanalName)) return $"{Name} {KanalName}";
            return KanalName;
        }
    }
}
