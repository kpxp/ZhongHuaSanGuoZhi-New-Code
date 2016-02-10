namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.FactionDetail;
    using GameObjects.PersonDetail;
    //using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using GameObjects.Influences;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.IO;
    using GameObjects.Conditions;

    public class Person : GameObject
    {
        private int maxExperience = GlobalVariables.maxExperience;
        public bool huaiyun = false;
        public bool shoudongsousuo = false;
        public int huaiyuntianshu = -1;
        public bool ManualStudy = false;

        private int numberOfChildren ;

        public bool faxianhuaiyun = false;

        public int suoshurenwu = -1;

        private bool alive;
        private int ambition;
        private int arrivingDays;
        private bool available;
        private int availableLocation;
        private float baseImpactRate;
        private PersonBornRegion bornRegion;
        private int braveness;
        private PersonList brothers = new PersonList();
        private float bubingExperience;
        private string calledName;
        private int calmness;
        public int ChanceOfNoCapture;
        public CharacterKind Character;
        private PersonList closePersons = new PersonList();
        private int command;
        private float commandExperience;
        public Person ConvincingPerson;
        public int ConvincingPersonID;
        private InformationKind currentInformationKind;
        public bool DayAvoidInfluenceByBattle;
        public bool DayAvoidInternalDecrementOnBattle;
        public bool DayAvoidPopulationEscape;
        public int DayLearnTitleDay = 90;
        public bool DayLocationLoyaltyNoChange;
        public float DayRateIncrementOfInternal = 0f;
        private PersonDeadReason deadReason;
        private Person father = null;
        private PersonForm form;
        private int generation;
        private string givenName;
        private int glamour;
        private float glamourExperience;
        private PersonList hatedPersons = new PersonList();
        private int ideal;
        public IdealTendencyKind IdealTendency;
        public bool ImmunityOfCaptive;
        public bool ImmunityOfDieInBattle;
        private float impactRateOfBadForm;
        private float impactRateOfGoodForm;
        public int IncrementOfAgricultureAbility;
        public int IncrementOfChallengeWinningChance;
        public int IncrementOfCommerceAbility;
        public int IncrementOfControversyWinningChance;
        public int IncrementOfDominationAbility;
        public int IncrementOfEnduranceAbility;
        public int IncrementOfMoraleAbility;
        public int IncrementOfRecruitmentAbility;
        public int IncrementOfSpyDays;
        public int IncrementOfTechnologyAbility;
        public int IncrementOfTrainingAbility;
        public bool InevitableSuccessOfConvince;
        public bool InevitableSuccessOfDestroy;
        public bool InevitableSuccessOfGossip;
        public bool InevitableSuccessOfInstigate;
        public bool InevitableSuccessOfSearch;
        public bool InevitableSuccessOfSpy;
        public bool InevitableSuccessOfJailBreak;
        public int InfluenceIncrementOfCommand;
        public int InfluenceIncrementOfGlamour;
        public int InfluenceIncrementOfIntelligence;
        public int InfluenceIncrementOfPolitics;
        public int InfluenceIncrementOfStrength;
        public int InfluenceIncrementOfReputation;
        public int InfluenceIncrementOfLoyalty;
        public float InfluenceRateOfBadForm;
        public float InfluenceRateOfCommand = 1f;
        public float InfluenceRateOfGlamour = 1f;
        public float InfluenceRateOfGoodForm;
        public float InfluenceRateOfIntelligence = 1f;
        public float InfluenceRateOfPolitics = 1f;
        public float InfluenceRateOfStrength = 1f;
        private int informationKindID = -1;
        private int intelligence;
        private float intelligenceExperience;
        private float internalExperience;
        public bool InternalNoFundNeeded;
        private bool leaderPossibility;
        private int loyalty;
        public int MonthIncrementOfFactionReputation = 0;
        public int MonthIncrementOfTechniquePoint = 0;
        private Person mother = null;
        public int MultipleOfAgricultureReputation = 1;
        public int MultipleOfAgricultureTechniquePoint = 1;
        public int MultipleOfCommerceReputation = 1;
        public int MultipleOfCommerceTechniquePoint = 1;
        public int MultipleOfDominationReputation = 1;
        public int MultipleOfDominationTechniquePoint = 1;
        public int MultipleOfEnduranceReputation = 1;
        public int MultipleOfEnduranceTechniquePoint = 1;
        public int MultipleOfMoraleReputation = 1;
        public int MultipleOfMoraleTechniquePoint = 1;
        public int MultipleOfRecruitmentReputation = 1;
        public int MultipleOfRecruitmentTechniquePoint = 1;
        public int MultipleOfTacticsReputation = 1;
        public int MultipleOfTacticsTechniquePoint = 1;
        public int MultipleOfTechnologyReputation = 1;
        public int MultipleOfTechnologyTechniquePoint = 1;
        public int MultipleOfTrainingReputation = 1;
        public int MultipleOfTrainingTechniquePoint = 1;
        private float nubingExperience;
        private List<int> joinFactionID = new List<int>();
        private Dictionary<int, int> prohibitedFactionID = new Dictionary<int, int>();
        public ArchitectureWorkKind OldWorkKind = ArchitectureWorkKind.无;
        public ArchitectureWorkKind firstPreferred = ArchitectureWorkKind.无;
        private Point? outsideDestination;
        private OutsideTaskKind outsideTask;
        private int personalLoyalty;
        public Biography PersonBiography;
        private int pictureIndex;
        private int politics;
        private float politicsExperience;
        private float qibingExperience;
        private float qixieExperience;
        private PersonQualification qualification;
        public int RadiusIncrementOfInformation;
        public float RateIncrementOfAgricultureAbility;
        public float RateIncrementOfCommerceAbility;
        public float RateIncrementOfConvince;
        public float RateIncrementOfDestroy;
        public float RateIncrementOfDominationAbility;
        public float RateIncrementOfEnduranceAbility;
        public float RateIncrementOfGossip;
        public float RateIncrementOfInstigate;
        public float RateIncrementOfJailBreakAbility;
        public float RateIncrementOfMoraleAbility;
        public float RateIncrementOfRecruitmentAbility;
        public float RateIncrementOfSearch;
        public float RateIncrementOfTechnologyAbility;
        public float RateIncrementOfTrainingAbility;
        private Military recruitmentMilitary;
        private int reputation;
        public bool RewardFinished;
        private int routCount;
        private int routedCount;
        private bool sex = false;
        private float shuijunExperience;
        public SkillTable Skills = new SkillTable();
        private Person spouse = null;
        private int strain;
        private float stratagemExperience;
        private PersonStrategyTendency strategyTendency;
        private int strength;
        private float strengthExperience;
        public Stunt StudyingStunt;
        public Title StudyingTitle;
        public GameObjectList StudySkillList = new GameObjectList();
        public GameObjectList StudyStuntList = new GameObjectList();
        public GameObjectList StudyTitleList = new GameObjectList();

        public GameObjectList AppointableTitleList = new GameObjectList();//封官列表

        public StuntTable Stunts = new StuntTable();
        private string surName;
        private float tacticsExperience;
        public Architecture TargetArchitecture;
        private int taskDays;
        public TreasureList Treasures = new TreasureList();
        private PersonValuationOnGovernment valuationOnGovernment;
        private ArchitectureWorkKind workKind = ArchitectureWorkKind.无;
        private int yearAvailable;
        private int yearBorn;
        private int yearDead;
        private Dictionary<Person, int> relations = new Dictionary<Person, int>();
        public List<Title> RealTitles = new List<Title>();

        //public List<Title> RealGuanzhis = new List<Title>();
       // public TitleTable Guanzhis = new TitleTable();

        public MilitaryKindTable UniqueMilitaryKinds = new MilitaryKindTable();
        public TitleTable UniqueTitles = new TitleTable();

        private PersonStatus status;

        private Person waitForFeiZi = null;
        private int waitForFeiZiPeriod = 0;

        public int waitForFeiziId;

        public float ExperienceRate;

        public int CommandExperienceIncrease { get; set; }
        public int StrengthExperienceIncrease { get; set; }
        public int IntelligenceExperienceIncrease { get; set; }
        public int PoliticsExperienceIncrease { get; set; }
        public int GlamourExperienceIncrease { get; set; }
        public int ReputationDayIncrease { get; set; }

        //public OngoingBattle Battle { get; set; }
        public int BattleSelfDamage { get; set; }
        
        public String Tags {get; set;}

        private Captive belongedCaptive;
        public Captive BelongedCaptive
        {
            get
            {
                return belongedCaptive;
            }
        }

        public void SetBelongedCaptive(Captive c, PersonStatus newState)
        {
            this.belongedCaptive = c;
            if (c == null)
            {
                this.Status = newState;
            }
            else
            {
                this.Status = PersonStatus.Captive;
            }
        }

        private float injureRate = 1.0f;

        public float InjureRate
        {
            get
            {
                if (!this.Alive)
                {
                    return 1;
                }
                if (this.Identity() != 0)
                {
                    return injureRate;
                }
                return 1;
            }
            set
            {
                if (this.Identity() != 0)
                {
                    injureRate = value;
                }
            }
        }

        public int captiveEscapeChance;
        public int pregnantChance;
        public int childrenAbilityIncrease;
        public int childrenSkillChanceIncrease;
        public int childrenStuntChanceIncrease;
        public int childrenTitleChanceIncrease;
        public int childrenReputationIncrease;
        public int childrenLoyalty;
        public int childrenLoyaltyRate;
        public int multipleChildrenRate;
        public int maxChildren = 1;
        public int chanceTirednessStopIncrease;
        public int bravenessIncrease;
        public int calmnessIncrease;

        public PersonList preferredTroopPersons = new PersonList();
        public string preferredTroopPersonsString;

        private Troop locationTroop = null;
        public Troop LocationTroop
        {
            get
            {
                return locationTroop;
            }
            set
            {
                locationTroop = value;
            }
        }

        private Architecture locationArchitecture = null;
        public Architecture LocationArchitecture
        {
            get
            {
                return locationArchitecture;
            }
            set
            {
                locationArchitecture = value;
            }
        }

        private Dictionary<int, Treasure> effectiveTreasures = new Dictionary<int, Treasure>();

        private int tiredness;

        public int Tiredness
        {
            get
            {
                if (!this.Alive)
                {
                    return 0;
                }
                if (this.Identity() != 0)
                {
                    return tiredness;
                }
                return 0;
            }
            set
            {
                if (this.Identity() != 0)
                {
                    tiredness = value;
                }
            }
        }

        public int HasHorse()
        {
            foreach (Treasure treasure in this.Treasures)
            {
                if (treasure.Influences.HasInfluenceKind(5110))
                {
                    return treasure.ID;
                }
            }
            return -1;
        }

        public bool CanOwnTitleByAge(Title t)
        {
            if (!GlobalVariables.EnableAgeAbilityFactor) return true;
            if (t == null) return true;
            return (this.ID * 953
                    + (this.Name.Length > 0 ? this.Name[0] : 753) * 866
                    + (this.Name.Length > 1 ? this.Name[1] : 125) * 539
                    + t.ID * 829
                    + (t.Description.Length > 0 ? t.Description[0] : 850) * 750
                    ) % 15 < this.Age
                    && (this.Age > t.Level * 3 || this.Age >= 15);
        }

        public List<Title> Titles
        {
            get
            {
                List<Title> result = new List<Title>();
                foreach (Title t in this.RealTitles)
                {
                    if (!GlobalVariables.EnableAgeAbilityFactor || this.CanOwnTitleByAge(t))
                    {
                        result.Add(t);
                    }
                }
                return result;
            }
        }
        /*
        public List<Guanzhi> Guanzhis
        {
            get
            {
                List<Guanzhi> result = new List<Guanzhi>();
                foreach (Guanzhi g in this.RealGuanzhis)
                {
                    result.Add(g);
                }
                return result;
            }
        }
        */
         
        public int TotalTitleLevel
        {
            get
            {
                int result = 0;
                foreach (Title t in this.Titles)
                {
                    result += t.Level;
                }
                return result;
            }
        }
        /*
        public Guanzhi getGuanzhiOfKind(GuanzhiKind kind)
        {
            foreach (Guanzhi g in this.Guanzhis)
            {
                if (g.Kind == kind)
                {
                    return g;
                }
            }
            return null;
        }
        */

        public Title getTitleOfKind(TitleKind kind)
        {
            foreach (Title t in this.Titles)
            {
                if (t.Kind == kind)
                {
                    return t;
                }
            }
            return null;
        }

        public int YearJoin { get; set; }
        public int TroopDamageDealt { get; set; }
        public int TroopBeDamageDealt { get; set; }
        public int ArchitectureDamageDealt { get; set; }
        public int RebelCount { get; set; }
        public int ExecuteCount { get; set; }
        public int OfficerKillCount { get; set; }
        public int FleeCount { get; set; }
        public int HeldCaptiveCount { get; set; }
        public int CaptiveCount { get; set; }
        public int StratagemSuccessCount { get; set; }
        public int StratagemFailCount { get; set; }
        public int StratagemBeSuccessCount { get; set; }
        public int StratagemBeFailCount { get; set; }

        private int agricultureAbility = 0; // 缓存这几个变量
        private int commerceAbility = 0;
        private int technologyAbility = 0;
        private int moraleAbility = 0;
        private int dominationAbility = 0;
        private int enduranceAbility = 0;
        private int trainingAbility = 0;

        public List<KeyValuePair<int, int>> CommandDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> CommandIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> StrengthDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> StrengthIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> IntelligenceDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> IntelligenceIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> PoliticsDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> PoliticsIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> GlamourDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> GlamourIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> ReputationDecrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> ReputationIncrease = new List<KeyValuePair<int, int>>();
        public List<KeyValuePair<int, int>> LoseSkill = new List<KeyValuePair<int, int>>();

        private OutsideTaskKind lastOutsideTask = OutsideTaskKind.无;

        public OutsideTaskKind LastOutsideTask
        {
            get
            {
                return lastOutsideTask;
            }
            private set
            {
                lastOutsideTask = value;
            }
        }

        private int returnedDaySince = 0;

        public int ReturnedDaySince
        {
            get
            {
                return returnedDaySince;
            }
            private set
            {
                returnedDaySince = value;
            }
        }

        public int ServedYears
        {
            get
            {
                if (this.Status != PersonStatus.Normal && this.Status != PersonStatus.Moving) return 0;
                int year = base.Scenario.Date.Year - this.YearJoin;
                int sinceBeginning = base.Scenario.DaySince / 360;
                return Math.Min(year, sinceBeginning);
            }
        }

        public PersonStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                if (value == PersonStatus.Moving && this.LocationTroop != null)
                {
                    this.LocationTroop = null;
                }
                if (value != PersonStatus.Normal)
                {
                    if (this.RecruitmentMilitary != null)
                    {
                        this.RecruitmentMilitary.StopRecruitment();
                    }
                    this.WorkKind = ArchitectureWorkKind.无;
                }
                if (value != PersonStatus.Normal && status == PersonStatus.Normal)
                {
                    this.PurifySkills(true);
                    this.PurifyTitles(true);
                    this.PurifyAllTreasures(true);
                    this.PurifyArchitectureInfluence(true);
                    this.PurifyFactionInfluence(true);
                }
                else if (value == PersonStatus.Normal && status == PersonStatus.Moving)
                {
                    this.ApplySkills(true);
                    this.ApplyTitles(true);
                    this.ApplyAllTreasures(true);
                    this.ApplyArchitectureInfluence(true);
                    this.ApplyFactionInfluence(true);
                }
                base.Scenario.ClearPersonWorkCache();
                base.Scenario.ClearPersonStatusCache();
                status = value;
            }
        }

        public Faction BelongedFaction
        {
            get
            {
                if ((this.Status == PersonStatus.Normal || this.Status == PersonStatus.Moving) && this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Normal && this.LocationTroop != null)
                {
                    return this.LocationTroop.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Captive)
                {
                    return this.BelongedCaptive.CaptiveFaction;
                }
                return null;
            }
        }

        public Faction BelongedFactionWithPrincess
        {
            get
            {
                if ((this.Status == PersonStatus.Normal || this.Status == PersonStatus.Moving || this.Status == PersonStatus.Princess) && this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Normal && this.LocationTroop != null)
                {
                    return this.LocationTroop.BelongedFaction;
                }
                else if (this.Status == PersonStatus.Captive)
                {
                    return this.BelongedCaptive.CaptiveFaction;
                }
                return null;
            }
        }

        public Person WaitForFeiZi
        {
            get
            {
                return waitForFeiZi;
            }
            set
            {
                waitForFeiZi = value;
                waitForFeiZiPeriod = 30;
                waitForFeiziId = value == null ? -1 : value.ID;
            }
        }

        public int WaitForFeiZiPeriod
        {
            get
            {
                return waitForFeiZiPeriod;
            }
            set
            {
                waitForFeiZiPeriod = value;
            }
        }


        private void updateDayCounters()
        {
            waitForFeiZiPeriod--;
            if (waitForFeiZiPeriod < 0)
            {
                WaitForFeiZi = null;
            }
            ReturnedDaySince++;
        } 

        public event BeAwardedTreasure OnBeAwardedTreasure;

        public event BeConfiscatedTreasure OnBeConfiscatedTreasure;

        public event BeKilled OnBeKilled;

        public event ChangeLeader OnChangeLeader;

        public event ConvinceFailed OnConvinceFailed;

        public event ConvinceSuccess OnConvinceSuccess;

        public event JailBreakSuccess OnJailBreakSuccess;

        public event JailBreakFailed OnJailBreakFailed;

        public event Death OnDeath;

        public event DeathChangeFaction OnDeathChangeFaction;

        public event DestroyFailed OnDestroyFailed;

        public event DestroySuccess OnDestroySuccess;

        public event GossipFailed OnGossipFailed;

        public event GossipSuccess OnGossipSuccess;

        public event InformationObtained OnInformationObtained;

        public event qingbaoshibai qingbaoshibaishijian;

        public event InstigateFailed OnInstigateFailed;

        public event InstigateSuccess OnInstigateSuccess;

        public event Leave OnLeave;

        public event SearchFinished OnSearchFinished;
        /*
        public event ShowMessage OnShowMessage;

        public event SpyFailed OnSpyFailed;

        public event SpyFound OnSpyFound;

        public event SpySuccess OnSpySuccess;
        */
        public event StudySkillFinished OnStudySkillFinished;

        public event StudyStuntFinished OnStudyStuntFinished;

        public event StudyTitleFinished OnStudyTitleFinished;

        public event TreasureFound OnTreasureFound;

        public event CapturedByArchitecture OnCapturedByArchitecture;

        public event CreateSpouse OnCreateSpouse;

        public event CreateBrother OnCreateBrother;

        public event CreateSister OnCreateSister;



        /*
        public List<string> LoadGuanzhiFromString(String s, TitleTable allTitles)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Title guanzhi = null ;
            try
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (allTitles.Titles.TryGetValue(int.Parse(strArray[i]), out title))
                    {
                        this.RealGuanzhis.Add(guanzhi);
                    }
                    else
                    {
                        errorMsg.Add("官职ID" + strArray[i] + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("官职一栏应为半型空格分隔的官职ID");
            }
            return errorMsg;
        }
        
        public String SaveGuanzhiToString()
        {
            String s = "";
            foreach (Guanzhi  g in this.RealGuanzhis)
            {
                s += g.ID + " ";
            }
            return s;
        }
        */

        public List<string> LoadTitleFromString(String s, TitleTable allTitles)
        {
            List<string> errorMsg = new List<string>();
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            Title title = null;
            try
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (allTitles.Titles.TryGetValue(int.Parse(strArray[i]), out title))
                    {
                        this.RealTitles.Add(title);
                    }
                    else
                    {
                        errorMsg.Add("稱號ID" + strArray[i] + "不存在");
                    }
                }
            }
            catch
            {
                errorMsg.Add("稱號一栏应为半型空格分隔的稱號ID");
            }
            return errorMsg;
        }

        public String SaveTitleToString()
        {
            String s = "";
            foreach (Title t in this.RealTitles)
            {
                s += t.ID + " ";
            }
            return s;
        }

        public double TirednessFactor
        {
            get
            {
                return Math.Max(0.2, Math.Min(1, ((210 - this.Tiredness) / 180.0)));
            }
        }

        public void AddBubingExperience(int increment)
        {
            this.bubingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.bubingExperience > maxExperience)
            {
                this.bubingExperience = maxExperience;
            }
        }

        public void AddCommandExperience(int increment)
        {
            if (increment > 0)
            {
                this.commandExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.commandExperience > maxExperience)
                {
                    this.commandExperience = maxExperience;
                }
            }
        }

        public void AddGlamourExperience(int increment)
        {
            if (increment > 0)
            {
                this.glamourExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.glamourExperience > maxExperience)
                {
                    this.glamourExperience = maxExperience;
                }
            }
        }

        public void AddIntelligenceExperience(int increment)
        {
            if (increment > 0)
            {
                this.intelligenceExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.intelligenceExperience > maxExperience)
                {
                    this.intelligenceExperience = maxExperience;
                }
            }
        }

        public void AddInternalExperience(int increment)
        {
            this.internalExperience += (increment * Parameters.InternalExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.internalExperience > maxExperience)
            {
                this.internalExperience = maxExperience;
            }
        }

        public void AddNubingExperience(int increment)
        {
            this.nubingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.nubingExperience > maxExperience)
            {
                this.nubingExperience = maxExperience;
            }
        }

        public void AddPoliticsExperience(int increment)
        {
            if (increment > 0)
            {
                this.politicsExperience += (increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.politicsExperience > maxExperience)
                {
                    this.politicsExperience = maxExperience;
                }
            }
        }

        public void AddQibingExperience(int increment)
        {
            this.qibingExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.qibingExperience > maxExperience)
            {
                this.qibingExperience = maxExperience;
            }
        }

        public void AddQixieExperience(int increment)
        {
            this.qixieExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.qixieExperience > maxExperience)
            {
                this.qixieExperience = maxExperience;
            }
        }

        public void AddShuijunExperience(int increment)
        {
            this.shuijunExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.shuijunExperience > maxExperience)
            {
                this.shuijunExperience = maxExperience;
            }
        }

        public void AddStratagemExperience(int increment)
        {
            this.stratagemExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.stratagemExperience > maxExperience)
            {
                this.stratagemExperience = maxExperience;
            }
        }

        public void AddStrengthExperience(int increment)
        {
            if (increment > 0)
            {
                this.strengthExperience += (int)(increment * Parameters.AbilityExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
                if (this.strengthExperience > maxExperience)
                {
                    this.strengthExperience = maxExperience;
                }
            }
        }

        public bool AddTacticsExperience(int increment)
        {
            this.tacticsExperience += (increment * Parameters.ArmyExperienceRate * (1 + ExperienceRate)
                    * (this.LocationArchitecture == null ? 1 : 1 + this.LocationArchitecture.ExperienceRate)
                    * (this.LocationTroop == null ? 1 : 1 + this.LocationTroop.ExperienceRate))
                * (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIOfficerExperienceRate);
            if (this.tacticsExperience > maxExperience)
            {
                this.tacticsExperience = maxExperience;
            }
            return true;
        }

        public void AddRecruitmentExperience(int increment)
        {
            if (this.RecruitmentMilitary != null)
            {
                switch (this.RecruitmentMilitary.Kind.Type)
                {
                    case MilitaryType.步兵:
                        this.AddBubingExperience(increment);
                        break;

                    case MilitaryType.弩兵:
                        this.AddNubingExperience(increment);
                        break;

                    case MilitaryType.骑兵:
                        this.AddQibingExperience(increment);
                        break;

                    case MilitaryType.水军:
                        this.AddShuijunExperience(increment);
                        break;

                    case MilitaryType.器械:
                        this.AddQixieExperience(increment);
                        break;
                }
            }
        }

        public void AddTreasureToList(TreasureList list)
        {
            foreach (Treasure treasure in this.Treasures)
            {
                list.Add(treasure);
            }
        }

        public void ApplySkills(bool excludePersonal)
        {
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                skill.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID, excludePersonal);
            }
        }

        public void PurifySkills(bool excludePersonal)
        {
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                skill.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID, excludePersonal);
            }
        }

        internal void ApplyStunts()
        {
            if ((this.LocationTroop != null) && (this.LocationTroop.Leader == this))
            {
                this.LocationTroop.Stunts.Clear();
                foreach (Stunt stunt in this.Stunts.Stunts.Values)
                {
                    this.LocationTroop.Stunts.AddStunt(stunt);
                }
            }
        }

        public void ApplyTitles(bool excludePersonal)
        {
            foreach (Title t in this.Titles)
            {
                t.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Title, t.ID, excludePersonal);
            }
        }

        public void PurifyTitles(bool excludePersonal)
        {
            foreach (Title t in this.Titles)
            {
                t.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Title, t.ID, excludePersonal);
            }
        }

        public void PurifyTreasure(Treasure treasure, bool excludePersonal)
        {
            PurifyTreasureSkipSubstitute(treasure, excludePersonal);

            Treasure substitute = null;
            foreach (Treasure t in this.Treasures)
            {
                if (t.TreasureGroup == treasure.TreasureGroup)
                {
                    if (substitute == null)
                    {
                        substitute = t;
                    } 
                    else if (t.Worth > substitute.Worth || (t.Worth == substitute.Worth && t.ID < substitute.ID))
                    {
                        substitute = t;
                    }
                }
            }
            if (substitute != null)
            {
                ApplyTreasure(substitute, excludePersonal);
            }
        }

        private void PurifyTreasureSkipSubstitute(Treasure treasure, bool excludePersonal)
        {
            treasure.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.TreasureGroup, excludePersonal);
            effectiveTreasures.Remove(treasure.TreasureGroup);
        }

        public void PurifyAllTreasures(bool excludePersonal)
        {
            // removing all treasures, do not need to care about treasure group stacking
            foreach (Treasure treasure in this.Treasures)
            {
                treasure.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.TreasureGroup, excludePersonal);
                effectiveTreasures.Remove(treasure.TreasureGroup);
            }
        }

        public void ApplyTreasure(Treasure treasure, bool excludePersonal)
        {
            if (effectiveTreasures.ContainsKey(treasure.TreasureGroup))
            {
                Treasure old = effectiveTreasures[treasure.TreasureGroup];
                if (treasure.Worth > old.Worth || (treasure.Worth == old.Worth && treasure.ID < old.ID))
                {
                    this.PurifyTreasureSkipSubstitute(effectiveTreasures[treasure.TreasureGroup], excludePersonal);
                }
                else
                {
                    return;
                }
            }
            treasure.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Treasure, treasure.TreasureGroup, excludePersonal);
            effectiveTreasures.Add(treasure.TreasureGroup, treasure);
        }

        public void ApplyAllTreasures(bool excludePersonal)
        {
            foreach (Treasure treasure in this.Treasures)
            {
                ApplyTreasure(treasure, excludePersonal);
            }
        }

        public void AwardedTreasure(Treasure t)
        {
            this.ReceiveTreasure(t);
            if (this.Loyalty <= 110)
            {
                if (this.OnBeAwardedTreasure != null)
                {
                    this.OnBeAwardedTreasure(this, t);
                }
                this.IncreaseLoyalty(t.Worth);
                this.AdjustIdealToFactionLeader(-t.Worth / 50);
            }
        }

        private bool BeAvailable()
        {
            Architecture gameObject = base.Scenario.Architectures.GetGameObject(this.AvailableLocation) as Architecture;
            if (gameObject == null)
            {
                this.AvailableLocation = (base.Scenario.Architectures[GameObject.Random(base.Scenario.Architectures.Count)] as Architecture).ID;
                gameObject = base.Scenario.Architectures.GetGameObject(this.AvailableLocation) as Architecture;
            }
            if (gameObject != null)
            {
                ExtensionInterface.call("PersonBecomeAvailable", new Object[] { this.Scenario, this });
                base.Scenario.PreparedAvailablePersons.Add(this);
                return true;
            }
            return false;
        }

        public void ChangeFaction(GameObjects.Faction faction)
        {
            this.Status = PersonStatus.Normal;
            this.YearJoin = base.Scenario.Date.Year;
            this.InitialLoyalty();
        }

        public static int ChanlengeWinningChance(Person source, Person destination)
        {
            int num = 0;
            if (source.Strength >= destination.Strength)
            {
                num = ((50 + ((int)Math.Round(Math.Pow((double)(source.Strength - destination.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
            }
            else
            {
                num = ((50 - ((int)Math.Round(Math.Pow((double)(destination.Strength - source.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
            }
            if (num > 100)
            {
                return 100;
            }
            if (num < 0)
            {
                return 0;
            }
            return num;
        }

        public Architecture BelongedArchitecture
        {
            get
            {
                if (this.IsCaptive)
                {
                    foreach (Captive c in base.Scenario.Captives)
                    {
                        if (c.ID == this.ID && c.CaptiveFaction != null)
                        {
                            return c.CaptiveFaction.Capital;
                        }
                    }
                }
                    

                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.StartingArchitecture;
                }
                return null;
            }
        }

        private int ClosePersonKilledReaction
        {
            get
            {
                int[] reaction = { 0, 2, 4, 3, 1 };
                if (this.PersonalLoyalty < 0) return reaction[0];
                if (this.PersonalLoyalty > 4) return reaction[4];

                return reaction[this.PersonalLoyalty];
            }
        }

        public void KilledInBattle(Person killer)
        {
            killer.OfficerKillCount++;
            this.Scenario.YearTable.addKilledInBattleEntry(this.Scenario.Date, killer, this);

            foreach (Person p in base.Scenario.Persons)
            {
                // person close to killed one may hate killer
                if (p == this) continue;
                if (p == killer) continue;
                if (p.HasCloseStrainTo(killer)) continue;
                if (p.IsCloseTo(killer)) continue;
                if (p.Hates(killer)) continue;
                if (p.Hates(this)) continue;
                if (p.IsVeryCloseTo(this))
                {
                    p.AddHated(killer);
                }
                if (p.HasCloseStrainTo(this))
                {
                    int hateChance = this.ClosePersonKilledReaction * 25;
                    if (GameObject.Chance(hateChance))
                    {
                        p.AddHated(killer);
                    }
                }
                if (killer.BelongedFaction != null)
                {
                    foreach (Treasure treasure in this.Treasures.GetList())
                    {
                        this.LoseTreasure(treasure);
                        killer.BelongedFaction.Leader.ReceiveTreasure(treasure);
                    }
                }
            }

            this.ToDeath(killer, this.BelongedFaction);
        }

        public void KilledInBattle(Troop killer)
        {
            Person kill;
            if (GameObject.Chance(70))
            {
                kill = killer.Leader;
            }
            else
            {
                kill = killer.Persons.GetMaxStrengthPerson();
            }

            this.KilledInBattle(kill);
        }

        public void ToDeath(Person killerInBattle, Faction oldFaction)
        {
            Architecture locationArchitecture;
            Troop locationTroop = null;
            GameObjects.Faction belongedFaction = oldFaction;

            this.Scenario.YearTable.addPersonDeathEntry(this.Scenario.Date, this);

            int deathLocation = 0;
            if (this.LocationTroop != null)
            {
                locationTroop = this.LocationTroop;
                locationArchitecture = this.LocationTroop.StartingArchitecture;
                deathLocation = 2;
                if (!locationTroop.Destroyed)
                {
                    locationTroop.Persons.Remove(this);
                    this.LocationTroop = null;
                    locationTroop.RefreshAfterLosePerson();
                }

            }
            else if (this.LocationArchitecture != null)
            {
                locationArchitecture = this.LocationArchitecture;
                deathLocation = 1;
            }
            else
            {
                deathLocation = 3;
                locationArchitecture = null;
                if(this.ArrivingDays > 0) this.ArrivingDays = 0;

                if (this.TaskDays > 0) this.TaskDays = 0;

                if (this.WorkKind != ArchitectureWorkKind.无) this.WorkKind = ArchitectureWorkKind.无;

                this.RecruitmentMilitary.ID = -1;

               // throw new Exception("try to kill person onway");
            }

            this.Alive = false;  //死亡
            this.SetBelongedCaptive(null, PersonStatus.None);
            this.LocationArchitecture = null;
            
            if (this.OnDeath != null && locationArchitecture != null && deathLocation == 1)
            {
                this.OnDeath(this, killerInBattle, locationArchitecture, null);
            }
            else if (this.OnDeath != null && locationTroop != null && deathLocation == 2)
            {
                this.OnDeath(this, killerInBattle, null, locationTroop);
            }
            else if (this.OnDeath != null && locationArchitecture == null && deathLocation == 3)
            {
                this.OnDeath(this, killerInBattle, null, null);
            }

            if (belongedFaction != null && this == belongedFaction.Leader)
            {
                string name = belongedFaction.Name;
                base.Scenario.YearTable.addKingDeathEntry(base.Scenario.Date, this, belongedFaction);
                GameObjects.Faction faction2 = belongedFaction.ChangeLeaderAfterLeaderDeath();
                if (faction2 != null)
                {
                    if (belongedFaction == faction2)
                    {
                        bool changeName = false;
                        if ((name == this.Name) && (belongedFaction.Leader.Ambition >= (int)PersonAmbition.普通))
                        {
                            belongedFaction.Name = belongedFaction.Leader.Name;
                            changeName = true;
                        }
                        if (this.OnChangeLeader != null)
                        {
                            this.OnChangeLeader(belongedFaction, belongedFaction.Leader, changeName, name);
                        }
                    }
                    else if (this.OnDeathChangeFaction != null)
                    {
                        this.OnDeathChangeFaction(this, faction2.Leader, name);
                    }
                }
                else
                {
                    foreach (Architecture architecture2 in belongedFaction.Architectures.GetList())
                    {
                        architecture2.ResetFaction(null);
                    }
                    belongedFaction.Destroy();
                }
            }
            else
            {

                Treasure baowu;

                while (this.Treasures.Count > 0)
                {
                    baowu = (Treasure)this.Treasures[0];
                    this.LoseTreasure(baowu);
                    baowu.Available = false;
                    baowu.HidePlace = locationArchitecture;
                }
            }

            ExtensionInterface.call("PersonDie", new Object[] { this.Scenario, this });
        }

        private void CheckDeath()
        {
            if ((GlobalVariables.PersonNaturalDeath && ((this.LocationArchitecture != null) && !this.IsCaptive)) && (this.alive && ((((((this.DeadReason == PersonDeadReason.自然死亡) && (this.YearDead <= base.Scenario.Date.Year)) && (GameObject.Random(base.Scenario.Date.LeftDays * ((1 + this.YearDead) - base.Scenario.Date.Year)) == 0)) || (((this.DeadReason == PersonDeadReason.被杀死) && (this.Age >= 80)) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.郁郁而终) && (this.YearDead <= base.Scenario.Date.Year)) && (((this.Age >= 80) || (this.BelongedFaction == null)) || ((this.BelongedFaction.Leader != this) || (this.BelongedFaction.ArchitectureTotalSize < 8)))) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.操劳过度) && (this.YearDead <= base.Scenario.Date.Year)) && ((this.Age >= 80) || ((((((((this.InternalExperience + this.TacticsExperience) + this.StratagemExperience) + this.BubingExperience) + this.NubingExperience) + this.QibingExperience) + this.QibingExperience) + this.ShuijunExperience) > 0x7530))) && (GameObject.Random(90) == 0)))))
            {
                if (this.Status != PersonStatus.Moving && this.Status != PersonStatus.NoFactionMoving)
                {
                    this.ToDeath(null, this.BelongedFaction);
                }
            }
        }

        public Troop BelongedTroop
        {
            get
            {
                foreach (Troop t in base.Scenario.Troops.GameObjects)
                {
                    if (t.Persons.GameObjects.Contains(this))
                    {
                        return t;
                    }
                }
                return null;
            }
        }

        public void ApplyFactionInfluence(bool excludePersonal)
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        if (i.Kind.Type != GameObjects.Influences.InfluenceType.战斗)
                        {
                            i.ApplyInfluence(this, GameObjects.Influences.Applier.Technique, t.ID, excludePersonal);
                        }
                        else
                        {
                            Troop a = this.LocationTroop;
                            if (a != null && a.Leader == this)
                            {
                                i.ApplyInfluence(a, GameObjects.Influences.Applier.Technique, t.ID);
                            }
                        }
                    }
                }
            }
        }

        public void PurifyFactionInfluence(bool excludePersonal)
        {
            if (this.BelongedFaction != null)
            {
                foreach (Technique t in this.BelongedFaction.AvailableTechniques.Techniques.Values)
                {
                    foreach (Influences.Influence i in t.Influences.Influences.Values)
                    {
                        if (i.Kind.Type != GameObjects.Influences.InfluenceType.战斗)
                        {
                            i.PurifyInfluence(this, GameObjects.Influences.Applier.Technique, t.ID, excludePersonal);
                        }
                        else
                        {
                            Troop a = this.LocationTroop;
                            if (a != null && a.Leader == this)
                            {
                                i.PurifyInfluence(a, GameObjects.Influences.Applier.Technique, t.ID);
                            }
                        }
                    }
                }
            }
        }

        public void ApplyArchitectureInfluence(bool excludePersonal)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                foreach (Influences.Influence i in this.LocationArchitecture.Characteristics.Influences.Values)
                {
                    i.ApplyInfluence(this, GameObjects.Influences.Applier.Characteristics, 0, excludePersonal);
                }
            }
        }

        public void PurifyArchitectureInfluence(bool excludePersonal)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                foreach (Influences.Influence i in this.LocationArchitecture.Characteristics.Influences.Values)
                {
                    i.PurifyInfluence(this, GameObjects.Influences.Applier.Characteristics, 0, excludePersonal);
                }
            }
        }

        public void ConfiscatedTreasure(Treasure t)
        {
            this.LoseTreasure(t);
            if (this.Loyalty <= 110)
            {
                if (this.OnBeConfiscatedTreasure != null)
                {
                    this.OnBeConfiscatedTreasure(this, t);
                }
                this.DecreaseLoyalty(t.Worth * 2);
                this.AdjustIdealToFactionLeader(t.Worth / 10 + 1);
                if (GameObject.Random(this.Loyalty) <= GameObject.Random(10))
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LeaveToNoFaction();
                    }
                }
            }
            ExtensionInterface.call("ConfiscatedTreasure", new Object[] { this.Scenario, this });
        }

        public static int ControversyWinningChance(Person source, Person destination)
        {
            int num = 0;
            int controversyAbility = source.ControversyAbility;
            int num3 = destination.ControversyAbility;
            num = (((50 + controversyAbility) - num3) + source.IncrementOfControversyWinningChance) - destination.IncrementOfControversyWinningChance;
            if (num > 100)
            {
                return 100;
            }
            if (num < 0)
            {
                return 0;
            }
            return num;
        }

        public void RecoverFromInjury()
        {
            if (this.InjureRate < 1 && GameObject.Chance(this.Strength + 10))
            {
                this.InjureRate += (GameObject.Random(30) + 1) / 1000.0f;
                if (this.InjureRate > 1)
                {
                    this.InjureRate = 1;
                }
            }
            if (this.Age > 60 && GameObject.Random(Math.Max((this.YearDead - base.Scenario.Date.Year) * 10 + 130, 30)) == 0 && this.InjureRate > 0.7)
            {
                this.InjureRate -= 0.1f;
            }
        }

        public void DayEvent()
        {
            this.CheckDeath();
            if (this.Alive)
            {
                this.RecoverFromInjury();
                this.LeaveFaction();
                this.NoFactionMove();
                this.LoyaltyChange();
                this.ProgressArrivingDays();
                this.huaiyunshijian();
                this.updateDayCounters();
                this.createRelations();
                this.AutoLearnEvent();

                List<int> toRemove = new List<int>();
                foreach (KeyValuePair<int, int> i in new Dictionary<int, int>(this.ProhibitedFactionID))
                {
                    this.ProhibitedFactionID[i.Key]--;
                    if (this.ProhibitedFactionID[i.Key] <= 0)
                    {
                        toRemove.Add(i.Key);
                    }
                }
                foreach (int i in toRemove) 
                {
                    this.ProhibitedFactionID.Remove(i);
                }
            }

            this.CommandExperience += this.CommandExperienceIncrease;
            this.StrengthExperience += this.StrengthExperienceIncrease;
            this.IntelligenceExperience += this.IntelligenceExperienceIncrease;
            this.PoliticsExperience += this.PoliticsExperienceIncrease;
            this.GlamourExperience += this.GlamourExperienceIncrease;
            this.Reputation += this.ReputationDayIncrease;

            agricultureAbility = 0;
            commerceAbility = 0;
            technologyAbility = 0;
            moraleAbility = 0;
            dominationAbility = 0;
            enduranceAbility = 0;
            trainingAbility = 0;
            higherLevelLearnableTitle = null;
        }

        private void AutoLearnEvent()
        {
            if (this.BelongedFaction != null)
            {
                this.AutoLearnSkill();
                this.AutoLearnStunt();
            }
        }

        private void AutoLearnSkill()
        {
            string skillString = "";
            foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                if (((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this)) && (GameObject.Chance(Parameters.AutoLearnSkillSuccessRate)))
                {
                    this.Skills.AddSkill(skill);
                    skill.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID, false);
                    skillString = skillString + "•" + skill.Name;
                }
            }
        }

        private void AutoLearnStunt()
        {
            foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
            {
                if ((this.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(this) && (GameObject.Chance(Parameters.AutoLearnStuntSuccessRate)))
                {
                    this.Stunts.AddStunt(stunt);
                    stunt.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Stunt, stunt.ID, false);
                }
            }
        }

        public PersonList MakeMarryable()
        {
            PersonList result = new PersonList();

            if (this.LocationArchitecture == null) return result;

            if (this.Spouse != null) return result;

            foreach (Person p in this.LocationArchitecture.Persons)
            {
                if (p == this) continue;
                if (p.isLegalFeiZi(this) && this.isLegalFeiZi(p) && Person.GetIdealOffset(p, this) <= Parameters.MakeMarrigeIdealLimit
                    && !p.Hates(this) && !this.Hates(p) && p.Spouse == null)
                {
                    result.Add(p);
                }
            }

            return result;
        }

        public void Marry(Person p)
        {
            this.LocationArchitecture.DecreaseFund(Parameters.MakeMarriageCost);

            this.Spouse = p;
            p.Spouse = this;

            this.AdjustRelation(p, 1, 50);
            p.AdjustRelation(this, 1, 50);

            base.Scenario.YearTable.addCreateSpouseEntry(base.Scenario.Date, this, p);
            this.Scenario.GameScreen.MakeMarriage(this, p);
        }

        private void createRelations()
        {
            if (this.LocationArchitecture != null && GameObject.Random(60) == 0)
            {
                foreach (KeyValuePair<Person, int> i in this.relations)
                {
                    if (i.Value >= Parameters.VeryCloseThreshold && i.Key.GetRelation(this) >= Parameters.VeryCloseThreshold && i.Key.BelongedFaction == this.BelongedFaction
                         && !this.HasStrainTo(i.Key) && !this.IsVeryCloseTo(i.Key)
                        && (!GlobalVariables.PersonNaturalDeath || (Math.Abs(this.Age - i.Key.Age) <= 40 && this.Age <= 50 && i.Key.Age <= 50
                            && this.Age >= 16 && i.Key.Age >= 16)))
                    {
                        if (this.Sex == i.Key.Sex)
                        {
                            bool legal = true;
                            foreach (Person p in i.Key.Brothers)
                            {
                                if (this.HasStrainTo(p) || this.IsVeryCloseTo(p))
                                {
                                    legal = false;
                                    break;
                                }
                            }
                            foreach (Person p in this.Brothers)
                            {
                                if (i.Key.HasStrainTo(p) || i.Key.IsVeryCloseTo(p))
                                {
                                    legal = false;
                                    break;
                                }
                            }
                            if (legal && this.Brothers.Count <= 2 && i.Key.Brothers.Count <= 2)
                            {
                                if (this.Brothers.Count == 0)
                                {
                                    this.Brothers.Add(this);
                                }
                                if (i.Key.Brothers.Count == 0)
                                {
                                    i.Key.Brothers.Add(i.Key);
                                }
                                this.Brothers.Add(i.Key);
                                i.Key.Brothers.Add(this);
                                if (this.Sex)
                                {
                                    base.Scenario.YearTable.addCreateSisterEntry(base.Scenario.Date, this, i.Key);
                                    if (this.OnCreateSister != null)
                                    {
                                        this.OnCreateSister(this, i.Key);
                                    }
                                }
                                else
                                {
                                    base.Scenario.YearTable.addCreateBrotherEntry(base.Scenario.Date, this, i.Key);
                                    if (this.OnCreateBrother != null)
                                    {
                                        this.OnCreateBrother(this, i.Key);
                                    }
                                }
                            }
                        }
                        else if (this.Spouse == null && i.Key.Spouse == null)
                        {
                            if (this.isLegalFeiZi(i.Key) && i.Key.isLegalFeiZi(this))
                            {
                                this.Spouse = i.Key;
                                i.Key.Spouse = this;
                                base.Scenario.YearTable.addCreateSpouseEntry(base.Scenario.Date, this, i.Key);
                                if (this.OnCreateSpouse != null)
                                {
                                    this.OnCreateSpouse(this, i.Key);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void huaiyunshijian()
        {
            if (this.huaiyun)
            {
                this.huaiyuntianshu++;
                //if (this.huaiyuntianshu == 30)
                if (GameObject.Chance((this.huaiyuntianshu - 20) * 5) && !this.faxianhuaiyun)
                {
                    ExtensionInterface.call("FoundPregnant", new Object[] { this.Scenario, this });
                    this.faxianhuaiyun = true;
                    if (this.BelongedFaction != null && this == this.BelongedFaction.Leader)  //女君主自己怀孕
                    {
                        this.Scenario.GameScreen.selfFoundPregnant(this);
                    }
                    else
                    {
                        if (this.Status == PersonStatus.Princess)
                        {
                            this.Scenario.GameScreen.faxianhuaiyun(this);
                        }
                        else
                        {
                            Person reporter;
                            if (this.BelongedArchitecture != null)
                            {
                                reporter = this.BelongedArchitecture.Advisor;
                                if (reporter != null && (reporter != this || (reporter == this && reporter.Spouse == reporter.BelongedFaction.Leader)))
                                {
                                    this.Scenario.GameScreen.coupleFoundPregnant(this, reporter);
                                }
                            }
                            
                        }
                    }

                    Person haizifuqin = this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person;
                    if (haizifuqin != null && !this.Hates(haizifuqin) && !haizifuqin.Hates(this))
                    {
                        this.AdjustRelation(haizifuqin, 1, 0);
                        haizifuqin.AdjustRelation(this, 1, 0);
                    }
                    if (this.Status == PersonStatus.Princess)
                    {
                        foreach (Person p in this.BelongedArchitecture.BelongedFaction.GetFeiziList())
                        {
                            if (p == this) continue;
                            p.AdjustRelation(this, (5 - p.PersonalLoyalty) * -0.5f, -1);
                        }
                    }
                }
                else if (GameObject.Chance((this.huaiyuntianshu - 290) * 5))
                {
                    Person haizifuqin = new Person();
                    Person haizi = new Person();
                    this.huaiyun = false;
                    this.faxianhuaiyun = false;
                    this.huaiyuntianshu = -1;

                    if (this.suoshurenwu == -1)
                    {
                        if (this.BelongedFaction != null)
                        {
                            this.suoshurenwu = this.BelongedFaction.LeaderID;
                        }
                        else
                        {
                            return;
                        }
                    }
                    haizifuqin = this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person;

                    if (haizifuqin != null)
                    {
                        int count = 0;
                        do
                        {
                            PersonList origChildren = haizifuqin.meichushengdehaiziliebiao();
                            if (origChildren.Count > 0)
                            {
                                haizi = origChildren[0] as Person;

                                int ageDeath = haizi.YearDead - haizi.YearBorn;
                                haizi.YearBorn = haizifuqin.Scenario.Date.Year;
                                haizi.YearAvailable = haizi.YearBorn + GlobalVariables.ChildrenAvailableAge;
                                haizi.YearDead = haizi.YearBorn + ageDeath;

                                haizi.father = this.Sex ? haizifuqin : this;
                                haizi.mother = this.Sex ? this : haizifuqin;
                            }
                            else
                            {
                                haizi = Person.createChildren(this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person, this);
                            }

                            if (origChildren.Count > 0)
                            {
                                haizi.muqinyingxiangnengli(this);
                            }
                            if (haizi.BaseCommand < 1) haizi.BaseCommand = 1;
                            if (haizi.BaseStrength < 1) haizi.BaseStrength = 1;
                            if (haizi.BaseIntelligence < 1) haizi.BaseIntelligence = 1;
                            if (haizi.BasePolitics < 1) haizi.BasePolitics = 1;
                            if (haizi.BaseGlamour < 1) haizi.BaseGlamour = 1;

                            base.Scenario.YearTable.addChildrenBornEntry(base.Scenario.Date, haizifuqin, this, haizi);

                            haizifuqin.TextResultString = haizi.Name;
                            //haizi.AvailableLocation = this.BelongedTroop != null ? this.BelongedTroop.StartingArchitecture.ID : this.BelongedArchitecture.ID;
                            if (this.BelongedFaction != null)
                            {
                                haizi.AvailableLocation = this.BelongedFaction.Capital.ID;

                            }
                            else if (this.BelongedTroop != null)
                            {
                                haizi.AvailableLocation = this.BelongedTroop.StartingArchitecture.ID;
                            }
                            else
                            {
                                haizi.AvailableLocation = this.BelongedArchitecture.ID;
                            }

                            base.Scenario.GameScreen.xiaohaichusheng(haizifuqin, haizi);

                            haizifuqin.NumberOfChildren++;
                            this.NumberOfChildren++;

                            if (!GlobalVariables.PersonNaturalDeath || GlobalVariables.ChildrenAvailableAge <= 0)
                            {
                                base.Scenario.haizichusheng(haizi, haizifuqin, this, origChildren.Count > 0);
                            }

                            if (!this.Hates(haizifuqin) && !haizifuqin.Hates(this))
                            {
                                this.AdjustRelation(haizifuqin, 3, -5);
                                haizifuqin.AdjustRelation(this, 3, -5);
                            }

                            count++;
                        } while ((GameObject.Chance(haizifuqin.multipleChildrenRate) || GameObject.Chance(this.multipleChildrenRate)) && count < Math.Max(haizifuqin.maxChildren, this.maxChildren));

                        haizifuqin.suoshurenwu = -1;
                    }

                    this.suoshurenwu = -1;

                }
            }
            else if (this.Spouse != null && !this.huaiyun && !this.Spouse.huaiyun && GlobalVariables.getChildrenRate > 0 &&
                (this.LocationArchitecture != null && this.Spouse.LocationArchitecture == this.LocationArchitecture ||
                    (this.LocationTroop != null && this.Spouse.LocationTroop == this.LocationTroop)) &&
                this.Status == PersonStatus.Normal && this.Spouse.Status == PersonStatus.Normal &&
                this.isLegalFeiZi(this.Spouse) && this.Spouse.isLegalFeiZi(this) &&
                this.NumberOfChildren < GlobalVariables.OfficerChildrenLimit &&
                this.Spouse.NumberOfChildren < GlobalVariables.OfficerChildrenLimit)
            {
                float relationFactor = (1 + this.GetRelation(this.Spouse) * 0.0001f + this.Spouse.GetRelation(this) * 0.0001f)
                    * (1 + this.pregnantChance / 100.0f + this.Spouse.pregnantChance / 100.0f);

                if (relationFactor > 0 && GameObject.Random((int)
                    (10000.0f / GlobalVariables.getChildrenRate * 20 / relationFactor / (base.Scenario.IsPlayer(this.BelongedFaction) ? 1 : Parameters.AIExtraPerson))) == 0)
                {
                    this.suoshurenwu = this.Spouse.ID;
                    this.Spouse.suoshurenwu = this.ID;
                    if (this.Sex)
                    {
                        this.huaiyun = true;
                        this.huaiyuntianshu = 0;
                    }
                    else
                    {
                        this.Spouse.huaiyun = true;
                        this.Spouse.huaiyuntianshu = 0;
                    }
                }
            }
        }



        public int Uncruelty
        {
            get
            {
                return Enum.GetNames(typeof(PersonAmbition)).Length - (int)this.Ambition + (int)this.PersonalLoyalty + 1;
            }
        }
        /*
        public int NumberOfChildren
        {
            get
            {
                int cnt = 0;
                foreach (Person p in base.Scenario.Persons)
                {
                    if ((p.Father == this || p.Mother == this) && (((p.Available || p.YearBorn <= base.Scenario.Date.Year) && p.Alive) || (p.Available && !p.Alive)))
                    {
                        cnt++;
                    }
                }
                return cnt;
            }
        }
        */

        public PersonList ChildrenList
        {
            get
            {
                PersonList list = new PersonList();
                foreach (Person p in base.Scenario.Persons)
                {
                    if ((p.Father == this || p.Mother == this) && (((p.Available || p.YearBorn <= base.Scenario.Date.Year) && p.Alive) || (p.Available && !p.Alive)))
                    {
                        list.Add(p);
                    }
                }
                return list;
            }
        }

        public int NumberOfChildren
        {
            get
            {
                
                return (this.ChildrenList.Count);
            }
            set
            {
                this.numberOfChildren = value;
            }
        }

        public int DecreaseLoyalty(int decrement)
        {
            if (decrement > this.Loyalty)
            {
                decrement = this.Loyalty;
            }
            this.loyalty -= decrement;
            return decrement;
        }

        public void DoJailBreak()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.BelongedFaction != null)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
                if ((architectureByPosition != null) && (architectureByPosition.BelongedFaction != null))
                {
                    bool success = false;
                    bool attempted = false;
                    foreach (Captive c in architectureByPosition.Captives)
                    {
                        if (c.CaptiveFaction == this.BelongedFaction)
                        {
                            attempted = true;
                            if (GameObject.Random((architectureByPosition.Domination * 10 + architectureByPosition.Morale) * 2) + 300 <=
                                GameObject.Random(this.JailBreakAbility + c.CaptivePerson.CaptiveAbility))
                            {
                                if (!GameObject.Chance(architectureByPosition.noEscapeChance) || GameObject.Chance(c.CaptivePerson.captiveEscapeChance))
                                {
                                    success = true;
                                    this.AddStrengthExperience(10);
                                    this.AddIntelligenceExperience(10);
                                    this.AddTacticsExperience(60);
                                    this.IncreaseReputation(20);
                                    this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                                    this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                                    ExtensionInterface.call("DoJailBreakSuccess", new Object[] { this.Scenario, this, c });
                                    if (this.OnJailBreakSuccess != null)
                                    {
                                        this.OnJailBreakSuccess(this, c);
                                    }
                                    c.CaptiveEscapeNoHint();
                                }
                            }
                        }
                    }
                    if (this.InevitableSuccessOfJailBreak && !success && architectureByPosition.Captives.Count > 0)
                    {
                        Captive c = (Captive)architectureByPosition.Captives[GameObject.Random(architectureByPosition.Captives.Count)];
                        attempted = true;
                        success = true;
                        this.AddStrengthExperience(10);
                        this.AddIntelligenceExperience(10);
                        this.AddTacticsExperience(60);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        ExtensionInterface.call("DoJailBreakSuccess", new Object[] { this.Scenario, this, c });
                        if (this.OnJailBreakSuccess != null)
                        {
                            this.OnJailBreakSuccess(this, c);
                        }
                        c.CaptiveEscapeNoHint();
                    }
                    if (!success)
                    {
                        if (this.OnJailBreakFailed != null)
                        {
                            this.OnJailBreakFailed(this, architectureByPosition);
                        }
                    }
                    if (attempted && architectureByPosition.BelongedFaction != this.BelongedFaction)
                    {
                        CheckCapturedByArchitecture(architectureByPosition);
                    }
                }
            }
        }

        public void DoAssassinate()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.ConvincingPerson != null && this.ConvincingPerson.BelongedArchitecture != null)
            {
                if (this.ConvincingPerson.BelongedFaction == this.BelongedFaction) return;

                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
                if (architectureByPosition != null && this.ConvincingPerson.Status == PersonStatus.Normal)
                {
                    int diff = GameObject.Random(this.AssassinateAbility) - GameObject.Random(architectureByPosition.DefendAssassinateAbility) * 2;
                    if (diff > 0)
                    {
                        this.ConvincingPerson.InjureRate -= diff / 1000.0f;
                        if (this.ConvincingPerson.InjureRate < 0.05 && GlobalVariables.OfficerDieInBattleRate > 0)
                        {
                            this.AddStrengthExperience(30);
                            this.AddIntelligenceExperience(30);
                            this.AddTacticsExperience(180);
                            this.BelongedFaction.IncreaseTechniquePoint(30 * this.MultipleOfTacticsTechniquePoint * 100);

                            this.illegallyKilled(this.BelongedFaction, this);

                            base.Scenario.GameScreen.PersonAssassinateSuccessKilled(this, this.ConvincingPerson, architectureByPosition);

                            ExtensionInterface.call("Assassinated", new Object[] { this.Scenario, this, this.ConvincingPerson });

                            base.Scenario.YearTable.addAssassinateEntry(base.Scenario.Date, this, this.ConvincingPerson);
                            this.ConvincingPerson.ToDeath(this, this.BelongedFaction);
                        }
                        else
                        {
                            this.AddStrengthExperience(10);
                            this.AddIntelligenceExperience(10);
                            this.AddTacticsExperience(60);
                            this.BelongedFaction.IncreaseTechniquePoint(10 * this.MultipleOfTacticsTechniquePoint * 100);

                            this.LoseReputationBy(0.005f * this.ConvincingPerson.PersonalLoyalty);

                            base.Scenario.GameScreen.PersonAssassinateSuccess(this, this.ConvincingPerson, architectureByPosition);
                            /*
                            if (GameObject.Random(this.AssassinateAbility) > GameObject.Random(this.ConvincingPerson.AssassinateAbility) * 3 &&
                                !this.ConvincingPerson.ImmunityOfCaptive)
                            {
                                Captive captive = Captive.Create(base.Scenario, this.ConvincingPerson, this.BelongedFaction);
                                this.ConvincingPerson.Status = PersonStatus.Captive;
                                this.ConvincingPerson.MoveToArchitecture(this.TargetArchitecture);

                                base.Scenario.GameScreen.PersonAssassinateSuccessCaptured(this, this.ConvincingPerson, architectureByPosition);
                            }
                            else
                            {
                                base.Scenario.GameScreen.PersonAssassinateSuccess(this, this.ConvincingPerson, architectureByPosition);
                            }*/
                        }
                    }
                    else
                    {
                        if (diff < -200)
                        {
                            this.InjureRate -= (-diff - 200) / 1000.0f;
                            if (this.InjureRate < 0.05 && GlobalVariables.OfficerDieInBattleRate > 0)
                            {
                                ExtensionInterface.call("Assassinated", new Object[] { this.Scenario, this, this.ConvincingPerson });

                                base.Scenario.YearTable.addReverseAssassinateEntry(base.Scenario.Date, this, this.ConvincingPerson);
                                this.ToDeath(this, this.BelongedFaction);

                                base.Scenario.GameScreen.PersonAssassinateFailedKilled(this, this.ConvincingPerson, architectureByPosition);
                            }
                        }

                        this.LoseReputationBy(0.005f * this.ConvincingPerson.PersonalLoyalty);

                        if (this.Alive)
                        {
                            base.Scenario.GameScreen.PersonAssassinateFailed(this, this.ConvincingPerson, architectureByPosition);
                        }

                        if (!CheckCapturedByArchitecture(architectureByPosition))
                        {
                            if (!CheckCapturedByArchitecture(architectureByPosition))
                            {
                                CheckCapturedByArchitecture(architectureByPosition);
                            }
                        }
                        
                    }
                }
            }
        }

        public Person VeryClosePersonInArchitecture
        {
            get
            {
                int maxRel = int.MinValue;
                Person closest = null;
                if (this.BelongedArchitecture != null)
                {
                    foreach (Person p in this.BelongedArchitecture.Persons)
                    {
                        if (this.IsVeryCloseTo(p))
                        {
                            if (this.GetRelation(p) > maxRel)
                            {
                                maxRel = this.GetRelation(p);
                                closest = p;
                            }
                        }
                    }
                }
                return closest;
            }
        }

        public PersonList VeryClosePersons
        {
            get
            {
                PersonList result = new PersonList();
                if (this.Spouse != null)
                {
                    result.Add(this.Spouse);
                }
                foreach (Person p in this.Brothers)
                {
                    result.Add(p);
                }
                return result;
            }
        }

        public void DoConvince()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.ConvincingPerson != null && this.BelongedFaction != null)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
                if ((architectureByPosition != null) && (
                    (this.ConvincingPerson.IsCaptive || this.ConvincingPerson.Status == PersonStatus.NoFaction || (architectureByPosition.BelongedFaction != this.BelongedFaction))))
                {
                    bool ConvinceSuccess;
                    int idealOffset = Person.GetIdealOffset(this.ConvincingPerson, this.BelongedFaction.Leader);

                    if (this.ConvincingPerson.BelongedFaction == null)
                    {
                        ConvinceSuccess =
                            (
                                (this.ConvincingPerson.IsCaptive &&
                                 architectureByPosition.IsCaptiveInArchitecture(this.ConvincingPerson.BelongedCaptive)
                                 )
                            || (this.ConvincingPerson.LocationArchitecture == architectureByPosition)
                        )
                        && !this.ConvincingPerson.Hates(this.BelongedFaction.Leader)
                        && (!GlobalVariables.IdealTendencyValid ||
                            (idealOffset <= this.ConvincingPerson.IdealTendency.Offset +
                             (double)this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75)
                        );

                        ConvinceSuccess |= !base.Scenario.IsPlayer(this.BelongedFaction) && GlobalVariables.AIAutoTakeNoFactionCaptives;
                        // 当被登用武将在野并且亲爱登用武将的君主或登用武将自己时，一定被登用
                        ConvinceSuccess |= this.ConvincingPerson.Closes(this) || this.ConvincingPerson.Closes(this.BelongedFaction.Leader);
                    }
                    else
                    {
                        ConvinceSuccess =
                            (
                     ((this.ConvincingPerson.IsCaptive && architectureByPosition.IsCaptiveInArchitecture(this.ConvincingPerson.BelongedCaptive))
                     || (this.ConvincingPerson.LocationArchitecture == architectureByPosition))
                     && (
                     (
                         ((this.ConvincingPerson.BelongedFaction != null) && (this.BelongedFaction != this.ConvincingPerson.BelongedFaction))

                     )
                     && ((this.ConvincingPerson != this.ConvincingPerson.BelongedFaction.Leader) && (this.ConvincingPerson.Loyalty < 100))))
                     && (!this.ConvincingPerson.Hates(this.BelongedFaction.Leader))
                     && (!GlobalVariables.IdealTendencyValid || (idealOffset <= this.ConvincingPerson.IdealTendency.Offset + (double)this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75))
                     && (GameObject.Random((this.ConvinceAbility - (this.ConvincingPerson.Loyalty * 2)) - ((int)this.ConvincingPerson.PersonalLoyalty * (int)((PersonLoyalty)0x19))) > this.ConvincingPerson.Loyalty);

                        ConvinceSuccess |= !base.Scenario.IsPlayer(this.BelongedFaction) && base.Scenario.IsPlayer(this.ConvincingPerson.BelongedFaction) &&
                            GlobalVariables.AIAutoTakePlayerCaptives && this.ConvincingPerson.IsCaptive &&
                            (!GlobalVariables.AIAutoTakePlayerCaptiveOnlyUnfull || this.ConvincingPerson.Loyalty < 100);
                    }
                    ConvinceSuccess = ConvinceSuccess && (!this.BelongedFaction.IsAlien || (int)this.ConvincingPerson.PersonalLoyalty < 2);  //异族只能说服义理为2以下的武将。
                    //这样配偶和义兄可以无视一切条件强登被登用武将 (当是君主的配偶或者义兄弟)
                    ConvinceSuccess |= this.ConvincingPerson.IsVeryCloseTo(this);

                    Person closest = this.ConvincingPerson.VeryClosePersonInArchitecture;
                    ConvinceSuccess &= closest == null || GameObject.Chance(1000 - this.ConvincingPerson.GetRelation(closest) / 10);

                    // prohibitedFactionID overrides all.
                    if (this.ConvincingPerson.ProhibitedFactionID.ContainsKey(this.BelongedFaction.ID))
                    {
                        ConvinceSuccess = false;
                    }

                    if (ConvinceSuccess)
                    {
                        this.ConvincePersonSuccess(this.ConvincingPerson);
                    }
                    else
                    {
                        ExtensionInterface.call("DoConvinceFail", new Object[] { this.Scenario, this });
                        if (this.OnConvinceFailed != null)
                        {
                            this.OnConvinceFailed(this, this.ConvincingPerson);
                        }
                    }

                    if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                    {
                        CheckCapturedByArchitecture(architectureByPosition);
                    }
                }
            }
        }

        internal void ConvincePersonSuccess(Person person)
        {
            if (this.BelongedFaction == null)  //盗贼不能说服武将
            {
                return;
            }
            GameObjects.Faction belongedFaction = null;
            if (person.BelongedFaction != null && this.BelongedFaction != null)
            {
                if (person.ProhibitedFactionID.ContainsKey(person.BelongedFaction.ID))
                {
                    person.ProhibitedFactionID.Remove(person.BelongedFaction.ID);
                }
                person.ProhibitedFactionID.Add(person.BelongedFaction.ID, 90);
                belongedFaction = person.BelongedFaction;
                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, person.BelongedFaction.ID, -10);
                if (person.BelongedFaction.Leader.HasStrainTo(person))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, person.BelongedFaction.ID, -10);
                }
                if (person.BelongedFaction.Leader.HasCloseStrainTo(person))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, person.BelongedFaction.ID, -10);
                }
                person.RebelCount++;
                person.Reputation = (int)(person.Reputation * 0.9);
            }
            if (this.BelongedFaction != null)
            {
                if (person.BelongedFaction != null)
                {
                    base.Scenario.YearTable.addChangeFactionEntry(base.Scenario.Date, person, this, belongedFaction, this.BelongedFaction);
                }
                else
                {
                    base.Scenario.YearTable.addJoinFactionEntry(base.Scenario.Date, person, this, this.BelongedFaction);
                }
            }

            Architecture from = null;
            if (person.IsCaptive)
            {
                from = person.BelongedCaptive.LocationArchitecture;
                person.SetBelongedCaptive(null, PersonStatus.Normal);
            }
            else if (person.LocationTroop != null)
            {
                from = person.LocationTroop.StartingArchitecture;
            }
            else
            {
                from = person.LocationArchitecture;
            }

            person.ChangeFaction(this.BelongedFaction);

            if (person.LocationTroop != null)  //单挑中说服敌人
            {
                this.ConvincePersonInTroop(person);
            }
            else if (from == null)
            {
                person.MoveToArchitecture(this.TargetArchitecture, null);
            }
            else
            {
                person.MoveToArchitecture(this.TargetArchitecture, from.ArchitectureArea.Area[0]);
                
            }
            if (person.Loyalty < 100)
            {
                person.Loyalty = 100 - GetIdealOffset(person, this.BelongedFaction.Leader)/5;
            }
            /*if (!(flag || (person.LocationArchitecture == null)))
            {
                person.LocationArchitecture.RemovePerson(person);
            }*/
            this.AddGlamourExperience(40);
            this.IncreaseReputation(40);
            this.BelongedFaction.IncreaseReputation(20 * this.MultipleOfTacticsReputation);
            this.BelongedFaction.IncreaseTechniquePoint((20 * this.MultipleOfTacticsTechniquePoint) * 100);

            ExtensionInterface.call("DoConvinceSuccess", new Object[] { this.Scenario, this });
            if (this.OnConvinceSuccess != null)
            {
                this.OnConvinceSuccess(this, person, belongedFaction);
            }
        }

        private void ConvincePersonInTroop(Person person)
        {
            if (person.LocationTroop.PersonCount >= 2)
            {
                if (!person.LocationTroop.Destroyed)
                {
                    Troop locationTroop = person.LocationTroop;

                    person.LocationTroop.Persons.Remove(person);
                    person.LocationTroop = null;
                    locationTroop.RefreshAfterLosePerson();
                    person.MoveToArchitecture(this.BelongedFaction.Capital, locationTroop.Position);

                }
                else
                {
                    person.MoveToArchitecture(this.BelongedFaction.Capital, null);

                }
            }
            else
            {
                if (!person.LocationTroop.Destroyed)
                {
                    person.LocationTroop.ChangeFaction(this.BelongedFaction);
                }
            }
        }

        public void DoDestroy()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                {
                    if ((architectureByPosition.Endurance > 0) && (this.InevitableSuccessOfDestroy || (GameObject.Random(architectureByPosition.Domination * 8) < GameObject.Random(this.DestroyAbility))))
                    {
                        int randomValue = StaticMethods.GetRandomValue(this.DestroyAbility, 12);
                        randomValue = architectureByPosition.DecreaseEndurance(randomValue);
                        int increment = randomValue / 4;
                        this.AddTacticsExperience(increment * 6);
                        this.AddIntelligenceExperience(increment);
                        this.AddStrengthExperience(increment / 2);
                        this.AddCommandExperience(increment / 2);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        if (this.OnDestroySuccess != null)
                        {
                            this.OnDestroySuccess(this, architectureByPosition, randomValue);
                        }
                        architectureByPosition.DecrementNumberList.AddNumber(randomValue, CombatNumberKind.人数, architectureByPosition.Position);
                        ExtensionInterface.call("DoDestroySuccess", new Object[] { this.Scenario, this, randomValue });
                    }
                    else
                    {
                        ExtensionInterface.call("DoDestroyFail", new Object[] { this.Scenario, this });
                        if (this.OnDestroyFailed != null)
                        {
                            this.OnDestroyFailed(this, architectureByPosition);
                        }
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else if (this.OnDestroyFailed != null)
                {
                    ExtensionInterface.call("DoDestroyFail", new Object[] { this.Scenario, this });
                    this.OnDestroyFailed(this, architectureByPosition);
                }
            }
        }

        public void DoHouGong()
        {
            this.OutsideTask = OutsideTaskKind.无;

        }

        public void DoGossip()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if ((architectureByPosition.BelongedFaction != null) && (this.BelongedFaction != architectureByPosition.BelongedFaction))
                {
                    if (this.InevitableSuccessOfGossip || (GameObject.Random(architectureByPosition.Domination * 5) < GameObject.Random(this.GossipAbility)))
                    {
                        architectureByPosition.DamageByGossip(this.GossipAbility);
                        this.AddTacticsExperience(60);
                        this.AddPoliticsExperience(10);
                        this.AddGlamourExperience(10);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        ExtensionInterface.call("DoGossipSuccess", new Object[] { this.Scenario, this });
                        if (this.OnGossipSuccess != null)
                        {
                            this.OnGossipSuccess(this, architectureByPosition);
                        }
                    }
                    else
                    {
                        ExtensionInterface.call("DoGossipFail", new Object[] { this.Scenario, this });
                        if (this.OnGossipFailed != null)
                        {
                            this.OnGossipFailed(this, architectureByPosition);
                        }
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else
                {
                    ExtensionInterface.call("DoGossipFail", new Object[] { this.Scenario, this });
                    if (this.OnGossipFailed != null)
                    {
                        this.OnGossipFailed(this, architectureByPosition);
                    }
                }
            }
        }

        public void DoInformation()
        {
            if (this.CurrentInformationKind != null && (!base.Scenario.IsPlayer(this.BelongedFaction) || (this.InformationAbility > 90 && GameObject.Random(280) < this.InformationAbility)))
            {
                Information information = new Information();
                information.Scenario = base.Scenario;
                information.ID = base.Scenario.Informations.GetFreeGameObjectID();
                information.Level = this.CurrentInformationKind.Level;
                information.Radius = this.CurrentInformationKind.Radius + this.RadiusIncrementOfInformation +
                    (this.InformationAbility + GameObject.Random(100) - 50) / 200;
                information.Position = this.OutsideDestination.Value;
                information.Oblique = this.CurrentInformationKind.Oblique;
                information.DayCost = (int)(240.0 / this.InformationAbility * this.CurrentInformationKind.CostFund *
                    Math.Max(1.0, base.Scenario.GetDistance(information.Position, this.BelongedArchitecture.Position) / 20.0));

                base.Scenario.Informations.AddInformation(information);
                this.BelongedArchitecture.AddInformation(information);

                information.Apply();
                this.BelongedArchitecture.DecreaseFund(information.DayCost);

                this.CurrentInformationKind = null;
                this.OutsideTask = OutsideTaskKind.无;

                int increment = (int)(((int)information.Level - 2) * (information.Radius + (information.Oblique ? 1 : 0)));
                this.AddTacticsExperience(increment * 6);
                this.AddIntelligenceExperience(increment);
                this.IncreaseReputation(increment * 2);
                this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
                this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                ExtensionInterface.call("DoInformationSuccess", new Object[] { this.Scenario, this, information });
                if (this.OnInformationObtained != null)
                {
                    this.OnInformationObtained(this, information);
                }

            }
            else
            {
                if (this.CurrentInformationKind != null)
                {
                    int increment = (int)(((int)this.CurrentInformationKind.Level - 2) * (this.CurrentInformationKind.Radius + (this.CurrentInformationKind.Oblique ? 1 : 0)));
                    this.AddTacticsExperience(increment * 6);
                    this.AddIntelligenceExperience(increment);
                    this.CurrentInformationKind = null;
                }
                this.OutsideTask = OutsideTaskKind.无;
                ExtensionInterface.call("DoInformationFail", new Object[] { this.Scenario, this });
                if (this.qingbaoshibaishijian != null)
                {
                    this.qingbaoshibaishijian(this);
                }
            }

        }

        public void DoInstigate()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if (architectureByPosition.BelongedFaction != this.BelongedFaction)
                {
                    if ((architectureByPosition.Domination > 0) && (this.InevitableSuccessOfInstigate || (GameObject.Random((architectureByPosition.Morale * 2) + 200) < GameObject.Random(this.InstigateAbility))))
                    {
                        int randomValue = StaticMethods.GetRandomValue(this.InstigateAbility, 60);
                        randomValue = architectureByPosition.DecreaseDomination(randomValue);
                        int increment = randomValue / 1;
                        this.AddTacticsExperience(increment * 6);
                        this.AddIntelligenceExperience(increment);
                        this.AddGlamourExperience(increment);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        if (this.OnInstigateSuccess != null)
                        {
                            this.OnInstigateSuccess(this, architectureByPosition, randomValue);
                        }
                        architectureByPosition.DecrementNumberList.AddNumber(randomValue, CombatNumberKind.士气, architectureByPosition.Position);
                        ExtensionInterface.call("DoInstigateSuccess", new Object[] { this.Scenario, this, randomValue });
                    }
                    else
                    {
                        ExtensionInterface.call("DoinstigateFail", new Object[] { this.Scenario, this });
                        if (this.OnInstigateFailed != null)
                        {
                            this.OnInstigateFailed(this, architectureByPosition);
                        }
                    }
                    CheckCapturedByArchitecture(architectureByPosition);
                }
                else
                {
                    ExtensionInterface.call("DoinstigateFail", new Object[] { this.Scenario, this });
                    if (this.OnInstigateFailed != null)
                    {
                        this.OnInstigateFailed(this, architectureByPosition);
                    }
                }
            }
        }

        public void DoEnhanceDiplomatic()
        {
            /*
            亲善
            势力间友好度上升=(c*20+max(执行武将政治-执行武将和目标势力君主的相性差/2,0)+100)/10
            系数c取决于执行武将和目标势力君主的关系，两者是义兄弟、配偶或者是目标君主的亲爱武将取2，是目标君主的厌恶武将取-1，否则取1
            如果难度为上级，则效果*0.8；如果难度为超级，则效果为*0.7 (这个部分可调整)
            执行武将名声+50，政治经验+5
            */
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            this.OutsideDestination = null;
            if ((this.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction != null))
            {
                //int g = (5 + (int)(5 * this.Glamour / 100));
                int c = 2;
                if (this.TargetArchitecture.BelongedFaction.Leader.IsCloseTo(this))
                {
                    c = 3;
                }
                if (this.TargetArchitecture.BelongedFaction.Leader.Hates(this))
                {
                    c = -2;
                }
                int g = (((c * 10 + Math.Max((this.politics - GetIdealOffset(this, this.TargetArchitecture.BelongedFaction.Leader) / 2), 0)) + 100) / 10);
                int cd = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID);
                if (((cd + g) > GlobalVariables.FriendlyDiplomacyThreshold * 0.95) && cd < GlobalVariables.FriendlyDiplomacyThreshold)
                {
                    g = (int) (GlobalVariables.FriendlyDiplomacyThreshold * 0.95 - cd);
                }
                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, g);
                this.TargetArchitecture.Fund += 10000;
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.EnhanceDiplomaticRelation, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                this.TargetArchitecture = this.LocationArchitecture;
                this.AddPoliticsExperience(5);
                this.IncreaseReputation(50);
            }
        }

        public void DoAllyDiplomatic()
        {
            /*
            同盟
        a、判定值=（金钱/150+执行武将政治-执行武将和目标势力君主的相性差/5+c*10）*t
        b、判定
        如果执行武将没有论客特技，且为执行势力君主为目标势力君主的厌恶武将，则必失败被捕
        如果判定值> 180，则成功
        否则执行武将有论客特技或者判定值>(80-势力间友好度)*2，则失败
        否则失败被捕（注：游戏中的实际效果和失败相同）
        c、结果
        1、成功
        势力间友好度+36 (大于300)
        执行武将功绩+500，政治经验+5
        势力技术点:50
        2、失败
        势力间友好度-10
        执行武将功绩+50，政治经验+1
        3、失败被捕（注：实际效果和失败相同）
            */
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            this.OutsideDestination = null;
            if ((this.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction != null))
            {
                int c = 2;
                if (this.TargetArchitecture.BelongedFaction.Leader.IsCloseTo(this))
                {
                    c = 3;
                }
                if (this.TargetArchitecture.BelongedFaction.Leader.Hates(this))
                {
                    c = -2;
                }
                int g = (c * 10 + (20000 / 150) + this.politics - GetIdealOffset(this, this.TargetArchitecture.BelongedFaction.Leader) / 5);
                int cd = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID);
                if (g > 180)
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, 36);
                    this.TargetArchitecture.Fund += 20000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.CreateAlly, "AllyDiplomaticRelation", "AllyDiplomaticRelation.jpg", "AllyDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(5);
                    this.IncreaseReputation(500);
                }
                else
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, -10);
                    this.BelongedArchitecture.Fund += 20000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.CreateAllyFailed, "AllyDiplomaticRelationFailed", "chuzhan.jpg", "BreakDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(1);
                    this.IncreaseReputation(50);
                }
            }
        }

        public void DoQuanXiangDiplomatic()
        {
            /*
          劝降
          a、判定成功条件：劝降势力声望>被劝降势力声望；劝降势力兵力大于0且为被劝降势力兵力的五倍；GameObjects.Chance(100-被劝降势力君主义理*25）；与被劝降势力接壤
          GameObjects.Chance(100-被劝降势力君主义理*25），如果被劝降势力君主义理为0，则概率为百分百 ，如此类推。   

          b、判定
          如果执行武将为目标势力君主的厌恶武将，则必失败；

          g = (c * 10 + 执行武将说服能力 + （执行武将政治+智谋）* 冷静度 - (执行武将与被劝降势力君主相性差 * 20 + （被劝降势力君主智谋+政治）*2));
          g > 0，则劝降成功

          c、结果
          1、成功

          执行武将名声+500，政治经验+50

         2、失败
         势力间友好度-100
         执行武将名声+50，政治经验+10
          */
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            Faction targetFaction = this.TargetArchitecture.BelongedFaction;
            this.OutsideDestination = null;

            if (QuanXiangChance(this.BelongedFaction, targetFaction, this))
            {
                QuanXiangSuccess(this.BelongedFaction, targetFaction, this);

            }
            else
            {
               QuanXiangFailed(this.BelongedFaction, targetFaction, this);
               return;
            }
            
        }

        private  bool QuanXiangChance(Faction sourceFaction, Faction targetFaction, Person shizhe)
        {
            if (sourceFaction == null || targetFaction == null) return false;

            if (targetFaction == sourceFaction) return false;

           // if (base.Scenario.IsPlayer(sourceFaction)) return true;

            if (sourceFaction.Army == 0) return false;

            if (sourceFaction.Reputation <= targetFaction.Reputation) return false;

            if (sourceFaction.Army < targetFaction.Army * 5) return false;

            if (!sourceFaction.adjacentTo(targetFaction)) return false;

            if (targetFaction.Leader.Hates(shizhe)) return false;

            if (GameObject.Random(targetFaction.Leader.Intelligence) + GameObject.Random( shizhe.Intelligence) >= 45) return false;

            if (targetFaction.Leader.PersonalLoyalty > 3) return false;

            int c = targetFaction.Leader.IsCloseTo(shizhe) ? 50 : 10 ;

            int g = (c * 10 + shizhe.ConvinceAbility + (shizhe.Politics + shizhe.Intelligence) * shizhe.Calmness - ((GetIdealOffset(shizhe, targetFaction.Leader) * 20) + (targetFaction.Leader.Intelligence + targetFaction.Leader.Politics) * targetFaction.Leader.Calmness));

            return g > 0;
        }

        private static void QuanXiangSuccess(Faction sourceFaction, Faction targetFaction, Person shizhe)
        {
            //势力合并
            shizhe.Scenario.GameScreen.xianshishijiantupian(shizhe, sourceFaction.Leader.Name, TextMessageKind.QuanXiang, "QuanXiangDiplomaticRelation", "QuanXiangDiplomaticRelation.jpg", "shilimiewang.wma", targetFaction.Name, true);

            shizhe.Scenario.YearTable.addChangeFactionEntry(shizhe.Scenario.Date, targetFaction, sourceFaction);
            foreach (Person p in targetFaction.Persons.GetList())
            {
                p.InitialLoyalty();
            }
            targetFaction.ChangeFaction(sourceFaction);
            
            targetFaction.AfterChangeLeader(targetFaction.Leader, sourceFaction.Leader);
                
            foreach (Treasure treasure in targetFaction.Leader.Treasures.GetList())
            {
                targetFaction.Leader.LoseTreasure(treasure);
                sourceFaction.Leader.ReceiveTreasure(treasure);

            }
            shizhe.TargetArchitecture = shizhe.LocationArchitecture;
            shizhe.AddPoliticsExperience(50);
            shizhe.IncreaseReputation(500);
        }

        private static void QuanXiangFailed(Faction sourceFaction, Faction targetFaction, Person shizhe)
        {
            shizhe.Scenario.ChangeDiplomaticRelation(sourceFaction.ID, targetFaction.ID, -100);
            shizhe.BelongedArchitecture.Fund += 20000;
            shizhe.TargetArchitecture.Fund += 30000;
            if (shizhe.Scenario.IsPlayer(shizhe.BelongedFaction))
            {
                shizhe.Scenario.GameScreen.xianshishijiantupian(shizhe, sourceFaction.Leader.Name, TextMessageKind.QuanXiangFailed, "QuanXiangDiplomaticRelationFailed", "BreakDiplomaticRelation.jpg", "BreakDiplomaticRelation.wav", targetFaction.Name, true);
            }
            shizhe.TargetArchitecture = shizhe.LocationArchitecture;
            shizhe.AddPoliticsExperience(10);
            shizhe.IncreaseReputation(50);
        }
        
      

      public void DoTruceDiplomatic()
      {
          /*
          停战协定
          a、判定值=（金钱/400+执行武将政治-执行武将和目标势力君主的相性差/5+c）*t
              系数c取决于执行武将和目标势力君主的关系，两者是义兄弟、配偶或者是目标君主的亲爱武将取20，是目标君主的厌恶武将取-15，否则取10
              t为难度系数，初级上级超级分别为1.0、0.8、0.7
          b、判定
              如果判定值>(80+停战期间/2-势力间友好度/4)，成功
              否则执行武将有论客特技或者判定值>(70+停战期间/2-势力间友好度/4)，则失败
              否则失败被捕（注：游戏中的实际效果和失败相同）
          c、结果
              1、成功
                  执行武将功绩+500，政治经验+5
                  势力技术点:+30
              2、失败
                  势力间友好度-10
                  执行武将功绩+50，政治经验+1
              3、失败被捕（注：实际效果和失败相同）
          */
            this.OutsideTask = OutsideTaskKind.无;
            this.TargetArchitecture = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            this.OutsideDestination = null;
            if ((this.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction != null))
            {
                int c = 2;
                if (this.TargetArchitecture.BelongedFaction.Leader.IsCloseTo(this))
                {
                    c = 4;
                }
                if (this.TargetArchitecture.BelongedFaction.Leader.Hates(this))
                {
                    c = -3;
                }
                int g = (c * 5 + 50000 / 400 + this.politics - GetIdealOffset(this, this.TargetArchitecture.BelongedFaction.Leader) / 5);
                int cd = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID);
                if (g > (80 - cd / 4))
                {
                    int di = 10;
                    if (cd + di > 290)
                    {
                        di = 290 - cd;
                    }
                    if (di < 0)
                    {
                        di = 0;
                    }
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, di);
                    this.TargetArchitecture.Fund += 50000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.Truce, "TruceDiplomaticRelation", "TruceDiplomaticRelation.jpg", "TruceDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    //设置停战
                    this.Scenario.SetDiplomaticRelationTruce(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, 30);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(5);
                    this.IncreaseReputation(500);
                }
                else
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.TargetArchitecture.BelongedFaction.ID, -10);
                    this.BelongedArchitecture.Fund += 30000;
                    this.TargetArchitecture.Fund += 20000;
                    this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.TruceFailed, "TruceDiplomaticRelationFailed", "chuzhan.jpg", "BreakDiplomaticRelation.wav", this.TargetArchitecture.BelongedFaction.Name, true);
                    this.TargetArchitecture = this.LocationArchitecture;
                    this.AddPoliticsExperience(1);
                    this.IncreaseReputation(50);
                }
            }
        }

        private void DoOutsideTask()
        {
            switch (this.OutsideTask)
            {
                case OutsideTaskKind.说服:
                    this.DoConvince();
                    break;

                case OutsideTaskKind.情报:
                    this.DoInformation();
                    break;
                    /*
                case OutsideTaskKind.间谍:
                    this.DoSpy();
                    break;
                    */
                case OutsideTaskKind.破坏:
                    this.DoDestroy();
                    break;

                case OutsideTaskKind.煽动:
                    this.DoInstigate();
                    break;

                case OutsideTaskKind.流言:
                    this.DoGossip();
                    break;

                case OutsideTaskKind.搜索:
                    this.DoSearch();
                    break;

                case OutsideTaskKind.技能:
                    this.DoStudySkill();
                    break;

                case OutsideTaskKind.称号:
                    this.DoStudyTitle();
                    break;

                case OutsideTaskKind.特技:
                    this.DoStudyStunt();
                    break;

                case OutsideTaskKind.后宮:
                    this.DoHouGong();
                    break;

                case OutsideTaskKind.亲善:
                    this.DoEnhanceDiplomatic();
                    break;

                case OutsideTaskKind.结盟:
                    this.DoAllyDiplomatic();
                    break;

                case OutsideTaskKind.停战:
                    this.DoTruceDiplomatic();
                    break;

                case OutsideTaskKind.劫狱:
                    this.DoJailBreak();
                    break;

                case OutsideTaskKind.暗杀:
                    this.DoAssassinate();
                    break;

                case OutsideTaskKind.劝降:
                    this.DoQuanXiangDiplomatic();
                    break ;
            }
        }

        

        public void DoSearch()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if ((this.TargetArchitecture != null) && (this.TargetArchitecture.BelongedFaction == this.BelongedFaction))
            {
                SearchResultPack pack = new SearchResultPack();
                bool flag = false;
                bool flag2 = false;
                bool flag3 = false;
                bool flag4 = false;
                if (this.InevitableSuccessOfSearch)
                {
                    pack.Result = (SearchResult)(GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length - 1) + 1);
                }
                else
                {
                    pack.Result = (SearchResult)GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length);
                }
                switch (pack.Result)
                {
                    case SearchResult.资金:
                        flag = this.DoSearchFund(pack);
                        break;

                    case SearchResult.粮草:
                        flag = this.DoSearchFood(pack);
                        break;

                    case SearchResult.技巧:
                        flag = this.DoSearchTechnique(pack);
                        break;
                        /*
                    case SearchResult.间谍:
                        flag = this.DoSearchSpy(pack);
                        flag2 = flag;
                        break;
                        */
                    case SearchResult.隐士:
                        flag = this.DoSearchPerson(pack);
                        flag3 = flag;
                        break;

                    case SearchResult.宝物:
                        flag = this.DoSearchTreasure(pack);
                        flag4 = flag;
                        break;
                }
                if (!flag && this.InevitableSuccessOfSearch)
                {
                    switch (GameObject.Random(3))
                    {
                        case 0:
                            pack.Result = SearchResult.资金;
                            flag = this.DoSearchFund(pack);
                            break;

                        case 1:
                            pack.Result = SearchResult.粮草;
                            flag = this.DoSearchFood(pack);
                            break;

                        case 2:
                            pack.Result = SearchResult.技巧;
                            flag = this.DoSearchTechnique(pack);
                            break;
                    }
                }
                if (flag)
                {
                    this.AddTacticsExperience(60);
                    this.AddIntelligenceExperience(5);
                    this.AddPoliticsExperience(5);
                    this.AddGlamourExperience(10);
                    this.IncreaseReputation(20);
                    this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                    this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                    if (this.OnSearchFinished != null)
                    {
                        this.OnSearchFinished(this, this.TargetArchitecture, pack);
                    }
                }
                else
                {
                    pack.Result = SearchResult.无;
                    if (this.OnSearchFinished != null)
                    {
                        this.OnSearchFinished(this, this.TargetArchitecture, pack);
                    }
                }
                ExtensionInterface.call("DoSearch", new Object[] { this.Scenario, this, pack });
            }
        }

        private bool DoSearchFood(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = this.SearchAbility * 20;
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                this.TargetArchitecture.IncreaseFood(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchFund(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = StaticMethods.GetRandomValue(this.SearchAbility, 2);
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                this.TargetArchitecture.IncreaseFund(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchPerson(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                foreach (Person person in base.Scenario.Persons)
                {
                    if (((((!person.Available && person.Alive) && (person.YearAvailable <= base.Scenario.Date.Year)) && GameObject.Chance(20)) && (person.AvailableLocation == this.TargetArchitecture.ID)) && ((((((GlobalVariables.CommonPersonAvailable && (person.ID >= 0)) && (person.ID <= 0x1b57)) || ((GlobalVariables.AdditionalPersonAvailable && (person.ID >= 0x1f40)) && (person.ID <= 0x2327))) || ((GlobalVariables.PlayerPersonAvailable && (person.ID >= 0x2328)) && (person.ID <= 0x270f))) && !base.Scenario.PreparedAvailablePersons.HasGameObject(person)) && person.BeAvailable()))
                    {
                        pack.FoundPerson = person;
                        return true;
                    }
                }
                /*
                if (GameObject.Random((int) (10000 * Math.Pow(this.BelongedFaction.PersonCount, Parameters.SearchPersonArchitectureCountPower))) < 
                    GlobalVariables.CreateRandomOfficerChance * 100)
                {
                    pack.FoundPerson = Person.createPerson(base.Scenario, this.TargetArchitecture, this,true);
                    return true;
                }
                else if (!base.Scenario.IsPlayer(this.BelongedFaction) &&
                    GameObject.Random((int) (10000 * Math.Pow(this.BelongedFaction.PersonCount, Parameters.SearchPersonArchitectureCountPower))) < 
                    GlobalVariables.CreateRandomOfficerChance * 100 * (Parameters.AIExtraPerson - 1))
                {
                    pack.FoundPerson = Person.createPerson(base.Scenario, this.TargetArchitecture, this,true);
   
                    GameObjectList ideals = base.Scenario.GameCommonData.AllIdealTendencyKinds;
                    IdealTendencyKind minIdeal = null;
                    foreach (IdealTendencyKind itk in ideals)
                    {
                        if (minIdeal == null || itk.Offset < minIdeal.Offset)
                        {
                            minIdeal = itk;
                        }
                    }

                    pack.FoundPerson.IdealTendency = minIdeal;
                    pack.FoundPerson.Ideal = (this.BelongedFaction.Leader.Ideal + GameObject.Random(minIdeal.Offset * 2 + 1) - minIdeal.Offset) % 150;

                    return true;
                }*/
                    
            }
            return false;
        }

        /*
        private bool DoSearchSpy(SearchResultPack pack)
        {
            if (this.TargetArchitecture.HasSpy && (this.InevitableSuccessOfSearch || (GameObject.Random(this.SearchAbility + 500) > 500)))
            {
                SpyPack sp = this.TargetArchitecture.SpyPacks[GameObject.Random(this.TargetArchitecture.SpyPacks.Count)];
                if (sp.SpyPerson.BelongedFaction != this.BelongedFaction)
                {
                    if (sp.SpyPerson.BelongedFaction != null)
                    {
                        base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, sp.SpyPerson.BelongedFaction.ID, -10);
                    }
                    if (this.OnSpyFound != null)
                    {
                        this.OnSpyFound(this, sp.SpyPerson);
                    }
                    pack.FoundPerson = sp.SpyPerson;
                }
                this.TargetArchitecture.RemoveSpyPack(sp);
                return true;
            }
            return false;
        }
        */

        private bool DoSearchTechnique(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                pack.Number = this.SearchAbility * 2;
                pack.Number = (pack.Number / 2) + GameObject.Random(pack.Number);
                return true;
            }
            return false;
        }

        private bool DoSearchTreasure(SearchResultPack pack)
        {
            if (this.InevitableSuccessOfSearch || (GameObject.Random(this.TargetArchitecture.Morale + this.SearchAbility) >= GameObject.Random(0x3e8)))
            {
                foreach (Treasure treasure in base.Scenario.Treasures.GetRandomList())
                {
                    if (((!treasure.Available && (treasure.BelongedPerson == null)) && (treasure.HidePlace == this.TargetArchitecture)) && (treasure.AppearYear <= base.Scenario.Date.Year))
                    {
                        if (GameObject.Random(treasure.Worth) <= GameObject.Random(Parameters.FindTreasureChance))
                        {
                            treasure.Available = true;
                            //this.ReceiveTreasure(treasure);
                            this.BelongedFaction.Leader.ReceiveTreasure(treasure);
                            if (this.OnTreasureFound != null)
                            {
                                this.OnTreasureFound(this, treasure);
                            }
                        }
                        break;
                    }
                }
            }
            return false;
        }

        /*
        public void DoSpy()
        {
            this.OutsideTask = OutsideTaskKind.无;
            Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
            if (architectureByPosition != null)
            {
                if ((architectureByPosition.BelongedFaction != null) && (this.BelongedFaction != architectureByPosition.BelongedFaction))
                {
                    if (this.InevitableSuccessOfSpy || (GameObject.Random((architectureByPosition.Domination * (20 - architectureByPosition.AreaCount)) - architectureByPosition.Commerce) < this.SpyAbility))
                    {
                        architectureByPosition.AddSpyPack(this, this.SpyDays);
                        this.AddTacticsExperience(60);
                        this.AddIntelligenceExperience(10);
                        this.AddStrengthExperience(5);
                        this.AddGlamourExperience(5);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        ExtensionInterface.call("DoSpySuccess", new Object[] { this.Scenario, this, this.SpyDays });
                        if (this.OnSpySuccess != null)
                        {
                            this.OnSpySuccess(this, architectureByPosition);
                        }
                    }
                    else
                    {
                        ExtensionInterface.call("DoSpyFail", new Object[] { this.Scenario, this });
                        if (this.OnSpyFailed != null)
                        {
                            this.OnSpyFailed(this, architectureByPosition);
                        }
                    }
                }
                else if (this.OnSpyFailed != null)
                {
                    ExtensionInterface.call("DoSpyFail", new Object[] { this.Scenario, this });
                    if (this.OnSpyFailed != null)
                    {
                        this.OnSpyFailed(this, architectureByPosition);
                    }
                }
            }
        }
        */

        public int zhenzaiWeighing
        {
            get
            {
                return zhenzaiAbility;
            }
        }
        public bool CheckCapturedByArchitecture(Architecture a)
        {
            if (a.BelongedFaction != null && a.BelongedFaction != this.BelongedFaction)
            {
                if (!this.ImmunityOfCaptive && 
                    (GameObject.Random(a.Domination * 10 + a.Morale) + 200 > GameObject.Random(this.CaptiveAbility) * 60 
                    || GameObject.Chance((int) (a.captureChance * (base.Scenario.IsPlayer(a.BelongedFaction) ? 1 : Parameters.AIExtraPerson)))))
                {
                    this.ArrivingDays = 0;
                    this.TargetArchitecture = null;
                    this.TaskDays = 0;
                    this.OutsideTask = OutsideTaskKind.无;
                    Captive captive = Captive.Create(base.Scenario, this, a.BelongedFaction);
                    this.Status = PersonStatus.Captive;
                    foreach (Treasure treasure in this.Treasures.GetList())
                    {
                        this.LoseTreasure(treasure);
                        a.BelongedFaction.Leader.ReceiveTreasure(treasure);
                    }
                    this.LocationArchitecture = a;
                    ExtensionInterface.call("CapturedByArchitecture", new Object[] { this.Scenario, this, a });
                    if (this.OnCapturedByArchitecture != null)
                    {
                        this.OnCapturedByArchitecture(this, a);
                    }
                    return true;
                }
            }
            return false;

        }

        public int StudyableSkillCount
        {
            get
            {
                int result = 0;
                foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
                {
                    if ((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public int StudyableStuntCount
        {
            get
            {
                int result = 0;
                foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
                {
                    if (this.Stunts.GetStunt(stunt.ID) == null && stunt.IsLearnable(this))
                    {
                        result++;
                    }
                }
                return result;
            }
        }

        public String TitleNames
        {
            get
            {
                String s = "";
                foreach (Title t in this.Titles)
                {
                    s += t.Name + " ";
                }
                return s;
            }
        }

        public String TitleDetailedNames
        {
            get
            {
                String s = "";
                foreach (Title t in this.Titles)
                {
                    s += t.DetailedName + " ";
                }
                return s;
            }
        }

        public int StudyableTitleCount
        {
            get
            {
                return this.GetStudyTitleList().Count;
            }
        }

        public int StudyableHigherLevelTitleCount
        {
            get
            {
                return this.HigherLevelLearnableTitle.Count;
            }
        }

        public String StudyableHigherLevelTitle
        {
            get
            {
                Dictionary<TitleKind, int> title = new Dictionary<TitleKind, int>();
                foreach (Title candidate in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    HashSet<TitleKind> hasKind = new HashSet<TitleKind>();
                    foreach (Title t in this.Titles)
                    {
                        if (t.Kind == candidate.Kind && candidate.Level > t.Level && candidate.CanLearn(this))
                        {
                            if (title.ContainsKey(candidate.Kind))
                            {
                                title[candidate.Kind]++;
                            }
                            else
                            {
                                title.Add(candidate.Kind, 1);
                            }
                        }
                        hasKind.Add(t.Kind);
                    }
                    if (!hasKind.Contains(candidate.Kind) && candidate.CanLearn(this))
                    {
                        if (title.ContainsKey(candidate.Kind))
                        {
                            title[candidate.Kind]++;
                        }
                        else
                        {
                            title.Add(candidate.Kind, 1);
                        }
                    }
                }

                String s = "";
                foreach (KeyValuePair<TitleKind, int> i in title)
                {
                    s += i.Key.Name + i.Value + "個";
                }
                return s;
            }
        }

        public void DoStudySkill()
        {
            this.OutsideTask = OutsideTaskKind.无;
            int num = 0;
            string skillString = "";
            foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                if (((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this)) && (GameObject.Random((skill.Level * 2) + 8) >= ((skill.Level + num) * 2 - Parameters.LearnSkillSuccessRate)))
                {
                    this.Skills.AddSkill(skill);
                    skill.Influences.ApplyInfluence(this, GameObjects.Influences.Applier.Skill, skill.ID, false);
                    skillString = skillString + "•" + skill.Name;
                    num++;
                    ExtensionInterface.call("StudySkill", new Object[] { this.Scenario, this, skill });
                }
            }
            if (this.OnStudySkillFinished != null && this.ManualStudy)
            {
                this.OnStudySkillFinished(this, skillString, num > 0);

            }
            this.ManualStudy = false;
        }

        public void DoStudyStunt()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingStunt != null)
            {
                if (GameObject.Chance(Parameters.LearnStuntSuccessRate))
                {
                    this.Stunts.AddStunt(this.StudyingStunt);
                    ExtensionInterface.call("StudyStuntSuccess", new Object[] { this.Scenario, this, this.StudyingStunt });
                    if (this.OnStudyStuntFinished != null && this.ManualStudy)
                    {
                        this.OnStudyStuntFinished(this, this.StudyingStunt, true);
                    }
                }
                else
                {
                    ExtensionInterface.call("StudyStuntFail", new Object[] { this.Scenario, this, this.StudyingStunt });
                    if (this.OnStudyStuntFinished != null && this.ManualStudy)
                    {
                        this.OnStudyStuntFinished(this, this.StudyingStunt, false);
                    }
                }
                this.StudyingStunt = null;
            }
            this.ManualStudy = false;
        }

        /*
        public bool HasHigherLevelGuazhi(Guanzhi guanzhi)
        {
            List<Guanzhi> oldGuanzhis = new List<Guanzhi> (this.RealGuanzhis);
            foreach (Guanzhi g in oldGuanzhis )
            {
                if (g.Kind == guanzhi .Kind && g.Level >= guanzhi.Level )
                {
                    return true;
                }
            }
            return false;
        }

        public void AwardGuanzhi(Guanzhi guanzhi)
        {
            List<Guanzhi> oldGuanzhis = new List<Guanzhi>(this.RealGuanzhis);
            foreach (Guanzhi g in oldGuanzhis)
            {
                if (g.Kind == guanzhi.Kind)
                {
                    g.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Guanzhi, g.ID, false);
                    this.RealGuanzhis.Remove(g);
                }
            }
            this.RealGuanzhis.Add(guanzhi);
            base.Scenario.YearTable.addObtainedGuanzhiEntry(base.Scenario.Date, this, guanzhi);
        }

        public void LoseGuanzhi()
        {
            List<Guanzhi> temp = new List<Guanzhi>(this.RealGuanzhis);
            foreach (Guanzhi g in temp)
            {
                if (g.LoseConditions.Count > 0 && g.WillLose(this))
                {
                    g.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Guanzhi, g.ID, false);

                    this.RealGuanzhis.Remove(g);
                }

            }
        }
        */

        public bool HasHigherLevelTitle(Title title)
        {
            List<Title> oldTitles = new List<Title>(this.RealTitles);
            foreach (Title t in oldTitles)
            {
                if (t.Kind == title.Kind && t.Level >= title.Level)
                {
                    return true;
                }
            }
            return false;
        }
        
        public void LearnTitle(Title title)
        {
            List<Title> oldTitles = new List<Title>(this.RealTitles);
            foreach (Title t in oldTitles)
            {
                if (t.Kind == title.Kind)
                {
                    t.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Title, t.ID, false);
                    this.RealTitles.Remove(t);
                }
            }
            this.RealTitles.Add(title);
            base.Scenario.YearTable.addObtainedTitleEntry(base.Scenario.Date, this, title);
        }

        public void LoseTitle()
        {
            List<Title> temp = new List<Title>(this.RealTitles);
            foreach (Title t in temp)
            {
                if (t.LoseConditions.Count > 0  && t.WillLose(this))
                {
                    t.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Title, t.ID, false);

                    this.RealTitles.Remove(t);
                }

            }
        }

        public void AwardTitle(Title title)
        {
            List<Title> oldTitles = new List<Title>(this.RealTitles);
            foreach (Title t in oldTitles)
            {
                if (t.Kind == title.Kind)
                {
                    t.Influences.PurifyInfluence(this, GameObjects.Influences.Applier.Title, t.ID, false);
                    this.RealTitles.Remove(t);
                }
            }
            this.RealTitles.Add(title);
            if (base.Scenario.IsPlayer(this.BelongedFaction))
            {
                base.Scenario.GameScreen.xianshishijiantupian(this.BelongedFaction.Leader, this.Name, "AwardTitle", "AwardTitle.jpg", "AwardTitle.wav", title.Name, true);
            }
            base.Scenario.YearTable.addAwardTitleEntry(base.Scenario.Date, this, title);
        }

        public void RemoveTitle(Title title)
        {
            this.RealTitles.Remove(title);
        }

        public void DoStudyTitle()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingTitle != null)
            {
                if (GameObject.Random((this.StudyingTitle.Level * 2) + 8) + this.StudyingTitle.Kind.SuccessRate >= (this.StudyingTitle.Level * 2 - Parameters.LearnTitleSuccessRate))
                {
                    this.PurifyTitles(false);

                    foreach (Title t in this.RealTitles)
                    {
                        if (t.Kind == this.StudyingTitle.Kind)
                        {
                            this.RealTitles.Remove(t);
                            break;
                        }

                    }
                    this.RealTitles.Add(this.StudyingTitle);
                    base.Scenario.YearTable.addObtainedTitleEntry(base.Scenario.Date, this, this.StudyingTitle);

                    this.ApplyTitles(false);
                    this.ApplySkills(false);

                    ExtensionInterface.call("StudyTitleSuccess", new Object[] { this.Scenario, this, this.StudyingTitle });
                    if (this.OnStudyTitleFinished != null && this.ManualStudy)
                    {
                        this.OnStudyTitleFinished(this, this.StudyingTitle, true);
                    }
                }
                else
                {
                    ExtensionInterface.call("StudyTitleFail", new Object[] { this.Scenario, this, this.StudyingTitle });
                    if (this.OnStudyTitleFinished != null && this.ManualStudy)
                    {
                        this.OnStudyTitleFinished(this, this.StudyingTitle, false);
                    }
                }
                this.StudyingTitle = null;
                this.ManualStudy = false;
            }
        }

        public GameObjectList GetHirableFactionList()
        {
            GameObjectList list = new GameObjectList();
            foreach (GameObjects.Faction faction in base.Scenario.Factions)
            {
                if (this.IsHirable(faction))
                {
                    list.Add(faction);
                }
            }
            return list;
        }

        public static int GetIdealOffset(Person p1, Person p2)
        {
            int num = Math.Abs((int)(p1.Ideal - p2.Ideal));
            if (num > 75)
            {
                num = Math.Abs(150 - num);
            }
            return num;
        }

        public bool YoukenengChuangjianXinShili()
        {
            if (this.IsCaptive || this.LocationArchitecture == null ||
                (this.Status != PersonStatus.Normal && this.Status != PersonStatus.NoFaction))
            {
                return false;
            }

            if (this.BelongedFaction == null)
            {

                return true;
            }
            else
            {
                if (this == this.BelongedFaction.Leader) return false;
                if (this.Father == this.BelongedFaction.Leader) return false;  //隐含父亲活着，下同。
                if (this.Mother == this.BelongedFaction.Leader) return false;
                if (this.IsCloseTo(this.BelongedFaction.Leader)) return false;
                if (this.Strain == this.BelongedFaction.Leader.Strain) return false;  //同一血缘不能独立，孙子不能从爷爷手下独立。
                return true;
            }

        }

        public GameObjectList GetSkillList()
        {
            return this.Skills.GetSkillList();
        }

        public GameObjectList GetStudySkillList()
        {
            this.StudySkillList.Clear();
            foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                if ((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this))
                {
                    this.StudySkillList.Add(skill);
                }
            }
            return StudySkillList;
        }

        public GameObjectList GetStuntList()
        {
            return this.Stunts.GetStuntList();
        }

        public GameObjectList GetStudyStuntList()
        {
            this.StudyStuntList.Clear();
            foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
            {
                if ((this.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(this))
                {
                    this.StudyStuntList.Add(stunt);
                }
            }
            return StudyStuntList;
        }

        public GameObjectList GetTitleList()
        {
            GameObjectList result = new GameObjectList();
            foreach (Title t in this.Titles)
            {
                result.Add(t);
            }
            return result;
        }

        public GameObjectList GetStudyTitleList()
        {
            this.StudyTitleList.Clear();
            foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                if (!this.RealTitles.Contains(title) && title.CanLearn(this))
                {
                    this.StudyTitleList.Add(title);
                }
            }
            return StudyTitleList;
        }

        public GameObjectList GetAppointableTitleList()
        {
            this.AppointableTitleList.Clear();
            foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                if (!this.RealTitles.Contains(title) && !this.HasHigherLevelTitle(title) && title.ManualAward && title.CanLearn(this,true))        
                {
                    this.AppointableTitleList.Add(title);
                }
            }
            return AppointableTitleList;
        }

        public GameObjectList RecallableTitleList()
        {
            GameObjectList list = new GameObjectList();
            foreach (Title title in this.RealTitles)
            {
                if ((title.Kind.ID == 5 || title.Kind.ID == 10 || title.Kind.ID == 20 || title.Kind.ID == 21) && title.AutoLearn > 0)
                {
                    list.Add(title);
                }
            }
            return list;
        }

        public int GetWorkAbility(ArchitectureWorkKind workKind)
        {
            switch (workKind)
            {
                case ArchitectureWorkKind.无:
                    return 0;

                case ArchitectureWorkKind.赈灾:
                    return this.zhenzaiAbility;

                case ArchitectureWorkKind.农业:
                    return this.AgricultureAbility;

                case ArchitectureWorkKind.商业:
                    return this.CommerceAbility;

                case ArchitectureWorkKind.技术:
                    return this.TechnologyAbility;

                case ArchitectureWorkKind.统治:
                    return this.DominationAbility;

                case ArchitectureWorkKind.民心:
                    return this.MoraleAbility;

                case ArchitectureWorkKind.耐久:
                    return this.EnduranceAbility;

                case ArchitectureWorkKind.训练:
                    return this.TrainingAbility;
            }
            return 0;
        }

        public void GoForConvince(Person person)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal) 
            {
                this.OutsideTask = OutsideTaskKind.说服;
                this.ConvincingPerson = person;
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.ConvincePersonFund);
                this.GoToDestinationAndReturn(this.OutsideDestination.Value);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForConvince", new Object[] { this.Scenario, this, person });
            }
        }
        /*
        public void GoForQxuanXiang(Person person)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal) 
            {
                this.outsideTask = OutsideTaskKind .劝降;
                this.ConvincingPerson = person;
                this.LocationArchitecture.DecreaseFund(10000);
                this.GoToDestinationAndReturn(this.OutsideDestination.Value);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForQuanXiang", new Object[] { this.Scenario, this, person });
            }
        }
        */

 

        public void GoForDestroy(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.破坏;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.DestroyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForDestroy", new Object[] { this.Scenario, this, position });
            }
        }

        public void GoForGossip(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.流言;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.GossipArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForGossip", new Object[] { this.Scenario, this, position });
            }
        }

        public void GoForInformation(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.情报;
                this.OutsideDestination = new Point?(position);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = this.ArrivingDays;
                ExtensionInterface.call("GoForInformation", new Object[] { this.Scenario, this, position });
            }
        }

        public void GoForJailBreak(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.劫狱;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.JailBreakArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForJailBreak", new Object[] { this.Scenario, this, position });
            }
        }

        public void GoForInstigate(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.煽动;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.InstigateArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForInstigate", new Object[] { this.Scenario, this, position });
            }
        }

        public void GoForSearch()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.搜索;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, Parameters.SearchDays);
                this.TaskDays = this.ArrivingDays;
                this.Status = PersonStatus.Moving;
                ExtensionInterface.call("GoForSearch", new Object[] { this.Scenario, this });
            }
        }

        public void GoForAssassinate(Person person)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.暗杀;
                this.ConvincingPerson = person;
                this.GoToDestinationAndReturn(this.OutsideDestination.Value);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForAssassinate", new Object[] { this.Scenario, this });
            }
        }

        public void shoudongjinxingsousuo()
        {
            this.shoudongsousuo = true;
            this.GoForSearch();
        }

        /*
        public void GoForSpy(Point position)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.间谍;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.SpyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
                ExtensionInterface.call("GoForSpy", new Object[] { this.Scenario, this, position });
            }
        }
        */

        public void GoForStudySkill()
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.技能;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, Parameters.LearnSkillDays);
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
                ExtensionInterface.call("GoForStudySkill", new Object[] { this.Scenario, this });
            }
        }

        public void GoForStudyStunt(Stunt desStunt)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.特技;
                this.StudyingStunt = desStunt;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1, Parameters.LearnStuntDays);
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
                ExtensionInterface.call("GoForStudyStunt", new Object[] { this.Scenario, this });
            }
        }

        public void GoForStudyTitle(Title desTitle)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                this.OutsideTask = OutsideTaskKind.称号;
                this.StudyingTitle = desTitle;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Math.Max(1,
                    Math.Min(this.LocationArchitecture.DayLearnTitleDay, desTitle.Kind.StudyDay));
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
                ExtensionInterface.call("GoForStudyTitle", new Object[] { this.Scenario, this });
            }
        }

        private void GoToDestinationAndReturn(Point destination)
        {
            this.TargetArchitecture = this.LocationArchitecture;
            this.ArrivingDays = base.Scenario.GetReturnDays(destination, this.TargetArchitecture.ArchitectureArea);
            this.Status = PersonStatus.Moving;
        }

        /*
        private void HandleSpyMessage(SpyMessage sm)
        {
            if (sm.Kind == SpyMessageKind.NewTroop)
            {
            }
        }
        */

        public int IncreaseLoyalty(int increment)
        {
            //110为剧本阈值，加忠诚不超过，超过的不降忠诚
            if (increment > (110 - this.Loyalty))
            {
                increment = 110 - this.Loyalty;
            }
            if (increment > 0)
            {
                this.loyalty += increment;
                return increment;
            }
            return 0;
        }

        public void DecreaseReputation(int v)
        {
            this.reputation -= v;
            if (this.reputation == 0)
            {
                this.reputation = 0;
            }
        }

        public bool IncreaseReputation(int increment)
        {
            this.reputation += increment;
            return true;
        }

        public bool LoseReputationBy(float rate)
        {
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.Reputation = (int)(this.BelongedFaction.Reputation * (1 - rate));
            }
            this.reputation = (int)(this.reputation * (1 - rate));
            return true;
        }

        public void IncreaseTechniquePoint(int increment)
        {
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.IncreaseTechniquePoint(increment);
            }
        }

        public void InitialLoyalty()
        {
            if (this.BelongedFaction == null)
            {
                this.Loyalty = 0;
                return;
            }

            if (this.Father != null && this.Mother != null && this.Father.childrenLoyalty > this.Mother.childrenLoyalty)
            {
                if (GameObject.Chance(this.Father.childrenLoyaltyRate))
                {
                    this.Loyalty = this.Father.childrenLoyalty;
                    return;
                }
                if (GameObject.Chance(this.Mother.childrenLoyaltyRate))
                {
                    this.Loyalty = this.Mother.childrenLoyalty;
                    return;
                }
            }
            else if (this.Father != null && this.Mother != null)
            {
                if (GameObject.Chance(this.Mother.childrenLoyaltyRate))
                {
                    this.Loyalty = this.Mother.childrenLoyalty;
                    return;
                }
                if (GameObject.Chance(this.Father.childrenLoyaltyRate))
                {
                    this.Loyalty = this.Father.childrenLoyalty;
                    return;
                }
            }

            int num = (60 + (10 * (int)this.PersonalLoyalty)) - (GetIdealOffset(this, this.BelongedFaction.Leader) / 5);
            if (this.Ideal == this.BelongedFaction.Leader.Ideal)
            {
                num += 20;
            }
            if (this.Father == this.BelongedFaction.Leader || this.Mother == this.BelongedFaction.Leader)
            {
                num += 20;
            }
            if (this.Closes(this.BelongedFaction.Leader))
            {
                num += 30;
            }
            if (this.IsVeryCloseTo(this.BelongedFaction.Leader))
            {
                num += 50;
            }
            this.Loyalty = num;
        }

        public bool IsHirable(GameObjects.Faction faction)
        {
            if (faction.Leader != null)
            {
                if (this.Hates(faction.Leader))
                {
                    return false;
                }
                if (GlobalVariables.IdealTendencyValid && (this.IdealTendency != null))
                {
                    bool flag = GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset;
                    if (!flag)
                    {
                        foreach (GameObjects.Faction faction2 in base.Scenario.Factions)
                        {
                            if ((faction2 != faction) && (faction2.Leader != null))
                            {
                                flag = GetIdealOffset(this, faction2.Leader) <= this.IdealTendency.Offset;
                                if (flag)
                                {
                                    return false;
                                }
                            }
                        }
                        return true;
                    }
                }
                return true;
            }
            return false;
        }

        public void Killed()   //现在用PlayerKillLeader代替，应该没有使用
        {
            if (((this.LocationArchitecture != null) && !this.IsCaptive) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.LocationArchitecture);
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.Status = PersonStatus.None;
                this.LocationArchitecture = null;
            }
            else if ((this.TargetArchitecture != null) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.TargetArchitecture);
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.status = PersonStatus.None;
                base.Scenario.AvailablePersons.Remove(this);
            }
        }

        public void PlayerKillLeader()
        {
            this.execute(this.Scenario.CurrentPlayer);
        }

        private void illegallyKilled(Faction executingFaction, Person killer)
        {
            killer.ExecuteCount++;

            if (this.BelongedCaptive != null && this.BelongedCaptive.CaptiveFaction != null && this.BelongedCaptive.CaptiveFaction != executingFaction) // 斩有势力的俘虏
            {
                base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                if (this.BelongedFaction.Leader.HasStrainTo(this))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                }
                if (this.BelongedFaction.Leader.HasCloseStrainTo(this))
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -10);
                    base.Scenario.SetDiplomaticRelationIfHigher(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, 0);
                }
                if (this == this.BelongedFaction.Leader)
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -1000);
                    base.Scenario.SetDiplomaticRelationIfHigher(this.BelongedCaptive.CaptiveFaction.ID, executingFaction.ID, -1000);
                }
            }

            foreach (Person p in base.Scenario.Persons)
            {
                if (p == this) continue;
                if (p == killer) continue;
                if (p.IsVeryCloseTo(this))
                {
                    p.AddHated(killer);
                }
                if (p.HasCloseStrainTo(this))
                {
                    // person close to killed one hates executor
                    p.AddHated(killer);

                    // person close to killed one may also hate executor's close persons
                    foreach (Person q in base.Scenario.Persons)
                    {
                        if (p == q || q == this || q == killer) continue;
                        if (GameObject.Chance((4 - p.PersonalLoyalty) * 25)) continue;
                        if (q.HasCloseStrainTo(killer))
                        {
                            p.AddHated(q);
                        }
                    }
                }
            }

            killer.LoseReputationBy(0.02f * this.PersonalLoyalty);
        }

        public void execute(Faction executingFaction)
        {
            Faction old = null;

            if (this.BelongedCaptive != null)
            {
                old = this.BelongedCaptive.CaptiveFaction;
                this.BelongedCaptive.Clear();
            }

            Person executor = executingFaction.Leader;

            this.illegallyKilled(executingFaction, executor);

            ExtensionInterface.call("Executed", new Object[] { this.Scenario, this, executingFaction });

            base.Scenario.YearTable.addExecuteEntry(base.Scenario.Date, executor, this, old);
            this.ToDeath(null, old);
        }
        /*
        private void LeaveFaction()
        {
            if (GameObject.Chance(20) && ((((this.LocationArchitecture != null) && (this.BelongedFaction != null)) && (this.BelongedFaction.Leader != this)) && !this.IsCaptive))
            {
                if ((this.Loyalty < 50) && (GameObject.Random(this.Loyalty * (1 + (int)this.PersonalLoyalty)) <= GameObject.Random(5)))
                {
                    this.LeaveToNoFaction();
                }
                else if (((GlobalVariables.IdealTendencyValid && (this.IdealTendency != null)) && (this.IdealTendency.Offset <= 1)) && (this.BelongedFaction.Leader != null))
                {
                    int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                    if (idealOffset > this.IdealTendency.Offset)
                    {
                        GameObjectList list = new GameObjectList();
                        foreach (GameObjects.Faction faction in base.Scenario.Factions)
                        {
                            if (((faction != this.BelongedFaction) && (faction.Leader != null)) && (GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset))
                            {
                                list.Add(faction);
                            }
                        }
                        if (list.Count > 0)
                        {
                            GameObjects.Faction faction2 = list[GameObject.Random(list.Count)] as GameObjects.Faction;
                            if ((faction2.Capital != null) && ((((this.PersonalLoyalty < PersonLoyalty.很高) || ((this.Father >= 0) && (this.Father == faction2.Leader.ID))) || ((this.Brother >= 0) && (this.Brother == faction2.Leader.ID))) || (idealOffset > 10)))
                            {
                                this.LeaveToNoFaction();
                                this.MoveToArchitecture(faction2.Capital);
                                //this.LocationArchitecture.RemoveNoFactionPerson(this);
                            }
                        }
                    }
                }
            }
        }
        */

        public void LeaveFaction()
        {
            if (GameObject.Chance(20) && this.LocationArchitecture != null && this.Status == PersonStatus.Normal && this.BelongedFaction != null && this.BelongedFaction.Leader != this && !this.IsCaptive)
            {
                if ((this.Loyalty < 50) && (GameObject.Random(this.Loyalty * (1 + (int)this.PersonalLoyalty)) <= GameObject.Random(5)))
                {
                    this.LeaveToNoFaction();
                    ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                }
                /*else if (((GlobalVariables.IdealTendencyValid && (this.IdealTendency != null)) && (this.IdealTendency.Offset <= 1)) && (this.BelongedFaction.Leader != null))
                {
                    int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                    if (idealOffset > this.IdealTendency.Offset + (double) this.BelongedFaction.Reputation / this.BelongedFaction.MaxPossibleReputation * 75)
                    {
                        GameObjectList list = new GameObjectList();
                        foreach (GameObjects.Faction faction in base.Scenario.Factions)
                        {
                            if (((faction != this.BelongedFaction) && (faction.Leader != null)) && (GetIdealOffset(this, faction.Leader) <= this.IdealTendency.Offset)
                                && !this.HatedPersons.Contains(faction.LeaderID))
                            {
                                list.Add(faction);
                            }
                        }
                        if (list.Count > 0)
                        {
                            GameObjects.Faction faction2 = list[GameObject.Random(list.Count)] as GameObjects.Faction;
                            if ((faction2.Capital != null) && ((((this.PersonalLoyalty < (int) PersonLoyalty.很高) || ((this.Father >= 0) && (this.Father == faction2.Leader.ID))) || ((this.Brother >= 0) && (this.Brother == faction2.Leader.Brother))) || (idealOffset > 10)))
                            {
                                this.LeaveToNoFaction();
                                this.MoveToArchitecture(faction2.Capital);
								ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                                //this.LocationArchitecture.RemoveNoFactionPerson(this);
                                //base.Scenario.detectDuplication();
                            }
                        }
                    }
                }*/
                if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null) && this.Hates(this.BelongedFaction.Leader) && (GameObject.Random(this.Loyalty * (1 + (int)this.PersonalLoyalty)) <= GameObject.Random(5)))
                {
                    this.LeaveToNoFaction();
                    ArchitectureList allArch = base.Scenario.Architectures;
                    this.MoveToArchitecture(allArch[GameObject.Random(allArch.Count)] as Architecture);
                    ExtensionInterface.call("LeaveFaction", new Object[] { this.Scenario, this });
                }
            }
        }

        public void LeaveToNoFaction() // 下野
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            this.ProhibitedFactionID.Add(this.BelongedFaction.ID, 90);

            if (TargetArchitecture != null)
            {
                this.TargetArchitecture = null;
                this.ArrivingDays = 0;
                this.TaskDays = 0;
                this.OutsideTask = OutsideTaskKind.无;
            }
            base.Scenario.YearTable.addBecomeNoFactionEntry(base.Scenario.Date, this, this.BelongedFaction);
            this.Status = PersonStatus.NoFaction;
            if (this.OnLeave != null)
            {
                this.OnLeave(this, locationArchitecture);
            }
        }

        public void BeLeaveToNoFaction() // 流放
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            if (this.ProhibitedFactionID.ContainsKey(this.BelongedFaction.ID))
            {
                this.ProhibitedFactionID.Remove(this.BelongedFaction.ID);
            }
            this.ProhibitedFactionID.Add(this.BelongedFaction.ID, 360);
            this.Status = PersonStatus.NoFaction;
        }

        public void LoseTreasure(Treasure t)
        {
            this.Treasures.Remove(t);
            this.PurifyTreasure(t, false);
            t.BelongedPerson = null;
        }

        public void LoseTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Remove(treasure);
                this.PurifyTreasure(treasure, false);
                treasure.BelongedPerson = null;
            }
        }

        public bool WillLoseLoyalty
        {
            get
            {
                if (this.Loyalty > 110) return false;
                if (this.PersonalLoyalty >= 4) return false;
                return true;
            }
        }

        public bool WillLoseLoyaltyWhenHeldCaptive
        {
            get
            {
                if (this.BelongedCaptive.LocationArchitecture.captiveLoyaltyFall.Count > 0) return true;
                if (this.Loyalty > 110) return false;
                if (this.PersonalLoyalty >= 4) return false;
                return true;
            }
        }

        private void LoyaltyChange()
        {
            if (((this.BelongedFaction != null) && (((this.LocationArchitecture == null) || this.IsCaptive) || !this.LocationArchitecture.DayLocationLoyaltyNoChange))
                && (((this.LocationTroop == null) || this.IsCaptive) || !this.LocationTroop.LoyaltyNoChange)
                && GameObject.Chance(100 - this.personalLoyalty * 25)
                && (this.Loyalty <= 110) && GameObject.Chance(50))
            {
                int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                //亲爱武将性格差调整
                if (this.Closes(this.BelongedFaction.Leader) && (idealOffset > 5))
                {
                    idealOffset = 5;
                }

                if (idealOffset > 0)
                {

                    int decrement = (int)(this.Ambition - ((PersonAmbition)((int)this.PersonalLoyalty)) + idealOffset / 10);

                    if (!(!GlobalVariables.IdealTendencyValid || this.IsHirable(this.BelongedFaction)))
                    {
                        decrement += 2;
                    }
                    if (this.IsCaptive)
                    {
                        decrement *= 2;
                    }
                    if (decrement > 0 && !this.IsVeryCloseTo(this.BelongedFaction.Leader))
                    {
                        this.DecreaseLoyalty((int)Math.Sqrt(decrement));
                    }
                    else if (decrement < 0 && (this.Loyalty < 100))
                    {
                        this.IncreaseLoyalty((int)Math.Sqrt(Math.Abs(decrement)));
                    }
                }
            }
            if (this.IsCaptive && this.BelongedCaptive.LocationArchitecture != null)
            {
                foreach (KeyValuePair<int, int> pair in this.BelongedCaptive.LocationArchitecture.captiveLoyaltyFall)
                {
                    if (this.Loyalty < pair.Key)
                    {
                        this.Loyalty -= pair.Value;
                    }
                }
            }
        }

        private bool MeetAvailableCondition()
        {
            return ((((this.Alive && !this.Available) && (this.YearAvailable <= base.Scenario.Date.Year)) && ((((GlobalVariables.CommonPersonAvailable && (base.ID >= 0)) && (base.ID <= 6999)) || ((GlobalVariables.AdditionalPersonAvailable && (base.ID >= 8000)) && (base.ID <= 8999))) || ((GlobalVariables.PlayerPersonAvailable && (base.ID >= 9000))))) && !base.Scenario.PreparedAvailablePersons.HasGameObject(this));
        }

        public void AdjustIdealToFactionLeader(int diff)
        {
            if (this.BelongedFaction == null) return;
            if (diff == 0) return;

            if (diff > 75)
            {
                diff = 75;
            }

            int oldDiff = Person.GetIdealOffset(this, this.BelongedFaction.Leader);

            if (this.Ideal == this.BelongedFaction.Leader.Ideal)
            {
                if (diff < 0) return;
                this.Ideal += diff * (GameObject.Chance(50) ? 1 : -1);
            }
            else if (this.Ideal > this.BelongedFaction.Leader.Ideal)
            {
                if (this.Ideal < this.BelongedFaction.Leader.Ideal + 75)
                {
                    this.Ideal += Math.Min(oldDiff, diff);
                }
                else if (this.Ideal > this.BelongedFaction.Leader.Ideal + 75)
                {
                    this.Ideal -= Math.Min(oldDiff, diff);
                }
                else
                {
                    this.Ideal += diff * (GameObject.Chance(50) ? 1 : -1);
                }
            }
            else
            {
                if (this.Ideal > this.BelongedFaction.Leader.Ideal - 75)
                {
                    this.Ideal -= Math.Min(oldDiff, diff);
                }
                else if (this.Ideal < this.BelongedFaction.Leader.Ideal - 75)
                {
                    this.Ideal += Math.Min(oldDiff, diff);
                }
                else
                {
                    this.Ideal += diff * (GameObject.Chance(50) ? 1 : -1);
                }
            }

            this.Ideal = (this.Ideal + 150) % 150;
        }

        private void AdjustIdeal()
        {
            if (this.BelongedFaction != null)
            {
                if (this.Status == PersonStatus.Captive)
                {
                    if (GameObject.Chance((10 - this.Uncruelty) * 10))
                    {
                        this.AdjustIdealToFactionLeader(1);
                    }
                }
                else
                {
                    if (GameObject.Chance(this.IdealTendency.Offset / 4))
                    {
                        this.AdjustIdealToFactionLeader(-1);
                    }
                }

            }
        }

        public void MonthEvent()
        {
            if ((this.MonthIncrementOfTechniquePoint > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.MonthIncrementOfTechniquePoint);
            }
            if ((this.MonthIncrementOfFactionReputation > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseReputation(this.MonthIncrementOfFactionReputation);
            }
            this.AdjustIdeal();
        }

        public void resetPreferredWorkkind(bool[] need)
        {
            this.firstPreferred = ArchitectureWorkKind.无;
            int firstAbility = 0;
            int agricultureAbility = (need[0] ? this.AgricultureAbility : -2);
            int commerceAbility = (need[1] ? this.CommerceAbility : -2);
            int technologyAbility = (need[2] ? this.TechnologyAbility : -2);
            int dominationAbility = (need[3] ? this.DominationAbility : -2);
            int moraleAbility = (need[4] ? this.MoraleAbility : -2);
            int enduranceAbility = (need[5] ? this.EnduranceAbility : -2);
            int trainingAbility = (need[6] ? this.TrainingAbility : -2);

            if (agricultureAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.农业;
                firstAbility = agricultureAbility;
            }
            if (commerceAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.商业;
                firstAbility = commerceAbility;
            }
            if (technologyAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.技术;
                firstAbility = technologyAbility;
            }
            if (dominationAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.统治;
                firstAbility = dominationAbility;
            }
            if (moraleAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.民心;
                firstAbility = moraleAbility;
            }
            if (enduranceAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.耐久;
                firstAbility = enduranceAbility;
            }
            if (trainingAbility > firstAbility)
            {
                this.firstPreferred = ArchitectureWorkKind.训练;
                firstAbility = trainingAbility;
            }
        }

        /*
        public void MoveToArchitecture(Architecture a)
        {
            if (this.LocationArchitecture != a)
            {
                Point position = this.Position;
                Architecture targetArchitecture = this.TargetArchitecture;
                this.TargetArchitecture = a;
                if (this.LocationArchitecture != null)
                {
                    this.ArrivingDays = (int) Math.Ceiling((double) (base.Scenario.GetDistance(this.LocationArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                }
                else if (targetArchitecture != null)
                {
                    this.ArrivingDays += (int) Math.Ceiling((double) (base.Scenario.GetDistance(targetArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                    if ((((this.OutsideTask == OutsideTaskKind.情报) || (this.OutsideTask == OutsideTaskKind.搜索)) || (this.OutsideTask == OutsideTaskKind.技能)) || (this.OutsideTask == OutsideTaskKind.称号))
                    {
                        this.TaskDays = this.ArrivingDays;
                    }
                }
                else
                {
                    this.ArrivingDays = (int) Math.Ceiling((double) (base.Scenario.GetDistance(position, base.Scenario.GetClosestPoint(a.ArchitectureArea, position)) / 10.0));
                }
                if (this.ArrivingDays == 0)
                {
                    this.ArrivingDays = 1;
                }
            }
            else
            {
                this.TargetArchitecture = a;
                this.ArrivingDays = 1;
            }
            if (this.TargetArchitecture != null)
            {
                if (this.BelongedFaction != null)
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.RemovePerson(this);
                    }
                    this.TargetArchitecture.MovingPersons.Add(this);

                }
                else
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.RemoveNoFactionPerson(this);
                    }
                    this.TargetArchitecture.NoFactionMovingPersons.Add(this);
                }

            }
        }
        */

        public void MoveToArchitecture(Architecture a, Point? startingPoint)
        {
            Architecture targetArchitecture = this.TargetArchitecture;

            if (a == null) return;

            //if (this.Status != PersonStatus.Normal) return;

            if (this.LocationArchitecture != a || startingPoint != null)
            {
                Point position = this.Position;
                this.TargetArchitecture = a;
                if (startingPoint.HasValue)
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(startingPoint.Value, a.ArchitectureArea) / 10.0));
                }
                else if (this.LocationArchitecture != null)
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(this.LocationArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                }
                else if (targetArchitecture != null)
                {
                    this.ArrivingDays += (int)Math.Ceiling((double)(base.Scenario.GetDistance(targetArchitecture.ArchitectureArea, a.ArchitectureArea) / 10.0));
                    if ((((this.OutsideTask == OutsideTaskKind.情报) || (this.OutsideTask == OutsideTaskKind.搜索)) || (this.OutsideTask == OutsideTaskKind.技能)) || (this.OutsideTask == OutsideTaskKind.称号))
                    {
                        this.TaskDays = this.ArrivingDays;
                    }
                }
                else
                {
                    this.ArrivingDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, a.ArchitectureArea.Centre) / 10.0));
                }
                if (this.ArrivingDays == 0)
                {
                    this.ArrivingDays = 1;
                }
            }
            else
            {
                this.TargetArchitecture = a;
                this.ArrivingDays = 1;
            }
            if (this.TargetArchitecture != null)
            {

                this.LocationArchitecture = this.TargetArchitecture;

                if (this.Status != PersonStatus.Princess   && this.Status != PersonStatus.Captive)
                {
                    this.WorkKind = ArchitectureWorkKind.无;
                    if (this.BelongedFaction != null)
                    {
                        this.Status = PersonStatus.Moving;
                    }
                    else
                    {
                        this.Status = PersonStatus.NoFactionMoving;
                    }
                }
                else
                {
                   // throw new Exception("try to disappear");
                    this.Scenario.ClearPersonStatusCache();
                }

            }
        }

        public void GoToQuanXiangDiplomatic(DiplomaticRelationDisplay a) //劝降
        {
            if (a == null) return;

            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            bool isAI = !base.Scenario.IsPlayer(this.BelongedFaction);
            bool isPlayer = base.Scenario.IsPlayer (targetFaction);
            if (isAI && isPlayer ) return;
            //Architecture targetArchitecture = targetFaction.Leader.BelongedArchitecture;
            Architecture targetArchitecture = targetFaction.Capital;

            
            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.QuanXiang, "QuanXiangDiplomaticRelation", "TruceDiplomaticRelation.jpg", "TruceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;
                
                this.LocationArchitecture = this.BelongedArchitecture;
                this.WorkKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.劝降;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
             
               if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }
            }
        }



        public void GoToDiplomatic(DiplomaticRelationDisplay a)
        {
            if (a == null) return;

            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            //Architecture targetArchitecture = targetFaction.Leader.BelongedArchitecture;
            Architecture targetArchitecture = targetFaction.Capital;

            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.EnhanceDiplomaticRelation, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;

                this.LocationArchitecture = this.BelongedArchitecture;
                this.WorkKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.亲善;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }
            }
        }

        public void GoToTruceDiplomatic(DiplomaticRelationDisplay a)
        {
            if (a == null) return;

            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            Architecture targetArchitecture = targetFaction.Capital;

            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.Truce, "TruceDiplomaticRelation", "TruceDiplomaticRelation.jpg", "TruceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;

                this.LocationArchitecture = this.BelongedArchitecture;
                this.WorkKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.停战;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }

            }
        }

        public void GoToAllyDiplomatic(DiplomaticRelationDisplay a)
        {
            if (a == null) return;

            Faction targetFaction = this.BelongedFaction.GetFactionByName(a.FactionName);
            //Architecture targetArchitecture = targetFaction.Leader.BelongedArchitecture;
            Architecture targetArchitecture = targetFaction.Capital;

            if (targetArchitecture == null)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this, this.BelongedFaction.Leader.Name, TextMessageKind.EnhanceDiplomaticRelation, "EnhaneceDiplomaticRelation", "EnhaneceDiplomaticRelation.jpg", "EnhaneceDiplomaticRelation.wav", "啊，出错了!", true);
                return;
            }

            if (this.LocationArchitecture != targetArchitecture)
            {
                this.outsideDestination = targetArchitecture.Position;
                Point position = this.BelongedArchitecture.Position;
                this.TargetArchitecture = targetArchitecture;

                this.TaskDays = (int)Math.Ceiling((double)(base.Scenario.GetDistance(position, targetArchitecture.Position) / 10.0));
                if (this.taskDays == 0)
                {
                    this.taskDays = 1;
                }
                if (this.taskDays > 5)
                {
                    this.taskDays = 5;
                }

                this.arrivingDays = this.TaskDays * 2;

                this.LocationArchitecture = this.BelongedArchitecture;
                this.WorkKind = ArchitectureWorkKind.无;
                this.OutsideTask = OutsideTaskKind.结盟;
                this.Scenario.GameScreen.renwukaishitishi(this, this.TargetArchitecture);
                if (this.BelongedFaction != null)
                {
                    this.Status = PersonStatus.Moving;
                }
                else
                {
                    this.Status = PersonStatus.NoFactionMoving;
                }

            }
        }

        public void MoveToArchitecture(Architecture a)
        {
            this.MoveToArchitecture(a, null);
        }

        public void NoFactionMove()
        {
            if (this.BelongedFaction == null && this.ArrivingDays == 0 && this.LocationArchitecture != null && this.Status == PersonStatus.NoFaction 
                && !this.IsCaptive && GameObject.Chance((2 + (int)this.Ambition) + (this.LeaderPossibility ? 10 : 0)) && this.Status != PersonStatus.Princess
                )
            {
                if (GameObject.Chance(50 + (this.LeaderPossibility ? 10 : 0)))
                {
                    GameObjectList hirableFactionList = this.GetHirableFactionList();
                    if (hirableFactionList.Count > 0)
                    {
                        GameObjects.Faction faction = hirableFactionList[GameObject.Random(hirableFactionList.Count)] as GameObjects.Faction;
                        if (((faction.Leader != null) && (GetIdealOffset(faction.Leader, this) <= 10)) && ((faction.Capital != null) && (faction.Capital != this.LocationArchitecture)))
                        {
                            this.MoveToArchitecture(faction.Capital);
                            //this.LocationArchitecture.RemoveNoFactionPerson(this);
                        }
                    }
                    else if (this.LeaderPossibility)
                    {
                        GameObjectList list2 = new GameObjectList();
                        foreach (Architecture architecture in this.LocationArchitecture.GetClosestArchitectures(40, 80))
                        {
                            if ((architecture.BelongedFaction == null) && (architecture.RecentlyAttacked <= 0))
                            {
                                list2.Add(architecture);
                            }
                        }
                        if (list2.Count > 0)
                        {
                            if (list2.Count > 1)
                            {
                                list2.PropertyName = "UnitPopulation";
                                list2.IsNumber = true;
                                list2.ReSort();
                            }
                            Architecture a = list2[GameObject.Random(list2.Count / 2)] as Architecture;
                            this.MoveToArchitecture(a);
                            //this.LocationArchitecture.RemoveNoFactionPerson(this);
                        }
                    }
                }
                else
                {
                    if (this.LocationArchitecture.ClosestArchitectures == null)
                    {
                        this.LocationArchitecture.GetClosestArchitectures();
                    }
                    if (this.LocationArchitecture.ClosestArchitectures.Count > 0)
                    {
                        int maxValue = 20;
                        if (maxValue > this.LocationArchitecture.ClosestArchitectures.Count)
                        {
                            maxValue = this.LocationArchitecture.ClosestArchitectures.Count;
                        }
                        maxValue = GameObject.Random(maxValue);
                        this.MoveToArchitecture(this.LocationArchitecture.ClosestArchitectures[maxValue] as Architecture);
                        //this.LocationArchitecture.RemoveNoFactionPerson(this);
                    }
                }
            }
        }

        public void PreDayEvent()
        {
            this.SetDayInfluence();
        }

        private void ProgressArrivingDays()
        {
            this.LastOutsideTask = this.outsideTask;
            if (this.TaskDays > 0)
            {
                this.TaskDays--;
                if ((this.TaskDays == 0) && (this.OutsideTask != OutsideTaskKind.无))
                {
                    if (this.BelongedFaction != null)
                    {
                        this.DoOutsideTask();
                    }
                    else
                    {
                        this.Status = PersonStatus.NoFaction;
                        this.TargetArchitecture = null;
                    }
                }
            }
            if (this.ArrivingDays > 0)
            {
                this.ArrivingDays--;
                if ((this.ArrivingDays == 0) && (this.TargetArchitecture != null) && this.Status != PersonStatus.Princess)
                {
                    this.ReturnedDaySince = 0;
                    if (this.BelongedFaction != null)
                    {
                        if (this.TargetArchitecture.BelongedFaction == this.BelongedFaction)
                        {
                            this.Status = PersonStatus.Normal;
                            if (this.Scenario.IsCurrentPlayer(this.BelongedFaction) && this.TargetArchitecture.TodayPersonArriveNote == false
                                && this.TargetArchitecture.BelongedSection != null && this.TargetArchitecture.BelongedSection.AIDetail.ID == 0)
                            {
                                this.TargetArchitecture.TodayPersonArriveNote = true;
                                this.Scenario.GameScreen.renwudaodatishi(this, this.TargetArchitecture);
                            }
                            this.TargetArchitecture = null;
                        }
                        else if (this.TargetArchitecture.BelongedFaction != this.BelongedFaction && this.Status == PersonStatus .Captive) //转移俘虏
                        {
                            
                            this.TargetArchitecture.TodayPersonArriveNote = true;
                            this.TargetArchitecture = null;
                        }
                        else if (this.BelongedFaction.Capital != null)
                        {
                            this.MoveToArchitecture(this.BelongedFaction.Capital);
                        }
                        else   //这种情况在现在的程序中应该不会出现。
                        {
                            this.Status = PersonStatus.NoFaction;
                            this.TargetArchitecture = null;
                        }

                    }
                    else if (this.BelongedFaction == null && this.Status == PersonStatus.Captive) //转移俘虏
                    {
                        
                        this.TargetArchitecture.TodayPersonArriveNote = true;
                        this.TargetArchitecture = null;
                    }
                    else
                    {
                        this.Status = PersonStatus.NoFaction;
                        this.Scenario.GameScreen.NoFactionPersonArrivesAtArchitecture(this, this.TargetArchitecture);
                        this.TargetArchitecture = null;
                    }
                    ExtensionInterface.call("ArrivedAtArchitecture", new Object[] { this.Scenario, this, this.TargetArchitecture });
                }
            }
        }

        public void ReceiveTreasure(Treasure t)
        {
            this.Treasures.Add(t);
            t.BelongedPerson = this;
            ApplyTreasure(t, false);
        }

        public void ReceiveTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Add(treasure);
                treasure.BelongedPerson = this;
                ApplyTreasure(treasure, false);
            }
        }

        public void SeasonEvent()
        {
        }

        private void SetDayInfluence()
        {
            this.RewardFinished = false;
            if (this.Status == PersonStatus.Normal)
            {
                if (((this.DayRateIncrementOfInternal > 0f) && ((this.BelongedFaction != null) && (this.LocationArchitecture != null))) && (this.LocationArchitecture.DayRateIncrementOfInternal < this.DayRateIncrementOfInternal))
                {
                    this.LocationArchitecture.DayRateIncrementOfInternal = this.DayRateIncrementOfInternal;
                }
                if ((this.LocationArchitecture != null) && (this.DayLearnTitleDay < this.LocationArchitecture.DayLearnTitleDay))
                {
                    this.LocationArchitecture.DayLearnTitleDay = this.DayLearnTitleDay;
                }
                if (this.DayLocationLoyaltyNoChange && (this.BelongedFaction != null))
                {
                    if (this.LocationArchitecture != null)
                    {
                        this.LocationArchitecture.DayLocationLoyaltyNoChange = true;
                    }
                    if (this.LocationTroop != null)
                    {
                        this.LocationTroop.LoyaltyNoChange = true;
                    }
                }
                if ((this.DayAvoidInfluenceByBattle && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidInfluenceByBattle = true;
                }
                if ((this.DayAvoidPopulationEscape && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidPopulationEscape = true;
                }
                if ((this.DayAvoidInternalDecrementOnBattle && (this.BelongedFaction != null)) && (this.LocationArchitecture != null))
                {
                    this.LocationArchitecture.DayAvoidInternalDecrementOnBattle = true;
                }
            }
        }
        /*
        public void ShowPersonMessage(PersonMessage personMessage)
        {
            bool flag = true;
            if ((this.BelongedFaction != null) && (personMessage is SpyMessage))
            {
                SpyMessage sm = personMessage as SpyMessage;
                Point key = new Point(sm.MessageArchitecture.ID, (int)sm.Kind);
                if (!this.BelongedFaction.SpyMessageCloseList.ContainsKey(key))
                {
                    this.HandleSpyMessage(sm);
                    this.BelongedFaction.SpyMessageCloseList.Add(key, null);
                }
                else
                {
                    flag = false;
                }
            }
            if (flag && (this.OnShowMessage != null))
            {
                this.OnShowMessage(this, personMessage);
            }
        }
        */
         
        public override string ToString()
        {
            return (this.NormalName + " 势力：" + this.Faction + " 所在：" + this.Location);
        }

        public void TryToBeAvailable()
        {
            if (GameObject.Chance(10) && this.MeetAvailableCondition())
            {
                this.BeAvailable();
            }
        }

        public void YearEvent()
        {
        }

        public int Age
        {
            get
            {
                if (GlobalVariables.PersonNaturalDeath)
                {
                    return base.Scenario.Date.Year - this.yearBorn;
                }
                else
                {
                    return 30;
                }
            }
        }

        public string DisplayedAge
        {
            get
            {
                return GlobalVariables.PersonNaturalDeath ? (base.Scenario.Date.Year - this.yearBorn).ToString() : "--";
            }
        }

        public int AgricultureAbility
        {
            get
            {
                if (agricultureAbility > 0) return agricultureAbility;
                agricultureAbility = (int)((this.BaseAgricultureAbility + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
                return agricultureAbility;
            }
        }

        public int zhenzaiAbility
        {
            get
            {
                return this.Intelligence + 2 * this.Politics;
            }
        }

        public int AgricultureWeighing
        {
            get
            {
                return ((this.AgricultureAbility * (this.MultipleOfAgricultureReputation + this.MultipleOfAgricultureTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public bool Alive
        {
            get
            {
                return this.alive;
            }
            set
            {
                this.alive = value;
            }
        }

        public int AllSkillMerit
        {
            get
            {
                int num = 0;
                foreach (Skill skill in this.Skills.Skills.Values)
                {
                    num += 5 * skill.Level;
                }
                return num;
            }
        }

        public int Ambition
        {
            get
            {
                return this.ambition;
            }
            set
            {
                this.ambition = value;
            }
        }

        public int ArrivingDays
        {
            get
            {
                return this.arrivingDays;
            }
            set
            {
                this.arrivingDays = value;
            }
        }

        public int AssassinateAbility
        {
            get
            {
                return this.Strength * 2 + this.Intelligence * 2 + this.Calmness * 20 + this.Braveness * 20;
            }
        }

        public bool Available
        {
            get
            {
                return this.available;
            }
            set
            {
                this.available = value;
            }
        }

        public int AvailableLocation
        {
            get
            {
                return this.availableLocation;
            }
            set
            {
                this.availableLocation = value;
            }
        }

        // precomputed values of y = 1.12 / (1+ 69.06e^(-0.428x))
        private static readonly float[] AGE_FACTORS = { 0.0160f, 0.0243f, 0.0369f, 0.0557f, 0.0832f, 0.1227f, 0.1779f, 0.2516f, 0.3446f, 0.4541f, 0.5726f, 0.6900f, 0.7965f, 0.8856f, 0.9552f };
        private float AbilityAgeFactor
        {
            get
            {
                if (!GlobalVariables.EnableAgeAbilityFactor) return 1;
                if (!this.Alive) return 1;

                float factor = 1;
                if (this.Age < 0)
                {
                    factor = AGE_FACTORS[0];
                }
                else if (this.Age < 15)
                {
                    factor = AGE_FACTORS[this.Age];
                }
                else if (this.Age > 60)
                {
                    factor = Math.Max(0.2f, -0.016f * this.Age + 1.96f);
                }

                return factor;
            }
        }

        private float huaiyunAbilityFactor
        {
            get
            {
                if (this.huaiyun)
                {
                    return Math.Min(1, (360 - this.huaiyuntianshu) / 180.0f);
                }

                return 1;
            }
        }

        private int BaseAgricultureAbility
        {
            get
            {
                return (2 * (this.Politics + this.Glamour));
            }
        }

        public int BaseCommand
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }

        private int BaseCommerceAbility
        {
            get
            {
                return ((this.Intelligence + (2 * this.Politics)) + this.Glamour);
            }
        }

        private int BaseDominationAbility
        {
            get
            {
                return (((2 * this.Strength) + this.Command) + this.Glamour);
            }
        }

        private int BaseEnduranceAbility
        {
            get
            {
                return (((this.Strength + this.Command) + this.Intelligence) + this.Politics);
            }
        }

        public int BaseGlamour
        {
            get
            {
                return this.glamour;
            }
            set
            {
                this.glamour = value;
            }
        }

        public float BaseImpactRate
        {
            get
            {
                return this.baseImpactRate;
            }
            set
            {
                this.baseImpactRate = value;
            }
        }

        public int BaseIntelligence
        {
            get
            {
                return this.intelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        private int BaseMoraleAbility
        {
            get
            {
                return ((this.Command + this.Politics) + (2 * this.Glamour));
            }
        }

        public int BasePolitics
        {
            get
            {
                return this.politics;
            }
            set
            {
                this.politics = value;
            }
        }

        private int BaseRecruitmentAbility
        {
            get
            {
                return ((2 * this.Command) + (2 * this.Glamour));
            }
        }

        public int BaseStrength
        {
            get
            {
                return this.strength;
            }
            set
            {
                this.strength = value;
            }
        }

        private int BaseTechnologyAbility
        {
            get
            {
                return (2 * (this.Intelligence + this.Politics));
            }
        }

        private int BaseTrainingAbility
        {
            get
            {
                return ((2 * this.Strength) + (2 * this.Command));
            }
        }

        public PersonBornRegion BornRegion
        {
            get
            {
                return this.bornRegion;
            }
            set
            {
                this.bornRegion = value;
            }
        }

        public int BaseBraveness
        {
            get
            {
                return this.braveness;
            }
        }

        public int Braveness
        {
            get
            {
                return (int)((this.braveness + this.bravenessIncrease) * this.AbilityAgeFactor * this.InjureRate);
            }
            set
            {
                this.braveness = value;
            }
        }

        public PersonList Brothers
        {
            get
            {
                return this.brothers;
            }
            set
            {
                this.brothers = value;
            }
        }

        public String BrotherName
        {
            get
            {
                String s = "";
                foreach (Person p in this.Brothers)
                {
                    s += p.Name + " ";
                }
                return s;
            }
        }

        public int BubingExperience
        {
            get
            {
                return (int)(this.bubingExperience);
            }
            set
            {
                this.bubingExperience = value;
            }
        }

        public string CalledName
        {
            get
            {
                return this.calledName;
            }
            set
            {
                this.calledName = value;
            }
        }

        public int BaseCalmness
        {
            get
            {
                return this.calmness;
            }
        }

        public int Calmness
        {
            get
            {
                return (int)((this.calmness + this.calmnessIncrease) * this.AbilityAgeFactor * this.InjureRate);
            }
            set
            {
                this.calmness = value;
            }
        }

        public int CaptiveAbility
        {
            get
            {
                return (((this.Strength * 3) + (this.Intelligence * 3)) + ((this.Braveness + this.Calmness) * 20));
            }
        }

        public string CharacterString
        {
            get
            {
                return this.Character.Name;
            }
        }

        public string CloseName
        {
            get
            {
                if ((this.calledName != null) && (this.calledName != ""))
                {
                    return this.calledName;
                }
                return this.NormalName;
            }
        }

        public int MilitaryTypeSkillMerit(MilitaryType kind)
        {
            int result = 0;
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                if (skill.Combat && (skill.MilitaryTypeOnly == kind || skill.MilitaryTypeOnly == MilitaryType.其他))
                {
                    result += 5 * skill.Level;
                }
            }
            return result;
        }

        public int MilitaryTypeStuntMerit(MilitaryType kind)
        {
            int result = 0;
            foreach (Stunt stunt in this.Stunts.Stunts.Values)
            {
                if ((stunt.MilitaryTypeOnly == kind || stunt.MilitaryTypeOnly == MilitaryType.其他))
                {
                    result += 30;
                }
            }
            return result;
        }

        public bool HasMilitaryKindTitle(MilitaryKind kind)
        {
            foreach (Title t in this.Titles)
            {
                if (t.MilitaryKindOnly == kind.ID)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMilitaryTypeTitle(MilitaryType kind)
        {
            foreach (Title t in this.Titles)
            {
                if (t.MilitaryTypeOnly == kind || t.MilitaryTypeOnly == MilitaryType.其他)
                {
                    return true;
                }
            }
            return false;
        }

        public int CombatSkillMerit
        {
            get
            {
                int num = 0;
                foreach (Skill skill in this.Skills.Skills.Values)
                {
                    if (skill.Combat)
                    {
                        num += skill.Merit;
                    }
                }
                return num;
            }
        }

        public int SubOfficerSkillMerit
        {
            get
            {
                int num = 0;
                foreach (Skill skill in this.Skills.Skills.Values)
                {
                    if (skill.Combat)
                    {
                        num += skill.SubOfficerMerit;
                    }
                }
                return num;
            }
        }

        public int Command
        {
            get
            {
                return this.NormalCommand;
            }
            set
            {
                this.command = value;
            }
        }

        public int CommandExperience
        {
            get
            {
                return (int)(this.commandExperience);
            }
            set
            {
                this.commandExperience = value;
            }
        }

        public int CommandFromExperience
        {
            get
            {
                return (this.CommandExperience / 0x3e8);
            }
        }

        public int CommandIncludingExperience
        {
            get
            {
                return (this.BaseCommand + this.CommandFromExperience);
            }
        }

        public int CommerceAbility
        {
            get
            {
                if (commerceAbility > 0) return commerceAbility;
                commerceAbility = (int)((this.BaseCommerceAbility + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
                return commerceAbility;
            }
        }

        public int CommerceWeighing
        {
            get
            {
                return ((this.CommerceAbility * (this.MultipleOfCommerceReputation + this.MultipleOfCommerceTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int ControversyAbility
        {
            get
            {
                return (this.Intelligence + this.Glamour);
            }
        }

        public int ConvinceAbility
        {
            get
            {
                return (int)((this.Glamour * 4) * (1f + this.RateIncrementOfConvince));
            }
        }

        public InformationKind CurrentInformationKind
        {
            get
            {
                if (this.currentInformationKind == null)
                {
                    this.currentInformationKind = base.Scenario.GameCommonData.AllInformationKinds.GetGameObject(this.informationKindID) as InformationKind;
                }
                return this.currentInformationKind;
            }
            set
            {
                this.currentInformationKind = value;
                if (value != null)
                {
                    this.informationKindID = value.ID;
                }
                else
                {
                    this.informationKindID = -1;
                }
            }
        }

        public PersonDeadReason DeadReason
        {
            get
            {
                return this.deadReason;
            }
            set
            {
                this.deadReason = value;
            }
        }

        public int DestroyAbility
        {
            get
            {
                return (int)(((this.Strength + this.Command) + (this.Intelligence * 2)) * (1f + this.RateIncrementOfDestroy));
            }
        }

        public int DominationAbility
        {
            get
            {
                if (dominationAbility > 0) return dominationAbility;
                dominationAbility = (int)((this.BaseDominationAbility + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
                return dominationAbility;
            }
        }

        public int DominationWeighing
        {
            get
            {
                return ((this.DominationAbility * (this.MultipleOfDominationReputation + this.MultipleOfDominationTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int EnduranceAbility
        {
            get
            {
                if (enduranceAbility > 0) return enduranceAbility;
                enduranceAbility = (int)((this.BaseEnduranceAbility + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
                return enduranceAbility;
            }
        }

        public int EnduranceWeighing
        {
            get
            {
                return ((this.EnduranceAbility * (this.MultipleOfEnduranceReputation + this.MultipleOfEnduranceTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public string Faction
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return this.BelongedFaction.Name;
                }
                return "----";
            }
        }

        public Person Father
        {
            get
            {
                return this.father;
            }
            set
            {
                this.father = value;
            }
        }

        public int TitleMerit
        {
            get
            {
                int result = 0;
                foreach (Title t in this.Titles)
                {
                    result += t.Merit;
                }
                return result;
            }
        }

        public int TitleFightingMerit
        {
            get
            {
                int result = 0;
                foreach (Title t in this.Titles)
                {
                    result += t.FightingMerit;
                }
                return result;
            }
        }

        public int TitleSubofficerMerit
        {
            get
            {
                int result = 0;
                foreach (Title t in this.Titles)
                {
                    result += t.SubOfficerMerit;
                }
                return result;
            }
        }

        public int TitleInheritableMerit
        {
            get
            {
                int result = 0;
                foreach (Title t in this.Titles)
                {
                    if (t.Kind.IsInheritable(base.Scenario.GameCommonData.AllTitles))
                    {
                        result += t.Merit;
                    }
                }
                return result;
            }
        }

        public int FightingForce
        {
            get
            {
                return (int)((this.Character.IntelligenceRate * (this.Strength * (1 - GlobalVariables.LeadershipOffenceRate) + this.Command * (GlobalVariables.LeadershipOffenceRate + 1))
                    + (1 - this.Character.IntelligenceRate) * this.Intelligence * 0.5) *
                    (100 + this.TitleFightingMerit
                    + this.TreasureMerit + this.CombatSkillMerit + Math.Sqrt(this.StuntCount) * 30));
            }
        }

        public int SubFightingForce
        {
            get
            {
                return (int)((this.Strength * 0.25 + this.Command * 0.25 + this.Intelligence * 2.5) *
                    (100 + this.TitleSubofficerMerit
                    + this.TreasureMerit + this.SubOfficerSkillMerit));
            }
        }

        public int FightingNumber
        {
            get
            {
                return (((this.Strength * 2) + (this.Command * 2)) + this.Intelligence);
            }
        }

        public PersonForm Form
        {
            get
            {
                return this.form;
            }
            set
            {
                this.form = value;
            }
        }

        public float FormRate
        {
            get
            {
                switch (this.form)
                {
                    case PersonForm.好:
                        return (1f + this.ImpactRateOfGoodForm);

                    case PersonForm.中:
                        return 1f;

                    case PersonForm.差:
                        return (1f - this.ImpactRateOfBadForm);
                }
                return 1f;
            }
        }

        public int Generation
        {
            get
            {
                return this.generation;
            }
            set
            {
                this.generation = value;
            }
        }

        public string GivenName
        {
            get
            {
                return this.givenName;
            }
            set
            {
                this.givenName = value;
            }
        }

        public int Glamour
        {
            get
            {
                return this.NormalGlamour;
            }
            set
            {
                this.glamour = value;
            }
        }

        public int GlamourExperience
        {
            get
            {
                return (int)(this.glamourExperience);
            }
            set
            {
                this.glamourExperience = value;
            }
        }

        public int GlamourFromExperience
        {
            get
            {
                return (this.GlamourExperience / 0x3e8);
            }
        }

        public int GlamourIncludingExperience
        {
            get
            {
                return (this.BaseGlamour + this.GlamourFromExperience);
            }
        }

        public int GossipAbility
        {
            get
            {
                return (int)(((this.Politics * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfGossip));
            }
        }

        public int JailBreakAbility
        {
            get
            {
                return (int)(this.CaptiveAbility * (1f + this.RateIncrementOfJailBreakAbility));
            }
        }

        public bool HasLeaderValidTitle
        {
            get
            {
                foreach (Title t in this.Titles)
                {
                    if (t.Influences.HasTroopLeaderValidInfluence)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /*
        public bool HasGuanzhi()
        {
            return this.Guanzhis.Count > 0;
        }
        */

        public bool HasTitle()
        {
           /* if (this.Titles.Count > 0)
            {
                return true;
            }
            return false;
            */
            return this.Titles != null;
        }

        public bool HasSkill(int id)
        {
            return this.Skills.GetSkill(id) != null;
        }

        public bool HasStunt(int id)
        {
            return this.Stunts.GetStunt(id) != null;
        }

        public String TitleName(int kind)
        {
            foreach (Title t in this.Titles)
            {
                if (t.Kind.ID == kind)
                {
                    return t.Level + "级「" + t.Name + "」";
                }
            }
            return "";
        }
        /*
        public String GuanzhiName(int kind)
        {
            foreach (Guanzhi g in this.Guanzhis)
            {
                if (g.Kind.ID == kind)
                {
                    return g.Level + "级「" + g.Name + "」";
                }
            }
            return "";
        }
        */

        public String StuntList
        {
            get
            {
                String result = "";
                foreach (Stunt s in this.Stunts.Stunts.Values)
                {
                    result += s.Name + " ";
                }
                return result;
            }
        }

        public String StudyableSkillList
        {
            get
            {
                String result = this.GetStudySkillList().Count + "个：";
                foreach (Skill s in this.StudySkillList)
                {
                    result += s.Name + "、";
                }
                return result;
            }
        }

        public String StudyableStuntList
        {
            get
            {
                String result = this.GetStudyStuntList().Count + "个：";
                foreach (Stunt s in this.StudyStuntList)
                {
                    result += s.Name + "、 ";
                }
                return result;
            }
        }

        public bool HasLearnableSkill
        {
            get
            {
                if (base.Scenario.GameCommonData.AllSkills.Count > this.SkillCount)
                {
                    foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
                    {
                        if ((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool HasLearnableStunt
        {
            get
            {
                if (base.Scenario.GameCommonData.AllStunts.Count > this.StuntCount)
                {
                    foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.Stunts.Values)
                    {
                        if ((this.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(this))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public bool HasLearnableTitle
        {
            get
            {
                return this.StudyableTitleCount > 0;
            }
        }

        private List<Title> higherLevelLearnableTitle = null;
        public List<Title> HigherLevelLearnableTitle
        {
            get
            {
                if (higherLevelLearnableTitle != null)
                {
                    return higherLevelLearnableTitle;
                }
                List<Title> title = new List<Title>();
                foreach (Title candidate in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    HashSet<TitleKind> hasKind = new HashSet<TitleKind>();
                    foreach (Title t in this.Titles)
                    {
                        if (t.Kind == candidate.Kind && candidate.Level > t.Level && candidate.CanLearn(this))
                        {
                            title.Add(candidate);
                        }
                        hasKind.Add(t.Kind);
                    }
                    if (!hasKind.Contains(candidate.Kind) && candidate.CanLearn(this))
                    {
                        title.Add(candidate);
                    }
                }
                higherLevelLearnableTitle = title;
                return title;
            }
        }

        public int Ideal
        {
            get
            {
                return this.ideal;
            }
            set
            {
                this.ideal = value;
            }
        }

        public string IdealTendencyString
        {
            get
            {
                return ((this.IdealTendency != null) ? this.IdealTendency.Name : "----");
            }
        }

        public float ImpactRateOfBadForm
        {
            get
            {
                return (this.impactRateOfBadForm + (this.BaseImpactRate * this.InfluenceRateOfBadForm));
            }
            set
            {
                this.impactRateOfGoodForm = value;
            }
        }

        public float ImpactRateOfGoodForm
        {
            get
            {
                return (this.impactRateOfGoodForm + (this.BaseImpactRate * this.InfluenceRateOfGoodForm));
            }
            set
            {
                this.impactRateOfGoodForm = value;
            }
        }

        public int InformationAbility
        {
            get
            {
                //return this.RadiusIncrementOfInformation;
                return ((this.Intelligence * 2) + this.Glamour);

            }
        }

        public int InformationKindID
        {
            get
            {
                return this.informationKindID;
            }
            set
            {
                this.informationKindID = value;
            }
        }

        public int InstigateAbility
        {
            get
            {
                return (int)(((this.Intelligence * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfInstigate));
            }
        }

        public int Intelligence
        {
            get
            {
                return this.NormalIntelligence;
            }
            set
            {
                this.intelligence = value;
            }
        }

        public int IntelligenceExperience
        {
            get
            {
                return (int)(this.intelligenceExperience);
            }
            set
            {
                this.intelligenceExperience = value;
            }
        }

        public int IntelligenceFromExperience
        {
            get
            {
                return (this.IntelligenceExperience / 0x3e8);
            }
        }

        public int IntelligenceIncludingExperience
        {
            get
            {
                return (this.BaseIntelligence + this.IntelligenceFromExperience);
            }
        }

        public int InternalExperience
        {
            get
            {
                return (int)(this.internalExperience);
            }
            set
            {
                this.internalExperience = value;
            }
        }

        public bool IsCaptive
        {
            get
            {
                return (this.BelongedCaptive != null);
            }
        }

        public bool LeaderPossibility
        {
            get
            {
                return this.leaderPossibility;
            }
            set
            {
                this.leaderPossibility = value;
            }
        }

        public string Location
        {
            get
            {
                if (this.IsCaptive)
                {
                    return "俘虏";
                }
                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.Name;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture.Name;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.DisplayName;
                }
                return "----";
            }
        }

        public int Loyalty
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    if (this == this.BelongedFaction.Leader) return 255;
                    return this.loyalty + this.InfluenceIncrementOfLoyalty;
                }
                return 0;
            }
            set
            {
                this.loyalty = value;
                if (this.loyalty < 0)
                {
                    this.loyalty = 0;
                }
            }
        }

        public int Merit
        {
            get
            {
                return (int)((this.Strength + this.Command + this.Intelligence + this.Politics + this.Glamour) *
                    (100 + this.TitleMerit + this.AllSkillMerit + this.TreasureMerit + Math.Sqrt(this.StuntCount) * 30));
            }
        }

        public int UntiredMerit
        {
            get
            {
                if (this.BelongedFaction != null && this == this.BelongedFaction.Prince) //储君身价公式
                {
                    return ((this.UntiredStrength + this.UntiredCommand + this.UntiredIntelligence + this.UntiredPolitics + this.UntiredGlamour) *
                    (100 + this.TitleInheritableMerit + this.AllSkillMerit)) * 2;
                }
                else
                {

                    return (this.UntiredStrength + this.UntiredCommand + this.UntiredIntelligence + this.UntiredPolitics + this.UntiredGlamour) *
                        (100 + this.TitleInheritableMerit + this.AllSkillMerit);
                }
            }
        }

        public int MoraleAbility
        {
            get
            {
                if (moraleAbility > 0) return moraleAbility;
                moraleAbility = (int)((this.BaseMoraleAbility + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
                return moraleAbility;
            }
        }

        public int MoraleWeighing
        {
            get
            {
                return ((this.MoraleAbility * (this.MultipleOfMoraleReputation + this.MultipleOfMoraleTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public Person Mother
        {
            get
            {
                return this.mother;
            }
            set
            {
                this.mother = value;
            }
        }

        public string Name
        {
            get
            {
                return this.NormalName;
            }
        }

        public int NonFightingNumber
        {
            get
            {
                return ((this.Intelligence + (this.Politics * 2)) + (this.Glamour * 2));
            }
        }

        public int NormalAgricultureAbility
        {
            get
            {
                return (int)(((2 * (this.NormalPolitics + this.NormalGlamour)) + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
            }
        }

        public int NormalCommand
        {
            get
            {
                return (int)(Math.Min((int)((this.CommandIncludingExperience + this.InfluenceIncrementOfCommand) * this.InfluenceRateOfCommand), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.RelationAbilityFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }

        public int UntiredCommand
        {
            get
            {
                return (int)(Math.Min((int)((this.CommandIncludingExperience + this.InfluenceIncrementOfCommand) * this.InfluenceRateOfCommand), GlobalVariables.MaxAbility) * this.AbilityAgeFactor);
            }
        }

        public int NormalCommerceAbility
        {
            get
            {
                return (int)((((this.NormalIntelligence + (2 * this.NormalPolitics)) + this.NormalGlamour) + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
            }
        }

        public int NormalDominationAbility
        {
            get
            {
                return (int)(((((2 * this.NormalStrength) + this.NormalCommand) + this.NormalGlamour) + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
            }
        }

        public int NormalEnduranceAbility
        {
            get
            {
                return (int)(((((this.NormalStrength + this.NormalCommand) + this.NormalIntelligence) + this.NormalPolitics) + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
            }
        }

        public int NormalGlamour
        {
            get
            {
                return (int)(Math.Min((int)((this.GlamourIncludingExperience + this.InfluenceIncrementOfGlamour) * this.InfluenceRateOfGlamour), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.RelationAbilityFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }

        public int UntiredGlamour
        {
            get
            {
                return (int)(Math.Min((int)((this.GlamourIncludingExperience + this.InfluenceIncrementOfGlamour) * this.InfluenceRateOfGlamour), GlobalVariables.MaxAbility) * this.AbilityAgeFactor);
            }
        }

        public int NormalIntelligence
        {
            get
            {
                return (int)(Math.Min((int)((this.IntelligenceIncludingExperience + this.InfluenceIncrementOfIntelligence) * this.InfluenceRateOfIntelligence), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.RelationAbilityFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }

        public int UntiredIntelligence
        {
            get
            {
                return (int)(Math.Min((int)((this.IntelligenceIncludingExperience + this.InfluenceIncrementOfIntelligence) * this.InfluenceRateOfIntelligence), GlobalVariables.MaxAbility) * this.AbilityAgeFactor);
            }
        }

        public int NormalMoraleAbility
        {
            get
            {
                return (int)((((this.NormalCommand + this.NormalPolitics) + (2 * this.NormalGlamour)) + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
            }
        }

        public string NormalName
        {
            get
            {
                return (this.surName + this.givenName);
            }
        }

        public int NormalPolitics
        {
            get
            {
                return (int)(Math.Min((int)((this.PoliticsIncludingExperience + this.InfluenceIncrementOfPolitics) * this.InfluenceRateOfPolitics), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.RelationAbilityFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }

        public int UntiredPolitics
        {
            get
            {
                return (int)(Math.Min((int)((this.PoliticsIncludingExperience + this.InfluenceIncrementOfPolitics) * this.InfluenceRateOfPolitics), GlobalVariables.MaxAbility) * this.AbilityAgeFactor);
            }
        }

        public int NormalRecruitmentAbility
        {
            get
            {
                return (int)((((2 * this.NormalCommand) + (2 * this.NormalGlamour)) + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public int NormalStrength
        {
            get
            {
                return (int)(Math.Min((int)((this.StrengthIncludingExperience + this.InfluenceIncrementOfStrength) * this.InfluenceRateOfStrength), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.RelationAbilityFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }

        //[Breamask]单挑用的武力数值，不含有义兄弟加成RelationAbilityFactor
        public int ChallengeStrength
        {
            get
            {
                return (int)(Math.Min((int)((this.StrengthIncludingExperience + this.InfluenceIncrementOfStrength) * this.InfluenceRateOfStrength), GlobalVariables.MaxAbility) * this.TirednessFactor * this.AbilityAgeFactor * this.huaiyunAbilityFactor * this.InjureRate);
            }
        }


        public int UntiredStrength
        {
            get
            {
                return (int)(Math.Min((int)((this.StrengthIncludingExperience + this.InfluenceIncrementOfStrength) * this.InfluenceRateOfStrength), GlobalVariables.MaxAbility) * this.AbilityAgeFactor);
            }
        }

        public int NormalTechnologyAbility
        {
            get
            {
                return (int)(((2 * (this.NormalIntelligence + this.NormalPolitics)) + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
            }
        }

        public int NormalTrainingAbility
        {
            get
            {
                return (int)((((2 * this.NormalStrength) + (2 * this.NormalCommand)) + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
            }
        }

        public int NubingExperience
        {
            get
            {
                return (int)(this.nubingExperience);
            }
            set
            {
                this.nubingExperience = value;
            }
        }

        public List<int> JoinFactionID
        {
            get
            {
                return this.joinFactionID;
            }
            set
            {
                this.joinFactionID = value;
            }
        }

        public Dictionary<int, int> ProhibitedFactionID
        {
            get
            {
                return prohibitedFactionID;
            }
            set
            {
                prohibitedFactionID = value;
            }
        }

        public Point? OutsideDestination
        {
            get
            {
                return this.outsideDestination;
            }
            set
            {
                this.outsideDestination = value;
            }
        }

        public OutsideTaskKind OutsideTask
        {
            get
            {
                return this.outsideTask;
            }
            set
            {
                this.outsideTask = value;
            }
        }

        public string OutsideTaskDaysString
        {
            get
            {
                if (this.TaskDays > 0)
                {
                    return (this.TaskDays.ToString() + "天");
                }
                return "----";
            }
        }

        public string OutsideTaskString
        {
            get
            {
                if (this.outsideTask != OutsideTaskKind.无)
                {
                    return this.outsideTask.ToString();
                }
                return "----";
            }
        }

        public int PersonalLoyalty
        {
            get
            {
                return this.personalLoyalty;
            }
            set
            {
                this.personalLoyalty = value;
            }
        }

        public int PictureIndex
        {
            get
            {
                return this.pictureIndex;
            }
            set
            {
                this.pictureIndex = value;
            }
        }

        public int Politics
        {
            get
            {
                return this.NormalPolitics;
            }
            set
            {
                this.politics = value;
            }
        }

        public int PoliticsExperience
        {
            get
            {
                return (int)(this.politicsExperience);
            }
            set
            {
                this.politicsExperience = value;
            }
        }

        public int PoliticsFromExperience
        {
            get
            {
                return (this.PoliticsExperience / 0x3e8);
            }
        }

        public int PoliticsIncludingExperience
        {
            get
            {
                return (this.BasePolitics + this.PoliticsFromExperience);
            }
        }

        public Texture2D Portrait
        {
            get
            {
                Texture2D result = base.Scenario.GetPortrait(this.PictureIndex);
                return result == null ? base.Scenario.GetPortrait(9999) : result;
            }
        }

        public Point Position
        {
            get
            {
                if (this.IsCaptive)
                {
                    if (this.BelongedCaptive.LocationArchitecture != null)
                    {
                        return this.BelongedCaptive.LocationArchitecture.Position;
                    }
                    if (this.BelongedCaptive.LocationTroop != null)
                    {
                        return this.BelongedCaptive.LocationTroop.Position;
                    }
                    return this.BelongedCaptive.BelongedFaction.Capital.Position;
                }
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.Position;
                }
                if (this.LocationArchitecture != null)
                {
                    return this.LocationArchitecture.Position;
                }
                if (this.TargetArchitecture != null)
                {
                    return this.TargetArchitecture.Position;
                }
                return Point.Zero;
            }
        }

        public int QibingExperience
        {
            get
            {
                return (int)(this.qibingExperience);
            }
            set
            {
                this.qibingExperience = value;
            }
        }

        public int QixieExperience
        {
            get
            {
                return (int)(this.qixieExperience);
            }
            set
            {
                this.qixieExperience = value;
            }
        }

        public PersonQualification Qualification
        {
            get
            {
                return this.qualification;
            }
            set
            {
                this.qualification = value;
            }
        }

        public string RealDestinationString
        {
            get
            {
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.RealDestinationString;
                }
                return "----";
            }
        }

        public int RecruitmentAbility
        {
            get
            {
                return (int)((this.BaseRecruitmentAbility + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public void RecruitMilitary(Military m)
        {
            
            if (this.recruitmentMilitary != null)
            {
                this.recruitmentMilitary.StopRecruitment();
            }
            m.StopRecruitment();
            this.WorkKind = ArchitectureWorkKind.补充;
            this.RecruitmentMilitary = m;
            m.RecruitmentPerson = this;
        }

        public Military RecruitmentMilitary
        {
            get
            {
                return this.recruitmentMilitary;
            }
            set
            {
                if (value != null && value.RecruitmentPerson != null)
                {
                    value.RecruitmentPerson.WorkKind = ArchitectureWorkKind.无;
                }
                this.recruitmentMilitary = value;
            }
        }

        public int RecruitmentWeighing
        {
            get
            {
                return (this.RecruitmentAbility * (this.MultipleOfRecruitmentReputation + this.MultipleOfRecruitmentTechniquePoint));
            }
        }

        public int Reputation
        {
            get
            {
                return reputation;
            }
            set
            {
                this.reputation = value;
            }
        }

        public string RespectfulName
        {
            get
            {
                if ((this.calledName != null) && (this.calledName != ""))
                {
                    return (this.surName + this.calledName);
                }
                return this.NormalName;
            }
        }

        public int RoutCount
        {
            get
            {
                return this.routCount;
            }
            set
            {
                this.routCount = value;
            }
        }

        public int RoutedCount
        {
            get
            {
                return this.routedCount;
            }
            set
            {
                this.routedCount = value;
            }
        }

        public int SearchAbility
        {
            get
            {
                return (int)(((this.Intelligence + this.Politics) + (this.Glamour * 2)) * (1f + this.RateIncrementOfSearch));
            }
        }

        public string SectionString
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    if (this.IsCaptive)
                    {
                        return "----";
                    }
                    if (this.LocationArchitecture != null)
                    {
                        return this.LocationArchitecture.SectionString;
                    }
                    if (this.TargetArchitecture != null)
                    {
                        return this.TargetArchitecture.SectionString;
                    }
                    if (this.LocationTroop != null)
                    {
                        if ((this.LocationTroop.StartingArchitecture != null) && (this.LocationTroop.StartingArchitecture.BelongedFaction == this.BelongedFaction))
                        {
                            return this.LocationTroop.StartingArchitecture.SectionString;
                        }
                        return "----";
                    }
                }
                return "----";
            }
        }

        public bool Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public string SexString
        {
            get
            {
                if (this.sex)
                {
                    return "女";
                }
                return "男";
            }
        }

        public int ShuijunExperience
        {
            get
            {
                return (int)(this.shuijunExperience);
            }
            set
            {
                this.shuijunExperience = value;
            }
        }

        public int SkillCount
        {
            get
            {
                return this.Skills.Skills.Count;
            }
        }

        public Texture2D SmallPortrait
        {
            get
            {
                Texture2D result = base.Scenario.GetSmallPortrait(this.PictureIndex);
                return result == null ? base.Scenario.GetSmallPortrait(9999) : result;
            }
        }

        public Person Spouse
        {
            get
            {
                return this.spouse;
            }
            set
            {
                this.spouse = value;
            }
        }

        public int SpyAbility
        {
            get
            {
                return ((this.Strength + (this.Intelligence * 2)) + this.Glamour);
            }
        }

        public int SpyDays
        {
            get
            {
                return (this.IncrementOfSpyDays + 80 + this.SpyAbility / 10);
            }
        }

        public int Strain
        {
            get
            {
                return this.strain;
            }
            set
            {
                this.strain = value;
            }
        }

        public int StratagemExperience
        {
            get
            {
                return (int)(this.stratagemExperience);
            }
            set
            {
                this.stratagemExperience = value;
            }
        }

        public PersonStrategyTendency StrategyTendency
        {
            get
            {
                return GlobalVariables.IgnoreStrategyTendency ? PersonStrategyTendency.统一全国 : this.strategyTendency;
            }
            set
            {
                this.strategyTendency = value;
            }
        }

        public int Strength
        {
            get
            {
                return this.NormalStrength;
            }
            set
            {
                this.strength = value;
            }
        }

        public int StrengthExperience
        {
            get
            {
                return (int)(this.strengthExperience);
            }
            set
            {
                this.strengthExperience = value;
            }
        }

        public int StrengthFromExperience
        {
            get
            {
                return (this.StrengthExperience / 0x3e8);
            }
        }

        public int StrengthIncludingExperience
        {
            get
            {
                return (this.BaseStrength + this.StrengthFromExperience);
            }
        }

        public int StuntCount
        {
            get
            {
                return this.Stunts.Count;
            }
        }

        public string SurName
        {
            get
            {
                return this.surName;
            }
            set
            {
                this.surName = value;
            }
        }

        public int TacticsExperience
        {
            get
            {
                return (int)(this.tacticsExperience);
            }
            set
            {
                this.tacticsExperience = value;
            }
        }

        public string TargetString
        {
            get
            {
                if (this.LocationTroop != null)
                {
                    return this.LocationTroop.TargetString;
                }
                return "----";
            }
        }

        public int TaskDays
        {
            get
            {
                return this.taskDays;
            }
            set
            {
                this.taskDays = value;
            }
        }

        public int TechnologyAbility
        {
            get
            {
                if (technologyAbility > 0) return technologyAbility;
                technologyAbility = (int)((this.BaseTechnologyAbility + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
                return technologyAbility;
            }
        }

        public int TechnologyWeighing
        {
            get
            {
                return ((this.TechnologyAbility * (this.MultipleOfTechnologyReputation + this.MultipleOfTechnologyTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int TrainingAbility
        {
            get
            {
                if (trainingAbility > 0) return trainingAbility;
                trainingAbility = (int)((this.BaseTrainingAbility + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
                return trainingAbility;
            }
        }

        public int TrainingWeighing
        {
            get
            {
                return (this.TrainingAbility * (this.MultipleOfTrainingReputation + this.MultipleOfTrainingTechniquePoint));
            }
        }

        public string Travel
        {
            get
            {
                if (this.ArrivingDays > 0)
                {
                    return (this.ArrivingDays + "天");
                }
                return "----";
            }
        }

        public int TreasureCount
        {
            get
            {
                return this.Treasures.Count;
            }
        }

        public int TreasureMerit
        {
            get
            {
                int num = 0;
                foreach (Treasure treasure in this.effectiveTreasures.Values)
                {
                    num += treasure.Worth;
                }
                return num;
            }
        }

        public PersonValuationOnGovernment ValuationOnGovernment
        {
            get
            {
                return this.valuationOnGovernment;
            }
            set
            {
                this.valuationOnGovernment = value;
            }
        }

        public float WinningRate
        {
            get
            {
                if ((this.routCount + this.routedCount) == 0)
                {
                    return 0f;
                }
                return (((float)this.routCount) / ((float)(this.routCount + this.routedCount)));
            }
        }

        public int WorkAbility
        {
            get
            {
                return this.GetWorkAbility(this.WorkKind);
            }
        }

        public ArchitectureWorkKind WorkKind
        {
            get
            {
                return this.workKind;
            }
            set
            {
                if (this.workKind == ArchitectureWorkKind.补充 && value != ArchitectureWorkKind.补充 && this.recruitmentMilitary != null)
                {
                    this.recruitmentMilitary.RecruitmentPerson = null;
                    this.recruitmentMilitary = null;
                }
                base.Scenario.ClearPersonWorkCache();
                this.workKind = value;
            }
        }

        public string WorkKindString
        {
            get
            {
                if (this.WorkKind != ArchitectureWorkKind.无)
                {
                    return this.WorkKind.ToString();
                }
                return "----";
            }
        }

        public int YearAvailable
        {
            get
            {
                return this.yearAvailable;
            }
            set
            {
                this.yearAvailable = value;
            }
        }

        public int YearBorn
        {
            get
            {
                return this.yearBorn;
            }
            set
            {
                this.yearBorn = value;
            }
        }

        public int YearDead
        {
            get
            {
                return this.yearDead;
            }
            set
            {
                this.yearDead = value;
            }
        }

        public PersonList ChildrenCanBeSelectedAsPrince()
        {
            PersonList candicate = new PersonList();
            foreach (Person person in this.Scenario.Persons)
            {
                if (person.Alive && person.Available && person.BelongedCaptive == null && person.sex == false 
                    && person.BelongedFaction == this.BelongedFaction && person.BelongedFaction != null && this == person.Father)
                {
                    candicate.Add(person);
                }
            }
            candicate.PropertyName = "YearBorn";
            candicate.IsNumber = true;
            candicate.SmallToBig = true;
            candicate.ReSort();
            return candicate;

        }



        public PersonList meichushengdehaiziliebiao()
        {
            PersonList haiziliebiao = new PersonList();
            foreach (Person person in this.Scenario.Persons)
            {
                if (person.Alive && !person.Available && person.Father == this && person.YearBorn > base.Scenario.Date.Year)
                {
                    haiziliebiao.Add(person);
                }
            }
            haiziliebiao.PropertyName = "YearBorn";
            haiziliebiao.IsNumber = true;
            haiziliebiao.SmallToBig = true;
            haiziliebiao.ReSort();
            return haiziliebiao;
        }

        public String FatherName
        {
            get
            {
                if (Father == null) return "－－－－";
                return Father.Name;
            }
        }

        public String MotherName
        {
            get
            {
                if (Mother == null) return "－－－－";
                return Mother.Name;
            }
        }

        public String SpouseName
        {
            get
            {
                if (spouse == null) return "－－－－";
                return Spouse.Name;
            }
        }


        public delegate void BeAwardedTreasure(Person person, Treasure t);

        public delegate void BeConfiscatedTreasure(Person person, Treasure t);

        public delegate void BeKilled(Person person, Architecture location);

        public delegate void ChangeLeader(Faction faction, Person leader, bool changeName, string oldName);

        public delegate void ConvinceFailed(Person source, Person destination);

        public delegate void ConvinceSuccess(Person source, Person destination, Faction oldFaction);

        public delegate void JailBreakFailed(Person source, Architecture destination);

        public delegate void JailBreakSuccess(Person source, Captive destination);

        public delegate void Death(Person person, Person killer, Architecture location, Troop locationTroop);

        public delegate void DeathChangeFaction(Person dead, Person leader, string oldName);

        public delegate void DestroyFailed(Person person, Architecture architecture);

        public delegate void DestroySuccess(Person person, Architecture architecture, int down);

        public delegate void GossipFailed(Person person, Architecture architecture);

        public delegate void GossipSuccess(Person person, Architecture architecture);

        public delegate void InformationObtained(Person person, Information information);

        public delegate void qingbaoshibai(Person person);

        public delegate void InstigateFailed(Person person, Architecture architecture);

        public delegate void InstigateSuccess(Person person, Architecture architecture, int down);

        public delegate void Leave(Person person, Architecture location);

        public delegate void SearchFinished(Person person, Architecture architecture, SearchResultPack resultPack);
        /*
        public delegate void ShowMessage(Person person, PersonMessage personMessage);

        public delegate void SpyFailed(Person person, Architecture architecture);

        public delegate void SpyFound(Person person, Person spy);

        public delegate void SpySuccess(Person person, Architecture architecture);
        */
        public delegate void StudySkillFinished(Person person, string skillString, bool success);

        public delegate void StudyStuntFinished(Person person, Stunt stunt, bool success);

        public delegate void StudyTitleFinished(Person person, Title title, bool success);

        public delegate void TreasureFound(Person person, Treasure treasure);

        public delegate void CapturedByArchitecture(Person person, Architecture architecture);

        public bool RecruitableBy(Faction f, int idealLeniency)
        {
            int idealOffset = Person.GetIdealOffset(this, f.Leader);
            //义兄弟或者配偶直接登用。(当前判断是和所在势力的君主)
            if (this.IsVeryCloseTo(f.Leader))
            {
                return true;
            }

            if (this.Hates(f.Leader))
            {
                return false;
            }
            if (GlobalVariables.IdealTendencyValid && idealOffset > this.IdealTendency.Offset + (double)f.Reputation / f.MaxPossibleReputation * 75 + idealLeniency)
            {
                return false;
            }
            if (this.Loyalty > 100 && this.BelongedFaction != f)
            {
                return false;
            }
            if (this.IsCaptive && this.BelongedFaction != null && this == this.BelongedFaction.Leader)
            {
                return false;
            }
            return true;
        }

        internal void muqinyingxiangnengli(Person muqin)
        {
            this.BaseStrength = (int)(this.BaseStrength * 0.9 + muqin.BaseStrength * 0.1);
            this.BaseStrength += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);

            this.BaseCommand = (int)(this.BaseCommand * 0.9 + muqin.BaseCommand * 0.1);
            this.BaseCommand += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);

            this.BaseIntelligence = (int)(this.BaseIntelligence * 0.9 + muqin.BaseIntelligence * 0.1);
            this.BaseIntelligence += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);

            this.BasePolitics = (int)(this.BasePolitics * 0.9 + muqin.BasePolitics * 0.1);
            this.BasePolitics += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);

            this.BaseGlamour = (int)(this.BaseGlamour * 0.9 + muqin.BaseGlamour * 0.1);
            this.BaseGlamour += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);

            if (!GlobalVariables.createChildrenIgnoreLimit)
            {
                if (this.BaseStrength > 100) this.BaseStrength = 100;
                if (this.BaseStrength < 0) this.BaseStrength = 0;
                if (this.BaseCommand > 100) this.BaseCommand = 100;
                if (this.BaseCommand < 0) this.BaseCommand = 0;
                if (this.BaseIntelligence > 100) this.BaseIntelligence = 100;
                if (this.BaseIntelligence < 0) this.BaseIntelligence = 0;
                if (this.BasePolitics > 100) this.BasePolitics = 100;
                if (this.BasePolitics < 0) this.BasePolitics = 0;
                if (this.BaseGlamour > 100) this.BaseGlamour = 100;
                if (this.BaseGlamour < 0) this.BaseGlamour = 0;
            }
        }

        private static List<String> readTextList(String fileName)
        {
            TextReader tr = new StreamReader("Resources/" + fileName);
            List<String> result = new List<String>();
            while (tr.Peek() >= 0)
            {
                result.Add(tr.ReadLine());
            }
            return result;
        }

        private static List<int> readNumberList(String fileName)
        {
            TextReader tr = new StreamReader("Resources/" + fileName);
            List<int> result = new List<int>();
            while (tr.Peek() >= 0)
            {
                result.Add(int.Parse(tr.ReadLine()));
            }
            return result;
        }

        private static void setNewOfficerFace(Person r)
        {
            List<int> pictureList;
            if (r.Sex)
            {
                if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/femalefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/femalefaceA.txt");
                }
            }
            else
            {
                if (r.BaseCommand < 50 && r.BaseStrength < 50 && r.BaseIntelligence < 50 && r.BasePolitics < 50 && r.BaseGlamour < 50)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceU.txt");
                }
                else if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("CreateChildrenTextFile/malefaceA.txt");
                }
            }
            r.PictureIndex = pictureList[GameObject.Random(pictureList.Count)];
        }

        private static String GenerateBiography(Person r, GameScenario scen)
        {
            String biography = "";

            List<String> adjectives = new List<String>();
            List<String> suffixes = new List<String>();
            int strength, command, intelligence, politics, glamour, braveness, calmness, personalLoyalty, ambition;
            strength = command = intelligence = politics = glamour = braveness = calmness = personalLoyalty = ambition = 0;
            foreach (BiographyAdjectives b in scen.GameCommonData.AllBiographyAdjectives)
            {
                if (b.Male && r.Sex)
                {
                    continue;
                }
                if (b.Female && !r.Sex)
                {
                    continue;
                }

                if ((b.Strength == 0 || (b.Strength > strength && r.BaseStrength >= b.Strength)) &&
                    (b.Command == 0 || (b.Command > command && r.BaseCommand >= b.Command)) &&
                    (b.Intelligence == 0 || (b.Intelligence > intelligence && r.BaseIntelligence >= b.Intelligence)) &&
                    (b.Politics == 0 || (b.Politics > politics && r.BasePolitics >= b.Politics)) &&
                    (b.Glamour == 0 || (b.Glamour > glamour && r.BaseGlamour >= b.Glamour)) &&
                    (b.Braveness == 0 || (b.Braveness > braveness && r.BaseBraveness >= b.Braveness)) &&
                    (b.Calmness == 0 || (b.Calmness > calmness && r.BaseCalmness >= b.Calmness)) &&
                    (b.PersonalLoyalty == 0 || (b.PersonalLoyalty > personalLoyalty && r.PersonalLoyalty >= b.PersonalLoyalty)) &&
                    (b.Ambition == 0 || (b.Ambition > ambition && r.Ambition >= b.Ambition))
                    )
                {
                    strength = b.Strength;
                    command = b.Command;
                    intelligence = b.Intelligence;
                    politics = b.Politics;
                    glamour = b.Glamour;
                    braveness = b.Braveness;
                    calmness = b.Calmness;
                    personalLoyalty = b.PersonalLoyalty;
                    ambition = b.Ambition;

                    if (b.Text.Count > 0)
                    {
                        adjectives.Add(b.Text[GameObject.Random(b.Text.Count)]);
                    }
                    if (b.SuffixText.Count > 0)
                    {
                        suffixes.Add(b.SuffixText[GameObject.Random(b.SuffixText.Count)]);
                    }
                }
            }
            if (adjectives.Count > 0)
            {
                foreach (String s in adjectives)
                {
                    biography += s + "，";
                }
                biography = biography.Substring(0, biography.Length - 1);
                if (adjectives.Count > 0)
                {
                    biography += "的" + (suffixes.Count > 0 ? suffixes[GameObject.Random(suffixes.Count)] : "將領");
                }
                biography += "。";
            }

            return biography;
        }

        //private enum OfficerType { GENERAL, BRAVE, ADVISOR, POLITICIAN, INTEL_GENERAL, EMPEROR, ALL_ROUNDER, NORMAL_ADVISOR, CHEAP, NORMAL_GENERAL };

        private static PersonGeneratorType generatePersonType(GameScenario scen)
        {
            PersonGeneratorType gernrateType = new PersonGeneratorType();
            
            //int[] weights = new int[10];
            int[] weights = { 100, 100, 100, 100, 60, 100, 1, 250, 250, 39 }; 
            /*foreach (PersonGeneratorType type in scen.GameCommonData.AllPersonGeneratorTypes)
            {
                weights[type.ID] = type.generationChance;
            }*/

            int total = 0;
            foreach (int i in weights)
            {
                total += i;
            }

            int officerType = 9;
            int typeInt = GameObject.Random(total);
            int typeSum = 0;
            for (int i = 0; i < weights.Length; ++i)
            {
                typeSum += weights[i];
                if (typeInt < typeSum)
                {
                    officerType = i;
                    break;
                }
            }
            gernrateType.ID = officerType  ;

            return gernrateType;
        }
        
        public static Person createPerson(GameScenario scen, Architecture foundLocation, Person finder, bool inGame)
        {
            return createPerson(scen, foundLocation, finder, inGame, generatePersonType(scen));
        }
        
        public static Person createPerson(PersonGenerateParam param)
        {
            return createPerson(param.Scenario, param.FoundLocation, param.Finder, param.InGame, param.PreferredType);
        }

        private static readonly List<int> playerGeneratorTypeIds = new List<int>() {0,1,2,3,4,5,7, 8, 9 };

        public static PersonGeneratorTypeList CreatePlayerPersonGeneratorTypeList(PersonGeneratorTypeList allTypes)
        {
            PersonGeneratorTypeList list = new PersonGeneratorTypeList();
            foreach (PersonGeneratorType type in allTypes)
            {
                if (playerGeneratorTypeIds.Contains(type.ID))
                {
                    list.Add(type);
                }

                if (list.Count == playerGeneratorTypeIds.Count)
                {
                    break;
                }
                
            }
            return list;
        }

        private static Person createPerson(GameScenario scen, Architecture foundLocation, Person finder, bool inGame, PersonGeneratorType preferredType)
        {
            
            Person r = new Person();

            //look for empty id
            int id = 25000;
            PersonList pl = scen.Persons as PersonList;
            pl.SmallToBig = true;
            pl.IsNumber = true;
            pl.PropertyName = "ID";
            pl.ReSort();
            foreach (Person p in pl)
            {
                if (p.ID == id)
                {
                    id++;
                    
                }
                else if (p.ID > id)
                {
                    break;
                }
            }
            r.ID = id;

            r.Scenario = scen;

            r.Father = null;
            r.Mother = null;
            r.Generation = 1;
            r.Strain = r.ID;
            finder = foundLocation.BelongedFaction.Leader;

            PersonGeneratorSetting options = scen.GameCommonData.PersonGeneratorSetting;

            r.Sex = GameObject.Chance(options.femaleChance) ? true : false;

            List<String> surnameList = Person.readTextList("CreateChildrenTextFile/surname.txt");
            r.SurName = surnameList[GameObject.Random(surnameList.Count)];
            List<String> givenNameList = r.Sex ? Person.readTextList("CreateChildrenTextFile/femalegivenname.txt") : Person.readTextList("CreateChildrenTextFile/malegivenname.txt");
            r.GivenName = givenNameList[GameObject.Random(givenNameList.Count)];
            if (r.GivenName.Length <= 1 && GameObject.Chance(r.Sex ? 90 : 10))
            {
                String s;
                int tries = 0;
                do
                {
                    s = givenNameList[GameObject.Random(givenNameList.Count)];
                    tries++;
                } while (s.Length > 1 && tries < 100);
                r.GivenName += s;
            }
            r.CalledName = "";

           
            int officerType = preferredType.ID ;
            

            int titleChance = 0;

            PersonGeneratorType typeParam = (PersonGeneratorType)scen.GameCommonData.AllPersonGeneratorTypes.GetGameObject(officerType);
            r.BaseCommand = GameObject.RandomGaussianRange(typeParam.commandLo, typeParam.commandHi);
            r.BaseStrength = GameObject.RandomGaussianRange(typeParam.strengthLo, typeParam.strengthHi);
            r.BaseIntelligence = GameObject.RandomGaussianRange(typeParam.intelligenceLo, typeParam.intelligenceHi);
            r.BasePolitics = GameObject.RandomGaussianRange(typeParam.politicsLo, typeParam.politicsHi);
            r.BaseGlamour = GameObject.RandomGaussianRange(typeParam.glamourLo, typeParam.glamourHi);
            r.Braveness = GameObject.RandomGaussianRange(typeParam.braveLo, typeParam.braveHi);
            r.Calmness = GameObject.RandomGaussianRange(typeParam.calmnessLo, typeParam.calmnessHi);
            r.PersonalLoyalty = GameObject.RandomGaussianRange(typeParam.personalLoyaltyLo, typeParam.personalLoyaltyHi);
            r.Ambition = GameObject.RandomGaussianRange(typeParam.ambitionLo, typeParam.ambitionHi);
            titleChance = typeParam.titleChance;

            if (typeParam.affectedByRateParameter || GlobalVariables.CreatedOfficerAbilityFactor > 1)
            {
                r.BaseCommand = (int)(r.BaseCommand * GlobalVariables.CreatedOfficerAbilityFactor);
                r.BaseStrength = (int)(r.BaseStrength * GlobalVariables.CreatedOfficerAbilityFactor);
                r.BaseIntelligence = (int)(r.BaseIntelligence * GlobalVariables.CreatedOfficerAbilityFactor);
                r.BasePolitics = (int)(r.BasePolitics * GlobalVariables.CreatedOfficerAbilityFactor);
                r.BaseGlamour = (int)(r.BaseGlamour * GlobalVariables.CreatedOfficerAbilityFactor);
            }
            if (r.BaseCommand < 1) r.Command = 1;
            if (r.BaseStrength < 1) r.Strength = 1;
            if (r.BaseIntelligence < 1) r.Intelligence = 1;
            if (r.BasePolitics < 1) r.Politics = 1;
            if (r.BaseGlamour < 1) r.Glamour = 1;

            setNewOfficerFace(r);

           

            r.YearBorn = scen.Date.Year + GameObject.Random(options.bornLo, options.bornHi);
            r.YearAvailable = scen.Date.Year + (inGame ? 0 : GameObject.Random(options.debutLo, options.debutHi));
            r.YearDead = Math.Max(r.YearBorn + GameObject.Random(options.dieLo, options.dieHi), scen.Date.Year + options.debutAtLeast);

            r.Reputation = GameObject.Random(51) * 100;

            r.Qualification = (PersonQualification)GameObject.Random(Enum.GetNames(typeof(PersonQualification)).Length);
            r.ValuationOnGovernment = (PersonValuationOnGovernment)GameObject.Random(Enum.GetNames(typeof(PersonValuationOnGovernment)).Length);
            r.StrategyTendency = (PersonStrategyTendency)GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length);
            r.IdealTendency = scen.GameCommonData.AllIdealTendencyKinds.GetRandomList()[0] as IdealTendencyKind;

            if (!scen.IsPlayer(foundLocation.BelongedFaction))
            {
                GameObjectList ideals = scen.GameCommonData.AllIdealTendencyKinds;
                IdealTendencyKind minIdeal = null;
                foreach (IdealTendencyKind itk in ideals)
                {
                    if (minIdeal == null || itk.Offset < minIdeal.Offset)
                    {
                        minIdeal = itk;
                    }
                }

                r.IdealTendency = minIdeal;
                r.Ideal = (foundLocation.BelongedFaction.Leader.Ideal + GameObject.Random(minIdeal.Offset * 2 + 1) - minIdeal.Offset) % 150;
            

            }
            else
            {
                r.Ideal = GameObject.Random(150);
            }
            

            r.BornRegion = (PersonBornRegion)GameObject.Random(Enum.GetNames(typeof(PersonBornRegion)).Length);

            {
                Dictionary<CharacterKind, int> chances = new Dictionary<CharacterKind, int>();
                foreach (CharacterKind t in scen.GameCommonData.AllCharacterKinds)
                {
                    chances.Add(t, t.GenerationChance[(int)officerType]);
                }

                int sum = 0;
                foreach (int i in chances.Values)
                {
                    sum += i;
                }

                int p = GameObject.Random(sum);
                double pt = 0;
                foreach (KeyValuePair<CharacterKind, int> td in chances)
                {
                    pt += td.Value;
                    if (p < pt)
                    {
                        r.Character = td.Key;
                        break;
                    }
                }
            }

            foreach (Skill s in scen.GameCommonData.AllSkills.Skills.Values)
            {
                if (s.CanBeChosenForGenerated())
                {
                    int chance = s.GenerationChance[(int)officerType];
                    chance = (int)(chance * Math.Max(0, s.GetRelatedAbility(r) - 50) / 10.0 + 1);
                    if (GameObject.Chance(chance))
                    {
                        r.Skills.AddSkill(s);
                    }
                }
            }

            foreach (Stunt s in scen.GameCommonData.AllStunts.Stunts.Values)
            {
                if (s.CanBeChosenForGenerated())
                {
                    int chance = s.GenerationChance[(int)officerType];
                    chance = (int)(chance * Math.Max(0, s.GetRelatedAbility(r) - 50) / 10.0 + 1);
                    if (GameObject.Random(1000) <= chance)
                    {
                        r.Stunts.AddStunt(s);
                    }
                }
            }

            if (GameObject.Chance(titleChance))
            {
                Dictionary<TitleKind, List<Title>> titles = Title.GetKindTitleDictionary(scen);
                foreach (KeyValuePair<TitleKind, List<Title>> kv in titles)
                {
                    Dictionary<Title, double> chances = new Dictionary<Title, double>();
                    foreach (Title t in kv.Value)
                    {
                        if (t.CanBeChosenForGenerated())
                        {
                            chances.Add(t, t.GenerationChance[(int)officerType]);
                        }
                    }

                    int randMax = 10000;
                    double sum = 0;
                    foreach (double i in chances.Values)
                    {
                        sum += i;
                    }

                    int p = GameObject.Random(randMax);
                    double pt = 0;
                    foreach (KeyValuePair<Title, double> td in chances)
                    {
                        pt += td.Value / sum * randMax;
                        if (p < pt)
                        {
                            r.RealTitles.Add(td.Key);
                            break;
                        }
                    }
                }
            }

            String biography = "";
            if (foundLocation != null && finder != null)
            {
                biography += "于" + scen.Date.Year + "年" + scen.Date.Month + "月在" + foundLocation.Name + "被" + finder.Name + "发掘成才。";
            }

            biography += Person.GenerateBiography(r, scen);

            Biography bio = new Biography();
            bio.Brief = biography;
            bio.ID = r.ID;
            bio.FactionColor = 52;
            bio.MilitaryKinds.AddBasicMilitaryKinds(scen);
            scen.AllBiographies.AddBiography(bio);
            r.PersonBiography = bio;

            r.Alive = true;
            r.Available = true;
            r.LocationArchitecture = foundLocation;
            r.Status = PersonStatus.Normal;

            r.Loyalty = 100;

            scen.Persons.Add(r);

            ExtensionInterface.call("CreatePerson", new Object[] { scen, r });

            return r;
        }

        

        public static Person createChildren(Person father, Person mother)
        {
            Person r = new Person();

            //look for empty id
            int id = 5000;
            PersonList pl = father.Scenario.Persons as PersonList;
            pl.SmallToBig = true;
            pl.IsNumber = true;
            pl.PropertyName = "ID";
            pl.ReSort();
            foreach (Person p in pl)
            {
                if (p.ID == id)
                {
                    id++;
                    if (id >= 7000 && id < 10000)
                    {
                        id = 10000;
                    }
                }
                else if (p.ID > id)
                {
                    break;
                }
            }
            r.ID = id;

            r.Father = father;
            r.Mother = mother;
            r.Generation = father.Generation + 1;
            r.Strain = father.Strain;

            r.Sex = GameObject.Chance(father.Scenario.GameCommonData.PersonGeneratorSetting.femaleChance) ? true : false;

            r.SurName = father.SurName;
            List<String> givenNameList = r.Sex ? Person.readTextList("CreateChildrenTextFile/femalegivenname.txt") : Person.readTextList("CreateChildrenTextFile/malegivenname.txt");
            r.GivenName = givenNameList[GameObject.Random(givenNameList.Count)];
            if (r.GivenName.Length <= 1 && GameObject.Chance(r.Sex ? 90 : 10))
            {
                String s;
                int tries = 0;
                do
                {
                    s = givenNameList[GameObject.Random(givenNameList.Count)];
                    tries++;
                } while (s.Length > 1 && tries < 100);
                r.GivenName += s;
            }
            r.CalledName = "";

            int var = 5; //variance / maximum divert from parent ability
            r.BaseCommand = GameObject.Random(Math.Abs(father.CommandIncludingExperience - mother.CommandIncludingExperience) + 2 * var + 1) + Math.Min(father.CommandIncludingExperience, mother.CommandIncludingExperience) - var + father.childrenAbilityIncrease + mother.childrenAbilityIncrease;
            r.BaseStrength = GameObject.Random(Math.Abs(father.StrengthIncludingExperience - mother.StrengthIncludingExperience) + 2 * var + 1) + Math.Min(father.StrengthIncludingExperience, mother.StrengthIncludingExperience) - var + father.childrenAbilityIncrease + mother.childrenAbilityIncrease;
            r.BaseIntelligence = GameObject.Random(Math.Abs(father.IntelligenceIncludingExperience - mother.IntelligenceIncludingExperience) + 2 * var + 1) + Math.Min(father.IntelligenceIncludingExperience, mother.IntelligenceIncludingExperience) - var + father.childrenAbilityIncrease + mother.childrenAbilityIncrease;
            r.BasePolitics = GameObject.Random(Math.Abs(father.PoliticsIncludingExperience - mother.PoliticsIncludingExperience) + 2 * var + 1) + Math.Min(father.PoliticsIncludingExperience, mother.PoliticsIncludingExperience) - var + father.childrenAbilityIncrease + mother.childrenAbilityIncrease;
            r.BaseGlamour = GameObject.Random(Math.Abs(father.GlamourIncludingExperience - mother.GlamourIncludingExperience) + 2 * var + 1) + Math.Min(father.GlamourIncludingExperience, mother.GlamourIncludingExperience) - var + father.childrenAbilityIncrease + mother.childrenAbilityIncrease;
            if (!GlobalVariables.createChildrenIgnoreLimit)
            {
                if (r.BaseStrength > 100) r.BaseStrength = 100;
                if (r.BaseStrength < 0) r.BaseStrength = 0;
                if (r.BaseCommand > 100) r.BaseCommand = 100;
                if (r.BaseCommand < 0) r.BaseCommand = 0;
                if (r.BaseIntelligence > 100) r.BaseIntelligence = 100;
                if (r.BaseIntelligence < 0) r.BaseIntelligence = 0;
                if (r.BasePolitics > 100) r.BasePolitics = 100;
                if (r.BasePolitics < 0) r.BasePolitics = 0;
                if (r.BaseGlamour > 100) r.BaseGlamour = 100;
                if (r.BaseGlamour < 0) r.BaseGlamour = 0;
            }

            setNewOfficerFace(r);

            r.YearBorn = father.Scenario.Date.Year;
            r.YearAvailable = father.Scenario.Date.Year + GlobalVariables.ChildrenAvailableAge;
            r.YearDead = r.YearBorn + GameObject.Random(69) + 30;

            r.Ideal = GameObject.Chance(50) ? father.Ideal + GameObject.Random(10) - 5 : mother.Ideal + GameObject.Random(10) - 5;
            r.Ideal = (r.Ideal + 150) % 150;

            r.Reputation = (int)((father.Reputation + mother.Reputation) * (GameObject.Random(100) / 100.0 * 0.1 + 0.05)) + father.childrenReputationIncrease + mother.childrenReputationIncrease;

            r.PersonalLoyalty = (GameObject.Chance(50) ? father.PersonalLoyalty : mother.PersonalLoyalty) + GameObject.Random(3) - 1;
            if (r.PersonalLoyalty < 0) r.PersonalLoyalty = 0;
            if ((int)r.PersonalLoyalty > Enum.GetNames(typeof(PersonLoyalty)).Length) r.PersonalLoyalty = Enum.GetNames(typeof(PersonLoyalty)).Length;

            r.Ambition = (GameObject.Chance(50) ? father.Ambition : mother.Ambition) + GameObject.Random(3) - 1;
            if (r.Ambition < 0) r.Ambition = 0;
            if ((int)r.Ambition > Enum.GetNames(typeof(PersonAmbition)).Length) r.Ambition = Enum.GetNames(typeof(PersonAmbition)).Length;

            r.Qualification = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Qualification : mother.Qualification) : (PersonQualification)GameObject.Random(Enum.GetNames(typeof(PersonQualification)).Length);

            r.Braveness = (GameObject.Chance(50) ? father.BaseBraveness : mother.BaseBraveness) + GameObject.Random(5) - 2;
            if (r.BaseBraveness < 1) r.Braveness = 1;
            if (r.BaseBraveness > 10 && !GlobalVariables.createChildrenIgnoreLimit) r.Braveness = 10;

            r.Calmness = (GameObject.Chance(50) ? father.BaseCalmness : mother.BaseCalmness) + GameObject.Random(5) - 2;
            if (r.BaseCalmness < 1) r.Calmness = 1;
            if (r.BaseCalmness > 10 && !GlobalVariables.createChildrenIgnoreLimit) r.Calmness = 10;

            r.ValuationOnGovernment = (GameObject.Chance(50) ? father.ValuationOnGovernment : mother.ValuationOnGovernment);

            r.StrategyTendency = (GameObject.Chance(50) ? father.StrategyTendency : mother.StrategyTendency);

            r.IdealTendency = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.IdealTendency : mother.IdealTendency) : father.Scenario.GameCommonData.AllIdealTendencyKinds.GetRandomList()[0] as IdealTendencyKind;
            if (father.BelongedFaction != null || mother.BelongedFaction != null)
            {
                Person leader = father.BelongedFaction == null ? mother.BelongedFaction.Leader : father.BelongedFaction.Leader;
                if (r.IdealTendency.Offset < Person.GetIdealOffset(r, leader))
                {
                    if (leader.IdealTendency.Offset >= 0)
                    {
                        r.Ideal = leader.Ideal + GameObject.Random(r.IdealTendency.Offset * 2 + 1) - r.IdealTendency.Offset;
                        r.Ideal = (r.Ideal + 150) % 150;
                    }
                    else
                    {
                        r.Ideal = leader.Ideal;
                    }
                }
            }

            Architecture bornArch = mother.BelongedArchitecture != null ? mother.BelongedArchitecture : father.BelongedArchitecture;

            try //best-effort approach for getting PersonBornRegion
            {
                r.BornRegion = (PersonBornRegion)Enum.Parse(typeof(PersonBornRegion), bornArch.LocationState.Name); //mother has no locationarch...
            }
            catch (Exception)
            {
                r.BornRegion = (PersonBornRegion)GameObject.Random(Enum.GetNames(typeof(PersonBornRegion)).Length);
            }

            int characterId = 0;
            do
            {
                characterId = GameObject.Random(father.Scenario.GameCommonData.AllCharacterKinds.Count);
            } while (characterId == 0);
            r.Character = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Character : mother.Character) : father.Scenario.GameCommonData.AllCharacterKinds[characterId];

            foreach (Skill i in father.Skills.GetSkillList())
            {
                if (GameObject.Chance(50 + father.childrenSkillChanceIncrease) && i.CanBeBorn(r))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in mother.Skills.GetSkillList())
            {
                if (GameObject.Chance(50 + mother.childrenSkillChanceIncrease) && i.CanBeBorn(r))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in father.Scenario.GameCommonData.AllSkills.GetSkillList())
            {
                if (((GameObject.Random(father.Scenario.GameCommonData.AllSkills.GetSkillList().Count / 2) == 0 && GameObject.Random(i.Level * i.Level / 2 + i.Level) == 0)
                    ||
                    GameObject.Chance(father.childrenSkillChanceIncrease + mother.childrenSkillChanceIncrease)) && i.CanBeBorn(r))
                {
                    r.Skills.AddSkill(i);
                }
            }

            foreach (Stunt i in father.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50 + father.childrenStuntChanceIncrease) && i.CanBeBorn(r))
                {
                    r.Stunts.AddStunt(i);
                }
            }
            foreach (Stunt i in mother.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50 + mother.childrenStuntChanceIncrease) && i.CanBeBorn(r))
                {
                    r.Stunts.AddStunt(i);
                }
            }
            foreach (Stunt i in father.Scenario.GameCommonData.AllStunts.GetStuntList())
            {
                if ((GameObject.Random(father.Scenario.GameCommonData.AllStunts.GetStuntList().Count * 2) == 0 ||
                    GameObject.Chance(father.childrenStuntChanceIncrease + mother.childrenStuntChanceIncrease)) && i.CanBeBorn(r))
                {
                    bool ok = true;
                    foreach (Condition j in i.LearnConditions.Conditions.Values)
                    {
                        if (j.Kind.ID == 600 || j.Kind.ID == 610) //check personality kind only
                        {
                            if (!j.CheckCondition(r))
                            {
                                ok = false;
                                break;
                            }
                        }
                    }
                    if (ok)
                    {
                        r.Stunts.AddStunt(i);
                    }
                }
            }

            Dictionary<TitleKind, List<Title>> titles = Title.GetKindTitleDictionary(father.Scenario);
            foreach (KeyValuePair<TitleKind, List<Title>> i in titles)
            {
                Title ft = father.getTitleOfKind(i.Key);
                Title mt = mother.getTitleOfKind(i.Key);
                int levelTendency = (((ft == null ? 0 : ft.Level) + (mt == null ? 0 : mt.Level)) / 2)
                    + father.childrenTitleChanceIncrease + mother.childrenTitleChanceIncrease;

                if (ft != null && GameObject.Chance(ft.InheritChance) && ft.CheckLimit(father))
                {
                    r.RealTitles.Add(ft);
                }
                else if (mt != null && GameObject.Chance(mt.InheritChance) && mt.CheckLimit(mother)) 
                {
                    r.RealTitles.Add(mt);
                }
                else
                {
                    int targetLevel = levelTendency + GameObject.Random(3) - 1;
                    if (targetLevel <= 0) continue;

                    List<Title> candidates = new List<Title>();
                    List<Title> lesserCandidates = new List<Title>();
                    List<Title> leastCandidates = new List<Title>();

                    foreach (Title t in i.Value)
                    {
                        if (t.Level == targetLevel && t.CanBeBorn(r))
                        {
                            candidates.Add(t);
                        }
                        else if ((t.Level + 1 == targetLevel || t.Level - 1 == targetLevel) && t.CanBeBorn(r))
                        {
                            lesserCandidates.Add(t);
                        }
                        else if (t.Level < targetLevel && t.CanBeBorn(r))
                        {
                            leastCandidates.Add(t);
                        }
                    }

                    if (candidates.Count > 0)
                    {
                        r.RealTitles.Add(candidates[GameObject.Random(candidates.Count)]);
                    }
                    else if (lesserCandidates.Count > 0)
                    {
                        r.RealTitles.Add(lesserCandidates[GameObject.Random(lesserCandidates.Count)]);
                    }
                    else if (leastCandidates.Count > 0)
                    {
                        r.RealTitles.Add(leastCandidates[GameObject.Random(lesserCandidates.Count)]);
                    }
                }
            }

            String biography = "";
            int fatherChildCount = father.NumberOfChildren;
            int motherChildCount = mother.NumberOfChildren;
            String[] order = new String[] { "长", "次", "三", "四", "五", "六", "七", "八" };
            biography += r.Father.Name + "之" + (fatherChildCount > 7 ? "" : order[fatherChildCount]) + (r.Sex ? "女" : "子") + "，" +
                r.Mother.Name + "之" + (motherChildCount > 7 ? "" : order[motherChildCount]) + (r.Sex ? "女" : "子") + "。" +
                "在" + r.father.Scenario.Date.Year + "年" + r.Father.Scenario.Date.Month + "月于" + bornArch.Name + "出生。";

            Person root = father;
            while (root.Father != null)
            {
                root = root.Father;
            }
            if (root != father)
            {
                biography += root.Name + "的后代。";
            }

            biography += Person.GenerateBiography(r, father.Scenario);

            Biography bio = new Biography();
            bio.Brief = biography;
            bio.ID = r.ID;
            Biography fatherBio = father.Scenario.AllBiographies.GetBiography(father.ID);
            if (fatherBio != null)
            {
                bio.FactionColor = fatherBio.FactionColor;
                bio.MilitaryKinds = fatherBio.MilitaryKinds;
            }
            else
            {
                bio.FactionColor = 52;
                bio.MilitaryKinds.AddBasicMilitaryKinds(father.Scenario);
            }
            father.Scenario.AllBiographies.AddBiography(bio);
            r.PersonBiography = bio;

            /*r.LocationArchitecture = father.BelongedArchitecture; //mother has no location arch!
            r.BelongedFaction = r.BelongedArchitecture.BelongedFaction;
            r.Available = true;*/
            r.Alive = true;
            r.JoinFactionID = new List<int>();
            if (father.BelongedFaction != null)
            {
                r.JoinFactionID.Add(father.BelongedFaction.ID);
            }
            if (mother.BelongedFaction != null)
            {
                r.JoinFactionID.Add(mother.BelongedFaction.ID);
            }

            father.Scenario.Persons.Add(r);

            r.Scenario = father.Scenario;

            foreach (Person p in father.Scenario.Persons)
            {
                int fatherRel = father.GetRelation(p);
                int motherRel = mother.GetRelation(p);

                if (fatherRel != 0 && motherRel != 0)
                {
                    int rel = GameObject.Random(Math.Abs(fatherRel - motherRel)) + Math.Min(fatherRel, motherRel);
                    p.SetRelation(p, rel);
                }
            }

            foreach (Person p in father.GetClosePersons())
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    r.AddClose(p);
                }
            }
            foreach (Person p in father.GetClosePersons())
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    r.AddClose(p);
                }
            }

            foreach (Person p in father.GetHatedPersons())
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    r.AddHated(p);
                }
            }
            /*foreach (Person p in father.GetHatedPersons())
            {
                if (!GameObject.Chance((int)r.personalLoyalty * 25))
                {
                    r.AddHated(p);
                }
            }*/

            ExtensionInterface.call("CreateChildren", new Object[] { father.Scenario, r });

            return r;
        }

        public bool IsCloseTo(Person p)
        {
            return this.IsVeryCloseTo(p) || this.Closes(p);
        }

        public bool IsVeryCloseTo(Person p)
        {
            return this.Spouse == p || this.Brothers.GameObjects.Contains(p);
        }

        public PersonList AvailableVeryClosePersons
        {
            get
            {
                PersonList result = new PersonList();
                if (this.Spouse != null && this.Spouse.Status == PersonStatus.Normal && this.Spouse.BelongedFaction == this.BelongedFaction && this.Spouse.BelongedArchitecture != null && this.BelongedArchitecture != null
                            && (!base.Scenario.IsPlayer(this.BelongedFaction) || this.Spouse.BelongedArchitecture.BelongedSection == this.BelongedArchitecture.BelongedSection))
                {
                    result.Add(this.Spouse);
                }
                foreach (Person q in this.Brothers)
                {
                    if (q.Status == PersonStatus.Normal && q.BelongedFaction == this.BelongedFaction && this.BelongedArchitecture != null && q.BelongedArchitecture != null
                        && (!base.Scenario.IsPlayer(this.BelongedFaction) || q.BelongedArchitecture.BelongedSection == this.BelongedArchitecture.BelongedSection))
                    {
                        result.Add(q);
                    }
                }
                return result;
            }
        }

        public bool DontMoveMeUnlessIMust
        {
            get
            {
                return this.HasFollowingArmy || this.HasLeadingArmy || this.WaitForFeiZi != null ||
                        (this == this.BelongedFaction.Leader && this.LocationArchitecture.meifaxianhuaiyundefeiziliebiao().Count > 0);
            }
        }

        public bool HasCloseStrainTo(Person b)
        {
            if (this.Father == b) return true;
            if (this.Mother == b) return true;

            if (this.Father != null && b.Father == this.Father) return true;
            if (this.Mother != null && b.Mother == this.Mother) return true;

            if (b.Father == this) return true;
            if (b.Mother == this) return true;

            return false;
        }

        public bool HasStrainTo(Person b)
        {
            if (this.HasCloseStrainTo(b)) return true;

            if (this.Strain == b.Strain) return true;

            if (this.Mother != null)
            {
                
                if (this.Mother.Strain == b.Strain)
                {

                    return true;
                }
                        
                
            }

            if (b.Mother != null)
            {
               
                        if (b.Mother.Strain == this.Strain)
                        {
                            return true;
                        }
                
            }

            return false;
        }

        public bool isLegalFeiZi(Person b)
        {
            if (this == b) return false;

            if (this.Sex == b.Sex) return false;

            if ((b.Age < 16 || b.Age > 50) && GlobalVariables.PersonNaturalDeath) return false;

            if (this.HasStrainTo(b)) return false;

            return true;
        }

        public Person XuanZeMeiNv(Person nvren)
        {
            Person tookSpouse = null;

            nvren.LocationArchitecture.DecreaseFund(Parameters.NafeiCost);

            nvren.Status = PersonStatus.Princess;
            nvren.workKind = ArchitectureWorkKind.无;

            nvren.LocationTroop = null;
            nvren.TargetArchitecture = null;

            if (nvren.Spouse != null)
            {
                Person p = new Person();
                foreach (Person person in base.Scenario.Persons)
                {
                    if (person == nvren.Spouse)
                    {
                        p = person;
                        break;
                    }
                }

                if ((p != null) && p.ID != nvren.LocationArchitecture.BelongedFaction.LeaderID)
                {
                    if (p.Alive)
                    {
                        tookSpouse = p;
                        this.LoseReputationBy(0.05f);

                        p.AddHated(this.BelongedFaction.Leader);
                    }
                }
            }// end if (this.CurrentPerson.Spouse != -1)

            this.Scenario.YearTable.addBecomePrincessEntry(this.Scenario.Date, nvren, this);

            ExtensionInterface.call("TakeToHouGong", new Object[] { this.Scenario, this, nvren });

            return tookSpouse;
        }

        public void GoForHouGong(Person nvren)
        {
            if (this.LocationArchitecture != null && this.Status == PersonStatus.Normal)
            {
                int houGongDays = nvren.Glamour / 4 + GameObject.Random(6) + 10;
                if (houGongDays > 60)
                {
                    houGongDays = GameObject.Random(10) + 60;
                }
                if (!nvren.Hates(this) && GlobalVariables.hougongGetChildrenRate > 0 &&
                    this.NumberOfChildren < GlobalVariables.OfficerChildrenLimit && nvren.NumberOfChildren < GlobalVariables.OfficerChildrenLimit)
                {
                    float extraRate = 1;
                    if (this.Closes(nvren))
                    {
                        extraRate += 0.1f;
                    }
                    if (nvren.Closes(this))
                    {
                        extraRate += 0.1f;
                    }
                    if (nvren.Ideal == this.Ideal)
                    {
                        extraRate += 0.2f;
                    }
                    if (this.Spouse == nvren)
                    {
                        extraRate += 1.6f;
                    }
                    extraRate += nvren.GetRelation(this) * 0.0001f + this.GetRelation(nvren) * 0.0001f;
                    if (!base.Scenario.IsPlayer(this.BelongedFaction))
                    {
                        extraRate += Parameters.AIExtraPerson - 1;
                    }

                    float pregnantChance = GlobalVariables.hougongGetChildrenRate / 100.0f;
                    pregnantChance *= houGongDays * extraRate;
                    pregnantChance += this.pregnantChance + nvren.pregnantChance;

                    if (GameObject.Chance(Math.Max((int)pregnantChance, Parameters.MinPregnantProb))
                        && !nvren.huaiyun && !this.huaiyun && this.isLegalFeiZi(nvren) &&
                        (this.LocationArchitecture.BelongedFaction.Leader.meichushengdehaiziliebiao().Count - this.LocationArchitecture.yihuaiyundefeiziliebiao().Count > 0 || GlobalVariables.createChildren))
                    {
                        nvren.suoshurenwu = this.ID;
                        this.suoshurenwu = nvren.ID;
                        if (nvren.Sex)
                        {
                            nvren.huaiyun = true;
                            nvren.huaiyuntianshu = -GameObject.Random(houGongDays);
                        }
                        else
                        {
                            this.huaiyun = true;
                            this.huaiyuntianshu = -GameObject.Random(houGongDays);
                        }
                    }
                }

                if (!nvren.Hates(this) && !this.Hates(nvren))
                {
                    this.AdjustRelation(nvren, houGongDays / 30.0f, 0);
                    nvren.AdjustRelation(this, houGongDays / 30.0f, 0);
                }
               
                foreach (Person p in this.BelongedFaction.GetFeiziList())
                {
                    if (p == nvren) continue;
                    p.AdjustRelation(this, -houGongDays / 90.0f * (5 - p.PersonalLoyalty), -1);
                    p.AdjustRelation(nvren, -houGongDays / 90.0f * (5 - p.PersonalLoyalty), -1);
                }

                this.OutsideTask = OutsideTaskKind.后宮;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = houGongDays;
                this.Status = PersonStatus.Moving;
                this.TaskDays = this.ArrivingDays;
                ExtensionInterface.call("GoForHouGong", new Object[] { this.Scenario, this, nvren });
            }
        }

        public String FoundPregnantString
        {
            get
            {
                return faxianhuaiyun ? "○" : "×";
            }
        }

        public String OfficerString
        {
            get
            {
                if (this.ID >= 25000)
                {
                    return "○";
                }
                return "×";
            }
        }

        public int PregnantDayForShowing
        {
            get
            {
                return faxianhuaiyun ? (huaiyuntianshu < 30 ? 1 : huaiyuntianshu / 30) : 0;
            }
        }

        public bool HasFollowingArmy
        {
            get
            {
                if (this.LocationArchitecture != null)
                {
                    foreach (Military i in this.LocationArchitecture.Militaries)
                    {
                        if (i.FollowedLeader == this && !i.IsTransport)
                        {
                            return true;
                        }
                    }
                }
                else if (this.LocationTroop != null)
                {
                    if (this.LocationTroop.Army.FollowedLeader == this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasEffectiveLeadingArmy
        {
            get
            {
                if (this.LocationArchitecture != null)
                {
                    foreach (Military i in this.LocationArchitecture.Militaries)
                    {
                        if ((i.Leader == this && i.Experience > 10 && !i.IsTransport) || i.FollowedLeader == this)
                        {
                            return true;
                        }
                    }
                }
                else if (this.LocationTroop != null)
                {
                    if (this.LocationTroop.Army.Experience > 10 || this.LocationTroop.Army.FollowedLeader == this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasLeadingArmy
        {
            get
            {
                if (this.LocationArchitecture != null)
                {
                    foreach (Military i in this.LocationArchitecture.Militaries)
                    {
                        if ((i.Leader == this || i.FollowedLeader == this) && !i.IsTransport)
                        {
                            return true;
                        }
                    }
                }
                else if (this.LocationTroop != null)
                {
                    if (this.LocationTroop.Leader == this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsCivil()
        {
            if (this.BaseStrength > 70)
            {
                return false;
            }
            if (this.BaseIntelligence > 60 && this.BaseIntelligence - this.BaseStrength > 20)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsBeingTroopPerson
        {
            get
            {
                if (this.LocationArchitecture != null)
                {
                    foreach (Person p in this.LocationArchitecture.Persons)
                    {
                        if (p.preferredTroopPersons.GameObjects.Contains(this) && p.HasLeadingArmy)
                        {
                            return true;
                        }
                    }
                }
                else if (this.LocationTroop != null)
                {
                    if (this.LocationTroop.Army.Leader != this)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool TooTiredToBattle
        {
            get
            {
                return this.Tiredness > this.Braveness * 10 + 30 || this.InjureRate < Math.Max(0.3, 0.8 - this.Braveness * 0.05)
                    || this.Loyalty < 80;
            }
        }

        public int Identity()
        {
            if (this.ID == 7108)  //盗贼
            {
                return 0;
            }
            else if (this.BelongedFaction != null && this == this.BelongedFaction.Leader)  //君主
            {
                return 2;
            }
            else  //普通武将
            {
                return 1;
            }

        }

        public float RelationAbilityFactor
        {
            get
            {
                if (this.LocationTroop == null || this.LocationArchitecture != null) return 1f;

                float rate = 1f;
                foreach (Person p in this.LocationTroop.Persons)
                {
                    if (p == this) continue;
                    float r = 1.0f;
                    if (this.Brothers.GameObjects.Contains(p))
                    {
                        r = (float) ((Parameters.VeryCloseAbilityRate - 1) * Math.Sqrt((float)this.GetRelation(p) / Parameters.VeryCloseThreshold) + 1);
                    }
                    if (!this.Hates(p) && !p.Hates(this))
                    {
                        if (this.Father == p || this.Mother == p)
                        {
                            r = Parameters.CloseAbilityRate;
                        }
                        else if (this == p.Father || this == p.Mother)
                        {
                            r = Parameters.CloseAbilityRate;
                        }
                        else if (this.Father != null && this.Mother != null && p.Father != null && p.Mother != null &&
                          this.Father == p.Father && this.Mother == p.Mother)
                        {
                            r = Parameters.CloseAbilityRate;
                        }
                    }
                    if (r > rate)
                    {
                        rate = r;
                    }
                }
                return rate;
            }
        }

        public bool Closes(Person p)
        {
            return this.closePersons.GameObjects.Contains(p);
        }

        public bool Hates(Person p)
        {
            return this.hatedPersons.GameObjects.Contains(p);
        }

        public void AddHated(Person p)
        {
            if (p != null && p != this && !this.Hates(p))
            {
                this.hatedPersons.Add(p);
                this.EnsureRelationAtMost(p, Parameters.HateThreshold);
            }
            else if (p != null && p != this)
            {
                this.AdjustRelation(p, 0, Parameters.HateThreshold);
            }
        }

        public void AddClose(Person p)
        {
            if (p != null && p != this && !this.Closes(p))
            {
                this.closePersons.Add(p);
                this.EnsureRelationAtLeast(p, Parameters.CloseThreshold);
            }
        }

        public void RemoveClose(Person p)
        {
            this.closePersons.Remove(p);
            this.EnsureRelationAtMost(p, Parameters.CloseThreshold / 2);
        }

        public void RemoveHated(Person p)
        {
            this.hatedPersons.Remove(p);
            this.EnsureRelationAtLeast(p, Parameters.HateThreshold / 2);
        }

        public PersonList GetClosePersons()
        {
            PersonList pl = new PersonList();
            foreach (Person p in this.closePersons)
            {
                pl.Add(p);
            }
            return pl;
        }

        public PersonList GetHatedPersons()
        {
            PersonList pl = new PersonList();
            foreach (Person p in this.hatedPersons)
            {
                pl.Add(p);
            }
            return pl;
        }

        public Dictionary<Person, int> GetRelations()
        {
            if (!GlobalVariables.EnablePersonRelations) return new Dictionary<Person, int>();
            return new Dictionary<Person, int>(relations);
        }

        public int GetRelation(Person p)
        {
            if (!GlobalVariables.EnablePersonRelations) return 0;
            if (p == null) return 0;
            if (this.relations.ContainsKey(p))
            {
                return this.relations[p];
            }
            else
            {
                return 0;
            }
        }

        public void SetRelation(Person p, int val)
        {
            if (!GlobalVariables.EnablePersonRelations) return;
            if (this == p) return;
            if (this.relations.ContainsKey(p))
            {
                if (val == 0)
                {
                    this.relations.Remove(p);
                }
                else
                {
                    this.relations[p] = val;
                }
            }
            else
            {
                if (val != 0)
                {
                    this.relations.Add(p, val);
                }
            }
        }

        public void AdjustRelation(Person p, float factor, int adjust)
        {
            if (!GlobalVariables.EnablePersonRelations) return;
            if (this == p || p == null) return;
            int val;
            if (factor > 0)
            {
                val = (int)(Math.Max(0, 75 - Person.GetIdealOffset(this, p)) * 30 * factor / 75 + adjust);
            }
            else
            {
                val = (int)(Person.GetIdealOffset(this, p) * 30 * factor / 75 + adjust);
            }
            if (val != 0)
            {
                if (this.relations.ContainsKey(p))
                {
                    this.relations[p] += val;
                }
                else
                {
                    this.relations.Add(p, val);
                }
            }
            else
            {
                return;
            }

            if (this.relations.ContainsKey(p))
            {
                if (this.relations[p] <= Parameters.HateThreshold && !this.Hates(p))
                {
                    this.AddHated(p);
                }
                if (this.relations[p] >= Parameters.HateThreshold / 2 && this.Hates(p))
                {
                    this.RemoveHated(p);
                }
                if (this.relations[p] <= Parameters.CloseThreshold / 2 && this.Closes(p))
                {
                    this.RemoveClose(p);
                }
                if (this.relations[p] >= Parameters.CloseThreshold && !this.Closes(p))
                {
                    this.AddClose(p);
                }
            }
        }

        public void EnsureRelationAtMost(Person p, int val)
        {
            if (!GlobalVariables.EnablePersonRelations) return;
            if (this.relations.ContainsKey(p))
            {
                if (this.relations[p] > val)
                {
                    this.relations[p] = val;
                }
            }
            else
            {
                this.relations[p] = val;
            }
        }

        public void EnsureRelationAtLeast(Person p, int val)
        {
            if (!GlobalVariables.EnablePersonRelations) return;
            if (this.relations.ContainsKey(p))
            {
                if (this.relations[p] < val)
                {
                    this.relations[p] = val;
                }
            }
            else
            {
                this.relations[p] = val;
            }
        }

        public delegate void CreateSpouse(Person p, Person q);

        public delegate void CreateBrother(Person p, Person q);

        public delegate void CreateSister(Person p, Person q);

        private class PersonSpecialRelationComparer : Comparer<KeyValuePair<int, Person>>
        {
            public override int Compare(KeyValuePair<int, Person> x, KeyValuePair<int, Person> y)
            {
                return Comparer<int>.Default.Compare(x.Key, y.Key);
            }
        }

        public String PersonSpecialRelationString
        {
            get
            {
                String s = "";

                List<KeyValuePair<int, Person>> reverseRel = new List<KeyValuePair<int, Person>>();
                foreach (KeyValuePair<Person, int> pr in this.relations)
                {
                    reverseRel.Add(new KeyValuePair<int, Person>(pr.Value, pr.Key));
                }
                reverseRel.Sort(new PersonSpecialRelationComparer());

                int shown = 0;
                foreach (KeyValuePair<int, Person> pr in reverseRel)
                {
                    if (pr.Key < -100 && shown < 3)
                    {
                        if (pr.Value.Alive && pr.Value.Available)
                        {
                            s += pr.Value.Name + ":" + pr.Key + " ";
                            shown++;
                        }
                    }
                    else break;
                }

                shown = 0;
                reverseRel.Reverse();

                foreach (KeyValuePair<int, Person> pr in reverseRel)
                {
                    if (pr.Key > 100 && shown < 5)
                    {
                        if (pr.Value.Alive && pr.Value.Available)
                        {
                            s += pr.Value.Name + ":" + pr.Key + " ";
                            shown++;
                        }
                    }
                    else break;
                }

                return s;
            }
        }

        public String InjuryString
        {
            get
            {
                if (this.InjureRate >= 1)
                {
                    return "健康";
                }
                else if (this.InjureRate >= 0.7)
                {
                    return "轻伤";
                }
                else if (this.InjureRate >= 0.3)
                {
                    return "重伤";
                }
                else
                {
                    return "濒危";
                }
            }
        }

        public bool HasInfluenceKind(int id)
        {
            foreach (Influence i in base.Scenario.GameCommonData.AllInfluences.Influences.Values)
            {
                if (i.Kind.ID == id)
                {
                    foreach (ApplyingPerson j in i.appliedPerson)
                    {
                        if (j.person == this)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
      

        public float InfluenceKindValueByTreasure(int id)
        {
            float result = 0;
            foreach (Influence i in base.Scenario.GameCommonData.AllInfluences.Influences.Values)
            {
                if (i.Kind.ID == id)
                {
                    foreach (ApplyingPerson j in i.appliedPerson)
                    {
                        if (j.person == this && j.applier == Applier.Treasure)
                        {
                            result += i.Value;
                        }
                    }
                }
            }
            return result;
        }

    }
}

