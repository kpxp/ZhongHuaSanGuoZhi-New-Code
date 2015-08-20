namespace MapEditor.Forms.StateForms
{
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using MapEditor.Forms.ArchitectureForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditState : Form
    {
        private Button btnResetStateAdmin;
        private Button btnStateAdmin;
        private ComboBox cbRegions;
        private CheckedListBox clbContactStates;
        private IContainer components = null;
        public GameObjects.ArchitectureDetail.State EditingState;
        private Label label1;
        private Label label2;
        private Label lbStateAdmin;
        public GameScenario Scenario;

        public frmEditState()
        {
            this.InitializeComponent();
        }

        private void btnResetStateAdmin_Click(object sender, EventArgs e)
        {
            this.EditingState.StateAdmin = null;
            this.lbStateAdmin.Text = this.EditingState.StateAdminString;
        }

        private void btnStateAdmin_Click(object sender, EventArgs e)
        {
            frmSelectArchitectureList list = new frmSelectArchitectureList();
            list.Architectures = this.Scenario.Architectures;
            list.SelectOne = true;
            list.ShowDialog();
            foreach (int num in list.IDList)
            {
                Architecture gameObject = list.Architectures.GetGameObject(num) as Architecture;
                if (gameObject != null)
                {
                    this.EditingState.StateAdmin = gameObject;
                    this.lbStateAdmin.Text = this.EditingState.StateAdminString;
                    break;
                }
            }
        }

        private void cbRegions_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameObjects.ArchitectureDetail.Region selectedItem = this.cbRegions.SelectedItem as GameObjects.ArchitectureDetail.Region;
            if (this.EditingState.LinkedRegion != null)
            {
                this.EditingState.LinkedRegion.States.Remove(this.EditingState);
            }
            this.EditingState.LinkedRegion = selectedItem;
            selectedItem.States.Add(this.EditingState);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmEditState_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.EditingState.ContactStates.Clear();
            foreach (GameObjects.ArchitectureDetail.State state in this.clbContactStates.CheckedItems)
            {
                this.EditingState.ContactStates.Add(state);
            }
        }

        private void frmEditState_Load(object sender, EventArgs e)
        {
            foreach (GameObjects.ArchitectureDetail.Region region in this.Scenario.Regions)
            {
                this.cbRegions.Items.Add(region);
            }
            this.cbRegions.SelectedItem = this.EditingState.LinkedRegion;
            this.lbStateAdmin.Text = this.EditingState.StateAdminString;
            foreach (GameObjects.ArchitectureDetail.State state in this.Scenario.States)
            {
                if (state != this.EditingState)
                {
                    this.clbContactStates.Items.Add(state, this.EditingState.ContactStates.HasGameObject(state));
                }
            }
        }

        private void InitializeComponent()
        {
            this.cbRegions = new ComboBox();
            this.label1 = new Label();
            this.lbStateAdmin = new Label();
            this.btnStateAdmin = new Button();
            this.btnResetStateAdmin = new Button();
            this.clbContactStates = new CheckedListBox();
            this.label2 = new Label();
            base.SuspendLayout();
            this.cbRegions.FormattingEnabled = true;
            this.cbRegions.Location = new Point(0x70, 0x17);
            this.cbRegions.Name = "cbRegions";
            this.cbRegions.Size = new Size(0x79, 20);
            this.cbRegions.TabIndex = 0;
            this.cbRegions.SelectedIndexChanged += new EventHandler(this.cbRegions_SelectedIndexChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x2d, 0x1c);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "所属地区";
            this.lbStateAdmin.Location = new Point(110, 0x44);
            this.lbStateAdmin.Name = "lbStateAdmin";
            this.lbStateAdmin.Size = new Size(0x7b, 0x17);
            this.lbStateAdmin.TabIndex = 2;
            this.lbStateAdmin.Text = "无";
            this.btnStateAdmin.Location = new Point(0x29, 0x3e);
            this.btnStateAdmin.Name = "btnStateAdmin";
            this.btnStateAdmin.Size = new Size(0x39, 0x17);
            this.btnStateAdmin.TabIndex = 3;
            this.btnStateAdmin.Text = "州治所";
            this.btnStateAdmin.UseVisualStyleBackColor = true;
            this.btnStateAdmin.Click += new EventHandler(this.btnStateAdmin_Click);
            this.btnResetStateAdmin.Location = new Point(0xef, 0x3f);
            this.btnResetStateAdmin.Name = "btnResetStateAdmin";
            this.btnResetStateAdmin.Size = new Size(0x3a, 0x17);
            this.btnResetStateAdmin.TabIndex = 4;
            this.btnResetStateAdmin.Text = "留空";
            this.btnResetStateAdmin.UseVisualStyleBackColor = true;
            this.btnResetStateAdmin.Click += new EventHandler(this.btnResetStateAdmin_Click);
            this.clbContactStates.CheckOnClick = true;
            this.clbContactStates.FormattingEnabled = true;
            this.clbContactStates.Location = new Point(12, 0x77);
            this.clbContactStates.Name = "clbContactStates";
            this.clbContactStates.Size = new Size(0x12a, 0x74);
            this.clbContactStates.TabIndex = 5;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x11, 0x63);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "连接州";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x142, 0xf6);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.clbContactStates);
            base.Controls.Add(this.btnResetStateAdmin);
            base.Controls.Add(this.btnStateAdmin);
            base.Controls.Add(this.lbStateAdmin);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cbRegions);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditState";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "修改州域信息";
            base.Load += new EventHandler(this.frmEditState_Load);
            base.FormClosed += new FormClosedEventHandler(this.frmEditState_FormClosed);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}

