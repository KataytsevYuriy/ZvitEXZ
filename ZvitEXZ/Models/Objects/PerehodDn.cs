using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    internal class PerehodDn:Zamer
    {
        public int NewDn { get; set; }
        public PerehodDn(object[] data) : base(data)
        {
            Name = ProjectConstants.PerehodDNName;
            if (data[241] == null)
            {
                NewDn = 0;
                Logs.AddError($"км {data[1]} вкажіть новий діаметр");
            }
            else
            {
                try
                {
                    NewDn = int.Parse(data[241].ToString());
                }
                catch
                {
                    NewDn = 0;
                    Logs.AddError($"км {data[1]} Невірний новий діаметр");
                }
            }
        }
        public override string ToString()
        {
            if (NewDn == 0) return Name;
            return $"{Name} (на DN {NewDn}мм)";
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjPerehodDn;
        }
    }
}
