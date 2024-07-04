using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZvitEXZ.Methods;
using ZvitEXZ.Models;

namespace ZvitEXZ.Models.Objects
{
    public class Shurf : Zamer
    {
        public string AktNumber { get; set; }
        public string ShurfLength { get; set; }
        public string IsolationSquare { get; set; }
        public string IsolationGettingSquare { get; set; }
        public string MestnostCharacteristics { get; set; }
        public string LitologHrunt { get; set; }
        public string StanHruntu { get; set; }
        public string NumbersObhortky { get; set; }
        public string TypeOfObhortka { get; set; }
        public string StanOfObhortka { get; set; }
        public string PrylypannyaOfObhortka { get; set; }
        public string IsMehPoshkodzhenObhortka { get; set; }
        public string IzolationType1 { get; set; }
        public string IzolationType2 { get; set; }
        public string StanPoverhnyUp { get; set; }
        public string StanPoverhnyDown { get; set; }
        public string StanPoverhnyLeft { get; set; }
        public string StanPoverhnyRight { get; set; }
        public string IzolationStructure { get; set; }
        public string Thin1SharUp { get; set; }
        public string Thin1SharDown { get; set; }
        public string Thin1SharRight { get; set; }
        public string Thin1SharLeft { get; set; }
        public string Thin2SharUp { get; set; }
        public string Thin2SharDown { get; set; }
        public string Thin2SharRight { get; set; }
        public string Thin2SharLeft { get; set; }
        public string IsHruntovka { get; set; }
        public string Adheziya { get; set; }
        public string Vologa { get; set; }
        public string PipeTemperature { get; set; }
        public string StanPoverhnyPipe { get; set; }
        public string SquareMetalPipe { get; set; }
        public string IsKorozyaExist { get; set; }
        public string CharacterKorozii { get; set; }
        public string KavernLength { get; set; }
        public string KavernHeight { get; set; }
        public string KavernPosition { get; set; }
        public string UtzBeforShurf { get; set; }
        public string UtzInShurf { get; set; }
        public string UtzAfterShurf { get; set; }
        public string ShurfMadeOrganization { get; set; }
        public string ShurfMadeUser { get; set; }
        public string PredstavnykZakazchyka { get; set; }
        public string DateOglyadu { get; set; }
        public string PhotoPoverhny { get; set; }


