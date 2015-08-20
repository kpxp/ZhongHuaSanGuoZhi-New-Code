namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.ArchitectureDetail;
    using GameObjects.FactionDetail;
    using GameObjects.Influences;
    using GameObjects.MapDetail;
    using GameObjects.PersonDetail;
    using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using GameFreeText;

    public class Architecture : GameObject
    {
        private int agriculture;
        private bool shoudongluyongshibai=false;
        private PersonList agriculturePersons = new PersonList();  //AI使用
        public PersonList AgricultureWorkingPersons = new PersonList();
        private PersonList zhenzaiPersons = new PersonList();   //AI使用，目前未用
        public PersonList zhenzaiWorkingPersons = new PersonList();
        public PersonList feiziliebiao = new PersonList();

        public Dictionary<int, LinkNode> AIAllLinkNodes = new Dictionary<int, LinkNode>();
        public ArchitectureList AILandLinks = new ArchitectureList();
        public string AILandLinksString;
        private Queue<AILinkProcedureDetail> AILinkProcedureDetails = new Queue<AILinkProcedureDetail>();
        public ArchitectureList AIWaterLinks = new ArchitectureList();
        public string AIWaterLinksString;
        public GameArea ArchitectureArea = new GameArea();
        private bool autoHiring;
        public bool AutoRefillFoodInLongViewArea;
        private bool autoRewarding;
        private bool autoSearching;
        private bool autoWorking;
        private GameArea baseFoodSurplyArea;
        public Faction BelongedFaction = null;
        public Section BelongedSection = null;
        public MilitaryList BeMergedMilitaryList = new MilitaryList();
        public GameObjectList BuildableFacilityKindList = new GameObjectList();
        private int buildingDaysLeft;
        private int buildingFacility = -1;
        public MilitaryList CampaignMilitaryList = new MilitaryList();
        public CaptiveList Captives = new CaptiveList();
        public ArchitectureList ChangeCapitalArchitectureList = new ArchitectureList();
        public InfluenceTable Characteristics = new InfluenceTable();
        public ArchitectureList ClosestArchitectures;
        public int CombativityOfRecruitment = 50;
        private int commerce;
        private PersonList commercePersons = new PersonList();
        public PersonList CommerceWorkingPersons = new PersonList();
        private GameArea contactArea;
        public PersonList ConvinceDestinationPersonList = new PersonList();
        public bool CriticalHostile;
        public bool DayAvoidInfluenceByBattle;
        public bool DayAvoidInternalDecrementOnBattle;
        public bool DayAvoidPopulationEscape;
        public int DayLearnTitleDay;
        public bool DayLocationLoyaltyNoChange;
        public float DayRateIncrementOfInternal;
        public CombatNumberItemList DecrementNumberList = new CombatNumberItemList(CombatNumberDirection.下);
        public Legion DefensiveLegion;
        public int DefensiveLegionID;
        private int domination;
        private PersonList dominationPersons = new PersonList();
        public PersonList DominationWorkingPersons = new PersonList();
        private int endurance;
        private PersonList endurancePersons = new PersonList();
        public PersonList EnduranceWorkingPersons = new PersonList();
        public FacilityList Facilities = new FacilityList();
        private bool facilityEnabled;
        private int food;
        public bool FrontLine;
        private int fund;
        internal List<FundPack> FundPacks = new List<FundPack>();
        private bool hireFinished;
        public bool HostileLine;
        public CombatNumberItemList IncrementNumberList = new CombatNumberItemList(CombatNumberDirection.上);
        public int IncrementOfAgricultureCeiling;
        public int IncrementOfAgriculturePerDay;
        public int IncrementOfCombativityInViewArea;
        public int IncrementOfCommerceCeiling;
        public int IncrementOfCommercePerDay;
        public int IncrementOfDominationPerDay;
        public int IncrementOfEnduranceCeiling;
        public int IncrementOfEndurancePerDay;
        public int IncrementOfFacilityPositionCount;
        public int IncrementOfFactionReputationPerDay;
        public int IncrementOfFactionTechniquePointPerDay;
        public int IncrementOfMonthFood;
        public int IncrementOfMonthFund;
        public int IncrementOfMoralePerDay;
        public int IncrementOfTechnologyCeiling;
        public int IncrementOfTechnologyPerDay;
        public int IncrementOfViewRadius;
        private int informationCoolDown;
        private bool isStrategicCenter;
        private bool JustAttacked = false;
        private ArchitectureKind kind;
        public MilitaryList LevelUpMilitaryList = new MilitaryList();
        public State LocationState;
        private GameArea longViewArea = null;
        public MilitaryList MergeMilitaryList = new MilitaryList();
        public MilitaryList Militaries = new MilitaryList();
        private int morale;
        public int MoraleOfRecruitment = 50;
        private PersonList moralePersons = new PersonList();
        public PersonList MoraleWorkingPersons = new PersonList();
        public PersonList MovingPersons = new PersonList();
        public int MultipleOfRecovery = 1;
        public int MultipleOfTraining = 1;
        public MilitaryKindList NewMilitaryKindList = new MilitaryKindList();
        public bool NoCounterStrikeInArchitecture;
        public PersonList NoFactionMovingPersons = new PersonList();
        public PersonList NoFactionPersons = new PersonList();
        public ArchitectureList OtherArchitectureList = new ArchitectureList();
        private int PathRoutewayID = -1;
        public PersonList PersonConveneList = new PersonList();
        public PersonList Persons = new PersonList();
        public PersonList PersonStudySkillList = new PersonList();
        public PersonList PersonStudyStuntList = new PersonList();
        public PersonList PersonStudyTitleList = new PersonList();
        public Architecture PlanArchitecture;
        public int PlanArchitectureID;
        public FacilityKind PlanFacilityKind;
        public int PlanFacilityKindID;
        private int population;
        internal List<PopulationPack> PopulationPacks = new List<PopulationPack>();
        public MilitaryKindTable PrivateMilitaryKinds = new MilitaryKindTable();
        public float RateIncrementOfMonthFood;
        public float RateIncrementOfMonthFund;
        public float RateIncrementOfNewBubingTroopDefence;
        public float RateIncrementOfNewBubingTroopOffence;
        public float RateIncrementOfNewNubingTroopDefence;
        public float RateIncrementOfNewNubingTroopOffence;
        public float RateIncrementOfNewQibingTroopDefence;
        public float RateIncrementOfNewQibingTroopOffence;
        public float RateIncrementOfNewQixieTroopDefence;
        public float RateIncrementOfNewQixieTroopOffence;
        public float RateIncrementOfNewShuijunTroopDefence;
        public float RateIncrementOfNewShuijunTroopOffence;
        public double RateIncrementOfPopulationDevelop;
        public float RateOfClearField = 1f;
        public float RateOfConvincePerson = 1f;
        public float RateOfDestroyArchitecture = 1f;
        public float RateOfFacilityEnduranceDown = 1f;
        public float RateOfFoodReduceRate = 1f;
        public float RateOfGossipArchitecture = 1f;
        public float RateOfHirePerson = 1f;
        public float RateOfInstigateArchitecture = 1f;
        public float RateOfInternal = 1f;
        public float RateOfNewBubingMilitaryFundCost = 1f;
        public float RateOfNewNubingMilitaryFundCost = 1f;
        public float RateOfNewQibingMilitaryFundCost = 1f;
        public float RateOfNewQixieMilitaryFundCost = 1f;
        public float RateOfNewShuijunMilitaryFundCost = 1f;
        public float RateOfRewardPerson = 1f;
        public float RateOfRoutewayBuildFundCost = 1f;
        public float RateOfSpyArchitecture = 1f;
        public int RecentlyAttacked;
        public int RecentlyBreaked;
        public MilitaryList RecruitmentMilitaryList = new MilitaryList();
        private PersonList recruitmentPersons = new PersonList();
        public CaptiveList RedeemCaptiveList = new CaptiveList();
        public GameObjectList ResetDiplomaticRelationList = new GameObjectList();
        public PersonList RewardPersonList = new PersonList();
        public Troop RobberTroop;
        public int RobberTroopID;
        private Dictionary<int, Architecture> RoutewayDestinationArchitectures = new Dictionary<int, Architecture>();
        private Queue<RoutewayProcedureDetail> RoutewayProcedures = new Queue<RoutewayProcedureDetail>();
        public RoutewayList Routeways = new RoutewayList();
        public MilitaryList ShelledMilitaryList = new MilitaryList();
        private bool showNumber;
        internal List<SpyPack> SpyPacks = new List<SpyPack>();
        private float surplusRate;
        private int technology;
        private PersonList technologyPersons = new PersonList();
        public PersonList TechnologyWorkingPersons = new PersonList();
        public SpyMessage TodayNewMilitarySpyMessage;
        public SpyMessage TodayNewTroopSpyMessage;
        public int TotalFriendlyForce;
        public int TotalHostileForce;
        public MilitaryList TrainingMilitaryList = new MilitaryList();
        private PersonList trainingPersons = new PersonList();
        public ArchitectureList TransferArchitectureList = new ArchitectureList();
        public Architecture TransferFoodArchitecture;
        public int TransferFoodArchitectureID;
        public Architecture TransferFundArchitecture;
        public int TransferFundArchitectureID;
        public bool TroopershipAvailable;
        private GameArea viewArea = null;
        private MilitaryList weighingMilitaries = new MilitaryList();
        public zainanlei zainan = new zainanlei();


        public event BeginRecentlyAttacked OnBeginRecentlyAttacked;

        public event FacilityCompleted OnFacilityCompleted;

        public event fashengzainan Onfashengzainan;

        public event HirePerson OnHirePerson;

        public event MilitaryCreate OnMilitaryCreate;

        public event PopulationEnter OnPopulationEnter;

        public event PopulationEscape OnPopulationEscape;

        public event ReleaseCaptiveAfterOccupied OnReleaseCaptiveAfterOccupied;

        public event RewardPersons OnRewardPersons;

        private void AddAllAILink(int level, int levelMax, Architecture root, List<Architecture> path)
        {
            path.Add(root);
            if (root != this)
            {
                double num = 0.0;
                for (int i = 1; i < path.Count; i++)
                {
                    num += base.Scenario.GetDistance(path[i - 1].ArchitectureArea, path[i].ArchitectureArea);
                }
                if (!this.AIAllLinkNodes.ContainsKey(root.ID))
                {
                    LinkNode node = new LinkNode();
                    node.A = root;
                    node.Level = level;
                    foreach (Architecture architecture in path)
                    {
                        node.Path.Add(architecture);
                    }
                    node.Distance = num;
                    this.AIAllLinkNodes.Add(root.ID, node);
                }
                else if ((this.AIAllLinkNodes[root.ID].Level == level) && (this.AIAllLinkNodes[root.ID].Distance > num))
                {
                    this.AIAllLinkNodes[root.ID].Distance = num;
                    this.AIAllLinkNodes[root.ID].Path.Clear();
                    foreach (Architecture architecture in path)
                    {
                        this.AIAllLinkNodes[root.ID].Path.Add(architecture);
                    }
                }
                else if (this.AIAllLinkNodes[root.ID].Level > level)
                {
                    this.AIAllLinkNodes[root.ID].Level = level;
                    this.AIAllLinkNodes[root.ID].Path.Clear();
                    foreach (Architecture architecture in path)
                    {
                        this.AIAllLinkNodes[root.ID].Path.Add(architecture);
                    }
                }
            }
            if (level < levelMax)
            {
                foreach (Architecture architecture in root.GetAILinks())
                {
                    this.AILinkProcedureDetails.Enqueue(new AILinkProcedureDetail(level + 1, architecture, path));
                }
            }
        }

        public void AddBaseSupplyingArchitecture()
        {
            foreach (Point point in this.BaseFoodSurplyArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddSupplyingArchitecture(this);
                }
            }
        }

        public void AddCaptive(Captive captive)
        {
            this.Captives.Add(captive);
            captive.LocationArchitecture = this;
            captive.CaptivePerson.LocationArchitecture = this;
        }

        private void AddCloseRoutewayDestinationArchitectures(Architecture a, float previousrate)
        {
            foreach (Routeway routeway in a.Routeways)
            {
                float minRate = 1f;
                if ((routeway.EndArchitecture != null) && routeway.IsActiveInArea(routeway.EndArchitecture.GetRoutewayStartArea(), out minRate))
                {
                    float rate = previousrate * (1f - (minRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures));
                    if (rate > routeway.EndArchitecture.surplusRate)
                    {
                        routeway.EndArchitecture.surplusRate = rate;
                        routeway.EndArchitecture.PathRoutewayID = routeway.ID;
                        if (!this.RoutewayDestinationArchitectures.ContainsKey(routeway.EndArchitecture.ID))
                        {
                            this.RoutewayDestinationArchitectures.Add(routeway.EndArchitecture.ID, routeway.EndArchitecture);
                        }
                        this.RoutewayProcedures.Enqueue(new RoutewayProcedureDetail(routeway.EndArchitecture, rate));
                    }
                }
            }
        }

        public void AddFundPack(int number, int days)
        {
            FundPack item = new FundPack(number, days);
            this.FundPacks.Add(item);
        }

        private void AddMessageToTodayMilitaryScaleSpyMessage(Military m)
        {
            this.CreateMilitaryScaleSpyMessage(m);
        }

        private void AddMessageToTodayNewMilitarySpyMessage(Military m)
        {
            if (this.TodayNewMilitarySpyMessage == null)
            {
                this.TodayNewMilitarySpyMessage = this.CreateNewMilitarySpyMessage(m);
            }
            else
            {
                this.TodayNewMilitarySpyMessage.Message3 = this.TodayNewMilitarySpyMessage.Message3 + "," + m.Name;
            }
        }

        private void AddMessageToTodayNewTroopSpyMessage(Troop t, bool hand)
        {
            if (this.TodayNewTroopSpyMessage == null)
            {
                this.TodayNewTroopSpyMessage = this.CreateNewTroopSpyMessage(t, hand);
            }
            else
            {
                this.TodayNewTroopSpyMessage.Message3 = this.TodayNewTroopSpyMessage.Message3 + "," + t.DisplayName;
            }
        }

        public void AddMilitary(Military military)
        {
            this.Militaries.AddMilitary(military);
            military.BelongedArchitecture = this;
        }

        public void AddNoFactionPerson(Person person)
        {
            if (person.BelongedFaction != null)
            {
                throw new Exception("人物已经属于某势力。一般是由于剧本设计中没有把某势力人物的Available属性设置为True。");
            }
            this.NoFactionPersons.Add(person);
            person.LocationArchitecture = this;
        }

        public void AddPerson(Person person)
        {
            this.Persons.Add(person);
            if (person.OldWorkKind != ArchitectureWorkKind.无)
            {
                this.AddPersonToWorkingList(person, person.OldWorkKind);
            }
            if ((person.LocationArchitecture != null) && (person.LocationArchitecture != this))
            {
                person.LocationArchitecture.RemovePerson(person);
            }
            person.LocationArchitecture = this;
        }

        public void AddPersonToAgricultureWorkingList(Person person)
        {
            this.AgricultureWorkingPersons.Add(person);
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.农业;
        }
        public void AddPersonTozhenzaiWorkingList(Person person)
        {
            this.zhenzaiWorkingPersons.Add(person);
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.赈灾;
        }
        public void AddPersonToCommerceWorkingList(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.商业;
            this.CommerceWorkingPersons.Add(person);
        }

        public void AddPersonToDominationWorkingList(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.统治;
            this.DominationWorkingPersons.Add(person);
        }

        public void AddPersonToEnduranceWorkingList(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.耐久;
            this.EnduranceWorkingPersons.Add(person);
        }

        public void AddPersonToMoraleWorkingList(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.民心;
            this.MoraleWorkingPersons.Add(person);
        }

        public void AddPersonToRecuitmentWork(Person person, Military military)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.补充;
            military.StopTraining();
            military.StopRecruitment();
            person.RecruitmentMilitaryID = military.ID;
            person.RecruitmentMilitary = military;
            military.RecruitmentPersonID = person.ID;
            military.RecruitmentPerson = person;
        }

        public void AddPersonToTechnologyWorkingList(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.技术;
            this.TechnologyWorkingPersons.Add(person);
        }

        public void AddPersonToTrainingWork(Person person, Military military)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            person.WorkKind = ArchitectureWorkKind.训练;
            military.StopTraining();
            military.StopRecruitment();
            person.TrainingMilitaryID = military.ID;
            person.TrainingMilitary = military;
            military.TrainingPersonID = person.ID;
            military.TrainingPerson = person;
        }

        private void AddPersonToTroop(Troop t)
        {
            if (t.TroopIntelligence < (0x4b - t.Leader.Calmness))
            {
                foreach (Person person in this.Persons)
                {
                    if ((!person.Selected && (person.Intelligence >= (0x4b - t.Leader.Calmness))) && (!t.Persons.HasGameObject(person) && ((((person.Strength < t.TroopStrength) && ((person.Intelligence - t.TroopIntelligence) >= 10)) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        t.Persons.Add(person);
                        break;
                    }
                }
            }
            if (t.TroopStrength < 0x4b)
            {
                foreach (Person person in this.Persons)
                {
                    if ((!person.Selected && (person.Strength >= 0x4b)) && ((!t.Persons.HasGameObject(person) && (person.ClosePersons.IndexOf(t.Leader.ID) >= 0)) && ((((person.Strength - t.TroopStrength) >= 10) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        t.Persons.Add(person);
                        break;
                    }
                }
            }
            if (t.TroopCommand < 0x4b)
            {
                foreach (Person person in this.Persons)
                {
                    if ((!person.Selected && (person.Command >= 0x4b)) && ((!t.Persons.HasGameObject(person) && (person.ClosePersons.IndexOf(t.Leader.ID) >= 0)) && ((((person.Command - t.TroopCommand) >= 10) && (person.FightingForce < t.Leader.FightingForce)) && !person.HasLeaderValidCombatTitle)))
                    {
                        person.Selected = true;
                        t.Persons.Add(person);
                        break;
                    }
                }
            }
            foreach (Person person in this.Persons)
            {
                if ((!person.Selected && !t.Persons.HasGameObject(person)) && ((person.FightingForce < t.Leader.FightingForce) && !person.HasLeaderValidCombatTitle))
                {
                    int incrementPerDayOfCombativity = t.IncrementPerDayOfCombativity;
                    bool immunityOfCaptive = t.ImmunityOfCaptive;
                    int routIncrementOfCombativity = t.RoutIncrementOfCombativity;
                    int attackDecrementOfCombativity = t.AttackDecrementOfCombativity;
                    int count = t.CombatMethods.Count;
                    int chanceIncrementOfCriticalStrike = t.ChanceIncrementOfCriticalStrike;
                    int chanceDecrementOfCriticalStrike = t.ChanceDecrementOfCriticalStrike;
                    int chanceIncrementOfChaosAfterCriticalStrike = t.ChanceIncrementOfChaosAfterCriticalStrike;
                    int avoidSurroundedChance = t.AvoidSurroundedChance;
                    int chaosAfterSurroundAttackChance = t.ChaosAfterSurroundAttackChance;
                    int chanceIncrementOfStratagem = t.ChanceIncrementOfStratagem;
                    int chanceDecrementOfStratagem = t.ChanceDecrementOfStratagem;
                    int chanceIncrementOfChaosAfterStratagem = t.ChanceIncrementOfChaosAfterStratagem;
                    t.Persons.Add(person);
                    person.LocationTroop = t;
                    person.ClearInfluence();
                    person.ApplySkills();
                    person.ApplyTitles();
                    person.LocationTroop = null;
                    if (((((((t.IncrementPerDayOfCombativity > incrementPerDayOfCombativity) || (t.ImmunityOfCaptive != immunityOfCaptive)) || ((t.RoutIncrementOfCombativity > routIncrementOfCombativity) || (t.AttackDecrementOfCombativity > attackDecrementOfCombativity))) || ((t.CombatMethods.Count > count) || (((t.TroopStrength >= 70) && (t.ChanceIncrementOfCriticalStrike > chanceIncrementOfCriticalStrike)) && (t.ChanceIncrementOfCriticalStrike <= 50)))) || (((((t.TroopCommand >= 70) && (t.ChanceDecrementOfCriticalStrike > chanceDecrementOfCriticalStrike)) && (t.ChanceDecrementOfCriticalStrike <= 50)) || (((t.ChanceIncrementOfCriticalStrike >= 10) && (t.ChanceIncrementOfChaosAfterCriticalStrike > chanceIncrementOfChaosAfterCriticalStrike)) && (t.ChanceIncrementOfChaosAfterCriticalStrike <= 100))) || (((t.AvoidSurroundedChance <= 80) && (t.AvoidSurroundedChance > avoidSurroundedChance)) || ((t.ChaosAfterSurroundAttackChance <= 20) && (t.ChaosAfterSurroundAttackChance > chaosAfterSurroundAttackChance))))) || ((((t.TroopIntelligence >= 70) && (t.ChanceIncrementOfStratagem > chanceIncrementOfStratagem)) && (t.ChanceIncrementOfStratagem <= 30)) || (((t.TroopIntelligence >= 70) && (t.ChanceDecrementOfStratagem > chanceDecrementOfStratagem)) && (t.ChanceDecrementOfStratagem <= 30)))) || (((t.TroopIntelligence >= 0x55) && (t.ChanceIncrementOfChaosAfterStratagem > chanceIncrementOfChaosAfterStratagem)) && (t.ChanceIncrementOfChaosAfterStratagem <= 100)))
                    {
                        person.Selected = true;
                    }
                    else
                    {
                        t.Persons.Remove(person);
                    }
                }
            }
        }

        public void AddPersonToWorkingList(Person person, ArchitectureWorkKind workKind)
        {
            switch (workKind)
            {
                case ArchitectureWorkKind.赈灾 :
                    this.AddPersonTozhenzaiWorkingList(person);
                    break;
                case ArchitectureWorkKind.农业:
                    this.AddPersonToAgricultureWorkingList(person);
                    break;

                case ArchitectureWorkKind.商业:
                    this.AddPersonToCommerceWorkingList(person);
                    break;

                case ArchitectureWorkKind.技术:
                    this.AddPersonToTechnologyWorkingList(person);
                    break;

                case ArchitectureWorkKind.统治:
                    this.AddPersonToDominationWorkingList(person);
                    break;

                case ArchitectureWorkKind.民心:
                    this.AddPersonToMoraleWorkingList(person);
                    break;

                case ArchitectureWorkKind.耐久:
                    this.AddPersonToEnduranceWorkingList(person);
                    break;
            }
        }

        internal void AddPopulationPack(int days, int population)
        {
            PopulationPack item = new PopulationPack(days, population);
            this.PopulationPacks.Add(item);
        }

        internal void AddSpyPack(Person person, int days)
        {
            SpyPack item = new SpyPack(person, days);
            this.SpyPacks.Add(item);
        }

        public bool AgricultureAvail()
        {
            return (this.Kind.HasAgriculture && this.HasPerson());
        }

        public void AI()
        {
            this.PrepareAI();
            this.ClearFieldAI();
            this.AITreasure();
            this.AITrade();
            this.AIMilitary();
            this.AIFacility();
            this.DiplomaticRelationAI();
            this.AICampaign();
            this.OutsideTacticsAI();
            this.AIWork();
            this.InsideTacticsAI();
            this.AITransfer();
        }

        private void AIFacility()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BuildingFacility < 0))
            {
                List<FacilityKind> list = new List<FacilityKind>();
                List<FacilityKind> list2 = new List<FacilityKind>();
                if (this.PlanFacilityKind != null)
                {
                    if (this.Technology >= this.PlanFacilityKind.TechnologyNeeded)
                    {
                        if ((this.Fund >= this.PlanFacilityKind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.DepositTechniquePointForFacility(this.PlanFacilityKind.PointCost);
                            this.BeginToBuildAFacility(this.PlanFacilityKind);
                            this.PlanFacilityKind = null;
                        }
                        else if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                    else
                    {
                        this.PlanFacilityKind = null;
                    }
                }
                else
                {
                    List<FacilityKind> list3 = new List<FacilityKind>();
                    int facilityPositionLeft = this.FacilityPositionLeft;
                    if (facilityPositionLeft <= 0)
                    {
                        foreach (Facility facility in this.Facilities.GetList())
                        {
                            if (((((this.Technology > facility.TechnologyNeeded) && this.FacilityIsPossibleOverTechnology(facility.TechnologyNeeded)) && (this.Fund > (facility.FundCost * 10))) && (this.BelongedFaction.TechniquePoint > (facility.PointCost * 10))) && (GameObject.Random(facility.Days * facility.PositionOccupied) < 20))
                            {
                                list3.Add(facility.Kind);
                                if (this.FacilityEnabled)
                                {
                                    facility.Influences.PurifyInfluence(this);
                                }
                                this.Facilities.Remove(facility);
                                base.Scenario.Facilities.Remove(facility);
                            }
                        }
                        if (list3.Count == 0)
                        {
                            return;
                        }
                        facilityPositionLeft = this.FacilityPositionLeft;
                    }
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (list3.IndexOf(kind) >= 0)
                        {
                            continue;
                        }
                        if (kind.rongna > 0) continue;  //不造美女设施

                        if (((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((this.Technology >= kind.TechnologyNeeded) && (facilityPositionLeft >= kind.PositionOccupied))) && (!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID))) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID))) && ((kind.FrontLine && ((this.HostileLine || (this.FrontLine && GameObject.Chance(50))) || (!this.FrontLine && GameObject.Chance(10)))) || (!kind.FrontLine && ((!this.FrontLine || (!this.HostileLine && GameObject.Chance(50))) || (this.HostileLine && GameObject.Chance(5))))))
                        {
                            list.Add(kind);
                            if ((this.Fund >= kind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= kind.PointCost))
                            {
                                list2.Add(kind);
                            }
                        }
                    }
                    if (list2.Count > 0)
                    {
                        FacilityKind facilityKind = list2[GameObject.Random(list2.Count)];
                        this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                        this.BeginToBuildAFacility(facilityKind);
                    }
                    else if (list.Count > 0)
                    {
                        this.PlanFacilityKind = list[GameObject.Random(list.Count)];
                        if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                }// end if (this.PlanFacilityKind != null)
            }
        }


        private void AIWork()
        {
            this.AIAutoHire();
            this.StopAllWork();
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && this.HasPerson())
            {
                int num;
                this.ReSortAllWeighingList();
                bool isFundAbundant = this.IsFundAbundant;
                if (this.Fund < ((100 * this.AreaCount) + ((30 - base.Scenario.Date.Day) * this.FacilityMaintenanceCost)))
                {
                    MilitaryList trainingMilitaryList = this.GetTrainingMilitaryList();
                    if (trainingMilitaryList.Count > 0)
                    {
                        trainingMilitaryList.IsNumber = true;
                        trainingMilitaryList.PropertyName = "Weighing";
                        trainingMilitaryList.ReSort();
                        GameObjectList maxObjects = this.trainingPersons.GetMaxObjects(trainingMilitaryList.Count);
                        for (num = 0; num < maxObjects.Count; num++)
                        {
                            this.AddPersonToTrainingWork(maxObjects[num] as Person, trainingMilitaryList[num] as Military);
                        }
                    }
                    int num2 = 0;
                    if ((GameObject.Chance(50) && this.Kind.HasDomination) && (this.Domination < (this.DominationCeiling * 0.8)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasEndurance) && (this.Endurance < (this.EnduranceCeiling * 0.2f)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasMorale) && (this.Morale < Parameters.RecruitmentMorale))
                    {
                        num2++;
                    }
                    if (num2 > 0)
                    {
                        for (num = 0; num < (this.Persons.Count - trainingMilitaryList.Count); num += num2)
                        {
                            foreach (Person person in this.dominationPersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToDominationWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.endurancePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToEnduranceWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.moralePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToMoraleWorkingList(person);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((GameObject.Chance(20) || !this.HasBuildingRouteway) || this.IsFundEnough)
                {
                    float num3;
                    bool flag2 = this.RecentlyAttacked > 0;
                    WorkRateList list3 = new WorkRateList();
                    if ((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) || GameObject.Chance(20))
                    {
                        if (!flag2 || !GameObject.Chance(80))
                        {
                            if (this.Kind.HasAgriculture && (this.Agriculture < this.AgricultureCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueAgriculture)
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Agriculture) / 4f) / ((float)this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Agriculture) / ((float)this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                            }
                            if (this.Kind.HasCommerce && (this.Commerce < this.CommerceCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueCommerce)
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Commerce) / 4f) / ((float)this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Commerce) / ((float)this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                            }
                            if (this.Kind.HasTechnology && (this.Technology < this.TechnologyCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueTechnology || (GameObject.Chance(50) && (this.IsStateAdmin || this.IsRegionCore)))
                                {
                                    list3.AddWorkRate(new WorkRate((((float)this.Technology) / 4f) / ((float)this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float)this.Technology) / ((float)this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                            }
                        }
                        if (this.Kind.HasDomination && (this.Domination < this.DominationCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueDomination)
                            {
                                list3.AddWorkRate(new WorkRate(((((float)this.Domination) / 5f) / 4f) / ((float)this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Domination) / 5f) / ((float)this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                        }
                        if (this.Kind.HasMorale && (this.Morale < this.MoraleCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueMorale)
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Morale) / 4f) / ((float)this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Morale) / ((float)this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                        }
                        if (this.Kind.HasEndurance && (this.Endurance < this.EnduranceCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueEndurance)
                            {
                                list3.AddWorkRate(new WorkRate((((float)this.Endurance) / 4f) / ((float)this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Endurance) / ((float)this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                        }
                    }
                    MilitaryList list4 = this.GetTrainingMilitaryList();
                    if (list4.Count > 0)
                    {
                        if (flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.训练));
                        }
                        else
                        {
                            num3 = 0f;
                            foreach (Military military in list4)
                            {
                                num3 += ((float)military.TrainingWeighing) / ((float)military.MaxTrainingWeighing);
                            }
                            num3 /= (float)list4.Count;
                            if (this.BelongedSection.AIDetail.ValueTraining)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.训练));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.训练));
                            }
                        }
                    }
                    MilitaryList recruitmentMilitaryList = null;
                    if (((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) && this.Kind.HasPopulation) && ((flag2 || (GameObject.Random(GameObject.Square(((int)this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0)) && this.RecruitmentAvail()))
                    {
                        recruitmentMilitaryList = this.GetRecruitmentMilitaryList();
                        if ((this.ArmyScale < this.FewArmyScale) && flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if (((this.ArmyScale < this.FewArmyScale) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(20)) || GameObject.Chance(5))) && this.IsFoodAbundant)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if ((((GameObject.Chance(1) || (this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(5))) && ((this.ArmyScale >= this.LargeArmyScale) && this.IsFoodAbundant)) || ((((this.ArmyScale < this.LargeArmyScale) && this.IsFoodEnough) && (((this.IsImportant || (this.AreaCount > 2)) && (this.Population > this.Kind.PopulationBoundary)) || (((this.AreaCount <= 2) && !this.IsImportant) && (this.Population > (this.RecruitmentPopulationBoundary / 2))))) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(60)) || GameObject.Chance(15)))) && (GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length) >= (int)this.BelongedFaction.Leader.StrategyTendency))
                        {
                            num3 = 0f;
                            foreach (Military military in recruitmentMilitaryList)
                            {
                                num3 += ((float)military.RecruitmentWeighing) / ((float)military.MaxRecruitmentWeighing);
                            }
                            num3 /= (float)recruitmentMilitaryList.Count;
                            if (this.BelongedSection.AIDetail.ValueRecruitment)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.补充));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.补充));
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        for (num = 0; num < this.Persons.Count; num += list3.Count)
                        {
                            foreach (WorkRate rate in list3.RateList)
                            {
                                switch (rate.workKind)
                                {
                                    case ArchitectureWorkKind.农业:
                                        foreach (Person person in this.agriculturePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.AgricultureAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToAgricultureWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.商业:
                                        foreach (Person person in this.commercePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.CommerceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToCommerceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.技术:
                                        foreach (Person person in this.technologyPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.TechnologyAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToTechnologyWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.统治:
                                        foreach (Person person in this.dominationPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.DominationAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToDominationWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.民心:
                                        foreach (Person person in this.moralePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.MoraleAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToMoraleWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.耐久:
                                        foreach (Person person in this.endurancePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.EnduranceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToEnduranceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.训练:
                                        foreach (Person person in this.trainingPersons)
                                        {
                                            if (person.WorkKind == ArchitectureWorkKind.无)
                                            {
                                                foreach (Military military in list4.GetRandomList())
                                                {
                                                    if (military.RecruitmentPersonID < 0)
                                                    {
                                                        this.AddPersonToTrainingWork(person, military);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.补充:
                                        foreach (Person person in this.recruitmentPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.RecruitmentAbility >= 120)))
                                            {
                                                if (recruitmentMilitaryList != null)
                                                {
                                                    foreach (Military military in recruitmentMilitaryList.GetRandomList())
                                                    {
                                                        if (military.TrainingPersonID < 0)
                                                        {
                                                            this.AddPersonToRecuitmentWork(person, military);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if (this.Kind.HasPopulation && (flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)))
                    {
                        if (((!flag2 && !this.BelongedSection.AIDetail.ValueNewMilitary) && !GameObject.Chance(10)) || (this.ArmyScale >= this.LargeArmyScale))
                        {
                            MilitaryList list6 = new MilitaryList();
                            foreach (Military military in this.Militaries)
                            {
                                if ((((military.Scales < 15) && (military.Quantity > 0)) && (military.Morale < (military.MoraleCeiling / 2))) && ((military.Kind.PointsPerSoldier <= 1) && (this.BelongedFaction.TechniquePoint > (military.Quantity * (military.Kind.PointsPerSoldier + 1)))))
                                {
                                    list6.Add(military);
                                }
                            }
                            foreach (Military military in list6)
                            {
                                this.DisbandMilitary(military);
                            }
                        }
                        else if (((this.Population > this.RecruitmentPopulationBoundary) || flag2) || ((this.Population >= 10000) && GameObject.Chance(5)))
                        {
                            bool flag3 = true;
                            foreach (Military military in this.Militaries)
                            {
                                if (military.Scales < 15)
                                {
                                    flag3 = false;
                                    break;
                                }
                            }
                            if (flag3)
                            {
                                this.AIRecruitment(false);
                            }
                            else if ((this.ValueWater && !this.HasShuijun()) && this.HasShuijunMilitaryKind())
                            {
                                this.AIRecruitment(true);
                            }
                        }
                    }
                }
            }
        }



        private void AIAutoHire()
        {
            if ((this.BelongedFaction != null) && (((!this.HireFinished && (this.NoFactionPersonCount > 0)) && (this.Fund >= this.HirePersonFund)) && (GameObject.Random(this.HirablePersonCount + 1) >= 1)))
            {
                this.HireNoFactionPerson();
            }
        }

        private void AIAutoReward()
        {
            if ((this.BelongedFaction != null) && (this.Fund >= this.RewardPersonFund))
            {
                this.RewardPersonsUnderLoyalty(100);
            }
        }

        private void AIAutoSearch()
        {
            foreach (Person person in this.Persons.GetList())
            {
                if (person.WorkKind == ArchitectureWorkKind.无)
                {
                    person.GoForSearch();
                }
            }
        }

        public void AICampaign()
        {
            this.DefensiveCampaign();
            this.OffensiveCampaign();
        }
        /*
        private void AIFacility()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BuildingFacility < 0))
            {
                List<FacilityKind> list = new List<FacilityKind>();
                List<FacilityKind> list2 = new List<FacilityKind>();
                if (this.PlanFacilityKind != null)
                {
                    if (this.Technology >= this.PlanFacilityKind.TechnologyNeeded)
                    {
                        if ((this.Fund >= this.PlanFacilityKind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.DepositTechniquePointForFacility(this.PlanFacilityKind.PointCost);
                            this.BeginToBuildAFacility(this.PlanFacilityKind);
                            this.PlanFacilityKind = null;
                        }
                        else if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                    else
                    {
                        this.PlanFacilityKind = null;
                    }
                }
                else
                {
                    List<FacilityKind> list3 = new List<FacilityKind>();
                    int facilityPositionLeft = this.FacilityPositionLeft;
                    if (facilityPositionLeft <= 0)
                    {
                        foreach (Facility facility in this.Facilities.GetList())
                        {
                            if (((((this.Technology > facility.TechnologyNeeded) && this.FacilityIsPossibleOverTechnology(facility.TechnologyNeeded)) && (this.Fund > (facility.FundCost * 10))) && (this.BelongedFaction.TechniquePoint > (facility.PointCost * 10))) && (GameObject.Random(facility.Days * facility.PositionOccupied) < 20))
                            {
                                list3.Add(facility.Kind);
                                if (this.FacilityEnabled)
                                {
                                    facility.Influences.PurifyInfluence(this);
                                }
                                this.Facilities.Remove(facility);
                                base.Scenario.Facilities.Remove(facility);
                            }
                        }
                        if (list3.Count == 0)
                        {
                            return;
                        }
                        facilityPositionLeft = this.FacilityPositionLeft;
                    }
                    foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
                    {
                        if (list3.IndexOf(kind) >= 0)
                        {
                            continue;
                        }
                        if (kind.rongna > 0) continue;  //不造美女设施

                        if (((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((this.Technology >= kind.TechnologyNeeded) && (facilityPositionLeft >= kind.PositionOccupied))) && (!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID))) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID))) && ((kind.FrontLine && ((this.HostileLine || (this.FrontLine && GameObject.Chance(50))) || (!this.FrontLine && GameObject.Chance(10)))) || (!kind.FrontLine && ((!this.FrontLine || (!this.HostileLine && GameObject.Chance(50))) || (this.HostileLine && GameObject.Chance(5))))))
                        {
                            list.Add(kind);
                            if ((this.Fund >= kind.FundCost) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) >= kind.PointCost))
                            {
                                list2.Add(kind);
                            }
                        }
                    }
                    if (list2.Count > 0)
                    {
                        FacilityKind facilityKind = list2[GameObject.Random(list2.Count)];
                        this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost);
                        this.BeginToBuildAFacility(facilityKind);
                    }
                    else if (list.Count > 0)
                    {
                        this.PlanFacilityKind = list[GameObject.Random(list.Count)];
                        if (GameObject.Chance(0x21) && ((this.BelongedFaction.TechniquePoint + this.BelongedFaction.TechniquePointForFacility) < this.PlanFacilityKind.PointCost))
                        {
                            this.BelongedFaction.SaveTechniquePointForFacility(this.PlanFacilityKind.PointCost / this.PlanFacilityKind.Days);
                        }
                    }
                }// end if (this.PlanFacilityKind != null)
            }
        }
        */
        private void AIFoodTransfer()
        {
            Routeway connectedRouteway;
            int food;
            if (this.IsFoodAbundant || ((!this.HostileLine && (!this.FrontLine || !GameObject.Chance(20))) && !GameObject.Chance(1)))
            {
                if (this.TransferFoodArchitecture != null)
                {
                    LinkNode node = null;
                    this.AIAllLinkNodes.TryGetValue(this.TransferFoodArchitecture.ID, out node);
                    if (node != null)
                    {
                        connectedRouteway = this.GetRouteway(node, true);
                        if ((connectedRouteway != null) && (connectedRouteway.LastPoint != null))
                        {
                            if (this.BelongedFaction != this.TransferFoodArchitecture.BelongedFaction)
                            {
                                connectedRouteway.RemoveAfterClose = true;
                                connectedRouteway.Close();
                                this.TransferFoodArchitecture = null;
                            }
                            else
                            {
                                connectedRouteway.DestinationToEnd();
                                if (connectedRouteway.EndArchitecture == this.TransferFoodArchitecture)
                                {
                                    food = this.Food - this.EnoughFood;
                                    if ((food >= 0x186a0) || (food > this.TransferFoodArchitecture.FoodCostPerDayOfAllMilitaries))
                                    {
                                        if (connectedRouteway.IsActive)
                                        {
                                            int abundantFood = this.TransferFoodArchitecture.AbundantFood;
                                            if (food > abundantFood)
                                            {
                                                food = abundantFood;
                                            }
                                            this.DecreaseFood(food);
                                            this.TransferFoodArchitecture.IncreaseFood((int) (food * (1f - (connectedRouteway.LastPoint.ConsumptionRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures))));
                                            this.TransferFoodArchitecture = null;
                                        }
                                        else if ((connectedRouteway.LastPoint.BuildFundCost * 2) <= this.Fund)
                                        {
                                            connectedRouteway.Building = true;
                                        }
                                    }
                                    else
                                    {
                                        this.TransferFoodArchitecture = null;
                                    }
                                }
                                else
                                {
                                    this.TransferFoodArchitecture = null;
                                }
                            }
                        }
                        else
                        {
                            this.TransferFoodArchitecture = null;
                        }
                    }
                    else
                    {
                        this.TransferFoodArchitecture = null;
                    }
                }
            }
            else
            {
                GameObjectList list = new GameObjectList();
                foreach (LinkNode node in this.AIAllLinkNodes.Values)
                {
                    if (node.Level > 3)
                    {
                        break;
                    }
                    if (node.A.BelongedFaction == this.BelongedFaction)
                    {
                        if (node.A.BelongedSection == this.BelongedSection)
                        {
                            list.Add(node.A);
                        }
                        else if (node.A.BelongedSection.AIDetail.AllowFoodTransfer && ((node.A.BelongedSection.OrientationSection == this.BelongedSection) || (node.A.BelongedSection.OrientationSection == null)))
                        {
                            list.Add(node.A);
                        }
                    }
                }
                if (list.Count > 1)
                {
                    list.PropertyName = "Food";
                    list.IsNumber = true;
                    list.ReSort();
                }
                foreach (Architecture architecture in list)
                {
                    connectedRouteway = architecture.GetConnectedRouteway(this);
                    if ((connectedRouteway == null) || (connectedRouteway.LastPoint == null))
                    {
                        connectedRouteway = this.GetConnectedRouteway(architecture);
                    }
                    if ((connectedRouteway != null) && (connectedRouteway.LastPoint != null))
                    {
                        food = 0;
                        if (architecture.IsFoodTwiceAbundant && (architecture.RecentlyAttacked <= 0))
                        {
                            food = (architecture.FoodCostPerDayOfAllMilitaries * 80) / 5;
                            if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                            {
                                food *= 2;
                                if (food > architecture.Food)
                                {
                                    food = architecture.Food;
                                }
                            }
                        }
                        else if (architecture.IsFoodAbundant && !architecture.HostileLine)
                        {
                            food = (architecture.FoodCostPerDayOfAllMilitaries * 40) / 5;
                            if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                            {
                                food *= 2;
                                if (food > architecture.Food)
                                {
                                    food = architecture.Food;
                                }
                            }
                        }
                        if (food >= 0x186a0)
                        {
                            architecture.DecreaseFood(food);
                            this.IncreaseFood((int) (food * (1f - (connectedRouteway.LastPoint.ConsumptionRate * this.BelongedFaction.RateOfFoodTransportBetweenArchitectures))));
                        }
                        else
                        {
                            architecture.TransferFoodArchitecture = null;
                        }
                    }
                    else if (architecture.TransferFoodArchitecture == null)
                    {
                        if ((((architecture.RecentlyAttacked == 0) && (!architecture.HostileLine || GameObject.Chance(20))) && (architecture.Food >= ((architecture.EnoughFood + this.EnoughFood) + 0x186a0))) && ((this.TransferFoodArchitectureCount <= GameObject.Random(2)) && (architecture.Food >= 0x61a80)))
                        {
                            architecture.TransferFoodArchitecture = this;
                        }
                    }
                    else if ((((architecture.BelongedFaction != this.BelongedFaction) || (this.BelongedFaction != architecture.TransferFoodArchitecture.BelongedFaction)) || ((architecture.RecentlyAttacked > 0) || architecture.TransferFoodArchitecture.IsFoodAbundant)) || ((architecture.Food < (architecture.EnoughFood + ((this.EnoughFood * 3) / 2))) && (architecture.Food < 0x61a80)))
                    {
                        architecture.TransferFoodArchitecture = null;
                    }
                }
            }
        }

        private void AIFundTransfer()
        {
            int fund;
            if (!this.IsFundEnough)
            {
                int num = this.EnoughFund - this.Fund;
                int num2 = 0;
                GameObjectList list = new GameObjectList();
                foreach (Architecture architecture in this.GetOtherArchitectureList())
                {
                    if (architecture.BelongedSection == this.BelongedSection)
                    {
                        list.Add(architecture);
                    }
                    else if (architecture.BelongedSection.AIDetail.AllowFundTransfer && ((architecture.BelongedSection.OrientationSection == this.BelongedSection) || (architecture.BelongedSection.OrientationSection == null)))
                    {
                        list.Add(architecture);
                    }
                }
                foreach (Architecture architecture in list)
                {
                    fund = 0;
                    if (architecture.Fund > architecture.AbundantFund)
                    {
                        fund = 0x3e8;
                        if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                        {
                            fund *= 2;
                            if (fund > architecture.Fund)
                            {
                                fund = architecture.Fund;
                            }
                        }
                    }
                    else if (architecture.Fund > architecture.EnoughFund)
                    {
                        fund = 500;
                        if (architecture.BelongedSection.OrientationSection == this.BelongedSection)
                        {
                            fund *= 2;
                            if (fund > architecture.Fund)
                            {
                                fund = architecture.Fund;
                            }
                        }
                    }
                    if (fund > 0)
                    {
                        architecture.DecreaseFund(fund);
                        this.AddFundPack(fund, base.Scenario.GetTranferFundDays(architecture, this));
                        num2 += fund;
                    }
                    if (num2 > num)
                    {
                        break;
                    }
                }
            }
            else if (((this.TransferFundArchitecture != null) && (this.TransferFundArchitecture.BelongedFaction == this.BelongedFaction)) && (this.TransferFundArchitecture.Fund < this.TransferFundArchitecture.FundCeiling))
            {
                fund = this.Fund - this.EnoughFund;
                if (fund > 500)
                {
                    this.DecreaseFund(fund);
                    this.TransferFundArchitecture.AddFundPack(fund, base.Scenario.GetTranferFundDays(this, this.TransferFundArchitecture));
                }
            }
            else if (this.BelongedSection.AIDetail.AllowFundTransfer && this.IsFundAbundant)
            {
                foreach (Architecture architecture in this.GetOtherArchitectureList())
                {
                    if (!architecture.IsFundEnough)
                    {
                        fund = 0x3e8;
                        if (fund > this.Fund)
                        {
                            fund = this.Fund;
                        }
                        if (fund > 0)
                        {
                            this.DecreaseFund(fund);
                            architecture.AddFundPack(fund, base.Scenario.GetTranferFundDays(this, architecture));
                        }
                    }
                    if (!this.IsFundAbundant)
                    {
                        break;
                    }
                }
            }
        }

        private void AIMilitary()
        {
            foreach (Military military in this.GetLevelUpMilitaryList())
            {
                this.LevelUpMilitary(military);
            }
        }

        private void AIMilitaryTransfer()
        {
            List<LinkNode> list;
            Routeway routeway;
            if (((!this.HasPerson() || !this.HasHostileTroopsInView()) || (this.RecentlyAttacked <= 0)) || ((!this.HasCampaignableMilitary() && (this.DefensiveLegion == null)) && !this.IsImportant))
            {
                if (!this.HasHostileTroopsInView())
                {
                    LinkNode node;
                    if (this.BelongedSection.AIDetail.AllowOffensiveCampaign)
                    {
                        if ((!this.HasPerson() || !this.HasCampaignableMilitary()) || (this.GetAllAvailableArea(false).Count == 0))
                        {
                            return;
                        }
                        foreach (Legion legion in this.BelongedFaction.Legions)
                        {
                            if ((((legion.WillArchitecture.BelongedFaction != null) && !this.BelongedFaction.IsFriendly(legion.WillArchitecture.BelongedFaction)) && this.BelongedFaction.IsArchitectureKnown(legion.WillArchitecture)) && (legion.Troops.Count < 30))
                            {
                                node = null;
                                if (this.AIAllLinkNodes.TryGetValue(legion.WillArchitecture.ID, out node))
                                {
                                    if ((node.Level > 2) || !this.IsSelfHelpArmyEnough(node))
                                    {
                                        continue;
                                    }
                                    if (legion.HasTroopWillArchitectureIsWillArchitecture && (legion.GetLegionTroopFightingForce() < (legion.GetLegionHostileTroopFightingForceInView() * 2)))
                                    {
                                        routeway = this.GetRouteway(node, true);
                                        if ((((routeway != null) && (routeway.LastPoint.ConsumptionRate <= 0.3f)) && (!routeway.ByPassHostileArchitecture && (this.Fund >= (routeway.LastPoint.BuildFundCost * 2)))) && this.IsSelfFoodEnough(node, routeway))
                                        {
                                            routeway.Building = true;
                                            this.BuildOffensiveTroop(legion.WillArchitecture, node.Kind, true);
                                            if (!(this.HasCampaignableMilitary() && (this.GetAllAvailableArea(false).Count != 0)))
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if ((this.HasPerson() && this.HasCampaignableMilitary()) && (this.GetAllAvailableArea(false).Count != 0))
                    {
                        if ((((GameObject.Random(GameObject.Square(((int) this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0) && ((this.IsFoodAbundant || (this.IsFoodEnough && GameObject.Chance(0x21))) || GameObject.Chance(5))) && (((base.Scenario.Date.Season != GameSeason.冬) || GameObject.Chance(5)) && (!this.HostileLine || GameObject.Chance(10)))) && ((GameObject.Chance(20) && this.BelongedSection.AIDetail.AllowMilitaryTransfer) || (this.BelongedSection.AIDetail.ValueOffensiveCampaign && GameObject.Chance(50))))
                        {
                            GameObjectList list2 = null;
                            if ((this.BelongedSection.AIDetail.AllowMilitaryTransfer && (this.BelongedSection.OrientationSection != null)) && (this.BelongedSection.OrientationSection.BelongedFaction == this.BelongedFaction))
                            {
                                list2 = this.BelongedSection.OrientationSection.Architectures.GetList();
                            }
                            else
                            {
                                list2 = this.BelongedSection.Architectures.GetList();
                            }
                            foreach (Architecture architecture in list2.GetList())
                            {
                                if (architecture != this)
                                {
                                    node = null;
                                    this.AIAllLinkNodes.TryGetValue(architecture.ID, out node);
                                    if ((node == null) || (node.Level > 3))
                                    {
                                        list2.Remove(architecture);
                                    }
                                }
                            }
                            if (list2.Count > 0)
                            {
                                if (list2.Count > 1)
                                {
                                    list2.PropertyName = "ArmyScaleWeighing";
                                    list2.IsNumber = true;
                                    list2.ReSort();
                                }
                                Architecture destination = list2[0] as Architecture;
                                if (destination != this)
                                {
                                    node = null;
                                    this.AIAllLinkNodes.TryGetValue(destination.ID, out node);
                                    if (((node != null) && (destination.ArmyScale < (destination.LargeArmyScale * (1.0 + (destination.HostileLine ? 0.5 : 0.0))))) && this.IsSelfMoveArmyEnough(node))
                                    {
                                        if (this.HasRouteway(node, true))
                                        {
                                            if ((this.BelongedSection.OrientationFaction == null) || (this.GetDistanceFromFaction(this.BelongedSection.OrientationFaction) > destination.GetDistanceFromFaction(this.BelongedSection.OrientationFaction)))
                                            {
                                                this.BuildOffensiveTroop(destination, node.Kind, false);
                                            }
                                            return;
                                        }
                                        if (list2.Count > 1)
                                        {
                                            list2.PropertyName = "Population";
                                            list2.IsNumber = true;
                                            list2.ReSort();
                                            if (list2[0] != destination)
                                            {
                                                destination = list2[0] as Architecture;
                                                this.AIAllLinkNodes.TryGetValue(destination.ID, out node);
                                                if ((node != null) && this.HasRouteway(node, true))
                                                {
                                                    this.BuildOffensiveTroop(destination, node.Kind, false);
                                                    return;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if ((GameObject.Random(GameObject.Square(((int) this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0) && (((this.Fund < (100 * this.AreaCount)) && (this.ExpectedFund < (100 * this.AreaCount))) || ((((this.Domination > (this.DominationCeiling * 0.8)) && (this.Morale >= Parameters.RecruitmentMorale)) && (this.Endurance >= (this.EnduranceCeiling * 0.2f))) && ((((((this.IsImportant && this.HostileLine) && (this.ArmyScale > this.LargeArmyScale)) || ((this.IsImportant && !this.HostileLine) && (this.ArmyScale > this.NormalArmyScale))) || (((!this.IsImportant && this.HostileLine) && (this.ArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && !this.HostileLine) && (this.ArmyScale > this.FewArmyScale)))) || (this.Kind.HasPopulation && (this.ArmyQuantity > this.Population))) || (this.Kind.HasPopulation && (this.ArmyScale > (this.Population / 0x3e8)))))))
                        {
                            list = new List<LinkNode>();
                            foreach (LinkNode node_0a1 in this.AIAllLinkNodes.Values)
                            {
                                if (node_0a1.Level > 3)
                                {
                                    break;
                                }
                                if (((node_0a1.A.BelongedFaction == this.BelongedFaction) && ((node_0a1.A.RecentlyAttacked > 0) || GameObject.Chance(5))) && ((node_0a1.A.HasOffensiveMilitary() && ((node_0a1.A.BelongedSection == this.BelongedSection) || (this.BelongedSection.AIDetail.AllowMilitaryTransfer && ((this.BelongedSection.OrientationSection == node_0a1.A.BelongedSection) || (this.BelongedSection.OrientationSection == null))))) && (node_0a1.A.IsFoodEnough && (((((node_0a1.A.IsImportant && node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.LargeArmyScale)) || ((node_0a1.A.IsImportant && !node_0a1.A.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.NormalArmyScale))) || ((!node_0a1.A.IsImportant && this.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.NormalArmyScale))) || ((!node_0a1.A.IsImportant && !this.HostileLine) && (node_0a1.A.ArmyScale < node_0a1.A.FewArmyScale))))))
                                {
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                    routeway = this.GetRouteway(node_0a1, true);
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                    if ((((routeway != null) && !routeway.ByPassHostileArchitecture) && (((routeway.LastPoint.BuildFundCost * 2) <= this.Fund) && (node_0a1.A.IsFoodAbundant || this.IsSelfFoodEnough(node_0a1, routeway)))) && ((node_0a1.A.Kind.HasPopulation && (node_0a1.A.HasHostileTroopsInView() || ((GameObject.Chance(10) && (node_0a1.A.ArmyQuantity < (node_0a1.A.Population / 2))) && (node_0a1.A.Population > (10000 * this.AreaCount))))) || (!node_0a1.A.Kind.HasPopulation && node_0a1.A.HasHostileTroopsInView())))
                                    {
                                        list.Add(node_0a1);
                                    }
                                }
                            }
                            if (list.Count > 0)
                            {
                                int num = -2147483648;
                                LinkNode node3 = null;
                                bool flag = false;
                                foreach (LinkNode node_0a2 in list)
                                {
                                    int num2 = node_0a2.A.Population / 0x2710;
                                    bool flag2 = node_0a2.A.RecentlyAttacked > 0;
                                    if (flag2)
                                    {
                                        num2 *= 10;
                                    }
                                    if (num2 > num)
                                    {
                                        num = num2;
                                        node3 = node_0a2;
                                        flag = flag2;
                                    }
                                }
                                if ((node3 != null) && (this.TargetingTroopCount(node3.A) < 4))
                                {
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.4f;
                                    routeway = this.GetRouteway(node3, true);
                                    this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
                                    if (routeway != null)
                                    {
                                        if (!routeway.IsActive && flag)
                                        {
                                            routeway.Building = true;
                                        }
                                        if (flag || GameObject.Chance(10))
                                        {
                                            this.BuildOffensiveTroop(node3.A, node3.Kind, node3.A.RecentlyAttacked > 0);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else if ((((GameObject.Chance(20) || this.HasRelationUnderZeroHostileTroopsInView()) && ((this.IsImportant && (this.ArmyScale < this.NormalArmyScale)) || (!this.IsImportant && (this.ArmyScale < this.FewArmyScale)))) && ((this.Endurance >= (0.1 * this.EnduranceCeiling)) && ((this.IsImportant || !this.Kind.HasPopulation) || (this.Population >= (this.RecruitmentPopulationBoundary / 2))))) && (this.TargetingTroopCount(this) < 10))
            {
                LinkNode node2;
                list = new List<LinkNode>();
                foreach (LinkNode node in this.AIAllLinkNodes.Values)
                {
                    if (node.Level > 2)
                    {
                        break;
                    }
                    if (((((this.IsFriendly(node.A.BelongedFaction) && (node.A.BelongedSection != null)) && (node.A.BelongedSection.AIDetail != null)) && node.A.BelongedSection.AIDetail.AutoRun) && ((!node.A.HostileLine || GameObject.Chance(10)) && !node.A.HasHostileTroopsInView())) && this.IsNodeHelpArmyEnough(node))
                    {
                        node2 = null;
                        node.A.AIAllLinkNodes.TryGetValue(base.ID, out node2);
                        if (node2 != null)
                        {
                            routeway = node.A.GetRouteway(node2, true);
                            if ((((routeway != null) && !routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * 2) <= node.A.Fund)) && (this.IsFoodAbundant || this.IsNodeFoodEnough(node, routeway)))
                            {
                                list.Add(node);
                            }
                        }
                    }
                }
                if (list.Count > 0)
                {
                    foreach (LinkNode node in list)
                    {
                        node2 = null;
                        node.A.AIAllLinkNodes.TryGetValue(base.ID, out node2);
                        if (node2 != null)
                        {
                            routeway = node.A.GetRouteway(node2, true);
                            if (routeway != null)
                            {
                                if (!routeway.IsActive)
                                {
                                    routeway.Building = true;
                                }
                                node.A.BuildOffensiveTroop(this, node.Kind, true);
                                if (GameObject.Chance(10))
                                {
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void AIPersonTransfer()
        {
            int num2;
            if ((this.MilitaryCount == 0) && ((this.IsImportant || (this.AreaCount > 1)) || (this.Population > this.RecruitmentPopulationBoundary)))
            {
                this.AIRecruitment(false);
            }
            if ((((this.BelongedFaction.ArchitectureCount > 1) && (this.PersonCount > this.MilitaryCount)) && (this.RecentlyAttacked > 0)) && ((this.Endurance == 0) || ((this.Endurance < 30) && GameObject.Chance(0x21))))
            {
                int num = this.PersonCount - this.MilitaryCount;
                GameObjectList list = new GameObjectList();
                list = this.Persons.GetList();
                if (list.Count > 1)
                {
                    list.IsNumber = true;
                    list.SmallToBig = true;
                    list.PropertyName = "FightingForce";
                    list.ReSort();
                }
                Architecture capital = this.BelongedFaction.Capital;
                if (capital == this)
                {
                    ArchitectureList otherArchitectureList = this.GetOtherArchitectureList();
                    if (otherArchitectureList.Count > 1)
                    {
                        otherArchitectureList.IsNumber = true;
                        otherArchitectureList.PropertyName = "ArmyScaleWeighing";
                        otherArchitectureList.ReSort();
                    }
                    capital = otherArchitectureList[0] as Architecture;
                }
                num2 = 0;
                while (num2 < num)
                {
                    (list[num2] as Person).MoveToArchitecture(capital);
                    this.RemovePerson(list[num2] as Person);
                    if (GameObject.Chance(20))
                    {
                        break;
                    }
                    num2++;
                }
            }
            else if (((this.PersonCount + this.MovingPersons.Count) < this.MilitaryCount) || (this.PlanArchitecture != null))
            {
                if (this.RecentlyAttacked > 0)
                {
                    int num3 = (this.MilitaryCount - this.PersonCount) - this.MovingPersons.Count;
                    PersonList list3 = new PersonList();
                    foreach (Architecture architecture2 in GameObject.Chance(20) ? this.BelongedFaction.Architectures : this.BelongedSection.Architectures)
                    {
                        if ((architecture2 != this) && (((architecture2.BelongedSection.AIDetail != null) && architecture2.BelongedSection.AIDetail.AutoRun) && (((architecture2.RecentlyAttacked <= 0) && ((architecture2.PersonCount + architecture2.MovingPersons.Count) >= architecture2.MilitaryCount)) || (((architecture2.Fund < (100 * this.AreaCount)) && (architecture2.Domination >= (architecture2.DominationCeiling * 0.8))) && (architecture2.Endurance >= (architecture2.EnduranceCeiling * 0.2f))))))
                        {
                            foreach (Person person in architecture2.Persons)
                            {
                                if ((!architecture2.HasFollowedLeaderMilitary(person) && (GameObject.Chance(10) || !architecture2.HasExperiencedLeaderMilitary(person))) && (person.Command >= 40))
                                {
                                    list3.Add(person);
                                }
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        if (list3.Count > 1)
                        {
                            list3.IsNumber = true;
                            list3.PropertyName = "FightingForce";
                            list3.ReSort();
                        }
                        for (num2 = 0; (num2 < num3) && (num2 < list3.Count); num2++)
                        {
                            Architecture locationArchitecture = (list3[num2] as Person).LocationArchitecture;
                            (list3[num2] as Person).MoveToArchitecture(this);
                            locationArchitecture.RemovePerson(list3[num2] as Person);
                        }
                    }
                }
            }
            else if (this.HasPerson() && GameObject.Chance(10))
            {
                PersonList list4 = new PersonList();
                if (this.Kind.HasPopulation && (this.Population < (0x3e8 * this.AreaCount)))
                {
                    if (this.IsCapital && (this.Fund >= this.ChangeCapitalCost))
                    {
                        Architecture newCapital = this.BelongedFaction.SelectNewCapital();
                        if (newCapital != this)
                        {
                            this.DecreaseFund(this.ChangeCapitalCost);
                            this.BelongedFaction.ChangeCapital(newCapital);
                        }
                    }
                    foreach (Person person in this.Persons)
                    {
                        if (!this.HasFollowedLeaderMilitary(person) && (GameObject.Chance(10) || !this.HasExperiencedLeaderMilitary(person)))
                        {
                            list4.Add(person);
                        }
                    }
                }
                else
                {
                    foreach (Person person in this.Persons)
                    {
                        if ((person.WorkKind == ArchitectureWorkKind.无) && (!this.HasFollowedLeaderMilitary(person) && (GameObject.Chance(10) || !this.HasExperiencedLeaderMilitary(person))))
                        {
                            list4.Add(person);
                        }
                    }
                }
                if (list4.Count > 0)
                {
                    ArchitectureList list5 = new ArchitectureList();
                    foreach (Architecture architecture2 in (base.Scenario.Date.Day == 1) ? this.BelongedFaction.Architectures : this.BelongedSection.Architectures)
                    {
                        if ((architecture2 != this) && ((((architecture2.IsRegionCore || architecture2.IsStateAdmin) || (architecture2.Kind.HasPopulation && (architecture2.Population > this.Population))) || GameObject.Chance(5)) || ((architecture2.Fund >= (100 * this.AreaCount)) && ((((architecture2.PersonCount + architecture2.MovingPersons.Count) < architecture2.MilitaryCount) || (architecture2.Domination < (architecture2.DominationCeiling * 0.8))) || (architecture2.Endurance < (architecture2.EnduranceCeiling * 0.2f))))))
                        {
                            list5.Add(architecture2);
                        }
                    }
                    if (list5.Count > 0)
                    {
                        if (list5.Count > 1)
                        {
                            list5.PropertyName = "ArmyScaleWeighing";
                            list5.IsNumber = true;
                            list5.ReSort();
                        }
                        for (num2 = 0; (num2 < list4.Count) && (num2 < list5.Count); num2++)
                        {
                            (list4[num2] as Person).MoveToArchitecture(list5[num2] as Architecture);
                            this.RemovePerson(list4[num2] as Person);
                        }
                    }
                }
            }
        }

        private void AIRecruitment(bool water)
        {
            if (this.Population > 0)
            {
                MilitaryKind current;
                Dictionary<int, MilitaryKind>.ValueCollection.Enumerator enumerator;
                MilitaryKindList list = new MilitaryKindList();
                using (enumerator = this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this))
                        {
                            if (current.ID != 29)
                                list.Add(current);
                        }
                    }
                }
                using (enumerator = this.PrivateMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this))
                        {
                            if (current.ID != 29)
                                list.Add(current);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    if (GameObject.Chance(90))
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                        //the problem: what if those merit values are all the same?
                        //this results in AI tends to create qibian other than bubian
                        int idCap = list.Count / 2;
                        if (list.Count > 1)
                        {
                            for (int i = idCap; i < list.Count; i++)
                            {
                                if ((list[i] as MilitaryKind).Merit == (list[i - 1] as MilitaryKind).Merit)
                                {
                                    idCap++;
                                }
                            }
                        }
                        //current = list[GameObject.Random(list.Count / 2)] as MilitaryKind;
                        current = list[GameObject.Random(idCap)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }
                    else
                    {
                        current = list[GameObject.Random(list.Count)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }
                }
            }
        }


        /*
        private void AIRecruitment(bool water)
        {
            if (this.Population > 0)
            {
                MilitaryKind current;
                Dictionary<int, MilitaryKind>.ValueCollection.Enumerator enumerator;
                MilitaryKindList list = new MilitaryKindList();
                using (enumerator = this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this))
                        {
                            if (current.ID!=29)
                                list.Add(current);
                        }
                    }
                }
                using (enumerator = this.PrivateMilitaryKinds.MilitaryKinds.Values.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        current = enumerator.Current;
                        if (((this.ValueWater == (current.Type == MilitaryType.水军)) || (!water && GameObject.Chance(20))) && current.CreateAvail(this))
                        {
                            if (current.ID != 29)
                                list.Add(current);
                        }
                    }
                }
                if (list.Count > 0)
                {
                    if (GameObject.Chance(90))
                    {
                        list.PropertyName = "Merit";
                        list.IsNumber = true;
                        list.ReSort();
                        current = list[GameObject.Random(list.Count / 2)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }
                    else
                    {
                        current = list[GameObject.Random(list.Count)] as MilitaryKind;
                        if ((!this.ValueWater || (current.Type == MilitaryType.水军)) || GameObject.Chance(20))
                        {
                            this.CreateMilitary(current);
                        }
                    }
                }
            }
        }
        */
        private void AIResourceTransfer()
        {
            this.AIFundTransfer();
            this.AIFoodTransfer();
        }

        private void AITrade()
        {
            if ((base.Scenario.Date.Day % 10) == 1)
            {
                int num;
                if (this.BuyFoodAvail())
                {
                    if ((((this.PlanArchitecture == null) && (this.PlanFacilityKind == null)) && (this.BelongedFaction.PlanTechniqueArchitecture != this)) && (((this.Food < (this.FoodCeiling / 2)) || GameObject.Chance(10)) && this.IsFundAbundant))
                    {
                        num = this.Fund - this.AbundantFund;
                        if (num > 0)
                        {
                            this.BuyFood(num / 2);
                        }
                    }
                }
                else if ((this.SellFoodAvail() && ((this.PlanArchitecture == null) && (this.TransferFoodArchitecture == null))) && (((!this.HostileLine && (this.Food >= (this.FoodCeiling / 2))) && !this.IsFundEnough) && this.IsFoodAbundant))
                {
                    num = this.Food - this.AbundantFood;
                    if (num > 0)
                    {
                        this.SellFood(num / 10);
                    }
                }
            }
        }

        private void AITransfer()
        {
            if (this.BelongedFaction.ArchitectureCount > 1)
            {
                this.AIMilitaryTransfer();
                this.AIPersonTransfer();
                this.AIResourceTransfer();
            }
        }

        private void AITreasure()
        {
            if (GameObject.Chance(10) && !base.Scenario.IsPlayer(this.BelongedFaction))
            {
                if (this.HasTreasureToConfiscate())
                {
                    foreach (Person person in this.Persons.GetList())
                    {
                        if (((person != this.BelongedFaction.Leader) && (person.TreasureCount > 0)) && ((person.TreasureCount > 2) || ((((person.PersonalTitle == null) && GameObject.Chance(50)) || (((person.PersonalTitle != null) && (person.PersonalTitle.Level <= person.TreasureCount)) && GameObject.Chance(0x19))) && ((person.CombatTitle == null) || (((person.CombatTitle != null) && (person.CombatTitle.Level <= person.TreasureCount)) && GameObject.Chance(50))))))
                        {
                            foreach (Treasure treasure in person.Treasures.GetRandomList())
                            {
                                person.ConfiscatedTreasure(treasure);
                                this.BelongedFaction.Leader.ReceiveTreasure(treasure);
                                break;
                            }
                        }
                    }
                }
                if (((this.BelongedFaction.Leader != null) && (this.BelongedFaction.Leader.TreasureCount > 2)) && this.HasTreasureToAward())
                {
                    GameObjectList list = this.Persons.GetList();
                    list.PropertyName = "FightingForce";
                    list.IsNumber = true;
                    list.ReSort();
                    foreach (Person person in list)
                    {
                        if ((person == this.BelongedFaction.Leader) || (person.TreasureCount != 0))
                        {
                            continue;
                        }
                        if ((((person.PersonalTitle != null) && (person.PersonalTitle.Level > 1)) && (person.CombatTitle != null)) && (person.CombatTitle.Level > 1))
                        {
                            foreach (Treasure treasure in this.BelongedFaction.Leader.Treasures.GetRandomList())
                            {
                                if (treasure.Worth < 40)
                                {
                                    this.BelongedFaction.Leader.LoseTreasure(treasure);
                                    person.AwardedTreasure(treasure);
                                    break;
                                }
                            }
                            return;
                        }
                    }
                }
            }
        }
        /*
        private void AIWork()
        {
            this.AIAutoHire();
            this.StopAllWork();
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && this.HasPerson())
            {
                int num;
                this.ReSortAllWeighingList();
                bool isFundAbundant = this.IsFundAbundant;
                if (this.Fund < ((100 * this.AreaCount) + ((30 - base.Scenario.Date.Day) * this.FacilityMaintenanceCost)))
                {
                    MilitaryList trainingMilitaryList = this.GetTrainingMilitaryList();
                    if (trainingMilitaryList.Count > 0)
                    {
                        trainingMilitaryList.IsNumber = true;
                        trainingMilitaryList.PropertyName = "Weighing";
                        trainingMilitaryList.ReSort();
                        GameObjectList maxObjects = this.trainingPersons.GetMaxObjects(trainingMilitaryList.Count);
                        for (num = 0; num < maxObjects.Count; num++)
                        {
                            this.AddPersonToTrainingWork(maxObjects[num] as Person, trainingMilitaryList[num] as Military);
                        }
                    }
                    int num2 = 0;
                    if ((GameObject.Chance(50) && this.Kind.HasDomination) && (this.Domination < (this.DominationCeiling * 0.8)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasEndurance) && (this.Endurance < (this.EnduranceCeiling * 0.2f)))
                    {
                        num2++;
                    }
                    if ((GameObject.Chance(50) && this.Kind.HasMorale) && (this.Morale < Parameters.RecruitmentMorale))
                    {
                        num2++;
                    }
                    if (num2 > 0)
                    {
                        for (num = 0; num < (this.Persons.Count - trainingMilitaryList.Count); num += num2)
                        {
                            foreach (Person person in this.dominationPersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToDominationWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.endurancePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToEnduranceWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.moralePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToMoraleWorkingList(person);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((GameObject.Chance(20) || !this.HasBuildingRouteway) || this.IsFundEnough)
                {
                    float num3;
                    bool flag2 = this.RecentlyAttacked > 0;
                    WorkRateList list3 = new WorkRateList();
                    if ((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) || GameObject.Chance(20))
                    {
                        if (!flag2 || !GameObject.Chance(80))
                        {
                            if (this.Kind.HasAgriculture && (this.Agriculture < this.AgricultureCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueAgriculture)
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Agriculture) / 4f) / ((float) this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Agriculture) / ((float) this.AgricultureCeiling), ArchitectureWorkKind.农业));
                                }
                            }
                            if (this.Kind.HasCommerce && (this.Commerce < this.CommerceCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueCommerce)
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Commerce) / 4f) / ((float) this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Commerce) / ((float) this.CommerceCeiling), ArchitectureWorkKind.商业));
                                }
                            }
                            if (this.Kind.HasTechnology && (this.Technology < this.TechnologyCeiling))
                            {
                                if (this.BelongedSection.AIDetail.ValueTechnology || (GameObject.Chance(50) && (this.IsStateAdmin || this.IsRegionCore)))
                                {
                                    list3.AddWorkRate(new WorkRate((((float) this.Technology) / 4f) / ((float) this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                                else
                                {
                                    list3.AddWorkRate(new WorkRate(((float) this.Technology) / ((float) this.TechnologyCeiling), ArchitectureWorkKind.技术));
                                }
                            }
                        }
                        if (this.Kind.HasDomination && (this.Domination < this.DominationCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueDomination)
                            {
                                list3.AddWorkRate(new WorkRate(((((float) this.Domination) / 5f) / 4f) / ((float) this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Domination) / 5f) / ((float) this.DominationCeiling), ArchitectureWorkKind.统治));
                            }
                        }
                        if (this.Kind.HasMorale && (this.Morale < this.MoraleCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueMorale)
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Morale) / 4f) / ((float) this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float) this.Morale) / ((float) this.MoraleCeiling), ArchitectureWorkKind.民心));
                            }
                        }
                        if (this.Kind.HasEndurance && (this.Endurance < this.EnduranceCeiling))
                        {
                            if (this.BelongedSection.AIDetail.ValueEndurance)
                            {
                                list3.AddWorkRate(new WorkRate((((float) this.Endurance) / 4f) / ((float) this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(((float) this.Endurance) / ((float) this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                            }
                        }
                    }
                    MilitaryList list4 = this.GetTrainingMilitaryList();
                    if (list4.Count > 0)
                    {
                        if (flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.训练));
                        }
                        else
                        {
                            num3 = 0f;
                            foreach (Military military in list4)
                            {
                                num3 += ((float) military.TrainingWeighing) / ((float) military.MaxTrainingWeighing);
                            }
                            num3 /= (float) list4.Count;
                            if (this.BelongedSection.AIDetail.ValueTraining)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.训练));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.训练));
                            }
                        }
                    }
                    MilitaryList recruitmentMilitaryList = null;
                    if (((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) && this.Kind.HasPopulation) && ((flag2 || (GameObject.Random(GameObject.Square(((int) this.BelongedFaction.Leader.StrategyTendency) + 1)) == 0)) && this.RecruitmentAvail()))
                    {
                        recruitmentMilitaryList = this.GetRecruitmentMilitaryList();
                        if ((this.ArmyScale < this.FewArmyScale) && flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if (((this.ArmyScale < this.FewArmyScale) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(20)) || GameObject.Chance(5))) && this.IsFoodAbundant)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if ((((GameObject.Chance(1) || (this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(5))) && ((this.ArmyScale >= this.LargeArmyScale) && this.IsFoodAbundant)) || ((((this.ArmyScale < this.LargeArmyScale) && this.IsFoodEnough) && (((this.IsImportant || (this.AreaCount > 2)) && (this.Population > this.Kind.PopulationBoundary)) || (((this.AreaCount <= 2) && !this.IsImportant) && (this.Population > (this.RecruitmentPopulationBoundary / 2))))) && ((this.BelongedSection.AIDetail.ValueRecruitment && GameObject.Chance(60)) || GameObject.Chance(15)))) && (GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length) >=(int) this.BelongedFaction.Leader.StrategyTendency))
                        {
                            num3 = 0f;
                            foreach (Military military in recruitmentMilitaryList)
                            {
                                num3 += ((float) military.RecruitmentWeighing) / ((float) military.MaxRecruitmentWeighing);
                            }
                            num3 /= (float) recruitmentMilitaryList.Count;
                            if (this.BelongedSection.AIDetail.ValueRecruitment)
                            {
                                list3.AddWorkRate(new WorkRate(num3 / 4f, ArchitectureWorkKind.补充));
                            }
                            else
                            {
                                list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.补充));
                            }
                        }
                    }
                    if (list3.Count > 0)
                    {
                        for (num = 0; num < this.Persons.Count; num += list3.Count)
                        {
                            foreach (WorkRate rate in list3.RateList)
                            {
                                switch (rate.workKind)
                                {
                                    case ArchitectureWorkKind.农业:
                                        foreach (Person person in this.agriculturePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.AgricultureAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToAgricultureWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.商业:
                                        foreach (Person person in this.commercePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.CommerceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToCommerceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.技术:
                                        foreach (Person person in this.technologyPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.TechnologyAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToTechnologyWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.统治:
                                        foreach (Person person in this.dominationPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.DominationAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToDominationWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.民心:
                                        foreach (Person person in this.moralePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.MoraleAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToMoraleWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.耐久:
                                        foreach (Person person in this.endurancePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.EnduranceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToEnduranceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.训练:
                                        foreach (Person person in this.trainingPersons)
                                        {
                                            if (person.WorkKind == ArchitectureWorkKind.无)
                                            {
                                                foreach (Military military in list4.GetRandomList())
                                                {
                                                    if (military.RecruitmentPersonID < 0)
                                                    {
                                                        this.AddPersonToTrainingWork(person, military);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.补充:
                                        foreach (Person person in this.recruitmentPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.RecruitmentAbility >= 120)))
                                            {
                                                if (recruitmentMilitaryList != null)
                                                {
                                                    foreach (Military military in recruitmentMilitaryList.GetRandomList())
                                                    {
                                                        if (military.TrainingPersonID < 0)
                                                        {
                                                            this.AddPersonToRecuitmentWork(person, military);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                    if (this.Kind.HasPopulation && (flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)))
                    {
                        if (((!flag2 && !this.BelongedSection.AIDetail.ValueNewMilitary) && !GameObject.Chance(10)) || (this.ArmyScale >= this.LargeArmyScale))
                        {
                            MilitaryList list6 = new MilitaryList();
                            foreach (Military military in this.Militaries)
                            {
                                if ((((military.Scales < 15) && (military.Quantity > 0)) && (military.Morale < (military.MoraleCeiling / 2))) && ((military.Kind.PointsPerSoldier <= 1) && (this.BelongedFaction.TechniquePoint > (military.Quantity * (military.Kind.PointsPerSoldier + 1)))))
                                {
                                    list6.Add(military);
                                }
                            }
                            foreach (Military military in list6)
                            {
                                this.DisbandMilitary(military);
                            }
                        }
                        else if (((this.Population > this.RecruitmentPopulationBoundary) || flag2) || ((this.Population >= 10000) && GameObject.Chance(5)))
                        {
                            bool flag3 = true;
                            foreach (Military military in this.Militaries)
                            {
                                if (military.Scales < 15)
                                {
                                    flag3 = false;
                                    break;
                                }
                            }
                            if (flag3)
                            {
                                this.AIRecruitment(false);
                            }
                            else if ((this.ValueWater && !this.HasShuijun()) && this.HasShuijunMilitaryKind())
                            {
                                this.AIRecruitment(true);
                            }
                        }
                    }
                }
            }
        }

        */

        public void AllEnter()
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction == this.BelongedFaction)) && troopByPosition.ControlAvail())
                {
                    troopByPosition.Enter(this);
                }
            }
        }

        public bool AllEnterAvail()
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction == this.BelongedFaction)) && troopByPosition.ControlAvail())
                {
                    return true;
                }
            }
            return false;
        }

        public void ApllyInfluences()
        {
            this.Characteristics.ApplyInfluence(this);
            if (this.FacilityEnabled)
            {
                this.ApplyFacilityInfluences();
            }
            this.ApplyInfluenceKind3070(this);
        }

        public void ApplyFacilityInfluences()
        {
            foreach (Facility facility in this.Facilities)
            {
                facility.Influences.ApplyInfluence(this);
            }
        }

        private  void ApplyInfluenceKind3070(Architecture architecture)
        {
            architecture.AutoRefillFoodInLongViewArea = true;
            architecture.RemoveBaseSupplyingArchitecture();
            foreach (Point point in architecture.LongViewArea.Area)
            {
                if (!architecture.Scenario.PositionOutOfRange(point))
                {
                    architecture.Scenario.MapTileData[point.X, point.Y].AddSupplyingArchitecture(architecture);
                }
            }
        }


        public bool ArchitectureHasFacilityKind(int id)
        {

            foreach (Facility facility in this.Facilities)
            {
                if (facility.KindID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public string ArmyQuantityInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x2710);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x1388);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.ArmyQuantity, 0x3e8);

                case InformationLevel.全:
                    return this.ArmyQuantity.ToString();
            }
            return "----";
        }

        private void AutoDecrement()
        {
            if (!(((this.BelongedFaction == null) || (this.RecentlyAttacked <= 0)) || this.DayAvoidInternalDecrementOnBattle))
            {
                int maxValue = (this.RecentlyAttacked / 2) + 1;
                this.DecreaseAgriculture(GameObject.Random(maxValue));
                this.DecreaseCommerce(GameObject.Random(maxValue));
                this.DecreaseTechnology(GameObject.Random(maxValue));
                this.DecreaseMorale(GameObject.Random(maxValue));
            }
        }

        public bool AutoHiringAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        private void AutoIncrement()
        {
            if (this.IncrementOfAgriculturePerDay > 0)
            {
                this.IncreaseAgriculture(this.IncrementOfAgriculturePerDay);
            }
            if (this.IncrementOfCommercePerDay > 0)
            {
                this.IncreaseCommerce(this.IncrementOfCommercePerDay);
            }
            if (this.IncrementOfTechnologyPerDay > 0)
            {
                this.IncreaseTechnology(this.IncrementOfTechnologyPerDay);
            }
            if (this.IncrementOfDominationPerDay > 0)
            {
                this.IncreaseDomination(this.IncrementOfDominationPerDay);
            }
            if (this.IncrementOfMoralePerDay > 0)
            {
                this.IncreaseMorale(this.IncrementOfMoralePerDay);
            }
            if ((this.IncrementOfEndurancePerDay > 0) && !((this.Endurance <= 0) && this.HasContactHostileTroop(this.BelongedFaction)))
            {
                this.IncreaseEndurance(this.IncrementOfEndurancePerDay);
            }
            if ((this.IncrementOfFactionReputationPerDay > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseReputation(this.IncrementOfFactionReputationPerDay);
            }
            if ((this.IncrementOfFactionTechniquePointPerDay > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.IncrementOfFactionTechniquePointPerDay);
            }
            if ((this.Technology > 0) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.IncreaseTechniquePoint(this.Technology / 5);
            }
            if ((this.BelongedFaction == null) && ((this.RecentlyAttacked <= 0) && !this.HasHostileTroopsInArchitecture()))
            {
                if (this.Endurance < (50 * this.AreaCount))
                {
                    this.Endurance++;
                }
                if (this.Domination < 30)
                {
                    this.Domination++;
                }
            }
        }

        public bool AutoRewardingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public bool AutoSearchingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public bool AutoWorkingAvail()
        {
            return ((this.BelongedSection.AIDetail == null) || !this.BelongedSection.AIDetail.AutoRun);
        }

        public void BeginToBuildAFacility(FacilityKind facilityKind)
        {
            this.BuildingFacility = facilityKind.ID;
            this.BuildingDaysLeft = facilityKind.Days;
            this.DecreaseFund(facilityKind.FundCost);
            if (this.BelongedFaction.TechniquePoint < facilityKind.PointCost)
            {
                this.BelongedFaction.DepositTechniquePointForFacility(facilityKind.PointCost - this.BelongedFaction.TechniquePoint);
                if (this.BelongedFaction.TechniquePoint < facilityKind.PointCost)
                {
                    this.BelongedFaction.DepositTechniquePointForTechnique(facilityKind.PointCost - this.BelongedFaction.TechniquePoint);
                }
            }
            this.BelongedFaction.DecreaseTechniquePoint(facilityKind.PointCost);
            if (this.HasSpy)
            {
                this.CreateNewFacilitySpyMessage(facilityKind);
            }
        }

        public void BuildFacility(FacilityKind facilityKind)
        {
            Facility facility = new Facility();
            facility.ID = base.Scenario.Facilities.GetFreeGameObjectID();
            facility.Scenario = base.Scenario;
            facility.KindID = facilityKind.ID;
            facility.Endurance = facilityKind.Endurance;
            this.Facilities.AddFacility(facility);
            base.Scenario.Facilities.AddFacility(facility);
            if (this.FacilityEnabled)
            {
                facility.Influences.ApplyInfluence(this);
            }
            if (this.OnFacilityCompleted != null)
            {
                this.OnFacilityCompleted(this, facility);
            }
        }

        public bool BuildFacilityAvail()
        {
            return ((this.BuildingFacility < 0) && (this.GetBuildableFacilityKindList().Count > 0));
        }

        private Troop BuildOffensiveTroop(Architecture destination, LinkKind linkkind, bool offensive)
        {
            Troop troop;
            if (linkkind == LinkKind.None)
            {
                return null;
            }
            TroopList list = new TroopList();
            this.Persons.ClearSelected();
        //Label_0309:
            foreach (Military military in this.Militaries.GetRandomList())
            {
                switch (linkkind)
                {
                    case LinkKind.Land:
                    {
                        if (military.Kind.Type != MilitaryType.水军)
                        {
                            break;
                        }
                        continue;
                    }
                    case LinkKind.Water:
                    {
                        if ((military.Kind.Type == MilitaryType.水军) || (this.ValueWater && (!offensive || ((military.Quantity >= 0x1f40) && (GameObject.Random(military.Kind.Merit) <= 0)))))
                        {
                            break;
                        }
                        continue;
                    }
                }
                if ((((military.Scales >= 3) && (military.Morale >= 80)) && (military.Combativity >= 80)) && (military.InjuryQuantity < military.Kind.MinScale))
                {
                    PersonList list2;
                    Military military2 = military;
                    if ((linkkind == LinkKind.Water) && (military.Kind.Type != MilitaryType.水军))
                    {
                        Military military3 = Military.SimCreate(base.Scenario, this, base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x1c));
                        military3.SetShelledMilitary(military);
                        military2 = military3;
                    }
                    if ((military2.FollowedLeader != null) && this.Persons.HasGameObject(military2.FollowedLeader))
                    {
                        list2 = new PersonList();
                        list2.Add(military2.FollowedLeader);
                        military2.FollowedLeader.Selected = true;
                        troop = Troop.CreateSimulateTroop(list2, military2, this.Position);
                        list.Add(troop);
                        //goto Label_0309;
                        continue;
                    }
                    if ((((military2.Leader != null) && (military2.LeaderExperience >= 200)) && (((military2.Leader.Strength >= 80) || (military2.Leader.Command >= 80)) || military2.Leader.HasLeaderValidCombatTitle)) && this.Persons.HasGameObject(military2.Leader))
                    {
                        list2 = new PersonList();
                        list2.Add(military2.Leader);
                        military2.Leader.Selected = true;
                        troop = Troop.CreateSimulateTroop(list2, military2, this.Position);
                        list.Add(troop);
                        //goto Label_0309;
                        continue;
                    }
                    foreach (Person person in this.Persons)
                    {
                        if (!person.Selected && (person.Command >= 40))
                        {
                            list2 = new PersonList();
                            list2.Add(person);
                            troop = Troop.CreateSimulateTroop(list2, military2, this.Position);
                            list.Add(troop);
                        }
                    }
                }
            }
            if (list.Count > 0)
            {
                list.IsNumber = true;
                list.PropertyName = "SimulatingFightingForce";
                list.ReSort();
                foreach (Troop troop2 in list.GetList())
                {
                    if (troop2.FightingForce < 0x2710)
                    {
                        break;
                    }
                    Point? nullable = this.GetCampaignPosition(troop2, destination.ArchitectureArea.Area, true);
                    if (!nullable.HasValue)
                    {
                        break;
                    }
                    Person leader = troop2.Persons[0] as Person;
                    this.AddPersonToTroop(troop2);
                    troop = this.CreateTroop(troop2.Persons, leader, troop2.Army, -1, nullable.Value);
                    troop.WillArchitecture = destination;
                    Legion legion = this.BelongedFaction.GetLegion(destination);
                    if (legion == null)
                    {
                        legion = this.CreateOffensiveLegion(destination);
                    }
                    legion.AddTroop(troop);
                    this.PostCreateTroop(troop, false);
                    return troop;
                }
            }
            return null;
        }

        public Routeway BuildRouteway(LinkNode node, bool hasEnd)
        {
            Point key = new Point(base.ID, node.A.ID);
            if (!this.BelongedFaction.ClosedRouteways.ContainsKey(key))
            {
                Point? nullable;
                Point? nullable2;
                base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), node.A.GetAIRoutewayEndPoints(this, true), out nullable, out nullable2);
                if (nullable.HasValue && nullable2.HasValue)
                {
                    this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = node.Kind == LinkKind.Land;
                    if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, hasEnd))
                    {
                        Routeway routeway = this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
                        routeway.DestinationArchitecture = node.A;
                        if (hasEnd)
                        {
                            routeway.EndArchitecture = node.A;
                        }
                        return routeway;
                    }
                    this.BelongedFaction.ClosedRouteways.Add(new Point(base.ID, node.A.ID), null);
                }
            }
            return null;
        }

        public Routeway BuildShortestRouteway(Architecture des, bool noWater)
        {
            Point? nullable;
            Point? nullable2;
            if (!noWater)
            {
                Point key = new Point(base.ID, des.ID);
                if (this.BelongedFaction.ClosedRouteways.ContainsKey(key))
                {
                    return null;
                }
            }
            base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), des.GetRoutewayStartPoints(), out nullable, out nullable2);
            if (nullable.HasValue && nullable2.HasValue)
            {
                this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = noWater;
                if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, true))
                {
                    Routeway routeway = this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
                    routeway.DestinationArchitecture = des;
                    routeway.EndArchitecture = des;
                    return routeway;
                }
                if (!noWater)
                {
                    this.BelongedFaction.ClosedRouteways.Add(new Point(base.ID, des.ID), null);
                }
            }
            return null;
        }

        public Routeway BuildShortestRouteway(Point point, bool noWater)
        {
            Point closestPoint = base.Scenario.GetClosestPoint(this.GetRoutewayStartPoints(), point);
            this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = noWater;
            if (this.BelongedFaction.RoutewayPathAvail(closestPoint, point, true))
            {
                return this.CreateRouteway(this.BelongedFaction.GetCurrentRoutewayPath());
            }
            return null;
        }

        public void BuyFood(int spendFund)
        {
            this.DecreaseFund(spendFund);
            this.IncreaseFood(spendFund * Parameters.FundToFoodMultiple);
        }

        public bool BuyFoodAvail()
        {
            return ((((this.Agriculture >= Parameters.BuyFoodAgriculture) && ((base.Scenario.Date.Season == GameSeason.夏) || (base.Scenario.Date.Season == GameSeason.秋))) && (this.Fund > 0)) && (this.Food < this.FoodCeiling));
        }

        public bool CampaignAvail()
        {
            if ((this.Persons.Count > 0) && (this.Militaries.Count > 0))
            {
                foreach (Military military in this.Militaries)
                {
                    if (((military.Quantity > 0) && (military.Morale > 0)) && (this.GetMilitaryCampaignArea(military).Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ChangeCapitalAvail()
        {
            return ((((this.BelongedFaction != null) && (this.BelongedFaction.ArchitectureCount > 1)) && this.IsCapital) && (this.Fund >= this.ChangeCapitalCost));
        }

        public void ChangeFaction(Faction faction)
        {
            this.ResetAuto();
            if ((faction != null) && base.Scenario.IsPlayer(faction))
            {
                this.AutoHiring = true;
                this.AutoRewarding = true;

            }
            if ((faction != null) && (this.BelongedFaction != null))
            {
                this.BelongedFaction.Architectures.Remove(this);
                this.BelongedFaction.RemoveArchitectureKnownData(this);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    this.ClearRouteways();
                }
                else
                {
                    foreach (Routeway routeway in this.Routeways)
                    {
                        this.BelongedFaction.RemoveRouteway(routeway);
                    }
                }
                foreach (Person person in this.Persons)
                {
                    this.BelongedFaction.RemovePerson(person);
                }
                foreach (Person person in this.MovingPersons)
                {
                    this.BelongedFaction.RemovePerson(person);
                }
                foreach (Captive captive in this.Captives)
                {
                    this.BelongedFaction.RemoveCaptive(captive);
                }
                foreach (Military military in this.Militaries)
                {
                    this.BelongedFaction.RemoveMilitary(military);
                }
                this.BelongedFaction = null;
                faction.AddArchitecture(this);
                faction.AddArchitectureKnownData(this);
                faction.AddArchitecturePersons(this);
                foreach (Person person in this.MovingPersons)
                {
                    faction.AddPerson(person);
                }
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (captive.CaptiveFaction == faction)
                    {
                        captive.CaptivePerson.BelongedCaptive = null;
                        this.RemoveCaptive(captive);
                        captive.CaptiveFaction.RemoveSelfCaptive(captive);
                        base.Scenario.Captives.Remove(captive);
                    }
                    else
                    {
                        faction.AddCaptive(captive);
                    }
                }
                this.InformationCoolDown = 0;
                foreach (Military military in this.Militaries)
                {
                    faction.AddMilitary(military);
                }
                foreach (Routeway routeway in this.Routeways)
                {
                    faction.AddRouteway(routeway);
                }
                faction.FirstSection.AddArchitecture(this);
            }
            if (faction != null)
            {
                this.jianzhuqizi.qizidezi.Text = faction.ToString().Substring(0, 1);
            }
        }

        private void CheckAmbushTroop(Point p)
        {
            Troop troopByPosition = base.Scenario.GetTroopByPosition(p);
            if (((troopByPosition != null) && (troopByPosition.Status == TroopStatus.埋伏)) && !this.IsFriendly(troopByPosition.BelongedFaction))
            {
                this.DetectAmbush(troopByPosition, this.BelongedFaction.GetKnownAreaData(p));
            }
        }

        private void CheckBuildingFacility()
        {
            if (this.BuildingDaysLeft > 0)
            {
                this.BuildingDaysLeft--;
                if (this.BuildingDaysLeft == 0)
                {
                    FacilityKind facilityKind = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.BuildingFacility);
                    if (facilityKind != null)
                    {
                        this.BuildFacility(facilityKind);
                    }
                    this.BuildingFacility = -1;
                }
            }
        }

        public LinkKind CheckCampaignable(LinkNode node)
        {
            bool flag = true;
            bool flag2 = true;
            for (int i = 1; i < node.Path.Count; i++)
            {
                flag = flag && node.Path[i - 1].IsLandLink(node.Path[i]);
                flag2 = flag2 && node.Path[i - 1].IsWaterLink(node.Path[i]);
            }
            if (flag && flag2)
            {
                return LinkKind.Both;
            }
            if (flag)
            {
                return LinkKind.Land;
            }
            if (flag2)
            {
                return LinkKind.Water;
            }
            return LinkKind.None;
        }

        public void CheckIsFrontLine()
        {
            this.FrontLine = false;
            this.HostileLine = false;
            this.CriticalHostile = false;
            this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.35f;
            foreach (Architecture architecture in this.GetAILinks())
            {
                if ((architecture.BelongedFaction == null) || this.IsFriendly(architecture.BelongedFaction))
                {
                    continue;
                }
                this.FrontLine = true;
                int num = (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture.BelongedFaction.ID) + architecture.BelongedFaction.ArchitectureTotalSize) - this.BelongedFaction.ArchitectureTotalSize;
                if (num < 0)
                {
                    this.HostileLine = true;
                    if (num <= -200)
                    {
                        this.CriticalHostile = true;
                    }
                }
            }
            this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax = 0.7f;
        }

        private void CheckRobberTroop()
        {
            if (this.BelongedFaction != null)
            {
                if ((this.RobberTroop != null) && (this.RobberTroop.RecentlyFighting <= 0))
                {
                    this.RobberTroop.Destroy();
                    base.Scenario.Militaries.Remove(this.RobberTroop.Army);
                    base.Scenario.Troops.RemoveTroop(this.RobberTroop);
                    this.RobberTroop = null;
                }
            }
            else if (this.RobberTroop == null)
            {
                if ((this.JustAttacked && (this.Endurance > 0)) && !this.HasHostileTroopsInArchitecture())
                {
                    List<Point> orientations = new List<Point>();
                    foreach (Troop troop in this.GetHostileTroopsInView())
                    {
                        orientations.Add(troop.Position);
                    }
                    this.CreateRobberTroop(base.Scenario.GetClosestPosition(this.ArchitectureArea, orientations).Value);
                }
            }
            else if (!(((this.RecentlyAttacked > 0) || (this.RobberTroop.RecentlyFighting > 0)) || this.HasHostileTroopsInView()))
            {
                this.RobberTroop.Destroy();
                base.Scenario.Militaries.Remove(this.RobberTroop.Army);
                base.Scenario.Troops.RemoveTroop(this.RobberTroop);
                this.RobberTroop = null;
            }
        }

        public void ClearField()
        {
            if (this.Kind.HasAgriculture)
            {
                this.Agriculture -= this.ClearFieldAgricultureCost;
            }
            this.DecreaseFund(this.ClearFieldFundCost);
            int num = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                if ((base.Scenario.GetArchitectureByPosition(point) != null) || base.Scenario.NoFoodDictionary.HasPosition(point))
                {
                    continue;
                }
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition == null) || this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                {
                    TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                    if ((terrainDetailByPosition != null) && (terrainDetailByPosition.FoodDeposit > 0))
                    {
                        num += terrainDetailByPosition.GetRandomFood(base.Scenario.Date.Season);
                        base.Scenario.NoFoodDictionary.AddPosition(new NoFoodPosition(point, terrainDetailByPosition.RandomRegainDays));
                    }
                }
            }
            this.IncreaseFood(num / 4);
        }

        private void ClearFieldAI()
        {
            if ((((((this.Endurance + this.Domination) - this.Agriculture) < 0) && (this.ArmyScale < this.NormalArmyScale)) && this.ClearFieldAvail()) && ((this.ClearFieldCredit / this.LongViewArea.Count) >= 0xc350))
            {
                float rationRate = 0f;
                int relationUnderZeroTroopFightingForceInView = this.GetRelationUnderZeroTroopFightingForceInView(out rationRate);
                if ((relationUnderZeroTroopFightingForceInView > 0) && ((rationRate < 0.2f) && (relationUnderZeroTroopFightingForceInView > ((this.GetFriendlyTroopFightingForceInView() + (this.FoodCostPerDayOfAllMilitaries * ((this.PersonCount < 10) ? this.PersonCount : 10))) * 2))))
                {
                    this.ClearField();
                }
            }
        }

        public bool ClearFieldAvail()
        {
            if (this.Kind.HasAgriculture && (this.Agriculture <= this.ClearFieldAgricultureCost))
            {
                return false;
            }
            if (this.Fund < this.ClearFieldFundCost)
            {
                return false;
            }
            return true;
        }

        public void ClearFundPacks()
        {
            this.FundPacks.Clear();
        }

        internal void ClearPopulationPacks()
        {
            this.PopulationPacks.Clear();
        }

        public void ClearRouteways()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        foreach (Routeway routeway in architecture.HasRoutewayList(this))
                        {
                            routeway.RemoveAfterClose = true;
                        }
                    }
                }
            }
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                base.Scenario.RemoveRouteway(routeway);
            }
            this.Routeways.Clear();
        }

        internal void ClearSpyPacks()
        {
            this.SpyPacks.Clear();
        }

        private void ClearWork()
        {
            PersonList renwuliebiao = new PersonList();

            if (this.Agriculture >= this.AgricultureCeiling)
            {

                foreach (Person person in this.AgricultureWorkingPersons)
                {
                    renwuliebiao.Add(person);
                }
                foreach (Person person in renwuliebiao)
                {
                    this.RemovePersonFromWorkingList(person);
                }
                renwuliebiao.Clear();
            }
            if (this.Commerce >= this.CommerceCeiling)
            {
                foreach (Person person in this.CommerceWorkingPersons)
                {
                    renwuliebiao.Add(person);
                }

                foreach (Person person in renwuliebiao )
                {
                    this.RemovePersonFromWorkingList(person);
                }
                renwuliebiao.Clear();
            }
            if (this.Technology >= this.TechnologyCeiling)
            {
                foreach (Person person in this.TechnologyWorkingPersons)
                {
                    renwuliebiao.Add(person);
                }
                foreach (Person person in renwuliebiao)
                {
                    this.RemovePersonFromWorkingList(person);
                }
                renwuliebiao.Clear();
            }
            /*        统治到顶时不停止工作
            if (this.Domination >= this.DominationCeiling)
            {
                foreach (Person person in this.DominationWorkingPersons)
                {
                    this.RemovePersonFromWorkingList(person);
                }
            }
            */
            if (this.Morale >= this.MoraleCeiling)
            {
                foreach (Person person in this.MoraleWorkingPersons)
                {
                    renwuliebiao.Add(person);
                }
                foreach (Person person in renwuliebiao)
                {
                    this.RemovePersonFromWorkingList(person);
                }
                renwuliebiao.Clear();
            }
            if (this.Endurance >= this.EnduranceCeiling)
            {
                foreach (Person person in this.EnduranceWorkingPersons)
                {
                    renwuliebiao.Add(person);
                }
                foreach (Person person in renwuliebiao)
                {
                    this.RemovePersonFromWorkingList(person);
                }
                renwuliebiao.Clear();
            }
            
            foreach (Military military in this.Militaries)
            {
                if ((military.Morale >= military.MoraleCeiling) && (military.Combativity >= military.CombativityCeiling))
                {
                    military.StopTraining();
                    
                }
                if (military.Quantity >= military.Kind.MaxScale)
                {
                    military.StopRecruitment();
                    
                }
            }
        }

        public void CloseAllRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                routeway.Close();
            }
        }

        public bool CommerceAvail()
        {
            return (this.Kind.HasCommerce && this.HasPerson());
        }

        public bool ConvincePersonAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.ConvincePersonFund)) && (this.GetConvincePersonArchitectureArea().Count > 0));
        }

        public Legion CreateDefensiveLegion()
        {
            this.DefensiveLegion = new Legion();
            this.DefensiveLegion.Scenario = base.Scenario;
            this.DefensiveLegion.Kind = LegionKind.Defensive;
            this.DefensiveLegion.ID = base.Scenario.Legions.GetFreeGameObjectID();
            this.DefensiveLegion.StartArchitecture = this;
            this.DefensiveLegion.WillArchitecture = this;
            base.Scenario.Legions.AddLegionWithEvent(this.DefensiveLegion);
            this.BelongedFaction.AddLegion(this.DefensiveLegion);
            return this.DefensiveLegion;
        }

        private SpyMessage CreateHireNewPersonSpyMessage(Person person)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.HireNewPerson;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = person.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        public void CreateMilitary(MilitaryKind mk)
        {
            Military military = Military.Create(base.Scenario, this, mk);
            if (this.OnMilitaryCreate != null)
            {
                this.OnMilitaryCreate(this, military);
            }
            if (this.HasSpy)
            {
                this.AddMessageToTodayNewMilitarySpyMessage(military);
            }
        }

        private SpyMessage CreateMilitaryScaleSpyMessage(Military m)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.MilitaryScale;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = m.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Message5 = (m.Scales * m.Kind.MinScale).ToString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewFacilitySpyMessage(FacilityKind fk)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewFacility;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = fk.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewMilitarySpyMessage(Military m)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewMilitary;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = m.Name;
            message.Message4 = base.Scenario.Date.ToDateString();
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        private SpyMessage CreateNewTroopSpyMessage(Troop t, bool hand)
        {
            SpyMessage message = new SpyMessage();
            message.Scenario = base.Scenario;
            message.ID = message.Scenario.SpyMessages.GetFreeGameObjectID();
            message.Kind = SpyMessageKind.NewTroop;
            message.MessageFaction = this.BelongedFaction;
            message.MessageArchitecture = this;
            message.Message1 = this.BelongedFaction.Name;
            message.Message2 = base.Name;
            message.Message3 = t.DisplayName;
            message.Message4 = base.Scenario.Date.ToDateString();
            if (hand)
            {
                message.Message5 = "不明";
            }
            else
            {
                message.Message5 = (t.WillArchitecture != null) ? t.WillArchitecture.Name : "不明";
            }
            message.Scenario.SpyMessages.AddMessageWithEvent(message);
            foreach (SpyPack pack in this.SpyPacks)
            {
                int singleWayDays = base.Scenario.GetSingleWayDays(pack.SpyPerson.Position, this.ArchitectureArea);
                message.AddPersonPack(pack.SpyPerson, singleWayDays);
            }
            return message;
        }

        public Legion CreateOffensiveLegion(Architecture willArchitecture)
        {
            Legion legion = new Legion();
            legion.Scenario = base.Scenario;
            legion.Kind = LegionKind.Offensive;
            legion.StartArchitecture = this;
            legion.WillArchitecture = willArchitecture;
            legion.ID = base.Scenario.Legions.GetFreeGameObjectID();
            base.Scenario.Legions.AddLegionWithEvent(legion);
            this.BelongedFaction.AddLegion(legion);
            LinkNode node = null;
            if (this.AIAllLinkNodes.TryGetValue(willArchitecture.ID, out node))
            {
                legion.PreferredRouteway = this.GetRouteway(node, false);
            }
            return legion;
        }

        public void CreateRobberTroop(Point position)
        {
            Military military = new Military();
            military.Scenario = base.Scenario;
            military.ID = base.Scenario.Militaries.GetFreeGameObjectID();
            base.Scenario.Militaries.AddMilitary(military);
            military.Kind = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x15);
            military.Name = military.Kind.Name;
            military.Morale = military.MoraleCeiling;
            military.Combativity = military.CombativityCeiling;
            military.Quantity = (military.Kind.MinScale + (this.Population / 100)) * ((this.AreaCount / 2) + 2);
            if (military.Quantity > military.Kind.MaxScale)
            {
                military.Quantity = military.Kind.MaxScale;
            }
            GameObjectList persons = new GameObjectList();
            Person gameObject = base.Scenario.Persons.GetGameObject(0x1bc4) as Person;
            persons.Add(gameObject);
            Troop troop = this.CreateTroop(persons, gameObject, military, 0, position);
            troop.WillArchitecture = this;
            this.RobberTroop = troop;
        }

        public Routeway CreateRouteway(Point p)
        {
            if (base.Scenario.GetTerrainDetailByPosition(p) != null)
            {
                Routeway routeway = new Routeway();
                routeway.Scenario = base.Scenario;
                routeway.ID = base.Scenario.Routeways.GetFreeGameObjectID();
                routeway.Scenario.Routeways.AddRoutewayWithEvent(routeway);
                this.BelongedFaction.AddRouteway(routeway);
                routeway.StartArchitecture = this;
                this.Routeways.Add(routeway);
                routeway.Extend(p);
                ArchitectureList routewayArchitecturesByPosition = base.Scenario.GetRoutewayArchitecturesByPosition(routeway, p);
                if (routewayArchitecturesByPosition.Count > 0)
                {
                    if (routewayArchitecturesByPosition.Count > 1)
                    {
                        routewayArchitecturesByPosition.PropertyName = "Food";
                        routewayArchitecturesByPosition.IsNumber = true;
                        routewayArchitecturesByPosition.SmallToBig = true;
                        routewayArchitecturesByPosition.ReSort();
                    }
                    routeway.EndArchitecture = routewayArchitecturesByPosition[0] as Architecture;
                    routeway.DestinationArchitecture = routeway.EndArchitecture;
                }
                return routeway;
            }
            return null;
        }

        public Routeway CreateRouteway(List<Point> pointlist)
        {
            int num2;
            Routeway routeway = new Routeway();
            routeway.Scenario = base.Scenario;
            routeway.ID = base.Scenario.Routeways.GetFreeGameObjectID();
            routeway.Scenario.Routeways.AddRoutewayWithEvent(routeway);
            this.BelongedFaction.AddRouteway(routeway);
            routeway.StartArchitecture = this;
            this.Routeways.Add(routeway);
            GameArea routewayStartPoints = this.GetRoutewayStartPoints();
            int num = 0;
            for (num2 = 0; num2 < pointlist.Count; num2++)
            {
                if (routewayStartPoints.HasPoint(pointlist[num2]))
                {
                    num = num2;
                }
            }
            for (num2 = num; num2 < pointlist.Count; num2++)
            {
                routeway.Extend(pointlist[num2]);
            }
            return routeway;
        }

        public Troop CreateTroop(GameObjectList persons, Person leader, Military military, int food, Point position)
        {
            return Troop.Create(this, persons, leader, military, food, position);
        }

        public bool CurrentPlayerOwned()
        {
            return ((GlobalVariables.SkyEye && this.HasFaction()) || (this.HasFaction() && (base.Scenario.NoCurrentPlayer || (this.BelongedFaction == base.Scenario.CurrentPlayer))));
        }

        public void DamageByGossip(int damage)
        {
            foreach (Person person in this.Persons)
            {
                if ((person.Loyalty <= 100) && (person != this.BelongedFaction.Leader))
                {
                    person.DecreaseLoyalty(StaticMethods.GetRandomValue(damage *(int)(Enum.GetNames(typeof(PersonLoyalty)).Length - person.PersonalLoyalty), 100));
                }
            }
        }

        public void DayEvent()
        {
            this.InformationDayEvent();
            this.FundPacksDayEvent();
            this.PopulationPacksDayEvent();
            this.SpyPacksDayEvent();
            this.HandleFacilities();
            this.ViewAreaEvent();
            this.StrategicCenterEffect();
            this.AutoDecrement();
            this.AutoIncrement();
            this.Sourrounded();
            this.ResetDayInfluence();
            this.CheckRobberTroop();
            this.PopulationEscapeEvent();
            this.FoodReduce();
            this.zainanshijian();
            this.JustAttacked = false;
        }

        private void tingzhizhenzai()
        {
            PersonList renwuliebiao = new PersonList();

            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                renwuliebiao.Add(person);
            }
            foreach (Person person in renwuliebiao)
            {
                this.RemovePersonFromWorkingList(person);
            }
            renwuliebiao.Clear();
        }

        private void zainanshijian()
        {
            
            if (this.youzainan)
            {
                this.DecreaseFood(this.zhenzaiWorkingPersons.Count* 3000);
                this.DecreaseFund(this.zhenzaiWorkingPersons.Count * 200);
                this.zhixingzainanshanghai();

                this.zainan.shengyutianshu--;
                if (base.Scenario.Date.Day % 10 == 0)
                {
                    this.zainan.shengyutianshu -= this.zhenzaijianshaotianshu();
                }
                if (this.zainan.shengyutianshu <= 0)
                {
                    this.youzainan = false;
                    this.tingzhizhenzai();
                }

                if (this.Food <= 0 || this.Fund <= 0)
                {
                    this.tingzhizhenzai();
                }
            }
            else
            {
                if (GameObject.Random(3000)==0 && base.Scenario.IsPlayer(this.BelongedFaction) && this.Kind.ID == 1)
                {
                    int kindID;
                    kindID = GameObject.Random(base.Scenario.GameCommonData.suoyouzainanzhonglei.Count);

                    this.zainan.zainanzhonglei = base.Scenario.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei(kindID);
                    this.zainan.shengyutianshu = this.zainan.zainanzhonglei.shijianxiaxian + GameObject.Random(this.zainan.zainanzhonglei.shijianshangxian  - this.zainan.zainanzhonglei.shijianxiaxian);
                    this.youzainan = true;
                    foreach (Military military in this.Militaries)//发生灾难时不能补充
                    {
                        military.StopRecruitment();
                    }
                    this.Onfashengzainan(this, this.zainan.zainanzhonglei.ID );
                }
            }
        }

        private int zhenzaijianshaotianshu()
        {
            int tianshu;
            int zhenzainenglizonghe = 0;
            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                zhenzainenglizonghe += person.zhenzaiAbility; ;
            }
            tianshu = zhenzainenglizonghe / 300;
            if (tianshu > 5)
            {
                tianshu = 5;
            }
            return tianshu;
        }

        private float jianzaixishu()
        {
            float xishu;
            int zhenzainenglizonghe=0;
            foreach (Person person in this.zhenzaiWorkingPersons)
            {
                zhenzainenglizonghe += person.zhenzaiAbility; ;
            }
            xishu = 1 - zhenzainenglizonghe / 1500f;
            if (xishu < 0.01f)
            {
                xishu = 0.01f;
            }
            return xishu;
        }

        private void zhixingzainanshanghai()
        {
            this.DecreasePopulation((int)(this.zainan.zainanzhonglei.renkoushanghai *jianzaixishu()));
            this.DecreaseDomination (this.zainan.zainanzhonglei.tongzhishanghai );
            this.xiajiangnaijiu (this.zainan.zainanzhonglei.naijiushanghai );
            this.DecreaseAgriculture (this.zainan.zainanzhonglei.nongyeshanghai );
            this.DecreaseCommerce (this.zainan.zainanzhonglei.shangyeshanghai );
            this.DecreaseTechnology (this.zainan.zainanzhonglei.jishushanghai );
            this.DecreaseMorale ((int)(this.zainan.zainanzhonglei.minxinshanghai *jianzaixishu()));
        }

        public void DecreaseAgriculture(int decrement)
        {
            this.Agriculture -= decrement;
            if (this.Agriculture < 0)
            {
                this.Agriculture = 0;
            }
        }

        public void DecreaseCommerce(int decrement)
        {
            this.Commerce -= decrement;
            if (this.Commerce < 0)
            {
                this.Commerce = 0;
            }
        }

        public int DecreaseDomination(int decrement)
        {
            int domination = decrement;
            if ((this.Domination - decrement) < 0)
            {
                domination = this.Domination;
            }
            this.Domination -= domination;
            return domination;
        }

        public void xiajiangnaijiu(int decrement)  //灾难下降耐久
        {
            this.Endurance -= decrement;
            if (this.Endurance < 1)
            {
                this.Endurance = 1;
            }
        }

        public int DecreaseEndurance(int decrement)
        {
            if (this.Endurance <= 0)
            {
                return 0;
            }
            if (this.IsCapital)
            {
                decrement = (decrement * 2) / 3;
            }
            if (decrement <= 0)
            {
                decrement = 1;
            }
            int endurance = decrement;
            if ((this.Endurance - decrement) < 0)
            {
                endurance = this.Endurance;
            }
            this.Endurance -= endurance;
            this.SetRecentlyAttacked();
            this.DecreaseFacilityEndurance(endurance);
            if (this.Endurance == 0)
            {
                this.RecentlyBreaked = 30;
                this.WallStateChange();
            }
            return endurance;
        }

        public void DecreaseFacilityEndurance(int decrement)
        {
            if (decrement > 0)
            {
                this.Facilities.DecreaseEndurance((int) (decrement * this.RateOfFacilityEnduranceDown));
                foreach (Facility facility in this.Facilities.GetList())
                {
                    if (facility.Endurance <= 0)
                    {
                        this.DemolishFacility(facility);
                    }
                }
            }
        }

        public void DecreaseFood(int decrement)
        {
            this.food -= decrement;
            if (this.food < 0)
            {
                this.food = 0;
            }
        }

        public void DecreaseFund(int decrement)
        {
            this.fund -= decrement;
            if (this.fund < 0)
            {
                this.fund = 0;
            }
        }

        public void DecreaseMorale(int decrement)
        {
            this.Morale -= decrement;
            if (this.Morale < 0)
            {
                this.Morale = 0;
            }
        }

        public int DecreasePopulation(int decrement)
        {
            if (this.population < decrement)
            {
                decrement = this.population;
            }
            this.population -= decrement;
            return decrement;
        }

        public void DecreaseTechnology(int decrement)
        {
            this.Technology -= decrement;
            if (this.Technology < 0)
            {
                this.Technology = 0;
            }
        }

        private void DefensiveCampaign()
        {
            if ((this.HasPerson() && this.HasCampaignableMilitary()) && (this.GetAllAvailableArea(false).Count != 0))
            {
                TroopList hostileTroopsInView = this.GetHostileTroopsInView();
                if (hostileTroopsInView.Count > 0)
                {
                    List<Point> orientations = new List<Point>();
                    foreach (Troop troop in hostileTroopsInView)
                    {
                        orientations.Add(troop.Position);
                    }
                    TroopList friendlyTroopsInView = this.GetFriendlyTroopsInView();
                    int num = 0;
                    int militaryCount = this.MilitaryCount;
                    while ((num < militaryCount) && (this.TotalFriendlyForce < (this.TotalHostileForce * 5)))
                    {
                        Troop troop2;
                        num++;
                        int num3 = (this.TotalHostileForce * 5) - this.TotalFriendlyForce;
                        TroopList list4 = new TroopList();
                        bool isBesideWater = this.IsBesideWater;
                    //Label_033D:
                        foreach (Military military in this.Militaries.GetRandomList())
                        {
                            if ((isBesideWater || (military.Kind.Type != MilitaryType.水军)) && (((((this.Endurance < 30) || military.Kind.AirOffence) || (military.Scales >= 2)) && (military.Morale > 0x2d)) && ((this.Endurance < 30) || (military.InjuryQuantity < military.Kind.MinScale))))
                            {
                                PersonList list5;
                                if ((military.FollowedLeader != null) && this.Persons.HasGameObject(military.FollowedLeader))
                                {
                                    list5 = new PersonList();
                                    list5.Add(military.FollowedLeader);
                                    military.FollowedLeader.Selected = true;
                                    troop2 = Troop.CreateSimulateTroop(list5, military, this.Position);
                                    list4.Add(troop2);
                                }
                                else
                                {
                                    if ((((military.Leader != null) && (military.LeaderExperience >= 200)) && (((military.Leader.Strength >= 80) || (military.Leader.Command >= 80)) || military.Leader.HasLeaderValidCombatTitle)) && this.Persons.HasGameObject(military.Leader))
                                    {
                                        list5 = new PersonList();
                                        list5.Add(military.Leader);
                                        military.Leader.Selected = true;
                                        troop2 = Troop.CreateSimulateTroop(list5, military, this.Position);
                                        list4.Add(troop2);
                                        //goto Label_033D;
                                        continue;
                                    }
                                    foreach (Person person in this.Persons)
                                    {
                                        if (!person.Selected)
                                        {
                                            list5 = new PersonList();
                                            list5.Add(person);
                                            troop2 = Troop.CreateSimulateTroop(list5, military, this.Position);
                                            list4.Add(troop2);
                                        }
                                    }
                                }
                            }
                        }
                        if (list4.Count <= 0)
                        {
                            break;
                        }
                        list4.IsNumber = true;
                        list4.PropertyName = "FightingForce";
                        list4.ReSort();
                        foreach (Troop troop in list4.GetList())
                        {
                            if (((troop.FightingForce < 0x2710) && (troop.FightingForce < (num3 / 0x19))) && (troop.Army.Scales < 10))
                            {
                                return;
                            }
                            Point? nullable = this.GetCampaignPosition(troop, orientations, troop.Army.Scales > 0);
                            if (!nullable.HasValue)
                            {
                                return;
                            }
                            if (troop.Army.Kind.AirOffence && (troop.Army.Scales < 2))
                            {
                                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(nullable.Value);
                                if ((architectureByPositionNoCheck == null) || (architectureByPositionNoCheck.Endurance == 0))
                                {
                                    continue;
                                }
                            }
                            Person leader = troop.Persons[0] as Person;
                            this.AddPersonToTroop(troop);
                            troop2 = this.CreateTroop(troop.Persons, leader, troop.Army, -1, nullable.Value);
                            troop2.WillArchitecture = this;
                            if (this.DefensiveLegion == null)
                            {
                                this.CreateDefensiveLegion();
                            }
                            this.DefensiveLegion.AddTroop(troop2);
                            this.PostCreateTroop(troop2, false);
                            this.TotalFriendlyForce += troop2.FightingForce;
                            break;
                        }
                        if (!(this.HasCampaignableMilitary() && this.HasPerson()))
                        {
                            break;
                        }
                    }
                }
            }
        }

        public void DemolishAllRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                base.Scenario.RemoveRouteway(routeway);
            }
        }

        public void DemolishFacility(Facility facility)
        {
            if (this.FacilityEnabled)
            {
                facility.Influences.PurifyInfluence(this);
            }
            this.Facilities.Remove(facility);
            base.Scenario.Facilities.Remove(facility);
        }

        public bool DestroyAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.DestroyArchitectureFund)) && (this.GetDestroyArchitectureArea().Count > 0));
        }

        public bool DetailAvail()
        {
            return (GlobalVariables.SkyEye || this.CurrentPlayerOwned());
        }

        private void DetectAmbush(Troop troop, InformationLevel level)
        {
            int chance = 40 - troop.Leader.Calmness;
            if (level <= InformationLevel.中)
            {
                if (troop.OnlyBeDetectedByHighLevelInformation)
                {
                    return;
                }
            }
            else
            {
                chance *= 3;
            }
            if (GameObject.Chance(chance))
            {
                troop.AmbushDetected(troop);
            }
        }

        private void DetectAmbushTroop()
        {
            if (this.BelongedFaction != null)
            {
                GameArea longViewArea = this.LongViewArea;
                foreach (Point point in longViewArea.Area)
                {
                    this.CheckAmbushTroop(point);
                }
            }
        }

        private void DevelopAgriculture()
        {
            if (this.Agriculture != this.AgricultureCeiling)
            {
                foreach (Person person in this.AgricultureWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.AgricultureAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.AddGlamourExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfAgricultureReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfAgricultureTechniquePoint) * 100);
                        this.IncreaseAgriculture(randomValue);
                    }
                }
            }
        }

        private void DevelopArmy()
        {
            foreach (Military military in this.Militaries)
            {
                military.Recovery(this.MultipleOfRecovery);
                this.TrainMilitary(military);
                this.RecruitmentMilitary(military);
            }
        }

        private void DevelopCommerce()
        {
            if (this.Commerce != this.CommerceCeiling)
            {
                foreach (Person person in this.CommerceWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.CommerceAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddIntelligenceExperience(randomValue);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.AddGlamourExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfCommerceReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfCommerceTechniquePoint) * 100);
                        this.IncreaseCommerce(randomValue);
                    }
                }
            }
        }

        public void DevelopDay()
        {
            if (this.kind.HasAgriculture)
            {
                this.DevelopAgriculture();
            }
            if (this.kind.HasCommerce)
            {
                this.DevelopCommerce();
            }
            if (this.kind.HasTechnology)
            {
                this.DevelopTechnology();
            }
            if (this.kind.HasDomination)
            {
                this.DevelopDomination();
            }
            if (this.kind.HasMorale)
            {
                this.DevelopMorale();
            }
            if (this.kind.HasEndurance)
            {
                this.DevelopEndurance();
            }
            if (this.kind.HasPopulation)
            {
                this.DevelopPopulation();
            }
            this.DevelopArmy();
            this.ClearWork();
        }

        public void DevelopDayNoFaction()
        {
            this.DevelopPopulation();
        }

        private void DevelopDomination()
        {
            if (this.Domination != this.DominationCeiling)
            {
                foreach (Person person in this.DominationWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.DominationAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddStrengthExperience(randomValue * 2);
                        person.AddCommandExperience(randomValue);
                        person.AddGlamourExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfDominationReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfDominationTechniquePoint) * 100);
                        this.IncreaseDomination(randomValue);
                    }
                }
            }
        }

        private void DevelopEndurance()
        {
            if ((this.Endurance != this.EnduranceCeiling) && ((this.Endurance != 0) || !this.HasContactHostileTroop(this.BelongedFaction)))
            {
                foreach (Person person in this.EnduranceWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.EnduranceAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddStrengthExperience(randomValue);
                        person.AddCommandExperience(randomValue);
                        person.AddIntelligenceExperience(randomValue);
                        person.AddPoliticsExperience(randomValue);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfEnduranceReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfEnduranceTechniquePoint) * 100);
                        this.IncreaseEndurance(randomValue);
                    }
                }
            }
        }

        public void DevelopFood()
        {
            this.IncreaseFood(this.ExpectedFood);
        }

        public void DevelopFund()
        {
            this.IncreaseFund(this.ExpectedFund);
        }

        private void DevelopMonth()
        {
            if (this.BelongedFaction != null)
            {
                if (this.Kind.HasAgriculture)
                {
                    this.DevelopFood();
                }
                if (this.Kind.HasCommerce)
                {
                    this.DevelopFund();
                }
            }
        }

        private void DevelopMorale()
        {
            if (this.Morale != this.MoraleCeiling)
            {
                foreach (Person person in this.MoraleWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.MoraleAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddCommandExperience(randomValue);
                        person.AddPoliticsExperience(randomValue);
                        person.AddGlamourExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfMoraleReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfMoraleTechniquePoint) * 100);
                        this.IncreaseMorale(randomValue);
                    }
                }
            }
        }

        private void DevelopPopulation()
        {
            double populationDevelopingRate = this.PopulationDevelopingRate;
            if (populationDevelopingRate != 0.0)
            {
                //this.IncreasePopulation(StaticMethods.GetRandomValue(this.population + (0x3e8 * this.AreaCount), (int) (1.0 / populationDevelopingRate)));
                this.IncreasePopulation(StaticMethods.GetBigRandomValue(this.population + (1000 * this.AreaCount), (int)(1.0 / populationDevelopingRate)));

            }
        }

        public void DevelopSeason()
        {
        }

        private void DevelopTechnology()
        {
            if (this.Technology != this.TechnologyCeiling)
            {
                foreach (Person person in this.TechnologyWorkingPersons)
                {
                    if (!person.InternalNoFundNeeded)
                    {
                        if (this.Fund < this.InternalFundCost)
                        {
                            continue;
                        }
                        this.DecreaseFund(this.InternalFundCost);
                    }
                    int randomValue = StaticMethods.GetRandomValue((int) ((person.TechnologyAbility * this.CurrentRateOfInternal) * Parameters.InternalRate), 500 + (150 * (this.AreaCount - 1)));
                    if (randomValue > 0)
                    {
                        person.AddInternalExperience(randomValue * 2);
                        person.AddIntelligenceExperience(randomValue * 2);
                        person.AddPoliticsExperience(randomValue * 2);
                        person.IncreaseReputation(randomValue * 4);
                        this.BelongedFaction.IncreaseReputation(randomValue * person.MultipleOfTechnologyReputation);
                        this.BelongedFaction.IncreaseTechniquePoint((randomValue * person.MultipleOfTechnologyTechniquePoint) * 100);
                        this.IncreaseTechnology(randomValue);
                    }
                }
            }
        }

        public void DevelopYear()
        {
        }

        private void DiplomaticRelationAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (this.BelongedFaction != null))
            {
            }
        }

        public bool DisbandAvail()
        {
            return ((this.Militaries.Count > 0) && this.Kind.HasPopulation);
        }

        public void DisbandMilitary(Military m)
        {
            this.IncreasePopulation(m.Quantity);
            this.RemoveMilitary(m);
            this.BelongedFaction.RemoveMilitary(m);
        }

        public bool DisbandSectionAvail()
        {
            return (this.BelongedFaction.SectionCount > 1);
        }

        public bool DominationAvail()
        {
            return (this.Kind.HasDomination && this.HasPerson());
        }

        public string DominationInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 20);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 10);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Domination, 5);

                case InformationLevel.全:
                    return this.Domination.ToString();
            }
            return "----";
        }

        public bool EnduranceAvail()
        {
            return (this.Kind.HasEndurance && this.HasPerson());
        }

        public string EnduranceInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 500);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 200);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Endurance, 100);

                case InformationLevel.全:
                    return this.Endurance.ToString();
            }
            return "----";
        }

        public bool FacilityBuildable(FacilityKind facilityKind)
        {
            if (this.BuildingFacility >= 0)
            {
                return false;
            }
            if (!(!facilityKind.PopulationRelated || this.Kind.HasPopulation))
            {
                return false;
            }
            if (((facilityKind.PointCost > this.BelongedFaction.TotalTechniquePoint) || (facilityKind.TechnologyNeeded > this.Technology)) || (facilityKind.FundCost > this.Fund))
            {
                return false;
            }
            if (facilityKind.UniqueInArchitecture && this.ArchitectureHasFacilityKind(facilityKind.ID))
            {
                return false;
            }
            if (this.FacilityPositionLeft < facilityKind.PositionOccupied)
            {
                return false;
            }
            if (facilityKind.UniqueInFaction && this.FactionHasFacilityKind(facilityKind.ID))
            {
                return false;
            }
            return true;
        }

        private void FacilityDoWork()
        {
            if (this.FacilityEnabled)
            {
                foreach (Facility facility in this.Facilities)
                {
                    facility.DoWork(this);
                }
            }
        }

        private bool FacilityIsPossibleOverTechnology(int tech)
        {
            foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
            {
                if ((((!kind.PopulationRelated || this.Kind.HasPopulation) && ((tech < kind.TechnologyNeeded) && (this.Technology >= kind.TechnologyNeeded))) && ((this.FacilityPositionCount >= kind.PositionOccupied) && (!kind.UniqueInArchitecture || !this.ArchitectureHasFacilityKind(kind.ID)))) && (!kind.UniqueInFaction || !this.FactionHasFacilityKind(kind.ID)))
                {
                    return true;
                }
            }
            return false;
        }

        private void FacilityMaintenance()
        {
            int facilityMaintenanceCost = this.FacilityMaintenanceCost;
            if (this.Fund >= facilityMaintenanceCost)
            {
                if (!this.FacilityEnabled)
                {
                    this.ApplyFacilityInfluences();
                }
                this.FacilityEnabled = true;
                this.DecreaseFund(facilityMaintenanceCost);
            }
            else
            {
                if (this.FacilityEnabled)
                {
                    this.PurifyFacilityInfluences();
                }
                this.FacilityEnabled = false;
            }
        }

        private void FacilityRecovery()
        {
            if (this.FacilityEnabled)
            {
                this.Facilities.RecoverEndurance();
            }
        }

        public bool FactionHasCaptive()
        {
            return ((this.BelongedFaction != null) ? this.BelongedFaction.HasCaptive() : false);
        }

        public bool FactionHasFacilityKind(int id)
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture.ArchitectureHasFacilityKind(id))
                {
                    return true;
                }
            }
            return false;
        }

        public bool FactionHasSelfCaptive()
        {
            return ((this.BelongedFaction != null) ? this.BelongedFaction.HasSelfCaptive() : false);
        }

        public bool FactionHasTreasure()
        {
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.BelongedFaction.Persons)
                {
                    if (person.TreasureCount > 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool FindRouteway(LinkNode node, bool hasEnd, out float rate)
        {
            rate = 1f;
            Point key = new Point(base.ID, node.A.ID);
            if (!this.BelongedFaction.ClosedRouteways.ContainsKey(key))
            {
                Point? nullable;
                Point? nullable2;
                base.Scenario.GetClosestPointsBetweenTwoAreas(this.GetRoutewayStartPoints(), node.A.GetAIRoutewayEndPoints(this, true), out nullable, out nullable2);
                if (nullable.HasValue && nullable2.HasValue)
                {
                    this.BelongedFaction.RoutewayPathBuilder.MultipleWaterCost = node.Kind == LinkKind.Land;
                    if (this.BelongedFaction.RoutewayPathAvail(nullable.Value, nullable2.Value, hasEnd))
                    {
                        rate = this.BelongedFaction.RoutewayPathBuilder.PathConsumptionRate;
                        return true;
                    }
                }
            }
            return false;
        }

        public void FoodReduce()
        {
            this.DecreaseFood((int) (this.Food * this.FoodReduceDayRate));
        }

        public void FundPacksDayEvent()
        {
            for (int i = this.FundPacks.Count - 1; i >= 0; i--)
            {
                FundPack local1 = this.FundPacks[i];
                local1.Days--;
                if (this.FundPacks[i].Days <= 0)
                {
                    this.IncreaseFund(this.FundPacks[i].Fund);
                    this.FundPacks.RemoveAt(i);
                }
            }
        }

        public void GenerateAllAILinkNodes(int levelMax)
        {
            this.AILinkProcedureDetails.Clear();
            this.AIAllLinkNodes.Clear();
            List<Architecture> path = new List<Architecture>();
            this.AILinkProcedureDetails.Enqueue(new AILinkProcedureDetail(0, this, path));
            while (this.AILinkProcedureDetails.Count > 0)
            {
                AILinkProcedureDetail detail = this.AILinkProcedureDetails.Dequeue();
                this.AddAllAILink(detail.Level, levelMax, detail.A, detail.Path);
            }
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                node.Kind = this.CheckCampaignable(node);
            }
        }

        public GameObjectList GetAILinks()
        {
            GameObjectList list = this.AILandLinks.GetList();
            foreach (Architecture architecture in this.AIWaterLinks)
            {
                if (list.GetGameObject(architecture.ID) == null)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public GameObjectList GetAILinks(int level)
        {
            GameObjectList list = new GameObjectList();
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level <= level)
                {
                    list.Add(node.A);
                }
            }
            return list;
        }

        public GameArea GetAIRoutewayEndPoints(Architecture a, bool nowater)
        {
            GameArea area = new GameArea();
            if (!this.IsFriendly(a.BelongedFaction))
            {
                foreach (Point point in this.ContactArea.Area)
                {
                    if (a.IsRoutewayPossible(point) && (!nowater || (base.Scenario.GetTerrainKindByPosition(point) != TerrainKind.水域)))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.GetRoutewayStartArea().Area)
                {
                    if (a.IsRoutewayPossible(point) && (!nowater || (base.Scenario.GetTerrainKindByPosition(point) != TerrainKind.水域)))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (a.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public GameArea GetAllAvailableArea(bool Square)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                if (base.Scenario.IsPositionEmpty(point))
                {
                    area.AddPoint(point);
                }
            }
            foreach (Point point in this.ArchitectureArea.Area)
            {
                if (!base.Scenario.PositionIsTroop(point))
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        public GameArea GetAllContactArea()
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                area.AddPoint(point);
            }
            foreach (Point point in this.ArchitectureArea.Area)
            {
                area.AddPoint(point);
            }
            return area;
        }

        public PersonList GetAllPersons()
        {
            PersonList list = new PersonList();
            foreach (Person person in this.Persons)
            {
                list.Add(person);
            }
            foreach (Person person in this.MovingPersons)
            {
                list.Add(person);
            }
            return list;
        }

        public TreasureList GetAllTreasureInArchitecture()
        {
            TreasureList list = new TreasureList();
            foreach (Person person in this.GetAllPersons())
            {
                person.AddTreasureToList(list);
            }
            return list;
        }

        public TreasureList GetAllTreasureInArchitectureExceptLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person != this.BelongedFaction.Leader)
                    {
                        person.AddTreasureToList(list);
                    }
                }
            }
            return list;
        }

        public TreasureList GetAllTreasureInFaction()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.BelongedFaction.Persons)
                {
                    person.AddTreasureToList(list);
                }
            }
            return list;
        }

        public GameArea GetAvailableContactArea(bool Square)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ContactArea.Area)
            {
                if (base.Scenario.IsPositionEmpty(point))
                {
                    area.AddPoint(point);
                }
            }
            if (area.Count > 0)
            {
                return area;
            }
            return null;
        }

        public MilitaryList GetBeMergedMilitaryList(Military military)
        {
            this.BeMergedMilitaryList.Clear();
            foreach (Military military2 in this.MergeMilitaryList)
            {
                if ((military2 != military) && (military2.Kind == military.Kind))
                {
                    this.BeMergedMilitaryList.Add(military2);
                }
            }
            return this.BeMergedMilitaryList;
        }

        public GameObjectList GetBuildableFacilityKindList()
        {
            this.BuildableFacilityKindList.Clear();
            foreach (FacilityKind kind in base.Scenario.GameCommonData.AllFacilityKinds.FacilityKinds.Values)
            {
                if (this.FacilityBuildable(kind))
                {
                    this.BuildableFacilityKindList.Add(kind);
                }
            }
            return this.BuildableFacilityKindList;
        }

        public MilitaryList GetCampaignMilitaryList()
        {
            this.CampaignMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity > 0) && (military.Morale > 0))
                {
                    this.CampaignMilitaryList.AddMilitary(military);
                }
            }
            return this.CampaignMilitaryList;
        }

        public Point? GetCampaignPosition(Troop troop, List<Point> orientations, bool close)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            GameArea sourceArea = new GameArea();
            foreach (Point point in allAvailableArea.Area)
            {
                if (((base.Scenario.GetArchitectureByPosition(point) == this) && (base.Scenario.GetTroopByPosition(point) == null)) || troop.IsMovableOnPosition(point))
                {
                    sourceArea.Area.Add(point);
                }
            }
            GameArea highestFightingForceArea = troop.GetHighestFightingForceArea(sourceArea);
            if (highestFightingForceArea != null)
            {
                if (close)
                {
                    return base.Scenario.GetClosestPosition(highestFightingForceArea, orientations);
                }
                return base.Scenario.GetFarthestPosition(highestFightingForceArea, orientations);
            }
            return null;
        }

        public ArchitectureList GetChangeCapitalArchitectureList()
        {
            this.ChangeCapitalArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.ChangeCapitalArchitectureList.Add(architecture);
                    }
                }
            }
            return this.ChangeCapitalArchitectureList;
        }

        public void GetClosestArchitectures()
        {
            this.ClosestArchitectures = new ArchitectureList();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture != this)
                {
                    this.ClosestArchitectures.Add(architecture);
                }
            }
            this.QuickSortArchitecturesDistance(this.ClosestArchitectures, 0, this.ClosestArchitectures.Count - 1);
        }

        public ArchitectureList GetClosestArchitectures(int count)
        {
            if (this.ClosestArchitectures == null)
            {
                this.GetClosestArchitectures();
            }
            ArchitectureList list = new ArchitectureList();
            if (count > this.ClosestArchitectures.Count)
            {
                count = this.ClosestArchitectures.Count;
            }
            for (int i = 0; i < count; i++)
            {
                list.Add(this.ClosestArchitectures[i]);
            }
            return list;
        }

        public Routeway GetConnectedRouteway(Architecture end)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if ((routeway.EndArchitecture == end) && routeway.IsActive)
                {
                    return routeway;
                }
            }
            return null;
        }

        public PersonList GetConvinceDestinationPersonList(Faction faction)
        {
            this.ConvinceDestinationPersonList.Clear();
            if (this.BelongedFaction == faction)
            {
                foreach (Captive captive in this.Captives)
                {
                    this.ConvinceDestinationPersonList.Add(captive.CaptivePerson);
                }
            }
            else
            {
                foreach (Person person in this.Persons)
                {
                    this.ConvinceDestinationPersonList.Add(person);
                }
            }
            return this.ConvinceDestinationPersonList;
        }

        public GameArea GetConvincePersonArchitectureArea()
        {
            GameArea area = new GameArea();
        //Label_0121:
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture.BelongedFaction == null)
                {
                    continue;
                }
                if (architecture.BelongedFaction == this.BelongedFaction)
                {
                    if (!architecture.HasCaptive())
                    {
                        //goto Label_0121;
                        continue;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
                else
                {
                    if (!architecture.HasPerson() || !this.BelongedFaction.IsArchitectureKnown(architecture))
                    {
                        continue;
                    }
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public GameArea GetDestroyArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (!this.IsFriendly(architecture.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public int GetDistanceFromFaction(Faction faction)
        {
            if ((faction == null) || (faction.ArchitectureCount == 0))
            {
                return 0;
            }
            if (this.BelongedFaction == faction)
            {
                return 0;
            }
            if (this.ClosestArchitectures == null)
            {
                this.GetClosestArchitectures();
            }
            int num = 0;
            for (int i = 0; i < this.ClosestArchitectures.Count; i++)
            {
                if ((this.ClosestArchitectures[i] as Architecture).BelongedFaction == faction)
                {
                    num += (i * (this.ClosestArchitectures[i] as Architecture).Population) / 0x2710;
                }
            }
            if (this.BelongedFaction != null)
            {
                int diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, faction.ID);
                if (diplomaticRelation <= -200)
                {
                    num /= 4;
                }
                else if (diplomaticRelation < 0)
                {
                    num /= 1;
                }
            }
            return (num / faction.ArchitectureCount);
        }

        public int GetDistanceFromSection(Section section)
        {
            if ((section == null) || (section.ArchitectureCount == 0))
            {
                return 0;
            }
            if (this.BelongedSection == section)
            {
                return 0;
            }
            int num = 0;
            foreach (Architecture architecture in section.Architectures)
            {
                LinkNode node = null;
                this.AIAllLinkNodes.TryGetValue(architecture.ID, out node);
                if (node != null)
                {
                    num += (int) (node.Level * node.Distance);
                }
                else
                {
                    num += 0x3e8;
                }
                num -= architecture.Population / 0x2710;
            }
            return (num / section.ArchitectureCount);
        }

        public Routeway GetExistingRouteway(Architecture destination)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    return routeway;
                }
            }
            return null;
        }

        public Captive GetExtremeLoyaltyCaptive(bool low)
        {
            GameObjectList list = this.Captives.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "Loyalty";
                    list.IsNumber = true;
                    list.SmallToBig = low;
                    list.ReSort();
                }
                return (list[0] as Captive);
            }
            return null;
        }

        public Person GetExtremeLoyaltyPerson(bool low)
        {
            GameObjectList list = this.Persons.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "Loyalty";
                    list.IsNumber = true;
                    list.SmallToBig = low;
                    list.ReSort();
                }
                return (list[0] as Person);
            }
            return null;
        }

        public Person GetExtremePersonFromWorkingList(ArchitectureWorkKind workKind, bool highest)  //大概是选择在冒泡小窗口说话的人
        {
            PersonList agricultureWorkingPersons = null;
            int num2;
            int num3;
            int workAbility;
            switch (workKind)
            {
                case ArchitectureWorkKind.赈灾:
                    agricultureWorkingPersons = this.zhenzaiWorkingPersons;   
                    break;
                case ArchitectureWorkKind.农业:
                    agricultureWorkingPersons = this.AgricultureWorkingPersons;
                    break;

                case ArchitectureWorkKind.商业:
                    agricultureWorkingPersons = this.CommerceWorkingPersons;
                    break;

                case ArchitectureWorkKind.技术:
                    agricultureWorkingPersons = this.TechnologyWorkingPersons;
                    break;

                case ArchitectureWorkKind.统治:
                    agricultureWorkingPersons = this.DominationWorkingPersons;
                    break;

                case ArchitectureWorkKind.民心:
                    agricultureWorkingPersons = this.MoraleWorkingPersons;
                    break;

                case ArchitectureWorkKind.耐久:
                    agricultureWorkingPersons = this.EnduranceWorkingPersons;
                    break;

                default:
                    return null;
            }
            if (agricultureWorkingPersons.Count == 0)
            {
                return null;
            }
            if (agricultureWorkingPersons.Count == 1)
            {
                return (agricultureWorkingPersons[0] as Person);
            }
            if (highest)
            {
                int num = 0;
                num2 = 0;
                for (num3 = 0; num3 < agricultureWorkingPersons.Count; num3++)
                {
                    workAbility = (agricultureWorkingPersons[num3] as Person).GetWorkAbility(workKind);
                    if (workAbility > num)
                    {
                        num = workAbility;
                        num2 = num3;
                    }
                }
                return (agricultureWorkingPersons[num2] as Person);
            }
            int num5 = 0x7fffffff;
            num2 = 0;
            for (num3 = 0; num3 < agricultureWorkingPersons.Count; num3++)
            {
                workAbility = (agricultureWorkingPersons[num3] as Person).GetWorkAbility(workKind);
                if (workAbility < num5)
                {
                    num5 = workAbility;
                    num2 = num3;
                }
            }
            return (agricultureWorkingPersons[num2] as Person);
        }

        public InformationKind GetFirstHalfInformationKind()
        {
            InformationKindList list = new InformationKindList();
            foreach (InformationKind kind in base.Scenario.GameCommonData.AllInformationKinds.GetAvailList(this))
            {
                if ((kind.Level <= InformationLevel.中) || GameObject.Chance(20))
                {
                    list.Add(kind);
                }
            }
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = "FightingWeighing";
                    list.IsNumber = true;
                    list.ReSort();
                }
                return (list[GameObject.Random(list.Count / 2)] as InformationKind);
            }
            return null;
        }

        private Person GetFirstHalfPerson(string propertyName)
        {
            GameObjectList list = this.Persons.GetList();
            if (list.Count > 0)
            {
                if (list.Count > 1)
                {
                    list.PropertyName = propertyName;
                    list.IsNumber = true;
                    list.ReSort();
                }
                return (list[GameObject.Random(list.Count / 2)] as Person);
            }
            return null;
        }

        internal int GetFriendlyTroopFightingForceInView()
        {
            int num = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                {
                    num += troopByPosition.FightingForce;
                }
            }
            return num;
        }

        public TroopList GetFriendlyTroopsInView()
        {
            GameArea longViewArea = this.LongViewArea;
            TroopList list = new TroopList();
            foreach (Point point in longViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && troopByPosition.IsFriendly(this.BelongedFaction))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        public int GetGossipablePersonCount()
        {
            int num = 0;
            foreach (Person person in this.Persons)
            {
                if ((person.Loyalty <= 100) && (person != this.BelongedFaction.Leader))
                {
                    num++;
                }
            }
            return num;
        }

        public GameArea GetGossipArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if ((((architecture.BelongedFaction != null) && !this.IsFriendly(architecture.BelongedFaction)) && architecture.HasPerson()) && this.BelongedFaction.IsArchitectureKnown(architecture))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public TroopList GetHostileTroopsInView()
        {
            GameArea viewArea = this.ViewArea;
            if ((this.RecentlyAttacked > 0) || (this.ArmyScale > this.LargeArmyScale))
            {
                viewArea = this.LongViewArea;
            }
            TroopList list = new TroopList();
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (!troopByPosition.IsFriendly(this.BelongedFaction) && (troopByPosition.Status != TroopStatus.埋伏)))
                {
                    int days = 1;
                    if ((((this.BelongedFaction != null) && (troopByPosition.BelongedFaction != null)) && (this.RecentlyAttacked <= 0)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) >= 0))
                    {
                        days = 0;
                    }
                    if (troopByPosition.DaysToReachPosition(base.Scenario.GetClosestPoint(this.ArchitectureArea, troopByPosition.Position), days))
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }

        public GameArea GetInstigateArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if (architecture.Kind.HasDomination && !this.IsFriendly(architecture.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetLevelUpMilitaryList()
        {
            this.LevelUpMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if (((military.InjuryQuantity == 0) && military.Kind.CanLevelUp) && (military.Experience >= military.Kind.LevelUpExperience))
                {
                    this.LevelUpMilitaryList.AddMilitary(military);
                }
            }
            return this.LevelUpMilitaryList;
        }

        public MilitaryList GetMergeMilitaryList()
        {
            this.MergeMilitaryList.Clear();
            for (int i = 0; i < this.Militaries.Count; i++)
            {
                Military t = this.Militaries[i] as Military;
                if ((t.Quantity != t.Kind.MaxScale) && (t.InjuryQuantity <= 0))
                {
                    foreach (Military military2 in this.Militaries)
                    {
                        if (((t != military2) && (t.Kind == military2.Kind)) && ((military2.Quantity < military2.Kind.MaxScale) && (military2.InjuryQuantity == 0)))
                        {
                            this.MergeMilitaryList.Add(t);
                            break;
                        }
                    }
                }
            }
            return this.MergeMilitaryList;
        }

        public GameArea GetMilitaryCampaignArea(Military military)
        {
            GameArea allAvailableArea = this.GetAllAvailableArea(false);
            military.ModifyAreaByTerrainAdaptablity(allAvailableArea);
            return allAvailableArea;
        }

        public MilitaryKindList GetNewMilitaryKindList()
        {
            this.NewMilitaryKindList.Clear();
            foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.CreateAvail(this))
                {
                    this.NewMilitaryKindList.Add(kind);
                }
            }
            foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.CreateAvail(this))
                {
                    this.NewMilitaryKindList.Add(kind);
                }
            }
            return this.NewMilitaryKindList;
        }

        public ArchitectureList GetOtherArchitectureList()
        {
            this.OtherArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.OtherArchitectureList.Add(architecture);
                    }
                }
            }
            return this.OtherArchitectureList;
        }


        public ArchitectureList jingongjianzhuliebiao()
        {
            ArchitectureList jianzhuliebiao=new ArchitectureList();
            if (base.Scenario.youhuangdi())
            {
                jianzhuliebiao.Add(base.Scenario.huangdisuozaijianzhu());
            }
            return jianzhuliebiao ;
        }

        public PersonList GetPersonConveneList()
        {
            this.PersonConveneList.Clear();
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture != this)
                {
                    foreach (Person person in architecture.Persons)
                    {
                        this.PersonConveneList.Add(person);
                    }
                }
            }
            return this.PersonConveneList;
        }

        public PersonList GetPersonListExceptLeader()
        {
            PersonList list = new PersonList();
            if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person != this.BelongedFaction.Leader)
                    {
                        list.Add(person);
                    }
                }
            }
            return list;
        }

        public PersonList GetPersonStudySkillList()
        {
            this.PersonStudySkillList.Clear();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableSkill)
                {
                    this.PersonStudySkillList.Add(person);
                }
            }
            return this.PersonStudySkillList;
        }

        public PersonList GetPersonStudyStuntList()
        {
            this.PersonStudyStuntList.Clear();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableStunt)
                {
                    this.PersonStudyStuntList.Add(person);
                }
            }
            return this.PersonStudyStuntList;
        }

        public PersonList GetPersonStudyTitleList()
        {
            this.PersonStudyTitleList.Clear();
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableTitle)
                {
                    this.PersonStudyTitleList.Add(person);
                }
            }
            return this.PersonStudyTitleList;
        }

        public GameArea GetRealTroopEnterableArea(Troop troop)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.GetTroopEnterableArea(troop).Area)
            {
                if (!base.Scenario.PositionIsTroop(point))
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        public MilitaryList GetRecruitmentMilitaryList()
        {
            this.RecruitmentMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity < military.Kind.MaxScale) && (military.InjuryQuantity == 0))
                {
                    this.RecruitmentMilitaryList.AddMilitary(military);
                }
            }
            return this.RecruitmentMilitaryList;
        }

        public CaptiveList GetRedeemCaptiveList()
        {
            this.RedeemCaptiveList.Clear();
            foreach (Captive captive in this.BelongedFaction.SelfCaptives)
            {
                if ((captive.RansomArriveDays == 0) && (captive.Ransom <= this.Fund))
                {
                    this.RedeemCaptiveList.Add(captive);
                }
            }
            return this.RedeemCaptiveList;
        }

        internal int GetRelationUnderZeroTroopFightingForceInView(out float rationRate)
        {
            int num = 0;
            rationRate = 0f;
            int num2 = 0;
            foreach (Point point in this.LongViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) < 0))
                {
                    rationRate += ((float) troopByPosition.RationDaysLeft) / ((float) troopByPosition.RationDays);
                    num2++;
                    num += troopByPosition.FightingForce;
                }
            }
            if (num2 > 1)
            {
                rationRate /= (float) num2;
            }
            return num;
        }

        public GameObjectList GetResetDiplomaticRelationList()
        {
            this.ResetDiplomaticRelationList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (DiplomaticRelationDisplay display in base.Scenario.DiplomaticRelations.GetDiplomaticRelationDisplayListByFactionID(this.BelongedFaction.ID))
                {
                    if (display.Relation >= 300)
                    {
                        this.ResetDiplomaticRelationList.Add(display);
                    }
                }
            }
            return this.ResetDiplomaticRelationList;
        }

        public PersonList GetRewardPersons()
        {
            this.RewardPersonList.Clear();
            foreach (Person person in this.Persons)
            {
                if ((!person.RewardFinished && (person.Loyalty < 100)) && (person != this.BelongedFaction.Leader))
                {
                    this.RewardPersonList.Add(person);
                }
            }
            return this.RewardPersonList;
        }

        public Routeway GetRouteway(LinkNode node, bool hasEnd)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if ((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A)))
                {
                    return routeway;
                }
            }
            return this.BuildRouteway(node, hasEnd);
        }

        public ArchitectureList GetRoutewayDestinationArchitectureList()
        {
            this.RoutewayDestinationArchitectures.Clear();
            this.RoutewayProcedures.Clear();
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                architecture.surplusRate = 0f;
                architecture.PathRoutewayID = -1;
            }
            this.surplusRate = 1f;
            this.RoutewayProcedures.Enqueue(new RoutewayProcedureDetail(this, 1f));
            while (this.RoutewayProcedures.Count > 0)
            {
                RoutewayProcedureDetail detail = this.RoutewayProcedures.Dequeue();
                this.AddCloseRoutewayDestinationArchitectures(detail.Start, detail.PreviousRate);
            }
            return this.RoutewayDestinationArchitectureList;
        }

        public GameArea GetRoutewayStartArea()
        {
            return this.GetAllContactArea().GetContactArea(false);
        }

        public GameArea GetRoutewayStartPoints()
        {
            GameArea area = new GameArea();
            foreach (Point point in this.GetRoutewayStartArea().Area)
            {
                if (this.IsRoutewayPossible(point))
                {
                    area.AddPoint(point);
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.ContactArea.Area)
                {
                    if (this.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            if (area.Count == 0)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (this.IsRoutewayPossible(point))
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetShelledMilitaryList(MilitaryType militaryType)
        {
            this.ShelledMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if (((military.Quantity > 0) && (military.Morale > 0)) && (military.Kind.Type != militaryType))
                {
                    this.ShelledMilitaryList.AddMilitary(military);
                }
            }
            return this.ShelledMilitaryList;
        }

        public GameArea GetSpyArchitectureArea()
        {
            GameArea area = new GameArea();
            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                if ((architecture.BelongedFaction != null) && (architecture.BelongedFaction != this.BelongedFaction))
                {
                    foreach (Point point in architecture.ArchitectureArea.Area)
                    {
                        area.AddPoint(point);
                    }
                }
            }
            return area;
        }

        public MilitaryList GetTrainingMilitaryList()
        {
            this.TrainingMilitaryList.Clear();
            foreach (Military military in this.Militaries)
            {
                if ((military.Quantity > 0) && ((military.Morale < military.MoraleCeiling) || (military.Combativity < military.CombativityCeiling)))
                {
                    this.TrainingMilitaryList.AddMilitary(military);
                }
            }
            return this.TrainingMilitaryList;
        }

        public ArchitectureList GetTransferArchitectureList()
        {
            this.TransferArchitectureList.Clear();
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        this.TransferArchitectureList.Add(architecture);
                    }
                }
            }
            return this.TransferArchitectureList;
        }

        public TreasureList GetTreasureListOfLeader()
        {
            TreasureList list = new TreasureList();
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.Leader.AddTreasureToList(list);
            }
            return list;
        }

        public GameArea GetTroopEnterableArea(Troop troop)
        {
            GameArea area = new GameArea();
            foreach (Point point in this.ArchitectureArea.Area)
            {
                if (base.Scenario.GetWaterPositionMapCost(troop.Army.Kind.Type, point) < 0xdac)
                {
                    area.AddPoint(point);
                }
            }
            foreach (Point point in this.ContactArea.Area)
            {
                if (troop.IsMovableOnPosition(point) && (base.Scenario.GetWaterPositionMapCost(troop.Army.Kind.Type, point) < 0xdac))
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        public bool GossipAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.GossipArchitectureFund)) && (this.GetGossipArchitectureArea().Count > 0));
        }

        private void HandleFacilities()
        {
            this.CheckBuildingFacility();
            this.FacilityMaintenance();
            this.FacilityRecovery();
            this.FacilityDoWork();
        }

        public bool HasAnyPerson()
        {
            return ((this.Persons.Count > 0) || (this.MovingPersons.Count > 0));
        }

        public bool HasCampaignableMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (((military.Quantity > 0) && (military.Morale > 0)) && (military.InjuryQuantity < military.Kind.MinScale))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasCaptive()
        {
            return (this.CaptiveCount > 0);
        }

        private bool HasCloserOffensiveArchitecture(LinkNode node, out Architecture closer)
        {
            closer = null;
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture != this)
                {
                    LinkNode node2 = null;
                    architecture.AIAllLinkNodes.TryGetValue(node.A.ID, out node2);
                    if (((node2 != null) && (node2.Level < node.Level)) && (node2.Kind != LinkKind.None))
                    {
                        closer = architecture;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasContactHostileTroop(Faction faction)
        {
            foreach (Point point in this.GetAllContactArea().Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !troopByPosition.IsFriendly(faction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEnoughForceOffensiveMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military) && (military.Scales >= 30))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasExperiencedLeaderMilitary(Person person)
        {
            foreach (Military military in this.Militaries)
            {
                if ((military.Leader == person) && (military.LeaderExperience >= 200))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFacility()
        {
            return (this.FacilityCount > 0);
        }
        public bool HaskechaichuFacility()
        {
            return (this.kechaichudesheshi().Count > 0);
        }
        public bool HasFaction()
        {
            return (this.BelongedFaction != null);
        }

        public bool HasFactionInClose(Faction faction, int level)
        {
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level > level)
                {
                    return false;
                }
                if (node.A.BelongedFaction == faction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFactionSpy(Faction faction)
        {
            foreach (SpyPack pack in this.SpyPacks)
            {
                if (pack.SpyPerson.BelongedFaction == faction)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasFollowedLeaderMilitary(Person person)
        {
            foreach (Military military in this.Militaries)
            {
                if (military.FollowedLeader == person)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasHostileArchitectureOnPath(LinkNode node)
        {
            foreach (Architecture architecture in node.Path)
            {
                if (((architecture != this) && (architecture != node.A)) && !((architecture.BelongedFaction == null) || this.IsFriendly(architecture.BelongedFaction)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasHostileTroopsInArchitecture()
        {
            foreach (Point point in this.ArchitectureArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !troopByPosition.IsFriendly(this.BelongedFaction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasHostileTroopsInView()
        {
            GameArea viewArea = this.ViewArea;
            if ((this.RecentlyAttacked > 0) || (this.ArmyScale > this.NormalArmyScale))
            {
                viewArea = this.LongViewArea;
            }
            foreach (Point point in viewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (!troopByPosition.IsFriendly(this.BelongedFaction) && (troopByPosition.Status != TroopStatus.埋伏)))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMilitary()
        {
            return (this.Militaries.Count > 0);
        }

        public bool HasMovingPerson()
        {
            return (this.MovingPersons.Count > 0);
        }

        public bool HasNoFactionPerson()
        {
            return (this.NoFactionPersonCount > 0);
        }

        public bool HasOffensiveMilitary()
        {
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasOffensiveSectionInClose(out Section section, int level)
        {
            section = null;
            foreach (LinkNode node in this.AIAllLinkNodes.Values)
            {
                if (node.Level > level)
                {
                    return false;
                }
                if (((node.A.BelongedSection != null) && (node.A.BelongedSection.BelongedFaction == this.BelongedFaction)) && node.A.BelongedSection.AIDetail.ValueOffensiveCampaign)
                {
                    section = node.A.BelongedSection;
                    return true;
                }
            }
            return false;
        }

        public bool HasPerson()
        {
            return (this.Persons.Count > 0);
        }

        public bool HasRelationUnderZeroHostileTroopsInView()
        {
            if (this.BelongedFaction != null)
            {
                GameArea viewArea = this.ViewArea;
                if (this.Kind.HasLongView && (this.ArmyScale < this.NormalArmyScale))
                {
                    viewArea = this.LongViewArea;
                }
                foreach (Point point in viewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((((troopByPosition != null) && (troopByPosition.BelongedFaction != null)) && (troopByPosition.Status != TroopStatus.埋伏)) && (base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, troopByPosition.BelongedFaction.ID) < 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasRouteway(Architecture destination)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasRouteway(LinkNode node, bool hasEnd)
        {
            float rate = 1f;
            foreach (Routeway routeway in this.Routeways)
            {
                if (((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A))) && (routeway.LastPoint.ConsumptionRate <= this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax))
                {
                    return true;
                }
            }
            return this.FindRouteway(node, hasEnd, out rate);
        }

        public bool HasRouteway(LinkNode node, bool hasEnd, out float rate)
        {
            foreach (Routeway routeway in this.Routeways)
            {
                if (((routeway.DestinationArchitecture == node.A) && (!hasEnd || (routeway.EndArchitecture == node.A))) && (routeway.LastPoint.ConsumptionRate <= this.BelongedFaction.RoutewayPathBuilder.ConsumptionMax))
                {
                    rate = routeway.LastPoint.ConsumptionRate;
                    return true;
                }
            }
            return this.FindRouteway(node, hasEnd, out rate);
        }

        public RoutewayList HasRoutewayList(Architecture destination)
        {
            RoutewayList list = new RoutewayList();
            foreach (Routeway routeway in this.Routeways)
            {
                if (routeway.DestinationArchitecture == destination)
                {
                    list.Add(routeway);
                }
            }
            return list;
        }

        public bool HasShuijun()
        {
            foreach (Military military in this.Militaries)
            {
                if (military.Kind.Type == MilitaryType.水军)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasShuijunMilitaryKind()
        {
            foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.Type == MilitaryType.水军)
                {
                    return true;
                }
            }
            foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
            {
                if (kind.Type == MilitaryType.水军)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTreasure()
        {
            foreach (Person person in this.GetAllPersons())
            {
                if (person.TreasureCount > 0)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasTreasureToAward()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                if (this.PersonCount <= 1)
                {
                    return false;
                }
                if (this.Persons.GetGameObject(this.BelongedFaction.Leader.ID) == null)
                {
                    return false;
                }
                foreach (Person person in this.Persons)
                {
                    if ((person == this.BelongedFaction.Leader) && (person.TreasureCount > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasTreasureToConfiscate()
        {
            if ((this.BelongedFaction != null) && (this.BelongedFaction.Leader != null))
            {
                if (this.Persons.GetGameObject(this.BelongedFaction.Leader.ID) == null)
                {
                    return false;
                }
                foreach (Person person in this.Persons)
                {
                    if ((person != this.BelongedFaction.Leader) && (person.TreasureCount > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool HasUnavailablePerson(PersonList personlist)
        {
            foreach (Person person in personlist)
            {
                if (person.LocationArchitecture == null)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasWorkingPerson()
        {
            foreach (Person person in this.Persons)
            {
                if (person.WorkKind != ArchitectureWorkKind.无)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HigtViewTroop(Troop troop)
        {
            return (this.ViewArea.HasPoint(troop.Position) && (((this.BelongedFaction != null) && this.IsFriendly(troop.BelongedFaction)) || (troop.Status != TroopStatus.埋伏)));
        }

        public void HireNoFactionPerson()
        {
            this.DecreaseFund(this.HirePersonFund);
            PersonList personList = new PersonList();
            foreach (Person person in this.NoFactionPersons.GetList())
            {
                if ((person.BelongedFaction != null) || (person.LocationArchitecture != this))
                {
                    this.NoFactionPersons.Remove(person);
                }
                else
                {
                    int idealOffset = Person.GetIdealOffset(person, this.BelongedFaction.Leader);
                    if ((!GlobalVariables.IdealTendencyValid || (idealOffset <= person.IdealTendency.Offset)) && (GameObject.Random((idealOffset + 10) * (idealOffset + 10)) < 100))
                    {
                        if (person.ProhibitedFactionID != this.BelongedFaction.ID)
                        {
                            personList.Add(person);
                        }
                        if (GameObject.Random(personList.Count) > 0)
                        {
                            break;
                        }
                    }
                }
            }
            foreach (Person person in personList)
            {
                this.RemoveNoFactionPerson(person);
                this.AddPerson(person);
                person.ChangeFaction(this.BelongedFaction);
            }
            if (personList.Count > 0)
            {

                if (this.OnHirePerson != null)
                {
                    this.OnHirePerson(personList);
                }

                if (this.HasSpy)
                {
                    this.CreateHireNewPersonSpyMessage(personList[GameObject.Random(personList.Count)] as Person);
                }
            }
            else if (personList.Count == 0)
            {
                if ((this.Scenario.CurrentPlayer != null) && this.BelongedFaction == this.Scenario.CurrentPlayer)
                {
                    this.shoudongluyongshibai = true;
                }

            }
            this.HireFinished = true;
        }

        public void shoudongluyong()
        {
            this.shoudongluyongshibai = false;
            this.HireNoFactionPerson();
            if (this.shoudongluyongshibai)
            {
                this.Scenario.GameScreen.xianshishijiantupian(this.NoFactionPersons[0] as Person, "", "luyongshibai", "", "");

            }
            this.shoudongluyongshibai = false;
        }

        public void IncreaseAgriculture(int increment)
        {
            this.Agriculture += increment;
            if (this.Agriculture > this.AgricultureCeiling)
            {
                this.Agriculture = this.AgricultureCeiling;
            }
        }

        public void IncreaseCommerce(int increment)
        {
            this.Commerce += increment;
            if (this.Commerce > this.CommerceCeiling)
            {
                this.Commerce = this.CommerceCeiling;
            }
        }

        public int IncreaseDomination(int increment)
        {
            int num = increment;
            if ((this.Domination + increment) > this.DominationCeiling)
            {
                num = this.DominationCeiling - this.Domination;
            }
            this.Domination += num;
            return num;
        }

        public int IncreaseEndurance(int increment)
        {
            if (increment <= 0)
            {
                return 0;
            }
            int num = increment;
            if ((this.Endurance + increment) > this.EnduranceCeiling)
            {
                num = this.EnduranceCeiling - this.Endurance;
            }
            if (this.Endurance == 0)
            {
                this.Endurance += num;
                this.WallStateChange();
            }
            else
            {
                this.Endurance += num;
            }
            return num;
        }

        public void IncreaseFood(int increment)
        {
            if (increment > 0)
            {
                if ((increment + this.food) > this.FoodCeiling)
                {
                    increment = this.FoodCeiling - this.food;
                }
                this.food += increment;
                this.IncrementNumberList.AddNumber(increment, CombatNumberKind.粮草, this.Position);
                this.ShowNumber = true;
            }
        }

        public void IncreaseFund(int increment)
        {
            if ((increment + this.fund) > this.FundCeiling)
            {
                increment = this.FundCeiling - this.fund;
            }
            this.fund += increment;
            this.IncrementNumberList.AddNumber(increment, CombatNumberKind.资金, this.Position);
            this.ShowNumber = true;
        }

        public void IncreaseMorale(int increment)
        {
            this.Morale += increment;
            if (this.Morale > this.MoraleCeiling)
            {
                this.Morale = this.MoraleCeiling;
            }
        }

        public int IncreasePopulation(int increment)
        {
            if ((this.population + increment) > this.PopulationCeiling)
            {
                increment = this.PopulationCeiling - this.population;
            }
            this.population += increment;
            if (this.population < 0)
            {
                this.population = 0;
            }
            return increment;
        }

        public void IncreaseTechnology(int increment)
        {
            this.Technology += increment;
            if (this.Technology > this.TechnologyCeiling)
            {
                this.Technology = this.TechnologyCeiling;
            }
        }

        private void IncreaseViewAreaCombativity()
        {
            if (this.IncrementOfCombativityInViewArea > 0)
            {
                foreach (Point point in this.ViewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition != null) && this.IsFriendly(troopByPosition.BelongedFaction))
                    {
                        troopByPosition.IncreaseCombativity(this.IncrementOfCombativityInViewArea);
                    }
                }
            }
        }

        public bool InformationAvail()
        {
            return (((this.InformationCoolDown <= 0) && this.HasPerson()) && base.Scenario.GameCommonData.AllInformationKinds.HasAvailItem(this));
        }

        private void InformationDayEvent()
        {
            if (this.InformationCoolDown > 0)
            {
                this.InformationCoolDown--;
            }
        }

        private void InsideTacticsAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && this.HasPerson())
            {
                if (this.Fund >= this.RewardPersonFund)
                {
                    if (this.IsFundEnough)
                    {
                        this.RewardPersonsUnderLoyalty(100);
                    }
                    else
                    {
                        Person extremeLoyaltyPerson = this.GetExtremeLoyaltyPerson(true);
                        if (!((extremeLoyaltyPerson.Loyalty >= 0x63) || extremeLoyaltyPerson.RewardFinished))
                        {
                            this.RewardPerson(extremeLoyaltyPerson);
                        }
                    }
                }
                if (((this.RecentlyAttacked <= 0) && (this.PlanArchitecture == null)) && !this.HasHostileTroopsInView())
                {
                //Label_0221:
                    foreach (Person person in this.Persons.GetList())
                    {
                        if (((!this.FrontLine || !GameObject.Chance(5)) && !GameObject.Chance(20)) || (GameObject.Random(base.Scenario.Date.Day) < GameObject.Random(30)))
                        {
                            continue;
                        }
                        if (GameObject.Chance(50) && person.HasLearnableSkill)
                        {
                            person.GoForStudySkill();
                        }
                        else if (GameObject.Chance(50))
                        {
                            Title higherLevelLearnableTitle = person.HigherLevelLearnableTitle;
                            if (higherLevelLearnableTitle != null)
                            {
                                person.GoForStudyTitle(higherLevelLearnableTitle);
                            }
                        }
                        else if (base.Scenario.GameCommonData.AllStunts.Count > person.StuntCount)
                        {
                            foreach (Stunt stunt in base.Scenario.GameCommonData.AllStunts.GetStuntList().GetRandomList())
                            {
                                if ((person.Stunts.GetStunt(stunt.ID) == null) && stunt.IsLearnable(person))
                                {
                                    person.GoForStudyStunt(stunt);
                                    break;
                                }
                            }
                        //Label_0220:;
                        }
                    }
                    foreach (Person person in this.Persons.GetList())
                    {
                        if ((person.WorkKind == ArchitectureWorkKind.无) && ((((((this.HostileLine && GameObject.Chance(10)) && GameObject.Chance(this.Morale / 10)) || !this.HostileLine) && ((GameObject.Random(base.Scenario.Date.Day) < GameObject.Random(30)) && (!this.HasFollowedLeaderMilitary(person) || GameObject.Chance(10)))) && (GameObject.Random(person.NonFightingNumber) > GameObject.Random(person.FightingNumber))) && (!this.FrontLine || (GameObject.Random(person.FightingNumber) < 100))))
                        {
                            person.GoForSearch();
                        }
                    }
                }
            }
        }

        public bool InstigateAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.InstigateArchitectureFund)) && (this.GetInstigateArchitectureArea().Count > 0));
        }

        public bool IsCaptiveInArchitecture(Captive captive)
        {
            return this.Captives.HasGameObject(captive);
        }

        public bool IsFriendly(Faction faction)
        {
            return ((this.BelongedFaction == faction) || ((this.BelongedFaction != null) && this.BelongedFaction.IsFriendly(faction)));
        }

        public bool IsFull()
        {
            return (((((this.Agriculture == this.AgricultureCeiling) && (this.Commerce == this.CommerceCeiling)) && ((this.Technology == this.TechnologyCeiling) && (this.Domination == this.DominationCeiling))) && (this.Morale == this.MoraleCeiling)) && (this.Endurance == this.EnduranceCeiling));
        }

        public bool IsGood()
        {
            return (((((this.Agriculture >= (this.AgricultureCeiling * 0.6)) && (this.Commerce >= (this.CommerceCeiling * 0.6))) && ((this.Technology >= (this.TechnologyCeiling * 0.6)) && (this.Domination >= (this.DominationCeiling * 0.8)))) && (this.Morale >= (this.MoraleCeiling * 0.6))) && (this.Endurance >= (this.EnduranceCeiling * 0.6)));
        }

        public bool IsHostile(Faction faction)
        {
            return ((this.BelongedFaction != null) && this.BelongedFaction.IsHostile(faction));
        }

        public bool IsLandLink(Architecture a)
        {
            return (this.AILandLinks.GetGameObject(a.ID) != null);
        }

        public bool IsMilitaryUnavailable(Military military)
        {
            return (military.BelongedArchitecture == null);
        }

        internal bool IsNodeFoodEnough(LinkNode node, Routeway routeway)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfLandMilitaries * ((routeway.Length + 6) - (node.A.LandArmyScale / 8))));

                case LinkKind.Water:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfWaterMilitaries * ((routeway.Length + 6) - (node.A.WaterArmyScale / 8))));

                case LinkKind.Both:
                    return (((node.A.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (node.A.FoodCostPerDayOfAllMilitaries * ((routeway.Length + 6) - (node.A.ArmyScale / 8))));
            }
            return false;
        }

        internal bool IsNodeHelpArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return ((!node.A.IsImportant && (node.A.LandArmyScale >= node.A.FewArmyScale)) || (node.A.LandArmyScale >= node.A.NormalArmyScale));

                case LinkKind.Water:
                    return ((!node.A.IsImportant && (node.A.WaterArmyScale >= node.A.FewArmyScale)) || (node.A.WaterArmyScale >= node.A.NormalArmyScale));

                case LinkKind.Both:
                    return ((!node.A.IsImportant && (node.A.ArmyScale >= node.A.FewArmyScale)) || (node.A.ArmyScale >= node.A.NormalArmyScale));
            }
            return false;
        }

        public bool IsOffensiveMilitary(Military m)
        {
            return ((((m.Scales >= 3) && (m.Morale >= 80)) && (m.Combativity >= 80)) && (m.InjuryQuantity <= m.Kind.MinScale));
        }

        public bool IsOK()
        {
            return (((((this.Agriculture >= (this.AgricultureCeiling * 0.45)) && (this.Commerce >= (this.CommerceCeiling * 0.45))) && ((this.Technology >= (this.TechnologyCeiling * 0.45)) && (this.Domination >= (this.DominationCeiling * 0.7)))) && (this.Morale >= (this.MoraleCeiling * 0.45))) && (this.Endurance >= (this.EnduranceCeiling * 0.4)));
        }

        public bool IsRoutewayPossible(Point p)
        {
            if (base.Scenario.GetArchitectureByPosition(p) != null)
            {
                return false;
            }
            TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(p);
            return ((terrainDetailByPosition != null) && ((this.BelongedFaction == null) || ((this.BelongedFaction.RoutewayWorkForce >= terrainDetailByPosition.RoutewayBuildWorkCost) && (terrainDetailByPosition.RoutewayConsumptionRate < 1f))));
        }

        internal bool IsSelfFoodEnough(LinkNode node, Routeway routeway)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfLandMilitaries * ((routeway.Length + 6) - (this.LandArmyScale / 8))));

                case LinkKind.Water:
                    return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfWaterMilitaries * ((routeway.Length + 6) - (this.WaterArmyScale / 8))));

                case LinkKind.Both:
                    return (((this.Food * (1f - routeway.LastPoint.ConsumptionRate)) * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length))) >= (this.FoodCostPerDayOfAllMilitaries * ((routeway.Length + 6) - (this.ArmyScale / 8))));
            }
            return false;
        }

        internal bool IsSelfHelpArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return ((!this.IsImportant && (this.LandArmyScale >= this.FewArmyScale)) || (this.LandArmyScale >= this.NormalArmyScale));

                case LinkKind.Water:
                    return ((!this.IsImportant && (this.WaterArmyScale >= this.FewArmyScale)) || (this.WaterArmyScale >= this.NormalArmyScale));

                case LinkKind.Both:
                    return ((!this.IsImportant && (this.ArmyScale >= this.FewArmyScale)) || (this.ArmyScale >= this.NormalArmyScale));
            }
            return false;
        }

        internal bool IsSelfMoveArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.LandArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.LandArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.LandArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.LandArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.LandArmyScale > this.FewArmyScale)));

                case LinkKind.Water:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.WaterArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.WaterArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.WaterArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.WaterArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.WaterArmyScale > this.FewArmyScale)));

                case LinkKind.Both:
                    return (((((this.IsImportant && (this.HostileLine || this.FrontLine)) && (this.ArmyScale > this.LargeArmyScale)) || (((this.IsImportant && !this.FrontLine) && (this.ArmyScale > this.NormalArmyScale)) || ((!this.IsImportant && this.HostileLine) && (this.ArmyScale > this.LargeArmyScale)))) || ((!this.IsImportant && this.FrontLine) && (this.ArmyScale > this.NormalArmyScale))) || ((!this.IsImportant && !this.FrontLine) && (this.ArmyScale > this.FewArmyScale)));
            }
            return false;
        }

        internal bool IsSelfOffensiveArmyEnough(LinkNode node)
        {
            switch (node.Kind)
            {
                case LinkKind.None:
                    return false;

                case LinkKind.Land:
                    return (((this.LandArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.LandArmyScale > node.A.ArmyScale))) || (!node.A.IsImportant && ((this.LandArmyScale * 2) > (node.A.ArmyScale * 3))));

                case LinkKind.Water:
                    return (((this.WaterArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.WaterArmyScale > node.A.ArmyScale))) || (!node.A.IsImportant && ((this.WaterArmyScale * 2) > (node.A.ArmyScale * 3))));

                case LinkKind.Both:
                    return (((this.ArmyScale > this.LargeArmyScale) || (node.A.IsImportant && (this.ArmyScale > node.A.ArmyScale))) || ((!node.A.IsImportant && (this.ArmyScale > this.NormalArmyScale)) && ((this.ArmyScale * 2) > (node.A.ArmyScale * 3))));
            }
            return false;
        }

        public bool IsViewing(Point position)
        {
            return this.LongViewArea.HasPoint(position);
        }

        public bool IsWaterLink(Architecture a)
        {
            return (this.AIWaterLinks.GetGameObject(a.ID) != null);
        }

        public bool LevelUpAvail()
        {
            foreach (Military military in this.Militaries)
            {
                if (((military.InjuryQuantity == 0) && military.Kind.CanLevelUp) && (military.Experience >= military.Kind.LevelUpExperience))
                {
                    return true;
                }
            }
            return false;
        }

        public void LevelUpMilitary(Military m)
        {
            MilitaryKind militaryKind = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(m.Kind.LevelUpKindID);
            if (militaryKind != null)
            {
                int num = (m.Quantity * militaryKind.MinScale) / m.Kind.MinScale;
                int num2 = ((m.Experience - m.Kind.LevelUpExperience) * militaryKind.MinScale) / m.Kind.MinScale;
                this.IncreasePopulation(m.Quantity - num);
                m.Kind = militaryKind;
                m.Quantity = num;
                m.Experience = num2;
                m.Name = m.Kind.Name + "队";
            }
        }

        public void LoadAILandLinksFromString(ArchitectureList architectures, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.AILandLinks.Clear();
            foreach (string str in strArray)
            {
                Architecture gameObject = architectures.GetGameObject(int.Parse(str)) as Architecture;
                if (gameObject != null)
                {
                    this.AILandLinks.Add(gameObject);
                }
            }
        }

        public void LoadAIWaterLinksFromString(ArchitectureList architectures, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.AIWaterLinks.Clear();
            foreach (string str in strArray)
            {
                Architecture gameObject = architectures.GetGameObject(int.Parse(str)) as Architecture;
                if (gameObject != null)
                {
                    this.AIWaterLinks.Add(gameObject);
                }
            }
        }

        public void LoadCaptivesFromString(CaptiveList captives, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Captives.Clear();
            foreach (string str in strArray)
            {
                Captive gameObject = captives.GetGameObject(int.Parse(str)) as Captive;
                if (gameObject != null)
                {
                    this.AddCaptive(gameObject);
                }
            }
        }

        public void LoadFacilitiesFromString(FacilityList facilities, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Facilities.Clear();
            foreach (string str in strArray)
            {
                Facility gameObject = facilities.GetGameObject(int.Parse(str)) as Facility;
                if (gameObject != null)
                {
                    this.Facilities.AddFacility(gameObject);
                }
            }
        }

        internal void LoadFundPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.FundPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.FundPacks.Add(new FundPack(int.Parse(strArray[i]), int.Parse(strArray[i + 1])));
            }
        }

        public void LoadMilitariesFromString(MilitaryList militaries, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Militaries.Clear();
            foreach (string str in strArray)
            {
                Military gameObject = militaries.GetGameObject(int.Parse(str)) as Military;
                if (gameObject != null)
                {
                    this.AddMilitary(gameObject);
                }
            }
        }

        public void LoadMovingPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.MovingPersons.Clear();
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null)
                {
                    this.MovingPersons.Add(t);
                    t.TargetArchitecture = this;
                }
            }
        }

        public void LoadNoFactionMovingPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.NoFactionMovingPersons.Clear();
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null)
                {
                    this.NoFactionMovingPersons.Add(t);
                    t.TargetArchitecture = this;
                }
            }
        }

        public void LoadNoFactionPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.NoFactionPersons.Clear();
            foreach (string str in strArray)
            {
                Person person = persons[int.Parse(str)];
                if (person != null)
                {
                    this.AddNoFactionPerson(person);
                }
            }
        }

        public void LoadfeiziPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.feiziliebiao.Clear();
            foreach (string str in strArray)
            {
                Person person = persons[int.Parse(str)];
                if (person != null)
                {
                    this.feiziliebiao.Add(person);
                    person.LocationArchitecture = null;
                    person.suozaijianzhu = this;
                    //person.suoshurenwu = this.BelongedFaction.LeaderID;
                }
            }
        }

        public void LoadPersonsFromString(Dictionary<int, Person> persons, string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Persons.Clear();
            foreach (string str in strArray)
            {
                Person t = persons[int.Parse(str)];
                if (t != null)
                {
                    this.Persons.Add(t);
                    t.LocationArchitecture = this;
                }
            }
        }

        internal void LoadPopulationPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.PopulationPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                this.PopulationPacks.Add(new PopulationPack(int.Parse(strArray[i]), int.Parse(strArray[i + 1])));
            }
        }

        internal void LoadSpyPacksFromString(string dataString)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.SpyPacks.Clear();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                Person gameObject = base.Scenario.Persons.GetGameObject(int.Parse(strArray[i])) as Person;
                if (gameObject != null)
                {
                    this.SpyPacks.Add(new SpyPack(gameObject, int.Parse(strArray[i + 1])));
                }
            }
        }

        public bool MergeAvail()
        {
            for (int i = 0; i < this.Militaries.Count; i++)
            {
                Military military = this.Militaries[i] as Military;
                if ((military.Quantity != military.Kind.MaxScale) && (military.InjuryQuantity <= 0))
                {
                    foreach (Military military2 in this.Militaries)
                    {
                        if (((military != military2) && (military.Kind == military2.Kind)) && ((military2.Quantity < military2.Kind.MaxScale) && (military2.InjuryQuantity == 0)))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void MonthEvent()
        {
            this.DevelopMonth();
        }

        public bool MoraleAvail()
        {
            return (this.Kind.HasMorale && this.HasPerson());
        }

        public bool NewMilitaryAvail()
        {
            if (this.BelongedFaction != null)
            {
                if (!this.Kind.HasPopulation)
                {
                    return false;
                }
                foreach (MilitaryKind kind in this.BelongedFaction.AvailableMilitaryKinds.MilitaryKinds.Values)
                {
                    if (kind.CreateAvail(this))
                    {
                        return true;
                    }
                }
                foreach (MilitaryKind kind in this.PrivateMilitaryKinds.MilitaryKinds.Values)
                {
                    if (kind.CreateAvail(this))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool NewSectionAvail()
        {
            return (this.BelongedFaction.ArchitectureCount > 1);
        }

        private void OffensiveCampaign()
        {
            //No offensive campaign if
            //1. the section is not allowed to do so
            //2. no officer is in the city
            //3. information hasn't been cooled down and no target specified
            if (!this.BelongedSection.AIDetail.AllowOffensiveCampaign)
            {
                this.PlanArchitecture = null;
            }
            else if (!this.HasPerson())
            {
                this.PlanArchitecture = null;
            }
            else if ((this.PlanArchitecture != null) || (this.InformationCoolDown <= 0))
            {
                //do not give a target, and cancel any offensive, if
                //1. there is no military good enough for an offensive
                //2. there is only 1 offensive army which scale < 30
                //3. There is nowhere for military to appear near the city
                //Otherwise, go into next step if:
                //5% chance, or population < 10000, or domination reaches its ceiling, or endurance reaches 20% of its ceiling, 
                //   or target is already specified and not cancelled
                int num = this.OffensiveMilitaryCount();
                if (num <= 0)
                {
                    this.PlanArchitecture = null;
                }
                else if (!((num != 1) || this.HasEnoughForceOffensiveMilitary()))
                {
                    this.PlanArchitecture = null;
                }
                else if (this.GetAllAvailableArea(false).Count == 0)
                {
                    this.PlanArchitecture = null;
                }
                else if ((((this.PlanArchitecture != null) || (this.Population < (10000 * this.AreaCount))) || ((this.Domination >= this.DominationCeiling) || (this.Endurance >= (this.EnduranceCeiling * 0.2f)))) || GameObject.Chance(5))
                {
                    //cancel any offensive if
                    //1. population >= 1000 (ignored if arch type has no population), and
                    //2. this arch is not good, and "good" means internal values reached 60% of their ceilings (80% of domination), and
                    //3. armyscale too little or army quantity less than half of the population (ignored if arch type has no population), and
                    //4. armyscale is not many or domination < 80% or endurance < 20%
                    if ((((!this.Kind.HasPopulation || (this.Population >= (1000 * this.AreaCount))) && !this.IsGood()) && ((!this.Kind.HasPopulation || (this.ArmyScale <= this.FewArmyScale)) || (this.ArmyQuantity <= (this.Population / 2)))) && (((this.ArmyScale < this.NormalArmyScale) || (this.Domination < (this.DominationCeiling * 0.8))) || (this.Endurance < (0.2f * this.EnduranceCeiling))))
                    {
                        this.PlanArchitecture = null;
                    }
                    else
                    {
                        LinkNode node = null;
                        int num2 = 0;
                        //if there is no target, pick one.
                        if (this.PlanArchitecture != null)
                        {
                            this.AIAllLinkNodes.TryGetValue(this.PlanArchitecture.ID, out node);
                        }
                        else
                        {
                            int num4;
                            double distance;
                            List<LinkNode> list = new List<LinkNode>();
                            List<LinkNode> list2 = new List<LinkNode>();
                            List<LinkNode> list3 = new List<LinkNode>();
                            int level = 1;
                            bool flag = this.LandArmyScale < this.VeryFewArmyScale;
                            bool flag2 = this.WaterArmyScale < this.VeryFewArmyScale;
                            //consider which target to attack
                            foreach (LinkNode node2 in this.AIAllLinkNodes.Values)
                            {
                                //stop the consideration entirely if a node has level > 2 i.e. the shortest distance from this arch to node2 arch > 2
                                Legion legion;
                                if (node2.Level > 2)
                                {
                                    break;
                                }
                                //stop the consideration entirely if a node has level > 1 unless there is another factioned base which satisfies the following code conditions
                                if (node2.Level > level)
                                {
                                    if (list3.Count > 0)
                                    {
                                        break;
                                    }
                                    level = node2.Level;
                                }
                                //don't attack any base that is friendly, or don't have enough troop on land/water to attack the base
                                if ((this.IsFriendly(node2.A.BelongedFaction) || (node2.Kind == LinkKind.None)) || (((node2.Kind == LinkKind.Land) && flag) || ((node2.Kind == LinkKind.Water) && flag2)))
                                {
                                    continue;
                                }
                                //don't attack any base that violates leader's stretagy tendency (possible culprit)
                                //111113 - added condition by troop scale that violates leader's tendency
                                switch (this.BelongedFaction.Leader.StrategyTendency)
                                {
                                    case PersonStrategyTendency.统一地区:
                                        {
                                            if (node2.A.LocationState.LinkedRegion == this.LocationState.LinkedRegion || this.ArmyScale > 1.5 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                    case PersonStrategyTendency.统一州:
                                        {
                                            if (node2.A.LocationState == this.LocationState || this.ArmyScale > 1.75 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                    case PersonStrategyTendency.维持现状:
                                        {
                                            if (node2.A.BelongedFaction == null || this.ArmyScale > 2.0 * node2.A.ArmyScale || GameObject.Chance(5))
                                            {
                                                break;
                                            }
                                            continue;
                                        }
                                }
                                //consider empty base if there is no legion (group a troops launching an attack) or the legion has less than 6 troops, and
                                //10% of chance or base is important or its population > 10000
                                if (node2.A.BelongedFaction == null)
                                {
                                    legion = this.BelongedFaction.GetLegion(node2.A);
                                    if (((legion == null) || (legion.Troops.Count < 6)) && ((GameObject.Chance(10) || node2.A.IsImportant) || (node2.A.Kind.HasPopulation && (node2.A.Population > (0x2710 * node2.A.AreaCount)))))
                                    {
                                        list.Add(node2);
                                    }
                                }
                                else
                                {
                                    list3.Add(node2);
                                    switch (this.BelongedSection.AIDetail.OrientationKind)
                                    {
                                        //otherwise, if no section command ordered, if
                                        //1. population >= 1000, and
                                        //2. not having many army, and 
                                        //3. having little army or army quantity < 0.8 * population, and
                                        //4. base is not completely developed or has not more than enough troop
                                        //add in base which (diplomatic relation + more arch than us) < 0, and more negative, greater chance
                                        //otherwise, if no legion is going on or that legion has troops count < 30, add into list
                                        case SectionOrientationKind.无:
                                            if (!this.BelongedSection.AIDetail.ValueOffensiveCampaign || ((((!this.Kind.HasPopulation || (this.Population >= (1000 * this.AreaCount))) && (this.ArmyScale < this.LargeArmyScale)) && ((!this.Kind.HasPopulation || (this.ArmyScale < this.FewArmyScale)) || (this.ArmyQuantity <= (this.Population * 0.8f)))) && (!this.IsFull() || (this.ArmyScale < this.NormalArmyScale))))
                                            {
                                                //goto Label_05AB;
                                                if (this.BelongedSection.AIDetail.ValueOffensiveCampaign || GameObject.Chance(20))
                                                {
                                                    num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize);
                                                    if ((num4 < 0) && GameObject.Chance(Math.Abs((int)(num4 / 10))))
                                                    {
                                                        list2.Add(node2);
                                                    }
                                                }
                                                break;
                                            }
                                            legion = this.BelongedFaction.GetLegion(node2.A);
                                            if ((legion == null) || (legion.Troops.Count < 30))
                                            {
                                                list2.Add(node2);
                                            }
                                            //
                                            continue;

                                        case SectionOrientationKind.军区:
                                            continue;

                                        case SectionOrientationKind.势力:
                                            if (this.BelongedSection.OrientationFaction == node2.A.BelongedFaction)
                                            {
                                                list2.Add(node2);
                                            }
                                            continue;

                                        case SectionOrientationKind.州域:
                                            if (this.BelongedSection.OrientationState == node2.A.LocationState)
                                            {
                                                list2.Add(node2);
                                            }
                                            continue;
                                    }// end switch
                                }// end else
                                //continue;
                                /*
                            Label_05AB:
                                if (this.BelongedSection.AIDetail.ValueOffensiveCampaign || GameObject.Chance(20))
                                {
                                    num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize);
                                    if ((num4 < 0) && GameObject.Chance(Math.Abs((int) (num4 / 10))))
                                    {
                                        list2.Add(node2);
                                    }
                                }
                                 */
                                //Label_0650:;
                            }
                            double maxValue = double.MaxValue;
                            LinkNode node3 = null;
                            //after first consideration, decide last target by determining base distances, and choose the minimum one
                            //this list is for empty bases
                            if (list.Count > 0)
                            {
                                foreach (LinkNode node2 in list)
                                {
                                    //1/(2*number of bases in consideration) chance to throw that node away
                                    /*if (GameObject.Random(list.Count * 2) == 0)
                                    {
                                        continue;
                                    }*/
                                    distance = node2.Distance;
                                    if (node2.A.LocationState.LinkedRegion.ID != this.LocationState.LinkedRegion.ID)
                                    {
                                        if (this.BelongedFaction.Leader.StrategyTendency != PersonStrategyTendency.统一全国)
                                        {
                                            continue;
                                        }
                                        distance *= 2.0;
                                    }
                                    else if (node2.A.LocationState.ID != this.LocationState.ID)
                                    {
                                        if (this.BelongedFaction.Leader.StrategyTendency == PersonStrategyTendency.统一地区)
                                        {
                                            distance *= 2.0;
                                        }
                                        else if (this.BelongedFaction.Leader.StrategyTendency != PersonStrategyTendency.统一全国)
                                        {
                                            continue;
                                        }
                                    }
                                    if (node2.A.IsImportant)
                                    {
                                        distance /= 2.0;
                                    }
                                    //add variation to AI attack (and less prone to cases where the selected base is prevented from attacking
                                    //because of conditions below
                                    distance *= 1 + (GameObject.Random(100) / 100.0 * 0.4 + 0.8);
                                    if (distance < maxValue)
                                    {
                                        maxValue = distance;
                                        node3 = node2;
                                    }
                                }
                            }
                            double num7 = double.MaxValue;
                            LinkNode node4 = null;
                            //this list is for occupied bases
                            if (list2.Count > 0)
                            {
                                foreach (LinkNode node2 in list2)
                                {
                                    //1/(2*number of bases in consideration) chance to throw that node away
                                    //if there has hostile arch on path, throw that node away
                                    if (/*(GameObject.Random(list2.Count * 2) != 0) && */!this.HasHostileArchitectureOnPath(node2))
                                    {
                                        distance = node2.Distance;
                                        num4 = 0;
                                        if (node2.A.BelongedFaction != null)
                                        {
                                            num4 = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, node2.A.BelongedFaction.ID) + (node2.A.BelongedFaction.ArchitectureTotalSize - this.BelongedFaction.ArchitectureTotalSize);
                                        }
                                        if (num4 < 0)
                                        {
                                            distance /= (double)((((float)Math.Abs(num4)) / 200f) + 1f);
                                        }
                                        if (node2.A.IsImportant)
                                        {
                                            distance /= 2.0;
                                        }
                                        //make AI more aggressive against player
                                        if (base.Scenario.IsPlayer(node2.A.BelongedFaction))
                                        {
                                            distance /= 2.0;
                                        }
                                        distance *= 1 + (GameObject.Random(100) / 100.0 * 0.4 + 0.8);
                                        if (distance < num7)
                                        {
                                            num7 = distance;
                                            node4 = node2;
                                        }
                                    }
                                }
                            }
                            //finally, choose the best target from both lists
                            if (maxValue <= num7)
                            {
                                node = node3;
                            }
                            else
                            {
                                node = node4;
                            }
                        }
                        //if a target is found, consider starting an offensive
                        if (node != null)
                        {
                            Architecture closer = null;
                            //if there is closer arch, really start an offensive to this arch
                            if (this.HasCloserOffensiveArchitecture(node, out closer))
                            {
                                if ((((closer != null) && this.AIAllLinkNodes.ContainsKey(closer.ID)) && (closer.BelongedSection == this.BelongedSection)) && this.BelongedSection.AIDetail.ValueOffensiveCampaign)
                                {
                                    this.BuildOffensiveTroop(closer, this.AIAllLinkNodes[closer.ID].Kind, true);
                                }
                                this.PlanArchitecture = null;
                            }
                            else
                            {
                                //if
                                //1. the target is not known nor there is any spy in it, or
                                //2. rand(target domination)^2 < rand(target domination) (prob should be n(n+1)/2n^3, 1.8y to attack on average...), or
                                //3. has enough troop to mount the offensive 
                                //  "enough" == number of troop is great, or has more troop if base is important, has 1.5 times more troop is base is unimportant
                                //then go on with the offensive
                                bool flag3 = this.BelongedFaction.IsArchitectureKnown(node.A);
                                if (!(((!flag3 && !node.A.HasFactionSpy(this.BelongedFaction)) || (GameObject.Random(GameObject.Square(node.A.Domination)) < GameObject.Random(node.A.DominationCeiling))) || this.IsSelfOffensiveArmyEnough(node)))
                                {
                                    this.PlanArchitecture = null;
                                }
                                else
                                {
                                    int num8;
                                    if (node.A.BelongedFaction != null)
                                    {
                                        num2 = 30;
                                    }
                                    else
                                    {
                                        num8 = 0;
                                        foreach (LinkNode node2 in node.A.AIAllLinkNodes.Values)
                                        {
                                            if (node2.Level > 2)
                                            {
                                                break;
                                            }
                                            if (!this.IsFriendly(node2.A.BelongedFaction) && (node2.A.BelongedFaction != null))
                                            {
                                                num8++;
                                            }
                                        }
                                        num2 = 2 + num8;
                                        if (num2 > 6)
                                        {
                                            num2 = 6;
                                        }
                                    }
                                    if (this.TargetingTroopCount(node.A) >= num2)
                                    {
                                        this.PlanArchitecture = null;
                                    }
                                    else
                                    {
                                        Routeway routeway;
                                        float foodRateBySeason;
                                        //if nothing is known about the target and no planned attacks, and
                                        //there are enough food and fund, then get info for that target
                                        if (!flag3 && (this.PlanArchitecture == null))
                                        {
                                            if ((this.PlanArchitecture == null) && this.InformationAvail())
                                            {
                                                routeway = this.GetRouteway(node, true);
                                                if (((routeway != null) && !routeway.ByPassHostileArchitecture) && ((routeway.LastPoint.BuildFundCost * (4 + ((node.A.AreaCount >= 4) ? 2 : 0))) <= this.Fund))
                                                {
                                                    foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                                                    if (((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnough(node, routeway))
                                                    {
                                                        this.PlanArchitecture = node.A;
                                                        Person firstHalfPerson = this.GetFirstHalfPerson("InformationAbility");
                                                        if (firstHalfPerson != null)
                                                        {
                                                            firstHalfPerson.CurrentInformationKind = this.GetFirstHalfInformationKind();
                                                            if (firstHalfPerson.CurrentInformationKind != null)
                                                            {
                                                                firstHalfPerson.GoForInformation(base.Scenario.GetClosestPoint(node.A.ArchitectureArea, this.Position));
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.PlanArchitecture = null;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            //if routeway to the target does not exist or bypasses hostile archs, forget about the target
                                            //else if fund or food is not enough, start plan to attack the target
                                            //afterall, really start an offensive
                                            routeway = this.GetRouteway(node, true);
                                            if (routeway == null)
                                            {
                                                this.PlanArchitecture = null;
                                            }
                                            else if (routeway.ByPassHostileArchitecture)
                                            {
                                                this.PlanArchitecture = null;
                                            }
                                            else if ((routeway.LastPoint.BuildFundCost * (4 + ((node.A.AreaCount >= 4) ? 2 : 0))) > this.Fund)
                                            {
                                                routeway.Building = false;
                                                this.PlanArchitecture = node.A;
                                            }
                                            else
                                            {
                                                foodRateBySeason = base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.GetSeason(routeway.Length));
                                                if (!(((this.Food * foodRateBySeason) >= (this.FoodCeiling / 3)) || this.IsSelfFoodEnough(node, routeway)))
                                                {
                                                    routeway.Building = false;
                                                    this.PlanArchitecture = node.A;
                                                }
                                                else if ((routeway.LastPoint.ConsumptionRate >= 0.1f) && (((int)(routeway.Length * (routeway.LastPoint.ConsumptionRate + 0.2f))) > routeway.LastActivePointIndex))
                                                {
                                                    routeway.Building = true;
                                                    this.PlanArchitecture = node.A;
                                                }
                                                else
                                                {
                                                    if (!routeway.IsActive)
                                                    {
                                                        routeway.Building = true;
                                                    }
                                                    num8 = 0;
                                                    while (num8 < num2)
                                                    {
                                                        if (this.BuildOffensiveTroop(node.A, node.Kind, true) == null)
                                                        {
                                                            break;
                                                        }
                                                        num8++;
                                                        if (!(this.HasOffensiveMilitary() && this.HasPerson()))
                                                        {
                                                            break;
                                                        }
                                                    }
                                                    this.PlanArchitecture = null;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public int OffensiveMilitaryCount()
        {
            int num = 0;
            foreach (Military military in this.Militaries)
            {
                if (this.IsOffensiveMilitary(military))
                {
                    num++;
                }
            }
            return num;
        }

        private void OutsideTacticsAI()
        {
            if (((this.PlanArchitecture == null) || GameObject.Chance(10)) && (((this.RecentlyAttacked <= 0) && this.HasPerson()) && this.IsFundEnough))
            {
                Architecture architecture2;
                int diplomaticRelation;
                Person firstHalfPerson;
                ArchitectureList list = new ArchitectureList();
                ArchitectureList list2 = new ArchitectureList();
                foreach (Architecture architecture in this.GetClosestArchitectures(20))
                {
                    if (!this.BelongedFaction.IsArchitectureKnown(architecture))
                    {
                        list.Add(architecture);
                    }
                    else
                    {
                        list2.Add(architecture);
                    }
                }
                if ((list.Count > 0) && this.BelongedSection.AIDetail.AllowInvestigateTactics)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Population";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    if ((((this.RecentlyAttacked <= 0) && (GameObject.Random(40) < GameObject.Random(list.Count))) && GameObject.Chance(20)) && this.InformationAvail())
                    {
                        architecture2 = list[GameObject.Random(list.Count / 2)] as Architecture;
                        if ((!this.BelongedFaction.IsArchitectureKnown(architecture2) || GameObject.Chance(20)) && ((architecture2.BelongedFaction != null) && (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10))))
                        {
                            diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                            if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                            {
                                firstHalfPerson = this.GetFirstHalfPerson("InformationAbility");
                                if ((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100))
                                {
                                    firstHalfPerson.CurrentInformationKind = this.GetFirstHalfInformationKind();
                                    if (firstHalfPerson.CurrentInformationKind != null)
                                    {
                                        firstHalfPerson.GoForInformation(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                    }
                                }
                            }
                        }
                    }
                    if (((this.PlanArchitecture == null) && (GameObject.Random(40) < GameObject.Random(list.Count))) && (this.HasPerson() && (GameObject.Random(this.Fund) >= this.SpyArchitectureFund)))
                    {
                        architecture2 = list[GameObject.Random(list.Count / 2)] as Architecture;
                        if ((!architecture2.HasFactionSpy(this.BelongedFaction) || GameObject.Chance(20)) && (((architecture2.BelongedFaction != null) && (GameObject.Random(architecture2.AreaCount + 4) >= 4)) && (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10))))
                        {
                            diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                            if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                            {
                                firstHalfPerson = this.GetFirstHalfPerson("SpyAbility");
                                if (((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100)) && (GameObject.Random(firstHalfPerson.SpyAbility) >= 200))
                                {
                                    firstHalfPerson.GoForSpy(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                }
                            }
                        }
                    }
                }
                if (((list2.Count > 0) && (this.PlanArchitecture == null)) && this.BelongedSection.AIDetail.AllowPersonTactics)
                {
                    if (list2.Count > 1)
                    {
                        list2.PropertyName = "PersonCount";
                        list2.IsNumber = true;
                        list2.ReSort();
                    }
                    if ((this.HasPerson() && (GameObject.Random(this.Fund) >= this.GossipArchitectureFund)) && GameObject.Chance(50))
                    {
                        ArchitectureList list3 = new ArchitectureList();
                        foreach (Architecture architecture in list2)
                        {
                            if ((architecture.BelongedFaction != this.BelongedFaction) && (architecture.BelongedFaction != null))
                            {
                                list3.Add(architecture);
                            }
                        }
                        if (list3.Count > 0)
                        {
                            architecture2 = list3[GameObject.Random(list3.Count / 2)] as Architecture;
                            if ((!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(10)) && ((architecture2.Fund < architecture2.EnoughFund) || ((architecture2.Fund < architecture2.AbundantFund) && GameObject.Chance(20))))
                            {
                                diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                                if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 200) <= GameObject.Random(50))) || ((diplomaticRelation < 0) && (GameObject.Random(Math.Abs(diplomaticRelation) + 100) >= GameObject.Random(100))))
                                {
                                    firstHalfPerson = this.GetFirstHalfPerson("GossipAbility");
                                    if (((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(10))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100)) && ((GameObject.Random(architecture2.GetGossipablePersonCount() + 4) >= 4) && (GameObject.Random(firstHalfPerson.GossipAbility) >= 200)))
                                    {
                                        firstHalfPerson.GoForGossip(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                    }
                                }
                            }
                        }
                    }
                    if ((this.HasPerson() && (GameObject.Random(this.Fund) >= this.ConvincePersonFund)) && GameObject.Chance(50))
                    {
                        ArchitectureList list4 = new ArchitectureList();
                        foreach (Architecture architecture in list2)
                        {
                            if (((architecture.BelongedFaction != this.BelongedFaction) && (architecture.BelongedFaction != null)) && architecture.HasPerson())
                            {
                                list4.Add(architecture);
                            }
                        }
                        foreach (Architecture architecture in this.BelongedFaction.Architectures)
                        {
                            if (architecture.HasCaptive())
                            {
                                list4.Add(architecture);
                            }
                        }
                        if (list4.Count > 0)
                        {
                            architecture2 = list4[GameObject.Random(list4.Count)] as Architecture;
                            if (architecture2.BelongedFaction == this.BelongedFaction)
                            {
                                Captive extremeLoyaltyCaptive = architecture2.GetExtremeLoyaltyCaptive(true);
                                if ((((extremeLoyaltyCaptive != null) && (extremeLoyaltyCaptive.CaptivePerson != null)) && ((extremeLoyaltyCaptive.Loyalty < 100) && (extremeLoyaltyCaptive.CaptiveFaction != null))) && (extremeLoyaltyCaptive.CaptivePerson != extremeLoyaltyCaptive.CaptiveFaction.Leader))
                                {
                                    firstHalfPerson = this.GetFirstHalfPerson("ConvinceAbility");
                                    if (((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(0x21))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && (GameObject.Random(firstHalfPerson.FightingNumber) < 100)) && ((GameObject.Random(firstHalfPerson.ConvinceAbility) >= 200) && (GameObject.Random(firstHalfPerson.ConvinceAbility) > GameObject.Random(extremeLoyaltyCaptive.Loyalty * 5))))
                                    {
                                        firstHalfPerson.OutsideDestination = new Point?(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                        firstHalfPerson.GoForConvince(extremeLoyaltyCaptive.CaptivePerson);
                                    }
                                }
                            }
                            else if (!this.IsFriendly(architecture2.BelongedFaction) || GameObject.Chance(50))
                            {
                                diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID);
                                if (((diplomaticRelation >= 0) && (GameObject.Random(diplomaticRelation + 50) <= GameObject.Random(50))) || (diplomaticRelation < 0))
                                {
                                    Person extremeLoyaltyPerson = architecture2.GetExtremeLoyaltyPerson(true);
                                    if (((extremeLoyaltyPerson.Loyalty < 100) && (extremeLoyaltyPerson.BelongedFaction != null)) && (extremeLoyaltyPerson != extremeLoyaltyPerson.BelongedFaction.Leader))
                                    {
                                        firstHalfPerson = this.GetFirstHalfPerson("ConvinceAbility");
                                        if ((((firstHalfPerson != null) && (!this.HasFollowedLeaderMilitary(firstHalfPerson) || GameObject.Chance(20))) && (GameObject.Random(firstHalfPerson.NonFightingNumber) > GameObject.Random(firstHalfPerson.FightingNumber))) && ((GameObject.Random(firstHalfPerson.ConvinceAbility) >= 200) && (GameObject.Random(firstHalfPerson.ConvinceAbility) > GameObject.Random(extremeLoyaltyPerson.Loyalty * 5))))
                                        {
                                            firstHalfPerson.OutsideDestination = new Point?(base.Scenario.GetClosestPoint(architecture2.ArchitectureArea, this.Position));
                                            firstHalfPerson.GoForConvince(extremeLoyaltyPerson);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public bool PersonConveneAvail()
        {
            int num = 0;
            if (this.BelongedFaction != null)
            {
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        num += architecture.Persons.Count;
                    }
                }
            }
            return (num > 0);
        }

        public bool PersonHireAvail()
        {
            return ((!this.HireFinished && (this.NoFactionPersonCount > 0)) && (this.Fund >= this.HirePersonFund));
        }

        public bool PersonStudySkillAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableSkill)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonStudyStuntAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableStunt)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonStudyTitleAvail()
        {
            foreach (Person person in this.Persons)
            {
                if (person.HasLearnableTitle)
                {
                    return true;
                }
            }
            return false;
        }

        public bool PersonTransferAvail()
        {
            return ((this.BelongedFaction != null) && ((this.Persons.Count > 0) && (this.BelongedFaction.ArchitectureCount > 1)));
        }

        public void PlayerAIHire()
        {
            this.AIAutoHire();
        }

        public void PlayerAIReward()
        {
            this.AIAutoReward();
        }

        public void PlayerAISearch()
        {
            this.AIAutoSearch();
        }

        public void PlayerAIWork()
        {
            if (this.HasPerson())
            {
                int num;
                this.StopAllWork();
                this.ReSortAllWeighingList();
                bool isFundAbundant = this.IsFundAbundant;
                if (this.Fund < ((100 * this.AreaCount) + ((30 - base.Scenario.Date.Day) * this.FacilityMaintenanceCost)))
                {
                    MilitaryList trainingMilitaryList = this.GetTrainingMilitaryList();
                    if (trainingMilitaryList.Count > 0)
                    {
                        trainingMilitaryList.IsNumber = true;
                        trainingMilitaryList.PropertyName = "Weighing";
                        trainingMilitaryList.ReSort();
                        GameObjectList maxObjects = this.trainingPersons.GetMaxObjects(trainingMilitaryList.Count);
                        for (num = 0; num < maxObjects.Count; num++)
                        {
                            this.AddPersonToTrainingWork(maxObjects[num] as Person, trainingMilitaryList[num] as Military);
                        }
                    }
                    int num2 = 0;
                    if (this.Kind.HasDomination && (this.Domination < (this.DominationCeiling * 0.8)))
                    {
                        num2++;
                    }
                    if (this.Kind.HasEndurance && (this.Endurance < (this.EnduranceCeiling * 0.2f)))
                    {
                        num2++;
                    }
                    if (this.Kind.HasMorale && (this.Morale < Parameters.RecruitmentMorale))
                    {
                        num2++;
                    }
                    if (num2 > 0)
                    {
                        for (num = 0; num < (this.Persons.Count - trainingMilitaryList.Count); num += num2)
                        {
                            foreach (Person person in this.dominationPersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToDominationWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.endurancePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToEnduranceWorkingList(person);
                                    break;
                                }
                            }
                            foreach (Person person in this.moralePersons)
                            {
                                if (person.WorkKind == ArchitectureWorkKind.无)
                                {
                                    this.AddPersonToMoraleWorkingList(person);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if ((GameObject.Chance(20) || !this.HasBuildingRouteway) || this.IsFundEnough)
                {
                    float num3;
                    bool flag2 = this.HasHostileTroopsInView();
                    WorkRateList list3 = new WorkRateList();
                    if (flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this))
                    {
                        if (!flag2 || !GameObject.Chance(80))
                        {
                            if (this.Kind.HasAgriculture && (this.Agriculture < this.AgricultureCeiling))
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Agriculture) / ((float)this.AgricultureCeiling), ArchitectureWorkKind.农业));
                            }
                            if (this.Kind.HasCommerce && (this.Commerce < this.CommerceCeiling))
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Commerce) / ((float)this.CommerceCeiling), ArchitectureWorkKind.商业));
                            }
                            if (this.Kind.HasTechnology && (this.Technology < this.TechnologyCeiling))
                            {
                                list3.AddWorkRate(new WorkRate(((float)this.Technology) / ((float)this.TechnologyCeiling), ArchitectureWorkKind.技术));
                            }
                        }
                        if (this.Kind.HasDomination && (this.Domination < this.DominationCeiling))
                        {
                            list3.AddWorkRate(new WorkRate((((float)this.Domination) / 5f) / ((float)this.DominationCeiling), ArchitectureWorkKind.统治));
                        }
                        if (this.Kind.HasMorale && (this.Morale < this.MoraleCeiling))
                        {
                            list3.AddWorkRate(new WorkRate(((float)this.Morale) / ((float)this.MoraleCeiling), ArchitectureWorkKind.民心));
                        }
                        if (this.Kind.HasEndurance && (this.Endurance < this.EnduranceCeiling))
                        {
                            list3.AddWorkRate(new WorkRate(((float)this.Endurance) / ((float)this.EnduranceCeiling), ArchitectureWorkKind.耐久));
                        }
                    }
                    MilitaryList list4 = this.GetTrainingMilitaryList();
                    if (list4.Count > 0)
                    {
                        if (flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.训练));
                        }
                        else
                        {
                            num3 = 0f;
                            foreach (Military military in list4)
                            {
                                num3 += ((float)military.TrainingWeighing) / ((float)military.MaxTrainingWeighing);
                            }
                            num3 /= (float)list4.Count;
                            list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.训练));
                        }
                    }
                    MilitaryList recruitmentMilitaryList = null;
                    if (((flag2 || (this.BelongedFaction.PlanTechniqueArchitecture != this)) && (this.Kind.HasPopulation && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population)))) && this.RecruitmentAvail())
                    {
                        recruitmentMilitaryList = this.GetRecruitmentMilitaryList();
                        if ((this.ArmyScale < this.FewArmyScale) && flag2)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if (((this.ArmyScale < this.FewArmyScale) && GameObject.Chance(5)) && this.IsFoodAbundant)
                        {
                            list3.AddWorkRate(new WorkRate(0f, ArchitectureWorkKind.补充));
                        }
                        else if ((((GameObject.Chance(1) && (this.ArmyScale >= this.LargeArmyScale)) && this.IsFoodAbundant) || ((((this.ArmyScale < this.LargeArmyScale) && this.IsFoodEnough) && (((this.IsImportant || (this.AreaCount > 2)) && (this.Population > this.Kind.PopulationBoundary)) || (((this.AreaCount <= 2) && !this.IsImportant) && (this.Population > (this.RecruitmentPopulationBoundary / 2))))) && GameObject.Chance(15))) && (GameObject.Random(Enum.GetNames(typeof(PersonStrategyTendency)).Length) >= (int)this.BelongedFaction.Leader.StrategyTendency))
                        {
                            num3 = 0f;
                            foreach (Military military in recruitmentMilitaryList)
                            {
                                num3 += ((float)military.RecruitmentWeighing) / ((float)military.MaxRecruitmentWeighing);
                            }
                            num3 /= (float)recruitmentMilitaryList.Count;
                            list3.AddWorkRate(new WorkRate(num3, ArchitectureWorkKind.补充));
                        }
                    }
                    if (list3.Count > 0)
                    {
                        for (num = 0; num < this.Persons.Count; num += list3.Count)
                        {
                            foreach (WorkRate rate in list3.RateList)
                            {
                                switch (rate.workKind)
                                {
                                    case ArchitectureWorkKind.农业:
                                        foreach (Person person in this.agriculturePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.AgricultureAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToAgricultureWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.商业:
                                        foreach (Person person in this.commercePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.CommerceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToCommerceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.技术:
                                        foreach (Person person in this.technologyPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.TechnologyAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToTechnologyWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.统治:
                                        foreach (Person person in this.dominationPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.DominationAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToDominationWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.民心:
                                        foreach (Person person in this.moralePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.MoraleAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToMoraleWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.耐久:
                                        foreach (Person person in this.endurancePersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.EnduranceAbility >= (120 + (this.AreaCount * 5)))))
                                            {
                                                this.AddPersonToEnduranceWorkingList(person);
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.训练:
                                        foreach (Person person in this.trainingPersons)
                                        {
                                            if (person.WorkKind == ArchitectureWorkKind.无)
                                            {
                                                foreach (Military military in list4.GetRandomList())
                                                {
                                                    if (military.RecruitmentPersonID < 0)
                                                    {
                                                        this.AddPersonToTrainingWork(person, military);
                                                        break;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;

                                    case ArchitectureWorkKind.补充:
                                        foreach (Person person in this.recruitmentPersons)
                                        {
                                            if ((person.WorkKind == ArchitectureWorkKind.无) && (isFundAbundant || (person.RecruitmentAbility >= 120)))
                                            {
                                                if (recruitmentMilitaryList != null)
                                                {
                                                    foreach (Military military in recruitmentMilitaryList.GetRandomList())
                                                    {
                                                        if (military.TrainingPersonID < 0)
                                                        {
                                                            this.AddPersonToRecuitmentWork(person, military);
                                                            break;
                                                        }
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void PlayerAutoAI()
        {
            if (this.AutoHiring)
            {
                this.PlayerAIHire();
            }
            if (this.AutoRewarding)
            {
                this.PlayerAIReward();
            }
            if (this.AutoWorking)
            {
                this.PlayerAIWork();
            }
            if (this.AutoSearching)
            {
                this.PlayerAISearch();
            }
        }

        private void PopulationEscapeEvent()
        {
            if ((((!this.DayAvoidPopulationEscape && this.Kind.HasPopulation) && ((this.Domination < this.DominationCeiling) && (this.RecentlyAttacked > 0))) && ((this.Population > (0x3e8 * this.AreaCount)) && (this.Morale < this.MoraleCeiling))) && (GameObject.Random(((int) Math.Pow((double) (this.Domination + this.Morale), 2.0)) + 0x3e8) < GameObject.Random(0x3e8)))
            {
                int num = 0;
                int maxValue = this.Population / 100;
                foreach (Architecture architecture in this.GetAILinks().GetRandomList())
                {
                    if (architecture.Kind.HasPopulation)
                    {
                        architecture.AddPopulationPack((int) (base.Scenario.GetDistance(this.ArchitectureArea, architecture.ArchitectureArea) / 2.0), 1 + GameObject.Random(maxValue));
                        num++;
                    }
                    if (num >= 100)
                    {
                        break;
                    }
                }
                if (num > 0)
                {
                    int decrement = maxValue * num;
                    this.DecreasePopulation(decrement);
                    if (this.OnPopulationEscape != null)
                    {
                        this.OnPopulationEscape(this, decrement);
                    }
                }
            }
        }

        public string PopulationInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0x186a0);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0xc350);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Population, 0x2710);

                case InformationLevel.全:
                    return this.Population.ToString();
            }
            return "----";
        }

        public void PopulationPacksDayEvent()
        {
            for (int i = this.PopulationPacks.Count - 1; i >= 0; i--)
            {
                PopulationPack local1 = this.PopulationPacks[i];
                local1.Days--;
                if (this.PopulationPacks[i].Days <= 0)
                {
                    this.ReceivePopulation(this.PopulationPacks[i].Population);
                    this.PopulationPacks.RemoveAt(i);
                }
            }
        }

        public void PostCreateTroop(Troop troop, bool hand)
        {
            if ((this.BelongedFaction != null) && this.HasSpy)
            {
                this.AddMessageToTodayNewTroopSpyMessage(troop, hand);
            }
        }

        private void PrepareAI()
        {
            this.TotalHostileForce = 0;
            this.TotalFriendlyForce = 0;
            TroopList hostileTroopsInView = this.GetHostileTroopsInView();
            foreach (Troop troop in hostileTroopsInView)
            {
                this.TotalHostileForce += troop.FightingForce;
            }
            TroopList friendlyTroopsInView = this.GetFriendlyTroopsInView();
            foreach (Troop troop in friendlyTroopsInView)
            {
                this.TotalFriendlyForce += troop.FightingForce;
            }
        }

        public void PurifyFacilityInfluences()
        {
            foreach (Facility facility in this.Facilities)
            {
                facility.Influences.PurifyInfluence(this);
            }
        }

        private void QuickSortArchitecturesDistance(ArchitectureList List, int begin, int end)
        {
            if (begin < end)
            {
                int num = this.QuickSortPartitionArchitecturesDistance(List, begin, end);
                if (begin < (num - 1))
                {
                    this.QuickSortArchitecturesDistance(List, begin, num - 1);
                }
                if ((num + 1) < end)
                {
                    this.QuickSortArchitecturesDistance(List, num + 1, end);
                }
            }
        }

        private int QuickSortPartitionArchitecturesDistance(ArchitectureList List, int begin, int end)
        {
            Architecture architecture = List[begin] as Architecture;
            int simpleDistance = base.Scenario.GetSimpleDistance(architecture.Position, this.Position);
            int num2 = begin;
            while (begin < end)
            {
                int num3 = base.Scenario.GetSimpleDistance((List[end] as Architecture).Position, this.Position);
                while ((begin < end) && (num3 >= simpleDistance))
                {
                    end--;
                    num3 = base.Scenario.GetSimpleDistance((List[end] as Architecture).Position, this.Position);
                }
                if (begin >= end)
                {
                    return begin;
                }
                this.QuickSortSwapArchitectureDistance(List, begin, end);
                begin++;
                for (num3 = base.Scenario.GetSimpleDistance((List[begin] as Architecture).Position, this.Position); (begin < end) && (num3 <= simpleDistance); num3 = base.Scenario.GetSimpleDistance((List[begin] as Architecture).Position, this.Position))
                {
                    begin++;
                }
                if (begin >= end)
                {
                    return begin;
                }
                this.QuickSortSwapArchitectureDistance(List, begin, end);
                end--;
            }
            return begin;
        }

        private void QuickSortSwapArchitectureDistance(ArchitectureList List, int i, int j)
        {
            GameObject obj2 = List[i];
            List[i] = List[j];
            List[j] = obj2;
        }

        public ArchitectureDamage ReceiveAttackDamage(ArchitectureDamage receivedDamage)
        {
            if (receivedDamage.Damage > 0)
            {
                int maxValue = 2 + (receivedDamage.Damage / 5);
                this.DecreaseAgriculture(GameObject.Random(maxValue));
                this.DecreaseCommerce(GameObject.Random(maxValue));
                this.DecreaseTechnology(GameObject.Random(maxValue));
                this.DecreaseMorale(GameObject.Random(maxValue));
            }
            return receivedDamage;
        }

        private void ReceivePopulation(int quantity)
        {
            int population = this.Population;
            quantity = this.IncreasePopulation(quantity);
            if (quantity > 0)
            {
                if (this.BelongedFaction != null)
                {
                    this.Domination = (this.Domination * population) / this.Population;
                    this.Morale = (this.Morale * population) / this.Population;
                }
                if (this.OnPopulationEnter != null)
                {
                    this.OnPopulationEnter(this, quantity);
                }
            }
        }

        public bool RecruitmentAvail()
        {
            if (this.HasPerson())
            {
                if (this.youzainan)
                {
                    return false;
                }
                if (!this.Kind.HasPopulation)
                {
                    return false;
                }
                if (GlobalVariables.PopulationRecruitmentLimit && (this.ArmyQuantity > this.Population))
                {
                    return false;
                }
                if (this.Population == 0)
                {
                    return false;
                }
                if (this.Domination < Parameters.RecruitmentDomination)
                {
                    return false;
                }
                if (this.Morale < Parameters.RecruitmentMorale)
                {
                    return false;
                }
                foreach (Military military in this.Militaries)
                {
                    if ((military.Quantity < military.Kind.MaxScale) && (military.InjuryQuantity == 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void RecruitmentMilitary(Military military)
        {
            if ((((this.Population != 0) && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population))) && ((this.Fund >= (Parameters.RecruitmentFundCost * this.AreaCount)) && (this.Domination >= Parameters.RecruitmentDomination))) && (((this.Morale >= Parameters.RecruitmentMorale) && ((military.RecruitmentPerson != null) && (military.RecruitmentPerson.BelongedFaction != null))) && (military.Quantity < military.Kind.MaxScale)))
            {
                int randomValue = StaticMethods.GetRandomValue((int) ((military.RecruitmentPerson.RecruitmentAbility * military.Kind.MinScale) * Parameters.RecruitmentRate), 0x7d0);
                if ((randomValue + military.Quantity) > military.Kind.MaxScale)
                {
                    randomValue = military.Kind.MaxScale - military.Quantity;
                }
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    randomValue = (int) (randomValue * Parameters.AIRecruitmentSpeedRate);
                }
                if ((randomValue * military.Kind.PointsPerSoldier) > military.BelongedFaction.TechniquePoint)
                {
                    if (!(((this.BelongedSection == null) || (this.BelongedSection.AIDetail == null)) || this.BelongedSection.AIDetail.AutoRun))
                    {
                        military.BelongedFaction.DepositTechniquePointForTechnique(randomValue * military.Kind.PointsPerSoldier);
                    }
                    randomValue = military.BelongedFaction.TechniquePoint / military.Kind.PointsPerSoldier;
                }
                if (randomValue > 0)
                {
                    this.DecreaseFund(Parameters.RecruitmentFundCost * this.AreaCount);
                    randomValue = this.DecreasePopulation(randomValue);
                    int scales = military.Scales;
                    military.IncreaseQuantity(randomValue, this.MoraleOfRecruitment, this.CombativityOfRecruitment, 0, 0);
                    if (this.HasSpy && ((military.Scales / 10) > (scales / 10)))
                    {
                        this.AddMessageToTodayMilitaryScaleSpyMessage(military);
                    }
                    if (this.Population < this.RecruitmentPopulationBoundary)
                    {
                        this.DecreaseDomination(GameObject.Random(6));
                        this.DecreaseMorale(GameObject.Random(6) * 2);
                    }
                    else
                    {
                        this.DecreaseDomination(GameObject.Random(2));
                        this.DecreaseMorale(GameObject.Random(2) * 2);
                    }
                    this.BelongedFaction.DecreaseTechniquePoint(randomValue * military.Kind.PointsPerSoldier);
                    int increment = StaticMethods.GetRandomValue(randomValue * 10, military.Kind.MinScale);
                    if (increment > 0)
                    {
                        military.RecruitmentPerson.AddRecruitmentExperience(increment);
                        military.RecruitmentPerson.AddCommandExperience(increment);
                        military.RecruitmentPerson.AddGlamourExperience(increment);
                        military.RecruitmentPerson.IncreaseReputation(increment * 4);
                        military.RecruitmentPerson.BelongedFaction.IncreaseReputation(increment * 2);
                        military.RecruitmentPerson.BelongedFaction.IncreaseTechniquePoint(increment * 100);
                    }
                }
            }
        }

        public void RecruitmentMilitary(Military military, float scale)
        {
            if ((((this.Population != 0) && (!GlobalVariables.PopulationRecruitmentLimit || (this.ArmyQuantity <= this.Population))) && ((this.Domination >= Parameters.RecruitmentDomination) && (this.Morale >= Parameters.RecruitmentMorale))) && (military.Quantity < military.Kind.MaxScale))
            {
                int decrement = (int) (military.Kind.MinScale * scale);
                if ((decrement + military.Quantity) > military.Kind.MaxScale)
                {
                    decrement = military.Kind.MaxScale - military.Quantity;
                }
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    decrement = (int) (decrement * Parameters.AIRecruitmentSpeedRate);
                }
                if ((decrement * military.Kind.PointsPerSoldier) > military.BelongedFaction.TechniquePoint)
                {
                    if (!(((this.BelongedSection == null) || (this.BelongedSection.AIDetail == null)) || this.BelongedSection.AIDetail.AutoRun))
                    {
                        military.BelongedFaction.DepositTechniquePointForTechnique(decrement * military.Kind.PointsPerSoldier);
                    }
                    decrement = military.BelongedFaction.TechniquePoint / military.Kind.PointsPerSoldier;
                }
                if (decrement > 0)
                {
                    decrement = this.DecreasePopulation(decrement);
                    int scales = military.Scales;
                    military.IncreaseQuantity(decrement, this.MoraleOfRecruitment, this.CombativityOfRecruitment, 0, 0);
                    if (this.HasSpy && ((military.Scales / 10) > (scales / 10)))
                    {
                        this.AddMessageToTodayMilitaryScaleSpyMessage(military);
                    }
                    if (this.Population < this.RecruitmentPopulationBoundary)
                    {
                        this.DecreaseDomination(GameObject.Random(6));
                        this.DecreaseMorale(GameObject.Random(6) * 2);
                    }
                    else
                    {
                        this.DecreaseDomination(GameObject.Random(2));
                        this.DecreaseMorale(GameObject.Random(2) * 2);
                    }
                    this.BelongedFaction.DecreaseTechniquePoint(decrement * military.Kind.PointsPerSoldier);
                    int randomValue = StaticMethods.GetRandomValue(decrement * 10, military.Kind.MinScale);
                    if (randomValue > 0)
                    {
                        military.BelongedFaction.IncreaseReputation(randomValue * 2);
                        military.BelongedFaction.IncreaseTechniquePoint(randomValue * 100);
                    }
                }
            }
        }

        public bool RedeemAvail()
        {
            if (this.FactionHasSelfCaptive())
            {
                foreach (Captive captive in this.BelongedFaction.SelfCaptives)
                {
                    if ((captive.RansomArriveDays == 0) && (captive.Ransom <= this.Fund))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void RefreshViewArea()
        {
            if (!base.Scenario.Preparing)
            {
                foreach (Point point in this.ViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        base.Scenario.MapTileData[point.X, point.Y].RemoveHighViewingArchitecture(this);
                    }
                }
                foreach (Point point in this.LongViewArea.Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point))
                    {
                        base.Scenario.MapTileData[point.X, point.Y].RemoveViewingArchitecture(this);
                    }
                }
            }
            this.ViewArea = null;
            this.LongViewArea = null;
            foreach (Point point in this.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddHighViewingArchitecture(this);
                }
            }
            foreach (Point point in this.LongViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].AddViewingArchitecture(this);
                }
            }
        }

        public bool RegionCoreEffectAvail()
        {
            return (this.Kind.HasTechnology && (this.Technology >= ((int) (this.TechnologyCeiling * 0.8))));
        }

        public bool RegroupSectionAvail()
        {
            return (this.BelongedFaction.SectionCount > 0);
        }

        private void ReleaseAllCaptive()
        {
            if (this.HasCaptive())
            {
                PersonList persons = new PersonList();
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (((captive.CaptivePerson != null) && (captive.CaptiveFaction != null)) && (captive.CaptiveFaction.Capital != null))
                    {
                        persons.Add(captive.CaptivePerson);
                        captive.CaptivePerson.MoveToArchitecture(captive.CaptiveFaction.Capital);
                        captive.CaptivePerson.BelongedCaptive = null;
                        this.RemoveCaptive(captive);
                        this.BelongedFaction.RemoveCaptive(captive);
                        captive.CaptiveFaction.RemoveSelfCaptive(captive);
                        base.Scenario.Captives.Remove(captive);
                    }
                }
                if ((persons.Count > 0) && (this.OnReleaseCaptiveAfterOccupied != null))
                {
                    this.OnReleaseCaptiveAfterOccupied(this, persons);
                }
            }
        }

        public bool ReleaseCaptiveAvail()
        {
            return (this.BelongedFaction.CaptiveCount > 0);
        }

        public void RemoveBaseSupplyingArchitecture()
        {
            foreach (Point point in this.BaseFoodSurplyArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.MapTileData[point.X, point.Y].RemoveSupplyingArchitecture(this);
                }
            }
        }

        public void RemoveCaptive(Captive captive)
        {
            this.Captives.Remove(captive);
            captive.LocationArchitecture = null;
        }

        public void RemoveInactiveRouteways()
        {
            foreach (Routeway routeway in this.Routeways.GetList())
            {
                if (!(routeway.Building || (routeway.LastActivePointIndex >= 0)))
                {
                    base.Scenario.RemoveRouteway(routeway);
                }
            }
        }

        public void RemoveMilitary(Military military)
        {
            this.Militaries.Remove(military);
            military.StopTraining();
            military.StopRecruitment();
            military.BelongedArchitecture = null;
        }

        public void RemoveNoFactionPerson(Person person)
        {
            this.NoFactionPersons.Remove(person);
            person.LocationArchitecture = null;
        }

        public void RemovePerson(Person person)
        {
            if (person.WorkKind != ArchitectureWorkKind.无)
            {
                this.RemovePersonFromWorkingList(person);
            }
            this.Persons.Remove(person);
            person.LocationArchitecture = null;
        }

        public void RemovePersonFromWorkingList(Person person)
        {
            person.OldWorkKind = person.WorkKind;
            switch (person.WorkKind)
            {
                case ArchitectureWorkKind.赈灾 :
                    this.zhenzaiWorkingPersons.Remove(person);
                    break;
                case ArchitectureWorkKind.农业:
                    this.AgricultureWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.商业:
                    this.CommerceWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.技术:
                    this.TechnologyWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.统治:
                    this.DominationWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.民心:
                    this.MoraleWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.耐久:
                    this.EnduranceWorkingPersons.Remove(person);
                    break;

                case ArchitectureWorkKind.训练:
                    person.StopTraining();
                    break;

                case ArchitectureWorkKind.补充:
                    person.StopRecruitment();
                    break;
            }
            person.WorkKind = ArchitectureWorkKind.无;
        }

        internal void RemovePopulationPack(PopulationPack pp)
        {
            this.PopulationPacks.Remove(pp);
        }

        internal void RemoveSpyPack(SpyPack sp)
        {
            this.SpyPacks.Remove(sp);
        }

        private void ResetAuto()
        {
            this.AutoHiring = false;
            this.AutoRewarding = false;
            this.AutoWorking = false;
            this.AutoSearching = false;
        }

        private void ResetDayInfluence()
        {
            this.DayRateIncrementOfInternal = 0f;
            this.DayLearnTitleDay = Parameters.LearnTitleDays;
            this.DayLocationLoyaltyNoChange = false;
            this.DayAvoidInfluenceByBattle = false;
            this.DayAvoidPopulationEscape = false;
            this.DayAvoidInternalDecrementOnBattle = false;
            if (this.RecentlyAttacked > 0)
            {
                this.RecentlyAttacked--;
            }
            if (this.RecentlyBreaked > 0)
            {
                this.RecentlyBreaked--;
            }
        }

        public bool ResetDiplomaticRelationAvail()
        {
            if (this.BelongedFaction == null)
            {
                return false;
            }
            return (this.HasFriendlyDiplomaticRelation && (this.BelongedFaction.TroopCount == 0));
        }

        public void ResetFaction(Faction faction)
        {
            this.ResetAuto();
            if ((faction != null) && base.Scenario.IsPlayer(faction))
            {
                this.AutoHiring = true;
                this.AutoRewarding = true;

            }
            if (this.BelongedFaction != null)
            {

                this.ClearFundPacks();
                this.ClearRouteways();
                this.ReleaseAllCaptive();
                this.BelongedSection.RemoveArchitecture(this);
                this.DefensiveLegion = null;
                if (this == this.BelongedFaction.Capital)
                {
                    Person leader = this.BelongedFaction.Leader;
                    foreach (Person person2 in this.Persons)
                    {
                        this.BelongedFaction.RemovePerson(person2);
                        this.AddNoFactionPerson(person2);
                    }
                    this.Persons.Clear();
                    foreach (Person person2 in this.MovingPersons)
                    {
                        person2.OutsideTask = OutsideTaskKind.无;
                        person2.TaskDays = 0;
                        if (person2.BelongedFaction != null)
                        {
                            person2.BelongedFaction.RemovePerson(person2);
                        }
                    }
                    this.MovingPersons.Clear();
                    if ((leader.LocationTroop == null) || leader.IsCaptive)
                    {
                        TroopList list = new TroopList();
                        foreach (Troop troop in this.BelongedFaction.Troops)
                        {
                            list.Add(troop);
                        }
                        foreach (Troop troop in list)
                        {
                            troop.FactionDestroy();
                        }
                        if (faction != null)
                        {
                            faction.CheckLeaderDeath(leader);
                        }
                        this.BelongedFaction.Destroy();

                    }
                    this.BelongedFaction.Capital = null;
                }
                else
                {
                    PersonList list2 = new PersonList();
                    foreach (Person person2 in this.Persons)
                    {
                        person2.MoveToArchitecture(this.BelongedFaction.Capital);
                        list2.Add(person2);
                    }
                    foreach (Person person2 in list2)
                    {
                        this.RemovePerson(person2);
                    }
                    foreach (Person person2 in this.MovingPersons)
                    {
                        person2.MoveToArchitecture(this.BelongedFaction.Capital);
                    }
                    this.MovingPersons.Clear();
                }
                if (this.BelongedFaction != null)
                {
                    this.BelongedFaction.RemoveArchitectureMilitaries(this);
                    this.BelongedFaction.RemoveArchitectureKnownData(this);
                    this.BelongedFaction.RemoveArchitecture(this);
                }
                if (faction != null)
                {
                    faction.AddArchitecture(this);
                    faction.AddArchitectureMilitaries(this);
                    faction.AddArchitecturePersons(this);
                }
                else
                {
                    this.BelongedFaction = null;
                }
            }
            else if (faction != null)
            {
                faction.AddArchitecture(this);
                faction.AddArchitectureMilitaries(this);
            }

            if (faction != null)
            {
                this.jianzhuqizi.qizidezi.Text = faction.ToString().Substring(0, 1);
            }

            foreach (Architecture architecture in base.Scenario.Architectures)
            {
                architecture.RefreshViewArea();
            }
            foreach (Troop troop in base.Scenario.Troops)
            {
                troop.RefreshViewArchitectureRelatedArea();
            }
        }

        private void ReSortAllWeighingList()
        {
            this.agriculturePersons.Clear();
            if (this.Kind.HasAgriculture)
            {
                foreach (Person person in this.Persons)
                {
                    this.agriculturePersons.Add(person);
                }
                this.agriculturePersons.IsNumber = true;
                this.agriculturePersons.PropertyName = "AgricultureWeighing";
                this.agriculturePersons.ReSort();
            }
            this.commercePersons.Clear();
            if (this.Kind.HasCommerce)
            {
                foreach (Person person in this.Persons)
                {
                    this.commercePersons.Add(person);
                }
                this.commercePersons.IsNumber = true;
                this.commercePersons.PropertyName = "CommerceWeighing";
                this.commercePersons.ReSort();
            }
            this.technologyPersons.Clear();
            if (this.Kind.HasTechnology)
            {
                foreach (Person person in this.Persons)
                {
                    this.technologyPersons.Add(person);
                }
                this.technologyPersons.IsNumber = true;
                this.technologyPersons.PropertyName = "TechnologyWeighing";
                this.technologyPersons.ReSort();
            }
            this.dominationPersons.Clear();
            if (this.Kind.HasDomination)
            {
                foreach (Person person in this.Persons)
                {
                    this.dominationPersons.Add(person);
                }
                this.dominationPersons.IsNumber = true;
                this.dominationPersons.PropertyName = "DominationWeighing";
                this.dominationPersons.ReSort();
            }
            this.moralePersons.Clear();
            if (this.Kind.HasMorale)
            {
                foreach (Person person in this.Persons)
                {
                    this.moralePersons.Add(person);
                }
                this.moralePersons.IsNumber = true;
                this.moralePersons.PropertyName = "MoraleWeighing";
                this.moralePersons.ReSort();
            }
            this.endurancePersons.Clear();
            if (this.Kind.HasEndurance)
            {
                foreach (Person person in this.Persons)
                {
                    this.endurancePersons.Add(person);
                }
                this.endurancePersons.IsNumber = true;
                this.endurancePersons.PropertyName = "EnduranceWeighing";
                this.endurancePersons.ReSort();
            }
            this.trainingPersons.Clear();
            foreach (Person person in this.Persons)
            {
                this.trainingPersons.Add(person);
            }
            this.trainingPersons.IsNumber = true;
            this.trainingPersons.PropertyName = "TrainingWeighing";
            this.trainingPersons.ReSort();
            this.recruitmentPersons.Clear();
            foreach (Person person in this.Persons)
            {
                this.recruitmentPersons.Add(person);
            }
            this.recruitmentPersons.IsNumber = true;
            this.recruitmentPersons.PropertyName = "RecruitmentWeighing";
            this.recruitmentPersons.ReSort();
            this.weighingMilitaries.Clear();
            foreach (Military military in this.Militaries)
            {
                this.weighingMilitaries.Add(military);
            }
            this.weighingMilitaries.IsNumber = true;
            this.weighingMilitaries.PropertyName = "Weighing";
            this.weighingMilitaries.ReSort();
        }

        public void RewardAll()
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (!architecture.HasPerson())
                {
                    continue;
                }
                int rewardPersonMaxCount = architecture.RewardPersonMaxCount;
                if (rewardPersonMaxCount > 0)
                {
                    GameObjectList list = architecture.Persons.GetList();
                    if (list.Count > 1)
                    {
                        list.PropertyName = "Loyalty";
                        list.SmallToBig = true;
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    int num2 = 0;
                    foreach (Person person in list)
                    {
                        if ((!person.RewardFinished && (person.Loyalty < 100)) && (person != person.BelongedFaction.Leader))
                        {
                            architecture.RewardPerson(person);
                            num2++;
                        }
                        if (num2 >= rewardPersonMaxCount)
                        {
                            break;
                        }
                    }
                }
            }
        }

        public bool RewardAllAvail()
        {
            foreach (Architecture architecture in this.BelongedFaction.Architectures)
            {
                if (architecture.RewardPersonAvail())
                {
                    return true;
                }
            }
            return false;
        }

        public void RewardByPersonList(GameObjectList personlist)
        {
            foreach (Person person in personlist)
            {
                this.RewardPerson(person);
            }
            if (this.OnRewardPersons != null)
            {
                this.OnRewardPersons(this, personlist);
            }
        }

        public bool RewardPerson(Person p)
        {
            if (this.Fund < this.RewardPersonFund)
            {
                return false;
            }
            p.RewardFinished = true;
            this.DecreaseFund(this.RewardPersonFund);
            int idealOffset = Person.GetIdealOffset(p, this.BelongedFaction.Leader);
            p.IncreaseLoyalty((15 - (idealOffset / 5)) +(int) p.PersonalLoyalty);
            return true;
        }

        public bool RewardPersonAvail()
        {
            return ((this.GetRewardPersons().Count > 0) && (this.Fund >= this.RewardPersonFund));
        }

        public void RewardPersonsUnderLoyalty(int loyalty)
        {
            foreach (Person person in this.Persons)
            {
                if (((!person.RewardFinished && (person.Loyalty < loyalty)) && (person != this.BelongedFaction.Leader)) && !this.RewardPerson(person))
                {
                    break;
                }
            }
        }

        public bool RoutewayAvail()
        {
            foreach (Point point in this.GetRoutewayStartArea().Area)
            {
                if (this.IsRoutewayPossible(point))
                {
                    return true;
                }
            }
            return false;
        }

        internal string SaveFundPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (FundPack pack in this.FundPacks)
            {
                builder.Append(string.Concat(new object[] { pack.Fund, " ", pack.Days, " " }));
            }
            return builder.ToString();
        }

        internal string SavePopulationPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (PopulationPack pack in this.PopulationPacks)
            {
                builder.Append(string.Concat(new object[] { pack.Days, " ", pack.Population, " " }));
            }
            return builder.ToString();
        }

        internal string SaveSpyPacksToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (SpyPack pack in this.SpyPacks)
            {
                builder.Append(string.Concat(new object[] { pack.SpyPerson.ID, " ", pack.Days, " " }));
            }
            return builder.ToString();
        }

        public bool SearchAvail()
        {
            return this.HasPerson();
        }

        public void SellFood(int spendFood)
        {
            this.DecreaseFood(spendFood);
            this.IncreaseFund(spendFood / Parameters.FoodToFundDivisor);
        }

        public bool SellFoodAvail()
        {
            return ((((this.Commerce >= Parameters.SellFoodCommerce) && ((base.Scenario.Date.Season == GameSeason.冬) || (base.Scenario.Date.Season == GameSeason.春))) && (this.Food > 0)) && (this.Fund < this.FundCeiling));
        }

        public void SetLongViewArea(GameArea area)
        {
            this.longViewArea = area;
        }

        public void SetRecentlyAttacked()
        {
            if (this.RecentlyAttacked <= 0)
            {
                this.JustAttacked = true;
                if (this.BelongedFaction != null)
                {
                    this.BelongedFaction.StopToControl = true;
                }
                if (this.OnBeginRecentlyAttacked != null)
                {
                    this.OnBeginRecentlyAttacked(this);
                }
            }
            this.RecentlyAttacked = 10;
        }

        public void SetViewArea(GameArea area)
        {
            this.viewArea = area;
        }

        private void Sourrounded()
        {
            if (((this.BelongedFaction != null) && (this.Endurance > 0)) && this.Kind.HasDomination)
            {
                int num = 0;
                foreach (Point point in this.ContactArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (!((troopByPosition == null) || this.IsFriendly(troopByPosition.BelongedFaction)))
                    {
                        num++;
                    }
                }
                if (num > this.AreaCount)
                {
                    int decrement = (num - this.AreaCount) * Parameters.SurroundArchitectureDominationUnit;
                    decrement = this.DecreaseDomination(decrement);
                    if (decrement > 0)
                    {
                        this.DecrementNumberList.AddNumber(decrement, CombatNumberKind.士气, this.Position);
                    }
                }
            }
        }

        public bool SpyAvail()
        {
            return ((this.HasPerson() && (this.Fund >= this.SpyArchitectureFund)) && (this.GetSpyArchitectureArea().Count > 0));
        }

        public void SpyPacksDayEvent()
        {
            this.TodayNewMilitarySpyMessage = null;
            this.TodayNewTroopSpyMessage = null;
            for (int i = this.SpyPacks.Count - 1; i >= 0; i--)
            {
                SpyPack local1 = this.SpyPacks[i];
                local1.Days--;
                if ((this.SpyPacks[i].Days <= 0) || ((this.SpyPacks[i].SpyPerson != null) && (this.SpyPacks[i].SpyPerson.BelongedFaction == this.BelongedFaction)))
                {
                    this.SpyPacks.RemoveAt(i);
                }
            }
        }

        public bool StateAdminEffectAvail()
        {
            return (this.Kind.HasTechnology && (this.Technology >= ((int) (this.TechnologyCeiling * 0.5))));
        }

        private void StopAllWork()
        {
            foreach (Person person in this.Persons)
            {
                if (person.WorkKind != ArchitectureWorkKind.无)
                {
                    this.RemovePersonFromWorkingList(person);
                }
            }
        }

        private void StopCostFundWork()
        {
            foreach (Person person in this.Persons)
            {
                if ((person.WorkKind != ArchitectureWorkKind.无) && (person.WorkKind != ArchitectureWorkKind.训练))
                {
                    this.RemovePersonFromWorkingList(person);
                }
            }
        }

        private void StrategicCenterEffect()
        {
            if ((this.BelongedFaction != null) && this.IsStrategicCenter)
            {
                foreach (Point point in this.LongViewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (troopByPosition != null)
                    {
                        if (this.IsFriendly(troopByPosition.BelongedFaction))
                        {
                            troopByPosition.IncreaseCombativity(5);
                        }
                        else
                        {
                            troopByPosition.DecreaseCombativity(10);
                        }
                    }
                }
                if (base.Scenario.Date.Day == 30)
                {
                    GameObjectList aILinks = this.GetAILinks();
                    aILinks.Add(this);
                    foreach (Architecture architecture in aILinks)
                    {
                        if (this.IsFriendly(architecture.BelongedFaction))
                        {
                            if (architecture.Kind.HasDomination)
                            {
                                int number = architecture.IncreaseDomination(20);
                                if (number > 0)
                                {
                                    architecture.IncrementNumberList.AddNumber(number, CombatNumberKind.士气, architecture.Position);
                                }
                            }
                        }
                        else if (this.IsHostile(architecture.BelongedFaction) && architecture.Kind.HasDomination)
                        {
                            int num2 = architecture.DecreaseDomination(10);
                            if (num2 > 0)
                            {
                                architecture.DecrementNumberList.AddNumber(num2, CombatNumberKind.士气, architecture.Position);
                            }
                        }
                    }
                }
            }
        }

        private int TargetingTroopCount(Architecture a)
        {
            int num = 0;
            foreach (Troop troop in this.BelongedFaction.Troops)
            {
                if (troop.WillArchitecture == a)
                {
                    num++;
                }
            }
            return num;
        }

        public bool TechnologyAvail()
        {
            return (this.Kind.HasTechnology && this.HasPerson());
        }

        public override string ToString()
        {
            return string.Concat(new object[] { base.Name, "  ", this.KindString, "  ", this.FactionString, "  ", this.Persons.Count, "人" });
        }

        public bool TrainingAvail()
        {
            if (this.HasPerson())
            {
                foreach (Military military in this.Militaries)
                {
                    if ((military.Quantity > 0) && ((military.Morale < military.MoraleCeiling) || (military.Combativity < military.CombativityCeiling)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void TrainMilitary(Military military)   //训练编队
        {
            if ((military.TrainingPerson != null) && (military.TrainingPerson.BelongedFaction != null))
            {
                if (military.Morale < military.MoraleCeiling)
                {
                    int randomValue = StaticMethods.GetRandomValue((int) ((military.TrainingPerson.TrainingAbility * this.MultipleOfTraining) * Parameters.TrainingRate), 200 + (10 * military.Scales));
                    if (randomValue > 0)
                    {
                        if (!base.Scenario.IsPlayer(this.BelongedFaction))
                        {
                            randomValue = (int) (randomValue * Parameters.AITrainingSpeedRate);
                        }
                        military.TrainingPerson.AddTrainingExperience(randomValue * 2);
                        military.TrainingPerson.AddCommandExperience(randomValue * 2);
                        military.TrainingPerson.IncreaseReputation(randomValue * 3);
                        military.TrainingPerson.BelongedFaction.IncreaseReputation(randomValue * 2);
                        military.TrainingPerson.BelongedFaction.IncreaseTechniquePoint(randomValue * 50);
                        military.IncreaseMorale(randomValue);
                    }
                }
                if (military.Combativity < military.CombativityCeiling)
                {
                    int increment = StaticMethods.GetRandomValue((int) ((military.TrainingPerson.TrainingAbility * this.MultipleOfTraining) * Parameters.TrainingRate), 50 + (5 * military.Scales));
                    if (increment > 0)
                    {
                        if (!base.Scenario.IsPlayer(this.BelongedFaction))
                        {
                            increment = (int) (increment * Parameters.AITrainingSpeedRate);
                        }
                        military.TrainingPerson.AddTrainingExperience(increment);
                        military.TrainingPerson.AddStrengthExperience(increment);
                        military.TrainingPerson.IncreaseReputation(increment);
                        military.TrainingPerson.BelongedFaction.IncreaseReputation(0);
                        military.TrainingPerson.BelongedFaction.IncreaseTechniquePoint(increment * 20);
                        military.IncreaseCombativity(increment);
                    }
                }

                /*
                if ((military.Morale >= military.MoraleCeiling) && (military.Combativity >= military.CombativityCeiling))
                {
                    this.RemovePersonFromWorkingList(military.TrainingPerson);
                    //military.TrainingPerson=null;
                }
                */



            }
        }

        public bool TransferFoodAvail()
        {
            if (this.Food > 0)
            {
                foreach (Routeway routeway in this.Routeways)
                {
                    float minRate = 1f;
                    if (((routeway.EndArchitecture != null) && routeway.IsActiveInArea(routeway.EndArchitecture.GetRoutewayStartArea(), out minRate)) && (minRate < 1f))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool TransferFundAvail()
        {
            return ((this.Fund > 0) && (this.GetOtherArchitectureList().Count > 0));
        }

        public bool TroopershipAvail()
        {
            if ((((base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x1c) != null) && (this.Persons.Count > 0)) && (this.Militaries.Count > 0)) && this.ValueWater)
            {
                foreach (Military military in this.Militaries)
                {
                    if ((((military.Quantity > 0) && (military.Morale > 0)) && (military.Kind.Type != MilitaryType.水军)) && (this.GetMilitaryCampaignArea(military).Count > 0))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void ViewAreaEvent()
        {
            this.DetectAmbushTroop();
            this.IncreaseViewAreaCombativity();
        }

        public bool ViewTroop(Troop troop)
        {
            return (this.LongViewArea.HasPoint(troop.Position) && (((this.BelongedFaction != null) && this.IsFriendly(troop.BelongedFaction)) || (troop.Status != TroopStatus.埋伏)));
        }

        public void WallStateChange()
        {
            foreach (Troop troop in base.Scenario.Troops)
            {
                if (!this.IsFriendly(troop.BelongedFaction))
                {
                    troop.RefreshViewArchitectureRelatedArea();
                }
            }
        }

        private void YearEnd()
        {
        }

        public void YearEvent()
        {
            this.YearEnd();
        }

        public int AbundantFood
        {
            get
            {
                int num = 0;
                foreach (Legion legion in this.BelongedFaction.Legions)
                {
                    if (legion.Kind == LegionKind.Defensive)
                    {
                        if (legion == this.DefensiveLegion)
                        {
                            num += legion.FoodCostPerDay * 80;
                        }
                    }
                    else if (((legion.Kind == LegionKind.Offensive) && (legion.PreferredRouteway != null)) && (legion.PreferredRouteway.StartArchitecture == this))
                    {
                        num += legion.FoodCostPerDay * 80;
                    }
                }
                int num2 = (((int) (Math.Sqrt((double) this.Population) * 400.0)) + (this.FoodCostPerDayOfAllMilitaries * 80)) + num;
                if (!this.HostileLine)
                {
                    num2 /= 2;
                }
                if (!this.FrontLine)
                {
                    num2 /= 2;
                }
                return num2;
            }
        }

        public int AbundantFund
        {
            get
            {
                return ((((((((this.AreaCount + this.PersonCount) + this.MilitaryCount) + ((this.TransferFoodArchitecture != null) ? 10 : 0)) + (this.IsCapital ? (4 * this.AreaCount) : 0)) + (this.IsImportant ? 6 : 0)) * 0x3e8) + (this.FacilityMaintenanceCost * 60)) + (this.RoutewayActiveCost * 60));
            }
        }

        public int Agriculture
        {
            get
            {
                return this.agriculture;
            }
            set
            {
                this.agriculture = value;
            }
        }

        public int AgricultureCeiling
        {
            get
            {
                return ((this.Kind.AgricultureBase + (this.Kind.AgricultureUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfAgricultureCeiling);
            }
        }

        public string AgricultureString
        {
            get
            {
                return (this.Agriculture + "/" + this.AgricultureCeiling);
            }
        }

        public string AILandLinksDisplayString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Architecture architecture in this.AILandLinks)
                {
                    builder.Append(architecture.Name + " ");
                }
                return builder.ToString();
            }
        }

        public string AIWaterLinksDisplayString
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (Architecture architecture in this.AIWaterLinks)
                {
                    builder.Append(architecture.Name + " ");
                }
                return builder.ToString();
            }
        }

        public int AreaCount
        {
            get
            {
                //return this.ArchitectureArea.Count;
                return 1;

            }
        }

        public int JianzhuGuimo
        {
            get
            {
                return this.ArchitectureArea.Count;
                

            }
        }


        public int ArmyQuantity
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    num += military.Quantity;
                }
                return num;
            }
        }

        public int ArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        num += military.Scales;
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        public int ArmyScaleWeighing
        {
            get
            {
                return ((this.ArmyScale + 10) * (((((((this.IsCapital ? 2 : 1) + (this.IsStateAdmin ? 1 : 0)) + (this.IsRegionCore ? 1 : 0)) + (this.IsStrategicCenter ? 1 : 0)) + (this.FrontLine ? 2 : 0)) + (this.HostileLine ? 2 : 0)) + (this.CriticalHostile ? 3 : 0)));
            }
        }

        public bool AutoHiring
        {
            get
            {
                return this.autoHiring;
            }
            set
            {
                this.autoHiring = value;
            }
        }

        public bool AutoRewarding
        {
            get
            {
                return this.autoRewarding;
            }
            set
            {
                this.autoRewarding = value;
            }
        }

        public bool AutoSearching
        {
            get
            {
                return this.autoSearching;
            }
            set
            {
                this.autoSearching = value;
            }
        }

        public bool AutoWorking
        {
            get
            {
                return this.autoWorking;
            }
            set
            {
                this.autoWorking = value;
            }
        }

        public GameArea BaseFoodSurplyArea
        {
            get
            {
                if (this.baseFoodSurplyArea == null)
                {
                    this.baseFoodSurplyArea = new GameArea();
                    foreach (Point point in this.ArchitectureArea.GetContactArea(true).Area)
                    {
                        this.baseFoodSurplyArea.AddPoint(point);
                    }
                    foreach (Point point in this.ArchitectureArea.Area)
                    {
                        this.baseFoodSurplyArea.AddPoint(point);
                    }
                    return this.baseFoodSurplyArea;
                }
                return this.baseFoodSurplyArea;
            }
        }

        public int BuildingDaysLeft
        {
            get
            {
                return this.buildingDaysLeft;
            }
            set
            {
                this.buildingDaysLeft = value;
            }
        }

        public int BuildingFacility
        {
            get
            {
                return this.buildingFacility;
            }
            set
            {
                this.buildingFacility = value;
            }
        }

        public int CaptiveCount
        {
            get
            {
                return this.Captives.Count;
            }
        }

        public int ChangeCapitalCost
        {
            get
            {
                return (Parameters.ChangeCapitalCost * this.AreaCount);
            }
        }

        public int ClearFieldAgricultureCost
        {
            get
            {
                if (this.Kind.HasAgriculture)
                {
                    return ((this.LongViewArea.Count - this.AreaCount) * Parameters.ClearFieldAgricultureCostUnit);
                }
                return 0;
            }
        }

        public int ClearFieldCredit
        {
            get
            {
                int num = 0;
                foreach (Point point in this.LongViewArea.Area)
                {
                    if ((base.Scenario.GetArchitectureByPosition(point) != null) || base.Scenario.NoFoodDictionary.HasPosition(point))
                    {
                        continue;
                    }
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition == null) || this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))
                    {
                        TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                        if ((terrainDetailByPosition != null) && (terrainDetailByPosition.FoodDeposit > 0))
                        {
                            num += terrainDetailByPosition.GetFood(base.Scenario.Date.Season);
                        }
                    }
                }
                return num;
            }
        }

        public int ClearFieldFundCost
        {
            get
            {
                int num = (int) (((this.LongViewArea.Count - this.AreaCount) * Parameters.ClearFieldFundCostUnit) * this.RateOfClearField);
                if (this.Kind.HasAgriculture)
                {
                    return num;
                }
                return (num * 2);
            }
        }

        public int Commerce
        {
            get
            {
                return this.commerce;
            }
            set
            {
                this.commerce = value;
            }
        }

        public int CommerceCeiling
        {
            get
            {
                return ((this.Kind.CommerceBase + (this.Kind.CommerceUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfCommerceCeiling);
            }
        }

        public string CommerceString
        {
            get
            {
                return (this.Commerce + "/" + this.CommerceCeiling);
            }
        }

        public GameArea ContactArea
        {
            get
            {
                if (this.contactArea == null)
                {
                    this.contactArea = this.ArchitectureArea.GetContactArea(false);
                }
                return this.contactArea;
            }
        }

        public int ConvincePersonFund
        {
            get
            {
                return (int) (Parameters.ConvincePersonCost * this.RateOfConvincePerson);
            }
        }

        public int ConvincePersonMaxCount
        {
            get
            {
                return (this.Fund / this.ConvincePersonFund);
            }
        }

        public float CurrentRateOfInternal
        {
            get
            {
                return (this.RateOfInternal + this.DayRateIncrementOfInternal);
            }
        }

        public float CurrentSurplusRate
        {
            get
            {
                return this.surplusRate;
            }
        }

        public int DestroyArchitectureFund
        {
            get
            {
                return (int) (Parameters.DestroyArchitectureCost * this.RateOfDestroyArchitecture);
            }
        }

        public int DestroyPersonMaxCount
        {
            get
            {
                return (this.Fund / this.DestroyArchitectureFund);
            }
        }

        public int Domination
        {
            get
            {
                return this.domination;
            }
            set
            {
                this.domination = value;
            }
        }

        public int DominationCeiling
        {
            get
            {
                return (this.Kind.DominationBase + (this.Kind.DominationUnit * (this.JianzhuGuimo - 1)));
            }
        }

        public string DominationString
        {
            get
            {
                return (this.Domination + "/" + this.DominationCeiling);
            }
        }

        public int Endurance
        {
            get
            {
                return this.endurance;
            }
            set
            {
                this.endurance = value;
            }
        }

        public int EnduranceCeiling
        {
            get
            {
                return ((this.Kind.EnduranceBase + (this.Kind.EnduranceUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfEnduranceCeiling);
            }
        }

        public string EnduranceString
        {
            get
            {
                return (this.Endurance + "/" + this.EnduranceCeiling);
            }
        }

        public int EnoughFood
        {
            get
            {
                int num = 0;
                foreach (Legion legion in this.BelongedFaction.Legions)
                {
                    if (legion.Kind == LegionKind.Defensive)
                    {
                        if (legion == this.DefensiveLegion)
                        {
                            num += legion.FoodCostPerDay * 40;
                        }
                    }
                    else if (((legion.Kind == LegionKind.Offensive) && (legion.PreferredRouteway != null)) && (legion.PreferredRouteway.StartArchitecture == this))
                    {
                        num += legion.FoodCostPerDay * 40;
                    }
                }
                int num2 = (((int) (Math.Sqrt((double) this.Population) * 200.0)) + (this.FoodCostPerDayOfAllMilitaries * 40)) + num;
                if (!this.HostileLine)
                {
                    num2 /= 2;
                }
                if (!this.FrontLine)
                {
                    num2 /= 2;
                }
                return num2;
            }
        }

        public int EnoughFund
        {
            get
            {
                return ((((((((this.AreaCount + this.PersonCount) + this.MilitaryCount) + ((this.TransferFoodArchitecture != null) ? 5 : 0)) + (this.IsCapital ? (2 * this.AreaCount) : 0)) + (this.IsImportant ? 3 : 0)) * 500) + (this.FacilityMaintenanceCost * 30)) + (this.RoutewayActiveCost * 30));
            }
        }

        public int ExpectedFood
        {
            get
            {
                int num = this.Agriculture + ((int) ((Math.Pow((double) this.Population, 0.3) * Math.Pow((double) this.Agriculture, 0.8)) * 47.0));
                num += this.IncrementOfMonthFood;
                num += (int) (this.RateIncrementOfMonthFood * num);
                num = (int) (num * base.Scenario.Date.GetFoodRateBySeason(base.Scenario.Date.Season));
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.IsFriendly(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num += (int) (num * 0.2);
                    }
                    else if (this.IsHostile(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num -= (int) (num * 0.2);
                    }
                }
                if (this.BelongedFaction != null)
                {
                    num = (int) (num * this.BelongedFaction.InternalSurplusRate);
                }
                num = (int) (num * Parameters.FoodRate);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    num = (int) (num * Parameters.AIFoodRate);
                }
                if (GlobalVariables.MultipleResource)
                {
                    num *= 2;
                }
                return num;
            }
        }

        public string ExpectedFoodString
        {
            get
            {
                return (this.ExpectedFood + "/月");
            }
        }

        public int ExpectedFund
        {
            get
            {
                int num = this.Commerce + ((int) ((Math.Pow((double) this.Population, 0.6) * Math.Pow((double) this.Commerce, 0.8)) / 59.0));
                num += this.IncrementOfMonthFund;
                num += (int) (this.RateIncrementOfMonthFund * num);
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.IsFriendly(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num += (int) (num * 0.2);
                    }
                    else if (this.IsHostile(this.LocationState.StateAdmin.BelongedFaction))
                    {
                        num -= (int) (num * 0.2);
                    }
                }
                if (this.BelongedFaction != null)
                {
                    num = (int) (num * this.BelongedFaction.InternalSurplusRate);
                }
                num = (int) (num * Parameters.FundRate);
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    num = (int) (num * Parameters.AIFundRate);
                }
                if (GlobalVariables.MultipleResource)
                {
                    num *= 2;
                }
                return num;
            }
        }

        public string ExpectedFundString
        {
            get
            {
                return (this.ExpectedFund + "/月");
            }
        }

        public int FacilityCount
        {
            get
            {
                return this.Facilities.Count;
            }
        }

        public bool FacilityEnabled
        {
            get
            {
                return this.facilityEnabled;
            }
            set
            {
                this.facilityEnabled = value;
            }
        }

        public string FacilityEnabledString
        {
            get
            {
                return (this.FacilityEnabled ? "是" : "否");
            }
        }

        public int FacilityMaintenanceCost
        {
            get
            {
                int num = 0;
                foreach (Facility facility in this.Facilities)
                {
                    num += facility.MaintenanceCost;
                }
                return num;
            }
        }

        public string FacilityMaintenanceCostString
        {
            get
            {
                return (this.FacilityMaintenanceCost + "/日");
            }
        }

        public int FacilityPositionCount
        {
            get
            {
                return (this.Kind.FacilityPositionUnit * (this.JianzhuGuimo + this.IncrementOfFacilityPositionCount));
            }
        }

        public int FacilityPositionLeft
        {
            get
            {
                int facilityPositionCount = this.FacilityPositionCount;
                foreach (Facility facility in this.Facilities)
                {
                    facilityPositionCount -= facility.PositionOccupied;
                }
                if (this.BuildingFacility >= 0)
                {
                    FacilityKind facilityKind = base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKind(this.BuildingFacility);
                    if (facilityKind != null)
                    {
                        facilityPositionCount -= facilityKind.PositionOccupied;
                    }
                }
                return facilityPositionCount;
            }
        }

        public string FacilityPositionString
        {
            get
            {
                return ((this.FacilityPositionCount - this.FacilityPositionLeft) + "/" + this.FacilityPositionCount);
            }
        }

        public bool FactionAutoRefuse
        {
            get
            {
                return ((this.BelongedFaction != null) && this.BelongedFaction.AutoRefuse);
            }
        }

        public string FactionInternalSurplusRatePercentString
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return StaticMethods.GetPercentString(this.BelongedFaction.InternalSurplusRate, 3);
                }
                return "----";
            }
        }

        public string FactionString
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

        public int FewArmyScale
        {
            get
            {
                return (10 + (2 * this.AreaCount));
            }
        }

        public int Food
        {
            get
            {
                return this.food;
            }
            set
            {
                this.food = value;
            }
        }

        public int FoodCeiling
        {
            get
            {
                return (this.kind.FoodMaxUnit * this.JianzhuGuimo);
            }
        }

        public int FoodCostPerDayOfAllMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    num += military.FoodCostPerDay;
                }
                return num;
            }
        }

        public int FoodCostPerDayOfLandMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Kind.Type != MilitaryType.水军)
                    {
                        num += military.FoodCostPerDay;
                    }
                }
                return num;
            }
        }

        public int FoodCostPerDayOfWaterMilitaries
        {
            get
            {
                int num = 0;
                foreach (Military military in this.Militaries)
                {
                    if (military.Kind.Type == MilitaryType.水军)
                    {
                        num += military.FoodCostPerDay;
                    }
                }
                return num;
            }
        }

        public float FoodReduceDayRate
        {
            get
            {
                return (0.001f * this.RateOfFoodReduceRate);
            }
        }

        public string FoodReduceDayRateString
        {
            get
            {
                return (Math.Round((double) this.FoodReduceDayRate, 4).ToString() + "/日");
            }
        }

        public int Fund
        {
            get
            {
                return this.fund;
            }
            set
            {
                this.fund = value;
            }
        }

        public int FundCeiling
        {
            get
            {
                return (this.Kind.FundMaxUnit * this.JianzhuGuimo);
            }
        }

        public int FundInPack
        {
            get
            {
                int num = 0;
                foreach (FundPack pack in this.FundPacks)
                {
                    num += pack.Fund;
                }
                return num;
            }
        }

        public int GossipArchitectureFund
        {
            get
            {
                return (int) (Parameters.GossipArchitectureCost * this.RateOfGossipArchitecture);
            }
        }

        public int GossipPersonMaxCount
        {
            get
            {
                return (this.Fund / this.GossipArchitectureFund);
            }
        }

        public bool HasBuildingRouteway
        {
            get
            {
                foreach (Routeway routeway in this.Routeways)
                {
                    if (routeway.Building)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasDefensiveLegion
        {
            get
            {
                return (this.DefensiveLegion != null);
            }
        }

        public bool HasFriendlyDiplomaticRelation
        {
            get
            {
                if (this.BelongedFaction == null)
                {
                    return false;
                }
                return this.BelongedFaction.HasFriendlyDiplomaticRelation;
            }
        }

        private bool HasHirablePerson
        {
            get
            {
                foreach (Person person in this.NoFactionPersons)
                {
                    if (person.IsHirable(this.BelongedFaction))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool HasSpy
        {
            get
            {
                return (this.SpyPacks.Count > 0);
            }
        }

        private int HirablePersonCount
        {
            get
            {
                int num = 0;
                foreach (Person person in this.NoFactionPersons)
                {
                    if (person.IsHirable(this.BelongedFaction))
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public bool HireFinished
        {
            get
            {
                return this.hireFinished;
            }
            set
            {
                this.hireFinished = value;
            }
        }

        public int HirePersonFund
        {
            get
            {
                return (int) ((Parameters.HireNoFactionPersonCost * this.AreaCount) * this.RateOfHirePerson);
            }
        }

        public int InformationCoolDown
        {
            get
            {
                return this.informationCoolDown;
            }
            set
            {
                this.informationCoolDown = value;
            }
        }

        public int InstigateArchitectureFund
        {
            get
            {
                return (int) (Parameters.InstigateArchitectureCost * this.RateOfInstigateArchitecture);
            }
        }

        public int InstigatePersonMaxCount
        {
            get
            {
                return (this.Fund / this.InstigateArchitectureFund);
            }
        }

        public int InternalFundCost
        {
            get
            {
                return (Parameters.InternalFundCost * this.AreaCount);
            }
        }

        public bool IsBesideWater
        {
            get
            {
                foreach (Point point in this.ArchitectureArea.GetContactArea(false).Area)
                {
                    if (!base.Scenario.PositionOutOfRange(point) && (base.Scenario.ScenarioMap.MapData[point.X, point.Y] == 6))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool IsCapital
        {
            get
            {
                return ((this.BelongedFaction != null) && (this.BelongedFaction.Capital == this));
            }
        }

        public bool IsFoodAbundant
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food >= this.AbundantFood));
            }
        }

        public bool IsFoodEnough
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food >= this.EnoughFood));
            }
        }

        public bool IsFoodTwiceAbundant
        {
            get
            {
                return ((this.Food >= this.FoodCeiling) || (this.Food > (this.AbundantFood * 2)));
            }
        }

        public bool IsFundAbundant
        {
            get
            {
                return ((this.Fund >= this.FundCeiling) || ((((this.Fund + this.FundInPack) - ((this.BelongedFaction.PlanTechniqueArchitecture == this) ? this.BelongedFaction.PlanTechnique.FundCost : 0)) - ((this.PlanFacilityKind != null) ? this.PlanFacilityKind.FundCost : 0)) >= this.AbundantFund));
            }
        }

        public bool IsFundEnough
        {
            get
            {
                return ((this.Fund >= this.FundCeiling) || ((((this.Fund + this.FundInPack) - ((this.BelongedFaction.PlanTechniqueArchitecture == this) ? this.BelongedFaction.PlanTechnique.FundCost : 0)) - ((this.PlanFacilityKind != null) ? this.PlanFacilityKind.FundCost : 0)) >= this.EnoughFund));
            }
        }

        public bool IsImportant
        {
            get
            {
                return (((this.IsCapital || this.IsStrategicCenter) || this.IsStateAdmin) || this.IsRegionCore);
            }
        }

        public bool IsRegionCore
        {
            get
            {
                return (this.LocationState.LinkedRegion.RegionCore == this);
            }
        }

        public bool IsStateAdmin
        {
            get
            {
                return (this.LocationState.StateAdmin == this);
            }
        }

        public bool IsStrategicCenter
        {
            get
            {
                return this.isStrategicCenter;
            }
            set
            {
                this.isStrategicCenter = value;
            }
        }

        public string IsStrategicCenterString
        {
            get
            {
                return (this.IsStrategicCenter ? "是" : "否");
            }
        }

        public ArchitectureKind Kind
        {
            get
            {
                return this.kind;
            }
            set
            {
                this.kind = value;
            }
        }

        public string KindString
        {
            get
            {
                return this.Kind.Name;
            }
        }

        public int LandArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        if (military.Kind.Type != MilitaryType.水军)
                        {
                            num += military.Scales;
                        }
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        public int LargeArmyScale
        {
            get
            {
                return (40 + (10 * this.AreaCount));
            }
        }

        public GameArea LongViewArea
        {
            get
            {
                if (!this.Kind.HasLongView)
                {
                    return this.ViewArea;
                }
                if (this.longViewArea != null)
                {
                    return this.longViewArea;
                }
                return (this.longViewArea = GameArea.GetAreaFromArea(this.ArchitectureArea, this.LongViewDistance, this.kind.HasObliqueView, base.Scenario, this.BelongedFaction));
            }
            set
            {
                this.longViewArea = value;
            }
        }

        public int LongViewDistance
        {
            get
            {
                return (this.ViewDistance * 2);
            }
        }

        public int MilitaryCount
        {
            get
            {
                return this.Militaries.Count;
            }
        }

        public int Morale
        {
            get
            {
                return this.morale;
            }
            set
            {
                this.morale = value;
            }
        }

        public int MoraleCeiling
        {
            get
            {
                return (this.Kind.MoraleBase + (this.Kind.MoraleUnit * (this.JianzhuGuimo - 1)));
            }
        }

        public string MoraleString
        {
            get
            {
                return (this.Morale + "/" + this.MoraleCeiling);
            }
        }

        public int NoFactionPersonCount
        {
            get
            {
                return this.NoFactionPersons.Count;
            }
        }

        public int NormalArmyScale
        {
            get
            {
                return (20 + (5 * this.AreaCount));
            }
        }

        public ArchitectureList OtherArchitectures
        {
            get
            {
                ArchitectureList list = new ArchitectureList();
                foreach (Architecture architecture in this.BelongedFaction.Architectures)
                {
                    if (architecture != this)
                    {
                        list.Add(architecture);
                    }
                }
                return list;
            }
        }

        public double PDRAgricultureFix
        {
            get
            {
                if (this.Agriculture >= ((int) (this.AgricultureCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Agriculture < ((int) (this.AgricultureCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRCommerceFix
        {
            get
            {
                if (this.Commerce >= ((int) (this.CommerceCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Commerce < ((int) (this.CommerceCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRDominationFix
        {
            get
            {
                if (this.Domination >= ((int) (this.DominationCeiling * 0.8)))
                {
                    return 2E-05;
                }
                if (this.Domination < ((int) (this.DominationCeiling * 0.2)))
                {
                    return -0.0001;
                }
                if (this.Domination < ((int) (this.DominationCeiling * 0.5)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public double PDRMoraleFix
        {
            get
            {
                if (this.Morale >= ((int) (this.MoraleCeiling * 0.6)))
                {
                    return 2E-05;
                }
                if (this.Morale < ((int) (this.MoraleCeiling * 0.1)))
                {
                    return -0.0001;
                }
                if (this.Morale < ((int) (this.MoraleCeiling * 0.3)))
                {
                    return -2E-05;
                }
                return 0.0;
            }
        }

        public int PersonCount
        {
            get
            {
                return this.Persons.Count;
            }
        }

        public int Population
        {
            get
            {
                return this.population;
            }
            set
            {
                this.population = value;
            }
        }

        public int PopulationCeiling
        {
            get
            {
                return (this.Kind.PopulationBase + (this.Kind.PopulationUnit * (this.JianzhuGuimo - 1)));
            }
        }

        public double PopulationDevelopingRate
        {
            get
            {
                double num = Math.Round((double) (((((Parameters.DefaultPopulationDevelopingRate + this.PDRAgricultureFix) + this.PDRCommerceFix) + this.PDRDominationFix) + this.PDRMoraleFix) + this.RateIncrementOfPopulationDevelop), 5);
                if (!((this.RecentlyAttacked <= 0) || this.DayAvoidInfluenceByBattle))
                {
                    num += -0.00030000000000000003;
                }

                return num;
            }
        }

        public string PopulationDevelopingRateString
        {
            get
            {
                return Math.Round((double) (this.PopulationDevelopingRate / 0.0001), 1).ToString();
            }
        }

        public Point Position
        {
            get
            {
                return this.ArchitectureArea.TopLeft;
            }
        }

        public int RecruitmentPopulationBoundary
        {
            get
            {
               // return (this.Kind.PopulationBoundary * this.AreaCount);
                return (this.Kind.PopulationBoundary);
            }
        }

        public string RegionEffectString
        {
            get
            {
                if ((this.LocationState.LinkedRegion.RegionCore != null) && this.LocationState.LinkedRegion.RegionCore.RegionCoreEffectAvail())
                {
                    if (this.LocationState.LinkedRegion.RegionCore.IsFriendly(this.BelongedFaction))
                    {
                        return "正面";
                    }
                    if (this.LocationState.LinkedRegion.RegionCore.IsHostile(this.BelongedFaction))
                    {
                        return "负面";
                    }
                }
                return "----";
            }
        }

        public string RegionString
        {
            get
            {
                return this.LocationState.LinkedRegionString;
            }
        }

        public int RewardPersonFund
        {
            get
            {
                return (int) (Parameters.RewardPersonCost * this.RateOfRewardPerson);
            }
        }

        public int RewardPersonMaxCount
        {
            get
            {
                int rewardPersonFund = this.RewardPersonFund;
                if (rewardPersonFund > 0)
                {
                    return (this.Fund / rewardPersonFund);
                }
                return this.PersonCount;
            }
        }

        public int RoutewayActiveCost
        {
            get
            {
                int num = 0;
                foreach (Routeway routeway in this.Routeways)
                {
                    if (routeway.LastActivePoint != null)
                    {
                        num += routeway.LastActivePoint.ActiveFundCost;
                    }
                }
                return num;
            }
        }

        public string RoutewayActiveCostString
        {
            get
            {
                return (this.RoutewayActiveCost.ToString() + "/日");
            }
        }

        public ArchitectureList RoutewayDestinationArchitectureList
        {
            get
            {
                ArchitectureList list = new ArchitectureList();
                foreach (Architecture architecture in this.RoutewayDestinationArchitectures.Values)
                {
                    list.Add(architecture);
                }
                return list;
            }
        }

        public string SectionString
        {
            get
            {
                if (this.BelongedSection != null)
                {
                    return this.BelongedSection.Name;
                }
                return "----";
            }
        }

        public bool ShowNumber
        {
            get
            {
                return this.showNumber;
            }
            set
            {
                this.showNumber = value;
                if (!value)
                {
                    this.IncrementNumberList.Clear();
                    this.DecrementNumberList.Clear();
                }
            }
        }

        public int SpyArchitectureFund
        {
            get
            {
                return (int) (Parameters.SendSpyCost * this.RateOfSpyArchitecture);
            }
        }

        public int SpyPersonMaxCount
        {
            get
            {
                return (this.Fund / this.SpyArchitectureFund);
            }
        }

        public string StateEffectString
        {
            get
            {
                if ((this.LocationState.StateAdmin != null) && this.LocationState.StateAdmin.StateAdminEffectAvail())
                {
                    if (this.LocationState.StateAdmin.IsFriendly(this.BelongedFaction))
                    {
                        return "正面";
                    }
                    if (this.LocationState.StateAdmin.IsHostile(this.BelongedFaction))
                    {
                        return "负面";
                    }
                }
                return "----";
            }
        }

        public string StateString
        {
            get
            {
                return this.LocationState.Name;
            }
        }

        public int Technology
        {
            get
            {
                return this.technology;
            }
            set
            {
                this.technology = value;
            }
        }

        public int TechnologyCeiling
        {
            get
            {
                return ((this.Kind.TechnologyBase + (this.Kind.TechnologyUnit * (this.JianzhuGuimo - 1))) + this.IncrementOfTechnologyCeiling);
            }
        }

        public string TechnologyString
        {
            get
            {
                return (this.Technology + "/" + this.TechnologyCeiling);
            }
        }

        public Texture2D Texture
        {
            get
            {
                return this.Kind.Texture;
            }
        }

        public int TransferFoodArchitectureCount
        {
            get
            {
                int num = 0;
                foreach (Architecture architecture in this.OtherArchitectures)
                {
                    if (architecture.TransferFoodArchitecture == this)
                    {
                        num++;
                    }
                }
                return num;
            }
        }

        public int UnitPopulation
        {
            get
            {
                return (this.Population / this.AreaCount);
            }
        }

        public bool ValueWater
        {
            get
            {
                return (this.Kind.HasHarbor || this.TroopershipAvailable);
            }
        }

        public int VeryFewArmyScale
        {
            get
            {
                return (5 + this.AreaCount);
            }
        }

        public GameArea ViewArea
        {
            get
            {
                if (this.viewArea != null)
                {
                    return this.viewArea;
                }
                return (this.viewArea = GameArea.GetAreaFromArea(this.ArchitectureArea, this.ViewDistance, this.kind.HasObliqueView, base.Scenario, this.BelongedFaction));
            }
            set
            {
                this.viewArea = value;
            }
        }

        public int ViewDistance
        {
            get
            {
                return ((this.Kind.ViewDistance + (this.AreaCount / this.Kind.ViewDistanceIncrementDivisor)) + this.IncrementOfViewRadius);
            }
        }

        public int WaterArmyScale
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    int num = 0;
                    foreach (Military military in this.Militaries)
                    {
                        if (military.Kind.Type == MilitaryType.水军)
                        {
                            num += military.Scales;
                        }
                        else if (this.ValueWater)
                        {
                            num += military.Quantity / 0x7d0;
                        }
                    }
                    return num;
                }
                return ((this.AreaCount * 5) + ((this.Population / 0x2710) / 2));
            }
        }

        private class AILinkProcedureDetail
        {
            internal Architecture A;
            internal int Level;
            internal List<Architecture> Path = new List<Architecture>();

            internal AILinkProcedureDetail(int level, Architecture a, List<Architecture> path)
            {
                this.Level = level;
                this.A = a;
                foreach (Architecture architecture in path)
                {
                    this.Path.Add(architecture);
                }
            }
        }

        public FreeText jianzhubiaoti
        {
            get;
            set;
        }

        public qizi jianzhuqizi
        {
            get;
            set;
        }

        public bool youzainan
        {
            get;
            set;
        }

        public string zainanming
        {
            get
            {
                if (this.youzainan)
                {
                    return this.zainan.zainanzhonglei.Name;
                }
                else
                {
                    return "——";
                }
            }
        }

        public string zainanshengyutianshu
        {
            get
            {
                if (this.youzainan)
                {
                    return this.zainan.shengyutianshu.ToString() ;
                }
                else
                {
                    return "——";
                }
            }
        }

        public bool kezhenzai()
        {

                if (this.youzainan && this.Fund > 0 && this.Food > 0 && this.HasPerson())
                {
                    return true;
                }
                else
                {
                    return false;
                }

        }

        public bool kenafei()
        {

            if (this.younvxingwujiang()&&this.Fund>50000&&this.meinvkongjian()>this.feiziliebiao.Count )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool kejinhougong()
        {
            if (this.meifaxianhuaiyundefeiziliebiao().Count != 0 && this.Persons.GameObjects.Contains(this.BelongedFaction.Leader))
            {

                return true;
            }
            return false;

        }
        public PersonList meifaxianhuaiyundefeiziliebiao()
        {
             PersonList meihuailiebiao=new PersonList();
             foreach (Person person in this.feiziliebiao)
                {
                    if (!person.faxianhuaiyun)
                        meihuailiebiao.Add(person);
                }
             return meihuailiebiao;
        }

        private bool younvxingwujiang()
        {
            foreach (Person person in this.Persons )
            {
                if (person.Sex)
                {
                    return true;
                }
            }
            return false;
        }

        public PersonList nvxingwujiang()
        {
            PersonList nvxingwujiangliebiao=new PersonList ();
            foreach (Person person in this.Persons)
            {
                if (person.Sex)
                {
                    nvxingwujiangliebiao.Add(person);
                }
            }
            return nvxingwujiangliebiao;
        }

        public int meinvkongjian()
        {
            int kongjian=0;
            foreach (Facility facility in this.Facilities)
            {
                kongjian += facility.Kind.rongna;
            }
            return kongjian;
        }

        public string meinvkongjianzifu
        {
            get
            {
                return this.feiziliebiao.Count.ToString()+"/"+this.meinvkongjian().ToString();
            }
        }


        public FacilityList kechaichudesheshi()
        {
            FacilityList kechaichu = new FacilityList();
            foreach (Facility facility in this.Facilities)
            {
                if (! facility.Kind.bukechaichu)
                {
                    kechaichu.Add(facility);
                }
            }
            return kechaichu;
        }

        public PersonList yihuaiyundefeiziliebiao()
        {
            PersonList feiziliebiao= new PersonList();
            foreach (Person feizi in this.feiziliebiao)
            {
                if (feizi.huaiyun)
                {
                    feiziliebiao.Add(feizi);
                }
            }
            return feiziliebiao;
        }

        public bool huangdisuozai
        {
            get;
            set;
        }

        public bool kejingongzijin()
        {
            if (base.Scenario.Date.Month==3 && base.Scenario.youhuangdi() && this.Fund > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool kejingongliangcao()
        {
            if (base.Scenario.Date.Month == 3 && base.Scenario.youhuangdi() && this.Food  > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Point zhongxindian
        {
            get
            {
                int xzonghe=0;
                int yzonghe=0;
                int xpingjunzhi;
                int ypingjunzhi;
                foreach (Point p in this.ArchitectureArea.Area  )
                {
                    xzonghe += p.X;
                    yzonghe += p.Y;
                }
                xpingjunzhi = xzonghe / this.JianzhuGuimo;
                ypingjunzhi = yzonghe / this.JianzhuGuimo;
                foreach (Point p in this.ArchitectureArea.Area)
                {
                    if (p.X == xpingjunzhi && p.Y == ypingjunzhi)
                    {
                        return p;
                    }
                }
                return this.ArchitectureArea.Area[0]; 
            }
        }

        public Point dingdian
        {
            get
            {
                Point zuishangmiandedian = this.ArchitectureArea.Area[0];
                foreach (Point p in this.ArchitectureArea.Area)
                {
                    if (p.Y < zuishangmiandedian.Y)
                    {
                        zuishangmiandedian = p;
                    }
                }

                if (this.Kind.ID == 2 )  //如果是关隘
                {
                    if (this.JianzhuGuimo == 1)
                    {
                        return zuishangmiandedian;
                    }
                    if (this.ArchitectureArea.Area[0].X == this.ArchitectureArea.Area[1].X)
                    {
                        return zuishangmiandedian;
                    }
                    else
                    {
                        return this.zhongxindian;
                    }

                }

                return zuishangmiandedian;
            }
        }

        public delegate void BeginRecentlyAttacked(Architecture architecture);

        public delegate void FacilityCompleted(Architecture architecture, Facility facility);

        public delegate void fashengzainan(Architecture architecture, int  zainanID);

        public delegate void HirePerson(PersonList personList);

        public delegate void MilitaryCreate(Architecture architecture, Military military);

        public delegate void PopulationEnter(Architecture a, int quantity);

        public delegate void PopulationEscape(Architecture a, int quantity);

        public delegate void ReleaseCaptiveAfterOccupied(Architecture architecture, PersonList persons);

        public delegate void RewardPersons(Architecture architecture, GameObjectList personlist);

        [StructLayout(LayoutKind.Sequential)]
        private struct RoutewayProcedureDetail
        {
            internal Architecture Start;
            internal float PreviousRate;
            internal RoutewayProcedureDetail(Architecture a, float rate)
            {
                this.Start = a;
                this.PreviousRate = rate;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct WorkRate
        {
            internal float rate;
            internal ArchitectureWorkKind workKind;
            public WorkRate(float r, ArchitectureWorkKind k)
            {
                this.rate = r;
                this.workKind = k;
            }
        }

        internal class WorkRateList
        {
            internal List<Architecture.WorkRate> RateList = new List<Architecture.WorkRate>();

            internal void AddWorkRate(Architecture.WorkRate wr)
            {
                for (int i = 0; i < this.RateList.Count; i++)
                {
                    if (wr.rate <= this.RateList[i].rate)
                    {
                        this.RateList.Insert(i, wr);
                        return;
                    }
                }
                this.RateList.Add(wr);
            }

            internal int Count
            {
                get
                {
                    return this.RateList.Count;
                }
            }
        }
    }
}

