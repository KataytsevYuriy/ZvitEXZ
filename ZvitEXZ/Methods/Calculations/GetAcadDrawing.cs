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
        List<Zamer> DocZamers;
        ExcelDictionary excelDictionary;
        double kmStart;
        string kmStartStr;
        double kmScale;
        double kmFinish;
        string kmFinishStr;
        AcadDrawing AcadDrawing;
        string pipeName;
        public GetAcadDrawing(ExcelDictionary excelDictionary, List<Zamer> Zamers)
        {
            this.Zamers = Zamers;
            this.excelDictionary = excelDictionary;
            AcadDrawing = new AcadDrawing();
            pipeName = $"{Char.ToUpper(excelDictionary.Type[0])}{excelDictionary.Type.Substring(1)} {excelDictionary.Name}";
        }
        public void Calculate(double kmstart, double kmscale)
        {
            this.kmStart = Math.Round(kmstart, 3);
            kmStartStr = kmstart.ToString().Replace(".", ",");
            this.kmScale = kmscale;
            kmFinish = Math.Round(kmstart + AcadConstants.AdocDefaultLenthKm * kmscale, 3);
            kmFinishStr = kmFinish.ToString().Replace(".", ",");
            DocZamers = Zamers.Where(z => z.Km >= kmstart && z.Km <= kmFinish).ToList();
            AcadDoc acadDoc = new AcadDoc(pipeName, $"{pipeName}_{kmStartStr}-{kmFinishStr}", pipeName, excelDictionary.Shyfr,
                $"км{ConvertToString.DoubleToString(kmstart)} - км {ConvertToString.DoubleToString(kmFinish)}");
            AddUtz(ref acadDoc);
        }
        private void AddUtz(ref AcadDoc acadDoc)
        {
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerUtz));
            double kmstart = -1;
            DrawPline pline = new DrawPline();
            foreach (Zamer zamer in Zamers)
            {
                if (zamer.Utz == null) continue;
                if (kmstart == -1)
                {
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmStart) * kmScale * AcadConstants.AdocDefaultLenthKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    kmstart = zamer.Km;
                }
                else if (zamer.Km - kmstart > AcadConstants.AcadMaxDrawingStep)
                {
                    if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
                    pline = new DrawPline();
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmStart) * kmScale * AcadConstants.AdocDefaultLenthKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    kmstart = zamer.Km;
                }
                else
                {
                    pline.Values.Add(AcadConstants.DocStartX + (zamer.Km - kmStart) * kmScale * AcadConstants.AdocDefaultLenthKm);
                    pline.Values.Add(AcadConstants.UtzMinY + (AcadConstants.UtzMaxY - AcadConstants.UtzMinY) / (AcadConstants.UtzMax - AcadConstants.UtzMin)
                        * ((double)zamer.Utz - AcadConstants.UtzMin));
                    pline.Values.Add(0);
                    kmstart = zamer.Km;
                }
            }
            if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
        }
    }
}
