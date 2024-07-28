using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Calculations;
using Word = Microsoft.Office.Interop.Word;

namespace ZvitEXZ.Methods.File
{
    internal class WriteWordFile
    {
        public void Save(string newFileName, List<WordReplace> wordReplaces)
        {
            string path = Directory.GetCurrentDirectory();
            object o = Missing.Value;
            object oFalse = false;
            object oTrue = true;
            Application app = null;
            Documents docs = null;
            Document doc = null;
            string fileName = "";
            if (string.IsNullOrEmpty(ProjectConstants.DocShablonPath))
            {
                if (System.IO.File.Exists($"{path}\\{ProjectConstants.ShablonWordFileName}"))
                {
                    fileName = $"{path}\\{ProjectConstants.ShablonWordFileName}";
                }
                else
                {
                    fileName = $"{path}\\{ProjectConstants.ShablonWordFileName2}"; ;
                }
            }
            else
            {
                fileName = ProjectConstants.DocShablonPath;
            }
            try
            {
                app = new Application();
                app.Visible = true;
                app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                docs = app.Documents;
                doc = docs.Open(fileName, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o, ref o);
                doc.Activate();

                //                                      Найти и заполнить таблицу
                //try
                //{
                //    string markStart = $"[<]101 [>]";
                //    string markEnd = $"[<]102 [>]";
                //    string[,] data = { { "1", "2", "3" }, { "11", "22", "33" } };
                //    CompliteTable(ref app, markStart, markEnd, data);
                //}
                //catch
                //{
                //    Logs.AddError("Таблица (название) не построена");
                //}
                //                                  Удалить взаписке markStart и markEnd

      
                if (wordReplaces.Count > 0)
                    foreach (WordReplace wordReplace in wordReplaces)
                    {

                        Find findObject = app.Selection.Find;
                        findObject.ClearFormatting();
                        findObject.Text = $"[<]{wordReplace.Source} *[>]";
                        findObject.Replacement.ClearFormatting();
                        findObject.Replacement.Text = wordReplace.Replacer;
                        object replaceAll = WdReplace.wdReplaceAll;
                        findObject.Execute(ref o, ref o, ref o, ref oTrue, ref o,
                            ref o, ref o, ref o, ref o, ref o,
                            ref replaceAll, ref o, ref o, ref o, ref o);
                    }


                try
                {
                    doc.SaveAs($"{path}\\{newFileName}.docm");
                }
                catch
                {
                    Logs.AddAlarm($"не удалось сохранить файл \"{newFileName}\" снимите защиту от записи");
                }
            }
            finally
            {
                docs.Close(oFalse);
                app.Quit();
            }
        }
        private void CompliteTable(ref Application app, string markStart, string markEnd, string[,] data)
        {
            int rowCount = data.GetLength(0);
            int colCount = data.GetLength(1);
            app.Selection.Find.Execute($"{markStart}*{markEnd}");
            Microsoft.Office.Interop.Word.Range wordRange = app.Selection.Range;
            if (wordRange.Tables.Count > 0)
            {
                Table table = wordRange.Tables[1];
                for (int i = 1; i < rowCount; i++)
                {
                    table.Rows.Add(table.Rows[2]);
                }
                for (int r = 1; r <= rowCount; r++)
                {
                    for (int c = 1; c <= colCount; c++)
                    {
                        table.Cell(r, c).Range.Text = data[r - 1, c - 1];
                    }

                }
            }
        }
    }
}