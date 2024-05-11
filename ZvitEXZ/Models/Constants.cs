using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    public static class Constants
    {
        //Objects names
        public const string PVName = "ПВ";
        public const string LepName = "ЛЕП";
        public const string RiverName = "Річка";
        public const string SwampName = "Болото";
        public const string PovorotName = "Поворот";
        public const string SvechaName = "Свіча";

        public const string RiverNameInNaborka = "Река";
        public const string LepNameInNaborka = "ЛЭП";
        public const string SwampNameInNaborka = "Болото непроходимое";
        public const string PovorotNameInNaborka = "Поворот";
        public const string SvechaNameInNaborka = "Свеча";

        //File Names
        public const string ShablonFileName = "Shablon.xlsb";
        public const string PVFolderName = "Додаток_И-ПВ";
        public const string NezahFolderName = "Додаток_М-Незахист";
        public const string KornebFolderName = "Додаток_К-КорНеб";


        public const string KorNebNezahMessage = "Eзах менше нормативного";
        public const string KorNebRhrMessage = "ρґ<=20 Ом*м";
        public const string KorNebZabolHrMessage = "заболочений грунт";
        // Message id data is empty
        public const string PrintMessagePZIsEmpty = "На обстеженому трубопроводі ПВ - відсутні";
        public const string PrintMessageKornebIsEmpty = "На обстеженому трубопроводі корозійно-небезпечні ділянки - відсутні";
        public const string PrintMessageNezahIsEmpty = "На обстеженому трубопроводі ділянки із недостатнім зівнем захисного потенціалу - відсутні";
    }
}
