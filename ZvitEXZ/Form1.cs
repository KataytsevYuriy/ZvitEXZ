using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using ZvitEXZ.Methods;
using ZvitEXZ.Methods.Calculations;
using ZvitEXZ.Models;
using ZvitEXZ.Models.Objects;
using Newtonsoft.Json.Linq;
using System.Globalization;
using System.Linq;
//using System.Net;

namespace ZvitEXZ
{
    public partial class Form1 : Form
    {
        List<Zamer> zamers = new List<Zamer>();
        public ExcelDictionary ExcelDictionary;
        private bool clearAll = true;
        double[] cadkmPerDrawing = { 0.3, 0.5, 1, 3, 5, 10 };
        double[] cadMaxPotencial = { -2, -2.5, -3, -3.5 };
        double kmPerDrawing;
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            Logs.AddForm(this);
            Progress.AddForm(this);
            Done.AddForm(this);
            cbCadKmperDrawing.DataSource = cadkmPerDrawing;
            cbCadKmperDrawing.SelectedIndex = 3;
            cbMaxPotencial.DataSource = cadMaxPotencial;
            cbMaxPotencial.SelectedIndex = 1;
            kmPerDrawing = AcadConstants.AdocDefaultLenthKm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool allowed = false;
            allowed = IsAllowed.Check();
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
            CheckErrors checkErrors = new CheckErrors();
            checkErrors.Check(zamers);
            if (zamers.Count > 0)
            {
                Logs.AddLog($"Файл прочтен, количество замеров {zamers.Count}");
                if (allowed) btnCalculate.Enabled = true;
                //tbKmStart.Text = Math.Truncate(zamers.FirstOrDefault().Km).ToString();
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
            bool onlyOneDrawing = false;
            if (!string.IsNullOrEmpty(tbKmStart.Text))
            {
                try
                {
                    AcadConstants.KmStart = Math.Round(Parse.ParseDouble(tbKmStart.Text));
                    onlyOneDrawing = true;
                }
                catch
                {
                    Logs.AddAlarm("Введите корректное значение начального километража");
                    btnCalculate.Enabled = true;
                    return;
                }
            }
            ProjectConstants.DocShablonPath = "";
            if (!cbIsStandartWordShablon.Checked)
            {
                openFileDialog1.Filter = "Word (*.docm)|*.docm|All files(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    ProjectConstants.DocShablonPath = openFileDialog1.FileName; ;
                }
            }
            kmPerDrawing = (double)cbCadKmperDrawing.SelectedValue;
            AcadConstants.UtzMax = (double)cbMaxPotencial.SelectedValue;
            Calculate calculate = new Calculate();
            calculate.CalculateAll(zamers, ExcelDictionary, chekeD, kmPerDrawing, onlyOneDrawing);
            btnCalculate.Enabled = true;
            btnOpen.Enabled = true;
        }

        private void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAll.Checked)
            {
                cbUkz.Checked = true; cbUpz.Checked = true;
                cbPv.Checked = true; cbKorneb.Checked = true;
                cbPovregd.Checked = true; cbPovregdGNT.Checked = true;
                cbNezah.Checked = true; cbPereh.Checked = true;
                cbFlantsy.Checked = true;
                cbZvedena.Checked = true; cbShurfy.Checked = true;
                cbPovitrPerehody.Checked = true;
                cbStatistiks.Checked = true;
                cbNenormHlyb.Checked = true;
                cbZapycka.Checked = true;
                cbProtokol.Checked = true;
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
                cbStatistiks.Checked = false;
                cbNenormHlyb.Checked = false;
                cbZapycka.Checked = false;
                cbProtokol.Checked = false;
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

        private void cbZapycka_CheckedChanged(object sender, EventArgs e)
        {
            if (!cbZapycka.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void cbProtokol_CheckedChanged(object sender, EventArgs e)
        {

            if (!cbProtokol.Checked)
            {
                clearAll = false;
                cbAll.Checked = false;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
        private void tbKmStart_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(tbKmStart.Text, "[^0-9]"))
            {
                tbKmStart.Text = tbKmStart.Text.Remove(tbKmStart.Text.Length - 1);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnSavePass_Click(object sender, EventArgs e)
        {
            Reg reg = new Reg();
            bool write = reg.WriteData(tbLogin.Text, tbPassword.Text);
            if (write) Logs.AddLog("Данные успешно сохранены");
        }
    }
}
