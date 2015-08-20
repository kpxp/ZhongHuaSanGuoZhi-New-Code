namespace MapEditor.Forms
{
    using GameObjects;
    using GameObjects.PersonDetail;
    using MapEditor;
    using MapEditor.Forms.ArchitectureForms;
    using MapEditor.Forms.PersonForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmPersonList : Form
    {
        private DataGridViewCheckBoxColumn aliveDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn ambitionDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn availableDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn AvailableLocation;
        private DataGridViewTextBoxColumn bravenessDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn brotherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calmnessDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn characterDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn CharacterString;
        private ContextMenuStrip cmsEditPerson;
        private DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView dgvPersons;
        public int EditPersonTabIndex;
        private DataGridViewTextBoxColumn factionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fatherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn generationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn glamourDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idealDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn intelligenceDataGridViewTextBoxColumn;
        private Architecture lastArchitecture;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn loyaltyDataGridViewTextBoxColumn;
        public formMapEditor MainForm;
        private ToolStripMenuItem menuRecentLocation;
        private DataGridViewTextBoxColumn motherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn oldFactionIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn personalLoyaltyDataGridViewTextBoxColumn;
        private BindingSource personBindingSource;
        public PersonList Persons;
        private DataGridViewTextBoxColumn politicsDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prohibitedFactionIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn qualificationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Reputation;
        private DataGridViewCheckBoxColumn sexDataGridViewCheckBoxColumn;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn spouseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn strainDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn strategyTendencyDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn strengthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valuationOnGovernmentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workKindDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearAvailableDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearBornDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearDeadDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑人物ToolStripMenuItem;
        private ToolStripMenuItem 删除选定人物ToolStripMenuItem;
        private ToolStripMenuItem 设置为前一个位置ToolStripMenuItem;
        private ToolStripMenuItem 设置位置ToolStripMenuItem;
        private ToolStripMenuItem 添加新人物ToolStripMenuItem;

        public frmPersonList()
        {
            this.InitializeComponent();
        }

        private void ApplyLastArchitecture(Person p)
        {
            if (!p.Available)
            {
                p.AvailableLocation = this.lastArchitecture.ID;
                p.Status = PersonStatus.None;
            }
            else
            {
                p.AvailableLocation = 0;
                p.LocationArchitecture = this.lastArchitecture;
                p.Status = PersonStatus.Normal;
            }
        }

        private void dgvPersons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvPersons.IsCurrentCellInEditMode)
            {
                this.EditPersons();
            }
        }

        private void dgvPersons_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvPersons.Columns[e.ColumnIndex].DataPropertyName, this.dgvPersons.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Persons.Sort(comparer);
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

        private void EditPersons()
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                PersonList list = new PersonList();
                for (int i = 0; i < this.dgvPersons.SelectedRows.Count; i++)
                {
                    list.Add(this.dgvPersons.SelectedRows[i].DataBoundItem as Person);
                }
                frmEditPerson person = new frmEditPerson();
                person.Owner = this;
                person.MainForm = this.MainForm;
                person.Persons = list;
                person.SetTabIndex(this.EditPersonTabIndex);
                person.AllPersons = this.Persons;
                person.ShowDialog();
                this.dgvPersons.Invalidate();
            }
        }

        private void frmPersonList_Load(object sender, EventArgs e)
        {
            if (this.Persons != null)
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
            DataGridViewCellStyle style21 = new DataGridViewCellStyle();
            DataGridViewCellStyle style22 = new DataGridViewCellStyle();
            DataGridViewCellStyle style23 = new DataGridViewCellStyle();
            DataGridViewCellStyle style24 = new DataGridViewCellStyle();
            DataGridViewCellStyle style25 = new DataGridViewCellStyle();
            DataGridViewCellStyle style26 = new DataGridViewCellStyle();
            DataGridViewCellStyle style27 = new DataGridViewCellStyle();
            DataGridViewCellStyle style28 = new DataGridViewCellStyle();
            this.dgvPersons = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.availableDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.aliveDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.sexDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            this.CharacterString = new DataGridViewTextBoxColumn();
            this.factionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.AvailableLocation = new DataGridViewTextBoxColumn();
            this.Reputation = new DataGridViewTextBoxColumn();
            this.strengthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.commandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.intelligenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.politicsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.glamourDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.bravenessDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.calmnessDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.loyaltyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.yearAvailableDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.yearBornDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.yearDeadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.idealDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.personalLoyaltyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.ambitionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.qualificationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.valuationOnGovernmentDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.strategyTendencyDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.oldFactionIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.prohibitedFactionIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.strainDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.fatherDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.motherDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.spouseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.brotherDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.generationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.workKindDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.cmsEditPerson = new ContextMenuStrip(this.components);
            this.编辑人物ToolStripMenuItem = new ToolStripMenuItem();
            this.添加新人物ToolStripMenuItem = new ToolStripMenuItem();
            this.设置位置ToolStripMenuItem = new ToolStripMenuItem();
            this.设置为前一个位置ToolStripMenuItem = new ToolStripMenuItem();
            this.menuRecentLocation = new ToolStripMenuItem();
            this.personBindingSource = new BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.删除选定人物ToolStripMenuItem = new ToolStripMenuItem();
            ((ISupportInitialize) this.dgvPersons).BeginInit();
            this.cmsEditPerson.SuspendLayout();
            ((ISupportInitialize) this.personBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvPersons.AllowUserToAddRows = false;
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AllowUserToOrderColumns = true;
            this.dgvPersons.AutoGenerateColumns = false;
            this.dgvPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.Columns.AddRange(new DataGridViewColumn[] { 
                this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.availableDataGridViewCheckBoxColumn, this.aliveDataGridViewCheckBoxColumn, this.sexDataGridViewCheckBoxColumn, this.CharacterString, this.factionDataGridViewTextBoxColumn, this.locationDataGridViewTextBoxColumn, this.AvailableLocation, this.Reputation, this.strengthDataGridViewTextBoxColumn, this.commandDataGridViewTextBoxColumn, this.intelligenceDataGridViewTextBoxColumn, this.politicsDataGridViewTextBoxColumn, this.glamourDataGridViewTextBoxColumn, this.bravenessDataGridViewTextBoxColumn, 
                this.calmnessDataGridViewTextBoxColumn, this.loyaltyDataGridViewTextBoxColumn, this.yearAvailableDataGridViewTextBoxColumn, this.yearBornDataGridViewTextBoxColumn, this.yearDeadDataGridViewTextBoxColumn, this.idealDataGridViewTextBoxColumn, this.personalLoyaltyDataGridViewTextBoxColumn, this.ambitionDataGridViewTextBoxColumn, this.qualificationDataGridViewTextBoxColumn, this.valuationOnGovernmentDataGridViewTextBoxColumn, this.strategyTendencyDataGridViewTextBoxColumn, this.oldFactionIDDataGridViewTextBoxColumn, this.prohibitedFactionIDDataGridViewTextBoxColumn, this.strainDataGridViewTextBoxColumn, this.fatherDataGridViewTextBoxColumn, this.motherDataGridViewTextBoxColumn, 
                this.spouseDataGridViewTextBoxColumn, this.brotherDataGridViewTextBoxColumn, this.generationDataGridViewTextBoxColumn, this.workKindDataGridViewTextBoxColumn
             });
            this.dgvPersons.ContextMenuStrip = this.cmsEditPerson;
            this.dgvPersons.DataSource = this.personBindingSource;
            this.dgvPersons.Dock = DockStyle.Fill;
            this.dgvPersons.Location = new Point(0, 0);
            this.dgvPersons.Name = "dgvPersons";
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvPersons.RowsDefaultCellStyle = style;
            this.dgvPersons.RowTemplate.Height = 0x17;
            this.dgvPersons.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersons.Size = new Size(870, 0x20b);
            this.dgvPersons.TabIndex = 0;
            this.dgvPersons.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvPersons_ColumnHeaderMouseClick);
            this.dgvPersons.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvPersons_CellMouseDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            style2.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.iDDataGridViewTextBoxColumn.FillWeight = 40f;
            this.iDDataGridViewTextBoxColumn.Frozen = true;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 40;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            style3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style3.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "姓名";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 50;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.availableDataGridViewCheckBoxColumn.DataPropertyName = "Available";
            this.availableDataGridViewCheckBoxColumn.HeaderText = "出场";
            this.availableDataGridViewCheckBoxColumn.Name = "availableDataGridViewCheckBoxColumn";
            this.availableDataGridViewCheckBoxColumn.Width = 50;
            this.aliveDataGridViewCheckBoxColumn.DataPropertyName = "Alive";
            this.aliveDataGridViewCheckBoxColumn.HeaderText = "活着";
            this.aliveDataGridViewCheckBoxColumn.Name = "aliveDataGridViewCheckBoxColumn";
            this.aliveDataGridViewCheckBoxColumn.Width = 50;
            this.sexDataGridViewCheckBoxColumn.DataPropertyName = "Sex";
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style4.BackColor = Color.White;
            style4.NullValue = false;
            this.sexDataGridViewCheckBoxColumn.DefaultCellStyle = style4;
            this.sexDataGridViewCheckBoxColumn.HeaderText = "性别";
            this.sexDataGridViewCheckBoxColumn.Name = "sexDataGridViewCheckBoxColumn";
            this.sexDataGridViewCheckBoxColumn.Width = 50;
            this.CharacterString.DataPropertyName = "CharacterString";
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.CharacterString.DefaultCellStyle = style5;
            this.CharacterString.HeaderText = "性格";
            this.CharacterString.Name = "CharacterString";
            this.CharacterString.ReadOnly = true;
            this.CharacterString.Width = 60;
            this.factionDataGridViewTextBoxColumn.DataPropertyName = "Faction";
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.factionDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.factionDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionDataGridViewTextBoxColumn.Name = "factionDataGridViewTextBoxColumn";
            this.factionDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            style7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style7.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.locationDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.locationDataGridViewTextBoxColumn.HeaderText = "位置";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.AvailableLocation.DataPropertyName = "AvailableLocation";
            this.AvailableLocation.HeaderText = "出场地点";
            this.AvailableLocation.Name = "AvailableLocation";
            this.Reputation.DataPropertyName = "BaseReputation";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.Reputation.DefaultCellStyle = style8;
            this.Reputation.HeaderText = "名声";
            this.Reputation.Name = "Reputation";
            this.Reputation.Width = 70;
            this.strengthDataGridViewTextBoxColumn.DataPropertyName = "BaseStrength";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.strengthDataGridViewTextBoxColumn.DefaultCellStyle = style9;
            this.strengthDataGridViewTextBoxColumn.HeaderText = "武勇";
            this.strengthDataGridViewTextBoxColumn.Name = "strengthDataGridViewTextBoxColumn";
            this.strengthDataGridViewTextBoxColumn.Width = 60;
            this.commandDataGridViewTextBoxColumn.DataPropertyName = "BaseCommand";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.commandDataGridViewTextBoxColumn.DefaultCellStyle = style10;
            this.commandDataGridViewTextBoxColumn.HeaderText = "统率";
            this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
            this.commandDataGridViewTextBoxColumn.Width = 60;
            this.intelligenceDataGridViewTextBoxColumn.DataPropertyName = "BaseIntelligence";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.intelligenceDataGridViewTextBoxColumn.DefaultCellStyle = style11;
            this.intelligenceDataGridViewTextBoxColumn.HeaderText = "智谋";
            this.intelligenceDataGridViewTextBoxColumn.Name = "intelligenceDataGridViewTextBoxColumn";
            this.intelligenceDataGridViewTextBoxColumn.Width = 60;
            this.politicsDataGridViewTextBoxColumn.DataPropertyName = "BasePolitics";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.politicsDataGridViewTextBoxColumn.DefaultCellStyle = style12;
            this.politicsDataGridViewTextBoxColumn.HeaderText = "政治";
            this.politicsDataGridViewTextBoxColumn.Name = "politicsDataGridViewTextBoxColumn";
            this.politicsDataGridViewTextBoxColumn.Width = 60;
            this.glamourDataGridViewTextBoxColumn.DataPropertyName = "BaseGlamour";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.glamourDataGridViewTextBoxColumn.DefaultCellStyle = style13;
            this.glamourDataGridViewTextBoxColumn.HeaderText = "魅力";
            this.glamourDataGridViewTextBoxColumn.Name = "glamourDataGridViewTextBoxColumn";
            this.glamourDataGridViewTextBoxColumn.Width = 60;
            this.bravenessDataGridViewTextBoxColumn.DataPropertyName = "BaseBraveness";
            style14.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.bravenessDataGridViewTextBoxColumn.DefaultCellStyle = style14;
            this.bravenessDataGridViewTextBoxColumn.HeaderText = "勇猛度";
            this.bravenessDataGridViewTextBoxColumn.Name = "bravenessDataGridViewTextBoxColumn";
            this.bravenessDataGridViewTextBoxColumn.Width = 70;
            this.calmnessDataGridViewTextBoxColumn.DataPropertyName = "BaseCalmness";
            style15.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.calmnessDataGridViewTextBoxColumn.DefaultCellStyle = style15;
            this.calmnessDataGridViewTextBoxColumn.HeaderText = "冷静度";
            this.calmnessDataGridViewTextBoxColumn.Name = "calmnessDataGridViewTextBoxColumn";
            this.calmnessDataGridViewTextBoxColumn.Width = 70;
            this.loyaltyDataGridViewTextBoxColumn.DataPropertyName = "Loyalty";
            style16.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.loyaltyDataGridViewTextBoxColumn.DefaultCellStyle = style16;
            this.loyaltyDataGridViewTextBoxColumn.HeaderText = "忠诚度";
            this.loyaltyDataGridViewTextBoxColumn.Name = "loyaltyDataGridViewTextBoxColumn";
            this.loyaltyDataGridViewTextBoxColumn.Width = 70;
            this.yearAvailableDataGridViewTextBoxColumn.DataPropertyName = "YearAvailable";
            style17.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.yearAvailableDataGridViewTextBoxColumn.DefaultCellStyle = style17;
            this.yearAvailableDataGridViewTextBoxColumn.HeaderText = "出场年";
            this.yearAvailableDataGridViewTextBoxColumn.Name = "yearAvailableDataGridViewTextBoxColumn";
            this.yearAvailableDataGridViewTextBoxColumn.Width = 70;
            this.yearBornDataGridViewTextBoxColumn.DataPropertyName = "YearBorn";
            style18.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.yearBornDataGridViewTextBoxColumn.DefaultCellStyle = style18;
            this.yearBornDataGridViewTextBoxColumn.HeaderText = "出生年";
            this.yearBornDataGridViewTextBoxColumn.Name = "yearBornDataGridViewTextBoxColumn";
            this.yearBornDataGridViewTextBoxColumn.Width = 70;
            this.yearDeadDataGridViewTextBoxColumn.DataPropertyName = "YearDead";
            style19.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.yearDeadDataGridViewTextBoxColumn.DefaultCellStyle = style19;
            this.yearDeadDataGridViewTextBoxColumn.HeaderText = "死亡年";
            this.yearDeadDataGridViewTextBoxColumn.Name = "yearDeadDataGridViewTextBoxColumn";
            this.yearDeadDataGridViewTextBoxColumn.Width = 70;
            this.idealDataGridViewTextBoxColumn.DataPropertyName = "Ideal";
            style20.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.idealDataGridViewTextBoxColumn.DefaultCellStyle = style20;
            this.idealDataGridViewTextBoxColumn.HeaderText = "相性";
            this.idealDataGridViewTextBoxColumn.Name = "idealDataGridViewTextBoxColumn";
            this.idealDataGridViewTextBoxColumn.Width = 60;
            this.personalLoyaltyDataGridViewTextBoxColumn.DataPropertyName = "PersonalLoyalty";
            this.personalLoyaltyDataGridViewTextBoxColumn.HeaderText = "义理";
            this.personalLoyaltyDataGridViewTextBoxColumn.Name = "personalLoyaltyDataGridViewTextBoxColumn";
            this.personalLoyaltyDataGridViewTextBoxColumn.Width = 60;
            this.ambitionDataGridViewTextBoxColumn.DataPropertyName = "Ambition";
            this.ambitionDataGridViewTextBoxColumn.HeaderText = "野心";
            this.ambitionDataGridViewTextBoxColumn.Name = "ambitionDataGridViewTextBoxColumn";
            this.ambitionDataGridViewTextBoxColumn.Width = 60;
            this.qualificationDataGridViewTextBoxColumn.DataPropertyName = "Qualification";
            this.qualificationDataGridViewTextBoxColumn.HeaderText = "录用";
            this.qualificationDataGridViewTextBoxColumn.Name = "qualificationDataGridViewTextBoxColumn";
            this.qualificationDataGridViewTextBoxColumn.Width = 60;
            this.valuationOnGovernmentDataGridViewTextBoxColumn.DataPropertyName = "ValuationOnGovernment";
            this.valuationOnGovernmentDataGridViewTextBoxColumn.HeaderText = "汉室";
            this.valuationOnGovernmentDataGridViewTextBoxColumn.Name = "valuationOnGovernmentDataGridViewTextBoxColumn";
            this.valuationOnGovernmentDataGridViewTextBoxColumn.Width = 60;
            this.strategyTendencyDataGridViewTextBoxColumn.DataPropertyName = "StrategyTendency";
            this.strategyTendencyDataGridViewTextBoxColumn.HeaderText = "战略倾向";
            this.strategyTendencyDataGridViewTextBoxColumn.Name = "strategyTendencyDataGridViewTextBoxColumn";
            this.strategyTendencyDataGridViewTextBoxColumn.Width = 90;
            this.oldFactionIDDataGridViewTextBoxColumn.DataPropertyName = "OldFactionID";
            style21.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.oldFactionIDDataGridViewTextBoxColumn.DefaultCellStyle = style21;
            this.oldFactionIDDataGridViewTextBoxColumn.HeaderText = "旧势力";
            this.oldFactionIDDataGridViewTextBoxColumn.Name = "oldFactionIDDataGridViewTextBoxColumn";
            this.oldFactionIDDataGridViewTextBoxColumn.Width = 70;
            this.prohibitedFactionIDDataGridViewTextBoxColumn.DataPropertyName = "ProhibitedFactionID";
            style22.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.prohibitedFactionIDDataGridViewTextBoxColumn.DefaultCellStyle = style22;
            this.prohibitedFactionIDDataGridViewTextBoxColumn.HeaderText = "禁止势力";
            this.prohibitedFactionIDDataGridViewTextBoxColumn.Name = "prohibitedFactionIDDataGridViewTextBoxColumn";
            this.prohibitedFactionIDDataGridViewTextBoxColumn.Width = 90;
            this.strainDataGridViewTextBoxColumn.DataPropertyName = "Strain";
            style23.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.strainDataGridViewTextBoxColumn.DefaultCellStyle = style23;
            this.strainDataGridViewTextBoxColumn.HeaderText = "血统";
            this.strainDataGridViewTextBoxColumn.Name = "strainDataGridViewTextBoxColumn";
            this.strainDataGridViewTextBoxColumn.Width = 60;
            this.fatherDataGridViewTextBoxColumn.DataPropertyName = "Father";
            style24.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.fatherDataGridViewTextBoxColumn.DefaultCellStyle = style24;
            this.fatherDataGridViewTextBoxColumn.HeaderText = "父亲";
            this.fatherDataGridViewTextBoxColumn.Name = "fatherDataGridViewTextBoxColumn";
            this.fatherDataGridViewTextBoxColumn.Width = 60;
            this.motherDataGridViewTextBoxColumn.DataPropertyName = "Mother";
            style25.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.motherDataGridViewTextBoxColumn.DefaultCellStyle = style25;
            this.motherDataGridViewTextBoxColumn.HeaderText = "母亲";
            this.motherDataGridViewTextBoxColumn.Name = "motherDataGridViewTextBoxColumn";
            this.motherDataGridViewTextBoxColumn.Width = 60;
            this.spouseDataGridViewTextBoxColumn.DataPropertyName = "Spouse";
            style26.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.spouseDataGridViewTextBoxColumn.DefaultCellStyle = style26;
            this.spouseDataGridViewTextBoxColumn.HeaderText = "配偶";
            this.spouseDataGridViewTextBoxColumn.Name = "spouseDataGridViewTextBoxColumn";
            this.spouseDataGridViewTextBoxColumn.Width = 60;
            this.brotherDataGridViewTextBoxColumn.DataPropertyName = "Brother";
            style27.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.brotherDataGridViewTextBoxColumn.DefaultCellStyle = style27;
            this.brotherDataGridViewTextBoxColumn.HeaderText = "兄长";
            this.brotherDataGridViewTextBoxColumn.Name = "brotherDataGridViewTextBoxColumn";
            this.brotherDataGridViewTextBoxColumn.Width = 60;
            this.generationDataGridViewTextBoxColumn.DataPropertyName = "Generation";
            style28.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.generationDataGridViewTextBoxColumn.DefaultCellStyle = style28;
            this.generationDataGridViewTextBoxColumn.HeaderText = "世代";
            this.generationDataGridViewTextBoxColumn.Name = "generationDataGridViewTextBoxColumn";
            this.generationDataGridViewTextBoxColumn.Width = 60;
            this.workKindDataGridViewTextBoxColumn.DataPropertyName = "WorkKind";
            this.workKindDataGridViewTextBoxColumn.HeaderText = "工作类型";
            this.workKindDataGridViewTextBoxColumn.Name = "workKindDataGridViewTextBoxColumn";
            this.workKindDataGridViewTextBoxColumn.Width = 90;
            this.cmsEditPerson.Items.AddRange(new ToolStripItem[] { this.编辑人物ToolStripMenuItem, this.添加新人物ToolStripMenuItem, this.删除选定人物ToolStripMenuItem, this.设置位置ToolStripMenuItem, this.设置为前一个位置ToolStripMenuItem, this.menuRecentLocation });
            this.cmsEditPerson.Name = "cmsEditPerson";
            this.cmsEditPerson.Size = new Size(0xad, 0x9e);
            this.编辑人物ToolStripMenuItem.Name = "编辑人物ToolStripMenuItem";
            this.编辑人物ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.编辑人物ToolStripMenuItem.Text = "编辑选定人物";
            this.编辑人物ToolStripMenuItem.Click += new EventHandler(this.编辑人物ToolStripMenuItem_Click);
            this.添加新人物ToolStripMenuItem.Name = "添加新人物ToolStripMenuItem";
            this.添加新人物ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.添加新人物ToolStripMenuItem.Text = "添加新人物";
            this.添加新人物ToolStripMenuItem.Click += new EventHandler(this.添加新人物ToolStripMenuItem_Click);
            this.设置位置ToolStripMenuItem.Name = "设置位置ToolStripMenuItem";
            this.设置位置ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.设置位置ToolStripMenuItem.Text = "设置位置";
            this.设置位置ToolStripMenuItem.Click += new EventHandler(this.设置位置ToolStripMenuItem_Click);
            this.设置为前一个位置ToolStripMenuItem.Name = "设置为前一个位置ToolStripMenuItem";
            this.设置为前一个位置ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.设置为前一个位置ToolStripMenuItem.Text = "设置为前一个位置";
            this.设置为前一个位置ToolStripMenuItem.Click += new EventHandler(this.设置为前一个位置ToolStripMenuItem_Click);
            this.menuRecentLocation.Name = "menuRecentLocation";
            this.menuRecentLocation.Size = new Size(0xac, 0x16);
            this.menuRecentLocation.Text = "最近的位置";
            this.personBindingSource.AllowNew = false;
            this.personBindingSource.DataSource = typeof(Person);
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WorkKind";
            this.dataGridViewTextBoxColumn1.HeaderText = "工作类型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            this.删除选定人物ToolStripMenuItem.Name = "删除选定人物ToolStripMenuItem";
            this.删除选定人物ToolStripMenuItem.Size = new Size(0xac, 0x16);
            this.删除选定人物ToolStripMenuItem.Text = "删除选定人物";
            this.删除选定人物ToolStripMenuItem.Click += new EventHandler(this.删除选定人物ToolStripMenuItem_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(870, 0x20b);
            base.Controls.Add(this.dgvPersons);
            base.Name = "frmPersonList";
            base.ShowInTaskbar = false;
            this.Text = "编辑人物";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmPersonList_Load);
            ((ISupportInitialize) this.dgvPersons).EndInit();
            this.cmsEditPerson.ResumeLayout(false);
            ((ISupportInitialize) this.personBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.personBindingSource.DataSource = null;
            this.personBindingSource.DataSource = this.Persons;
        }

        private void RecentLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((this.Persons != null) && (this.Persons.Count != 0)) && (this.lastArchitecture != null))
            {
                PersonList list = new PersonList();
                for (int i = 0; i < this.dgvPersons.SelectedRows.Count; i++)
                {
                    list.Add(this.dgvPersons.SelectedRows[i].DataBoundItem as Person);
                }
                this.lastArchitecture = (sender as ToolStripItem).Tag as Architecture;
                foreach (Person person in list)
                {
                    this.ApplyLastArchitecture(person);
                }
                this.dgvPersons.Invalidate();
            }
        }

        private void 编辑人物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvPersons.IsCurrentCellInEditMode)
            {
                this.EditPersons();
            }
        }

        private void 删除选定人物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("确定要删除选定人物吗？", "请确认", MessageBoxButtons.OKCancel) == DialogResult.OK) && ((this.Persons != null) && (this.Persons.Count != 0)))
            {
                PersonList list = new PersonList();
                for (int i = 0; i < this.dgvPersons.SelectedRows.Count; i++)
                {
                    Person dataBoundItem = this.dgvPersons.SelectedRows[i].DataBoundItem as Person;
                    dataBoundItem.LocationArchitecture = null;
                    dataBoundItem.Status = PersonStatus.None;
                    this.MainForm.Scenario.Persons.Remove(dataBoundItem);
                }
                this.RebindDataSource();
            }
        }

        private void 设置为前一个位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (((this.Persons != null) && (this.Persons.Count != 0)) && (this.lastArchitecture != null))
            {
                PersonList list = new PersonList();
                for (int i = 0; i < this.dgvPersons.SelectedRows.Count; i++)
                {
                    list.Add(this.dgvPersons.SelectedRows[i].DataBoundItem as Person);
                }
                foreach (Person person in list)
                {
                    this.ApplyLastArchitecture(person);
                }
                this.dgvPersons.Invalidate();
            }
        }

        private void 设置位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                PersonList list = new PersonList();
                for (int i = 0; i < this.dgvPersons.SelectedRows.Count; i++)
                {
                    list.Add(this.dgvPersons.SelectedRows[i].DataBoundItem as Person);
                }
                frmSelectArchitectureList list2 = new frmSelectArchitectureList();
                list2.Architectures = this.Persons[0].Scenario.Architectures;
                list2.SelectOne = true;
                list2.ShowDialog();
                if (list2.IDList.Count > 0)
                {
                    this.lastArchitecture = this.Persons[0].Scenario.Architectures.GetGameObject(list2.IDList[0]) as Architecture;
                    this.menuRecentLocation.DropDownItems.Add(this.lastArchitecture.Name, null, new EventHandler(this.RecentLocationToolStripMenuItem_Click)).Tag = this.lastArchitecture;
                    if (this.menuRecentLocation.DropDownItems.Count > 10)
                    {
                        this.menuRecentLocation.DropDownItems.RemoveAt(0);
                    }
                    foreach (Person person in list)
                    {
                        this.ApplyLastArchitecture(person);
                    }
                    this.dgvPersons.Invalidate();
                }
            }
        }

        private void 添加新人物ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0x2328; i <= 0x270f; i++)
            {
                if (!this.Persons.HasGameObject(i))
                {
                    Person t = new Person();
                    t.Scenario = this.MainForm.Scenario;
                    t.ID = i;
                    t.SurName = "新";
                    t.GivenName = "人物";
                    t.PictureIndex = 0x7d1;
                    t.Strain = t.ID;
                    t.Alive = true;
                    t.IdealTendency = this.MainForm.Scenario.GameCommonData.AllIdealTendencyKinds[0] as IdealTendencyKind;
                    t.Character = this.MainForm.Scenario.GameCommonData.AllCharacterKinds[0];
                    this.Persons.Add(t);
                    Biography biography = this.MainForm.Scenario.AllBiographies.GetBiography(t.ID);
                    if (biography == null)
                    {
                        biography = new Biography();
                        biography.ID = t.ID;
                        biography.Scenario = t.Scenario;
                        biography.FactionColor = 0;
                        biography.MilitaryKinds.AddBasicMilitaryKinds(this.MainForm.Scenario);
                        t.Scenario.AllBiographies.AddBiography(biography);
                    }
                    t.PersonBiography = biography;
                    this.RebindDataSource();
                    break;
                }
            }
        }
    }
}

