namespace MapEditor.Forms.PersonForms
{
    using GameObjects;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectPersonList : Form
    {
        private DataGridViewTextBoxColumn bravenessDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn calmnessDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn characterDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn commandDataGridViewTextBoxColumn;
        private IContainer components = null;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridView dgvPersons;
        private DataGridViewTextBoxColumn factionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn glamourDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        public List<int> IDList = new List<int>();
        private DataGridViewTextBoxColumn intelligenceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn locationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource personBindingSource;
        public PersonList Persons;
        private DataGridViewTextBoxColumn politicsDataGridViewTextBoxColumn;
        public Person SelectedPerson;
        public bool SelectOne = false;
        private bool smalltobig = false;
        private DataGridViewTextBoxColumn strengthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearBornDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn yearDeadDataGridViewTextBoxColumn;

        public frmSelectPersonList()
        {
            this.InitializeComponent();
        }

        private void dgvPersons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvPersons.IsCurrentCellInEditMode)
            {
                this.SelectedPerson = this.dgvPersons.SelectedRows[0].DataBoundItem as Person;
                int iD = this.SelectedPerson.ID;
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
            this.dgvPersons = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.factionDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.strengthDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.commandDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.intelligenceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.politicsDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.glamourDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.bravenessDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.calmnessDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.yearBornDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.yearDeadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.personBindingSource = new BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dgvPersons).BeginInit();
            ((ISupportInitialize) this.personBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvPersons.AllowUserToAddRows = false;
            this.dgvPersons.AllowUserToDeleteRows = false;
            this.dgvPersons.AutoGenerateColumns = false;
            this.dgvPersons.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersons.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn, this.factionDataGridViewTextBoxColumn, this.locationDataGridViewTextBoxColumn, this.strengthDataGridViewTextBoxColumn, this.commandDataGridViewTextBoxColumn, this.intelligenceDataGridViewTextBoxColumn, this.politicsDataGridViewTextBoxColumn, this.glamourDataGridViewTextBoxColumn, this.bravenessDataGridViewTextBoxColumn, this.calmnessDataGridViewTextBoxColumn, this.yearBornDataGridViewTextBoxColumn, this.yearDeadDataGridViewTextBoxColumn });
            this.dgvPersons.DataSource = this.personBindingSource;
            this.dgvPersons.Dock = DockStyle.Fill;
            this.dgvPersons.Location = new Point(0, 0);
            this.dgvPersons.Name = "dgvPersons";
            this.dgvPersons.ReadOnly = true;
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
            this.factionDataGridViewTextBoxColumn.DataPropertyName = "Faction";
            style4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style4.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.factionDataGridViewTextBoxColumn.DefaultCellStyle = style4;
            this.factionDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionDataGridViewTextBoxColumn.Name = "factionDataGridViewTextBoxColumn";
            this.factionDataGridViewTextBoxColumn.ReadOnly = true;
            this.factionDataGridViewTextBoxColumn.Width = 60;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            style5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style5.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.locationDataGridViewTextBoxColumn.DefaultCellStyle = style5;
            this.locationDataGridViewTextBoxColumn.HeaderText = "位置";
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationDataGridViewTextBoxColumn.Width = 60;
            this.strengthDataGridViewTextBoxColumn.DataPropertyName = "Strength";
            style6.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.strengthDataGridViewTextBoxColumn.DefaultCellStyle = style6;
            this.strengthDataGridViewTextBoxColumn.HeaderText = "武勇";
            this.strengthDataGridViewTextBoxColumn.Name = "strengthDataGridViewTextBoxColumn";
            this.strengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.strengthDataGridViewTextBoxColumn.Width = 60;
            this.commandDataGridViewTextBoxColumn.DataPropertyName = "Command";
            style7.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.commandDataGridViewTextBoxColumn.DefaultCellStyle = style7;
            this.commandDataGridViewTextBoxColumn.HeaderText = "统率";
            this.commandDataGridViewTextBoxColumn.Name = "commandDataGridViewTextBoxColumn";
            this.commandDataGridViewTextBoxColumn.ReadOnly = true;
            this.commandDataGridViewTextBoxColumn.Width = 60;
            this.intelligenceDataGridViewTextBoxColumn.DataPropertyName = "Intelligence";
            style8.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.intelligenceDataGridViewTextBoxColumn.DefaultCellStyle = style8;
            this.intelligenceDataGridViewTextBoxColumn.HeaderText = "智谋";
            this.intelligenceDataGridViewTextBoxColumn.Name = "intelligenceDataGridViewTextBoxColumn";
            this.intelligenceDataGridViewTextBoxColumn.ReadOnly = true;
            this.intelligenceDataGridViewTextBoxColumn.Width = 60;
            this.politicsDataGridViewTextBoxColumn.DataPropertyName = "Politics";
            style9.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.politicsDataGridViewTextBoxColumn.DefaultCellStyle = style9;
            this.politicsDataGridViewTextBoxColumn.HeaderText = "政治";
            this.politicsDataGridViewTextBoxColumn.Name = "politicsDataGridViewTextBoxColumn";
            this.politicsDataGridViewTextBoxColumn.ReadOnly = true;
            this.politicsDataGridViewTextBoxColumn.Width = 60;
            this.glamourDataGridViewTextBoxColumn.DataPropertyName = "Glamour";
            style10.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.glamourDataGridViewTextBoxColumn.DefaultCellStyle = style10;
            this.glamourDataGridViewTextBoxColumn.HeaderText = "魅力";
            this.glamourDataGridViewTextBoxColumn.Name = "glamourDataGridViewTextBoxColumn";
            this.glamourDataGridViewTextBoxColumn.ReadOnly = true;
            this.glamourDataGridViewTextBoxColumn.Width = 60;
            this.bravenessDataGridViewTextBoxColumn.DataPropertyName = "Braveness";
            style11.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.bravenessDataGridViewTextBoxColumn.DefaultCellStyle = style11;
            this.bravenessDataGridViewTextBoxColumn.HeaderText = "勇猛度";
            this.bravenessDataGridViewTextBoxColumn.Name = "bravenessDataGridViewTextBoxColumn";
            this.bravenessDataGridViewTextBoxColumn.ReadOnly = true;
            this.bravenessDataGridViewTextBoxColumn.Width = 70;
            this.calmnessDataGridViewTextBoxColumn.DataPropertyName = "Calmness";
            style12.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.calmnessDataGridViewTextBoxColumn.DefaultCellStyle = style12;
            this.calmnessDataGridViewTextBoxColumn.HeaderText = "冷静度";
            this.calmnessDataGridViewTextBoxColumn.Name = "calmnessDataGridViewTextBoxColumn";
            this.calmnessDataGridViewTextBoxColumn.ReadOnly = true;
            this.calmnessDataGridViewTextBoxColumn.Width = 70;
            this.yearBornDataGridViewTextBoxColumn.DataPropertyName = "YearBorn";
            style13.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.yearBornDataGridViewTextBoxColumn.DefaultCellStyle = style13;
            this.yearBornDataGridViewTextBoxColumn.HeaderText = "出生年";
            this.yearBornDataGridViewTextBoxColumn.Name = "yearBornDataGridViewTextBoxColumn";
            this.yearBornDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearBornDataGridViewTextBoxColumn.Width = 70;
            this.yearDeadDataGridViewTextBoxColumn.DataPropertyName = "YearDead";
            style14.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.yearDeadDataGridViewTextBoxColumn.DefaultCellStyle = style14;
            this.yearDeadDataGridViewTextBoxColumn.HeaderText = "死亡年";
            this.yearDeadDataGridViewTextBoxColumn.Name = "yearDeadDataGridViewTextBoxColumn";
            this.yearDeadDataGridViewTextBoxColumn.ReadOnly = true;
            this.yearDeadDataGridViewTextBoxColumn.Width = 70;
            this.personBindingSource.AllowNew = false;
            this.personBindingSource.DataSource = typeof(Person);
            this.dataGridViewTextBoxColumn1.DataPropertyName = "WorkKind";
            this.dataGridViewTextBoxColumn1.HeaderText = "工作类型";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(870, 0x20b);
            base.Controls.Add(this.dgvPersons);
            base.Name = "frmSelectPersonList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择人物（双击）";
            base.Load += new EventHandler(this.frmPersonList_Load);
            ((ISupportInitialize) this.dgvPersons).EndInit();
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
    }
}

