namespace MapEditor.Forms.TreasureForms
{
    using GameObjects;
    using GameObjects.Influences;
    using MapEditor.Forms.ArchitectureForms;
    using MapEditor.Forms.PersonForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditTreasure : Form
    {
        private Button btnResetBelongedPerson;
        private Button btnResetHidePlace;
        private Button btnSetBelongedPerson;
        private Button btnSetHidePlace;
        private IContainer components = null;
        public Treasure EditingTreasure;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lbBelongedPerson;
        private Label lbHidePlace;
        private ListBox lbInfluences;
        private RichTextBox rtbDescription;
        public GameScenario Scenario;

        public frmEditTreasure()
        {
            this.InitializeComponent();
        }

        private void btnResetBelongedPerson_Click(object sender, EventArgs e)
        {
            this.EditingTreasure.BelongedPerson = null;
            this.EditingTreasure.Available = false;
            this.lbBelongedPerson.Text = this.EditingTreasure.BelongedPersonString;
        }

        private void btnResetHidePlace_Click(object sender, EventArgs e)
        {
            this.EditingTreasure.HidePlace = null;
            this.lbHidePlace.Text = this.EditingTreasure.HidePlaceString;
        }

        private void btnSetBelongedPerson_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.SelectOne = true;
            list.Persons = this.Scenario.Persons;
            list.ShowDialog();
            if (list.SelectedPerson != null)
            {
                this.EditingTreasure.BelongedPerson = list.SelectedPerson;
                this.EditingTreasure.Available = this.EditingTreasure.BelongedPerson.Available;
                this.lbBelongedPerson.Text = this.EditingTreasure.BelongedPersonString;
            }
        }

        private void btnSetHidePlace_Click(object sender, EventArgs e)
        {
            frmSelectArchitectureList list = new frmSelectArchitectureList();
            list.SelectOne = true;
            list.Architectures = this.Scenario.Architectures;
            list.ShowDialog();
            if (list.SelectedArchitecture != null)
            {
                this.EditingTreasure.HidePlace = list.SelectedArchitecture;
                this.lbHidePlace.Text = this.EditingTreasure.HidePlaceString;
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

        private void frmEditTreasure_Load(object sender, EventArgs e)
        {
            this.lbHidePlace.Text = this.EditingTreasure.HidePlaceString;
            this.lbBelongedPerson.Text = this.EditingTreasure.BelongedPersonString;
            this.rtbDescription.Text = this.EditingTreasure.Description;
            foreach (Influence influence in this.EditingTreasure.Influences.Influences.Values)
            {
                this.lbInfluences.Items.Add(influence);
            }
        }

        private void InitializeComponent()
        {
            this.btnSetHidePlace = new Button();
            this.lbHidePlace = new Label();
            this.btnSetBelongedPerson = new Button();
            this.lbBelongedPerson = new Label();
            this.rtbDescription = new RichTextBox();
            this.label1 = new Label();
            this.label2 = new Label();
            this.lbInfluences = new ListBox();
            this.label3 = new Label();
            this.label4 = new Label();
            this.btnResetHidePlace = new Button();
            this.btnResetBelongedPerson = new Button();
            base.SuspendLayout();
            this.btnSetHidePlace.Location = new Point(0x13, 12);
            this.btnSetHidePlace.Name = "btnSetHidePlace";
            this.btnSetHidePlace.Size = new Size(0x4b, 0x17);
            this.btnSetHidePlace.TabIndex = 0;
            this.btnSetHidePlace.Text = "隐藏地点";
            this.btnSetHidePlace.UseVisualStyleBackColor = true;
            this.btnSetHidePlace.Click += new EventHandler(this.btnSetHidePlace_Click);
            this.lbHidePlace.AutoSize = true;
            this.lbHidePlace.Location = new Point(0x76, 0x11);
            this.lbHidePlace.Name = "lbHidePlace";
            this.lbHidePlace.Size = new Size(0x1d, 12);
            this.lbHidePlace.TabIndex = 1;
            this.lbHidePlace.Text = "----";
            this.btnSetBelongedPerson.Location = new Point(0x13, 0x29);
            this.btnSetBelongedPerson.Name = "btnSetBelongedPerson";
            this.btnSetBelongedPerson.Size = new Size(0x4b, 0x17);
            this.btnSetBelongedPerson.TabIndex = 2;
            this.btnSetBelongedPerson.Text = "所属人物";
            this.btnSetBelongedPerson.UseVisualStyleBackColor = true;
            this.btnSetBelongedPerson.Click += new EventHandler(this.btnSetBelongedPerson_Click);
            this.lbBelongedPerson.AutoSize = true;
            this.lbBelongedPerson.Location = new Point(0x77, 0x2e);
            this.lbBelongedPerson.Name = "lbBelongedPerson";
            this.lbBelongedPerson.Size = new Size(0x1d, 12);
            this.lbBelongedPerson.TabIndex = 3;
            this.lbBelongedPerson.Text = "----";
            this.rtbDescription.Location = new Point(0x11, 0x74);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new Size(0x163, 0x55);
            this.rtbDescription.TabIndex = 4;
            this.rtbDescription.Text = "";
            this.rtbDescription.TextChanged += new EventHandler(this.rtbDescription_TextChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x13, 0x62);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "简介";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x13, 0xd7);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "效果";
            this.lbInfluences.FormattingEnabled = true;
            this.lbInfluences.ItemHeight = 12;
            this.lbInfluences.Location = new Point(0x11, 0xf1);
            this.lbInfluences.Name = "lbInfluences";
            this.lbInfluences.Size = new Size(0x163, 0x58);
            this.lbInfluences.TabIndex = 7;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(15, 0x158);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x131, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "此处仅供察看，要修改具体效果还请在数据库中直接修改";
            this.label4.AutoSize = true;
            this.label4.Location = new Point(20, 0x4a);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x155, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "如果为未登场宝物设置所属人物，则宝物将随人物的登场而出现";
            this.btnResetHidePlace.Location = new Point(0xaf, 12);
            this.btnResetHidePlace.Name = "btnResetHidePlace";
            this.btnResetHidePlace.Size = new Size(0x4b, 0x17);
            this.btnResetHidePlace.TabIndex = 10;
            this.btnResetHidePlace.Text = "置空";
            this.btnResetHidePlace.UseVisualStyleBackColor = true;
            this.btnResetHidePlace.Click += new EventHandler(this.btnResetHidePlace_Click);
            this.btnResetBelongedPerson.Location = new Point(0xaf, 0x29);
            this.btnResetBelongedPerson.Name = "btnResetBelongedPerson";
            this.btnResetBelongedPerson.Size = new Size(0x4b, 0x17);
            this.btnResetBelongedPerson.TabIndex = 11;
            this.btnResetBelongedPerson.Text = "置空";
            this.btnResetBelongedPerson.UseVisualStyleBackColor = true;
            this.btnResetBelongedPerson.Click += new EventHandler(this.btnResetBelongedPerson_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x183, 0x170);
            base.Controls.Add(this.btnResetBelongedPerson);
            base.Controls.Add(this.btnResetHidePlace);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.lbInfluences);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.rtbDescription);
            base.Controls.Add(this.lbBelongedPerson);
            base.Controls.Add(this.btnSetBelongedPerson);
            base.Controls.Add(this.lbHidePlace);
            base.Controls.Add(this.btnSetHidePlace);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditTreasure";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "编辑宝物";
            base.Load += new EventHandler(this.frmEditTreasure_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void rtbDescription_TextChanged(object sender, EventArgs e)
        {
            this.EditingTreasure.Description = this.rtbDescription.Text;
        }
    }
}

