namespace MapEditor.Forms.ArchitectureForms
{
    using GameObjects;
    using GameObjects.ArchitectureDetail;
    using GameObjects.Influences;
    using MapEditor;
    using MapEditor.Forms.FactionForms;
    using MapEditor.Forms.MilitaryForms;
    using MapEditor.Forms.PersonForms;
    using MapEditor.Forms.SectionForms;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;

    public class frmEditArchitecture : Form
    {
        public ArchitectureList Architectures;
        private Button btnAddCharacteristic;
        private Button btnAddFacility;
        private Button btnAddMilitary;
        private Button btnAddNoFactionPerson;
        private Button btnAddPerson;
        private Button btnAllFood;
        private Button btnAllFund;
        private Button btnAllPopulation;
        private Button btnCancel;
        private Button btnCapital;
        private Button btnDeleteLandLink;
        private Button btnDeleteWaterLink;
        private Button btnEditMilitary;
        private Button btnEditNoFactionPerson;
        private Button btnEditPerson;
        private Button btnModify;
        private Button btnNewMilitary;
        private Button btnRemoveCharacteristic;
        private Button btnRemoveFacility;
        private Button btnRemoveMilitary;
        private Button btnRemoveNoFactionPerson;
        private Button btnRemovePerson;
        private Button btnSelectFaction;
        private Button btnSelectSection;
        private ComboBox cbCharacteristics;
        private ComboBox cbFacilityKinds;
        private CheckBox cbIsStrategicCenter;
        private ComboBox cbState;
        private CheckedListBox clbCharacteristics;
        private CheckedListBox clbFacilities;
        private CheckedListBox clbLandLinks;
        private CheckedListBox clbMilitaries;
        private CheckedListBox clbNoFactionPerson;
        private CheckedListBox clbPersons;
        private CheckedListBox clbWaterLinks;
        private IContainer components = null;
        public Architecture editingArchitecture;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label label1;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Label label19;
        private Label label2;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label24;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblFaction;
        private Label lblSection;
        public formMapEditor MainForm;
        private TextBox tbAgriculture;
        private TextBox tbAllFood;
        private TextBox tbAllFund;
        private TextBox tbAllPopulation;
        private TextBox tbCommerce;
        private TextBox tbDomination;
        private TextBox tbEndurance;
        private TextBox tbFood;
        private TextBox tbFund;
        private ComboBox tbKind;
        private TextBox tbMorale;
        private TextBox tbName;
        private TextBox tbPopulation;
        private TextBox tbTechnology;

        public frmEditArchitecture()
        {
            this.InitializeComponent();
        }

        private void btnAddCharacteristic_Click(object sender, EventArgs e)
        {
            if (this.cbCharacteristics.SelectedIndex >= 0)
            {
                this.editingArchitecture.Characteristics.AddInfluence(this.cbCharacteristics.SelectedItem as Influence);
                this.RefreshCharacteristics();
            }
        }

        private void btnAddFacility_Click(object sender, EventArgs e)
        {
            if (this.cbFacilityKinds.SelectedIndex >= 0)
            {
                this.editingArchitecture.BuildFacility(this.cbFacilityKinds.SelectedItem as FacilityKind);
                this.RefreshFacilities();
            }
        }

