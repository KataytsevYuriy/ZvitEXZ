﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    public static class ProjectConstants
    {
        //Objects names
        public const string PVName = "ПВ";
        public const string LepName = "ЛЕП";
        public const string LepNameInNaborka = "ЛЭП";
        public const string RoadName = "Дорога";
        public const string RoadNameInNaborka = "Дорога";
        public const string RiverName = "Річка";
        public const string RiverNameInNaborka = "Река";
        public const string SwampName = "Болото";
        public const string SwampNameInNaborka = "Болото непроходимое";
        public const string PovorotName = "Поворот";
        public const string PovorotNameInNaborka = "Поворот";
        public const string TurnRightName = "праворуч";
        public const string TurnLeftName = "ліворуч";
        public const string SvechaName = "Свіча";
        public const string SvechaNameInNaborka = "Свеча";
        public const string TreeName = "Дерево";
        public const string Stolb = "Стовп";
        public const string StolbInNaborka = "Столб";
        public const string UKZName = "УКЗ";
        public const string UKZNameInNaborka = "УКЗ";
        public const string UDZName = "УДЗ";
        public const string UDZNameInNaborka = "УДЗ";
        public const string KranName = "Кран";
        public const string KranNameInNaborka = "Кран";
        public const string TruboprovodName = "Трубопровід";
        public const string TruboprovodNameInNaborka = "Трубопровод";
        public const string OtvodName = "Відвід";
        public const string OtvodNameInNaborka = "Отвод";
        public const string KanalName = "Канал";
        public const string KanalNameInNaborka = "Канал";
        public const string YamaName = "Яма";
        public const string YamaNameInNaborka = "Яма";
        public const string SvalkaName = "Звалище";
        public const string SvalkaInNaborka = "Свалка";
        public const string VyhodIsZemlyName = "Повітряний перехід";
        public const string VyhodIsZemlyInNaborka = "Выход из земли";
        public const string GRSName = "ГРС";
        public const string GRSInNaborka = "ГРС";
        public const string ZaroslyName = "Хащі непролазні";
        public const string ZaroslyInNaborka = "Заросли непрол";
        public const string KabelName = "Кабель";
        public const string KabelInNaborka = "Кабель";
        public const string ShurfName = "Шурф";
        public const string ShurfInNaborka = "Шурф";
        public const string BludyName = "Блукаючі струми";
        public const string BludyInNaborka = "Блужд токи";
        public const string SvishName = "Свіщ";
        public const string SvishInNaborka = "Свищ";
        public const string DilyankaKorNebName = "Корозійно-небезпечна ділянка";
        public const string DilyankaKorNebInNaborka = "Корр небез уч-ок";
        public const string DripName = "ДРІП";
        public const string DripInNaborka = "ДРІП";
        public const string ObjectName = "Об'єкт";
        public const string ObjectInNaborka = "Объект";
        public const string PerehodDNName = "Перехід діаметрів";
        public const string PerehodDNInNaborka = "Переход DN";
        public const string UPZName = "УПЗ";
        public const string UPZNInNaborka = "УПЗ";
        public const string NeobstegenaDylyankaName = "Необстежена ділянка";
        public const string NeobstegenaDylyankaNInNaborka = "Необсл уч-ок";
        public const string UstanovytName = "Встановити";
        public const string UstanovytNameInNaborka = "Установить";
        public const string ZaborName = "Огорожа";
        public const string ZaborNameInNaborka = "Забор";

        //File Names
        public const string ShablonFileName2 = "Shablon.xlsb";
        public const string ShablonWordFileName2 = "Shablon.docm";
        public const string ShablonFileName = @"..\..\Shablon.xlsb";
        public const string ShablonWordFileName = @"..\..\Shablon.docm";
        public const string PVFolderName = "Додаток_И-ПВ";
        public const string NezahFolderName = "Додаток_М-Незахист";
        public const string NezahpolFileName = "Додаток_М-Незахист_поляриз";
        public const string KornebFolderName = "Додаток_К-КорНеб";
        public const string ZvedenaFolderName = "Додаток_Р-Зведена";
        public const string UkzFolderName = "Додаток_Д-УКЗ";
        public const string PovregdFolderName = "Додаток_Л-Пошкодження";
        public const string PovregdGNTFolderName = "Додаток_Л-Пошкодження_ГНТ";
        public const string UpzFolderName = "Додаток_Ж-УПЗ";
        public const string FlanetsFolderName = "Додаток_П-Фланці";
        public const string NenormHlubFolderName = "Додаток_С-Ненор_глибина";
        public const string PerehodFolderName = "Додаток_Н-Переходи";
        public const string ShurfFolderName = "Додаток_У-Шурфи";
        public const string PovitrPerehodFolderName = "Додаток_Ф-Повітряні_Переходи";
        public const string StatisticsFolderName = "Статистика";

        public const string PerehodKozhuhFileName = "Додаток_Н-Вимір_кожух";
        public const string PerehodStanFileName = "Додаток_Н-Стан_переходу";

        //Korneb
        public const string KorNebNezahMessage = "Eзах менше нормативного";
        public const string KorNebPerezahMessage = "Eзах більше нормативного";
        public const string KorNebRhrMessage = "ρґ<=20 Ом*м";
        public const string KorNebZabolHrMessage = "заболочений грунт";
        public const string KorNebTruboprovodMessage = "перетин із трубопроводом";
        // Message id data is empty
        public const string PrintMessagePZIsEmpty = "На обстеженому трубопроводі ПВ - відсутні";
        public const string PrintMessageKornebIsEmpty = "На обстеженому трубопроводі корозійно-небезпечні ділянки - відсутні";
        public const string PrintMessageNezahIsEmpty = "На обстеженому трубопроводі ділянки із недостатнім зівнем захисного потенціалу - відсутні";
        public const string PrintMessageUkzIsEmpty = "На обстеженому трубопроводі УКЗ - відсутні";
        public const string PrintMessagepovregdIsEmpty = "На обстеженому трубопроводі пошкождення ізоляції - відсутні";
        public const string PrintMessageUpzdIsEmpty = "На обстеженому трубопроводі УПЗ - відсутні";
        public const string PrintMessagePerehodKozhuhIsEmpty = "На обстеженому трубопроводі переходи через автодороги та залізниці в кожусі - відсутні";
        public const string PrintMessageStanPerehoduIsEmpty = "На обстеженому трубопроводі переходи через автодороги та залізниці - відсутні";
        public const string PrintMessageFlanetsIsEmpty = "На обстеженому трубопроводі електроізолююці фланці - відсутні";
        public const string PrintMessagePovitrPerehIsEmpty = "На обстеженому трубопроводі повітряні переходи - відсутні";
        public const string PrintMessageShurfIsEmpty = "На обстеженому трубопроводі шурфи - відсутні";
        public const string PrintMessageNenormHlubIsEmpty = "На обстеженому трубопроводі ділянки з ненормативною глибиною залягання - відсутні";

        //Mestnoct
        public const string MestnostCX = "с/г угіддя";
        public const string MestnostPosBPros = "посадка без просіки";
        public const string MestnostPosSPros = "посадка з просікою";
        public const string MestnostLesBPros = "ліс без просіки";
        public const string MestnostLesSPros = "ліс с просікою";
        public const string MestnostLug = "луговина";
        public const string MestnostZarosly = "хащі";
        public const string MestnostZabolHrunt = "заболочений грунт";
        public const string MestnostPustyr = "пустир";
        public const string MestnostSad = "сад";
        public const string MestnostBalka = "балка";
        public const string MestnostPoyma = "заплавина річки";


        public const double TruboprovodKornebLength = 0.05;
        public const double RoadKornebLength = 0.05;


        public static double PovregdenyaFirstCherga = -0.02;
        public static double PovregdenyaSecondCherga = -0.15;
        public static double UperezahBitum = 2.5;
        public static double UperezahPlivka = 3.5;
        public static double StepVymiryvannya = 0.0101;
        public static double DylyankaGNT = 0.1;

        //static variables
        public static string DocShablonPath;

        //IsAllowed
        public static bool IsAllowedCad = false;
    }
}
