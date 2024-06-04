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
                case ProjectConstants.PVName: return new PV(data);
                case ProjectConstants.LepNameInNaborka: return new Lep(data);
                case ProjectConstants.RiverNameInNaborka: return new River(data);
                case ProjectConstants.RoadNameInNaborka: return new Road(data);
                case ProjectConstants.SwampNameInNaborka: return new Swamp(data);
                case ProjectConstants.PovorotNameInNaborka: return new Povorot(data);
                case ProjectConstants.SvechaNameInNaborka: return new Svecha(data);
                case ProjectConstants.TreeName: return new Tree(data);
                case ProjectConstants.Stolb: return new Stolb(data);
                case ProjectConstants.UKZNameInNaborka: return new UKZ(data);
                case ProjectConstants.UDZNameInNaborka:return new UDZ(data);
                case ProjectConstants.KranNameInNaborka:return new Kran(data);
                case ProjectConstants.TruboprovodNameInNaborka:return new Truboprovod(data);
                case ProjectConstants.OtvodNameInNaborka:return new Otvod(data);
                case ProjectConstants.KanalNameInNaborka:return new Kanal(data);
                case ProjectConstants.YamaNameInNaborka:return new Yama(data);
                case ProjectConstants.SvalkaInNaborka:return new Svalka(data);
                case ProjectConstants.VyhodIsZemlyInNaborka:return new VyhodIsZemly(data);
                case ProjectConstants.GRSInNaborka:return new GRS(data);
                case ProjectConstants.ZaroslyInNaborka:return new Zarosly(data);
                case ProjectConstants.KabelInNaborka:return new Kabel(data);
                case ProjectConstants.ShurfInNaborka:return new Shurf(data);
                case ProjectConstants.BludyInNaborka:return new Bludy(data);
                case ProjectConstants.SvishInNaborka:return new Svish(data);
                case ProjectConstants.DilyankaKorNebInNaborka:return new DilyankaKorNeb(data);
                case ProjectConstants.DripInNaborka:return new Drip(data);
                case ProjectConstants.ObjectInNaborka:return new ObjectZamer(data);
                case ProjectConstants.PerehodDNInNaborka:return new PerehodDn(data);
                case ProjectConstants.UPZNInNaborka:return new UPZ(data);
                case ProjectConstants.NeobstegenaDylyankaNInNaborka:return new NeObstegenaDylyanka(data);


                default:
                    string km = "";
                    if (data[1] != null) km = data[1].ToString();
                    Logs.AddError($"км {km} неверный тип обьекта \"{data[0]}\" замер создан без объекта");
                    return new Zamer(data);
            }
        }
    }
}