        private void btnAddMilitary_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                frmSelectMilitaryList list = new frmSelectMilitaryList();
                list.Militaries = this.editingArchitecture.Scenario.Militaries;
                list.ShowDialog();
                if (list.SelectedMilitaries.Count > 0)
                {
                    foreach (Military military in list.SelectedMilitaries)
                    {
                        if (military.BelongedArchitecture != null)
                        {
                            military.BelongedArchitecture.RemoveMilitary(military);
                        }
                        if (military.BelongedFaction != null)
                        {
                            military.BelongedFaction.RemoveMilitary(military);
                        }
                        this.editingArchitecture.AddMilitary(military);
                        if (this.editingArchitecture.BelongedFaction != null)
                        {
                            this.editingArchitecture.BelongedFaction.AddMilitary(military);
                        }
                    }
                    this.RefreshMilitaries();
                }
            }
        }

        private void btnAddNoFactionPerson_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.editingArchitecture.Scenario.Persons;
            list.ShowDialog();
            foreach (int num in list.IDList)
            {
                Person gameObject = this.editingArchitecture.Scenario.Persons.GetGameObject(num) as Person;
                gameObject.Available = true;
                try
                {
                    gameObject.LocationArchitecture = this.editingArchitecture;
                    gameObject.Status = GameObjects.PersonDetail.PersonStatus.NoFaction;
                }
                catch
                {
                    MessageBox.Show(gameObject.Name + "没有被添加到在野人物列表。", "操作无效");
                }
            }
            this.RefreshNoFactionPersons();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmSelectPersonList list = new frmSelectPersonList();
            list.Persons = this.editingArchitecture.Scenario.Persons;
            list.ShowDialog();
            foreach (int num in list.IDList)
            {
                Person gameObject = this.editingArchitecture.Scenario.Persons.GetGameObject(num) as Person;
                gameObject.Alive = true;
                gameObject.Available = true;
                gameObject.LocationArchitecture = this.editingArchitecture;
                gameObject.Status = GameObjects.PersonDetail.PersonStatus.Normal;
            }
            this.RefreshPersons();
        }

        private void btnAllFood_Click(object sender, EventArgs e)
        {
            float num = float.Parse(this.tbAllFood.Text);
            foreach (Architecture architecture in this.editingArchitecture.Scenario.Architectures)
            {
                architecture.Food = (int) (architecture.Food * num);
            }
        }

        private void btnAllFund_Click(object sender, EventArgs e)
        {
            float num = float.Parse(this.tbAllFund.Text);
            foreach (Architecture architecture in this.editingArchitecture.Scenario.Architectures)
            {
                architecture.Fund = (int) (architecture.Fund * num);
            }
        }

        private void btnAllPopulation_Click(object sender, EventArgs e)
        {
            float num = float.Parse(this.tbAllPopulation.Text);
            foreach (Architecture architecture in this.editingArchitecture.Scenario.Architectures)
            {
                architecture.Population = (int) (architecture.Population * num);
            }
        }

        private void btnCapital_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture.BelongedFaction != null)
            {
                this.editingArchitecture.BelongedFaction.ChangeCapital(this.editingArchitecture);
            }
        }

        private void btnDeleteLandLink_Click(object sender, EventArgs e)
        {
            Architecture selectedItem = this.clbLandLinks.SelectedItem as Architecture;
            if (selectedItem != null)
            {
                this.editingArchitecture.AILandLinks.Remove(selectedItem);
                selectedItem.AILandLinks.Remove(this.editingArchitecture);
                this.RefreshLinks();
            }
        }

        private void btnDeleteWaterLink_Click(object sender, EventArgs e)
        {
            Architecture selectedItem = this.clbWaterLinks.SelectedItem as Architecture;
            if (selectedItem != null)
            {
                this.editingArchitecture.AIWaterLinks.Remove(selectedItem);
                selectedItem.AIWaterLinks.Remove(this.editingArchitecture);
                this.RefreshLinks();
            }
        }

        private void btnEditMilitary_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                frmEditMilitary military = new frmEditMilitary();
                MilitaryList list = new MilitaryList();
                list.AddMilitary(this.clbMilitaries.SelectedItem as Military);
                military.Militaries = list;
                military.CurrentArchitecture = this.editingArchitecture;
                military.ShowDialog();
            }
        }

        private void btnEditNoFactionPerson_Click(object sender, EventArgs e)
        {
            frmEditPerson person = new frmEditPerson();
            person.MainForm = this.MainForm;
            PersonList list = new PersonList();
            list.Add(this.clbPersons.SelectedItem as Person);
            person.Persons = list;
            person.AllPersons = this.editingArchitecture.Scenario.Persons;
            person.ShowDialog();
        }

        private void btnEditPerson_Click(object sender, EventArgs e)
        {
            frmEditPerson person = new frmEditPerson();
            person.MainForm = this.MainForm;
            PersonList list = new PersonList();
            list.Add(this.clbPersons.SelectedItem as Person);
            person.Persons = list;
            person.AllPersons = this.editingArchitecture.Scenario.Persons;
            person.ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.editingArchitecture.Name = this.tbName.Text;
                foreach (ArchitectureKind kind in this.editingArchitecture.Scenario.GameCommonData.AllArchitectureKinds.ArchitectureKinds.Values) 
                {
                    if (kind.Name == this.tbKind.SelectedItem)
                    {
                        this.editingArchitecture.Kind = kind;
                    }
                }
                this.editingArchitecture.Population = int.Parse(this.tbPopulation.Text);
                this.editingArchitecture.LocationState = this.cbState.SelectedItem as GameObjects.ArchitectureDetail.State;
                this.editingArchitecture.IsStrategicCenter = this.cbIsStrategicCenter.Checked;
                this.editingArchitecture.Fund = int.Parse(this.tbFund.Text);
                this.editingArchitecture.Food = int.Parse(this.tbFood.Text);
                this.editingArchitecture.Agriculture = int.Parse(this.tbAgriculture.Text);
                this.editingArchitecture.Commerce = int.Parse(this.tbCommerce.Text);
                this.editingArchitecture.Technology = int.Parse(this.tbTechnology.Text);
                this.editingArchitecture.Domination = int.Parse(this.tbDomination.Text);
                this.editingArchitecture.Morale = int.Parse(this.tbMorale.Text);
                this.editingArchitecture.Endurance = int.Parse(this.tbEndurance.Text);
            }
            catch
            {
            }
        }

        private void btnNewMilitary_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                Military military = new Military();
                military.Scenario = this.editingArchitecture.Scenario;
                military.ID = this.editingArchitecture.Scenario.Militaries.GetFreeGameObjectID();
                military.Name = "轻步兵队";
                military.KindID = 0;
                military.Quantity = 0x2710;
                military.Morale = 100;
                military.Combativity = 100;
                this.editingArchitecture.Scenario.Militaries.AddMilitary(military);
                this.editingArchitecture.AddMilitary(military);
                if (this.editingArchitecture.BelongedFaction != null)
                {
                    this.editingArchitecture.BelongedFaction.AddMilitary(military);
                }
                this.RefreshMilitaries();
            }
        }

        private void btnRemoveCharacteristic_Click(object sender, EventArgs e)
        {
            foreach (Influence influence in this.clbCharacteristics.SelectedItems)
            {
                this.editingArchitecture.Characteristics.Influences.Remove(influence.ID);
            }
            this.RefreshCharacteristics();
        }

        private void btnRemoveFacility_Click(object sender, EventArgs e)
        {
            foreach (Facility facility in this.clbFacilities.SelectedItems)
            {
                this.editingArchitecture.DemolishFacility(facility);
            }
            this.RefreshFacilities();
        }

        private void btnRemoveMilitary_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                foreach (Military military in this.clbMilitaries.CheckedItems)
                {
                    this.editingArchitecture.RemoveMilitary(military);
                    if (this.editingArchitecture.BelongedFaction != null)
                    {
                        this.editingArchitecture.BelongedFaction.RemoveMilitary(military);
                    }
                    this.editingArchitecture.Scenario.Militaries.Remove(military);
                }
                this.RefreshMilitaries();
            }
        }

        private void btnRemoveNoFactionPerson_Click(object sender, EventArgs e)
        {
            foreach (object obj2 in this.clbNoFactionPerson.CheckedItems)
            {
                (obj2 as Person).Available = false;
                (obj2 as Person).Status = GameObjects.PersonDetail.PersonStatus.None;
                (obj2 as Person).LocationArchitecture = null;
            }
            this.RefreshNoFactionPersons();
        }

        private void btnRemovePerson_Click(object sender, EventArgs e)
        {
            foreach (object obj2 in this.clbPersons.CheckedItems)
            {
                (obj2 as Person).Available = false;
                (obj2 as Person).Status = GameObjects.PersonDetail.PersonStatus.None;
                (obj2 as Person).LocationArchitecture = null;
            }
            this.RefreshPersons();
        }

        private void btnSelectFaction_Click(object sender, EventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                frmSelectFactionList list = new frmSelectFactionList();
                list.Factions = this.editingArchitecture.Scenario.Factions;
                list.ShowDialog();
                if ((list.SelectedFaction != null) && !list.SelectedFaction.HasArchitecture(this.editingArchitecture))
                {
                    list.SelectedFaction.AddArchitecture(this.editingArchitecture);
                    list.SelectedFaction.AddArchitectureMilitaries(this.editingArchitecture);
                    if ((list.SelectedFaction.FirstSection != null) && !list.SelectedFaction.FirstSection.HasArchitecture(this.editingArchitecture))
                    {
                        list.SelectedFaction.FirstSection.AddArchitecture(this.editingArchitecture);
                    }
                    this.lblFaction.Text = this.editingArchitecture.FactionString;
                }
            }
        }

        private void btnSelectSection_Click(object sender, EventArgs e)
        {
            if (((this.editingArchitecture != null) && (this.editingArchitecture.BelongedFaction != null)) && (this.editingArchitecture.BelongedFaction.FirstSection != null))
            {
                frmSelectSectionList list = new frmSelectSectionList();
                list.Sections = this.editingArchitecture.BelongedFaction.Sections;
                list.ShowDialog();
                if ((list.SelectedSection != null) && !list.SelectedSection.HasArchitecture(this.editingArchitecture))
                {
                    list.SelectedSection.AddArchitecture(this.editingArchitecture);
                }
                if (this.editingArchitecture.BelongedSection != null)
                {
                    this.lblSection.Text = this.editingArchitecture.BelongedSection.Name;
                }
            }
        }

        private void clbMilitaries_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.editingArchitecture != null)
            {
                frmEditMilitary military = new frmEditMilitary();
                MilitaryList list = new MilitaryList();
                list.AddMilitary(this.clbMilitaries.SelectedItem as Military);
                military.Militaries = list;
                military.CurrentArchitecture = this.editingArchitecture;
                military.ShowDialog();
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

        private void frmEditArchitecture_Load(object sender, EventArgs e)
        {
            if (this.Architectures != null)
            {
                this.editingArchitecture = this.Architectures[0] as Architecture;
            }
            if ((this.editingArchitecture != null) || ((this.Architectures != null) && (this.Architectures.Count == 1)))
            {
                List<String> allNames = new List<string>();
                foreach (ArchitectureKind a in this.editingArchitecture.Scenario.GameCommonData.AllArchitectureKinds.ArchitectureKinds.Values)
                {
                    allNames.Add(a.Name);
                }
                this.tbKind.Items.AddRange(allNames.ToArray());
                this.tbName.Text = this.editingArchitecture.Name;
                this.tbKind.SelectedItem = this.editingArchitecture.Kind.Name;
                this.lblFaction.Text = this.editingArchitecture.FactionString;
                this.lblSection.Text = this.editingArchitecture.SectionString;
                this.tbPopulation.Text = this.editingArchitecture.Population.ToString();
                foreach (GameObjects.ArchitectureDetail.State state in this.editingArchitecture.Scenario.States)
                {
                    this.cbState.Items.Add(state);
                }
                this.cbState.SelectedItem = this.editingArchitecture.LocationState;
                this.cbIsStrategicCenter.Checked = this.editingArchitecture.IsStrategicCenter;
                this.tbFund.Text = this.editingArchitecture.Fund.ToString();
                this.tbFood.Text = this.editingArchitecture.Food.ToString();
                this.tbAgriculture.Text = this.editingArchitecture.Agriculture.ToString();
                this.tbCommerce.Text = this.editingArchitecture.Commerce.ToString();
                this.tbTechnology.Text = this.editingArchitecture.Technology.ToString();
                this.tbDomination.Text = this.editingArchitecture.Domination.ToString();
                this.tbMorale.Text = this.editingArchitecture.Morale.ToString();
                this.tbEndurance.Text = this.editingArchitecture.Endurance.ToString();
                foreach (Influence influence in this.editingArchitecture.Scenario.GameCommonData.AllInfluences.Influences.Values)
                {
                    if ((influence.ID >= 0x3e8) && (influence.ID < 0x7d0))
                    {
                        this.cbCharacteristics.Items.Add(influence);
                    }
                }
                foreach (FacilityKind kind in this.editingArchitecture.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                {
                    this.cbFacilityKinds.Items.Add(kind);
                }
                this.RefreshCharacteristics();
                this.RefreshFacilities();
                this.RefreshPersons();
                this.RefreshNoFactionPersons();
                this.RefreshMilitaries();
                this.RefreshLinks();
            }
        }

        private void InitializeComponent()
        {
            this.groupBox2 = new GroupBox();
            this.tbEndurance = new TextBox();
            this.tbMorale = new TextBox();
            this.tbDomination = new TextBox();
            this.tbTechnology = new TextBox();
            this.tbCommerce = new TextBox();
            this.tbAgriculture = new TextBox();
            this.tbFood = new TextBox();
            this.tbFund = new TextBox();
            this.label21 = new Label();
            this.label20 = new Label();
            this.label19 = new Label();
            this.label18 = new Label();
            this.label17 = new Label();
            this.label16 = new Label();
            this.label15 = new Label();
            this.label14 = new Label();
            this.btnCapital = new Button();
            this.groupBox1 = new GroupBox();
            this.btnAllFood = new Button();
            this.tbAllFood = new TextBox();
            this.label23 = new Label();
            this.btnAllFund = new Button();
            this.tbAllFund = new TextBox();
            this.label22 = new Label();
            this.btnAllPopulation = new Button();
            this.tbAllPopulation = new TextBox();
            this.label7 = new Label();
            this.cbIsStrategicCenter = new CheckBox();
            this.btnDeleteWaterLink = new Button();
            this.btnDeleteLandLink = new Button();
            this.label10 = new Label();
            this.clbWaterLinks = new CheckedListBox();
            this.label8 = new Label();
            this.clbLandLinks = new CheckedListBox();
            this.lblSection = new Label();
            this.btnSelectSection = new Button();
            this.label9 = new Label();
            this.cbCharacteristics = new ComboBox();
            this.cbFacilityKinds = new ComboBox();
            this.label6 = new Label();
            this.btnRemoveFacility = new Button();
            this.btnAddFacility = new Button();
            this.clbFacilities = new CheckedListBox();
            this.label5 = new Label();
            this.btnRemoveCharacteristic = new Button();
            this.btnAddCharacteristic = new Button();
            this.clbCharacteristics = new CheckedListBox();
            this.label4 = new Label();
            this.cbState = new ComboBox();
            this.btnNewMilitary = new Button();
            this.btnEditMilitary = new Button();
            this.label13 = new Label();
            this.btnRemoveMilitary = new Button();
            this.btnAddMilitary = new Button();
            this.clbMilitaries = new CheckedListBox();
            this.btnEditPerson = new Button();
            this.lblFaction = new Label();
            this.btnSelectFaction = new Button();
            this.label12 = new Label();
            this.label11 = new Label();
            this.btnRemovePerson = new Button();
            this.btnAddPerson = new Button();
            this.clbPersons = new CheckedListBox();
            this.label3 = new Label();
            this.tbPopulation = new TextBox();
            this.tbKind = new ComboBox();
            this.label2 = new Label();
            this.label1 = new Label();
            this.tbName = new TextBox();
            this.btnCancel = new Button();
            this.btnModify = new Button();
            this.clbNoFactionPerson = new CheckedListBox();
            this.label24 = new Label();
            this.btnRemoveNoFactionPerson = new Button();
            this.btnAddNoFactionPerson = new Button();
            this.btnEditNoFactionPerson = new Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox2.Controls.Add(this.btnEditNoFactionPerson);
            this.groupBox2.Controls.Add(this.btnRemoveNoFactionPerson);
            this.groupBox2.Controls.Add(this.btnAddNoFactionPerson);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.clbNoFactionPerson);
            this.groupBox2.Controls.Add(this.tbEndurance);
            this.groupBox2.Controls.Add(this.tbMorale);
            this.groupBox2.Controls.Add(this.tbDomination);
            this.groupBox2.Controls.Add(this.tbTechnology);
            this.groupBox2.Controls.Add(this.tbCommerce);
            this.groupBox2.Controls.Add(this.tbAgriculture);
            this.groupBox2.Controls.Add(this.tbFood);
            this.groupBox2.Controls.Add(this.tbFund);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.btnCapital);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.cbIsStrategicCenter);
            this.groupBox2.Controls.Add(this.btnDeleteWaterLink);
            this.groupBox2.Controls.Add(this.btnDeleteLandLink);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.clbWaterLinks);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.clbLandLinks);
            this.groupBox2.Controls.Add(this.lblSection);
            this.groupBox2.Controls.Add(this.btnSelectSection);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.cbCharacteristics);
            this.groupBox2.Controls.Add(this.cbFacilityKinds);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.btnRemoveFacility);
            this.groupBox2.Controls.Add(this.btnAddFacility);
            this.groupBox2.Controls.Add(this.clbFacilities);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btnRemoveCharacteristic);
            this.groupBox2.Controls.Add(this.btnAddCharacteristic);
            this.groupBox2.Controls.Add(this.clbCharacteristics);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cbState);
            this.groupBox2.Controls.Add(this.btnNewMilitary);
            this.groupBox2.Controls.Add(this.btnEditMilitary);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnRemoveMilitary);
            this.groupBox2.Controls.Add(this.btnAddMilitary);
            this.groupBox2.Controls.Add(this.clbMilitaries);
            this.groupBox2.Controls.Add(this.btnEditPerson);
            this.groupBox2.Controls.Add(this.lblFaction);
            this.groupBox2.Controls.Add(this.btnSelectFaction);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btnRemovePerson);
            this.groupBox2.Controls.Add(this.btnAddPerson);
            this.groupBox2.Controls.Add(this.clbPersons);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbPopulation);
            this.groupBox2.Controls.Add(this.tbKind);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbName);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnModify);
            this.groupBox2.Location = new Point(-1, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(870, 0x209);
            this.groupBox2.TabIndex = 0x10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前建筑";
            this.tbEndurance.Location = new Point(0xeb, 0xba);
            this.tbEndurance.Name = "tbEndurance";
            this.tbEndurance.Size = new Size(0x92, 0x15);
            this.tbEndurance.TabIndex = 0x51;
            this.tbMorale.Location = new Point(0xeb, 0xa4);
            this.tbMorale.Name = "tbMorale";
            this.tbMorale.Size = new Size(0x92, 0x15);
            this.tbMorale.TabIndex = 80;
            this.tbDomination.Location = new Point(0xeb, 0x8e);
            this.tbDomination.Name = "tbDomination";
            this.tbDomination.Size = new Size(0x92, 0x15);
            this.tbDomination.TabIndex = 0x4f;
            this.tbTechnology.Location = new Point(0xeb, 120);
            this.tbTechnology.Name = "tbTechnology";
            this.tbTechnology.Size = new Size(0x92, 0x15);
            this.tbTechnology.TabIndex = 0x4e;
            this.tbCommerce.Location = new Point(0xeb, 0x62);
            this.tbCommerce.Name = "tbCommerce";
            this.tbCommerce.Size = new Size(0x92, 0x15);
            this.tbCommerce.TabIndex = 0x4d;
            this.tbAgriculture.Location = new Point(0xeb, 0x4c);
            this.tbAgriculture.Name = "tbAgriculture";
            this.tbAgriculture.Size = new Size(0x92, 0x15);
            this.tbAgriculture.TabIndex = 0x4c;
            this.tbFood.Location = new Point(0xeb, 0x30);
            this.tbFood.Name = "tbFood";
            this.tbFood.Size = new Size(0x92, 0x15);
            this.tbFood.TabIndex = 0x4b;
            this.tbFund.Location = new Point(0xeb, 0x19);
            this.tbFund.Name = "tbFund";
            this.tbFund.Size = new Size(0x92, 0x15);
            this.tbFund.TabIndex = 0x4a;
            this.label21.AutoSize = true;
            this.label21.Location = new Point(200, 0xbd);
            this.label21.Name = "label21";
            this.label21.Size = new Size(0x1d, 12);
            this.label21.TabIndex = 0x49;
            this.label21.Text = "耐久";
            this.label20.AutoSize = true;
            this.label20.Location = new Point(200, 0xa7);
            this.label20.Name = "label20";
            this.label20.Size = new Size(0x1d, 12);
            this.label20.TabIndex = 0x48;
            this.label20.Text = "民心";
            this.label19.AutoSize = true;
            this.label19.Location = new Point(200, 0x91);
            this.label19.Name = "label19";
            this.label19.Size = new Size(0x1d, 12);
            this.label19.TabIndex = 0x47;
            this.label19.Text = "统治";
            this.label18.AutoSize = true;
            this.label18.Location = new Point(200, 0x7b);
            this.label18.Name = "label18";
            this.label18.Size = new Size(0x1d, 12);
            this.label18.TabIndex = 70;
            this.label18.Text = "技术";
            this.label17.AutoSize = true;
            this.label17.Location = new Point(200, 0x65);
            this.label17.Name = "label17";
            this.label17.Size = new Size(0x1d, 12);
            this.label17.TabIndex = 0x45;
            this.label17.Text = "商业";
            this.label16.AutoSize = true;
            this.label16.Location = new Point(200, 0x4f);
            this.label16.Name = "label16";
            this.label16.Size = new Size(0x1d, 12);
            this.label16.TabIndex = 0x44;
            this.label16.Text = "农业";
            this.label15.AutoSize = true;
            this.label15.Location = new Point(200, 0x33);
            this.label15.Name = "label15";
            this.label15.Size = new Size(0x1d, 12);
            this.label15.TabIndex = 0x43;
            this.label15.Text = "粮草";
            this.label14.AutoSize = true;
            this.label14.Location = new Point(200, 0x1c);
            this.label14.Name = "label14";
            this.label14.Size = new Size(0x1d, 12);
            this.label14.TabIndex = 0x42;
            this.label14.Text = "资金";
            this.btnCapital.Location = new Point(0x22, 0x9d);
            this.btnCapital.Name = "btnCapital";
            this.btnCapital.Size = new Size(0x92, 0x17);
            this.btnCapital.TabIndex = 0x11;
            this.btnCapital.Text = "设置为势力都城";
            this.btnCapital.UseVisualStyleBackColor = true;
            this.btnCapital.Click += new EventHandler(this.btnCapital_Click);
            this.groupBox1.Controls.Add(this.btnAllFood);
            this.groupBox1.Controls.Add(this.tbAllFood);
            this.groupBox1.Controls.Add(this.label23);
            this.groupBox1.Controls.Add(this.btnAllFund);
            this.groupBox1.Controls.Add(this.tbAllFund);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.btnAllPopulation);
            this.groupBox1.Controls.Add(this.tbAllPopulation);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new Point(0x279, 0x10a);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(0xdb, 0xf4);
            this.groupBox1.TabIndex = 0x41;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "全部建筑";
            this.btnAllFood.Location = new Point(0x8e, 70);
            this.btnAllFood.Name = "btnAllFood";
            this.btnAllFood.Size = new Size(0x38, 0x17);
            this.btnAllFood.TabIndex = 8;
            this.btnAllFood.Text = "应用";
            this.btnAllFood.UseVisualStyleBackColor = true;
            this.btnAllFood.Click += new EventHandler(this.btnAllFood_Click);
            this.tbAllFood.Location = new Point(0x4f, 0x48);
            this.tbAllFood.Name = "tbAllFood";
            this.tbAllFood.Size = new Size(0x34, 0x15);
            this.tbAllFood.TabIndex = 7;
            this.tbAllFood.Text = "1.0";
            this.label23.AutoSize = true;
            this.label23.Location = new Point(20, 0x4d);
            this.label23.Name = "label23";
            this.label23.Size = new Size(0x35, 12);
            this.label23.TabIndex = 6;
            this.label23.Text = "粮草乘以";
            this.btnAllFund.Location = new Point(0x8e, 0x29);
            this.btnAllFund.Name = "btnAllFund";
            this.btnAllFund.Size = new Size(0x38, 0x17);
            this.btnAllFund.TabIndex = 5;
            this.btnAllFund.Text = "应用";
            this.btnAllFund.UseVisualStyleBackColor = true;
            this.btnAllFund.Click += new EventHandler(this.btnAllFund_Click);
            this.tbAllFund.Location = new Point(0x4f, 0x2b);
            this.tbAllFund.Name = "tbAllFund";
            this.tbAllFund.Size = new Size(0x34, 0x15);
            this.tbAllFund.TabIndex = 4;
            this.tbAllFund.Text = "1.0";
            this.label22.AutoSize = true;
            this.label22.Location = new Point(20, 0x30);
            this.label22.Name = "label22";
            this.label22.Size = new Size(0x35, 12);
            this.label22.TabIndex = 3;
            this.label22.Text = "资金乘以";
            this.btnAllPopulation.Location = new Point(0x8e, 12);
            this.btnAllPopulation.Name = "btnAllPopulation";
            this.btnAllPopulation.Size = new Size(0x38, 0x17);
            this.btnAllPopulation.TabIndex = 2;
            this.btnAllPopulation.Text = "应用";
            this.btnAllPopulation.UseVisualStyleBackColor = true;
            this.btnAllPopulation.Click += new EventHandler(this.btnAllPopulation_Click);
            this.tbAllPopulation.Location = new Point(0x4f, 14);
            this.tbAllPopulation.Name = "tbAllPopulation";
            this.tbAllPopulation.Size = new Size(0x34, 0x15);
            this.tbAllPopulation.TabIndex = 1;
            this.tbAllPopulation.Text = "1.0";
            this.label7.AutoSize = true;
            this.label7.Location = new Point(20, 0x13);
            this.label7.Name = "label7";
            this.label7.Size = new Size(0x35, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "人口乘以";
            this.cbIsStrategicCenter.AutoSize = true;
            this.cbIsStrategicCenter.Location = new Point(0x20, 130);
            this.cbIsStrategicCenter.Name = "cbIsStrategicCenter";
            this.cbIsStrategicCenter.Size = new Size(0x60, 0x10);
            this.cbIsStrategicCenter.TabIndex = 0x40;
            this.cbIsStrategicCenter.Text = "是否战略要冲";
            this.cbIsStrategicCenter.UseVisualStyleBackColor = true;
            this.btnDeleteWaterLink.Location = new Point(0x225, 0x1e7);
            this.btnDeleteWaterLink.Name = "btnDeleteWaterLink";
            this.btnDeleteWaterLink.Size = new Size(40, 0x17);
            this.btnDeleteWaterLink.TabIndex = 0x3f;
            this.btnDeleteWaterLink.Text = "删除";
            this.btnDeleteWaterLink.UseVisualStyleBackColor = true;
            this.btnDeleteWaterLink.Click += new EventHandler(this.btnDeleteWaterLink_Click);
            this.btnDeleteLandLink.Location = new Point(0x1d0, 0x1e7);
            this.btnDeleteLandLink.Name = "btnDeleteLandLink";
            this.btnDeleteLandLink.Size = new Size(40, 0x17);
            this.btnDeleteLandLink.TabIndex = 0x3e;
            this.btnDeleteLandLink.Text = "删除";
            this.btnDeleteLandLink.UseVisualStyleBackColor = true;
            this.btnDeleteLandLink.Click += new EventHandler(this.btnDeleteLandLink_Click);
            this.label10.AutoSize = true;
            this.label10.Location = new Point(0x223, 0x10a);
            this.label10.Name = "label10";
            this.label10.Size = new Size(0x35, 12);
            this.label10.TabIndex = 0x3d;
            this.label10.Text = "水上链接";
            this.clbWaterLinks.CheckOnClick = true;
            this.clbWaterLinks.FormattingEnabled = true;
            this.clbWaterLinks.Location = new Point(0x225, 0x11d);
            this.clbWaterLinks.Name = "clbWaterLinks";
            this.clbWaterLinks.Size = new Size(0x4e, 0xc4);
            this.clbWaterLinks.TabIndex = 60;
            this.label8.AutoSize = true;
            this.label8.Location = new Point(0x1ce, 0x10a);
            this.label8.Name = "label8";
            this.label8.Size = new Size(0x35, 12);
            this.label8.TabIndex = 0x3b;
            this.label8.Text = "陆上链接";
            this.clbLandLinks.CheckOnClick = true;
            this.clbLandLinks.FormattingEnabled = true;
            this.clbLandLinks.Location = new Point(0x1d0, 0x11d);
            this.clbLandLinks.Name = "clbLandLinks";
            this.clbLandLinks.Size = new Size(0x4f, 0xc4);
            this.clbLandLinks.TabIndex = 0x3a;
            this.lblSection.AutoSize = true;
            this.lblSection.Location = new Point(0x44, 0xe0);
            this.lblSection.Name = "lblSection";
            this.lblSection.Size = new Size(0x1d, 12);
            this.lblSection.TabIndex = 0x39;
            this.lblSection.Text = "军区";
            this.btnSelectSection.Location = new Point(0x83, 0xda);
            this.btnSelectSection.Name = "btnSelectSection";
            this.btnSelectSection.Size = new Size(0x31, 0x17);
            this.btnSelectSection.TabIndex = 0x38;
            this.btnSelectSection.Text = "选择";
            this.btnSelectSection.UseVisualStyleBackColor = true;
            this.btnSelectSection.Click += new EventHandler(this.btnSelectSection_Click);
            this.label9.AutoSize = true;
            this.label9.Location = new Point(0x1d, 0xe0);
            this.label9.Margin = new Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new Size(0x1d, 12);
            this.label9.TabIndex = 0x37;
            this.label9.Text = "军区";
            this.cbCharacteristics.FormattingEnabled = true;
            this.cbCharacteristics.Location = new Point(0x18e, 0xc2);
            this.cbCharacteristics.Name = "cbCharacteristics";
            this.cbCharacteristics.Size = new Size(0x8e, 20);
            this.cbCharacteristics.TabIndex = 0x36;
            this.cbFacilityKinds.FormattingEnabled = true;
            this.cbFacilityKinds.Location = new Point(0x257, 0xc2);
            this.cbFacilityKinds.Name = "cbFacilityKinds";
            this.cbFacilityKinds.Size = new Size(0x83, 20);
            this.cbFacilityKinds.TabIndex = 0x35;
            this.label6.AutoSize = true;
            this.label6.Location = new Point(0x255, 0x12);
            this.label6.Name = "label6";
            this.label6.Size = new Size(0x1d, 12);
            this.label6.TabIndex = 0x34;
            this.label6.Text = "设施";
            this.btnRemoveFacility.Location = new Point(0x257, 220);
            this.btnRemoveFacility.Name = "btnRemoveFacility";
            this.btnRemoveFacility.Size = new Size(0x26, 0x17);
            this.btnRemoveFacility.TabIndex = 0x33;
            this.btnRemoveFacility.Text = "删除";
            this.btnRemoveFacility.UseVisualStyleBackColor = true;
            this.btnRemoveFacility.Click += new EventHandler(this.btnRemoveFacility_Click);
            this.btnAddFacility.Location = new Point(0x2e0, 0xbf);
            this.btnAddFacility.Name = "btnAddFacility";
            this.btnAddFacility.Size = new Size(0x25, 0x17);
            this.btnAddFacility.TabIndex = 50;
            this.btnAddFacility.Text = "添加";
            this.btnAddFacility.UseVisualStyleBackColor = true;
            this.btnAddFacility.Click += new EventHandler(this.btnAddFacility_Click);
            this.clbFacilities.CheckOnClick = true;
            this.clbFacilities.FormattingEnabled = true;
            this.clbFacilities.Location = new Point(0x257, 0x25);
            this.clbFacilities.Name = "clbFacilities";
            this.clbFacilities.Size = new Size(0xae, 0x94);
            this.clbFacilities.TabIndex = 0x31;
            this.label5.AutoSize = true;
            this.label5.Location = new Point(0x18c, 0x12);
            this.label5.Name = "label5";
            this.label5.Size = new Size(0x1d, 12);
            this.label5.TabIndex = 0x30;
            this.label5.Text = "特色";
            this.btnRemoveCharacteristic.Location = new Point(0x18e, 220);
            this.btnRemoveCharacteristic.Name = "btnRemoveCharacteristic";
            this.btnRemoveCharacteristic.Size = new Size(0x29, 0x17);
            this.btnRemoveCharacteristic.TabIndex = 0x2f;
            this.btnRemoveCharacteristic.Text = "删除";
            this.btnRemoveCharacteristic.UseVisualStyleBackColor = true;
            this.btnRemoveCharacteristic.Click += new EventHandler(this.btnRemoveCharacteristic_Click);
            this.btnAddCharacteristic.Location = new Point(0x222, 0xc2);
            this.btnAddCharacteristic.Name = "btnAddCharacteristic";
            this.btnAddCharacteristic.Size = new Size(0x2b, 0x17);
            this.btnAddCharacteristic.TabIndex = 0x2e;
            this.btnAddCharacteristic.Text = "添加";
            this.btnAddCharacteristic.UseVisualStyleBackColor = true;
            this.btnAddCharacteristic.Click += new EventHandler(this.btnAddCharacteristic_Click);
            this.clbCharacteristics.CheckOnClick = true;
            this.clbCharacteristics.FormattingEnabled = true;
            this.clbCharacteristics.Location = new Point(0x18e, 0x25);
            this.clbCharacteristics.Name = "clbCharacteristics";
            this.clbCharacteristics.Size = new Size(0xbf, 0x94);
            this.clbCharacteristics.TabIndex = 0x2d;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(0x1d, 0x66);
            this.label4.Margin = new Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new Size(0x1d, 12);
            this.label4.TabIndex = 0x2c;
            this.label4.Text = "州域";
            this.cbState.FormattingEnabled = true;
            this.cbState.Location = new Point(70, 0x63);
            this.cbState.Margin = new Padding(2);
            this.cbState.Name = "cbState";
            this.cbState.Size = new Size(110, 20);
            this.cbState.TabIndex = 0x2b;
            this.btnNewMilitary.Location = new Point(0xfe, 0x1e7);
            this.btnNewMilitary.Name = "btnNewMilitary";
            this.btnNewMilitary.Size = new Size(0x26, 0x17);
            this.btnNewMilitary.TabIndex = 0x2a;
            this.btnNewMilitary.Text = "新增";
            this.btnNewMilitary.UseVisualStyleBackColor = true;
            this.btnNewMilitary.Click += new EventHandler(this.btnNewMilitary_Click);
            this.btnEditMilitary.Location = new Point(0x12a, 0x1e7);
            this.btnEditMilitary.Name = "btnEditMilitary";
            this.btnEditMilitary.Size = new Size(0x26, 0x17);
            this.btnEditMilitary.TabIndex = 0x29;
            this.btnEditMilitary.Text = "编辑";
            this.btnEditMilitary.UseVisualStyleBackColor = true;
            this.btnEditMilitary.Click += new EventHandler(this.btnEditMilitary_Click);
            this.label13.AutoSize = true;
            this.label13.Location = new Point(0xfc, 0x10a);
            this.label13.Name = "label13";
            this.label13.Size = new Size(0x1d, 12);
            this.label13.TabIndex = 40;
            this.label13.Text = "编队";
            this.btnRemoveMilitary.Location = new Point(0x183, 0x1e7);
            this.btnRemoveMilitary.Name = "btnRemoveMilitary";
            this.btnRemoveMilitary.Size = new Size(40, 0x17);
            this.btnRemoveMilitary.TabIndex = 0x27;
            this.btnRemoveMilitary.Text = "删除";
            this.btnRemoveMilitary.UseVisualStyleBackColor = true;
            this.btnRemoveMilitary.Click += new EventHandler(this.btnRemoveMilitary_Click);
            this.btnAddMilitary.Location = new Point(0x156, 0x1e7);
            this.btnAddMilitary.Name = "btnAddMilitary";
            this.btnAddMilitary.Size = new Size(0x27, 0x17);
            this.btnAddMilitary.TabIndex = 0x26;
            this.btnAddMilitary.Text = "添加";
            this.btnAddMilitary.UseVisualStyleBackColor = true;
            this.btnAddMilitary.Click += new EventHandler(this.btnAddMilitary_Click);
            this.clbMilitaries.FormattingEnabled = true;
            this.clbMilitaries.Location = new Point(0xfe, 0x11d);
            this.clbMilitaries.Name = "clbMilitaries";
            this.clbMilitaries.Size = new Size(0xc4, 0xc4);
            this.clbMilitaries.TabIndex = 0x25;
            this.clbMilitaries.MouseDoubleClick += new MouseEventHandler(this.clbMilitaries_MouseDoubleClick);
            this.btnEditPerson.Location = new Point(13, 0x1e7);
            this.btnEditPerson.Name = "btnEditPerson";
            this.btnEditPerson.Size = new Size(0x2d, 0x17);
            this.btnEditPerson.TabIndex = 0x24;
            this.btnEditPerson.Text = "编辑";
            this.btnEditPerson.UseVisualStyleBackColor = true;
            this.btnEditPerson.Click += new EventHandler(this.btnEditPerson_Click);
            this.lblFaction.AutoSize = true;
            this.lblFaction.Location = new Point(0x44, 0xc6);
            this.lblFaction.Name = "lblFaction";
            this.lblFaction.Size = new Size(0x1d, 12);
            this.lblFaction.TabIndex = 0x23;
            this.lblFaction.Text = "势力";
            this.btnSelectFaction.Location = new Point(0x83, 0xc0);
            this.btnSelectFaction.Name = "btnSelectFaction";
            this.btnSelectFaction.Size = new Size(0x31, 0x17);
            this.btnSelectFaction.TabIndex = 0x22;
            this.btnSelectFaction.Text = "选择";
            this.btnSelectFaction.UseVisualStyleBackColor = true;
            this.btnSelectFaction.Click += new EventHandler(this.btnSelectFaction_Click);
            this.label12.AutoSize = true;
            this.label12.Location = new Point(0x1d, 0xc6);
            this.label12.Margin = new Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new Size(0x1d, 12);
            this.label12.TabIndex = 0x21;
            this.label12.Text = "势力";
            this.label11.AutoSize = true;
            this.label11.Location = new Point(11, 0x10a);
            this.label11.Name = "label11";
            this.label11.Size = new Size(0x1d, 12);
            this.label11.TabIndex = 0x20;
            this.label11.Text = "人物";
            this.btnRemovePerson.Location = new Point(0x70, 0x1e7);
            this.btnRemovePerson.Name = "btnRemovePerson";
            this.btnRemovePerson.Size = new Size(0x29, 0x17);
            this.btnRemovePerson.TabIndex = 0x1f;
            this.btnRemovePerson.Text = "删除";
            this.btnRemovePerson.UseVisualStyleBackColor = true;
            this.btnRemovePerson.Click += new EventHandler(this.btnRemovePerson_Click);
            this.btnAddPerson.Location = new Point(0x40, 0x1e7);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new Size(0x2b, 0x17);
            this.btnAddPerson.TabIndex = 30;
            this.btnAddPerson.Text = "添加";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new EventHandler(this.btnAddPerson_Click);
            this.clbPersons.CheckOnClick = true;
            this.clbPersons.FormattingEnabled = true;
            this.clbPersons.Location = new Point(13, 0x11d);
            this.clbPersons.Name = "clbPersons";
            this.clbPersons.Size = new Size(0xe1, 0xc4);
            this.clbPersons.TabIndex = 0x1d;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(30, 0x4a);
            this.label3.Margin = new Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(0x1d, 12);
            this.label3.TabIndex = 0x16;
            this.label3.Text = "人口";
            this.tbPopulation.Location = new Point(70, 0x48);
            this.tbPopulation.Margin = new Padding(2);
            this.tbPopulation.MaxLength = 20;
            this.tbPopulation.Name = "tbPopulation";
            this.tbPopulation.Size = new Size(110, 0x15);
            this.tbPopulation.TabIndex = 0x15;
            this.tbPopulation.WordWrap = false;
            this.tbKind.FormattingEnabled = true;
            this.tbKind.Items.AddRange(new object[] {});
            this.tbKind.Location = new Point(70, 0x2e);
            this.tbKind.Margin = new Padding(2);
            this.tbKind.Name = "tbKind";
            this.tbKind.Size = new Size(110, 20);
            this.tbKind.TabIndex = 20;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(0x1d, 0x30);
            this.label2.Margin = new Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x1d, 12);
            this.label2.TabIndex = 0x13;
            this.label2.Text = "种类";
            this.label1.AutoSize = true;
            this.label1.Location = new Point(0x1d, 0x17);
            this.label1.Margin = new Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x1d, 12);
            this.label1.TabIndex = 0x12;
            this.label1.Text = "名称";
            this.tbName.Location = new Point(70, 0x13);
            this.tbName.Margin = new Padding(2);
            this.tbName.MaxLength = 20;
            this.tbName.Name = "tbName";
            this.tbName.Size = new Size(110, 0x15);
            this.tbName.TabIndex = 0x11;
            this.tbName.WordWrap = false;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.Location = new Point(0x142, 0xe2);
            this.btnCancel.Margin = new Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(0x38, 20);
            this.btnCancel.TabIndex = 0x10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnModify.DialogResult = DialogResult.OK;
            this.btnModify.Location = new Point(0x105, 0xe2);
            this.btnModify.Margin = new Padding(2);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new Size(0x38, 20);
            this.btnModify.TabIndex = 15;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new EventHandler(this.btnModify_Click);
            this.clbNoFactionPerson.FormattingEnabled = true;
            this.clbNoFactionPerson.Location = new Point(0x30b, 0x25);
            this.clbNoFactionPerson.Name = "clbNoFactionPerson";
            this.clbNoFactionPerson.Size = new Size(0x55, 0x94);
            this.clbNoFactionPerson.TabIndex = 0x52;
            this.label24.AutoSize = true;
            this.label24.Location = new Point(0x309, 0x13);
            this.label24.Name = "label24";
            this.label24.Size = new Size(0x35, 12);
            this.label24.TabIndex = 0x53;
            this.label24.Text = "在野人物";
            this.btnRemoveNoFactionPerson.Location = new Point(0x337, 0xbd);
            this.btnRemoveNoFactionPerson.Name = "btnRemoveNoFactionPerson";
            this.btnRemoveNoFactionPerson.Size = new Size(0x29, 0x17);
            this.btnRemoveNoFactionPerson.TabIndex = 0x55;
            this.btnRemoveNoFactionPerson.Text = "删除";
            this.btnRemoveNoFactionPerson.UseVisualStyleBackColor = true;
            this.btnRemoveNoFactionPerson.Click += new EventHandler(this.btnRemoveNoFactionPerson_Click);
            this.btnAddNoFactionPerson.Location = new Point(0x30d, 0xbd);
            this.btnAddNoFactionPerson.Name = "btnAddNoFactionPerson";
            this.btnAddNoFactionPerson.Size = new Size(0x2b, 0x17);
            this.btnAddNoFactionPerson.TabIndex = 0x54;
            this.btnAddNoFactionPerson.Text = "添加";
            this.btnAddNoFactionPerson.UseVisualStyleBackColor = true;
            this.btnAddNoFactionPerson.Click += new EventHandler(this.btnAddNoFactionPerson_Click);
            this.btnEditNoFactionPerson.Location = new Point(0x30d, 0xd5);
            this.btnEditNoFactionPerson.Name = "btnEditNoFactionPerson";
            this.btnEditNoFactionPerson.Size = new Size(0x53, 0x17);
            this.btnEditNoFactionPerson.TabIndex = 0x56;
            this.btnEditNoFactionPerson.Text = "编辑";
            this.btnEditNoFactionPerson.UseVisualStyleBackColor = true;
            this.btnEditNoFactionPerson.Click += new EventHandler(this.btnEditNoFactionPerson_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x371, 0x21f);
            base.Controls.Add(this.groupBox2);
            base.FormBorderStyle = FormBorderStyle.FixedSingle;
            base.Margin = new Padding(2);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "frmEditArchitecture";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "修改建筑属性";
            base.Load += new EventHandler(this.frmEditArchitecture_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void RefreshCharacteristics()
        {
            this.clbCharacteristics.Items.Clear();
            foreach (Influence influence in this.editingArchitecture.Characteristics.Influences.Values)
            {
                this.clbCharacteristics.Items.Add(influence);
            }
        }

        private void RefreshFacilities()
        {
            this.clbFacilities.Items.Clear();
            foreach (Facility facility in this.editingArchitecture.Facilities)
            {
                this.clbFacilities.Items.Add(facility);
            }
        }

        private void RefreshLinks()
        {
            this.clbLandLinks.Items.Clear();
            foreach (Architecture architecture in this.editingArchitecture.AILandLinks)
            {
                this.clbLandLinks.Items.Add(architecture);
            }
            this.clbWaterLinks.Items.Clear();
            foreach (Architecture architecture in this.editingArchitecture.AIWaterLinks)
            {
                this.clbWaterLinks.Items.Add(architecture);
            }
        }

        private void RefreshMilitaries()
        {
            this.clbMilitaries.Items.Clear();
            foreach (Military military in this.editingArchitecture.Militaries)
            {
                this.clbMilitaries.Items.Add(military);
            }
        }

        private void RefreshNoFactionPersons()
        {
            this.clbNoFactionPerson.Items.Clear();
            foreach (Person person in this.editingArchitecture.NoFactionPersons)
            {
                this.clbNoFactionPerson.Items.Add(person);
            }
        }

        private void RefreshPersons()
        {
            this.clbPersons.Items.Clear();
            foreach (Person person in this.editingArchitecture.Persons)
            {
                this.clbPersons.Items.Add(person);
            }
        }
    }
}

