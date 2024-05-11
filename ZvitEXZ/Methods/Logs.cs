using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZvitEXZ.Models;
using System.Drawing;

namespace ZvitEXZ.Methods
{
    public static class Logs
    {
        private static Form1 form1;
        public static void AddForm(Form1 form)
        {
            form1 = form;
        }
        public static void AddAlarm(string text)
        {
            PrintLog(text, Color.Red);

        }
        public static void AddLog(string text)
        {
            PrintLog(text, Color.Gray);
        }
        public static void AddError(string text)
        {
            PrintLog(text, Color.Orange);
        }

        private static void PrintLog(string text, Color color)
        {
            form1.rTBLogs.SelectionStart = form1.rTBLogs.TextLength;
            form1.rTBLogs.SelectionLength = 0;
            form1.rTBLogs.SelectionColor = color;
            form1.rTBLogs.AppendText($"{text};\r\n");
        }
    }
}
