using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models.AcadModels;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods.Calculations
{
    public class DrawPotencial
    {
        public void AddPotencial(ref AcadDoc acadDoc, List<AcadZamer> zamers, string layerName, CalculateCoordinateX X, CalculateCoordinateY Y)
        {
            acadDoc.DrawingSteps.Add(new DrawLayer(layerName));
            double lastKm = -1;
            DrawPline pline = new DrawPline();
            foreach (AcadZamer zamer in zamers)
            {
                if (zamer.Value == null) continue;
                if (lastKm != -1 && zamer.Km - lastKm > AcadConstants.AcadMaxDrawingStep)
                {
                    if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
                    pline = new DrawPline();
                }
                pline.Values.Add(X.Calkulate(zamer.Km));
                pline.Values.Add(Y.Calculate(zamer.Value));
                pline.Values.Add(0);
                lastKm = zamer.Km;
            }
            if (pline.Values.Count > 3) acadDoc.DrawingSteps.Add(pline);
        }
        public void AddShkala(ref AcadDoc acadDoc, CalculationYSettings YSettings, List<double> signatures = null)
        {
            double currentU = YSettings.UMin;
            CalculateCoordinateY Y = new CalculateCoordinateY(YSettings);
            while (Math.Abs(currentU) <= Math.Abs(YSettings.UMax))
            {
                string txt = Math.Round(currentU, 1).ToString().Replace(".", ",");
                double y = Y.Calculate(currentU);
                if (signatures == null)
                    acadDoc.DrawingSteps.Add(new DrawingText(txt, AcadConstants.DocStartX - AcadConstants.DigitMoveLeft, y, AcadConstants.DigitHeight));
                acadDoc.DrawingSteps.Add(new DrawPline(AcadConstants.DocStartX - AcadConstants.RyskaLenth, y, AcadConstants.DocStartX, y));
                currentU += YSettings.ShkalaStep;
            }
            if (signatures != null)
                foreach (double znak in signatures)
                {
                    string txt = Math.Round(znak).ToString();
                    acadDoc.DrawingSteps.Add(new DrawingText(txt, AcadConstants.DocStartX - AcadConstants.DigitMoveLeft, Y.Calculate(znak), AcadConstants.DigitHeight));
                }
        }
        public void AddLineMinZah(ref AcadDoc acadDoc, CalculateCoordinateY Y, string layerName = "Текст")
        {
            acadDoc.DrawingSteps.Add(new DrawLayer(layerName));
            double y09 = Y.Calculate(-0.9);
            acadDoc.DrawingSteps.Add(new DrawPline(AcadConstants.DocStartX, y09, AcadConstants.DocStartX + AcadConstants.LenthXByDoc, y09));
        }
    }
}
