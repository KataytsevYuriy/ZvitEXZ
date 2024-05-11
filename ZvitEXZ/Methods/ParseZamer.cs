using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods
{
    public class ParseZamer
    {
        public Zamer Parse(object[] data)
        {
            if (data[0] == null) return new Zamer(data);
            switch (data[0].ToString())
            {
                case Constants.PVName: return new PV(data);
                case Constants.LepNameInNaborka: return new Lep(data);
                case Constants.RiverNameInNaborka: return new River(data);
                case Constants.SwampNameInNaborka: return new Swamp(data);
                case Constants.PovorotNameInNaborka: return new Povorot(data);
                case Constants.SvechaNameInNaborka: return new Svecha(data);
                default:
                    string km = "";
                    if (data[1] != null) km = data[1].ToString();
                    Logs.AddError($"км {km} неверный тип обьекта \"{data[0]}\" замер создан без объекта");
                    return new Zamer(data);
            };
        }
    }
}
