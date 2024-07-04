using System.Collections.Generic;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
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
        public void SavePV(List<PV> zamers)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PVFolderName, _pipeName, converter.ConvertPV(zamers),
                "B", "L", "L", ProjectConstants.PrintMessagePZIsEmpty, 1);
        }
        public void SaveKornebezpechny(List<KorNebezpechny> korNebezpechnies)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.KornebFolderName, _pipeName, converter.ConvertKorneb(korNebezpechnies),
                "C", "F", "F", ProjectConstants.PrintMessageKornebIsEmpty, 3);
        }
        public void SaveNezahyst(List<Nezahyst> nezahysts)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.NezahFolderName, _pipeName, converter.ConvertNezah(nezahysts),
                "B", "I", "I", ProjectConstants.PrintMessageNezahIsEmpty, 2);
        }
        public void SaveZvedena(List<Zamer> zamers, List<KorNebezpechny> korNebezpechnies, List<Povregdenya> povregdenyas)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.ZvedenaFolderName, _pipeName, converter.ConvertZvedena(zamers, korNebezpechnies, povregdenyas),
                "A", "L", "L", ProjectConstants.PrintMessageNezahIsEmpty, 4);
        }
        public void SaveUKZ(List<Zamer> data)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.UkzFolderName, _pipeName, converter.ConvertUKZ(data),
                "A", "Y", "Y", ProjectConstants.PrintMessageNezahIsEmpty, 5);
        }
        public void SavePovregd(List<Povregdenya> povregdenya)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PovregdFolderName, _pipeName, converter.ConvertPovregd(povregdenya),
               "A", "J", "J", ProjectConstants.PrintMessageNezahIsEmpty, 6);
        }
        public void SaveUPZ(List<UPZ> uPZs)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.UpzFolderName, _pipeName, converter.ConvertUpz(uPZs),
               "A", "R", "R", ProjectConstants.PrintMessageUpzdIsEmpty, 7);
        }
        public void SaveVymirKozhuh(List<RoadKozhuh> roadKozhuhs)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PerehodFolderName, _pipeName,
                converter.ConvertVymirKozhuh(roadKozhuhs), "A", "L", "L",
                ProjectConstants.PrintMessagePerehodKozhuhIsEmpty, 8, ProjectConstants.PerehodKozhuhFileName);
        }
        public void SaveStanNaPerehode(List<RoadKozhuh> roadKozhuhs)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PerehodFolderName, _pipeName,
                converter.ConvertStanNaPerehode(roadKozhuhs), "A", "K", "K",
                ProjectConstants.PrintMessageStanPerehoduIsEmpty, 9, ProjectConstants.PerehodStanFileName);
        }
        public void SaveFlantsy(List<Flanets> flantsy)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.FlanetsFolderName, _pipeName,
                converter.ConvertFlantsy(flantsy), "A", "M", "M",
                ProjectConstants.PrintMessageFlanetsIsEmpty, 10);
        }
        public void SavePovitrPerehody(List<PovitrPerehod> perehods)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PovitrPerehodFolderName, _pipeName,
                converter.ConvertPovitrPerehody(perehods), "A", "K", "K",
                ProjectConstants.PrintMessagePovitrPerehIsEmpty, 11);
        }
        public void SaveShurves(List<Shurf> shurves)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.ShurfFolderName, _pipeName,
                converter.ConvertShurfy(shurves), "A", "AX", "AX",
                ProjectConstants.PrintMessageShurfIsEmpty, 12);
        }
        public void SaveNenormHlubynas(List<NenormHlubyna> nenormHlubynas)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.NenormHlubFolderName, _pipeName,
                converter.ConvertNenormHlubyna(nenormHlubynas), "A", "I", "I",
                ProjectConstants.PrintMessageNenormHlubIsEmpty, 13);
        }
        public void SaveStatistics(Statistics statistics)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.StatisticsFolderName, _pipeName, converter.ConvertStatistics(statistics), "B", "K", "K", "", 14);
        }
        public void SavePovregdGNT(List<PovregdenyaGNT> povregdenyaGNT, double bal)
        {
            writeToFile.WriteFile(_fileName, ProjectConstants.PovregdFolderName, _pipeName, converter.ConvertPovregdGNT(povregdenyaGNT),
                           "A", "E", "F", ProjectConstants.PrintMessageNezahIsEmpty, 15, ProjectConstants.PovregdGNTFolderName, bal);
        }
        public void SaveCadProtocol(AcadDrawing acadDrawing)
        {
            WriteCadProtocol writeCadProtocol = new WriteCadProtocol();
            writeCadProtocol.Write($"{AcadConstants.AcadPrefixFileName}_{acadDrawing.SourceFileName}", converter.ConvertProtokol(acadDrawing));
        }
    }
}
