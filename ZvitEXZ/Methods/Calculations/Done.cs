using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZvitEXZ.Methods.Calculations
{
    internal static class Done
    {
        private static Form1 form1;
        private static System.Drawing.Color color = System.Drawing.Color.Gainsboro;
        public static void AddForm(Form1 form)
        {
            form1 = form;
        }
        public static void Ukz()
        {
            form1.cbUkz.BackColor = color;
        }
        public static void Upz()
        {
            form1.cbUpz.BackColor = color;
        }
        public static void PV()
        {
            form1.cbPv.BackColor = color;
        }
        public static void Korneb()
        {
            form1.cbKorneb.BackColor = color;
        }
        public static void Povregd()
        {
            form1.cbPovregd.BackColor = color;
        }
        public static void PovregdGNT()
        {
            form1.cbPovregdGNT.BackColor = color;
        }
        public static void Nezahyst()
        {
            form1.cbNezah.BackColor = color;
        }
        public static void Perehody()
        {
            form1.cbPereh.BackColor = color;
        }
        public static void Flantsy()
        {
            form1.cbFlantsy.BackColor = color;
        }
        public static void Zvedena()
        {
            form1.cbZvedena.BackColor = color;
        }
        public static void Shurfy()
        {
            form1.cbShurfy.BackColor = color;
        }
        public static void povitrPerehody()
        {
            form1.cbPovitrPerehody.BackColor = color;
        }

    }
}
