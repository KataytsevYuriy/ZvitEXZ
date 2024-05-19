using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZvitEXZ.Methods;
using System.Threading.Tasks;

namespace ZvitEXZ.Models.Objects
{
    internal class ObjectZamer : Zamer
    {
        public string ObjectName { get; set; }
        public float? Uobject { get; set; }
        public ObjectZamer(object[] data) : base(data)
        {
            Name = Constants.ObjectName;

            if (data[221] == null)
            {
                ObjectName = "";
                Logs.AddError($"км {data[1]} укажите название объекта");
            }
            else
            {
                ObjectName = data[221].ToString();
            }

            if (data[76] == null)
            {
                Uobject = null;
            }
            else
            {
                try
                {
                    Uobject = (float)Parse.ParseFloat(data[76].ToString());
                }
                catch
                {
                    Uobject = null;
                    Logs.AddError($"км {data[1]} Неверный потенциал объекта");
                }
            }
        }
        public override string ToString()
        {
            return String.IsNullOrEmpty(ObjectName) ? Name : ObjectName;
        }
    }
}
