using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Methods;

namespace ZvitEXZ.Models.Objects
{
    public class UKZ : Zamer
    {
        public string Identificator { get; set; }
        public string TypeUkryttya { get; set; }
        public string PreobrazovatelType { get; set; }
        public string StartUsing { get; set; }
        public string Power { get; set; }
        public double? Uwork { get; set; }
        public double? Iwork { get; set; }
        public double? Umax { get; set; }
        public double? Imax { get; set; }
        public string RecomendedPower { get; set; }
        public string UtzOn { get; set; }
        public string UtzOff { get; set; }
        public string UtzRecomended { get; set; }
        public string Irecomended { get; set; }
        public string Urecomended { get; set; }
        public string Raz { get; set; }
        public string MarkaKatodProvoda { get; set; }
        public string SecenieKatodProvoda { get; set; }
        public string Rzah { get; set; }
        public string TehStan { get; set; }
        public UKZ(object[] data) : base(data)
        {
            Name = ProjectConstants.UKZName;
            if (data[53] == null)
            {
                Identificator = "";
                Logs.AddError($"км {data[1]} укажите идентификатор УКЗ");
            }
            else
            {
                Identificator = data[53].ToString();
            }
            if (data[54] == null)
            {
                TypeUkryttya = "";
                Logs.AddError($"км {data[1]} укажите тип укрытия УКЗ");
            }
            else
            {
                TypeUkryttya = data[54].ToString();
            }

            if (data[57] == null)
            {
                PreobrazovatelType = "";
                Logs.AddError($"км {data[1]} укажите тип преобразователя УКЗ");
            }
            else
            {
                PreobrazovatelType = data[57].ToString();
            }

            if (data[172] == null)
            {
                StartUsing = "";
                Logs.AddError($"км {data[1]} укажите дату начала єксплуатации УКЗ");
            }
            else
            {
                StartUsing = data[172].ToString();
            }

            if (data[58] == null)
            {
                Power = "";
                Logs.AddError($"км {data[1]} укажите мощность УКЗ");
            }
            else
            {
                Power = data[58].ToString();
            }
            if (data[59] == null)
            {
                Uwork = null;
                Logs.AddError($"км {data[1]} укажите рабочий режим УКЗ");
            }
            else
            {
                try
                {
                    Uwork = Parse.ParseDouble(data[59]);
                }
                catch
                {
                    Uwork = null;
                    Logs.AddError($"км {data[1]} неверно указан рабочий режим УКЗ");
                }
            }

            if (data[60] == null)
            {
                Iwork = null;
                Logs.AddError($"км {data[1]} укажите рабочий режим УКЗ");
            }
            else
            {
                try
                {
                    Iwork = Parse.ParseDouble(data[60]);
                }
                catch
                {
                    Iwork = null;
                    Logs.AddError($"км {data[1]} неверно указан рабочий режим УКЗ");
                }
            }

            if (data[61] == null)
            {
                Umax = null;
                Logs.AddError($"км {data[1]} укажите максимальный режим УКЗ");
            }
            else
            {
                try
                {
                    Umax = Parse.ParseDouble(data[61]);
                }
                catch
                {
                    Umax = null;
                    Logs.AddError($"км {data[1]} неверно указан максимальный режим УКЗ");
                }
            }

            if (data[62] == null)
            {
                Imax = null;
                Logs.AddError($"км {data[1]} укажите максимальный режим УКЗ");
            }
            else
            {
                try
                {
                    Imax = Parse.ParseDouble(data[62]);
                }
                catch
                {
                    Imax = null;
                    Logs.AddError($"км {data[1]} неверно указан максимальный режим УКЗ");
                }
            }

            if (data[244] == null)
            {
                RecomendedPower = "";
                Logs.AddError($"км {data[1]} укажите рекомендуемую мощность УКЗ");
            }
            else
            {
                RecomendedPower = data[244].ToString();
            }
            if (data[50] == null)
            {
                UtzOn = "";
                Logs.AddError($"км {data[1]} укажите Uт-з в рабочем режиме УКЗ");
            }
            else
            {
                UtzOn = $"-{data[50]}";
            }

            if (data[226] == null)
            {
                UtzOff = "";
                Logs.AddError($"км {data[1]} укажите Uт-з при выкл УКЗ");
            }
            else
            {
                UtzOff = $"-{data[226]}";
            }

            if (data[52] == null)
            {
                UtzRecomended = "";
                Logs.AddError($"км {data[1]} укажите рекомендованый Uт-з");
            }
            else
            {
                UtzRecomended = $"-{data[52]}";
            }

            if (data[45] == null)
            {
                Urecomended = "";
                Irecomended = "";
                Logs.AddError($"км {data[1]} укажите рекомендованый режим работы");
            }
            else
            {
                string[] recomended = data[45].ToString().Split('/');
                if (recomended.Length == 2)
                {
                    Urecomended = recomended[0];
                    Irecomended = recomended[1];
                }
                else
                {
                    Urecomended = "";
                    Irecomended = "";
                    Logs.AddError($"км {data[1]} неверно указано рекомендованый режим работы");
                }
            }

            if (data[177] == null)
            {
                Raz = "";
                Logs.AddError($"км {data[1]} укажите сопротивление анода");
            }
            else
            {
                Raz = data[177].ToString();
            }

            if (data[186] == null)
            {
                MarkaKatodProvoda = "";
                Logs.AddError($"км {data[1]} укажите марку катодного кабеля");
            }
            else
            {
                MarkaKatodProvoda = data[186].ToString();
            }

            if (data[187] == null)
            {
                SecenieKatodProvoda = "";
                Logs.AddError($"км {data[1]} укажите сечение катодного кабеля");
            }
            else
            {
                SecenieKatodProvoda = data[187].ToString();
            }

            if (data[189] == null)
            {
                Rzah = "";
                Logs.AddError($"км {data[1]} укажите сопротивление защитного заземления");
            }
            else
            {
                Rzah = data[189].ToString();
            }

            if (data[55] == null)
            {
                TehStan = "";
                Logs.AddError($"км {data[1]} укажите тех. состояние УКЗ");
            }
            else
            {
                TehStan = data[55].ToString();
            }


        }
        public override string ToString()
        {
            return $"{ProjectConstants.UKZName} {Identificator}";
        }
        public override string GetCadType()
        {
            switch (TehStan)
            {
                case "працює": return AcadConstants.ObjUKZ;
                case "не працює": return AcadConstants.ObjUKZDontWork;
                case "в резерві": return AcadConstants.ObjUKZRezerv;
                default: return AcadConstants.ObjUKZ;
            }
        }
        public override string GetCadSignature()
        {
            return ToString();
        }
    }

}
