namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor;
    using MapEditor.Forms.ArchitectureForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmArchitectureList : Form
    {
        private DataGridViewTextBoxColumn AgricultureCeiling;
        private DataGridViewTextBoxColumn agricultureDataGridViewTextBoxColumn;
        private BindingSource architectureBindingSource;
        public ArchitectureList Architectures;
        private DataGridViewTextBoxColumn areaCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn armyExperienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn armyMoraleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn armyQuantityDataGridViewTextBoxColumn;
        private ContextMenuStrip cmsEditArchitecture;
        private DataGridViewTextBoxColumn CommerceCeiling;
        private DataGridViewTextBoxColumn commerceDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridView dgvArchitectures;
        private DataGridViewTextBoxColumn Domination;
        private DataGridViewTextBoxColumn DominationCeiling;
        private DataGridViewTextBoxColumn Endurance;
        private DataGridViewTextBoxColumn EnduranceCeiling;
        private DataGridViewTextBoxColumn factionStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Food;
        private DataGridViewTextBoxColumn Fund;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kindDataGridViewTextBoxColumn;
        public formMapEditor MainForm;
        private DataGridViewTextBoxColumn MoraleCeiling;
        private DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn RegionString;
        private DataGridViewTextBoxColumn securityDataGridViewTextBoxColumn;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn StateString;
        private DataGridViewTextBoxColumn TechnologyCeiling;
        private DataGridViewTextBoxColumn technologyDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑选定建筑ToolStripMenuItem;

        public frmArchitectureList()
        {
            this.InitializeComponent();
        }

        private void dgvArchitectures_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvArchitectures.IsCurrentCellInEditMode)
            {
                this.EditArchitectures();
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

        private void EditArchitectures()
        {
            ArchitectureList list = new ArchitectureList();
            for (int i = 0; i < this.dgvArchitectures.SelectedRows.Count; i++)
            {
                list.Add(this.Architectures[this.dgvArchitectures.SelectedRows[i].Index]);
            }
            frmEditArchitecture architecture = new frmEditArchitecture();
            architecture.MainForm = this.MainForm;
            architecture.Architectures = list;
            architecture.ShowDialog();
            this.dgvArchitectures.Invalidate();
        }

        private void frmArchitectureList_Load(object sender, EventArgs e)
        {
            this.InitializeListData();
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
            DataGridViewCellStyle style8 = new DataGridViewCellStyle();
            DataGridViewCellStyle style9 = new DataGridViewCellStyle();
            DataGridViewCellStyle style10 = new DataGridViewCellStyle();
            DataGridViewCellStyle style11 = new DataGridViewCellStyle();
            DataGridViewCellStyle style12 = new DataGridViewCellStyle();
            DataGridViewCellStyle style13 = new DataGridViewCellStyle();
            DataGridViewCellStyle style14 = new DataGridViewCellStyle();
            DataGridViewCellStyle style15 = new DataGridViewCellStyle();
            DataGridViewCellStyle style16 = new DataGridViewCellStyle();
            DataGridViewCellStyle style17 = new DataGridViewCellStyle();
            DataGridViewCellStyle style18 = new DataGridViewCellStyle();
            DataGridViewCellStyle style19 = new DataGridViewCellStyle();
            DataGridViewCellStyle style20 = new DataGridViewCellStyle();
            this.dgvArchitectures = new DataGridView();
            this.cmsEditArchitecture = new ContextMenuStrip(this.components);
            this.编辑选定建筑ToolStripMenuItem = new ToolStripMenuItem();
            this.architectureBindingSource = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.kindDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.areaCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.StateString = new DataGridViewTextBoxColumn();
            this.RegionString = new DataGridViewTextBoxColumn();
            this.factionStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.Fund = new DataGridViewTextBoxColumn();
            this.Food = new DataGridViewTextBoxColumn();
            this.agricultureDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.AgricultureCeiling = new DataGridViewTextBoxColumn();
            this.commerceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.CommerceCeiling = new DataGridViewTextBoxColumn();
            this.technologyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.TechnologyCeiling = new DataGridViewTextBoxColumn();
            this.Domination = new DataGridViewTextBoxColumn();
            this.DominationCeiling = new DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.MoraleCeiling = new DataGridViewTextBoxColumn();
            this.Endurance = new DataGridViewTextBoxColumn();
            this.EnduranceCeiling = new DataGridViewTextBoxColumn();
            this.armyQuantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dgvArchitectures).BeginInit();
            this.cmsEditArchitecture.SuspendLayout();
            ((ISupportInitialize) this.architectureBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvArchitectures.AllowUserToAddRows = false;
            this.dgvArchitectures.AllowUserToDeleteRows = false;
            this.dgvArchitectures.AllowUserToOrderColumns = true;
            this.dgvArchitectures.AutoGenerateColumns = false;
            this.dgvArchitectures.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArchitectures.Columns.AddRange(new DataGridViewColumn[] { 
                this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.kindDataGridViewTextBoxColumn, this.areaCountDataGridViewTextBoxColumn, this.StateString, this.RegionString, this.factionStringDataGridViewTextBoxColumn, this.populationDataGridViewTextBoxColumn, this.Fund, this.Food, this.agricultureDataGridViewTextBoxColumn, this.AgricultureCeiling, this.commerceDataGridViewTextBoxColumn, this.CommerceCeiling, this.technologyDataGridViewTextBoxColumn, this.TechnologyCeiling, 
                this.Domination, this.DominationCeiling, this.moraleDataGridViewTextBoxColumn, this.MoraleCeiling, this.Endurance, this.EnduranceCeiling, this.armyQuantityDataGridViewTextBoxColumn
             });
            this.dgvArchitectures.ContextMenuStrip = this.cmsEditArchitecture;
            this.dgvArchitectures.DataSource = this.architectureBindingSource;
            this.dgvArchitectures.Dock = DockStyle.Fill;
            this.dgvArchitectures.Location = new Point(0, 0);
            this.dgvArchitectures.Name = "dgvArchitectures";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvArchitectures.RowsDefaultCellStyle = style;
            this.dgvArchitectures.RowTemplate.Height = 0x17;
            this.dgvArchitectures.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvArchitectures.Size = new Size(0x32f, 520);
            this.dgvArchitectures.TabIndex = 1;
            this.dgvArchitectures.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvArchitectures_CellDoubleClick);
            this.dgvArchitectures.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvArchitectures_ColumnHeaderMouseClick);
            this.cmsEditArchitecture.Items.AddRange(new ToolStripItem[] { this.编辑选定建筑ToolStripMenuItem });
            this.cmsEditArchitecture.Name = "cmsEditArchitecture";
            this.cmsEditArchitecture.Size = new Size(0x95, 0x1a);
            this.编辑选定建筑ToolStripMenuItem.Name = "编辑选定建筑ToolStripMenuItem";
            this.编辑选定建筑ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.编辑选定建筑ToolStripMenuItem.Text = "编辑选定建筑";
            this.编辑选定建筑ToolStripMenuItem.Click += new EventHandler(this.编辑选定建筑ToolStripMenuItem_Click);
            this.architectureBindingSource.DataSource = typeof(Architecture);
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
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 70;
            this.kindDataGridViewTextBoxColumn.DataPropertyName = "KindString";
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.kindDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.kindDataGridViewTextBoxColumn.HeaderText = "种类";
            this.kindDataGridViewTextBoxColumn.Name = "kindDataGridViewTextBoxColumn";
            this.kindDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindDataGridViewTextBoxColumn.Width = 60;
            this.areaCountDataGridViewTextBoxColumn.DataPropertyName = "JianzhuGuimo";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.areaCountDataGridViewTextBoxColumn.DefaultCellStyle = style5;
            this.areaCountDataGridViewTextBoxColumn.HeaderText = "规模";
            this.areaCountDataGridViewTextBoxColumn.Name = "areaCountDataGridViewTextBoxColumn";
            this.areaCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaCountDataGridViewTextBoxColumn.Width = 60;
            this.StateString.DataPropertyName = "StateString";
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.StateString.DefaultCellStyle = style6;
            this.StateString.HeaderText = "州名";
            this.StateString.Name = "StateString";
            this.StateString.ReadOnly = true;
            this.RegionString.DataPropertyName = "RegionString";
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style7.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.RegionString.DefaultCellStyle = style7;
            this.RegionString.HeaderText = "地域";
            this.RegionString.Name = "RegionString";
            this.RegionString.ReadOnly = true;
            this.factionStringDataGridViewTextBoxColumn.DataPropertyName = "FactionString";
            style8.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.factionStringDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.factionStringDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionStringDataGridViewTextBoxColumn.Name = "factionStringDataGridViewTextBoxColumn";
            this.factionStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.factionStringDataGridViewTextBoxColumn.Width = 70;
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.populationDataGridViewTextBoxColumn.DefaultCellStyle = style9;
            this.populationDataGridViewTextBoxColumn.HeaderText = "人口";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            this.populationDataGridViewTextBoxColumn.Width = 70;
            this.Fund.DataPropertyName = "Fund";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Fund.DefaultCellStyle = style10;
            this.Fund.HeaderText = "资金";
            this.Fund.Name = "Fund";
            this.Fund.Width = 70;
            this.Food.DataPropertyName = "Food";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Food.DefaultCellStyle = style11;
            this.Food.HeaderText = "粮草";
            this.Food.Name = "Food";
            this.Food.Width = 70;
            this.agricultureDataGridViewTextBoxColumn.DataPropertyName = "Agriculture";
            this.agricultureDataGridViewTextBoxColumn.HeaderText = "农业";
            this.agricultureDataGridViewTextBoxColumn.Name = "agricultureDataGridViewTextBoxColumn";
            this.agricultureDataGridViewTextBoxColumn.Width = 70;
            this.AgricultureCeiling.DataPropertyName = "AgricultureCeiling";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            style12.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.AgricultureCeiling.DefaultCellStyle = style12;
            this.AgricultureCeiling.HeaderText = "农业上限";
            this.AgricultureCeiling.Name = "AgricultureCeiling";
            this.AgricultureCeiling.ReadOnly = true;
            this.AgricultureCeiling.Width = 80;
            this.commerceDataGridViewTextBoxColumn.DataPropertyName = "Commerce";
            this.commerceDataGridViewTextBoxColumn.HeaderText = "商业";
            this.commerceDataGridViewTextBoxColumn.Name = "commerceDataGridViewTextBoxColumn";
            this.commerceDataGridViewTextBoxColumn.Width = 70;
            this.CommerceCeiling.DataPropertyName = "CommerceCeiling";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            style13.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.CommerceCeiling.DefaultCellStyle = style13;
            this.CommerceCeiling.HeaderText = "商业上限";
            this.CommerceCeiling.Name = "CommerceCeiling";
            this.CommerceCeiling.ReadOnly = true;
            this.CommerceCeiling.Width = 80;
            this.technologyDataGridViewTextBoxColumn.DataPropertyName = "Technology";
            this.technologyDataGridViewTextBoxColumn.HeaderText = "技术";
            this.technologyDataGridViewTextBoxColumn.Name = "technologyDataGridViewTextBoxColumn";
            this.technologyDataGridViewTextBoxColumn.Width = 70;
            this.TechnologyCeiling.DataPropertyName = "TechnologyCeiling";
            style14.Alignment = DataGridViewContentAlignment.MiddleRight;
            style14.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.TechnologyCeiling.DefaultCellStyle = style14;
            this.TechnologyCeiling.HeaderText = "技术上限";
            this.TechnologyCeiling.Name = "TechnologyCeiling";
            this.TechnologyCeiling.ReadOnly = true;
            this.TechnologyCeiling.Width = 80;
            this.Domination.DataPropertyName = "Domination";
            style15.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Domination.DefaultCellStyle = style15;
            this.Domination.HeaderText = "统治";
            this.Domination.Name = "Domination";
            this.Domination.Width = 70;
            this.DominationCeiling.DataPropertyName = "DominationCeiling";
            style16.Alignment = DataGridViewContentAlignment.MiddleRight;
            style16.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.DominationCeiling.DefaultCellStyle = style16;
            this.DominationCeiling.HeaderText = "统治上限";
            this.DominationCeiling.Name = "DominationCeiling";
            this.DominationCeiling.ReadOnly = true;
            this.DominationCeiling.Width = 80;
            this.moraleDataGridViewTextBoxColumn.DataPropertyName = "Morale";
            this.moraleDataGridViewTextBoxColumn.HeaderText = "民心";
            this.moraleDataGridViewTextBoxColumn.Name = "moraleDataGridViewTextBoxColumn";
            this.moraleDataGridViewTextBoxColumn.Width = 70;
            this.MoraleCeiling.DataPropertyName = "MoraleCeiling";
            style17.Alignment = DataGridViewContentAlignment.MiddleRight;
            style17.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.MoraleCeiling.DefaultCellStyle = style17;
            this.MoraleCeiling.HeaderText = "民心上限";
            this.MoraleCeiling.Name = "MoraleCeiling";
            this.MoraleCeiling.ReadOnly = true;
            this.MoraleCeiling.Width = 80;
            this.Endurance.DataPropertyName = "Endurance";
            style18.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Endurance.DefaultCellStyle = style18;
            this.Endurance.HeaderText = "耐久";
            this.Endurance.Name = "Endurance";
            this.Endurance.Width = 70;
            this.EnduranceCeiling.DataPropertyName = "EnduranceCeiling";
            style19.Alignment = DataGridViewContentAlignment.MiddleRight;
            style19.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.EnduranceCeiling.DefaultCellStyle = style19;
            this.EnduranceCeiling.HeaderText = "耐久上限";
            this.EnduranceCeiling.Name = "EnduranceCeiling";
            this.EnduranceCeiling.ReadOnly = true;
            this.EnduranceCeiling.Width = 80;
            this.armyQuantityDataGridViewTextBoxColumn.DataPropertyName = "ArmyQuantity";
            style20.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.armyQuantityDataGridViewTextBoxColumn.DefaultCellStyle = style20;
            this.armyQuantityDataGridViewTextBoxColumn.HeaderText = "军队数量";
            this.armyQuantityDataGridViewTextBoxColumn.Name = "armyQuantityDataGridViewTextBoxColumn";
            this.armyQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x32f, 520);
            base.Controls.Add(this.dgvArchitectures);
            base.Name = "frmArchitectureList";
            base.ShowInTaskbar = false;
            this.Text = "建筑列表";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmArchitectureList_Load);
            ((ISupportInitialize) this.dgvArchitectures).EndInit();
            this.cmsEditArchitecture.ResumeLayout(false);
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

        private void 编辑选定建筑ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvArchitectures.IsCurrentCellInEditMode)
            {
                this.EditArchitectures();
            }
        }
    }
}

