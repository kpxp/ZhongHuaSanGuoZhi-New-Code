namespace ScenarioGenerator
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
            this.btnLoadScenario = new System.Windows.Forms.Button();
            this.lblFilename = new System.Windows.Forms.Label();
            this.openScenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbJoinedFactionChance = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbAgeHi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAgeLo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbDebutAgeHi = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDebutAgeLo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBornYearHi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBornYearLo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFemaleChance = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAddPersonHi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAddPersonLo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbDeletePersonLo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbDeletePersonHi = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDeletePersonAbyLo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbDeletePersonTAbyLo = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbDeleteLeader = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbDeletePersonAbyHi = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbDeletePersonTAbyHi = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblPersonType0 = new System.Windows.Forms.Label();
            this.tbPersonType0 = new System.Windows.Forms.TextBox();
            this.tbPersonType1 = new System.Windows.Forms.TextBox();
            this.lblPersonType1 = new System.Windows.Forms.Label();
            this.tbPersonType2 = new System.Windows.Forms.TextBox();
            this.lblPersonType2 = new System.Windows.Forms.Label();
            this.tbPersonType3 = new System.Windows.Forms.TextBox();
            this.lblPersonType3 = new System.Windows.Forms.Label();
            this.tbPersonType4 = new System.Windows.Forms.TextBox();
            this.lblPersonType4 = new System.Windows.Forms.Label();
            this.tbPersonType5 = new System.Windows.Forms.TextBox();
            this.lblPersonType5 = new System.Windows.Forms.Label();
            this.tbPersonType6 = new System.Windows.Forms.TextBox();
            this.lblPersonType6 = new System.Windows.Forms.Label();
            this.tbPersonType7 = new System.Windows.Forms.TextBox();
            this.lblPersonType7 = new System.Windows.Forms.Label();
            this.tbPersonType8 = new System.Windows.Forms.TextBox();
            this.lblPersonType8 = new System.Windows.Forms.Label();
            this.tbPersonType9 = new System.Windows.Forms.TextBox();
            this.lblPersonType9 = new System.Windows.Forms.Label();
            this.tbDebutAtLeast = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadScenario
            // 
            this.btnLoadScenario.Location = new System.Drawing.Point(12, 12);
            this.btnLoadScenario.Name = "btnLoadScenario";
            this.btnLoadScenario.Size = new System.Drawing.Size(75, 23);
            this.btnLoadScenario.TabIndex = 0;
            this.btnLoadScenario.Text = "讀取劇本";
            this.btnLoadScenario.UseVisualStyleBackColor = true;
            this.btnLoadScenario.Click += new System.EventHandler(this.btnLoadScenario_Click);
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(93, 17);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(89, 12);
            this.lblFilename.TabIndex = 1;
            this.lblFilename.Text = "請選擇劇本檔案";
            // 
            // openScenFileDialog
            // 
            this.openScenFileDialog.FileName = "openFileDialog1";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Enabled = false;
            this.btnGenerate.Location = new System.Drawing.Point(646, 12);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "生成劇本";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(701, 293);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "人物";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbJoinedFactionChance
            // 
            this.tbJoinedFactionChance.Location = new System.Drawing.Point(114, 77);
            this.tbJoinedFactionChance.Name = "tbJoinedFactionChance";
            this.tbJoinedFactionChance.Size = new System.Drawing.Size(63, 22);
            this.tbJoinedFactionChance.TabIndex = 20;
            this.tbJoinedFactionChance.Text = "10";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 19;
            this.label11.Text = "仕官機率";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 18;
            this.label10.Text = "年";
            // 
            // tbAgeHi
            // 
            this.tbAgeHi.Location = new System.Drawing.Point(206, 161);
            this.tbAgeHi.Name = "tbAgeHi";
            this.tbAgeHi.Size = new System.Drawing.Size(63, 22);
            this.tbAgeHi.TabIndex = 17;
            this.tbAgeHi.Text = "90";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(183, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "至";
            // 
            // tbAgeLo
            // 
            this.tbAgeLo.Location = new System.Drawing.Point(114, 161);
            this.tbAgeLo.Name = "tbAgeLo";
            this.tbAgeLo.Size = new System.Drawing.Size(63, 22);
            this.tbAgeLo.TabIndex = 15;
            this.tbAgeLo.Text = "30";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 164);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "壽命";
            // 
            // tbDebutAgeHi
            // 
            this.tbDebutAgeHi.Location = new System.Drawing.Point(206, 133);
            this.tbDebutAgeHi.Name = "tbDebutAgeHi";
            this.tbDebutAgeHi.Size = new System.Drawing.Size(63, 22);
            this.tbDebutAgeHi.TabIndex = 13;
            this.tbDebutAgeHi.Text = "20";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(183, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "至";
            // 
            // tbDebutAgeLo
            // 
            this.tbDebutAgeLo.Location = new System.Drawing.Point(114, 133);
            this.tbDebutAgeLo.Name = "tbDebutAgeLo";
            this.tbDebutAgeLo.Size = new System.Drawing.Size(63, 22);
            this.tbDebutAgeLo.TabIndex = 11;
            this.tbDebutAgeLo.Text = "15";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "登場年齡";
            // 
            // tbBornYearHi
            // 
            this.tbBornYearHi.Location = new System.Drawing.Point(206, 105);
            this.tbBornYearHi.Name = "tbBornYearHi";
            this.tbBornYearHi.Size = new System.Drawing.Size(63, 22);
            this.tbBornYearHi.TabIndex = 9;
            this.tbBornYearHi.Text = "20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(183, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "至";
            // 
            // tbBornYearLo
            // 
            this.tbBornYearLo.Location = new System.Drawing.Point(114, 105);
            this.tbBornYearLo.Name = "tbBornYearLo";
            this.tbBornYearLo.Size = new System.Drawing.Size(63, 22);
            this.tbBornYearLo.TabIndex = 7;
            this.tbBornYearLo.Text = "-10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "出生年：劇本年後";
            // 
            // tbFemaleChance
            // 
            this.tbFemaleChance.Location = new System.Drawing.Point(114, 49);
            this.tbFemaleChance.Name = "tbFemaleChance";
            this.tbFemaleChance.Size = new System.Drawing.Size(63, 22);
            this.tbFemaleChance.TabIndex = 5;
            this.tbFemaleChance.Text = "10";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "生成女武將機率";
            // 
            // tbAddPersonHi
            // 
            this.tbAddPersonHi.Location = new System.Drawing.Point(206, 21);
            this.tbAddPersonHi.Name = "tbAddPersonHi";
            this.tbAddPersonHi.Size = new System.Drawing.Size(63, 22);
            this.tbAddPersonHi.TabIndex = 3;
            this.tbAddPersonHi.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "至";
            // 
            // tbAddPersonLo
            // 
            this.tbAddPersonLo.Location = new System.Drawing.Point(114, 21);
            this.tbAddPersonLo.Name = "tbAddPersonLo";
            this.tbAddPersonLo.Size = new System.Drawing.Size(63, 22);
            this.tbAddPersonLo.TabIndex = 1;
            this.tbAddPersonLo.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "增加人物數量";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(709, 319);
            this.tabControl1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.tbDebutAtLeast);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbJoinedFactionChance);
            this.groupBox1.Controls.Add(this.tbAddPersonLo);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tbAddPersonHi);
            this.groupBox1.Controls.Add(this.tbAgeHi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbFemaleChance);
            this.groupBox1.Controls.Add(this.tbAgeLo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tbBornYearLo);
            this.groupBox1.Controls.Add(this.tbDebutAgeHi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbBornYearHi);
            this.groupBox1.Controls.Add(this.tbDebutAgeLo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 214);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "增加人物";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tbDeletePersonTAbyHi);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tbDeletePersonAbyHi);
            this.groupBox2.Controls.Add(this.cbDeleteLeader);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tbDeletePersonTAbyLo);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.tbDeletePersonAbyLo);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tbDeletePersonLo);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbDeletePersonHi);
            this.groupBox2.Location = new System.Drawing.Point(305, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 140);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "刪除人物";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "刪除人物數量";
            // 
            // tbDeletePersonLo
            // 
            this.tbDeletePersonLo.Location = new System.Drawing.Point(115, 21);
            this.tbDeletePersonLo.Name = "tbDeletePersonLo";
            this.tbDeletePersonLo.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonLo.TabIndex = 5;
            this.tbDeletePersonLo.Text = "0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(184, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(17, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "至";
            // 
            // tbDeletePersonHi
            // 
            this.tbDeletePersonHi.Location = new System.Drawing.Point(207, 21);
            this.tbDeletePersonHi.Name = "tbDeletePersonHi";
            this.tbDeletePersonHi.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonHi.TabIndex = 7;
            this.tbDeletePersonHi.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 52);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(89, 12);
            this.label14.TabIndex = 8;
            this.label14.Text = "只限所有能力於";
            // 
            // tbDeletePersonAbyLo
            // 
            this.tbDeletePersonAbyLo.Location = new System.Drawing.Point(115, 49);
            this.tbDeletePersonAbyLo.Name = "tbDeletePersonAbyLo";
            this.tbDeletePersonAbyLo.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonAbyLo.TabIndex = 9;
            this.tbDeletePersonAbyLo.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(77, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "只限五圍和於";
            // 
            // tbDeletePersonTAbyLo
            // 
            this.tbDeletePersonTAbyLo.Location = new System.Drawing.Point(115, 77);
            this.tbDeletePersonTAbyLo.Name = "tbDeletePersonTAbyLo";
            this.tbDeletePersonTAbyLo.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonTAbyLo.TabIndex = 11;
            this.tbDeletePersonTAbyLo.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(276, 52);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "或";
            // 
            // cbDeleteLeader
            // 
            this.cbDeleteLeader.AutoSize = true;
            this.cbDeleteLeader.Location = new System.Drawing.Point(8, 107);
            this.cbDeleteLeader.Name = "cbDeleteLeader";
            this.cbDeleteLeader.Size = new System.Drawing.Size(96, 16);
            this.cbDeleteLeader.TabIndex = 13;
            this.cbDeleteLeader.Text = "容許刪除君主";
            this.cbDeleteLeader.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(184, 52);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(17, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "至";
            // 
            // tbDeletePersonAbyHi
            // 
            this.tbDeletePersonAbyHi.Location = new System.Drawing.Point(207, 49);
            this.tbDeletePersonAbyHi.Name = "tbDeletePersonAbyHi";
            this.tbDeletePersonAbyHi.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonAbyHi.TabIndex = 15;
            this.tbDeletePersonAbyHi.Text = "50";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(184, 80);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(17, 12);
            this.label18.TabIndex = 16;
            this.label18.Text = "至";
            // 
            // tbDeletePersonTAbyHi
            // 
            this.tbDeletePersonTAbyHi.Location = new System.Drawing.Point(207, 77);
            this.tbDeletePersonTAbyHi.Name = "tbDeletePersonTAbyHi";
            this.tbDeletePersonTAbyHi.Size = new System.Drawing.Size(63, 22);
            this.tbDeletePersonTAbyHi.TabIndex = 17;
            this.tbDeletePersonTAbyHi.Text = "250";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbPersonType9);
            this.groupBox3.Controls.Add(this.lblPersonType9);
            this.groupBox3.Controls.Add(this.tbPersonType8);
            this.groupBox3.Controls.Add(this.lblPersonType8);
            this.groupBox3.Controls.Add(this.tbPersonType7);
            this.groupBox3.Controls.Add(this.lblPersonType7);
            this.groupBox3.Controls.Add(this.tbPersonType6);
            this.groupBox3.Controls.Add(this.lblPersonType6);
            this.groupBox3.Controls.Add(this.tbPersonType5);
            this.groupBox3.Controls.Add(this.lblPersonType5);
            this.groupBox3.Controls.Add(this.tbPersonType4);
            this.groupBox3.Controls.Add(this.lblPersonType4);
            this.groupBox3.Controls.Add(this.tbPersonType3);
            this.groupBox3.Controls.Add(this.lblPersonType3);
            this.groupBox3.Controls.Add(this.tbPersonType2);
            this.groupBox3.Controls.Add(this.lblPersonType2);
            this.groupBox3.Controls.Add(this.tbPersonType1);
            this.groupBox3.Controls.Add(this.lblPersonType1);
            this.groupBox3.Controls.Add(this.tbPersonType0);
            this.groupBox3.Controls.Add(this.lblPersonType0);
            this.groupBox3.Location = new System.Drawing.Point(6, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(459, 64);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "生成武將種類";
            // 
            // lblPersonType0
            // 
            this.lblPersonType0.AutoSize = true;
            this.lblPersonType0.Location = new System.Drawing.Point(6, 18);
            this.lblPersonType0.Name = "lblPersonType0";
            this.lblPersonType0.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType0.TabIndex = 0;
            this.lblPersonType0.Text = "將軍";
            // 
            // tbPersonType0
            // 
            this.tbPersonType0.Location = new System.Drawing.Point(6, 33);
            this.tbPersonType0.Name = "tbPersonType0";
            this.tbPersonType0.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType0.TabIndex = 2;
            this.tbPersonType0.Text = "0";
            // 
            // tbPersonType1
            // 
            this.tbPersonType1.Location = new System.Drawing.Point(51, 33);
            this.tbPersonType1.Name = "tbPersonType1";
            this.tbPersonType1.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType1.TabIndex = 4;
            this.tbPersonType1.Text = "0";
            // 
            // lblPersonType1
            // 
            this.lblPersonType1.AutoSize = true;
            this.lblPersonType1.Location = new System.Drawing.Point(51, 18);
            this.lblPersonType1.Name = "lblPersonType1";
            this.lblPersonType1.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType1.TabIndex = 3;
            this.lblPersonType1.Text = "猛將";
            // 
            // tbPersonType2
            // 
            this.tbPersonType2.Location = new System.Drawing.Point(96, 33);
            this.tbPersonType2.Name = "tbPersonType2";
            this.tbPersonType2.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType2.TabIndex = 6;
            this.tbPersonType2.Text = "0";
            // 
            // lblPersonType2
            // 
            this.lblPersonType2.AutoSize = true;
            this.lblPersonType2.Location = new System.Drawing.Point(96, 18);
            this.lblPersonType2.Name = "lblPersonType2";
            this.lblPersonType2.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType2.TabIndex = 5;
            this.lblPersonType2.Text = "軍師";
            // 
            // tbPersonType3
            // 
            this.tbPersonType3.Location = new System.Drawing.Point(141, 33);
            this.tbPersonType3.Name = "tbPersonType3";
            this.tbPersonType3.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType3.TabIndex = 8;
            this.tbPersonType3.Text = "0";
            // 
            // lblPersonType3
            // 
            this.lblPersonType3.AutoSize = true;
            this.lblPersonType3.Location = new System.Drawing.Point(141, 18);
            this.lblPersonType3.Name = "lblPersonType3";
            this.lblPersonType3.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType3.TabIndex = 7;
            this.lblPersonType3.Text = "識者";
            // 
            // tbPersonType4
            // 
            this.tbPersonType4.Location = new System.Drawing.Point(186, 33);
            this.tbPersonType4.Name = "tbPersonType4";
            this.tbPersonType4.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType4.TabIndex = 10;
            this.tbPersonType4.Text = "0";
            // 
            // lblPersonType4
            // 
            this.lblPersonType4.AutoSize = true;
            this.lblPersonType4.Location = new System.Drawing.Point(186, 18);
            this.lblPersonType4.Name = "lblPersonType4";
            this.lblPersonType4.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType4.TabIndex = 9;
            this.lblPersonType4.Text = "智將";
            // 
            // tbPersonType5
            // 
            this.tbPersonType5.Location = new System.Drawing.Point(231, 33);
            this.tbPersonType5.Name = "tbPersonType5";
            this.tbPersonType5.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType5.TabIndex = 12;
            this.tbPersonType5.Text = "0";
            // 
            // lblPersonType5
            // 
            this.lblPersonType5.AutoSize = true;
            this.lblPersonType5.Location = new System.Drawing.Point(231, 18);
            this.lblPersonType5.Name = "lblPersonType5";
            this.lblPersonType5.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType5.TabIndex = 11;
            this.lblPersonType5.Text = "君主";
            // 
            // tbPersonType6
            // 
            this.tbPersonType6.Location = new System.Drawing.Point(276, 33);
            this.tbPersonType6.Name = "tbPersonType6";
            this.tbPersonType6.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType6.TabIndex = 14;
            this.tbPersonType6.Text = "0";
            // 
            // lblPersonType6
            // 
            this.lblPersonType6.AutoSize = true;
            this.lblPersonType6.Location = new System.Drawing.Point(276, 18);
            this.lblPersonType6.Name = "lblPersonType6";
            this.lblPersonType6.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType6.TabIndex = 13;
            this.lblPersonType6.Text = "全能";
            // 
            // tbPersonType7
            // 
            this.tbPersonType7.Location = new System.Drawing.Point(321, 33);
            this.tbPersonType7.Name = "tbPersonType7";
            this.tbPersonType7.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType7.TabIndex = 16;
            this.tbPersonType7.Text = "0";
            // 
            // lblPersonType7
            // 
            this.lblPersonType7.AutoSize = true;
            this.lblPersonType7.Location = new System.Drawing.Point(321, 18);
            this.lblPersonType7.Name = "lblPersonType7";
            this.lblPersonType7.Size = new System.Drawing.Size(41, 12);
            this.lblPersonType7.TabIndex = 15;
            this.lblPersonType7.Text = "平凡文";
            // 
            // tbPersonType8
            // 
            this.tbPersonType8.Location = new System.Drawing.Point(366, 33);
            this.tbPersonType8.Name = "tbPersonType8";
            this.tbPersonType8.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType8.TabIndex = 18;
            this.tbPersonType8.Text = "0";
            // 
            // lblPersonType8
            // 
            this.lblPersonType8.AutoSize = true;
            this.lblPersonType8.Location = new System.Drawing.Point(366, 18);
            this.lblPersonType8.Name = "lblPersonType8";
            this.lblPersonType8.Size = new System.Drawing.Size(41, 12);
            this.lblPersonType8.TabIndex = 17;
            this.lblPersonType8.Text = "平凡武";
            // 
            // tbPersonType9
            // 
            this.tbPersonType9.Location = new System.Drawing.Point(411, 33);
            this.tbPersonType9.Name = "tbPersonType9";
            this.tbPersonType9.Size = new System.Drawing.Size(39, 22);
            this.tbPersonType9.TabIndex = 20;
            this.tbPersonType9.Text = "0";
            // 
            // lblPersonType9
            // 
            this.lblPersonType9.AutoSize = true;
            this.lblPersonType9.Location = new System.Drawing.Point(411, 18);
            this.lblPersonType9.Name = "lblPersonType9";
            this.lblPersonType9.Size = new System.Drawing.Size(29, 12);
            this.lblPersonType9.TabIndex = 19;
            this.lblPersonType9.Text = "庸才";
            // 
            // tbDebutAtLeast
            // 
            this.tbDebutAtLeast.Location = new System.Drawing.Point(114, 189);
            this.tbDebutAtLeast.Name = "tbDebutAtLeast";
            this.tbDebutAtLeast.Size = new System.Drawing.Size(63, 22);
            this.tbDebutAtLeast.TabIndex = 22;
            this.tbDebutAtLeast.Text = "15";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 192);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(53, 12);
            this.label19.TabIndex = 21;
            this.label19.Text = "登場最少";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(183, 192);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(17, 12);
            this.label20.TabIndex = 23;
            this.label20.Text = "年";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 372);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.btnLoadScenario);
            this.Name = "Form1";
            this.Text = "劇本生成器";
            this.tabPage1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadScenario;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.OpenFileDialog openScenFileDialog;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbAddPersonHi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAddPersonLo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFemaleChance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbDebutAgeHi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDebutAgeLo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbBornYearHi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbBornYearLo;
        private System.Windows.Forms.TextBox tbAgeHi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbAgeLo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbJoinedFactionChance;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbDeletePersonLo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbDeletePersonHi;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbDeletePersonAbyLo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbDeletePersonTAbyLo;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbDeletePersonTAbyHi;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbDeletePersonAbyHi;
        private System.Windows.Forms.CheckBox cbDeleteLeader;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbPersonType9;
        private System.Windows.Forms.Label lblPersonType9;
        private System.Windows.Forms.TextBox tbPersonType8;
        private System.Windows.Forms.Label lblPersonType8;
        private System.Windows.Forms.TextBox tbPersonType7;
        private System.Windows.Forms.Label lblPersonType7;
        private System.Windows.Forms.TextBox tbPersonType6;
        private System.Windows.Forms.Label lblPersonType6;
        private System.Windows.Forms.TextBox tbPersonType5;
        private System.Windows.Forms.Label lblPersonType5;
        private System.Windows.Forms.TextBox tbPersonType4;
        private System.Windows.Forms.Label lblPersonType4;
        private System.Windows.Forms.TextBox tbPersonType3;
        private System.Windows.Forms.Label lblPersonType3;
        private System.Windows.Forms.TextBox tbPersonType2;
        private System.Windows.Forms.Label lblPersonType2;
        private System.Windows.Forms.TextBox tbPersonType1;
        private System.Windows.Forms.Label lblPersonType1;
        private System.Windows.Forms.TextBox tbPersonType0;
        private System.Windows.Forms.Label lblPersonType0;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbDebutAtLeast;
        private System.Windows.Forms.Label label19;
    }
}

