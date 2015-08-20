namespace MapEditor.Forms.SectionForms
{
    using GameObjects;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmSelectSectionList : Form
    {
        private IContainer components = null;
        private DataGridView dgvSections;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn kindDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private BindingSource sectionBindingSource;
        public SectionList Sections;
        public Section SelectedSection;
        private bool smalltobig = false;

        public frmSelectSectionList()
        {
            this.InitializeComponent();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PropertyComparer comparer = new PropertyComparer(this.dgvSections.Columns[e.ColumnIndex].DataPropertyName, this.dgvSections.Columns[e.ColumnIndex].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleRight, this.smalltobig);
            this.Sections.Sort(comparer);
            this.RebindDataSource();
            this.smalltobig = !this.smalltobig;
        }

        private void dgvSections_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!this.dgvSections.IsCurrentCellInEditMode)
            {
                this.SelectedSection = this.dgvSections.SelectedRows[0].DataBoundItem as Section;
                base.Close();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmSelectSectionList_Load(object sender, EventArgs e)
        {
            if (this.Sections != null)
            {
                this.InitializeListData();
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            this.dgvSections = new DataGridView();
            this.iDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.sectionBindingSource = new BindingSource(this.components);
            ((ISupportInitialize) this.dgvSections).BeginInit();
            ((ISupportInitialize) this.sectionBindingSource).BeginInit();
            base.SuspendLayout();
            this.dgvSections.AllowUserToAddRows = false;
            this.dgvSections.AllowUserToDeleteRows = false;
            this.dgvSections.AllowUserToOrderColumns = true;
            this.dgvSections.AutoGenerateColumns = false;
            this.dgvSections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Columns.AddRange(new DataGridViewColumn[] { this.iDDataGridViewTextBoxColumn, this.nameDataGridViewTextBoxColumn });
            this.dgvSections.DataSource = this.sectionBindingSource;
            this.dgvSections.Dock = DockStyle.Fill;
            this.dgvSections.Location = new Point(0, 0);
            this.dgvSections.MultiSelect = false;
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.ReadOnly = true;
            this.dgvSections.RowTemplate.Height = 0x17;
            this.dgvSections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSections.Size = new Size(0x2be, 0x202);
            this.dgvSections.TabIndex = 0;
            this.dgvSections.ColumnHeaderMouseClick += new DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dgvSections.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvSections_CellMouseDoubleClick);
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.iDDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 60;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 120;
            this.sectionBindingSource.DataSource = typeof(Section);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2be, 0x202);
            base.Controls.Add(this.dgvSections);
            base.Name = "frmSelectSectionList";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "选择军团";
            base.Load += new EventHandler(this.frmSelectSectionList_Load);
            ((ISupportInitialize) this.dgvSections).EndInit();
            ((ISupportInitialize) this.sectionBindingSource).EndInit();
            base.ResumeLayout(false);
        }

        private void InitializeListData()
        {
            this.RebindDataSource();
        }

        private void RebindDataSource()
        {
            this.sectionBindingSource.DataSource = null;
            this.sectionBindingSource.DataSource = this.Sections;
        }
    }
}

