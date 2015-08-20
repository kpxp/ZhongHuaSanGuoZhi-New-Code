namespace MapEditor.Forms
{
    using GameObjects;
    using GameObjects.MapDetail;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmReplaceTerrain : Form
    {
        private Button btnCancel;
        private Button btnOK;
        private ComboBox cbTerrain1;
        private ComboBox cbTerrain2;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        public GameScenario Scenario;

        public frmReplaceTerrain()
        {
            this.InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Scenario.ScenarioMap.Replace((this.cbTerrain1.SelectedItem as TerrainDetail).ID, (this.cbTerrain2.SelectedItem as TerrainDetail).ID);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmReplaceTerrain_Load(object sender, EventArgs e)
        {
            foreach (TerrainDetail detail in this.Scenario.GameCommonData.AllTerrainDetails.TerrainDetails.Values)
            {
                this.cbTerrain1.Items.Add(detail);
                this.cbTerrain2.Items.Add(detail);
            }
        }

        private void InitializeComponent()
        {
            this.cbTerrain1 = new ComboBox();
            this.cbTerrain2 = new ComboBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            base.SuspendLayout();
            this.cbTerrain1.FormattingEnabled = true;
            this.cbTerrain1.Location = new Point(0x36, 12);
            this.cbTerrain1.Name = "cbTerrain1";
            this.cbTerrain1.Size = new Size(0x79, 20);
            this.cbTerrain1.TabIndex = 0;
            this.cbTerrain2.FormattingEnabled = true;
            this.cbTerrain2.Location = new Point(0xed, 12);
            this.cbTerrain2.Name = "cbTerrain2";
            this.cbTerrain2.Size = new Size(0x79, 20);
            this.cbTerrain2.TabIndex = 1;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x11, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "将";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(190, 15);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "替换为";
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Location = new Point(0xca, 0x2d);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(0x4b, 0x17);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x11b, 0x2d);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x4b, 0x17);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x177, 80);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cbTerrain2);
            base.Controls.Add(this.cbTerrain1);
            base.Name = "frmReplaceTerrain";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmReplaceTerrain";
            base.Load += new EventHandler(this.frmReplaceTerrain_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

