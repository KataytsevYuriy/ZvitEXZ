using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.Objects;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;

namespace ZvitEXZ.Methods.File
{
    public class SaveToFiles
    {
        private string _fileName;
        private string _pipeName;
        private ConvertListToFile converter;
        public SaveToFiles(string sourceFileName, string pipeName)
        {
            _fileName = sourceFileName; _pipeName = pipeName;
            converter = new ConvertListToFile();
        }
        public void SavePV(List<Zamer> zamers)
        {
            WriteToFile writeToFile = new WriteToFile();
            writeToFile.WriteFile(_fileName, Constants.PVFolderName, _pipeName, converter.ConvertPV(zamers),
                "B", "L", "L", Constants.PrintMessagePZIsEmpty, 1);
        }
        public void SaveKornebezpechny(List<KorNebezpechny> korNebezpechnies)
        {
            WriteToFile writeToFile = new WriteToFile();
            writeToFile.WriteFile(_fileName, Constants.KornebFolderName, _pipeName, converter.ConvertKorneb(korNebezpechnies),
                "C", "F", "F", Constants.PrintMessageKornebIsEmpty, 3);
        }
        public void SaveNezahyst(List<Nezahyst> nezahysts)
        {
            WriteToFile writeToFile = new WriteToFile();
            writeToFile.WriteFile(_fileName, Constants.NezahFolderName, _pipeName, converter.ConvertNezah(nezahysts),
                "B", "I", "I", Constants.PrintMessageNezahIsEmpty, 2);
        }
    }
}
