namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor.Forms.FactionForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmFactionList : Form
    {
        private DataGridViewTextBoxColumn architectureCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ArchitectureTotalSize;
        private DataGridViewTextBoxColumn armyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CapitalID;
        private ContextMenuStrip cmsFaction;
        private DataGridViewTextBoxColumn colorIndexDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Column1;
        private IContainer components = null;
        private DataGridView dgvFactions;
        private BindingSource factionBindingSource;
        public FactionList Factions;
        private DataGridViewTextBoxColumn Food;
        private DataGridViewTextBoxColumn Fund;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn MilitaryCount;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn personCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Reputation;
        public GameScenario Scenario;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn TechniquePoint;
        private DataGridViewTextBoxColumn TechniquePointForFacility;
        private DataGridViewTextBoxColumn TechniquePointForTechnique;
        private DataGridViewTextBoxColumn TotalTechniquePoint;
        private DataGridViewTextBoxColumn troopCountDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑选中势力ToolStripMenuItem;
        private ToolStripMenuItem 删除势力ToolStripMenuItem;
        private ToolStripMenuItem 添加新势力ToolStripMenuItem;

        public frmFactionList()
        {
            this.InitializeComponent();
        }

        private void dgvFactions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvFactions.IsCurrentCellInEditMode)
            {
                this.EditFactions();
            }
        }

        private void dgvFactions_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvFactions.Columns[e.ColumnIndex].DataPropertyName, this.dgvFactions.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Factions.Sort(comparer);
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

        private void EditFactions()
        {
            FactionList list = new FactionList();
            for (int i = 0; i < this.dgvFactions.SelectedRows.Count; i++)
            {
                list.Add(this.Factions[this.dgvFactions.SelectedRows[i].Index]);
            }
            if (list.Count > 0)
            {
                frmEditFaction faction = new frmEditFaction();
                faction.Factions = list;
                faction.ShowDialog();
                this.dgvFactions.Invalidate();
            }
        }

        private void frmFactionList_Load(object sender, EventArgs e)
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
            this.dgvFactions = new DataGridView();
            this.cmsFaction = new ContextMenuStrip(this.components);
            this.编辑选中势力ToolStripMenuItem = new ToolStripMenuItem();
            this.添加新势力ToolStripMenuItem = new ToolStripMenuItem();
            this.删除势力ToolStripMenuItem = new ToolStripMenuItem();
            this.factionBindingSource = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.Column1 = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.colorIndexDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.Reputation = new DataGridViewTextBoxColumn();
            this.CapitalID = new DataGridViewTextBoxColumn();
            this.TotalTechniquePoint = new DataGridViewTextBoxColumn();
            this.TechniquePoint = new DataGridViewTextBoxColumn();
            this.TechniquePointForTechnique = new DataGridViewTextBoxColumn();
            this.TechniquePointForFacility = new DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.Fund = new DataGridViewTextBoxColumn();
            this.Food = new DataGridViewTextBoxColumn();
            this.armyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.architectureCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.ArchitectureTotalSize = new DataGridViewTextBoxColumn();
            this.personCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.MilitaryCount = new DataGridViewTextBoxColumn();
            this.troopCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dgvFactions).BeginInit();
            this.cmsFaction.SuspendLayout();
            ((ISupportInitialize) this.factionBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvFactions.AllowUserToAddRows = false;
            this.dgvFactions.AllowUserToDeleteRows = false;
            this.dgvFactions.AllowUserToOrderColumns = true;
            this.dgvFactions.AutoGenerateColumns = false;
            this.dgvFactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactions.Columns.AddRange(new DataGridViewColumn[] { 
                this.iDDataGridViewTextBoxColumn, this.Column1, this.nameDataGridViewTextBoxColumn, this.colorIndexDataGridViewTextBoxColumn, this.Reputation, this.CapitalID, this.TotalTechniquePoint, this.TechniquePoint, this.TechniquePointForTechnique, this.TechniquePointForFacility, this.populationDataGridViewTextBoxColumn, this.Fund, this.Food, this.armyDataGridViewTextBoxColumn, this.architectureCountDataGridViewTextBoxColumn, this.ArchitectureTotalSize, 
                this.personCountDataGridViewTextBoxColumn, this.MilitaryCount, this.troopCountDataGridViewTextBoxColumn
             });
            this.dgvFactions.ContextMenuStrip = this.cmsFaction;
            this.dgvFactions.DataSource = this.factionBindingSource;
            this.dgvFactions.Dock = DockStyle.Fill;
            this.dgvFactions.Location = new Point(0, 0);
            this.dgvFactions.Name = "dgvFactions";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFactions.RowsDefaultCellStyle = style;
            this.dgvFactions.RowTemplate.Height = 0x17;
            this.dgvFactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactions.Size = new Size(0x354, 480);
            this.dgvFactions.TabIndex = 2;
            this.dgvFactions.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvFactions_ColumnHeaderMouseClick);
            this.dgvFactions.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvFactions_CellMouseDoubleClick);
            this.cmsFaction.Items.AddRange(new ToolStripItem[] { this.编辑选中势力ToolStripMenuItem, this.添加新势力ToolStripMenuItem, this.删除势力ToolStripMenuItem });
            this.cmsFaction.Name = "cmsFaction";
            this.cmsFaction.Size = new Size(0x95, 70);
            this.编辑选中势力ToolStripMenuItem.Name = "编辑选中势力ToolStripMenuItem";
            this.编辑选中势力ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.编辑选中势力ToolStripMenuItem.Text = "编辑选中势力";
            this.编辑选中势力ToolStripMenuItem.Click += new EventHandler(this.编辑选中势力ToolStripMenuItem_Click);
            this.添加新势力ToolStripMenuItem.Name = "添加新势力ToolStripMenuItem";
            this.添加新势力ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.添加新势力ToolStripMenuItem.Text = "添加新势力";
            this.添加新势力ToolStripMenuItem.Click += new EventHandler(this.添加新势力ToolStripMenuItem_Click);
            this.删除势力ToolStripMenuItem.Name = "删除势力ToolStripMenuItem";
            this.删除势力ToolStripMenuItem.Size = new Size(0x94, 0x16);
            this.删除势力ToolStripMenuItem.Text = "删除选中势力";
            this.删除势力ToolStripMenuItem.Click += new EventHandler(this.删除势力ToolStripMenuItem_Click);
            this.factionBindingSource.DataSource = typeof(Faction);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.iDDataGridViewTextBoxColumn.Frozen = true;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 40;
            this.Column1.DataPropertyName = "LeaderID";
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "君主ID";
            this.Column1.Name = "Column1";
            this.Column1.Width = 70;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "势力名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 80;
            this.colorIndexDataGridViewTextBoxColumn.DataPropertyName = "ColorIndex";
            this.colorIndexDataGridViewTextBoxColumn.Frozen = true;
            this.colorIndexDataGridViewTextBoxColumn.HeaderText = "势力颜色";
            this.colorIndexDataGridViewTextBoxColumn.Name = "colorIndexDataGridViewTextBoxColumn";
            this.Reputation.DataPropertyName = "Reputation";
            style3.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Reputation.DefaultCellStyle = style3;
            this.Reputation.Frozen = true;
            this.Reputation.HeaderText = "声望";
            this.Reputation.Name = "Reputation";
            this.Reputation.Width = 70;
            this.CapitalID.DataPropertyName = "CapitalID";
            this.CapitalID.Frozen = true;
            this.CapitalID.HeaderText = "都城ID";
            this.CapitalID.Name = "CapitalID";
            this.CapitalID.Width = 70;
            this.TotalTechniquePoint.DataPropertyName = "TotalTechniquePoint";
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            style4.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.TotalTechniquePoint.DefaultCellStyle = style4;
            this.TotalTechniquePoint.Frozen = true;
            this.TotalTechniquePoint.HeaderText = "总技巧点数";
            this.TotalTechniquePoint.Name = "TotalTechniquePoint";
            this.TotalTechniquePoint.ReadOnly = true;
            this.TechniquePoint.DataPropertyName = "TechniquePoint";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.TechniquePoint.DefaultCellStyle = style5;
            this.TechniquePoint.Frozen = true;
            this.TechniquePoint.HeaderText = "技巧点数";
            this.TechniquePoint.Name = "TechniquePoint";
            this.TechniquePointForTechnique.DataPropertyName = "TechniquePointForTechnique";
            style6.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.TechniquePointForTechnique.DefaultCellStyle = style6;
            this.TechniquePointForTechnique.Frozen = true;
            this.TechniquePointForTechnique.HeaderText = "为升级势力技巧保留的技巧点数";
            this.TechniquePointForTechnique.Name = "TechniquePointForTechnique";
            this.TechniquePointForTechnique.Width = 300;
            this.TechniquePointForFacility.DataPropertyName = "TechniquePointForFacility";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.TechniquePointForFacility.DefaultCellStyle = style7;
            this.TechniquePointForFacility.Frozen = true;
            this.TechniquePointForFacility.HeaderText = "为兴建设施保留的技巧点数";
            this.TechniquePointForFacility.Name = "TechniquePointForFacility";
            this.TechniquePointForFacility.Width = 300;
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            style8.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.populationDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.populationDataGridViewTextBoxColumn.HeaderText = "人口数量";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            this.populationDataGridViewTextBoxColumn.ReadOnly = true;
            this.Fund.DataPropertyName = "Fund";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            style9.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.Fund.DefaultCellStyle = style9;
            this.Fund.HeaderText = "资金总数";
            this.Fund.Name = "Fund";
            this.Fund.ReadOnly = true;
            this.Food.DataPropertyName = "Food";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            style10.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.Food.DefaultCellStyle = style10;
            this.Food.HeaderText = "粮草总数";
            this.Food.Name = "Food";
            this.Food.ReadOnly = true;
            this.armyDataGridViewTextBoxColumn.DataPropertyName = "Army";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            style11.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.armyDataGridViewTextBoxColumn.DefaultCellStyle = style11;
            this.armyDataGridViewTextBoxColumn.HeaderText = "军队数量";
            this.armyDataGridViewTextBoxColumn.Name = "armyDataGridViewTextBoxColumn";
            this.armyDataGridViewTextBoxColumn.ReadOnly = true;
            this.architectureCountDataGridViewTextBoxColumn.DataPropertyName = "ArchitectureCount";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            style12.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.architectureCountDataGridViewTextBoxColumn.DefaultCellStyle = style12;
            this.architectureCountDataGridViewTextBoxColumn.HeaderText = "建筑数量";
            this.architectureCountDataGridViewTextBoxColumn.Name = "architectureCountDataGridViewTextBoxColumn";
            this.architectureCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.ArchitectureTotalSize.DataPropertyName = "ArchitectureTotalSize";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            style13.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.ArchitectureTotalSize.DefaultCellStyle = style13;
            this.ArchitectureTotalSize.HeaderText = "建筑总规模";
            this.ArchitectureTotalSize.Name = "ArchitectureTotalSize";
            this.ArchitectureTotalSize.ReadOnly = true;
            this.personCountDataGridViewTextBoxColumn.DataPropertyName = "PersonCount";
            style14.Alignment = DataGridViewContentAlignment.MiddleRight;
            style14.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.personCountDataGridViewTextBoxColumn.DefaultCellStyle = style14;
            this.personCountDataGridViewTextBoxColumn.HeaderText = "人物数量";
            this.personCountDataGridViewTextBoxColumn.Name = "personCountDataGridViewTextBoxColumn";
            this.personCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.MilitaryCount.DataPropertyName = "MilitaryCount";
            style15.Alignment = DataGridViewContentAlignment.MiddleRight;
            style15.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.MilitaryCount.DefaultCellStyle = style15;
            this.MilitaryCount.HeaderText = "编队数量";
            this.MilitaryCount.Name = "MilitaryCount";
            this.MilitaryCount.ReadOnly = true;
            this.troopCountDataGridViewTextBoxColumn.DataPropertyName = "TroopCount";
            style16.Alignment = DataGridViewContentAlignment.MiddleRight;
            style16.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.troopCountDataGridViewTextBoxColumn.DefaultCellStyle = style16;
            this.troopCountDataGridViewTextBoxColumn.HeaderText = "部队数量";
            this.troopCountDataGridViewTextBoxColumn.Name = "troopCountDataGridViewTextBoxColumn";
            this.troopCountDataGridViewTextBoxColumn.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x354, 480);
            base.Controls.Add(this.dgvFactions);
            base.Name = "frmFactionList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "势力列表";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmFactionList_Load);
            ((ISupportInitialize) this.dgvFactions).EndInit();
            this.cmsFaction.ResumeLayout(false);
            ((ISupportInitialize) this.factionBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            foreach (Faction faction in this.Factions)
            {
                Section firstSection = faction.FirstSection;
            }
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.factionBindingSource.DataSource = null;
            this.factionBindingSource.DataSource = this.Factions;
        }

        private void 编辑选中势力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvFactions.IsCurrentCellInEditMode)
            {
                this.EditFactions();
            }
        }

        private void 删除势力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FactionList list = new FactionList();
            for (int i = 0; i < this.dgvFactions.SelectedRows.Count; i++)
            {
                list.Add(this.Factions[this.dgvFactions.SelectedRows[i].Index]);
            }
            foreach (Faction faction in this.Scenario.Factions)
            {
                foreach (Faction faction2 in list)
                {
                    this.Scenario.DiplomaticRelations.RemoveDiplomaticRelationByFactionID(faction2.ID);
                }
            }
            foreach (Faction faction in list)
            {
                this.Scenario.Factions.RemoveFaction(faction);
            }
            foreach (Legion legion in this.Scenario.Legions.GetList())
            {
                if (legion.BelongedFaction == null)
                {
                    this.Scenario.Legions.Remove(legion);
                }
            }
            foreach (Section section in this.Scenario.Sections.GetList())
            {
                if (section.BelongedFaction == null)
                {
                    this.Scenario.Sections.Remove(section);
                }
            }
            this.RebindDataSource();
        }

        private void 添加新势力ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Faction t = new Faction();
            t.ID = this.Scenario.Factions.GetFreeGameObjectID();
            t.Scenario = this.Scenario;
            t.CapitalID = -1;
            t.LeaderID = -1;
            t.Name = "势力名";
            this.Scenario.Factions.Add(t);
            foreach (Faction faction2 in this.Scenario.Factions)
            {
                if (faction2 != t)
                {
                    this.Scenario.DiplomaticRelations.AddDiplomaticRelation(this.Scenario, t.ID, faction2.ID, 0);
                }
            }
            this.RebindDataSource();
        }
    }
}

