using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods
{
    internal static class Progress
    {
        private static Form1 form1;
        private static int step;

        public static void AddForm(Form1 form)
        {
            form1 = form;
            form1.progressBar1.Value = 0;
        }
        public static void SetOperationCount(int count)
        {
            if (count > 0)
                step = (int)(100 / count);
            Clear();
        }
        public static void AddStep()
        {
            if (form1.progressBar1.Value + step < 100)
            {
                form1.progressBar1.Value = form1.progressBar1.Value + step;
            }
            else
            {
                Finish();
            }
        }
        public static void Clear()
        {
            form1.progressBar1.Value = 0;
        }
        public static void Finish()
        {
            form1.progressBar1.Value = 100;
            form1.progressBar1.ForeColor = Color.Gray;
        }
    }
}
