namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.FactionDetail;
    using GameObjects.PersonDetail;
    using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.IO;
    using GameObjects.Conditions;

    public class Person : GameObject
    {
        public bool huaiyun = false;
        public bool shoudongsousuo = false;
        public int huaiyuntianshu = -1;


        public bool faxianhuaiyun = false;

        public int suoshurenwu = -1;
        public Architecture suozaijianzhu = null;
 
        private bool alive;
        private PersonAmbition ambition;
        private int arrivingDays;
        private bool available;
        private int availableLocation;
        private float baseImpactRate;
        public Captive BelongedCaptive;
        public GameObjects.Faction BelongedFaction = null;
        private PersonBornRegion bornRegion;
        private int braveness;
        private int brother = -1;
        private int bubingExperience;
        private string calledName;
        private int calmness;
        public int ChanceOfNoCapture;
        public CharacterKind Character;
        private int CharacterKindID;
        private List<int> closePersons = new List<int>();
        public Title CombatTitle;
        private int command;
        private int commandExperience;
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
        private int father = -1;
        private PersonForm form;
        private int generation;
        private string givenName;
        private int glamour;
        private int glamourExperience;
        private List<int> hatedPersons = new List<int>();
        private int ideal;
        public IdealTendencyKind IdealTendency;
        public bool ImmunityOfCaptive;
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
        public int InfluenceIncrementOfCommand;
        public int InfluenceIncrementOfGlamour;
        public int InfluenceIncrementOfIntelligence;
        public int InfluenceIncrementOfPolitics;
        public int InfluenceIncrementOfStrength;
        public float InfluenceRateOfBadForm;
        public float InfluenceRateOfCommand = 1f;
        public float InfluenceRateOfGlamour = 1f;
        public float InfluenceRateOfGoodForm;
        public float InfluenceRateOfIntelligence = 1f;
        public float InfluenceRateOfPolitics = 1f;
        public float InfluenceRateOfStrength = 1f;
        private int informationKindID = -1;
        private int intelligence;
        private int intelligenceExperience;
        private int internalExperience;
        public bool InternalNoFundNeeded;
        private bool leaderPossibility;
        public Architecture LocationArchitecture = null;
 
        public Troop LocationTroop = null;
        private int loyalty;
        public int MonthIncrementOfFactionReputation = 0;
        public int MonthIncrementOfTechniquePoint = 0;
        private int mother = -1;
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
        private int nubingExperience;
        private int oldFactionID = -1;
        public ArchitectureWorkKind OldWorkKind = ArchitectureWorkKind.无;
        private Point? outsideDestination;
        private OutsideTaskKind outsideTask;
        private PersonLoyalty personalLoyalty;
        public Title PersonalTitle;
        public Biography PersonBiography;
        public TextMessage PersonTextMessage;
        private int pictureIndex;
        private int politics;
        private int politicsExperience;
        private int prohibitedFactionID = -1;
        private int qibingExperience;
        private int qixieExperience;
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
        public float RateIncrementOfMoraleAbility;
        public float RateIncrementOfRecruitmentAbility;
        public float RateIncrementOfSearch;
        public float RateIncrementOfTechnologyAbility;
        public float RateIncrementOfTrainingAbility;
        private Military recruitmentMilitary;
        private int recruitmentMilitaryID;
        private int reputation;
        public bool RewardFinished;
        private int routCount;
        private int routedCount;
        private bool sex = false;
        private int shuijunExperience;
        public SkillTable Skills = new SkillTable();
        private int spouse = -1;
        private int strain;
        private int stratagemExperience;
        private PersonStrategyTendency strategyTendency;
        private int strength;
        private int strengthExperience;
        public Stunt StudyingStunt;
        public Title StudyingTitle;
        public GameObjectList StudyStuntList = new GameObjectList();
        public GameObjectList StudyTitleList = new GameObjectList();
        public StuntTable Stunts = new StuntTable();
        private string surName;
        private int tacticsExperience;
        public Architecture TargetArchitecture;
        private int taskDays;
        private Military trainingMilitary;
        private int trainingMilitaryID;
        public TreasureList Treasures = new TreasureList();
        private PersonValuationOnGovernment valuationOnGovernment;
        private ArchitectureWorkKind workKind = ArchitectureWorkKind.无;
        private int yearAvailable;
        private int yearBorn;
        private int yearDead;

        public event BeAwardedTreasure OnBeAwardedTreasure;

        public event BeConfiscatedTreasure OnBeConfiscatedTreasure;

        public event BeKilled OnBeKilled;

        public event ChangeLeader OnChangeLeader;

        public event ConvinceFailed OnConvinceFailed;

        public event ConvinceSuccess OnConvinceSuccess;

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

        public event ShowMessage OnShowMessage;

        public event SpyFailed OnSpyFailed;

        public event SpyFound OnSpyFound;

        public event SpySuccess OnSpySuccess;

        public event StudySkillFinished OnStudySkillFinished;

        public event StudyStuntFinished OnStudyStuntFinished;

        public event StudyTitleFinished OnStudyTitleFinished;

        public event TreasureFound OnTreasureFound;

        public void AddBubingExperience(int increment)
        {
            this.bubingExperience += increment;
        }

        public void AddCommandExperience(int increment)
        {
            if (increment > 0)
            {
                this.commandExperience += increment;
            }
        }

        public void AddGlamourExperience(int increment)
        {
            if (increment > 0)
            {
                this.glamourExperience += increment;
            }
        }

        public void AddIntelligenceExperience(int increment)
        {
            if (increment > 0)
            {
                this.intelligenceExperience += increment;
            }
        }

        public void AddInternalExperience(int increment)
        {
            this.internalExperience += increment;
        }

        public void AddNubingExperience(int increment)
        {
            this.nubingExperience += increment;
        }

        public void AddPoliticsExperience(int increment)
        {
            if (increment > 0)
            {
                this.politicsExperience += increment;
            }
        }

        public void AddQibingExperience(int increment)
        {
            this.qibingExperience += increment;
        }

        public void AddQixieExperience(int increment)
        {
            this.qixieExperience += increment;
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

        public void AddRoutCount()
        {
            this.routCount++;
        }

        public void AddRoutedCount()
        {
            this.routedCount++;
        }

        public void AddShuijunExperience(int increment)
        {
            this.shuijunExperience += increment;
        }

        public void AddStratagemExperience(int increment)
        {
            this.stratagemExperience += increment;
        }

        public void AddStrengthExperience(int increment)
        {
            if (increment > 0)
            {
                this.strengthExperience += increment;
            }
        }

        public bool AddTacticsExperience(int increment)
        {
            this.tacticsExperience += increment;
            return true;
        }

        public void AddTrainingExperience(int increment)
        {
            if (this.TrainingMilitary != null)
            {
                switch (this.TrainingMilitary.Kind.Type)
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

        public void ApplySkills()
        {
            foreach (Skill skill in this.Skills.Skills.Values)
            {
                skill.Influences.ApplyInfluence(this);
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

        public void ApplyTitles()
        {
            if (this.PersonalTitle != null)
            {
                this.PersonalTitle.Influences.ApplyInfluence(this);
            }
            if (this.CombatTitle != null)
            {
                this.CombatTitle.Influences.ApplyInfluence(this);
            }
        }

        public void ApplyTreasures()
        {
            foreach (Treasure treasure in this.Treasures)
            {
                treasure.Influences.ApplyInfluence(this);
            }
        }

        public void AwardedTreasure(Treasure t)
        {
            this.ReceiveTreasure(t);
            if (this.Loyalty <= 100)
            {
                if (this.OnBeAwardedTreasure != null)
                {
                    this.OnBeAwardedTreasure(this, t);
                }
                this.IncreaseLoyalty(t.Worth);
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
                base.Scenario.PreparedAvailablePersons.Add(this);
                return true;
            }
            return false;
        }

        public void ChangeFaction(GameObjects.Faction faction)
        {
            if (this.BelongedFaction != null)
            {
                if (this.LocationTroop != null)
                {
                }
                this.BelongedFaction.RemovePerson(this);
            }
            faction.AddPerson(this);
            this.InitialLoyalty();
        }

        public static int ChanlengeWinningChance(Person source, Person destination)
        {
            int num = 0;
            if (source.Strength >= destination.Strength)
            {
                num = ((50 + ((int) Math.Round(Math.Pow((double) (source.Strength - destination.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
            }
            else
            {
                num = ((50 - ((int) Math.Round(Math.Pow((double) (destination.Strength - source.Strength), 2.0), 3))) + source.IncrementOfChallengeWinningChance) - destination.IncrementOfChallengeWinningChance;
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
                        if (c.ID == this.ID)
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

        public  void ToDeath()
        {


                Architecture locationArchitecture = this.LocationArchitecture;
                GameObjects.Faction belongedFaction = this.BelongedFaction;
                this.Alive = false;  //死亡
                if (this.OnDeath != null)
                {
                    this.OnDeath(this, locationArchitecture);
                }
                if (belongedFaction == null)
                {
                    if (locationArchitecture != null)
                    {
                        locationArchitecture.RemoveNoFactionPerson(this);
                    }
                    base.Scenario.AvailablePersons.Remove(this);
                    base.Scenario.Persons.Remove(this);
                }
                else if (this == belongedFaction.Leader)
                {
                    string name = belongedFaction.Name;
                    GameObjects.Faction faction2 = belongedFaction.ChangeLeaderAfterLeaderDeath();
                    if (faction2 != null)
                    {
                        if (belongedFaction == faction2)
                        {
                            bool changeName = false;
                            if ((name == this.Name) && (belongedFaction.Leader.Ambition >= PersonAmbition.普通))
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
                        if (locationArchitecture != null)
                        {
                            locationArchitecture.RemovePerson(this);
                        }
                        foreach (Architecture architecture2 in belongedFaction.Architectures.GetList())
                        {
                            architecture2.ResetFaction(null);
                        }
                        belongedFaction.RemovePerson(this);
                        belongedFaction.Destroy();
                        base.Scenario.AvailablePersons.Remove(this);
                        base.Scenario.Persons.Remove(this);
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
                    if (locationArchitecture != null)
                    {
                        locationArchitecture.RemovePerson(this);
                    }
                    belongedFaction.RemovePerson(this);
                    base.Scenario.AvailablePersons.Remove(this);
                    base.Scenario.Persons.Remove(this);
                }
        }

        private void CheckDeath()
        {


            if ((GlobalVariables.PersonNaturalDeath && ((this.LocationArchitecture != null) && !this.IsCaptive)) && (this.alive && ((((((this.DeadReason == PersonDeadReason.自然死亡) && (this.YearDead <= base.Scenario.Date.Year)) && (GameObject.Random(base.Scenario.Date.LeftDays * ((1 + this.YearDead) - base.Scenario.Date.Year)) == 0)) || (((this.DeadReason == PersonDeadReason.被杀死) && (this.Age >= 80)) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.郁郁而终) && (this.YearDead <= base.Scenario.Date.Year)) && (((this.Age >= 80) || (this.BelongedFaction == null)) || ((this.BelongedFaction.Leader != this) || (this.BelongedFaction.ArchitectureTotalSize < 8)))) && (GameObject.Random(90) == 0))) || ((((this.DeadReason == PersonDeadReason.操劳过度) && (this.YearDead <= base.Scenario.Date.Year)) && ((this.Age >= 80) || ((((((((this.InternalExperience + this.TacticsExperience) + this.StratagemExperience) + this.BubingExperience) + this.NubingExperience) + this.QibingExperience) + this.QibingExperience) + this.ShuijunExperience) > 0x7530))) && (GameObject.Random(90) == 0)))))
            {
                this.ToDeath();
            }
        }

        public void ClearInfluence()
        {
            this.InternalNoFundNeeded = false;
            this.IncrementOfAgricultureAbility = 0;
            this.RateIncrementOfAgricultureAbility = 0f;
            this.MultipleOfAgricultureReputation = 1;
            this.MultipleOfAgricultureTechniquePoint = 1;
            this.IncrementOfCommerceAbility = 0;
            this.RateIncrementOfCommerceAbility = 0f;
            this.MultipleOfCommerceReputation = 1;
            this.MultipleOfCommerceTechniquePoint = 1;
            this.IncrementOfTechnologyAbility = 0;
            this.RateIncrementOfTechnologyAbility = 0f;
            this.MultipleOfTechnologyReputation = 1;
            this.MultipleOfTechnologyTechniquePoint = 1;
            this.IncrementOfDominationAbility = 0;
            this.RateIncrementOfDominationAbility = 0f;
            this.MultipleOfDominationReputation = 1;
            this.MultipleOfDominationTechniquePoint = 1;
            this.IncrementOfMoraleAbility = 0;
            this.RateIncrementOfMoraleAbility = 0f;
            this.MultipleOfMoraleReputation = 1;
            this.MultipleOfMoraleTechniquePoint = 1;
            this.IncrementOfEnduranceAbility = 0;
            this.RateIncrementOfEnduranceAbility = 0f;
            this.MultipleOfEnduranceReputation = 1;
            this.MultipleOfEnduranceTechniquePoint = 1;
            this.IncrementOfTrainingAbility = 0;
            this.RateIncrementOfTrainingAbility = 0f;
            this.MultipleOfTrainingReputation = 1;
            this.MultipleOfTrainingTechniquePoint = 1;
            this.IncrementOfRecruitmentAbility = 0;
            this.RateIncrementOfRecruitmentAbility = 0f;
            this.MultipleOfRecruitmentReputation = 1;
            this.MultipleOfRecruitmentTechniquePoint = 1;
            this.MultipleOfTacticsReputation = 1;
            this.MultipleOfTacticsTechniquePoint = 1;
            this.InevitableSuccessOfConvince = false;
            this.RateIncrementOfConvince = 0f;
            this.RadiusIncrementOfInformation = 0;
            this.InevitableSuccessOfSpy = false;
            this.IncrementOfSpyDays = 0;
            this.InevitableSuccessOfDestroy = false;
            this.RateIncrementOfDestroy = 0f;
            this.InevitableSuccessOfInstigate = false;
            this.RateIncrementOfInstigate = 0f;
            this.InevitableSuccessOfGossip = false;
            this.RateIncrementOfGossip = 0f;
            this.InevitableSuccessOfSearch = false;
            this.RateIncrementOfSearch = 0f;
            this.ChanceOfNoCapture = 0;
            this.DayRateIncrementOfInternal = 0f;
            this.DayLocationLoyaltyNoChange = false;
            this.DayAvoidInfluenceByBattle = false;
            this.DayLearnTitleDay = Parameters.LearnTitleDays;
            this.DayAvoidPopulationEscape = false;
            this.DayAvoidInternalDecrementOnBattle = false;
            this.MonthIncrementOfTechniquePoint = 0;
            this.MonthIncrementOfFactionReputation = 0;
        }

        public void ConfiscatedTreasure(Treasure t)
        {
            this.LoseTreasure(t);
            if (this.Loyalty <= 100)
            {
                if (this.OnBeConfiscatedTreasure != null)
                {
                    this.OnBeConfiscatedTreasure(this, t);
                }
                this.DecreaseLoyalty(t.Worth * 2);
                if (GameObject.Random(this.Loyalty) <= GameObject.Random(10))
                {
                    this.LeaveToNoFaction();
                }
            }
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

        public void DayEvent()
        {
            this.CheckDeath();
            if (this.Alive)
            {
                this.LeaveFaction();
                this.NoFactionMove();
                this.LoyaltyChange();
                this.ProgressArrivingDays();
                this.huaiyunshijian();

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
                    this.faxianhuaiyun = true;
                    this.Scenario.GameScreen.faxianhuaiyun(this);
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
                        this.suoshurenwu = this.FeiZiLocationArchitecture.BelongedFaction.LeaderID;
                    }
                    haizifuqin = this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person;

                    PersonList origChildren = haizifuqin.meichushengdehaiziliebiao();
                    if (origChildren.Count > 0)
                    {
                        haizi = origChildren[0] as Person;
                    }
                    else
                    {
                        haizi = this.createChildren(this.Scenario.Persons.GetGameObject(this.suoshurenwu) as Person, this);
                    }

                    haizifuqin.TextResultString = haizi.Name;

                    base.Scenario.GameScreen.xiaohaichusheng(haizifuqin);
                    base.Scenario.haizichusheng(haizi, this);

                    this.suoshurenwu = -1;
                    haizifuqin.suoshurenwu = -1;

                }
            }
        }

        public int NumberOfChildren
        {
            get
            {
                int cnt = 0;
                foreach (Person p in base.Scenario.Persons)
                {
                    if ((p.Father == this.ID || p.Mother == this.ID) && p.Available)
                    {
                        cnt++;
                    }
                }
                return cnt;
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

        public void DoConvince()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.ConvincingPerson != null)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.OutsideDestination.Value);
                if ((architectureByPosition != null) && ((architectureByPosition.BelongedFaction != null) && (this.ConvincingPerson.IsCaptive || (architectureByPosition.BelongedFaction != this.BelongedFaction))))
                {
                    if ((((this.ConvincingPerson.IsCaptive && architectureByPosition.IsCaptiveInArchitecture(this.ConvincingPerson.BelongedCaptive)) || (this.ConvincingPerson.LocationArchitecture == architectureByPosition)) && (((this.ConvincingPerson.BelongedFaction != null) && (this.BelongedFaction != this.ConvincingPerson.BelongedFaction)) && ((this.ConvincingPerson != this.ConvincingPerson.BelongedFaction.Leader) && (this.ConvincingPerson.Loyalty < 100)))) && (GameObject.Random((this.ConvinceAbility - (this.ConvincingPerson.Loyalty * 2)) - ((int)this.ConvincingPerson.PersonalLoyalty *(int) ((PersonLoyalty) 0x19))) > this.ConvincingPerson.Loyalty))
                    {
                        GameObjects.Faction belongedFaction = this.ConvincingPerson.BelongedFaction;
                        base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.ConvincingPerson.BelongedFaction.ID, -10);
                        bool flag = false;
                        if (this.ConvincingPerson.IsCaptive)
                        {
                            flag = true;
                            this.ConvincingPerson.BelongedCaptive.BelongedFaction.RemoveCaptive(this.ConvincingPerson.BelongedCaptive);
                            this.ConvincingPerson.BelongedCaptive.CaptiveFaction.RemoveSelfCaptive(this.ConvincingPerson.BelongedCaptive);
                            this.ConvincingPerson.BelongedCaptive.LocationArchitecture.RemoveCaptive(this.ConvincingPerson.BelongedCaptive);
                            base.Scenario.Captives.Remove(this.ConvincingPerson.BelongedCaptive);
                            this.ConvincingPerson.BelongedCaptive = null;
                        }
                        this.ConvincingPerson.ChangeFaction(this.BelongedFaction);
                        this.ConvincingPerson.MoveToArchitecture(this.TargetArchitecture);
                        if (!(flag || (this.ConvincingPerson.LocationArchitecture == null)))
                        {
                            this.ConvincingPerson.LocationArchitecture.RemovePerson(this.ConvincingPerson);
                        }
                        this.AddGlamourExperience(40);
                        this.IncreaseReputation(40);
                        this.BelongedFaction.IncreaseReputation(20 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((20 * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (this.OnConvinceSuccess != null)
                        {
                            this.OnConvinceSuccess(this, this.ConvincingPerson, belongedFaction);
                        }
                    }
                    else if (this.OnConvinceFailed != null)
                    {
                        this.OnConvinceFailed(this, this.ConvincingPerson);
                    }
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
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.AddStrengthExperience(increment / 2);
                        this.AddCommandExperience(increment / 2);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
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
                    }
                    else if (this.OnDestroyFailed != null)
                    {
                        this.OnDestroyFailed(this, architectureByPosition);
                    }
                }
                else if (this.OnDestroyFailed != null)
                {
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
                        this.AddTacticsExperience(20);
                        this.AddPoliticsExperience(10);
                        this.AddGlamourExperience(10);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (architectureByPosition.BelongedFaction != null)
                        {
                            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architectureByPosition.BelongedFaction.ID, -5);
                        }
                        if (this.OnGossipSuccess != null)
                        {
                            this.OnGossipSuccess(this, architectureByPosition);
                        }
                    }
                    else if (this.OnGossipFailed != null)
                    {
                        this.OnGossipFailed(this, architectureByPosition);
                    }
                }
                else if (this.OnGossipFailed != null)
                {
                    this.OnGossipFailed(this, architectureByPosition);
                }
            }
        }

        public void DoInformation()
        {
            if (!base.Scenario.IsPlayer(this.BelongedFaction) || (this.InformationAbility >90 && GameObject.Random(280) < this.InformationAbility))
                    {
                        Information information = new Information();
                        information.Scenario = base.Scenario;
                        information.ID = base.Scenario.Informations.GetFreeGameObjectID();
                        information.Level = this.CurrentInformationKind.Level;
                        information.Radius = this.CurrentInformationKind.Radius + this.RadiusIncrementOfInformation;
                        information.Position = this.OutsideDestination.Value;
                        information.Oblique = this.CurrentInformationKind.Oblique;
                        information.DaysLeft = this.CurrentInformationKind.Days;
                        base.Scenario.Informations.AddInformation(information);
                        this.BelongedFaction.AddInformation(information);
                        information.Apply();

                        this.CurrentInformationKind = null;
                        this.OutsideTask = OutsideTaskKind.无;

                        int increment = (int)(((int)information.Level - 2) * (information.Radius + (information.Oblique ? 1 : 0)));
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (this.OnInformationObtained != null)
                        {
                            this.OnInformationObtained(this, information);
                        }
 
                    }
            else
                    {
                        int increment = (int)(((int)this.CurrentInformationKind.Level - 2) * (this.CurrentInformationKind.Radius + (this.CurrentInformationKind.Oblique? 1 : 0)));
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.CurrentInformationKind = null;
                        this.OutsideTask = OutsideTaskKind.无;
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
                        this.AddTacticsExperience(increment * 2);
                        this.AddIntelligenceExperience(increment);
                        this.AddGlamourExperience(increment);
                        this.IncreaseReputation(increment * 2);
                        this.BelongedFaction.IncreaseReputation(increment * this.MultipleOfTacticsReputation);
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
                    }
                    else if (this.OnInstigateFailed != null)
                    {
                        this.OnInstigateFailed(this, architectureByPosition);
                    }
                }
                else if (this.OnInstigateFailed != null)
                {
                    this.OnInstigateFailed(this, architectureByPosition);
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

                case OutsideTaskKind.间谍:
                    this.DoSpy();
                    break;

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
                    pack.Result = (SearchResult) (GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length - 1) + 1);
                }
                else
                {
                    pack.Result = (SearchResult) GameObject.Random(Enum.GetNames(typeof(SearchResult)).Length);
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

                    case SearchResult.间谍:
                        flag = this.DoSearchSpy(pack);
                        flag2 = flag;
                        break;

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
                    this.AddTacticsExperience(20);
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
            }
            return false;
        }

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
                            this.ReceiveTreasure(treasure);
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
                        this.AddTacticsExperience(20);
                        this.AddIntelligenceExperience(10);
                        this.AddStrengthExperience(5);
                        this.AddGlamourExperience(5);
                        this.IncreaseReputation(20);
                        this.BelongedFaction.IncreaseReputation(10 * this.MultipleOfTacticsReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((10 * this.MultipleOfTacticsTechniquePoint) * 100);
                        if (this.OnSpySuccess != null)
                        {
                            this.OnSpySuccess(this, architectureByPosition);
                        }
                    }
                    else if (this.OnSpyFailed != null)
                    {
                        this.OnSpyFailed(this, architectureByPosition);
                    }
                }
                else if (this.OnSpyFailed != null)
                {
                    this.OnSpyFailed(this, architectureByPosition);
                }
            }
        }

        public void DoStudySkill()
        {
            this.OutsideTask = OutsideTaskKind.无;
            int num = 0;
            string skillString = "";
            foreach (Skill skill in base.Scenario.GameCommonData.AllSkills.Skills.Values)
            {
                if (((this.Skills.GetSkill(skill.ID) == null) && skill.CanLearn(this)) && (GameObject.Random((skill.Level * 2) + 8) >= ((skill.Level + num) * 2)))
                {
                    this.Skills.AddSkill(skill);
                    skill.Influences.ApplyInfluence(this);
                    skillString = skillString + "•" + skill.Name;
                    num++;
                }
            }
            if (this.OnStudySkillFinished != null)
            {
                this.OnStudySkillFinished(this, skillString, num > 0);
            }
        }

        public void DoStudyStunt()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingStunt != null)
            {
                if (GameObject.Chance(0x4b))
                {
                    this.Stunts.AddStunt(this.StudyingStunt);
                    if (this.OnStudyStuntFinished != null)
                    {
                        this.OnStudyStuntFinished(this, this.StudyingStunt, true);
                    }
                }
                else if (this.OnStudyStuntFinished != null)
                {
                    this.OnStudyStuntFinished(this, this.StudyingStunt, false);
                }
                this.StudyingStunt = null;
            }
        }

        public void DoStudyTitle()
        {
            this.OutsideTask = OutsideTaskKind.无;
            if (this.StudyingTitle != null)
            {
                bool flag = false;
                if (GameObject.Random((this.StudyingTitle.Level * 2) + 8) >= (this.StudyingTitle.Level * 2))
                {
                    if (this.StudyingTitle.Kind == TitleKind.个人)
                    {
                        if (this.PersonalTitle != null)
                        {
                            this.ClearInfluence();
                            flag = true;
                        }
                        this.PersonalTitle = this.StudyingTitle;
                    }
                    else
                    {
                        if (this.StudyingTitle.Kind != TitleKind.战斗)
                        {
                            return;
                        }
                        if (this.CombatTitle != null)
                        {
                            this.ClearInfluence();
                            flag = true;
                        }
                        this.CombatTitle = this.StudyingTitle;
                    }
                    if (flag)
                    {
                        this.ApplyTitles();
                        this.ApplySkills();
                    }
                    if (this.OnStudyTitleFinished != null)
                    {
                        this.OnStudyTitleFinished(this, this.StudyingTitle, true);
                    }
                }
                else if (this.OnStudyTitleFinished != null)
                {
                    this.OnStudyTitleFinished(this, this.StudyingTitle, false);
                }
                this.StudyingTitle = null;
            }
        }

        public GameObjectList GetCombatTitleInfluenceList()
        {
            if (this.CombatTitle == null)
            {
                return null;
            }
            return this.CombatTitle.GetInfluenceList();
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
            int num = Math.Abs((int) (p1.Ideal - p2.Ideal));
            if (num > 0x4b)
            {
                num = 150 - num;
            }
            return num;
        }

        public GameObjectList GetPersonalTitleInfluenceList()
        {
            if (this.PersonalTitle == null)
            {
                return null;
            }
            return this.PersonalTitle.GetInfluenceList();
        }

        public GameObjectList GetSkillList()
        {
            return this.Skills.GetSkillList();
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
            return this.StudyStuntList;
        }

        public GameObjectList GetStudyTitleList()
        {
            this.StudyTitleList.Clear();
            foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
            {
                if (((title != this.PersonalTitle) && (title != this.CombatTitle)) && title.CanLearn(this))
                {
                    this.StudyTitleList.Add(title);
                }
            }
            return this.StudyTitleList;
        }

        public GameObjectList GetStuntList()
        {
            return this.Stunts.GetStuntList();
        }

        public int GetWorkAbility(ArchitectureWorkKind workKind)
        {
            switch (workKind)
            {
                case ArchitectureWorkKind.无:
                    return 0;

                case ArchitectureWorkKind.赈灾 :
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
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.说服;
                this.ConvincingPerson = person;
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.ConvincePersonFund);
                this.GoToDestinationAndReturn(this.OutsideDestination.Value);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
            }
        }

        public void GoForDestroy(Point position)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.破坏;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.DestroyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
            }
        }

        public void GoForGossip(Point position)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.流言;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.GossipArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
            }
        }

        public void GoForInformation(Point position)
        {
            this.OutsideTask = OutsideTaskKind.情报;
            this.OutsideDestination = new Point?(position);
            this.LocationArchitecture.InformationCoolDown += this.CurrentInformationKind.CoolDown;
            this.LocationArchitecture.DecreaseFund(this.CurrentInformationKind.CostFund);
            this.GoToDestinationAndReturn(position);
            this.TaskDays = this.ArrivingDays;
        }

        public void GoForInstigate(Point position)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.煽动;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.InstigateArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
            }
        }

        public void GoForSearch()
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.搜索;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = 10;
                this.TargetArchitecture.RemovePerson(this);
                this.TargetArchitecture.MovingPersons.Add(this);
                this.TaskDays = this.ArrivingDays;
            }
        }

        public void shoudongjinxingsousuo()
        {
            this.shoudongsousuo = true;
            this.GoForSearch();
        }

        public void GoForSpy(Point position)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.间谍;
                this.OutsideDestination = new Point?(position);
                this.LocationArchitecture.DecreaseFund(this.LocationArchitecture.SpyArchitectureFund);
                this.GoToDestinationAndReturn(position);
                this.TaskDays = (this.ArrivingDays + 1) / 2;
            }
        }

        public void GoForStudySkill()
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.技能;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Parameters.LearnSkillDays;
                this.TargetArchitecture.RemovePerson(this);
                this.TargetArchitecture.MovingPersons.Add(this);
                this.TaskDays = this.ArrivingDays;
            }
        }

        public void GoForStudyStunt(Stunt desStunt)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.特技;
                this.StudyingStunt = desStunt;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = Parameters.LearnStuntDays;
                this.TargetArchitecture.RemovePerson(this);
                this.TargetArchitecture.MovingPersons.Add(this);
                this.TaskDays = this.ArrivingDays;
            }
        }

        public void GoForStudyTitle(Title desTitle)
        {
            if (this.LocationArchitecture != null)
            {
                this.OutsideTask = OutsideTaskKind.称号;
                this.StudyingTitle = desTitle;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = this.LocationArchitecture.DayLearnTitleDay;
                this.TargetArchitecture.RemovePerson(this);
                this.TargetArchitecture.MovingPersons.Add(this);
                this.TaskDays = this.ArrivingDays;
            }
        }

        private void GoToDestinationAndReturn(Point destination)
        {
            this.TargetArchitecture = this.LocationArchitecture;
            this.ArrivingDays = base.Scenario.GetReturnDays(destination, this.TargetArchitecture.ArchitectureArea);
            this.TargetArchitecture.RemovePerson(this);
            this.TargetArchitecture.MovingPersons.Add(this);
        }

        private void HandleSpyMessage(SpyMessage sm)
        {
            if (sm.Kind == SpyMessageKind.NewTroop)
            {
            }
        }

        public int IncreaseLoyalty(int increment)
        {
            if (increment > (100 - this.Loyalty))
            {
                increment = 100 - this.Loyalty;
            }
            if (increment > 0)
            {
                this.loyalty += increment;
                return increment;
            }
            return 0;
        }

        public bool IncreaseReputation(int increment)
        {
            this.reputation += increment;
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
            int num = (60 + (10 * (int)this.PersonalLoyalty)) - (GetIdealOffset(this, this.BelongedFaction.Leader) / 5);
            if (this.Ideal == this.BelongedFaction.Leader.Ideal)
            {
                num += 20;
            }
            if (this.Father == this.BelongedFaction.Leader.ID || this.Mother == this.BelongedFaction.Leader.ID)
            {
                num += 20;
            }
            if (this.Spouse == this.BelongedFaction.Leader.ID || (this.Brother == this.BelongedFaction.Leader.Brother && this.Brother >= 0))
            {
                num += 50;
            }
            this.Loyalty = num;
        }

        public bool IsHirable(GameObjects.Faction faction)
        {
            if (faction.Leader != null)
            {
                if (this.ProhibitedFactionID == faction.Leader.ID)
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

        public void Killed()
        {
            if (((this.LocationArchitecture != null) && !this.IsCaptive) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.LocationArchitecture);
                }
                if ((this.LocationArchitecture.BelongedFaction != null) && (this.LocationArchitecture.BelongedFaction.Leader != null))
                {
                    foreach (Person person in base.Scenario.AvailablePersons)
                    {
                        if ((person != this) && (((person.Father >= 0) && (person.Father == base.ID)) || ((person.Brother >= 0) && (person.Brother == this.Brother))))
                        {
                            person.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.Leader.ID;
                        }
                    }
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.LocationArchitecture.RemoveNoFactionPerson(this);
                base.Scenario.AvailablePersons.Remove(this);
            }
            else if ((this.TargetArchitecture != null) && (this.BelongedFaction == null))
            {
                if (this.OnBeKilled != null)
                {
                    this.OnBeKilled(this, this.TargetArchitecture);
                }
                if ((this.TargetArchitecture.BelongedFaction != null) && (this.TargetArchitecture.BelongedFaction.Leader != null))
                {
                    foreach (Person person in base.Scenario.AvailablePersons)
                    {
                        if ((person != this) && (((person.Father >= 0) && (person.Father == base.ID)) || ((person.Brother >= 0) && (person.Brother == this.Brother))))
                        {
                            person.ProhibitedFactionID = this.TargetArchitecture.BelongedFaction.Leader.ID;
                        }
                    }
                }
                this.Alive = false;
                this.ArrivingDays = 0;
                this.TargetArchitecture.NoFactionMovingPersons.Remove(this);
                base.Scenario.AvailablePersons.Remove(this);
            }
        }

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
                                this.LocationArchitecture.RemoveNoFactionPerson(this);
                            }
                        }
                    }
                }
            }
        }

        private void LeaveToNoFaction()
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            locationArchitecture.RemovePerson(this);
            this.BelongedFaction.RemovePerson(this);
            locationArchitecture.AddNoFactionPerson(this);
            if (this.OnLeave != null)
            {
                this.OnLeave(this, locationArchitecture);
            }
        }

        public  void BeLeaveToNoFaction()
        {
            Architecture locationArchitecture = this.LocationArchitecture;
            locationArchitecture.RemovePerson(this);
            this.BelongedFaction.RemovePerson(this);
            locationArchitecture.AddNoFactionPerson(this);
            this.ProhibitedFactionID = locationArchitecture.BelongedFaction.ID;
        }

        public void LoseTreasure(Treasure t)
        {
            this.Treasures.Remove(t);
            t.Influences.PurifyInfluence(this);
            t.BelongedPerson = null;
        }

        public void LoseTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Remove(treasure);
                treasure.Influences.PurifyInfluence(this);
                treasure.BelongedPerson = null;
            }
        }

        private void LoyaltyChange()
        {
            if ((((this.BelongedFaction != null) && (((this.LocationArchitecture == null) || this.IsCaptive) || !this.LocationArchitecture.DayLocationLoyaltyNoChange)) && ((((this.LocationTroop == null) || this.IsCaptive) || !this.LocationTroop.DayLocationLoyaltyNoChange) && (GameObject.Random(30) <= 0))) && (this.Loyalty <= 100))
            {
                int idealOffset = GetIdealOffset(this, this.BelongedFaction.Leader);
                if (idealOffset > 0)
                {
                    int decrement = ((int) (this.Ambition - ((PersonAmbition) ((int) this.PersonalLoyalty)))) + (idealOffset / 10);
                    if (!(!GlobalVariables.IdealTendencyValid || this.IsHirable(this.BelongedFaction)))
                    {
                        decrement += 2;
                    }
                    if (this.IsCaptive)
                    {
                        decrement *= 2;
                    }
                    if (decrement > 0)
                    {
                        this.DecreaseLoyalty(decrement);
                    }
                    else if (decrement < 0)
                    {
                        this.IncreaseLoyalty(Math.Abs(decrement));
                    }
                }
            }
        }

        private bool MeetAvailableCondition()
        {
            foreach (Faction faction in this.Scenario.Factions)
            {
                if (this.Scenario.IsPlayer(faction) && this.Father == faction.LeaderID)
                {
                    return false;
                }
            }
            return ((((this.Alive && !this.Available) && (this.YearAvailable <= base.Scenario.Date.Year)) && ((((GlobalVariables.CommonPersonAvailable && (base.ID >= 0)) && (base.ID <= 6999)) || ((GlobalVariables.AdditionalPersonAvailable && (base.ID >= 8000)) && (base.ID <= 8999))) || ((GlobalVariables.PlayerPersonAvailable && (base.ID >= 9000)) && (base.ID <= 9999)))) && !base.Scenario.PreparedAvailablePersons.HasGameObject(this));
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
        }

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
                    this.TargetArchitecture.MovingPersons.Add(this);
                }
                else
                {
                    this.TargetArchitecture.NoFactionMovingPersons.Add(this);
                }
            }
        }

        public void NoFactionMove()
        {
            if (((((this.BelongedFaction == null) && (this.ArrivingDays == 0)) && (this.LocationArchitecture != null)) && !this.IsCaptive) && GameObject.Chance((2 + (int) this.Ambition) + (this.LeaderPossibility ? 10 : 0)))
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
                            this.LocationArchitecture.RemoveNoFactionPerson(this);
                        }
                    }
                    else if (this.LeaderPossibility)
                    {
                        GameObjectList list2 = new GameObjectList();
                        foreach (Architecture architecture in this.LocationArchitecture.GetClosestArchitectures(40))
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
                            this.LocationArchitecture.RemoveNoFactionPerson(this);
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
                        this.LocationArchitecture.RemoveNoFactionPerson(this);
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
            if (this.TaskDays > 0)
            {
                this.TaskDays--;
                if ((this.TaskDays == 0) && (this.OutsideTask != OutsideTaskKind.无))
                {
                    this.DoOutsideTask();
                }
            }
            if (this.ArrivingDays > 0)
            {
                this.ArrivingDays--;
                if ((this.ArrivingDays == 0) && (this.TargetArchitecture != null))
                {
                    if (this.BelongedFaction != null)
                    {
                        if (this.TargetArchitecture.BelongedFaction == this.BelongedFaction)
                        {
                            this.TargetArchitecture.AddPerson(this);
                            this.TargetArchitecture.MovingPersons.Remove(this);

                            if (this.Scenario.IsCurrentPlayer(this.BelongedFaction) && this.TargetArchitecture.TodayPersonArriveNote==false )
                            {
                                this.TargetArchitecture.TodayPersonArriveNote = true;
                                this.Scenario.GameScreen.renwudaodatishi(this, this.TargetArchitecture);
                            }
                            this.TargetArchitecture = null;
                        }
                        else if (this.BelongedFaction.Capital != null)
                        {
                            this.MoveToArchitecture(this.BelongedFaction.Capital);
                        }
                        else
                        {
                            this.TargetArchitecture.NoFactionMovingPersons.Remove(this);
                            this.TargetArchitecture.AddNoFactionPerson(this);
                            this.TargetArchitecture = null;
                        }
                    }
                    else
                    {
                        this.TargetArchitecture.NoFactionMovingPersons.Remove(this);
                        this.TargetArchitecture.AddNoFactionPerson(this);
                        this.TargetArchitecture = null;
                    }
                }
            }
        }

        public void ReceiveTreasure(Treasure t)
        {
            this.Treasures.Add(t);
            t.BelongedPerson = this;
            t.Influences.ApplyInfluence(this);
        }

        public void ReceiveTreasureList(TreasureList list)
        {
            foreach (Treasure treasure in list)
            {
                this.Treasures.Add(treasure);
                treasure.BelongedPerson = this;
                treasure.Influences.ApplyInfluence(this);
            }
        }

        public void SeasonEvent()
        {
        }

        private void SetDayInfluence()
        {
            this.RewardFinished = false;
            if (!this.IsCaptive)
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
                        this.LocationTroop.DayLocationLoyaltyNoChange = true;
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

        public void ShowPersonMessage(PersonMessage personMessage)
        {
            bool flag = true;
            if ((this.BelongedFaction != null) && (personMessage is SpyMessage))
            {
                SpyMessage sm = personMessage as SpyMessage;
                Point key = new Point(sm.MessageArchitecture.ID, (int) sm.Kind);
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

        public void StopRecruitment()
        {
            if (this.RecruitmentMilitary != null)
            {
                this.RecruitmentMilitary.RecruitmentPerson = null;
                this.RecruitmentMilitary.RecruitmentPersonID = -1;
                this.RecruitmentMilitary = null;
                this.RecruitmentMilitaryID = -1;
            }
        }

        public void StopTraining()
        {
            if (this.TrainingMilitary != null)
            {
                this.TrainingMilitary.TrainingPerson = null;
                this.TrainingMilitary.TrainingPersonID = -1;
                this.TrainingMilitary = null;
                this.TrainingMilitaryID = -1;
            }
        }

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
                return (base.Scenario.Date.Year - this.yearBorn);
            }
        }

        public int AgricultureAbility
        {
            get
            {
                return (int) ((this.BaseAgricultureAbility + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
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

        public PersonAmbition Ambition
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

        public int Braveness
        {
            get
            {
                return this.braveness;
            }
            set
            {
                this.braveness = value;
            }
        }

        public int Brother
        {
            get
            {
                return this.brother;
            }
            set
            {
                this.brother = value;
            }
        }

        public int BubingExperience
        {
            get
            {
                return this.bubingExperience;
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

        public int Calmness
        {
            get
            {
                return this.calmness;
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

        public List<int> ClosePersons
        {
            get
            {
                return this.closePersons;
            }
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
                        num += 5 * skill.Level;
                    }
                }
                return num;
            }
        }

        public int CombatTitleInfluenceCount
        {
            get
            {
                if (this.CombatTitle != null)
                {
                    return this.CombatTitle.InfluenceCount;
                }
                return 0;
            }
        }

        public string CombatTitleString
        {
            get
            {
                if (this.CombatTitle != null)
                {
                    return this.CombatTitle.Name;
                }
                return "----";
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
                return this.commandExperience;
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
                return (int) ((this.BaseCommerceAbility + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
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
                return (int) ((this.Glamour * 4) * (1f + this.RateIncrementOfConvince));
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
                return (int) (((this.Strength + this.Command) + (this.Intelligence * 2)) * (1f + this.RateIncrementOfDestroy));
            }
        }

        public int DominationAbility
        {
            get
            {
                return (int) ((this.BaseDominationAbility + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
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
                return (int) ((this.BaseEnduranceAbility + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
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

        public int Father
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

        public int FightingForce
        {
            get
            {
                return (((this.Strength + this.Command) + this.Intelligence) * (((((((100 + (((this.PersonalTitle != null) && this.PersonalTitle.Combat) ? this.PersonalTitle.Merit : 0)) + ((this.CombatTitle != null) ? this.CombatTitle.Merit : 0)) + this.CombatSkillMerit) + this.TreasureMerit) + (this.StuntCount * 30)) + (this.Braveness * 5)) + (this.Calmness * 5)));
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
                return this.glamourExperience;
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
                return (int) (((this.Politics * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfGossip));
            }
        }

        public bool HasLeaderValidCombatTitle
        {
            get
            {
                if (this.CombatTitle == null)
                {
                    return false;
                }
                return this.CombatTitle.Influences.HasTroopLeaderValidInfluence;
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
                foreach (Title title in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if (((title != this.PersonalTitle) && (title != this.CombatTitle)) && title.CanLearn(this))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public List<int> HatedPersons
        {
            get
            {
                return this.hatedPersons;
            }
        }

        public Title HigherLevelLearnableTitle
        {
            get
            {
                Title title = null;
                foreach (Title title2 in base.Scenario.GameCommonData.AllTitles.Titles.Values)
                {
                    if ((title2.Kind == TitleKind.个人) && (((this.PersonalTitle == null) || (title2.Level > this.PersonalTitle.Level)) && title2.CanLearn(this)))
                    {
                        if ((title == null) || (title.Level < title2.Level))
                        {
                            title = title2;
                        }
                        else if ((title.Level == title2.Level) && GameObject.Chance(50))
                        {
                            title = title2;
                        }
                    }
                    if ((title2.Kind == TitleKind.战斗) && (((this.CombatTitle == null) || (title2.Level > this.CombatTitle.Level)) && title2.CanLearn(this)))
                    {
                        if ((title == null) || (title.Level < title2.Level))
                        {
                            title = title2;
                        }
                        else if (GameObject.Chance(50))
                        {
                            title = title2;
                        }
                    }
                }
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
                return (int) (((this.Intelligence * 2) + (this.Glamour * 2)) * (1f + this.RateIncrementOfInstigate));
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
                return this.intelligenceExperience;
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
                return this.internalExperience;
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
                    return this.loyalty;
                }
                return 0;
            }
            set
            {
                this.loyalty = value;
            }
        }

        public int Merit
        {
            get
            {
                return (((((this.Strength + this.Command) + this.Intelligence) + this.Politics) + this.Glamour) * ((((((100 + ((this.PersonalTitle != null) ? this.PersonalTitle.Merit : 0)) + ((this.CombatTitle != null) ? this.CombatTitle.Merit : 0)) + this.AllSkillMerit) + this.TreasureMerit) + (this.Braveness * 5)) + (this.Calmness * 5)));
            }
        }

        public int MoraleAbility
        {
            get
            {
                return (int) ((this.BaseMoraleAbility + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
            }
        }

        public int MoraleWeighing
        {
            get
            {
                return ((this.MoraleAbility * (this.MultipleOfMoraleReputation + this.MultipleOfMoraleTechniquePoint)) * (1 + (this.InternalNoFundNeeded ? 1 : 0)));
            }
        }

        public int Mother
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
                return (int) (((2 * (this.NormalPolitics + this.NormalGlamour)) + this.IncrementOfAgricultureAbility) * (1f + this.RateIncrementOfAgricultureAbility));
            }
        }

        public int NormalCommand
        {
            get
            {
                return (int) ((this.CommandIncludingExperience + this.InfluenceIncrementOfCommand) * this.InfluenceRateOfCommand);
            }
        }

        public int NormalCommerceAbility
        {
            get
            {
                return (int) ((((this.NormalIntelligence + (2 * this.NormalPolitics)) + this.NormalGlamour) + this.IncrementOfCommerceAbility) * (1f + this.RateIncrementOfCommerceAbility));
            }
        }

        public int NormalDominationAbility
        {
            get
            {
                return (int) (((((2 * this.NormalStrength) + this.NormalCommand) + this.NormalGlamour) + this.IncrementOfDominationAbility) * (1f + this.RateIncrementOfDominationAbility));
            }
        }

        public int NormalEnduranceAbility
        {
            get
            {
                return (int) (((((this.NormalStrength + this.NormalCommand) + this.NormalIntelligence) + this.NormalPolitics) + this.IncrementOfEnduranceAbility) * (1f + this.RateIncrementOfEnduranceAbility));
            }
        }

        public int NormalGlamour
        {
            get
            {
                return (int) ((this.GlamourIncludingExperience + this.InfluenceIncrementOfGlamour) * this.InfluenceRateOfGlamour);
            }
        }

        public int NormalIntelligence
        {
            get
            {
                return (int) ((this.IntelligenceIncludingExperience + this.InfluenceIncrementOfIntelligence) * this.InfluenceRateOfIntelligence);
            }
        }

        public int NormalMoraleAbility
        {
            get
            {
                return (int) ((((this.NormalCommand + this.NormalPolitics) + (2 * this.NormalGlamour)) + this.IncrementOfMoraleAbility) * (1f + this.RateIncrementOfMoraleAbility));
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
                return (int) ((this.PoliticsIncludingExperience + this.InfluenceIncrementOfPolitics) * this.InfluenceRateOfPolitics);
            }
        }

        public int NormalRecruitmentAbility
        {
            get
            {
                return (int) ((((2 * this.NormalCommand) + (2 * this.NormalGlamour)) + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public int NormalStrength
        {
            get
            {
                return (int) ((this.StrengthIncludingExperience + this.InfluenceIncrementOfStrength) * this.InfluenceRateOfStrength);
            }
        }

        public int NormalTechnologyAbility
        {
            get
            {
                return (int) (((2 * (this.NormalIntelligence + this.NormalPolitics)) + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
            }
        }

        public int NormalTrainingAbility
        {
            get
            {
                return (int) ((((2 * this.NormalStrength) + (2 * this.NormalCommand)) + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
            }
        }

        public int NubingExperience
        {
            get
            {
                return this.nubingExperience;
            }
            set
            {
                this.nubingExperience = value;
            }
        }

        public int OldFactionID
        {
            get
            {
                return this.oldFactionID;
            }
            set
            {
                this.oldFactionID = value;
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

        public PersonLoyalty PersonalLoyalty
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

        public int PersonalTitleInfluenceCount
        {
            get
            {
                if (this.PersonalTitle != null)
                {
                    return this.PersonalTitle.InfluenceCount;
                }
                return 0;
            }
        }

        public string PersonalTitleString
        {
            get
            {
                if (this.PersonalTitle != null)
                {
                    return this.PersonalTitle.Name;
                }
                return "----";
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
                return this.politicsExperience;
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
                return base.Scenario.GetPortrait(this.PictureIndex);
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

        public int ProhibitedFactionID
        {
            get
            {
                return this.prohibitedFactionID;
            }
            set
            {
                this.prohibitedFactionID = value;
            }
        }

        public int QibingExperience
        {
            get
            {
                return this.qibingExperience;
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
                return this.qixieExperience;
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
                return (int) ((this.BaseRecruitmentAbility + this.IncrementOfRecruitmentAbility) * (1f + this.RateIncrementOfRecruitmentAbility));
            }
        }

        public Military RecruitmentMilitary
        {
            get
            {
                if (this.recruitmentMilitary == null)
                {
                    this.recruitmentMilitary = this.LocationArchitecture.Militaries.GetGameObject(this.RecruitmentMilitaryID) as Military;
                    if (this.recruitmentMilitary != null)
                    {
                        this.recruitmentMilitary.RecruitmentPerson = this;
                    }
                }
                return this.recruitmentMilitary;
            }
            set
            {
                this.recruitmentMilitary = value;
            }
        }

        public int RecruitmentMilitaryID
        {
            get
            {
                return this.recruitmentMilitaryID;
            }
            set
            {
                this.recruitmentMilitaryID = value;
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
                return this.reputation;
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
                return (int) (((this.Intelligence + this.Politics) + (this.Glamour * 2)) * (1f + this.RateIncrementOfSearch));
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
                return this.shuijunExperience;
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
                return base.Scenario.GetSmallPortrait(this.PictureIndex);
            }
        }

        public int Spouse
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
                return (this.IncrementOfSpyDays + 90);
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
                return this.stratagemExperience;
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
                return this.strengthExperience;
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
                return this.tacticsExperience;
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
                return (int) ((this.BaseTechnologyAbility + this.IncrementOfTechnologyAbility) * (1f + this.RateIncrementOfTechnologyAbility));
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
                return (int) ((this.BaseTrainingAbility + this.IncrementOfTrainingAbility) * (1f + this.RateIncrementOfTrainingAbility));
            }
        }

        public Military TrainingMilitary
        {
            get
            {
                if (this.trainingMilitary == null)
                {
                    this.trainingMilitary = this.LocationArchitecture.Militaries.GetGameObject(this.trainingMilitaryID) as Military;
                    if (this.trainingMilitary != null)
                    {
                        this.trainingMilitary.TrainingPerson = this;
                    }
                }
                return this.trainingMilitary;
            }
            set
            {
                this.trainingMilitary = value;
            }
        }

        public int TrainingMilitaryID
        {
            get
            {
                return this.trainingMilitaryID;
            }
            set
            {
                this.trainingMilitaryID = value;
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
                foreach (Treasure treasure in this.Treasures)
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
                return (((float) this.routCount) / ((float) (this.routCount + this.routedCount)));
            }
        }

        public int WorkAbility
        {
            get
            {
                return this.GetWorkAbility(this.workKind);
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
                this.workKind = value;
            }
        }

        public string WorkKindString
        {
            get
            {
                if (this.workKind != ArchitectureWorkKind.无)
                {
                    return this.workKind.ToString();
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




        public PersonList meichushengdehaiziliebiao()
        {
            PersonList haiziliebiao = new PersonList();
            foreach (Person person in this.Scenario.Persons)
            {
                if (person.Alive && !person.Available && person.Father == this.ID)
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
                if (father == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person fatherPerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == Father)
                    {
                        fatherPerson = i;
                        break;
                    }
                }
                return fatherPerson == null ? "－－－－" : fatherPerson.Name;
            }
        }

        public String MotherName
        {
            get
            {
                if (mother == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person motherPerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == Mother)
                    {
                        motherPerson = i;
                        break;
                    }
                }
                return motherPerson == null ? "－－－－" : motherPerson.Name;
            }
        }

        public String SpouseName
        {
            get
            {
                if (spouse == -1) return "－－－－";
                PersonList allPersons = base.Scenario.Persons;
                Person spousePerson = null;
                foreach (Person i in allPersons)
                {
                    if (i.ID == spouse)
                    {
                        spousePerson = i;
                        break;
                    }
                }
                return spousePerson == null ? "－－－－" : spousePerson.Name;
            }
        }


        public delegate void BeAwardedTreasure(Person person, Treasure t);

        public delegate void BeConfiscatedTreasure(Person person, Treasure t);

        public delegate void BeKilled(Person person, Architecture location);

        public delegate void ChangeLeader(Faction faction, Person leader, bool changeName, string oldName);

        public delegate void ConvinceFailed(Person source, Person destination);

        public delegate void ConvinceSuccess(Person source, Person destination, Faction oldFaction);

        public delegate void Death(Person person, Architecture location);

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

        public delegate void ShowMessage(Person person, PersonMessage personMessage);

        public delegate void SpyFailed(Person person, Architecture architecture);

        public delegate void SpyFound(Person person, Person spy);

        public delegate void SpySuccess(Person person, Architecture architecture);

        public delegate void StudySkillFinished(Person person, string skillString, bool success);

        public delegate void StudyStuntFinished(Person person, Stunt stunt, bool success);

        public delegate void StudyTitleFinished(Person person, Title title, bool success);

        public delegate void TreasureFound(Person person, Treasure treasure);

        internal void muqinyingxiangnengli(Person muqin)
        {
            this.BaseStrength =(int) (this.BaseStrength*0.9 + muqin.BaseStrength*0.1);
            this.BaseStrength+=GameObject.Random(3)*(GameObject.Random(2)==0 ? 1:-1);
            if (this.BaseStrength>100) this.BaseStrength=100;
            if (this.BaseStrength<0) this.BaseStrength=0;

            this.BaseCommand = (int)(this.BaseCommand * 0.9 + muqin.BaseCommand * 0.1);
            this.BaseCommand += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseCommand > 100) this.BaseCommand = 100;
            if (this.BaseCommand < 0) this.BaseCommand = 0;

            this.BaseIntelligence = (int)(this.BaseIntelligence * 0.9 + muqin.BaseIntelligence * 0.1);
            this.BaseIntelligence += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseIntelligence > 100) this.BaseIntelligence = 100;
            if (this.BaseIntelligence < 0) this.BaseIntelligence = 0;

            this.BasePolitics = (int)(this.BasePolitics * 0.9 + muqin.BasePolitics * 0.1);
            this.BasePolitics += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BasePolitics > 100) this.BasePolitics = 100;
            if (this.BasePolitics < 0) this.BasePolitics = 0;

            this.BaseGlamour = (int)(this.BaseGlamour * 0.9 + muqin.BaseGlamour * 0.1);
            this.BaseGlamour += GameObject.Random(3) * (GameObject.Random(2) == 0 ? 1 : -1);
            if (this.BaseGlamour > 100) this.BaseGlamour = 100;
            if (this.BaseGlamour < 0) this.BaseGlamour = 0;
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

        internal Person createChildren(Person father, Person mother)
        {
            Person r = new Person();

            //look for empty id
            int id = 0;
            PersonList pl = base.Scenario.Persons as PersonList;
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
                /*if (id >= 7000)
                {
                    //no more room!
                    throw new Exception("No more room for children!");
                }*/
            }
            r.ID = id;

            r.Father = father.ID;
            r.Mother = mother.ID;
            r.Generation = father.Generation + 1;
            r.Strain = father.Strain;

            r.Sex = GameObject.Chance(50) ? true : false;

            r.SurName = father.SurName;
            List<String> givenNameList = r.Sex ? Person.readTextList("malegivenname.txt") : Person.readTextList("femalegivenname.txt");
            r.GivenName = givenNameList[GameObject.Random(givenNameList.Count)];
            r.CalledName = "";

            int var = 5; //variance / maximum divert from parent ability
            r.BaseCommand = GameObject.Random(Math.Abs(father.BaseCommand - mother.BaseCommand) + 2 * var + 1) + Math.Min(father.BaseCommand, mother.BaseCommand) - var;
            r.BaseStrength = GameObject.Random(Math.Abs(father.BaseStrength - mother.BaseStrength) + 2 * var + 1) + Math.Min(father.BaseStrength, mother.BaseStrength) - var;
            r.BaseIntelligence = GameObject.Random(Math.Abs(father.BaseIntelligence - mother.BaseIntelligence) + 2 * var + 1) + Math.Min(father.BaseIntelligence, mother.BaseIntelligence) - var;
            r.BasePolitics = GameObject.Random(Math.Abs(father.BasePolitics - mother.BasePolitics) + 2 * var + 1) + Math.Min(father.BasePolitics, mother.BasePolitics) - var;
            r.BaseGlamour = GameObject.Random(Math.Abs(father.BaseGlamour - mother.BaseGlamour) + 2 * var + 1) + Math.Min(father.BaseGlamour, mother.BaseGlamour) - var;
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

            List<int> pictureList;
            if (r.Sex)
            {
                if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("femalefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("femalefaceA.txt");
                }
            }
            else
            {
                if (r.BaseCommand < 50 && r.BaseStrength < 50 && r.BaseIntelligence < 50 && r.BasePolitics < 50 && r.BaseGlamour < 50)
                {
                    pictureList = Person.readNumberList("malefaceU.txt");
                }
                else if (r.BaseCommand + r.BaseStrength > r.BaseIntelligence + r.BasePolitics)
                {
                    pictureList = Person.readNumberList("malefaceM.txt");
                }
                else
                {
                    pictureList = Person.readNumberList("malefaceA.txt");
                }
            }
            r.PictureIndex = pictureList[GameObject.Random(pictureList.Count)];

            r.YearBorn = base.Scenario.Date.Year;
            r.YearAvailable = base.Scenario.Date.Year;
            r.YearDead = r.YearBorn + GameObject.Random(69) + 30;

            r.Ideal = GameObject.Chance(50) ? father.Ideal + GameObject.Random(10) - 5 : mother.Ideal + GameObject.Random(10) - 5;
            r.Ideal = (r.Ideal + 150) % 150;

            r.Reputation = (int)((father.Reputation + mother.Reputation) * (GameObject.Random(100) / 100.0 * 0.1 + 0.05));

            r.PersonalLoyalty = (GameObject.Chance(50) ? father.PersonalLoyalty : mother.PersonalLoyalty) + GameObject.Random(3) - 1;
            if (r.PersonalLoyalty < 0) r.PersonalLoyalty = 0;
            if ((int)r.PersonalLoyalty > Enum.GetNames(typeof(PersonLoyalty)).Length) r.PersonalLoyalty = (PersonLoyalty)Enum.GetNames(typeof(PersonLoyalty)).Length;

            r.Ambition = (GameObject.Chance(50) ? father.Ambition : mother.Ambition) + GameObject.Random(3) - 1;
            if (r.Ambition < 0) r.Ambition = 0;
            if ((int)r.Ambition > Enum.GetNames(typeof(PersonAmbition)).Length) r.Ambition = (PersonAmbition)Enum.GetNames(typeof(PersonAmbition)).Length;

            r.Qualification = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Qualification : mother.Qualification) : (PersonQualification)GameObject.Random(Enum.GetNames(typeof(PersonQualification)).Length);

            r.Braveness = (GameObject.Chance(50) ? father.Braveness : mother.Braveness) + GameObject.Random(5) - 2;
            if (r.Braveness < 1) r.Braveness = 1;
            if (r.Braveness > 10) r.Braveness = 10;

            r.Calmness = (GameObject.Chance(50) ? father.Calmness : mother.Calmness) + GameObject.Random(5) - 2;
            if (r.Calmness < 1) r.Calmness = 1;
            if (r.Calmness > 10) r.Calmness = 10;

            r.ValuationOnGovernment = (GameObject.Chance(50) ? father.ValuationOnGovernment : mother.ValuationOnGovernment);

            r.StrategyTendency = (GameObject.Chance(50) ? father.StrategyTendency : mother.StrategyTendency);

            r.IdealTendency = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.IdealTendency : mother.IdealTendency) : base.Scenario.GameCommonData.AllIdealTendencyKinds.GetRandomList()[0] as IdealTendencyKind;
            Person leader = father.BelongedFaction == null ? mother.BelongedFaction.Leader : father.BelongedFaction.Leader;
            if (r.IdealTendency.Offset < Person.GetIdealOffset(r, leader))
            {
                r.Ideal = leader.Ideal + GameObject.Random(r.IdealTendency.Offset * 2 + 1) - r.IdealTendency.Offset;
                r.Ideal = (r.Ideal + 150) % 150;
            }

            Architecture bornArch = father.BelongedArchitecture == null ? mother.BelongedArchitecture : father.BelongedArchitecture;
            try //best-effort approach for getting PersonBornRegion
            {
                r.BornRegion = (PersonBornRegion)Enum.Parse(typeof(PersonBornRegion), bornArch.LocationState.Name); //mother has no locationarch...
            }
            catch (ArgumentException ex)
            {
                r.BornRegion = (PersonBornRegion)GameObject.Random(Enum.GetNames(typeof(PersonBornRegion)).Length);
            }

            r.Character = GameObject.Chance(84) ? (GameObject.Chance(50) ? father.Character : mother.Character) : base.Scenario.GameCommonData.AllCharacterKinds[GameObject.Random(base.Scenario.GameCommonData.AllCharacterKinds.Count)];

            foreach (Skill i in father.Skills.GetSkillList())
            {
                if (GameObject.Chance(50))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in mother.Skills.GetSkillList())
            {
                if (GameObject.Chance(50))
                {
                    r.Skills.AddSkill(i);
                }
            }
            foreach (Skill i in base.Scenario.GameCommonData.AllSkills.GetSkillList())
            {
                if (GameObject.Random(base.Scenario.GameCommonData.AllSkills.GetSkillList().Count / 2) == 0)
                {
                    r.Skills.AddSkill(i);
                }
            }

            foreach (Stunt i in father.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50))
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
            foreach (Stunt i in mother.Stunts.GetStuntList())
            {
                if (GameObject.Chance(50))
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
            foreach (Stunt i in base.Scenario.GameCommonData.AllStunts.GetStuntList())
            {
                if (GameObject.Random(base.Scenario.GameCommonData.AllStunts.GetStuntList().Count * 2) == 0)
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

            if (GameObject.Chance(10))
            {
                r.PersonalTitle = GameObject.Chance(50) ? father.PersonalTitle : mother.PersonalTitle;
            }
            else
            {
                GameObjectList titles = base.Scenario.GameCommonData.AllTitles.GetTitleList().GetRandomList();
                foreach (Title t in titles)
                {
                    if (t.Kind == TitleKind.个人 && GameObject.Random(t.Level * t.Level) == 0)
                    {
                        if (t.Combat)
                        {
                            if (GameObject.Chance((r.BaseCommand + r.BaseStrength) / 2))
                            {
                                r.PersonalTitle = t;
                                break;
                            }
                        }
                        else
                        {
                            if (GameObject.Chance((r.BaseIntelligence + r.BasePolitics) / 2))
                            {
                                r.PersonalTitle = t;
                                break;
                            }
                        }
                    }
                }
            }

            if (GameObject.Chance(10))
            {
                r.CombatTitle = GameObject.Chance(50) ? father.CombatTitle : mother.CombatTitle;
            }
            else
            {
                GameObjectList titles = base.Scenario.GameCommonData.AllTitles.GetTitleList().GetRandomList();
                foreach (Title t in titles)
                {
                    if (t.Kind == TitleKind.战斗 && GameObject.Random(t.Level * t.Level) == 0)
                    {
                        if (t.Combat)
                        {
                            if (GameObject.Chance((r.BaseCommand + r.Strength + r.BaseIntelligence) / 3))
                            {
                                r.CombatTitle = t;
                                break;
                            }
                        }
                        else
                        {
                            if (GameObject.Chance((r.BaseIntelligence + r.BasePolitics) / 2))
                            {
                                r.CombatTitle = t;
                                break;
                            }
                        }
                    }
                }
            }

            /*r.LocationArchitecture = father.BelongedArchitecture; //mother has no location arch!
            r.BelongedFaction = r.BelongedArchitecture.BelongedFaction;
            r.Available = true;*/
            r.Alive = true;

            base.Scenario.Persons.Add(r);

            r.Scenario = base.Scenario;

            return r;
        }

        public bool isLegalFeiZi(Person b)
        {
            if (this.Sex == b.Sex) return false;

            if ((b.Age < 16 || b.Age > 50) && GlobalVariables.PersonNaturalDeath) return false;

            if (this.Strain == b.Strain) return false;

            if (this.father == b.ID) return false;
            if (this.mother == b.ID) return false;

            if (this.father!=-1&&b.father == this.father) return false;
            if (this.mother!=-1&&b.mother == this.mother) return false;

            if (b.father == this.ID) return false;
            if (b.mother == this.ID) return false;

            //father's parent
            if (this.Father != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == this.Father)
                    {
                        if (b.ID == p.Father || b.ID == p.Mother)
                        {
                            return false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            //Mother's parent
            if (this.Mother != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == this.Mother)
                    {
                        if (b.ID == p.Father || b.ID == p.Mother)
                        {
                            return false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            //grandchild thru father
            if (b.Father != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == b.Father)
                    {
                        if (p.Father == this.ID || p.Mother == this.ID)
                        {
                            return false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            //grandchild thru mother
            if (b.Mother != -1)
            {
                foreach (Person p in base.Scenario.Persons)
                {
                    if (p.ID == b.Mother)
                    {
                        if (p.Father == this.ID || p.Mother == this.ID)
                        {
                            return false;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            return true;
        }


        public Person XuanZeMeiNv(Person nvren)
        {
            Person tookSpouse = null;
            /*  人物死亡时的程序
                locationArchitecture.RemovePerson(this);
                belongedFaction.RemovePerson(this);
                base.Scenario.AvailablePersons.Remove(this);
                base.Scenario.Persons.Remove(this);
                */
            Architecture originalLocationArch = nvren.LocationArchitecture;

            originalLocationArch.DecreaseFund(50000);

            originalLocationArch.RemovePerson(nvren);
            originalLocationArch.BelongedFaction.RemovePerson(nvren);
            //this.mainGameScreen.Scenario.AvailablePersons.Remove(this.CurrentPerson);
            //this.CurrentPerson.suoshurenwu = this.CurrentArchitecture.BelongedFaction.Leader;
            originalLocationArch.feiziliebiao.Add(nvren);
            //nvren.suoshurenwu = originalLocationArch.BelongedFaction.LeaderID;
            nvren.suozaijianzhu = originalLocationArch;

            if (nvren.Spouse != -1)
            {
                Person p = new Person();
                foreach (Person person in base.Scenario.Persons)
                {
                    if (person.ID == nvren.Spouse)
                    {
                        p = person;
                    }
                }

                if ((p != null) && p.ID != originalLocationArch.BelongedFaction.LeaderID)
                {
                    if (p.Alive)
                    {
                        tookSpouse = p;

                        p.HatedPersons.Add(this.LocationArchitecture.BelongedFaction.LeaderID);
                        if (p.Available == false)
                        {
                            p.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.ID;

                        }
                        else if (p.BelongedFaction == null)
                        {
                            p.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.ID;
                        }
                        else if (p.BelongedFaction != this.LocationArchitecture.BelongedFaction)
                        {
                            p.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.ID;
                        }
                        else if (p.BelongedFaction == this.LocationArchitecture.BelongedFaction)
                        {
                            p.ProhibitedFactionID = this.LocationArchitecture.BelongedFaction.ID;

                            p.Loyalty = -100;
                        }
                    }
                }
            }// end if (this.CurrentPerson.Spouse != -1)
            return tookSpouse;
        }

        public void GoForHouGong(Person nvren)
        {
            if (this.LocationArchitecture != null)
            {
                int houGongDays = nvren.Glamour / 4 + GameObject.Random(6) + 10;
                if (GameObject.Random((int)((this.NumberOfChildren + nvren.NumberOfChildren * 2 + 2) / 2.0 * 90 / houGongDays)) == 0 && !nvren.huaiyun && !this.huaiyun && this.isLegalFeiZi(nvren) &&
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
                this.OutsideTask = OutsideTaskKind.后宮;
                this.TargetArchitecture = this.LocationArchitecture;
                this.ArrivingDays = houGongDays;
                this.TargetArchitecture.RemovePerson(this);
                this.TargetArchitecture.MovingPersons.Add(this);
                this.TaskDays = this.ArrivingDays;
            }
        }


        public Architecture FeiZiLocationArchitecture
        {
            get
            {
                ArchitectureList allArch = base.Scenario.Architectures;
                foreach (Architecture i in allArch)
                {
                    if (i.feiziliebiao.GameObjects.Contains(this))
                    {
                        return i;
                    }
                }
                return null;
            }
        }
    }
}

