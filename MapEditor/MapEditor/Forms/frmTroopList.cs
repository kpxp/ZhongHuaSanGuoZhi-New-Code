namespace MapEditor.Forms
{
    using GameObjects;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmTroopList : Form
    {
        private BindingSource bsTroopList;
        private DataGridViewTextBoxColumn chaosDayLeftDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn combativityDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridView dgvTroopList;
        private DataGridViewTextBoxColumn displayNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn experienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn factionStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn foodDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn injuryQuantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn KindString;
        private DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn personCountDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        public GameScenario Scenario;
        private DataGridViewTextBoxColumn sectionStringDataGridViewTextBoxColumn;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn StuntDayLeft;
        private DataGridViewTextBoxColumn technologyIncrementDataGridViewTextBoxColumn;

        public frmTroopList()
        {
            this.InitializeComponent();
        }

        private void dgvTroopList_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvTroopList.Columns[e.ColumnIndex].DataPropertyName, this.dgvTroopList.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Scenario.Troops.Sort(comparer);
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

        private void frmTroopList_Load(object sender, EventArgs e)
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
            this.dgvTroopList = new DataGridView();
            this.bsTroopList = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.displayNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.factionStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.sectionStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.KindString = new DataGridViewTextBoxColumn();
            this.personCountDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.foodDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.injuryQuantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.combativityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.experienceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.technologyIncrementDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.chaosDayLeftDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.StuntDayLeft = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dgvTroopList).BeginInit();
            ((ISupportInitialize) this.bsTroopList).BeginInit();
            base.SuspendLayout();
            this.dgvTroopList.AllowUserToAddRows = false;
            this.dgvTroopList.AllowUserToDeleteRows = false;
            this.dgvTroopList.AutoGenerateColumns = false;
            this.dgvTroopList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTroopList.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.displayNameDataGridViewTextBoxColumn, this.factionStringDataGridViewTextBoxColumn, this.sectionStringDataGridViewTextBoxColumn, this.KindString, this.personCountDataGridViewTextBoxColumn, this.foodDataGridViewTextBoxColumn, this.quantityDataGridViewTextBoxColumn, this.injuryQuantityDataGridViewTextBoxColumn, this.moraleDataGridViewTextBoxColumn, this.combativityDataGridViewTextBoxColumn, this.experienceDataGridViewTextBoxColumn, this.technologyIncrementDataGridViewTextBoxColumn, this.chaosDayLeftDataGridViewTextBoxColumn, this.StuntDayLeft });
            this.dgvTroopList.DataSource = this.bsTroopList;
            this.dgvTroopList.Dock = DockStyle.Fill;
            this.dgvTroopList.Location = new Point(0, 0);
            this.dgvTroopList.MultiSelect = false;
            this.dgvTroopList.Name = "dgvTroopList";
            this.dgvTroopList.RowTemplate.Height = 0x17;
            this.dgvTroopList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTroopList.Size = new Size(930, 0x201);
            this.dgvTroopList.TabIndex = 0;
            this.dgvTroopList.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvTroopList_ColumnHeaderMouseClick);
            this.bsTroopList.DataSource = typeof(Troop);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.displayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName";
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.displayNameDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.displayNameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.displayNameDataGridViewTextBoxColumn.Name = "displayNameDataGridViewTextBoxColumn";
            this.displayNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.factionStringDataGridViewTextBoxColumn.DataPropertyName = "FactionString";
            style3.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.factionStringDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.factionStringDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionStringDataGridViewTextBoxColumn.Name = "factionStringDataGridViewTextBoxColumn";
            this.factionStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.sectionStringDataGridViewTextBoxColumn.DataPropertyName = "SectionString";
            style4.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.sectionStringDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.sectionStringDataGridViewTextBoxColumn.HeaderText = "军区";
            this.sectionStringDataGridViewTextBoxColumn.Name = "sectionStringDataGridViewTextBoxColumn";
            this.sectionStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.KindString.DataPropertyName = "KindString";
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.KindString.DefaultCellStyle = style5;
            this.KindString.HeaderText = "兵种";
            this.KindString.Name = "KindString";
            this.KindString.ReadOnly = true;
            this.KindString.Width = 80;
            this.personCountDataGridViewTextBoxColumn.DataPropertyName = "PersonCount";
            style6.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.personCountDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.personCountDataGridViewTextBoxColumn.HeaderText = "人物数量";
            this.personCountDataGridViewTextBoxColumn.Name = "personCountDataGridViewTextBoxColumn";
            this.personCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.personCountDataGridViewTextBoxColumn.Width = 80;
            this.foodDataGridViewTextBoxColumn.DataPropertyName = "Food";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.foodDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.foodDataGridViewTextBoxColumn.HeaderText = "粮草";
            this.foodDataGridViewTextBoxColumn.Name = "foodDataGridViewTextBoxColumn";
            this.foodDataGridViewTextBoxColumn.Width = 80;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "军队人数";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            this.injuryQuantityDataGridViewTextBoxColumn.DataPropertyName = "InjuryQuantity";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.injuryQuantityDataGridViewTextBoxColumn.DefaultCellStyle = style9;
            this.injuryQuantityDataGridViewTextBoxColumn.HeaderText = "伤兵人数";
            this.injuryQuantityDataGridViewTextBoxColumn.Name = "injuryQuantityDataGridViewTextBoxColumn";
            this.injuryQuantityDataGridViewTextBoxColumn.Width = 80;
            this.moraleDataGridViewTextBoxColumn.DataPropertyName = "Morale";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.moraleDataGridViewTextBoxColumn.DefaultCellStyle = style10;
            this.moraleDataGridViewTextBoxColumn.HeaderText = "士气";
            this.moraleDataGridViewTextBoxColumn.Name = "moraleDataGridViewTextBoxColumn";
            this.moraleDataGridViewTextBoxColumn.Width = 80;
            this.combativityDataGridViewTextBoxColumn.DataPropertyName = "Combativity";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.combativityDataGridViewTextBoxColumn.DefaultCellStyle = style11;
            this.combativityDataGridViewTextBoxColumn.HeaderText = "战意";
            this.combativityDataGridViewTextBoxColumn.Name = "combativityDataGridViewTextBoxColumn";
            this.experienceDataGridViewTextBoxColumn.DataPropertyName = "Experience";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.experienceDataGridViewTextBoxColumn.DefaultCellStyle = style12;
            this.experienceDataGridViewTextBoxColumn.HeaderText = "经验";
            this.experienceDataGridViewTextBoxColumn.Name = "experienceDataGridViewTextBoxColumn";
            this.technologyIncrementDataGridViewTextBoxColumn.DataPropertyName = "TechnologyIncrement";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.technologyIncrementDataGridViewTextBoxColumn.DefaultCellStyle = style13;
            this.technologyIncrementDataGridViewTextBoxColumn.HeaderText = "技术基础";
            this.technologyIncrementDataGridViewTextBoxColumn.Name = "technologyIncrementDataGridViewTextBoxColumn";
            this.chaosDayLeftDataGridViewTextBoxColumn.DataPropertyName = "ChaosDayLeft";
            style14.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.chaosDayLeftDataGridViewTextBoxColumn.DefaultCellStyle = style14;
            this.chaosDayLeftDataGridViewTextBoxColumn.HeaderText = "混乱剩余天数";
            this.chaosDayLeftDataGridViewTextBoxColumn.Name = "chaosDayLeftDataGridViewTextBoxColumn";
            this.chaosDayLeftDataGridViewTextBoxColumn.Width = 120;
            this.StuntDayLeft.DataPropertyName = "StuntDayLeft";
            style15.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.StuntDayLeft.DefaultCellStyle = style15;
            this.StuntDayLeft.HeaderText = "特技剩余时间";
            this.StuntDayLeft.Name = "StuntDayLeft";
            this.StuntDayLeft.Width = 120;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(930, 0x201);
            base.Controls.Add(this.dgvTroopList);
            base.MinimizeBox = false;
            base.Name = "frmTroopList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "部队列表";
            base.Load += new EventHandler(this.frmTroopList_Load);
            ((ISupportInitialize) this.dgvTroopList).EndInit();
            ((ISupportInitialize) this.bsTroopList).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.bsTroopList.DataSource = null;
            this.bsTroopList.DataSource = this.Scenario.Troops;
        }
    }
}

