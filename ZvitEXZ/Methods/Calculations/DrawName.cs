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
    internal class DrawName
    {
        public void AddNames(ref AcadDoc acadDoc, ExcelDictionary excelDictionary, double kmStart, double kmEnd)
        {
            acadDoc.DrawingSteps.Add(new DrawLayer(AcadConstants.LayerText));
            if (!string.IsNullOrEmpty(excelDictionary.Shyfr))
                acadDoc.DrawingSteps.Add(new DrawingText(excelDictionary.Shyfr, AcadConstants.NameShifrX, AcadConstants.NameShifrY, AcadConstants.NameTexySyze));

            if (!string.IsNullOrEmpty(excelDictionary.ShortType))
            {
                string namePipe = excelDictionary.ShortType[0].ToString().ToUpper() + excelDictionary.ShortType.Substring(1) + " " + excelDictionary.Name;
                acadDoc.DrawingSteps.Add(new DrawingText(namePipe, AcadConstants.NameShifrX, AcadConstants.NamePipeNameY, AcadConstants.NameTexySyze));
            }
            string km = $"км {ConvertToString.DoubleToString(kmStart, 3, true)} - км {ConvertToString.DoubleToString(kmEnd, 3, true)}";
            acadDoc.DrawingSteps.Add(new DrawingText(km, AcadConstants.NameShifrX, AcadConstants.NameKmY, AcadConstants.NameTexySyze));
            if (!string.IsNullOrEmpty(excelDictionary.PipesData))
                acadDoc.DrawingSteps.Add(new DrawingText(excelDictionary.PipesData, AcadConstants.NamePipesDataX, AcadConstants.NamePipesDataY, AcadConstants.NameTexySyze));
        }
    }
}
