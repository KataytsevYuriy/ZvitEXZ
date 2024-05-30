using System.Collections.Generic;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.File
{
    public class SaveToFiles
    {
        private string _fileName;
        private string _pipeName;
        private ConvertListToFile converter;
        WriteToFile writeToFile;
        public SaveToFiles(string sourceFileName, string pipeName)
        {
            _fileName = sourceFileName; _pipeName = pipeName;
            converter = new ConvertListToFile();
            writeToFile = new WriteToFile();
        }
        public void SavePV(List<Zamer> zamers)
        {
            writeToFile.WriteFile(_fileName, Constants.PVFolderName, _pipeName, converter.ConvertPV(zamers),
                "B", "L", "L", Constants.PrintMessagePZIsEmpty, 1);
        }
        public void SaveKornebezpechny(List<KorNebezpechny> korNebezpechnies)
        {
            writeToFile.WriteFile(_fileName, Constants.KornebFolderName, _pipeName, converter.ConvertKorneb(korNebezpechnies),
                "C", "F", "F", Constants.PrintMessageKornebIsEmpty, 3);
        }
        public void SaveNezahyst(List<Nezahyst> nezahysts)
        {
            writeToFile.WriteFile(_fileName, Constants.NezahFolderName, _pipeName, converter.ConvertNezah(nezahysts),
                "B", "I", "I", Constants.PrintMessageNezahIsEmpty, 2);
        }
        public void SaveZvedena(string[,] data)
        {
            writeToFile.WriteFile(_fileName, Constants.ZvedenaFolderName, _pipeName, data,
                "A", "L", "L", Constants.PrintMessageNezahIsEmpty, 4);
        }
        public void SaveUKZ(List<Zamer> data)
        {
            writeToFile.WriteFile(_fileName, Constants.UkzFolderName, _pipeName, converter.ConvertUKZ(data),
                "A", "Y", "Y", Constants.PrintMessageNezahIsEmpty, 5);
        }
        public void SavePovregd(List<Povregdenya> povregdenya)
        {
            writeToFile.WriteFile(_fileName, Constants.PovregdFolderName, _pipeName, converter.ConvertPovregd(povregdenya),
               "A", "J", "J", Constants.PrintMessageNezahIsEmpty, 6);
        }
        public void SaveUPZ(List<UPZ> uPZs)
        {
            writeToFile.WriteFile(_fileName, Constants.UpzFolderName, _pipeName, converter.ConvertUpz(uPZs),
               "A", "R", "R", Constants.PrintMessageUpzdIsEmpty, 7);
        }
        public void SaveVymirKozhuh(List<RoadKozhuh> roadKozhuhs)
        {
            writeToFile.WriteFile(_fileName, Constants.PerehodFolderName, _pipeName,
                converter.ConvertVymirKozhuh(roadKozhuhs), "A", "L", "L",
                Constants.PrintMessagePerehodKozhuhIsEmpty, 8, Constants.PerehodKozhuhFileName);
        }
        public void SaveStanNaPerehode(List<RoadKozhuh> roadKozhuhs)
        {
            writeToFile.WriteFile(_fileName, Constants.PerehodFolderName, _pipeName,
                converter.ConvertStanNaPerehode(roadKozhuhs), "A", "K", "K",
                Constants.PrintMessageStanPerehoduIsEmpty, 9, Constants.PerehodStanFileName);
        }
        public void SaveFlantsy(List<Flanets> flantsy)
        {
            writeToFile.WriteFile(_fileName, Constants.FlanetsFolderName, _pipeName,
                converter.ConvertFlantsy(flantsy), "A", "M", "M",
                Constants.PrintMessageFlanetsIsEmpty, 10);
        }
        public void SavePovitrPerehody(List<PovitrPerehod> perehods)
        {
            writeToFile.WriteFile(_fileName, Constants.PovitrPerehodFolderName, _pipeName,
                converter.ConvertPovitrPerehody(perehods), "A", "K", "K",
                Constants.PrintMessagePovitrPerehIsEmpty, 11);
        }
        public void SaveShurves(List<Shurf> shurves)
        {
            writeToFile.WriteFile(_fileName, Constants.ShurfFolderName, _pipeName,
                converter.ConvertShurfy(shurves), "A", "AX", "AX",
                Constants.PrintMessageShurfIsEmpty, 12);
        }

    }
}
