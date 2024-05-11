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
            int colCount = 306;
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
    }
}
