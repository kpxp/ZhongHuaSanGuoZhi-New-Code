namespace MapEditor.Forms.PersonForms
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.PersonDetail;
    using MapEditor;
    using MapEditor.Forms;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class frmEditPerson : Form
    {
        public PersonList AllPersons;
        private Button btnAddClosePerson;
        private Button btnAddHatedPersons;
        private Button btnAddStunt;
        private Button btnApply;
        private Button btnApplySkills;
        private Button btnChangePortrait;
        private Button btnDeleteAllStunt;
        private Button btnDeleteSelectedStunt;
        private Button btnRemoveClosePerson;
        private Button btnRemoveHatedPersons;
        private Button btnSaveTextMessage;
        private ComboBox cbAllStunt;
        private ComboBox cbAmbition;
        private ComboBox cbBornRegion;
        private ComboBox cbCharacter;
        private ComboBox cbDeadReason;
        private ComboBox cbFactionColor;
        private ComboBox cbIdealTendency;
        private CheckBox cbOnlySelectFromTheNew;
        private ComboBox cbPersonalLoyalty;
        private ComboBox cbQualification;
        private ComboBox cbStrategyTendency;
        private ComboBox cbValuationOnGovernment;
        private CheckedListBox clb00;
        private CheckedListBox clb01;
        private CheckedListBox clb02;
        private CheckedListBox clb03;
        private CheckedListBox clb04;
        private CheckedListBox clb05;
        private CheckedListBox clb06;
        private CheckedListBox clb07;
        private CheckedListBox clb08;
        private CheckedListBox clb09;
        private CheckedListBox clb10;
        private CheckedListBox clb11;
        private IContainer components = null;
        private GroupBox gbClosePersons;
        private GroupBox gbHatedPersons;
        private GroupBox gbSkills;
        private GroupBox gbStunt;
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
        private Label label25;
        private Label label26;
        private Label label27;
        private Label label28;
        private Label label29;
        private Label label3;
        private Label label30;
        private Label label31;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label label37;
        private Label label38;
        private Label label39;
        private Label label4;
        private Label label40;
        private Label label41;
        private Label label42;
        private Label label43;
        private Label label44;
        private Label label45;
        private Label label46;
        private Label label47;
        private Label label48;
        private Label label49;
        private Label label5;
        private Label label50;
        private Label label51;
        private Label label54;
        private Label label55;
        private Label label56;
        private Label label57;
        private Label label58;
        private Label label59;
        private Label label6;
        private Label label60;
        private Label label61;
        private Label label62;
        private Label label63;
        private Label label64;
        private Label label65;
        private Label label66;
        private Label label67;
        private Label label68;
        private Label label69;
        private Label label7;
        private Label label70;
        private Label label71;
        private Label label72;
        private Label label73;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label77;
        private Label label78;
        private Label label79;
        private Label label8;
        private Label label9;
        private ListBox lbClosePersons;
        private ListBox lbHatedPersons;
        private ListBox lbStunt;
        public formMapEditor MainForm;
        private bool multiEdit = false;
        private PictureBox pbHead;
        private Person person;
        public PersonList Persons;
        private RichTextBox rtbAntiAttack;
        private RichTextBox rtbBiographyBrief;
        private RichTextBox rtbBiographyHistory;
        private RichTextBox rtbBiographyRomance;
        private RichTextBox rtbBreakWall;
        private RichTextBox rtbCastDeepChaos;
        private RichTextBox rtbChaos;
        private RichTextBox rtbControversyInitiativeWin;
        private RichTextBox rtbControversyPassiveWin;
        private RichTextBox rtbCriticalStrike;
        private RichTextBox rtbCriticalStrikeOnArchitecture;
        private RichTextBox rtbDeepChaos;
        private RichTextBox rtbDualInitiativeWin;
        private RichTextBox rtbDualPassiveWin;
        private RichTextBox rtbHelpedByStratagem;
        private RichTextBox rtbOutburstAngry;
        private RichTextBox rtbOutburstQuiet;
        private RichTextBox rtbReceiveCriticalStrike;
        private RichTextBox rtbRecoverFromChaos;
        private RichTextBox rtbResistHarmfulStratagem;
        private RichTextBox rtbResistHelpfulStratagem;
        private RichTextBox rtbRout;
        private RichTextBox rtbSurround;
        private RichTextBox rtbTrappedByStratagem;
        private StatusStrip ssInfo;
        private TabControl tabPerson;
        private TextBox tbAvailableLocation;
        private TextBox tbAvailableYear;
        private TextBox tbBornYear;
        private TextBox tbBraveness;
        private TextBox tbBrother;
        private TextBox tbCalledName;
        private TextBox tbCalmness;
        private TextBox tbCommand;
        private TextBox tbCommandExperience;
        private TextBox tbDeadYear;
        private TextBox tbFather;
        private TextBox tbGeneration;
        private TextBox tbGivenName;
        private TextBox tbGlamour;
        private TextBox tbGlamourExperience;
        private TextBox tbIdeal;
        private TextBox tbIntelligence;
        private TextBox tbIntelligenceExperience;
        private TextBox tbLoyalty;
        private TextBox tbMother;
        private TextBox tbOldFactionID;
        private TextBox tbPic;
        private TextBox tbPolitics;
        private TextBox tbPoliticsExperience;
        private TextBox tbSpouse;
        private TextBox tbStrain;
        private TextBox tbStrength;
        private TextBox tbStrengthExperience;
        private TextBox tbSurName;
        private TabPage tpBasic;
        private TabPage tpSkill;
        private TabPage tpTextMessage;
        private GroupBox groupBox1;
        private Button btnDeleteAllTitle;
        private Button btnDeleteSelectedTitle;
        private Button btnAddTitle;
        private ComboBox cbAllTitle;
        private ListBox lbTitle;
        private ToolStripStatusLabel tsslIDtoName;

        public frmEditPerson()
        {
            this.InitializeComponent();
        }

        private void btnAddClosePerson_Click(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.AllPersons;
                list.ShowDialog();
                foreach (int num in list.IDList)
                {
                    this.lbClosePersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                }
            }
        }

        private void btnAddHatedPersons_Click(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count != 0))
            {
                frmSelectPersonList list = new frmSelectPersonList();
                list.Persons = this.AllPersons;
                list.ShowDialog();
                foreach (int num in list.IDList)
                {
                    this.lbHatedPersons.Items.Add(num.ToString() + " " + (this.AllPersons.GetGameObject(num) as Person).Name);
                }
            }
        }

        private void btnAddTitle_Click(object sender, EventArgs e)
        {
            Title selectedItem = this.cbAllTitle.SelectedItem as Title;
            if (selectedItem != null)
            {
                if (!this.person.RealTitles.Contains(selectedItem))
                {
                    this.person.RealTitles.Add(selectedItem);
                }
                this.RefreshTitleList();
            }
        }

        private void btnAddStunt_Click(object sender, EventArgs e)
        {
            Stunt selectedItem = this.cbAllStunt.SelectedItem as Stunt;
            if (selectedItem != null)
            {
                if (this.person.Stunts.GetStunt(selectedItem.ID) == null)
                {
                    this.person.Stunts.AddStunt(selectedItem);
                }
                this.RefreshStuntList();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (this.multiEdit)
            {
                foreach (Person person in this.Persons)
                {
                }
            }
            else
            {
                this.SavePersonBasicData(this.person);
            }
        }

        private void btnApplySkills_Click(object sender, EventArgs e)
        {
            if (this.multiEdit)
            {
                foreach (Person person in this.Persons)
                {
                }
            }
            else
            {
                this.SavePersonSkills(this.person);
            }
        }

        private void btnChangePortrait_Click(object sender, EventArgs e)
        {
            frmSelectPortrait portrait = new frmSelectPortrait();
            portrait.MainForm = this.MainForm;
            portrait.person = this.person;
            portrait.OnlySelectFromNew = this.cbOnlySelectFromTheNew.Checked;
            if (portrait.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.tbPic.Text = this.person.PictureIndex.ToString();
                this.pbHead.Image = this.MainForm.GetPersonPortrait(this.person.PictureIndex);
            }
        }

        private void btnDeleteAllTitle_Click(object sender, EventArgs e)
        {
            this.person.RealTitles.Clear();
            this.RefreshTitleList();
        }

        private void btnDeleteAllStunt_Click(object sender, EventArgs e)
        {
            this.person.Stunts.Clear();
            this.RefreshStuntList();
        }

        private void btnDeleteSelectedStunt_Click(object sender, EventArgs e)
        {
            Stunt selectedItem = this.lbStunt.SelectedItem as Stunt;
            if (selectedItem != null)
            {
                this.person.Stunts.Stunts.Remove(selectedItem.ID);
                this.RefreshStuntList();
            }
        }

        private void btnRemoveClosePerson_Click(object sender, EventArgs e)
        {
            if (this.lbClosePersons.SelectedIndex >= 0)
            {
                this.lbClosePersons.Items.RemoveAt(this.lbClosePersons.SelectedIndex);
            }
        }

        private void btnRemoveHatedPersons_Click(object sender, EventArgs e)
        {
            if (this.lbHatedPersons.SelectedIndex >= 0)
            {
                this.lbHatedPersons.Items.RemoveAt(this.lbHatedPersons.SelectedIndex);
            }
        }

        private void btnSaveTextMessage_Click(object sender, EventArgs e)
        {
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Critical), this.rtbCriticalStrike.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.CriticalArchitecture), this.rtbCriticalStrikeOnArchitecture.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DeepChaos), this.rtbDeepChaos.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DualActiveWin), this.rtbDualInitiativeWin.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DualPassiveWin), this.rtbDualPassiveWin.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ControversyActiveWin), this.rtbControversyInitiativeWin.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ControversyPassiveWin), this.rtbControversyPassiveWin.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.AntiAttack), this.rtbAntiAttack.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.BreakWall), this.rtbBreakWall.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.CastDeepChaos), this.rtbCastDeepChaos.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Chaos), this.rtbChaos.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.HelpedByStratagem), this.rtbHelpedByStratagem.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Angry), this.rtbOutburstAngry.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Calm), this.rtbOutburstQuiet.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.BeCritical), this.rtbReceiveCriticalStrike.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.RecoverChaos), this.rtbRecoverFromChaos.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ResistHarmfulStratagem), this.rtbResistHarmfulStratagem.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ResistHelpfulStratagem), this.rtbResistHelpfulStratagem.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Rout), this.rtbRout.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Surround), this.rtbSurround.Text);
            StaticMethods.LoadFromString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.TrappedByStratagem), this.rtbTrappedByStratagem.Text);
        }

        private void cbFactionColor_DrawItem(object sender, DrawItemEventArgs e)
        {
            Microsoft.Xna.Framework.Graphics.Color color = (Microsoft.Xna.Framework.Graphics.Color) this.cbFactionColor.Items[e.Index];
            e.Graphics.DrawLine(new Pen(System.Drawing.Color.FromArgb((int) color.PackedValue), (float) e.Bounds.Height), e.Bounds.Left, e.Bounds.Top + (e.Bounds.Height / 2), e.Bounds.Right, e.Bounds.Top + (e.Bounds.Height / 2));
        }

        private void cbFactionColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.FactionColor = this.cbFactionColor.SelectedIndex;
            Microsoft.Xna.Framework.Graphics.Color color = this.person.Scenario.GameCommonData.AllColors[this.person.PersonBiography.FactionColor];
            this.cbFactionColor.BackColor = System.Drawing.Color.FromArgb((int) color.PackedValue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void frmEditPerson_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (base.Owner is frmPersonList)
            {
                (base.Owner as frmPersonList).EditPersonTabIndex = this.tabPerson.SelectedIndex;
            }
        }

        private void frmEditPerson_Load(object sender, EventArgs e)
        {
            if ((this.Persons != null) && (this.Persons.Count > 0))
            {
                if (this.Persons.Count == 1)
                {
                    this.person = this.Persons[0] as Person;
                    this.multiEdit = false;
                    this.InitializeTabData();
                }
                else
                {
                    this.person = null;
                    this.multiEdit = true;
                    this.tabPerson.TabPages.Remove(this.tpBasic);
                }
            }
        }

        private void InitializeComponent()
        {
            this.tpSkill = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDeleteAllTitle = new System.Windows.Forms.Button();
            this.btnDeleteSelectedTitle = new System.Windows.Forms.Button();
            this.btnAddTitle = new System.Windows.Forms.Button();
            this.cbAllTitle = new System.Windows.Forms.ComboBox();
            this.lbTitle = new System.Windows.Forms.ListBox();
            this.gbStunt = new System.Windows.Forms.GroupBox();
            this.btnDeleteAllStunt = new System.Windows.Forms.Button();
            this.btnDeleteSelectedStunt = new System.Windows.Forms.Button();
            this.btnAddStunt = new System.Windows.Forms.Button();
            this.cbAllStunt = new System.Windows.Forms.ComboBox();
            this.lbStunt = new System.Windows.Forms.ListBox();
            this.btnApplySkills = new System.Windows.Forms.Button();
            this.gbSkills = new System.Windows.Forms.GroupBox();
            this.label51 = new System.Windows.Forms.Label();
            this.clb08 = new System.Windows.Forms.CheckedListBox();
            this.label50 = new System.Windows.Forms.Label();
            this.clb07 = new System.Windows.Forms.CheckedListBox();
            this.label49 = new System.Windows.Forms.Label();
            this.clb04 = new System.Windows.Forms.CheckedListBox();
            this.label48 = new System.Windows.Forms.Label();
            this.clb05 = new System.Windows.Forms.CheckedListBox();
            this.label47 = new System.Windows.Forms.Label();
            this.clb01 = new System.Windows.Forms.CheckedListBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.clb11 = new System.Windows.Forms.CheckedListBox();
            this.clb10 = new System.Windows.Forms.CheckedListBox();
            this.clb09 = new System.Windows.Forms.CheckedListBox();
            this.clb06 = new System.Windows.Forms.CheckedListBox();
            this.clb03 = new System.Windows.Forms.CheckedListBox();
            this.clb02 = new System.Windows.Forms.CheckedListBox();
            this.clb00 = new System.Windows.Forms.CheckedListBox();
            this.tpBasic = new System.Windows.Forms.TabPage();
            this.label57 = new System.Windows.Forms.Label();
            this.rtbBiographyHistory = new System.Windows.Forms.RichTextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.rtbBiographyRomance = new System.Windows.Forms.RichTextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.cbOnlySelectFromTheNew = new System.Windows.Forms.CheckBox();
            this.btnChangePortrait = new System.Windows.Forms.Button();
            this.pbHead = new System.Windows.Forms.PictureBox();
            this.label55 = new System.Windows.Forms.Label();
            this.cbIdealTendency = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.rtbBiographyBrief = new System.Windows.Forms.RichTextBox();
            this.tbAvailableLocation = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.ssInfo = new System.Windows.Forms.StatusStrip();
            this.tsslIDtoName = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbHatedPersons = new System.Windows.Forms.GroupBox();
            this.btnRemoveHatedPersons = new System.Windows.Forms.Button();
            this.btnAddHatedPersons = new System.Windows.Forms.Button();
            this.lbHatedPersons = new System.Windows.Forms.ListBox();
            this.gbClosePersons = new System.Windows.Forms.GroupBox();
            this.btnRemoveClosePerson = new System.Windows.Forms.Button();
            this.btnAddClosePerson = new System.Windows.Forms.Button();
            this.lbClosePersons = new System.Windows.Forms.ListBox();
            this.cbCharacter = new System.Windows.Forms.ComboBox();
            this.label38 = new System.Windows.Forms.Label();
            this.cbFactionColor = new System.Windows.Forms.ComboBox();
            this.tbOldFactionID = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.cbStrategyTendency = new System.Windows.Forms.ComboBox();
            this.label34 = new System.Windows.Forms.Label();
            this.cbValuationOnGovernment = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.cbQualification = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cbAmbition = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.cbPersonalLoyalty = new System.Windows.Forms.ComboBox();
            this.tbGeneration = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbBrother = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tbSpouse = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.tbMother = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbFather = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbStrain = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.cbBornRegion = new System.Windows.Forms.ComboBox();
            this.tbLoyalty = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tbCalmness = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tbBraveness = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.tbGlamourExperience = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbPoliticsExperience = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbIntelligenceExperience = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbCommandExperience = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbStrengthExperience = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tbGlamour = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbPolitics = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbIntelligence = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbCommand = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbStrength = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbDeadReason = new System.Windows.Forms.ComboBox();
            this.tbDeadYear = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbBornYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbAvailableYear = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbIdeal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPic = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbCalledName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbGivenName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSurName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPerson = new System.Windows.Forms.TabControl();
            this.tpTextMessage = new System.Windows.Forms.TabPage();
            this.label59 = new System.Windows.Forms.Label();
            this.rtbControversyPassiveWin = new System.Windows.Forms.RichTextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.rtbControversyInitiativeWin = new System.Windows.Forms.RichTextBox();
            this.btnSaveTextMessage = new System.Windows.Forms.Button();
            this.label58 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.rtbOutburstQuiet = new System.Windows.Forms.RichTextBox();
            this.label77 = new System.Windows.Forms.Label();
            this.rtbOutburstAngry = new System.Windows.Forms.RichTextBox();
            this.label76 = new System.Windows.Forms.Label();
            this.rtbBreakWall = new System.Windows.Forms.RichTextBox();
            this.label75 = new System.Windows.Forms.Label();
            this.rtbAntiAttack = new System.Windows.Forms.RichTextBox();
            this.label74 = new System.Windows.Forms.Label();
            this.rtbResistHelpfulStratagem = new System.Windows.Forms.RichTextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.rtbResistHarmfulStratagem = new System.Windows.Forms.RichTextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.rtbHelpedByStratagem = new System.Windows.Forms.RichTextBox();
            this.label71 = new System.Windows.Forms.Label();
            this.rtbTrappedByStratagem = new System.Windows.Forms.RichTextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.rtbRecoverFromChaos = new System.Windows.Forms.RichTextBox();
            this.label69 = new System.Windows.Forms.Label();
            this.rtbCastDeepChaos = new System.Windows.Forms.RichTextBox();
            this.label68 = new System.Windows.Forms.Label();
            this.rtbDeepChaos = new System.Windows.Forms.RichTextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.rtbChaos = new System.Windows.Forms.RichTextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.rtbDualPassiveWin = new System.Windows.Forms.RichTextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.rtbDualInitiativeWin = new System.Windows.Forms.RichTextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.rtbRout = new System.Windows.Forms.RichTextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.rtbSurround = new System.Windows.Forms.RichTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.rtbReceiveCriticalStrike = new System.Windows.Forms.RichTextBox();
            this.label61 = new System.Windows.Forms.Label();
            this.rtbCriticalStrikeOnArchitecture = new System.Windows.Forms.RichTextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.rtbCriticalStrike = new System.Windows.Forms.RichTextBox();
            this.tpSkill.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbStunt.SuspendLayout();
            this.gbSkills.SuspendLayout();
            this.tpBasic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHead)).BeginInit();
            this.ssInfo.SuspendLayout();
            this.gbHatedPersons.SuspendLayout();
            this.gbClosePersons.SuspendLayout();
            this.tabPerson.SuspendLayout();
            this.tpTextMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpSkill
            // 
            this.tpSkill.Controls.Add(this.groupBox1);
            this.tpSkill.Controls.Add(this.gbStunt);
            this.tpSkill.Controls.Add(this.btnApplySkills);
            this.tpSkill.Controls.Add(this.gbSkills);
            this.tpSkill.Location = new System.Drawing.Point(4, 22);
            this.tpSkill.Name = "tpSkill";
            this.tpSkill.Padding = new System.Windows.Forms.Padding(3);
            this.tpSkill.Size = new System.Drawing.Size(833, 579);
            this.tpSkill.TabIndex = 1;
            this.tpSkill.Text = "技能";
            this.tpSkill.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnDeleteAllTitle);
            this.groupBox1.Controls.Add(this.btnDeleteSelectedTitle);
            this.groupBox1.Controls.Add(this.btnAddTitle);
            this.groupBox1.Controls.Add(this.cbAllTitle);
            this.groupBox1.Controls.Add(this.lbTitle);
            this.groupBox1.Location = new System.Drawing.Point(625, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 244);
            this.groupBox1.TabIndex = 161;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "称号列表";
            // 
            // btnDeleteAllTitle
            // 
            this.btnDeleteAllTitle.Location = new System.Drawing.Point(103, 207);
            this.btnDeleteAllTitle.Name = "btnDeleteAllTitle";
            this.btnDeleteAllTitle.Size = new System.Drawing.Size(91, 23);
            this.btnDeleteAllTitle.TabIndex = 4;
            this.btnDeleteAllTitle.Text = "删除全部";
            this.btnDeleteAllTitle.UseVisualStyleBackColor = true;
            this.btnDeleteAllTitle.Click += new System.EventHandler(this.btnDeleteAllTitle_Click);
            // 
            // btnDeleteSelectedTitle
            // 
            this.btnDeleteSelectedTitle.Location = new System.Drawing.Point(6, 207);
            this.btnDeleteSelectedTitle.Name = "btnDeleteSelectedTitle";
            this.btnDeleteSelectedTitle.Size = new System.Drawing.Size(91, 23);
            this.btnDeleteSelectedTitle.TabIndex = 3;
            this.btnDeleteSelectedTitle.Text = "删除选中";
            this.btnDeleteSelectedTitle.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedTitle.Click += new System.EventHandler(this.btnDeleteSelectedTitle_Click);
            // 
            // btnAddTitle
            // 
            this.btnAddTitle.Location = new System.Drawing.Point(135, 169);
            this.btnAddTitle.Name = "btnAddTitle";
            this.btnAddTitle.Size = new System.Drawing.Size(55, 23);
            this.btnAddTitle.TabIndex = 2;
            this.btnAddTitle.Text = "添加";
            this.btnAddTitle.UseVisualStyleBackColor = true;
            this.btnAddTitle.Click += new System.EventHandler(this.btnAddTitle_Click);
            // 
            // cbAllTitle
            // 
            this.cbAllTitle.FormattingEnabled = true;
            this.cbAllTitle.Location = new System.Drawing.Point(6, 171);
            this.cbAllTitle.Name = "cbAllTitle";
            this.cbAllTitle.Size = new System.Drawing.Size(121, 20);
            this.cbAllTitle.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.FormattingEnabled = true;
            this.lbTitle.ItemHeight = 12;
            this.lbTitle.Location = new System.Drawing.Point(6, 17);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(184, 148);
            this.lbTitle.TabIndex = 0;
            // 
            // gbStunt
            // 
            this.gbStunt.Controls.Add(this.btnDeleteAllStunt);
            this.gbStunt.Controls.Add(this.btnDeleteSelectedStunt);
            this.gbStunt.Controls.Add(this.btnAddStunt);
            this.gbStunt.Controls.Add(this.cbAllStunt);
            this.gbStunt.Controls.Add(this.lbStunt);
            this.gbStunt.Location = new System.Drawing.Point(620, 268);
            this.gbStunt.Name = "gbStunt";
            this.gbStunt.Size = new System.Drawing.Size(200, 244);
            this.gbStunt.TabIndex = 160;
            this.gbStunt.TabStop = false;
            this.gbStunt.Text = "战斗特技列表";
            // 
            // btnDeleteAllStunt
            // 
            this.btnDeleteAllStunt.Location = new System.Drawing.Point(103, 207);
            this.btnDeleteAllStunt.Name = "btnDeleteAllStunt";
            this.btnDeleteAllStunt.Size = new System.Drawing.Size(91, 23);
            this.btnDeleteAllStunt.TabIndex = 4;
            this.btnDeleteAllStunt.Text = "删除全部";
            this.btnDeleteAllStunt.UseVisualStyleBackColor = true;
            this.btnDeleteAllStunt.Click += new System.EventHandler(this.btnDeleteAllStunt_Click);
            // 
            // btnDeleteSelectedStunt
            // 
            this.btnDeleteSelectedStunt.Location = new System.Drawing.Point(6, 207);
            this.btnDeleteSelectedStunt.Name = "btnDeleteSelectedStunt";
            this.btnDeleteSelectedStunt.Size = new System.Drawing.Size(91, 23);
            this.btnDeleteSelectedStunt.TabIndex = 3;
            this.btnDeleteSelectedStunt.Text = "删除选中";
            this.btnDeleteSelectedStunt.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedStunt.Click += new System.EventHandler(this.btnDeleteSelectedStunt_Click);
            // 
            // btnAddStunt
            // 
            this.btnAddStunt.Location = new System.Drawing.Point(135, 169);
            this.btnAddStunt.Name = "btnAddStunt";
            this.btnAddStunt.Size = new System.Drawing.Size(55, 23);
            this.btnAddStunt.TabIndex = 2;
            this.btnAddStunt.Text = "添加";
            this.btnAddStunt.UseVisualStyleBackColor = true;
            this.btnAddStunt.Click += new System.EventHandler(this.btnAddStunt_Click);
            // 
            // cbAllStunt
            // 
            this.cbAllStunt.FormattingEnabled = true;
            this.cbAllStunt.Location = new System.Drawing.Point(6, 171);
            this.cbAllStunt.Name = "cbAllStunt";
            this.cbAllStunt.Size = new System.Drawing.Size(121, 20);
            this.cbAllStunt.TabIndex = 1;
            // 
            // lbStunt
            // 
            this.lbStunt.FormattingEnabled = true;
            this.lbStunt.ItemHeight = 12;
            this.lbStunt.Location = new System.Drawing.Point(6, 17);
            this.lbStunt.Name = "lbStunt";
            this.lbStunt.Size = new System.Drawing.Size(184, 148);
            this.lbStunt.TabIndex = 0;
            // 
            // btnApplySkills
            // 
            this.btnApplySkills.Location = new System.Drawing.Point(735, 531);
            this.btnApplySkills.Name = "btnApplySkills";
            this.btnApplySkills.Size = new System.Drawing.Size(75, 23);
            this.btnApplySkills.TabIndex = 153;
            this.btnApplySkills.Text = "应用修改";
            this.btnApplySkills.UseVisualStyleBackColor = true;
            this.btnApplySkills.Click += new System.EventHandler(this.btnApplySkills_Click);
            // 
            // gbSkills
            // 
            this.gbSkills.Controls.Add(this.label51);
            this.gbSkills.Controls.Add(this.clb08);
            this.gbSkills.Controls.Add(this.label50);
            this.gbSkills.Controls.Add(this.clb07);
            this.gbSkills.Controls.Add(this.label49);
            this.gbSkills.Controls.Add(this.clb04);
            this.gbSkills.Controls.Add(this.label48);
            this.gbSkills.Controls.Add(this.clb05);
            this.gbSkills.Controls.Add(this.label47);
            this.gbSkills.Controls.Add(this.clb01);
            this.gbSkills.Controls.Add(this.label44);
            this.gbSkills.Controls.Add(this.label43);
            this.gbSkills.Controls.Add(this.label42);
            this.gbSkills.Controls.Add(this.label41);
            this.gbSkills.Controls.Add(this.label40);
            this.gbSkills.Controls.Add(this.label39);
            this.gbSkills.Controls.Add(this.clb11);
            this.gbSkills.Controls.Add(this.clb10);
            this.gbSkills.Controls.Add(this.clb09);
            this.gbSkills.Controls.Add(this.clb06);
            this.gbSkills.Controls.Add(this.clb03);
            this.gbSkills.Controls.Add(this.clb02);
            this.gbSkills.Controls.Add(this.clb00);
            this.gbSkills.Location = new System.Drawing.Point(22, 18);
            this.gbSkills.Name = "gbSkills";
            this.gbSkills.Size = new System.Drawing.Size(592, 431);
            this.gbSkills.TabIndex = 6;
            this.gbSkills.TabStop = false;
            this.gbSkills.Text = "技能列表";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(24, 240);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(29, 12);
            this.label51.TabIndex = 30;
            this.label51.Text = "领兵";
            // 
            // clb08
            // 
            this.clb08.CheckOnClick = true;
            this.clb08.ColumnWidth = 70;
            this.clb08.FormattingEnabled = true;
            this.clb08.IntegralHeight = false;
            this.clb08.Items.AddRange(new object[] {
            "练步",
            "练弩",
            "练骑",
            "练水",
            "练器",
            "保护",
            "爱卒"});
            this.clb08.Location = new System.Drawing.Point(68, 236);
            this.clb08.MultiColumn = true;
            this.clb08.Name = "clb08";
            this.clb08.Size = new System.Drawing.Size(509, 24);
            this.clb08.TabIndex = 29;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(24, 214);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(29, 12);
            this.label50.TabIndex = 28;
            this.label50.Text = "器械";
            // 
            // clb07
            // 
            this.clb07.CheckOnClick = true;
            this.clb07.ColumnWidth = 70;
            this.clb07.FormattingEnabled = true;
            this.clb07.IntegralHeight = false;
            this.clb07.Items.AddRange(new object[] {
            "冲车",
            "井栏",
            "投石",
            "粉碎",
            "箭岚",
            "巨石",
            "坚固"});
            this.clb07.Location = new System.Drawing.Point(68, 210);
            this.clb07.MultiColumn = true;
            this.clb07.Name = "clb07";
            this.clb07.Size = new System.Drawing.Size(509, 24);
            this.clb07.TabIndex = 27;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(24, 136);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(29, 12);
            this.label49.TabIndex = 26;
            this.label49.Text = "弩兵";
            // 
            // clb04
            // 
            this.clb04.CheckOnClick = true;
            this.clb04.ColumnWidth = 70;
            this.clb04.FormattingEnabled = true;
            this.clb04.IntegralHeight = false;
            this.clb04.Items.AddRange(new object[] {
            "火矢",
            "贯穿",
            "散射",
            "致命",
            "善攻",
            "善守",
            "燎原"});
            this.clb04.Location = new System.Drawing.Point(68, 132);
            this.clb04.MultiColumn = true;
            this.clb04.Name = "clb04";
            this.clb04.Size = new System.Drawing.Size(509, 24);
            this.clb04.TabIndex = 25;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(24, 162);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(29, 12);
            this.label48.TabIndex = 24;
            this.label48.Text = "骑兵";
            // 
            // clb05
            // 
            this.clb05.CheckOnClick = true;
            this.clb05.ColumnWidth = 70;
            this.clb05.FormattingEnabled = true;
            this.clb05.IntegralHeight = false;
            this.clb05.Items.AddRange(new object[] {
            "进击",
            "冲击",
            "突击",
            "纵横",
            "善攻",
            "善守",
            "雷霆"});
            this.clb05.Location = new System.Drawing.Point(68, 158);
            this.clb05.MultiColumn = true;
            this.clb05.Name = "clb05";
            this.clb05.Size = new System.Drawing.Size(509, 24);
            this.clb05.TabIndex = 23;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(24, 56);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(35, 12);
            this.label47.TabIndex = 22;
            this.label47.Text = "内政2";
            // 
            // clb01
            // 
            this.clb01.CheckOnClick = true;
            this.clb01.ColumnWidth = 70;
            this.clb01.FormattingEnabled = true;
            this.clb01.IntegralHeight = false;
            this.clb01.Items.AddRange(new object[] {
            "开垦",
            "商才",
            "发明",
            "威严",
            "仁德",
            "筑城",
            "补充"});
            this.clb01.Location = new System.Drawing.Point(68, 52);
            this.clb01.MultiColumn = true;
            this.clb01.Name = "clb01";
            this.clb01.Size = new System.Drawing.Size(509, 24);
            this.clb01.TabIndex = 21;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(24, 291);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(29, 12);
            this.label44.TabIndex = 18;
            this.label44.Text = "策略";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(24, 266);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(29, 12);
            this.label43.TabIndex = 17;
            this.label43.Text = "计略";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(24, 188);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(29, 12);
            this.label42.TabIndex = 16;
            this.label42.Text = "水军";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(24, 110);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(29, 12);
            this.label41.TabIndex = 15;
            this.label41.Text = "步兵";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(24, 84);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(29, 12);
            this.label40.TabIndex = 14;
            this.label40.Text = "行军";
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(24, 30);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(35, 12);
            this.label39.TabIndex = 13;
            this.label39.Text = "内政1";
            // 
            // clb11
            // 
            this.clb11.CheckOnClick = true;
            this.clb11.ColumnWidth = 70;
            this.clb11.FormattingEnabled = true;
            this.clb11.IntegralHeight = false;
            this.clb11.Items.AddRange(new object[] {
            "医治"});
            this.clb11.Location = new System.Drawing.Point(68, 314);
            this.clb11.MultiColumn = true;
            this.clb11.Name = "clb11";
            this.clb11.Size = new System.Drawing.Size(509, 24);
            this.clb11.TabIndex = 12;
            // 
            // clb10
            // 
            this.clb10.CheckOnClick = true;
            this.clb10.ColumnWidth = 70;
            this.clb10.FormattingEnabled = true;
            this.clb10.IntegralHeight = false;
            this.clb10.Items.AddRange(new object[] {
            "情报",
            "间谍",
            "破坏",
            "煽动",
            "流言",
            "搜索",
            "说服"});
            this.clb10.Location = new System.Drawing.Point(68, 288);
            this.clb10.MultiColumn = true;
            this.clb10.Name = "clb10";
            this.clb10.Size = new System.Drawing.Size(509, 24);
            this.clb10.TabIndex = 11;
            // 
            // clb09
            // 
            this.clb09.CheckOnClick = true;
            this.clb09.ColumnWidth = 70;
            this.clb09.FormattingEnabled = true;
            this.clb09.IntegralHeight = false;
            this.clb09.Items.AddRange(new object[] {
            "攻心",
            "扰乱",
            "侦查",
            "埋伏",
            "火攻",
            "防火",
            "鼓舞"});
            this.clb09.Location = new System.Drawing.Point(68, 262);
            this.clb09.MultiColumn = true;
            this.clb09.Name = "clb09";
            this.clb09.Size = new System.Drawing.Size(509, 24);
            this.clb09.TabIndex = 10;
            // 
            // clb06
            // 
            this.clb06.CheckOnClick = true;
            this.clb06.ColumnWidth = 70;
            this.clb06.FormattingEnabled = true;
            this.clb06.IntegralHeight = false;
            this.clb06.Items.AddRange(new object[] {
            "涉水",
            "穿梭",
            "箭雨",
            "猛撞",
            "善攻",
            "善守",
            "水战"});
            this.clb06.Location = new System.Drawing.Point(68, 184);
            this.clb06.MultiColumn = true;
            this.clb06.Name = "clb06";
            this.clb06.Size = new System.Drawing.Size(509, 24);
            this.clb06.TabIndex = 9;
            // 
            // clb03
            // 
            this.clb03.CheckOnClick = true;
            this.clb03.ColumnWidth = 70;
            this.clb03.FormattingEnabled = true;
            this.clb03.IntegralHeight = false;
            this.clb03.Items.AddRange(new object[] {
            "大盾",
            "枪阵",
            "旋风",
            "坚阵",
            "善攻",
            "善守",
            "破甲"});
            this.clb03.Location = new System.Drawing.Point(68, 106);
            this.clb03.MultiColumn = true;
            this.clb03.Name = "clb03";
            this.clb03.Size = new System.Drawing.Size(509, 24);
            this.clb03.TabIndex = 8;
            // 
            // clb02
            // 
            this.clb02.CheckOnClick = true;
            this.clb02.ColumnWidth = 70;
            this.clb02.FormattingEnabled = true;
            this.clb02.IntegralHeight = false;
            this.clb02.Items.AddRange(new object[] {
            "驰骋",
            "穿林",
            "翻山",
            "操舵",
            "强行",
            "推进",
            "负载"});
            this.clb02.Location = new System.Drawing.Point(68, 80);
            this.clb02.MultiColumn = true;
            this.clb02.Name = "clb02";
            this.clb02.Size = new System.Drawing.Size(509, 24);
            this.clb02.TabIndex = 7;
            // 
            // clb00
            // 
            this.clb00.CheckOnClick = true;
            this.clb00.ColumnWidth = 70;
            this.clb00.FormattingEnabled = true;
            this.clb00.IntegralHeight = false;
            this.clb00.Items.AddRange(new object[] {
            "农业",
            "商业",
            "技术",
            "统治",
            "民心",
            "耐久",
            "训练"});
            this.clb00.Location = new System.Drawing.Point(68, 26);
            this.clb00.MultiColumn = true;
            this.clb00.Name = "clb00";
            this.clb00.Size = new System.Drawing.Size(509, 24);
            this.clb00.TabIndex = 6;
            // 
            // tpBasic
            // 
            this.tpBasic.Controls.Add(this.label57);
            this.tpBasic.Controls.Add(this.rtbBiographyHistory);
            this.tpBasic.Controls.Add(this.label56);
            this.tpBasic.Controls.Add(this.rtbBiographyRomance);
            this.tpBasic.Controls.Add(this.label46);
            this.tpBasic.Controls.Add(this.cbOnlySelectFromTheNew);
            this.tpBasic.Controls.Add(this.btnChangePortrait);
            this.tpBasic.Controls.Add(this.pbHead);
            this.tpBasic.Controls.Add(this.label55);
            this.tpBasic.Controls.Add(this.cbIdealTendency);
            this.tpBasic.Controls.Add(this.label54);
            this.tpBasic.Controls.Add(this.rtbBiographyBrief);
            this.tpBasic.Controls.Add(this.tbAvailableLocation);
            this.tpBasic.Controls.Add(this.label45);
            this.tpBasic.Controls.Add(this.ssInfo);
            this.tpBasic.Controls.Add(this.btnApply);
            this.tpBasic.Controls.Add(this.gbHatedPersons);
            this.tpBasic.Controls.Add(this.gbClosePersons);
            this.tpBasic.Controls.Add(this.cbCharacter);
            this.tpBasic.Controls.Add(this.label38);
            this.tpBasic.Controls.Add(this.cbFactionColor);
            this.tpBasic.Controls.Add(this.tbOldFactionID);
            this.tpBasic.Controls.Add(this.label37);
            this.tpBasic.Controls.Add(this.label35);
            this.tpBasic.Controls.Add(this.cbStrategyTendency);
            this.tpBasic.Controls.Add(this.label34);
            this.tpBasic.Controls.Add(this.cbValuationOnGovernment);
            this.tpBasic.Controls.Add(this.label33);
            this.tpBasic.Controls.Add(this.cbQualification);
            this.tpBasic.Controls.Add(this.label32);
            this.tpBasic.Controls.Add(this.cbAmbition);
            this.tpBasic.Controls.Add(this.label31);
            this.tpBasic.Controls.Add(this.cbPersonalLoyalty);
            this.tpBasic.Controls.Add(this.tbGeneration);
            this.tpBasic.Controls.Add(this.label30);
            this.tpBasic.Controls.Add(this.tbBrother);
            this.tpBasic.Controls.Add(this.label25);
            this.tpBasic.Controls.Add(this.tbSpouse);
            this.tpBasic.Controls.Add(this.label26);
            this.tpBasic.Controls.Add(this.tbMother);
            this.tpBasic.Controls.Add(this.label27);
            this.tpBasic.Controls.Add(this.tbFather);
            this.tpBasic.Controls.Add(this.label28);
            this.tpBasic.Controls.Add(this.tbStrain);
            this.tpBasic.Controls.Add(this.label29);
            this.tpBasic.Controls.Add(this.label24);
            this.tpBasic.Controls.Add(this.cbBornRegion);
            this.tpBasic.Controls.Add(this.tbLoyalty);
            this.tpBasic.Controls.Add(this.label23);
            this.tpBasic.Controls.Add(this.tbCalmness);
            this.tpBasic.Controls.Add(this.label22);
            this.tpBasic.Controls.Add(this.tbBraveness);
            this.tpBasic.Controls.Add(this.label21);
            this.tpBasic.Controls.Add(this.tbGlamourExperience);
            this.tpBasic.Controls.Add(this.label16);
            this.tpBasic.Controls.Add(this.tbPoliticsExperience);
            this.tpBasic.Controls.Add(this.label17);
            this.tpBasic.Controls.Add(this.tbIntelligenceExperience);
            this.tpBasic.Controls.Add(this.label18);
            this.tpBasic.Controls.Add(this.tbCommandExperience);
            this.tpBasic.Controls.Add(this.label19);
            this.tpBasic.Controls.Add(this.tbStrengthExperience);
            this.tpBasic.Controls.Add(this.label20);
            this.tpBasic.Controls.Add(this.tbGlamour);
            this.tpBasic.Controls.Add(this.label15);
            this.tpBasic.Controls.Add(this.tbPolitics);
            this.tpBasic.Controls.Add(this.label14);
            this.tpBasic.Controls.Add(this.tbIntelligence);
            this.tpBasic.Controls.Add(this.label13);
            this.tpBasic.Controls.Add(this.tbCommand);
            this.tpBasic.Controls.Add(this.label12);
            this.tpBasic.Controls.Add(this.tbStrength);
            this.tpBasic.Controls.Add(this.label11);
            this.tpBasic.Controls.Add(this.label10);
            this.tpBasic.Controls.Add(this.cbDeadReason);
            this.tpBasic.Controls.Add(this.tbDeadYear);
            this.tpBasic.Controls.Add(this.label7);
            this.tpBasic.Controls.Add(this.tbBornYear);
            this.tpBasic.Controls.Add(this.label8);
            this.tpBasic.Controls.Add(this.tbAvailableYear);
            this.tpBasic.Controls.Add(this.label9);
            this.tpBasic.Controls.Add(this.label6);
            this.tpBasic.Controls.Add(this.tbIdeal);
            this.tpBasic.Controls.Add(this.label5);
            this.tpBasic.Controls.Add(this.tbPic);
            this.tpBasic.Controls.Add(this.label4);
            this.tpBasic.Controls.Add(this.tbCalledName);
            this.tpBasic.Controls.Add(this.label3);
            this.tpBasic.Controls.Add(this.tbGivenName);
            this.tpBasic.Controls.Add(this.label2);
            this.tpBasic.Controls.Add(this.tbSurName);
            this.tpBasic.Controls.Add(this.label1);
            this.tpBasic.Location = new System.Drawing.Point(4, 22);
            this.tpBasic.Name = "tpBasic";
            this.tpBasic.Padding = new System.Windows.Forms.Padding(3);
            this.tpBasic.Size = new System.Drawing.Size(833, 579);
            this.tpBasic.TabIndex = 0;
            this.tpBasic.Text = "基本";
            this.tpBasic.UseVisualStyleBackColor = true;
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(272, 469);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(29, 12);
            this.label57.TabIndex = 167;
            this.label57.Text = "历史";
            // 
            // rtbBiographyHistory
            // 
            this.rtbBiographyHistory.BackColor = System.Drawing.SystemColors.Window;
            this.rtbBiographyHistory.Location = new System.Drawing.Point(319, 445);
            this.rtbBiographyHistory.Name = "rtbBiographyHistory";
            this.rtbBiographyHistory.Size = new System.Drawing.Size(488, 63);
            this.rtbBiographyHistory.TabIndex = 166;
            this.rtbBiographyHistory.Text = "";
            this.rtbBiographyHistory.TextChanged += new System.EventHandler(this.rtbBiographyHistory_TextChanged);
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(272, 402);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(29, 12);
            this.label56.TabIndex = 165;
            this.label56.Text = "演义";
            // 
            // rtbBiographyRomance
            // 
            this.rtbBiographyRomance.BackColor = System.Drawing.SystemColors.Window;
            this.rtbBiographyRomance.Location = new System.Drawing.Point(319, 377);
            this.rtbBiographyRomance.Name = "rtbBiographyRomance";
            this.rtbBiographyRomance.Size = new System.Drawing.Size(488, 62);
            this.rtbBiographyRomance.TabIndex = 164;
            this.rtbBiographyRomance.Text = "";
            this.rtbBiographyRomance.TextChanged += new System.EventHandler(this.rtbBiographyRomance_TextChanged);
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(272, 326);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(29, 12);
            this.label46.TabIndex = 163;
            this.label46.Text = "简介";
            // 
            // cbOnlySelectFromTheNew
            // 
            this.cbOnlySelectFromTheNew.AutoSize = true;
            this.cbOnlySelectFromTheNew.Checked = true;
            this.cbOnlySelectFromTheNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOnlySelectFromTheNew.Location = new System.Drawing.Point(685, 200);
            this.cbOnlySelectFromTheNew.Name = "cbOnlySelectFromTheNew";
            this.cbOnlySelectFromTheNew.Size = new System.Drawing.Size(144, 16);
            this.cbOnlySelectFromTheNew.TabIndex = 162;
            this.cbOnlySelectFromTheNew.Text = "只从新武将头像中选择";
            this.cbOnlySelectFromTheNew.UseVisualStyleBackColor = true;
            // 
            // btnChangePortrait
            // 
            this.btnChangePortrait.Location = new System.Drawing.Point(752, 171);
            this.btnChangePortrait.Name = "btnChangePortrait";
            this.btnChangePortrait.Size = new System.Drawing.Size(75, 23);
            this.btnChangePortrait.TabIndex = 161;
            this.btnChangePortrait.Text = "更换头像";
            this.btnChangePortrait.UseVisualStyleBackColor = true;
            this.btnChangePortrait.Click += new System.EventHandler(this.btnChangePortrait_Click);
            // 
            // pbHead
            // 
            this.pbHead.ErrorImage = null;
            this.pbHead.InitialImage = null;
            this.pbHead.Location = new System.Drawing.Point(690, 3);
            this.pbHead.Name = "pbHead";
            this.pbHead.Size = new System.Drawing.Size(137, 162);
            this.pbHead.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHead.TabIndex = 160;
            this.pbHead.TabStop = false;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(509, 13);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(53, 12);
            this.label55.TabIndex = 158;
            this.label55.Text = "仕官倾向";
            // 
            // cbIdealTendency
            // 
            this.cbIdealTendency.FormattingEnabled = true;
            this.cbIdealTendency.Location = new System.Drawing.Point(569, 10);
            this.cbIdealTendency.Name = "cbIdealTendency";
            this.cbIdealTendency.Size = new System.Drawing.Size(101, 20);
            this.cbIdealTendency.TabIndex = 159;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(269, 295);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(41, 12);
            this.label54.TabIndex = 157;
            this.label54.Text = "列传：";
            // 
            // rtbBiographyBrief
            // 
            this.rtbBiographyBrief.BackColor = System.Drawing.SystemColors.Window;
            this.rtbBiographyBrief.Location = new System.Drawing.Point(319, 310);
            this.rtbBiographyBrief.Name = "rtbBiographyBrief";
            this.rtbBiographyBrief.Size = new System.Drawing.Size(488, 61);
            this.rtbBiographyBrief.TabIndex = 156;
            this.rtbBiographyBrief.Text = "";
            this.rtbBiographyBrief.TextChanged += new System.EventHandler(this.rtbBiographyBrief_TextChanged);
            // 
            // tbAvailableLocation
            // 
            this.tbAvailableLocation.Location = new System.Drawing.Point(194, 262);
            this.tbAvailableLocation.MaxLength = 4;
            this.tbAvailableLocation.Name = "tbAvailableLocation";
            this.tbAvailableLocation.Size = new System.Drawing.Size(59, 22);
            this.tbAvailableLocation.TabIndex = 155;
            this.tbAvailableLocation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(135, 265);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(53, 12);
            this.label45.TabIndex = 154;
            this.label45.Text = "登场地点";
            // 
            // ssInfo
            // 
            this.ssInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslIDtoName});
            this.ssInfo.Location = new System.Drawing.Point(3, 554);
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.Size = new System.Drawing.Size(827, 22);
            this.ssInfo.TabIndex = 153;
            this.ssInfo.Text = "信息";
            // 
            // tsslIDtoName
            // 
            this.tsslIDtoName.Name = "tsslIDtoName";
            this.tsslIDtoName.Size = new System.Drawing.Size(0, 17);
            this.tsslIDtoName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(732, 514);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 152;
            this.btnApply.Text = "应用修改";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gbHatedPersons
            // 
            this.gbHatedPersons.Controls.Add(this.btnRemoveHatedPersons);
            this.gbHatedPersons.Controls.Add(this.btnAddHatedPersons);
            this.gbHatedPersons.Controls.Add(this.lbHatedPersons);
            this.gbHatedPersons.Location = new System.Drawing.Point(133, 301);
            this.gbHatedPersons.Name = "gbHatedPersons";
            this.gbHatedPersons.Size = new System.Drawing.Size(112, 225);
            this.gbHatedPersons.TabIndex = 151;
            this.gbHatedPersons.TabStop = false;
            this.gbHatedPersons.Text = "厌恶人物列表";
            // 
            // btnRemoveHatedPersons
            // 
            this.btnRemoveHatedPersons.Location = new System.Drawing.Point(63, 20);
            this.btnRemoveHatedPersons.Name = "btnRemoveHatedPersons";
            this.btnRemoveHatedPersons.Size = new System.Drawing.Size(41, 23);
            this.btnRemoveHatedPersons.TabIndex = 74;
            this.btnRemoveHatedPersons.Text = "删除";
            this.btnRemoveHatedPersons.UseVisualStyleBackColor = true;
            this.btnRemoveHatedPersons.Click += new System.EventHandler(this.btnRemoveHatedPersons_Click);
            // 
            // btnAddHatedPersons
            // 
            this.btnAddHatedPersons.Location = new System.Drawing.Point(7, 20);
            this.btnAddHatedPersons.Name = "btnAddHatedPersons";
            this.btnAddHatedPersons.Size = new System.Drawing.Size(41, 23);
            this.btnAddHatedPersons.TabIndex = 73;
            this.btnAddHatedPersons.Text = "添加";
            this.btnAddHatedPersons.UseVisualStyleBackColor = true;
            this.btnAddHatedPersons.Click += new System.EventHandler(this.btnAddHatedPersons_Click);
            // 
            // lbHatedPersons
            // 
            this.lbHatedPersons.FormattingEnabled = true;
            this.lbHatedPersons.ItemHeight = 12;
            this.lbHatedPersons.Location = new System.Drawing.Point(8, 49);
            this.lbHatedPersons.Name = "lbHatedPersons";
            this.lbHatedPersons.Size = new System.Drawing.Size(97, 160);
            this.lbHatedPersons.TabIndex = 72;
            // 
            // gbClosePersons
            // 
            this.gbClosePersons.Controls.Add(this.btnRemoveClosePerson);
            this.gbClosePersons.Controls.Add(this.btnAddClosePerson);
            this.gbClosePersons.Controls.Add(this.lbClosePersons);
            this.gbClosePersons.Location = new System.Drawing.Point(13, 301);
            this.gbClosePersons.Name = "gbClosePersons";
            this.gbClosePersons.Size = new System.Drawing.Size(112, 225);
            this.gbClosePersons.TabIndex = 150;
            this.gbClosePersons.TabStop = false;
            this.gbClosePersons.Text = "亲近人物列表";
            // 
            // btnRemoveClosePerson
            // 
            this.btnRemoveClosePerson.Location = new System.Drawing.Point(63, 20);
            this.btnRemoveClosePerson.Name = "btnRemoveClosePerson";
            this.btnRemoveClosePerson.Size = new System.Drawing.Size(41, 23);
            this.btnRemoveClosePerson.TabIndex = 74;
            this.btnRemoveClosePerson.Text = "删除";
            this.btnRemoveClosePerson.UseVisualStyleBackColor = true;
            this.btnRemoveClosePerson.Click += new System.EventHandler(this.btnRemoveClosePerson_Click);
            // 
            // btnAddClosePerson
            // 
            this.btnAddClosePerson.Location = new System.Drawing.Point(7, 20);
            this.btnAddClosePerson.Name = "btnAddClosePerson";
            this.btnAddClosePerson.Size = new System.Drawing.Size(41, 23);
            this.btnAddClosePerson.TabIndex = 73;
            this.btnAddClosePerson.Text = "添加";
            this.btnAddClosePerson.UseVisualStyleBackColor = true;
            this.btnAddClosePerson.Click += new System.EventHandler(this.btnAddClosePerson_Click);
            // 
            // lbClosePersons
            // 
            this.lbClosePersons.FormattingEnabled = true;
            this.lbClosePersons.ItemHeight = 12;
            this.lbClosePersons.Location = new System.Drawing.Point(7, 49);
            this.lbClosePersons.Name = "lbClosePersons";
            this.lbClosePersons.Size = new System.Drawing.Size(97, 160);
            this.lbClosePersons.TabIndex = 72;
            // 
            // cbCharacter
            // 
            this.cbCharacter.FormattingEnabled = true;
            this.cbCharacter.Items.AddRange(new object[] {
            "未定义",
            "鲁莽",
            "小心",
            "高傲",
            "坚韧",
            "稳健",
            "冷静"});
            this.cbCharacter.Location = new System.Drawing.Point(433, 150);
            this.cbCharacter.Name = "cbCharacter";
            this.cbCharacter.Size = new System.Drawing.Size(82, 20);
            this.cbCharacter.TabIndex = 122;
            this.cbCharacter.Text = "未定义";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(529, 153);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(53, 12);
            this.label38.TabIndex = 79;
            this.label38.Text = "势力颜色";
            // 
            // cbFactionColor
            // 
            this.cbFactionColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFactionColor.FormattingEnabled = true;
            this.cbFactionColor.Location = new System.Drawing.Point(588, 150);
            this.cbFactionColor.Name = "cbFactionColor";
            this.cbFactionColor.Size = new System.Drawing.Size(82, 23);
            this.cbFactionColor.TabIndex = 123;
            this.cbFactionColor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cbFactionColor_DrawItem);
            this.cbFactionColor.SelectedIndexChanged += new System.EventHandler(this.cbFactionColor_SelectedIndexChanged);
            // 
            // tbOldFactionID
            // 
            this.tbOldFactionID.Location = new System.Drawing.Point(66, 262);
            this.tbOldFactionID.MaxLength = 4;
            this.tbOldFactionID.Name = "tbOldFactionID";
            this.tbOldFactionID.Size = new System.Drawing.Size(59, 22);
            this.tbOldFactionID.TabIndex = 148;
            this.tbOldFactionID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbOldFactionID.MouseHover += new System.EventHandler(this.tbOldFactionID_MouseHover);
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(11, 265);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(53, 12);
            this.label37.TabIndex = 147;
            this.label37.Text = "仕官势力";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(496, 228);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(53, 12);
            this.label35.TabIndex = 144;
            this.label35.Text = "战略倾向";
            // 
            // cbStrategyTendency
            // 
            this.cbStrategyTendency.FormattingEnabled = true;
            this.cbStrategyTendency.Items.AddRange(new object[] {
            "统一全国",
            "统一地区",
            "统一州",
            "维持现状"});
            this.cbStrategyTendency.Location = new System.Drawing.Point(559, 225);
            this.cbStrategyTendency.Name = "cbStrategyTendency";
            this.cbStrategyTendency.Size = new System.Drawing.Size(82, 20);
            this.cbStrategyTendency.TabIndex = 145;
            this.cbStrategyTendency.Text = "统一全国";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(374, 228);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(29, 12);
            this.label34.TabIndex = 142;
            this.label34.Text = "汉室";
            // 
            // cbValuationOnGovernment
            // 
            this.cbValuationOnGovernment.FormattingEnabled = true;
            this.cbValuationOnGovernment.Items.AddRange(new object[] {
            "无视",
            "普通",
            "重视"});
            this.cbValuationOnGovernment.Location = new System.Drawing.Point(414, 225);
            this.cbValuationOnGovernment.Name = "cbValuationOnGovernment";
            this.cbValuationOnGovernment.Size = new System.Drawing.Size(57, 20);
            this.cbValuationOnGovernment.TabIndex = 143;
            this.cbValuationOnGovernment.Text = "普通";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(247, 228);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(29, 12);
            this.label33.TabIndex = 140;
            this.label33.Text = "起用";
            // 
            // cbQualification
            // 
            this.cbQualification.FormattingEnabled = true;
            this.cbQualification.Items.AddRange(new object[] {
            "任意",
            "能力",
            "功绩",
            "名声",
            "义理"});
            this.cbQualification.Location = new System.Drawing.Point(287, 225);
            this.cbQualification.Name = "cbQualification";
            this.cbQualification.Size = new System.Drawing.Size(66, 20);
            this.cbQualification.TabIndex = 141;
            this.cbQualification.Text = "任意";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(125, 228);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(29, 12);
            this.label32.TabIndex = 138;
            this.label32.Text = "野心";
            // 
            // cbAmbition
            // 
            this.cbAmbition.FormattingEnabled = true;
            this.cbAmbition.Items.AddRange(new object[] {
            "很低",
            "低",
            "普通",
            "高",
            "很高"});
            this.cbAmbition.Location = new System.Drawing.Point(165, 225);
            this.cbAmbition.Name = "cbAmbition";
            this.cbAmbition.Size = new System.Drawing.Size(59, 20);
            this.cbAmbition.TabIndex = 139;
            this.cbAmbition.Text = "普通";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(9, 228);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(29, 12);
            this.label31.TabIndex = 136;
            this.label31.Text = "义理";
            // 
            // cbPersonalLoyalty
            // 
            this.cbPersonalLoyalty.FormattingEnabled = true;
            this.cbPersonalLoyalty.Items.AddRange(new object[] {
            "很低",
            "低",
            "普通",
            "高",
            "很高"});
            this.cbPersonalLoyalty.Location = new System.Drawing.Point(49, 225);
            this.cbPersonalLoyalty.Name = "cbPersonalLoyalty";
            this.cbPersonalLoyalty.Size = new System.Drawing.Size(59, 20);
            this.cbPersonalLoyalty.TabIndex = 137;
            this.cbPersonalLoyalty.Text = "普通";
            // 
            // tbGeneration
            // 
            this.tbGeneration.Location = new System.Drawing.Point(611, 187);
            this.tbGeneration.MaxLength = 2;
            this.tbGeneration.Name = "tbGeneration";
            this.tbGeneration.Size = new System.Drawing.Size(59, 22);
            this.tbGeneration.TabIndex = 135;
            this.tbGeneration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(571, 190);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(29, 12);
            this.label30.TabIndex = 134;
            this.label30.Text = "世代";
            // 
            // tbBrother
            // 
            this.tbBrother.Location = new System.Drawing.Point(498, 187);
            this.tbBrother.MaxLength = 4;
            this.tbBrother.Name = "tbBrother";
            this.tbBrother.Size = new System.Drawing.Size(59, 22);
            this.tbBrother.TabIndex = 133;
            this.tbBrother.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBrother.MouseHover += new System.EventHandler(this.tbBrother_MouseHover);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(458, 190);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 12);
            this.label25.TabIndex = 132;
            this.label25.Text = "义兄";
            // 
            // tbSpouse
            // 
            this.tbSpouse.Location = new System.Drawing.Point(380, 187);
            this.tbSpouse.MaxLength = 4;
            this.tbSpouse.Name = "tbSpouse";
            this.tbSpouse.Size = new System.Drawing.Size(59, 22);
            this.tbSpouse.TabIndex = 131;
            this.tbSpouse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbSpouse.MouseHover += new System.EventHandler(this.tbSpouse_MouseHover);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(340, 190);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(29, 12);
            this.label26.TabIndex = 130;
            this.label26.Text = "配偶";
            // 
            // tbMother
            // 
            this.tbMother.Location = new System.Drawing.Point(264, 187);
            this.tbMother.MaxLength = 4;
            this.tbMother.Name = "tbMother";
            this.tbMother.Size = new System.Drawing.Size(59, 22);
            this.tbMother.TabIndex = 129;
            this.tbMother.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbMother.MouseHover += new System.EventHandler(this.tbMother_MouseHover);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(224, 190);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(29, 12);
            this.label27.TabIndex = 128;
            this.label27.Text = "母亲";
            // 
            // tbFather
            // 
            this.tbFather.Location = new System.Drawing.Point(156, 187);
            this.tbFather.MaxLength = 4;
            this.tbFather.Name = "tbFather";
            this.tbFather.Size = new System.Drawing.Size(59, 22);
            this.tbFather.TabIndex = 127;
            this.tbFather.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbFather.MouseHover += new System.EventHandler(this.tbFather_MouseHover);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(116, 190);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(29, 12);
            this.label28.TabIndex = 126;
            this.label28.Text = "父亲";
            // 
            // tbStrain
            // 
            this.tbStrain.Location = new System.Drawing.Point(49, 187);
            this.tbStrain.MaxLength = 4;
            this.tbStrain.Name = "tbStrain";
            this.tbStrain.Size = new System.Drawing.Size(59, 22);
            this.tbStrain.TabIndex = 125;
            this.tbStrain.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbStrain.MouseHover += new System.EventHandler(this.tbStrain_MouseHover);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 190);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(29, 12);
            this.label29.TabIndex = 124;
            this.label29.Text = "血缘";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(11, 50);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 12);
            this.label24.TabIndex = 121;
            this.label24.Text = "出生地";
            // 
            // cbBornRegion
            // 
            this.cbBornRegion.FormattingEnabled = true;
            this.cbBornRegion.Items.AddRange(new object[] {
            "幽州",
            "冀州",
            "青徐",
            "兖豫",
            "司隶",
            "京兆",
            "凉州",
            "扬州",
            "荆北",
            "荆南",
            "益州",
            "南中",
            "交州",
            "夷州"});
            this.cbBornRegion.Location = new System.Drawing.Point(58, 47);
            this.cbBornRegion.Name = "cbBornRegion";
            this.cbBornRegion.Size = new System.Drawing.Size(82, 20);
            this.cbBornRegion.TabIndex = 86;
            this.cbBornRegion.Text = "幽州";
            // 
            // tbLoyalty
            // 
            this.tbLoyalty.Location = new System.Drawing.Point(319, 150);
            this.tbLoyalty.MaxLength = 4;
            this.tbLoyalty.Name = "tbLoyalty";
            this.tbLoyalty.Size = new System.Drawing.Size(59, 22);
            this.tbLoyalty.TabIndex = 120;
            this.tbLoyalty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(272, 153);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(41, 12);
            this.label23.TabIndex = 119;
            this.label23.Text = "忠诚度";
            // 
            // tbCalmness
            // 
            this.tbCalmness.Location = new System.Drawing.Point(186, 150);
            this.tbCalmness.MaxLength = 2;
            this.tbCalmness.Name = "tbCalmness";
            this.tbCalmness.Size = new System.Drawing.Size(59, 22);
            this.tbCalmness.TabIndex = 118;
            this.tbCalmness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(139, 153);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 12);
            this.label22.TabIndex = 117;
            this.label22.Text = "冷静度";
            // 
            // tbBraveness
            // 
            this.tbBraveness.Location = new System.Drawing.Point(58, 150);
            this.tbBraveness.MaxLength = 2;
            this.tbBraveness.Name = "tbBraveness";
            this.tbBraveness.Size = new System.Drawing.Size(59, 22);
            this.tbBraveness.TabIndex = 116;
            this.tbBraveness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(11, 153);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(41, 12);
            this.label21.TabIndex = 115;
            this.label21.Text = "勇猛度";
            // 
            // tbGlamourExperience
            // 
            this.tbGlamourExperience.Location = new System.Drawing.Point(507, 113);
            this.tbGlamourExperience.MaxLength = 4;
            this.tbGlamourExperience.Name = "tbGlamourExperience";
            this.tbGlamourExperience.Size = new System.Drawing.Size(59, 22);
            this.tbGlamourExperience.TabIndex = 114;
            this.tbGlamourExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(467, 116);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 12);
            this.label16.TabIndex = 113;
            this.label16.Text = "魅经";
            // 
            // tbPoliticsExperience
            // 
            this.tbPoliticsExperience.Location = new System.Drawing.Point(389, 113);
            this.tbPoliticsExperience.MaxLength = 4;
            this.tbPoliticsExperience.Name = "tbPoliticsExperience";
            this.tbPoliticsExperience.Size = new System.Drawing.Size(59, 22);
            this.tbPoliticsExperience.TabIndex = 112;
            this.tbPoliticsExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(349, 116);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 111;
            this.label17.Text = "政经";
            // 
            // tbIntelligenceExperience
            // 
            this.tbIntelligenceExperience.Location = new System.Drawing.Point(273, 113);
            this.tbIntelligenceExperience.MaxLength = 4;
            this.tbIntelligenceExperience.Name = "tbIntelligenceExperience";
            this.tbIntelligenceExperience.Size = new System.Drawing.Size(59, 22);
            this.tbIntelligenceExperience.TabIndex = 110;
            this.tbIntelligenceExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(233, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 109;
            this.label18.Text = "智经";
            // 
            // tbCommandExperience
            // 
            this.tbCommandExperience.Location = new System.Drawing.Point(165, 113);
            this.tbCommandExperience.MaxLength = 4;
            this.tbCommandExperience.Name = "tbCommandExperience";
            this.tbCommandExperience.Size = new System.Drawing.Size(59, 22);
            this.tbCommandExperience.TabIndex = 108;
            this.tbCommandExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(125, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 107;
            this.label19.Text = "统经";
            // 
            // tbStrengthExperience
            // 
            this.tbStrengthExperience.Location = new System.Drawing.Point(58, 113);
            this.tbStrengthExperience.MaxLength = 4;
            this.tbStrengthExperience.Name = "tbStrengthExperience";
            this.tbStrengthExperience.Size = new System.Drawing.Size(59, 22);
            this.tbStrengthExperience.TabIndex = 106;
            this.tbStrengthExperience.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(18, 116);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 12);
            this.label20.TabIndex = 105;
            this.label20.Text = "武经";
            // 
            // tbGlamour
            // 
            this.tbGlamour.Location = new System.Drawing.Point(507, 86);
            this.tbGlamour.MaxLength = 4;
            this.tbGlamour.Name = "tbGlamour";
            this.tbGlamour.Size = new System.Drawing.Size(59, 22);
            this.tbGlamour.TabIndex = 104;
            this.tbGlamour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(467, 89);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 12);
            this.label15.TabIndex = 103;
            this.label15.Text = "魅力";
            // 
            // tbPolitics
            // 
            this.tbPolitics.Location = new System.Drawing.Point(389, 86);
            this.tbPolitics.MaxLength = 4;
            this.tbPolitics.Name = "tbPolitics";
            this.tbPolitics.Size = new System.Drawing.Size(59, 22);
            this.tbPolitics.TabIndex = 102;
            this.tbPolitics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(349, 89);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 101;
            this.label14.Text = "政治";
            // 
            // tbIntelligence
            // 
            this.tbIntelligence.Location = new System.Drawing.Point(273, 86);
            this.tbIntelligence.MaxLength = 4;
            this.tbIntelligence.Name = "tbIntelligence";
            this.tbIntelligence.Size = new System.Drawing.Size(59, 22);
            this.tbIntelligence.TabIndex = 100;
            this.tbIntelligence.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 89);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 99;
            this.label13.Text = "智谋";
            // 
            // tbCommand
            // 
            this.tbCommand.Location = new System.Drawing.Point(165, 86);
            this.tbCommand.MaxLength = 4;
            this.tbCommand.Name = "tbCommand";
            this.tbCommand.Size = new System.Drawing.Size(59, 22);
            this.tbCommand.TabIndex = 98;
            this.tbCommand.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 97;
            this.label12.Text = "统率";
            // 
            // tbStrength
            // 
            this.tbStrength.Location = new System.Drawing.Point(58, 86);
            this.tbStrength.MaxLength = 4;
            this.tbStrength.Name = "tbStrength";
            this.tbStrength.Size = new System.Drawing.Size(59, 22);
            this.tbStrength.TabIndex = 96;
            this.tbStrength.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 95;
            this.label11.Text = "武勇";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(548, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 93;
            this.label10.Text = "死因";
            // 
            // cbDeadReason
            // 
            this.cbDeadReason.FormattingEnabled = true;
            this.cbDeadReason.Items.AddRange(new object[] {
            "自然死亡",
            "被杀死",
            "郁郁而终",
            "操劳过度"});
            this.cbDeadReason.Location = new System.Drawing.Point(588, 48);
            this.cbDeadReason.Name = "cbDeadReason";
            this.cbDeadReason.Size = new System.Drawing.Size(82, 20);
            this.cbDeadReason.TabIndex = 94;
            this.cbDeadReason.Text = "自然死亡";
            // 
            // tbDeadYear
            // 
            this.tbDeadYear.Location = new System.Drawing.Point(469, 47);
            this.tbDeadYear.MaxLength = 4;
            this.tbDeadYear.Name = "tbDeadYear";
            this.tbDeadYear.Size = new System.Drawing.Size(59, 22);
            this.tbDeadYear.TabIndex = 92;
            this.tbDeadYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(422, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 88;
            this.label7.Text = "死亡年";
            // 
            // tbBornYear
            // 
            this.tbBornYear.Location = new System.Drawing.Point(338, 47);
            this.tbBornYear.MaxLength = 4;
            this.tbBornYear.Name = "tbBornYear";
            this.tbBornYear.Size = new System.Drawing.Size(59, 22);
            this.tbBornYear.TabIndex = 91;
            this.tbBornYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(291, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 87;
            this.label8.Text = "出生年";
            // 
            // tbAvailableYear
            // 
            this.tbAvailableYear.Location = new System.Drawing.Point(210, 47);
            this.tbAvailableYear.MaxLength = 4;
            this.tbAvailableYear.Name = "tbAvailableYear";
            this.tbAvailableYear.Size = new System.Drawing.Size(59, 22);
            this.tbAvailableYear.TabIndex = 90;
            this.tbAvailableYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(163, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 89;
            this.label9.Text = "出场年";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(398, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 76;
            this.label6.Text = "性格";
            // 
            // tbIdeal
            // 
            this.tbIdeal.Location = new System.Drawing.Point(435, 9);
            this.tbIdeal.MaxLength = 4;
            this.tbIdeal.Name = "tbIdeal";
            this.tbIdeal.Size = new System.Drawing.Size(59, 22);
            this.tbIdeal.TabIndex = 85;
            this.tbIdeal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 77;
            this.label5.Text = "相性";
            // 
            // tbPic
            // 
            this.tbPic.Location = new System.Drawing.Point(319, 9);
            this.tbPic.MaxLength = 4;
            this.tbPic.Name = "tbPic";
            this.tbPic.Size = new System.Drawing.Size(59, 22);
            this.tbPic.TabIndex = 84;
            this.tbPic.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 74;
            this.label4.Text = "头像序号";
            // 
            // tbCalledName
            // 
            this.tbCalledName.Location = new System.Drawing.Point(198, 9);
            this.tbCalledName.MaxLength = 6;
            this.tbCalledName.Name = "tbCalledName";
            this.tbCalledName.Size = new System.Drawing.Size(40, 22);
            this.tbCalledName.TabIndex = 83;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 75;
            this.label3.Text = "字";
            // 
            // tbGivenName
            // 
            this.tbGivenName.Location = new System.Drawing.Point(118, 9);
            this.tbGivenName.MaxLength = 6;
            this.tbGivenName.Name = "tbGivenName";
            this.tbGivenName.Size = new System.Drawing.Size(40, 22);
            this.tbGivenName.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 80;
            this.label2.Text = "名";
            // 
            // tbSurName
            // 
            this.tbSurName.Location = new System.Drawing.Point(41, 9);
            this.tbSurName.MaxLength = 6;
            this.tbSurName.Name = "tbSurName";
            this.tbSurName.Size = new System.Drawing.Size(40, 22);
            this.tbSurName.TabIndex = 81;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 78;
            this.label1.Text = "姓";
            // 
            // tabPerson
            // 
            this.tabPerson.Controls.Add(this.tpBasic);
            this.tabPerson.Controls.Add(this.tpSkill);
            this.tabPerson.Controls.Add(this.tpTextMessage);
            this.tabPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPerson.Location = new System.Drawing.Point(0, 0);
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.SelectedIndex = 0;
            this.tabPerson.Size = new System.Drawing.Size(841, 605);
            this.tabPerson.TabIndex = 74;
            // 
            // tpTextMessage
            // 
            this.tpTextMessage.Controls.Add(this.label59);
            this.tpTextMessage.Controls.Add(this.rtbControversyPassiveWin);
            this.tpTextMessage.Controls.Add(this.label79);
            this.tpTextMessage.Controls.Add(this.rtbControversyInitiativeWin);
            this.tpTextMessage.Controls.Add(this.btnSaveTextMessage);
            this.tpTextMessage.Controls.Add(this.label58);
            this.tpTextMessage.Controls.Add(this.label78);
            this.tpTextMessage.Controls.Add(this.rtbOutburstQuiet);
            this.tpTextMessage.Controls.Add(this.label77);
            this.tpTextMessage.Controls.Add(this.rtbOutburstAngry);
            this.tpTextMessage.Controls.Add(this.label76);
            this.tpTextMessage.Controls.Add(this.rtbBreakWall);
            this.tpTextMessage.Controls.Add(this.label75);
            this.tpTextMessage.Controls.Add(this.rtbAntiAttack);
            this.tpTextMessage.Controls.Add(this.label74);
            this.tpTextMessage.Controls.Add(this.rtbResistHelpfulStratagem);
            this.tpTextMessage.Controls.Add(this.label73);
            this.tpTextMessage.Controls.Add(this.rtbResistHarmfulStratagem);
            this.tpTextMessage.Controls.Add(this.label72);
            this.tpTextMessage.Controls.Add(this.rtbHelpedByStratagem);
            this.tpTextMessage.Controls.Add(this.label71);
            this.tpTextMessage.Controls.Add(this.rtbTrappedByStratagem);
            this.tpTextMessage.Controls.Add(this.label70);
            this.tpTextMessage.Controls.Add(this.rtbRecoverFromChaos);
            this.tpTextMessage.Controls.Add(this.label69);
            this.tpTextMessage.Controls.Add(this.rtbCastDeepChaos);
            this.tpTextMessage.Controls.Add(this.label68);
            this.tpTextMessage.Controls.Add(this.rtbDeepChaos);
            this.tpTextMessage.Controls.Add(this.label67);
            this.tpTextMessage.Controls.Add(this.rtbChaos);
            this.tpTextMessage.Controls.Add(this.label66);
            this.tpTextMessage.Controls.Add(this.rtbDualPassiveWin);
            this.tpTextMessage.Controls.Add(this.label65);
            this.tpTextMessage.Controls.Add(this.rtbDualInitiativeWin);
            this.tpTextMessage.Controls.Add(this.label64);
            this.tpTextMessage.Controls.Add(this.rtbRout);
            this.tpTextMessage.Controls.Add(this.label63);
            this.tpTextMessage.Controls.Add(this.rtbSurround);
            this.tpTextMessage.Controls.Add(this.label62);
            this.tpTextMessage.Controls.Add(this.rtbReceiveCriticalStrike);
            this.tpTextMessage.Controls.Add(this.label61);
            this.tpTextMessage.Controls.Add(this.rtbCriticalStrikeOnArchitecture);
            this.tpTextMessage.Controls.Add(this.label60);
            this.tpTextMessage.Controls.Add(this.rtbCriticalStrike);
            this.tpTextMessage.Location = new System.Drawing.Point(4, 22);
            this.tpTextMessage.Name = "tpTextMessage";
            this.tpTextMessage.Size = new System.Drawing.Size(833, 579);
            this.tpTextMessage.TabIndex = 2;
            this.tpTextMessage.Text = "个性话语";
            this.tpTextMessage.UseVisualStyleBackColor = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(8, 225);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(53, 12);
            this.label59.TabIndex = 63;
            this.label59.Text = "被动论战";
            // 
            // rtbControversyPassiveWin
            // 
            this.rtbControversyPassiveWin.AcceptsTab = true;
            this.rtbControversyPassiveWin.Location = new System.Drawing.Point(97, 222);
            this.rtbControversyPassiveWin.Name = "rtbControversyPassiveWin";
            this.rtbControversyPassiveWin.Size = new System.Drawing.Size(551, 21);
            this.rtbControversyPassiveWin.TabIndex = 34;
            this.rtbControversyPassiveWin.Text = "";
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(8, 198);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(53, 12);
            this.label79.TabIndex = 61;
            this.label79.Text = "主动论战";
            // 
            // rtbControversyInitiativeWin
            // 
            this.rtbControversyInitiativeWin.AcceptsTab = true;
            this.rtbControversyInitiativeWin.Location = new System.Drawing.Point(97, 195);
            this.rtbControversyInitiativeWin.Name = "rtbControversyInitiativeWin";
            this.rtbControversyInitiativeWin.Size = new System.Drawing.Size(551, 21);
            this.rtbControversyInitiativeWin.TabIndex = 33;
            this.rtbControversyInitiativeWin.Text = "";
            // 
            // btnSaveTextMessage
            // 
            this.btnSaveTextMessage.Location = new System.Drawing.Point(729, 544);
            this.btnSaveTextMessage.Name = "btnSaveTextMessage";
            this.btnSaveTextMessage.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTextMessage.TabIndex = 59;
            this.btnSaveTextMessage.Text = "保存修改";
            this.btnSaveTextMessage.UseVisualStyleBackColor = true;
            this.btnSaveTextMessage.Click += new System.EventHandler(this.btnSaveTextMessage_Click);
            // 
            // label58
            // 
            this.label58.Location = new System.Drawing.Point(664, 15);
            this.label58.Margin = new System.Windows.Forms.Padding(3);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(152, 39);
            this.label58.TabIndex = 58;
            this.label58.Text = "每种对话可以设置为多句，只需要用空格符分割每句。";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(8, 549);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(53, 12);
            this.label78.TabIndex = 57;
            this.label78.Text = "沉静状态";
            // 
            // rtbOutburstQuiet
            // 
            this.rtbOutburstQuiet.AcceptsTab = true;
            this.rtbOutburstQuiet.Location = new System.Drawing.Point(97, 546);
            this.rtbOutburstQuiet.Name = "rtbOutburstQuiet";
            this.rtbOutburstQuiet.Size = new System.Drawing.Size(551, 21);
            this.rtbOutburstQuiet.TabIndex = 56;
            this.rtbOutburstQuiet.Text = "";
            // 
            // label77
            // 
            this.label77.AutoSize = true;
            this.label77.Location = new System.Drawing.Point(8, 522);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(53, 12);
            this.label77.TabIndex = 55;
            this.label77.Text = "愤怒状态";
            // 
            // rtbOutburstAngry
            // 
            this.rtbOutburstAngry.AcceptsTab = true;
            this.rtbOutburstAngry.Location = new System.Drawing.Point(97, 519);
            this.rtbOutburstAngry.Name = "rtbOutburstAngry";
            this.rtbOutburstAngry.Size = new System.Drawing.Size(551, 21);
            this.rtbOutburstAngry.TabIndex = 54;
            this.rtbOutburstAngry.Text = "";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(8, 495);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(53, 12);
            this.label76.TabIndex = 53;
            this.label76.Text = "攻破城墙";
            // 
            // rtbBreakWall
            // 
            this.rtbBreakWall.AcceptsTab = true;
            this.rtbBreakWall.Location = new System.Drawing.Point(97, 492);
            this.rtbBreakWall.Name = "rtbBreakWall";
            this.rtbBreakWall.Size = new System.Drawing.Size(551, 21);
            this.rtbBreakWall.TabIndex = 52;
            this.rtbBreakWall.Text = "";
            // 
            // label75
            // 
            this.label75.AutoSize = true;
            this.label75.Location = new System.Drawing.Point(8, 468);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(53, 12);
            this.label75.TabIndex = 51;
            this.label75.Text = "抵抗攻击";
            // 
            // rtbAntiAttack
            // 
            this.rtbAntiAttack.AcceptsTab = true;
            this.rtbAntiAttack.Location = new System.Drawing.Point(97, 465);
            this.rtbAntiAttack.Name = "rtbAntiAttack";
            this.rtbAntiAttack.Size = new System.Drawing.Size(551, 21);
            this.rtbAntiAttack.TabIndex = 50;
            this.rtbAntiAttack.Text = "";
            // 
            // label74
            // 
            this.label74.AutoSize = true;
            this.label74.Location = new System.Drawing.Point(8, 441);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(77, 12);
            this.label74.TabIndex = 49;
            this.label74.Text = "抵抗友好计略";
            // 
            // rtbResistHelpfulStratagem
            // 
            this.rtbResistHelpfulStratagem.AcceptsTab = true;
            this.rtbResistHelpfulStratagem.Location = new System.Drawing.Point(97, 438);
            this.rtbResistHelpfulStratagem.Name = "rtbResistHelpfulStratagem";
            this.rtbResistHelpfulStratagem.Size = new System.Drawing.Size(551, 21);
            this.rtbResistHelpfulStratagem.TabIndex = 48;
            this.rtbResistHelpfulStratagem.Text = "";
            // 
            // label73
            // 
            this.label73.AutoSize = true;
            this.label73.Location = new System.Drawing.Point(8, 414);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(77, 12);
            this.label73.TabIndex = 47;
            this.label73.Text = "抵抗敌军计略";
            // 
            // rtbResistHarmfulStratagem
            // 
            this.rtbResistHarmfulStratagem.AcceptsTab = true;
            this.rtbResistHarmfulStratagem.Location = new System.Drawing.Point(97, 411);
            this.rtbResistHarmfulStratagem.Name = "rtbResistHarmfulStratagem";
            this.rtbResistHarmfulStratagem.Size = new System.Drawing.Size(551, 21);
            this.rtbResistHarmfulStratagem.TabIndex = 46;
            this.rtbResistHarmfulStratagem.Text = "";
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(8, 387);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(65, 12);
            this.label72.TabIndex = 45;
            this.label72.Text = "被计略帮助";
            // 
            // rtbHelpedByStratagem
            // 
            this.rtbHelpedByStratagem.AcceptsTab = true;
            this.rtbHelpedByStratagem.Location = new System.Drawing.Point(97, 384);
            this.rtbHelpedByStratagem.Name = "rtbHelpedByStratagem";
            this.rtbHelpedByStratagem.Size = new System.Drawing.Size(551, 21);
            this.rtbHelpedByStratagem.TabIndex = 44;
            this.rtbHelpedByStratagem.Text = "";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(8, 360);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(29, 12);
            this.label71.TabIndex = 43;
            this.label71.Text = "中计";
            // 
            // rtbTrappedByStratagem
            // 
            this.rtbTrappedByStratagem.AcceptsTab = true;
            this.rtbTrappedByStratagem.Location = new System.Drawing.Point(97, 357);
            this.rtbTrappedByStratagem.Name = "rtbTrappedByStratagem";
            this.rtbTrappedByStratagem.Size = new System.Drawing.Size(551, 21);
            this.rtbTrappedByStratagem.TabIndex = 42;
            this.rtbTrappedByStratagem.Text = "";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(8, 333);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(53, 12);
            this.label70.TabIndex = 41;
            this.label70.Text = "混乱恢复";
            // 
            // rtbRecoverFromChaos
            // 
            this.rtbRecoverFromChaos.AcceptsTab = true;
            this.rtbRecoverFromChaos.Location = new System.Drawing.Point(97, 330);
            this.rtbRecoverFromChaos.Name = "rtbRecoverFromChaos";
            this.rtbRecoverFromChaos.Size = new System.Drawing.Size(551, 21);
            this.rtbRecoverFromChaos.TabIndex = 40;
            this.rtbRecoverFromChaos.Text = "";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(8, 306);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(53, 12);
            this.label69.TabIndex = 39;
            this.label69.Text = "计略致乱";
            // 
            // rtbCastDeepChaos
            // 
            this.rtbCastDeepChaos.AcceptsTab = true;
            this.rtbCastDeepChaos.Location = new System.Drawing.Point(97, 303);
            this.rtbCastDeepChaos.Name = "rtbCastDeepChaos";
            this.rtbCastDeepChaos.Size = new System.Drawing.Size(551, 21);
            this.rtbCastDeepChaos.TabIndex = 38;
            this.rtbCastDeepChaos.Text = "";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(8, 279);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(53, 12);
            this.label68.TabIndex = 37;
            this.label68.Text = "深度混乱";
            // 
            // rtbDeepChaos
            // 
            this.rtbDeepChaos.AcceptsTab = true;
            this.rtbDeepChaos.Location = new System.Drawing.Point(97, 276);
            this.rtbDeepChaos.Name = "rtbDeepChaos";
            this.rtbDeepChaos.Size = new System.Drawing.Size(551, 21);
            this.rtbDeepChaos.TabIndex = 36;
            this.rtbDeepChaos.Text = "";
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(8, 252);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(53, 12);
            this.label67.TabIndex = 35;
            this.label67.Text = "进入混乱";
            // 
            // rtbChaos
            // 
            this.rtbChaos.AcceptsTab = true;
            this.rtbChaos.Location = new System.Drawing.Point(97, 249);
            this.rtbChaos.Name = "rtbChaos";
            this.rtbChaos.Size = new System.Drawing.Size(551, 21);
            this.rtbChaos.TabIndex = 34;
            this.rtbChaos.Text = "";
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(8, 171);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(53, 12);
            this.label66.TabIndex = 33;
            this.label66.Text = "被动单挑";
            // 
            // rtbDualPassiveWin
            // 
            this.rtbDualPassiveWin.AcceptsTab = true;
            this.rtbDualPassiveWin.Location = new System.Drawing.Point(97, 168);
            this.rtbDualPassiveWin.Name = "rtbDualPassiveWin";
            this.rtbDualPassiveWin.Size = new System.Drawing.Size(551, 21);
            this.rtbDualPassiveWin.TabIndex = 32;
            this.rtbDualPassiveWin.Text = "";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(8, 144);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 31;
            this.label65.Text = "主动单挑";
            // 
            // rtbDualInitiativeWin
            // 
            this.rtbDualInitiativeWin.AcceptsTab = true;
            this.rtbDualInitiativeWin.Location = new System.Drawing.Point(97, 141);
            this.rtbDualInitiativeWin.Name = "rtbDualInitiativeWin";
            this.rtbDualInitiativeWin.Size = new System.Drawing.Size(551, 21);
            this.rtbDualInitiativeWin.TabIndex = 30;
            this.rtbDualInitiativeWin.Text = "";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(8, 117);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(53, 12);
            this.label64.TabIndex = 29;
            this.label64.Text = "击破部队";
            // 
            // rtbRout
            // 
            this.rtbRout.AcceptsTab = true;
            this.rtbRout.Location = new System.Drawing.Point(97, 114);
            this.rtbRout.Name = "rtbRout";
            this.rtbRout.Size = new System.Drawing.Size(551, 21);
            this.rtbRout.TabIndex = 28;
            this.rtbRout.Text = "";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(8, 90);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(53, 12);
            this.label63.TabIndex = 27;
            this.label63.Text = "包围攻击";
            // 
            // rtbSurround
            // 
            this.rtbSurround.AcceptsTab = true;
            this.rtbSurround.Location = new System.Drawing.Point(97, 87);
            this.rtbSurround.Name = "rtbSurround";
            this.rtbSurround.Size = new System.Drawing.Size(551, 21);
            this.rtbSurround.TabIndex = 26;
            this.rtbSurround.Text = "";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(8, 63);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(41, 12);
            this.label62.TabIndex = 25;
            this.label62.Text = "被暴击";
            // 
            // rtbReceiveCriticalStrike
            // 
            this.rtbReceiveCriticalStrike.AcceptsTab = true;
            this.rtbReceiveCriticalStrike.Location = new System.Drawing.Point(97, 60);
            this.rtbReceiveCriticalStrike.Name = "rtbReceiveCriticalStrike";
            this.rtbReceiveCriticalStrike.Size = new System.Drawing.Size(551, 21);
            this.rtbReceiveCriticalStrike.TabIndex = 24;
            this.rtbReceiveCriticalStrike.Text = "";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(8, 36);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(53, 12);
            this.label61.TabIndex = 23;
            this.label61.Text = "暴击建筑";
            // 
            // rtbCriticalStrikeOnArchitecture
            // 
            this.rtbCriticalStrikeOnArchitecture.AcceptsTab = true;
            this.rtbCriticalStrikeOnArchitecture.Location = new System.Drawing.Point(97, 33);
            this.rtbCriticalStrikeOnArchitecture.Name = "rtbCriticalStrikeOnArchitecture";
            this.rtbCriticalStrikeOnArchitecture.Size = new System.Drawing.Size(551, 21);
            this.rtbCriticalStrikeOnArchitecture.TabIndex = 22;
            this.rtbCriticalStrikeOnArchitecture.Text = "";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(8, 9);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(53, 12);
            this.label60.TabIndex = 21;
            this.label60.Text = "暴击部队";
            // 
            // rtbCriticalStrike
            // 
            this.rtbCriticalStrike.AcceptsTab = true;
            this.rtbCriticalStrike.Location = new System.Drawing.Point(97, 6);
            this.rtbCriticalStrike.Name = "rtbCriticalStrike";
            this.rtbCriticalStrike.Size = new System.Drawing.Size(551, 21);
            this.rtbCriticalStrike.TabIndex = 20;
            this.rtbCriticalStrike.Text = "";
            // 
            // frmEditPerson
            // 
            this.ClientSize = new System.Drawing.Size(841, 605);
            this.Controls.Add(this.tabPerson);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEditPerson";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑人物属性";
            this.Load += new System.EventHandler(this.frmEditPerson_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEditPerson_FormClosed);
            this.tpSkill.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.gbStunt.ResumeLayout(false);
            this.gbSkills.ResumeLayout(false);
            this.gbSkills.PerformLayout();
            this.tpBasic.ResumeLayout(false);
            this.tpBasic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbHead)).EndInit();
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.gbHatedPersons.ResumeLayout(false);
            this.gbClosePersons.ResumeLayout(false);
            this.tabPerson.ResumeLayout(false);
            this.tpTextMessage.ResumeLayout(false);
            this.tpTextMessage.PerformLayout();
            this.ResumeLayout(false);

        }

        void btnDeleteSelectedTitle_Click(object sender, EventArgs e)
        {
            Title selectedItem = this.lbTitle.SelectedItem as Title;
            if (selectedItem != null)
            {
                this.person.RealTitles.Remove(selectedItem);
                this.RefreshTitleList();
            }
        }

        private void InitializeSkillData(Person p)
        {
            foreach (Skill skill in p.Skills.Skills.Values)
            {
                switch (skill.ID)
                {
                    case 0:
                        this.clb00.SetItemChecked(0, true);
                        break;

                    case 1:
                        this.clb00.SetItemChecked(1, true);
                        break;

                    case 2:
                        this.clb00.SetItemChecked(2, true);
                        break;

                    case 3:
                        this.clb00.SetItemChecked(3, true);
                        break;

                    case 4:
                        this.clb00.SetItemChecked(4, true);
                        break;

                    case 5:
                        this.clb00.SetItemChecked(5, true);
                        break;

                    case 6:
                        this.clb00.SetItemChecked(6, true);
                        break;

                    case 10:
                        this.clb01.SetItemChecked(0, true);
                        break;

                    case 11:
                        this.clb01.SetItemChecked(1, true);
                        break;

                    case 12:
                        this.clb01.SetItemChecked(2, true);
                        break;

                    case 13:
                        this.clb01.SetItemChecked(3, true);
                        break;

                    case 14:
                        this.clb01.SetItemChecked(4, true);
                        break;

                    case 15:
                        this.clb01.SetItemChecked(5, true);
                        break;

                    case 0x10:
                        this.clb01.SetItemChecked(6, true);
                        break;

                    case 20:
                        this.clb02.SetItemChecked(0, true);
                        break;

                    case 0x15:
                        this.clb02.SetItemChecked(1, true);
                        break;

                    case 0x16:
                        this.clb02.SetItemChecked(2, true);
                        break;

                    case 0x17:
                        this.clb02.SetItemChecked(3, true);
                        break;

                    case 0x18:
                        this.clb02.SetItemChecked(4, true);
                        break;

                    case 0x19:
                        this.clb02.SetItemChecked(5, true);
                        break;

                    case 0x1a:
                        this.clb02.SetItemChecked(6, true);
                        break;

                    case 30:
                        this.clb03.SetItemChecked(0, true);
                        break;

                    case 0x1f:
                        this.clb03.SetItemChecked(1, true);
                        break;

                    case 0x20:
                        this.clb03.SetItemChecked(2, true);
                        break;

                    case 0x21:
                        this.clb03.SetItemChecked(3, true);
                        break;

                    case 0x22:
                        this.clb03.SetItemChecked(4, true);
                        break;

                    case 0x23:
                        this.clb03.SetItemChecked(5, true);
                        break;

                    case 0x24:
                        this.clb03.SetItemChecked(6, true);
                        break;

                    case 40:
                        this.clb04.SetItemChecked(0, true);
                        break;

                    case 0x29:
                        this.clb04.SetItemChecked(1, true);
                        break;

                    case 0x2a:
                        this.clb04.SetItemChecked(2, true);
                        break;

                    case 0x2b:
                        this.clb04.SetItemChecked(3, true);
                        break;

                    case 0x2c:
                        this.clb04.SetItemChecked(4, true);
                        break;

                    case 0x2d:
                        this.clb04.SetItemChecked(5, true);
                        break;

                    case 0x2e:
                        this.clb04.SetItemChecked(6, true);
                        break;

                    case 50:
                        this.clb05.SetItemChecked(0, true);
                        break;

                    case 0x33:
                        this.clb05.SetItemChecked(1, true);
                        break;

                    case 0x34:
                        this.clb05.SetItemChecked(2, true);
                        break;

                    case 0x35:
                        this.clb05.SetItemChecked(3, true);
                        break;

                    case 0x36:
                        this.clb05.SetItemChecked(4, true);
                        break;

                    case 0x37:
                        this.clb05.SetItemChecked(5, true);
                        break;

                    case 0x38:
                        this.clb05.SetItemChecked(6, true);
                        break;

                    case 60:
                        this.clb06.SetItemChecked(0, true);
                        break;

                    case 0x3d:
                        this.clb06.SetItemChecked(1, true);
                        break;

                    case 0x3e:
                        this.clb06.SetItemChecked(2, true);
                        break;

                    case 0x3f:
                        this.clb06.SetItemChecked(3, true);
                        break;

                    case 0x40:
                        this.clb06.SetItemChecked(4, true);
                        break;

                    case 0x41:
                        this.clb06.SetItemChecked(5, true);
                        break;

                    case 0x42:
                        this.clb06.SetItemChecked(6, true);
                        break;

                    case 70:
                        this.clb07.SetItemChecked(0, true);
                        break;

                    case 0x47:
                        this.clb07.SetItemChecked(1, true);
                        break;

                    case 0x48:
                        this.clb07.SetItemChecked(2, true);
                        break;

                    case 0x49:
                        this.clb07.SetItemChecked(3, true);
                        break;

                    case 0x4a:
                        this.clb07.SetItemChecked(4, true);
                        break;

                    case 0x4b:
                        this.clb07.SetItemChecked(5, true);
                        break;

                    case 0x4c:
                        this.clb07.SetItemChecked(6, true);
                        break;

                    case 80:
                        this.clb08.SetItemChecked(0, true);
                        break;

                    case 0x51:
                        this.clb08.SetItemChecked(1, true);
                        break;

                    case 0x52:
                        this.clb08.SetItemChecked(2, true);
                        break;

                    case 0x53:
                        this.clb08.SetItemChecked(3, true);
                        break;

                    case 0x54:
                        this.clb08.SetItemChecked(4, true);
                        break;

                    case 0x55:
                        this.clb08.SetItemChecked(5, true);
                        break;

                    case 0x56:
                        this.clb08.SetItemChecked(6, true);
                        break;

                    case 90:
                        this.clb09.SetItemChecked(0, true);
                        break;

                    case 0x5b:
                        this.clb09.SetItemChecked(1, true);
                        break;

                    case 0x5c:
                        this.clb09.SetItemChecked(2, true);
                        break;

                    case 0x5d:
                        this.clb09.SetItemChecked(3, true);
                        break;

                    case 0x5e:
                        this.clb09.SetItemChecked(4, true);
                        break;

                    case 0x5f:
                        this.clb09.SetItemChecked(5, true);
                        break;

                    case 0x60:
                        this.clb09.SetItemChecked(6, true);
                        break;

                    case 100:
                        this.clb10.SetItemChecked(0, true);
                        break;

                    case 0x65:
                        this.clb10.SetItemChecked(1, true);
                        break;

                    case 0x66:
                        this.clb10.SetItemChecked(2, true);
                        break;

                    case 0x67:
                        this.clb10.SetItemChecked(3, true);
                        break;

                    case 0x68:
                        this.clb10.SetItemChecked(4, true);
                        break;

                    case 0x69:
                        this.clb10.SetItemChecked(5, true);
                        break;

                    case 0x6a:
                        this.clb10.SetItemChecked(6, true);
                        break;

                    case 110:
                        this.clb11.SetItemChecked(0, true);
                        break;
                }
            }
        }

        private void InitializeStuntData(Person p)
        {
            foreach (Stunt stunt in p.Stunts.Stunts.Values)
            {
                this.lbStunt.Items.Add(stunt);
            }
            foreach (Stunt stunt in p.Scenario.GameCommonData.AllStunts.Stunts.Values)
            {
                this.cbAllStunt.Items.Add(stunt);
            }
        }

        private void InitializeTabData()
        {
            if (this.person != null)
            {
                    Biography biography = this.MainForm.Scenario.AllBiographies.GetBiography(this.person.ID);
                    if (biography == null)
                    {
                        biography = new Biography();
                        biography.ID = this.person.ID;
                        biography.Scenario = this.person.Scenario;
                        biography.FactionColor = 0;
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0));
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(1));
                        biography.MilitaryKinds.AddMilitaryKind(this.person.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(2));
                        this.person.Scenario.AllBiographies.AddBiography(biography);
                    }
                    this.person.PersonBiography = biography;
                    this.tbSurName.Text = this.person.SurName;
                    this.tbGivenName.Text = this.person.GivenName;
                    this.tbCalledName.Text = this.person.CalledName;
                    this.tbPic.Text = this.person.PictureIndex.ToString();
                    this.pbHead.Image = this.MainForm.GetPersonPortrait(this.person.PictureIndex);
                    this.tbIdeal.Text = this.person.Ideal.ToString();
                    this.cbIdealTendency.Items.Clear();
                    foreach (IdealTendencyKind kind in this.person.Scenario.GameCommonData.AllIdealTendencyKinds)
                    {
                        this.cbIdealTendency.Items.Add(kind);
                    }
                    try
                    {
                        this.cbIdealTendency.SelectedIndex = this.person.IdealTendency.ID;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbBornRegion.SelectedIndex = (int)this.person.BornRegion;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbAvailableLocation.Text = this.person.AvailableLocation.ToString();
                    this.tbAvailableYear.Text = this.person.YearAvailable.ToString();
                    this.tbBornYear.Text = this.person.YearBorn.ToString();
                    this.tbDeadYear.Text = this.person.YearDead.ToString();
                    try
                    {
                        this.cbDeadReason.SelectedIndex = (int)this.person.DeadReason;
                    } 
                    catch (ArgumentOutOfRangeException) { }
                    this.tbStrength.Text = this.person.BaseStrength.ToString();
                    this.tbCommand.Text = this.person.BaseCommand.ToString();
                    this.tbIntelligence.Text = this.person.BaseIntelligence.ToString();
                    this.tbPolitics.Text = this.person.BasePolitics.ToString();
                    this.tbGlamour.Text = this.person.BaseGlamour.ToString();
                    this.tbStrengthExperience.Text = this.person.StrengthExperience.ToString();
                    this.tbCommandExperience.Text = this.person.CommandExperience.ToString();
                    this.tbIntelligenceExperience.Text = this.person.IntelligenceExperience.ToString();
                    this.tbPoliticsExperience.Text = this.person.PoliticsExperience.ToString();
                    this.tbGlamourExperience.Text = this.person.GlamourExperience.ToString();
                    this.tbBraveness.Text = this.person.BaseBraveness.ToString();
                    this.tbCalmness.Text = this.person.BaseCalmness.ToString();
                    this.tbLoyalty.Text = this.person.Loyalty.ToString();
                    try 
                    {
                        this.cbCharacter.SelectedIndex = this.person.Character.ID;
                    } 
                    catch (ArgumentOutOfRangeException) { }
                    foreach (Microsoft.Xna.Framework.Graphics.Color color in this.person.Scenario.GameCommonData.AllColors)
                    {
                        this.cbFactionColor.Items.Add(color);
                    }
                    Microsoft.Xna.Framework.Graphics.Color color3 = this.person.Scenario.GameCommonData.AllColors[this.person.PersonBiography.FactionColor];
                    System.Drawing.Color color2 = System.Drawing.Color.FromArgb((int)color3.PackedValue);
                    try
                    {
                        this.cbFactionColor.SelectedIndex = this.cbFactionColor.Items.IndexOf(color2);
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbFactionColor.BackColor = color2;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbStrain.Text = this.person.Strain.ToString();
                    this.tbFather.Text = this.person.Father != null ? this.person.Father.ID.ToString() : "-1";
                    this.tbMother.Text = this.person.Mother != null ? this.person.Mother.ID.ToString() : "-1";
                    this.tbSpouse.Text = this.person.Spouse != null ? this.person.Spouse.ID.ToString() : "-1";
                    try
                    {
                        this.tbBrother.Text = "";
                        foreach (Person num in this.person.Brothers)
                        {
                            this.tbBrother.Text += num.ID + " ";
                        }
                    }
                    catch { }
                    this.tbGeneration.Text = this.person.Generation.ToString();
                    try
                    {
                        this.cbPersonalLoyalty.SelectedIndex = (int)this.person.PersonalLoyalty;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try 
                    {
                        this.cbAmbition.SelectedIndex = (int)this.person.Ambition;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbQualification.SelectedIndex = (int)this.person.Qualification;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbValuationOnGovernment.SelectedIndex = (int)this.person.ValuationOnGovernment;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    try
                    {
                        this.cbStrategyTendency.SelectedIndex = (int)this.person.StrategyTendency;
                    }
                    catch (ArgumentOutOfRangeException) { }
                    this.tbOldFactionID.Text = StaticMethods.SaveToString(this.person.JoinFactionID);
                    try
                    {
                        foreach (Person num in this.person.GetClosePersons())
                        {
                            this.lbClosePersons.Items.Add(num.ID + " " + num.Name);
                        }
                        foreach (Person num in this.person.GetHatedPersons())
                        {
                            this.lbHatedPersons.Items.Add(num.ID + " " + num.Name);
                        }
                    }
                    catch
                    {
                    }
                    if (this.person.PersonBiography != null)
                    {
                        this.rtbBiographyBrief.Text = this.person.PersonBiography.Brief;
                        this.rtbBiographyRomance.Text = this.person.PersonBiography.Romance;
                        this.rtbBiographyHistory.Text = this.person.PersonBiography.History;
                    }
                    else
                    {
                        this.rtbBiographyBrief.Enabled = false;
                        this.rtbBiographyRomance.Enabled = false;
                        this.rtbBiographyHistory.Enabled = false;
                    }
                    this.InitializeSkillData(this.person);
                    this.InitializeStuntData(this.person);
                    this.InitializeTitleData(this.person);
                    this.rtbCriticalStrike.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Critical));
                    this.rtbCriticalStrikeOnArchitecture.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.CriticalArchitecture));
                    this.rtbReceiveCriticalStrike.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.BeCritical));
                    this.rtbSurround.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Surround));
                    this.rtbRout.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Rout));
                    this.rtbDualInitiativeWin.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DualActiveWin));
                    this.rtbDualPassiveWin.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DualPassiveWin));
                    this.rtbControversyInitiativeWin.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ControversyActiveWin));
                    this.rtbControversyPassiveWin.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ControversyPassiveWin));
                    this.rtbChaos.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Chaos));
                    this.rtbDeepChaos.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.DeepChaos));
                    this.rtbCastDeepChaos.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.CastDeepChaos));
                    this.rtbRecoverFromChaos.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.RecoverChaos));
                    this.rtbTrappedByStratagem.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.TrappedByStratagem));
                    this.rtbHelpedByStratagem.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.HelpedByStratagem));
                    this.rtbResistHarmfulStratagem.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ResistHarmfulStratagem));
                    this.rtbResistHelpfulStratagem.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.ResistHelpfulStratagem));
                    this.rtbAntiAttack.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.AntiAttack));
                    this.rtbBreakWall.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.BreakWall));
                    this.rtbOutburstAngry.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Angry));
                    this.rtbOutburstQuiet.Text = StaticMethods.SaveToString(this.person.Scenario.GameCommonData.AllTextMessages.GetTextMessage(this.person.ID, TextMessageKind.Calm));
            }
        }

        private void InitializeTitleData(Person p)
        {
            foreach (Title title in p.RealTitles)
            {
                this.lbTitle.Items.Add(title);
            }
            foreach (Title title in p.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                this.cbAllTitle.Items.Add(title);
            }
        }

        private void RefreshTitleList()
        {
            this.lbTitle.Items.Clear();
            foreach (Title title in this.person.RealTitles)
            {
                this.lbTitle.Items.Add(title);
            }
        }

        private void RefreshStuntList()
        {
            this.lbStunt.Items.Clear();
            foreach (Stunt stunt in this.person.Stunts.Stunts.Values)
            {
                this.lbStunt.Items.Add(stunt);
            }
        }

        private void rtbBiographyBrief_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.Brief = this.rtbBiographyBrief.Text;
        }

        private void rtbBiographyHistory_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.History = this.rtbBiographyHistory.Text;
        }

        private void rtbBiographyRomance_TextChanged(object sender, EventArgs e)
        {
            this.person.PersonBiography.Romance = this.rtbBiographyRomance.Text;
        }

        private void SavePersonBasicData(Person p)
        {
            try
            {
                p.SurName = this.tbSurName.Text;
                p.GivenName = this.tbGivenName.Text;
                p.CalledName = this.tbCalledName.Text;
                p.PictureIndex = int.Parse(this.tbPic.Text);
                p.Ideal = int.Parse(this.tbIdeal.Text);
                p.IdealTendency = this.cbIdealTendency.SelectedItem as IdealTendencyKind;
                p.BornRegion = (PersonBornRegion) this.cbBornRegion.SelectedIndex;
                p.AvailableLocation = int.Parse(this.tbAvailableLocation.Text);
                p.YearAvailable = int.Parse(this.tbAvailableYear.Text);
                p.YearBorn = int.Parse(this.tbBornYear.Text);
                p.YearDead = int.Parse(this.tbDeadYear.Text);
                p.DeadReason = (PersonDeadReason) this.cbDeadReason.SelectedIndex;
                p.Strength = int.Parse(this.tbStrength.Text);
                p.Command = int.Parse(this.tbCommand.Text);
                p.Intelligence = int.Parse(this.tbIntelligence.Text);
                p.Politics = int.Parse(this.tbPolitics.Text);
                p.Glamour = int.Parse(this.tbGlamour.Text);
                p.StrengthExperience = int.Parse(this.tbStrengthExperience.Text);
                p.CommandExperience = int.Parse(this.tbCommandExperience.Text);
                p.IntelligenceExperience = int.Parse(this.tbIntelligenceExperience.Text);
                p.PoliticsExperience = int.Parse(this.tbPoliticsExperience.Text);
                p.GlamourExperience = int.Parse(this.tbGlamourExperience.Text);
                p.Braveness = int.Parse(this.tbBraveness.Text);
                p.Calmness = int.Parse(this.tbCalmness.Text);
                p.Loyalty = int.Parse(this.tbLoyalty.Text);
                p.Character = p.Scenario.GameCommonData.AllCharacterKinds[this.cbCharacter.SelectedIndex];
                p.Strain = int.Parse(this.tbStrain.Text);
                int t;
                int.TryParse(this.tbFather.Text, out t);
                p.Father = p.Scenario.Persons.GetGameObject(t) as Person;
                int.TryParse(this.tbMother.Text, out t);
                p.Mother = p.Scenario.Persons.GetGameObject(t) as Person;
                int.TryParse(this.tbSpouse.Text, out t);
                p.Spouse = p.Scenario.Persons.GetGameObject(t) as Person;

                p.Brothers.Clear();
                char[] separator = new char[] { ' ', '\n', '\r', '\t' };
                string[] strArray = this.tbBrother.Text.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (String s in strArray)
                {
                    int.TryParse(s, out t);
                    Person q = this.Persons.GetGameObject(t) as Person;
                    p.Brothers.Add(q);
                }

                p.Generation = int.Parse(this.tbGeneration.Text);
                p.PersonalLoyalty = (int) this.cbPersonalLoyalty.SelectedIndex;
                p.Ambition = (int) this.cbAmbition.SelectedIndex;
                p.Qualification = (PersonQualification) this.cbQualification.SelectedIndex;
                p.ValuationOnGovernment = (PersonValuationOnGovernment) this.cbValuationOnGovernment.SelectedIndex;
                p.StrategyTendency = (PersonStrategyTendency) this.cbStrategyTendency.SelectedIndex;
                try
                {
                    StaticMethods.LoadFromString(p.JoinFactionID, this.tbOldFactionID.Text);
                }
                catch
                {
                }

                PersonList pl = p.GetClosePersons();
                foreach (Person q in pl)
                {
                    p.RemoveClose(q);
                }
                pl = p.GetHatedPersons();
                foreach (Person q in pl)
                {
                    p.RemoveHated(q);
                }

                foreach (string str in this.lbClosePersons.Items)
                {
                    int id = int.Parse(str.Substring(0, str.IndexOf(" ")));
                    p.AddClose(p.Scenario.Persons.GetGameObject(id) as Person);
                }

                foreach (string str in this.lbHatedPersons.Items)
                {
                    int id = int.Parse(str.Substring(0, str.IndexOf(" ")));
                    p.AddHated(p.Scenario.Persons.GetGameObject(id) as Person);
                }
            }
            catch
            {
                MessageBox.Show("请输入正确的数据格式。");
            }
        }

        private void SavePersonSkills(Person p)
        {
            p.Skills.Clear();
            foreach (int num in this.clb00.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num));
            }
            foreach (int num in this.clb01.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 10));
            }
            foreach (int num in this.clb02.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 20));
            }
            foreach (int num in this.clb03.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 30));
            }
            foreach (int num in this.clb04.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 40));
            }
            foreach (int num in this.clb05.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 50));
            }
            foreach (int num in this.clb06.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 60));
            }
            foreach (int num in this.clb07.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 70));
            }
            foreach (int num in this.clb08.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 80));
            }
            foreach (int num in this.clb09.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 90));
            }
            foreach (int num in this.clb10.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 100));
            }
            foreach (int num in this.clb11.CheckedIndices)
            {
                p.Skills.AddSkill(p.Scenario.GameCommonData.AllSkills.GetSkill(num + 110));
            }
        }

        public void SetTabIndex(int index)
        {
            this.tabPerson.SelectedIndex = index;
        }

        private void tbBrother_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的义兄是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbBrother.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbFather_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的父亲是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbFather.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbMother_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的母亲是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbMother.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbOldFactionID_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = "填勢力ID，半型空格分隔";
                }
                catch
                {
                }
            }
        }

        private void tbSpouse_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "的配偶是:" + (this.AllPersons.GetGameObject(int.Parse(this.tbSpouse.Text)) as Person).Name;
                }
                catch
                {
                }
            }
        }

        private void tbStrain_MouseHover(object sender, EventArgs e)
        {
            if (this.person != null)
            {
                try
                {
                    this.tsslIDtoName.Text = this.person.Name + "属于" + (this.AllPersons.GetGameObject(int.Parse(this.tbStrain.Text)) as Person).Name + "一脉";
                }
                catch
                {
                }
            }
        }
    }
}

