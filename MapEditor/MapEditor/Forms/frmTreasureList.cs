namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor.Forms.TreasureForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmTreasureList : Form
    {
        private DataGridViewTextBoxColumn appearYearDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn availableDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn belongedPersonStringDataGridViewTextBoxColumn;
        private BindingSource bsTreasure;
        private ContextMenuStrip cmsTreasure;
        private IContainer components = null;
        private DataGridView dgvTreasure;
        private DataGridViewTextBoxColumn hidePlaceStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn picDataGridViewTextBoxColumn;
        public GameScenario Scenario;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn worthDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑宝物ToolStripMenuItem;
        private ToolStripMenuItem 删除宝物ToolStripMenuItem;
        private ToolStripMenuItem 添加宝物ToolStripMenuItem;

        public frmTreasureList()
        {
            this.InitializeComponent();
        }

        private void dgvTreasure_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.EditTreasure();
        }

        private void dgvTreasureList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvTreasure.Columns[e.ColumnIndex].DataPropertyName, this.dgvTreasure.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Scenario.Treasures.Sort(comparer);
            this.RebindDataSource();
            this.smalltobig = !this.smalltobig;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void EditTreasure()
        {
            if (!(this.dgvTreasure.IsCurrentCellInEditMode || (this.dgvTreasure.SelectedRows.Count <= 0)))
            {
                frmEditTreasure treasure = new frmEditTreasure();
                treasure.Scenario = this.Scenario;
                treasure.EditingTreasure = this.dgvTreasure.SelectedRows[0].DataBoundItem as Treasure;
                treasure.ShowDialog();
                this.dgvTreasure.Invalidate();
            }
        }

        private void frmTreasureList_Load(object sender, EventArgs e)
        {
            this.InitializeListData();
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            this.dgvTreasure = new DataGridView();
            this.cmsTreasure = new ContextMenuStrip(this.components);
            this.编辑宝物ToolStripMenuItem = new ToolStripMenuItem();
            this.添加宝物ToolStripMenuItem = new ToolStripMenuItem();
            this.删除宝物ToolStripMenuItem = new ToolStripMenuItem();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.picDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.worthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.appearYearDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.availableDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.hidePlaceStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.belongedPersonStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.bsTreasure = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvTreasure).BeginInit();
            this.cmsTreasure.SuspendLayout();
            ((ISupportInitialize) this.bsTreasure).BeginInit();
            base.SuspendLayout();
            this.dgvTreasure.AllowUserToAddRows = false;
            this.dgvTreasure.AllowUserToDeleteRows = false;
            this.dgvTreasure.AutoGenerateColumns = false;
            this.dgvTreasure.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreasure.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.picDataGridViewTextBoxColumn, this.worthDataGridViewTextBoxColumn, this.appearYearDataGridViewTextBoxColumn, this.availableDataGridViewCheckBoxColumn, this.hidePlaceStringDataGridViewTextBoxColumn, this.belongedPersonStringDataGridViewTextBoxColumn });
            this.dgvTreasure.ContextMenuStrip = this.cmsTreasure;
            this.dgvTreasure.DataSource = this.bsTreasure;
            this.dgvTreasure.Dock = DockStyle.Fill;
            this.dgvTreasure.Location = new Point(0, 0);
            this.dgvTreasure.Name = "dgvTreasure";
            this.dgvTreasure.RowTemplate.Height = 0x17;
            this.dgvTreasure.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreasure.Size = new Size(880, 0x216);
            this.dgvTreasure.TabIndex = 0;
            this.dgvTreasure.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvTreasureList_ColumnHeaderMouseClick);
            this.dgvTreasure.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvTreasure_CellMouseDoubleClick);
            this.cmsTreasure.Items.AddRange(new ToolStripItem[] { this.编辑宝物ToolStripMenuItem, this.添加宝物ToolStripMenuItem, this.删除宝物ToolStripMenuItem });
            this.cmsTreasure.Name = "cmsTreasure";
            this.cmsTreasure.Size = new Size(0x8d, 70);
            this.编辑宝物ToolStripMenuItem.Name = "编辑宝物ToolStripMenuItem";
            this.编辑宝物ToolStripMenuItem.Size = new Size(140, 0x16);
            this.编辑宝物ToolStripMenuItem.Text = "编辑宝物";
            this.编辑宝物ToolStripMenuItem.Click += new EventHandler(this.编辑宝物ToolStripMenuItem_Click);
            this.添加宝物ToolStripMenuItem.Name = "添加宝物ToolStripMenuItem";
            this.添加宝物ToolStripMenuItem.Size = new Size(140, 0x16);
            this.添加宝物ToolStripMenuItem.Text = "添加宝物";
            this.添加宝物ToolStripMenuItem.Click += new EventHandler(this.添加宝物ToolStripMenuItem_Click);
            this.删除宝物ToolStripMenuItem.Name = "删除宝物ToolStripMenuItem";
            this.删除宝物ToolStripMenuItem.Size = new Size(140, 0x16);
            this.删除宝物ToolStripMenuItem.Text = "删除宝物";
            this.删除宝物ToolStripMenuItem.Click += new EventHandler(this.删除宝物ToolStripMenuItem_Click);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.picDataGridViewTextBoxColumn.DataPropertyName = "Pic";
            this.picDataGridViewTextBoxColumn.HeaderText = "图片编号";
            this.picDataGridViewTextBoxColumn.Name = "picDataGridViewTextBoxColumn";
            this.picDataGridViewTextBoxColumn.Width = 80;
            this.worthDataGridViewTextBoxColumn.DataPropertyName = "Worth";
            this.worthDataGridViewTextBoxColumn.HeaderText = "价值";
            this.worthDataGridViewTextBoxColumn.Name = "worthDataGridViewTextBoxColumn";
            this.worthDataGridViewTextBoxColumn.Width = 60;
            this.appearYearDataGridViewTextBoxColumn.DataPropertyName = "AppearYear";
            this.appearYearDataGridViewTextBoxColumn.HeaderText = "出场年";
            this.appearYearDataGridViewTextBoxColumn.Name = "appearYearDataGridViewTextBoxColumn";
            this.appearYearDataGridViewTextBoxColumn.Width = 70;
            this.availableDataGridViewCheckBoxColumn.DataPropertyName = "Available";
            this.availableDataGridViewCheckBoxColumn.HeaderText = "已出场";
            this.availableDataGridViewCheckBoxColumn.Name = "availableDataGridViewCheckBoxColumn";
            this.availableDataGridViewCheckBoxColumn.Width = 70;
            this.hidePlaceStringDataGridViewTextBoxColumn.DataPropertyName = "HidePlaceString";
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.hidePlaceStringDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.hidePlaceStringDataGridViewTextBoxColumn.HeaderText = "隐藏地点";
            this.hidePlaceStringDataGridViewTextBoxColumn.Name = "hidePlaceStringDataGridViewTextBoxColumn";
            this.hidePlaceStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.belongedPersonStringDataGridViewTextBoxColumn.DataPropertyName = "BelongedPersonString";
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.belongedPersonStringDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.belongedPersonStringDataGridViewTextBoxColumn.HeaderText = "所属人物";
            this.belongedPersonStringDataGridViewTextBoxColumn.Name = "belongedPersonStringDataGridViewTextBoxColumn";
            this.belongedPersonStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.bsTreasure.DataSource = typeof(Treasure);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(880, 0x216);
            base.Controls.Add(this.dgvTreasure);
            base.Name = "frmTreasureList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "宝物列表";
            base.Load += new EventHandler(this.frmTreasureList_Load);
            ((ISupportInitialize) this.dgvTreasure).EndInit();
            this.cmsTreasure.ResumeLayout(false);
            ((ISupportInitialize) this.bsTreasure).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.bsTreasure.DataSource = null;
            this.bsTreasure.DataSource = this.Scenario.Treasures;
        }

        private void 编辑宝物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.EditTreasure();
        }

        private void 删除宝物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvTreasure.IsCurrentCellInEditMode && (this.dgvTreasure.SelectedRows.Count > 0))
            {
                Treasure dataBoundItem = this.dgvTreasure.SelectedRows[0].DataBoundItem as Treasure;
                if (dataBoundItem.BelongedPerson != null)
                {
                    dataBoundItem.BelongedPerson.LoseTreasure(dataBoundItem);
                }
                this.Scenario.Treasures.Remove(dataBoundItem);
                this.RebindDataSource();
            }
        }

        private void 添加宝物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Treasure t = new Treasure();
            t.ID = this.Scenario.Treasures.GetFreeGameObjectID();
            this.Scenario.Treasures.Add(t);
            this.RebindDataSource();
        }
    }
}

