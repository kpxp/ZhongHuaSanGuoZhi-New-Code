namespace MapEditor.Forms.MilitaryForms
{
    using GameObjects;
    using GameObjects.TroopDetail;
    using MapEditor.Forms.PersonForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditMilitary : Form
    {
        private Button btnApplyChange;
        private Button btnSelectFollowedLeader;
        private Button btnSelectFollowedLeaderInCurrentArchitecture;
        private Button btnSelectLeader;
        private Button btnSelectLeaderInCurrentArchitecture;
        private ComboBox cbKind;
        private IContainer components = null;
        public Architecture CurrentArchitecture;
        private Military editingMilitary;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        public MilitaryList Militaries;
        private TextBox tbCombativity;
        private TextBox tbExperience;
        private TextBox tbFollowedLeaderID;
        private TextBox tbLeaderExperience;
        private TextBox tbLeaderID;
        private TextBox tbMorale;
        private TextBox tbName;
        private TextBox tbQuantity;

        public frmEditMilitary()
        {
            this.InitializeComponent();
        }

        private void btnApplyChange_Click(object sender, EventArgs e)
        {
            if (this.editingMilitary != null)
            {
                try
                {
                    this.editingMilitary.Name = this.tbName.Text;
                    this.editingMilitary.Kind = this.cbKind.SelectedItem as MilitaryKind;
                    this.editingMilitary.Quantity = int.Parse(this.tbQuantity.Text);
                    this.editingMilitary.Morale = int.Parse(this.tbMorale.Text);
                    this.editingMilitary.Combativity = int.Parse(this.tbCombativity.Text);
                    this.editingMilitary.Experience = int.Parse(this.tbExperience.Text);
                    this.editingMilitary.FollowedLeaderID = int.Parse(this.tbFollowedLeaderID.Text);
                    this.editingMilitary.LeaderID = int.Parse(this.tbLeaderID.Text);
                    this.editingMilitary.LeaderExperience = int.Parse(this.tbLeaderExperience.Text);
                    base.Close();
                }
                catch
                {
                    MessageBox.Show("请输入正确格式的数据。");
                }
            }
        }

        private void btnSelectFollowedLeader_Click(object sender, EventArgs e)
        {
            if (this.editingMilitary != null)
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.editingMilitary.Scenario.Persons;
                list.SelectOne = true;
                list.ShowDialog();
                if (list.IDList.Count == 1)
                {
                    this.tbFollowedLeaderID.Text = list.IDList[0].ToString();
                }
            }
        }

        private void btnSelectFollowedLeaderInCurrentArchitecture_Click(object sender, EventArgs e)
        {
            if ((this.CurrentArchitecture != null) && (this.editingMilitary != null))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.CurrentArchitecture.Persons;
                list.SelectOne = true;
                list.ShowDialog();
                if (list.IDList.Count == 1)
                {
                    this.tbFollowedLeaderID.Text = list.IDList[0].ToString();
                }
            }
        }

        private void btnSelectLeader_Click(object sender, EventArgs e)
        {
            if (this.editingMilitary != null)
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.editingMilitary.Scenario.Persons;
                list.SelectOne = true;
                list.ShowDialog();
                if (list.IDList.Count == 1)
                {
                    this.tbLeaderID.Text = list.IDList[0].ToString();
                }
            }
        }

        private void btnSelectLeaderInCurrentArchitecture_Click(object sender, EventArgs e)
        {
            if ((this.CurrentArchitecture != null) && (this.editingMilitary != null))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.CurrentArchitecture.Persons;
                list.SelectOne = true;
                list.ShowDialog();
                if (list.IDList.Count == 1)
                {
                    this.tbLeaderID.Text = list.IDList[0].ToString();
                }
            }
        }

        private void cbKind_TextChanged(object sender, EventArgs e)
        {
            this.tbName.Text = (this.cbKind.SelectedItem as MilitaryKind).Name + "队";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmEditMilitary_Load(object sender, EventArgs e)
        {
            this.editingMilitary = this.Militaries[0] as Military;
            if (this.editingMilitary != null)
            {
                this.tbName.Text = this.editingMilitary.Name;
                foreach (MilitaryKind kind in this.editingMilitary.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
                {
                    this.cbKind.Items.Add(kind);
                }
                if (this.editingMilitary.Kind == null)
                {
                    this.cbKind.SelectedIndex = -1;
                }
                else
                {
                    this.cbKind.SelectedIndex = this.cbKind.Items.IndexOf(this.editingMilitary.Kind);
                }
                this.tbQuantity.Text = this.editingMilitary.Quantity.ToString();
                this.tbMorale.Text = this.editingMilitary.Morale.ToString();
                this.tbCombativity.Text = this.editingMilitary.Combativity.ToString();
                this.tbExperience.Text = this.editingMilitary.Experience.ToString();
                this.tbFollowedLeaderID.Text = this.editingMilitary.FollowedLeaderID.ToString();
                this.tbLeaderID.Text = this.editingMilitary.LeaderID.ToString();
                this.tbLeaderExperience.Text = this.editingMilitary.LeaderExperience.ToString();
                if (this.CurrentArchitecture == null)
                {
                    this.btnSelectFollowedLeaderInCurrentArchitecture.Visible = false;
                    this.btnSelectLeaderInCurrentArchitecture.Visible = false;
                }
            }
        }

        private void InitializeComponent()
        {
            this.label1 = new Label();
            this.tbName = new TextBox();
            this.cbKind = new ComboBox();
            this.label2 = new Label();
            this.tbQuantity = new TextBox();
            this.label3 = new Label();
            this.tbMorale = new TextBox();
            this.label4 = new Label();
            this.tbExperience = new TextBox();
            this.label5 = new Label();
            this.tbFollowedLeaderID = new TextBox();
            this.label6 = new Label();
            this.tbLeaderID = new TextBox();
            this.label7 = new Label();
            this.tbLeaderExperience = new TextBox();
            this.label8 = new Label();
            this.btnApplyChange = new Button();
            this.btnSelectFollowedLeader = new Button();
            this.btnSelectLeader = new Button();
            this.btnSelectFollowedLeaderInCurrentArchitecture = new Button();
            this.btnSelectLeaderInCurrentArchitecture = new Button();
            this.tbCombativity = new TextBox();
            this.label9 = new Label();
            base.SuspendLayout();
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "名称";
            this.tbName.Location = new Point(0x3b, 6);
            this.tbName.Name = "tbName";
            this.tbName.Size = new Size(100, 0x15);
            this.tbName.TabIndex = 1;
            this.cbKind.FormattingEnabled = true;
            this.cbKind.Location = new Point(260, 6);
            this.cbKind.Name = "cbKind";
            this.cbKind.Size = new Size(0x8f, 20);
            this.cbKind.TabIndex = 2;
            this.cbKind.TextChanged += new EventHandler(this.cbKind_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xd5, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "兵种";
            this.tbQuantity.Location = new Point(0x3b, 0x2c);
            this.tbQuantity.Name = "tbQuantity";
            this.tbQuantity.Size = new Size(100, 0x15);
            this.tbQuantity.TabIndex = 5;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 0x2f);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1d, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "兵数";
            this.tbMorale.Location = new Point(0x3b, 0x47);
            this.tbMorale.Name = "tbMorale";
            this.tbMorale.Size = new Size(100, 0x15);
            this.tbMorale.TabIndex = 7;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(12, 0x4a);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1d, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "士气";
            this.tbExperience.Location = new Point(0x3b, 0x7d);
            this.tbExperience.Name = "tbExperience";
            this.tbExperience.Size = new Size(100, 0x15);
            this.tbExperience.TabIndex = 9;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(12, 0x80);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x1d, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "经验";
            this.tbFollowedLeaderID.Location = new Point(260, 0x2c);
            this.tbFollowedLeaderID.Name = "tbFollowedLeaderID";
            this.tbFollowedLeaderID.Size = new Size(100, 0x15);
            this.tbFollowedLeaderID.TabIndex = 11;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0xc9, 0x2f);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x35, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "追随将领";
            this.tbLeaderID.Location = new Point(260, 0x47);
            this.tbLeaderID.Name = "tbLeaderID";
            this.tbLeaderID.Size = new Size(100, 0x15);
            this.tbLeaderID.TabIndex = 13;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0xc9, 0x4a);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x35, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "当前将领";
            this.tbLeaderExperience.Location = new Point(260, 0x62);
            this.tbLeaderExperience.Name = "tbLeaderExperience";
            this.tbLeaderExperience.Size = new Size(100, 0x15);
            this.tbLeaderExperience.TabIndex = 15;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0xc9, 0x65);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x29, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "信任度";
            this.btnApplyChange.Location = new Point(420, 0x97);
            this.btnApplyChange.Name = "btnApplyChange";
            this.btnApplyChange.Size = new Size(0x4b, 0x17);
            this.btnApplyChange.TabIndex = 0x10;
            this.btnApplyChange.Text = "应用修改";
            this.btnApplyChange.UseVisualStyleBackColor = true;
            this.btnApplyChange.Click += new EventHandler(this.btnApplyChange_Click);
            this.btnSelectFollowedLeader.Location = new Point(0x16e, 0x2c);
            this.btnSelectFollowedLeader.Name = "btnSelectFollowedLeader";
            this.btnSelectFollowedLeader.Size = new Size(0x2e, 0x15);
            this.btnSelectFollowedLeader.TabIndex = 0x11;
            this.btnSelectFollowedLeader.Text = "选择";
            this.btnSelectFollowedLeader.UseVisualStyleBackColor = true;
            this.btnSelectFollowedLeader.Click += new EventHandler(this.btnSelectFollowedLeader_Click);
            this.btnSelectLeader.Location = new Point(0x16e, 0x47);
            this.btnSelectLeader.Name = "btnSelectLeader";
            this.btnSelectLeader.Size = new Size(0x2e, 0x15);
            this.btnSelectLeader.TabIndex = 0x12;
            this.btnSelectLeader.Text = "选择";
            this.btnSelectLeader.UseVisualStyleBackColor = true;
            this.btnSelectLeader.Click += new EventHandler(this.btnSelectLeader_Click);
            this.btnSelectFollowedLeaderInCurrentArchitecture.Location = new Point(420, 0x2c);
            this.btnSelectFollowedLeaderInCurrentArchitecture.Name = "btnSelectFollowedLeaderInCurrentArchitecture";
            this.btnSelectFollowedLeaderInCurrentArchitecture.Size = new Size(0x2e, 0x15);
            this.btnSelectFollowedLeaderInCurrentArchitecture.TabIndex = 0x13;
            this.btnSelectFollowedLeaderInCurrentArchitecture.Text = "本城";
            this.btnSelectFollowedLeaderInCurrentArchitecture.UseVisualStyleBackColor = true;
            this.btnSelectFollowedLeaderInCurrentArchitecture.Click += new EventHandler(this.btnSelectFollowedLeaderInCurrentArchitecture_Click);
            this.btnSelectLeaderInCurrentArchitecture.Location = new Point(420, 0x47);
            this.btnSelectLeaderInCurrentArchitecture.Name = "btnSelectLeaderInCurrentArchitecture";
            this.btnSelectLeaderInCurrentArchitecture.Size = new Size(0x2e, 0x15);
            this.btnSelectLeaderInCurrentArchitecture.TabIndex = 20;
            this.btnSelectLeaderInCurrentArchitecture.Text = "本城";
            this.btnSelectLeaderInCurrentArchitecture.UseVisualStyleBackColor = true;
            this.btnSelectLeaderInCurrentArchitecture.Click += new EventHandler(this.btnSelectLeaderInCurrentArchitecture_Click);
            this.tbCombativity.Location = new Point(0x3b, 0x62);
            this.tbCombativity.Name = "tbCombativity";
            this.tbCombativity.Size = new Size(100, 0x15);
            this.tbCombativity.TabIndex = 0x16;
            this.label9.AutoSize = true;
            this.label9.Location = new Point(12, 0x65);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x1d, 12);
            this.label9.TabIndex = 0x15;
            this.label9.Text = "战意";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1f6, 0xbb);
            base.Controls.Add(this.tbCombativity);
            base.Controls.Add(this.label9);
            base.Controls.Add(this.btnSelectLeaderInCurrentArchitecture);
            base.Controls.Add(this.btnSelectFollowedLeaderInCurrentArchitecture);
            base.Controls.Add(this.btnSelectLeader);
            base.Controls.Add(this.btnSelectFollowedLeader);
            base.Controls.Add(this.btnApplyChange);
            base.Controls.Add(this.tbLeaderExperience);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.tbLeaderID);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.tbFollowedLeaderID);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.tbExperience);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.tbMorale);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.tbQuantity);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.cbKind);
            base.Controls.Add(this.tbName);
            base.Controls.Add(this.label1);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditMilitary";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "编辑编队";
            base.Load += new EventHandler(this.frmEditMilitary_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

