namespace MapEditor.Forms.TroopEventForms
{
    using GameObjects;
    using MapEditor.Forms.PersonForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditEventDialog : Form
    {
        private Button btnAnyPerson;
        private Button button1;
        private IContainer components = null;
        public PersonDialog Dialog;
        private Label label1;
        private Label lbPerson;
        public GameScenario Scenario;
        private TextBox tbText;

        public frmEditEventDialog()
        {
            this.InitializeComponent();
        }

        private void btnAnyPerson_Click(object sender, EventArgs e)
        {
            this.Dialog.SpeakingPerson = null;
            this.lbPerson.Text = "任意人物";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.Scenario.Persons;
            list.SelectOne = true;
            list.ShowDialog();
            if (list.IDList.Count == 1)
            {
                this.Dialog.SpeakingPerson = this.Scenario.Persons.GetGameObject(list.IDList[0]) as Person;
                if (this.Dialog.SpeakingPerson != null)
                {
                    this.lbPerson.Text = this.Dialog.SpeakingPerson.Name;
                }
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

        private void frmEditEventDialog_Load(object sender, EventArgs e)
        {
            if (this.Dialog.SpeakingPerson != null)
            {
                this.lbPerson.Text = this.Dialog.SpeakingPerson.Name;
            }
            else
            {
                this.lbPerson.Text = "任意人物";
            }
            this.tbText.Text = this.Dialog.Text;
        }

        private void InitializeComponent()
        {
            this.lbPerson = new Label();
            this.button1 = new Button();
            this.tbText = new TextBox();
            this.label1 = new Label();
            this.btnAnyPerson = new Button();
            base.SuspendLayout();
            this.lbPerson.AutoSize = true;
            this.lbPerson.Location = new Point(12, 0x11);
            this.lbPerson.Name = "lbPerson";
            this.lbPerson.Size = new Size(0x1d, 12);
            this.lbPerson.TabIndex = 0;
            this.lbPerson.Text = "人物";
            this.button1.Location = new Point(0x45, 12);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 1;
            this.button1.Text = "选择人物";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.tbText.Location = new Point(14, 0x4b);
            this.tbText.Name = "tbText";
            this.tbText.Size = new Size(0x283, 0x15);
            this.tbText.TabIndex = 2;
            this.tbText.TextChanged += new EventHandler(this.tbText_TextChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0xdd, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "人物对话（不能包含空格，也不能为空）";
            this.btnAnyPerson.Location = new Point(0x9e, 12);
            this.btnAnyPerson.Name = "btnAnyPerson";
            this.btnAnyPerson.Size = new Size(0x4b, 0x17);
            this.btnAnyPerson.TabIndex = 4;
            this.btnAnyPerson.Text = "任意人物";
            this.btnAnyPerson.UseVisualStyleBackColor = true;
            this.btnAnyPerson.Click += new EventHandler(this.btnAnyPerson_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x29d, 0x72);
            base.Controls.Add(this.btnAnyPerson);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.tbText);
            base.Controls.Add(this.button1);
            base.Controls.Add(this.lbPerson);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditEventDialog";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "修改部队事件对话";
            base.Load += new EventHandler(this.frmEditEventDialog_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            this.Dialog.Text = this.tbText.Text.Trim();
        }
    }
}

