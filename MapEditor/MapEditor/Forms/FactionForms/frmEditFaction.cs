namespace MapEditor.Forms.FactionForms
{
    using GameObjects;
    using GameObjects.FactionDetail;
    using GameObjects.TroopDetail;
    using MapEditor.Forms.ArchitectureForms;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditFaction : Form
    {
        private Button btnAddArchitectures;
        private Button btnAddMilitaryKind;
        private Button btnAllMilitaryFull;
        private Button btnCancelAllTechniques;
        private Button btnEditArchitecture;
        private Button btnInitializeAllDiplomaticRelations;
        private Button btnRemoveArchitectures;
        private Button btnRemoveMilitaryKind;
        private Button btnResetDiplomaticRelations;
        private Button btnSelectAllTechniques;
        private ComboBox cbFactionColor;
        private ComboBox cbMilitaryKind;
        private ComboBox cbUpgradingTechnique;
        private CheckedListBox clbArchitectures;
        private CheckedListBox clbBaseMilitaryKinds;
        private CheckedListBox clbTechniques;
        private IContainer components = null;
        private DataGridView dgvDiplomaticRelation;
        private BindingSource diplomaticRelationDisplayBindingSource;
        private Faction editingFaction;
        private DataGridViewTextBoxColumn factionNameDataGridViewTextBoxColumn;
        public FactionList Factions;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private MaskedTextBox mtbUpgradingDaysLeft;
        private DataGridViewTextBoxColumn relationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn truceDataGridViewTextBoxColumn;
        private ToolTip TechniqueToolTip;
        private int ToolTipingIndex = -1;

        public frmEditFaction()
        {
            this.InitializeComponent();
        }

        private void btnAddArchitectures_Click(object sender, EventArgs e)
        {
            frmSelectArchitectureList list = new frmSelectArchitectureList();
            list.Architectures = this.editingFaction.Scenario.Architectures;
            list.ShowDialog();
            foreach (int num in list.IDList)
            {
                Architecture gameObject = list.Architectures.GetGameObject(num) as Architecture;
                if (gameObject != null)
                {
                    this.editingFaction.AddArchitecture(gameObject);
                    this.editingFaction.AddArchitectureMilitaries(gameObject);
                }
            }
            this.RefreshArchitectures();
        }

        private void btnAddMilitaryKind_Click(object sender, EventArgs e)
        {
            if (this.cbMilitaryKind.SelectedIndex >= 0)
            {
                this.editingFaction.BaseMilitaryKinds.AddMilitaryKind(this.cbMilitaryKind.SelectedItem as MilitaryKind);
                this.RefreshMilitaryKinds();
            }
        }

        private void btnAllMilitaryFull_Click(object sender, EventArgs e)
        {
            foreach (Military military in this.editingFaction.Militaries)
            {
                military.Morale = military.MoraleCeiling;
                military.Combativity = military.CombativityCeiling;
            }
        }

        private void btnEditArchitecture_Click(object sender, EventArgs e)
        {
            if (this.clbArchitectures.SelectedItem != null)
            {
                frmEditArchitecture architecture = new frmEditArchitecture();
                architecture.editingArchitecture = this.clbArchitectures.SelectedItem as Architecture;
                architecture.ShowDialog();
            }
        }

        private void btnInitializeAllDiplomaticRelations_Click(object sender, EventArgs e)
        {
            this.editingFaction.Scenario.DiplomaticRelations.Clear();
            for (int i = 0; i < this.editingFaction.Scenario.Factions.Count; i++)
            {
                Faction faction = this.editingFaction.Scenario.Factions[i] as Faction;
                for (int j = 0; j < this.editingFaction.Scenario.Factions.Count; j++)
                {
                    Faction faction2 = this.editingFaction.Scenario.Factions[j] as Faction;
                    if (faction != faction2)
                    {
                        this.editingFaction.Scenario.DiplomaticRelations.AddDiplomaticRelation(this.editingFaction.Scenario, faction.ID, faction2.ID, 0);
                    }
                }
            }
            this.RebindDataSource();
        }

        private void btnRemoveArchitectures_Click(object sender, EventArgs e)
        {
            foreach (Architecture architecture in this.clbArchitectures.CheckedItems)
            {
                this.editingFaction.RemoveArchitectureMilitaries(architecture);
                foreach (Person person in architecture.Persons.GetList())
                {
                    person.Status = GameObjects.PersonDetail.PersonStatus.None;
                    person.LocationArchitecture = null;
                }
                foreach (Military military in architecture.Militaries.GetList())
                {
                    architecture.RemoveMilitary(military);
                }
                this.editingFaction.RemoveArchitecture(architecture);
                if (architecture.BelongedSection != null)
                {
                    architecture.BelongedSection.RemoveArchitecture(architecture);
                    if (this.editingFaction.ArchitectureCount == 0)
                    {
                        this.editingFaction.Sections.Clear();
                    }
                }
            }
            this.RefreshArchitectures();
        }

        private void btnRemoveMilitaryKind_Click(object sender, EventArgs e)
        {
            foreach (MilitaryKind kind in this.clbBaseMilitaryKinds.SelectedItems)
            {
                this.editingFaction.BaseMilitaryKinds.MilitaryKinds.Remove(kind.ID);
            }
            this.RefreshMilitaryKinds();
        }

        private void btnResetDiplomaticRelations_Click(object sender, EventArgs e)
        {
            foreach (DiplomaticRelation relation in this.editingFaction.Scenario.DiplomaticRelations.GetDiplomaticRelationListByFactionID(this.editingFaction.ID))
            {
                relation.Relation = 0;
            }
            this.RebindDataSource();
        }

        private void cbFactionColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Microsoft.Xna.Framework.Graphics.Color color = (Microsoft.Xna.Framework.Graphics.Color) this.cbFactionColor.Items[e.Index];
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.FromArgb((int) color.PackedValue), (float) e.Bounds.Height), e.Bounds.Left, e.Bounds.Top + (e.Bounds.Height / 2), e.Bounds.Right, e.Bounds.Top + (e.Bounds.Height / 2));
        }

        private void cbFactionColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.editingFaction.ColorIndex = this.cbFactionColor.SelectedIndex;
            Microsoft.Xna.Framework.Graphics.Color color = (Microsoft.Xna.Framework.Graphics.Color) this.cbFactionColor.Items[this.cbFactionColor.SelectedIndex];
            this.cbFactionColor.BackColor = System.Drawing.Color.FromArgb((int) color.PackedValue);
        }

        private void clbTechniques_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.editingFaction.PurifyTechniques();
            if ((e.CurrentValue == CheckState.Checked) && (e.NewValue == CheckState.Unchecked))
            {
                this.editingFaction.AvailableTechniques.RemoveTechniuqe((this.clbTechniques.Items[e.Index] as Technique).ID);
            }
            else if ((e.CurrentValue == CheckState.Unchecked) && (e.NewValue == CheckState.Checked))
            {
                this.editingFaction.AvailableTechniques.AddTechnique(this.clbTechniques.Items[e.Index] as Technique);
            }
            this.editingFaction.ApplyTechniques();
        }

        private void clbTechniques_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < this.clbTechniques.Items.Count; i++)
            {
                if (this.clbTechniques.GetItemRectangle(i).Contains(e.Location) && (this.ToolTipingIndex != i))
                {
                    this.ToolTipingIndex = i;
                    if (this.TechniqueToolTip != null)
                    {
                        this.TechniqueToolTip.Active = false;
                    }
                    this.TechniqueToolTip = new ToolTip();
                    this.TechniqueToolTip.InitialDelay = 0;
                    this.TechniqueToolTip.ToolTipTitle = (this.clbTechniques.Items[i] as Technique).Name;
                    this.TechniqueToolTip.SetToolTip(this.clbTechniques, (this.clbTechniques.Items[i] as Technique).Description);
                    break;
                }
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

        private void frmEditFaction_Load(object sender, EventArgs e)
        {
            this.editingFaction = this.Factions[0] as Faction;
            this.RefreshArchitectures();
            this.RebindDataSource();
            this.RefreshMilitaryKinds();
            foreach (MilitaryKind kind in this.editingFaction.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
            {
                this.cbMilitaryKind.Items.Add(kind);
            }
            foreach (Technique technique in this.editingFaction.Scenario.GameCommonData.AllTechniques.Techniques.Values)
            {
                this.cbUpgradingTechnique.Items.Add(technique);
                this.clbTechniques.Items.Add(technique);
            }
            if (this.editingFaction.UpgradingTechnique >= 0)
            {
                this.cbUpgradingTechnique.SelectedItem = this.editingFaction.Scenario.GameCommonData.AllTechniques.GetTechnique(this.editingFaction.UpgradingTechnique);
            }
            foreach (Technique technique in this.editingFaction.AvailableTechniques.Techniques.Values)
            {
                int index = this.clbTechniques.Items.IndexOf(technique);
                if (index >= 0)
                {
                    this.clbTechniques.SetItemChecked(index, true);
                }
            }
            foreach (Microsoft.Xna.Framework.Graphics.Color color in this.editingFaction.Scenario.GameCommonData.AllColors)
            {
                this.cbFactionColor.Items.Add(color);
            }
            this.cbFactionColor.SelectedIndex = this.editingFaction.ColorIndex;
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            this.clbArchitectures = new CheckedListBox();
            this.label1 = new Label();
            this.btnAddArchitectures = new Button();
            this.btnRemoveArchitectures = new Button();
            this.dgvDiplomaticRelation = new DataGridView();
            this.factionNameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.relationDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.truceDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            this.diplomaticRelationDisplayBindingSource = new BindingSource(this.components);
            this.label2 = new Label();
            this.btnResetDiplomaticRelations = new Button();
            this.btnInitializeAllDiplomaticRelations = new Button();
            this.clbBaseMilitaryKinds = new CheckedListBox();
            this.label3 = new Label();
            this.btnRemoveMilitaryKind = new Button();
            this.btnAddMilitaryKind = new Button();
            this.label4 = new Label();
            this.cbMilitaryKind = new ComboBox();
            this.clbTechniques = new CheckedListBox();
            this.btnSelectAllTechniques = new Button();
            this.btnCancelAllTechniques = new Button();
            this.label5 = new Label();
            this.label6 = new Label();
            this.cbUpgradingTechnique = new ComboBox();
            this.mtbUpgradingDaysLeft = new MaskedTextBox();
            this.label7 = new Label();
            this.cbFactionColor = new ComboBox();
            this.label8 = new Label();
            this.btnEditArchitecture = new Button();
            this.btnAllMilitaryFull = new Button();
            ((ISupportInitialize) this.dgvDiplomaticRelation).BeginInit();
            ((ISupportInitialize) this.diplomaticRelationDisplayBindingSource).BeginInit();
            base.SuspendLayout();
            this.clbArchitectures.CheckOnClick = true;
            this.clbArchitectures.FormattingEnabled = true;
            this.clbArchitectures.Location = new Point(12, 30);
            this.clbArchitectures.Name = "clbArchitectures";
            this.clbArchitectures.Size = new Size(0xda, 0xf4);
            this.clbArchitectures.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "建筑列表";
            this.btnAddArchitectures.Location = new Point(14, 280);
            this.btnAddArchitectures.Name = "btnAddArchitectures";
            this.btnAddArchitectures.Size = new Size(0x45, 0x17);
            this.btnAddArchitectures.TabIndex = 2;
            this.btnAddArchitectures.Text = "添加建筑";
            this.btnAddArchitectures.UseVisualStyleBackColor = true;
            this.btnAddArchitectures.Click += new EventHandler(this.btnAddArchitectures_Click);
            this.btnRemoveArchitectures.Location = new Point(0x59, 280);
            this.btnRemoveArchitectures.Name = "btnRemoveArchitectures";
            this.btnRemoveArchitectures.Size = new Size(0x40, 0x17);
            this.btnRemoveArchitectures.TabIndex = 3;
            this.btnRemoveArchitectures.Text = "删除建筑";
            this.btnRemoveArchitectures.UseVisualStyleBackColor = true;
            this.btnRemoveArchitectures.Click += new EventHandler(this.btnRemoveArchitectures_Click);
            this.dgvDiplomaticRelation.AllowUserToAddRows = false;
            this.dgvDiplomaticRelation.AllowUserToDeleteRows = false;
            this.dgvDiplomaticRelation.AllowUserToOrderColumns = true;
            this.dgvDiplomaticRelation.AutoGenerateColumns = false;
            this.dgvDiplomaticRelation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiplomaticRelation.Columns.AddRange(new DataGridViewColumn[] { this.factionNameDataGridViewTextBoxColumn, this.relationDataGridViewTextBoxColumn, this.truceDataGridViewTextBoxColumn });
            this.dgvDiplomaticRelation.DataSource = this.diplomaticRelationDisplayBindingSource;
            this.dgvDiplomaticRelation.Location = new Point(0xf6, 30);
            this.dgvDiplomaticRelation.Name = "dgvDiplomaticRelation";
            this.dgvDiplomaticRelation.RowTemplate.Height = 0x17;
            this.dgvDiplomaticRelation.Size = new Size(0x10d, 0xf4);
            this.dgvDiplomaticRelation.TabIndex = 4;
            this.factionNameDataGridViewTextBoxColumn.DataPropertyName = "FactionName";
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = System.Drawing.Color.FromArgb(0xe0, 0xe0, 0xe0);
            this.factionNameDataGridViewTextBoxColumn.DefaultCellStyle = style;
            this.factionNameDataGridViewTextBoxColumn.HeaderText = "势力";
            this.factionNameDataGridViewTextBoxColumn.Name = "factionNameDataGridViewTextBoxColumn";
            this.factionNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.factionNameDataGridViewTextBoxColumn.Width = 80;
            this.relationDataGridViewTextBoxColumn.DataPropertyName = "Relation";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.relationDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.relationDataGridViewTextBoxColumn.HeaderText = "关系";
            this.relationDataGridViewTextBoxColumn.Name = "relationDataGridViewTextBoxColumn";
            this.relationDataGridViewTextBoxColumn.Width = 60;
            //
            this.truceDataGridViewTextBoxColumn.DataPropertyName = "Truce";
            style2.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.truceDataGridViewTextBoxColumn.DefaultCellStyle = style2;
            this.truceDataGridViewTextBoxColumn.HeaderText = "停战";
            this.truceDataGridViewTextBoxColumn.Name = "truceDataGridViewTextBoxColumn";
            this.truceDataGridViewTextBoxColumn.Width = 60;
            //
            this.diplomaticRelationDisplayBindingSource.DataSource = typeof(DiplomaticRelationDisplay);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0xf4, 9);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x35, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "外交关系";
            this.btnResetDiplomaticRelations.Location = new Point(0xf6, 280);
            this.btnResetDiplomaticRelations.Name = "btnResetDiplomaticRelations";
            this.btnResetDiplomaticRelations.Size = new Size(0x80, 0x17);
            this.btnResetDiplomaticRelations.TabIndex = 6;
            this.btnResetDiplomaticRelations.Text = "重置本势力外交关系";
            this.btnResetDiplomaticRelations.UseVisualStyleBackColor = true;
            this.btnResetDiplomaticRelations.Click += new EventHandler(this.btnResetDiplomaticRelations_Click);
            this.btnInitializeAllDiplomaticRelations.Location = new Point(380, 280);
            this.btnInitializeAllDiplomaticRelations.Name = "btnInitializeAllDiplomaticRelations";
            this.btnInitializeAllDiplomaticRelations.Size = new Size(0x87, 0x17);
            this.btnInitializeAllDiplomaticRelations.TabIndex = 7;
            this.btnInitializeAllDiplomaticRelations.Text = "初始化所有外交关系";
            this.btnInitializeAllDiplomaticRelations.UseVisualStyleBackColor = true;
            this.btnInitializeAllDiplomaticRelations.Click += new EventHandler(this.btnInitializeAllDiplomaticRelations_Click);
            this.clbBaseMilitaryKinds.CheckOnClick = true;
            this.clbBaseMilitaryKinds.FormattingEnabled = true;
            this.clbBaseMilitaryKinds.Location = new Point(0x215, 30);
            this.clbBaseMilitaryKinds.Name = "clbBaseMilitaryKinds";
            this.clbBaseMilitaryKinds.Size = new Size(0xad, 0xd4);
            this.clbBaseMilitaryKinds.TabIndex = 8;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x213, 9);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "基本兵种";
            this.btnRemoveMilitaryKind.Location = new Point(0x266, 280);
            this.btnRemoveMilitaryKind.Name = "btnRemoveMilitaryKind";
            this.btnRemoveMilitaryKind.Size = new Size(0x4b, 0x17);
            this.btnRemoveMilitaryKind.TabIndex = 11;
            this.btnRemoveMilitaryKind.Text = "删除兵种";
            this.btnRemoveMilitaryKind.UseVisualStyleBackColor = true;
            this.btnRemoveMilitaryKind.Click += new EventHandler(this.btnRemoveMilitaryKind_Click);
            this.btnAddMilitaryKind.Location = new Point(0x215, 280);
            this.btnAddMilitaryKind.Name = "btnAddMilitaryKind";
            this.btnAddMilitaryKind.Size = new Size(0x4b, 0x17);
            this.btnAddMilitaryKind.TabIndex = 10;
            this.btnAddMilitaryKind.Text = "添加兵种";
            this.btnAddMilitaryKind.UseVisualStyleBackColor = true;
            this.btnAddMilitaryKind.Click += new EventHandler(this.btnAddMilitaryKind_Click);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(530, 0xfb);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1d, 12);
            this.label4.TabIndex = 13;
            this.label4.Text = "兵种";
            this.cbMilitaryKind.FormattingEnabled = true;
            this.cbMilitaryKind.Location = new Point(0x241, 0xf8);
            this.cbMilitaryKind.Name = "cbMilitaryKind";
            this.cbMilitaryKind.Size = new Size(0x81, 20);
            this.cbMilitaryKind.TabIndex = 12;
            this.clbTechniques.CheckOnClick = true;
            this.clbTechniques.FormattingEnabled = true;
            this.clbTechniques.Location = new Point(0x12, 0x196);
            this.clbTechniques.MultiColumn = true;
            this.clbTechniques.Name = "clbTechniques";
            this.clbTechniques.Size = new Size(0x2b0, 0xe4);
            this.clbTechniques.TabIndex = 14;
            this.clbTechniques.ItemCheck += new ItemCheckEventHandler(this.clbTechniques_ItemCheck);
            this.clbTechniques.MouseMove += new MouseEventHandler(this.clbTechniques_MouseMove);
            this.btnSelectAllTechniques.Location = new Point(0x12, 640);
            this.btnSelectAllTechniques.Name = "btnSelectAllTechniques";
            this.btnSelectAllTechniques.Size = new Size(0x4b, 0x17);
            this.btnSelectAllTechniques.TabIndex = 15;
            this.btnSelectAllTechniques.Text = "选择所有";
            this.btnSelectAllTechniques.UseVisualStyleBackColor = true;
            this.btnCancelAllTechniques.Location = new Point(0x63, 0x281);
            this.btnCancelAllTechniques.Name = "btnCancelAllTechniques";
            this.btnCancelAllTechniques.Size = new Size(0x4b, 0x17);
            this.btnCancelAllTechniques.TabIndex = 0x10;
            this.btnCancelAllTechniques.Text = "取消所有";
            this.btnCancelAllTechniques.UseVisualStyleBackColor = true;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x12, 0x15d);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x41, 12);
            this.label5.TabIndex = 0x11;
            this.label5.Text = "正在升级：";
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x12, 0x177);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x41, 12);
            this.label6.TabIndex = 0x12;
            this.label6.Text = "剩余天数：";
            this.cbUpgradingTechnique.FormattingEnabled = true;
            this.cbUpgradingTechnique.Location = new Point(0x52, 0x159);
            this.cbUpgradingTechnique.Name = "cbUpgradingTechnique";
            this.cbUpgradingTechnique.Size = new Size(0x79, 20);
            this.cbUpgradingTechnique.TabIndex = 0x15;
            this.mtbUpgradingDaysLeft.Location = new Point(0x52, 0x174);
            this.mtbUpgradingDaysLeft.Mask = "9999";
            this.mtbUpgradingDaysLeft.Name = "mtbUpgradingDaysLeft";
            this.mtbUpgradingDaysLeft.Size = new Size(0x79, 0x15);
            this.mtbUpgradingDaysLeft.TabIndex = 0x16;
            this.label7.AutoSize = true;
            this.label7.Location = new Point(0x12, 0x141);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x35, 12);
            this.label7.TabIndex = 0x17;
            this.label7.Text = "势力技巧";
            this.cbFactionColor.DrawMode = DrawMode.OwnerDrawFixed;
            this.cbFactionColor.Location = new Point(0xf6, 0x159);
            this.cbFactionColor.MaxDropDownItems = 10;
            this.cbFactionColor.Name = "cbFactionColor";
            this.cbFactionColor.Size = new Size(0xba, 0x16);
            this.cbFactionColor.TabIndex = 0x18;
            this.cbFactionColor.DrawItem += new DrawItemEventHandler(this.cbFactionColor_DrawItem);
            this.cbFactionColor.SelectedIndexChanged += new EventHandler(this.cbFactionColor_SelectedIndexChanged);
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0xf4, 0x141);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x35, 12);
            this.label8.TabIndex = 0x19;
            this.label8.Text = "势力颜色";
            this.btnEditArchitecture.Location = new Point(0x9f, 280);
            this.btnEditArchitecture.Name = "btnEditArchitecture";
            this.btnEditArchitecture.Size = new Size(0x47, 0x17);
            this.btnEditArchitecture.TabIndex = 0x1a;
            this.btnEditArchitecture.Text = "编辑建筑";
            this.btnEditArchitecture.UseVisualStyleBackColor = true;
            this.btnEditArchitecture.Click += new EventHandler(this.btnEditArchitecture_Click);
            this.btnAllMilitaryFull.AutoSize = true;
            this.btnAllMilitaryFull.Location = new Point(0x215, 0x13c);
            this.btnAllMilitaryFull.Name = "btnAllMilitaryFull";
            this.btnAllMilitaryFull.Size = new Size(0x87, 0x16);
            this.btnAllMilitaryFull.TabIndex = 0x1b;
            this.btnAllMilitaryFull.Text = "所有编队士气战意全满";
            this.btnAllMilitaryFull.UseVisualStyleBackColor = true;
            this.btnAllMilitaryFull.Click += new EventHandler(this.btnAllMilitaryFull_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2d7, 0x29d);
            base.Controls.Add(this.btnAllMilitaryFull);
            base.Controls.Add(this.btnEditArchitecture);
            base.Controls.Add(this.label8);
            base.Controls.Add(this.cbFactionColor);
            base.Controls.Add(this.label7);
            base.Controls.Add(this.mtbUpgradingDaysLeft);
            base.Controls.Add(this.cbUpgradingTechnique);
            base.Controls.Add(this.label6);
            base.Controls.Add(this.label5);
            base.Controls.Add(this.btnCancelAllTechniques);
            base.Controls.Add(this.btnSelectAllTechniques);
            base.Controls.Add(this.clbTechniques);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.cbMilitaryKind);
            base.Controls.Add(this.btnRemoveMilitaryKind);
            base.Controls.Add(this.btnAddMilitaryKind);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.clbBaseMilitaryKinds);
            base.Controls.Add(this.btnInitializeAllDiplomaticRelations);
            base.Controls.Add(this.btnResetDiplomaticRelations);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.dgvDiplomaticRelation);
            base.Controls.Add(this.btnRemoveArchitectures);
            base.Controls.Add(this.btnAddArchitectures);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.clbArchitectures);
            base.FormBorderStyle = FormBorderStyle.Fixed3D;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditFaction";
            base.ShowInTaskbar = false;
            this.Text = "编辑势力";
            base.Load += new EventHandler(this.frmEditFaction_Load);
            ((ISupportInitialize) this.dgvDiplomaticRelation).EndInit();
            ((ISupportInitialize) this.diplomaticRelationDisplayBindingSource).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void RebindDataSource()
        {
            this.diplomaticRelationDisplayBindingSource.DataSource = null;
            this.diplomaticRelationDisplayBindingSource.DataSource = this.editingFaction.Scenario.DiplomaticRelations.GetDiplomaticRelationDisplayListByFactionID(this.editingFaction.ID);
        }

        private void RefreshArchitectures()
        {
            this.clbArchitectures.Items.Clear();
            foreach (Architecture architecture in this.editingFaction.Architectures)
            {
                this.clbArchitectures.Items.Add(architecture);
            }
        }

        private void RefreshMilitaryKinds()
        {
            this.clbBaseMilitaryKinds.Items.Clear();
            foreach (MilitaryKind kind in this.editingFaction.BaseMilitaryKinds.MilitaryKinds.Values)
            {
                this.clbBaseMilitaryKinds.Items.Add(kind);
            }
        }
    }
}

