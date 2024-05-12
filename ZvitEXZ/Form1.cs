using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        string baseFileName;
        List<LogMessage> logMessages = new List<LogMessage>();
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            Logs.AddForm(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnCalculate.Enabled = false;
            openFileDialog1.Filter = "Excel (*.xlsb)|*.xlsb|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;
            string fileName = openFileDialog1.FileName;
            labelFileName.Text = Path.GetFileName(fileName);
            baseFileName = Path.GetFileNameWithoutExtension(fileName);
            ReadExcelFile fileReader = new ReadExcelFile();
            List<object[]> listObjects = new List<object[]>();
            listObjects = fileReader.ReadFile(fileName);
            ParseAllZamers parseAllZamers = new ParseAllZamers();
            zamers = parseAllZamers.Parse(listObjects, out ExcelDictionary);
            if (zamers.Count > 0)
            {
                Logs.AddLog($"Файл прочтен, колличество замеров {zamers.Count}");
                btnCalculate.Enabled = true;
            }
            else Logs.AddAlarm("Файл не прочтен");
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
            Calculate calculate = new Calculate();
            calculate.CalculateAll(zamers, ExcelDictionary);
            btnCalculate.Enabled = true;
            btnOpen.Enabled = true;
        }
    }
}
