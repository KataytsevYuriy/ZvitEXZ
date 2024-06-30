using Aspose.Cells;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using Excel = Microsoft.Office.Interop.Excel;

namespace ZvitEXZ.Methods.File
{
    internal class WriteCadProtocol
    {
        public void Write(string DestinationFileName, object[,] data)
        {
            int sheetNumber = 1;
            string path = Directory.GetCurrentDirectory();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application excelApp = new Excel.Application();
            string fileName = AcadConstants.ShablonProtokolFilename;
            if (!System.IO.File.Exists($"{path}\\{AcadConstants.ShablonProtokolFilename}"))
            {
                fileName = @"..\..\" + fileName;
            }
            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open($"{path}\\{fileName}", Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[sheetNumber];//получить N sheetNumber лист
                int rowCount = data.GetLength(0) + 1;
                int columnCount = data.GetLength(1);
                var celStart = worksheet.Cells[2, 1];
                var celEndt = worksheet.Cells[rowCount, columnCount];
                worksheet.Range[celStart, celEndt].Value = data;
                excelApp.DisplayAlerts = false;
                CreateFolder createFolder = new CreateFolder();
                createFolder.Create($"{path}\\{AcadConstants.AcadFolderName}");
                try
                {
                    workbook.SaveAs($"{path}\\{AcadConstants.AcadFolderName}\\{DestinationFileName}", Excel.XlFileFormat.xlOpenXMLWorkbookMacroEnabled);
                }
                catch
                {
                    Logs.AddAlarm($"не удалось сохранить файл \"{DestinationFileName}\" снимите защиту от записи");
                }
            }
            finally
            {
                excelApp.Quit();
            }
        }
    }
}
