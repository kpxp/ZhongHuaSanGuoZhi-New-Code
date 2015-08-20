namespace MapEditor.Forms.TroopEventForms
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.TroopDetail.EventEffect;
    using MapEditor.Forms.PersonForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditTroopEvent : Form
    {
        private Button btnAddAnyDialog;
        private Button btnAddAreaEffect;
        private Button btnAddCondition;
        private Button btnAddDialogFromAll;
        private Button btnAddDialogFromRelated;
        private Button btnAddPersonEffectFromAll;
        private Button btnAddPersonEffectFromRelated;
        private Button btnAddSelfEffect;
        private Button btnAddTargetPerson;
        private Button btnEditDialog;
        private Button btnLaunchPerson;
        private Button btnMoveDialogDown;
        private Button btnMoveDialogUp;
        private Button btnNoAfterHappenedEvent;
        private Button btnNoLaunchPerson;
        private Button btnRemoveAreaEffect;
        private Button btnRemoveCondition;
        private Button btnRemoveDialog;
        private Button btnRemovePersonEffect;
        private Button btnRemoveSelfEffect;
        private Button btnRemoveTargetPerson;
        private CheckBox cbHappened;
        private ComboBox cbPersonEffect;
        private CheckBox cbRepeatable;
        private ComboBox cbSelectAreaEffect;
        private ComboBox cbSelectAreaKind;
        private ComboBox cbSelectCheckArea;
        private ComboBox cbSelectCondition;
        private ComboBox cbSelectSelfEffect;
        private CheckedListBox clbTargetPersons;
        private IContainer components = null;
        public TroopEvent EditingEvent;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private bool holdevent;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ListBox lbAreaEffects;
        private ListBox lbConditions;
        private ListBox lbDialogs;
        private Label lbLaunchPerson;
        private Label lbPersonEffect;
        private ListBox lbPersonEffects;
        private ListBox lbSelfEffects;
        public GameScenario Scenario;
        private TextBox tbAfterHappenedEvent;
        private TextBox tbHappenChance;

        public frmEditTroopEvent()
        {
            this.InitializeComponent();
        }

        private void btnAddAnyDialog_Click(object sender, EventArgs e)
        {
            PersonDialog item = new PersonDialog();
            item.SpeakingPerson = null;
            item.Text = "非空话语";
            this.EditingEvent.Dialogs.Add(item);
            this.RefreshDialogs();
        }

        private void btnAddAreaEffect_Click(object sender, EventArgs e)
        {
            TroopEffectArea item = new TroopEffectArea();
            item.Effect = this.cbSelectAreaEffect.Items[0] as GameObjects.TroopDetail.EventEffect.EventEffect;
            this.EditingEvent.EffectAreas.Add(item);
            this.RefreshAreaEffects();
        }

        private void btnAddCondition_Click(object sender, EventArgs e)
        {
            if ((this.cbSelectCondition.SelectedIndex >= 0) && (this.EditingEvent.Conditions.GetCondition(this.cbSelectCondition.SelectedIndex) == null))
            {
                this.EditingEvent.Conditions.AddCondition(this.cbSelectCondition.SelectedItem as Condition);
                this.RefreshConditions();
            }
        }

        private void btnAddDialogFromAll_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.Scenario.Persons;
            list.SelectOne = true;
            list.ShowDialog();
            if (list.IDList.Count == 1)
            {
                PersonDialog item = new PersonDialog();
                item.SpeakingPerson = this.Scenario.Persons.GetGameObject(list.IDList[0]) as Person;
                item.Text = "非空话语";
                this.EditingEvent.Dialogs.Add(item);
                this.RefreshDialogs();
            }
        }

        private void btnAddDialogFromRelated_Click(object sender, EventArgs e)
        {
            PersonList list = new PersonList();
            if (this.EditingEvent.LaunchPerson != null)
            {
                list.Add(this.EditingEvent.LaunchPerson);
            }
            if (this.EditingEvent.TargetPersons.Count > 0)
            {
                foreach (PersonRelation relation in this.EditingEvent.TargetPersons)
                {
                    list.Add(relation.SpeakingPerson);
                }
            }
            frmSelectPersonList list2 = new frmSelectPersonList();
            list2.Persons = list;
            list2.SelectOne = true;
            list2.ShowDialog();
            if (list2.IDList.Count == 1)
            {
                PersonDialog item = new PersonDialog();
                item.SpeakingPerson = list.GetGameObject(list2.IDList[0]) as Person;
                item.Text = "非空话语";
                this.EditingEvent.Dialogs.Add(item);
                this.RefreshDialogs();
            }
        }

        private void btnAddPersonEffectFromAll_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.Scenario.Persons;
            list.SelectOne = true;
            list.ShowDialog();
            if (list.IDList.Count == 1)
            {
                TroopEffectPerson item = new TroopEffectPerson();
                item.EffectPerson = this.Scenario.Persons.GetGameObject(list.IDList[0]) as Person;
                item.Effect = this.cbPersonEffect.Items[0] as GameObjects.TroopDetail.EventEffect.EventEffect;
                this.EditingEvent.EffectPersons.Add(item);
                this.RefreshPersonEffects();
            }
        }

        private void btnAddSelfEffect_Click(object sender, EventArgs e)
        {
            if ((this.cbSelectSelfEffect.SelectedIndex >= 0) && (this.EditingEvent.SelfEffects.IndexOf(this.cbSelectSelfEffect.SelectedItem as GameObjects.TroopDetail.EventEffect.EventEffect) < 0))
            {
                this.EditingEvent.SelfEffects.Add(this.cbSelectSelfEffect.SelectedItem as GameObjects.TroopDetail.EventEffect.EventEffect);
                this.RefreshSelfEffects();
            }
        }

        private void btnAddTargetPerson_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.Scenario.Persons;
            list.ShowDialog();
            if (list.IDList.Count > 0)
            {
                foreach (int num in list.IDList)
                {
                    PersonRelation item = new PersonRelation();
                    item.SpeakingPerson = this.Scenario.Persons.GetGameObject(num) as Person;
                    if (this.clbTargetPersons.Items.IndexOf(item.SpeakingPerson) < 0)
                    {
                        this.EditingEvent.TargetPersons.Add(item);
                    }
                }
                this.RefreshTargetPersons();
            }
        }

        private void btnEditDialog_Click(object sender, EventArgs e)
        {
            this.EditDialog();
        }

        private void btnLaunchPerson_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.Scenario.Persons;
            list.SelectOne = true;
            list.ShowDialog();
            if (list.IDList.Count == 1)
            {
                this.EditingEvent.LaunchPerson = this.Scenario.Persons.GetGameObject(list.IDList[0]) as Person;
                if (this.EditingEvent.LaunchPerson != null)
                {
                    this.lbLaunchPerson.Text = this.EditingEvent.LaunchPerson.Name;
                }
            }
        }

        private void btnMoveDialogDown_Click(object sender, EventArgs e)
        {
            if (this.lbDialogs.SelectedIndex < (this.lbDialogs.Items.Count - 1))
            {
                int selectedIndex = this.lbDialogs.SelectedIndex;
                PersonDialog dialog = this.EditingEvent.Dialogs[this.lbDialogs.SelectedIndex];
                this.EditingEvent.Dialogs[selectedIndex] = this.EditingEvent.Dialogs[selectedIndex + 1];
                this.EditingEvent.Dialogs[selectedIndex + 1] = dialog;
                this.RefreshDialogs();
            }
        }

        private void btnMoveDialogUp_Click(object sender, EventArgs e)
        {
            if (this.lbDialogs.SelectedIndex >= 1)
            {
                int selectedIndex = this.lbDialogs.SelectedIndex;
                PersonDialog dialog = this.EditingEvent.Dialogs[this.lbDialogs.SelectedIndex];
                this.EditingEvent.Dialogs[selectedIndex] = this.EditingEvent.Dialogs[selectedIndex - 1];
                this.EditingEvent.Dialogs[selectedIndex - 1] = dialog;
                this.RefreshDialogs();
            }
        }

        private void btnNoAfterHappenedEvent_Click(object sender, EventArgs e)
        {
            this.EditingEvent.AfterHappenedEvent = null;
            this.tbAfterHappenedEvent.Text = "-1";
        }

        private void btnNoLaunchPerson_Click(object sender, EventArgs e)
        {
            this.EditingEvent.LaunchPerson = null;
            this.lbLaunchPerson.Text = "----";
        }

        private void btnRemoveAreaEffect_Click(object sender, EventArgs e)
        {
            if (this.lbAreaEffects.SelectedIndex >= 0)
            {
                this.EditingEvent.EffectAreas.Remove(this.lbAreaEffects.SelectedItem as TroopEffectArea);
                this.RefreshAreaEffects();
            }
        }

        private void btnRemoveCondition_Click(object sender, EventArgs e)
        {
            if (this.lbConditions.SelectedIndex >= 0)
            {
                this.EditingEvent.Conditions.Conditions.Remove((this.lbConditions.SelectedItem as Condition).ID);
                this.RefreshConditions();
            }
        }

        private void btnRemoveDialog_Click(object sender, EventArgs e)
        {
            if (this.lbDialogs.SelectedIndex >= 0)
            {
                this.EditingEvent.Dialogs.Remove(this.lbDialogs.SelectedItem as PersonDialog);
                this.RefreshDialogs();
            }
        }

        private void btnRemovePersonEffect_Click(object sender, EventArgs e)
        {
            if (this.lbPersonEffects.SelectedIndex >= 0)
            {
                this.EditingEvent.EffectPersons.Remove(this.lbPersonEffects.SelectedItem as TroopEffectPerson);
                this.RefreshPersonEffects();
            }
        }

        private void btnRemoveSelfEffect_Click(object sender, EventArgs e)
        {
            if (this.lbSelfEffects.SelectedIndex >= 0)
            {
                this.EditingEvent.SelfEffects.Remove(this.lbSelfEffects.SelectedItem as GameObjects.TroopDetail.EventEffect.EventEffect);
                this.RefreshSelfEffects();
            }
        }

        private void btnRemoveTargetPerson_Click(object sender, EventArgs e)
        {
            if (this.clbTargetPersons.SelectedIndex >= 0)
            {
                for (int i = this.EditingEvent.TargetPersons.Count - 1; i >= 0; i--)
                {
                    if (this.clbTargetPersons.SelectedItem == this.EditingEvent.TargetPersons[i].SpeakingPerson)
                    {
                        this.EditingEvent.TargetPersons.RemoveAt(i);
                        break;
                    }
                }
                this.RefreshTargetPersons();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonList list = new PersonList();
            if (this.EditingEvent.LaunchPerson != null)
            {
                list.Add(this.EditingEvent.LaunchPerson);
            }
            if (this.EditingEvent.TargetPersons.Count > 0)
            {
                foreach (PersonRelation relation in this.EditingEvent.TargetPersons)
                {
                    list.Add(relation.SpeakingPerson);
                }
            }
            frmSelectPersonList list2 = new frmSelectPersonList();
            list2.Persons = list;
            list2.SelectOne = true;
            list2.ShowDialog();
            if (list2.IDList.Count == 1)
            {
                TroopEffectPerson item = new TroopEffectPerson();
                item.EffectPerson = list.GetGameObject(list2.IDList[0]) as Person;
                item.Effect = this.cbPersonEffect.Items[0] as GameObjects.TroopDetail.EventEffect.EventEffect;
                this.EditingEvent.EffectPersons.Add(item);
                this.RefreshPersonEffects();
            }
        }

        private void cbHappened_CheckedChanged(object sender, EventArgs e)
        {
            this.EditingEvent.Happened = this.cbHappened.Checked;
        }

        private void cbPersonEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.holdevent)
            {
                TroopEffectPerson selectedItem = this.lbPersonEffects.SelectedItem as TroopEffectPerson;
                if (selectedItem != null)
                {
                    selectedItem.Effect = this.cbPersonEffect.SelectedItem as GameObjects.TroopDetail.EventEffect.EventEffect;
                    this.RefreshPersonEffects();
                }
            }
        }

        private void cbRepeatable_CheckedChanged(object sender, EventArgs e)
        {
            this.EditingEvent.Repeatable = this.cbRepeatable.Checked;
        }

        private void cbSelectAreaEffect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.holdevent)
            {
                TroopEffectArea selectedItem = this.lbAreaEffects.SelectedItem as TroopEffectArea;
                if (selectedItem != null)
                {
                    selectedItem.Effect = this.cbSelectAreaEffect.SelectedItem as GameObjects.TroopDetail.EventEffect.EventEffect;
                    this.RefreshAreaEffects();
                }
            }
        }

        private void cbSelectAreaKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.holdevent)
            {
                TroopEffectArea selectedItem = this.lbAreaEffects.SelectedItem as TroopEffectArea;
                if (selectedItem != null)
                {
                    selectedItem.Kind = (EffectAreaKind) this.cbSelectAreaKind.SelectedIndex;
                    this.RefreshAreaEffects();
                }
            }
        }

        private void cbSelectCheckArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.EditingEvent.CheckArea = (EventCheckAreaKind) this.cbSelectCheckArea.SelectedIndex;
        }

        private void clbTargetPersons_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clbTargetPersons.Items.Count; i++)
            {
                this.EditingEvent.TargetPersons[i].Relation = this.clbTargetPersons.GetItemChecked(i) ? PersonRelationKind.友好 : PersonRelationKind.非友好;
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

        private void EditDialog()
        {
            if (this.lbDialogs.SelectedIndex >= 0)
            {
                frmEditEventDialog dialog = new frmEditEventDialog();
                dialog.Scenario = this.Scenario;
                dialog.Dialog = this.lbDialogs.SelectedItem as PersonDialog;
                dialog.ShowDialog();
                this.RefreshDialogs();
            }
        }

        private void frmEditTroopEvent_Load(object sender, EventArgs e)
        {
            this.cbHappened.Checked = this.EditingEvent.Happened;
            this.cbRepeatable.Checked = this.EditingEvent.Repeatable;
            this.tbHappenChance.Text = this.EditingEvent.HappenChance.ToString();
            if (this.EditingEvent.LaunchPerson != null)
            {
                this.lbLaunchPerson.Text = this.EditingEvent.LaunchPerson.Name;
            }
            else
            {
                this.lbLaunchPerson.Text = "----";
            }
            this.tbAfterHappenedEvent.Text = ((this.EditingEvent.AfterHappenedEvent != null) ? this.EditingEvent.AfterHappenedEvent.ID : -1).ToString();
            this.RefreshConditions();
            foreach (Condition condition in this.Scenario.GameCommonData.AllConditions.Conditions.Values)
            {
                if (condition.ID >= 0x3e8)
                {
                    this.cbSelectCondition.Items.Add(condition);
                }
            }
            this.cbSelectCheckArea.SelectedIndex = (int) this.EditingEvent.CheckArea;
            this.RefreshTargetPersons();
            this.RefreshSelfEffects();
            foreach (GameObjects.TroopDetail.EventEffect.EventEffect effect in this.Scenario.GameCommonData.AllTroopEventEffects.EventEffects.Values)
            {
                this.cbSelectSelfEffect.Items.Add(effect);
                this.cbSelectAreaEffect.Items.Add(effect);
                this.cbPersonEffect.Items.Add(effect);
            }
            this.RefreshAreaEffects();
            this.RefreshDialogs();
            this.RefreshPersonEffects();
        }

        private void InitializeComponent()
        {
            this.cbHappened = new CheckBox();
            this.cbRepeatable = new CheckBox();
            this.label1 = new Label();
            this.tbHappenChance = new TextBox();
            this.btnLaunchPerson = new Button();
            this.lbLaunchPerson = new Label();
            this.btnNoLaunchPerson = new Button();
            this.label3 = new Label();
            this.groupBox1 = new GroupBox();
            this.btnRemoveCondition = new Button();
            this.btnAddCondition = new Button();
            this.cbSelectCondition = new ComboBox();
            this.lbConditions = new ListBox();
            this.groupBox2 = new GroupBox();
            this.label5 = new Label();
            this.clbTargetPersons = new CheckedListBox();
            this.label4 = new Label();
            this.cbSelectCheckArea = new ComboBox();
            this.btnRemoveTargetPerson = new Button();
            this.btnAddTargetPerson = new Button();
            this.groupBox3 = new GroupBox();
            this.btnRemoveSelfEffect = new Button();
            this.btnAddSelfEffect = new Button();
            this.cbSelectSelfEffect = new ComboBox();
            this.lbSelfEffects = new ListBox();
            this.groupBox4 = new GroupBox();
            this.cbSelectAreaKind = new ComboBox();
            this.btnRemoveAreaEffect = new Button();
            this.btnAddAreaEffect = new Button();
            this.cbSelectAreaEffect = new ComboBox();
            this.lbAreaEffects = new ListBox();
            this.groupBox5 = new GroupBox();
            this.btnAddAnyDialog = new Button();
            this.btnEditDialog = new Button();
            this.btnAddDialogFromRelated = new Button();
            this.btnMoveDialogDown = new Button();
            this.btnMoveDialogUp = new Button();
            this.btnRemoveDialog = new Button();
            this.btnAddDialogFromAll = new Button();
            this.lbDialogs = new ListBox();
            this.groupBox6 = new GroupBox();
            this.btnRemovePersonEffect = new Button();
            this.cbPersonEffect = new ComboBox();
            this.btnAddPersonEffectFromRelated = new Button();
            this.btnAddPersonEffectFromAll = new Button();
            this.lbPersonEffect = new Label();
            this.lbPersonEffects = new ListBox();
            this.tbAfterHappenedEvent = new TextBox();
            this.label2 = new Label();
            this.btnNoAfterHappenedEvent = new Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            base.SuspendLayout();
            this.cbHappened.AutoSize = true;
            this.cbHappened.Location = new Point(12, 12);
            this.cbHappened.Name = "cbHappened";
            this.cbHappened.Size = new Size(60, 0x10);
            this.cbHappened.TabIndex = 0;
            this.cbHappened.Text = "已发生";
            this.cbHappened.UseVisualStyleBackColor = true;
            this.cbHappened.CheckedChanged += new EventHandler(this.cbHappened_CheckedChanged);
            this.cbRepeatable.AutoSize = true;
            this.cbRepeatable.Location = new Point(12, 0x22);
            this.cbRepeatable.Name = "cbRepeatable";
            this.cbRepeatable.Size = new Size(60, 0x10);
            this.cbRepeatable.TabIndex = 1;
            this.cbRepeatable.Text = "可重复";
            this.cbRepeatable.UseVisualStyleBackColor = true;
            this.cbRepeatable.CheckedChanged += new EventHandler(this.cbRepeatable_CheckedChanged);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x53, 13);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "发生几率";
            this.tbHappenChance.Location = new Point(0x8e, 7);
            this.tbHappenChance.Name = "tbHappenChance";
            this.tbHappenChance.Size = new Size(0x5c, 0x15);
            this.tbHappenChance.TabIndex = 3;
            this.tbHappenChance.TextChanged += new EventHandler(this.tbHappenChance_TextChanged);
            this.btnLaunchPerson.Location = new Point(0xf5, 5);
            this.btnLaunchPerson.Name = "btnLaunchPerson";
            this.btnLaunchPerson.Size = new Size(0x4b, 0x17);
            this.btnLaunchPerson.TabIndex = 4;
            this.btnLaunchPerson.Text = "发动人物";
            this.btnLaunchPerson.UseVisualStyleBackColor = true;
            this.btnLaunchPerson.Click += new EventHandler(this.btnLaunchPerson_Click);
            this.lbLaunchPerson.AutoSize = true;
            this.lbLaunchPerson.Location = new Point(0x152, 10);
            this.lbLaunchPerson.Name = "lbLaunchPerson";
            this.lbLaunchPerson.Size = new Size(0x59, 12);
            this.lbLaunchPerson.TabIndex = 5;
            this.lbLaunchPerson.Text = "请设置发动人物";
            this.btnNoLaunchPerson.Location = new Point(0x1c3, 5);
            this.btnNoLaunchPerson.Name = "btnNoLaunchPerson";
            this.btnNoLaunchPerson.Size = new Size(0x31, 0x17);
            this.btnNoLaunchPerson.TabIndex = 6;
            this.btnNoLaunchPerson.Text = "置空";
            this.btnNoLaunchPerson.UseVisualStyleBackColor = true;
            this.btnNoLaunchPerson.Click += new EventHandler(this.btnNoLaunchPerson_Click);
            this.label3.AutoSize = true;
            this.label3.Location = new Point(0x206, 10);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0xc5, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "置空则任何部队都有机会触发该事件";
            this.groupBox1.Controls.Add(this.btnRemoveCondition);
            this.groupBox1.Controls.Add(this.btnAddCondition);
            this.groupBox1.Controls.Add(this.cbSelectCondition);
            this.groupBox1.Controls.Add(this.lbConditions);
            this.groupBox1.Location = new Point(12, 0x39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xcb, 0xcb);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发动条件";
            this.btnRemoveCondition.Location = new Point(0x55, 0xa7);
            this.btnRemoveCondition.Name = "btnRemoveCondition";
            this.btnRemoveCondition.Size = new Size(0x3f, 0x15);
            this.btnRemoveCondition.TabIndex = 3;
            this.btnRemoveCondition.Text = "删除";
            this.btnRemoveCondition.UseVisualStyleBackColor = true;
            this.btnRemoveCondition.Click += new EventHandler(this.btnRemoveCondition_Click);
            this.btnAddCondition.Location = new Point(0x10, 0xa7);
            this.btnAddCondition.Name = "btnAddCondition";
            this.btnAddCondition.Size = new Size(0x3f, 0x15);
            this.btnAddCondition.TabIndex = 2;
            this.btnAddCondition.Text = "添加";
            this.btnAddCondition.UseVisualStyleBackColor = true;
            this.btnAddCondition.Click += new EventHandler(this.btnAddCondition_Click);
            this.cbSelectCondition.FormattingEnabled = true;
            this.cbSelectCondition.Location = new Point(0x10, 0x8d);
            this.cbSelectCondition.Name = "cbSelectCondition";
            this.cbSelectCondition.Size = new Size(0xae, 20);
            this.cbSelectCondition.TabIndex = 1;
            this.lbConditions.FormattingEnabled = true;
            this.lbConditions.ItemHeight = 12;
            this.lbConditions.Location = new Point(0x10, 20);
            this.lbConditions.Name = "lbConditions";
            this.lbConditions.Size = new Size(0xae, 100);
            this.lbConditions.TabIndex = 0;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.clbTargetPersons);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbSelectCheckArea);
            this.groupBox2.Controls.Add(this.btnRemoveTargetPerson);
            this.groupBox2.Controls.Add(this.btnAddTargetPerson);
            this.groupBox2.Location = new Point(230, 0x39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(0xe1, 0xcb);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "搜索人物";
            this.label5.AutoSize = true;
            this.label5.Location = new Point(13, 0x3a);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0xad, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "选中则表示人物需要在友好部队";
            this.clbTargetPersons.CheckOnClick = true;
            this.clbTargetPersons.FormattingEnabled = true;
            this.clbTargetPersons.Location = new Point(15, 0x4c);
            this.clbTargetPersons.Name = "clbTargetPersons";
            this.clbTargetPersons.Size = new Size(0xc0, 0x54);
            this.clbTargetPersons.TabIndex = 8;
            this.clbTargetPersons.SelectedIndexChanged += new EventHandler(this.clbTargetPersons_SelectedIndexChanged);
            this.label4.AutoSize = true;
            this.label4.Location = new Point(13, 0x17);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x35, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "搜索范围";
            this.cbSelectCheckArea.FormattingEnabled = true;
            this.cbSelectCheckArea.Items.AddRange(new object[] { "视野内", "周边八格", "攻击范围" });
            this.cbSelectCheckArea.Location = new Point(0x54, 20);
            this.cbSelectCheckArea.Name = "cbSelectCheckArea";
            this.cbSelectCheckArea.Size = new Size(0x7e, 20);
            this.cbSelectCheckArea.TabIndex = 6;
            this.cbSelectCheckArea.SelectedIndexChanged += new EventHandler(this.cbSelectCheckArea_SelectedIndexChanged);
            this.btnRemoveTargetPerson.Location = new Point(0x54, 0xa6);
            this.btnRemoveTargetPerson.Name = "btnRemoveTargetPerson";
            this.btnRemoveTargetPerson.Size = new Size(0x3f, 0x15);
            this.btnRemoveTargetPerson.TabIndex = 5;
            this.btnRemoveTargetPerson.Text = "删除";
            this.btnRemoveTargetPerson.UseVisualStyleBackColor = true;
            this.btnRemoveTargetPerson.Click += new EventHandler(this.btnRemoveTargetPerson_Click);
            this.btnAddTargetPerson.Location = new Point(15, 0xa6);
            this.btnAddTargetPerson.Name = "btnAddTargetPerson";
            this.btnAddTargetPerson.Size = new Size(0x3f, 0x15);
            this.btnAddTargetPerson.TabIndex = 4;
            this.btnAddTargetPerson.Text = "添加";
            this.btnAddTargetPerson.UseVisualStyleBackColor = true;
            this.btnAddTargetPerson.Click += new EventHandler(this.btnAddTargetPerson_Click);
            this.groupBox3.Controls.Add(this.btnRemoveSelfEffect);
            this.groupBox3.Controls.Add(this.btnAddSelfEffect);
            this.groupBox3.Controls.Add(this.cbSelectSelfEffect);
            this.groupBox3.Controls.Add(this.lbSelfEffects);
            this.groupBox3.Location = new Point(0x1d8, 0x39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new Size(0x9a, 0xca);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "自身效果";
            this.btnRemoveSelfEffect.Location = new Point(80, 0xa6);
            this.btnRemoveSelfEffect.Name = "btnRemoveSelfEffect";
            this.btnRemoveSelfEffect.Size = new Size(0x3f, 0x15);
            this.btnRemoveSelfEffect.TabIndex = 5;
            this.btnRemoveSelfEffect.Text = "删除";
            this.btnRemoveSelfEffect.UseVisualStyleBackColor = true;
            this.btnRemoveSelfEffect.Click += new EventHandler(this.btnRemoveSelfEffect_Click);
            this.btnAddSelfEffect.Location = new Point(11, 0xa6);
            this.btnAddSelfEffect.Name = "btnAddSelfEffect";
            this.btnAddSelfEffect.Size = new Size(0x3f, 0x15);
            this.btnAddSelfEffect.TabIndex = 4;
            this.btnAddSelfEffect.Text = "添加";
            this.btnAddSelfEffect.UseVisualStyleBackColor = true;
            this.btnAddSelfEffect.Click += new EventHandler(this.btnAddSelfEffect_Click);
            this.cbSelectSelfEffect.FormattingEnabled = true;
            this.cbSelectSelfEffect.Location = new Point(11, 140);
            this.cbSelectSelfEffect.Name = "cbSelectSelfEffect";
            this.cbSelectSelfEffect.Size = new Size(130, 20);
            this.cbSelectSelfEffect.TabIndex = 1;
            this.lbSelfEffects.FormattingEnabled = true;
            this.lbSelfEffects.ItemHeight = 12;
            this.lbSelfEffects.Location = new Point(11, 0x18);
            this.lbSelfEffects.Name = "lbSelfEffects";
            this.lbSelfEffects.Size = new Size(130, 100);
            this.lbSelfEffects.TabIndex = 0;
            this.groupBox4.Controls.Add(this.cbSelectAreaKind);
            this.groupBox4.Controls.Add(this.btnRemoveAreaEffect);
            this.groupBox4.Controls.Add(this.btnAddAreaEffect);
            this.groupBox4.Controls.Add(this.cbSelectAreaEffect);
            this.groupBox4.Controls.Add(this.lbAreaEffects);
            this.groupBox4.Location = new Point(0x278, 0x39);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new Size(0xfe, 0xca);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "特定范围效果";
            this.cbSelectAreaKind.FormattingEnabled = true;
            this.cbSelectAreaKind.Items.AddRange(new object[] { "视野内敌军", "视野内友军", "周围八格敌军", "周围八格友军", "攻击范围敌军", "攻击范围友军" });
            this.cbSelectAreaKind.Location = new Point(9, 0x18);
            this.cbSelectAreaKind.Name = "cbSelectAreaKind";
            this.cbSelectAreaKind.Size = new Size(0x71, 20);
            this.cbSelectAreaKind.TabIndex = 8;
            this.cbSelectAreaKind.SelectedIndexChanged += new EventHandler(this.cbSelectAreaKind_SelectedIndexChanged);
            this.btnRemoveAreaEffect.Location = new Point(0xb9, 0xa6);
            this.btnRemoveAreaEffect.Name = "btnRemoveAreaEffect";
            this.btnRemoveAreaEffect.Size = new Size(0x3f, 0x15);
            this.btnRemoveAreaEffect.TabIndex = 7;
            this.btnRemoveAreaEffect.Text = "删除";
            this.btnRemoveAreaEffect.UseVisualStyleBackColor = true;
            this.btnRemoveAreaEffect.Click += new EventHandler(this.btnRemoveAreaEffect_Click);
            this.btnAddAreaEffect.Location = new Point(0x74, 0xa6);
            this.btnAddAreaEffect.Name = "btnAddAreaEffect";
            this.btnAddAreaEffect.Size = new Size(0x3f, 0x15);
            this.btnAddAreaEffect.TabIndex = 6;
            this.btnAddAreaEffect.Text = "添加";
            this.btnAddAreaEffect.UseVisualStyleBackColor = true;
            this.btnAddAreaEffect.Click += new EventHandler(this.btnAddAreaEffect_Click);
            this.cbSelectAreaEffect.FormattingEnabled = true;
            this.cbSelectAreaEffect.Location = new Point(0x87, 0x18);
            this.cbSelectAreaEffect.Name = "cbSelectAreaEffect";
            this.cbSelectAreaEffect.Size = new Size(0x71, 20);
            this.cbSelectAreaEffect.TabIndex = 2;
            this.cbSelectAreaEffect.SelectedIndexChanged += new EventHandler(this.cbSelectAreaEffect_SelectedIndexChanged);
            this.lbAreaEffects.FormattingEnabled = true;
            this.lbAreaEffects.ItemHeight = 12;
            this.lbAreaEffects.Location = new Point(6, 0x3a);
            this.lbAreaEffects.Name = "lbAreaEffects";
            this.lbAreaEffects.Size = new Size(0xf2, 100);
            this.lbAreaEffects.TabIndex = 0;
            this.lbAreaEffects.SelectedIndexChanged += new EventHandler(this.lbAreaEffects_SelectedIndexChanged);
            this.groupBox5.Controls.Add(this.btnAddAnyDialog);
            this.groupBox5.Controls.Add(this.btnEditDialog);
            this.groupBox5.Controls.Add(this.btnAddDialogFromRelated);
            this.groupBox5.Controls.Add(this.btnMoveDialogDown);
            this.groupBox5.Controls.Add(this.btnMoveDialogUp);
            this.groupBox5.Controls.Add(this.btnRemoveDialog);
            this.groupBox5.Controls.Add(this.btnAddDialogFromAll);
            this.groupBox5.Controls.Add(this.lbDialogs);
            this.groupBox5.Location = new Point(12, 270);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new Size(0x220, 0x150);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "人物对话";
            this.btnAddAnyDialog.Location = new Point(0x13a, 0x135);
            this.btnAddAnyDialog.Name = "btnAddAnyDialog";
            this.btnAddAnyDialog.Size = new Size(0x42, 0x15);
            this.btnAddAnyDialog.TabIndex = 10;
            this.btnAddAnyDialog.Text = "添加任意";
            this.btnAddAnyDialog.UseVisualStyleBackColor = true;
            this.btnAddAnyDialog.Click += new EventHandler(this.btnAddAnyDialog_Click);
            this.btnEditDialog.Location = new Point(0x10, 0x135);
            this.btnEditDialog.Name = "btnEditDialog";
            this.btnEditDialog.Size = new Size(0x3f, 0x15);
            this.btnEditDialog.TabIndex = 9;
            this.btnEditDialog.Text = "修改";
            this.btnEditDialog.UseVisualStyleBackColor = true;
            this.btnEditDialog.Click += new EventHandler(this.btnEditDialog_Click);
            this.btnAddDialogFromRelated.Location = new Point(0x55, 0x135);
            this.btnAddDialogFromRelated.Name = "btnAddDialogFromRelated";
            this.btnAddDialogFromRelated.Size = new Size(0x6c, 0x15);
            this.btnAddDialogFromRelated.TabIndex = 8;
            this.btnAddDialogFromRelated.Text = "从相关人物添加";
            this.btnAddDialogFromRelated.UseVisualStyleBackColor = true;
            this.btnAddDialogFromRelated.Click += new EventHandler(this.btnAddDialogFromRelated_Click);
            this.btnMoveDialogDown.Location = new Point(0x1de, 0x135);
            this.btnMoveDialogDown.Name = "btnMoveDialogDown";
            this.btnMoveDialogDown.Size = new Size(0x2d, 0x15);
            this.btnMoveDialogDown.TabIndex = 7;
            this.btnMoveDialogDown.Text = "下移";
            this.btnMoveDialogDown.UseVisualStyleBackColor = true;
            this.btnMoveDialogDown.Click += new EventHandler(this.btnMoveDialogDown_Click);
            this.btnMoveDialogUp.Location = new Point(430, 0x135);
            this.btnMoveDialogUp.Name = "btnMoveDialogUp";
            this.btnMoveDialogUp.Size = new Size(0x2a, 0x15);
            this.btnMoveDialogUp.TabIndex = 6;
            this.btnMoveDialogUp.Text = "上移";
            this.btnMoveDialogUp.UseVisualStyleBackColor = true;
            this.btnMoveDialogUp.Click += new EventHandler(this.btnMoveDialogUp_Click);
            this.btnRemoveDialog.Location = new Point(0x182, 0x135);
            this.btnRemoveDialog.Name = "btnRemoveDialog";
            this.btnRemoveDialog.Size = new Size(0x27, 0x15);
            this.btnRemoveDialog.TabIndex = 5;
            this.btnRemoveDialog.Text = "删除";
            this.btnRemoveDialog.UseVisualStyleBackColor = true;
            this.btnRemoveDialog.Click += new EventHandler(this.btnRemoveDialog_Click);
            this.btnAddDialogFromAll.Location = new Point(0xc7, 0x135);
            this.btnAddDialogFromAll.Name = "btnAddDialogFromAll";
            this.btnAddDialogFromAll.Size = new Size(0x6d, 0x15);
            this.btnAddDialogFromAll.TabIndex = 4;
            this.btnAddDialogFromAll.Text = "从所有人物添加";
            this.btnAddDialogFromAll.UseVisualStyleBackColor = true;
            this.btnAddDialogFromAll.Click += new EventHandler(this.btnAddDialogFromAll_Click);
            this.lbDialogs.FormattingEnabled = true;
            this.lbDialogs.ItemHeight = 12;
            this.lbDialogs.Location = new Point(0x10, 20);
            this.lbDialogs.Name = "lbDialogs";
            this.lbDialogs.Size = new Size(0x1ff, 280);
            this.lbDialogs.TabIndex = 0;
            this.lbDialogs.MouseDoubleClick += new MouseEventHandler(this.lbDialogs_MouseDoubleClick);
            this.groupBox6.Controls.Add(this.btnRemovePersonEffect);
            this.groupBox6.Controls.Add(this.cbPersonEffect);
            this.groupBox6.Controls.Add(this.btnAddPersonEffectFromRelated);
            this.groupBox6.Controls.Add(this.btnAddPersonEffectFromAll);
            this.groupBox6.Controls.Add(this.lbPersonEffect);
            this.groupBox6.Controls.Add(this.lbPersonEffects);
            this.groupBox6.Location = new Point(0x232, 0x10f);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new Size(0x144, 0x14f);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "特定人物效果";
            this.btnRemovePersonEffect.Location = new Point(0xf2, 0x134);
            this.btnRemovePersonEffect.Name = "btnRemovePersonEffect";
            this.btnRemovePersonEffect.Size = new Size(0x3f, 0x15);
            this.btnRemovePersonEffect.TabIndex = 13;
            this.btnRemovePersonEffect.Text = "删除";
            this.btnRemovePersonEffect.UseVisualStyleBackColor = true;
            this.btnRemovePersonEffect.Click += new EventHandler(this.btnRemovePersonEffect_Click);
            this.cbPersonEffect.FormattingEnabled = true;
            this.cbPersonEffect.Location = new Point(0x12, 0x40);
            this.cbPersonEffect.Name = "cbPersonEffect";
            this.cbPersonEffect.Size = new Size(0x71, 20);
            this.cbPersonEffect.TabIndex = 11;
            this.cbPersonEffect.SelectedIndexChanged += new EventHandler(this.cbPersonEffect_SelectedIndexChanged);
            this.btnAddPersonEffectFromRelated.Location = new Point(0x54, 0x19);
            this.btnAddPersonEffectFromRelated.Name = "btnAddPersonEffectFromRelated";
            this.btnAddPersonEffectFromRelated.Size = new Size(0x6c, 0x15);
            this.btnAddPersonEffectFromRelated.TabIndex = 10;
            this.btnAddPersonEffectFromRelated.Text = "从相关人物添加";
            this.btnAddPersonEffectFromRelated.UseVisualStyleBackColor = true;
            this.btnAddPersonEffectFromRelated.Click += new EventHandler(this.button1_Click);
            this.btnAddPersonEffectFromAll.Location = new Point(0xc4, 0x19);
            this.btnAddPersonEffectFromAll.Name = "btnAddPersonEffectFromAll";
            this.btnAddPersonEffectFromAll.Size = new Size(0x6d, 0x15);
            this.btnAddPersonEffectFromAll.TabIndex = 9;
            this.btnAddPersonEffectFromAll.Text = "从所有人物添加";
            this.btnAddPersonEffectFromAll.UseVisualStyleBackColor = true;
            this.btnAddPersonEffectFromAll.Click += new EventHandler(this.btnAddPersonEffectFromAll_Click);
            this.lbPersonEffect.AutoSize = true;
            this.lbPersonEffect.Location = new Point(0x16, 0x1d);
            this.lbPersonEffect.Name = "lbPersonEffect";
            this.lbPersonEffect.Size = new Size(0x1d, 12);
            this.lbPersonEffect.TabIndex = 6;
            this.lbPersonEffect.Text = "人物";
            this.lbPersonEffects.FormattingEnabled = true;
            this.lbPersonEffects.ItemHeight = 12;
            this.lbPersonEffects.Location = new Point(0x12, 0x66);
            this.lbPersonEffects.Name = "lbPersonEffects";
            this.lbPersonEffects.Size = new Size(0x11f, 0xc4);
            this.lbPersonEffects.TabIndex = 1;
            this.lbPersonEffects.SelectedIndexChanged += new EventHandler(this.lbPersonEffects_SelectedIndexChanged);
            this.tbAfterHappenedEvent.Location = new Point(0x9a, 0x20);
            this.tbAfterHappenedEvent.Name = "tbAfterHappenedEvent";
            this.tbAfterHappenedEvent.Size = new Size(80, 0x15);
            this.tbAfterHappenedEvent.TabIndex = 15;
            this.tbAfterHappenedEvent.TextChanged += new EventHandler(this.tbAfterHappenedEvent_TextChanged);
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x53, 0x26);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x41, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "前提事件ID";
            this.btnNoAfterHappenedEvent.Location = new Point(0xf5, 30);
            this.btnNoAfterHappenedEvent.Name = "btnNoAfterHappenedEvent";
            this.btnNoAfterHappenedEvent.Size = new Size(0x31, 0x17);
            this.btnNoAfterHappenedEvent.TabIndex = 0x10;
            this.btnNoAfterHappenedEvent.Text = "置空";
            this.btnNoAfterHappenedEvent.UseVisualStyleBackColor = true;
            this.btnNoAfterHappenedEvent.Click += new EventHandler(this.btnNoAfterHappenedEvent_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x382, 0x26a);
            base.Controls.Add(this.btnNoAfterHappenedEvent);
            base.Controls.Add(this.tbAfterHappenedEvent);
            base.Controls.Add(this.label2);
            base.Controls.Add(this.groupBox6);
            base.Controls.Add(this.groupBox5);
            base.Controls.Add(this.groupBox4);
            base.Controls.Add(this.groupBox3);
            base.Controls.Add(this.groupBox2);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.label3);
            base.Controls.Add(this.btnNoLaunchPerson);
            base.Controls.Add(this.lbLaunchPerson);
            base.Controls.Add(this.btnLaunchPerson);
            base.Controls.Add(this.tbHappenChance);
            base.Controls.Add(this.label1);
            base.Controls.Add(this.cbRepeatable);
            base.Controls.Add(this.cbHappened);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditTroopEvent";
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "编辑部队事件";
            base.Load += new EventHandler(this.frmEditTroopEvent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void lbAreaEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            TroopEffectArea selectedItem = this.lbAreaEffects.SelectedItem as TroopEffectArea;
            if (selectedItem != null)
            {
                this.holdevent = true;
                this.cbSelectAreaKind.SelectedIndex = (int) selectedItem.Kind;
                this.cbSelectAreaEffect.SelectedItem = selectedItem.Effect;
                this.holdevent = false;
            }
        }

        private void lbDialogs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.EditDialog();
        }

        private void lbPersonEffects_SelectedIndexChanged(object sender, EventArgs e)
        {
            TroopEffectPerson selectedItem = this.lbPersonEffects.SelectedItem as TroopEffectPerson;
            if (selectedItem != null)
            {
                this.holdevent = true;
                this.lbPersonEffect.Text = selectedItem.EffectPerson.Name;
                this.cbPersonEffect.SelectedItem = selectedItem.Effect;
                this.holdevent = false;
            }
        }

        private void RefreshAreaEffects()
        {
            this.lbAreaEffects.Items.Clear();
            foreach (TroopEffectArea area in this.EditingEvent.EffectAreas)
            {
                this.lbAreaEffects.Items.Add(area);
            }
        }

        private void RefreshConditions()
        {
            this.lbConditions.Items.Clear();
            foreach (Condition condition in this.EditingEvent.Conditions.Conditions.Values)
            {
                this.lbConditions.Items.Add(condition);
            }
        }

        private void RefreshDialogs()
        {
            this.lbDialogs.Items.Clear();
            foreach (PersonDialog dialog in this.EditingEvent.Dialogs)
            {
                this.lbDialogs.Items.Add(dialog);
            }
        }

        private void RefreshPersonEffects()
        {
            this.lbPersonEffects.Items.Clear();
            foreach (TroopEffectPerson person in this.EditingEvent.EffectPersons)
            {
                this.lbPersonEffects.Items.Add(person);
            }
        }

        private void RefreshSelfEffects()
        {
            this.lbSelfEffects.Items.Clear();
            foreach (GameObjects.TroopDetail.EventEffect.EventEffect effect in this.EditingEvent.SelfEffects)
            {
                this.lbSelfEffects.Items.Add(effect);
            }
        }

        private void RefreshTargetPersons()
        {
            this.clbTargetPersons.Items.Clear();
            foreach (PersonRelation relation in this.EditingEvent.TargetPersons)
            {
                this.clbTargetPersons.SetItemChecked(this.clbTargetPersons.Items.Add(relation.SpeakingPerson), relation.Relation == PersonRelationKind.友好);
            }
        }

        private void tbAfterHappenedEvent_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.EditingEvent.AfterHappenedEvent = this.Scenario.TroopEvents.GetGameObject(int.Parse(this.tbAfterHappenedEvent.Text)) as TroopEvent;
            }
            catch
            {
                this.EditingEvent.AfterHappenedEvent = null;
                this.tbAfterHappenedEvent.Text = "-1";
                MessageBox.Show("请输入正确的ID", "提示");
            }
            if (this.EditingEvent.AfterHappenedEvent == null)
            {
                this.tbAfterHappenedEvent.Text = "-1";
            }
        }

        private void tbHappenChance_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.EditingEvent.HappenChance = short.Parse(this.tbHappenChance.Text);
            }
            catch
            {
                this.EditingEvent.HappenChance = 0;
                this.tbHappenChance.Text = "0";
            }
        }
    }
}