        public Shurf(object[] data) : base(data)
        {
            Name = ProjectConstants.ShurfName;
            if (data[122] == null)
            {
                AktNumber = "-";
                Logs.AddError($"{ErrorMessageStart} укажите номер акта");
            }
            else
            {
                AktNumber = data[122].ToString();
            }

            if (data[124] == null)
            {
                ShurfLength = "-";
                Logs.AddError($"{ErrorMessageStart} укажите длинну шурфа");
            }
            else
            {
                ShurfLength = data[124].ToString();
                Logs.AddError($"{ErrorMessageStart} укажите длинну шурфа");
            }

            if (data[125] == null)
            {
                IsolationSquare = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите площадь изоляции");
            }
            else
            {
                IsolationSquare = data[125].ToString();
            }

            if (data[126] == null)
            {
                IsolationGettingSquare = "-";
            }
            else
            {
                IsolationGettingSquare = data[126].ToString();
            }

            if (data[127] == null)
            {
                MestnostCharacteristics = "-";
                Logs.AddError($"{ErrorMessageStart} укажите местность");
            }
            else
            {
                MestnostCharacteristics = data[127].ToString();
            }

            if (data[129] == null)
            {
                LitologHrunt = "";
                Logs.AddError($"{ErrorMessageStart} укажите склад грунта");
            }
            else
            {
                LitologHrunt = data[129].ToString();
            }

            if (data[130] == null)
            {
                StanHruntu = "-";
                Logs.AddError($"{ErrorMessageStart} укажите стан грунту");
            }
            else
            {
                StanHruntu = data[130].ToString();
            }

            if (data[131] == null)
            {
                NumbersObhortky = "-";
            }
            else
            {
                NumbersObhortky = data[131].ToString();
            }

            if (data[132] == null)
            {
                TypeOfObhortka = "-";
            }
            else
            {
                TypeOfObhortka = data[132].ToString();
            }

            if (data[133] == null)
            {
                StanOfObhortka = "-";
            }
            else
            {
                StanOfObhortka = data[133].ToString();
            }

            if (data[134] == null)
            {
                PrylypannyaOfObhortka = "-";
            }
            else
            {
                PrylypannyaOfObhortka = data[134].ToString();
            }

            if (data[135] == null)
            {
                IsMehPoshkodzhenObhortka = "-";
                Logs.AddError($"{ErrorMessageStart} укажите мех. повреждения");
            }
            else
            {
                IsMehPoshkodzhenObhortka = data[135].ToString();
            }

            if (data[136] == null)
            {
                IzolationType1 = "-";
                Logs.AddError($"{ErrorMessageStart} укажите тип изоляции");
            }
            else
            {
                IzolationType1 = data[136].ToString();
            }

            if (data[137] == null)
            {
                IzolationType2 = "-";
            }
            else
            {
                IzolationType2 = data[137].ToString();
            }

            if (data[138] == null)
            {
                StanPoverhnyUp = "-";
                Logs.AddError($"{ErrorMessageStart} укажите стан поверхности");
            }
            else
            {
                StanPoverhnyUp = data[138].ToString();
            }

            if (data[139] == null)
            {
                StanPoverhnyDown = "-";
                Logs.AddError($"{ErrorMessageStart} укажите стан поверхности");
            }
            else
            {
                StanPoverhnyDown = data[139].ToString();
            }

            if (data[140] == null)
            {
                StanPoverhnyRight = "-";
                Logs.AddError($"{ErrorMessageStart} укажите стан поверхности");
            }
            else
            {
                StanPoverhnyRight = data[140].ToString();
            }

            if (data[141] == null)
            {
                StanPoverhnyLeft = "-";
                Logs.AddError($"{ErrorMessageStart} укажите стан поверхности");
            }
            else
            {
                StanPoverhnyLeft = data[141].ToString();
            }

            if (data[142] == null)
            {
                IzolationStructure = "-";
                Logs.AddError($"{ErrorMessageStart} укажите структуру изоляции");
            }
            else
            {
                IzolationStructure = data[142].ToString();
            }

            if (data[143] == null)
            {
                Thin1SharUp = "-";
                Logs.AddError($"{ErrorMessageStart} укажите толщину изоляции");
            }
            else
            {
                Thin1SharUp = data[143].ToString();
                Logs.AddError($"{ErrorMessageStart} укажите толщину изоляции");
            }

            if (data[144] == null)
            {
                Thin1SharDown = "-";
                Logs.AddError($"{ErrorMessageStart} укажите толщину изоляции");
            }
            else
            {
                Thin1SharDown = data[144].ToString();
            }

            if (data[145] == null)
            {
                Thin1SharRight = "-";
                Logs.AddError($"{ErrorMessageStart} укажите толщину изоляции");
            }
            else
            {
                Thin1SharRight = data[145].ToString();
            }

            if (data[146] == null)
            {
                Thin1SharLeft = "-";
                Logs.AddError($"{ErrorMessageStart} укажите толщину изоляции");
            }
            else
            {
                Thin1SharLeft = data[146].ToString();
            }

            if (data[147] == null)
            {
                Thin2SharUp = "-";
            }
            else
            {
                Thin2SharUp = data[147].ToString();
            }

            if (data[148] == null)
            {
                Thin2SharDown = "-";
            }
            else
            {
                Thin2SharDown = data[148].ToString();
            }

            if (data[149] == null)
            {
                Thin2SharRight = "-";
            }
            else
            {
                Thin2SharRight = data[149].ToString();
            }

            if (data[150] == null)
            {
                Thin2SharLeft = "-";
            }
            else
            {
                Thin2SharLeft = data[150].ToString();
            }

            if (data[151] == null)
            {
                IsHruntovka = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите нилачие грунтовки");
            }
            else
            {
                IsHruntovka = data[151].ToString();
            }

            if (data[152] == null)
            {
                Adheziya = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите наличие адгезии");
            }
            else
            {
                Adheziya = data[152].ToString();
            }

            if (data[153] == null)
            {
                Vologa = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите наличие влажности");
            }
            else
            {
                Vologa = data[153].ToString();
            }

            if (data[154] == null)
            {
                PipeTemperature = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите температуру трубы");
            }
            else
            {
                PipeTemperature = data[154].ToString();
            }

            if (data[155] == null)
            {
                StanPoverhnyPipe = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите стан поверхности трубы");
            }
            else
            {
                StanPoverhnyPipe = data[155].ToString();
            }

            if (data[156] == null)
            {
                SquareMetalPipe = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите площадь поверхности трубы");
            }
            else
            {
                SquareMetalPipe = data[156].ToString();
            }

            if (data[157] == null)
            {
                IsKorozyaExist = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите наличие корозии");
            }
            else
            {
                IsKorozyaExist = data[157].ToString();
            }

            if (data[158] == null)
            {
                CharacterKorozii = "-";
            }
            else
            {
                CharacterKorozii = data[158].ToString();
            }

            if (data[159] == null)
            {
                KavernLength = "-";
            }
            else
            {
                KavernLength = data[159].ToString();
            }

            if (data[160] == null)
            {
                KavernHeight = "-";
            }
            else
            {
                KavernHeight = data[160].ToString();
            }

            if (data[161] == null)
            {
                KavernPosition = "-";
            }
            else
            {
                KavernPosition = data[161].ToString();
            }


            if (data[162] == null)
            {
                UtzBeforShurf = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите потенциал до шурфования");
            }
            else
            {
                UtzBeforShurf = data[162].ToString();
            }


            if (data[163] == null)
            {
                UtzAfterShurf = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите потенциал после шурфования");
            }
            else
            {
                UtzAfterShurf = data[163].ToString();
            }


            if (data[164] == null)
            {
                UtzInShurf = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите потенциал в шурфе");
            }
            else
            {
                UtzInShurf = data[164].ToString();
            }

            if (data[165] == null)
            {
                ShurfMadeOrganization = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите кто шурфовал (организация)");
            }
            else
            {
                ShurfMadeOrganization = data[165].ToString();
            }

            if (data[166] == null)
            {
                ShurfMadeUser = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите кто шурфовал");
            }
            else
            {
                ShurfMadeUser = data[166].ToString();
            }

            if (data[167] == null)
            {
                PredstavnykZakazchyka = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите представитель заказчика");
            }
            else
            {
                PredstavnykZakazchyka = data[167].ToString();
            }

            if (data[168] == null)
            {
                DateOglyadu = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите дату");
            }
            else
            {
                DateOglyadu = data[168].ToString();
            }

            if (data[169] == null)
            {
                PhotoPoverhny = "-";
                Logs.AddError($"{ErrorMessageStart}  укажите фото певерхности");
            }
            else
            {
                PhotoPoverhny = data[169].ToString();
            }
            if (Hlub == null) Logs.AddError($"{ErrorMessageStart}  укажите глубину");
            if (Rhr == null) Logs.AddError($"{ErrorMessageStart}  укажите сопротивление грунта");
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(AktNumber) || AktNumber == "-") return Name;
            return $"{Name} №{AktNumber}";
        }

    }
}
