namespace MapEditor.Forms.MilitaryForms
{
    using GameObjects;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectMilitaryList : Form
    {
        private IContainer components = null;
        private DataGridView dgvMilitaries;
        private DataGridViewTextBoxColumn experienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn followedLeaderIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kindDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderExperienceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn leaderIDDataGridViewTextBoxColumn;
        public MilitaryList Militaries;
        private BindingSource militaryBindingSource;
        private DataGridViewTextBoxColumn moraleDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        public MilitaryList SelectedMilitaries = new MilitaryList();
        public bool SelectOne = false;
        private bool smalltobig = false;

        public frmSelectMilitaryList()
        {
            this.InitializeComponent();
        }

        private void dgvMilitaries_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvMilitaries.IsCurrentCellInEditMode)
            {
                this.SelectedMilitaries.AddMilitary(this.dgvMilitaries.SelectedRows[0].DataBoundItem as Military);
                if (this.SelectOne)
                {
                    base.Close();
                }
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

        private void frmSelectMilitaryList_Load(object sender, EventArgs e)
        {
            if (this.Militaries != null)
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
            this.dgvMilitaries = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.kindDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.moraleDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.experienceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.followedLeaderIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.leaderIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.leaderExperienceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.militaryBindingSource = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvMilitaries).BeginInit();
            ((ISupportInitialize) this.militaryBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvMilitaries.AllowUserToAddRows = false;
            this.dgvMilitaries.AllowUserToDeleteRows = false;
            this.dgvMilitaries.AllowUserToOrderColumns = true;
            this.dgvMilitaries.AutoGenerateColumns = false;
            this.dgvMilitaries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaries.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.kindDataGridViewTextBoxColumn, this.quantityDataGridViewTextBoxColumn, this.moraleDataGridViewTextBoxColumn, this.experienceDataGridViewTextBoxColumn, this.followedLeaderIDDataGridViewTextBoxColumn, this.leaderIDDataGridViewTextBoxColumn, this.leaderExperienceDataGridViewTextBoxColumn });
            this.dgvMilitaries.DataSource = this.militaryBindingSource;
            this.dgvMilitaries.Dock = DockStyle.Fill;
            this.dgvMilitaries.Location = new Point(0, 0);
            this.dgvMilitaries.Name = "dgvMilitaries";
            this.dgvMilitaries.ReadOnly = true;
            style.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvMilitaries.RowsDefaultCellStyle = style;
            this.dgvMilitaries.RowTemplate.Height = 0x17;
            this.dgvMilitaries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvMilitaries.Size = new Size(0x371, 0x202);
            this.dgvMilitaries.TabIndex = 3;
            this.dgvMilitaries.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dgvMilitaries_ColumnHeaderMouseClick);
            this.dgvMilitaries.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvMilitaries_CellMouseDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 40;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindDataGridViewTextBoxColumn.DataPropertyName = "Kind";
            this.kindDataGridViewTextBoxColumn.HeaderText = "兵种";
            this.kindDataGridViewTextBoxColumn.Name = "kindDataGridViewTextBoxColumn";
            this.kindDataGridViewTextBoxColumn.ReadOnly = true;
            this.kindDataGridViewTextBoxColumn.Width = 150;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            style3.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = style3;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "数量";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 80;
            this.moraleDataGridViewTextBoxColumn.DataPropertyName = "Morale";
            style4.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.moraleDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.moraleDataGridViewTextBoxColumn.HeaderText = "士气";
            this.moraleDataGridViewTextBoxColumn.Name = "moraleDataGridViewTextBoxColumn";
            this.moraleDataGridViewTextBoxColumn.ReadOnly = true;
            this.moraleDataGridViewTextBoxColumn.Width = 60;
            this.experienceDataGridViewTextBoxColumn.DataPropertyName = "Experience";
            style5.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.experienceDataGridViewTextBoxColumn.DefaultCellStyle = style5;
            this.experienceDataGridViewTextBoxColumn.HeaderText = "经验";
            this.experienceDataGridViewTextBoxColumn.Name = "experienceDataGridViewTextBoxColumn";
            this.experienceDataGridViewTextBoxColumn.ReadOnly = true;
            this.experienceDataGridViewTextBoxColumn.Width = 70;
            this.followedLeaderIDDataGridViewTextBoxColumn.DataPropertyName = "FollowedLeaderID";
            style6.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.followedLeaderIDDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.followedLeaderIDDataGridViewTextBoxColumn.HeaderText = "追随将领";
            this.followedLeaderIDDataGridViewTextBoxColumn.Name = "followedLeaderIDDataGridViewTextBoxColumn";
            this.followedLeaderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.leaderIDDataGridViewTextBoxColumn.DataPropertyName = "LeaderID";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.leaderIDDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.leaderIDDataGridViewTextBoxColumn.HeaderText = "当前将领";
            this.leaderIDDataGridViewTextBoxColumn.Name = "leaderIDDataGridViewTextBoxColumn";
            this.leaderIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.leaderExperienceDataGridViewTextBoxColumn.DataPropertyName = "LeaderExperience";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.leaderExperienceDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.leaderExperienceDataGridViewTextBoxColumn.HeaderText = "信任度";
            this.leaderExperienceDataGridViewTextBoxColumn.Name = "leaderExperienceDataGridViewTextBoxColumn";
            this.leaderExperienceDataGridViewTextBoxColumn.ReadOnly = true;
            this.militaryBindingSource.DataSource = typeof(Military);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x371, 0x202);
            base.Controls.Add(this.dgvMilitaries);
            base.Name = "frmSelectMilitaryList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "frmSelectMilitaryList";
            base.Load += new EventHandler(this.frmSelectMilitaryList_Load);
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
    }
}

