namespace MapEditor.Forms
{
    using GameObjects;
    using MapEditor.Forms.MilitaryForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmMilitaryList : Form
    {
        private ContextMenuStrip cmsEditMilitary;
        private DataGridViewTextBoxColumn combativityDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridViewTextBoxColumn defenceDataGridViewTextBoxColumn;
        private DataGridView dgvMilitaries;
        private DataGridViewTextBoxColumn experienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn followedLeaderIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn followedLeaderNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn injuryQuantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kindStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderExperienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderNameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationStringDataGridViewTextBoxColumn;
        public MilitaryList Militaries;
        private BindingSource militaryBindingSource;
        private DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn offenceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn recruitmentStringDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scalesDataGridViewTextBoxColumn;
        public GameScenario Scenario;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn trainingStringDataGridViewTextBoxColumn;
        private ToolStripMenuItem 编辑编队ToolStripMenuItem;

        public frmMilitaryList()
        {
            this.InitializeComponent();
        }

        private void dgvMilitaries_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvMilitaries.IsCurrentCellInEditMode)
            {
                this.EditMilitaries();
            }
        }

        private void dgvMilitaries_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvMilitaries.Columns[e.ColumnIndex].DataPropertyName, this.dgvMilitaries.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Militaries.Sort(comparer);
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

        private void EditMilitaries()
        {
            MilitaryList list = new MilitaryList();
            for (int i = 0; i < this.dgvMilitaries.SelectedRows.Count; i++)
            {
                list.Add(this.Militaries[this.dgvMilitaries.SelectedRows[i].Index]);
            }
            if (list.Count != 0)
            {
                frmEditMilitary military = new frmEditMilitary();
                military.Militaries = list;
                military.ShowDialog();
                this.dgvMilitaries.Invalidate();
            }
        }

        private void frmMilitaryList_Load(object sender, EventArgs e)
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
            this.cmsEditMilitary = new ContextMenuStrip(this.components);
            this.编辑编队ToolStripMenuItem = new ToolStripMenuItem();
            this.dgvMilitaries = new DataGridView();
            this.militaryBindingSource = new BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.kindStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.offenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.defenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.locationStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.scalesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.combativityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.experienceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.injuryQuantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.followedLeaderIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.followedLeaderNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.leaderIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.leaderNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.leaderExperienceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.trainingStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.recruitmentStringDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.cmsEditMilitary.SuspendLayout();
            ((ISupportInitialize) this.dgvMilitaries).BeginInit();
            ((ISupportInitialize) this.militaryBindingSource).BeginInit();
            base.SuspendLayout();
            this.cmsEditMilitary.Items.AddRange(new ToolStripItem[] { this.编辑编队ToolStripMenuItem });
            this.cmsEditMilitary.Name = "cmsEditMilitary";
            this.cmsEditMilitary.Size = new Size(0x7d, 0x1a);
            this.编辑编队ToolStripMenuItem.Name = "编辑编队ToolStripMenuItem";
            this.编辑编队ToolStripMenuItem.Size = new Size(0x7c, 0x16);
            this.编辑编队ToolStripMenuItem.Text = "编辑编队";
            this.编辑编队ToolStripMenuItem.Click += new EventHandler(this.编辑编队ToolStripMenuItem_Click);
            this.dgvMilitaries.AutoGenerateColumns = false;
            this.dgvMilitaries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaries.Columns.AddRange(new DataGridViewColumn[] { 
                this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.kindStringDataGridViewTextBoxColumn, this.offenceDataGridViewTextBoxColumn, this.defenceDataGridViewTextBoxColumn, this.locationStringDataGridViewTextBoxColumn, this.scalesDataGridViewTextBoxColumn, this.quantityDataGridViewTextBoxColumn, this.moraleDataGridViewTextBoxColumn, this.combativityDataGridViewTextBoxColumn, this.experienceDataGridViewTextBoxColumn, this.injuryQuantityDataGridViewTextBoxColumn, this.followedLeaderIDDataGridViewTextBoxColumn, this.followedLeaderNameDataGridViewTextBoxColumn, this.leaderIDDataGridViewTextBoxColumn, this.leaderNameDataGridViewTextBoxColumn, 
                this.leaderExperienceDataGridViewTextBoxColumn, this.trainingStringDataGridViewTextBoxColumn, this.recruitmentStringDataGridViewTextBoxColumn
             });
            this.dgvMilitaries.DataSource = this.militaryBindingSource;
            this.dgvMilitaries.Dock = DockStyle.Fill;
            this.dgvMilitaries.Location = new Point(0, 0);
            this.dgvMilitaries.Name = "dgvMilitaries";
            this.dgvMilitaries.RowTemplate.Height = 0x17;
            this.dgvMilitaries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMilitaries.Size = new Size(0x30e, 0x223);
            this.dgvMilitaries.TabIndex = 1;
            this.dgvMilitaries.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvMilitaries_ColumnHeaderMouseClick);
            this.dgvMilitaries.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvMilitaries_CellMouseDoubleClick);
            this.militaryBindingSource.AllowNew = false;
            this.militaryBindingSource.DataSource = typeof(Military);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.iDDataGridViewTextBoxColumn.Frozen = true;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 50;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            style2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.nameDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 80;
            this.kindStringDataGridViewTextBoxColumn.DataPropertyName = "KindString";
            style3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style3.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.kindStringDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.kindStringDataGridViewTextBoxColumn.Frozen = true;
            this.kindStringDataGridViewTextBoxColumn.HeaderText = "兵种";
            this.kindStringDataGridViewTextBoxColumn.Name = "kindStringDataGridViewTextBoxColumn";
            this.kindStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindStringDataGridViewTextBoxColumn.Width = 80;
            this.offenceDataGridViewTextBoxColumn.DataPropertyName = "Offence";
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            style4.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.offenceDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.offenceDataGridViewTextBoxColumn.HeaderText = "攻击力";
            this.offenceDataGridViewTextBoxColumn.Name = "offenceDataGridViewTextBoxColumn";
            this.offenceDataGridViewTextBoxColumn.ReadOnly = true;
            this.offenceDataGridViewTextBoxColumn.Width = 80;
            this.defenceDataGridViewTextBoxColumn.DataPropertyName = "Defence";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.defenceDataGridViewTextBoxColumn.DefaultCellStyle = style5;
            this.defenceDataGridViewTextBoxColumn.HeaderText = "防御力";
            this.defenceDataGridViewTextBoxColumn.Name = "defenceDataGridViewTextBoxColumn";
            this.defenceDataGridViewTextBoxColumn.ReadOnly = true;
            this.defenceDataGridViewTextBoxColumn.Width = 80;
            this.locationStringDataGridViewTextBoxColumn.DataPropertyName = "LocationString";
            style6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style6.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.locationStringDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.locationStringDataGridViewTextBoxColumn.HeaderText = "所在";
            this.locationStringDataGridViewTextBoxColumn.Name = "locationStringDataGridViewTextBoxColumn";
            this.locationStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationStringDataGridViewTextBoxColumn.Width = 80;
            this.scalesDataGridViewTextBoxColumn.DataPropertyName = "Scales";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            style7.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.scalesDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.scalesDataGridViewTextBoxColumn.HeaderText = "规模";
            this.scalesDataGridViewTextBoxColumn.Name = "scalesDataGridViewTextBoxColumn";
            this.scalesDataGridViewTextBoxColumn.ReadOnly = true;
            this.scalesDataGridViewTextBoxColumn.Width = 60;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "数量";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            this.moraleDataGridViewTextBoxColumn.DataPropertyName = "Morale";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.moraleDataGridViewTextBoxColumn.DefaultCellStyle = style9;
            this.moraleDataGridViewTextBoxColumn.HeaderText = "士气";
            this.moraleDataGridViewTextBoxColumn.Name = "moraleDataGridViewTextBoxColumn";
            this.moraleDataGridViewTextBoxColumn.Width = 60;
            this.combativityDataGridViewTextBoxColumn.DataPropertyName = "Combativity";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.combativityDataGridViewTextBoxColumn.DefaultCellStyle = style10;
            this.combativityDataGridViewTextBoxColumn.HeaderText = "战意";
            this.combativityDataGridViewTextBoxColumn.Name = "combativityDataGridViewTextBoxColumn";
            this.combativityDataGridViewTextBoxColumn.Width = 60;
            this.experienceDataGridViewTextBoxColumn.DataPropertyName = "Experience";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.experienceDataGridViewTextBoxColumn.DefaultCellStyle = style11;
            this.experienceDataGridViewTextBoxColumn.HeaderText = "经验";
            this.experienceDataGridViewTextBoxColumn.Name = "experienceDataGridViewTextBoxColumn";
            this.experienceDataGridViewTextBoxColumn.Width = 80;
            this.injuryQuantityDataGridViewTextBoxColumn.DataPropertyName = "InjuryQuantity";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.injuryQuantityDataGridViewTextBoxColumn.DefaultCellStyle = style12;
            this.injuryQuantityDataGridViewTextBoxColumn.HeaderText = "伤兵";
            this.injuryQuantityDataGridViewTextBoxColumn.Name = "injuryQuantityDataGridViewTextBoxColumn";
            this.injuryQuantityDataGridViewTextBoxColumn.Width = 80;
            this.followedLeaderIDDataGridViewTextBoxColumn.DataPropertyName = "FollowedLeaderID";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.followedLeaderIDDataGridViewTextBoxColumn.DefaultCellStyle = style13;
            this.followedLeaderIDDataGridViewTextBoxColumn.HeaderText = "追随将领ID";
            this.followedLeaderIDDataGridViewTextBoxColumn.Name = "followedLeaderIDDataGridViewTextBoxColumn";
            this.followedLeaderIDDataGridViewTextBoxColumn.Width = 120;
            this.followedLeaderNameDataGridViewTextBoxColumn.DataPropertyName = "FollowedLeaderName";
            style14.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style14.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.followedLeaderNameDataGridViewTextBoxColumn.DefaultCellStyle = style14;
            this.followedLeaderNameDataGridViewTextBoxColumn.HeaderText = "追随将领姓名";
            this.followedLeaderNameDataGridViewTextBoxColumn.Name = "followedLeaderNameDataGridViewTextBoxColumn";
            this.followedLeaderNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.followedLeaderNameDataGridViewTextBoxColumn.Width = 120;
            this.leaderIDDataGridViewTextBoxColumn.DataPropertyName = "LeaderID";
            style15.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.leaderIDDataGridViewTextBoxColumn.DefaultCellStyle = style15;
            this.leaderIDDataGridViewTextBoxColumn.HeaderText = "当前将领ID";
            this.leaderIDDataGridViewTextBoxColumn.Name = "leaderIDDataGridViewTextBoxColumn";
            this.leaderIDDataGridViewTextBoxColumn.Width = 120;
            this.leaderNameDataGridViewTextBoxColumn.DataPropertyName = "LeaderName";
            style16.Alignment = DataGridViewContentAlignment.MiddleLeft;
            style16.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.leaderNameDataGridViewTextBoxColumn.DefaultCellStyle = style16;
            this.leaderNameDataGridViewTextBoxColumn.HeaderText = "当前将领姓名";
            this.leaderNameDataGridViewTextBoxColumn.Name = "leaderNameDataGridViewTextBoxColumn";
            this.leaderNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.leaderNameDataGridViewTextBoxColumn.Width = 120;
            this.leaderExperienceDataGridViewTextBoxColumn.DataPropertyName = "LeaderExperience";
            style17.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.leaderExperienceDataGridViewTextBoxColumn.DefaultCellStyle = style17;
            this.leaderExperienceDataGridViewTextBoxColumn.HeaderText = "当前将领信任度";
            this.leaderExperienceDataGridViewTextBoxColumn.Name = "leaderExperienceDataGridViewTextBoxColumn";
            this.leaderExperienceDataGridViewTextBoxColumn.Width = 120;
            this.trainingStringDataGridViewTextBoxColumn.DataPropertyName = "TrainingString";
            style18.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style18.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.trainingStringDataGridViewTextBoxColumn.DefaultCellStyle = style18;
            this.trainingStringDataGridViewTextBoxColumn.HeaderText = "训练";
            this.trainingStringDataGridViewTextBoxColumn.Name = "trainingStringDataGridViewTextBoxColumn";
            this.trainingStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.trainingStringDataGridViewTextBoxColumn.Width = 80;
            this.recruitmentStringDataGridViewTextBoxColumn.DataPropertyName = "RecruitmentString";
            style19.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style19.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.recruitmentStringDataGridViewTextBoxColumn.DefaultCellStyle = style19;
            this.recruitmentStringDataGridViewTextBoxColumn.HeaderText = "补充";
            this.recruitmentStringDataGridViewTextBoxColumn.Name = "recruitmentStringDataGridViewTextBoxColumn";
            this.recruitmentStringDataGridViewTextBoxColumn.ReadOnly = true;
            this.recruitmentStringDataGridViewTextBoxColumn.Width = 80;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x30e, 0x223);
            base.Controls.Add(this.dgvMilitaries);
            base.Name = "frmMilitaryList";
            base.ShowInTaskbar = false;
            this.Text = "编队列表";
            base.WindowState = FormWindowState.Maximized;
            base.Load += new EventHandler(this.frmMilitaryList_Load);
            this.cmsEditMilitary.ResumeLayout(false);
            ((ISupportInitialize) this.dgvMilitaries).EndInit();
            ((ISupportInitialize) this.militaryBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.militaryBindingSource.DataSource = null;
            this.militaryBindingSource.DataSource = this.Militaries;
        }

        private void 编辑编队ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.dgvMilitaries.IsCurrentCellInEditMode)
            {
                this.EditMilitaries();
            }
        }
    }
}

