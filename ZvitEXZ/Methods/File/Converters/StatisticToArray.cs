using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class StatisticToArray
    {
        public string[,] Convert(Statistics statistics)
        {
            string[,] res = new string[55, 10];
            res[0, 0] = statistics.PipeName;
            res[1, 0] = statistics.DateStart;
            res[2, 0] = statistics.ProjectsOrganization;
            res[3, 0] = statistics.BuildingsOrganization;
            res[4, 0] = statistics.ProjectPressure;
            res[5, 0] = statistics.WorkPressure;
            res[6, 0] = statistics.Temperuture;
            res[9, 0] = statistics.DnToDn;
            res[10, 0] = statistics.Rechovyna;
            res[11, 0] = statistics.PoperObstegennya;
            res[12, 0] = statistics.NameOrganization;
            res[13, 0] = statistics.DylyankaName;
            res[14, 0] = statistics.DylyankaKm;
            res[15, 0] = statistics.PipeType;
            res[17, 0] = statistics.PipeBuilder;
            res[18, 0] = statistics.StealMark;
            res[19, 0] = statistics.StartDN;
            res[20, 0] = statistics.Thikness;
            res[21, 0] = statistics.IsolationKlass;
            res[22, 0] = statistics.IsolationType;
            res[23, 0] = statistics.IsolationConstruction;
            res[24, 0] = "КМ";
            res[24, 1] = "%";
            res[25, 0] = statistics.LengthByTZ;
            res[26, 0] = ConvertToString.DoubleToString(statistics.KmFakt);
            res[26, 1] = "100";
            res[27, 0] = ConvertToString.DoubleToString(statistics.KmObstegeno);
            res[27, 1] = ConvertToString.DoubleToString(statistics.KmObstegenoPerсent);
            res[28, 0] = ConvertToString.DoubleToString(statistics.KmNeobstegeno);
            res[28, 1] = ConvertToString.DoubleToString(statistics.KmNeobstegenoPerсent);
            res[29, 0] = ConvertToString.DoubleToString(statistics.Water);
            res[29, 1] = ConvertToString.DoubleToString(statistics.WaterPersent);
            res[31, 0] = ConvertToString.DoubleToString(statistics.HruntHight);
            res[31, 1] = ConvertToString.DoubleToString(statistics.HruntHightPerсent);
            res[32, 0] = ConvertToString.DoubleToString(statistics.HruntMedium);
            res[32, 1] = ConvertToString.DoubleToString(statistics.HruntMediumtPerсent);
            res[33, 0] = ConvertToString.DoubleToString(statistics.HruntLow);
            res[33, 1] = ConvertToString.DoubleToString(statistics.HruntLowPersent);
            res[34, 0] = ConvertToString.DoubleToString(statistics.RhruntMin);
            res[35, 0] = ConvertToString.DoubleToString(statistics.RhruntMax);
            res[37, 0] = ConvertToString.DoubleToString(statistics.Protected);
            res[37, 1] = ConvertToString.DoubleToString(statistics.ProtectedPerсent);
            res[38, 0] = ConvertToString.DoubleToString(statistics.NoProtected);
            res[38, 1] = ConvertToString.DoubleToString(statistics.NoProtectedPerсent);
            res[43, 0] = ConvertToString.DoubleToString(statistics.Korneb);
            res[43, 1] = ConvertToString.DoubleToString(statistics.KornebPersent);
            res[45, 0] = ConvertToString.DoubleToString(statistics.PovregdFirstCherga);
            res[45, 1] = ConvertToString.DoubleToString(statistics.PovregdFirstChergaPercent);
            res[46, 0] = ConvertToString.DoubleToString(statistics.PovregdSecondCherga);
            res[46, 1] = ConvertToString.DoubleToString(statistics.PovregdSecondChergaPercent);
            res[47, 0] = ConvertToString.DoubleToString(statistics.Umin);
            res[48, 0] = ConvertToString.DoubleToString(statistics.Umax);
            res[51, 0] = ConvertToString.DoubleToString(statistics.HlubMin);
            res[52, 0] = ConvertToString.DoubleToString(statistics.HlybMax);
            res[53, 0] = ConvertToString.DoubleToString(statistics.ForestsAll);
            res[53, 1] = ConvertToString.DoubleToString(statistics.ForestsAllPrecent);
            res[54, 0] = ConvertToString.DoubleToString(statistics.ForestsToClear);
            res[54, 1] = ConvertToString.DoubleToString(statistics.ForestsToClearPrecent);
            //Сторонние коммуникации
            int i = 0;
            foreach (Truboprovod truboprovod in statistics.StoronnieComunications)
            {
                res[i, 2] = $"{truboprovod} км {ConvertToString.DoubleToString(truboprovod.Km)}";
                i++;
            }
            i = 0;
            foreach (Kanal kanal in statistics.Kanals)
            {
                res[i, 3] = $"{kanal} км {ConvertToString.DoubleToString(kanal.Km)}, L = {ConvertToString.DoubleToString(kanal.Length, 0)} м";
                i++;
            }
            i = 0;
            foreach (River river in statistics.Rivers)
            {
                res[i, 4] = $"{river} км {ConvertToString.DoubleToString(river.Km)}, L = {ConvertToString.DoubleToString(river.Length, 0)} м";
                i++;
            }
            i = 0;
            foreach (NeObstegeno neObstegeno in statistics.NeObstegenos)
            {
                res[i, 5] = $" км {ConvertToString.DoubleToString(neObstegeno.KmStart)} - км {ConvertToString.DoubleToString(neObstegeno.KmEnd)}, L = {ConvertToString.DoubleToString(neObstegeno.KmEnd - neObstegeno.KmStart)} км";
                i++;
            }
            return res;
        }
    }
}
