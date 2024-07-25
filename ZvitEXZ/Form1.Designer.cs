namespace ZvitEXZ
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.rTBLogs = new System.Windows.Forms.RichTextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cbIsStandartWordShablon = new System.Windows.Forms.CheckBox();
            this.cbProtokol = new System.Windows.Forms.CheckBox();
            this.cbZapycka = new System.Windows.Forms.CheckBox();
            this.cbStatistiks = new System.Windows.Forms.CheckBox();
            this.cbPovitrPerehody = new System.Windows.Forms.CheckBox();
            this.cbShurfy = new System.Windows.Forms.CheckBox();
            this.cbNenormHlyb = new System.Windows.Forms.CheckBox();
            this.cbZvedena = new System.Windows.Forms.CheckBox();
            this.cbFlantsy = new System.Windows.Forms.CheckBox();
            this.cbPereh = new System.Windows.Forms.CheckBox();
            this.cbNezah = new System.Windows.Forms.CheckBox();
            this.cbPovregdGNT = new System.Windows.Forms.CheckBox();
            this.cbPovregd = new System.Windows.Forms.CheckBox();
            this.cbKorneb = new System.Windows.Forms.CheckBox();
            this.cbPv = new System.Windows.Forms.CheckBox();
            this.cbUpz = new System.Windows.Forms.CheckBox();
            this.cbUkz = new System.Windows.Forms.CheckBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbMaxPotencial = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbKmStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCadKmperDrawing = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOpen.Location = new System.Drawing.Point(12, 12);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(89, 32);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open File";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // rTBLogs
            // 
            this.rTBLogs.BackColor = System.Drawing.SystemColors.Control;
            this.rTBLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rTBLogs.HideSelection = false;
            this.rTBLogs.Location = new System.Drawing.Point(585, 35);
            this.rTBLogs.Name = "rTBLogs";
            this.rTBLogs.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTBLogs.Size = new System.Drawing.Size(464, 463);
            this.rTBLogs.TabIndex = 3;
            this.rTBLogs.Text = "";
            this.rTBLogs.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Enabled = false;
            this.btnCalculate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(12, 171);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(123, 33);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Рассчитать";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 58);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 13);
            this.labelFileName.TabIndex = 6;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 508);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1037, 23);
            this.progressBar1.TabIndex = 7;
            this.progressBar1.UseWaitCursor = true;
            // 
            // cbIsStandartWordShablon
            // 
            this.cbIsStandartWordShablon.AutoSize = true;
            this.cbIsStandartWordShablon.Checked = true;
            this.cbIsStandartWordShablon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsStandartWordShablon.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIsStandartWordShablon.Location = new System.Drawing.Point(115, 374);
            this.cbIsStandartWordShablon.Name = "cbIsStandartWordShablon";
            this.cbIsStandartWordShablon.Size = new System.Drawing.Size(132, 22);
            this.cbIsStandartWordShablon.TabIndex = 17;
            this.cbIsStandartWordShablon.Text = "Shablon.docm )";
            this.cbIsStandartWordShablon.UseVisualStyleBackColor = true;
            // 
            // cbProtokol
            // 
            this.cbProtokol.AutoSize = true;
            this.cbProtokol.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbProtokol.Location = new System.Drawing.Point(24, 402);
            this.cbProtokol.Name = "cbProtokol";
            this.cbProtokol.Size = new System.Drawing.Size(254, 22);
            this.cbProtokol.TabIndex = 16;
            this.cbProtokol.Text = "Протокол построения графиков";
            this.cbProtokol.UseVisualStyleBackColor = true;
            this.cbProtokol.CheckedChanged += new System.EventHandler(this.cbProtokol_CheckedChanged);
            // 
            // cbZapycka
            // 
            this.cbZapycka.AutoSize = true;
            this.cbZapycka.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbZapycka.Location = new System.Drawing.Point(24, 374);
            this.cbZapycka.Name = "cbZapycka";
            this.cbZapycka.Size = new System.Drawing.Size(94, 22);
            this.cbZapycka.TabIndex = 15;
            this.cbZapycka.Text = "Записка (";
            this.cbZapycka.UseVisualStyleBackColor = true;
            this.cbZapycka.CheckedChanged += new System.EventHandler(this.cbZapycka_CheckedChanged);
            // 
            // cbStatistiks
            // 
            this.cbStatistiks.AutoSize = true;
            this.cbStatistiks.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbStatistiks.Location = new System.Drawing.Point(80, 346);
            this.cbStatistiks.Name = "cbStatistiks";
            this.cbStatistiks.Size = new System.Drawing.Size(107, 22);
            this.cbStatistiks.TabIndex = 14;
            this.cbStatistiks.Text = "Статистика";
            this.cbStatistiks.UseVisualStyleBackColor = true;
            this.cbStatistiks.CheckedChanged += new System.EventHandler(this.cbStatistiks_CheckedChanged);
            // 
            // cbPovitrPerehody
            // 
            this.cbPovitrPerehody.AutoSize = true;
            this.cbPovitrPerehody.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPovitrPerehody.Location = new System.Drawing.Point(80, 313);
            this.cbPovitrPerehody.Name = "cbPovitrPerehody";
            this.cbPovitrPerehody.Size = new System.Drawing.Size(201, 22);
            this.cbPovitrPerehody.TabIndex = 12;
            this.cbPovitrPerehody.Text = "Ф-Воздушные Переходы";
            this.cbPovitrPerehody.UseVisualStyleBackColor = true;
            this.cbPovitrPerehody.CheckedChanged += new System.EventHandler(this.cbPovitrPerehody_CheckedChanged);
            // 
            // cbShurfy
            // 
            this.cbShurfy.AutoSize = true;
            this.cbShurfy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbShurfy.Location = new System.Drawing.Point(80, 287);
            this.cbShurfy.Name = "cbShurfy";
            this.cbShurfy.Size = new System.Drawing.Size(94, 22);
            this.cbShurfy.TabIndex = 11;
            this.cbShurfy.Text = "У-Шурфы";
            this.cbShurfy.UseVisualStyleBackColor = true;
            this.cbShurfy.CheckedChanged += new System.EventHandler(this.cbShurfy_CheckedChanged);
            // 
            // cbNenormHlyb
            // 
            this.cbNenormHlyb.AutoSize = true;
            this.cbNenormHlyb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNenormHlyb.Location = new System.Drawing.Point(80, 259);
            this.cbNenormHlyb.Name = "cbNenormHlyb";
            this.cbNenormHlyb.Size = new System.Drawing.Size(205, 22);
            this.cbNenormHlyb.TabIndex = 13;
            this.cbNenormHlyb.Text = "С-Ненормативна глибина";
            this.cbNenormHlyb.UseVisualStyleBackColor = true;
            this.cbNenormHlyb.CheckedChanged += new System.EventHandler(this.cbNenormHlyb_CheckedChanged);
            // 
            // cbZvedena
            // 
            this.cbZvedena.AutoSize = true;
            this.cbZvedena.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbZvedena.Location = new System.Drawing.Point(80, 231);
            this.cbZvedena.Name = "cbZvedena";
            this.cbZvedena.Size = new System.Drawing.Size(101, 22);
            this.cbZvedena.TabIndex = 10;
            this.cbZvedena.Text = "Р-Зведена";
            this.cbZvedena.UseVisualStyleBackColor = true;
            this.cbZvedena.CheckedChanged += new System.EventHandler(this.cbZvedena_CheckedChanged);
            // 
            // cbFlantsy
            // 
            this.cbFlantsy.AutoSize = true;
            this.cbFlantsy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbFlantsy.Location = new System.Drawing.Point(80, 205);
            this.cbFlantsy.Name = "cbFlantsy";
            this.cbFlantsy.Size = new System.Drawing.Size(100, 22);
            this.cbFlantsy.TabIndex = 9;
            this.cbFlantsy.Text = "П-Фланцы";
            this.cbFlantsy.UseVisualStyleBackColor = true;
            this.cbFlantsy.CheckedChanged += new System.EventHandler(this.cbFlantsy_CheckedChanged);
            // 
            // cbPereh
            // 
            this.cbPereh.AutoSize = true;
            this.cbPereh.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPereh.Location = new System.Drawing.Point(80, 180);
            this.cbPereh.Name = "cbPereh";
            this.cbPereh.Size = new System.Drawing.Size(111, 22);
            this.cbPereh.TabIndex = 8;
            this.cbPereh.Text = "Н-Переходи";
            this.cbPereh.UseVisualStyleBackColor = true;
            this.cbPereh.CheckedChanged += new System.EventHandler(this.cbPereh_CheckedChanged);
            // 
            // cbNezah
            // 
            this.cbNezah.AutoSize = true;
            this.cbNezah.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbNezah.Location = new System.Drawing.Point(80, 154);
            this.cbNezah.Name = "cbNezah";
            this.cbNezah.Size = new System.Drawing.Size(110, 22);
            this.cbNezah.TabIndex = 7;
            this.cbNezah.Text = "М-Незахист";
            this.cbNezah.UseVisualStyleBackColor = true;
            this.cbNezah.CheckedChanged += new System.EventHandler(this.cbNezah_CheckedChanged);
            // 
            // cbPovregdGNT
            // 
            this.cbPovregdGNT.AutoSize = true;
            this.cbPovregdGNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPovregdGNT.Location = new System.Drawing.Point(80, 131);
            this.cbPovregdGNT.Name = "cbPovregdGNT";
            this.cbPovregdGNT.Size = new System.Drawing.Size(176, 22);
            this.cbPovregdGNT.TabIndex = 6;
            this.cbPovregdGNT.Text = "Л-Пошкодження ГНТ";
            this.cbPovregdGNT.UseVisualStyleBackColor = true;
            this.cbPovregdGNT.CheckedChanged += new System.EventHandler(this.cbPovregdGNT_CheckedChanged);
            // 
            // cbPovregd
            // 
            this.cbPovregd.AutoSize = true;
            this.cbPovregd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPovregd.Location = new System.Drawing.Point(80, 105);
            this.cbPovregd.Name = "cbPovregd";
            this.cbPovregd.Size = new System.Drawing.Size(143, 22);
            this.cbPovregd.TabIndex = 5;
            this.cbPovregd.Text = "Л-Пошкодження";
            this.cbPovregd.UseVisualStyleBackColor = true;
            this.cbPovregd.CheckedChanged += new System.EventHandler(this.cbPovregd_CheckedChanged);
            // 
            // cbKorneb
            // 
            this.cbKorneb.AutoSize = true;
            this.cbKorneb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbKorneb.Location = new System.Drawing.Point(80, 82);
            this.cbKorneb.Name = "cbKorneb";
            this.cbKorneb.Size = new System.Drawing.Size(153, 22);
            this.cbKorneb.TabIndex = 4;
            this.cbKorneb.Text = "К-Кор. небезпечні";
            this.cbKorneb.UseVisualStyleBackColor = true;
            this.cbKorneb.CheckedChanged += new System.EventHandler(this.cbKorneb_CheckedChanged);
            // 
            // cbPv
            // 
            this.cbPv.AutoSize = true;
            this.cbPv.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbPv.Location = new System.Drawing.Point(80, 56);
            this.cbPv.Name = "cbPv";
            this.cbPv.Size = new System.Drawing.Size(64, 22);
            this.cbPv.TabIndex = 3;
            this.cbPv.Text = "И-ПВ";
            this.cbPv.UseVisualStyleBackColor = true;
            this.cbPv.CheckedChanged += new System.EventHandler(this.cbPv_CheckedChanged);
            // 
            // cbUpz
            // 
            this.cbUpz.AutoSize = true;
            this.cbUpz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUpz.Location = new System.Drawing.Point(80, 33);
            this.cbUpz.Name = "cbUpz";
            this.cbUpz.Size = new System.Drawing.Size(77, 22);
            this.cbUpz.TabIndex = 2;
            this.cbUpz.Text = "Ж-УПЗ";
            this.cbUpz.UseVisualStyleBackColor = true;
            this.cbUpz.CheckedChanged += new System.EventHandler(this.cbUpz_CheckedChanged);
            // 
            // cbUkz
            // 
            this.cbUkz.AutoSize = true;
            this.cbUkz.BackColor = System.Drawing.SystemColors.Control;
            this.cbUkz.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbUkz.Location = new System.Drawing.Point(80, 10);
            this.cbUkz.Name = "cbUkz";
            this.cbUkz.Size = new System.Drawing.Size(74, 22);
            this.cbUkz.TabIndex = 1;
            this.cbUkz.Text = "Д-УКЗ";
            this.cbUkz.UseVisualStyleBackColor = false;
            this.cbUkz.CheckedChanged += new System.EventHandler(this.cbUkz_CheckedChanged);
            // 
            // cbAll
            // 
            this.cbAll.AutoSize = true;
            this.cbAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAll.Location = new System.Drawing.Point(16, 14);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(58, 22);
            this.cbAll.TabIndex = 0;
            this.cbAll.Text = "ВСЕ";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(141, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(438, 490);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.cbIsStandartWordShablon);
            this.tabPage1.Controls.Add(this.cbAll);
            this.tabPage1.Controls.Add(this.cbProtokol);
            this.tabPage1.Controls.Add(this.cbUpz);
            this.tabPage1.Controls.Add(this.cbZapycka);
            this.tabPage1.Controls.Add(this.cbUkz);
            this.tabPage1.Controls.Add(this.cbStatistiks);
            this.tabPage1.Controls.Add(this.cbPv);
            this.tabPage1.Controls.Add(this.cbPovitrPerehody);
            this.tabPage1.Controls.Add(this.cbKorneb);
            this.tabPage1.Controls.Add(this.cbShurfy);
            this.tabPage1.Controls.Add(this.cbPovregd);
            this.tabPage1.Controls.Add(this.cbNenormHlyb);
            this.tabPage1.Controls.Add(this.cbPovregdGNT);
            this.tabPage1.Controls.Add(this.cbZvedena);
            this.tabPage1.Controls.Add(this.cbNezah);
            this.tabPage1.Controls.Add(this.cbFlantsy);
            this.tabPage1.Controls.Add(this.cbPereh);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(430, 459);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.cbMaxPotencial);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbKmStart);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbCadKmperDrawing);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(430, 459);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Settings";
            // 
            // cbMaxPotencial
            // 
            this.cbMaxPotencial.AllowDrop = true;
            this.cbMaxPotencial.BackColor = System.Drawing.SystemColors.Control;
            this.cbMaxPotencial.FormattingEnabled = true;
            this.cbMaxPotencial.Items.AddRange(new object[] {
            "0.3",
            "0.5",
            "1",
            "3",
            "5"});
            this.cbMaxPotencial.Location = new System.Drawing.Point(281, 93);
            this.cbMaxPotencial.Name = "cbMaxPotencial";
            this.cbMaxPotencial.Size = new System.Drawing.Size(76, 26);
            this.cbMaxPotencial.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Максимальное значение потенциала";
            // 
            // tbKmStart
            // 
            this.tbKmStart.BackColor = System.Drawing.SystemColors.Control;
            this.tbKmStart.Location = new System.Drawing.Point(266, 59);
            this.tbKmStart.Name = "tbKmStart";
            this.tbKmStart.Size = new System.Drawing.Size(68, 24);
            this.tbKmStart.TabIndex = 3;
            this.tbKmStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbKmStart.TextChanged += new System.EventHandler(this.tbKmStart_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Начальный километраж графиков ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Колличестко километром на графике";
            // 
            // cbCadKmperDrawing
            // 
            this.cbCadKmperDrawing.AllowDrop = true;
            this.cbCadKmperDrawing.BackColor = System.Drawing.SystemColors.Control;
            this.cbCadKmperDrawing.FormattingEnabled = true;
            this.cbCadKmperDrawing.Items.AddRange(new object[] {
            "0.3",
            "0.5",
            "1",
            "3",
            "5"});
            this.cbCadKmperDrawing.Location = new System.Drawing.Point(290, 16);
            this.cbCadKmperDrawing.Name = "cbCadKmperDrawing";
            this.cbCadKmperDrawing.Size = new System.Drawing.Size(76, 26);
            this.cbCadKmperDrawing.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 429);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 543);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.rTBLogs);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Zvit EXZ v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        public System.Windows.Forms.RichTextBox rTBLogs;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label labelFileName;
        public System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.CheckBox cbAll;
        public System.Windows.Forms.CheckBox cbPereh;
        public System.Windows.Forms.CheckBox cbPovitrPerehody;
        public System.Windows.Forms.CheckBox cbShurfy;
        public System.Windows.Forms.CheckBox cbZvedena;
        public System.Windows.Forms.CheckBox cbFlantsy;
        public System.Windows.Forms.CheckBox cbNezah;
        public System.Windows.Forms.CheckBox cbPovregdGNT;
        public System.Windows.Forms.CheckBox cbPovregd;
        public System.Windows.Forms.CheckBox cbKorneb;
        public System.Windows.Forms.CheckBox cbPv;
        public System.Windows.Forms.CheckBox cbUpz;
        public System.Windows.Forms.CheckBox cbUkz;
        public System.Windows.Forms.CheckBox cbStatistiks;
        public System.Windows.Forms.CheckBox cbNenormHlyb;
        public System.Windows.Forms.CheckBox cbZapycka;
        public System.Windows.Forms.CheckBox cbProtokol;
        public System.Windows.Forms.CheckBox cbIsStandartWordShablon;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cbCadKmperDrawing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.TextBox tbKmStart;
        private System.Windows.Forms.ComboBox cbMaxPotencial;
        private System.Windows.Forms.Label label3;
    }
}

