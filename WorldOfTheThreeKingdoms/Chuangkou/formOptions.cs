using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		System.Drawing;
using		System.Windows.Forms;
using System.Xml;
using System.ComponentModel;

namespace WorldOfTheThreeKingdoms.GameForms
{
    internal enum Difficulty
    {
        beginner,
        easy,
        normal,
        hard,
        veryhard,
        custom
    }

    public class formOptions : Form
    {
        private int AIEncircleRank = 0;
        private int AIEncircleVar = 0;

        private Button btnCancel;
        private Button btnOK;
        private CheckBox cbAdditionalPersonAvailable;
        private CheckBox cbCommonPersonAvailable;
        private CheckBox cbDrawMapVeil;
        private CheckBox cbDrawTroopAnimation;
        private CheckBox cbHintPopulation;
        private CheckBox cbHintPopulationUnder1000;
        private CheckBox cbNoHintOnSmallFacility;
        private CheckBox cbPlayBattleSound;
        private CheckBox cbPlayerPersonAvailable;
        private CheckBox cbPlayMusic;
        private CheckBox cbPlayNormalSound;
        private CheckBox cbRunWhileNotFocused;
        private CheckBox cbSingleSelectionOneClick;
        private XmlDocument commonDoc = new XmlDocument();
        private IContainer components = null;
        private Label lblTroopMoveSpeed;
        private Label lblAIArchitectureDamageRate;
        private Label lblAITroopOffenceRate;
        private Label lblAIFoodRate;
        private Label lblAIFundRate;
        private Label lblAITroopDefenceRate;
        private Label lblAITrainingSpeedRate;
        private Label lblAIRecruitmentSpeedRate;
        private Label lblFindTreasureChance;
        private Label lblLearnTitleDays;
        private Label lblLearnStuntDays;
        private Label lblLearnSkillDays;
        private Label lblSearchDays;
        private Label lblFollowedLeaderOffenceRateIncrement;
        private Label lblFollowedLeaderDefenceRateIncrement;
        private XmlDocument parameterDoc = new XmlDocument();
        private TabPage tabPageAIParameter;
        private TabPage tabPageEnvironment;
        private TabPage tabPagePerson;
        private TextBox tbAIArchitectureDamageRate;
        private TextBox tbAIFoodRate;
        private TextBox tbAIFundRate;
        private TextBox tbAIRecruitmentSpeedRate;
        private TextBox tbAITrainingSpeedRate;
        private TextBox tbAITroopDefenceRate;
        private TextBox tbAITroopOffenceRate;
        private TextBox tbFindTreasureChance;
        private TextBox tbFollowedLeaderDefenceRateIncrement;
        private TextBox tbFollowedLeaderOffenceRateIncrement;
        private TextBox tbLearnSkillDays;
        private TextBox tbLearnStuntDays;
        private TextBox tbLearnTitleDays;
        private TextBox tbSearchDays;
        private TextBox tbTroopMoveSpeed;
        private TabControl tcOptions;
        private CheckBox cbPinPointAtPlayer;
        private CheckBox cbIgnoreStrategyTendency;
        private CheckBox cbDoAutoSave;
        private CheckBox cbCreateChildrenIgnoreLimit;
        private CheckBox cbInternalSurplusRateForPlayer;
        private CheckBox cbInternalSurplusRateForAI;
        private Label lblAIExecutionRate;
        private TextBox tbAIExecutionRate;
        private CheckBox cbAIExecuteBetterOfficer;
        private Label lblMaxExperience;
        private TextBox tbMaxExperience;
        private CheckBox cbLockChildrenLoyalty;
        private CheckBox cbAIAutoTakePlayerCaptives;
        private CheckBox cbAIAutoTakeNoFactionPerson;
        private CheckBox cbAIAutoTakeNoFactionCaptives;
        private CheckBox cbAIAutoTakePlayerCaptiveOnlyUnfull;
        private Label lblDialogShowTime;
        private TextBox tbDialogShowTime;
        private TextBox tbBattleSpeed;
        private Label lblBattleSpeed;
        private Label lblAIArmyExperienceRate;
        private TextBox tbAIArmyExperienceRate;
        private Label lblAIOfficerExperienceRate;
        private TextBox tbAIOfficerExperienceRate;
        private Label lblMaxAbility;
        private TextBox tbMaxAbility;
        private Label lblTirednessIncrease;
        private TextBox tbTirednessIncrease;
        private Label lblTirednessDecrease;
        private TextBox tbTirednessDecrease;
        private Label lblLearnTitleSuccessRate;
        private TextBox tbLearnTitleSuccessRate;
        private Label lblLearnStuntSuccessRate;
        private TextBox tbLearnStuntSuccessRate;
        private Label lblLearnSkillSuccessRate;
        private TextBox tbLearnSkillSuccessRate;
        private TextBox tbAutosaveFrequency;
        private Label label59;
        private CheckBox cbShowChallengeAnimation;
        private TabPage tabPageBasic;
        private Label lblOfficerDieInBattleRate;
        private TextBox tbOfficerDieInBattleRate;
        private CheckBox cbCreateChildren;
        private TextBox tbGetChildrenRate;
        private Label lblGetChildrenRate;
        private CheckBox cbEnableAgeAbilityFactor;
        private CheckBox cbIdealTendencyValid;
        private CheckBox cbPersonNaturalDeath;
        private CheckBox cbPersonDieInChallenge;
        private TextBox tbTabListDetailLevel;
        private Label lblTabListDetailLevel;
        private CheckBox cbLandArmyCanGoDownWater;
        private CheckBox cbHardcoreMode;
        private CheckBox cbEnableCheat;
        private CheckBox wujiangYoukenengDuli;
        private CheckBox checkLiangdaoXitong;
        private GroupBox groupBox1;
        private RadioButton rbCustom;
        private RadioButton rbVeryhard;
        private RadioButton rbHard;
        private RadioButton rbNormal;
        private RadioButton rbEasy;
        private RadioButton rbBeginner;
        private CheckBox cbPermitFactionMerge;
        private CheckBox cbMilitaryKindSpeedValid;
        private CheckBox cbPopulationRecruitmentLimit;
        private CheckBox cbMultipleResource;
        private CheckBox cbSkyEye;
        private Label zainanbiaoqian;
        private TextBox zainanfashengjilv;
        private TabPage tabPageParameter;
        private Label lblLeadershipOffenceRate;
        private TextBox tbLeadershipOffenceRate;
        private Label lblTechniquePointMultiple;
        private TextBox tbTechniquePointMultiple;
        private Label lblFireDamageScale;
        private TextBox tbFireDamageScale;
        private Label lblSurroundArchitectureDominationUnit;
        private TextBox tbSurroundArchitectureDominationUnit;
        private Label lblFoodToFundDivisor;
        private TextBox tbFoodToFundDivisor;
        private Label lblFundToFoodMultiple;
        private TextBox tbFundToFoodMultiple;
        private Label lblSellFoodCommerce;
        private TextBox tbSellFoodCommerce;
        private Label lblBuyFoodAgriculture;
        private TextBox tbBuyFoodAgriculture;
        private Label lblGossipArchitectureCost;
        private TextBox tbGossipArchitectureCost;
        private Label lblInstigateArchitectureCost;
        private TextBox tbInstigateArchitectureCost;
        private Label lblDestroyArchitectureCost;
        private TextBox tbDestroyArchitectureCost;
        private Label lblRewardPersonCost;
        private TextBox tbRewardPersonCost;
        private Label lblConvincePersonCost;
        private TextBox tbConvincePersonCost;
        private Label lblChangeCapitalCost;
        private TextBox tbChangeCapitalCost;
        private Label lblRecruitmentMorale;
        private TextBox tbRecruitmentMorale;
        private Label lblRecruitmentDomination;
        private TextBox tbRecruitmentDomination;
        private Label lblRecruitmentFundCost;
        private TextBox tbRecruitmentFundCost;
        private Label lblInternalFundCost;
        private TextBox tbInternalFundCost;
        private Label lblDefaultPopulationDevelopingRate;
        private TextBox tbDefaultPopulationDevelopingRate;
        private Label lblArchitectureDamageRate;
        private TextBox tbArchitectureDamageRate;
        private Label lblTroopDamageRate;
        private TextBox tbTroopDamageRate;
        private Label lblFoodRate;
        private TextBox tbFoodRate;
        private Label lblFundRate;
        private TextBox tbFundRate;
        private Label lblRecruitmentRate;
        private TextBox tbRecruitmentRate;
        private Label lblTrainingRate;
        private TextBox tbTrainingRate;
        private Label lblInternalRate;
        private TextBox tbInternalRate;
        private Label lblMilitaryPopulationReloadQuantity;
        private TextBox tbMilitaryPopulationReloadQuantity;
        private Label lblMilitaryPopulationCap;
        private TextBox tbMilitaryPopulationCap;
        private Label lblJailBreakArchitectureCost;
        private Label lblOfficerChildrenLimit;
        private TextBox tbOfficerChildrenLimit;
        private Label label61;
        private TextBox tbAIArmyExperienceIncreaseRate;
        private TextBox tbAIOfficerExperienceIncreaseRate;
        private TextBox tbAITrainingSpeedIncreaseRate;
        private TextBox tbAIRecruitmentSpeedIncreaseRate;
        private TextBox tbAITroopDefenceIncreaseRate;
        private TextBox tbAIArchitectureDamageIncreaseRate;
        private TextBox tbAITroopOffenceIncreaseRate;
        private TextBox tbAIFoodIncreaseRate;
        private TextBox tbAIFundIncreaseRate;
        private Label label62;
        private CheckBox cbStopToControlOnAttack;
        private Label lblMaxMilitaryExperience;
        private TextBox tbMaxMilitaryExperience;
        private TextBox tbAIAntiSurroundIncreaseRate;
        private Label lblAIAntiSurround;
        private TextBox tbAIAntiSurround;
        private TextBox tbAIAntiStratagemIncreaseRate;
        private Label lblAIAntiStratagem;
        private TextBox tbAIAntiStratagem;
        private TextBox tbCreateRandomOfficerChance;
        private Label lblCreateRandomOfficerChance;
        private TextBox tbHougongGetChildrenRate;
        private Label lblHougongGetChildrenRate;
        
        private TextBox tbCreatedOfficerAbilityFactor;
        private Label lblCreatedOfficerAbilityFactor;
        private CheckBox cbEnablePersonRelations;
        private Label lblChildrenAvailableAge;
        private TextBox tbChildrenAvailableAge;
        private CheckBox cbFullScreen;
        private TextBox tbAIExtraPersonIncreaseRate;
        private Label lblAIExtraPerson;
        private TextBox tbAIExtraPerson;
        private Label lblAIEncirclePlayerRate;
        private TextBox tbAIEncirclePlayerRate;
        private TextBox tbJailBreakArchitectureCost;

