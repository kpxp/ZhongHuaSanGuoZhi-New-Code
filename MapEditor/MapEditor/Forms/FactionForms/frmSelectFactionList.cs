namespace MapEditor.Forms.FactionForms
{
    using GameObjects;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectFactionList : Form
    {
        private DataGridViewTextBoxColumn architectureCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn armyDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridView dgvFactions;
        private BindingSource factionBindingSource;
        public FactionList Factions;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn personCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        public Faction SelectedFaction;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn troopCountDataGridViewTextBoxColumn;

        public frmSelectFactionList()
        {
            this.InitializeComponent();
        }

        private void dgvFactions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvFactions.IsCurrentCellInEditMode)
            {
                this.SelectedFaction = this.dgvFactions.SelectedRows[0].DataBoundItem as Faction;
                base.Close();
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

        private void frmSelectFactionList_Load(object sender, EventArgs e)
        {
            if (this.Factions != null)
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
            DataGridViewCellStyle style8 = new DataGridViewCellStyle();
            this.dgvFactions = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.architectureCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.personCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.troopCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.populationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.armyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.factionBindingSource = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvFactions).BeginInit();
            ((ISupportInitialize) this.factionBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvFactions.AllowUserToAddRows = false;
            this.dgvFactions.AllowUserToDeleteRows = false;
            this.dgvFactions.AllowUserToOrderColumns = true;
            this.dgvFactions.AutoGenerateColumns = false;
            this.dgvFactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactions.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.architectureCountDataGridViewTextBoxColumn, this.personCountDataGridViewTextBoxColumn, this.troopCountDataGridViewTextBoxColumn, this.populationDataGridViewTextBoxColumn, this.armyDataGridViewTextBoxColumn });
            this.dgvFactions.DataSource = this.factionBindingSource;
            this.dgvFactions.Dock = DockStyle.Fill;
            this.dgvFactions.Location = new Point(0, 0);
            this.dgvFactions.MultiSelect = false;
            this.dgvFactions.Name = "dgvFactions";
            this.dgvFactions.ReadOnly = true;
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvFactions.RowsDefaultCellStyle = style;
            this.dgvFactions.RowTemplate.Height = 0x17;
            this.dgvFactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactions.Size = new Size(0x29b, 0x1bb);
            this.dgvFactions.TabIndex = 3;
            this.dgvFactions.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvFactions_ColumnHeaderMouseClick);
            this.dgvFactions.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvFactions_CellMouseDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.iDDataGridViewTextBoxColumn.Frozen = true;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.architectureCountDataGridViewTextBoxColumn.DataPropertyName = "ArchitectureCount";
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.architectureCountDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.architectureCountDataGridViewTextBoxColumn.HeaderText = "建筑数量";
            this.architectureCountDataGridViewTextBoxColumn.Name = "architectureCountDataGridViewTextBoxColumn";
            this.architectureCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.personCountDataGridViewTextBoxColumn.DataPropertyName = "PersonCount";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.personCountDataGridViewTextBoxColumn.DefaultCellStyle = style5;
            this.personCountDataGridViewTextBoxColumn.HeaderText = "人物数量";
            this.personCountDataGridViewTextBoxColumn.Name = "personCountDataGridViewTextBoxColumn";
            this.personCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.troopCountDataGridViewTextBoxColumn.DataPropertyName = "TroopCount";
            style6.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.troopCountDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.troopCountDataGridViewTextBoxColumn.HeaderText = "部队数量";
            this.troopCountDataGridViewTextBoxColumn.Name = "troopCountDataGridViewTextBoxColumn";
            this.troopCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "Population";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.populationDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.populationDataGridViewTextBoxColumn.HeaderText = "人口数量";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            this.populationDataGridViewTextBoxColumn.ReadOnly = true;
            this.armyDataGridViewTextBoxColumn.DataPropertyName = "Army";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.armyDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.armyDataGridViewTextBoxColumn.HeaderText = "军队数量";
            this.armyDataGridViewTextBoxColumn.Name = "armyDataGridViewTextBoxColumn";
            this.armyDataGridViewTextBoxColumn.ReadOnly = true;
            this.factionBindingSource.DataSource = typeof(Faction);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x29b, 0x1bb);
            base.Controls.Add(this.dgvFactions);
            base.Name = "frmSelectFactionList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择势力";
            base.Load += new EventHandler(this.frmSelectFactionList_Load);
            ((ISupportInitialize) this.dgvFactions).EndInit();
            ((ISupportInitialize) this.factionBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.factionBindingSource.DataSource = null;
            this.factionBindingSource.DataSource = this.Factions;
        }
    }
}

