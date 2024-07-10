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
        public double? UtzStartOff { get; set; }
        public double? UtzFinishOff { get; set; }
        public double? UkzStartOff { get; set; }
        public double? UkzFinishOff { get; set; }
        public AtestationVumiruKozhuhs AtestationVumiruKozhuh { get; set; }
        public TrainRoadTypes TrainRoadType { get; set; }

        public Road(object[] data) : base(data)
        {
            Name = ProjectConstants.RoadName;
            if (data[23] == null)
            {
                RoadType = RoadTypes.undefined;
                Logs.AddError($"{ErrorMessageStart} не задан тип дороги");
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
                        Logs.AddError($"{ErrorMessageStart} неверно задан тип дороги");
                        break;

                }
            }
            if (data[19] == null)
            {
                RoadName = "";
                if (RoadType == RoadTypes.automobile || RoadType == RoadTypes.train)
                    Logs.AddError($"{ErrorMessageStart} укажите название дороги");
            }
            else
            {
                RoadName = data[19].ToString();
            }
            if (data[21] == null)
            {
                length = null;
                Logs.AddError($"{ErrorMessageStart} укажите ширину дороги");
            }
            else
            {
                try
                {
                    length = (int)Parse.ParseDouble(data[21]);
                }
                catch
                {
                    Upol = null;
                    Logs.AddError($"{ErrorMessageStart} укажите ширину дороги");
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
                Logs.AddError($"{ErrorMessageStart} неверно указано наличие кожуха");
            }
            if (!HasKozhuh)
            {
                KozhuhLength = null;
            }
            else
            {
                if (data[115] == null)
                {
                    KozhuhLength = length;
                    Logs.AddError($"{ErrorMessageStart} укажите длину кожуха");
                }
                else
                {
                    try
                    {
                        KozhuhLength = (int)Parse.ParseDouble(data[115]);
                    }
                    catch
                    {
                        KozhuhLength = length;
                        Logs.AddError($"{ErrorMessageStart} правильно укажите длину кожуха");
                    }
                }
                if (KozhuhLength < length)
                {
                    KozhuhLength = length;
                    Logs.AddError($"{ErrorMessageStart} правильную укажите длину кожуха");
                }
            }
            if (!HasKozhuh)
            {
                ProtectionType = ProtectionTypes.undefined;
            }
            else if (data[208] == null)
            {
                ProtectionType = ProtectionTypes.undefined;
                Logs.AddError($"{ErrorMessageStart} укажите тип защиты кожуха");
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
                        Logs.AddError($"{ErrorMessageStart} неверно указано тип защиты кожуха");
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
                    UtzStartOff = Parse.ParseDouble(data[214]);
                }
                catch
                {
                    UtzStartOff = null;
                    Logs.AddError($"{ErrorMessageStart} правильно укажите замеры на УПЗ");
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
                    UtzFinishOff = Parse.ParseDouble(data[215]);
                }
                catch
                {
                    UtzFinishOff = null;
                    Logs.AddError($"{ErrorMessageStart} правильно укажите замеры на УПЗ");
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
                    UkzStartOff = Parse.ParseDouble(data[216]);
                }
                catch
                {
                    UkzStartOff = null;
                    Logs.AddError($"{ErrorMessageStart} правильно укажите замеры на УПЗ");
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
                    UkzFinishOff = Parse.ParseDouble(data[217]);
                }
                catch
                {
                    UkzFinishOff = null;
                    Logs.AddError($"{ErrorMessageStart} правильно укажите замеры на УПЗ");
                }
            }
            if (data[248] == null)
            {
                Logs.AddError($"{ErrorMessageStart} проверьте номер привязки");
                NumberSvyazky = 0;
            }
            else
            {
                try
                {
                    NumberSvyazky = (int)Parse.ParseDouble(data[248]);
                }
                catch
                {
                    NumberSvyazky = 0;
                    Logs.AddError($"{ErrorMessageStart} проверьте номер привязки");
                }
            }
            if (!HasKozhuh)
            {
                AtestationVumiruKozhuh = AtestationVumiruKozhuhs.undefined;
            }
            else if (data[218] == null)
            {
                AtestationVumiruKozhuh = AtestationVumiruKozhuhs.undefined;
                Logs.AddError($"{ErrorMessageStart} неуказана атестация измерений");
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
                        Logs.AddError($"{ErrorMessageStart} неверно указана (неуказана) атестация измерений");
                        break;
                }
            }
            if (data[225] == null)
            {
                TrainRoadType = TrainRoadTypes.undefined;
            }
            else
            {
                switch (data[225])
                {
                    case "не елекрифік":
                        TrainRoadType = TrainRoadTypes.noElectrificied;
                        break;
                    case "пост. струм":
                        TrainRoadType = TrainRoadTypes.postStrum;
                        break;
                    case "змін. струм":
                        TrainRoadType = TrainRoadTypes.peremStrum;
                        break;
                    default:
                        TrainRoadType = TrainRoadTypes.undefined;
                        break;
                }
            }
        }
        public override string ToString()
        {
            switch (RoadType)
            {
                case RoadTypes.automobile: return $"автодорога {RoadName}";
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
        public override string GetCadType()
        {
            if (RoadType == RoadTypes.automobile) return AcadConstants.ObjRoadAutomobil;
            if (RoadType == RoadTypes.polevaya) return AcadConstants.ObjRoadPolevaya;
            if (RoadType == RoadTypes.gruntovaya) return AcadConstants.ObjRoadHrunt;
            if (RoadType == RoadTypes.train)
            {
                if (TrainRoadType == TrainRoadTypes.postStrum) return AcadConstants.ObjRoadRailPost;
                if (TrainRoadType == TrainRoadTypes.peremStrum) return AcadConstants.ObjRoadRailPerem;
                return AcadConstants.ObjRoadRail;
            }
            return "";
        }
        public override string GetCadSignature()
        {
            if (RoadType == RoadTypes.automobile) return $"автодорога {RoadName}";
            if (RoadType == RoadTypes.train) return $"залізниця {RoadName}";
            return base.GetCadSignature();
        }
    }
}