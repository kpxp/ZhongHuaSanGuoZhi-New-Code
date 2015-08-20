namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor;
    using MapEditor.Forms.TroopEventForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmTroopEventList : Form
    {
        private BindingSource bsTroopEventList;
        private ContextMenuStrip cmsEditTroopEvent;
        private IContainer components = null;
        private DataGridView dgvTroopEventList;
        private DataGridViewTextBoxColumn happenChanceDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn happenedDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        public formMapEditor MainForm;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn repeatableDataGridViewCheckBoxColumn;
        private ToolStripMenuItem 编辑部队事件ToolStripMenuItem;
        private ToolStripMenuItem 删除部队事件ToolStripMenuItem;
        private ToolStripMenuItem 添加部队事件ToolStripMenuItem;

        public frmTroopEventList()
        {
            this.InitializeComponent();
        }

        private void dgvTroopEventList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.EditTroopEvent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditTroopEvent()
        {
            if (!(this.dgvTroopEventList.IsCurrentCellInEditMode || (this.dgvTroopEventList.SelectedRows.Count <= 0)))
            {
                frmEditTroopEvent event2 = new frmEditTroopEvent();
                event2.Scenario = this.MainForm.Scenario;
                event2.EditingEvent = this.dgvTroopEventList.SelectedRows[0].DataBoundItem as TroopEvent;
                event2.ShowDialog();
                this.dgvTroopEventList.Invalidate();
            }
        }

        private void frmTroopEventList_Load(object sender, EventArgs e)
        {
            this.InitializeListData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.dgvTroopEventList = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.happenedDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.repeatableDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.happenChanceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.cmsEditTroopEvent = new ContextMenuStrip(this.components);
            this.编辑部队事件ToolStripMenuItem = new ToolStripMenuItem();
            this.添加部队事件ToolStripMenuItem = new ToolStripMenuItem();
            this.删除部队事件ToolStripMenuItem = new ToolStripMenuItem();
            this.bsTroopEventList = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvTroopEventList).BeginInit();
            this.cmsEditTroopEvent.SuspendLayout();
            ((ISupportInitialize) this.bsTroopEventList).BeginInit();
            base.SuspendLayout();
            this.dgvTroopEventList.AllowUserToAddRows = false;
            this.dgvTroopEventList.AllowUserToDeleteRows = false;
            this.dgvTroopEventList.AutoGenerateColumns = false;
            this.dgvTroopEventList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTroopEventList.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.happenedDataGridViewCheckBoxColumn, this.repeatableDataGridViewCheckBoxColumn, this.happenChanceDataGridViewTextBoxColumn });
            this.dgvTroopEventList.ContextMenuStrip = this.cmsEditTroopEvent;
            this.dgvTroopEventList.DataSource = this.bsTroopEventList;
            this.dgvTroopEventList.Dock = DockStyle.Fill;
            this.dgvTroopEventList.Location = new Point(0, 0);
            this.dgvTroopEventList.MultiSelect = false;
            this.dgvTroopEventList.Name = "dgvTroopEventList";
            this.dgvTroopEventList.RowTemplate.Height = 0x17;
            this.dgvTroopEventList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTroopEventList.Size = new Size(0x2fb, 0x231);
            this.dgvTroopEventList.TabIndex = 0;
            this.dgvTroopEventList.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvTroopEventList_CellDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 120;
            this.happenedDataGridViewCheckBoxColumn.DataPropertyName = "Happened";
            this.happenedDataGridViewCheckBoxColumn.HeaderText = "已发生过";
            this.happenedDataGridViewCheckBoxColumn.Name = "happenedDataGridViewCheckBoxColumn";
            this.happenedDataGridViewCheckBoxColumn.Width = 80;
            this.repeatableDataGridViewCheckBoxColumn.DataPropertyName = "Repeatable";
            this.repeatableDataGridViewCheckBoxColumn.HeaderText = "可重复";
            this.repeatableDataGridViewCheckBoxColumn.Name = "repeatableDataGridViewCheckBoxColumn";
            this.repeatableDataGridViewCheckBoxColumn.Width = 80;
            this.happenChanceDataGridViewTextBoxColumn.DataPropertyName = "HappenChance";
            this.happenChanceDataGridViewTextBoxColumn.HeaderText = "发生概率";
            this.happenChanceDataGridViewTextBoxColumn.Name = "happenChanceDataGridViewTextBoxColumn";
            this.cmsEditTroopEvent.Items.AddRange(new ToolStripItem[] { this.编辑部队事件ToolStripMenuItem, this.添加部队事件ToolStripMenuItem, this.删除部队事件ToolStripMenuItem });
            this.cmsEditTroopEvent.Name = "cmsEditTroopEvent";
            this.cmsEditTroopEvent.Size = new Size(0x95, 70);
            this.编辑部队事件ToolStripMenuItem.Name = "编辑部队事件ToolStripMenuItem";
            this.编辑部队事件ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.编辑部队事件ToolStripMenuItem.Text = "编辑部队事件";
            this.编辑部队事件ToolStripMenuItem.Click += new EventHandler(this.编辑部队事件ToolStripMenuItem_Click);
            this.添加部队事件ToolStripMenuItem.Name = "添加部队事件ToolStripMenuItem";
            this.添加部队事件ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.添加部队事件ToolStripMenuItem.Text = "添加部队事件";
            this.添加部队事件ToolStripMenuItem.Click += new EventHandler(this.添加部队事件ToolStripMenuItem_Click);
            this.删除部队事件ToolStripMenuItem.Name = "删除部队事件ToolStripMenuItem";
            this.删除部队事件ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.删除部队事件ToolStripMenuItem.Text = "删除部队事件";
            this.删除部队事件ToolStripMenuItem.Click += new EventHandler(this.删除部队事件ToolStripMenuItem_Click);
            this.bsTroopEventList.DataSource = typeof(TroopEvent);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2fb, 0x231);
            base.Controls.Add(this.dgvTroopEventList);
            base.Name = "frmTroopEventList";
            base.ShowInTaskbar = false;
            this.Text = "部队事件列表";
            base.Load += new EventHandler(this.frmTroopEventList_Load);
            ((ISupportInitialize) this.dgvTroopEventList).EndInit();
            this.cmsEditTroopEvent.ResumeLayout(false);
            ((ISupportInitialize) this.bsTroopEventList).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.bsTroopEventList.DataSource = null;
            this.bsTroopEventList.DataSource = this.MainForm.Scenario.TroopEvents;
        }

        private void 编辑部队事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditTroopEvent();
        }

        private void 删除部队事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.dgvTroopEventList.IsCurrentCellInEditMode || (this.dgvTroopEventList.SelectedRows.Count <= 0)))
            {
                TroopEvent dataBoundItem = this.dgvTroopEventList.SelectedRows[0].DataBoundItem as TroopEvent;
                this.MainForm.Scenario.TroopEvents.Remove(dataBoundItem);
                this.RebindDataSource();
            }
        }

        private void 添加部队事件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TroopEvent t = new TroopEvent();
            t.Scenario = this.MainForm.Scenario;
            t.ID = this.MainForm.Scenario.TroopEvents.GetFreeGameObjectID();
            this.MainForm.Scenario.TroopEvents.Add(t);
            this.RebindDataSource();
        }
    }
}

