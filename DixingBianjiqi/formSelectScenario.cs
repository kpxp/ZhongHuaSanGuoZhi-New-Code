using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using		GameObjects;


using		System.Data;
using		System.Drawing;
using		System.Windows.Forms;
using System.IO;
using System.ComponentModel;
using System.Data.OleDb;




namespace WorldOfTheThreeKingdoms.GameForms

{
    public class formSelectScenario : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private CheckedListBox clbFactions;
        private IContainer components = null;
        private FactionList currentFactions;
        private BindingSource gameScenarioBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox lbScenarios;
        public string ScenarioPath;
        private List<string> ScenarioPaths = new List<string>();
        public List<int> SelectedFactionIDs = new List<int>();
        private TextBox tbScenarioDescription;

        public formSelectScenario()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.lbScenarios.SelectedIndex >= 0)
            {
                if (this.clbFactions.CheckedIndices.Count > 0)
                {
                    this.ScenarioPath = this.ScenarioPaths[this.lbScenarios.SelectedIndex];
                    foreach (int num in this.clbFactions.CheckedIndices)
                    {
                        this.SelectedFactionIDs.Add(this.currentFactions[num].ID);
                    }
                    base.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("请选择您想要控制的势力。");
                }
            }
            else
            {
                MessageBox.Show("请选择剧本。");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void formSelectScenario_Load(object sender, EventArgs e)
        {
            string path = "GameData/Scenario/";
            if (!Directory.Exists(path))
            {
                base.Close();
            }
            foreach (string str2 in Directory.GetFiles(path))
            {
                FileInfo info = new FileInfo(str2);
                if (info.Extension.Equals(".mdb"))
                {
                    this.ScenarioPaths.Add(str2);
                    this.SetScenarioDisplayText(str2);
                }
            }
        }

        private void formSelectScenario_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                base.DialogResult = DialogResult.Cancel;
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.lbScenarios = new ListBox();
            this.clbFactions = new CheckedListBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();
            this.gameScenarioBindingSource = new BindingSource(this.components);
            this.tbScenarioDescription = new TextBox();
            this.label3 = new Label();
            ((ISupportInitialize)this.gameScenarioBindingSource).BeginInit();
            base.SuspendLayout();
            this.lbScenarios.FormattingEnabled = true;
            this.lbScenarios.ItemHeight = 12;
            this.lbScenarios.Location = new Point(12, 0x25);
            this.lbScenarios.Name = "lbScenarios";
            this.lbScenarios.Size = new Size(0x173, 0x94);
            this.lbScenarios.TabIndex = 0;
            this.lbScenarios.MouseClick += new MouseEventHandler(this.formSelectScenario_MouseClick);
            this.lbScenarios.SelectedIndexChanged += new EventHandler(this.lbScenarios_SelectedIndexChanged);
            this.clbFactions.CheckOnClick = true;
            this.clbFactions.FormattingEnabled = true;
            this.clbFactions.Location = new Point(0x185, 0x25);
            this.clbFactions.Name = "clbFactions";
            this.clbFactions.Size = new Size(0x125, 0x144);
            this.clbFactions.TabIndex = 1;
            this.btnOK.Location = new Point(0x20a, 380);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x25b, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 0x12);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "剧本列表";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x184, 0x12);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "势力列表";
            this.gameScenarioBindingSource.DataSource = typeof(GameScenario);
            this.tbScenarioDescription.BackColor = SystemColors.Window;
            this.tbScenarioDescription.Location = new Point(13, 0xda);
            this.tbScenarioDescription.Multiline = true;
            this.tbScenarioDescription.Name = "tbScenarioDescription";
            this.tbScenarioDescription.ReadOnly = true;
            this.tbScenarioDescription.Size = new Size(370, 0x8f);
            this.tbScenarioDescription.TabIndex = 6;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(11, 0xc7);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "剧本介绍";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2b4, 0x1a1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.tbScenarioDescription);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.clbFactions);
            base.Controls.Add(this.lbScenarios);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "formSelectScenario";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择剧本";
            base.Load += new EventHandler(this.formSelectScenario_Load);
            base.MouseClick += new MouseEventHandler(this.formSelectScenario_MouseClick);
            ((ISupportInitialize)this.gameScenarioBindingSource).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbScenarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetCurrentScenario(this.ScenarioPaths[this.lbScenarios.SelectedIndex]);
        }

        private void SetCurrentScenario(string filename)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            OleDbConnection dbConnection = new OleDbConnection(builder.ConnectionString);
            string gameScenarioDescription = GameScenario.GetGameScenarioDescription(dbConnection);
            this.tbScenarioDescription.Text = gameScenarioDescription;
            this.currentFactions = GameScenario.GetGameScenarioFactions(dbConnection);
            this.clbFactions.Items.Clear();
            foreach (Faction faction in this.currentFactions)
            {
                this.clbFactions.Items.Add(faction.Name);
            }
        }

        private void SetScenarioDisplayText(string filename)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            OleDbConnection dbConnection = new OleDbConnection(builder.ConnectionString);
            string gameScenarioSurveyText = GameScenario.GetGameScenarioSurveyText(dbConnection);
            this.lbScenarios.Items.Add(gameScenarioSurveyText);
        }
    }

 

}
