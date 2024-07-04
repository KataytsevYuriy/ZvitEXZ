using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Models
{
    internal static class AcadConstants
    {
        public static double LenthByDoc = 300;
        public static double AdocDefaultLenthKm = 3;
        public static double AcadMaxDrawingStep = 0.011;

        //Acad Layer Names
        public static string LayerUtz = "График_U";
        public static string LayerGrad = "График_G";

        public static double DocStartX = 100;

        //Draw Shkala
        public static double DigitHeight = 2;
        public static double DigitMoveLeft = 7;
        public static double RyskaLenth = 2;
        public static double ShkalaUtzStep = 0.2;


        //Coordinates Utz
        public static double UtzStartY = 210;
        public static double UtzMinY = 219.5;
        public static double UtzMin = 0.5;
        public static double UtzMaxY = 162;
        public static double UtzMax = 2.5;

        //Drawing block Names
        public const string DrawingBlockName = "block";
        public const string DrawingLayerName = "layer";
        public const string DrawingPlineName = "pline";
        public const string DrawingTextName = "text";

        //Files
        public const string AcadFolderName = "Графики";
        public const string AcadPrefixFileName = "Protocol";
        public const string ShablonProtokolFilename = "Shablon_Protocol.xlsm";

    }
}
