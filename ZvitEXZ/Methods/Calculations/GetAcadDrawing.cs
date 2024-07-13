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
        CalculationYSettings UgradSettings;
        CalculationYSettings HlubynasSettings;
        CalculationYSettings RhrSettings;
        List<PovitrPerehod> PovitrPerehods;
        List<HruntAktivity> hruntAktivities;
        List<Povregdenya> povregdenyas;
        List<Nezahyst> nezahysts;
        List<KorNebezpechny> korNebezpechnies;
        List<Hlubyna> hlubynas;
        List<NeObstegeno> neObstegenos;
        public GetAcadDrawing(ExcelDictionary excelDictionary, List<Zamer> Zamers, List<PovitrPerehod> povitrPerehods, List<HruntAktivity> hruntAktivities,
            List<Povregdenya> povregdenyas, List<Nezahyst> nezahysts, List<KorNebezpechny> korNebezpechnies, List<Hlubyna> hlubynas, List<NeObstegeno> neObstegenos)
        {
            this.Zamers = Zamers;
            this.excelDictionary = excelDictionary;
            pipeName = $"{Char.ToUpper(excelDictionary.Type[0])}{excelDictionary.Type.Substring(1)} {excelDictionary.Name}";
            AcadDrawing = new AcadDrawing($"{AcadConstants.AcadPrefixFileName}_{excelDictionary.SourceFileName}", pipeName,
                excelDictionary.SourceFileName, excelDictionary.SourceFileName, excelDictionary.Shyfr);
            sourceFileName = excelDictionary.SourceFileName;
            UtzSettings = new CalculationYSettings(AcadConstants.UtzMin, AcadConstants.UtzMax, AcadConstants.UtzMinY, AcadConstants.UtzMaxY, AcadConstants.ShkalaUtzStep);
            UgradSettings = new CalculationYSettings(AcadConstants.UgradMin, AcadConstants.UgradMax, AcadConstants.UgradMinY, AcadConstants.UgradMaxY, AcadConstants.ShkalaUgradStep);
            HlubynasSettings = new CalculationYSettings(AcadConstants.HlubMin, AcadConstants.HlubMax, AcadConstants.HlubMinY, AcadConstants.HlubMaxY, AcadConstants.ShkalaHlubynaStep);
            RhrSettings = new CalculationYSettings(AcadConstants.RhrMin, AcadConstants.RhrMax, AcadConstants.RhrMinY, AcadConstants.RhrMaxY, AcadConstants.ShkalaRhruntaStep);
            PovitrPerehods = povitrPerehods;
            this.hruntAktivities = hruntAktivities;
            this.povregdenyas = povregdenyas;
            this.nezahysts = nezahysts;
            this.korNebezpechnies = korNebezpechnies;
            this.hlubynas = hlubynas;
            this.neObstegenos = neObstegenos;
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
                List<AcadZamer> acadZamers = docZamers.Select(el => new AcadZamer(el.Km, el.Utz == null ? null : -el.Utz)).ToList();
                CalculateCoordinateY Y = new CalculateCoordinateY(UtzSettings);
                potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerUtz);
                potencailDrawer.AddPotencial(ref acadDoc, acadZamers, X, Y);        // Draw Utz
                potencailDrawer.AddShkala(ref acadDoc, UtzSettings);
                potencailDrawer.AddLineMinZah(ref acadDoc, Y);
                acadZamers = docZamers.Select(el => new AcadZamer(el.Km, el.Upol == null ? null : -el.Upol)).ToList();
                potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerUpol);
                potencailDrawer.AddPotencial(ref acadDoc, acadZamers, X, Y);       // Draw Upol
                acadZamers = docZamers.Select(el => new AcadZamer(el.Km, el.Ugrad == null ? null : el.Ugrad * 1000)).ToList();                //Draw gradient
                TrimGradient trimGradient = new TrimGradient();
                acadZamers = trimGradient.Trim(acadZamers, out List<AcadZamer> trimmed);
                Y = new CalculateCoordinateY(UgradSettings);
                potencailDrawer.SelectLayer(ref acadDoc, AcadConstants.LayerGrad);
                potencailDrawer.AddPotencial(ref acadDoc, acadZamers,  X, Y);
                potencailDrawer.AddShkala(ref acadDoc, UgradSettings);
                foreach (AcadZamer acadZamer in trimmed)
                {
                    acadDoc.DrawingSteps.Add(new DrawingText(Math.Round((double)acadZamer.Value).ToString(), X.Calkulate(acadZamer.Km), AcadConstants.UgradTrimmedY, 2.2));
                }
                DrawObjects drawObjects = new DrawObjects();
                drawObjects.AddObjects(ref acadDoc, docZamers, X, start, end, kmPerDrawing, PovitrPerehods);                //Draw pipe objects
                DrawHruntActivities drawHruntActivities = new DrawHruntActivities();                                    //Draw Hrunts
                drawHruntActivities.AddHruntActivities(ref acadDoc, X, start, end, hruntAktivities);
                Y = new CalculateCoordinateY(RhrSettings);
                drawHruntActivities.DrawGraph(ref acadDoc, potencailDrawer, RhrSettings, docZamers, start, end, X, Y, neObstegenos);
                DrawPovregdenya drawPovregdenya = new DrawPovregdenya();
                drawPovregdenya.AddPovregdenyas(ref acadDoc, X, start, end, povregdenyas);
                DrawNezahyst drawNezahyst = new DrawNezahyst();
                drawNezahyst.AddNezah(ref acadDoc, X, start, end, nezahysts);
                Drawkorneb drawkorneb = new Drawkorneb();
                drawkorneb.AddKorneb(ref acadDoc, X, start, end, korNebezpechnies);
                Y = new CalculateCoordinateY(HlubynasSettings);                                          //Draw hlubynas
                DrawHlubynas drawHlubynas = new DrawHlubynas();
                drawHlubynas.AddHlubynas(ref acadDoc, potencailDrawer, HlubynasSettings, hlubynas, start, end, X, Y, neObstegenos);




                AcadDrawing.Docs.Add(acadDoc);
            }
            return AcadDrawing;
        }
    }
}
