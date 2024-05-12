using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class Road : Zamer
    {
        public string RoadName { get; set; }
        public RoadTypes.Type RoadType { get; set; }
        public int? length { get; set; }
        public bool HasKozhuh { get; set; }
        public string Kozhuh { get; set; }
        public ProtectionTypes.Type ProtectionType { get; set; }
        public float? UtzStart { get; set; }
        public float? UtzFinish { get; set; }
        public float? UkzStart { get; set; }
        public float? UkzFinish { get; set; }
        public AtestationVumiruKozhuhs.Atestation AtestationVumiruKozhuh { get; set; }
        public int NumberSvyazky { get; set; }

        public Road(object[] data) : base(data)
        {
            if (data[23] == null)
            {
                Name = "дорога";
                RoadType = RoadTypes.Type.undefined;
                Logs.AddError($"км {data[1]} не задан тип дороги");
            }
            else
            {
                switch (data[23])
                {
                    case "автомобільна":
                        Name = "а.д.";
                        RoadType = RoadTypes.Type.automobile;
                        break;
                    case "польова":
                        Name = "польова дорога";
                        RoadType = RoadTypes.Type.polevaya;
                        break;
                    case "залізниця":
                        Name = "залізниця";
                        RoadType = RoadTypes.Type.train;
                        break;
                    case "грунтова":
                        Name = "грунтова дорога";
                        RoadType = RoadTypes.Type.gruntovaya;
                        break;
                    default:
                        Name = "дорога";
                        RoadType = RoadTypes.Type.undefined;
                        Logs.AddError($"км {data[1]} неверно задан тип дороги");
                        break;

                }
            }
            if (data[19] == null) { RoadName = ""; }
            else
            {
                RoadName = data[19].ToString();
                if (RoadType == RoadTypes.Type.automobile) Logs.AddError($"км {data[1]} укажите название дороги");
            }
            if (data[21] == null)
            {
                length = null;
                Logs.AddError($"км {data[1]} укажите ширину дороги");
            }
            else
            {
                try
                {
                    length = (int)Parse.ParseFloat(data[21]);
                }
                catch
                {
                    Upol = null;
                    Logs.AddError($"км {data[1]} укажите ширину дороги");
                }
            }
            if (data[114] == null)
            {
                HasKozhuh = false;
            }
            else if (data[114].ToString() == "так")
            {
                HasKozhuh = true;
            }
            else
            {
                HasKozhuh = false;
                Logs.AddError($"км {data[1]} неверно указано наличие кожуха");
            }
            if (data[208] == null)
            {
                ProtectionType = ProtectionTypes.Type.without;
            }
            else
            {
                switch (data[208].ToString())
                {
                    case "захист відсутній": ProtectionType = ProtectionTypes.Type.without; break;
                    case "протекторний": ProtectionType = ProtectionTypes.Type.hasProtector; break;
                    case "БСЗ": ProtectionType = ProtectionTypes.Type.bzk; break;
                    default:
                        ProtectionType = ProtectionTypes.Type.without;
                        Logs.AddError($"км {data[1]} неверно указано тип защиты кожуха");
                        break;
                }
            }
            if (data[214] == null)
            {
                UtzStart = null;
            }
            else
            {
                try
                {
                    UtzStart = Parse.ParseFloat(data[214]);
                }
                catch
                {
                    UtzStart = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
            }
            if (data[215] == null)
            {
                UtzFinish = null;
            }
            else
            {
                try
                {
                    UtzFinish = Parse.ParseFloat(data[215]);
                }
                catch
                {
                    UtzFinish = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
            }
            if (data[216] == null)
            {
                UkzStart = null;
            }
            else
            {
                try
                {
                    UkzStart = Parse.ParseFloat(data[216]);
                }
                catch
                {
                    UkzStart = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
                if (data[217] == null)
                {
                    UkzFinish = null;
                }
                else
                {
                    try
                    {
                        UkzFinish = Parse.ParseFloat(data[216]);
                    }
                    catch
                    {
                        UkzFinish = null;
                        Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                    }
                }
            }
            if (data[248] == null)
            {
                Logs.AddError($"км {data[1]} проверьте номер привязки");
                NumberSvyazky = 0;
            }
            else
            {
                try
                {
                    NumberSvyazky = (int)Parse.ParseFloat(data[248]);
                }
                catch
                {
                    NumberSvyazky = 0;
                    Logs.AddError($"км {data[1]} проверьте номер привязки");
                }
            }
            if (data[218] == null)
            {
                AtestationVumiruKozhuh = AtestationVumiruKozhuhs.Atestation.undefined;
            }
            else
            {
                switch (data[218].ToString())
                {
                    case "контакт відсутній": AtestationVumiruKozhuh=AtestationVumiruKozhuhs.Atestation.noKontakt; break;
                    case "електролітичний контакт": AtestationVumiruKozhuh=AtestationVumiruKozhuhs.Atestation.elektrolitKontakt; break;
                    case "прямий (електричний) контакт": AtestationVumiruKozhuh=AtestationVumiruKozhuhs.Atestation.kontakt; break;
                    case "відсутні засоби контр.": AtestationVumiruKozhuh=AtestationVumiruKozhuhs.Atestation.noPV; break;
                    case "не можливо роз'єднати": AtestationVumiruKozhuh=AtestationVumiruKozhuhs.Atestation.coudNotCheck; break;
                    default:
                        AtestationVumiruKozhuh = AtestationVumiruKozhuhs.Atestation.undefined;
                        Logs.AddError($"км {data[1]} неверно указано атестация измерений");
                        break;
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}