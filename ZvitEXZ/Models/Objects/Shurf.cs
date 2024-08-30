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
                Logs.AddError($"{ErrorMessageStart} вкажіть номер акта");
            }
            else
            {
                AktNumber = data[122].ToString();
            }

            if (data[124] == null)
            {
                ShurfLength = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть довжину шурфа");
            }
            else
            {
                ShurfLength = data[124].ToString();
            }

            if (data[125] == null)
            {
                IsolationSquare = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть площу ізоляції");
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
                Logs.AddError($"{ErrorMessageStart} вкажіть місцевість");
            }
            else
            {
                MestnostCharacteristics = data[127].ToString();
            }

            if (data[129] == null)
            {
                LitologHrunt = "";
                Logs.AddError($"{ErrorMessageStart} вкажіть склад грунту");
            }
            else
            {
                LitologHrunt = data[129].ToString();
            }

            if (data[130] == null)
            {
                StanHruntu = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть стан грунту");
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
                //Logs.AddError($"{ErrorMessageStart} укажите мех. повреждения");
            }
            else
            {
                IsMehPoshkodzhenObhortka = data[135].ToString();
            }

            if (data[136] == null)
            {
                IzolationType1 = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть тип ізоляції");
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
                Logs.AddError($"{ErrorMessageStart} вкажіть стан поверхні");
            }
            else
            {
                StanPoverhnyUp = data[138].ToString();
            }

            if (data[139] == null)
            {
                StanPoverhnyDown = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть стан поверхні");
            }
            else
            {
                StanPoverhnyDown = data[139].ToString();
            }

            if (data[140] == null)
            {
                StanPoverhnyRight = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть стан поверхні");
            }
            else
            {
                StanPoverhnyRight = data[140].ToString();
            }

            if (data[141] == null)
            {
                StanPoverhnyLeft = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть стан поверхні");
            }
            else
            {
                StanPoverhnyLeft = data[141].ToString();
            }

            if (data[142] == null)
            {
                IzolationStructure = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть структуру изоляції");
            }
            else
            {
                IzolationStructure = data[142].ToString();
            }

            if (data[143] == null)
            {
                Thin1SharUp = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть толщину изоляції");
            }
            else
            {
                Thin1SharUp = data[143].ToString();
            }

            if (data[144] == null)
            {
                Thin1SharDown = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть толщину изоляції");
            }
            else
            {
                Thin1SharDown = data[144].ToString();
            }

            if (data[145] == null)
            {
                Thin1SharRight = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть толщину изоляції");
            }
            else
            {
                Thin1SharRight = data[145].ToString();
            }

            if (data[146] == null)
            {
                Thin1SharLeft = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть толщину изоляції");
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
                Logs.AddError($"{ErrorMessageStart}  вкажіть наявність грунтівки");
            }
            else
            {
                IsHruntovka = data[151].ToString();
            }

            if (data[152] == null)
            {
                Adheziya = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть наявність адгезії");
            }
            else
            {
                Adheziya = data[152].ToString();
            }

            if (data[153] == null)
            {
                Vologa = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть наявність вологи");
            }
            else
            {
                Vologa = data[153].ToString();
            }

            if (data[154] == null)
            {
                PipeTemperature = "-";
                Logs.AddError($"{ErrorMessageStart} вкажіть температуру труби");
            }
            else
            {
                PipeTemperature = data[154].ToString();
            }

            if (data[155] == null)
            {
                StanPoverhnyPipe = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть стан поверхні труби");
            }
            else
            {
                StanPoverhnyPipe = data[155].ToString();
            }

            if (data[156] == null)
            {
                SquareMetalPipe = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть площу поверхні труби");
            }
            else
            {
                SquareMetalPipe = data[156].ToString();
            }

            if (data[157] == null)
            {
                IsKorozyaExist = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть наявність корозії");
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
                Logs.AddError($"{ErrorMessageStart}  вкажіть потенціал до шурфования");
            }
            else
            {
                UtzBeforShurf = data[162].ToString();
            }


            if (data[163] == null)
            {
                UtzAfterShurf = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть потенціал після шурфования");
            }
            else
            {
                UtzAfterShurf = data[163].ToString();
            }


            if (data[164] == null)
            {
                UtzInShurf = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть потенціал в шурфі");
            }
            else
            {
                UtzInShurf = data[164].ToString();
            }

            if (data[165] == null)
            {
                ShurfMadeOrganization = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть кто шурфував (организація)");
            }
            else
            {
                ShurfMadeOrganization = data[165].ToString();
            }

            if (data[166] == null)
            {
                ShurfMadeUser = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть кто шурфував");
            }
            else
            {
                ShurfMadeUser = data[166].ToString();
            }

            if (data[167] == null)
            {
                PredstavnykZakazchyka = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть представник замовника");
            }
            else
            {
                PredstavnykZakazchyka = data[167].ToString();
            }

            if (data[168] == null)
            {
                DateOglyadu = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть дату");
            }
            else
            {
                DateOglyadu = data[168].ToString();
            }

            if (data[169] == null)
            {
                PhotoPoverhny = "-";
                Logs.AddError($"{ErrorMessageStart}  вкажіть фото певерхні");
            }
            else
            {
                PhotoPoverhny = data[169].ToString();
            }
            if (Hlub == null) Logs.AddError($"{ErrorMessageStart}  вкажіть глибину");
            if (Rhr == null) Logs.AddError($"{ErrorMessageStart}  вкажіть опір грунта");
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(AktNumber) || AktNumber == "-") return Name;
            return $"{Name} №{AktNumber}";
        }
        public override string GetCadType()
        {
            return AcadConstants.ObjShurf;
        }
        public override string GetCadSignature()
        {
            if (string.IsNullOrEmpty(AktNumber)) return "Шурф";
            return $"Шурф №{AktNumber}";
        }
    }
}
