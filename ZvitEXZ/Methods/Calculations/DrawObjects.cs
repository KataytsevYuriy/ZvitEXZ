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
    public class DrawObjects
    {
        public void AddObjects(ref AcadDoc acadDoc, List<Zamer> zamers, CalculateCoordinateX X, double kmStart, double kmEnd, double kmPerDrawing, List<PovitrPerehod> povitrPerehods)
        {
            double thisPipeScale = (kmEnd - kmStart) * AcadConstants.LenthXByDoc / kmPerDrawing;
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerText));
            //acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ThisPipe, AcadConstants.DocStartX, AcadConstants.PipeStartY, thisPipeScale));
            AddPipeLineWithPovPerehods(ref acadDoc, X, kmStart, kmEnd, povitrPerehods);
            int kmposition = 0;
            int signatureposition = 0;
            foreach (Zamer zamer in zamers)
            {
                string zamerType = zamer.GetCadType();
                if (!string.IsNullOrEmpty(zamerType))
                {
                    acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(zamer.Km), AcadConstants.PipeStartY));
                    acadDoc.DrawingSteps.Add(new DrawingText(ConvertToString.DoubleToString(zamer.Km), X.Calkulate(zamer.Km),
                        AcadConstants.KmobjectsStartY + kmposition * AcadConstants.KmobjectsStepY, 2));
                    if(!string.IsNullOrEmpty(zamer.GetCadSignature()))
                     acadDoc.DrawingSteps.Add(new DrawingText(zamer.GetCadSignature(), X.Calkulate(zamer.Km),
                        AcadConstants.SignatureObjectsStartY + signatureposition * AcadConstants.SignatureObjectsStepY, 2));
                    if (kmposition == 2) { kmposition = 0; }
                    else { kmposition++; }
                    if (signatureposition == 5) { signatureposition = 0; }
                    else { signatureposition++; }
                }
                if (zamer.Name == ProjectConstants.RiverName)
                {
                    River river = zamer as River;
                    double sdvig = 1;
                    while (sdvig * AcadConstants.RepeatObjectsEvery < (double)river.Length / 1000)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(river.Km + sdvig * AcadConstants.RepeatObjectsEvery), AcadConstants.PipeStartY));
                        sdvig++;
                    }
                    acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(river.Km + (double)river.Length / 1000), AcadConstants.PipeStartY));
                }
                if (zamer.Name == ProjectConstants.SwampName)
                {
                    Swamp swamp = zamer as Swamp;
                    double sdvig = 1;
                    while (sdvig * AcadConstants.RepeatObjectsEvery < (double)swamp.Length / 1000)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(swamp.Km + sdvig * AcadConstants.RepeatObjectsEvery), AcadConstants.PipeStartY));
                        sdvig++;
                    }
                    //acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(swamp.Km + (double)swamp.Length / 1000), AcadConstants.PipeStartY));
                }
                if (zamer.Name == ProjectConstants.ZaroslyName)
                {
                    Zarosly zarosly = zamer as Zarosly;
                    double sdvig = 1;
                    while (sdvig * AcadConstants.RepeatObjectsEvery < (double)zarosly.Length / 1000)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(zarosly.Km + sdvig * AcadConstants.RepeatObjectsEvery), AcadConstants.PipeStartY));
                        sdvig++;
                    }
                    //acadDoc.DrawingSteps.Add(new DrawBlock(zamerType, X.Calkulate(swamp.Km + (double)swamp.Length / 1000), AcadConstants.PipeStartY));
                }
                else if (zamer.Name == ProjectConstants.RoadName)
                {
                    Road road = zamer as Road;
                    if (road.HasKozhuh)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.Objkozhuh, X.Calkulate(road.Km), AcadConstants.PipeStartY));
                    }
                }
                else if (zamer.Name == ProjectConstants.VyhodIsZemlyName)
                {
                    VyhodIsZemly vyhodIsZemly = zamer as VyhodIsZemly;
                    if (vyhodIsZemly.PerehodType == PerehodTypes.finish && zamers.First().Km == zamer.Km)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ObjVhodVZemlyu, X.Calkulate(vyhodIsZemly.Km), AcadConstants.PipeStartY));
                    }
                    else if (vyhodIsZemly.PerehodType == PerehodTypes.start && zamers.Last().Km == zamer.Km)
                    {
                        acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ObjVyhodIzZemly, X.Calkulate(vyhodIsZemly.Km), AcadConstants.PipeStartY));
                    }
                }

            }
        }
        private void AddPipeLineWithPovPerehods(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, List<PovitrPerehod> povitrPerehods)
        {
            double start = kmStart;
            foreach (PovitrPerehod perehod in povitrPerehods)
            {
                double perehodStart = (double)perehod.KmStart / 1000;
                double perehodFinish = (double)perehod.KmFinish / 1000;
                if (perehodFinish < kmStart) continue;
                if (perehodStart > kmEnd) break;
                if (kmStart <= perehodStart)
                {
                    DrawPipeLine(ref acadDoc, X, start, perehodStart);
                    acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ObjPovitrPereh, X.Calkulate(perehodStart), AcadConstants.PipeStartY));
                    start = perehodStart;
                }
                if (perehodFinish <= kmEnd)
                {
                    DrawPipeLine(ref acadDoc, X, start, perehodFinish, AcadConstants.ObjPovPerehHeight);
                    acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ObjPovitrPereh, X.Calkulate(perehodFinish), AcadConstants.PipeStartY));
                    start = perehodFinish;
                }
                else
                {
                    DrawPipeLine(ref acadDoc, X, start, kmEnd, AcadConstants.ObjPovPerehHeight);
                    start = kmEnd;
                }
            }
            if (start < kmEnd)
            {
                DrawPipeLine(ref acadDoc, X, start, kmEnd);
            }
        }
        private void DrawPipeLine(ref AcadDoc acadDoc, CalculateCoordinateX X, double kmStart, double kmEnd, double yToUp = 0)
        {
            double thisPipeScale = X.Calkulate(kmEnd) - X.Calkulate(kmStart);
            if (thisPipeScale > 0)
            {
                acadDoc.DrawingSteps.Add(new DrawBlock(AcadConstants.ThisPipe, X.Calkulate(kmStart), AcadConstants.PipeStartY + yToUp, thisPipeScale));
            }
        }
    }
}