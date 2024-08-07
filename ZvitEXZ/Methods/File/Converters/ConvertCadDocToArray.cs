﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.AcadModels;

namespace ZvitEXZ.Methods.File.Converters
{
    internal class ConvertCadDocToArray
    {
        public List<object[,]> Convert(AcadDrawing acadDrawing)
        {
            List<object[,]> res = new List<object[,]>();
            foreach (AcadDoc acadDoc in acadDrawing.Docs)
            {
                res.Add(ConvertDoc(acadDoc));
            }
            return res;
        }
        private object[,] ConvertDoc(AcadDoc doc)
        {
            int cellCount = doc.CellsCount;
            if (cellCount < 10) cellCount = 10;
            int rowCount = doc.DrawingSteps.Count + 1;
            object[,] res = new object[rowCount, cellCount];
            int i = 1;
            res[0, 0] = doc.FileName;
            res[0, 1] = doc.FolderName;
            res[0, 2] = doc.NextSheet;
            foreach (DrawingStep step in doc.DrawingSteps)
            {
                res[i, 0] = step.Name;
                switch (step.Name)
                {
                    case AcadConstants.DrawingBlockName:
                        DrawBlock block = step as DrawBlock;
                        res[i, 1] = block.BlockName;
                        res[i, 2] = block.X;
                        res[i, 3] = block.Y;
                        res[i, 4] = block.XScale;
                        break;
                    case AcadConstants.DrawingLayerName:
                        DrawLayer layer = step as DrawLayer;
                        res[i, 1] = layer.LayerName;
                        break;
                    case AcadConstants.DrawingTextName:
                        DrawingText text = step as DrawingText;
                        res[i, 1] = text.Text;
                        res[i, 2] = text.X;
                        res[i, 3] = text.Y;
                        res[i, 4] = text.Size;
                        res[i, 5] = text.Alignment;
                        break;
                    case AcadConstants.DrawingPlineName:
                        DrawPline pline = step as DrawPline;
                        res[i, 1] = pline.Values.Count;
                        for (int j = 0; j < pline.Values.Count; j++)
                        {
                            res[i, j + 2] = pline.Values[j];
                        }
                        break;
                    default: break;
                }
                i++;
            }
            return res;
        }
    }
}
