namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmScenarioInformation : Form
    {
        private Button btnCancel;
        private Button btnModify;
        private ComboBox cbDay;
        private ComboBox cbMonth;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private formMapEditor MainForm;
        private MaskedTextBox mtbYear;
        private RichTextBox rtbScenarioBrief;
        private GameScenario Scenario;
        private TextBox tbScenarioTitle;

        public frmScenarioInformation()
        {
            this.InitializeComponent();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            this.Scenario.Date.Year = int.Parse(this.mtbYear.Text);
            this.Scenario.Date.Month = int.Parse(this.cbMonth.Text);
            this.Scenario.Date.Day = int.Parse(this.cbDay.Text);
            this.Scenario.ScenarioTitle = this.tbScenarioTitle.Text;
            this.Scenario.ScenarioDescription = this.rtbScenarioBrief.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void Initialize(formMapEditor form)
        {
            this.MainForm = form;
            this.Scenario = form.Scenario;
            this.mtbYear.Text = this.Scenario.Date.Year.ToString();
            this.cbMonth.SelectedIndex = this.cbMonth.Items.IndexOf(this.Scenario.Date.Month.ToString());
            this.cbDay.SelectedIndex = this.cbDay.Items.IndexOf(this.Scenario.Date.Day.ToString());
            this.tbScenarioTitle.Text = this.Scenario.ScenarioTitle;
            this.rtbScenarioBrief.Text = this.Scenario.ScenarioDescription;
        }

        private void InitializeComponent()
        {
            this.mtbYear = new MaskedTextBox();
            this.cbMonth = new ComboBox();
            this.cbDay = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.label3 = new Label();
            this.btnCancel = new Button();
            this.btnModify = new Button();
            this.tbScenarioTitle = new TextBox();
            this.label4 = new Label();
            this.rtbScenarioBrief = new RichTextBox();
            this.label5 = new Label();
            base.SuspendLayout();
            this.mtbYear.Location = new Point(0x24, 11);
            this.mtbYear.Margin = new Padding(2);
            this.mtbYear.Mask = "999";
            this.mtbYear.Name = "mtbYear";
            this.mtbYear.Size = new Size(0x36, 0x15);
            this.mtbYear.TabIndex = 0;
            this.mtbYear.Text = "184";
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            this.cbMonth.Location = new Point(0x7f, 11);
            this.cbMonth.Margin = new Padding(2);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new Size(0x36, 20);
            this.cbMonth.TabIndex = 1;
            this.cbMonth.Text = "1";
            this.cbDay.FormattingEnabled = true;
            this.cbDay.Items.AddRange(new object[] { 
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", 
                "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30"
             });
            this.cbDay.Location = new Point(0xe3, 10);
            this.cbDay.Margin = new Padding(2);
            this.cbDay.Name = "cbDay";
            this.cbDay.Size = new Size(0x36, 20);
            this.cbDay.TabIndex = 2;
            this.cbDay.Text = "1";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(15, 13);
            this.label1.Margin = new Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x11, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "年";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x6a, 13);
            this.label2.Margin = new Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x11, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "月";
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0xce, 13);
            this.label3.Margin = new Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x11, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "日";
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x27b, 0x191);
            this.btnCancel.Margin = new Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x45, 0x19);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnModify.DialogResult = DialogResult.OK;
            this.btnModify.Location = new Point(0x232, 0x191);
            this.btnModify.Margin = new Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new Size(0x45, 0x19);
            this.btnModify.TabIndex = 6;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new EventHandler(this.btnModify_Click);
            this.tbScenarioTitle.Location = new Point(0x4a, 0x34);
            this.tbScenarioTitle.Name = "tbScenarioTitle";
            this.tbScenarioTitle.Size = new Size(0x89, 0x15);
            this.tbScenarioTitle.TabIndex = 8;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(15, 0x37);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "剧本标题";
            this.rtbScenarioBrief.Location = new Point(0x11, 110);
            this.rtbScenarioBrief.Name = "rtbScenarioBrief";
            this.rtbScenarioBrief.Size = new Size(0x2a0, 0x108);
            this.rtbScenarioBrief.TabIndex = 10;
            this.rtbScenarioBrief.Text = "";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(15, 0x56);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x35, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "剧本介绍";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2cc, 0x1bd);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.rtbScenarioBrief);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.tbScenarioTitle);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnModify);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cbDay);
            base.Controls.Add(this.cbMonth);
            base.Controls.Add(this.mtbYear);
            base.Margin = new Padding(2);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmScenarioInformation";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "剧本信息";
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

