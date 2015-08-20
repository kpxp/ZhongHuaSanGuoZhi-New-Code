namespace MapEditor.Forms
{
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using MapEditor.Forms.StateForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmStateList : Form
    {
        private BindingSource bsState;
        private ContextMenuStrip cmsEditState;
        private IContainer components = null;
        private DataGridViewTextBoxColumn ContactStatesDisplayString;
        private DataGridView dgvState;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn linkedRegionStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        public GameScenario Scenario;
        private DataGridViewTextBoxColumn stateAdminStringDataGridViewTextBoxColumn;
        private ToolStripMenuItem 删除州域ToolStripMenuItem;
        private ToolStripMenuItem 添加州域ToolStripMenuItem;
        private ToolStripMenuItem 修改州域ToolStripMenuItem;

        public frmStateList()
        {
            this.InitializeComponent();
        }

        private void dgvState_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.EditState();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditState()
        {
            if (!(this.dgvState.IsCurrentCellInEditMode || (this.dgvState.SelectedRows.Count <= 0)))
            {
                frmEditState state = new frmEditState();
                state.Scenario = this.Scenario;
                state.EditingState = this.dgvState.SelectedRows[0].DataBoundItem as GameObjects.ArchitectureDetail.State;
                state.ShowDialog();
                this.dgvState.Invalidate();
            }
        }

        private void frmStateList_Load(object sender, EventArgs e)
        {
            this.InitializeListData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            this.dgvState = new DataGridView();
            this.cmsEditState = new ContextMenuStrip(this.components);
            this.修改州域ToolStripMenuItem = new ToolStripMenuItem();
            this.bsState = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.linkedRegionStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.stateAdminStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.ContactStatesDisplayString = new DataGridViewTextBoxColumn();
            this.添加州域ToolStripMenuItem = new ToolStripMenuItem();
            this.删除州域ToolStripMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize) this.dgvState).BeginInit();
            this.cmsEditState.SuspendLayout();
            ((ISupportInitialize) this.bsState).BeginInit();
            base.SuspendLayout();
            this.dgvState.AllowUserToAddRows = false;
            this.dgvState.AllowUserToDeleteRows = false;
            this.dgvState.AutoGenerateColumns = false;
            this.dgvState.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvState.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.linkedRegionStringDataGridViewTextBoxColumn, this.stateAdminStringDataGridViewTextBoxColumn, this.ContactStatesDisplayString });
            this.dgvState.ContextMenuStrip = this.cmsEditState;
            this.dgvState.DataSource = this.bsState;
            this.dgvState.Dock = DockStyle.Fill;
            this.dgvState.Location = new Point(0, 0);
            this.dgvState.MultiSelect = false;
            this.dgvState.Name = "dgvState";
            this.dgvState.RowTemplate.Height = 0x17;
            this.dgvState.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvState.Size = new Size(0x287, 0x1b9);
            this.dgvState.TabIndex = 0;
            this.dgvState.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvState_CellMouseDoubleClick);
            this.cmsEditState.Items.AddRange(new ToolStripItem[] { this.修改州域ToolStripMenuItem, this.添加州域ToolStripMenuItem, this.删除州域ToolStripMenuItem });
            this.cmsEditState.Name = "cmsEditState";
            this.cmsEditState.Size = new Size(0x99, 0x5c);
            this.修改州域ToolStripMenuItem.Name = "修改州域ToolStripMenuItem";
            this.修改州域ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.修改州域ToolStripMenuItem.Text = "修改州域";
            this.修改州域ToolStripMenuItem.Click += new EventHandler(this.修改州域ToolStripMenuItem_Click);
            this.bsState.DataSource = typeof(GameObjects.ArchitectureDetail.State);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.linkedRegionStringDataGridViewTextBoxColumn.DataPropertyName = "LinkedRegionString";
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.linkedRegionStringDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.linkedRegionStringDataGridViewTextBoxColumn.HeaderText = "所属地区";
            this.linkedRegionStringDataGridViewTextBoxColumn.Name = "linkedRegionStringDataGridViewTextBoxColumn";
            this.linkedRegionStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.stateAdminStringDataGridViewTextBoxColumn.DataPropertyName = "StateAdminString";
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.stateAdminStringDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.stateAdminStringDataGridViewTextBoxColumn.HeaderText = "州治所";
            this.stateAdminStringDataGridViewTextBoxColumn.Name = "stateAdminStringDataGridViewTextBoxColumn";
            this.stateAdminStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.ContactStatesDisplayString.DataPropertyName = "ContactStatesDisplayString";
            style3.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.ContactStatesDisplayString.DefaultCellStyle = style3;
            this.ContactStatesDisplayString.HeaderText = "连接州域";
            this.ContactStatesDisplayString.Name = "ContactStatesDisplayString";
            this.ContactStatesDisplayString.ReadOnly = true;
            this.ContactStatesDisplayString.Width = 200;
            this.添加州域ToolStripMenuItem.Name = "添加州域ToolStripMenuItem";
            this.添加州域ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.添加州域ToolStripMenuItem.Text = "添加州域";
            this.添加州域ToolStripMenuItem.Click += new EventHandler(this.添加州域ToolStripMenuItem_Click);
            this.删除州域ToolStripMenuItem.Name = "删除州域ToolStripMenuItem";
            this.删除州域ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.删除州域ToolStripMenuItem.Text = "删除州域";
            this.删除州域ToolStripMenuItem.Click += new EventHandler(this.删除州域ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x287, 0x1b9);
            base.Controls.Add(this.dgvState);
            base.Name = "frmStateList";
            this.Text = "编辑州域";
            base.Load += new EventHandler(this.frmStateList_Load);
            ((ISupportInitialize) this.dgvState).EndInit();
            this.cmsEditState.ResumeLayout(false);
            ((ISupportInitialize) this.bsState).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.bsState.DataSource = null;
            this.bsState.DataSource = this.Scenario.States;
        }

        private void 删除州域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvState.IsCurrentCellInEditMode && (this.dgvState.SelectedRows.Count > 0))
            {
                GameObjects.ArchitectureDetail.State dataBoundItem = this.dgvState.SelectedRows[0].DataBoundItem as GameObjects.ArchitectureDetail.State;
                this.Scenario.States.Remove(dataBoundItem);
                if (dataBoundItem.LinkedRegion != null)
                {
                    dataBoundItem.LinkedRegion.States.Remove(dataBoundItem);
                }
                foreach (GameObjects.ArchitectureDetail.State state2 in this.Scenario.States)
                {
                    state2.ContactStates.Remove(dataBoundItem);
                }
                this.RebindDataSource();
            }
        }

        private void 添加州域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameObjects.ArchitectureDetail.State t = new GameObjects.ArchitectureDetail.State();
            t.ID = this.Scenario.States.GetFreeGameObjectID();
            this.Scenario.States.Add(t);
            this.RebindDataSource();
        }

        private void 修改州域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditState();
        }
    }
}

