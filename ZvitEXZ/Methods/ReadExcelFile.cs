using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;


namespace ZvitEXZ.Methods
{
    internal class ReadExcelFile
    {
        public List<object[]> ReadFile(string path)
        {
            int colCount = 307;
            List<object[]> res = new List<object[]>();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application excelApp = new Excel.Application();
            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open(path, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[4];//получить 2 лист
                object[,] dictData = (object[,])worksheet2.Range["C2:E36"].Value;
                object[] dictRes = new object[37];
                dictRes[0] = dictData[1, 3];
                dictRes[36] = Path.GetFileNameWithoutExtension(path); //имя исходного файла
                for (int i = 1; i < 36; i++)
                {
                    dictRes[i] = dictData[i, 1];
                }
                res.Add(dictRes);

                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];//получить 1 лист
                int iLastRow = worksheet.Cells[worksheet.Rows.Count, "B"].End[Excel.XlDirection.xlUp].Row;  //последняя заполненная строка в столбце B
                var arrData = (object[,])worksheet.Range["A3:KU" + iLastRow].Value;  //массив значений с листа excellfor (int i = 0; i < iLastRow - 2; i++)
                for (int i = 0; i < iLastRow - 2; i++)
                {
                    object[] rowRes = new object[colCount];
                    for (int j = 0; j < colCount; j++)
                    {
                        rowRes[j] = arrData[i + 1, j + 1];
                    }
                    res.Add(rowRes);
                }
                workbook.Close(false);
            }
            catch (Exception ex)
            {
                Logs.AddError(ex.Message);
            }
            finally
            {
                excelApp.Quit();
            }
            return res;
        }
        public void WriteFile(string sourceFileName, string ShablonFileName, List<object[]> data)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            Excel.Application excelApp = new Excel.Application();
            excelApp.AutomationSecurity = Microsoft.Office.Core.MsoAutomationSecurity.msoAutomationSecurityForceDisable;
            excelApp.Visible = true;

            try
            {
                Excel.Workbook workbook = excelApp.Workbooks.Open(ShablonFileName, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                Excel.Worksheet worksheet2 = (Excel.Worksheet)workbook.Sheets[4];//получить 2 лист
                object[] dictData = data[0];
                for (int i = 1; i < 36; i++)
                {
                    worksheet2.Cells[i + 1, 3] = dictData[i];
                }
                data.RemoveAt(0);
                int rowcount = data.Count;
                int colCount = data[0].Length;
                object[,] arrData = new object[rowcount, colCount];
                for (int i = 0; i < rowcount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        arrData[i, j] = data[i][j];
                    }
                }
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];//получить 1 лист
                string range = $"A3:KU{data.Count + 2}";
                worksheet.Range[range].Value = arrData;
                string s = Path.GetDirectoryName(sourceFileName) + "\\" + Path.GetFileNameWithoutExtension(sourceFileName) + "_Converted" + Path.GetExtension(sourceFileName);
                workbook.SaveAs(s, Excel.XlFileFormat.xlExcel12);
                Logs.AddLog("Файл конвертирован");
            }
            catch (Exception ex)
            {
                Logs.AddError(ex.Message);
            }
            finally
            {
                excelApp.Quit();
            }
        }
    }
}