        public formOptions()
        {
            this.InitializeComponent();
            this.LoadCommonDoc();
            this.LoadParameterDoc();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!this.SaveCommonDoc()) this.DialogResult = DialogResult.None;
            if (!this.SaveParameterDoc()) this.DialogResult = DialogResult.None;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.tcOptions = new System.Windows.Forms.TabControl();
            this.tabPageBasic = new System.Windows.Forms.TabPage();
            this.tbHougongGetChildrenRate = new System.Windows.Forms.TextBox();
            this.lblHougongGetChildrenRate = new System.Windows.Forms.Label();
            this.tbCreateRandomOfficerChance = new System.Windows.Forms.TextBox();
            this.lblCreateRandomOfficerChance = new System.Windows.Forms.Label();
            this.lblOfficerDieInBattleRate = new System.Windows.Forms.Label();
            this.tbOfficerDieInBattleRate = new System.Windows.Forms.TextBox();
            this.cbCreateChildren = new System.Windows.Forms.CheckBox();
            this.tbGetChildrenRate = new System.Windows.Forms.TextBox();
            this.lblGetChildrenRate = new System.Windows.Forms.Label();
            this.cbEnableAgeAbilityFactor = new System.Windows.Forms.CheckBox();
            this.cbIdealTendencyValid = new System.Windows.Forms.CheckBox();
            this.cbPersonNaturalDeath = new System.Windows.Forms.CheckBox();
            this.cbPersonDieInChallenge = new System.Windows.Forms.CheckBox();
            this.tbTabListDetailLevel = new System.Windows.Forms.TextBox();
            this.lblTabListDetailLevel = new System.Windows.Forms.Label();
            this.cbLandArmyCanGoDownWater = new System.Windows.Forms.CheckBox();
            this.cbHardcoreMode = new System.Windows.Forms.CheckBox();
            this.cbEnableCheat = new System.Windows.Forms.CheckBox();
            this.wujiangYoukenengDuli = new System.Windows.Forms.CheckBox();
            this.checkLiangdaoXitong = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCustom = new System.Windows.Forms.RadioButton();
            this.rbVeryhard = new System.Windows.Forms.RadioButton();
            this.rbHard = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbEasy = new System.Windows.Forms.RadioButton();
            this.rbBeginner = new System.Windows.Forms.RadioButton();
            this.cbPermitFactionMerge = new System.Windows.Forms.CheckBox();
            this.cbMilitaryKindSpeedValid = new System.Windows.Forms.CheckBox();
            this.cbPopulationRecruitmentLimit = new System.Windows.Forms.CheckBox();
            this.cbMultipleResource = new System.Windows.Forms.CheckBox();
            this.cbSkyEye = new System.Windows.Forms.CheckBox();
            this.zainanbiaoqian = new System.Windows.Forms.Label();
            this.zainanfashengjilv = new System.Windows.Forms.TextBox();
            this.tabPageEnvironment = new System.Windows.Forms.TabPage();
            this.cbFullScreen = new System.Windows.Forms.CheckBox();
            this.cbStopToControlOnAttack = new System.Windows.Forms.CheckBox();
            this.cbShowChallengeAnimation = new System.Windows.Forms.CheckBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tbAutosaveFrequency = new System.Windows.Forms.TextBox();
            this.tbBattleSpeed = new System.Windows.Forms.TextBox();
            this.lblBattleSpeed = new System.Windows.Forms.Label();
            this.lblDialogShowTime = new System.Windows.Forms.Label();
            this.tbDialogShowTime = new System.Windows.Forms.TextBox();
            this.cbHintPopulationUnder1000 = new System.Windows.Forms.CheckBox();
            this.cbHintPopulation = new System.Windows.Forms.CheckBox();
            this.lblTroopMoveSpeed = new System.Windows.Forms.Label();
            this.tbTroopMoveSpeed = new System.Windows.Forms.TextBox();
            this.cbNoHintOnSmallFacility = new System.Windows.Forms.CheckBox();
            this.cbSingleSelectionOneClick = new System.Windows.Forms.CheckBox();
            this.cbDrawTroopAnimation = new System.Windows.Forms.CheckBox();
            this.cbDrawMapVeil = new System.Windows.Forms.CheckBox();
            this.cbPlayBattleSound = new System.Windows.Forms.CheckBox();
            this.cbPlayNormalSound = new System.Windows.Forms.CheckBox();
            this.cbPlayMusic = new System.Windows.Forms.CheckBox();
            this.cbRunWhileNotFocused = new System.Windows.Forms.CheckBox();
            this.cbDoAutoSave = new System.Windows.Forms.CheckBox();
            this.tabPagePerson = new System.Windows.Forms.TabPage();
            this.lblChildrenAvailableAge = new System.Windows.Forms.Label();
            this.tbChildrenAvailableAge = new System.Windows.Forms.TextBox();
            this.cbEnablePersonRelations = new System.Windows.Forms.CheckBox();
            this.tbCreatedOfficerAbilityFactor = new System.Windows.Forms.TextBox();
            this.lblCreatedOfficerAbilityFactor = new System.Windows.Forms.Label();
            this.lblOfficerChildrenLimit = new System.Windows.Forms.Label();
            this.tbOfficerChildrenLimit = new System.Windows.Forms.TextBox();
            this.lblLearnTitleSuccessRate = new System.Windows.Forms.Label();
            this.tbLearnTitleSuccessRate = new System.Windows.Forms.TextBox();
            this.lblLearnStuntSuccessRate = new System.Windows.Forms.Label();
            this.tbLearnStuntSuccessRate = new System.Windows.Forms.TextBox();
            this.lblLearnSkillSuccessRate = new System.Windows.Forms.Label();
            this.tbLearnSkillSuccessRate = new System.Windows.Forms.TextBox();
            this.lblTirednessDecrease = new System.Windows.Forms.Label();
            this.tbTirednessDecrease = new System.Windows.Forms.TextBox();
            this.lblTirednessIncrease = new System.Windows.Forms.Label();
            this.tbTirednessIncrease = new System.Windows.Forms.TextBox();
            this.lblMaxAbility = new System.Windows.Forms.Label();
            this.tbMaxAbility = new System.Windows.Forms.TextBox();
            this.cbLockChildrenLoyalty = new System.Windows.Forms.CheckBox();
            this.lblMaxExperience = new System.Windows.Forms.Label();
            this.tbMaxExperience = new System.Windows.Forms.TextBox();
            this.lblFollowedLeaderDefenceRateIncrement = new System.Windows.Forms.Label();
            this.tbFollowedLeaderDefenceRateIncrement = new System.Windows.Forms.TextBox();
            this.lblFollowedLeaderOffenceRateIncrement = new System.Windows.Forms.Label();
            this.tbFollowedLeaderOffenceRateIncrement = new System.Windows.Forms.TextBox();
            this.lblLearnTitleDays = new System.Windows.Forms.Label();
            this.tbLearnTitleDays = new System.Windows.Forms.TextBox();
            this.lblLearnStuntDays = new System.Windows.Forms.Label();
            this.tbLearnStuntDays = new System.Windows.Forms.TextBox();
            this.lblLearnSkillDays = new System.Windows.Forms.Label();
            this.tbLearnSkillDays = new System.Windows.Forms.TextBox();
            this.lblSearchDays = new System.Windows.Forms.Label();
            this.tbSearchDays = new System.Windows.Forms.TextBox();
            this.lblFindTreasureChance = new System.Windows.Forms.Label();
            this.tbFindTreasureChance = new System.Windows.Forms.TextBox();
            this.cbPlayerPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbAdditionalPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbCommonPersonAvailable = new System.Windows.Forms.CheckBox();
            this.cbCreateChildrenIgnoreLimit = new System.Windows.Forms.CheckBox();
            this.tabPageParameter = new System.Windows.Forms.TabPage();
            this.lblMaxMilitaryExperience = new System.Windows.Forms.Label();
            this.tbMaxMilitaryExperience = new System.Windows.Forms.TextBox();
            this.lblMilitaryPopulationReloadQuantity = new System.Windows.Forms.Label();
            this.tbMilitaryPopulationReloadQuantity = new System.Windows.Forms.TextBox();
            this.lblMilitaryPopulationCap = new System.Windows.Forms.Label();
            this.tbMilitaryPopulationCap = new System.Windows.Forms.TextBox();
            this.lblJailBreakArchitectureCost = new System.Windows.Forms.Label();
            this.tbJailBreakArchitectureCost = new System.Windows.Forms.TextBox();
            this.lblLeadershipOffenceRate = new System.Windows.Forms.Label();
            this.tbLeadershipOffenceRate = new System.Windows.Forms.TextBox();
            this.lblTechniquePointMultiple = new System.Windows.Forms.Label();
            this.tbTechniquePointMultiple = new System.Windows.Forms.TextBox();
            this.lblFireDamageScale = new System.Windows.Forms.Label();
            this.tbFireDamageScale = new System.Windows.Forms.TextBox();
            this.lblSurroundArchitectureDominationUnit = new System.Windows.Forms.Label();
            this.tbSurroundArchitectureDominationUnit = new System.Windows.Forms.TextBox();
            this.lblFoodToFundDivisor = new System.Windows.Forms.Label();
            this.tbFoodToFundDivisor = new System.Windows.Forms.TextBox();
            this.lblFundToFoodMultiple = new System.Windows.Forms.Label();
            this.tbFundToFoodMultiple = new System.Windows.Forms.TextBox();
            this.lblSellFoodCommerce = new System.Windows.Forms.Label();
            this.tbSellFoodCommerce = new System.Windows.Forms.TextBox();
            this.lblBuyFoodAgriculture = new System.Windows.Forms.Label();
            this.tbBuyFoodAgriculture = new System.Windows.Forms.TextBox();
            this.lblGossipArchitectureCost = new System.Windows.Forms.Label();
            this.tbGossipArchitectureCost = new System.Windows.Forms.TextBox();
            this.lblInstigateArchitectureCost = new System.Windows.Forms.Label();
            this.tbInstigateArchitectureCost = new System.Windows.Forms.TextBox();
            this.lblDestroyArchitectureCost = new System.Windows.Forms.Label();
            this.tbDestroyArchitectureCost = new System.Windows.Forms.TextBox();
            this.lblRewardPersonCost = new System.Windows.Forms.Label();
            this.tbRewardPersonCost = new System.Windows.Forms.TextBox();
            this.lblConvincePersonCost = new System.Windows.Forms.Label();
            this.tbConvincePersonCost = new System.Windows.Forms.TextBox();
            this.lblChangeCapitalCost = new System.Windows.Forms.Label();
            this.tbChangeCapitalCost = new System.Windows.Forms.TextBox();
            this.lblRecruitmentMorale = new System.Windows.Forms.Label();
            this.tbRecruitmentMorale = new System.Windows.Forms.TextBox();
            this.lblRecruitmentDomination = new System.Windows.Forms.Label();
            this.tbRecruitmentDomination = new System.Windows.Forms.TextBox();
            this.lblRecruitmentFundCost = new System.Windows.Forms.Label();
            this.tbRecruitmentFundCost = new System.Windows.Forms.TextBox();
            this.lblInternalFundCost = new System.Windows.Forms.Label();
            this.tbInternalFundCost = new System.Windows.Forms.TextBox();
            this.lblDefaultPopulationDevelopingRate = new System.Windows.Forms.Label();
            this.tbDefaultPopulationDevelopingRate = new System.Windows.Forms.TextBox();
            this.lblArchitectureDamageRate = new System.Windows.Forms.Label();
            this.tbArchitectureDamageRate = new System.Windows.Forms.TextBox();
            this.lblTroopDamageRate = new System.Windows.Forms.Label();
            this.tbTroopDamageRate = new System.Windows.Forms.TextBox();
            this.lblFoodRate = new System.Windows.Forms.Label();
            this.tbFoodRate = new System.Windows.Forms.TextBox();
            this.lblFundRate = new System.Windows.Forms.Label();
            this.tbFundRate = new System.Windows.Forms.TextBox();
            this.lblRecruitmentRate = new System.Windows.Forms.Label();
            this.tbRecruitmentRate = new System.Windows.Forms.TextBox();
            this.lblTrainingRate = new System.Windows.Forms.Label();
            this.tbTrainingRate = new System.Windows.Forms.TextBox();
            this.lblInternalRate = new System.Windows.Forms.Label();
            this.tbInternalRate = new System.Windows.Forms.TextBox();
            this.tabPageAIParameter = new System.Windows.Forms.TabPage();
            this.lblAIEncirclePlayerRate = new System.Windows.Forms.Label();
            this.tbAIEncirclePlayerRate = new System.Windows.Forms.TextBox();
            this.tbAIExtraPersonIncreaseRate = new System.Windows.Forms.TextBox();
            this.lblAIExtraPerson = new System.Windows.Forms.Label();
            this.tbAIExtraPerson = new System.Windows.Forms.TextBox();
            this.tbAIAntiSurroundIncreaseRate = new System.Windows.Forms.TextBox();
            this.lblAIAntiSurround = new System.Windows.Forms.Label();
            this.tbAIAntiSurround = new System.Windows.Forms.TextBox();
            this.tbAIAntiStratagemIncreaseRate = new System.Windows.Forms.TextBox();
            this.lblAIAntiStratagem = new System.Windows.Forms.Label();
            this.tbAIAntiStratagem = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.tbAIArmyExperienceIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAIOfficerExperienceIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAITrainingSpeedIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAIRecruitmentSpeedIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAITroopDefenceIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAIArchitectureDamageIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAITroopOffenceIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAIFoodIncreaseRate = new System.Windows.Forms.TextBox();
            this.tbAIFundIncreaseRate = new System.Windows.Forms.TextBox();
            this.lblAIArmyExperienceRate = new System.Windows.Forms.Label();
            this.tbAIArmyExperienceRate = new System.Windows.Forms.TextBox();
            this.lblAIOfficerExperienceRate = new System.Windows.Forms.Label();
            this.tbAIOfficerExperienceRate = new System.Windows.Forms.TextBox();
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakePlayerCaptives = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakeNoFactionPerson = new System.Windows.Forms.CheckBox();
            this.cbAIAutoTakeNoFactionCaptives = new System.Windows.Forms.CheckBox();
            this.cbAIExecuteBetterOfficer = new System.Windows.Forms.CheckBox();
            this.lblAIExecutionRate = new System.Windows.Forms.Label();
            this.tbAIExecutionRate = new System.Windows.Forms.TextBox();
            this.lblAITrainingSpeedRate = new System.Windows.Forms.Label();
            this.tbAITrainingSpeedRate = new System.Windows.Forms.TextBox();
            this.lblAIRecruitmentSpeedRate = new System.Windows.Forms.Label();
            this.tbAIRecruitmentSpeedRate = new System.Windows.Forms.TextBox();
            this.lblAITroopDefenceRate = new System.Windows.Forms.Label();
            this.tbAITroopDefenceRate = new System.Windows.Forms.TextBox();
            this.lblAIArchitectureDamageRate = new System.Windows.Forms.Label();
            this.tbAIArchitectureDamageRate = new System.Windows.Forms.TextBox();
            this.lblAITroopOffenceRate = new System.Windows.Forms.Label();
            this.tbAITroopOffenceRate = new System.Windows.Forms.TextBox();
            this.lblAIFoodRate = new System.Windows.Forms.Label();
            this.tbAIFoodRate = new System.Windows.Forms.TextBox();
            this.lblAIFundRate = new System.Windows.Forms.Label();
            this.tbAIFundRate = new System.Windows.Forms.TextBox();
            this.cbPinPointAtPlayer = new System.Windows.Forms.CheckBox();
            this.cbIgnoreStrategyTendency = new System.Windows.Forms.CheckBox();
            this.cbInternalSurplusRateForPlayer = new System.Windows.Forms.CheckBox();
            this.cbInternalSurplusRateForAI = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tcOptions.SuspendLayout();
            this.tabPageBasic.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageEnvironment.SuspendLayout();
            this.tabPagePerson.SuspendLayout();
            this.tabPageParameter.SuspendLayout();
            this.tabPageAIParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcOptions
            // 
            this.tcOptions.Controls.Add(this.tabPageBasic);
            this.tcOptions.Controls.Add(this.tabPageEnvironment);
            this.tcOptions.Controls.Add(this.tabPagePerson);
            this.tcOptions.Controls.Add(this.tabPageParameter);
            this.tcOptions.Controls.Add(this.tabPageAIParameter);
            this.tcOptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tcOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcOptions.Location = new System.Drawing.Point(0, 0);
            this.tcOptions.Multiline = true;
            this.tcOptions.Name = "tcOptions";
            this.tcOptions.SelectedIndex = 0;
            this.tcOptions.Size = new System.Drawing.Size(453, 448);
            this.tcOptions.TabIndex = 0;
            // 
            // tabPageBasic
            // 
            this.tabPageBasic.Controls.Add(this.tbHougongGetChildrenRate);
            this.tabPageBasic.Controls.Add(this.lblHougongGetChildrenRate);
            this.tabPageBasic.Controls.Add(this.tbCreateRandomOfficerChance);
            this.tabPageBasic.Controls.Add(this.lblCreateRandomOfficerChance);
            this.tabPageBasic.Controls.Add(this.lblOfficerDieInBattleRate);
            this.tabPageBasic.Controls.Add(this.tbOfficerDieInBattleRate);
            this.tabPageBasic.Controls.Add(this.cbCreateChildren);
            this.tabPageBasic.Controls.Add(this.tbGetChildrenRate);
            this.tabPageBasic.Controls.Add(this.lblGetChildrenRate);
            this.tabPageBasic.Controls.Add(this.cbEnableAgeAbilityFactor);
            this.tabPageBasic.Controls.Add(this.cbIdealTendencyValid);
            this.tabPageBasic.Controls.Add(this.cbPersonNaturalDeath);
            this.tabPageBasic.Controls.Add(this.cbPersonDieInChallenge);
            this.tabPageBasic.Controls.Add(this.tbTabListDetailLevel);
            this.tabPageBasic.Controls.Add(this.lblTabListDetailLevel);
            this.tabPageBasic.Controls.Add(this.cbLandArmyCanGoDownWater);
            this.tabPageBasic.Controls.Add(this.cbHardcoreMode);
            this.tabPageBasic.Controls.Add(this.cbEnableCheat);
            this.tabPageBasic.Controls.Add(this.wujiangYoukenengDuli);
            this.tabPageBasic.Controls.Add(this.checkLiangdaoXitong);
            this.tabPageBasic.Controls.Add(this.groupBox1);
            this.tabPageBasic.Controls.Add(this.cbPermitFactionMerge);
            this.tabPageBasic.Controls.Add(this.cbMilitaryKindSpeedValid);
            this.tabPageBasic.Controls.Add(this.cbPopulationRecruitmentLimit);
            this.tabPageBasic.Controls.Add(this.cbMultipleResource);
            this.tabPageBasic.Controls.Add(this.cbSkyEye);
            this.tabPageBasic.Controls.Add(this.zainanbiaoqian);
            this.tabPageBasic.Controls.Add(this.zainanfashengjilv);
            this.tabPageBasic.Location = new System.Drawing.Point(4, 22);
            this.tabPageBasic.Name = "tabPageBasic";
            this.tabPageBasic.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageBasic.Size = new System.Drawing.Size(445, 422);
            this.tabPageBasic.TabIndex = 4;
            this.tabPageBasic.Text = "基本";
            this.tabPageBasic.UseVisualStyleBackColor = true;
            // 
            // tbHougongGetChildrenRate
            // 
            this.tbHougongGetChildrenRate.Location = new System.Drawing.Point(381, 253);
            this.tbHougongGetChildrenRate.Name = "tbHougongGetChildrenRate";
            this.tbHougongGetChildrenRate.Size = new System.Drawing.Size(51, 21);
            this.tbHougongGetChildrenRate.TabIndex = 141;
            this.tbHougongGetChildrenRate.Text = "100";
            // 
            // lblHougongGetChildrenRate
            // 
            this.lblHougongGetChildrenRate.AutoSize = true;
            this.lblHougongGetChildrenRate.Location = new System.Drawing.Point(298, 256);
            this.lblHougongGetChildrenRate.Name = "lblHougongGetChildrenRate";
            this.lblHougongGetChildrenRate.Size = new System.Drawing.Size(77, 12);
            this.lblHougongGetChildrenRate.TabIndex = 140;
            this.lblHougongGetChildrenRate.Text = "妃子怀孕机率";
            // 
            // tbCreateRandomOfficerChance
            // 
            this.tbCreateRandomOfficerChance.Location = new System.Drawing.Point(381, 281);
            this.tbCreateRandomOfficerChance.Name = "tbCreateRandomOfficerChance";
            this.tbCreateRandomOfficerChance.Size = new System.Drawing.Size(51, 21);
            this.tbCreateRandomOfficerChance.TabIndex = 139;
            this.tbCreateRandomOfficerChance.Text = "100";
            // 
            // lblCreateRandomOfficerChance
            // 
            this.lblCreateRandomOfficerChance.AutoSize = true;
            this.lblCreateRandomOfficerChance.Location = new System.Drawing.Point(310, 284);
            this.lblCreateRandomOfficerChance.Name = "lblCreateRandomOfficerChance";
            this.lblCreateRandomOfficerChance.Size = new System.Drawing.Size(65, 12);
            this.lblCreateRandomOfficerChance.TabIndex = 138;
            this.lblCreateRandomOfficerChance.Text = "招贤成功率";
            this.lblCreateRandomOfficerChance.Click += new System.EventHandler(this.lblCreateRandomOfficerChance_Click);
            // 
            // lblOfficerDieInBattleRate
            // 
            this.lblOfficerDieInBattleRate.AutoSize = true;
            this.lblOfficerDieInBattleRate.Location = new System.Drawing.Point(311, 201);
            this.lblOfficerDieInBattleRate.Name = "lblOfficerDieInBattleRate";
            this.lblOfficerDieInBattleRate.Size = new System.Drawing.Size(65, 12);
            this.lblOfficerDieInBattleRate.TabIndex = 137;
            this.lblOfficerDieInBattleRate.Text = "武将战死率";
            // 
            // tbOfficerDieInBattleRate
            // 
            this.tbOfficerDieInBattleRate.Location = new System.Drawing.Point(382, 198);
            this.tbOfficerDieInBattleRate.Name = "tbOfficerDieInBattleRate";
            this.tbOfficerDieInBattleRate.Size = new System.Drawing.Size(50, 21);
            this.tbOfficerDieInBattleRate.TabIndex = 136;
            this.tbOfficerDieInBattleRate.Text = "10";
            // 
            // cbCreateChildren
            // 
            this.cbCreateChildren.AutoSize = true;
            this.cbCreateChildren.Location = new System.Drawing.Point(13, 321);
            this.cbCreateChildren.Name = "cbCreateChildren";
            this.cbCreateChildren.Size = new System.Drawing.Size(96, 16);
            this.cbCreateChildren.TabIndex = 135;
            this.cbCreateChildren.Text = "生成虚拟子嗣";
            // 
            // tbGetChildrenRate
            // 
            this.tbGetChildrenRate.Location = new System.Drawing.Point(381, 226);
            this.tbGetChildrenRate.Name = "tbGetChildrenRate";
            this.tbGetChildrenRate.Size = new System.Drawing.Size(51, 21);
            this.tbGetChildrenRate.TabIndex = 134;
            this.tbGetChildrenRate.Text = "100";
            // 
            // lblGetChildrenRate
            // 
            this.lblGetChildrenRate.AutoSize = true;
            this.lblGetChildrenRate.Location = new System.Drawing.Point(298, 229);
            this.lblGetChildrenRate.Name = "lblGetChildrenRate";
            this.lblGetChildrenRate.Size = new System.Drawing.Size(77, 12);
            this.lblGetChildrenRate.TabIndex = 133;
            this.lblGetChildrenRate.Text = "武將怀孕机率";
            // 
            // cbEnableAgeAbilityFactor
            // 
            this.cbEnableAgeAbilityFactor.AutoSize = true;
            this.cbEnableAgeAbilityFactor.Location = new System.Drawing.Point(13, 123);
            this.cbEnableAgeAbilityFactor.Name = "cbEnableAgeAbilityFactor";
            this.cbEnableAgeAbilityFactor.Size = new System.Drawing.Size(96, 16);
            this.cbEnableAgeAbilityFactor.TabIndex = 132;
            this.cbEnableAgeAbilityFactor.Text = "年龄影响能力";
            this.cbEnableAgeAbilityFactor.UseVisualStyleBackColor = true;
            // 
            // cbIdealTendencyValid
            // 
            this.cbIdealTendencyValid.AutoSize = true;
            this.cbIdealTendencyValid.Location = new System.Drawing.Point(13, 35);
            this.cbIdealTendencyValid.Name = "cbIdealTendencyValid";
            this.cbIdealTendencyValid.Size = new System.Drawing.Size(120, 16);
            this.cbIdealTendencyValid.TabIndex = 131;
            this.cbIdealTendencyValid.Text = "出仕相性考虑有效";
            this.cbIdealTendencyValid.UseVisualStyleBackColor = true;
            // 
            // cbPersonNaturalDeath
            // 
            this.cbPersonNaturalDeath.AutoSize = true;
            this.cbPersonNaturalDeath.Location = new System.Drawing.Point(13, 101);
            this.cbPersonNaturalDeath.Name = "cbPersonNaturalDeath";
            this.cbPersonNaturalDeath.Size = new System.Drawing.Size(72, 16);
            this.cbPersonNaturalDeath.TabIndex = 130;
            this.cbPersonNaturalDeath.Text = "年龄有效";
            this.cbPersonNaturalDeath.UseVisualStyleBackColor = true;
            // 
            // cbPersonDieInChallenge
            // 
            this.cbPersonDieInChallenge.AutoSize = true;
            this.cbPersonDieInChallenge.Location = new System.Drawing.Point(13, 79);
            this.cbPersonDieInChallenge.Name = "cbPersonDieInChallenge";
            this.cbPersonDieInChallenge.Size = new System.Drawing.Size(144, 16);
            this.cbPersonDieInChallenge.TabIndex = 129;
            this.cbPersonDieInChallenge.Text = "武将可能在单挑中死亡";
            this.cbPersonDieInChallenge.UseVisualStyleBackColor = true;
            // 
            // tbTabListDetailLevel
            // 
            this.tbTabListDetailLevel.Location = new System.Drawing.Point(405, 170);
            this.tbTabListDetailLevel.MaxLength = 1;
            this.tbTabListDetailLevel.Name = "tbTabListDetailLevel";
            this.tbTabListDetailLevel.Size = new System.Drawing.Size(27, 21);
            this.tbTabListDetailLevel.TabIndex = 128;
            this.tbTabListDetailLevel.Text = "1";
            // 
            // lblTabListDetailLevel
            // 
            this.lblTabListDetailLevel.AutoSize = true;
            this.lblTabListDetailLevel.Location = new System.Drawing.Point(310, 173);
            this.lblTabListDetailLevel.Name = "lblTabListDetailLevel";
            this.lblTabListDetailLevel.Size = new System.Drawing.Size(89, 12);
            this.lblTabListDetailLevel.TabIndex = 127;
            this.lblTabListDetailLevel.Text = "资料显示详细度";
            // 
            // cbLandArmyCanGoDownWater
            // 
            this.cbLandArmyCanGoDownWater.AutoSize = true;
            this.cbLandArmyCanGoDownWater.Location = new System.Drawing.Point(13, 167);
            this.cbLandArmyCanGoDownWater.Name = "cbLandArmyCanGoDownWater";
            this.cbLandArmyCanGoDownWater.Size = new System.Drawing.Size(132, 16);
            this.cbLandArmyCanGoDownWater.TabIndex = 126;
            this.cbLandArmyCanGoDownWater.Text = "陆上部队可直接下水";
            this.cbLandArmyCanGoDownWater.UseVisualStyleBackColor = true;
            // 
            // cbHardcoreMode
            // 
            this.cbHardcoreMode.AutoSize = true;
            this.cbHardcoreMode.Location = new System.Drawing.Point(13, 299);
            this.cbHardcoreMode.Name = "cbHardcoreMode";
            this.cbHardcoreMode.Size = new System.Drawing.Size(126, 16);
            this.cbHardcoreMode.TabIndex = 125;
            this.cbHardcoreMode.Text = "硬核模式(禁止S/L)";
            this.cbHardcoreMode.UseVisualStyleBackColor = true;
            // 
            // cbEnableCheat
            // 
            this.cbEnableCheat.AutoSize = true;
            this.cbEnableCheat.Location = new System.Drawing.Point(13, 277);
            this.cbEnableCheat.Name = "cbEnableCheat";
            this.cbEnableCheat.Size = new System.Drawing.Size(96, 16);
            this.cbEnableCheat.TabIndex = 124;
            this.cbEnableCheat.Text = "开启作弊功能";
            this.cbEnableCheat.UseVisualStyleBackColor = true;
            // 
            // wujiangYoukenengDuli
            // 
            this.wujiangYoukenengDuli.AutoSize = true;
            this.wujiangYoukenengDuli.Location = new System.Drawing.Point(13, 145);
            this.wujiangYoukenengDuli.Name = "wujiangYoukenengDuli";
            this.wujiangYoukenengDuli.Size = new System.Drawing.Size(108, 16);
            this.wujiangYoukenengDuli.TabIndex = 123;
            this.wujiangYoukenengDuli.Text = "武将有可能独立";
            this.wujiangYoukenengDuli.UseVisualStyleBackColor = true;
            // 
            // checkLiangdaoXitong
            // 
            this.checkLiangdaoXitong.AutoSize = true;
            this.checkLiangdaoXitong.Location = new System.Drawing.Point(13, 13);
            this.checkLiangdaoXitong.Name = "checkLiangdaoXitong";
            this.checkLiangdaoXitong.Size = new System.Drawing.Size(72, 16);
            this.checkLiangdaoXitong.TabIndex = 122;
            this.checkLiangdaoXitong.Text = "粮道系统";
            this.checkLiangdaoXitong.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCustom);
            this.groupBox1.Controls.Add(this.rbVeryhard);
            this.groupBox1.Controls.Add(this.rbHard);
            this.groupBox1.Controls.Add(this.rbNormal);
            this.groupBox1.Controls.Add(this.rbEasy);
            this.groupBox1.Controls.Add(this.rbBeginner);
            this.groupBox1.Location = new System.Drawing.Point(338, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(94, 151);
            this.groupBox1.TabIndex = 121;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "游戏难度";
            // 
            // rbCustom
            // 
            this.rbCustom.AutoSize = true;
            this.rbCustom.Location = new System.Drawing.Point(7, 129);
            this.rbCustom.Name = "rbCustom";
            this.rbCustom.Size = new System.Drawing.Size(47, 16);
            this.rbCustom.TabIndex = 5;
            this.rbCustom.TabStop = true;
            this.rbCustom.Text = "自订";
            this.rbCustom.UseVisualStyleBackColor = true;
            // 
            // rbVeryhard
            // 
            this.rbVeryhard.AutoSize = true;
            this.rbVeryhard.Location = new System.Drawing.Point(7, 107);
            this.rbVeryhard.Name = "rbVeryhard";
            this.rbVeryhard.Size = new System.Drawing.Size(47, 16);
            this.rbVeryhard.TabIndex = 4;
            this.rbVeryhard.TabStop = true;
            this.rbVeryhard.Text = "修罗";
            this.rbVeryhard.UseVisualStyleBackColor = true;
            this.rbVeryhard.CheckedChanged += new System.EventHandler(this.veryhardSelected);
            // 
            // rbHard
            // 
            this.rbHard.AutoSize = true;
            this.rbHard.Location = new System.Drawing.Point(7, 85);
            this.rbHard.Name = "rbHard";
            this.rbHard.Size = new System.Drawing.Size(47, 16);
            this.rbHard.TabIndex = 3;
            this.rbHard.TabStop = true;
            this.rbHard.Text = "超级";
            this.rbHard.UseVisualStyleBackColor = true;
            this.rbHard.CheckedChanged += new System.EventHandler(this.hardSelected);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(6, 63);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(47, 16);
            this.rbNormal.TabIndex = 2;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "上级";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.normalSelected);
            // 
            // rbEasy
            // 
            this.rbEasy.AutoSize = true;
            this.rbEasy.Location = new System.Drawing.Point(6, 41);
            this.rbEasy.Name = "rbEasy";
            this.rbEasy.Size = new System.Drawing.Size(47, 16);
            this.rbEasy.TabIndex = 1;
            this.rbEasy.TabStop = true;
            this.rbEasy.Text = "初级";
            this.rbEasy.UseVisualStyleBackColor = true;
            this.rbEasy.CheckedChanged += new System.EventHandler(this.easySelected);
            // 
            // rbBeginner
            // 
            this.rbBeginner.AutoSize = true;
            this.rbBeginner.Location = new System.Drawing.Point(6, 19);
            this.rbBeginner.Name = "rbBeginner";
            this.rbBeginner.Size = new System.Drawing.Size(47, 16);
            this.rbBeginner.TabIndex = 0;
            this.rbBeginner.TabStop = true;
            this.rbBeginner.Text = "入门";
            this.rbBeginner.UseVisualStyleBackColor = true;
            this.rbBeginner.CheckedChanged += new System.EventHandler(this.beginnerSelected);
            // 
            // cbPermitFactionMerge
            // 
            this.cbPermitFactionMerge.AutoSize = true;
            this.cbPermitFactionMerge.Location = new System.Drawing.Point(13, 189);
            this.cbPermitFactionMerge.Name = "cbPermitFactionMerge";
            this.cbPermitFactionMerge.Size = new System.Drawing.Size(96, 16);
            this.cbPermitFactionMerge.TabIndex = 120;
            this.cbPermitFactionMerge.Text = "容许势力合并";
            this.cbPermitFactionMerge.UseVisualStyleBackColor = true;
            // 
            // cbMilitaryKindSpeedValid
            // 
            this.cbMilitaryKindSpeedValid.AutoSize = true;
            this.cbMilitaryKindSpeedValid.Location = new System.Drawing.Point(13, 57);
            this.cbMilitaryKindSpeedValid.Name = "cbMilitaryKindSpeedValid";
            this.cbMilitaryKindSpeedValid.Size = new System.Drawing.Size(96, 16);
            this.cbMilitaryKindSpeedValid.TabIndex = 119;
            this.cbMilitaryKindSpeedValid.Text = "部队速率有效";
            this.cbMilitaryKindSpeedValid.UseVisualStyleBackColor = true;
            // 
            // cbPopulationRecruitmentLimit
            // 
            this.cbPopulationRecruitmentLimit.AutoSize = true;
            this.cbPopulationRecruitmentLimit.Location = new System.Drawing.Point(13, 211);
            this.cbPopulationRecruitmentLimit.Name = "cbPopulationRecruitmentLimit";
            this.cbPopulationRecruitmentLimit.Size = new System.Drawing.Size(156, 16);
            this.cbPopulationRecruitmentLimit.TabIndex = 118;
            this.cbPopulationRecruitmentLimit.Text = "人口小于兵力时禁止征兵";
            this.cbPopulationRecruitmentLimit.UseVisualStyleBackColor = true;
            // 
            // cbMultipleResource
            // 
            this.cbMultipleResource.AutoSize = true;
            this.cbMultipleResource.Location = new System.Drawing.Point(13, 233);
            this.cbMultipleResource.Name = "cbMultipleResource";
            this.cbMultipleResource.Size = new System.Drawing.Size(96, 16);
            this.cbMultipleResource.TabIndex = 115;
            this.cbMultipleResource.Text = "资源收入加倍";
            this.cbMultipleResource.UseVisualStyleBackColor = true;
            // 
            // cbSkyEye
            // 
            this.cbSkyEye.AutoSize = true;
            this.cbSkyEye.Location = new System.Drawing.Point(13, 255);
            this.cbSkyEye.Name = "cbSkyEye";
            this.cbSkyEye.Size = new System.Drawing.Size(96, 16);
            this.cbSkyEye.TabIndex = 114;
            this.cbSkyEye.Text = "默认开启天眼";
            this.cbSkyEye.UseVisualStyleBackColor = true;
            // 
            // zainanbiaoqian
            // 
            this.zainanbiaoqian.AutoSize = true;
            this.zainanbiaoqian.Location = new System.Drawing.Point(11, 349);
            this.zainanbiaoqian.Name = "zainanbiaoqian";
            this.zainanbiaoqian.Size = new System.Drawing.Size(197, 12);
            this.zainanbiaoqian.TabIndex = 117;
            this.zainanbiaoqian.Text = "灾难发生几率（发生几率为1/此数）";
            // 
            // zainanfashengjilv
            // 
            this.zainanfashengjilv.Location = new System.Drawing.Point(211, 346);
            this.zainanfashengjilv.Name = "zainanfashengjilv";
            this.zainanfashengjilv.Size = new System.Drawing.Size(50, 21);
            this.zainanfashengjilv.TabIndex = 116;
            this.zainanfashengjilv.Text = "3000";
            // 
            // tabPageEnvironment
            // 
            this.tabPageEnvironment.Controls.Add(this.cbFullScreen);
            this.tabPageEnvironment.Controls.Add(this.cbStopToControlOnAttack);
            this.tabPageEnvironment.Controls.Add(this.cbShowChallengeAnimation);
            this.tabPageEnvironment.Controls.Add(this.label59);
            this.tabPageEnvironment.Controls.Add(this.tbAutosaveFrequency);
            this.tabPageEnvironment.Controls.Add(this.tbBattleSpeed);
            this.tabPageEnvironment.Controls.Add(this.lblBattleSpeed);
            this.tabPageEnvironment.Controls.Add(this.lblDialogShowTime);
            this.tabPageEnvironment.Controls.Add(this.tbDialogShowTime);
            this.tabPageEnvironment.Controls.Add(this.cbHintPopulationUnder1000);
            this.tabPageEnvironment.Controls.Add(this.cbHintPopulation);
            this.tabPageEnvironment.Controls.Add(this.lblTroopMoveSpeed);
            this.tabPageEnvironment.Controls.Add(this.tbTroopMoveSpeed);
            this.tabPageEnvironment.Controls.Add(this.cbNoHintOnSmallFacility);
            this.tabPageEnvironment.Controls.Add(this.cbSingleSelectionOneClick);
            this.tabPageEnvironment.Controls.Add(this.cbDrawTroopAnimation);
            this.tabPageEnvironment.Controls.Add(this.cbDrawMapVeil);
            this.tabPageEnvironment.Controls.Add(this.cbPlayBattleSound);
            this.tabPageEnvironment.Controls.Add(this.cbPlayNormalSound);
            this.tabPageEnvironment.Controls.Add(this.cbPlayMusic);
            this.tabPageEnvironment.Controls.Add(this.cbRunWhileNotFocused);
            this.tabPageEnvironment.Controls.Add(this.cbDoAutoSave);
            this.tabPageEnvironment.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnvironment.Name = "tabPageEnvironment";
            this.tabPageEnvironment.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageEnvironment.Size = new System.Drawing.Size(445, 422);
            this.tabPageEnvironment.TabIndex = 0;
            this.tabPageEnvironment.Text = "环境";
            this.tabPageEnvironment.UseVisualStyleBackColor = true;
            // 
            // cbFullScreen
            // 
            this.cbFullScreen.AutoSize = true;
            this.cbFullScreen.Location = new System.Drawing.Point(13, 35);
            this.cbFullScreen.Name = "cbFullScreen";
            this.cbFullScreen.Size = new System.Drawing.Size(48, 16);
            this.cbFullScreen.TabIndex = 119;
            this.cbFullScreen.Text = "全屏";
            this.cbFullScreen.UseVisualStyleBackColor = true;
            // 
            // cbStopToControlOnAttack
            // 
            this.cbStopToControlOnAttack.AutoSize = true;
            this.cbStopToControlOnAttack.Location = new System.Drawing.Point(13, 167);
            this.cbStopToControlOnAttack.Name = "cbStopToControlOnAttack";
            this.cbStopToControlOnAttack.Size = new System.Drawing.Size(120, 16);
            this.cbStopToControlOnAttack.TabIndex = 118;
            this.cbStopToControlOnAttack.Text = "被攻击时暂停游戏";
            this.cbStopToControlOnAttack.UseVisualStyleBackColor = true;
            // 
            // cbShowChallengeAnimation
            // 
            this.cbShowChallengeAnimation.AutoSize = true;
            this.cbShowChallengeAnimation.Location = new System.Drawing.Point(13, 299);
            this.cbShowChallengeAnimation.Name = "cbShowChallengeAnimation";
            this.cbShowChallengeAnimation.Size = new System.Drawing.Size(72, 16);
            this.cbShowChallengeAnimation.TabIndex = 117;
            this.cbShowChallengeAnimation.Text = "单挑演示";
            this.cbShowChallengeAnimation.UseVisualStyleBackColor = true;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(130, 278);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(29, 12);
            this.label59.TabIndex = 115;
            this.label59.Text = "分钟";
            // 
            // tbAutosaveFrequency
            // 
            this.tbAutosaveFrequency.Location = new System.Drawing.Point(106, 275);
            this.tbAutosaveFrequency.MaxLength = 2;
            this.tbAutosaveFrequency.Name = "tbAutosaveFrequency";
            this.tbAutosaveFrequency.Size = new System.Drawing.Size(27, 21);
            this.tbAutosaveFrequency.TabIndex = 114;
            this.tbAutosaveFrequency.Text = "30";
            // 
            // tbBattleSpeed
            // 
            this.tbBattleSpeed.Location = new System.Drawing.Point(69, 368);
            this.tbBattleSpeed.MaxLength = 2;
            this.tbBattleSpeed.Name = "tbBattleSpeed";
            this.tbBattleSpeed.Size = new System.Drawing.Size(27, 21);
            this.tbBattleSpeed.TabIndex = 108;
            this.tbBattleSpeed.Text = "1";
            // 
            // lblBattleSpeed
            // 
            this.lblBattleSpeed.AutoSize = true;
            this.lblBattleSpeed.Location = new System.Drawing.Point(10, 371);
            this.lblBattleSpeed.Name = "lblBattleSpeed";
            this.lblBattleSpeed.Size = new System.Drawing.Size(53, 12);
            this.lblBattleSpeed.TabIndex = 107;
            this.lblBattleSpeed.Text = "战斗速度";
            // 
            // lblDialogShowTime
            // 
            this.lblDialogShowTime.AutoSize = true;
            this.lblDialogShowTime.Location = new System.Drawing.Point(11, 346);
            this.lblDialogShowTime.Name = "lblDialogShowTime";
            this.lblDialogShowTime.Size = new System.Drawing.Size(89, 12);
            this.lblDialogShowTime.TabIndex = 102;
            this.lblDialogShowTime.Text = "对话窗显示时间";
            // 
            // tbDialogShowTime
            // 
            this.tbDialogShowTime.Location = new System.Drawing.Point(106, 343);
            this.tbDialogShowTime.MaxLength = 2;
            this.tbDialogShowTime.Name = "tbDialogShowTime";
            this.tbDialogShowTime.Size = new System.Drawing.Size(27, 21);
            this.tbDialogShowTime.TabIndex = 101;
            this.tbDialogShowTime.Text = "0";
            // 
            // cbHintPopulationUnder1000
            // 
            this.cbHintPopulationUnder1000.AutoSize = true;
            this.cbHintPopulationUnder1000.Location = new System.Drawing.Point(13, 255);
            this.cbHintPopulationUnder1000.Name = "cbHintPopulationUnder1000";
            this.cbHintPopulationUnder1000.Size = new System.Drawing.Size(168, 16);
            this.cbHintPopulationUnder1000.TabIndex = 13;
            this.cbHintPopulationUnder1000.Text = "提示1000人以下的人口迁移";
            this.cbHintPopulationUnder1000.UseVisualStyleBackColor = true;
            // 
            // cbHintPopulation
            // 
            this.cbHintPopulation.AutoSize = true;
            this.cbHintPopulation.Location = new System.Drawing.Point(13, 233);
            this.cbHintPopulation.Name = "cbHintPopulation";
            this.cbHintPopulation.Size = new System.Drawing.Size(108, 16);
            this.cbHintPopulation.TabIndex = 12;
            this.cbHintPopulation.Text = "提示人口的迁移";
            this.cbHintPopulation.UseVisualStyleBackColor = true;
            // 
            // lblTroopMoveSpeed
            // 
            this.lblTroopMoveSpeed.AutoSize = true;
            this.lblTroopMoveSpeed.Location = new System.Drawing.Point(11, 323);
            this.lblTroopMoveSpeed.Name = "lblTroopMoveSpeed";
            this.lblTroopMoveSpeed.Size = new System.Drawing.Size(185, 12);
            this.lblTroopMoveSpeed.TabIndex = 11;
            this.lblTroopMoveSpeed.Text = "部队移动速度（数字越大则越慢）";
            // 
            // tbTroopMoveSpeed
            // 
            this.tbTroopMoveSpeed.Location = new System.Drawing.Point(202, 320);
            this.tbTroopMoveSpeed.MaxLength = 1;
            this.tbTroopMoveSpeed.Name = "tbTroopMoveSpeed";
            this.tbTroopMoveSpeed.Size = new System.Drawing.Size(27, 21);
            this.tbTroopMoveSpeed.TabIndex = 10;
            this.tbTroopMoveSpeed.Text = "0";
            // 
            // cbNoHintOnSmallFacility
            // 
            this.cbNoHintOnSmallFacility.AutoSize = true;
            this.cbNoHintOnSmallFacility.Location = new System.Drawing.Point(13, 211);
            this.cbNoHintOnSmallFacility.Name = "cbNoHintOnSmallFacility";
            this.cbNoHintOnSmallFacility.Size = new System.Drawing.Size(168, 16);
            this.cbNoHintOnSmallFacility.TabIndex = 9;
            this.cbNoHintOnSmallFacility.Text = "不提示小型设施的建设完成";
            this.cbNoHintOnSmallFacility.UseVisualStyleBackColor = true;
            // 
            // cbSingleSelectionOneClick
            // 
            this.cbSingleSelectionOneClick.AutoSize = true;
            this.cbSingleSelectionOneClick.Location = new System.Drawing.Point(13, 189);
            this.cbSingleSelectionOneClick.Name = "cbSingleSelectionOneClick";
            this.cbSingleSelectionOneClick.Size = new System.Drawing.Size(216, 16);
            this.cbSingleSelectionOneClick.TabIndex = 8;
            this.cbSingleSelectionOneClick.Text = "从某列表中选择单一项时单击即确定";
            this.cbSingleSelectionOneClick.UseVisualStyleBackColor = true;
            // 
            // cbDrawTroopAnimation
            // 
            this.cbDrawTroopAnimation.AutoSize = true;
            this.cbDrawTroopAnimation.Location = new System.Drawing.Point(13, 145);
            this.cbDrawTroopAnimation.Name = "cbDrawTroopAnimation";
            this.cbDrawTroopAnimation.Size = new System.Drawing.Size(96, 16);
            this.cbDrawTroopAnimation.TabIndex = 5;
            this.cbDrawTroopAnimation.Text = "显示部队动画";
            this.cbDrawTroopAnimation.UseVisualStyleBackColor = true;
            // 
            // cbDrawMapVeil
            // 
            this.cbDrawMapVeil.AutoSize = true;
            this.cbDrawMapVeil.Location = new System.Drawing.Point(13, 123);
            this.cbDrawMapVeil.Name = "cbDrawMapVeil";
            this.cbDrawMapVeil.Size = new System.Drawing.Size(96, 16);
            this.cbDrawMapVeil.TabIndex = 4;
            this.cbDrawMapVeil.Text = "显示地图烟幕";
            this.cbDrawMapVeil.UseVisualStyleBackColor = true;
            // 
            // cbPlayBattleSound
            // 
            this.cbPlayBattleSound.AutoSize = true;
            this.cbPlayBattleSound.Location = new System.Drawing.Point(13, 101);
            this.cbPlayBattleSound.Name = "cbPlayBattleSound";
            this.cbPlayBattleSound.Size = new System.Drawing.Size(96, 16);
            this.cbPlayBattleSound.TabIndex = 3;
            this.cbPlayBattleSound.Text = "播放战斗音效";
            this.cbPlayBattleSound.UseVisualStyleBackColor = true;
            // 
            // cbPlayNormalSound
            // 
            this.cbPlayNormalSound.AutoSize = true;
            this.cbPlayNormalSound.Location = new System.Drawing.Point(13, 79);
            this.cbPlayNormalSound.Name = "cbPlayNormalSound";
            this.cbPlayNormalSound.Size = new System.Drawing.Size(96, 16);
            this.cbPlayNormalSound.TabIndex = 2;
            this.cbPlayNormalSound.Text = "播放一般音效";
            this.cbPlayNormalSound.UseVisualStyleBackColor = true;
            // 
            // cbPlayMusic
            // 
            this.cbPlayMusic.AutoSize = true;
            this.cbPlayMusic.Location = new System.Drawing.Point(13, 57);
            this.cbPlayMusic.Name = "cbPlayMusic";
            this.cbPlayMusic.Size = new System.Drawing.Size(72, 16);
            this.cbPlayMusic.TabIndex = 1;
            this.cbPlayMusic.Text = "播放音乐";
            this.cbPlayMusic.UseVisualStyleBackColor = true;
            // 
            // cbRunWhileNotFocused
            // 
            this.cbRunWhileNotFocused.AutoSize = true;
            this.cbRunWhileNotFocused.Location = new System.Drawing.Point(13, 13);
            this.cbRunWhileNotFocused.Name = "cbRunWhileNotFocused";
            this.cbRunWhileNotFocused.Size = new System.Drawing.Size(180, 16);
            this.cbRunWhileNotFocused.TabIndex = 0;
            this.cbRunWhileNotFocused.Text = "游戏窗体失去焦点时继续运行";
            this.cbRunWhileNotFocused.UseVisualStyleBackColor = true;
            // 
            // cbDoAutoSave
            // 
            this.cbDoAutoSave.AutoSize = true;
            this.cbDoAutoSave.Location = new System.Drawing.Point(13, 277);
            this.cbDoAutoSave.Name = "cbDoAutoSave";
            this.cbDoAutoSave.Size = new System.Drawing.Size(96, 16);
            this.cbDoAutoSave.TabIndex = 100;
            this.cbDoAutoSave.Text = "自动存档密度";
            this.cbDoAutoSave.UseVisualStyleBackColor = true;
            // 
            // tabPagePerson
            // 
            this.tabPagePerson.Controls.Add(this.lblChildrenAvailableAge);
            this.tabPagePerson.Controls.Add(this.tbChildrenAvailableAge);
            this.tabPagePerson.Controls.Add(this.cbEnablePersonRelations);
            this.tabPagePerson.Controls.Add(this.tbCreatedOfficerAbilityFactor);
            this.tabPagePerson.Controls.Add(this.lblCreatedOfficerAbilityFactor);
            this.tabPagePerson.Controls.Add(this.lblOfficerChildrenLimit);
            this.tabPagePerson.Controls.Add(this.tbOfficerChildrenLimit);
            this.tabPagePerson.Controls.Add(this.lblLearnTitleSuccessRate);
            this.tabPagePerson.Controls.Add(this.tbLearnTitleSuccessRate);
            this.tabPagePerson.Controls.Add(this.lblLearnStuntSuccessRate);
            this.tabPagePerson.Controls.Add(this.tbLearnStuntSuccessRate);
            this.tabPagePerson.Controls.Add(this.lblLearnSkillSuccessRate);
            this.tabPagePerson.Controls.Add(this.tbLearnSkillSuccessRate);
            this.tabPagePerson.Controls.Add(this.lblTirednessDecrease);
            this.tabPagePerson.Controls.Add(this.tbTirednessDecrease);
            this.tabPagePerson.Controls.Add(this.lblTirednessIncrease);
            this.tabPagePerson.Controls.Add(this.tbTirednessIncrease);
            this.tabPagePerson.Controls.Add(this.lblMaxAbility);
            this.tabPagePerson.Controls.Add(this.tbMaxAbility);
            this.tabPagePerson.Controls.Add(this.cbLockChildrenLoyalty);
            this.tabPagePerson.Controls.Add(this.lblMaxExperience);
            this.tabPagePerson.Controls.Add(this.tbMaxExperience);
            this.tabPagePerson.Controls.Add(this.lblFollowedLeaderDefenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.tbFollowedLeaderDefenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.lblFollowedLeaderOffenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.tbFollowedLeaderOffenceRateIncrement);
            this.tabPagePerson.Controls.Add(this.lblLearnTitleDays);
            this.tabPagePerson.Controls.Add(this.tbLearnTitleDays);
            this.tabPagePerson.Controls.Add(this.lblLearnStuntDays);
            this.tabPagePerson.Controls.Add(this.tbLearnStuntDays);
            this.tabPagePerson.Controls.Add(this.lblLearnSkillDays);
            this.tabPagePerson.Controls.Add(this.tbLearnSkillDays);
            this.tabPagePerson.Controls.Add(this.lblSearchDays);
            this.tabPagePerson.Controls.Add(this.tbSearchDays);
            this.tabPagePerson.Controls.Add(this.lblFindTreasureChance);
            this.tabPagePerson.Controls.Add(this.tbFindTreasureChance);
            this.tabPagePerson.Controls.Add(this.cbPlayerPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbAdditionalPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbCommonPersonAvailable);
            this.tabPagePerson.Controls.Add(this.cbCreateChildrenIgnoreLimit);
            this.tabPagePerson.Location = new System.Drawing.Point(4, 22);
            this.tabPagePerson.Name = "tabPagePerson";
            this.tabPagePerson.Padding = new System.Windows.Forms.Padding(10);
            this.tabPagePerson.Size = new System.Drawing.Size(445, 422);
            this.tabPagePerson.TabIndex = 1;
            this.tabPagePerson.Text = "人物";
            this.tabPagePerson.UseVisualStyleBackColor = true;
            // 
            // lblChildrenAvailableAge
            // 
            this.lblChildrenAvailableAge.AutoSize = true;
            this.lblChildrenAvailableAge.Location = new System.Drawing.Point(168, 300);
            this.lblChildrenAvailableAge.Name = "lblChildrenAvailableAge";
            this.lblChildrenAvailableAge.Size = new System.Drawing.Size(77, 12);
            this.lblChildrenAvailableAge.TabIndex = 150;
            this.lblChildrenAvailableAge.Text = "子女登场年龄";
            // 
            // tbChildrenAvailableAge
            // 
            this.tbChildrenAvailableAge.Location = new System.Drawing.Point(251, 297);
            this.tbChildrenAvailableAge.Name = "tbChildrenAvailableAge";
            this.tbChildrenAvailableAge.Size = new System.Drawing.Size(71, 21);
            this.tbChildrenAvailableAge.TabIndex = 149;
            // 
            // cbEnablePersonRelations
            // 
            this.cbEnablePersonRelations.AutoSize = true;
            this.cbEnablePersonRelations.Location = new System.Drawing.Point(13, 353);
            this.cbEnablePersonRelations.Name = "cbEnablePersonRelations";
            this.cbEnablePersonRelations.Size = new System.Drawing.Size(144, 16);
            this.cbEnablePersonRelations.TabIndex = 148;
            this.cbEnablePersonRelations.Text = "武将关系会随游戏调整";
            // 
            // tbCreatedOfficerAbilityFactor
            // 
            this.tbCreatedOfficerAbilityFactor.Location = new System.Drawing.Point(114, 325);
            this.tbCreatedOfficerAbilityFactor.Name = "tbCreatedOfficerAbilityFactor";
            this.tbCreatedOfficerAbilityFactor.Size = new System.Drawing.Size(51, 21);
            this.tbCreatedOfficerAbilityFactor.TabIndex = 147;
            this.tbCreatedOfficerAbilityFactor.Text = "0.8";
            // 
            // lblCreatedOfficerAbilityFactor
            // 
            this.lblCreatedOfficerAbilityFactor.AutoSize = true;
            this.lblCreatedOfficerAbilityFactor.Location = new System.Drawing.Point(11, 328);
            this.lblCreatedOfficerAbilityFactor.Name = "lblCreatedOfficerAbilityFactor";
            this.lblCreatedOfficerAbilityFactor.Size = new System.Drawing.Size(101, 12);
            this.lblCreatedOfficerAbilityFactor.TabIndex = 146;
            this.lblCreatedOfficerAbilityFactor.Text = "生成武将能力乘数";
            // 
            // lblOfficerChildrenLimit
            // 
            this.lblOfficerChildrenLimit.AutoSize = true;
            this.lblOfficerChildrenLimit.Location = new System.Drawing.Point(11, 300);
            this.lblOfficerChildrenLimit.Name = "lblOfficerChildrenLimit";
            this.lblOfficerChildrenLimit.Size = new System.Drawing.Size(77, 12);
            this.lblOfficerChildrenLimit.TabIndex = 41;
            this.lblOfficerChildrenLimit.Text = "武將子女上限";
            // 
            // tbOfficerChildrenLimit
            // 
            this.tbOfficerChildrenLimit.Location = new System.Drawing.Point(94, 297);
            this.tbOfficerChildrenLimit.Name = "tbOfficerChildrenLimit";
            this.tbOfficerChildrenLimit.Size = new System.Drawing.Size(71, 21);
            this.tbOfficerChildrenLimit.TabIndex = 40;
            // 
            // lblLearnTitleSuccessRate
            // 
            this.lblLearnTitleSuccessRate.AutoSize = true;
            this.lblLearnTitleSuccessRate.Location = new System.Drawing.Point(180, 213);
            this.lblLearnTitleSuccessRate.Name = "lblLearnTitleSuccessRate";
            this.lblLearnTitleSuccessRate.Size = new System.Drawing.Size(65, 12);
            this.lblLearnTitleSuccessRate.TabIndex = 39;
            this.lblLearnTitleSuccessRate.Text = "成功率参数";
            // 
            // tbLearnTitleSuccessRate
            // 
            this.tbLearnTitleSuccessRate.Location = new System.Drawing.Point(251, 210);
            this.tbLearnTitleSuccessRate.Name = "tbLearnTitleSuccessRate";
            this.tbLearnTitleSuccessRate.Size = new System.Drawing.Size(71, 21);
            this.tbLearnTitleSuccessRate.TabIndex = 38;
            // 
            // lblLearnStuntSuccessRate
            // 
            this.lblLearnStuntSuccessRate.AutoSize = true;
            this.lblLearnStuntSuccessRate.Location = new System.Drawing.Point(180, 185);
            this.lblLearnStuntSuccessRate.Name = "lblLearnStuntSuccessRate";
            this.lblLearnStuntSuccessRate.Size = new System.Drawing.Size(65, 12);
            this.lblLearnStuntSuccessRate.TabIndex = 37;
            this.lblLearnStuntSuccessRate.Text = "成功率参数";
            // 
            // tbLearnStuntSuccessRate
            // 
            this.tbLearnStuntSuccessRate.Location = new System.Drawing.Point(251, 182);
            this.tbLearnStuntSuccessRate.Name = "tbLearnStuntSuccessRate";
            this.tbLearnStuntSuccessRate.Size = new System.Drawing.Size(71, 21);
            this.tbLearnStuntSuccessRate.TabIndex = 36;
            // 
            // lblLearnSkillSuccessRate
            // 
            this.lblLearnSkillSuccessRate.AutoSize = true;
            this.lblLearnSkillSuccessRate.Location = new System.Drawing.Point(180, 157);
            this.lblLearnSkillSuccessRate.Name = "lblLearnSkillSuccessRate";
            this.lblLearnSkillSuccessRate.Size = new System.Drawing.Size(65, 12);
            this.lblLearnSkillSuccessRate.TabIndex = 35;
            this.lblLearnSkillSuccessRate.Text = "成功率参数";
            // 
            // tbLearnSkillSuccessRate
            // 
            this.tbLearnSkillSuccessRate.Location = new System.Drawing.Point(251, 154);
            this.tbLearnSkillSuccessRate.Name = "tbLearnSkillSuccessRate";
            this.tbLearnSkillSuccessRate.Size = new System.Drawing.Size(71, 21);
            this.tbLearnSkillSuccessRate.TabIndex = 34;
            // 
            // lblTirednessDecrease
            // 
            this.lblTirednessDecrease.AutoSize = true;
            this.lblTirednessDecrease.Location = new System.Drawing.Point(294, 100);
            this.lblTirednessDecrease.Name = "lblTirednessDecrease";
            this.lblTirednessDecrease.Size = new System.Drawing.Size(65, 12);
            this.lblTirednessDecrease.TabIndex = 32;
            this.lblTirednessDecrease.Text = "疲累度下降";
            // 
            // tbTirednessDecrease
            // 
            this.tbTirednessDecrease.Location = new System.Drawing.Point(361, 97);
            this.tbTirednessDecrease.Name = "tbTirednessDecrease";
            this.tbTirednessDecrease.Size = new System.Drawing.Size(71, 21);
            this.tbTirednessDecrease.TabIndex = 31;
            // 
            // lblTirednessIncrease
            // 
            this.lblTirednessIncrease.AutoSize = true;
            this.lblTirednessIncrease.Location = new System.Drawing.Point(294, 72);
            this.lblTirednessIncrease.Name = "lblTirednessIncrease";
            this.lblTirednessIncrease.Size = new System.Drawing.Size(65, 12);
            this.lblTirednessIncrease.TabIndex = 30;
            this.lblTirednessIncrease.Text = "疲累度增长";
            // 
            // tbTirednessIncrease
            // 
            this.tbTirednessIncrease.Location = new System.Drawing.Point(361, 69);
            this.tbTirednessIncrease.Name = "tbTirednessIncrease";
            this.tbTirednessIncrease.Size = new System.Drawing.Size(71, 21);
            this.tbTirednessIncrease.TabIndex = 29;
            // 
            // lblMaxAbility
            // 
            this.lblMaxAbility.AutoSize = true;
            this.lblMaxAbility.Location = new System.Drawing.Point(306, 44);
            this.lblMaxAbility.Name = "lblMaxAbility";
            this.lblMaxAbility.Size = new System.Drawing.Size(53, 12);
            this.lblMaxAbility.TabIndex = 28;
            this.lblMaxAbility.Text = "最大能力";
            // 
            // tbMaxAbility
            // 
            this.tbMaxAbility.Location = new System.Drawing.Point(361, 41);
            this.tbMaxAbility.Name = "tbMaxAbility";
            this.tbMaxAbility.Size = new System.Drawing.Size(71, 21);
            this.tbMaxAbility.TabIndex = 27;
            // 
            // cbLockChildrenLoyalty
            // 
            this.cbLockChildrenLoyalty.AutoSize = true;
            this.cbLockChildrenLoyalty.Location = new System.Drawing.Point(13, 79);
            this.cbLockChildrenLoyalty.Name = "cbLockChildrenLoyalty";
            this.cbLockChildrenLoyalty.Size = new System.Drawing.Size(132, 16);
            this.cbLockChildrenLoyalty.TabIndex = 26;
            this.cbLockChildrenLoyalty.Text = "生下的子女绝对忠诚";
            // 
            // lblMaxExperience
            // 
            this.lblMaxExperience.AutoSize = true;
            this.lblMaxExperience.Location = new System.Drawing.Point(306, 17);
            this.lblMaxExperience.Name = "lblMaxExperience";
            this.lblMaxExperience.Size = new System.Drawing.Size(53, 12);
            this.lblMaxExperience.TabIndex = 25;
            this.lblMaxExperience.Text = "最大经验";
            // 
            // tbMaxExperience
            // 
            this.tbMaxExperience.Location = new System.Drawing.Point(361, 13);
            this.tbMaxExperience.Name = "tbMaxExperience";
            this.tbMaxExperience.Size = new System.Drawing.Size(71, 21);
            this.tbMaxExperience.TabIndex = 24;
            // 
            // lblFollowedLeaderDefenceRateIncrement
            // 
            this.lblFollowedLeaderDefenceRateIncrement.AutoSize = true;
            this.lblFollowedLeaderDefenceRateIncrement.Location = new System.Drawing.Point(11, 272);
            this.lblFollowedLeaderDefenceRateIncrement.Name = "lblFollowedLeaderDefenceRateIncrement";
            this.lblFollowedLeaderDefenceRateIncrement.Size = new System.Drawing.Size(113, 12);
            this.lblFollowedLeaderDefenceRateIncrement.TabIndex = 23;
            this.lblFollowedLeaderDefenceRateIncrement.Text = "追随将领防御力加成";
            // 
            // tbFollowedLeaderDefenceRateIncrement
            // 
            this.tbFollowedLeaderDefenceRateIncrement.Location = new System.Drawing.Point(128, 269);
            this.tbFollowedLeaderDefenceRateIncrement.Name = "tbFollowedLeaderDefenceRateIncrement";
            this.tbFollowedLeaderDefenceRateIncrement.Size = new System.Drawing.Size(71, 21);
            this.tbFollowedLeaderDefenceRateIncrement.TabIndex = 22;
            // 
            // lblFollowedLeaderOffenceRateIncrement
            // 
            this.lblFollowedLeaderOffenceRateIncrement.AutoSize = true;
            this.lblFollowedLeaderOffenceRateIncrement.Location = new System.Drawing.Point(11, 245);
            this.lblFollowedLeaderOffenceRateIncrement.Name = "lblFollowedLeaderOffenceRateIncrement";
            this.lblFollowedLeaderOffenceRateIncrement.Size = new System.Drawing.Size(113, 12);
            this.lblFollowedLeaderOffenceRateIncrement.TabIndex = 21;
            this.lblFollowedLeaderOffenceRateIncrement.Text = "追随将领攻击力加成";
            // 
            // tbFollowedLeaderOffenceRateIncrement
            // 
            this.tbFollowedLeaderOffenceRateIncrement.Location = new System.Drawing.Point(128, 242);
            this.tbFollowedLeaderOffenceRateIncrement.Name = "tbFollowedLeaderOffenceRateIncrement";
            this.tbFollowedLeaderOffenceRateIncrement.Size = new System.Drawing.Size(71, 21);
            this.tbFollowedLeaderOffenceRateIncrement.TabIndex = 20;
            // 
            // lblLearnTitleDays
            // 
            this.lblLearnTitleDays.AutoSize = true;
            this.lblLearnTitleDays.Location = new System.Drawing.Point(11, 213);
            this.lblLearnTitleDays.Name = "lblLearnTitleDays";
            this.lblLearnTitleDays.Size = new System.Drawing.Size(77, 12);
            this.lblLearnTitleDays.TabIndex = 19;
            this.lblLearnTitleDays.Text = "修习称号时间";
            // 
            // tbLearnTitleDays
            // 
            this.tbLearnTitleDays.Location = new System.Drawing.Point(94, 210);
            this.tbLearnTitleDays.Name = "tbLearnTitleDays";
            this.tbLearnTitleDays.Size = new System.Drawing.Size(71, 21);
            this.tbLearnTitleDays.TabIndex = 18;
            // 
            // lblLearnStuntDays
            // 
            this.lblLearnStuntDays.AutoSize = true;
            this.lblLearnStuntDays.Location = new System.Drawing.Point(11, 185);
            this.lblLearnStuntDays.Name = "lblLearnStuntDays";
            this.lblLearnStuntDays.Size = new System.Drawing.Size(77, 12);
            this.lblLearnStuntDays.TabIndex = 17;
            this.lblLearnStuntDays.Text = "修习特技时间";
            // 
            // tbLearnStuntDays
            // 
            this.tbLearnStuntDays.Location = new System.Drawing.Point(94, 182);
            this.tbLearnStuntDays.Name = "tbLearnStuntDays";
            this.tbLearnStuntDays.Size = new System.Drawing.Size(71, 21);
            this.tbLearnStuntDays.TabIndex = 16;
            // 
            // lblLearnSkillDays
            // 
            this.lblLearnSkillDays.AutoSize = true;
            this.lblLearnSkillDays.Location = new System.Drawing.Point(11, 157);
            this.lblLearnSkillDays.Name = "lblLearnSkillDays";
            this.lblLearnSkillDays.Size = new System.Drawing.Size(77, 12);
            this.lblLearnSkillDays.TabIndex = 15;
            this.lblLearnSkillDays.Text = "修习技能时间";
            // 
            // tbLearnSkillDays
            // 
            this.tbLearnSkillDays.Location = new System.Drawing.Point(94, 154);
            this.tbLearnSkillDays.Name = "tbLearnSkillDays";
            this.tbLearnSkillDays.Size = new System.Drawing.Size(71, 21);
            this.tbLearnSkillDays.TabIndex = 14;
            // 
            // lblSearchDays
            // 
            this.lblSearchDays.AutoSize = true;
            this.lblSearchDays.Location = new System.Drawing.Point(220, 245);
            this.lblSearchDays.Name = "lblSearchDays";
            this.lblSearchDays.Size = new System.Drawing.Size(53, 12);
            this.lblSearchDays.TabIndex = 51;
            this.lblSearchDays.Text = "搜索时间";
            // 
            // tbSearchDays
            // 
            this.tbSearchDays.Location = new System.Drawing.Point(278, 242);
            this.tbSearchDays.Name = "tbSearchDays";
            this.tbSearchDays.Size = new System.Drawing.Size(71, 21);
            this.tbSearchDays.TabIndex = 50;
            // 
            // lblFindTreasureChance
            // 
            this.lblFindTreasureChance.AutoSize = true;
            this.lblFindTreasureChance.Location = new System.Drawing.Point(11, 129);
            this.lblFindTreasureChance.Name = "lblFindTreasureChance";
            this.lblFindTreasureChance.Size = new System.Drawing.Size(209, 12);
            this.lblFindTreasureChance.TabIndex = 13;
            this.lblFindTreasureChance.Text = "宝物发现概率（数字越大越容易发现）";
            // 
            // tbFindTreasureChance
            // 
            this.tbFindTreasureChance.Location = new System.Drawing.Point(226, 126);
            this.tbFindTreasureChance.MaxLength = 2;
            this.tbFindTreasureChance.Name = "tbFindTreasureChance";
            this.tbFindTreasureChance.Size = new System.Drawing.Size(25, 21);
            this.tbFindTreasureChance.TabIndex = 12;
            this.tbFindTreasureChance.Text = "10";
            // 
            // cbPlayerPersonAvailable
            // 
            this.cbPlayerPersonAvailable.AutoSize = true;
            this.cbPlayerPersonAvailable.Location = new System.Drawing.Point(13, 57);
            this.cbPlayerPersonAvailable.Name = "cbPlayerPersonAvailable";
            this.cbPlayerPersonAvailable.Size = new System.Drawing.Size(174, 16);
            this.cbPlayerPersonAvailable.TabIndex = 2;
            this.cbPlayerPersonAvailable.Text = "玩家人物登场（9000-9999）";
            this.cbPlayerPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbAdditionalPersonAvailable
            // 
            this.cbAdditionalPersonAvailable.AutoSize = true;
            this.cbAdditionalPersonAvailable.Location = new System.Drawing.Point(13, 35);
            this.cbAdditionalPersonAvailable.Name = "cbAdditionalPersonAvailable";
            this.cbAdditionalPersonAvailable.Size = new System.Drawing.Size(174, 16);
            this.cbAdditionalPersonAvailable.TabIndex = 1;
            this.cbAdditionalPersonAvailable.Text = "附加人物登场（8000-8999）";
            this.cbAdditionalPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbCommonPersonAvailable
            // 
            this.cbCommonPersonAvailable.AutoSize = true;
            this.cbCommonPersonAvailable.Location = new System.Drawing.Point(13, 13);
            this.cbCommonPersonAvailable.Name = "cbCommonPersonAvailable";
            this.cbCommonPersonAvailable.Size = new System.Drawing.Size(96, 16);
            this.cbCommonPersonAvailable.TabIndex = 0;
            this.cbCommonPersonAvailable.Text = "一般人物登场";
            this.cbCommonPersonAvailable.UseVisualStyleBackColor = true;
            // 
            // cbCreateChildrenIgnoreLimit
            // 
            this.cbCreateChildrenIgnoreLimit.AutoSize = true;
            this.cbCreateChildrenIgnoreLimit.Location = new System.Drawing.Point(13, 101);
            this.cbCreateChildrenIgnoreLimit.Name = "cbCreateChildrenIgnoreLimit";
            this.cbCreateChildrenIgnoreLimit.Size = new System.Drawing.Size(156, 16);
            this.cbCreateChildrenIgnoreLimit.TabIndex = 10;
            this.cbCreateChildrenIgnoreLimit.Text = "虚拟子嗣能力可超越上限";
            // 
            // tabPageParameter
            // 
            this.tabPageParameter.Controls.Add(this.lblMaxMilitaryExperience);
            this.tabPageParameter.Controls.Add(this.tbMaxMilitaryExperience);
            this.tabPageParameter.Controls.Add(this.lblMilitaryPopulationReloadQuantity);
            this.tabPageParameter.Controls.Add(this.tbMilitaryPopulationReloadQuantity);
            this.tabPageParameter.Controls.Add(this.lblMilitaryPopulationCap);
            this.tabPageParameter.Controls.Add(this.tbMilitaryPopulationCap);
            this.tabPageParameter.Controls.Add(this.lblJailBreakArchitectureCost);
            this.tabPageParameter.Controls.Add(this.tbJailBreakArchitectureCost);
            this.tabPageParameter.Controls.Add(this.lblLeadershipOffenceRate);
            this.tabPageParameter.Controls.Add(this.tbLeadershipOffenceRate);
            this.tabPageParameter.Controls.Add(this.lblTechniquePointMultiple);
            this.tabPageParameter.Controls.Add(this.tbTechniquePointMultiple);
            this.tabPageParameter.Controls.Add(this.lblFireDamageScale);
            this.tabPageParameter.Controls.Add(this.tbFireDamageScale);
            this.tabPageParameter.Controls.Add(this.lblSurroundArchitectureDominationUnit);
            this.tabPageParameter.Controls.Add(this.tbSurroundArchitectureDominationUnit);
            this.tabPageParameter.Controls.Add(this.lblFoodToFundDivisor);
            this.tabPageParameter.Controls.Add(this.tbFoodToFundDivisor);
            this.tabPageParameter.Controls.Add(this.lblFundToFoodMultiple);
            this.tabPageParameter.Controls.Add(this.tbFundToFoodMultiple);
            this.tabPageParameter.Controls.Add(this.lblSellFoodCommerce);
            this.tabPageParameter.Controls.Add(this.tbSellFoodCommerce);
            this.tabPageParameter.Controls.Add(this.lblBuyFoodAgriculture);
            this.tabPageParameter.Controls.Add(this.tbBuyFoodAgriculture);
            this.tabPageParameter.Controls.Add(this.lblGossipArchitectureCost);
            this.tabPageParameter.Controls.Add(this.tbGossipArchitectureCost);
            this.tabPageParameter.Controls.Add(this.lblInstigateArchitectureCost);
            this.tabPageParameter.Controls.Add(this.tbInstigateArchitectureCost);
            this.tabPageParameter.Controls.Add(this.lblDestroyArchitectureCost);
            this.tabPageParameter.Controls.Add(this.tbDestroyArchitectureCost);
            this.tabPageParameter.Controls.Add(this.lblRewardPersonCost);
            this.tabPageParameter.Controls.Add(this.tbRewardPersonCost);
            this.tabPageParameter.Controls.Add(this.lblConvincePersonCost);
            this.tabPageParameter.Controls.Add(this.tbConvincePersonCost);
            this.tabPageParameter.Controls.Add(this.lblChangeCapitalCost);
            this.tabPageParameter.Controls.Add(this.tbChangeCapitalCost);
            this.tabPageParameter.Controls.Add(this.lblRecruitmentMorale);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentMorale);
            this.tabPageParameter.Controls.Add(this.lblRecruitmentDomination);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentDomination);
            this.tabPageParameter.Controls.Add(this.lblRecruitmentFundCost);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentFundCost);
            this.tabPageParameter.Controls.Add(this.lblInternalFundCost);
            this.tabPageParameter.Controls.Add(this.tbInternalFundCost);
            this.tabPageParameter.Controls.Add(this.lblDefaultPopulationDevelopingRate);
            this.tabPageParameter.Controls.Add(this.tbDefaultPopulationDevelopingRate);
            this.tabPageParameter.Controls.Add(this.lblArchitectureDamageRate);
            this.tabPageParameter.Controls.Add(this.tbArchitectureDamageRate);
            this.tabPageParameter.Controls.Add(this.lblTroopDamageRate);
            this.tabPageParameter.Controls.Add(this.tbTroopDamageRate);
            this.tabPageParameter.Controls.Add(this.lblFoodRate);
            this.tabPageParameter.Controls.Add(this.tbFoodRate);
            this.tabPageParameter.Controls.Add(this.lblFundRate);
            this.tabPageParameter.Controls.Add(this.tbFundRate);
            this.tabPageParameter.Controls.Add(this.lblRecruitmentRate);
            this.tabPageParameter.Controls.Add(this.tbRecruitmentRate);
            this.tabPageParameter.Controls.Add(this.lblTrainingRate);
            this.tabPageParameter.Controls.Add(this.tbTrainingRate);
            this.tabPageParameter.Controls.Add(this.lblInternalRate);
            this.tabPageParameter.Controls.Add(this.tbInternalRate);
            this.tabPageParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageParameter.Name = "tabPageParameter";
            this.tabPageParameter.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageParameter.Size = new System.Drawing.Size(445, 422);
            this.tabPageParameter.TabIndex = 2;
            this.tabPageParameter.Text = "参数";
            this.tabPageParameter.UseVisualStyleBackColor = true;
            // 
            // lblMaxMilitaryExperience
            // 
            this.lblMaxMilitaryExperience.AutoSize = true;
            this.lblMaxMilitaryExperience.Location = new System.Drawing.Point(278, 367);
            this.lblMaxMilitaryExperience.Name = "lblMaxMilitaryExperience";
            this.lblMaxMilitaryExperience.Size = new System.Drawing.Size(77, 12);
            this.lblMaxMilitaryExperience.TabIndex = 67;
            this.lblMaxMilitaryExperience.Text = "部队经验上限";
            // 
            // tbMaxMilitaryExperience
            // 
            this.tbMaxMilitaryExperience.Location = new System.Drawing.Point(361, 364);
            this.tbMaxMilitaryExperience.Name = "tbMaxMilitaryExperience";
            this.tbMaxMilitaryExperience.Size = new System.Drawing.Size(71, 21);
            this.tbMaxMilitaryExperience.TabIndex = 66;
            // 
            // lblMilitaryPopulationReloadQuantity
            // 
            this.lblMilitaryPopulationReloadQuantity.AutoSize = true;
            this.lblMilitaryPopulationReloadQuantity.Location = new System.Drawing.Point(278, 340);
            this.lblMilitaryPopulationReloadQuantity.Name = "lblMilitaryPopulationReloadQuantity";
            this.lblMilitaryPopulationReloadQuantity.Size = new System.Drawing.Size(77, 12);
            this.lblMilitaryPopulationReloadQuantity.TabIndex = 65;
            this.lblMilitaryPopulationReloadQuantity.Text = "兵役增量倍数";
            // 
            // tbMilitaryPopulationReloadQuantity
            // 
            this.tbMilitaryPopulationReloadQuantity.Location = new System.Drawing.Point(361, 337);
            this.tbMilitaryPopulationReloadQuantity.Name = "tbMilitaryPopulationReloadQuantity";
            this.tbMilitaryPopulationReloadQuantity.Size = new System.Drawing.Size(71, 21);
            this.tbMilitaryPopulationReloadQuantity.TabIndex = 64;
            // 
            // lblMilitaryPopulationCap
            // 
            this.lblMilitaryPopulationCap.AutoSize = true;
            this.lblMilitaryPopulationCap.Location = new System.Drawing.Point(302, 313);
            this.lblMilitaryPopulationCap.Name = "lblMilitaryPopulationCap";
            this.lblMilitaryPopulationCap.Size = new System.Drawing.Size(53, 12);
            this.lblMilitaryPopulationCap.TabIndex = 63;
            this.lblMilitaryPopulationCap.Text = "兵役上限";
            // 
            // tbMilitaryPopulationCap
            // 
            this.tbMilitaryPopulationCap.Location = new System.Drawing.Point(361, 310);
            this.tbMilitaryPopulationCap.Name = "tbMilitaryPopulationCap";
            this.tbMilitaryPopulationCap.Size = new System.Drawing.Size(71, 21);
            this.tbMilitaryPopulationCap.TabIndex = 62;
            // 
            // lblJailBreakArchitectureCost
            // 
            this.lblJailBreakArchitectureCost.AutoSize = true;
            this.lblJailBreakArchitectureCost.Location = new System.Drawing.Point(278, 205);
            this.lblJailBreakArchitectureCost.Name = "lblJailBreakArchitectureCost";
            this.lblJailBreakArchitectureCost.Size = new System.Drawing.Size(77, 12);
            this.lblJailBreakArchitectureCost.TabIndex = 61;
            this.lblJailBreakArchitectureCost.Text = "劫牢所需资金";
            // 
            // tbJailBreakArchitectureCost
            // 
            this.tbJailBreakArchitectureCost.Location = new System.Drawing.Point(361, 201);
            this.tbJailBreakArchitectureCost.Name = "tbJailBreakArchitectureCost";
            this.tbJailBreakArchitectureCost.Size = new System.Drawing.Size(71, 21);
            this.tbJailBreakArchitectureCost.TabIndex = 60;
            // 
            // lblLeadershipOffenceRate
            // 
            this.lblLeadershipOffenceRate.AutoSize = true;
            this.lblLeadershipOffenceRate.Location = new System.Drawing.Point(218, 395);
            this.lblLeadershipOffenceRate.Name = "lblLeadershipOffenceRate";
            this.lblLeadershipOffenceRate.Size = new System.Drawing.Size(137, 12);
            this.lblLeadershipOffenceRate.TabIndex = 59;
            this.lblLeadershipOffenceRate.Text = "统率对部队攻击影响参数";
            // 
            // tbLeadershipOffenceRate
            // 
            this.tbLeadershipOffenceRate.Location = new System.Drawing.Point(361, 392);
            this.tbLeadershipOffenceRate.Name = "tbLeadershipOffenceRate";
            this.tbLeadershipOffenceRate.Size = new System.Drawing.Size(71, 21);
            this.tbLeadershipOffenceRate.TabIndex = 58;
            // 
            // lblTechniquePointMultiple
            // 
            this.lblTechniquePointMultiple.AutoSize = true;
            this.lblTechniquePointMultiple.Location = new System.Drawing.Point(12, 395);
            this.lblTechniquePointMultiple.Name = "lblTechniquePointMultiple";
            this.lblTechniquePointMultiple.Size = new System.Drawing.Size(65, 12);
            this.lblTechniquePointMultiple.TabIndex = 57;
            this.lblTechniquePointMultiple.Text = "技巧点乘数";
            // 
            // tbTechniquePointMultiple
            // 
            this.tbTechniquePointMultiple.Location = new System.Drawing.Point(107, 392);
            this.tbTechniquePointMultiple.Name = "tbTechniquePointMultiple";
            this.tbTechniquePointMultiple.Size = new System.Drawing.Size(71, 21);
            this.tbTechniquePointMultiple.TabIndex = 56;
            // 
            // lblFireDamageScale
            // 
            this.lblFireDamageScale.AutoSize = true;
            this.lblFireDamageScale.Location = new System.Drawing.Point(12, 259);
            this.lblFireDamageScale.Name = "lblFireDamageScale";
            this.lblFireDamageScale.Size = new System.Drawing.Size(65, 12);
            this.lblFireDamageScale.TabIndex = 55;
            this.lblFireDamageScale.Text = "火焰伤害率";
            // 
            // tbFireDamageScale
            // 
            this.tbFireDamageScale.Location = new System.Drawing.Point(107, 256);
            this.tbFireDamageScale.Name = "tbFireDamageScale";
            this.tbFireDamageScale.Size = new System.Drawing.Size(71, 21);
            this.tbFireDamageScale.TabIndex = 54;
            // 
            // lblSurroundArchitectureDominationUnit
            // 
            this.lblSurroundArchitectureDominationUnit.AutoSize = true;
            this.lblSurroundArchitectureDominationUnit.Location = new System.Drawing.Point(12, 232);
            this.lblSurroundArchitectureDominationUnit.Name = "lblSurroundArchitectureDominationUnit";
            this.lblSurroundArchitectureDominationUnit.Size = new System.Drawing.Size(77, 12);
            this.lblSurroundArchitectureDominationUnit.TabIndex = 53;
            this.lblSurroundArchitectureDominationUnit.Text = "围城统治单位";
            // 
            // tbSurroundArchitectureDominationUnit
            // 
            this.tbSurroundArchitectureDominationUnit.Location = new System.Drawing.Point(107, 229);
            this.tbSurroundArchitectureDominationUnit.Name = "tbSurroundArchitectureDominationUnit";
            this.tbSurroundArchitectureDominationUnit.Size = new System.Drawing.Size(71, 21);
            this.tbSurroundArchitectureDominationUnit.TabIndex = 52;
            // 
            // lblFoodToFundDivisor
            // 
            this.lblFoodToFundDivisor.AutoSize = true;
            this.lblFoodToFundDivisor.Location = new System.Drawing.Point(12, 367);
            this.lblFoodToFundDivisor.Name = "lblFoodToFundDivisor";
            this.lblFoodToFundDivisor.Size = new System.Drawing.Size(89, 12);
            this.lblFoodToFundDivisor.TabIndex = 51;
            this.lblFoodToFundDivisor.Text = "粮草换资金除数";
            // 
            // tbFoodToFundDivisor
            // 
            this.tbFoodToFundDivisor.Location = new System.Drawing.Point(107, 364);
            this.tbFoodToFundDivisor.Name = "tbFoodToFundDivisor";
            this.tbFoodToFundDivisor.Size = new System.Drawing.Size(71, 21);
            this.tbFoodToFundDivisor.TabIndex = 50;
            // 
            // lblFundToFoodMultiple
            // 
            this.lblFundToFoodMultiple.AutoSize = true;
            this.lblFundToFoodMultiple.Location = new System.Drawing.Point(12, 340);
            this.lblFundToFoodMultiple.Name = "lblFundToFoodMultiple";
            this.lblFundToFoodMultiple.Size = new System.Drawing.Size(89, 12);
            this.lblFundToFoodMultiple.TabIndex = 49;
            this.lblFundToFoodMultiple.Text = "资金换粮草乘数";
            // 
            // tbFundToFoodMultiple
            // 
            this.tbFundToFoodMultiple.Location = new System.Drawing.Point(107, 337);
            this.tbFundToFoodMultiple.Name = "tbFundToFoodMultiple";
            this.tbFundToFoodMultiple.Size = new System.Drawing.Size(71, 21);
            this.tbFundToFoodMultiple.TabIndex = 48;
            // 
            // lblSellFoodCommerce
            // 
            this.lblSellFoodCommerce.AutoSize = true;
            this.lblSellFoodCommerce.Location = new System.Drawing.Point(12, 313);
            this.lblSellFoodCommerce.Name = "lblSellFoodCommerce";
            this.lblSellFoodCommerce.Size = new System.Drawing.Size(77, 12);
            this.lblSellFoodCommerce.TabIndex = 47;
            this.lblSellFoodCommerce.Text = "卖粮所需商业";
            // 
            // tbSellFoodCommerce
            // 
            this.tbSellFoodCommerce.Location = new System.Drawing.Point(107, 310);
            this.tbSellFoodCommerce.Name = "tbSellFoodCommerce";
            this.tbSellFoodCommerce.Size = new System.Drawing.Size(71, 21);
            this.tbSellFoodCommerce.TabIndex = 46;
            // 
            // lblBuyFoodAgriculture
            // 
            this.lblBuyFoodAgriculture.AutoSize = true;
            this.lblBuyFoodAgriculture.Location = new System.Drawing.Point(12, 286);
            this.lblBuyFoodAgriculture.Name = "lblBuyFoodAgriculture";
            this.lblBuyFoodAgriculture.Size = new System.Drawing.Size(77, 12);
            this.lblBuyFoodAgriculture.TabIndex = 45;
            this.lblBuyFoodAgriculture.Text = "买粮所需农业";
            // 
            // tbBuyFoodAgriculture
            // 
            this.tbBuyFoodAgriculture.Location = new System.Drawing.Point(107, 283);
            this.tbBuyFoodAgriculture.Name = "tbBuyFoodAgriculture";
            this.tbBuyFoodAgriculture.Size = new System.Drawing.Size(71, 21);
            this.tbBuyFoodAgriculture.TabIndex = 44;
            // 
            // lblGossipArchitectureCost
            // 
            this.lblGossipArchitectureCost.AutoSize = true;
            this.lblGossipArchitectureCost.Location = new System.Drawing.Point(278, 286);
            this.lblGossipArchitectureCost.Name = "lblGossipArchitectureCost";
            this.lblGossipArchitectureCost.Size = new System.Drawing.Size(77, 12);
            this.lblGossipArchitectureCost.TabIndex = 39;
            this.lblGossipArchitectureCost.Text = "流言所需资金";
            // 
            // tbGossipArchitectureCost
            // 
            this.tbGossipArchitectureCost.Location = new System.Drawing.Point(361, 283);
            this.tbGossipArchitectureCost.Name = "tbGossipArchitectureCost";
            this.tbGossipArchitectureCost.Size = new System.Drawing.Size(71, 21);
            this.tbGossipArchitectureCost.TabIndex = 38;
            // 
            // lblInstigateArchitectureCost
            // 
            this.lblInstigateArchitectureCost.AutoSize = true;
            this.lblInstigateArchitectureCost.Location = new System.Drawing.Point(278, 259);
            this.lblInstigateArchitectureCost.Name = "lblInstigateArchitectureCost";
            this.lblInstigateArchitectureCost.Size = new System.Drawing.Size(77, 12);
            this.lblInstigateArchitectureCost.TabIndex = 37;
            this.lblInstigateArchitectureCost.Text = "煽动所需资金";
            // 
            // tbInstigateArchitectureCost
            // 
            this.tbInstigateArchitectureCost.Location = new System.Drawing.Point(361, 256);
            this.tbInstigateArchitectureCost.Name = "tbInstigateArchitectureCost";
            this.tbInstigateArchitectureCost.Size = new System.Drawing.Size(71, 21);
            this.tbInstigateArchitectureCost.TabIndex = 36;
            // 
            // lblDestroyArchitectureCost
            // 
            this.lblDestroyArchitectureCost.AutoSize = true;
            this.lblDestroyArchitectureCost.Location = new System.Drawing.Point(278, 232);
            this.lblDestroyArchitectureCost.Name = "lblDestroyArchitectureCost";
            this.lblDestroyArchitectureCost.Size = new System.Drawing.Size(77, 12);
            this.lblDestroyArchitectureCost.TabIndex = 35;
            this.lblDestroyArchitectureCost.Text = "破坏所需资金";
            // 
            // tbDestroyArchitectureCost
            // 
            this.tbDestroyArchitectureCost.Location = new System.Drawing.Point(361, 229);
            this.tbDestroyArchitectureCost.Name = "tbDestroyArchitectureCost";
            this.tbDestroyArchitectureCost.Size = new System.Drawing.Size(71, 21);
            this.tbDestroyArchitectureCost.TabIndex = 34;
            // 
            // lblRewardPersonCost
            // 
            this.lblRewardPersonCost.AutoSize = true;
            this.lblRewardPersonCost.Location = new System.Drawing.Point(278, 178);
            this.lblRewardPersonCost.Name = "lblRewardPersonCost";
            this.lblRewardPersonCost.Size = new System.Drawing.Size(77, 12);
            this.lblRewardPersonCost.TabIndex = 31;
            this.lblRewardPersonCost.Text = "褒奖所需资金";
            // 
            // tbRewardPersonCost
            // 
            this.tbRewardPersonCost.Location = new System.Drawing.Point(361, 175);
            this.tbRewardPersonCost.Name = "tbRewardPersonCost";
            this.tbRewardPersonCost.Size = new System.Drawing.Size(71, 21);
            this.tbRewardPersonCost.TabIndex = 30;
            // 
            // lblConvincePersonCost
            // 
            this.lblConvincePersonCost.AutoSize = true;
            this.lblConvincePersonCost.Location = new System.Drawing.Point(278, 151);
            this.lblConvincePersonCost.Name = "lblConvincePersonCost";
            this.lblConvincePersonCost.Size = new System.Drawing.Size(77, 12);
            this.lblConvincePersonCost.TabIndex = 29;
            this.lblConvincePersonCost.Text = "说服所需资金";
            // 
            // tbConvincePersonCost
            // 
            this.tbConvincePersonCost.Location = new System.Drawing.Point(361, 148);
            this.tbConvincePersonCost.Name = "tbConvincePersonCost";
            this.tbConvincePersonCost.Size = new System.Drawing.Size(71, 21);
            this.tbConvincePersonCost.TabIndex = 28;
            // 
            // lblChangeCapitalCost
            // 
            this.lblChangeCapitalCost.AutoSize = true;
            this.lblChangeCapitalCost.Location = new System.Drawing.Point(278, 124);
            this.lblChangeCapitalCost.Name = "lblChangeCapitalCost";
            this.lblChangeCapitalCost.Size = new System.Drawing.Size(77, 12);
            this.lblChangeCapitalCost.TabIndex = 25;
            this.lblChangeCapitalCost.Text = "迁都资金单位";
            // 
            // tbChangeCapitalCost
            // 
            this.tbChangeCapitalCost.Location = new System.Drawing.Point(361, 121);
            this.tbChangeCapitalCost.Name = "tbChangeCapitalCost";
            this.tbChangeCapitalCost.Size = new System.Drawing.Size(71, 21);
            this.tbChangeCapitalCost.TabIndex = 24;
            // 
            // lblRecruitmentMorale
            // 
            this.lblRecruitmentMorale.AutoSize = true;
            this.lblRecruitmentMorale.Location = new System.Drawing.Point(278, 97);
            this.lblRecruitmentMorale.Name = "lblRecruitmentMorale";
            this.lblRecruitmentMorale.Size = new System.Drawing.Size(77, 12);
            this.lblRecruitmentMorale.TabIndex = 23;
            this.lblRecruitmentMorale.Text = "补充最小民心";
            // 
            // tbRecruitmentMorale
            // 
            this.tbRecruitmentMorale.Location = new System.Drawing.Point(361, 94);
            this.tbRecruitmentMorale.Name = "tbRecruitmentMorale";
            this.tbRecruitmentMorale.Size = new System.Drawing.Size(71, 21);
            this.tbRecruitmentMorale.TabIndex = 22;
            // 
            // lblRecruitmentDomination
            // 
            this.lblRecruitmentDomination.AutoSize = true;
            this.lblRecruitmentDomination.Location = new System.Drawing.Point(278, 70);
            this.lblRecruitmentDomination.Name = "lblRecruitmentDomination";
            this.lblRecruitmentDomination.Size = new System.Drawing.Size(77, 12);
            this.lblRecruitmentDomination.TabIndex = 21;
            this.lblRecruitmentDomination.Text = "补充最小统治";
            // 
            // tbRecruitmentDomination
            // 
            this.tbRecruitmentDomination.Location = new System.Drawing.Point(361, 67);
            this.tbRecruitmentDomination.Name = "tbRecruitmentDomination";
            this.tbRecruitmentDomination.Size = new System.Drawing.Size(71, 21);
            this.tbRecruitmentDomination.TabIndex = 20;
            // 
            // lblRecruitmentFundCost
            // 
            this.lblRecruitmentFundCost.AutoSize = true;
            this.lblRecruitmentFundCost.Location = new System.Drawing.Point(278, 43);
            this.lblRecruitmentFundCost.Name = "lblRecruitmentFundCost";
            this.lblRecruitmentFundCost.Size = new System.Drawing.Size(77, 12);
            this.lblRecruitmentFundCost.TabIndex = 19;
            this.lblRecruitmentFundCost.Text = "补充资金单位";
            // 
            // tbRecruitmentFundCost
            // 
            this.tbRecruitmentFundCost.Location = new System.Drawing.Point(361, 40);
            this.tbRecruitmentFundCost.Name = "tbRecruitmentFundCost";
            this.tbRecruitmentFundCost.Size = new System.Drawing.Size(71, 21);
            this.tbRecruitmentFundCost.TabIndex = 18;
            // 
            // lblInternalFundCost
            // 
            this.lblInternalFundCost.AutoSize = true;
            this.lblInternalFundCost.Location = new System.Drawing.Point(278, 16);
            this.lblInternalFundCost.Name = "lblInternalFundCost";
            this.lblInternalFundCost.Size = new System.Drawing.Size(77, 12);
            this.lblInternalFundCost.TabIndex = 17;
            this.lblInternalFundCost.Text = "内政资金单位";
            // 
            // tbInternalFundCost
            // 
            this.tbInternalFundCost.Location = new System.Drawing.Point(361, 13);
            this.tbInternalFundCost.Name = "tbInternalFundCost";
            this.tbInternalFundCost.Size = new System.Drawing.Size(71, 21);
            this.tbInternalFundCost.TabIndex = 16;
            // 
            // lblDefaultPopulationDevelopingRate
            // 
            this.lblDefaultPopulationDevelopingRate.AutoSize = true;
            this.lblDefaultPopulationDevelopingRate.Location = new System.Drawing.Point(12, 205);
            this.lblDefaultPopulationDevelopingRate.Name = "lblDefaultPopulationDevelopingRate";
            this.lblDefaultPopulationDevelopingRate.Size = new System.Drawing.Size(89, 12);
            this.lblDefaultPopulationDevelopingRate.TabIndex = 15;
            this.lblDefaultPopulationDevelopingRate.Text = "人口默认增长率";
            // 
            // tbDefaultPopulationDevelopingRate
            // 
            this.tbDefaultPopulationDevelopingRate.Location = new System.Drawing.Point(107, 202);
            this.tbDefaultPopulationDevelopingRate.Name = "tbDefaultPopulationDevelopingRate";
            this.tbDefaultPopulationDevelopingRate.Size = new System.Drawing.Size(71, 21);
            this.tbDefaultPopulationDevelopingRate.TabIndex = 14;
            // 
            // lblArchitectureDamageRate
            // 
            this.lblArchitectureDamageRate.AutoSize = true;
            this.lblArchitectureDamageRate.Location = new System.Drawing.Point(12, 178);
            this.lblArchitectureDamageRate.Name = "lblArchitectureDamageRate";
            this.lblArchitectureDamageRate.Size = new System.Drawing.Size(65, 12);
            this.lblArchitectureDamageRate.TabIndex = 13;
            this.lblArchitectureDamageRate.Text = "建筑伤害率";
            // 
            // tbArchitectureDamageRate
            // 
            this.tbArchitectureDamageRate.Location = new System.Drawing.Point(107, 175);
            this.tbArchitectureDamageRate.Name = "tbArchitectureDamageRate";
            this.tbArchitectureDamageRate.Size = new System.Drawing.Size(71, 21);
            this.tbArchitectureDamageRate.TabIndex = 12;
            // 
            // lblTroopDamageRate
            // 
            this.lblTroopDamageRate.AutoSize = true;
            this.lblTroopDamageRate.Location = new System.Drawing.Point(12, 151);
            this.lblTroopDamageRate.Name = "lblTroopDamageRate";
            this.lblTroopDamageRate.Size = new System.Drawing.Size(65, 12);
            this.lblTroopDamageRate.TabIndex = 11;
            this.lblTroopDamageRate.Text = "部队伤害率";
            // 
            // tbTroopDamageRate
            // 
            this.tbTroopDamageRate.Location = new System.Drawing.Point(107, 148);
            this.tbTroopDamageRate.Name = "tbTroopDamageRate";
            this.tbTroopDamageRate.Size = new System.Drawing.Size(71, 21);
            this.tbTroopDamageRate.TabIndex = 10;
            // 
            // lblFoodRate
            // 
            this.lblFoodRate.AutoSize = true;
            this.lblFoodRate.Location = new System.Drawing.Point(12, 124);
            this.lblFoodRate.Name = "lblFoodRate";
            this.lblFoodRate.Size = new System.Drawing.Size(65, 12);
            this.lblFoodRate.TabIndex = 9;
            this.lblFoodRate.Text = "粮草收入率";
            // 
            // tbFoodRate
            // 
            this.tbFoodRate.Location = new System.Drawing.Point(107, 121);
            this.tbFoodRate.Name = "tbFoodRate";
            this.tbFoodRate.Size = new System.Drawing.Size(71, 21);
            this.tbFoodRate.TabIndex = 8;
            // 
            // lblFundRate
            // 
            this.lblFundRate.AutoSize = true;
            this.lblFundRate.Location = new System.Drawing.Point(12, 97);
            this.lblFundRate.Name = "lblFundRate";
            this.lblFundRate.Size = new System.Drawing.Size(65, 12);
            this.lblFundRate.TabIndex = 7;
            this.lblFundRate.Text = "资金收入率";
            // 
            // tbFundRate
            // 
            this.tbFundRate.Location = new System.Drawing.Point(107, 94);
            this.tbFundRate.Name = "tbFundRate";
            this.tbFundRate.Size = new System.Drawing.Size(71, 21);
            this.tbFundRate.TabIndex = 6;
            // 
            // lblRecruitmentRate
            // 
            this.lblRecruitmentRate.AutoSize = true;
            this.lblRecruitmentRate.Location = new System.Drawing.Point(12, 70);
            this.lblRecruitmentRate.Name = "lblRecruitmentRate";
            this.lblRecruitmentRate.Size = new System.Drawing.Size(53, 12);
            this.lblRecruitmentRate.TabIndex = 5;
            this.lblRecruitmentRate.Text = "补充速率";
            // 
            // tbRecruitmentRate
            // 
            this.tbRecruitmentRate.Location = new System.Drawing.Point(107, 67);
            this.tbRecruitmentRate.Name = "tbRecruitmentRate";
            this.tbRecruitmentRate.Size = new System.Drawing.Size(71, 21);
            this.tbRecruitmentRate.TabIndex = 4;
            // 
            // lblTrainingRate
            // 
            this.lblTrainingRate.AutoSize = true;
            this.lblTrainingRate.Location = new System.Drawing.Point(12, 43);
            this.lblTrainingRate.Name = "lblTrainingRate";
            this.lblTrainingRate.Size = new System.Drawing.Size(53, 12);
            this.lblTrainingRate.TabIndex = 3;
            this.lblTrainingRate.Text = "训练速率";
            // 
            // tbTrainingRate
            // 
            this.tbTrainingRate.Location = new System.Drawing.Point(107, 40);
            this.tbTrainingRate.Name = "tbTrainingRate";
            this.tbTrainingRate.Size = new System.Drawing.Size(71, 21);
            this.tbTrainingRate.TabIndex = 2;
            // 
            // lblInternalRate
            // 
            this.lblInternalRate.AutoSize = true;
            this.lblInternalRate.Location = new System.Drawing.Point(12, 16);
            this.lblInternalRate.Name = "lblInternalRate";
            this.lblInternalRate.Size = new System.Drawing.Size(53, 12);
            this.lblInternalRate.TabIndex = 1;
            this.lblInternalRate.Text = "内政速率";
            // 
            // tbInternalRate
            // 
            this.tbInternalRate.Location = new System.Drawing.Point(107, 13);
            this.tbInternalRate.Name = "tbInternalRate";
            this.tbInternalRate.Size = new System.Drawing.Size(71, 21);
            this.tbInternalRate.TabIndex = 0;
            // 
            // tabPageAIParameter
            // 
            this.tabPageAIParameter.Controls.Add(this.lblAIEncirclePlayerRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIEncirclePlayerRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIExtraPersonIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIExtraPerson);
            this.tabPageAIParameter.Controls.Add(this.tbAIExtraPerson);
            this.tabPageAIParameter.Controls.Add(this.tbAIAntiSurroundIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIAntiSurround);
            this.tabPageAIParameter.Controls.Add(this.tbAIAntiSurround);
            this.tabPageAIParameter.Controls.Add(this.tbAIAntiStratagemIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIAntiStratagem);
            this.tabPageAIParameter.Controls.Add(this.tbAIAntiStratagem);
            this.tabPageAIParameter.Controls.Add(this.label62);
            this.tabPageAIParameter.Controls.Add(this.label61);
            this.tabPageAIParameter.Controls.Add(this.tbAIArmyExperienceIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIOfficerExperienceIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITrainingSpeedIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIRecruitmentSpeedIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopDefenceIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIArchitectureDamageIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopOffenceIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIFoodIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIFundIncreaseRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIArmyExperienceRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIArmyExperienceRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIOfficerExperienceRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIOfficerExperienceRate);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakePlayerCaptiveOnlyUnfull);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakePlayerCaptives);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakeNoFactionPerson);
            this.tabPageAIParameter.Controls.Add(this.cbAIAutoTakeNoFactionCaptives);
            this.tabPageAIParameter.Controls.Add(this.cbAIExecuteBetterOfficer);
            this.tabPageAIParameter.Controls.Add(this.lblAIExecutionRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIExecutionRate);
            this.tabPageAIParameter.Controls.Add(this.lblAITrainingSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITrainingSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIRecruitmentSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIRecruitmentSpeedRate);
            this.tabPageAIParameter.Controls.Add(this.lblAITroopDefenceRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopDefenceRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIArchitectureDamageRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIArchitectureDamageRate);
            this.tabPageAIParameter.Controls.Add(this.lblAITroopOffenceRate);
            this.tabPageAIParameter.Controls.Add(this.tbAITroopOffenceRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIFoodRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIFoodRate);
            this.tabPageAIParameter.Controls.Add(this.lblAIFundRate);
            this.tabPageAIParameter.Controls.Add(this.tbAIFundRate);
            this.tabPageAIParameter.Controls.Add(this.cbPinPointAtPlayer);
            this.tabPageAIParameter.Controls.Add(this.cbIgnoreStrategyTendency);
            this.tabPageAIParameter.Controls.Add(this.cbInternalSurplusRateForPlayer);
            this.tabPageAIParameter.Controls.Add(this.cbInternalSurplusRateForAI);
            this.tabPageAIParameter.Location = new System.Drawing.Point(4, 22);
            this.tabPageAIParameter.Name = "tabPageAIParameter";
            this.tabPageAIParameter.Padding = new System.Windows.Forms.Padding(10);
            this.tabPageAIParameter.Size = new System.Drawing.Size(445, 422);
            this.tabPageAIParameter.TabIndex = 3;
            this.tabPageAIParameter.Text = "电脑";
            this.tabPageAIParameter.UseVisualStyleBackColor = true;
            // 
            // lblAIEncirclePlayerRate
            // 
            this.lblAIEncirclePlayerRate.AutoSize = true;
            this.lblAIEncirclePlayerRate.Location = new System.Drawing.Point(252, 203);
            this.lblAIEncirclePlayerRate.Name = "lblAIEncirclePlayerRate";
            this.lblAIEncirclePlayerRate.Size = new System.Drawing.Size(101, 12);
            this.lblAIEncirclePlayerRate.TabIndex = 75;
            this.lblAIEncirclePlayerRate.Text = "电脑声讨玩家参数";
            // 
            // tbAIEncirclePlayerRate
            // 
            this.tbAIEncirclePlayerRate.Location = new System.Drawing.Point(359, 200);
            this.tbAIEncirclePlayerRate.Name = "tbAIEncirclePlayerRate";
            this.tbAIEncirclePlayerRate.Size = new System.Drawing.Size(71, 21);
            this.tbAIEncirclePlayerRate.TabIndex = 76;
            // 
            // tbAIExtraPersonIncreaseRate
            // 
            this.tbAIExtraPersonIncreaseRate.Location = new System.Drawing.Point(189, 340);
            this.tbAIExtraPersonIncreaseRate.Name = "tbAIExtraPersonIncreaseRate";
            this.tbAIExtraPersonIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIExtraPersonIncreaseRate.TabIndex = 74;
            // 
            // lblAIExtraPerson
            // 
            this.lblAIExtraPerson.AutoSize = true;
            this.lblAIExtraPerson.Location = new System.Drawing.Point(13, 343);
            this.lblAIExtraPerson.Name = "lblAIExtraPerson";
            this.lblAIExtraPerson.Size = new System.Drawing.Size(77, 12);
            this.lblAIExtraPerson.TabIndex = 72;
            this.lblAIExtraPerson.Text = "电脑额外人才";
            // 
            // tbAIExtraPerson
            // 
            this.tbAIExtraPerson.Location = new System.Drawing.Point(130, 340);
            this.tbAIExtraPerson.Name = "tbAIExtraPerson";
            this.tbAIExtraPerson.Size = new System.Drawing.Size(57, 21);
            this.tbAIExtraPerson.TabIndex = 73;
            // 
            // tbAIAntiSurroundIncreaseRate
            // 
            this.tbAIAntiSurroundIncreaseRate.Location = new System.Drawing.Point(189, 312);
            this.tbAIAntiSurroundIncreaseRate.Name = "tbAIAntiSurroundIncreaseRate";
            this.tbAIAntiSurroundIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIAntiSurroundIncreaseRate.TabIndex = 71;
            // 
            // lblAIAntiSurround
            // 
            this.lblAIAntiSurround.AutoSize = true;
            this.lblAIAntiSurround.Location = new System.Drawing.Point(13, 315);
            this.lblAIAntiSurround.Name = "lblAIAntiSurround";
            this.lblAIAntiSurround.Size = new System.Drawing.Size(89, 12);
            this.lblAIAntiSurround.TabIndex = 69;
            this.lblAIAntiSurround.Text = "电脑部队抗围率";
            // 
            // tbAIAntiSurround
            // 
            this.tbAIAntiSurround.Location = new System.Drawing.Point(130, 312);
            this.tbAIAntiSurround.Name = "tbAIAntiSurround";
            this.tbAIAntiSurround.Size = new System.Drawing.Size(57, 21);
            this.tbAIAntiSurround.TabIndex = 70;
            // 
            // tbAIAntiStratagemIncreaseRate
            // 
            this.tbAIAntiStratagemIncreaseRate.Location = new System.Drawing.Point(189, 284);
            this.tbAIAntiStratagemIncreaseRate.Name = "tbAIAntiStratagemIncreaseRate";
            this.tbAIAntiStratagemIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIAntiStratagemIncreaseRate.TabIndex = 68;
            // 
            // lblAIAntiStratagem
            // 
            this.lblAIAntiStratagem.AutoSize = true;
            this.lblAIAntiStratagem.Location = new System.Drawing.Point(13, 287);
            this.lblAIAntiStratagem.Name = "lblAIAntiStratagem";
            this.lblAIAntiStratagem.Size = new System.Drawing.Size(89, 12);
            this.lblAIAntiStratagem.TabIndex = 66;
            this.lblAIAntiStratagem.Text = "电脑部队抗计率";
            // 
            // tbAIAntiStratagem
            // 
            this.tbAIAntiStratagem.Location = new System.Drawing.Point(130, 284);
            this.tbAIAntiStratagem.Name = "tbAIAntiStratagem";
            this.tbAIAntiStratagem.Size = new System.Drawing.Size(57, 21);
            this.tbAIAntiStratagem.TabIndex = 67;
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(205, 17);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(29, 12);
            this.label62.TabIndex = 65;
            this.label62.Text = "增量";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(142, 17);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(29, 12);
            this.label61.TabIndex = 64;
            this.label61.Text = "基值";
            // 
            // tbAIArmyExperienceIncreaseRate
            // 
            this.tbAIArmyExperienceIncreaseRate.Location = new System.Drawing.Point(189, 256);
            this.tbAIArmyExperienceIncreaseRate.Name = "tbAIArmyExperienceIncreaseRate";
            this.tbAIArmyExperienceIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIArmyExperienceIncreaseRate.TabIndex = 63;
            // 
            // tbAIOfficerExperienceIncreaseRate
            // 
            this.tbAIOfficerExperienceIncreaseRate.Location = new System.Drawing.Point(189, 228);
            this.tbAIOfficerExperienceIncreaseRate.Name = "tbAIOfficerExperienceIncreaseRate";
            this.tbAIOfficerExperienceIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIOfficerExperienceIncreaseRate.TabIndex = 62;
            // 
            // tbAITrainingSpeedIncreaseRate
            // 
            this.tbAITrainingSpeedIncreaseRate.Location = new System.Drawing.Point(189, 173);
            this.tbAITrainingSpeedIncreaseRate.Name = "tbAITrainingSpeedIncreaseRate";
            this.tbAITrainingSpeedIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITrainingSpeedIncreaseRate.TabIndex = 60;
            // 
            // tbAIRecruitmentSpeedIncreaseRate
            // 
            this.tbAIRecruitmentSpeedIncreaseRate.Location = new System.Drawing.Point(189, 200);
            this.tbAIRecruitmentSpeedIncreaseRate.Name = "tbAIRecruitmentSpeedIncreaseRate";
            this.tbAIRecruitmentSpeedIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIRecruitmentSpeedIncreaseRate.TabIndex = 61;
            // 
            // tbAITroopDefenceIncreaseRate
            // 
            this.tbAITroopDefenceIncreaseRate.Location = new System.Drawing.Point(189, 118);
            this.tbAITroopDefenceIncreaseRate.Name = "tbAITroopDefenceIncreaseRate";
            this.tbAITroopDefenceIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITroopDefenceIncreaseRate.TabIndex = 58;
            // 
            // tbAIArchitectureDamageIncreaseRate
            // 
            this.tbAIArchitectureDamageIncreaseRate.Location = new System.Drawing.Point(189, 145);
            this.tbAIArchitectureDamageIncreaseRate.Name = "tbAIArchitectureDamageIncreaseRate";
            this.tbAIArchitectureDamageIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIArchitectureDamageIncreaseRate.TabIndex = 59;
            // 
            // tbAITroopOffenceIncreaseRate
            // 
            this.tbAITroopOffenceIncreaseRate.Location = new System.Drawing.Point(189, 91);
            this.tbAITroopOffenceIncreaseRate.Name = "tbAITroopOffenceIncreaseRate";
            this.tbAITroopOffenceIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITroopOffenceIncreaseRate.TabIndex = 57;
            // 
            // tbAIFoodIncreaseRate
            // 
            this.tbAIFoodIncreaseRate.Location = new System.Drawing.Point(189, 64);
            this.tbAIFoodIncreaseRate.Name = "tbAIFoodIncreaseRate";
            this.tbAIFoodIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIFoodIncreaseRate.TabIndex = 56;
            // 
            // tbAIFundIncreaseRate
            // 
            this.tbAIFundIncreaseRate.Location = new System.Drawing.Point(189, 37);
            this.tbAIFundIncreaseRate.Name = "tbAIFundIncreaseRate";
            this.tbAIFundIncreaseRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIFundIncreaseRate.TabIndex = 55;
            // 
            // lblAIArmyExperienceRate
            // 
            this.lblAIArmyExperienceRate.AutoSize = true;
            this.lblAIArmyExperienceRate.Location = new System.Drawing.Point(13, 259);
            this.lblAIArmyExperienceRate.Name = "lblAIArmyExperienceRate";
            this.lblAIArmyExperienceRate.Size = new System.Drawing.Size(113, 12);
            this.lblAIArmyExperienceRate.TabIndex = 51;
            this.lblAIArmyExperienceRate.Text = "电脑部队经验获得率";
            // 
            // tbAIArmyExperienceRate
            // 
            this.tbAIArmyExperienceRate.Location = new System.Drawing.Point(130, 256);
            this.tbAIArmyExperienceRate.Name = "tbAIArmyExperienceRate";
            this.tbAIArmyExperienceRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIArmyExperienceRate.TabIndex = 52;
            // 
            // lblAIOfficerExperienceRate
            // 
            this.lblAIOfficerExperienceRate.AutoSize = true;
            this.lblAIOfficerExperienceRate.Location = new System.Drawing.Point(13, 231);
            this.lblAIOfficerExperienceRate.Name = "lblAIOfficerExperienceRate";
            this.lblAIOfficerExperienceRate.Size = new System.Drawing.Size(113, 12);
            this.lblAIOfficerExperienceRate.TabIndex = 49;
            this.lblAIOfficerExperienceRate.Text = "电脑武将经验获得率";
            // 
            // tbAIOfficerExperienceRate
            // 
            this.tbAIOfficerExperienceRate.Location = new System.Drawing.Point(130, 228);
            this.tbAIOfficerExperienceRate.Name = "tbAIOfficerExperienceRate";
            this.tbAIOfficerExperienceRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIOfficerExperienceRate.TabIndex = 50;
            // 
            // cbAIAutoTakePlayerCaptiveOnlyUnfull
            // 
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.AutoSize = true;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Location = new System.Drawing.Point(270, 93);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Name = "cbAIAutoTakePlayerCaptiveOnlyUnfull";
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Size = new System.Drawing.Size(150, 16);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.TabIndex = 48;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Text = "只限忠诚不满100的俘虏";
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.UseVisualStyleBackColor = true;
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakePlayerCaptives
            // 
            this.cbAIAutoTakePlayerCaptives.AutoSize = true;
            this.cbAIAutoTakePlayerCaptives.Location = new System.Drawing.Point(252, 67);
            this.cbAIAutoTakePlayerCaptives.Name = "cbAIAutoTakePlayerCaptives";
            this.cbAIAutoTakePlayerCaptives.Size = new System.Drawing.Size(180, 16);
            this.cbAIAutoTakePlayerCaptives.TabIndex = 47;
            this.cbAIAutoTakePlayerCaptives.Text = "电脑必成功说服玩家势力俘虏";
            this.cbAIAutoTakePlayerCaptives.UseVisualStyleBackColor = true;
            this.cbAIAutoTakePlayerCaptives.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakeNoFactionPerson
            // 
            this.cbAIAutoTakeNoFactionPerson.AutoSize = true;
            this.cbAIAutoTakeNoFactionPerson.Location = new System.Drawing.Point(252, 39);
            this.cbAIAutoTakeNoFactionPerson.Name = "cbAIAutoTakeNoFactionPerson";
            this.cbAIAutoTakeNoFactionPerson.Size = new System.Drawing.Size(180, 16);
            this.cbAIAutoTakeNoFactionPerson.TabIndex = 46;
            this.cbAIAutoTakeNoFactionPerson.Text = "电脑必成功说服城中在野武将";
            this.cbAIAutoTakeNoFactionPerson.UseVisualStyleBackColor = true;
            this.cbAIAutoTakeNoFactionPerson.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIAutoTakeNoFactionCaptives
            // 
            this.cbAIAutoTakeNoFactionCaptives.AutoSize = true;
            this.cbAIAutoTakeNoFactionCaptives.Location = new System.Drawing.Point(252, 13);
            this.cbAIAutoTakeNoFactionCaptives.Name = "cbAIAutoTakeNoFactionCaptives";
            this.cbAIAutoTakeNoFactionCaptives.Size = new System.Drawing.Size(168, 16);
            this.cbAIAutoTakeNoFactionCaptives.TabIndex = 45;
            this.cbAIAutoTakeNoFactionCaptives.Text = "电脑必成功说服没势力俘虏";
            this.cbAIAutoTakeNoFactionCaptives.UseVisualStyleBackColor = true;
            this.cbAIAutoTakeNoFactionCaptives.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbAIExecuteBetterOfficer
            // 
            this.cbAIExecuteBetterOfficer.AutoSize = true;
            this.cbAIExecuteBetterOfficer.Location = new System.Drawing.Point(293, 370);
            this.cbAIExecuteBetterOfficer.Name = "cbAIExecuteBetterOfficer";
            this.cbAIExecuteBetterOfficer.Size = new System.Drawing.Size(144, 16);
            this.cbAIExecuteBetterOfficer.TabIndex = 44;
            this.cbAIExecuteBetterOfficer.Text = "电脑优先处斩能力高者";
            this.cbAIExecuteBetterOfficer.UseVisualStyleBackColor = true;
            // 
            // lblAIExecutionRate
            // 
            this.lblAIExecutionRate.AutoSize = true;
            this.lblAIExecutionRate.Location = new System.Drawing.Point(13, 371);
            this.lblAIExecutionRate.Name = "lblAIExecutionRate";
            this.lblAIExecutionRate.Size = new System.Drawing.Size(197, 12);
            this.lblAIExecutionRate.TabIndex = 43;
            this.lblAIExecutionRate.Text = "电脑处斩机率（数值越大几率越高）";
            // 
            // tbAIExecutionRate
            // 
            this.tbAIExecutionRate.Location = new System.Drawing.Point(216, 368);
            this.tbAIExecutionRate.Name = "tbAIExecutionRate";
            this.tbAIExecutionRate.Size = new System.Drawing.Size(71, 21);
            this.tbAIExecutionRate.TabIndex = 42;
            // 
            // lblAITrainingSpeedRate
            // 
            this.lblAITrainingSpeedRate.AutoSize = true;
            this.lblAITrainingSpeedRate.Location = new System.Drawing.Point(13, 176);
            this.lblAITrainingSpeedRate.Name = "lblAITrainingSpeedRate";
            this.lblAITrainingSpeedRate.Size = new System.Drawing.Size(77, 12);
            this.lblAITrainingSpeedRate.TabIndex = 27;
            this.lblAITrainingSpeedRate.Text = "电脑训练速度";
            // 
            // tbAITrainingSpeedRate
            // 
            this.tbAITrainingSpeedRate.Location = new System.Drawing.Point(130, 173);
            this.tbAITrainingSpeedRate.Name = "tbAITrainingSpeedRate";
            this.tbAITrainingSpeedRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITrainingSpeedRate.TabIndex = 24;
            this.tbAITrainingSpeedRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAIRecruitmentSpeedRate
            // 
            this.lblAIRecruitmentSpeedRate.AutoSize = true;
            this.lblAIRecruitmentSpeedRate.Location = new System.Drawing.Point(13, 203);
            this.lblAIRecruitmentSpeedRate.Name = "lblAIRecruitmentSpeedRate";
            this.lblAIRecruitmentSpeedRate.Size = new System.Drawing.Size(77, 12);
            this.lblAIRecruitmentSpeedRate.TabIndex = 25;
            this.lblAIRecruitmentSpeedRate.Text = "电脑征兵速度";
            // 
            // tbAIRecruitmentSpeedRate
            // 
            this.tbAIRecruitmentSpeedRate.Location = new System.Drawing.Point(130, 200);
            this.tbAIRecruitmentSpeedRate.Name = "tbAIRecruitmentSpeedRate";
            this.tbAIRecruitmentSpeedRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIRecruitmentSpeedRate.TabIndex = 26;
            this.tbAIRecruitmentSpeedRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAITroopDefenceRate
            // 
            this.lblAITroopDefenceRate.AutoSize = true;
            this.lblAITroopDefenceRate.Location = new System.Drawing.Point(13, 121);
            this.lblAITroopDefenceRate.Name = "lblAITroopDefenceRate";
            this.lblAITroopDefenceRate.Size = new System.Drawing.Size(113, 12);
            this.lblAITroopDefenceRate.TabIndex = 23;
            this.lblAITroopDefenceRate.Text = "电脑部队防御力乘数";
            // 
            // tbAITroopDefenceRate
            // 
            this.tbAITroopDefenceRate.Location = new System.Drawing.Point(130, 118);
            this.tbAITroopDefenceRate.Name = "tbAITroopDefenceRate";
            this.tbAITroopDefenceRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITroopDefenceRate.TabIndex = 20;
            this.tbAITroopDefenceRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAIArchitectureDamageRate
            // 
            this.lblAIArchitectureDamageRate.AutoSize = true;
            this.lblAIArchitectureDamageRate.Location = new System.Drawing.Point(13, 148);
            this.lblAIArchitectureDamageRate.Name = "lblAIArchitectureDamageRate";
            this.lblAIArchitectureDamageRate.Size = new System.Drawing.Size(113, 12);
            this.lblAIArchitectureDamageRate.TabIndex = 21;
            this.lblAIArchitectureDamageRate.Text = "电脑建筑伤害率乘数";
            // 
            // tbAIArchitectureDamageRate
            // 
            this.tbAIArchitectureDamageRate.Location = new System.Drawing.Point(130, 145);
            this.tbAIArchitectureDamageRate.Name = "tbAIArchitectureDamageRate";
            this.tbAIArchitectureDamageRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIArchitectureDamageRate.TabIndex = 22;
            this.tbAIArchitectureDamageRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAITroopOffenceRate
            // 
            this.lblAITroopOffenceRate.AutoSize = true;
            this.lblAITroopOffenceRate.Location = new System.Drawing.Point(13, 94);
            this.lblAITroopOffenceRate.Name = "lblAITroopOffenceRate";
            this.lblAITroopOffenceRate.Size = new System.Drawing.Size(113, 12);
            this.lblAITroopOffenceRate.TabIndex = 19;
            this.lblAITroopOffenceRate.Text = "电脑部队攻击力乘数";
            // 
            // tbAITroopOffenceRate
            // 
            this.tbAITroopOffenceRate.Location = new System.Drawing.Point(130, 91);
            this.tbAITroopOffenceRate.Name = "tbAITroopOffenceRate";
            this.tbAITroopOffenceRate.Size = new System.Drawing.Size(57, 21);
            this.tbAITroopOffenceRate.TabIndex = 18;
            this.tbAITroopOffenceRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAIFoodRate
            // 
            this.lblAIFoodRate.AutoSize = true;
            this.lblAIFoodRate.Location = new System.Drawing.Point(13, 67);
            this.lblAIFoodRate.Name = "lblAIFoodRate";
            this.lblAIFoodRate.Size = new System.Drawing.Size(89, 12);
            this.lblAIFoodRate.TabIndex = 17;
            this.lblAIFoodRate.Text = "电脑粮草收入率";
            // 
            // tbAIFoodRate
            // 
            this.tbAIFoodRate.Location = new System.Drawing.Point(130, 64);
            this.tbAIFoodRate.Name = "tbAIFoodRate";
            this.tbAIFoodRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIFoodRate.TabIndex = 16;
            this.tbAIFoodRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // lblAIFundRate
            // 
            this.lblAIFundRate.AutoSize = true;
            this.lblAIFundRate.Location = new System.Drawing.Point(13, 40);
            this.lblAIFundRate.Name = "lblAIFundRate";
            this.lblAIFundRate.Size = new System.Drawing.Size(89, 12);
            this.lblAIFundRate.TabIndex = 15;
            this.lblAIFundRate.Text = "电脑资金收入率";
            // 
            // tbAIFundRate
            // 
            this.tbAIFundRate.Location = new System.Drawing.Point(130, 37);
            this.tbAIFundRate.Name = "tbAIFundRate";
            this.tbAIFundRate.Size = new System.Drawing.Size(57, 21);
            this.tbAIFundRate.TabIndex = 14;
            this.tbAIFundRate.TextChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbPinPointAtPlayer
            // 
            this.cbPinPointAtPlayer.AutoSize = true;
            this.cbPinPointAtPlayer.Location = new System.Drawing.Point(252, 120);
            this.cbPinPointAtPlayer.Name = "cbPinPointAtPlayer";
            this.cbPinPointAtPlayer.Size = new System.Drawing.Size(144, 16);
            this.cbPinPointAtPlayer.TabIndex = 40;
            this.cbPinPointAtPlayer.Text = "电脑视玩家为最大敌人";
            this.cbPinPointAtPlayer.UseVisualStyleBackColor = true;
            this.cbPinPointAtPlayer.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbIgnoreStrategyTendency
            // 
            this.cbIgnoreStrategyTendency.AutoSize = true;
            this.cbIgnoreStrategyTendency.Location = new System.Drawing.Point(254, 230);
            this.cbIgnoreStrategyTendency.Name = "cbIgnoreStrategyTendency";
            this.cbIgnoreStrategyTendency.Size = new System.Drawing.Size(156, 16);
            this.cbIgnoreStrategyTendency.TabIndex = 41;
            this.cbIgnoreStrategyTendency.Text = "忽略电脑君主的战略倾向";
            this.cbIgnoreStrategyTendency.UseVisualStyleBackColor = true;
            // 
            // cbInternalSurplusRateForPlayer
            // 
            this.cbInternalSurplusRateForPlayer.AutoSize = true;
            this.cbInternalSurplusRateForPlayer.Location = new System.Drawing.Point(252, 148);
            this.cbInternalSurplusRateForPlayer.Name = "cbInternalSurplusRateForPlayer";
            this.cbInternalSurplusRateForPlayer.Size = new System.Drawing.Size(144, 16);
            this.cbInternalSurplusRateForPlayer.TabIndex = 41;
            this.cbInternalSurplusRateForPlayer.Text = "收入缩减率对玩家有效";
            this.cbInternalSurplusRateForPlayer.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // cbInternalSurplusRateForAI
            // 
            this.cbInternalSurplusRateForAI.AutoSize = true;
            this.cbInternalSurplusRateForAI.Location = new System.Drawing.Point(252, 175);
            this.cbInternalSurplusRateForAI.Name = "cbInternalSurplusRateForAI";
            this.cbInternalSurplusRateForAI.Size = new System.Drawing.Size(144, 16);
            this.cbInternalSurplusRateForAI.TabIndex = 41;
            this.cbInternalSurplusRateForAI.Text = "收入缩减率对电脑有效";
            this.cbInternalSurplusRateForAI.UseVisualStyleBackColor = true;
            this.cbInternalSurplusRateForAI.CheckedChanged += new System.EventHandler(this.setDifficultyToCustom);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(292, 454);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(374, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // formOptions
            // 
            this.ClientSize = new System.Drawing.Size(453, 485);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tcOptions);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "formOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "游戏设置";
            this.tcOptions.ResumeLayout(false);
            this.tabPageBasic.ResumeLayout(false);
            this.tabPageBasic.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageEnvironment.ResumeLayout(false);
            this.tabPageEnvironment.PerformLayout();
            this.tabPagePerson.ResumeLayout(false);
            this.tabPagePerson.PerformLayout();
            this.tabPageParameter.ResumeLayout(false);
            this.tabPageParameter.PerformLayout();
            this.tabPageAIParameter.ResumeLayout(false);
            this.tabPageAIParameter.PerformLayout();
            this.ResumeLayout(false);

        }


        private void LoadCommonDoc()
        {
            doNotSetDifficultyToCustom = true;
            this.commonDoc.Load("GameData/GlobalVariables.xml");
            XmlNode nextSibling = this.commonDoc.FirstChild.NextSibling;
            this.cbRunWhileNotFocused.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("RunWhileNotFocused").Value);
            this.cbPlayMusic.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayMusic").Value);
            this.cbPlayNormalSound.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayNormalSound").Value);
            this.cbPlayBattleSound.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayBattleSound").Value);
            this.cbDrawMapVeil.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawMapVeil").Value);
            this.cbDrawTroopAnimation.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawTroopAnimation").Value);
            this.cbSkyEye.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("SkyEye").Value);
            this.cbMultipleResource.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("MultipleResource").Value);
            this.cbSingleSelectionOneClick.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("SingleSelectionOneClick").Value);
            this.cbNoHintOnSmallFacility.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("NoHintOnSmallFacility").Value);
            this.cbHintPopulation.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulation").Value);
            this.cbHintPopulationUnder1000.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulationUnder1000").Value);
            this.cbPopulationRecruitmentLimit.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PopulationRecruitmentLimit").Value);
            this.cbMilitaryKindSpeedValid.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("MilitaryKindSpeedValid").Value);
            this.tbTroopMoveSpeed.Text = nextSibling.Attributes.GetNamedItem("TroopMoveSpeed").Value;
            this.cbCommonPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("CommonPersonAvailable").Value);
            this.cbAdditionalPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AdditionalPersonAvailable").Value);
            this.cbPlayerPersonAvailable.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayerPersonAvailable").Value);
            this.cbPersonNaturalDeath.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PersonNaturalDeath").Value);
            this.cbIdealTendencyValid.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("IdealTendencyValid").Value);
            this.cbPinPointAtPlayer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PinPointAtPlayer").Value);
            this.cbIgnoreStrategyTendency.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("IgnoreStrategyTendency").Value);
            this.cbCreateChildren.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildren").Value);
            this.zainanfashengjilv.Text = nextSibling.Attributes.GetNamedItem("zainanfashengjilv").Value;
            this.cbDoAutoSave.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("doAutoSave").Value);
            this.cbCreateChildrenIgnoreLimit.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildrenIgnoreLimit").Value);
            this.cbInternalSurplusRateForPlayer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForPlayer").Value);
            this.cbInternalSurplusRateForAI.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForAI").Value);
            this.tbGetChildrenRate.Text = nextSibling.Attributes.GetNamedItem("getChildrenRate").Value;
            this.tbHougongGetChildrenRate.Text = nextSibling.Attributes.GetNamedItem("hougongGetChildrenRate").Value;
            this.tbAIExecutionRate.Text = nextSibling.Attributes.GetNamedItem("AIExecutionRate").Value;
            this.cbAIExecuteBetterOfficer.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIExecuteBetterOfficer").Value);
            this.tbMaxExperience.Text = nextSibling.Attributes.GetNamedItem("maxExperience").Value;
            this.cbLockChildrenLoyalty.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("lockChildrenLoyalty").Value);
            this.cbAIAutoTakeNoFactionCaptives.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionCaptives").Value);
            this.cbAIAutoTakeNoFactionPerson.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionPerson").Value);
            this.cbAIAutoTakePlayerCaptives.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptives").Value);
            this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptiveOnlyUnfull").Value);
            this.tbDialogShowTime.Text = nextSibling.Attributes.GetNamedItem("DialogShowTime").Value;
            this.tbTechniquePointMultiple.Text = nextSibling.Attributes.GetNamedItem("TechniquePointMultiple").Value;
            this.cbPermitFactionMerge.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PermitFactionMerge").Value);
            this.tbLeadershipOffenceRate.Text = nextSibling.Attributes.GetNamedItem("LeadershipOffenceRate").Value;
            doNotSetDifficultyToCustom = false;
            this.changeDifficultySelection((Difficulty) Enum.Parse(typeof(Difficulty), nextSibling.Attributes.GetNamedItem("GameDifficulty").Value));
            this.checkLiangdaoXitong.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("LiangdaoXitong").Value);
            this.wujiangYoukenengDuli.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("WujiangYoukenengDuli").Value);
            this.tbBattleSpeed.Text = nextSibling.Attributes.GetNamedItem("FastBattleSpeed").Value;
            this.cbEnableCheat.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("EnableCheat").Value);
            this.cbHardcoreMode.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("HardcoreMode").Value);
            this.cbLandArmyCanGoDownWater.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("LandArmyCanGoDownWater").Value);
            this.tbMaxAbility.Text = nextSibling.Attributes.GetNamedItem("MaxAbility").Value;
            this.tbTirednessIncrease.Text = nextSibling.Attributes.GetNamedItem("TirednessIncrease").Value;
            this.tbTirednessDecrease.Text = nextSibling.Attributes.GetNamedItem("TirednessDecrease").Value;
            this.cbEnableAgeAbilityFactor.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("EnableAgeAbilityFactor").Value);
            this.tbTabListDetailLevel.Text = nextSibling.Attributes.GetNamedItem("TabListDetailLevel").Value;
            this.cbShowChallengeAnimation.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("ShowChallengeAnimation").Value);
            this.cbPersonDieInChallenge.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("PersonDieInChallenge").Value);
            this.tbOfficerDieInBattleRate.Text = nextSibling.Attributes.GetNamedItem("OfficerDieInBattleRate").Value;
            this.tbAutosaveFrequency.Text = nextSibling.Attributes.GetNamedItem("AutoSaveFrequency").Value;
            this.tbOfficerChildrenLimit.Text = nextSibling.Attributes.GetNamedItem("OfficerChildrenLimit").Value;
            this.cbStopToControlOnAttack.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("StopToControlOnAttack").Value);
            this.tbMaxMilitaryExperience.Text = nextSibling.Attributes.GetNamedItem("MaxMilitaryExperience").Value;
            this.tbCreateRandomOfficerChance.Text = nextSibling.Attributes.GetNamedItem("CreateRandomOfficerChance").Value;
            
            this.tbCreatedOfficerAbilityFactor.Text = nextSibling.Attributes.GetNamedItem("CreatedOfficerAbilityFactor").Value;
            this.cbEnablePersonRelations.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("EnablePersonRelations").Value);
            this.tbChildrenAvailableAge.Text = nextSibling.Attributes.GetNamedItem("ChildrenAvailableAge").Value;
            this.cbFullScreen.Checked = bool.Parse(nextSibling.Attributes.GetNamedItem("FullScreen").Value);
        }

        private void LoadParameterDoc()
        {
            doNotSetDifficultyToCustom = true;
            this.parameterDoc.Load("GameData/GameParameters.xml");
            XmlNode nextSibling = this.parameterDoc.FirstChild.NextSibling;
            this.tbFindTreasureChance.Text = nextSibling.Attributes.GetNamedItem("FindTreasureChance").Value;
            this.tbLearnSkillDays.Text = nextSibling.Attributes.GetNamedItem("LearnSkillDays").Value;
            this.tbLearnStuntDays.Text = nextSibling.Attributes.GetNamedItem("LearnStuntDays").Value;
            this.tbLearnTitleDays.Text = nextSibling.Attributes.GetNamedItem("LearnTitleDays").Value;
            this.tbSearchDays.Text = nextSibling.Attributes.GetNamedItem("SearchDays").Value;
            this.tbFollowedLeaderOffenceRateIncrement.Text = nextSibling.Attributes.GetNamedItem("FollowedLeaderOffenceRateIncrement").Value;
            this.tbFollowedLeaderDefenceRateIncrement.Text = nextSibling.Attributes.GetNamedItem("FollowedLeaderDefenceRateIncrement").Value;
            this.tbInternalRate.Text = nextSibling.Attributes.GetNamedItem("InternalRate").Value;
            this.tbTrainingRate.Text = nextSibling.Attributes.GetNamedItem("TrainingRate").Value;
            this.tbRecruitmentRate.Text = nextSibling.Attributes.GetNamedItem("RecruitmentRate").Value;
            this.tbFundRate.Text = nextSibling.Attributes.GetNamedItem("FundRate").Value;
            this.tbFoodRate.Text = nextSibling.Attributes.GetNamedItem("FoodRate").Value;
            this.tbTroopDamageRate.Text = nextSibling.Attributes.GetNamedItem("TroopDamageRate").Value;
            this.tbArchitectureDamageRate.Text = nextSibling.Attributes.GetNamedItem("ArchitectureDamageRate").Value;
            this.tbDefaultPopulationDevelopingRate.Text = nextSibling.Attributes.GetNamedItem("DefaultPopulationDevelopingRate").Value;
            this.tbSurroundArchitectureDominationUnit.Text = nextSibling.Attributes.GetNamedItem("SurroundArchitectureDominationUnit").Value;
            this.tbFireDamageScale.Text = nextSibling.Attributes.GetNamedItem("FireDamageScale").Value;
            this.tbBuyFoodAgriculture.Text = nextSibling.Attributes.GetNamedItem("BuyFoodAgriculture").Value;
            this.tbSellFoodCommerce.Text = nextSibling.Attributes.GetNamedItem("SellFoodCommerce").Value;
            this.tbFundToFoodMultiple.Text = nextSibling.Attributes.GetNamedItem("FundToFoodMultiple").Value;
            this.tbFoodToFundDivisor.Text = nextSibling.Attributes.GetNamedItem("FoodToFundDivisor").Value;
            this.tbInternalFundCost.Text = nextSibling.Attributes.GetNamedItem("InternalFundCost").Value;
            this.tbRecruitmentFundCost.Text = nextSibling.Attributes.GetNamedItem("RecruitmentFundCost").Value;
            this.tbRecruitmentDomination.Text = nextSibling.Attributes.GetNamedItem("RecruitmentDomination").Value;
            this.tbRecruitmentMorale.Text = nextSibling.Attributes.GetNamedItem("RecruitmentMorale").Value;
            this.tbChangeCapitalCost.Text = nextSibling.Attributes.GetNamedItem("ChangeCapitalCost").Value;
            this.tbConvincePersonCost.Text = nextSibling.Attributes.GetNamedItem("ConvincePersonCost").Value;
            this.tbRewardPersonCost.Text = nextSibling.Attributes.GetNamedItem("RewardPersonCost").Value;
            this.tbDestroyArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("DestroyArchitectureCost").Value;
            this.tbInstigateArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("InstigateArchitectureCost").Value;
            this.tbGossipArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("GossipArchitectureCost").Value;
            this.tbAIFundRate.Text = nextSibling.Attributes.GetNamedItem("AIFundRate").Value;
            this.tbAIFoodRate.Text = nextSibling.Attributes.GetNamedItem("AIFoodRate").Value;
            this.tbAITroopOffenceRate.Text = nextSibling.Attributes.GetNamedItem("AITroopOffenceRate").Value;
            this.tbAITroopDefenceRate.Text = nextSibling.Attributes.GetNamedItem("AITroopDefenceRate").Value;
            this.tbAIArchitectureDamageRate.Text = nextSibling.Attributes.GetNamedItem("AIArchitectureDamageRate").Value;
            this.tbAITrainingSpeedRate.Text = nextSibling.Attributes.GetNamedItem("AITrainingSpeedRate").Value;
            this.tbAIRecruitmentSpeedRate.Text = nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedRate").Value;
            this.tbAIOfficerExperienceRate.Text = nextSibling.Attributes.GetNamedItem("AIOfficerExperienceRate").Value;
            this.tbAIArmyExperienceRate.Text = nextSibling.Attributes.GetNamedItem("AIArmyExperienceRate").Value;
            this.tbAIFundIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIFundYearIncreaseRate").Value;
            this.tbAIFoodIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIFoodYearIncreaseRate").Value;
            this.tbAITroopOffenceIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AITroopOffenceYearIncreaseRate").Value;
            this.tbAITroopDefenceIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AITroopDefenceYearIncreaseRate").Value;
            this.tbAIArchitectureDamageIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIArchitectureDamageYearIncreaseRate").Value;
            this.tbAITrainingSpeedIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AITrainingSpeedYearIncreaseRate").Value;
            this.tbAIRecruitmentSpeedIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedYearIncreaseRate").Value;
            this.tbAIOfficerExperienceIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIOfficerExperienceYearIncreaseRate").Value;
            this.tbAIArmyExperienceIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIArmyExperienceYearIncreaseRate").Value;
            this.tbLearnSkillSuccessRate.Text = nextSibling.Attributes.GetNamedItem("LearnSkillSuccessRate").Value;
            this.tbLearnStuntSuccessRate.Text = nextSibling.Attributes.GetNamedItem("LearnStuntSuccessRate").Value;
            this.tbLearnTitleSuccessRate.Text = nextSibling.Attributes.GetNamedItem("LearnTitleSuccessRate").Value;
            this.tbJailBreakArchitectureCost.Text = nextSibling.Attributes.GetNamedItem("JailBreakArchitectureCost").Value;
            this.tbMilitaryPopulationCap.Text = nextSibling.Attributes.GetNamedItem("MilitaryPopulationCap").Value;
            this.tbMilitaryPopulationReloadQuantity.Text = nextSibling.Attributes.GetNamedItem("MilitaryPopulationReloadQuantity").Value;
            this.tbAIAntiStratagem.Text = nextSibling.Attributes.GetNamedItem("AIAntiStratagem").Value;
            this.tbAIAntiStratagemIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIAntiStratagemIncreaseRate").Value;
            this.tbAIAntiSurround.Text = nextSibling.Attributes.GetNamedItem("AIAntiSurround").Value;
            this.tbAIAntiSurroundIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIAntiSurroundIncreaseRate").Value;
            this.tbAIEncirclePlayerRate.Text = nextSibling.Attributes.GetNamedItem("AIEncirclePlayerRate").Value;
            this.tbAIExtraPerson.Text = nextSibling.Attributes.GetNamedItem("AIExtraPerson").Value;
            this.tbAIExtraPersonIncreaseRate.Text = nextSibling.Attributes.GetNamedItem("AIExtraPersonIncreaseRate").Value;
            AIEncircleRank = int.Parse(nextSibling.Attributes.GetNamedItem("AIEncircleRank").Value);
            AIEncircleVar = int.Parse(nextSibling.Attributes.GetNamedItem("AIEncircleVar").Value);
            doNotSetDifficultyToCustom = false;
        }

        private bool checkIntSave(XmlNode nextSibling, String xmlName, Label label, TextBox textBox)
        {
            return checkIntSave(nextSibling, xmlName, label.Text, textBox.Text);
        }

        private bool checkIntSave(XmlNode nextSibling, String xmlName, string label, string textToSave) 
        {
            try
            {
                nextSibling.Attributes.GetNamedItem(xmlName).Value = int.Parse(textToSave).ToString();
                return true;
            }
            catch
            {
                MessageBox.Show(label + "必须为-2147483648至2147483647之间的整数", "中华三国志", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool checkFloatSave(XmlNode nextSibling, String xmlName, Label label, TextBox textBox)
        {
            return checkFloatSave(nextSibling, xmlName, label.Text, textBox.Text);
        }

        private bool checkFloatSave(XmlNode nextSibling, String xmlName, string label, string textToSave)
        {
            try
            {
                nextSibling.Attributes.GetNamedItem(xmlName).Value = float.Parse(textToSave).ToString();
                return true;
            }
            catch
            {
                MessageBox.Show(label + "必须为有效的数字", "中华三国志", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool SaveCommonDoc()
        {
            XmlNode nextSibling = this.commonDoc.FirstChild.NextSibling;
            nextSibling.Attributes.GetNamedItem("RunWhileNotFocused").Value = this.cbRunWhileNotFocused.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayMusic").Value = this.cbPlayMusic.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayNormalSound").Value = this.cbPlayNormalSound.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayBattleSound").Value = this.cbPlayBattleSound.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("DrawMapVeil").Value = this.cbDrawMapVeil.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("DrawTroopAnimation").Value = this.cbDrawTroopAnimation.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("SkyEye").Value = this.cbSkyEye.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("MultipleResource").Value = this.cbMultipleResource.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("SingleSelectionOneClick").Value = this.cbSingleSelectionOneClick.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("NoHintOnSmallFacility").Value = this.cbNoHintOnSmallFacility.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("HintPopulation").Value = this.cbHintPopulation.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("HintPopulationUnder1000").Value = this.cbHintPopulationUnder1000.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PopulationRecruitmentLimit").Value = this.cbPopulationRecruitmentLimit.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("MilitaryKindSpeedValid").Value = this.cbMilitaryKindSpeedValid.Checked.ToString();
            if (!checkIntSave(nextSibling, "TroopMoveSpeed", this.lblTroopMoveSpeed, this.tbTroopMoveSpeed)) { return false; }
            nextSibling.Attributes.GetNamedItem("CommonPersonAvailable").Value = this.cbCommonPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AdditionalPersonAvailable").Value = this.cbAdditionalPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PlayerPersonAvailable").Value = this.cbPlayerPersonAvailable.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PersonNaturalDeath").Value = this.cbPersonNaturalDeath.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("IdealTendencyValid").Value = this.cbIdealTendencyValid.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PinPointAtPlayer").Value = this.cbPinPointAtPlayer.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("IgnoreStrategyTendency").Value = this.cbIgnoreStrategyTendency.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("createChildren").Value = this.cbCreateChildren.Checked.ToString();
            if (!checkIntSave(nextSibling, "zainanfashengjilv", this.zainanbiaoqian, this.zainanfashengjilv)) { return false; }
            nextSibling.Attributes.GetNamedItem("doAutoSave").Value = this.cbDoAutoSave.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("createChildrenIgnoreLimit").Value = this.cbCreateChildrenIgnoreLimit.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("internalSurplusRateForPlayer").Value = this.cbInternalSurplusRateForPlayer.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("internalSurplusRateForAI").Value = this.cbInternalSurplusRateForAI.Checked.ToString();
            if (!checkIntSave(nextSibling, "getChildrenRate", this.lblGetChildrenRate, this.tbGetChildrenRate)) { return false; }
            if (!checkIntSave(nextSibling, "hougongGetChildrenRate", this.lblHougongGetChildrenRate, this.tbHougongGetChildrenRate)) { return false; }
            if (!checkIntSave(nextSibling, "AIExecutionRate", this.lblAIExecutionRate, this.tbAIExecutionRate)) { return false; }
            nextSibling.Attributes.GetNamedItem("AIExecuteBetterOfficer").Value = this.cbAIExecuteBetterOfficer.Checked.ToString();
            if (!checkIntSave(nextSibling, "maxExperience", this.lblMaxExperience, this.tbMaxExperience)) { return false; }
            nextSibling.Attributes.GetNamedItem("lockChildrenLoyalty").Value = this.cbLockChildrenLoyalty.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionCaptives").Value = this.cbAIAutoTakeNoFactionCaptives.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionPerson").Value = this.cbAIAutoTakeNoFactionPerson.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptives").Value = this.cbAIAutoTakePlayerCaptives.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptiveOnlyUnfull").Value = this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked.ToString();
            if (!checkIntSave(nextSibling, "DialogShowTime", this.lblDialogShowTime, this.tbDialogShowTime)) { return false; }
            if (!checkFloatSave(nextSibling, "TechniquePointMultiple", this.lblTechniquePointMultiple, this.tbTechniquePointMultiple)) { return false; }
            nextSibling.Attributes.GetNamedItem("PermitFactionMerge").Value = this.cbPermitFactionMerge.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("GameDifficulty").Value = this.getDifficultyFromRadio.ToString();
            if (!checkFloatSave(nextSibling, "LeadershipOffenceRate", this.lblLeadershipOffenceRate, this.tbLeadershipOffenceRate)) { return false; }
            nextSibling.Attributes.GetNamedItem("LiangdaoXitong").Value = this.checkLiangdaoXitong.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("WujiangYoukenengDuli").Value = this.wujiangYoukenengDuli.Checked.ToString();
            if (!checkIntSave(nextSibling, "FastBattleSpeed", this.lblBattleSpeed, this.tbBattleSpeed)) { return false; }
            nextSibling.Attributes.GetNamedItem("EnableCheat").Value = this.cbEnableCheat.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("HardcoreMode").Value = this.cbHardcoreMode.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("LandArmyCanGoDownWater").Value = this.cbLandArmyCanGoDownWater.Checked.ToString();
            if (!checkIntSave(nextSibling, "MaxAbility", this.lblMaxAbility, this.tbMaxAbility)) { return false; }
            if (!checkIntSave(nextSibling, "TirednessIncrease", this.lblTirednessIncrease, this.tbTirednessIncrease)) { return false; }
            if (!checkIntSave(nextSibling, "TirednessDecrease", this.lblTirednessDecrease, this.tbTirednessDecrease)) { return false; }
            nextSibling.Attributes.GetNamedItem("EnableAgeAbilityFactor").Value = this.cbEnableAgeAbilityFactor.Checked.ToString();
            if (!checkIntSave(nextSibling, "TabListDetailLevel", this.lblTabListDetailLevel, this.tbTabListDetailLevel)) { return false; }
            nextSibling.Attributes.GetNamedItem("ShowChallengeAnimation").Value = this.cbShowChallengeAnimation.Checked.ToString();
            nextSibling.Attributes.GetNamedItem("PersonDieInChallenge").Value = this.cbPersonDieInChallenge.Checked.ToString();
            if (!checkIntSave(nextSibling, "OfficerDieInBattleRate", this.lblOfficerDieInBattleRate, this.tbOfficerDieInBattleRate)) { return false; }
            if (!checkIntSave(nextSibling, "AutoSaveFrequency", this.cbDoAutoSave.Text, this.tbAutosaveFrequency.Text)) { return false; }
            if (!checkIntSave(nextSibling, "OfficerChildrenLimit", this.lblOfficerChildrenLimit, this.tbOfficerChildrenLimit)) { return false; }
            nextSibling.Attributes.GetNamedItem("StopToControlOnAttack").Value = this.cbStopToControlOnAttack.Checked.ToString();
            if (!checkIntSave(nextSibling, "MaxMilitaryExperience", this.lblMaxMilitaryExperience, this.tbMaxMilitaryExperience)) { return false; }
            if (!checkFloatSave(nextSibling, "CreateRandomOfficerChance", this.lblCreateRandomOfficerChance, this.tbCreateRandomOfficerChance)) { return false; }
            
            if (!checkFloatSave(nextSibling, "CreatedOfficerAbilityFactor", this.lblCreatedOfficerAbilityFactor, this.tbCreatedOfficerAbilityFactor)) { return false; }
            nextSibling.Attributes.GetNamedItem("EnablePersonRelations").Value = this.cbEnablePersonRelations.Checked.ToString();
            if (!checkIntSave(nextSibling, "ChildrenAvailableAge", this.lblChildrenAvailableAge, this.tbChildrenAvailableAge)) { return false; }
            nextSibling.Attributes.GetNamedItem("FullScreen").Value = this.cbFullScreen.Checked.ToString();
            this.commonDoc.Save("GameData/GlobalVariables.xml");
            return true;
        }

        private bool SaveParameterDoc()
        {
            XmlNode nextSibling = this.parameterDoc.FirstChild.NextSibling;
            if (!checkIntSave(nextSibling, "FindTreasureChance", this.lblFindTreasureChance, this.tbFindTreasureChance)) { return false; }
            if (!checkIntSave(nextSibling, "LearnSkillDays", this.lblLearnSkillDays, this.tbLearnSkillDays)) { return false; }
            if (!checkIntSave(nextSibling, "LearnStuntDays", this.lblLearnStuntDays, this.tbLearnStuntDays)) { return false; }
            if (!checkIntSave(nextSibling, "LearnTitleDays", this.lblLearnTitleDays, this.tbLearnTitleDays)) { return false; }
            if (!checkIntSave(nextSibling, "SearchDays", this.lblSearchDays, this.tbSearchDays)) { return false; }
            if (!checkFloatSave(nextSibling, "FollowedLeaderOffenceRateIncrement", this.lblFollowedLeaderOffenceRateIncrement, this.tbFollowedLeaderOffenceRateIncrement)) { return false; }
            if (!checkFloatSave(nextSibling, "FollowedLeaderDefenceRateIncrement", this.lblFollowedLeaderDefenceRateIncrement, this.tbFollowedLeaderDefenceRateIncrement)) { return false; }
            if (!checkFloatSave(nextSibling, "InternalRate", this.lblInternalRate, this.tbInternalRate)) { return false; }
            if (!checkFloatSave(nextSibling, "TrainingRate", this.lblTrainingRate, this.tbTrainingRate)) { return false; }
            if (!checkFloatSave(nextSibling, "RecruitmentRate", this.lblRecruitmentRate, this.tbRecruitmentRate)) { return false; }
            if (!checkFloatSave(nextSibling, "FundRate", this.lblFundRate, this.tbFundRate)) { return false; }
            if (!checkFloatSave(nextSibling, "FoodRate", this.lblFoodRate, this.tbFoodRate)) { return false; }
            if (!checkFloatSave(nextSibling, "TroopDamageRate", this.lblTroopDamageRate, this.tbTroopDamageRate)) { return false; }
            if (!checkFloatSave(nextSibling, "ArchitectureDamageRate", this.lblArchitectureDamageRate, this.tbArchitectureDamageRate)) { return false; }
            if (!checkFloatSave(nextSibling, "DefaultPopulationDevelopingRate", this.lblDefaultPopulationDevelopingRate, this.tbDefaultPopulationDevelopingRate)) { return false; }
            if (!checkIntSave(nextSibling, "SurroundArchitectureDominationUnit", this.lblSurroundArchitectureDominationUnit, this.tbSurroundArchitectureDominationUnit)) { return false; }
            if (!checkFloatSave(nextSibling, "FireDamageScale", this.lblFireDamageScale, this.tbFireDamageScale)) { return false; }
            if (!checkIntSave(nextSibling, "BuyFoodAgriculture", this.lblBuyFoodAgriculture, this.tbBuyFoodAgriculture)) { return false; }
            if (!checkIntSave(nextSibling, "SellFoodCommerce", this.lblSellFoodCommerce, this.tbSellFoodCommerce)) { return false; }
            if (!checkIntSave(nextSibling, "FundToFoodMultiple", this.lblFundToFoodMultiple, this.tbFundToFoodMultiple)) { return false; }
            if (!checkIntSave(nextSibling, "FoodToFundDivisor", this.lblFoodToFundDivisor, this.tbFoodToFundDivisor)) { return false; }
            if (!checkIntSave(nextSibling, "InternalFundCost", this.lblInternalFundCost, this.tbInternalFundCost)) { return false; }
            if (!checkIntSave(nextSibling, "RecruitmentFundCost", this.lblRecruitmentFundCost, this.tbRecruitmentFundCost)) { return false; }
            if (!checkIntSave(nextSibling, "RecruitmentDomination", this.lblRecruitmentDomination, this.tbRecruitmentDomination)) { return false; }
            if (!checkIntSave(nextSibling, "RecruitmentMorale", this.lblRecruitmentMorale, this.tbRecruitmentMorale)) { return false; }
            if (!checkIntSave(nextSibling, "ChangeCapitalCost", this.lblChangeCapitalCost, this.tbChangeCapitalCost)) { return false; }
            if (!checkIntSave(nextSibling, "ConvincePersonCost", this.lblConvincePersonCost, this.tbConvincePersonCost)) { return false; }
            if (!checkIntSave(nextSibling, "RewardPersonCost", this.lblRewardPersonCost, this.tbRewardPersonCost)) { return false; }
            if (!checkIntSave(nextSibling, "DestroyArchitectureCost", this.lblDestroyArchitectureCost, this.tbDestroyArchitectureCost)) { return false; }
            if (!checkIntSave(nextSibling, "InstigateArchitectureCost", this.lblInstigateArchitectureCost, this.tbInstigateArchitectureCost)) { return false; }
            if (!checkIntSave(nextSibling, "GossipArchitectureCost", this.lblGossipArchitectureCost, this.tbGossipArchitectureCost)) { return false; }
            if (!checkFloatSave(nextSibling, "AIFundRate", this.lblAIFundRate, this.tbAIFundRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIFoodRate", this.lblAIFoodRate, this.tbAIFoodRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITroopOffenceRate", this.lblAITroopOffenceRate, this.tbAITroopOffenceRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITroopDefenceRate", this.lblAITroopDefenceRate, this.tbAITroopDefenceRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIArchitectureDamageRate", this.lblAIArchitectureDamageRate, this.tbAIArchitectureDamageRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITrainingSpeedRate", this.lblAITrainingSpeedRate, this.tbAITrainingSpeedRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIRecruitmentSpeedRate", this.lblAIRecruitmentSpeedRate, this.tbAIRecruitmentSpeedRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIOfficerExperienceRate", this.lblAIOfficerExperienceRate, this.tbAIOfficerExperienceRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIArmyExperienceRate", this.lblAIArmyExperienceRate, this.tbAIArmyExperienceRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIFundYearIncreaseRate", this.lblAIFundRate, this.tbAIFundIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIFoodYearIncreaseRate", this.lblAIFoodRate, this.tbAIFoodIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITroopOffenceYearIncreaseRate", this.lblAITroopOffenceRate, this.tbAITroopOffenceIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITroopDefenceYearIncreaseRate", this.lblAITroopDefenceRate, this.tbAITroopDefenceIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIArchitectureDamageYearIncreaseRate", this.lblAIArchitectureDamageRate, this.tbAIArchitectureDamageIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AITrainingSpeedYearIncreaseRate", this.lblAITrainingSpeedRate, this.tbAITrainingSpeedIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIRecruitmentSpeedYearIncreaseRate", this.lblAIRecruitmentSpeedRate, this.tbAIRecruitmentSpeedIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIOfficerExperienceYearIncreaseRate", this.lblAIOfficerExperienceRate, this.tbAIOfficerExperienceIncreaseRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIArmyExperienceYearIncreaseRate", this.lblAIArmyExperienceRate, this.tbAIArmyExperienceIncreaseRate)) { return false; }
            if (!checkIntSave(nextSibling, "LearnSkillSuccessRate", this.lblLearnSkillSuccessRate, this.tbLearnSkillSuccessRate)) { return false; }
            if (!checkIntSave(nextSibling, "LearnStuntSuccessRate", this.lblLearnStuntSuccessRate, this.tbLearnStuntSuccessRate)) { return false; }
            if (!checkIntSave(nextSibling, "LearnTitleSuccessRate", this.lblLearnTitleSuccessRate, this.tbLearnTitleSuccessRate)) { return false; }
            if (!checkIntSave(nextSibling, "JailBreakArchitectureCost", this.lblJailBreakArchitectureCost, this.tbJailBreakArchitectureCost)) { return false; }
            if (!checkFloatSave(nextSibling, "MilitaryPopulationCap", this.lblMilitaryPopulationCap, this.tbMilitaryPopulationCap)) { return false; }
            if (!checkFloatSave(nextSibling, "MilitaryPopulationReloadQuantity", this.lblMilitaryPopulationReloadQuantity, this.tbMilitaryPopulationReloadQuantity)) { return false; }
            if (!checkIntSave(nextSibling, "AIAntiStratagem", this.lblAIAntiStratagem, this.tbAIAntiStratagem)) { return false; }
            if (!checkFloatSave(nextSibling, "AIAntiStratagemIncreaseRate", this.lblAIAntiStratagem, this.tbAIAntiStratagemIncreaseRate)) { return false; }
            if (!checkIntSave(nextSibling, "AIAntiSurround", this.lblAIAntiSurround, this.tbAIAntiSurround)) { return false; }
            if (!checkFloatSave(nextSibling, "AIAntiSurroundIncreaseRate", this.lblAIAntiSurround, this.tbAIAntiSurroundIncreaseRate)) { return false; }
            if (!checkIntSave(nextSibling, "AIEncirclePlayerRate", this.lblAIEncirclePlayerRate, this.tbAIEncirclePlayerRate)) { return false; }
            if (!checkFloatSave(nextSibling, "AIExtraPerson", this.lblAIExtraPerson, this.tbAIExtraPerson)) { return false; }
            if (!checkFloatSave(nextSibling, "AIExtraPersonIncreaseRate", this.lblAIExtraPerson, this.tbAIExtraPersonIncreaseRate)) { return false; }
            nextSibling.Attributes.GetNamedItem("AIEncircleRank").Value = this.AIEncircleRank.ToString();
            nextSibling.Attributes.GetNamedItem("AIEncircleVar").Value = this.AIEncircleVar.ToString();
            this.parameterDoc.Save("GameData/GameParameters.xml");
            return true;
        }

        private Difficulty getDifficultyFromRadio
        {
            get
            {
                if (this.rbBeginner.Checked)
                {
                    return Difficulty.beginner;
                }
                else if (this.rbEasy.Checked)
                {
                    return Difficulty.easy;
                }
                else if (this.rbNormal.Checked)
                {
                    return Difficulty.normal;
                }
                else if (this.rbHard.Checked)
                {
                    return Difficulty.hard;
                }
                else if (this.rbVeryhard.Checked)
                {
                    return Difficulty.veryhard;
                }
                else if (this.rbCustom.Checked)
                {
                    return Difficulty.custom;
                }
                return Difficulty.custom;
            }
        }

        private void changeDifficultySelection(Difficulty d)
        {
            this.rbBeginner.Checked = false;
            this.rbEasy.Checked = false;
            this.rbNormal.Checked = false;
            this.rbHard.Checked = false;
            this.rbVeryhard.Checked = false;
            this.rbCustom.Checked = false;
            switch (d)
            {
                case Difficulty.beginner: this.rbBeginner.Checked = true; break;
                case Difficulty.easy: this.rbEasy.Checked = true; break;
                case Difficulty.normal: this.rbNormal.Checked = true; break;
                case Difficulty.hard: this.rbHard.Checked = true; break;
                case Difficulty.veryhard: this.rbVeryhard.Checked = true; break;
                case Difficulty.custom: this.rbCustom.Checked = true; break;
                default: this.rbCustom.Checked = true; break;
            }
        }

        private void beginnerSelected(object sender, EventArgs e)
        {
            if (rbBeginner.Checked)
            {
                this.setDifficultyParameters(Difficulty.beginner);
            }
        }

        private void easySelected(object sender, EventArgs e)
        {
            if (rbEasy.Checked)
            {
                this.setDifficultyParameters(Difficulty.easy);
            }
        }

        private void normalSelected(object sender, EventArgs e)
        {
            if (rbNormal.Checked)
            {
                this.setDifficultyParameters(Difficulty.normal);
            }
        }

        private void hardSelected(object sender, EventArgs e)
        {
            if (rbHard.Checked)
            {
                this.setDifficultyParameters(Difficulty.hard);
            }
        }

        private void veryhardSelected(object sender, EventArgs e)
        {
            if (rbVeryhard.Checked)
            {
                this.setDifficultyParameters(Difficulty.veryhard);
            }
        }

        private void setDifficultyParameters(Difficulty d)
        {
            doNotSetDifficultyToCustom = true;
            switch (d)
            {
                case Difficulty.beginner:
                    this.tbAIFundRate.Text = "0.7";
                    this.tbAIFoodRate.Text = "0.7";
                    this.tbAIArchitectureDamageRate.Text = "0.7";
                    this.tbAITroopOffenceRate.Text = "0.7";
                    this.tbAITroopDefenceRate.Text = "0.7";
                    this.tbAIRecruitmentSpeedRate.Text = "0.7";
                    this.tbAITrainingSpeedRate.Text = "0.7";
                    this.tbAIOfficerExperienceRate.Text = "0.7";
                    this.tbAIArmyExperienceRate.Text = "0.7";
                    this.tbAIAntiStratagem.Text = "0";
                    this.tbAIAntiSurround.Text = "0";
                    this.tbAIFundIncreaseRate.Text = "0.0";
                    this.tbAIFoodIncreaseRate.Text = "0.0";
                    this.tbAIArchitectureDamageIncreaseRate.Text = "0.0";
                    this.tbAITroopOffenceIncreaseRate.Text = "0.0";
                    this.tbAITroopDefenceIncreaseRate.Text = "0.0";
                    this.tbAIRecruitmentSpeedIncreaseRate.Text = "0.0";
                    this.tbAITrainingSpeedIncreaseRate.Text = "0.0";
                    this.tbAIOfficerExperienceIncreaseRate.Text = "0.0";
                    this.tbAIArmyExperienceIncreaseRate.Text = "0.0";
                    this.tbAIAntiStratagemIncreaseRate.Text = "0.0";
                    this.tbAIAntiSurroundIncreaseRate.Text = "0.0";
                    this.cbPinPointAtPlayer.Checked = false;
                    this.cbInternalSurplusRateForPlayer.Checked = false;
                    this.cbInternalSurplusRateForAI.Checked = true;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    this.tbAIEncirclePlayerRate.Text = "0";
                    this.tbAIExtraPerson.Text = "1.0";
                    this.tbAIExtraPersonIncreaseRate.Text = "0.0";
                    this.AIEncircleRank = 0;
                    this.AIEncircleVar = 0;
                    break;
                case Difficulty.easy:
                    this.tbAIFundRate.Text = "1.0";
                    this.tbAIFoodRate.Text = "1.0";
                    this.tbAIArchitectureDamageRate.Text = "1.0";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.0";
                    this.tbAIRecruitmentSpeedRate.Text = "1.0";
                    this.tbAITrainingSpeedRate.Text = "1.0";
                    this.tbAIOfficerExperienceRate.Text = "1.0";
                    this.tbAIArmyExperienceRate.Text = "1.0";
                    this.tbAIAntiStratagem.Text = "0";
                    this.tbAIAntiSurround.Text = "0";
                    this.tbAIFundIncreaseRate.Text = "0.0";
                    this.tbAIFoodIncreaseRate.Text = "0.0";
                    this.tbAIArchitectureDamageIncreaseRate.Text = "0.0";
                    this.tbAITroopOffenceIncreaseRate.Text = "0.0";
                    this.tbAITroopDefenceIncreaseRate.Text = "0.0";
                    this.tbAIRecruitmentSpeedIncreaseRate.Text = "0.0";
                    this.tbAITrainingSpeedIncreaseRate.Text = "0.0";
                    this.tbAIOfficerExperienceIncreaseRate.Text = "0.0";
                    this.tbAIArmyExperienceIncreaseRate.Text = "0.0";
                    this.tbAIAntiStratagemIncreaseRate.Text = "0.0";
                    this.tbAIAntiSurroundIncreaseRate.Text = "0.0";
                    this.cbPinPointAtPlayer.Checked = false;
                    this.cbInternalSurplusRateForPlayer.Checked = true;
                    this.cbInternalSurplusRateForAI.Checked = true;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    this.tbAIEncirclePlayerRate.Text = "0";
                    this.tbAIExtraPerson.Text = "1.0";
                    this.tbAIExtraPersonIncreaseRate.Text = "0.0";
                    this.AIEncircleRank = 15;
                    this.AIEncircleVar = 15;
                    break;
                case Difficulty.normal:
                    this.tbAIFundRate.Text = "2.0";
                    this.tbAIFoodRate.Text = "2.0";
                    this.tbAIArchitectureDamageRate.Text = "1.0";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.0";
                    this.tbAIRecruitmentSpeedRate.Text = "1.2";
                    this.tbAITrainingSpeedRate.Text = "1.2";
                    this.tbAIOfficerExperienceRate.Text = "1.0";
                    this.tbAIArmyExperienceRate.Text = "1.5";
                    this.tbAIAntiStratagem.Text = "0";
                    this.tbAIAntiSurround.Text = "0";
                    this.tbAIFundIncreaseRate.Text = "0.02";
                    this.tbAIFoodIncreaseRate.Text = "0.02";
                    this.tbAIArchitectureDamageIncreaseRate.Text = "0.0";
                    this.tbAITroopOffenceIncreaseRate.Text = "0.0";
                    this.tbAITroopDefenceIncreaseRate.Text = "0.0";
                    this.tbAIRecruitmentSpeedIncreaseRate.Text = "0.02";
                    this.tbAITrainingSpeedIncreaseRate.Text = "0.02";
                    this.tbAIOfficerExperienceIncreaseRate.Text = "0.0";
                    this.tbAIArmyExperienceIncreaseRate.Text = "0.01";
                    this.tbAIAntiStratagemIncreaseRate.Text = "0.0";
                    this.tbAIAntiSurroundIncreaseRate.Text = "0.0";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = true;
                    this.cbInternalSurplusRateForAI.Checked = true;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = false;
                    this.cbAIAutoTakeNoFactionPerson.Checked = false;
                    this.cbAIAutoTakePlayerCaptives.Checked = false;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    this.tbAIEncirclePlayerRate.Text = "5";
                    this.tbAIExtraPerson.Text = "1.2";
                    this.tbAIExtraPersonIncreaseRate.Text = "0.0";
                    this.AIEncircleRank = 30;
                    this.AIEncircleVar = 30;
                    break;
                case Difficulty.hard:
                    this.tbAIFundRate.Text = "3.0";
                    this.tbAIFoodRate.Text = "3.0";
                    this.tbAIArchitectureDamageRate.Text = "1.2";
                    this.tbAITroopOffenceRate.Text = "1.0";
                    this.tbAITroopDefenceRate.Text = "1.2";
                    this.tbAIRecruitmentSpeedRate.Text = "1.5";
                    this.tbAITrainingSpeedRate.Text = "1.5";
                    this.tbAIOfficerExperienceRate.Text = "1.0";
                    this.tbAIArmyExperienceRate.Text = "2.0";
                    this.tbAIAntiStratagem.Text = "0";
                    this.tbAIAntiSurround.Text = "0";
                    this.tbAIFundIncreaseRate.Text = "0.05";
                    this.tbAIFoodIncreaseRate.Text = "0.05";
                    this.tbAIArchitectureDamageIncreaseRate.Text = "0.005";
                    this.tbAITroopOffenceIncreaseRate.Text = "0.0";
                    this.tbAITroopDefenceIncreaseRate.Text = "0.01";
                    this.tbAIRecruitmentSpeedIncreaseRate.Text = "0.05";
                    this.tbAITrainingSpeedIncreaseRate.Text = "0.05";
                    this.tbAIOfficerExperienceIncreaseRate.Text = "0.0";
                    this.tbAIArmyExperienceIncreaseRate.Text = "0.02";
                    this.tbAIAntiStratagemIncreaseRate.Text = "0.2";
                    this.tbAIAntiSurroundIncreaseRate.Text = "0.2";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = true;
                    this.cbInternalSurplusRateForAI.Checked = true;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = true;
                    this.cbAIAutoTakeNoFactionPerson.Checked = true;
                    this.cbAIAutoTakePlayerCaptives.Checked = true;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = true;
                    this.tbAIEncirclePlayerRate.Text = "20";
                    this.tbAIExtraPerson.Text = "1.5";
                    this.tbAIExtraPersonIncreaseRate.Text = "0.01";
                    this.AIEncircleRank = 70;
                    this.AIEncircleVar = 30;
                    break;
                case Difficulty.veryhard:
                    this.tbAIFundRate.Text = "6.0";
                    this.tbAIFoodRate.Text = "6.0";
                    this.tbAIArchitectureDamageRate.Text = "1.5";
                    this.tbAITroopOffenceRate.Text = "1.2";
                    this.tbAITroopDefenceRate.Text = "1.5";
                    this.tbAIRecruitmentSpeedRate.Text = "3.0";
                    this.tbAITrainingSpeedRate.Text = "3.0";
                    this.tbAIOfficerExperienceRate.Text = "1.0";
                    this.tbAIArmyExperienceRate.Text = "4.0";
                    this.tbAIAntiStratagem.Text = "0";
                    this.tbAIAntiSurround.Text = "0";
                    this.tbAIFundIncreaseRate.Text = "0.2";
                    this.tbAIFoodIncreaseRate.Text = "0.2";
                    this.tbAIArchitectureDamageIncreaseRate.Text = "0.02";
                    this.tbAITroopOffenceIncreaseRate.Text = "0.0";
                    this.tbAITroopDefenceIncreaseRate.Text = "0.05";
                    this.tbAIRecruitmentSpeedIncreaseRate.Text = "0.1";
                    this.tbAITrainingSpeedIncreaseRate.Text = "0.1";
                    this.tbAIOfficerExperienceIncreaseRate.Text = "0.0";
                    this.tbAIArmyExperienceIncreaseRate.Text = "0.1";
                    this.tbAIAntiStratagemIncreaseRate.Text = "1.0";
                    this.tbAIAntiSurroundIncreaseRate.Text = "1.0";
                    this.cbPinPointAtPlayer.Checked = true;
                    this.cbInternalSurplusRateForPlayer.Checked = true;
                    this.cbInternalSurplusRateForAI.Checked = false;
                    this.cbAIAutoTakeNoFactionCaptives.Checked = true;
                    this.cbAIAutoTakeNoFactionPerson.Checked = true;
                    this.cbAIAutoTakePlayerCaptives.Checked = true;
                    this.cbAIAutoTakePlayerCaptiveOnlyUnfull.Checked = false;
                    this.tbAIEncirclePlayerRate.Text = "100";
                    this.tbAIExtraPerson.Text = "3.0";
                    this.tbAIExtraPersonIncreaseRate.Text = "0.05";
                    this.AIEncircleRank = 100;
                    this.AIEncircleVar = 0;
                    break;
            }
            doNotSetDifficultyToCustom = false;
        }

        private bool doNotSetDifficultyToCustom = false;
        private void setDifficultyToCustom(object sender, EventArgs e)
        {
            if (!doNotSetDifficultyToCustom)
            {
                changeDifficultySelection(Difficulty.custom);
            }
        }

        private void lblCreateRandomOfficerChance_Click(object sender, EventArgs e)
        {

        }

    }

 

}
