﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using ZvitEXZ.Models;

namespace ZvitEXZ.Methods
{
    public class WriteEcxelFile
    {
        public void WriteFile(string folder, string newFileName, string objectName, string[,] data, string rangeName,
            string rangeData, string rangeDataEmpty, string rangeToPrint, string ifDataEmpty, int sheetNumber)
        {
            string path = Directory.GetCurrentDirectory();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application excelApp = new Excel.Application();
            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open($"{path}\\{Constants.ShablonFileName}", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetNumber];//получить N sheetNumber лист
                excelApp.DisplayAlerts = false;
                worksheet.Range[rangeName].Merge();
                excelApp.DisplayAlerts = true;
                worksheet.Range[rangeName].Value = objectName;
                worksheet.Range[rangeName].Font.Bold = true;
                worksheet.Range[rangeName].Font.Size = 12;
                excelApp.DisplayAlerts = false;
                worksheet.Range[rangeName].Borders.Weight = 2d;
                if (data.Length == 0)
                {
                    worksheet.Range[rangeDataEmpty].Value = ifDataEmpty;
                    excelApp.DisplayAlerts = false;
                    worksheet.Range[rangeDataEmpty].Merge();
                    worksheet.Range[rangeDataEmpty].Borders.Weight = 2d;
                }
                else
                {
                    worksheet.Range[rangeData].Value = data;
                    worksheet.Range[rangeData].Font.Size = 12;
                    worksheet.Range[rangeData].Borders.Weight = 2d;
                    worksheet.Range[rangeData].WrapText = true;
                    worksheet.Range[rangeData].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                worksheet.PageSetup.PrintArea = rangeToPrint;
                CreateFolder createFolder = new CreateFolder();
                createFolder.Create($"{path}\\{folder}");
                Excel.Workbook newWorkbook = excelApp.Workbooks.Add(1);
                Excel.Worksheet workSheet1 = (Excel.Worksheet)newWorkbook.Sheets[1];
                worksheet.Copy(workSheet1);
                workbook.Close(false);
                newWorkbook.SaveAs($"{path}\\{folder}\\{newFileName}", Excel.XlFileFormat.xlExcel12);
            }
            finally
            {
                excelApp.Quit();
            }
        }
    }
}