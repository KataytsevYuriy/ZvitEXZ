using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    internal static class AcadConstants
    {
        public static double? KmStart = null;
        public static double LenthXByDoc = 300;
        public static double LenthXByDocDefault = 300;
        public static double AdocDefaultLenthKm = 3;
        public static double AcadMaxDrawingStep = 0.011;

        public static double RepeatObjectsEvery = 0.05;

        //Acad Layer Names
        public static string LayerUtz = "График_U";
        public static string LayerUpol = "График_UPolar";
        public static string LayerUpolLine = "График_U_085";
        public static string LayerGrad = "График_G";
        public static string LayerText = "Текст";
        public static string LayerNormHlubyna = "График_Глуб";
        public static string LayerNotNormHlubyna = "График_Среза_НеНормативной_Глубины";
        public static string LayerDstuHlubyna = "График_Нормативной_Глубины";
        public static string LayerRhr = "График_Rгр.";
        public static string LayerRhr20 = "График_Rгр_20Ом.";
        public static string LayerRhr50 = "График_Rгр_50Ом.";

        public static double DocStartX = 100;

        //Draw Shkala 
        public static double DigitHeight = 2;
        public static double DigitMoveLeft = 7;
        public static double RyskaLenth = 2;
        public static double ShkalaUtzStep = -0.2;
        public static double ShkalaUgradStep = -50;
        public static double ShkalaRhruntaStep = 10;
        public static double ShkalaHlubynaStep = 1;
        public static double ShkalaRhrStep = 10;


        //Coordinates Utz
        public static double UtzStartY = 210;
        public static double UtzMinY = 219.5;
        public static double UtzMin = -0.5;
        public static double UtzMaxY = 163.5;
        public static double UtzMax = -2.5;
        public static double UtzTrimmedY = 161;

        //Coordidates Zalivky
        public static double HruntActivityStartY = 51.5;
        public static double PovregdenyaStartY = 30.5;
        public static double NezahystUtzStartY = 35.75;
        public static double NezahystUpolStartY = 39.25;
        public static double KornebStartY = 44.5;
        public static double KmobjectsStartY = 223.2;
        public static double KmobjectsStepY = 3;
        public static double SignatureObjectsStartY = 310;
        public static double SignatureObjectsStepY = 5;
        //Coordibates Gradient
        public static double UgradMinY = 158;
        public static double UgradMin = 0;
        public static double UgradMaxY = 102;
        public static double UgradMax = -150;
        public static double UgradTrimmedY = 99.5;
        //Coordinates R hrunta
        public static double RhrMinY = 78;
        public static double RhrMin = 10;
        public static double RhrMaxY = 96;
        public static double RhrMax = 100;
        //Coordinates Hlubynad
        public static double HlubMinY = 74.5;
        public static double HlubMin = 0;
        public static double HlubMaxY = 57.5;
        public static double HlubMax = 2;
        public static double HlubTrimmed = HlubMax * 1.1;
        //Coordinates objects
        public static double PipeStartY = 254;
        public static double ObjPovPerehHeight = 4.8;
        public static double ObjPovPerehWidth = 1.25;
        //Shkala Km
        public static double ShkalaKmStartY = 282;
        public static double ShkalaKmDigitStartY = 286.5;
        public static double ShkalaKmDigitSize = 3.5;
        public static double ShkalaKmDigitStep = 0.5;
        public static double ShkalaKmDigitSdvigX = -3;
        public static double ShkalaKmStep = 0.1;
        public static string ShkalaKmBlockName = "shkalaKm";
        public static string LineDotsName = "dots";
        public static double LineDotsY = 222;



        //Drawing block Names
        public const string DrawingBlockName = "block";
        public const string DrawingLayerName = "layer";
        public const string DrawingPlineName = "pline";
        public const string DrawingTextName = "text";

        //Files
        public const string AcadFolderName = "Графики";
        public const string AcadPrefixFileName = "Protocol";
        public const string ShablonProtokolFilename = "Shablon_Protocol.xlsm";

        //Objects
        public const string ThisPipe = "pipe";
        public const string ObjRiver = "Река";
        public const string ObjDrip = "Кран_Дренажн";
        public const string ObjGRS = "ГРС";
        public const string ObjKabel = "Кабель";
        public const string ObjKanal = "Канал";
        public const string ObjKran = "Кран";
        public const string ObjLep02 = "ЛЭП_2";
        public const string ObjLep04 = "ЛЭП_4";
        public const string ObjLep10 = "ЛЭП_10";
        public const string ObjLep35 = "ЛЭП_35";
        public const string ObjLep110 = "ЛЭП_110";
        public const string ObjLep220 = "ЛЭП_220";
        public const string ObjLep330 = "ЛЭП_330";
        public const string ObjLep500 = "ЛЭП_500";
        public const string ObjLep750 = "ЛЭП_750";
        public const string ObjOtvodLeft = "Отвод_лево";
        public const string ObjOtvodRight = "Отвод_право";
        public const string ObjPerehodDn = "Переход_DN";
        public const string ObjPovorotLeft = "Поворот_лево";
        public const string ObjPovoroRight = "Поворот_право";
        public const string ObjPV = "КИП_рабоч";
        public const string ObjPVNwork = "КИП_нерабоч";
        public const string ObjRoadAutomobil = "Дорога_автомобильная";
        public const string ObjRoadHrunt = "Дорога_грунтовая";
        public const string ObjRoadPolevaya = "Дорога_полевая";
        public const string ObjRoadRail = "Дорога_железная";
        public const string ObjRoadRailPost = "Дорога_железная(постоянный ток)";
        public const string ObjRoadRailPerem = "Дорога_железная (переменный ток)";
        public const string Objkozhuh = "Кожух";
        public const string ObjShurf = "Шурф";
        public const string ObjStolbUkaz = "Столб_указательный";
        public const string ObjStolbKm = "Столб_километровый";
        public const string ObjSvechaProduv = "Свеча_продув";
        public const string ObjSvechaObrez = "Свеча_обрезанная";
        public const string ObjSvechaVytyazh = "Свеча_вытяжная";
        public const string ObjSvish = "Свищь";
        public const string ObjSwampNP = "Болото_непроходимое";
        public const string ObjTree = "Дерево_на_трубе";
        public const string ObjTruboprovid = "Трубопровод";
        public const string ObjGazoprovid = "Газопровод";
        public const string ObjNaftaprovid = "Нефтепровод";
        public const string ObjVodovod = "Водовод";
        public const string ObjAmiakprovid = "Аммиакопровод";
        public const string ObjUDZ = "УДЗ";
        public const string ObjUKZ = "СКЗ_работающая";
        public const string ObjUKZDontWork = "СКЗ_неработающая";
        public const string ObjUKZRezerv = "СКЗ_резервн";
        public const string ObjVhodVZemlyu = "Вход_в_землю";
        public const string ObjVyhodIzZemly = "Выход_из_земли";
        public const string ObjPovitrPerehStart = "Возд_перех_нач";
        public const string ObjPovitrPerehEnd = "Возд_перех_кон";
        public const string ObjPovitrPereh = "Возд_переход";
        public const string ObjZaroslyNP = "Заросли_непролазные";
        public const string ObjUstanovytPV = "Установить_ПВ";
        public const string ObjUstanovytStolb = "Установить_столб_указательный";
        public const string ObjUstanovytUkz = "Установить УКЗ";
        public const string ObjUstanovytUdz = "Установить УДЗ";
        public const string ObjUstanovytSvecha = "Установить_Свечу";
        public const string ObjUstanovytKozhuh = "Установить кожух";
        public const string ObjZabor = "Забор";
        public const string ObjObjecstZamer = "Объект";
        //Установить_столб_указательный

        //Mestnost
        public const string MestnostCX = "Сх_поля";
        public const string MestnostPosBPros = "Посадка";
        public const string MestnostPosSPros = "посадка_просека";
        public const string MestnostLesBPros = "Лес_лиственный";
        public const string MestnostLesSPros = "Лес_просека";
        public const string MestnostLug = "Луг";
        public const string MestnostZarosly = "Заросли_пролазные";
        public const string MestnostZabolHrunt = "Болото_проходимое";
        public const string MestnostPustyr = "Пустырь";
        public const string MestnostSad = "Сад";
        public const string MestnostBalkaStart = "Балка_начало";
        public const string MestnostBalkaEnd = "Балка_конец";

        //Блоки с заливкой
        public const string ZalivkaGreen = "green";
        public const string ZalivkaYellow = "yellow";
        public const string ZalivkaRed = "red";
        public const string ZalivkaRedSmall = "red_small";
        public const string ZalivkaBlueSmall = "blue_small";
        public const string ZalivkaBlue = "blue";


        //Namse
        public static double NameShifrX = 300;
        public static double NameShifrY = 15.15;
        public static double NamePipeNameY = 11.4;
        public static double NameKmY = 7.65;
        public static double NamePipesDataY = 22.4;
        public static double NamePipesDataX = 150;

        public static double NameTexySyze = 2.2;
    }
}
