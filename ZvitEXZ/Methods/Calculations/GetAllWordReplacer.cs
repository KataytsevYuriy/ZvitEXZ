using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Calculations;

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


            return wordReplaces;
        }
        private string FromUpper(string word)
        {
            return Char.ToUpper(word[0]) + word.Substring(1);
        }
        private string DoubleToString(double? value, int round = 3)
        {
            if (value == null) return "";
            return Math.Round((double)value, round).ToString().Replace(".", ",");
        }
    }
}
