using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ZvitEXZ.Methods;
using ZvitEXZ.Methods.Calculations;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;

namespace ZvitEXZ
{
    public partial class Form1 : Form
    {
        List<Zamer> zamers = new List<Zamer>();
        public ExcelDictionary ExcelDictionary;
        private bool clearAll = true;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            Logs.AddForm(this);
            Progress.AddForm(this);
            Done.AddForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            openFileDialog1.Filter = "Excel (*.xlsb)|*.xlsb|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string fileName = openFileDialog1.FileName;
            labelFileName.Text = Path.GetFileName(fileName);
            ReadExcelFile fileReader = new ReadExcelFile();
            List<object[]> listObjects = new List<object[]>();
            listObjects = fileReader.ReadFile(fileName);
            ParseAllZamers parseAllZamers = new ParseAllZamers();
            zamers = parseAllZamers.Parse(listObjects, out ExcelDictionary);
            IsAllowed isAllowed = new IsAllowed();
            isAllowed.Check();
            if (zamers.Count > 0)
            {
                Logs.AddLog($"Файл прочтен, колличество замеров {zamers.Count}");
                btnCalculate.Enabled = true;
            }
            else
            {
                Logs.AddAlarm("Файл не прочтен");
                Logs.AddError("\"Я там не ходив...\"");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnCalculate_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            btnOpen.Enabled = false;
            Models.Calculations.Checked chekeD = new Models.Calculations.Checked(this);
            Calculate calculate = new Calculate();
            calculate.CalculateAll(zamers, ExcelDictionary, chekeD);
            btnCalculate.Enabled = true;
            btnOpen.Enabled = true;
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                cbUkz.Checked = true; cbUpz.Checked = true;
                cbPv.Checked = true; cbKorneb.Checked = true;
                cbPovregd.Checked = true; // cbPovregdGNT.Checked=true;
                cbNezah.Checked = true; cbPereh.Checked = true;
                cbFlantsy.Checked = true;
                cbZvedena.Checked = true; cbShurfy.Checked = true;
                cbPovitrPerehody.Checked = true;
                //cbStatistiks.Checked = true;
                //cbNenormHlyb.Checked = true;
            }
            else if (clearAll)
            {
                cbUkz.Checked = false; cbUpz.Checked = false;
                cbPv.Checked = false; cbKorneb.Checked = false;
                cbPovregd.Checked = false; cbPovregdGNT.Checked = false;
                cbNezah.Checked = false; cbPereh.Checked = false;
                cbFlantsy.Checked = false;
                cbZvedena.Checked = false; cbShurfy.Checked = false;
                cbPovitrPerehody.Checked = false;
            }
            clearAll = true;
        }

        private void cbUkz_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbUkz.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbUpz_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbUpz.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbPv_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPv.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbKorneb_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbKorneb.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbPovregd_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPovregd.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbPovregdGNT_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPovregdGNT.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbNezah_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbNezah.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbPereh_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPereh.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbFlantsy_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbFlantsy.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbZvedena_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbZvedena.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbShurfy_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbShurfy.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbPovitrPerehody_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbPovitrPerehody.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            progressBar1.Value = 50;
            progressBar1.BackColor = Color.Gray;
        }

        private void cbNenormHlyb_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbNenormHlyb.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbStatistiks_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbStatistiks.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }
    }
}
