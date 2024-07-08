using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models.Calculations;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ.Methods.Calculations
{
    internal class GetAcadDrawing
    {
        List<Zamer> Zamers;
        ExcelDictionary excelDictionary;
        double lenthByKm;
        AcadDrawing AcadDrawing;
        string pipeName;
        string sourceFileName;
        CalculationYSettings UtzSettings;
        List<PovitrPerehod> PovitrPerehods;
        List<HruntAktivity> hruntAktivities;
        public GetAcadDrawing(ExcelDictionary excelDictionary, List<Zamer> Zamers, List<PovitrPerehod> povitrPerehods, List<HruntAktivity> hruntAktivities)
        {
            this.Zamers = Zamers;
            this.excelDictionary = excelDictionary;
            pipeName = $"{Char.ToUpper(excelDictionary.Type[0])}{excelDictionary.Type.Substring(1)} {excelDictionary.Name}";
            AcadDrawing = new AcadDrawing($"{AcadConstants.AcadPrefixFileName}_{excelDictionary.SourceFileName}", pipeName,
                excelDictionary.SourceFileName, excelDictionary.SourceFileName, excelDictionary.Shyfr);
            sourceFileName = excelDictionary.SourceFileName;
            UtzSettings = new CalculationYSettings(AcadConstants.UtzMin, AcadConstants.UtzMax, AcadConstants.UtzMinY, AcadConstants.UtzMaxY, AcadConstants.ShkalaUtzStep);
            PovitrPerehods = povitrPerehods;
            this.hruntAktivities = hruntAktivities;
        }
        public AcadDrawing Calculate(double kmstart, double kmPerDrawing = 3, bool drawAllDocs = true)
        {
            DrawPotencial potencailDrawer = new DrawPotencial();
            double kmStart = Math.Round(kmstart, 3);
            this.lenthByKm = AcadConstants.LenthXByDoc / kmPerDrawing;
            double fullKm = Zamers.Last().Km;
            int docCount = (int)((fullKm - kmstart) / kmPerDrawing);
            if (((fullKm - kmstart) % kmPerDrawing) > 0) docCount++;
            for (int i = 0; i < docCount; i++)
            {
                double start = kmstart + i * kmPerDrawing;
                double end = start + kmPerDrawing;
                if (fullKm < end) end = fullKm;
                AcadDoc acadDoc = new AcadDoc(AcadDrawing.PipeName, $"{sourceFileName}_{start}-{end}".Replace(".", ","), AcadDrawing.FolderName,
                    AcadDrawing.Shifr, start, end, i + 1);
                CalculateCoordinateX X = new CalculateCoordinateX(start, kmPerDrawing);
                if (i + 1 < docCount) acadDoc.NextSheet = (i + 2).ToString();
                List<Zamer> docZamers = Zamers.Where(el => el.Km >= start && el.Km <= end).ToList();
                List<AcadZamer> acadZamers = docZamers.Select(el => new AcadZamer(el.Km, el.Utz)).ToList();
                CalculateCoordinateY Y = new CalculateCoordinateY(UtzSettings);
                potencailDrawer.AddPotencial(ref acadDoc, acadZamers, AcadConstants.LayerUtz, X, Y);        // Draw Utz
                potencailDrawer.AddUtzShkala(ref acadDoc, UtzSettings);
                potencailDrawer.AddLineMinZah(ref acadDoc, Y);
                acadZamers = docZamers.Select(el => new AcadZamer(el.Km, el.Upol)).ToList();
                potencailDrawer.AddPotencial(ref acadDoc, acadZamers, AcadConstants.LayerUpol, X, Y);       // Draw Upol
                DrawObjects drawObjects = new DrawObjects();
                drawObjects.AddObjects(ref acadDoc, docZamers, X, start, end, kmPerDrawing, PovitrPerehods);                //Draw pipe objects
                DrawHruntActivities drawHruntActivities = new DrawHruntActivities();
                drawHruntActivities.AddHruntActivities(ref acadDoc, X, start, end, hruntAktivities);
                AcadDrawing.Docs.Add(acadDoc);
            }
            return AcadDrawing;
        }
    }
}
