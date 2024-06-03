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
        public RoadTypes RoadType { get; set; }
        public int? length { get; set; }
        public bool HasKozhuh { get; set; }
        public int? KozhuhLength { get; set; }
        public ProtectionTypes ProtectionType { get; set; }
        public float? UtzStartOff { get; set; }
        public float? UtzFinishOff { get; set; }
        public float? UkzStartOff { get; set; }
        public float? UkzFinishOff { get; set; }
        public AtestationVumiruKozhuhs AtestationVumiruKozhuh { get; set; }

        public Road(object[] data) : base(data)
        {
            Name = Constants.RoadName;
            if (data[23] == null)
            {
                RoadType = RoadTypes.undefined;
                Logs.AddError($"км {data[1]} не задан тип дороги");
            }
            else
            {
                switch (data[23])
                {
                    case "автомобільна":
                        RoadType = RoadTypes.automobile;
                        break;
                    case "польова":
                        RoadType = RoadTypes.polevaya;
                        break;
                    case "залізниця":
                        RoadType = RoadTypes.train;
                        break;
                    case "грунтова":
                        RoadType = RoadTypes.gruntovaya;
                        break;
                    default:
                        RoadType = RoadTypes.undefined;
                        Logs.AddError($"км {data[1]} неверно задан тип дороги");
                        break;

                }
            }
            if (data[19] == null)
            {
                RoadName = "";
                if (RoadType == RoadTypes.automobile || RoadType == RoadTypes.train)
                    Logs.AddError($"км {data[1]} укажите название дороги");
            }
            else
            {
                RoadName = data[19].ToString();
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
            if (data[115] == null)
            {
                KozhuhLength = null;
            }
            else
            {
                try
                {
                    KozhuhLength = (int)Parse.ParseFloat(data[115]);
                }
                catch
                {
                    KozhuhLength = null;
                    Logs.AddError($"км {data[1]} правильно укажите длинну кожуха");
                }
            }
            if (!HasKozhuh)
            {
                ProtectionType = ProtectionTypes.undefined;
            }
            else if (data[208] == null)
            {
                ProtectionType = ProtectionTypes.undefined;
                Logs.AddError($"км {data[1]} укажите тип защиты кожуха");
            }
            else
            {
                switch (data[208].ToString())
                {
                    case "захист відсутній": ProtectionType = ProtectionTypes.without; break;
                    case "протекторний": ProtectionType = ProtectionTypes.hasProtector; break;
                    case "БСЗ": ProtectionType = ProtectionTypes.bzk; break;
                    default:
                        ProtectionType = ProtectionTypes.without;
                        Logs.AddError($"км {data[1]} неверно указано тип защиты кожуха");
                        break;
                }
            }
            if (data[214] == null)
            {
                UtzStartOff = null;
            }
            else
            {
                try
                {
                    UtzStartOff = Parse.ParseFloat(data[214]);
                }
                catch
                {
                    UtzStartOff = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
            }
            if (data[215] == null)
            {
                UtzFinishOff = null;
            }
            else
            {
                try
                {
                    UtzFinishOff = Parse.ParseFloat(data[215]);
                }
                catch
                {
                    UtzFinishOff = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
            }
            if (data[216] == null)
            {
                UkzStartOff = null;
            }
            else
            {
                try
                {
                    UkzStartOff = Parse.ParseFloat(data[216]);
                }
                catch
                {
                    UkzStartOff = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
                }
            }
            if (data[217] == null)
            {
                UkzFinishOff = null;
            }
            else
            {
                try
                {
                    UkzFinishOff = Parse.ParseFloat(data[217]);
                }
                catch
                {
                    UkzFinishOff = null;
                    Logs.AddError($"км {data[1]} правильно укажите замеры на УПЗ");
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
            if (!HasKozhuh)
            {
                AtestationVumiruKozhuh = AtestationVumiruKozhuhs.undefined;
            }
            else if (data[218] == null)
            {
                AtestationVumiruKozhuh = AtestationVumiruKozhuhs.undefined;
                Logs.AddError($"км {data[1]} неуказана атестация измерений");
            }
            else
            {
                switch (data[218].ToString())
                {
                    case "контакт відсутній": AtestationVumiruKozhuh = AtestationVumiruKozhuhs.noKontakt; break;
                    case "електролітичний контакт": AtestationVumiruKozhuh = AtestationVumiruKozhuhs.elektrolitKontakt; break;
                    case "прямий (електричний) контакт": AtestationVumiruKozhuh = AtestationVumiruKozhuhs.kontakt; break;
                    case "відсутні засоби контр.": AtestationVumiruKozhuh = AtestationVumiruKozhuhs.noPV; break;
                    case "не можливо роз'єднати": AtestationVumiruKozhuh = AtestationVumiruKozhuhs.coudNotCheck; break;
                    default:
                        AtestationVumiruKozhuh = AtestationVumiruKozhuhs.undefined;
                        Logs.AddError($"км {data[1]} неверно указана (неуказана) атестация измерений");
                        break;
                }
            }
        }
        public override string ToString()
        {
            switch (RoadType)
            {
                case RoadTypes.automobile: return $"а.д. {RoadName}";
                case RoadTypes.polevaya: return "польова дорога";
                case RoadTypes.train: return $"залізниця {RoadName}";
                case RoadTypes.gruntovaya: return "грунтова дорога";
                default: return Name;
            }
        }
        public string HasKontakt()
        {
            switch (AtestationVumiruKozhuh)
            {
                case AtestationVumiruKozhuhs.noKontakt: return "контакт відсутній";
                case AtestationVumiruKozhuhs.elektrolitKontakt: return "електролітичний контакт";
                case AtestationVumiruKozhuhs.kontakt: return "прямий (електричний) контакт";
                case AtestationVumiruKozhuhs.noPV: return "відсутні засоби контролю";
                case AtestationVumiruKozhuhs.coudNotCheck: return "не можливо роз'єднати";
                default: return "";
            }
        }
        public string HasProtection()
        {
            switch (ProtectionType)
            {
                case ProtectionTypes.without: return "захист відсутній";
                case ProtectionTypes.hasProtector: return "протекторний";
                case ProtectionTypes.bzk: return "БСЗ";
                default: return "";
            }
        }
    }
}