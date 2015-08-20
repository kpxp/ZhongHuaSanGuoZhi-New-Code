namespace MapEditor.Forms
{
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using MapEditor.Forms.ArchitectureForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmRegionList : Form
    {
        private BindingSource bsRegion;
        private ContextMenuStrip cmsEditRegion;
        private IContainer components = null;
        private DataGridView dgvRegion;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn RegionCoreString;
        public GameScenario Scenario;
        private DataGridViewTextBoxColumn statesStringDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑地区核心ToolStripMenuItem;
        private ToolStripMenuItem 取消地区核心ToolStripMenuItem;
        private ToolStripMenuItem 删除地区ToolStripMenuItem;
        private ToolStripMenuItem 添加地区ToolStripMenuItem;

        public frmRegionList()
        {
            this.InitializeComponent();
        }

        private void dgvRegion_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.SelectRegionCore();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmRegionList_Load(object sender, EventArgs e)
        {
            this.InitializeListData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            this.dgvRegion = new DataGridView();
            this.bsRegion = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.statesStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.RegionCoreString = new DataGridViewTextBoxColumn();
            this.cmsEditRegion = new ContextMenuStrip(this.components);
            this.编辑地区核心ToolStripMenuItem = new ToolStripMenuItem();
            this.取消地区核心ToolStripMenuItem = new ToolStripMenuItem();
            this.添加地区ToolStripMenuItem = new ToolStripMenuItem();
            this.删除地区ToolStripMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize) this.dgvRegion).BeginInit();
            ((ISupportInitialize) this.bsRegion).BeginInit();
            this.cmsEditRegion.SuspendLayout();
            base.SuspendLayout();
            this.dgvRegion.AllowUserToAddRows = false;
            this.dgvRegion.AllowUserToDeleteRows = false;
            this.dgvRegion.AutoGenerateColumns = false;
            this.dgvRegion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegion.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.statesStringDataGridViewTextBoxColumn, this.RegionCoreString });
            this.dgvRegion.ContextMenuStrip = this.cmsEditRegion;
            this.dgvRegion.DataSource = this.bsRegion;
            this.dgvRegion.Dock = DockStyle.Fill;
            this.dgvRegion.Location = new Point(0, 0);
            this.dgvRegion.MultiSelect = false;
            this.dgvRegion.Name = "dgvRegion";
            this.dgvRegion.RowTemplate.Height = 0x17;
            this.dgvRegion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvRegion.Size = new Size(0x282, 0x18c);
            this.dgvRegion.TabIndex = 0;
            this.dgvRegion.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvRegion_CellDoubleClick);
            this.bsRegion.DataSource = typeof(GameObjects.ArchitectureDetail.Region);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.statesStringDataGridViewTextBoxColumn.DataPropertyName = "StatesString";
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.statesStringDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.statesStringDataGridViewTextBoxColumn.HeaderText = "包含州域";
            this.statesStringDataGridViewTextBoxColumn.Name = "statesStringDataGridViewTextBoxColumn";
            this.statesStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.statesStringDataGridViewTextBoxColumn.Width = 300;
            this.RegionCoreString.DataPropertyName = "RegionCoreString";
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.RegionCoreString.DefaultCellStyle = style2;
            this.RegionCoreString.HeaderText = "地区核心";
            this.RegionCoreString.Name = "RegionCoreString";
            this.RegionCoreString.ReadOnly = true;
            this.cmsEditRegion.Items.AddRange(new ToolStripItem[] { this.编辑地区核心ToolStripMenuItem, this.取消地区核心ToolStripMenuItem, this.添加地区ToolStripMenuItem, this.删除地区ToolStripMenuItem });
            this.cmsEditRegion.Name = "cmsEditRegion";
            this.cmsEditRegion.Size = new Size(0x95, 0x5c);
            this.编辑地区核心ToolStripMenuItem.Name = "编辑地区核心ToolStripMenuItem";
            this.编辑地区核心ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.编辑地区核心ToolStripMenuItem.Text = "编辑地区核心";
            this.编辑地区核心ToolStripMenuItem.Click += new EventHandler(this.编辑地区核心ToolStripMenuItem_Click);
            this.取消地区核心ToolStripMenuItem.Name = "取消地区核心ToolStripMenuItem";
            this.取消地区核心ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.取消地区核心ToolStripMenuItem.Text = "取消地区核心";
            this.取消地区核心ToolStripMenuItem.Click += new EventHandler(this.取消地区核心ToolStripMenuItem_Click);
            this.添加地区ToolStripMenuItem.Name = "添加地区ToolStripMenuItem";
            this.添加地区ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.添加地区ToolStripMenuItem.Text = "添加地区";
            this.添加地区ToolStripMenuItem.Click += new EventHandler(this.添加地区ToolStripMenuItem_Click);
            this.删除地区ToolStripMenuItem.Name = "删除地区ToolStripMenuItem";
            this.删除地区ToolStripMenuItem.Size = new Size(0x98, 0x16);
            this.删除地区ToolStripMenuItem.Text = "删除地区";
            this.删除地区ToolStripMenuItem.Click += new EventHandler(this.删除地区ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x282, 0x18c);
            base.Controls.Add(this.dgvRegion);
            base.Name = "frmRegionList";
            this.Text = "地区列表";
            base.Load += new EventHandler(this.frmRegionList_Load);
            ((ISupportInitialize) this.dgvRegion).EndInit();
            ((ISupportInitialize) this.bsRegion).EndInit();
            this.cmsEditRegion.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.bsRegion.DataSource = null;
            this.bsRegion.DataSource = this.Scenario.Regions;
        }

        private void SelectRegionCore()
        {
            if (!this.dgvRegion.IsCurrentCellInEditMode && (this.dgvRegion.SelectedRows.Count > 0))
            {
                GameObjects.ArchitectureDetail.Region dataBoundItem = this.dgvRegion.SelectedRows[0].DataBoundItem as GameObjects.ArchitectureDetail.Region;
                frmSelectArchitectureList list = new frmSelectArchitectureList();
                list.Architectures = this.Scenario.Architectures;
                list.SelectOne = true;
                list.ShowDialog();
                foreach (int num in list.IDList)
                {
                    Architecture gameObject = list.Architectures.GetGameObject(num) as Architecture;
                    if (gameObject != null)
                    {
                        dataBoundItem.RegionCore = gameObject;
                        this.dgvRegion.Invalidate();
                        break;
                    }
                }
            }
        }

        private void 编辑地区核心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SelectRegionCore();
        }

        private void 取消地区核心ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(this.dgvRegion.IsCurrentCellInEditMode || (this.dgvRegion.SelectedRows.Count <= 0)))
            {
                GameObjects.ArchitectureDetail.Region dataBoundItem = this.dgvRegion.SelectedRows[0].DataBoundItem as GameObjects.ArchitectureDetail.Region;
                dataBoundItem.RegionCore = null;
                this.dgvRegion.Invalidate();
            }
        }

        private void 删除地区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvRegion.IsCurrentCellInEditMode && (this.dgvRegion.SelectedRows.Count > 0))
            {
                GameObjects.ArchitectureDetail.Region dataBoundItem = this.dgvRegion.SelectedRows[0].DataBoundItem as GameObjects.ArchitectureDetail.Region;
                this.Scenario.Regions.Remove(dataBoundItem);
                foreach (GameObjects.ArchitectureDetail.State state in dataBoundItem.States)
                {
                    state.LinkedRegion = null;
                }
                this.RebindDataSource();
            }
        }

        private void 添加地区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GameObjects.ArchitectureDetail.Region t = new GameObjects.ArchitectureDetail.Region();
            t.ID = this.Scenario.Regions.GetFreeGameObjectID();
            this.Scenario.Regions.Add(t);
            this.RebindDataSource();
        }
    }
}

