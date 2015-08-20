namespace MapEditor.Forms.ArchitectureForms
{
    using GameObjects;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectArchitectureList : Form
    {
        private BindingSource architectureBindingSource;
        public ArchitectureList Architectures;
        private DataGridViewTextBoxColumn areaCountDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridView dgvArchitectures;
        private DataGridViewTextBoxColumn factionStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        public List<int> IDList = new List<int>();
        private DataGridViewTextBoxColumn kindStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn RegionString;
        public Architecture SelectedArchitecture;
        public bool SelectOne = false;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn StateString;

        public frmSelectArchitectureList()
        {
            this.InitializeComponent();
        }

        private void dgvArchitectures_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvArchitectures.IsCurrentCellInEditMode)
            {
                this.SelectedArchitecture = this.dgvArchitectures.SelectedRows[0].DataBoundItem as Architecture;
                int iD = this.SelectedArchitecture.ID;
                if (this.IDList.IndexOf(iD) < 0)
                {
                    this.IDList.Add(iD);
                }
                if (this.SelectOne)
                {
                    base.Close();
                }
            }
        }

        private void dgvArchitectures_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvArchitectures.Columns[e.ColumnIndex].DataPropertyName, this.dgvArchitectures.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Architectures.Sort(comparer);
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

        private void frmSelectArchitectureList_Load(object sender, EventArgs e)
        {
            if (this.Architectures != null)
            {
                this.InitializeListData();
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            DataGridViewCellStyle style3 = new DataGridViewCellStyle();
            DataGridViewCellStyle style4 = new DataGridViewCellStyle();
            DataGridViewCellStyle style5 = new DataGridViewCellStyle();
            DataGridViewCellStyle style6 = new DataGridViewCellStyle();
            DataGridViewCellStyle style7 = new DataGridViewCellStyle();
            this.dgvArchitectures = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.kindStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.areaCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.StateString = new DataGridViewTextBoxColumn();
            this.RegionString = new DataGridViewTextBoxColumn();
            this.factionStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.architectureBindingSource = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvArchitectures).BeginInit();
            ((ISupportInitialize) this.architectureBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvArchitectures.AllowUserToAddRows = false;
            this.dgvArchitectures.AllowUserToDeleteRows = false;
            this.dgvArchitectures.AllowUserToOrderColumns = true;
            this.dgvArchitectures.AutoGenerateColumns = false;
            this.dgvArchitectures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchitectures.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.kindStringDataGridViewTextBoxColumn, this.areaCountDataGridViewTextBoxColumn, this.StateString, this.RegionString, this.factionStringDataGridViewTextBoxColumn });
            this.dgvArchitectures.DataSource = this.architectureBindingSource;
            this.dgvArchitectures.Dock = DockStyle.Fill;
            this.dgvArchitectures.Location = new Point(0, 0);
            this.dgvArchitectures.Name = "dgvArchitectures";
            this.dgvArchitectures.ReadOnly = true;
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvArchitectures.RowsDefaultCellStyle = style;
            this.dgvArchitectures.RowTemplate.Height = 0x17;
            this.dgvArchitectures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchitectures.Size = new Size(0x1bc, 0x20a);
            this.dgvArchitectures.TabIndex = 2;
            this.dgvArchitectures.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvArchitectures_ColumnHeaderMouseClick);
            this.dgvArchitectures.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvArchitectures_CellMouseDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 40;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindStringDataGridViewTextBoxColumn.DataPropertyName = "KindString";
            this.kindStringDataGridViewTextBoxColumn.HeaderText = "种类";
            this.kindStringDataGridViewTextBoxColumn.Name = "kindStringDataGridViewTextBoxColumn";
            this.kindStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaCountDataGridViewTextBoxColumn.DataPropertyName = "AreaCount";
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.areaCountDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.areaCountDataGridViewTextBoxColumn.HeaderText = "规模";
            this.areaCountDataGridViewTextBoxColumn.Name = "areaCountDataGridViewTextBoxColumn";
            this.areaCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.StateString.DataPropertyName = "StateString";
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.StateString.DefaultCellStyle = style5;
            this.StateString.HeaderText = "州名";
            this.StateString.Name = "StateString";
            this.StateString.ReadOnly = true;
            this.RegionString.DataPropertyName = "RegionString";
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.RegionString.DefaultCellStyle = style6;
            this.RegionString.HeaderText = "地域";
            this.RegionString.Name = "RegionString";
            this.RegionString.ReadOnly = true;
            this.factionStringDataGridViewTextBoxColumn.DataPropertyName = "FactionString";
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.factionStringDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.factionStringDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionStringDataGridViewTextBoxColumn.Name = "factionStringDataGridViewTextBoxColumn";
            this.factionStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.architectureBindingSource.DataSource = typeof(Architecture);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1bc, 0x20a);
            base.Controls.Add(this.dgvArchitectures);
            base.Name = "frmSelectArchitectureList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择建筑（双击）";
            base.Load += new EventHandler(this.frmSelectArchitectureList_Load);
            ((ISupportInitialize) this.dgvArchitectures).EndInit();
            ((ISupportInitialize) this.architectureBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.architectureBindingSource.DataSource = null;
            this.architectureBindingSource.DataSource = this.Architectures;
        }
    }
}

