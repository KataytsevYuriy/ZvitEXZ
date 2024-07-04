using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAllWordReplacer
    {
        public List<WordReplace> Get(Statistics statistics)
        {
            List<WordReplace> wordReplaces = new List<WordReplace>();
            wordReplaces.Add(new WordReplace("1", statistics.PipeType));
            wordReplaces.Add(new WordReplace("2", FromUpper(statistics.PipeType)));
            wordReplaces.Add(new WordReplace("3", statistics.PipeType.ToUpper()));
            wordReplaces.Add(new WordReplace("4", statistics.PipeTypeRodPadezh));
            wordReplaces.Add(new WordReplace("5", FromUpper(statistics.PipeShortType)));
            wordReplaces.Add(new WordReplace("6", statistics.PipeTypeRodPadezh.ToUpper()));
            wordReplaces.Add(new WordReplace("7", statistics.PipeShortType));
            wordReplaces.Add(new WordReplace("8", FromUpper(statistics.PipeShortType)));
            wordReplaces.Add(new WordReplace("9", statistics.PipeShortType.ToUpper()));
            wordReplaces.Add(new WordReplace("10", statistics.PipeName));
            wordReplaces.Add(new WordReplace("11", FromUpper(statistics.PipeName)));
            wordReplaces.Add(new WordReplace("12", statistics.PipeName.ToUpper()));
            wordReplaces.Add(new WordReplace("13", statistics.DylyankaName));
            wordReplaces.Add(new WordReplace("14", statistics.DylyankaKm));
            wordReplaces.Add(new WordReplace("15", statistics.StartDN));
            wordReplaces.Add(new WordReplace("16", statistics.IsolationType));
            wordReplaces.Add(new WordReplace("17", statistics.NameOrganization));
            wordReplaces.Add(new WordReplace("18", statistics.DateStart));
            wordReplaces.Add(new WordReplace("19", statistics.ProjectsOrganization));
            wordReplaces.Add(new WordReplace("20", statistics.BuildingsOrganization));
            wordReplaces.Add(new WordReplace("21", statistics.DN));
            wordReplaces.Add(new WordReplace("22", statistics.Thikness));
            wordReplaces.Add(new WordReplace("23", statistics.StealMark));
            wordReplaces.Add(new WordReplace("24", statistics.PipeBuilder));
            wordReplaces.Add(new WordReplace("25", statistics.LengthByTZ));
            wordReplaces.Add(new WordReplace("26", statistics.ProjectPressure));
            wordReplaces.Add(new WordReplace("27", statistics.WorkPressure));
            wordReplaces.Add(new WordReplace("28", statistics.Temperuture));
            wordReplaces.Add(new WordReplace("29", statistics.Rechovyna));
            wordReplaces.Add(new WordReplace("30", statistics.IsolationKlass));
            wordReplaces.Add(new WordReplace("31", statistics.IsolationConstruction));
            wordReplaces.Add(new WordReplace("32", statistics.DnToDn));
            wordReplaces.Add(new WordReplace("33", statistics.Remonty));
            wordReplaces.Add(new WordReplace("34", statistics.PoperObstegennya));
            wordReplaces.Add(new WordReplace("35", statistics.Shyfr));
            wordReplaces.Add(new WordReplace("36", statistics.Shyfr.Replace("КК", "ПЗ").Replace("KK", "ПЗ")));
            wordReplaces.Add(new WordReplace("37", DoubleToString(statistics.KmFakt)));
            wordReplaces.Add(new WordReplace("38", statistics.DylyankaName.ToUpper()));
            wordReplaces.Add(new WordReplace("39", DoubleToString(statistics.KmObstegeno)));
            wordReplaces.Add(new WordReplace("40", DoubleToString(statistics.KmObstegenoPerсent, 2)));
            wordReplaces.Add(new WordReplace("41", DoubleToString(statistics.KmNeobstegeno)));
            wordReplaces.Add(new WordReplace("42", DoubleToString(statistics.KmNeobstegenoPerсent, 2)));
            wordReplaces.Add(new WordReplace("43", DoubleToString(statistics.Water)));
            wordReplaces.Add(new WordReplace("44", DoubleToString(statistics.WaterPersent, 2)));
            wordReplaces.Add(new WordReplace("45", DoubleToString(statistics.HruntHight)));
            wordReplaces.Add(new WordReplace("46", DoubleToString(statistics.HruntHightPerсent, 2)));
            wordReplaces.Add(new WordReplace("47", DoubleToString(statistics.HruntMedium)));
            wordReplaces.Add(new WordReplace("48", DoubleToString(statistics.HruntMediumtPerсent, 2)));
            wordReplaces.Add(new WordReplace("49", DoubleToString(statistics.HruntLow)));
            wordReplaces.Add(new WordReplace("50", DoubleToString(statistics.HruntLowPersent, 2)));
            wordReplaces.Add(new WordReplace("51", DoubleToString(statistics.Protected)));
            wordReplaces.Add(new WordReplace("52", DoubleToString(statistics.ProtectedPerсent, 2)));
            wordReplaces.Add(new WordReplace("53", DoubleToString(statistics.NoProtected)));
            wordReplaces.Add(new WordReplace("54", DoubleToString(statistics.NoProtectedPerсent, 2)));
            wordReplaces.Add(new WordReplace("55", DoubleToString(statistics.Korneb)));
            wordReplaces.Add(new WordReplace("56", DoubleToString(statistics.KornebPersent, 2)));
            wordReplaces.Add(new WordReplace("57", DoubleToString(statistics.RhruntMin, 1)));
            wordReplaces.Add(new WordReplace("58", DoubleToString(statistics.RhruntMax, 1)));
            wordReplaces.Add(new WordReplace("59", DoubleToString(statistics.PovregdFirstCherga)));
            wordReplaces.Add(new WordReplace("60", DoubleToString(statistics.PovregdFirstChergaPercent, 2)));
            wordReplaces.Add(new WordReplace("61", DoubleToString(statistics.PovregdSecondCherga)));
            wordReplaces.Add(new WordReplace("62", DoubleToString(statistics.PovregdSecondChergaPercent, 2)));
            wordReplaces.Add(new WordReplace("63", DoubleToString(statistics.Umin)));
            wordReplaces.Add(new WordReplace("64", DoubleToString(statistics.Umax)));
            wordReplaces.Add(new WordReplace("65", DoubleToString(statistics.HlubMin, 2)));
            wordReplaces.Add(new WordReplace("66", DoubleToString(statistics.HlybMax, 2)));
            wordReplaces.Add(new WordReplace("67", DoubleToString(statistics.ForestsAll)));
            wordReplaces.Add(new WordReplace("68", DoubleToString(statistics.ForestsAllPrecent, 2)));
            wordReplaces.Add(new WordReplace("69", DoubleToString(statistics.ForestsToClear)));
            wordReplaces.Add(new WordReplace("70", DoubleToString(statistics.ForestsToClearPrecent, 2)));
            wordReplaces.Add(new WordReplace("71", statistics.PvCount.ToString()));
            wordReplaces.Add(new WordReplace("72", statistics.NenormHlubynas.Count == 0 ? "не має" : "має"));
            string shurves = "";
            foreach (Shurf shurf in statistics.Shurves)
            {
                shurves += $"км {DoubleToString(shurf.Km)} (акт № {shurf.AktNumber}), ";
            }
            wordReplaces.Add(new WordReplace("73", shurves));

            return wordReplaces;
        }
        private string FromUpper(string word)
        {
            if (string.IsNullOrEmpty(word)) return word;
            return Char.ToUpper(word[0]) + word.Substring(1);
        }
        private string DoubleToString(double? value, int round = 3)
        {
            if (value == null) return "";
            return Math.Round((double)value, round).ToString("0.0##").Replace(".", ",");
        }
    }
}
