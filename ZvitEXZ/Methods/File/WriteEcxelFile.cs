using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using ZvitEXZ.Models;
using Microsoft.Office.Interop.Excel;

namespace ZvitEXZ.Methods
{
    public class WriteEcxelFile
    {
        public void WriteFile(string folder, string newFileName, string objectName, object[,] data, string rangeName,
            string rangeData, string rangeDataEmpty, string rangeToPrint, string ifDataEmpty, int sheetNumber, double bal, string rangeBal)
        {
            string path = Directory.GetCurrentDirectory();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application excelApp = new Excel.Application();
            string fileName = "";
            if (System.IO.File.Exists($"{path}\\{ProjectConstants.ShablonFileName}"))
            {
                fileName = ProjectConstants.ShablonFileName;
            }
            else
            {
                fileName = ProjectConstants.ShablonFileName2;
            }
            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open($"{path}\\{fileName}", Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetNumber];//получить N sheetNumber лист

               // string cell = worksheet.Cells[11, 15].Value.ToString();
               // Excel.Range rng = (Excel.Range)worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[3, 3]);
                var s = worksheet.Cells[6, 1];
                var e = worksheet.Cells[7, 6];
                var arrData = (object[,])worksheet.Range[s,e].Value;

                excelApp.DisplayAlerts = false;
                worksheet.Range[rangeName].Merge();
                excelApp.DisplayAlerts = true;
                worksheet.Range[rangeName].Value = objectName;
                worksheet.Range[rangeName].Font.Bold = true;
                worksheet.Range[rangeName].Font.Name = "Times New Roman";
                worksheet.Range[rangeName].Font.Size = 12;
                worksheet.Range[rangeName].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                excelApp.DisplayAlerts = false;
                worksheet.Range[rangeName].Borders.Weight = 2d;
                if (data.Length == 0)
                {
                    worksheet.Range[rangeDataEmpty].Value = ifDataEmpty;
                    excelApp.DisplayAlerts = false;
                    worksheet.Range[rangeDataEmpty].Merge();
                    worksheet.Range[rangeData].Font.Name = "Times New Roman";
                    worksheet.Range[rangeDataEmpty].Borders.Weight = 2d;
                    worksheet.Range[rangeDataEmpty].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                }
                else
                {
                    worksheet.Range[rangeData].Value = data;
                    worksheet.Range[rangeData].Font.Size = 12;
                    worksheet.Range[rangeData].Font.Name = "Times New Roman";
                    worksheet.Range[rangeData].Borders.Weight = 2d;
                    worksheet.Range[rangeData].WrapText = true;
                    worksheet.Range[rangeData].VerticalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range[rangeData].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                }
                if (bal > -0.5)
                {
                    excelApp.DisplayAlerts = false;
                    worksheet.Range[rangeBal].Merge();
                    //excelApp.DisplayAlerts = true;
                    worksheet.Range[rangeBal].Value = bal == 0 ? "-" :  bal.ToString();
                    worksheet.Range[rangeBal].Font.Bold = false;
                    worksheet.Range[rangeBal].Font.Name = "Times New Roman";
                    worksheet.Range[rangeBal].Font.Size = 12;
                    worksheet.Range[rangeBal].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    worksheet.Range[rangeBal].Borders.Weight = 2d;
                }
                worksheet.PageSetup.PrintArea = rangeToPrint;
                CreateFolder createFolder = new CreateFolder();
                createFolder.Create($"{path}\\{folder}");
                Excel.Workbook newWorkbook = excelApp.Workbooks.Add(1);
                Excel.Worksheet workSheet1 = (Excel.Worksheet)newWorkbook.Sheets[1];
                worksheet.Copy(workSheet1);
                workbook.Close(false);
                try
                {
                    newWorkbook.SaveAs($"{path}\\{folder}\\{newFileName}", Excel.XlFileFormat.xlExcel12);
                }
                catch
                {
                    Logs.AddAlarm($"не удалось сохранить файл \"{newFileName}\" снимите защиту от записи");
                }
            }
            finally
            {
                excelApp.Quit();
            }
        }
    }
}
