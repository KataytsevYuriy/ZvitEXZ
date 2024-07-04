using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;
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
        public GetAcadDrawing(ExcelDictionary excelDictionary, List<Zamer> Zamers)
        {
            this.Zamers = Zamers;
            this.excelDictionary = excelDictionary;
            pipeName = $"{Char.ToUpper(excelDictionary.Type[0])}{excelDictionary.Type.Substring(1)} {excelDictionary.Name}";
            AcadDrawing = new AcadDrawing($"{AcadConstants.AcadPrefixFileName}_{excelDictionary.SourceFileName}", pipeName,
                excelDictionary.SourceFileName, excelDictionary.SourceFileName, excelDictionary.Shyfr);
            sourceFileName = excelDictionary.SourceFileName;
        }
        public AcadDrawing Calculate(double kmstart, double kmPerDrawing = 3, bool drawAllDocs = true)
        {
            double kmStart = Math.Round(kmstart, 3);
            this.lenthByKm = AcadConstants.LenthByDoc / kmPerDrawing;
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
                if (i + 1 < docCount) acadDoc.NextSheet = (i + 2).ToString();
                AddUtz(ref acadDoc, kmPerDrawing);

                AcadDrawing.Docs.Add(acadDoc);
            }
            return AcadDrawing;
        }
        private void AddUtz(ref AcadDoc acadDoc, double kmPerDrawing)
        {
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerUtz));
            double kmstart = acadDoc.KmStart;
            double kmend = acadDoc.KmEnd;
            List<Zamer> docZamers = Zamers.Where(el => el.Km >= kmstart && el.Km <= kmend).ToList();
            double lastKm = -1;
            DrawPline pline = new DrawPline();
            foreach (Zamer zamer in docZamers)
            {
                if (zamer.Utz == null) continue;
                if (lastKm == -1)
                {
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmstart) * lenthByKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    lastKm = zamer.Km;
                }
                else if (zamer.Km - lastKm > AcadConstants.AcadMaxDrawingStep)
                {
                    if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
                    pline = new DrawPline();
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmstart) * lenthByKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    lastKm = zamer.Km;
                }
                else
                {
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmstart) * lenthByKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    lastKm = zamer.Km;
                }
            }
            if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
        }
    }
}
