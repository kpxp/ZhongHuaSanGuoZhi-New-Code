namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.ArchitectureDetail;
    using GameObjects.FactionDetail;
    using GameObjects.Influences;
    using GameObjects.MapDetail;
    using GameObjects.PersonDetail;
    //using GameObjects.PersonDetail.PersonMessages;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    //using GameFreeText;

    public class GameScenario
    {
        //public GameFreeText.FreeText GameProgressCaution;

        public static readonly string SCENARIO_ERROR_TEXT_FILE = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/GameData/ScenarioErrors.txt";

        private Dictionary<int, Architecture> AllArchitectures = new Dictionary<int, Architecture>();
        private Dictionary<int, Person> AllPersons = new Dictionary<int, Person>();

        

       // public OngoingBattleList AllOngoingBattles = new OngoingBattleList();
        public ArchitectureList Architectures = new ArchitectureList();
        public Faction CurrentFaction;
        public Faction CurrentPlayer;
        public GameDate Date = new GameDate();
        public DiplomaticRelationTable DiplomaticRelations = new DiplomaticRelationTable();
        public bool EnableLoadAndSave = true;
        public FacilityList Facilities = new FacilityList();
        public FactionListWithQueue Factions = new FactionListWithQueue();
        public PositionTable FireTable = new PositionTable();
        public CommonData GameCommonData = new CommonData();
        public Screen GameScreen;
        public TileAnimationGenerator GeneratorOfTileAnimation;
        public InformationList Informations = new InformationList();
        public LegionList Legions = new LegionList();
        public TileData[,] MapTileData;
        public MilitaryList Militaries = new MilitaryList();
        private Person neutralPerson;
        public bool NewInfluence;
        public NoFoodTable NoFoodDictionary = new NoFoodTable();
        public int[,] PenalizedMapData;
        public PersonList Persons = new PersonList();
        public FactionList PlayerFactions = new FactionList();
        public PersonList PreparedAvailablePersons = new PersonList();
        public bool Preparing = false;
        public RegionList Regions = new RegionList();
        public RoutewayList Routeways = new RoutewayList();
        public string ScenarioDescription;
        public Map ScenarioMap = new Map();
        public string ScenarioTitle;
        public SectionList Sections = new SectionList();
        //public GameMessageList SpyMessages = new GameMessageList();
        public StateList States = new StateList();
        public int[] TerrainAdaptability;
        public bool Threading;
        public TreasureList Treasures = new TreasureList();
        public TroopEventList TroopEvents = new TroopEventList();
        public Dictionary<TroopEvent, TroopList> TroopEventsToApply = new Dictionary<TroopEvent, TroopList>();
        public TroopListWithQueue Troops = new TroopListWithQueue();
        public YearTable YearTable = new YearTable();
        public Dictionary<Event, Architecture> EventsToApply = new Dictionary<Event, Architecture>();
        public EventList AllEvents = new EventList();
        public String LoadedFileName;
        public bool UsingOwnCommonData;

        public BiographyTable AllBiographies = new BiographyTable();

        // 缓存地图上有几支部队在埋伏
        private int numberOfAmbushTroop = -1;
        public int NumberOfAmbushTroop
        {
            get
            {
                if (numberOfAmbushTroop >= 0)
                    return numberOfAmbushTroop;
                else
                {
                    int number = 0;
                    foreach (Troop t in Troops)
                    {
                        if (t.Status == TroopStatus.埋伏)
                            number++;
                    }
                    numberOfAmbushTroop = number;
                    return numberOfAmbushTroop;
                }
            }
        }

        public event AfterLoadScenario OnAfterLoadScenario;

        public event AfterSaveScenario OnAfterSaveScenario;

        public event NewFactionAppear OnNewFactionAppear;

        public bool scenarioJustLoaded;

        public int DaySince { get; set; }

        internal Dictionary<PathCacheKey, List<Point>> pathCache = new Dictionary<PathCacheKey, List<Point>>();

        public GameScenario(Screen screen)
        {
            this.GameScreen = screen;
            this.GeneratorOfTileAnimation = new TileAnimationGenerator(this);
        }

        private Dictionary<Architecture, PersonList>
             NormalPLCache, MovingPLCache, NoFactionPLCache, NoFactionMovingPLCache, PrincessPLCache,
             ZhenzaiPLCache, AgriculturePLCache, CommercePLCache, TechnologyPLCache,
             DominationPLCache, MoralePLCache, EndurancePLCache, TrainingPLCache;
        private Dictionary<Architecture, CaptiveList> CaptivePLCache;

        private PersonList emptyPersonList = new PersonList();
        private CaptiveList emptyCaptiveList = new CaptiveList();

        public PersonList GetPersonList(Architecture a)
        {
            if (NormalPLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.NormalPLCache.ContainsKey(a)) return emptyPersonList;
            return NormalPLCache[a];
        }

        public PersonList GetMovingPersonList(Architecture a)
        {
            if (MovingPLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.MovingPLCache.ContainsKey(a)) return emptyPersonList;
            return MovingPLCache[a];
        }

        public PersonList GetNoFactionPersonList(Architecture a)
        {
            if (NoFactionPLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.NoFactionPLCache.ContainsKey(a)) return emptyPersonList;
            return NoFactionPLCache[a];
        }

        public PersonList GetNoFactionMovingPersonList(Architecture a)
        {
            if (NoFactionMovingPLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.NoFactionMovingPLCache.ContainsKey(a)) return emptyPersonList;
            return NoFactionMovingPLCache[a];
        }

        public PersonList GetPrincessPersonList(Architecture a)
        {
            if (PrincessPLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.PrincessPLCache.ContainsKey(a)) return emptyPersonList;
            return PrincessPLCache[a];
        }

        public CaptiveList GetCaptiveList(Architecture a)
        {
            if (CaptivePLCache == null)
            {
                CreatePersonStatusCache();
            }
            if (!this.CaptivePLCache.ContainsKey(a)) return emptyCaptiveList;
            return CaptivePLCache[a];
        }

        public PersonList GetZhenzaiPersonList(Architecture a)
        {
            if (ZhenzaiPLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.ZhenzaiPLCache.ContainsKey(a)) return emptyPersonList;
            return ZhenzaiPLCache[a];
        }

        public PersonList GetAgriculturePersonList(Architecture a)
        {
            if (AgriculturePLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.AgriculturePLCache.ContainsKey(a)) return emptyPersonList;
            return AgriculturePLCache[a];
        }

        public PersonList GetCommercePersonList(Architecture a)
        {
            if (CommercePLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.CommercePLCache.ContainsKey(a)) return emptyPersonList;
            return CommercePLCache[a];
        }

        public PersonList GetTechnologyPersonList(Architecture a)
        {
            if (TechnologyPLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.TechnologyPLCache.ContainsKey(a)) return emptyPersonList;
            return TechnologyPLCache[a];
        }

        public PersonList GetDomintaionPersonList(Architecture a)
        {
            if (DominationPLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.DominationPLCache.ContainsKey(a)) return emptyPersonList;
            return DominationPLCache[a];
        }

        public PersonList GetMoralePersonList(Architecture a)
        {
            if (MoralePLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.MoralePLCache.ContainsKey(a)) return emptyPersonList;
            return MoralePLCache[a];
        }

        public PersonList GetEndurancePersonList(Architecture a)
        {
            if (EndurancePLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.EndurancePLCache.ContainsKey(a)) return emptyPersonList;
            return EndurancePLCache[a];
        }

        public PersonList GetTrainingPersonList(Architecture a)
        {
            if (TrainingPLCache == null)
            {
                CreatePersonWorkCache();
            }
            if (!this.TrainingPLCache.ContainsKey(a)) return emptyPersonList;
            return TrainingPLCache[a];
        }

        private void CreatePersonWorkCache()
        {
            ZhenzaiPLCache = new Dictionary<Architecture, PersonList>();
            AgriculturePLCache = new Dictionary<Architecture, PersonList>();
            CommercePLCache = new Dictionary<Architecture, PersonList>();
            TechnologyPLCache = new Dictionary<Architecture, PersonList>();
            DominationPLCache = new Dictionary<Architecture, PersonList>();
            MoralePLCache = new Dictionary<Architecture, PersonList>();
            EndurancePLCache = new Dictionary<Architecture, PersonList>();
            TrainingPLCache = new Dictionary<Architecture, PersonList>();

            foreach (Person i in this.AvailablePersons)
            {
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.赈灾 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.ZhenzaiPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.ZhenzaiPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    ZhenzaiPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.农业 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.AgriculturePLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.AgriculturePLCache[i.LocationArchitecture] = new PersonList();
                    }
                    AgriculturePLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.商业 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.CommercePLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.CommercePLCache[i.LocationArchitecture] = new PersonList();
                    }
                    CommercePLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.技术 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.TechnologyPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.TechnologyPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    TechnologyPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.统治 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.DominationPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.DominationPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    DominationPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.民心 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.MoralePLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.MoralePLCache[i.LocationArchitecture] = new PersonList();
                    }
                    MoralePLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.耐久 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.EndurancePLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.EndurancePLCache[i.LocationArchitecture] = new PersonList();
                    }
                    EndurancePLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Normal && i.WorkKind == ArchitectureWorkKind.训练 && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.TrainingPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.TrainingPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    TrainingPLCache[i.LocationArchitecture].Add(i);
                }
            }
        }

        private void CreatePersonStatusCache()
        {
            NormalPLCache = new Dictionary<Architecture, PersonList>();
            MovingPLCache = new Dictionary<Architecture, PersonList>();
            NoFactionPLCache = new Dictionary<Architecture, PersonList>();
            NoFactionMovingPLCache = new Dictionary<Architecture, PersonList>();
            PrincessPLCache = new Dictionary<Architecture, PersonList>();
            CaptivePLCache = new Dictionary<Architecture, CaptiveList>();

            foreach (Person i in this.AvailablePersons)
            {
                if (i.Status == PersonStatus.Normal && i.LocationArchitecture != null && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.NormalPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.NormalPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    NormalPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Moving && i.LocationArchitecture != null && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.MovingPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.MovingPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    MovingPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.NoFaction && i.LocationArchitecture != null && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.NoFactionPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.NoFactionPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    NoFactionPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.NoFactionMoving && i.LocationArchitecture != null && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.NoFactionMovingPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.NoFactionMovingPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    NoFactionMovingPLCache[i.LocationArchitecture].Add(i);
                }
                if (i.Status == PersonStatus.Princess && i.LocationArchitecture != null && (i.LocationTroop == null || !this.Troops.GameObjects.Contains(i.LocationTroop)))
                {
                    if (!this.PrincessPLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.PrincessPLCache[i.LocationArchitecture] = new PersonList();
                    }
                    PrincessPLCache[i.LocationArchitecture].Add(i);
                }
            }
            foreach (Captive i in this.Captives)
            {
                if (i.LocationArchitecture != null && i.CaptivePerson != null)
                {
                    if (!this.CaptivePLCache.ContainsKey(i.LocationArchitecture))
                    {
                        this.CaptivePLCache[i.LocationArchitecture] = new CaptiveList();
                    }
                    CaptivePLCache[i.LocationArchitecture].Add(i);
                }
            }
        }

        public void ClearPersonStatusCache()
        {
            NormalPLCache = MovingPLCache = NoFactionPLCache = NoFactionMovingPLCache = PrincessPLCache = null;
            CaptivePLCache = null;
        }

        public void ClearPersonWorkCache()
        {
            ZhenzaiPLCache = AgriculturePLCache = CommercePLCache = TechnologyPLCache =
            DominationPLCache = MoralePLCache = EndurancePLCache = TrainingPLCache = null;
        }

        public CaptiveList Captives
        {
            get
            {
                CaptiveList result = new CaptiveList();
                foreach (Person i in this.Persons)
                {
                    if (i.Status == PersonStatus.Captive)
                    {
                        if (i.BelongedCaptive == null)
                        {
                            continue;
                        }
                        result.Add(i.BelongedCaptive);
                    }
                }
                return result;
            }
        }

        public PersonList AvailablePersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in this.Persons)
                {
                    if (i.Status != PersonStatus.None && i.Alive && i.Available)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public PersonList DeadPersons
        {
            get
            {
                PersonList result = new PersonList();
                foreach (Person i in this.Persons)
                {
                    if (i.Status != PersonStatus.None && !i.Alive && i.Available)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }

        public void AddPositionAreaInfluence(Troop troop, Point position, AreaInfluenceKind kind, int offset, float rate)
        {
            if (!this.PositionOutOfRange(position))
            {
                Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
                this.MapTileData[position.X, position.Y].AddAreaInfluence(troop, kind, offset, rate, troopByPositionNoCheck);
            }
        }

        public void AddPositionContactingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddContactingTroop(troop);
            }
        }

        public void AddPositionOffencingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddOffencingTroop(troop);
            }
        }

        public void AddPositionStratagemingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].AddStratagemingTroop(troop);
            }
        }

        public void AddPositionViewingTroopNoCheck(Troop troop, Point position)
        {
            this.MapTileData[position.X, position.Y].AddViewingTroop(troop);
        }
        /*
        private void AddPreparedAvailablePersons()
        {
            foreach (Person person in this.PreparedAvailablePersons)
            {
                Architecture gameObject = this.Architectures.GetGameObject(person.AvailableLocation) as Architecture;
                person.Available = true;
                foreach (Treasure treasure in person.Treasures)
                {
                    treasure.Available = true;
                }
                if (person.Father > 0)
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Father)
                        {
                            if (p.Available && p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null&&p.BelongedCaptive==null )
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                this.GameScreen.xianshishijiantupian(p.BelongedFaction.Leader,(this.Persons.GetGameObject(person.Father) as Person).Name,"ChildJoin","","",person.Name ,false);
                                this.GameScreen.xianshishijiantupian(person, p.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "",  false);

                            }
                        }
                    }
                }
                else if (person.Mother > 0)
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Mother)
                        {
                            if (p.Available && p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null && p.BelongedCaptive == null)
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                this.GameScreen.xianshishijiantupian(p.BelongedFaction.Leader, (this.Persons.GetGameObject(person.Mother) as Person).Name, "ChildJoin", "", "", person.Name, false);
                                this.GameScreen.xianshishijiantupian(person, p.LocationArchitecture.Name, "ChildJoinSelfTalk", "", "", false);

                            }
                        }
                    }
                }
                else if (person.Spouse > 0 )
                {
                    foreach (Person p in this.Persons)
                    {
                        if (p.ID == person.Spouse)
                        {
                            if (p.Alive && p.LocationArchitecture != null && p.BelongedFaction != null && p.BelongedCaptive == null)
                            {
                                p.LocationArchitecture.AddPerson(person);
                                p.BelongedFaction.AddPerson(person);
                                if (person.Sex) //女的
                                {
                                    this.GameScreen.xianshishijiantupian(person, (this.Persons.GetGameObject(person.Spouse) as Person).Name, "FemaleSpouseJoin", "", "", false);
                                }
                                else
                                {
                                    this.GameScreen.xianshishijiantupian(person, (this.Persons.GetGameObject(person.Spouse) as Person).Name, "MaleSpouseJoin", "", "", false);

                                }

                            }
                        }
                    }
                }
                else
                {
                    gameObject.AddNoFactionPerson(person);
                }
                this.AvailablePersons.Add(person);
            }
            this.PreparedAvailablePersons.Clear();
        }
        */

        private void AddPreparedAvailablePersons()
        {
            foreach (Person person in this.PreparedAvailablePersons)
            {
                person.Available = true;
                foreach (Treasure treasure in person.Treasures)
                {
                    treasure.Available = true;
                }

                Person joinToPerson = person.Father;

                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive && joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.BelongedArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    person.YearJoin = this.Date.Year;
                    this.GameScreen.xianshishijiantupian(joinToPerson.BelongedFaction.Leader, joinToPerson.Name, TextMessageKind.ChildJoin, "ChildJoin", "", "", person.Name, false);
                    if (person.LocationArchitecture != null)
                    {
                        this.GameScreen.xianshishijiantupian(person, person.LocationArchitecture.Name, TextMessageKind.ChildJoinSelfTalk, "ChildJoinSelfTalk", "", "", false);
                    }
                    this.AvailablePersons.Add(person);
                    this.YearTable.addGrownBecomeAvailableEntry(this.Date, person);
                    continue;
                }

                joinToPerson = person.Mother;
                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive && joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.BelongedArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    person.YearJoin = this.Date.Year;
                    this.GameScreen.xianshishijiantupian(joinToPerson.BelongedFaction.Leader, joinToPerson.Name, TextMessageKind.ChildJoin, "ChildJoin", "", "", person.Name, false);
                    this.GameScreen.xianshishijiantupian(person, person.LocationArchitecture.Name, TextMessageKind.ChildJoinSelfTalk, "ChildJoinSelfTalk", "", "", false);
                    this.AvailablePersons.Add(person);
                    this.YearTable.addGrownBecomeAvailableEntry(this.Date, person);
                    continue;
                }

                joinToPerson = person.Spouse;
                if (joinToPerson != null && joinToPerson.Available && joinToPerson.Alive && joinToPerson.BelongedFaction != null && joinToPerson.BelongedCaptive == null)
                {
                    person.LocationArchitecture = joinToPerson.BelongedArchitecture;
                    person.Status = PersonStatus.Normal;
                    person.InitialLoyalty();
                    person.YearJoin = this.Date.Year;
                    if (person.Sex) //女的
                    {
                        this.GameScreen.xianshishijiantupian(person, joinToPerson.Name, TextMessageKind.FemaleSpouseJoin, "FemaleSpouseJoin", "", "", false);
                    }
                    else
                    {
                        this.GameScreen.xianshishijiantupian(person, joinToPerson.Name, TextMessageKind.MaleSpouseJoin, "MaleSpouseJoin", "", "", false);

                    }
                    this.AvailablePersons.Add(person);
                    this.YearTable.addGrownBecomeAvailableEntry(this.Date, person);
                    continue;
                }

                bool joined = false;
                foreach (int id in person.JoinFactionID)
                {
                    Faction f = (Faction)this.Factions.GetGameObject(id);
                    if (f != null)
                    {
                        this.AvailablePersons.Add(person);
                        person.LocationArchitecture = f.Capital;
                        person.Status = PersonStatus.Normal;
                        person.InitialLoyalty();
                        person.YearJoin = this.Date.Year;
                        this.GameScreen.xianshishijiantupian(person, f.Capital.Name, TextMessageKind.PersonJoin, "PersonJoin", "", "", f.Name, false);
                        this.YearTable.addGrownBecomeAvailableEntry(this.Date, person);
                        joined = true;
                        break;
                    }
                }
                if (joined) continue;

                person.LocationArchitecture = this.Architectures.GetGameObject(person.AvailableLocation) as Architecture;
                person.Status = PersonStatus.NoFaction;
            }
            this.PreparedAvailablePersons.Clear();
        }

        public void haizichusheng(Person person, Person father, Person muqin, bool doAffect)
        {
            person.Available = true;
            foreach (Treasure treasure in person.Treasures)
            {
                treasure.Available = true;
            }

            person.LocationArchitecture = muqin.BelongedArchitecture;
            person.ChangeFaction(muqin.BelongedFaction);

            if (muqin.IsCaptive)
            {
                person.Loyalty = muqin.Loyalty;
                Captive.Create(this, person, muqin.BelongedArchitecture.BelongedFaction);
            }
            else
            {
                if (GlobalVariables.lockChildrenLoyalty && father != null && father.BelongedFaction == person.LocationArchitecture.BelongedFaction)
                {
                    person.Loyalty = 120;
                }
                if (GameObject.Chance(father.childrenLoyaltyRate))
                {
                    person.Loyalty = father.childrenLoyalty;
                }
                else if (GameObject.Chance(muqin.childrenLoyaltyRate))
                {
                    person.Loyalty = muqin.childrenLoyalty;
                }
            }

            ExtensionInterface.call("ChildrenJoinFaction", new Object[] { this, person });

            this.GameScreen.haizizhangdachengren(person, person);
        }




        public void ApplyFireTable()
        {
            foreach (Point point in this.FireTable.Positions)
            {
                this.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.火焰, point, true);
            }
        }

        public void ApplyTroopEvents()
        {
            if (this.TroopEventsToApply.Count != 0)
            {
                foreach (TroopEvent event2 in this.TroopEvents)
                {
                    TroopList list = null;
                    if (this.TroopEventsToApply.TryGetValue(event2, out list))
                    {
                        foreach (Troop troop in list.GetList())
                        {
                            event2.ApplyEventEffects(troop);
                        }
                    }
                }
                this.TroopEventsToApply.Clear();
            }
        }

        public void ApplyEvents()
        {
            foreach (KeyValuePair<Event, Architecture> i in this.EventsToApply)
            {
                i.Key.DoApplyEvent(i.Value);
                i.Key.happened = true;
            }
            this.EventsToApply.Clear();
        }

        public void ChangeDiplomaticRelation(int faction1, int faction2, int offset)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(this, faction1, faction2);
                if (diplomaticRelation != null)
                {
                    diplomaticRelation.Relation += offset;
                }
            }
        }

        public void SetDiplomaticRelationIfHigher(int faction1, int faction2, int value)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(this, faction1, faction2);
                if (diplomaticRelation != null)
                {
                    if (diplomaticRelation.Relation > value)
                    {
                        diplomaticRelation.Relation = value;
                    }
                }
            }
        }

        public void SetDiplomaticRelationTruce(int faction1, int faction2, int value)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(this, faction1, faction2);
                if (diplomaticRelation != null)
                {
                    diplomaticRelation.Truce = value;
                }
            }
        }

        private void CheckGameEnd()
        {
            FactionList noArchFaction = new FactionList();
            foreach (Faction f in this.Factions)
            {
                if (f.ArchitectureCount == 0)
                {
                    noArchFaction.Add(f);
                }
            }

            foreach (Faction f in noArchFaction)
            {
                this.Factions.Remove(f);
            }

            if (this.Factions.Count == 1)
            {
                ExtensionInterface.call("GameEnd", new Object[] { this });
                if (this.CurrentPlayer != null && !this.runScenarioEnd(this.CurrentPlayer.Capital))
                {
                    this.GameScreen.GameEndWithUnite(this.Factions[0] as Faction);
                }
            }
        }

        public void Clear()
        {
            this.AllEvents.Clear();
            this.TroopEvents.Clear();
            this.Persons.Clear();
            this.AvailablePersons.Clear();
            this.PreparedAvailablePersons.Clear();
            this.Captives.Clear();
            this.Facilities.Clear();
            this.Militaries.Clear();
            this.Treasures.Clear();
            this.Informations.Clear();
            //this.SpyMessages.Clear();
            this.Routeways.Clear();
            GameObjectList t1 = this.Troops.GetList();
            foreach (Troop t in t1)
            {
                t.Destroy(true, false);
            }
            this.Troops.Clear();
            this.Legions.Clear();
            this.Architectures.Clear();
            this.Sections.Clear();
            this.Factions.Clear();
            this.Regions.Clear();
            this.States.Clear();
            this.ScenarioMap.Clear();
            this.PlayerFactions.Clear();
            this.FireTable.Clear();
            this.NoFoodDictionary.Clear();
            this.DiplomaticRelations.Clear();
            this.GeneratorOfTileAnimation.Clear();
            this.YearTable.Clear();
            this.GameCommonData.Clear();
            this.CurrentFaction = null;
            this.CurrentPlayer = null;
        }

        public void ClearPenalizedMapDataByArea(GameArea gameArea)
        {
            foreach (Point point in gameArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.PenalizedMapData[point.X, point.Y] = 0;
                }
            }
        }

        public void ClearPenalizedMapDataByPosition(Point position)
        {
            this.PenalizedMapData[position.X, position.Y] = 0;
        }

        public void ClearPositionFire(Point position)
        {
            this.FireTable.RemovePosition(position);
            this.GeneratorOfTileAnimation.RemoveTileAnimation(TileAnimationKind.火焰, position, true);
        }

        public void CreateNewFaction(Person leader)
        {
            if (leader.Status != PersonStatus.Normal && leader.Status != PersonStatus.NoFaction) return;

            Faction newFaction = new Faction();
            newFaction.Scenario = this;
            newFaction.ID = this.Factions.GetFreeGameObjectID();
            this.Factions.AddFactionWithEvent(newFaction);
            foreach (Faction faction2 in this.Factions)
            {
                if (faction2 != newFaction)
                {
                    this.DiplomaticRelations.AddDiplomaticRelation(this, newFaction.ID, faction2.ID, 0);
                }
            }
            newFaction.Leader = leader;
            leader.Loyalty = 100;
            newFaction.Reputation = leader.Reputation;
            newFaction.Name = leader.Name;
            if (leader.PersonBiography != null)
            {
                foreach (MilitaryKind kind in leader.PersonBiography.MilitaryKinds.MilitaryKinds.Values)
                {
                    newFaction.BaseMilitaryKinds.AddMilitaryKind(kind);
                }
                newFaction.ColorIndex = leader.PersonBiography.FactionColor;
            }
            else
            {
                newFaction.BaseMilitaryKinds.AddBasicMilitaryKinds(this);
                newFaction.ColorIndex = -1;
            }

            List<int> allUnusedColors = new List<int>();
            for (int i = 0; i < this.GameCommonData.AllColors.Count; ++i)
            {
                allUnusedColors.Add(i);
            }
            foreach (Faction f in this.Factions)
            {
                allUnusedColors.Remove(f.ColorIndex);
            }
            if (allUnusedColors.Count == 0)
            {
                newFaction.ColorIndex = GameObject.Random(this.GameCommonData.AllColors.Count);
            }
            else
            {
                if (!allUnusedColors.Contains(newFaction.ColorIndex))
                {
                    newFaction.ColorIndex = allUnusedColors[GameObject.Random(allUnusedColors.Count)];
                }
            }

            newFaction.FactionColor = this.GameCommonData.AllColors[newFaction.ColorIndex];

            Architecture newFactionCapital = leader.LocationArchitecture;
            Faction oldFaction = newFactionCapital.BelongedFaction;

            newFaction.Capital = newFactionCapital;

            if (leader.BelongedFaction == null)
            {
                leader.Status = PersonStatus.Normal;
            }
            else
            {
                this.ChangeDiplomaticRelation(newFaction.ID, newFactionCapital.BelongedFaction.ID, -500);
            }
            newFaction.PrepareData();

            newFactionCapital.ResetFaction(newFaction);

            newFaction.AddArchitectureKnownData(newFactionCapital);
            newFaction.FirstSection.AddArchitecture(newFactionCapital);

            leader.MoveToArchitecture(newFactionCapital);

            if (oldFaction != null && !GameObject.Chance((int)oldFaction.Leader.PersonalLoyalty * 10))
            {
                oldFaction.Leader.AddHated(leader);
            }
            foreach (Person p in this.AvailablePersons)
            {
                if ((p.BelongedFaction == null || p.BelongedFaction == oldFaction) && !p.IsCaptive && p.Status != PersonStatus.Princess && p != leader)
                {
                    int offset = Person.GetIdealOffset(leader, p);
                    if (p.HasCloseStrainTo(leader) || p.IsVeryCloseTo(leader) || (GameObject.Chance(100 - offset * 20)))
                    {
                        if (p.BelongedFaction == null || p.IsVeryCloseTo(leader) || (GameObject.Chance(100 - ((int)p.PersonalLoyalty) * 25 + (5 - offset) * 10) 
                            && GameObject.Chance(220 - p.Loyalty * 2 + (5 - offset) * 20)))
                        {
                            if (p.BelongedFaction != null)
                            {
                                p.ChangeFaction(newFaction);
                            }
                            p.InitialLoyalty();
                            if (p.LocationTroop == null)
                            {
                                p.MoveToArchitecture(newFactionCapital);
                            }
                            else
                            {
                                p.BelongedTroop.ChangeFaction(newFaction);
                            }
                        }
                    }
                }
            }
            ExtensionInterface.call("CreateNewFaction", new Object[] { this, oldFaction, newFaction, newFactionCapital });

            this.YearTable.addNewFactionEntry(this.Date, oldFaction, newFaction, newFactionCapital);
            if (this.OnNewFactionAppear != null)
            {
                this.OnNewFactionAppear(newFaction);
            }
        }

        public int PlayerArchitectureCount
        {
            get
            {
                int r = 0;
                foreach (Faction f in this.Factions)
                {
                    if (this.IsPlayer(f))
                    {
                        r += f.ArchitectureCount;
                    }
                }
                return r;
            }
        }
        /*
        private void OngoingBattleDayEvent()
        {
            List<OngoingBattle> toRemove = new List<OngoingBattle>();
            foreach (OngoingBattle ob in this.AllOngoingBattles)
            {
                ob.CalmDay++;
                if (ob.CalmDay >= 5)
                {
                    Dictionary<Faction, int> factionDamages = new Dictionary<Faction, int>();
                    List<Person> persons = new List<Person>();
                    foreach (Person p in this.Persons)
                    {
                        if (p.Battle == ob && p.BelongedFaction != null) 
                        {
                            persons.Add(p);
                            if (!factionDamages.ContainsKey(p.BelongedFaction))
                            {
                               factionDamages.Add(p.BelongedFaction, 0); 
                            }
                            factionDamages[p.BelongedFaction] += p.BattleSelfDamage;
                        }
                    }

                    ArchitectureList battleArch = ob.Architectures;

                    bool first = true;
                    foreach (Person p in persons)
                    {
                        this.YearTable.addBattleEntry(first, this.Date, ob, p, battleArch, factionDamages);
                        p.Battle = null;
                        first = false;
                    }

                    foreach (Architecture a in battleArch)
                    {
                        a.OldFactionName = a.BelongedFaction == null ? "贼军" : a.BelongedFaction.Name;
                        a.Battle = null;
                    }


                    toRemove.Add(ob);
                }
            }

            foreach (OngoingBattle i in toRemove)
            {
                this.AllOngoingBattles.Remove(i);
            }
        }
        */
        public void DayPassedEvent()
        {
            ExtensionInterface.call("DayEvent", new Object[] { this });

            //this.GameProgressCaution.Text = "开始";
            Parameters.DayEvent(this.PlayerArchitectureCount);

            /*this.ClearPersonStatusCache();
            this.ClearPersonWorkCache();*/

            //clearupRepeatedOfficers();

            
            this.Troops.FinalizeQueue();
            this.Factions.BuildQueue(false);
            this.Architectures.NoFactionDevelop();
            this.FireDayEvent();
            this.NoFoodPositionDayEvent();
            this.NewFaction();

            //this.GameProgressCaution.Text = "运行外交";
            foreach (DiplomaticRelationDisplay display in this.DiplomaticRelations.GetAllDiplomaticRelationDisplayList())
            {
                if (display.Truce > 0)
                {
                    display.Truce--;
                }
            }
            //this.GameProgressCaution.Text = "运行势力";
            //this.OngoingBattleDayEvent();

            foreach (Faction faction in this.Factions.GetRandomList())
            {
                faction.DayEvent();
            }
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.DayEvent();
            }
            foreach (Routeway routeway in this.Routeways.GetRandomList())
            {
                routeway.DayEvent();
            }
            foreach (Legion legion in this.Legions.GetRandomList())
            {
                legion.DayEvent();
                if (legion.Troops.Count == 0)
                {
                    legion.Disband();
                    this.Legions.Remove(legion);
                }
            }
            //this.GameProgressCaution.Text = "运行军队";
            foreach (Troop troop in this.Troops.GetRandomList())
            {
                if (troop.BelongedFaction == null)
                {
                    troop.DayEvent();
                }
            }

            this.detectCurrentPlayerBattleState(this.CurrentPlayer);

            this.militaryKindEvent();
            this.titleDayEvent();
            this.guanzhiDayEvent();


            //this.GameProgressCaution.Text = "运行人物";
            foreach (Person person in this.AvailablePersons.GetList())
            {
                person.PreDayEvent();
            }
            foreach (Person person in this.AvailablePersons.GetRandomList())
            {
                person.DayEvent();
            }
            this.AdjustGlobalPersonRelation();
            this.AddPreparedAvailablePersons();
            /*
            foreach (SpyMessage message in this.SpyMessages.GetRandomList())
            {
                message.DayEvent();
            }
             */
            foreach (Captive captive in this.Captives.GetRandomList())
            {
                captive.DayEvent();
            }
            this.CheckGameEnd();

            this.DaySince++;

            ExtensionInterface.call("PostDayEvent", new Object[] { this });

            this.scenarioJustLoaded = false;
            this.GameScreen.LoadScenarioInInitialization = false;
            numberOfAmbushTroop = -1; // 缓存有几支部队在埋伏，绝大多数时候地图上根本没有埋伏部队，这时候不需要叫浪费时间的函数detectAmbushTroop

            this.GameScreen.DisposeMapTileMemory();
        }
        
       

        private void militaryKindEvent()
        {
            foreach (MilitaryKind m in this.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
            {
                if (m.Persons.Count > 0 && m.ObtainProb > 0)
                {
                    foreach (Person p in m.Persons)
                    {
                        if (GameObject.Random(m.ObtainProb) == 0) {
                            if (p.BelongedFaction != null && !p.BelongedFaction.BaseMilitaryKinds.MilitaryKinds.ContainsValue(m))
                            {
                                p.BelongedFaction.BaseMilitaryKinds.AddMilitaryKind(m);
                                this.GameScreen.xianshishijiantupian(p, m.Name, TextMessageKind.ObtainMilitaryKind, "ObtainMilitaryKind", "", "", false);
                            }
                        }
                    }
                }
            }
        }
        
        private void guanzhiDayEvent()
        {

            List<Title> ManualAwardTitles = new List<Title>();
            foreach (Title t in this.GameCommonData.AllTitles.Titles.Values)
            {
                if (t.ManualAward)
                {
                    ManualAwardTitles.Add(t);
                }
            }
            foreach (Title t in ManualAwardTitles)
            {
                if (t.AutoLearn > 0 && GameObject.Random(t.AutoLearn) == 0)
                {
                    PersonList candidates = new PersonList();
                    if (t.Persons.Count > 0)
                    {
                        foreach (Person p in t.Persons)
                        {
                            if (p.Available && p.Alive)
                            {
                                candidates.Add(p);
                            }
                        }
                    }
                    else
                    {
                        candidates = this.AvailablePersons;
                    }
                    foreach (Person p in candidates)
                    {
                        if ((!this.IsPlayer(p.BelongedFaction ) || GlobalVariables.PermitManualAwardTitleAutoLearn) && !p.HasHigherLevelTitle(t) && t.CanLearn(p, true))
                        {
                            p.AwardTitle(t);
                        }
                    }
                }
            }
        }
        

        private static Person courier = null;
        private void titleDayEvent()
        {
            if (courier == null)
            {
                courier = (Person) this.Persons.GetGameObject(7200);
            }
            foreach (Title t in this.GameCommonData.AllTitles.Titles.Values)
            {
                if (t.AutoLearn > 0 && GameObject.Random(t.AutoLearn) == 0)
                {
                    PersonList candidates = new PersonList();
                    if (t.Persons.Count > 0)
                    {
                        foreach (Person p in t.Persons)
                        {
                            if (p.Available && p.Alive)
                            {
                                candidates.Add(p);
                            }
                        }
                    }
                    else
                    {
                        candidates = this.AvailablePersons;
                    }
                    foreach (Person p in candidates)
                    {
                        if (!p.HasHigherLevelTitle(t) && t.CanLearn(p, true) && !t.ManualAward)
                        {
                            p.LearnTitle(t);
                            this.GameScreen.AutoLearnTitle(p, courier, t);
                        }
                        else if (p.HasTitle() && t.WillLose(p))
                        {
                            p.LoseTitle();
                        }
                    }
                }
            }
        }

        private void detectCurrentPlayerBattleState(Faction faction)
        {

            if (faction == null) return;
            //defend
            ZhandouZhuangtai originalBattleState = faction.BattleState;
            bool fangshou = false;
            int fightingArchitectureCount = 0;
            foreach (Architecture architecture in faction.Architectures)
            {
                if (architecture.BelongedFaction == null) continue;

                if (architecture.BelongedSection == null || architecture.BelongedSection.AIDetail.AutoRun) continue;

                if (architecture.FindHostileTroopInView())
                {
                    fightingArchitectureCount++;

                    if (!architecture.hostileTroopInViewLastDay)  //如果已经提醒过就不再提醒
                    {
                        //architecture.JustAttacked = true;
                        architecture.BelongedFaction.StopToControl = GlobalVariables.StopToControlOnAttack;
                        architecture.RecentlyAttacked = 5;
                        if (this.GameScreen != null)
                        {
                            this.GameScreen.ArchitectureBeginRecentlyAttacked(architecture);  //提示玩家建筑视野范围内出现敌军。
                        }

                    }
                    architecture.hostileTroopInViewLastDay = true;

                }
                else
                {
                    architecture.hostileTroopInViewLastDay = false;
                }

            }
            if (fightingArchitectureCount == 0)
            {
                fangshou = false;
            }
            else
            {
                fangshou = true;
            }
            //attack
            bool jingong = false;

            foreach (Troop t in faction.Troops)
            {
                if (t.HasHostileArchitectureInView())         //||t.HasHostileTroopInView())
                {
                    jingong = true;
                    break;
                }
            }

            if (!jingong && !fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.和平;
            }
            else if (jingong && !fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.进攻;

            }
            else if (!jingong && fangshou)
            {
                faction.BattleState = ZhandouZhuangtai.防守;

            }
            else
            {
                faction.BattleState = ZhandouZhuangtai.攻守兼备;
            }



            if (originalBattleState != faction.BattleState && this.GameScreen != null)
            {
                this.GameScreen.SwichMusic(this.Date.Season);
            }



        }

        public void DayStartingEvent()
        {
            this.Factions.SetControlling(false);
            foreach (Troop troop in this.Troops.GetList())
            {
                if (troop.BelongedFaction == null || troop.BelongedLegion == null)
                {
                    troop.AI();
                }
            }
            this.Troops.BuildQueue();
            foreach (Architecture architecture in this.Architectures.GetList())
            {
                architecture.HireFinished = false;
                architecture.HasManualHire = false;
                architecture.TodayPersonArriveNote = false;

            }
        }

        public void FireDayEvent()
        {
            List<Point> list = new List<Point>();
            foreach (Point point in this.FireTable.Positions)
            {
                if (GameObject.Chance(Parameters.FireStayProb))
                {
                    list.Add(point);
                }
            }
            foreach (Point point in list)
            {
                this.ClearPositionFire(point);
            }
            list.Clear();
            foreach (Point point in this.FireTable.Positions)
            {
                list.Add(point);
            }
            foreach (Point point in list)
            {
                this.FireSpread(point);
            }
        }

        public void FireSpread(Point position)
        {
            GameArea area = GameArea.GetArea(position, 1, false);
            foreach (Point point in area.Area)
            {
                if ((point != position) && this.IsFireVaild(point, false, MilitaryType.步兵))
                {
                    if (this.PositionIsOnFire(point))
                    {
                        continue;
                    }
                    int chance = 0;
                    switch (this.GetTerrainKindByPosition(position))
                    {
                        case TerrainKind.平原:
                            chance = 3;
                            break;

                        case TerrainKind.草原:
                            chance = 4;
                            break;

                        case TerrainKind.森林:
                            chance = 10;
                            break;

                        case TerrainKind.山地:
                            chance = 6;
                            break;
                    }
                    if (GameObject.Chance((int)(chance * Parameters.FireSpreadProbMultiply)))
                    {
                        this.SetPositionOnFire(point);
                        Troop troopByPosition = this.GetTroopByPosition(point);
                        if (troopByPosition != null)
                        {
                            troopByPosition.BurntBySpreadFire();
                        }
                    }
                }
            }
        }

        public RoutewayList GetActiveRoutewayListByPosition(Point position)
        {
            RoutewayList list = new RoutewayList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return list;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (routeway.IsActive || routeway.IsPointActive(position))
                    {
                        list.Add(routeway);
                    }
                }
            }
            return list;
        }

        public Architecture GetArchitectureByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileArchitecture;
        }

        public Architecture GetArchitectureByPositionNoCheck(Point position)
        {
            return this.MapTileData[position.X, position.Y].TileArchitecture;
        }

        public GameArea GetAreaWithinDistance(Point centre, int distance, bool includingCentre)
        {
            GameArea area = new GameArea();
            for (int i = -distance; i <= distance; i++)
            {
                for (int j = -distance; j <= distance; j++)
                {
                    Point fromPosition = new Point(centre.X + i, centre.Y + j);
                    if ((includingCentre || !(fromPosition == centre)) && (this.GetDistance(fromPosition, centre) <= distance))
                    {
                        area.AddPoint(fromPosition);
                    }
                }
            }
            return area;
        }

        public Point GetClosestPoint(GameArea area, Point fromPosition)
        {
            int simpleDistance = 0, minSimpleDistance = int.MaxValue;
            double distance = 0, minDistance = double.MaxValue;
            Point point = new Point();
            foreach (Point point2 in area.Area)
            {
                simpleDistance = this.GetSimpleDistance(fromPosition, point2);
                if (simpleDistance <= minSimpleDistance)
                {
                    distance = this.GetDistance(fromPosition, point2);
                    if (distance < minDistance)
                    {
                        minSimpleDistance = simpleDistance;
                        minDistance = distance;
                        point = point2;
                    }
                }
            }
            return point;
        }

        public void GetClosestPointsBetweenTwoAreas(GameArea area1, GameArea area2, out Point? out1, out Point? out2)
        {
            out1 = null;
            out2 = null;
            int simpleDistance = 0, minSimpleDistance = int.MaxValue;
            double distance = 0, minDistance = double.MaxValue;
            foreach (Point point in area1.Area)
            {
                foreach (Point point2 in area2.Area)
                {
                    simpleDistance = this.GetSimpleDistance(point, point2);
                    if (simpleDistance <= minSimpleDistance)
                    {
                        distance = this.GetDistance(point, point2);
                        if (distance < minDistance)
                        {
                            minSimpleDistance = simpleDistance;
                            minDistance = distance;
                            out1 = new Point?(point);
                            out2 = new Point?(point2);
                        }
                    }
                }
            }
        }

        public Point? GetClosestPosition(GameArea area, List<Point> orientations)
        {
            Point? nullable = null;
            int num = 0x7fffffff;
            foreach (Point point in area.Area)
            {
                int num2 = 0;
                foreach (Point point2 in orientations)
                {
                    num2 += this.GetSimpleDistance(point, point2);
                }
                if (num2 < num)
                {
                    num = num2;
                    nullable = new Point?(point);
                }
            }
            return nullable;
        }

        public string GetCoordinateString(Point position)
        {
            return (position.X + "," + position.Y);
        }

        public int GetDiplomaticRelation(int faction1, int faction2)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(this, faction1, faction2);
                if (diplomaticRelation != null)
                {
                    return diplomaticRelation.Relation;
                }
            }
            return 0;
        }

        public int GetDiplomaticRelationTruce(int faction1, int faction2)
        {
            if (faction1 != faction2)
            {
                DiplomaticRelation diplomaticRelation = this.DiplomaticRelations.GetDiplomaticRelation(this, faction1, faction2);
                if (diplomaticRelation != null)
                {
                    return diplomaticRelation.Truce;
                }
            }
            return 0;
        }

        public double GetResourceConsumptionRate(Architecture a, Troop b)
        {
            return this.GetDistance(b.Position, a.ArchitectureArea) / 50.0 + 1;
        }

        public double GetResourceConsumptionRate(Architecture a, Architecture b)
        {
            return this.GetDistance(a.ArchitectureArea, b.ArchitectureArea) / 150.0 + 1;
        }

        public double GetDistance(GameArea fromArea, GameArea toArea)
        {
            // 上面这段浪费太多时间O(n^2)，下面仅需要O(1)，一个非常近似的值已经足够
            double distance = GetDistance(fromArea.Centre, toArea.Centre);

            if (distance < 0) return 0;

            distance -= (1 + Math.Sqrt(2 * fromArea.Count + 1)) / 2;
            distance -= (1 + Math.Sqrt(2 * toArea.Count + 1)) / 2;

            return distance;
        }

        public double GetDistance(Point fromPosition, GameArea toArea)
        {
            // O(1) instead of O(n)
            double distance = GetDistance(fromPosition, toArea.Centre);

            distance -= (1 + Math.Sqrt(2 * toArea.Count + 1)) / 2;

            return distance;
        }

        public double GetDistance(Point fromPosition, Point toPosition)
        {
            return Math.Sqrt(Math.Pow(toPosition.X - fromPosition.X, 2) + Math.Pow(toPosition.Y - fromPosition.Y, 2));
        }

        public Point? GetFarthestPosition(GameArea area, List<Point> orientations)
        {
            Point? nullable = null;
            int num = -2147483648;
            foreach (Point point in area.Area)
            {
                int num2 = 0;
                foreach (Point point2 in orientations)
                {
                    num2 += this.GetSimpleDistance(point, point2);
                }
                if (num2 > num)
                {
                    num = num2;
                    nullable = new Point?(point);
                }
            }
            return nullable;
        }

        public static string GetGameSaveFileSurveyText(string connectionString)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select * From GameSurvey", connection);
                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = reader["PlayerInfo"].ToString() + "  ";
                object obj2 = str;
                str = string.Concat(new object[] { obj2, reader["Title"].ToString(), " ", (short)reader["GYear"], "年", (short)reader["GMonth"], "月", (short)reader["GDay"], "日  " });
                str = str + reader["SaveTime"].ToString();
                connection.Close();
            }
            catch
            {
                connection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public static string GetGameScenarioDescription(OleDbConnection DbConnection)
        {
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select Description From GameSurvey", DbConnection);
                DbConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = reader["Description"].ToString();
                DbConnection.Close();
            }
            catch
            {
                DbConnection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public static FactionList GetGameScenarioFactions(OleDbConnection DbConnection)
        {
            DbConnection.Open();
            OleDbDataReader reader = new OleDbCommand("Select * From Faction", DbConnection).ExecuteReader();
            FactionList list = new FactionList();
            while (reader.Read())
            {
                Faction t = new Faction();
                t.ID = (short)reader["ID"];
                t.LeaderID = (short)reader["LeaderID"];
                t.Name = reader["FName"].ToString();
                try
                {
                    if (!((bool)reader["NotPlayerSelectable"]))
                    {
                        list.Add(t);
                    }
                }
                catch
                {
                    list.Add(t);
                }
            }
            DbConnection.Close();
            return list;
        }

        public static string GetGameScenarioSurveyText(OleDbConnection DbConnection)
        {
            string str = "";
            try
            {
                OleDbCommand command = new OleDbCommand("Select * From GameSurvey", DbConnection);
                DbConnection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
                str = string.Concat(new object[] { reader["Title"].ToString(), " ", (short)reader["GYear"], "年", (short)reader["GMonth"], "月", (short)reader["GDay"], "日  " });
                DbConnection.Close();
            }
            catch
            {
                DbConnection.Close();
                str = str + "已损坏的文件";
            }
            return str;
        }

        public ArchitectureList GetHighViewingArchitecturesByPosition(Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].HighViewingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].HighViewingArchitectures)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public string GetPlayerInfo()
        {
            if (this.CurrentPlayer != null)
            {
                if (this.PlayerFactions.Count > 1)
                {
                    return (this.CurrentPlayer.Name + " 等");
                }
                if (this.PlayerFactions.Count == 1)
                {
                    return this.CurrentPlayer.Name;
                }
                return "电脑";
            }
            return "电脑";
        }

        public Texture2D GetPortrait(int id)
        {
            return this.GameScreen.GetPortrait(id);
        }

        public int GetPositionHostileOffencingDiscredit(Troop troop, Point position)
        {
            return this.MapTileData[position.X, position.Y].GetPositionHostileOffencingDiscredit(troop);
        }

        public int GetPositionMapCost(Faction faction, Point position)
        {
            Architecture architectureByPositionNoCheck = this.GetArchitectureByPositionNoCheck(position);
            if (architectureByPositionNoCheck != null)
            {
                if ((architectureByPositionNoCheck.Endurance > 0) && (architectureByPositionNoCheck.BelongedFaction != faction))
                {
                    return 0xdac;
                }
                return 5;
            }
            Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
            if (troopByPositionNoCheck != null)
            {
                if (!((faction != null) && faction.IsFriendly(troopByPositionNoCheck.BelongedFaction)))
                {
                    return 0xdac;
                }
                return 0;
            }
            if (this.PositionIsOnFire(position))
            {
                return 10;
            }
            return 0;
        }

        public Point GetProperDestination(Point from, Point to)
        {
            double distance = this.GetDistance(from, to);
            if (distance > 15.0)
            {
                return new Point(from.X + ((int)(((double)((to.X - from.X) * 15)) / distance)), from.Y + ((int)(((double)((to.Y - from.Y) * 15)) / distance)));
            }
            return to;
        }

        public int GetReturnDays(Point destination, GameArea fromArea)
        {
            int num = (int)Math.Ceiling((double)(this.GetDistance(destination, this.GetClosestPoint(fromArea, destination)) / 10.0));
            num *= 2;
            if (num == 0)
            {
                num = 1;
            }
            return num;
        }

        public ArchitectureList GetRoutewayArchitecturesByPosition(Routeway routeway, Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                foreach (Architecture architecture in routeway.BelongedFaction.Architectures)
                {
                    if ((architecture != routeway.StartArchitecture) && architecture.GetRoutewayStartArea().HasPoint(position))
                    {
                        list.Add(architecture);
                    }
                }
            }
            return list;
        }

        public Routeway GetRoutewayByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            if (this.MapTileData[position.X, position.Y].TileRouteways == null)
            {
                return null;
            }
            if (this.MapTileData[position.X, position.Y].TileRouteways.Count == 0)
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileRouteways[0];
        }

        public Routeway GetRoutewayByPositionAndFaction(Point position, Faction faction)
        {
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return null;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (((routeway.BelongedFaction == faction) && (routeway.StartArchitecture != null)) && ((((routeway.DestinationArchitecture == null) || !routeway.StartArchitecture.BelongedSection.AIDetail.AutoRun) || routeway.Building) || (routeway.LastActivePointIndex >= 0)))
                    {
                        return routeway;
                    }
                }
            }
            return null;
        }

        public List<Routeway> GetRoutewaysByPositionAndFaction(Point position, Faction faction)
        {
            List<Routeway> list = new List<Routeway>();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].TileRouteways == null)
                {
                    return list;
                }
                foreach (Routeway routeway in this.MapTileData[position.X, position.Y].TileRouteways)
                {
                    if (routeway.BelongedFaction == faction)
                    {
                        list.Add(routeway);
                    }
                }
            }
            return list;
        }

        public int GetSimpleDistance(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        public int GetSingleWayDays(Point destination, GameArea fromArea)
        {
            int num = (int)Math.Ceiling((double)(this.GetDistance(destination, this.GetClosestPoint(fromArea, destination)) / 10.0));
            if (num == 0)
            {
                num = 1;
            }
            return num;
        }

        public Texture2D GetSmallPortrait(int id)
        {
            return this.GameScreen.GetSmallPortrait(id);
        }

        public ArchitectureList GetSupplyArchitecturesByPositionAndFaction(Point position, Faction faction)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].SupplyingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].SupplyingArchitectures)
                {
                    //if (faction.IsFriendly(architecture.BelongedFaction))
                    if (faction == architecture.BelongedFaction)
                    {
                        list.Add(architecture);
                    }
                }
            }
            return list;
        }

        public List<RoutePoint> GetSupplyRoutePointsByPositionAndFaction(Point position, Faction faction)
        {
            List<RoutePoint> list = new List<RoutePoint>();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].SupplyingRoutePoints == null)
                {
                    return list;
                }
                foreach (RoutePoint point in this.MapTileData[position.X, position.Y].SupplyingRoutePoints)
                {
                    if (point.BelongedRouteway.IsSupporting(faction))
                    {
                        list.Add(point);
                    }
                }
            }
            return list;
        }

        public TerrainDetail GetTerrainDetailByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]);
        }

        public TerrainDetail GetTerrainDetailByPositionNoCheck(Point position)
        {
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]);
        }

        public TerrainKind GetTerrainKindByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return TerrainKind.无;
            }
            return (TerrainKind)this.ScenarioMap.MapData[position.X, position.Y];
        }

        public TerrainKind GetTerrainKindByPositionNoCheck(Point position)
        {
            return (TerrainKind)this.ScenarioMap.MapData[position.X, position.Y];
        }

        public string GetTerrainNameByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return "----";
            }
            return this.GameCommonData.AllTerrainDetails.GetTerrainDetail(this.ScenarioMap.MapData[position.X, position.Y]).Name;
        }

        public int GetTransferFundDays(Architecture from, Architecture to)
        {
            return (int)Math.Ceiling(this.GetDistance(from.ArchitectureArea, to.ArchitectureArea) / 2.5);
        }


        public Troop GetTroopByPosition(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return null;
            }
            return this.MapTileData[position.X, position.Y].TileTroop;
        }

        public Troop GetTroopByPositionNoCheck(Point position)
        {
            return this.MapTileData[position.X, position.Y].TileTroop;
        }

        public ArchitectureList GetViewingArchitecturesByPosition(Point position)
        {
            ArchitectureList list = new ArchitectureList();
            if (!this.PositionOutOfRange(position))
            {
                if (this.MapTileData[position.X, position.Y].ViewingArchitectures == null)
                {
                    return list;
                }
                foreach (Architecture architecture in this.MapTileData[position.X, position.Y].ViewingArchitectures)
                {
                    list.Add(architecture);
                }
            }
            return list;
        }

        public int GetWaterPositionMapCost(MilitaryKind kind, Point position)
        {
            if (this.ScenarioMap.MapData[position.X, position.Y] == 6)
            {
                if (GlobalVariables.LandArmyCanGoDownWater)
                {
                    return 0;
                }

                if (this.GetArchitectureByPositionNoCheck(position) != null)
                {
                    return 0;
                }
                if (kind.Type == MilitaryType.水军)
                {
                    return 0;
                }
                int num = 0;
                Point point = new Point(position.X - 1, position.Y);
                if (!(this.PositionOutOfRange(point) || (this.ScenarioMap.MapData[point.X, point.Y] != 6)))
                {
                    num++;
                }
                Point point2 = new Point(position.X, position.Y - 1);
                if (!(this.PositionOutOfRange(point2) || (this.ScenarioMap.MapData[point2.X, point2.Y] != 6)))
                {
                    num++;
                }
                Point point3 = new Point(position.X + 1, position.Y);
                if (!(this.PositionOutOfRange(point3) || (this.ScenarioMap.MapData[point3.X, point3.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return 0xdac;
                }
                Point point4 = new Point(position.X, position.Y + 1);
                if (!(this.PositionOutOfRange(point4) || (this.ScenarioMap.MapData[point4.X, point4.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return 0xdac;
                }
            }
            else
            {
                if (kind.Type != MilitaryType.水军 || kind.IsShell || kind.IsTransport)
                {
                    return 0;
                }

                Architecture a = this.GetArchitectureByPositionNoCheck(position);
                if (a != null && !a.Kind.ShipCanEnter)
                {
                    return 0xdac;
                }
            }
            return 0;
        }

        private bool HasSameIdealFaction(Person person)
        {
            if ((person.BelongedFaction != null) && (person.BelongedFaction.Leader == person))
            {
                return true;
            }
            foreach (Faction faction in this.Factions)
            {
                if ((faction.Leader != null) && (faction.Leader.Ideal == person.Ideal))
                {
                    return true;
                }
            }
            return false;
        }

        public int HostileContactingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileContactingTroopsCount(faction);
        }

        public int HostileOffencingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileOffencingTroopsCount(faction);
        }

        public int HostileViewingTroopsCount(Faction faction, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return 0;
            }
            return this.MapTileData[position.X, position.Y].HostileViewingTroopsCount(faction);
        }

        public void InitialGameData()
        {
            Parameters.DayEvent(this.PlayerArchitectureCount);
            this.InitializeSectionData();
            this.InitializeRoutewayData();
            this.InitializeArchitectureData();
            this.InitializeMilitariesData();
            this.InitializeTroopData();
            this.InitializeCaptiveData();
            this.InitializePersonData();
            //this.InitializeSpyMessageData();

            foreach (Person p in this.Persons)
            {
                foreach (Title t in p.UniqueTitles.Titles.Values)
                {
                    t.Persons.Add(p);
                }
                foreach (MilitaryKind m in p.UniqueMilitaryKinds.MilitaryKinds.Values)
                {
                    m.Persons.Add(p);
                }
            }
            /*
            this.GameProgressCaution = new GameFreeText.FreeText(this.GameScreen.spriteBatch.GraphicsDevice,new System.Drawing.Font("宋体", 16f), new Color(1f, 1f, 1f));
            this.GameProgressCaution.Text = "——";
            this.GameProgressCaution.Align=TextAlign.Middle;
            */
        }

        private void InitializeArchitectureMapTile()
        {
            foreach (Architecture architecture in this.Architectures)
            {
                foreach (Point point in architecture.ArchitectureArea.Area)
                {
                    this.MapTileData[point.X, point.Y].TileArchitecture = architecture;
                }
            }
            foreach (Architecture architecture in this.Architectures)
            {
                this.SetMapTileArchitecture(architecture);
            }
        }

        private void InitializeArchitectureData()
        {
            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.PlanArchitectureID >= 0)
                {
                    architecture.PlanArchitecture = this.Architectures.GetGameObject(architecture.PlanArchitectureID) as Architecture;
                }
                if (architecture.TransferFundArchitectureID >= 0)
                {
                    architecture.TransferFundArchitecture = this.Architectures.GetGameObject(architecture.TransferFundArchitectureID) as Architecture;
                }
                if (architecture.TransferFoodArchitectureID >= 0)
                {
                    architecture.TransferFoodArchitecture = this.Architectures.GetGameObject(architecture.TransferFoodArchitectureID) as Architecture;
                }
                if (architecture.DefensiveLegionID >= 0)
                {
                    architecture.DefensiveLegion = this.Legions.GetGameObject(architecture.DefensiveLegionID) as Legion;
                }
                if (architecture.RobberTroopID >= 0)
                {
                    architecture.RobberTroop = this.Troops.GetGameObject(architecture.RobberTroopID) as Troop;
                }
            }

            bool redoLinks = false;
            foreach (Architecture architecture2 in this.Architectures)
            {
                architecture2.LoadAILandLinksFromString(this.Architectures, architecture2.AILandLinksString);
                architecture2.LoadAIWaterLinksFromString(this.Architectures, architecture2.AIWaterLinksString);
            }
            foreach (Architecture architecture2 in this.Architectures)
            {
                if (architecture2.AILandLinks.Count == 0 && architecture2.AIWaterLinks.Count == 0)
                {
                    redoLinks = true;
                    break;
                }
            }
            if (redoLinks)
            {
                foreach (Architecture architecture2 in this.Architectures)
                {
                    architecture2.AILandLinks.Clear();
                    architecture2.AIWaterLinks.Clear();
                }
                foreach (Architecture architecture2 in this.Architectures)
                {
                    architecture2.FindLinks(this.Architectures);
                }
            }

            foreach (Architecture architecture in this.Architectures)
            {
                if (architecture.BelongedFaction != null)
                {
                    architecture.CheckIsFrontLine();
                }
                architecture.GenerateAllAILinkNodes(2);
            }

            /*foreach (Architecture a in this.Architectures)
            {
                foreach (LinkNode i in a.AILandLinks)
                {
                    Point? p1;
                    Point? p2;
                    this.GetClosestPointsBetweenTwoAreas(a.ArchitectureArea, i.A.ArchitectureArea, out p1, out p2);

                    if (p1 != null && p2 != null){
                        Military m = new Military();
                        Troop t = new Troop();

                        t.pathFinder.GetFirstTierPath(p1.Value, p2.Value);
                        this.pathCache[new PathCacheKey(a, i.A)] = new List<Point>(t.FirstTierPath);
                    }
                }
            }*/
        }

        private void InitializeCaptiveData()
        {
            foreach (Captive captive in this.Captives)
            {
                if (captive.CaptiveFactionID >= 0)
                {
                    captive.CaptiveFaction = this.Factions.GetGameObject(captive.CaptiveFactionID) as Faction;
                }
                if (captive.RansomArchitectureID >= 0)
                {
                    captive.RansomArchitecture = this.Architectures.GetGameObject(captive.RansomArchitectureID) as Architecture;
                }
            }
        }

        private void InitializeFactionData()
        {
            foreach (Faction faction in this.Factions)
            {
                faction.PrepareData();
            }
        }

        private void InitializeMapData()
        {
            this.MapTileData = new TileData[this.ScenarioMap.MapDimensions.X, this.ScenarioMap.MapDimensions.Y];
            this.PenalizedMapData = new int[this.ScenarioMap.MapDimensions.X, this.ScenarioMap.MapDimensions.Y];
        }

        private void InitializeMilitaryData()
        {
            foreach (Military military in this.Militaries)
            {
                if (military.ShelledMilitaryID >= 0)
                {
                    military.SetShelledMilitary(this.Militaries.GetGameObject(military.ShelledMilitaryID) as Military);
                }


            }
        }

        private void InitializePersonData()
        {
            foreach (Person person in this.Persons)
            {
                if (person.ConvincingPersonID >= 0)
                {
                    person.ConvincingPerson = this.Persons.GetGameObject(person.ConvincingPersonID) as Person;
                }
            }
        }

        private void InitializeRoutewayData()
        {
            foreach (Routeway routeway in this.Routeways)
            {
                routeway.RefreshRoutewayPointsData();
            }
        }

        public void InitializeScenarioPlayerFactions(List<int> factionIDs)
        {
            this.PlayerFactions.LoadFromString(this.Factions, StaticMethods.SaveToString(factionIDs));
        }

        private void InitializeSectionData()
        {
            foreach (Section section in this.Sections)
            {
                if (section.OrientationFactionID >= 0)
                {
                    section.OrientationFaction = this.Factions.GetGameObject(section.OrientationFactionID) as Faction;
                }
                if (section.OrientationSectionID >= 0)
                {
                    section.OrientationSection = this.Sections.GetGameObject(section.OrientationSectionID) as Section;
                }
                if (section.OrientationStateID >= 0)
                {
                    section.OrientationState = this.States.GetGameObject(section.OrientationStateID) as State;
                }
                if (section.OrientationArchitectureID >= 0)
                {
                    section.OrientationArchitecture = this.Architectures.GetGameObject(section.OrientationArchitectureID) as Architecture;
                }
            }
        }

        /*
        private void InitializeSpyMessageData()
        {
            foreach (SpyMessage message in this.SpyMessages)
            {
                if (message.MessageFactionID >= 0)
                {
                    message.MessageFaction = this.Factions.GetGameObject(message.MessageFactionID) as Faction;
                }
                if (message.MessageArchitectureID >= 0)
                {
                    message.MessageArchitecture = this.Architectures.GetGameObject(message.MessageArchitectureID) as Architecture;
                }
            }
        }
        */

        private void InitializeTroopData()
        {
            TroopList toRemove = new TroopList();
            foreach (Troop troop in this.Troops)
            {
                if (troop.Leader == null || troop.Army == null || troop.Army.Kind == null)
                {
                    toRemove.Add(troop);
                }
                else if (troop.Persons.Count == 0)
                {
                    troop.Leader.LocationTroop = troop;
                }
            }
            foreach (Troop troop in toRemove)
            {
                if (troop.BelongedFaction != null)
                {
                    troop.BelongedFaction.RemoveTroop(troop);
                }
                this.Troops.Remove(troop);
            }

            foreach (Troop troop in this.Troops)
            {
                troop.Initialize();
            }
            foreach (TroopEvent event2 in this.TroopEvents)
            {
                if (event2.AfterEventHappened >= 0)
                {
                    event2.AfterHappenedEvent = this.TroopEvents.GetGameObject(event2.AfterEventHappened) as TroopEvent;
                }
            }
        }

        private void InitializeMilitariesData()
        {
            MilitaryList toRemove = new MilitaryList();
            foreach (Military military in this.Militaries)
            {
                if (military.Kind == null)
                {
                    toRemove.Add(military);
                }
            }
            foreach (Military military in toRemove)
            {
                if (military.BelongedArchitecture != null)
                {
                    military.BelongedArchitecture.RemoveMilitary(military);
                }
                this.Militaries.Remove(military);
            }
        }

        public bool IsCurrentPlayer(Faction faction)
        {
            return (this.CurrentPlayer == faction);
        }

        public bool IsFireVaild(Point position, bool typevalid, MilitaryType type)
        {
            if (this.GetArchitectureByPosition(position) != null)
            {
                return false;
            }
            TerrainKind terrainKindByPosition = this.GetTerrainKindByPosition(position);
            return (((typevalid && (type == MilitaryType.水军)) && (terrainKindByPosition == TerrainKind.水域)) || ((((terrainKindByPosition == TerrainKind.平原) || (terrainKindByPosition == TerrainKind.草原)) || (terrainKindByPosition == TerrainKind.森林)) || (terrainKindByPosition == TerrainKind.山地)));
        }

        public bool IsLastPlayer(Faction faction)
        {
            if (faction == null)
            {
                return false;
            }
            foreach (Faction faction2 in this.PlayerFactions)
            {
                if ((faction2 != faction) && !faction2.Passed)
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPlayer(Faction faction)
        {
            return ((faction != null) && (this.PlayerFactions.GetGameObject(faction.ID) != null));
        }

        public bool IsPlayerControlling()
        {
            return (((this.CurrentPlayer != null) && (this.CurrentFaction == this.CurrentPlayer)) && this.CurrentPlayer.Controlling);
        }

        public bool IsPositionDisplayable(Point position)
        {
            return (this.GameScreen.TileInScreen(position) && ((GlobalVariables.SkyEye || (this.CurrentPlayer == null)) || this.CurrentPlayer.IsPositionKnown(position)));
        }

        public bool IsPositionEmpty(Point position)
        {
            if (this.PositionIsArchitecture(position))
            {
                return false;
            }
            if (this.PositionIsTroop(position))
            {
                return false;
            }
            return true;
        }

        public bool IsPositionMovable(Point position, Faction faction)
        {
            if (this.PositionIsTroop(position))
            {
                return false;
            }
            Architecture architectureByPosition = this.GetArchitectureByPosition(position);
            return ((architectureByPosition == null) || (architectureByPosition.BelongedFaction == faction));
        }

        public bool IsTheBottomTroop(Troop troop)
        {
            return (this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop == troop);
        }

        public bool IsTroopViewingPosition(Troop troop, Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return false;
            }
            return this.MapTileData[position.X, position.Y].IsTroopViewing(troop);
        }

        public bool IsWaterPositionRoutewayable(Point position)
        {
            if (this.ScenarioMap.MapData[position.X, position.Y] == 6)
            {
                int num = 0;
                Point point = new Point(position.X - 1, position.Y);
                if (!(this.PositionOutOfRange(point) || (this.ScenarioMap.MapData[point.X, point.Y] != 6)))
                {
                    num++;
                }
                Point point2 = new Point(position.X, position.Y - 1);
                if (!(this.PositionOutOfRange(point2) || (this.ScenarioMap.MapData[point2.X, point2.Y] != 6)))
                {
                    num++;
                }
                Point point3 = new Point(position.X + 1, position.Y);
                if (!(this.PositionOutOfRange(point3) || (this.ScenarioMap.MapData[point3.X, point3.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return false;
                }
                Point point4 = new Point(position.X, position.Y + 1);
                if (!(this.PositionOutOfRange(point4) || (this.ScenarioMap.MapData[point4.X, point4.Y] != 6)))
                {
                    num++;
                }
                if (num > 2)
                {
                    return false;
                }
            }
            return true;
        }

        public bool SaveAvail()
        {
            return (this.IsPlayerControlling() && this.EnableLoadAndSave && !GlobalVariables.HardcoreMode);
        }

        public bool LoadAvail()
        {
            return (this.IsPlayerControlling() && this.EnableLoadAndSave && !GlobalVariables.HardcoreMode);
        }

        public bool isInCaptiveList(int personId)
        {
            foreach (Captive i in this.Captives)
            {
                if (i.CaptivePerson.ID == personId)
                {
                    return true;
                }
            }

            return false;
        }

        public void LoadCommonData()
        {
            this.GameCommonData.LoadFromDatabase(GetCommonDataConnectionString(), this);
        }

        private String GetCommonDataConnectionString()
        {
            string path = System.Windows.Forms.Application.StartupPath + "/GameData/Common/CommonData.mdb";
            if (!System.IO.File.Exists(path))
            {
                throw new Exception(path + " .File Does Not Exist.");
            }
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = path,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            return builder.ConnectionString;
        }

        private void LoadSettingsFromDatabase(string connectionString)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);

            try
            {
                connection.Open();
                OleDbDataReader reader = new OleDbCommand("Select * From GameParameters", connection).ExecuteReader();
                while (reader.Read())
                {
                    String name = (String)reader["Name"];
                    String rawValue = (String)reader["Value"];

                    foreach (FieldInfo i in typeof(Parameters).GetFields(BindingFlags.Public | BindingFlags.Static))
                    {
                        if (i.IsLiteral) continue;

                        if (GlobalVariables.getFieldsExcludedFromSave().Contains(i.Name)) continue;

                        if (i.Name.Equals(name))
                        {
                            if (name.Equals("ExpandConditions"))
                            {
                                List<int> result = new List<int>();
                                StaticMethods.LoadFromString(result, rawValue);
                                i.SetValue(null, result);
                            }
                            else
                            {
                                int outInt;
                                float outDouble;
                                bool outBool;
                                if (int.TryParse(rawValue, out outInt))
                                {
                                    i.SetValue(null, outInt);
                                }
                                else if (float.TryParse(rawValue, out outDouble))
                                {
                                    i.SetValue(null, outDouble);
                                }
                                else if (bool.TryParse(rawValue, out outBool))
                                {
                                    i.SetValue(null, outBool);
                                }
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }

            try
            {
                connection.Open();
                OleDbDataReader reader = new OleDbCommand("Select * From GlobalVariables", connection).ExecuteReader();
                while (reader.Read())
                {
                    String name = (String)reader["Name"];
                    String rawValue = (String)reader["Value"];

                    foreach (FieldInfo i in typeof(GlobalVariables).GetFields(BindingFlags.Public | BindingFlags.Static))
                    {
                        if (i.IsLiteral) continue;

                        if (GlobalVariables.getFieldsExcludedFromSave().Contains(i.Name)) continue;

                        if (i.Name == name)
                        {
                            int outInt;
                            float outDouble;
                            bool outBool;
                            if (int.TryParse(rawValue, out outInt))
                            {
                                i.SetValue(null, outInt);
                            }
                            else if (float.TryParse(rawValue, out outDouble))
                            {
                                i.SetValue(null, outDouble);
                            }
                            else if (bool.TryParse(rawValue, out outBool))
                            {
                                i.SetValue(null, outBool);
                            }
                            break;
                        }
                    }
                }
            }
            catch
            {
            }
            finally
            {
                connection.Close();
            }
        }

        private List<string> LoadGameDataFromDataBase(OleDbConnection DbConnection, string connectionString, bool fromScenario)  //读剧本和读存档都调用了此函数
        {
            List<string> errorMsg = new List<string>();

            String commonConnString = this.GetCommonDataConnectionString();
            OleDbConnection commonConn = new OleDbConnection(commonConnString);

            UsingOwnCommonData = true;
           /* try
            {
                errorMsg.AddRange(this.GameCommonData.LoadGuanzhiKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadGuanzhiKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadGuanzhi(DbConnection, this));
            }
            catch 
            {
                errorMsg.AddRange(this.GameCommonData.LoadGuanzhi(commonConn, this));
                UsingOwnCommonData = false;
            }
            */
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadPersonGeneratorSetting(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadPersonGeneratorSetting(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadPersonGeneratorTypes(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadPersonGeneratorTypes(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTerrainDetail(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTerrainDetail(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadColor(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadColor(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadIdealTendencyKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadIdealTendencyKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadCharacterKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadCharacterKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadArchitectureKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadArchitectureKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadSectionAIDetail(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadSectionAIDetail(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadInfluenceKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadInfluenceKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadInfluence(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadInfluence(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadConditionKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadConditionKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadCondition(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadCondition(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopEventEffectKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopEventEffectKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopEventEffect(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopEventEffect(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadEventEffectKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadEventEffectKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadEventEffect(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadEventEffect(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadFacilityKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadFacilityKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadDisasterKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadDisasterKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadOfficeKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadOfficeKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTechnique(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTechnique(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadSkill(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadSkill(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTitleKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTitleKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTitle(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTitle(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadMilitaryKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadMilitaryKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadInformationKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadInformationKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadAttackDefaultKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadAttackDefaultKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadAttackTargetKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadAttackTargetKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadCombatMethodKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadCombatMethodKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadStunt(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadStunt(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadCastDefaultKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadCastDefaultKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadCastTargetKind(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadCastTargetKind(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadStratagem(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadStratagem(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopAnimation(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTroopAnimation(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTileAnimation(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTileAnimation(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadTextMessage(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadTextMessage(commonConn, this));
                UsingOwnCommonData = false;
            }
            try
            {
                errorMsg.AddRange(this.GameCommonData.LoadBiographyAdjectives(DbConnection, this));
            }
            catch
            {
                errorMsg.AddRange(this.GameCommonData.LoadBiographyAdjectives(commonConn, this));
                UsingOwnCommonData = false;
            }

            DbConnection.Close();

            this.LoadSettingsFromDatabase(connectionString);

            ExtensionInterface.loadCompiledTypes();

            this.scenarioJustLoaded = true;
            OleDbDataReader reader;

            OleDbCommand command = new OleDbCommand("Select * From Map", DbConnection);
            ////////////////////////////////////////////////////////////////////////////////////////////
            DbConnection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            this.ScenarioMap.MapName = reader["FileName"].ToString();
            this.ScenarioMap.TileWidth = (short)reader["TileWidth"];
            try
            {
                this.ScenarioMap.NumberOfTiles = (short)reader["kuaishu"];
                this.ScenarioMap.NumberOfSquaresInEachTile = (short)reader["meikuaidexiaokuaishu"];
                this.ScenarioMap.UseSimpleArchImages = (bool)reader["useSimpleArchImages"];
            }
            catch
            {
                this.ScenarioMap.NumberOfTiles = 20;
                this.ScenarioMap.NumberOfSquaresInEachTile = 10;
                this.ScenarioMap.UseSimpleArchImages = false;
            }
            this.ScenarioMap.LoadMapData(reader["MapData"].ToString(), (short)reader["DimensionX"], (short)reader["DimensionY"]);
            DbConnection.Close();
            ///////////////////////////////////////////////////////////////////////////////////////////
            DbConnection.Open();
            reader = new OleDbCommand("Select * From State", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                State t = new State();
                t.ID = (short)reader["ID"];
                t.Name = reader["Name"].ToString();
                t.ContactStatesString = reader["ContactStates"].ToString();
                t.StateAdminID = (short)reader["StateAdmin"];
                this.States.Add(t);
            }
            DbConnection.Close();
            foreach (State state in this.States)
            {
                List<string> e = state.LoadContactStatesFromString(this.States, state.ContactStatesString);
                if (e.Count > 0)
                {
                    errorMsg.Add("州域ID" + state.ID + "：");
                    errorMsg.AddRange(e);
                }
            }
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Region", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Region region = new Region();
                region.ID = (short)reader["ID"];
                region.Name = reader["Name"].ToString();
                List<string> e = region.LoadStatesFromString(this.States, reader["States"].ToString());
                if (e.Count > 0)
                {
                    errorMsg.Add("地区ID" + region.ID + "：");
                    errorMsg.AddRange(e);
                }
                region.RegionCoreID = (short)reader["RegionCore"];
                this.Regions.Add(region);
            }
            DbConnection.Close();
            /*
            DbConnection.Open();
            try
            {
                reader = new OleDbCommand("Select * From OngoingBattle", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    OngoingBattle b = new OngoingBattle();
                    b.Scenario = this;
                    b.ID = (int)reader["ID"];
                    b.StartDay = (short)reader["StartDay"];
                    b.StartMonth = (short)reader["StartMonth"];
                    b.StartYear = (int)reader["StartYear"];
                    b.CalmDay = (int)reader["CalmDay"];
                    b.Skirmish = (bool)reader["Skirmish"];
                    AllOngoingBattles.Add(b);
                }
            }
            catch (OleDbException)
            {
                //ignore
            }
            DbConnection.Close();
             */
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Person", DbConnection).ExecuteReader();
            Dictionary<int, int> fatherIds = new Dictionary<int, int>();
            Dictionary<int, int> motherIds = new Dictionary<int, int>();
            Dictionary<int, int> spouseIds = new Dictionary<int, int>();
            Dictionary<int, int[]> brotherIds = new Dictionary<int, int[]>();
            Dictionary<int, int[]> closeIds = new Dictionary<int, int[]>();
            Dictionary<int, int[]> hatedIds = new Dictionary<int, int[]>();
            while (reader.Read())
            {
                List<string> errors = new List<string>();

                Person person = new Person();
                person.Scenario = this;
                person.ID = (short)reader["ID"];
                person.Available = (bool)reader["Available"];
                person.Alive = (bool)reader["Alive"];
                person.SurName = reader["SurName"].ToString();
                person.GivenName = reader["GivenName"].ToString();
                person.CalledName = reader["CalledName"].ToString();
                person.Sex = (bool)reader["Sex"];
                person.PictureIndex = (short)reader["Pic"];
                person.Ideal = (short)reader["Ideal"];
                person.IdealTendency = this.GameCommonData.AllIdealTendencyKinds.GetGameObject((short)reader["IdealTendency"]) as IdealTendencyKind;
                if (person.IdealTendency == null)
                {
                    errors.Add("出仕相性考虑ID" + (short)reader["IdealTendency"] + "不存在");
                }
                person.LeaderPossibility = (bool)reader["LeaderPossibility"];
                person.Character = this.GameCommonData.AllCharacterKinds[(short)reader["PCharacter"]];
                if (person.Character == null)
                {
                    errors.Add("性格ID" + (short)reader["PCharacter"] + "不存在");
                }
                person.YearAvailable = (short)reader["YearAvailable"];
                person.YearBorn = (short)reader["YearBorn"];
                person.YearDead = (short)reader["YearDead"];
                if ((short)reader["DeadReason"] >= Enum.GetNames(typeof(PersonDeadReason)).Length || (short)reader["DeadReason"] < 0)
                {
                    errors.Add("人物死亡原因必须在0至" + Enum.GetNames(typeof(PersonDeadReason)).Length + "之间");
                }
                else
                {
                    person.DeadReason = (PersonDeadReason)((short)reader["DeadReason"]);
                }
                person.BaseStrength = (short)reader["Strength"];
                person.BaseCommand = (short)reader["Command"];
                person.BaseIntelligence = (short)reader["Intelligence"];
                person.BasePolitics = (short)reader["Politics"];
                person.BaseGlamour = (short)reader["Glamour"];
                person.Reputation = (int)reader["Reputation"];
                try
                {
                    errors.AddRange(person.UniqueMilitaryKinds.LoadFromString(this.GameCommonData.AllMilitaryKinds, reader["UniqueMilitaryKinds"].ToString()));
                    errors.AddRange(person.UniqueTitles.LoadFromString(this.GameCommonData.AllTitles, reader["UniqueTitles"].ToString()));
                    //errors.AddRange(person.Guanzhis.LoadFromString(this.GameCommonData.AllTitles, reader["Guanzhis"].ToString()));
                }
                catch 
                {
                }
                person.StrengthExperience = (int)reader["StrengthExperience"];
                person.CommandExperience = (int)reader["CommandExperience"];
                person.IntelligenceExperience = (int)reader["IntelligenceExperience"];
                person.PoliticsExperience = (int)reader["PoliticsExperience"];
                person.GlamourExperience = (int)reader["GlamourExperience"];
                person.InternalExperience = (int)reader["InternalExperience"];
                person.TacticsExperience = (int)reader["TacticsExperience"];
                person.BubingExperience = (int)reader["BubingExperience"];
                person.NubingExperience = (int)reader["NubingExperience"];
                person.QibingExperience = (int)reader["QibingExperience"];
                person.ShuijunExperience = (int)reader["ShuijunExperience"];
                person.QixieExperience = (int)reader["QixieExperience"];
                person.StratagemExperience = (int)reader["StratagemExperience"];
                person.RoutCount = (int)reader["RoutCount"];
                person.RoutedCount = (int)reader["RoutedCount"];
                person.Braveness = (short)reader["Braveness"];
                person.Calmness = (short)reader["Calmness"];
                person.Loyalty = (short)reader["Loyalty"];
                if ((short)reader["DeadReason"] >= Enum.GetNames(typeof(PersonBornRegion)).Length || (short)reader["BornRegion"] < 0)
                {
                    errors.Add("人物出生地点必须在0至" + Enum.GetNames(typeof(PersonBornRegion)).Length + "之间");
                }
                else
                {
                    person.BornRegion = (PersonBornRegion)((short)reader["BornRegion"]);
                }
                person.AvailableLocation = (short)reader["AvailableLocation"];
                person.Strain = (short)reader["Strain"];
                fatherIds[person.ID] = (short)reader["Father"];
                motherIds[person.ID] = (short)reader["Mother"];
                spouseIds[person.ID] = (short)reader["Spouse"];

                String str;
                char[] separator = separator = new char[] { ' ', '\n', '\r', '\t' };
                String[] strArray;
                int[] intArray;
                try
                {
                    str = reader["Brother"].ToString();
                    strArray = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    intArray = new int[strArray.Length];
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        intArray[i] = int.Parse(strArray[i]);
                    }
                    brotherIds.Add(person.ID, intArray);
                }
                catch
                {
                    errors.Add("义兄弟一栏应为半型空格分隔的人物ID");
                }

                person.Generation = (short)reader["Generation"];
                person.PersonalLoyalty = ((short)reader["PersonalLoyalty"]);
                person.Ambition = ((short)reader["Ambition"]);
                if ((short)reader["Qualification"] >= Enum.GetNames(typeof(PersonQualification)).Length || (short)reader["Qualification"] < 0)
                {
                    errors.Add("人才起用必须在0至" + Enum.GetNames(typeof(PersonQualification)).Length + "之间");
                }
                else
                {
                    person.Qualification = (PersonQualification)((short)reader["Qualification"]);
                }
                if ((short)reader["ValuationOnGovernment"] >= Enum.GetNames(typeof(PersonValuationOnGovernment)).Length || (short)reader["ValuationOnGovernment"] < 0)
                {
                    errors.Add("汉室重视度必须在0至" + Enum.GetNames(typeof(PersonValuationOnGovernment)).Length + "之间");
                }
                else
                {
                    person.ValuationOnGovernment = (PersonValuationOnGovernment)((short)reader["ValuationOnGovernment"]);
                }
                if ((short)reader["StrategyTendency"] >= Enum.GetNames(typeof(PersonStrategyTendency)).Length || (short)reader["StrategyTendency"] < 0)
                {
                    errors.Add("战略取向必须在0至" + Enum.GetNames(typeof(PersonStrategyTendency)).Length + "之间");
                }
                else
                {
                    person.StrategyTendency = (PersonStrategyTendency)((short)reader["StrategyTendency"]);
                }
                try
                {
                    StaticMethods.LoadFromString(person.JoinFactionID, reader["OldFactionID"].ToString());
                }
                catch
                {
                    errors.Add("出仕势力为半型空隔的势力ID");
                }
                try
                {
                    StaticMethods.LoadFromString(person.ProhibitedFactionID, reader["ProhibitedFactionID"].ToString());
                }
                catch
                {
                    errors.Add("出仕势力为半型空隔，交错为的势力ID及禁止仕官的天数");
                }
 
                person.RewardFinished = (bool)reader["RewardFinished"];
                if ((short)reader["WorkKind"] >= Enum.GetNames(typeof(ArchitectureWorkKind)).Length || (short)reader["WorkKind"] < 0)
                {
                    errors.Add("工作类型必须在0至" + Enum.GetNames(typeof(ArchitectureWorkKind)).Length + "之间");
                }
                else
                {
                    person.WorkKind = (ArchitectureWorkKind)((short)reader["WorkKind"]);
                }
                if ((short)reader["OldWorkKind"] >= Enum.GetNames(typeof(ArchitectureWorkKind)).Length || (short)reader["OldWorkKind"] < 0)
                {
                    errors.Add("人物旧工作类型必须在0至" + Enum.GetNames(typeof(ArchitectureWorkKind)).Length + "之间");
                }
                else
                {
                    person.OldWorkKind = (ArchitectureWorkKind)((short)reader["OldWorkKind"]);
                }
                person.RecruitmentMilitary = null;
                person.ArrivingDays = (short)reader["ArrivingDays"];
                person.TaskDays = (short)reader["TaskDays"];
                if ((short)reader["OutsideTask"] >= Enum.GetNames(typeof(OutsideTaskKind)).Length || (short)reader["OutsideTask"] < 0)
                {
                    errors.Add("人物在外工作在0至" + Enum.GetNames(typeof(OutsideTaskKind)).Length + "之间");
                }
                else
                {
                    person.OutsideTask = (OutsideTaskKind)((short)reader["OutsideTask"]);
                }
                person.OutsideDestination = StaticMethods.LoadFromString(reader["OutsideDestination"].ToString());
                person.ConvincingPersonID = (short)reader["ConvincingPerson"];
                person.InformationKindID = (short)reader["InformationKind"];

                try
                {
                    str = reader["ClosePersons"].ToString();
                    strArray = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    intArray = new int[strArray.Length];
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        intArray[i] = int.Parse(strArray[i]);
                    }
                    closeIds.Add(person.ID, intArray);
                }
                catch
                {
                    errors.Add("亲爱武将一栏应为半型空格分隔的人物ID");
                }

                try
                {
                    str = reader["HatedPersons"].ToString();
                    strArray = str.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                    intArray = new int[strArray.Length];
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        intArray[i] = int.Parse(strArray[i]);
                    }
                    hatedIds.Add(person.ID, intArray);
                }
                catch
                {
                    errors.Add("厌恶武将一栏应为半型空格分隔的人物ID");
                }

                person.Skills.LoadFromString(this.GameCommonData.AllSkills, reader["Skills"].ToString());
               /* try
                {

                    errors.AddRange(person.LoadGuanzhiFromString(reader["Guanzhi"].ToString(), this.GameCommonData.AllTitles));
                }
                catch { }
                
                try
                {
                    errors.AddRange(person.LoadGuanzhiFromString(reader["Guanzhi"].ToString(), this.GameCommonData.AllGuanzhis));
                    //Guanzhi g = this.GameCommonData.AllGuanzhis.GetGuanzhi((short)reader["GeneralGuanzhi"]);
                    //g = this.GameCommonData.AllGuanzhis.GetGuanzhi((short)reader["CombatGuanzhi"]);
                }
                catch
                {
                   
                    
                   Guanzhi g = this.GameCommonData .AllGuanzhis.GetGuanzhi((short)reader ["Guanzhi"]);
                    if (g != null)
                    {
                        person.RealGuanzhis.Add(g);
                    }
                     = this.GameCommonData.AllGuanzhis.GetGuanzhi((short)reader["CombatGuanzhi"]);
                    if (g != null)
                    {
                        person.RealGuanzhis.Add(g);
                    }
                }*/

                try
                {
                    errors.AddRange(person.LoadTitleFromString(reader["Title"].ToString(), this.GameCommonData.AllTitles));
                }
                catch
                {
                    Title t = this.GameCommonData.AllTitles.GetTitle((short)reader["PersonalTitle"]);
                    if (t != null)
                    {
                        person.RealTitles.Add(t);
                    }
                    t = this.GameCommonData.AllTitles.GetTitle((short)reader["CombatTitle"]);
                    if (t != null)
                    {
                        person.RealTitles.Add(t);
                    }
                }

                person.StudyingTitle = this.GameCommonData.AllTitles.GetTitle((short)reader["StudyingTitle"]);
                person.huaiyun = (bool)reader["huaiyun"];
                person.faxianhuaiyun = (bool)reader["faxianhuaiyun"];
                person.huaiyuntianshu = short.Parse(reader["huaiyuntianshu"].ToString());

                try
                {
                    person.suoshurenwu = (short)reader["suoshurenwu"];
                }
                catch
                {


                }

                try
                {
                    person.Stunts.LoadFromString(this.GameCommonData.AllStunts, reader["Stunts"].ToString());
                    person.StudyingStunt = this.GameCommonData.AllStunts.GetStunt((short)reader["StudyingStunt"]);
                }
                catch
                {
                }

                try
                {
                    person.waitForFeiziId = int.Parse(reader["WaitForFeizi"].ToString());
                    person.WaitForFeiZiPeriod = (int)reader["WaitForFeiziPeriod"];
                }
                catch (Exception ex)
                {
                    person.waitForFeiziId = -1;
                    person.WaitForFeiZiPeriod = 0;
                }

                try
                {
                    person.preferredTroopPersonsString = reader["PreferredTroopPersons"].ToString();
                }
                catch (Exception ex)
                {
                    person.preferredTroopPersonsString = "";
                }

                try
                {
                    person.YearJoin = (short)reader["YearJoin"];
                    person.TroopDamageDealt = (int)reader["TroopDamageDealt"];
                    person.TroopBeDamageDealt = (int)reader["TroopBeDamageDealt"];
                    person.ArchitectureDamageDealt = (int)reader["ArchitectureDamageDealt"];
                    person.RebelCount = (short)reader["RebelCount"];
                    person.ExecuteCount = (short)reader["ExecuteCount"];
                    person.FleeCount = (short)reader["FleeCount"];
                    person.HeldCaptiveCount = (short)reader["HeldCaptiveCount"];
                    person.CaptiveCount = (short)reader["CaptiveCount"];
                    person.StratagemSuccessCount = (int)reader["StratagemSuccessCount"];
                    person.StratagemFailCount = (int)reader["StratagemFailCount"];
                    person.StratagemBeSuccessCount = (int)reader["StratagemBeSuccessCount"];
                    person.StratagemBeFailCount = (int)reader["StratagemBeFailCount"];
                }
                catch
                {
                    // all zeroes.
                }
                try
                {
                    person.Tiredness = (int)reader["Tiredness"];
                }
                catch
                {
                }
                try
                {
                    person.OfficerKillCount = (int)reader["OfficerKillCount"];
                }
                catch
                {
                }
                try
                {
                    person.InjureRate = (float)reader["InjureRate"];
                }
                catch 
                {
                    person.InjureRate = 1;
                }
                try
                {
                   // person.Battle = (OngoingBattle)this.AllOngoingBattles.GetGameObject((int)reader["Battle"]);
                    person.BattleSelfDamage = (int)reader["BattleSelfDamage"];
                }
                catch
                {
                }
                try
                {
                    person.NumberOfChildren = (int)reader["NumberOfChildren"];
                }
                catch
                {
                }
                try 
                {
                    person.Tags = reader["Tags"].ToString();
                }
                catch
                {
                }

                if (errors.Count > 0)
                {
                    errorMsg.Add("人物ID" + person.ID + "：");
                    errorMsg.AddRange(errors);
                }

                this.Persons.AddPersonWithEvent(person);  //所有武将，并加载武将事件
                this.AllPersons.Add(person.ID, person);   //武将字典

               // this.AllChildren.Add(person, person.NumberOfChildren);

                if (person.Available && person.Alive)
                {
                    this.AvailablePersons.Add(person);  //已出场武将
                }
            }
            DbConnection.Close();
            foreach (Person p in this.Persons)
            {
                p.WaitForFeiZi = this.Persons.GetGameObject(p.waitForFeiziId) as Person;
                List<string> e = p.preferredTroopPersons.LoadFromString(this.Persons, p.preferredTroopPersonsString);
                if (e.Count > 0)
                {
                    errorMsg.Add("人物ID" + p.ID + "：副将一栏：");
                    errorMsg.AddRange(e);
                }
            }
            foreach (KeyValuePair<int, int> i in fatherIds)
            {
                (this.Persons.GetGameObject(i.Key) as Person).Father = this.Persons.GetGameObject(i.Value) as Person;
            }
            foreach (KeyValuePair<int, int> i in motherIds)
            {
                (this.Persons.GetGameObject(i.Key) as Person).Mother = this.Persons.GetGameObject(i.Value) as Person;
            }
            foreach (KeyValuePair<int, int> i in spouseIds)
            {
                Person p = (this.Persons.GetGameObject(i.Key) as Person);
                Person q = this.Persons.GetGameObject(i.Value) as Person;
                p.Spouse = q;
                if (q != null && fromScenario)
                {
                    p.EnsureRelationAtLeast(q, Parameters.VeryCloseThreshold);
                }
            }
            foreach (KeyValuePair<int, int[]> i in brotherIds)
            {
                if (i.Value.Length == 1 && i.Value[0] != -1)
                {
                    foreach (KeyValuePair<int, int[]> j in brotherIds)
                    {
                        if (j.Value.Length > 0 && i.Value[0] == j.Value[0])
                        {
                            Person p = this.Persons.GetGameObject(i.Key) as Person;
                            Person q = this.Persons.GetGameObject(j.Key) as Person;
                            p.Brothers.Add(q);
                            if (q != null && fromScenario)
                            {
                                p.EnsureRelationAtLeast(q, Parameters.VeryCloseThreshold);
                            }
                        }
                    }
                }
                else
                {
                    Person p = this.Persons.GetGameObject(i.Key) as Person;
                    foreach (int j in i.Value)
                    {
                        Person q = this.Persons.GetGameObject(j) as Person;
                        if (q != null)
                        {
                            p.Brothers.Add(q);
                            if (q != null && fromScenario)
                            {
                                p.EnsureRelationAtLeast(q, Parameters.VeryCloseThreshold);
                            }
                        }
                        else
                        {
                            errorMsg.Add("人物ID" + p.ID + "：义兄弟ID" + j + "不存在");
                        }
                    }
                }
            }
            foreach (KeyValuePair<int, int[]> i in closeIds)
            {
                Person p = this.Persons.GetGameObject(i.Key) as Person;
                foreach (int j in i.Value)
                {
                    Person q = this.Persons.GetGameObject(j) as Person;
                    if (q != null)
                    {
                        p.AddClose(q);
                    }
                    else
                    {
                        errorMsg.Add("人物ID" + p.ID + "：亲爱武将ID" + j + "不存在");
                    }
                }
            }
            foreach (KeyValuePair<int, int[]> i in hatedIds)
            {
                Person p = this.Persons.GetGameObject(i.Key) as Person;
                foreach (int j in i.Value)
                {
                    Person q = this.Persons.GetGameObject(j) as Person;
                    if (q != null)
                    {
                        p.AddHated(q);
                    }
                    else
                    {
                        errorMsg.Add("人物ID" + p.ID + "：厌恶武将ID" + j + "不存在");
                    }
                }
            }

            try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From Biography", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    Biography biography = new Biography();
                    biography.Scenario = this;
                    int id = (short)reader["ID"];
                    Person p = (Person)this.Persons.GetGameObject(id);
                    if (p != null)
                    {
                        biography.ID = id;
                        biography.Brief = reader["Brief"].ToString();
                        biography.Romance = reader["Romance"].ToString();
                        biography.History = reader["History"].ToString();
                        try
                        {
                            biography.InGame = reader["InGame"].ToString();
                        }
                        catch
                        {
                            biography.InGame = "";
                        }
                        biography.FactionColor = (short)reader["FactionColor"];
                        List<string> e = biography.MilitaryKinds.LoadFromString(this.GameCommonData.AllMilitaryKinds, reader["MilitaryKinds"].ToString());
                        if (e.Count > 0)
                        {
                            errorMsg.Add("列传人物ID" + biography.ID + "：");
                            errorMsg.AddRange(e);
                        }
                        if (biography.MilitaryKinds.MilitaryKinds.Count == 0)
                        {
                            errorMsg.Add("列传人物ID" + biography.ID + "：没有基本兵种。");
                        }
                        this.AllBiographies.AddBiography(biography);
                        p.PersonBiography = biography;
                    }
                }
                DbConnection.Close();
            }
            catch (Exception ex)
            {
            }

            foreach (Person p in this.Persons)
            {
                if (p.PersonBiography == null)
                {
                    p.PersonBiography = new Biography();
                    p.PersonBiography.FactionColor = 52;
                    p.PersonBiography.MilitaryKinds.AddBasicMilitaryKinds(this);
                    p.PersonBiography.Brief = "";
                    p.PersonBiography.History = "";
                    p.PersonBiography.Romance = "";
                    p.PersonBiography.InGame = "";
                    p.PersonBiography.ID = p.ID;
                    this.AllBiographies.AddBiography(p.PersonBiography);
                }
            }

            DbConnection.Open();
            try
            {
                reader = new OleDbCommand("Select * From PersonRelation", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    Person person1 = this.Persons.GetGameObject((short)reader["Person1"]) as Person;
                    Person person2 = this.Persons.GetGameObject((short)reader["Person2"]) as Person;
                    int relation = (int)reader["Relation"];
                    if (person1 == null)
                    {
                        errorMsg.Add("人物关系：武将ID" + (short)reader["Person1"] + "不存在");
                    }
                    if (person2 == null)
                    {
                        errorMsg.Add("人物关系：武将ID" + (short)reader["Person2"] + "不存在");
                    }
                    if (person1 != null && person2 != null)
                    {
                        person1.SetRelation(person2, relation);
                    }
                }
            }
            catch (OleDbException)
            {
                //ignore
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Captive", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Captive captive = new Captive();
                captive.Scenario = this;
                captive.ID = (short)reader["ID"];
                captive.CaptivePerson = this.Persons.GetGameObject((short)reader["CaptivePerson"]) as Person;
                if (captive.CaptivePerson == null)
                {
                    errorMsg.Add("俘虏ID" + captive.ID + "：武将ID" + (short)reader["CaptivePerson"] + "不存在");
                    continue;
                }
                else
                {
                    captive.CaptivePerson.SetBelongedCaptive(captive, PersonStatus.Captive);
                }
                captive.CaptiveFactionID = (short)reader["CaptiveFaction"];
                captive.RansomArchitectureID = (short)reader["RansomArchitecture"];
                captive.RansomFund = (int)reader["RansomFund"];
                captive.RansomArriveDays = (int)reader["RansomArriveDays"];
                captive.CaptivePerson.Status = PersonStatus.Captive;
                if (!isInCaptiveList(captive.CaptivePerson.ID))
                {
                    this.Captives.AddCaptiveWithEvent(captive);
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Military", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Military military = new Military();
                military.Scenario = this;
                military.ID = (short)reader["ID"];
                military.Name = reader["Name"].ToString();
                military.KindID = (short)reader["KindID"];
                if (this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(military.KindID) == null)
                {
                    errorMsg.Add("编队ID" + military.ID + "：兵种ID" + military.KindID + "不存在");
                    continue;
                }
                military.Quantity = (int)reader["Quantity"];
                military.Morale = (int)reader["Morale"];
                military.Combativity = (int)reader["Combativity"];
                military.Experience = (int)reader["Experience"];
                military.InjuryQuantity = (int)reader["InjuryQuantity"];
                military.FollowedLeaderID = (short)reader["FollowedLeaderID"];
                military.LeaderID = (short)reader["LeaderID"];
                military.LeaderExperience = (int)reader["LeaderExperience"];
                int recruiter = (short)reader["RecruitmentPersonID"];
                foreach (Person p in this.Persons)
                {
                    if (p.ID == recruiter)
                    {
                        //p.RecruitmentMilitary = military;
                        p.RecruitMilitary(military);
                    }
                }
                military.ShelledMilitaryID = (short)reader["ShelledMilitary"];
                try
                {
                    military.Tiredness = (int)reader["Tiredness"];
                }
                catch
                {
                }
                try
                {
                    military.ArrivingDays = (short)reader["ArrivingDays"];
                }
                catch
                {
                }
                try
                {
                    military.StartingArchitectureID = (short)reader["StartingArchitectureID"];
                }
                catch
                {
                }
                try
                {
                    military.TargetArchitectureID = (short)reader["TargetArchitectureID"];
                }
                catch
                {
                }

                if (military.Kind != null)
                {
                    this.Militaries.AddMilitary(military);
                }
            }
            this.InitializeMilitaryData();
            DbConnection.Close();

            DbConnection.Open();
            reader = new OleDbCommand("Select * From Facility", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Facility facility = new Facility();
                facility.Scenario = this;
                facility.ID = (short)reader["ID"];
                facility.KindID = (short)reader["KindID"];
                if (this.GameCommonData.AllFacilityKinds.GetFacilityKind(facility.KindID) == null)
                {
                    errorMsg.Add("设施ID" + facility.ID + "：设施种类ID" + facility.KindID + "不存在");
                    continue;
                }
                facility.Endurance = (int)reader["Endurance"];
                this.Facilities.AddFacility(facility);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Information", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Information information = new Information();
                information.Scenario = this;
                information.ID = (short)reader["ID"];
                information.Level = (InformationLevel)((short)reader["iLevel"]);
                information.Position = new Point((short)reader["PositionX"], (short)reader["PositionY"]);
                information.Radius = (short)reader["Radius"];
                information.Oblique = (bool)reader["Oblique"];
                try
                {
                    information.DayCost = (int)reader["DayCost"];
                    information.DaysLeft = (int)reader["DaysLeft"];
                    information.DaysStarted = (int)reader["DaysStarted"];
                    this.Informations.AddInformation(information);
                }
                catch
                {
                }
            }
            DbConnection.Close();
            //DbConnection.Open();
            //reader = new OleDbCommand("Select * From SpyMessage", DbConnection).ExecuteReader();
            //while (reader.Read())
            //{
            //    SpyMessage message = new SpyMessage();
            //    message.Scenario = this;
            //    message.ID = (int)reader["ID"];
            //    message.Kind = (SpyMessageKind)((short)reader["Kind"]);
            //    message.MessageFactionID = (short)reader["MessageFaction"];
            //    message.MessageArchitectureID = (short)reader["MessageArchitecture"];
            //    message.LoadPersonPacksFromString(this.AllPersons, reader["PersonPacks"].ToString());
            //    message.Message1 = reader["Message1"].ToString();
            //    message.Message2 = reader["Message2"].ToString();
            //    message.Message3 = reader["Message3"].ToString();
            //    message.Message4 = reader["Message4"].ToString();
            //    message.Message5 = reader["Message5"].ToString();
            //    this.SpyMessages.AddMessageWithEvent(message);
            //}
            //DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Architecture", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                List<string> e = new List<string>();

                Architecture architecture = new Architecture();
                architecture.Scenario = this;
                architecture.ID = (short)reader["ID"];
                try
                {
                    architecture.CaptionID = (short)reader["CaptionID"];
                }
                catch
                {
                    architecture.CaptionID = 9999;

                }
                try
                {
                    architecture.MayorID = (short)reader["MayorID"];
                }
                catch
                {
                }

                architecture.Name = reader["Name"].ToString();
                architecture.Kind = this.GameCommonData.AllArchitectureKinds.GetArchitectureKind((short)reader["Kind"]);
                if (architecture.Kind == null)
                {
                    e.Add("建筑种类ID" + reader["Kind"] + "不存在");
                }
                architecture.IsStrategicCenter = (bool)reader["IsStrategicCenter"];
                architecture.LocationState = this.States.GetGameObject((short)reader["StateID"]) as State;
                if (architecture.LocationState == null)
                {
                    e.Add("州域ID" + reader["Kind"] + "不存在");
                }
                else
                {
                    architecture.LocationState.Architectures.Add(architecture);
                    architecture.LocationState.LinkedRegion.Architectures.Add(architecture);
                    if (architecture.LocationState.StateAdminID == architecture.ID)
                    {
                        architecture.LocationState.StateAdmin = architecture;
                    }
                    if (architecture.LocationState.LinkedRegion.RegionCoreID == architecture.ID)
                    {
                        architecture.LocationState.LinkedRegion.RegionCore = architecture;
                    }
                }
                e.AddRange(architecture.Characteristics.LoadFromString(this.GameCommonData.AllInfluences, reader["Characteristics"].ToString()));
                architecture.LoadFromString(architecture.ArchitectureArea, reader["Area"].ToString());
                e.AddRange(architecture.LoadPersonsFromString(this.AllPersons, reader["Persons"].ToString(), PersonStatus.Normal));
                e.AddRange(architecture.LoadPersonsFromString(this.AllPersons, reader["MovingPersons"].ToString(), PersonStatus.Moving));
                e.AddRange(architecture.LoadPersonsFromString(this.AllPersons, reader["NoFactionPersons"].ToString(), PersonStatus.NoFaction));
                e.AddRange(architecture.LoadPersonsFromString(this.AllPersons, reader["NoFactionMovingPersons"].ToString(), PersonStatus.NoFactionMoving));
                e.AddRange(architecture.LoadPersonsFromString(this.AllPersons, reader["feiziliebiao"].ToString(), PersonStatus.Princess));
                architecture.Population = (int)reader["Population"];
                architecture.Fund = (int)reader["Fund"];
                architecture.Food = (int)reader["Food"];
                architecture.Agriculture = (int)reader["Agriculture"];
                architecture.Commerce = (int)reader["Commerce"];
                architecture.Technology = (int)reader["Technology"];
                architecture.Domination = (int)reader["Domination"];
                architecture.Morale = (int)reader["Morale"];
                architecture.Endurance = (int)reader["Endurance"];
                architecture.AutoHiring = (bool)reader["AutoHiring"];
                architecture.AutoRewarding = (bool)reader["AutoRewarding"];
                architecture.AutoWorking = (bool)reader["AutoWorking"];
                architecture.AutoSearching = (bool)reader["AutoSearching"];
                /*
                try
                {
                    architecture.AutoZhaoXian = (bool)reader["AutoZhaoXian"];
                }
                catch
                {
                }
                */
                try
                {
                    architecture.AutoRecruiting = (bool)reader["AutoRecruiting"];
                }
                catch
                {
                }

                architecture.HireFinished = (bool)reader["HireFinished"];
                architecture.FacilityEnabled = (bool)reader["FacilityEnabled"];

                try
                {
                    architecture.MilitaryPopulation = (int)reader["MilitaryPopulation"];
                }
                catch
                {
                }

                e.AddRange(architecture.LoadMilitariesFromString(this.Militaries, reader["Militaries"].ToString()));
                e.AddRange(architecture.LoadFacilitiesFromString(this.Facilities, reader["Facilities"].ToString()));
                architecture.BuildingFacility = (int)reader["BuildingFacility"];
                architecture.BuildingDaysLeft = (int)reader["BuildingDaysLeft"];
                architecture.PlanFacilityKindID = (int)reader["PlanFacilityKind"];
                e.AddRange(architecture.LoadFundPacksFromString(reader["FundPacks"].ToString()));
                try
                {
                    e.AddRange(architecture.LoadFoodPacksFromString(reader["FoodPacks"].ToString()));
                }
                catch { }
                // architecture.LoadSpyPacksFromString(reader["SpyPacks"].ToString());
                // architecture.TodayNewMilitarySpyMessage = this.SpyMessages.GetGameObject((short)reader["TodayNewMilitarySpyMessage"]) as SpyMessage;
                // architecture.TodayNewTroopSpyMessage = this.SpyMessages.GetGameObject((short)reader["TodayNewTroopSpyMessage"]) as SpyMessage;
                e.AddRange(architecture.LoadPopulationPacksFromString(reader["PopulationPacks"].ToString()));
                architecture.PlanArchitectureID = (int)reader["PlanArchitecture"];
                architecture.TransferFundArchitectureID = (int)reader["TransferFundArchitecture"];
                architecture.TransferFoodArchitectureID = (int)reader["TransferFoodArchitecture"];
                architecture.DefensiveLegionID = (int)reader["DefensiveLegion"];
                e.AddRange(architecture.LoadCaptivesFromString(this.Captives, reader["Captives"].ToString()));
                architecture.RobberTroopID = (short)reader["RobberTroop"];
                architecture.RecentlyAttacked = (short)reader["RecentlyAttacked"];
                architecture.RecentlyBreaked = (short)reader["RecentlyBreaked"];
                architecture.AILandLinksString = reader["AILandLinks"].ToString();
                architecture.AIWaterLinksString = reader["AIWaterLinks"].ToString();

                try
                {
                    architecture.youzainan = (bool)reader["youzainan"];
                    architecture.zainan.zainanzhonglei = this.GameCommonData.suoyouzainanzhonglei.Getzainanzhonglei((short)reader["zainanleixing"]);
                    architecture.zainan.shengyutianshu = (short)reader["zainanshengyutianshu"];
                }
                catch
                {
                    architecture.youzainan = false;

                }
                try
                {
                    architecture.huangdisuozai = (bool)reader["Emperor"];
                }
                catch
                {
                    architecture.huangdisuozai = false;

                }


                try
                {
                    e.AddRange(architecture.LoadInformationsFromString(this.Informations, (string)reader["Informations"]));
                }
                catch
                {
                }

                try
                {
                    architecture.SuspendTroopTransfer = (int)reader["SuspendTroopTransfer"];
                }
                catch { };
                /*
                try
                {
                    architecture.Battle = (OngoingBattle) this.AllOngoingBattles.GetGameObject((int)reader["Battle"]);
                }
                catch { }
                */
                try
                {
                    architecture.OldFactionName = reader["OldFactionName"].ToString();
                }
                catch { }


                if (e.Count > 0)
                {
                    errorMsg.Add("建筑ID" + architecture.ID + "：");
                    errorMsg.AddRange(e);
                }
                else
                {
                    this.Architectures.AddArchitectureWithEvent(architecture);
                    this.AllArchitectures.Add(architecture.ID, architecture);
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Routeway", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                List<string> e = new List<string>();
                Routeway routeway = new Routeway();
                routeway.Scenario = this;
                routeway.ID = (short)reader["ID"];
                routeway.Building = (bool)reader["Building"];
                routeway.ShowArea = (bool)reader["ShowArea"];
                routeway.RemoveAfterClose = (bool)reader["RemoveAfterClose"];
                routeway.LastActivePointIndex = (int)reader["LastActivePointIndex"];
                routeway.InefficiencyDays = (int)reader["InefficiencyDays"];
                routeway.StartArchitecture = this.Architectures.GetGameObject((int)reader["StartArchitecture"]) as Architecture;
                if (routeway.StartArchitecture != null)
                {
                    routeway.StartArchitecture.Routeways.Add(routeway);
                }
                else
                {
                    e.Add("建筑ID" + (int)reader["StartArchitecture"] + "不存在");
                }
                routeway.EndArchitecture = this.Architectures.GetGameObject((int)reader["EndArchitecture"]) as Architecture;
                routeway.DestinationArchitecture = this.Architectures.GetGameObject((int)reader["DestinationArchitecture"]) as Architecture;
                routeway.LoadRoutePointsFromString(reader["Points"].ToString());
                if (e.Count > 0)
                {
                    errorMsg.Add("粮道ID" + routeway.ID + "：");
                    errorMsg.AddRange(e);
                }
                else
                {
                    this.Routeways.AddRoutewayWithEvent(routeway);
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Troop", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                List<string> errors = new List<string>();
                Troop troop = new Troop();
                troop.Scenario = this;
                troop.ID = (short)reader["ID"];
                troop.Controllable = (bool)reader["Controllable"];
                if ((short)reader["Status"] >= Enum.GetNames(typeof(TroopStatus)).Length || (short)reader["Status"] < 0)
                {
                    errors.Add("部队状态在0至" + Enum.GetNames(typeof(TroopStatus)).Length + "之间");
                }
                else
                {
                    troop.SetStatus((TroopStatus)((short)reader["Status"]));
                }
                if ((short)reader["Direction"] >= Enum.GetNames(typeof(TroopDirection)).Length || (short)reader["Direction"] < 0)
                {
                    errors.Add("部队方向在0至" + Enum.GetNames(typeof(TroopDirection)).Length + "之间");
                }
                else
                {
                    troop.Direction = (TroopDirection)((short)reader["Direction"]);
                }
                troop.Auto = (bool)reader["Auto"];
                troop.Operated = (bool)reader["Operated"];
                troop.Food = (int)reader["Food"];
                troop.zijin = (int)reader["zijin"];
                troop.StartingArchitecture = this.Architectures.GetGameObject((short)reader["StartingArchitecture"]) as Architecture;
                if (troop.StartingArchitecture == null)
                {
                    errors.Add("起始建筑ID" + (short)reader["StartingArchitecture"] + "不存在");
                }
                errors.AddRange(troop.LoadPersonsFromString(this.AllPersons, reader["Persons"].ToString(), (short)reader["LeaderID"]));
                troop.LoadPathInformation((short)reader["PositionX"], (short)reader["PositionY"], (short)reader["DestinationX"], (short)reader["DestinationY"], (short)reader["RealDestinationX"], (short)reader["RealDestinationY"], reader["FirstTierPath"].ToString(), reader["SecondTierPath"].ToString(), reader["ThirdTierPath"].ToString(), (short)reader["FirstIndex"], (short)reader["SecondIndex"], (short)reader["ThirdIndex"]);
                troop.MilitaryID = (short)reader["MilitaryID"];
                if (this.Militaries.GetGameObject(troop.MilitaryID) == null)
                {
                    errors.Add("编队ID" + troop.MilitaryID + "不存在");
                }
                if ((short)reader["AttackDefaultKind"] >= Enum.GetNames(typeof(TroopAttackTargetKind)).Length || (short)reader["AttackDefaultKind"] < 0)
                {
                    errors.Add("攻击预设模式在0至" + Enum.GetNames(typeof(TroopAttackTargetKind)).Length + "之间");
                }
                else
                {
                    troop.AttackDefaultKind = (TroopAttackDefaultKind)((short)reader["AttackDefaultKind"]);
                }
                if ((short)reader["AttackTargetKind"] >= Enum.GetNames(typeof(TroopAttackTargetKind)).Length || (short)reader["AttackTargetKind"] < 0)
                {
                    errors.Add("攻击目标模式在0至" + Enum.GetNames(typeof(TroopAttackTargetKind)).Length + "之间");
                }
                else
                {
                    troop.AttackTargetKind = (TroopAttackTargetKind)((short)reader["AttackTargetKind"]);
                }
                troop.TargetTroopID = (short)reader["TargetTroopID"];
                troop.TargetArchitectureID = (short)reader["TargetArchitectureID"];
                troop.WillTroopID = (short)reader["WillTroopID"];
                troop.WillArchitectureID = (short)reader["WillArchitectureID"];
                troop.CurrentCombatMethodID = (short)reader["CurrentCombatMethodID"];
                troop.CurrentStratagemID = (short)reader["CurrentStratagemID"];
                troop.SelfCastPosition = new Point((short)reader["SelfCastPositionX"], (short)reader["SelfCastPositionY"]);
                troop.ChaosDayLeft = (short)reader["ChaosDayLeft"];
                try
                {
                    troop.ForceTroopTargetId = (short)reader["ForceTroopTarget"];
                }
                catch
                {
                    troop.ForceTroopTargetId = -1;
                }
                troop.CutRoutewayDays = (short)reader["CutRoutewayDays"];
                errors.AddRange(troop.LoadCaptivesFromString(this.Captives, reader["Captives"].ToString()));
                troop.RecentlyFighting = (short)reader["RecentlyFighting"];
                troop.TechnologyIncrement = (short)reader["TechnologyIncrement"];
                errors.AddRange(troop.EventInfluences.LoadFromString(this.GameCommonData.AllInfluences, reader["EventInfluences"].ToString()));
                try
                {
                    troop.CurrentStunt = this.GameCommonData.AllStunts.GetStunt((short)reader["CurrentStunt"]);
                    troop.StuntDayLeft = (short)reader["StuntDayLeft"];
                }
                catch
                {
                }
                try
                {
                    troop.mingling = reader["mingling"].ToString();
                }
                catch
                {
                }
                try
                {
                    troop.ManualControl = (bool)reader["ManualControl"];
                }
                catch
                {
                }
                troop.minglingweizhi = troop.RealDestination;

                if (errors.Count > 0)
                {
                    errors.Add("部队ID" + troop.ID + "：");
                    errorMsg.AddRange(errors);
                }
                else
                {
                    if (troop.Army != null)
                    {
                        this.Troops.AddTroopWithEvent(troop);
                    }
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Legion", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                Legion legion = new Legion();
                legion.Scenario = this;
                legion.ID = int.Parse(reader["ID"].ToString());
                legion.Kind = (LegionKind)((short)reader["Kind"]);
                legion.StartArchitecture = this.Architectures.GetGameObject((int)reader["StartArchitecture"]) as Architecture;
                legion.WillArchitecture = this.Architectures.GetGameObject((int)reader["WillArchitecture"]) as Architecture;
                legion.PreferredRouteway = this.Routeways.GetGameObject((int)reader["PreferredRouteway"]) as Routeway;
                legion.InformationDestination = StaticMethods.LoadFromString(reader["InformationDestination"].ToString());
                legion.CoreTroop = this.Troops.GetGameObject((int)reader["CoreTroop"]) as Troop;
                legion.LoadTroopsFromString(this.Troops, reader["Troops"].ToString());
                this.Legions.AddLegionWithEvent(legion);
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Sections", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                List<string> e = new List<string>();

                Section section = new Section();
                section.Scenario = this;
                section.ID = int.Parse(reader["ID"].ToString());
                section.Name = reader["Name"].ToString();
                section.AIDetail = this.GameCommonData.AllSectionAIDetails.GetSectionAIDetail((short)reader["AIDetail"]);
                if (section.AIDetail == null)
                {
                    e.Add("军区委任类型" + (short)reader["AIDetail"] + "不存在");
                }
                section.OrientationFactionID = (short)reader["OrientationFaction"];
                section.OrientationSectionID = (short)reader["OrientationSection"];
                section.OrientationStateID = (short)reader["OrientationState"];
                try
                {
                    section.OrientationArchitectureID = (short)reader["OrientationArchitecture"];
                }
                catch
                {
                }
                e.AddRange(section.LoadArchitecturesFromString(this.Architectures, reader["Architectures"].ToString()));
                if (e.Count > 0)
                {
                    errorMsg.Add("军区ID" + section.ID + "：");
                    errorMsg.AddRange(e);
                }
                else
                {
                    this.Sections.AddSectionWithEvent(section);
                }
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From Faction", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                List<string> e = new List<string>();
                Faction faction = new Faction();
                faction.Scenario = this;
                faction.ID = (short)reader["ID"];
                faction.Passed = (bool)reader["Passed"];
                faction.PreUserControlFinished = (bool)reader["PreUserControlFinished"];
                faction.Controlling = (bool)reader["Controlling"];
                faction.LeaderID = (short)reader["LeaderID"];
                faction.ColorIndex = (short)reader["ColorIndex"];
                if (faction.ColorIndex >= this.GameCommonData.AllColors.Count)
                {
                    e.Add("颜色ID" + faction.ColorIndex + "不存在");
                }
                else
                {
                    faction.FactionColor = this.GameCommonData.AllColors[faction.ColorIndex];
                }
                faction.Name = reader["FName"].ToString();
                faction.CapitalID = (short)reader["CapitalID"];
                faction.Reputation = (int)reader["Reputation"];
                faction.TechniquePoint = (int)reader["TechniquePoint"];
                faction.TechniquePointForTechnique = (int)reader["TechniquePointForTechnique"];
                faction.TechniquePointForFacility = (int)reader["TechniquePointForFacility"];
                e.AddRange(faction.LoadArchitecturesFromString(this.Architectures, reader["Architectures"].ToString()));
                e.AddRange(faction.LoadSectionsFromString(this.Sections, reader["Sections"].ToString()));
                e.AddRange(faction.LoadTroopsFromString(this.Troops, reader["Troops"].ToString()));
                e.AddRange(faction.LoadInformationsFromString(this.Informations, reader["Informations"].ToString()));
                e.AddRange(faction.LoadRoutewaysFromString(this.Routeways, reader["Routeways"].ToString()));
                e.AddRange(faction.LoadLegionsFromString(this.Legions, reader["Legions"].ToString()));
                faction.BaseMilitaryKinds.LoadFromString(this.GameCommonData.AllMilitaryKinds, reader["BaseMilitaryKinds"].ToString());
                faction.UpgradingTechnique = (short)reader["UpgradingTechnique"];
                faction.UpgradingDaysLeft = (short)reader["UpgradingDaysLeft"];
                e.AddRange(faction.AvailableTechniques.LoadFromString(this.GameCommonData.AllTechniques, reader["AvailableTechniques"].ToString()));
                StaticMethods.LoadFromString(faction.PreferredTechniqueKinds, reader["PreferredTechniqueKinds"].ToString());
                faction.PlanTechnique = this.GameCommonData.AllTechniques.GetTechnique((short)reader["PlanTechnique"]);
                faction.AutoRefuse = (bool)reader["AutoRefuse"];
                
                try
                {
                    faction.chaotinggongxiandu = (int)reader["chaotinggongxiandu"];
                }
                catch
                {
                    faction.chaotinggongxiandu = 0;

                }
                try
                {
                    e.AddRange(faction.LoadTransferingMilitariesFromString(this.Militaries, reader["TransferingMilitaries"].ToString()));
                    e.AddRange(faction.LoadMilitariesFromString(this.Militaries, reader["Militaries"].ToString()));
                }
                catch
                {
                }
                try
                {
                    faction.LoadGeneratorPersonCountFromString(reader["GetGeneratorPersonCount"].ToString());
                    
                }
                catch { }
                
                try
                {
                    faction.MilitaryCount = (int)reader["MilitaryCount"];
                }
                catch
                {
                }
                try
                {
                    faction.TransferingMilitaryCount = (int)reader["TransferingMilitaryCount"];
                }
                catch
                {
                }
                try
                {
                    faction.CreatePersonTimes = (int)reader["CreatePersonTimes"];
                }
                catch
                {
                    faction.CreatePersonTimes = 0;
                }
                try
                {
                    faction.YearOfficialLimit = (int)reader["YearOfficialLimit"];
                }
                catch
                {
                    faction.YearOfficialLimit = 0;
                }
                /*
                try
                {
                    faction.ZongShu[0] = (int)reader["General"];
                    faction.ZongShu[1] = (int)reader["Brave"];
                    faction.ZongShu[2] = (int)reader["Advisor"];
                    faction.ZongShu[3] = (int)reader["Politician"];
                    faction.ZongShu[4] = (int)reader["IntelGeneral"];
                    faction.ZongShu[5] = (int)reader["Emperor"];
                    faction.ZongShu[6] = (int)reader["AllRounder"];
                    faction.ZongShu[7] = (int)reader["Normal"];
                    faction.ZongShu[8] = (int)reader["Cheap"];
                    faction.ZongShu[9] = (int)reader["Normal2"];
                }
                catch
                {
                    faction.ZongShu[0] = 0;
                    faction.ZongShu[1] = 0;
                    faction.ZongShu[2] = 0;
                    faction.ZongShu[3] = 0;
                    faction.ZongShu[4] = 0;
                    faction.ZongShu[5] = 0;
                    faction.ZongShu[6] = 0;
                    faction.ZongShu[7] = 0;
                    faction.ZongShu[8] = 0;
                    faction.ZongShu[9] = 0;
                }*/
                try
                {
                    faction.PrinceID = (short)reader["PrinceID"];
                }
                catch
                {
                }

                try
                {
                    faction.guanjue = (short)reader["guanjue"];
                }
                catch
                {
                    faction.guanjue = 0;

                }
                try
                {
                    faction.IsAlien = (bool)reader["IsAlien"];
                }
                catch
                {
                    faction.IsAlien = false;
                }
                try
                {
                    faction.NotPlayerSelectable = (bool)reader["NotPlayerSelectable"];
                }
                catch
                {
                }
                if (faction.AvailableMilitaryKinds.GetMilitaryKindList().Count == 0)
                {
                    faction.AvailableMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0));
                    faction.AvailableMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(1));
                    faction.AvailableMilitaryKinds.AddMilitaryKind(this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(2));
                }
                if (e.Count > 0)
                {
                    errorMsg.Add("势力ID" + faction.ID + "：");
                    errorMsg.AddRange(e);
                }
                this.Factions.AddFactionWithEvent(faction);
            }
            DbConnection.Close();
            DbConnection.Open();
            try
            {
                reader = new OleDbCommand("Select * From Treasure", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    Treasure treasure = new Treasure();
                    treasure.Scenario = this;
                    treasure.ID = (short)reader["ID"];
                    treasure.Name = reader["Name"].ToString();
                    treasure.Description = reader["Description"].ToString();
                    treasure.Pic = (short)reader["Pic"];
                    treasure.Worth = (short)reader["Worth"];
                    treasure.Available = (bool)reader["Available"];
                    treasure.AppearYear = (short)reader["AppearYear"];
                    try
                    {
                        treasure.TreasureGroup = (short)reader["TreasureGroup"];
                    }
                    catch
                    {
                        treasure.TreasureGroup = treasure.ID;
                    }
                    int key = (short)reader["HidePlace"];
                    treasure.HidePlace = this.AllArchitectures.ContainsKey(key) ? this.AllArchitectures[key] : null;
                    int num2 = (short)reader["BelongedPerson"];
                    treasure.BelongedPerson = this.AllPersons.ContainsKey(num2) ? this.AllPersons[num2] : null;
                    if (treasure.BelongedPerson != null)
                    {
                        treasure.BelongedPerson.Treasures.Add(treasure);
                    }
                    treasure.Influences.LoadFromString(this.GameCommonData.AllInfluences, reader["Influences"].ToString());
                    this.Treasures.AddTreasure(treasure);
                }
            }
            catch
            {
            }
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From DiplomaticRelation", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                DiplomaticRelation dr = new DiplomaticRelation();
                dr.Scenario = this;
                dr.RelationFaction1ID = (short)reader["Faction1ID"];
                dr.RelationFaction2ID = (short)reader["Faction2ID"];
                dr.Relation = (int)reader["Relation"];
                try
                {
                    dr.Truce = (int)reader["Truce"];
                }
                catch
                {
                }
                this.DiplomaticRelations.AddDiplomaticRelation(dr);
            }
            DbConnection.Close();
            command = new OleDbCommand("Select * From GameSurvey", DbConnection);
            DbConnection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            this.ScenarioTitle = reader["Title"].ToString();
            this.ScenarioDescription = reader["Description"].ToString();
            this.Date.LoadDateData((short)reader["GYear"], (short)reader["GMonth"], (short)reader["GDay"]);
            this.ScenarioMap.JumpPosition = StaticMethods.LoadFromString(reader["JumpPosition"].ToString()).Value;
            DbConnection.Close();
            DbConnection.Open();
            reader = new OleDbCommand("Select * From TroopEvent", DbConnection).ExecuteReader();
            while (reader.Read())
            {
                TroopEvent te = new TroopEvent();
                te.Scenario = this;
                te.ID = (short)reader["ID"];
                try
                {
                    te.Name = reader["Name"].ToString();
                    te.Happened = (bool)reader["Happened"];
                    te.Repeatable = (bool)reader["Repeatable"];
                    try
                    {
                        te.AfterEventHappened = (short)reader["AfterEventHappened"];
                    }
                    catch
                    {
                    }
                    te.LaunchPerson = this.Persons.GetGameObject((short)reader["LaunchPerson"]) as Person;
                    te.Conditions.LoadFromString(this.GameCommonData.AllConditions, reader["Conditions"].ToString());
                    te.HappenChance = (short)reader["Chance"];
                    te.CheckArea = (EventCheckAreaKind)((short)reader["CheckAreaKind"]);
                    te.LoadTargetPersonFromString(this.AllPersons, reader["TargetPersons"].ToString());
                    te.LoadDialogFromString(this.AllPersons, reader["Dialogs"].ToString());
                    
                    te.LoadSelfEffectFromString(this.GameCommonData.AllTroopEventEffects, reader["EffectSelf"].ToString());
                    te.LoadEffectPersonFromString(this.AllPersons, this.GameCommonData.AllTroopEventEffects, reader["EffectPersons"].ToString());
                    te.LoadEffectAreaFromString(this.GameCommonData.AllTroopEventEffects, reader["EffectAreas"].ToString());
                    try
                    {
                        te.Image = reader["ShowImage"].ToString();
                        te.Sound = reader["ShowSound"].ToString();
                    }
                    catch
                    {
                        te.Image = "";
                        te.Sound = "";
                    }
                    this.TroopEvents.AddTroopEventWithEvent(te);
                }
                catch (FormatException ex)
                {
                    errorMsg.Add("部队事件ID" + te.ID + "：读取字串转化成数字出错，请检查所有字串格式，对话里数字与字串以半型空格分隔");
                }
            }
            DbConnection.Close();
            try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From Event", DbConnection).ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        Event e = new Event();
                        e.Scenario = this;
                        e.ID = (short)reader["ID"];
                        try
                        {
                            e.Name = reader["Name"].ToString();
                            e.happened = (bool)reader["Happened"];
                            e.repeatable = (bool)reader["Repeatable"];
                            e.AfterEventHappened = (short)reader["AfterEventHappened"];
                            e.happenChance = (short)reader["Chance"];
                            e.LoadPersonIdFromString(this.Persons, reader["PersonId"].ToString());
                            e.LoadPersonCondFromString(this.GameCommonData.AllConditions, reader["PersonCond"].ToString());
                            e.LoadArchitectureFromString(this.Architectures, reader["ArchitectureID"].ToString());
                            e.LoadArchitctureCondFromString(this.GameCommonData.AllConditions, reader["ArchitectureCond"].ToString());
                            e.LoadFactionFromString(this.Factions, reader["FactionID"].ToString());
                            e.LoadFactionCondFromString(this.GameCommonData.AllConditions, reader["FactionCond"].ToString());
                            e.LoadDialogFromString(reader["Dialog"].ToString());
                            e.LoadEffectFromString(this.GameCommonData.AllEventEffects, reader["Effect"].ToString());
                            e.LoadArchitectureEffectFromString(this.GameCommonData.AllEventEffects, reader["ArchitectureEffect"].ToString());
                            e.LoadFactionEffectFromString(this.GameCommonData.AllEventEffects, reader["FactionEffect"].ToString());
                            try
                            {
                                e.nextScenario = reader["NextScenario"].ToString();
                            }
                            catch
                            {
                                e.nextScenario = "";
                            }
                            try
                            {
                                e.Image = reader["ShowImage"].ToString();
                                e.Sound = reader["ShowSound"].ToString();
                                e.GloballyDisplayed = (bool)reader["GloballyDisplayed"];
                                e.StartYear = (int)reader["StartYear"];
                                e.StartMonth = (int)reader["StartMonth"];
                                e.EndYear = (int)reader["EndYear"];
                                e.EndMonth = (int)reader["EndMonth"];
                            }
                            catch
                            {
                                e.Image = "";
                                e.Sound = "";
                            }
                            try
                            {
                                e.LoadScenBiographyFromString(reader["ScenBiography"].ToString());
                            }
                            catch
                            {

                            }
                            this.AllEvents.AddEventWithEvent(e);
                        }
                        catch (FormatException)
                        {
                            errorMsg.Add("事件ID" + e.ID + "：读取字串转化成数字出错，请检查所有字串格式，对话里数字与字串以半型空格分隔");
                        }
                    }
                    catch
                    {
                        //ignore this event
                    }
                }
            }
            catch
            {
                
                //ignore, let there be empty event list
            }
            finally
            {
                DbConnection.Close();
            }
            try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From YearTable", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["ID"];
                    int year = (short)reader["GYear"];
                    int month = (short)reader["GMonth"];
                    int day = (short)reader["GDay"];
                    FactionList faction = new FactionList();
                    faction.LoadFromString(this.Factions, (string)reader["Faction"]);
                    string content = (string)reader["Content"];
                    bool isGlobal = (bool)reader["IsGloballyKnown"];
                    this.YearTable.addTableEntry(id, new GameDate(year, month, day), faction, content, isGlobal);
                }
            }
            catch
            {
                //ignore, let there be empty yeartable
            }
            finally
            {
                DbConnection.Close();
            }
            /*try
            {
                DbConnection.Open();
                reader = new OleDbCommand("Select * From AAPaths", DbConnection).ExecuteReader();
                while (reader.Read())
                {
                    int aid1 = (short)reader["Architecture1"];
                    int aid2 = (short)reader["Architecture2"];
                    if (aid1 == aid2) continue;
                    int kid = (short)reader["MilitaryKind"];
                    Architecture a1 = this.Architectures.GetGameObject(aid1) as Architecture;
                    Architecture a2 = this.Architectures.GetGameObject(aid2) as Architecture;
                    MilitaryKind mk = this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(kid);
                    List<Point> path = new List<Point>();
                    StaticMethods.LoadFromString(path, (string)reader["Path"]);
                    this.pathCache[new PathCacheKey(a1, a2, mk)] = path;
                }
            }
            catch
            {
                //ignore, let there be empty cache
            }
            finally
            {
                DbConnection.Close();
            }*/

            foreach (Person p in this.Persons)
            {
                if (p.Status == PersonStatus.Normal || p.Status == PersonStatus.Moving)
                {
                    if (p.LocationArchitecture != null && p.LocationArchitecture.BelongedFaction == null)
                    {
                        errorMsg.Add("武将ID" + p.ID + "在一座没有势力的城池仕官");
                        if (p.Status == PersonStatus.Normal)
                        {
                            p.Status = PersonStatus.NoFaction;
                        }
                        else
                        {
                            p.Status = PersonStatus.NoFactionMoving;
                        }
                    }
                }
                if (p.Status == PersonStatus.Moving || p.Status == PersonStatus.NoFactionMoving)
                {
                    if (p.ArrivingDays <= 0)
                    {
                        errorMsg.Add("武将ID" + p.ID + "正移动，但没有移动天数");
                        p.ArrivingDays = 1;
                    }
                }
                if (p.Available && p.Alive && p.LocationArchitecture == null && p.LocationTroop == null && (p.ID < 7000 || p.ID >= 8000))
                {
                    if (p.Status != PersonStatus.Princess)
                    {
                        errorMsg.Add("武将ID" + p.ID + "已登场，但没有所属建筑");
                        p.Available = false;
                        p.Alive = false;
                        p.Status = PersonStatus.None;
                    }
                }
            }

            this.AllPersons.Clear();
            this.AllArchitectures.Clear();

            this.alterTransportShipAdaptibility();

            using (TextWriter tw = new StreamWriter(SCENARIO_ERROR_TEXT_FILE)) {
                foreach (string s in errorMsg)
                {
                    tw.WriteLine(s);
                }
            }

            ExtensionInterface.call("Load", new Object[] { this });

            return errorMsg;
        }

        private void alterTransportShipAdaptibility()
        {
            MilitaryKind militaryKind = this.GameCommonData.AllMilitaryKinds.GetMilitaryKind(28);
            if (GlobalVariables.LandArmyCanGoDownWater)
            {
                militaryKind.OneAdaptabilityKind = 0;
                /*militaryKind.PlainAdaptability = 5;
                militaryKind.GrasslandAdaptability = 5;
                militaryKind.ForrestAdaptability = 6;
                militaryKind.MarshAdaptability = 100;
                militaryKind.MountainAdaptability = 10;
                militaryKind.WaterAdaptability = 5;
                militaryKind.RidgeAdaptability = 100;
                militaryKind.WastelandAdaptability = 6;
                militaryKind.DesertAdaptability = 10;
                militaryKind.CliffAdaptability = 7;*/
            }
            else
            {
                militaryKind.OneAdaptabilityKind = 6;
                militaryKind.PlainAdaptability = 100;
                militaryKind.GrasslandAdaptability = 100;
                militaryKind.ForrestAdaptability = 100;
                militaryKind.MarshAdaptability = 100;
                militaryKind.MountainAdaptability = 100;
                //militaryKind.WaterAdaptability = 5;
                militaryKind.RidgeAdaptability = 100;
                militaryKind.WastelandAdaptability = 100;
                militaryKind.DesertAdaptability = 100;
                militaryKind.CliffAdaptability = 100;
            }
        }

        private void ApplyInformations()
        {
            foreach (Information i in this.Informations)
            {
                i.Apply();
            }
        }

        private void ForceOptionsOnAutoplay()
        {
            if (this.PlayerFactions.Count == 0)
            {
                GlobalVariables.SkyEye = true;
                GlobalVariables.EnableCheat = true;
                GlobalVariables.HardcoreMode = false;
            }
        }

        public bool LoadGameScenarioFromDatabase(string connectionString, List<int> playerFactions)
        {
            this.Clear();
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            this.LoadGameDataFromDataBase(dbConnection, connectionString, true);
            OleDbCommand command = new OleDbCommand("Select * From GameData", dbConnection);
            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();

            if (playerFactions.Count > 0)
            {
                foreach (int i in playerFactions)
                {
                    this.PlayerFactions.Add(this.Factions.GetGameObject(i));
                }
                this.CurrentPlayer = this.Factions.GetGameObject(playerFactions[0]) as Faction;
                this.CurrentFaction = this.CurrentPlayer;
                this.Factions.RunningFaction = this.CurrentPlayer;
            }
            else
            {
                this.PlayerFactions.LoadFromString(this.Factions, reader["PlayerList"].ToString());
                int iD = (short)reader["CurrentPlayer"];
                if (iD >= 0)
                {
                    this.CurrentPlayer = this.Factions.GetGameObject(iD) as Faction;
                    this.CurrentFaction = this.CurrentPlayer;
                    this.Factions.RunningFaction = this.CurrentPlayer;
                }
            }

            this.Factions.LoadQueueFromString(reader["FactionQueue"].ToString());
            this.FireTable.LoadFromString(reader["FireTable"].ToString());
            this.NoFoodDictionary.LoadFromString(reader["NoFoodTable"].ToString());
            dbConnection.Close();

            this.InitPluginsWithScenario();
            this.InitializeMapData();
            this.TroopAnimations.UpdateDirectionAnimations(this.ScenarioMap.TileWidth);
            this.ApplyFireTable();
            this.InitializeArchitectureMapTile();
            this.InitializeFactionData();
            this.ApplyInformations();
            this.Preparing = true;
            this.Factions.BuildQueue(true);
            this.Factions.ApplyInfluences();
            this.Architectures.ApplyInfluences();
            this.Persons.ApplyInfluences();
            this.Preparing = false;
            this.InitialGameData();
            if (this.OnAfterLoadScenario != null)
            {
                this.OnAfterLoadScenario(this);
            }
            this.detectCurrentPlayerBattleState(this.CurrentPlayer);

            if (playerFactions.Count == 0)
            {
                this.ForceOptionsOnAutoplay();
            }

            this.LoadedFileName = "";
            return true;
        }

        public void InitPluginsWithScenario()
        {
            if (this.GameScreen != null)
            {
                foreach (GameObject plugin in this.GameScreen.PluginList)
                {
                    if (plugin is IScenarioAwarePlugin)
                    {
                        ((IScenarioAwarePlugin)plugin).SetScenario(this);
                    }
                }
            }
        }

        public bool LoadGameScenarioFromDatabase(string connectionString)  //读取剧本
        {
            return this.LoadGameScenarioFromDatabase(connectionString, new List<int>());
        }

        public bool LoadSaveFileFromDatabase(string connectionString, String LoadedFileName) //读取存档
        {
            this.Clear();

            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            this.LoadGameDataFromDataBase(dbConnection, connectionString, false);
            OleDbCommand command = new OleDbCommand("Select * From GameData", dbConnection);
            dbConnection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            this.PlayerFactions.LoadFromString(this.Factions, reader["PlayerList"].ToString());
            this.CurrentPlayer = this.Factions.GetGameObject((short)reader["CurrentPlayer"]) as Faction;
            this.CurrentFaction = this.CurrentPlayer;
            this.Factions.RunningFaction = this.CurrentPlayer;
            this.Factions.LoadQueueFromString(reader["FactionQueue"].ToString());
            this.FireTable.LoadFromString(reader["FireTable"].ToString());
            this.NoFoodDictionary.LoadFromString(reader["NoFoodTable"].ToString());
            try
            {
                this.DaySince = (int)reader["DaySince"];
            }
            catch
            {
            }
            dbConnection.Close();

            this.InitPluginsWithScenario();
            this.InitializeMapData();
            this.TroopAnimations.UpdateDirectionAnimations(this.ScenarioMap.TileWidth);
            this.ApplyFireTable();
            this.InitializeArchitectureMapTile();
            this.InitializeFactionData();
            this.ApplyInformations();
            this.Preparing = true;
            this.Factions.ApplyInfluences();
            this.Architectures.ApplyInfluences();
            this.Persons.ApplyInfluences();
            this.Preparing = false;
            this.InitialGameData();
            if (this.OnAfterLoadScenario != null)
            {
                this.OnAfterLoadScenario(this);
            }
            this.detectCurrentPlayerBattleState(this.CurrentPlayer);
            if (this.PlayerFactions.Count == 0)
            {
                oldDialogShowTime = GlobalVariables.DialogShowTime;
                GlobalVariables.DialogShowTime = 0;
            }
            else
            {
                if (oldDialogShowTime >= 0)
                {
                    GlobalVariables.DialogShowTime = oldDialogShowTime;
                }
            }
            this.ForceOptionsOnAutoplay();
            this.LoadedFileName = LoadedFileName;
            return true;
        }
        private int oldDialogShowTime = -1;

        public void MonthPassedEvent()
        {
            ExtensionInterface.call("MonthEvent", new Object[] { this });
            foreach (Faction faction in this.Factions.GetRandomList())
            {
                faction.MonthEvent();   
            }
            foreach (Person person in this.Persons)
            {
                person.TryToBeAvailable();
            }
            this.AddPreparedAvailablePersons();
            foreach (Person person in this.AvailablePersons.GetRandomList())
            {
                person.MonthEvent();
            }
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.MonthEvent();
            }
            foreach (MilitaryKind kind in this.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
            {
                bool flag = true;
                foreach (Troop troop in this.Troops)
                {
                    if ((troop.Army.Kind == kind) && this.GameScreen.TileInScreen(troop.Position))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    kind.Textures.Dispose();
                }
            }
        }

        private void AdjustGlobalPersonRelation()
        {
            foreach (Person p in this.Persons)
            {
                if (p.Available && p.Alive && GameObject.Random(30) == 0)
                {
                    foreach (Person q in this.Persons)
                    {
                        if (p == q) continue;
                        if (!q.Alive)
                        {
                            p.SetRelation(q, 0);
                            q.SetRelation(p, 0);
                            continue;
                        }
                        if (!q.Available) continue;
                        if (p.GetRelation(q) > 0)
                        {
                            if (p.LocationArchitecture == q.LocationArchitecture || p.LocationTroop == q.LocationTroop)
                            {
                                p.AdjustRelation(q, -0.3f, 1 + GameObject.Random(5));
                            }

                            int g = p.PersonalLoyalty - 3 + (GameObject.Random(5) - 2);
                            if (p.Closes(q)) 
                            {
                                g = Math.Max(g, 0);
                            }
                            p.AdjustRelation(q, 0, g);

                            if (p.GetRelation(q) < 0)
                            {
                                p.SetRelation(q, 0);
                            }
                        }
                        else if (p.GetRelation(q) < 0)
                        {
                            if (p.LocationArchitecture == q.LocationArchitecture || p.LocationTroop == q.LocationTroop)
                            {
                                p.AdjustRelation(q, 0.3f, -1 - GameObject.Random(5));
                            }

                            int g = p.PersonalLoyalty - 1 + (GameObject.Random(5) - 2);
                            if (p.Hates(q))
                            {
                                g = Math.Min(-5, g);
                            }
                            p.AdjustRelation(q, 0, g);

                            if (p.GetRelation(q) > 0)
                            {
                                p.SetRelation(q, 0);
                            }
                        }
                    }
                }
            }
        }

        public void MonthStartingEvent()
        {
        }

        public void SeasonChangeEvent()
        {
            if (!this.scenarioJustLoaded)
            {
                ExtensionInterface.call("SeasonEvent", new Object[] { this });
                if ((this.Date.Month == 3 || this.Date.Month == 6 || this.Date.Month == 9 || this.Date.Month == 12) && this.Date.Day == 1)
                {
                    foreach (Faction faction in this.Factions.GetRandomList())
                    {
                        faction.SeasonEvent();
                    }
                    foreach (Architecture architecture in this.Architectures.GetRandomList())
                    {
                        architecture.DevelopSeason();
                    }
                }
            }
        }

        public bool MoreThanOneTroopOnPosition(Point position)
        {
            return (this.MapTileData[position.X, position.Y].TroopCount > 1);
        }

        internal void NewFaction()
        {
            if (GameObject.Random(15) == 0) 
            {
                this.NewFaction(this.AvailablePersons);
            }
        }

        internal void NewFaction(PersonList candidates)
        {
            if (GlobalVariables.WujiangYoukenengDuli == false) return;

            PersonList list = new PersonList();
            foreach (Person person in candidates)
            {
                if (person.YoukenengChuangjianXinShili())   //里面包含武将有可能独立的参数
                {
                    if ((person.Ambition > 1 && GameObject.Random((5 - person.Ambition) * (5 - person.Ambition) * (5 - person.Ambition)) == 0) || 
                        (person.BelongedFaction != null && person.Hates(person.BelongedFaction.Leader)))
                    {
                        list.Add(person);
                    }
                }
            }
            if (list.Count > 0)
            {
                Person person3 = list[GameObject.Random(list.Count)] as Person;
                Architecture location = person3.BelongedArchitecture;
                Faction faction = person3.BelongedFaction;
                if (location == null) return;
                if (faction != null && !person3.Hates(faction.Leader))
                {
                    if (person3.Loyalty >= 100) return;
                    if (person3.Loyalty >= 90 && !person3.LeaderPossibility) return;
                }
                if (faction != null && Person.GetIdealOffset(faction.Leader, person3) <= 10 && !person3.Hates(faction.Leader)) return;
                if (faction != null && location == faction.Capital) return;
                //if (GameObject.Random(15) != 0) return;
                if (GameObject.Random(location.Population + location.ArmyScale * 5000 +
                        location.Domination * 200 + location.Morale * 10) >
                    GameObject.Random(person3.Reputation *
                    (person3.LeaderPossibility ? 3 : 1) *
                    (faction != null && person3.Hates(faction.Leader) ? 10 : 1) *
                    (faction == null ? 2 : 1))) return;
                this.CreateNewFaction(person3);
            }
        }

        private void NoFoodPositionDayEvent()
        {
            List<NoFoodPosition> list = new List<NoFoodPosition>();
            foreach (NoFoodPosition position in this.NoFoodDictionary.Positions.Values)
            {
                position.Days--;
                if (position.Days <= 0)
                {
                    list.Add(position);
                }
            }
            foreach (NoFoodPosition position in list)
            {
                this.NoFoodDictionary.RemovePosition(position);
            }
        }

        public bool PositionIsArchitecture(Point position)
        {
            return (this.GetArchitectureByPosition(position) != null);
        }

        public bool PositionIsOnFire(Point position)
        {
            if (this.PositionOutOfRange(position))
            {
                return false;
            }
            return this.FireTable.HasPosition(position);
        }

        public bool PositionIsOnFireNoCheck(Point position)
        {
            return this.FireTable.HasPosition(position);
        }

        public bool PositionIsTroop(Point position)
        {
            return (this.GetTroopByPosition(position) != null);
        }

        public bool PositionOutOfRange(Point position)
        {
            return this.ScenarioMap.PositionOutOfRange(position);
        }

        public string PositionString(Point position)
        {

            if (this.PositionIsArchitecture(position))
            {
                return this.GetArchitectureByPositionNoCheck(position).Name;
            }
            /*
            if (this.PositionIsTroop(position))
            {
                return this.GetTroopByPositionNoCheck(position).DisplayName;
            }
            */
            return (this.GetTerrainNameByPosition(position) + " " + this.GetCoordinateString(position));
        }

        public void ReflectDiplomaticRelations(int src, int des, int offset)
        {
            foreach (DiplomaticRelation relation in this.DiplomaticRelations.GetDiplomaticRelationListByFactionID(des))
            {
                int theOtherFactionID = relation.GetTheOtherFactionID(des);
                if ((theOtherFactionID != src) && (Math.Abs(relation.Relation) >= 100))
                {
                    int num2 = this.DiplomaticRelations.GetDiplomaticRelation(this, src, theOtherFactionID).Relation;
                    if ((num2 > -GlobalVariables.FriendlyDiplomacyThreshold) && (num2 < GlobalVariables.FriendlyDiplomacyThreshold))
                    {
                        int num3 = relation.Relation;
                        if (num3 > 0x3e8)
                        {
                            num3 = 0x3e8;
                        }
                        else if (num3 < -0x3e8)
                        {
                            num3 = -0x3e8;
                        }
                        this.ChangeDiplomaticRelation(src, theOtherFactionID, (offset * num3) / 0x3e8);
                    }
                }
            }
        }

        public void RemovePositionAreaInfluence(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                Troop troopByPositionNoCheck = this.GetTroopByPositionNoCheck(position);
                this.MapTileData[position.X, position.Y].RemoveAreaInfluence(troop, troopByPositionNoCheck);
                if (troopByPositionNoCheck != null)
                {
                    troopByPositionNoCheck.RefreshDataOfAreaInfluence();
                }
            }
        }

        public void RemovePositionContactingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveContactingTroop(troop);
            }
        }

        public void RemovePositionOffencingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveOffencingTroop(troop);
            }
        }

        public void RemovePositionStratagemingTroop(Troop troop, Point position)
        {
            if (!this.PositionOutOfRange(position))
            {
                this.MapTileData[position.X, position.Y].RemoveStratagemingTroop(troop);
            }
        }

        public void RemovePositionViewingTroopNoCheck(Troop troop, Point position)
        {
            this.MapTileData[position.X, position.Y].RemoveViewingTroop(troop);
        }

        public void RemoveRouteway(Routeway routeway)
        {
            if (routeway.FirstPoint != null)
            {
                routeway.CutAt(routeway.FirstPoint.Position);
            }
            if (routeway.StartArchitecture != null)
            {
                routeway.StartArchitecture.Routeways.Remove(routeway);
            }
            if (routeway.BelongedFaction != null)
            {
                routeway.BelongedFaction.RemoveRouteway(routeway);
            }
            this.Routeways.Remove(routeway);
        }

        public void ResetMapTileTroop(Point position)
        {
            if (this.MapTileData[position.X, position.Y].TileTroop != null && this.MapTileData[position.X, position.Y].TileTroop.Destroyed)
            {
                TileData data1 = this.MapTileData[position.X, position.Y];
                data1.TroopCount--;
                this.MapTileData[position.X, position.Y].TileTroop = null;
            }
        }

        public bool SaveGameScenarioToDatabase(string connectionString, bool saveMap, bool saveCommonData)
        {
            ClearPersonStatusCache();
            ClearPersonWorkCache();
            //try
            //{
            //this.DisposeLotsOfMemory();
            using (OleDbConnection selectConnection = new OleDbConnection(connectionString))
            {
                selectConnection.Open();
                DataSet dataSet = new DataSet();
                DataRow row = null;
                OleDbDataAdapter adapter;
                OleDbCommandBuilder builder;
                if (saveMap)
                {
                    new OleDbCommand("Delete from Map", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from Map", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "Map");
                    row = dataSet.Tables["Map"].NewRow();
                    row.BeginEdit();
                    row["TileWidth"] = this.ScenarioMap.TileWidth;
                    row["DimensionX"] = this.ScenarioMap.MapDimensions.X;
                    row["DimensionY"] = this.ScenarioMap.MapDimensions.Y;
                    row["MapData"] = this.ScenarioMap.SaveToString();
                    row["FileName"] = this.ScenarioMap.MapName;
                    row["kuaishu"] = this.ScenarioMap.NumberOfTiles;
                    row["meikuaidexiaokuaishu"] = this.ScenarioMap.NumberOfSquaresInEachTile;
                    row["useSimpleArchImages"] = this.ScenarioMap.UseSimpleArchImages;
                    row.EndEdit();
                    dataSet.Tables["Map"].Rows.Add(row);
                    adapter.Update(dataSet, "Map");
                    dataSet.Clear();
                }
                new OleDbCommand("Delete from DiplomaticRelation", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from DiplomaticRelation", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "DiplomaticRelation");
                dataSet.Tables["DiplomaticRelation"].Rows.Clear();
                foreach (DiplomaticRelation relation in this.DiplomaticRelations.DiplomaticRelations.Values)
                {
                    row = dataSet.Tables["DiplomaticRelation"].NewRow();
                    row.BeginEdit();
                    row["Faction1ID"] = relation.RelationFaction1ID;
                    row["Faction2ID"] = relation.RelationFaction2ID;
                    row["Relation"] = relation.Relation;
                    row["Truce"] = relation.Truce;
                    row.EndEdit();
                    dataSet.Tables["DiplomaticRelation"].Rows.Add(row);
                }
                adapter.Update(dataSet, "DiplomaticRelation");
                dataSet.Clear();
                new OleDbCommand("Delete from Faction", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Faction", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Faction");
                dataSet.Tables["Faction"].Rows.Clear();
                foreach (Faction faction in this.Factions)
                {
                    row = dataSet.Tables["Faction"].NewRow();
                    row.BeginEdit();
                    row["ID"] = faction.ID;
                    row["Passed"] = faction.Passed;
                    row["PreUserControlFinished"] = faction.PreUserControlFinished;
                    row["Controlling"] = faction.Controlling;
                    row["LeaderID"] = faction.LeaderID;
                    row["PrinceID"] = faction.PrinceID;
                    row["ColorIndex"] = faction.ColorIndex;
                    row["FName"] = faction.Name;
                    row["CapitalID"] = faction.CapitalID;
                    row["Reputation"] = faction.Reputation;
                    row["TechniquePoint"] = faction.TechniquePoint;
                    row["TechniquePointForTechnique"] = faction.TechniquePointForTechnique;
                    row["TechniquePointForFacility"] = faction.TechniquePointForFacility;
                    row["Sections"] = faction.Sections.SaveToString();
                    row["Architectures"] = faction.Architectures.SaveToString();
                    row["Troops"] = faction.Troops.SaveToString();
                    row["Informations"] = faction.Informations.SaveToString();
                    row["Routeways"] = faction.Routeways.SaveToString();
                    row["Legions"] = faction.Legions.SaveToString();
                    row["BaseMilitaryKinds"] = faction.BaseMilitaryKinds.SaveToString();
                    row["UpgradingTechnique"] = faction.UpgradingTechnique;
                    row["UpgradingDaysLeft"] = faction.UpgradingDaysLeft;
                    row["AvailableTechniques"] = faction.AvailableTechniques.SaveToString();
                    row["PreferredTechniqueKinds"] = StaticMethods.SaveToString(faction.PreferredTechniqueKinds);
                    row["PlanTechnique"] = (faction.PlanTechnique != null) ? faction.PlanTechnique.ID : -1;
                    row["AutoRefuse"] = faction.AutoRefuse;
                    row["chaotinggongxiandu"] = faction.chaotinggongxiandu;
                    row["guanjue"] = faction.guanjue;
                    row["IsAlien"] = faction.IsAlien;
                    row["NotPlayerSelectable"] = faction.NotPlayerSelectable;
                    row["CreatePersonTimes"] = faction.CreatePersonTimes;
                    row["YearOfficialLimit"] = faction.YearOfficialLimit;
                    row["MilitaryCount"] = faction.MilitaryCount;
                    row["TransferingMilitaryCount"] = faction.TransferingMilitaryCount;
                    row["GetGeneratorPersonCount"] = faction.SaveGeneratorPersonCountToString();
                    row["TransferingMilitaries"] = faction.TransferingMilitaries.SaveToString();
                    row["Militaries"] = faction.Militaries.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Faction"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Faction");
                dataSet.Clear();
                new OleDbCommand("Delete from Sections", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Sections", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Sections");
                dataSet.Tables["Sections"].Rows.Clear();
                foreach (Section section in this.Sections)
                {
                    section.EnsureSectionArchitecture();
                    row = dataSet.Tables["Sections"].NewRow();
                    row.BeginEdit();
                    row["ID"] = section.ID;
                    row["AIDetail"] = section.AIDetail.ID;
                    row["Name"] = section.Name;
                    row["OrientationFaction"] = (section.OrientationFaction != null) ? section.OrientationFaction.ID : -1;
                    row["OrientationSection"] = (section.OrientationSection != null) ? section.OrientationSection.ID : -1;
                    row["OrientationState"] = (section.OrientationState != null) ? section.OrientationState.ID : -1;
                    row["OrientationArchitecture"] = (section.OrientationArchitecture != null) ? section.OrientationArchitecture.ID : -1;
                    row["Architectures"] = section.Architectures.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Sections"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Sections");
                dataSet.Clear();
                new OleDbCommand("Delete from Architecture", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Architecture", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Architecture");
                dataSet.Tables["Architecture"].Rows.Clear();
                foreach (Architecture architecture in this.Architectures)
                {
                    row = dataSet.Tables["Architecture"].NewRow();
                    row.BeginEdit();
                    row["ID"] = architecture.ID;
                    row["MayorID"] = architecture.MayorID; //太守
                    row["CaptionID"] = architecture.CaptionID;
                    row["Name"] = architecture.Name;
                    row["Kind"] = architecture.Kind.ID;
                    row["IsStrategicCenter"] = architecture.IsStrategicCenter;
                    row["StateID"] = architecture.LocationState.ID;
                    row["Characteristics"] = architecture.Characteristics.SaveToString();
                    row["Area"] = StaticMethods.SaveToString(architecture.ArchitectureArea.Area);
                    row["Persons"] = architecture.Persons.SaveToString();
                    row["MovingPersons"] = architecture.MovingPersons.SaveToString();
                    row["NoFactionPersons"] = architecture.NoFactionPersons.SaveToString();
                    row["NoFactionMovingPersons"] = architecture.NoFactionMovingPersons.SaveToString();
                    row["Population"] = architecture.Population;
                    row["Fund"] = architecture.Fund;
                    row["Food"] = architecture.Food;
                    row["Agriculture"] = architecture.Agriculture;
                    row["Commerce"] = architecture.Commerce;
                    row["Technology"] = architecture.Technology;
                    row["Domination"] = architecture.Domination;
                    row["Morale"] = architecture.Morale;
                    row["Endurance"] = architecture.Endurance;
                    row["AutoHiring"] = architecture.AutoHiring;
                    row["AutoRewarding"] = architecture.AutoRewarding;
                    row["AutoWorking"] = architecture.AutoWorking;
                    row["AutoSearching"] = architecture.AutoSearching;
                    row["AutoRecruiting"] = architecture.AutoRecruiting;
                    //row["AutoZhaoXian"] = architecture.AutoZhaoXian;
                    row["HireFinished"] = architecture.HireFinished;
                    row["FacilityEnabled"] = architecture.FacilityEnabled;
                    row["AgricultureWorkingPersons"] = architecture.AgricultureWorkingPersons.SaveToString();
                    row["CommerceWorkingPersons"] = architecture.CommerceWorkingPersons.SaveToString();
                    row["TechnologyWorkingPersons"] = architecture.TechnologyWorkingPersons.SaveToString();
                    row["DominationWorkingPersons"] = architecture.DominationWorkingPersons.SaveToString();
                    row["MoraleWorkingPersons"] = architecture.MoraleWorkingPersons.SaveToString();
                    row["EnduranceWorkingPersons"] = architecture.EnduranceWorkingPersons.SaveToString();
                    row["zhenzaiWorkingPersons"] = architecture.ZhenzaiWorkingPersons.SaveToString();
                    row["TrainingWorkingPersons"] = architecture.TrainingWorkingPersons.SaveToString();
                    row["feiziliebiao"] = architecture.Feiziliebiao.SaveToString();

                    row["Militaries"] = architecture.Militaries.SaveToString();
                    row["Facilities"] = architecture.Facilities.SaveToString();
                    row["BuildingFacility"] = architecture.BuildingFacility;
                    row["BuildingDaysLeft"] = architecture.BuildingDaysLeft;
                    row["PlanFacilityKind"] = (architecture.PlanFacilityKind != null) ? architecture.PlanFacilityKind.ID : -1;
                    row["FundPacks"] = architecture.SaveFundPacksToString();
                    row["FoodPacks"] = architecture.SaveFoodPacksToString();
                   // row["SpyPacks"] = architecture.SaveSpyPacksToString();
                  //  row["TodayNewMilitarySpyMessage"] = (architecture.TodayNewMilitarySpyMessage != null) ? architecture.TodayNewMilitarySpyMessage.ID : -1;
                   // row["TodayNewTroopSpyMessage"] = (architecture.TodayNewTroopSpyMessage != null) ? architecture.TodayNewTroopSpyMessage.ID : -1;
                    row["PopulationPacks"] = architecture.SavePopulationPacksToString();
                    row["PlanArchitecture"] = (architecture.PlanArchitecture != null) ? architecture.PlanArchitecture.ID : -1;
                    row["TransferFundArchitecture"] = (architecture.TransferFundArchitecture != null) ? architecture.TransferFundArchitecture.ID : -1;
                    row["TransferFoodArchitecture"] = (architecture.TransferFoodArchitecture != null) ? architecture.TransferFoodArchitecture.ID : -1;
                    row["DefensiveLegion"] = (architecture.DefensiveLegion != null) ? architecture.DefensiveLegion.ID : -1;
                    row["Captives"] = architecture.Captives.SaveToString();
                    row["RobberTroop"] = (architecture.RobberTroop != null) ? architecture.RobberTroop.ID : -1;
                    row["RecentlyAttacked"] = architecture.RecentlyAttacked;
                    row["RecentlyBreaked"] = architecture.RecentlyBreaked;
                    row["AILandLinks"] = architecture.AILandLinks.SaveToString();
                    row["AIWaterLinks"] = architecture.AIWaterLinks.SaveToString();
                    row["youzainan"] = architecture.youzainan;
                    row["zainanleixing"] = architecture.zainan.zainanzhonglei.ID;
                    row["zainanshengyutianshu"] = architecture.zainan.shengyutianshu;
                    row["Emperor"] = architecture.huangdisuozai;
                    row["MilitaryPopulation"] = architecture.MilitaryPopulation;
                    row["Informations"] = architecture.Informations.SaveToString();
                    row["SuspendTroopTransfer"] = architecture.SuspendTroopTransfer;
                    //row["Battle"] = architecture.Battle == null ? -1 : architecture.Battle.ID;
                    row["OldFactionName"] = architecture.OldFactionName;
                    row.EndEdit();
                    dataSet.Tables["Architecture"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Architecture");
                dataSet.Clear();
                new OleDbCommand("Delete from Legion", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Legion", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Legion");
                dataSet.Tables["Legion"].Rows.Clear();
                foreach (Legion legion in this.Legions)
                {
                    row = dataSet.Tables["Legion"].NewRow();
                    row.BeginEdit();
                    row["ID"] = legion.ID;
                    row["Kind"] = (int)legion.Kind;
                    row["StartArchitecture"] = (legion.StartArchitecture != null) ? legion.StartArchitecture.ID : -1;
                    row["WillArchitecture"] = (legion.WillArchitecture != null) ? legion.WillArchitecture.ID : -1;
                    row["PreferredRouteway"] = (legion.PreferredRouteway != null) ? legion.PreferredRouteway.ID : -1;
                    row["InformationDestination"] = StaticMethods.SaveToString(legion.InformationDestination);
                    row["CoreTroop"] = (legion.CoreTroop != null) ? legion.CoreTroop.ID : -1;
                    row["Troops"] = legion.Troops.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Legion"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Legion");
                dataSet.Clear();
                new OleDbCommand("Delete from Troop", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Troop", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Troop");
                dataSet.Tables["Troop"].Rows.Clear();
                foreach (Troop troop in this.Troops)
                {
                    row = dataSet.Tables["Troop"].NewRow();
                    row.BeginEdit();
                    row["ID"] = troop.ID;
                    row["LeaderID"] = troop.Leader.ID;
                    row["Controllable"] = troop.Controllable;
                    row["Status"] = troop.Status;
                    row["Direction"] = troop.Direction;
                    row["Auto"] = troop.Auto;
                    row["Operated"] = troop.Operated;
                    row["Food"] = troop.Food;
                    row["zijin"] = troop.zijin;
                    row["StartingArchitecture"] = (troop.StartingArchitecture != null) ? troop.StartingArchitecture.ID : -1;
                    row["Persons"] = troop.SavePersonsToString();
                    row["PositionX"] = troop.Position.X;
                    row["PositionY"] = troop.Position.Y;
                    row["DestinationX"] = troop.Destination.X;
                    row["DestinationY"] = troop.Destination.Y;
                    row["RealDestinationX"] = troop.RealDestination.X;
                    row["RealDestinationY"] = troop.RealDestination.Y;
                    row["FirstTierPath"] = StaticMethods.SaveToString(troop.FirstTierPath);
                    row["SecondTierPath"] = StaticMethods.SaveToString(troop.SecondTierPath);
                    row["ThirdTierPath"] = StaticMethods.SaveToString(troop.ThirdTierPath);
                    row["FirstIndex"] = troop.FirstIndex;
                    row["SecondIndex"] = troop.SecondIndex;
                    row["ThirdIndex"] = troop.ThirdIndex;
                    row["MilitaryID"] = troop.MilitaryID;
                    row["AttackDefaultKind"] = troop.AttackDefaultKind;
                    row["AttackTargetKind"] = troop.AttackTargetKind;
                    row["TargetTroopID"] = troop.TargetTroopID;
                    row["TargetArchitectureID"] = troop.TargetArchitectureID;
                    row["WillTroopID"] = troop.RealWillTroop == null ? -1 : troop.RealWillTroop.ID;
                    row["WillArchitectureID"] = troop.RealWillArchitecture == null ? -1 : troop.RealWillArchitecture.ID;
                    row["CurrentCombatMethodID"] = troop.CurrentCombatMethodID;
                    row["CurrentStratagemID"] = troop.CurrentStratagemID;
                    row["SelfCastPositionX"] = troop.SelfCastPosition.X;
                    row["SelfCastPositionY"] = troop.SelfCastPosition.Y;
                    row["ChaosDayLeft"] = troop.ChaosDayLeft;
                    row["CutRoutewayDays"] = troop.CutRoutewayDays;
                    row["Captives"] = troop.Captives.SaveToString();
                    row["RecentlyFighting"] = troop.RecentlyFighting;
                    row["TechnologyIncrement"] = troop.TechnologyIncrement;
                    row["EventInfluences"] = troop.EventInfluences.SaveToString();
                    row["CurrentStunt"] = (troop.CurrentStunt != null) ? troop.CurrentStunt.ID : -1;
                    row["StuntDayLeft"] = troop.StuntDayLeft;
                    row["mingling"] = troop.mingling;
                    row["ManualControl"] = troop.ManualControl;
                    row["ForceTroopTarget"] = troop.ForceTroopTargetId;
                    row.EndEdit();
                    dataSet.Tables["Troop"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Troop");
                dataSet.Clear();
                if (saveMap)
                {
                    new OleDbCommand("Delete from TroopEvent", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from TroopEvent", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "TroopEvent");
                    dataSet.Tables["TroopEvent"].Rows.Clear();
                    foreach (TroopEvent event2 in this.TroopEvents)
                    {
                        row = dataSet.Tables["TroopEvent"].NewRow();
                        row.BeginEdit();
                        row["ID"] = event2.ID;
                        row["Name"] = event2.Name;
                        row["Happened"] = event2.Happened;
                        row["Repeatable"] = event2.Repeatable;
                        row["AfterEventHappened"] = (event2.AfterHappenedEvent != null) ? event2.AfterHappenedEvent.ID : -1;
                        row["LaunchPerson"] = (event2.LaunchPerson != null) ? event2.LaunchPerson.ID : -1;
                        row["Conditions"] = event2.Conditions.SaveToString();
                        row["Chance"] = event2.HappenChance;
                        row["CheckAreaKind"] = event2.CheckArea;
                        row["TargetPersons"] = event2.SaveTargetPersonToString();
                        row["Dialogs"] = event2.SaveDialogToString();
                        row["EffectSelf"] = event2.SaveSelfEffectToString();
                        row["EffectPersons"] = event2.SaveEffectPersonToString();
                        row["EffectAreas"] = event2.SaveEffectAreaToString();
                        row["ShowImage"] = event2.Image;
                        row["ShowSound"] = event2.Sound;
                        row.EndEdit();
                        dataSet.Tables["TroopEvent"].Rows.Add(row);
                    }
                    adapter.Update(dataSet, "TroopEvent");
                    dataSet.Clear();
                }
                new OleDbCommand("Delete from Routeway", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Routeway", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Routeway");
                dataSet.Tables["Routeway"].Rows.Clear();
                foreach (Routeway routeway in this.Routeways)
                {
                    if ((routeway.StartArchitecture != null) && ((routeway.Building || (routeway.LastActivePointIndex >= 0)) || (routeway.StartArchitecture.BelongedSection == null || (!routeway.StartArchitecture.BelongedSection.AIDetail.AutoRun && this.IsPlayer(routeway.StartArchitecture.BelongedFaction)))))
                    {
                        row = dataSet.Tables["Routeway"].NewRow();
                        row.BeginEdit();
                        row["ID"] = routeway.ID;
                        row["Building"] = routeway.Building;
                        row["ShowArea"] = routeway.ShowArea;
                        row["RemoveAfterClose"] = routeway.RemoveAfterClose;
                        row["InefficiencyDays"] = routeway.InefficiencyDays;
                        row["LastActivePointIndex"] = routeway.LastActivePointIndex;
                        row["StartArchitecture"] = (routeway.StartArchitecture != null) ? routeway.StartArchitecture.ID : -1;
                        row["EndArchitecture"] = (routeway.EndArchitecture != null) ? routeway.EndArchitecture.ID : -1;
                        row["DestinationArchitecture"] = (routeway.DestinationArchitecture != null) ? routeway.DestinationArchitecture.ID : -1;
                        row["Points"] = routeway.SaveRoutePointsToString();
                        row.EndEdit();
                        dataSet.Tables["Routeway"].Rows.Add(row);
                    }
                }
                adapter.Update(dataSet, "Routeway");
                dataSet.Clear();
                new OleDbCommand("Delete from Information", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Information", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Information");
                dataSet.Tables["Information"].Rows.Clear();
                foreach (Information information in this.Informations)
                {
                    row = dataSet.Tables["Information"].NewRow();
                    row.BeginEdit();
                    row["ID"] = information.ID;
                    row["iLevel"] = information.Level;
                    row["PositionX"] = information.Position.X;
                    row["PositionY"] = information.Position.Y;
                    row["Radius"] = information.Radius;
                    row["Oblique"] = information.Oblique;
                    row["DayCost"] = information.DayCost;
                    row["DaysLeft"] = information.DaysLeft;
                    row["DaysStarted"] = information.DaysStarted;
                    row.EndEdit();
                    dataSet.Tables["Information"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Information");
                dataSet.Clear();
                /*
                new OleDbCommand("Delete from SpyMessage", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from SpyMessage", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "SpyMessage");
                dataSet.Tables["SpyMessage"].Rows.Clear();
                foreach (SpyMessage message in this.SpyMessages)
                {
                    row = dataSet.Tables["SpyMessage"].NewRow();
                    row.BeginEdit();
                    row["ID"] = message.ID;
                    row["Kind"] = message.Kind;
                    row["MessageFaction"] = (message.MessageFaction != null) ? message.MessageFaction.ID : -1;
                    row["MessageArchitecture"] = (message.MessageArchitecture != null) ? message.MessageArchitecture.ID : -1;
                    row["PersonPacks"] = message.SavePersonPacksToString();
                    row["Message1"] = message.Message1;
                    row["Message2"] = message.Message2;
                    row["Message3"] = message.Message3;
                    row["Message4"] = message.Message4;
                    row["Message5"] = message.Message5;
                    row.EndEdit();
                    dataSet.Tables["SpyMessage"].Rows.Add(row);
                }
                adapter.Update(dataSet, "SpyMessage");
                dataSet.Clear();
                 */
                new OleDbCommand("Delete from Military", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Military", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Military");
                dataSet.Tables["Military"].Rows.Clear();
                foreach (Military military in this.Militaries)
                {
                    row = dataSet.Tables["Military"].NewRow();
                    row.BeginEdit();
                    row["ID"] = military.ID;
                    row["Name"] = military.Name;
                    row["KindID"] = military.RealKindID;
                    row["Quantity"] = military.Quantity;
                    row["Morale"] = military.Morale;
                    row["Combativity"] = military.Combativity;
                    row["Experience"] = military.Experience;
                    row["InjuryQuantity"] = military.InjuryQuantity;
                    row["FollowedLeaderID"] = (military.FollowedLeader != null) ? military.FollowedLeader.ID : -1;
                    row["LeaderID"] = (military.Leader != null) ? military.Leader.ID : -1;
                    row["LeaderExperience"] = military.LeaderExperience;
                    row["TrainingPersonID"] = -1;
                    row["RecruitmentPersonID"] = military.RecruitmentPerson == null ? -1 : military.RecruitmentPerson.ID;
                    row["ShelledMilitary"] = (military.ShelledMilitary != null) ? military.ShelledMilitary.ID : -1;
                    row["Tiredness"] = military.Tiredness;
                    row["ArrivingDays"] = military.ArrivingDays;
                    row["StartingArchitectureID"] = military.StartingArchitectureID;
                    row["TargetArchitectureID"] = military.TargetArchitectureID;
                    row.EndEdit();
                    dataSet.Tables["Military"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Military");
                dataSet.Clear();
                new OleDbCommand("Delete from Facility", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Facility", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Facility");
                dataSet.Tables["Facility"].Rows.Clear();
                foreach (Facility facility in this.Facilities)
                {
                    row = dataSet.Tables["Facility"].NewRow();
                    row.BeginEdit();
                    row["ID"] = facility.ID;
                    row["KindID"] = facility.KindID;
                    row["Endurance"] = facility.Endurance;
                    row.EndEdit();
                    dataSet.Tables["Facility"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Facility");
                dataSet.Clear();
                new OleDbCommand("Delete from Captive", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Captive", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Captive");
                dataSet.Tables["Captive"].Rows.Clear();
                foreach (Captive captive in this.Captives)
                {
                    row = dataSet.Tables["Captive"].NewRow();
                    row.BeginEdit();
                    row["ID"] = captive.ID;
                    row["CaptivePerson"] = (captive.CaptivePerson != null) ? captive.CaptivePerson.ID : -1;
                    row["CaptiveFaction"] = (captive.CaptiveFaction != null) ? captive.CaptiveFaction.ID : -1;
                    row["RansomArchitecture"] = (captive.RansomArchitecture != null) ? captive.RansomArchitecture.ID : -1;
                    row["RansomFund"] = captive.RansomFund;
                    row["RansomArriveDays"] = captive.RansomArriveDays;
                    row.EndEdit();
                    dataSet.Tables["Captive"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Captive");
                dataSet.Clear();
                new OleDbCommand("Delete from Person", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Person", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Person");
                dataSet.Tables["Person"].Rows.Clear();
                foreach (Person person in this.Persons)
                {
                    row = dataSet.Tables["Person"].NewRow();
                    row.BeginEdit();
                    row["ID"] = person.ID;
                    row["Available"] = person.Available;
                    row["Alive"] = person.Alive;
                    row["SurName"] = person.SurName;
                    row["GivenName"] = person.GivenName;
                    row["CalledName"] = person.CalledName;
                    row["Sex"] = person.Sex;
                    row["Pic"] = person.PictureIndex;
                    row["Ideal"] = person.Ideal;
                    row["UniqueTitles"] = person.UniqueTitles.SaveToString();
                    row["UniqueMilitaryKinds"] = person.UniqueMilitaryKinds.SaveToString();
                    row["IdealTendency"] = (person.IdealTendency != null) ? person.IdealTendency.ID : -1;
                    row["LeaderPossibility"] = person.LeaderPossibility;
                    row["PCharacter"] = person.Character.ID;
                    row["YearAvailable"] = person.YearAvailable;
                    row["YearBorn"] = person.YearBorn;
                    row["YearDead"] = person.YearDead;
                    row["DeadReason"] = (int)person.DeadReason;
                    row["Strength"] = person.BaseStrength;
                    row["Command"] = person.BaseCommand;
                    row["Intelligence"] = person.BaseIntelligence;
                    row["Politics"] = person.BasePolitics;
                    row["Glamour"] = person.BaseGlamour;
                    row["Reputation"] = person.Reputation;
                    row["UniqueTitles"] = person.UniqueTitles.SaveToString();
                    row["UniqueMilitaryKinds"] = person.UniqueMilitaryKinds.SaveToString();
                    row["StrengthExperience"] = person.StrengthExperience;
                    row["CommandExperience"] = person.CommandExperience;
                    row["IntelligenceExperience"] = person.IntelligenceExperience;
                    row["PoliticsExperience"] = person.PoliticsExperience;
                    row["GlamourExperience"] = person.GlamourExperience;
                    row["InternalExperience"] = person.InternalExperience;
                    row["TacticsExperience"] = person.TacticsExperience;
                    row["BubingExperience"] = person.BubingExperience;
                    row["NubingExperience"] = person.NubingExperience;
                    row["QibingExperience"] = person.QibingExperience;
                    row["ShuijunExperience"] = person.ShuijunExperience;
                    row["QixieExperience"] = person.QixieExperience;
                    row["StratagemExperience"] = person.StratagemExperience;
                    row["RoutCount"] = person.RoutCount;
                    row["RoutedCount"] = person.RoutedCount;
                    row["Braveness"] = person.BaseBraveness;
                    row["Calmness"] = person.BaseCalmness;
                    row["Loyalty"] = person.Loyalty;
                    row["BornRegion"] = (int)person.BornRegion;
                    row["AvailableLocation"] = person.AvailableLocation;
                    row["Strain"] = person.Strain;
                    row["Father"] = person.Father == null ? -1 : person.Father.ID;
                    row["Mother"] = person.Mother == null ? -1 : person.Mother.ID;
                    row["Spouse"] = person.Spouse == null ? -1 : person.Spouse.ID;

                    String brotherStr = "";
                    foreach (Person p in person.Brothers)
                    {
                        brotherStr += p.ID + " ";
                    }
                    row["Brother"] = brotherStr;

                    row["Generation"] = person.Generation;
                    row["PersonalLoyalty"] = (int)person.PersonalLoyalty;
                    row["Ambition"] = (int)person.Ambition;
                    row["Qualification"] = (int)person.Qualification;
                    row["ValuationOnGovernment"] = (int)person.ValuationOnGovernment;
                    row["StrategyTendency"] = (int)person.StrategyTendency;
                    row["OldFactionID"] = StaticMethods.SaveToString(person.JoinFactionID);
                    row["ProhibitedFactionID"] = StaticMethods.SaveToString(person.ProhibitedFactionID);
                    row["RewardFinished"] = person.RewardFinished;
                    row["WorkKind"] = person.WorkKind;
                    row["OldWorkKind"] = person.OldWorkKind;
                    row["TrainingMilitaryID"] = -1;
                    row["RecruitmentMilitaryID"] = person.RecruitmentMilitary == null ? -1 : person.RecruitmentMilitary.ID;
                    row["ArrivingDays"] = person.ArrivingDays;
                    row["TaskDays"] = person.TaskDays;
                    row["OutsideTask"] = person.OutsideTask;
                    row["OutsideDestination"] = StaticMethods.SaveToString(person.OutsideDestination);
                    row["ConvincingPerson"] = (person.ConvincingPerson != null) ? person.ConvincingPerson.ID : -1;
                    row["InformationKind"] = person.InformationKindID;

                    String closeStr = "";
                    String hatedStr = "";
                    foreach (Person p in person.GetClosePersons())
                    {
                        closeStr += p.ID + " ";
                    }
                    foreach (Person p in person.GetHatedPersons())
                    {
                        hatedStr += p.ID + " ";
                    }
                    row["ClosePersons"] = closeStr;
                    row["HatedPersons"] = hatedStr;

                    row["Skills"] = person.Skills.SaveToString();
                    row["Title"] = person.SaveTitleToString();
                    //row["Guanzhi"] = person.SaveGuanzhiToString(); 
                    row["StudyingTitle"] = (person.StudyingTitle != null) ? person.StudyingTitle.ID : -1;
                    row["Stunts"] = person.Stunts.SaveToString();
                    row["StudyingStunt"] = (person.StudyingStunt != null) ? person.StudyingStunt.ID : -1;
                    row["huaiyun"] = person.huaiyun;
                    row["faxianhuaiyun"] = person.faxianhuaiyun;
                    row["huaiyuntianshu"] = person.huaiyuntianshu;
                    row["NumberOfChildren"] = person.NumberOfChildren;
                    row["suoshurenwu"] = person.suoshurenwu;
                    row["WaitForFeizi"] = (person.WaitForFeiZi != null) ? person.WaitForFeiZi.ID : -1;
                    row["WaitForFeiziPeriod"] = person.WaitForFeiZiPeriod;
                    row["PreferredTroopPersons"] = person.preferredTroopPersons.SaveToString();
                    row["YearJoin"] = person.YearJoin;
                    row["TroopDamageDealt"] = person.TroopDamageDealt;
                    row["TroopBeDamageDealt"] = person.TroopBeDamageDealt;
                    row["ArchitectureDamageDealt"] = person.ArchitectureDamageDealt;
                    row["RebelCount"] = person.RebelCount;
                    row["ExecuteCount"] = person.ExecuteCount;
                    row["FleeCount"] = person.FleeCount;
                    row["CaptiveCount"] = person.CaptiveCount;
                    row["HeldCaptiveCount"] = person.HeldCaptiveCount;
                    row["StratagemSuccessCount"] = person.StratagemSuccessCount;
                    row["StratagemFailCount"] = person.StratagemFailCount;
                    row["StratagemBeSuccessCount"] = person.StratagemBeSuccessCount;
                    row["StratagemBeFailCount"] = person.StratagemBeFailCount;
                    row["Tiredness"] = person.Tiredness;
                    row["OfficerKillCount"] = person.OfficerKillCount;
                    row["InjureRate"] = person.InjureRate;
                   // row["Battle"] = person.Battle == null ? -1 : person.Battle.ID;
                    row["BattleSelfDamage"] = person.BattleSelfDamage;
                    row["Tags"] = person.Tags;
                   // row["Guanzhis"] = person.Guanzhis.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Person"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Person");
                dataSet.Clear();
                try
                {
                    new OleDbCommand("Delete from PersonRelation", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from PersonRelation", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "PersonRelation");
                    dataSet.Tables["PersonRelation"].Rows.Clear();
                    foreach (Person p in this.Persons)
                    {
                        foreach (KeyValuePair<Person, int> pi in p.GetRelations())
                        {
                            row = dataSet.Tables["PersonRelation"].NewRow();
                            row.BeginEdit();
                            row["Person1"] = p.ID;
                            row["Person2"] = pi.Key.ID;
                            row["Relation"] = pi.Value;
                            row.EndEdit();
                            dataSet.Tables["PersonRelation"].Rows.Add(row);
                        }
                    }
                    adapter.Update(dataSet, "PersonRelation");
                    dataSet.Clear();
                }
                catch (OleDbException)
                {
                    //ignore
                }
                /*
                try
                {
                    new OleDbCommand("Delete from OngoingBattle", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from OngoingBattle", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "OngoingBattle");
                    dataSet.Tables["OngoingBattle"].Rows.Clear();
                    foreach (OngoingBattle b in this.AllOngoingBattles)
                    {
                        row = dataSet.Tables["OngoingBattle"].NewRow();
                        row.BeginEdit();
                        row["ID"] = b.ID;
                        row["StartYear"] = b.StartYear;
                        row["StartMonth"] = b.StartMonth;
                        row["StartDay"] = b.StartDay;
                        row["CalmDay"] = b.CalmDay;
                        row["Skirmish"] = b.Skirmish;
                        row.EndEdit();
                        dataSet.Tables["OngoingBattle"].Rows.Add(row);
                    }
                    adapter.Update(dataSet, "OngoingBattle");
                    dataSet.Clear();
                } 
                catch (OleDbException)
                {
                    // ignore
                }
                */
                if (saveMap)
                {
                    new OleDbCommand("Delete from Region", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from Region", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "Region");
                    dataSet.Tables["Region"].Rows.Clear();
                    foreach (Region region in this.Regions)
                    {
                        row = dataSet.Tables["Region"].NewRow();
                        row.BeginEdit();
                        row["ID"] = region.ID;
                        row["Name"] = region.Name;
                        row["States"] = region.States.SaveToString();
                        row["RegionCore"] = (region.RegionCore != null) ? region.RegionCore.ID : -1;
                        row.EndEdit();
                        dataSet.Tables["Region"].Rows.Add(row);
                    }
                    adapter.Update(dataSet, "Region");
                    dataSet.Clear();
                    new OleDbCommand("Delete from State", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from State", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "State");
                    dataSet.Tables["State"].Rows.Clear();
                    foreach (State state in this.States)
                    {
                        row = dataSet.Tables["State"].NewRow();
                        row.BeginEdit();
                        row["ID"] = state.ID;
                        row["Name"] = state.Name;
                        row["ContactStates"] = state.ContactStates.SaveToString();
                        row["StateAdmin"] = (state.StateAdmin != null) ? state.StateAdmin.ID : -1;
                        row.EndEdit();
                        dataSet.Tables["State"].Rows.Add(row);
                    }
                    adapter.Update(dataSet, "State");
                    dataSet.Clear();
                }
                new OleDbCommand("Delete from Treasure", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Treasure", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Treasure");
                dataSet.Tables["Treasure"].Rows.Clear();
                foreach (Treasure treasure in this.Treasures)
                {
                    row = dataSet.Tables["Treasure"].NewRow();
                    row.BeginEdit();
                    row["ID"] = treasure.ID;
                    row["Name"] = treasure.Name;
                    row["Pic"] = treasure.Pic;
                    row["Available"] = treasure.Available;
                    row["AppearYear"] = treasure.AppearYear;
                    row["Worth"] = treasure.Worth;
                    row["Description"] = treasure.Description;
                    row["BelongedPerson"] = (treasure.BelongedPerson != null) ? treasure.BelongedPerson.ID : -1;
                    row["HidePlace"] = (treasure.HidePlace != null) ? treasure.HidePlace.ID : -1;
                    row["Influences"] = treasure.Influences.SaveToString();
                    try
                    {
                        row["TreasureGroup"] = treasure.TreasureGroup;
                    }
                    catch
                    {
                    }
                    row.EndEdit();
                    dataSet.Tables["Treasure"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Treasure");
                dataSet.Clear();
                new OleDbCommand("Delete from YearTable", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from YearTable", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "YearTable");
                dataSet.Tables["YearTable"].Rows.Clear();
                foreach (YearTableEntry yt in this.YearTable)
                {
                    row = dataSet.Tables["YearTable"].NewRow();
                    row.BeginEdit();
                    row["ID"] = yt.ID;
                    row["GYear"] = yt.Date.Year;
                    row["GMonth"] = yt.Date.Month;
                    row["GDay"] = yt.Date.Day;
                    string factionStr = "";
                    foreach (Faction f in yt.Factions)
                    {
                        factionStr += f.ID + " ";
                    }
                    row["Faction"] = factionStr;
                    row["Content"] = yt.Content;
                    row["IsGloballyKnown"] = yt.IsGloballyKnown;
                    row.EndEdit();
                    dataSet.Tables["YearTable"].Rows.Add(row);
                }
                adapter.Update(dataSet, "YearTable");
                dataSet.Clear();

                //try
                //{
                if (saveMap)
                {
                    new OleDbCommand("Delete from Event", selectConnection).ExecuteNonQuery();
                    adapter = new OleDbDataAdapter("Select * from Event", selectConnection);
                    builder = new OleDbCommandBuilder(adapter);
                    adapter.Fill(dataSet, "Event");
                    dataSet.Tables["Event"].Rows.Clear();
                    foreach (Event e in this.AllEvents)
                    {
                        row = dataSet.Tables["Event"].NewRow();
                        row.BeginEdit();
                        row["ID"] = e.ID;
                        row["Name"] = e.Name;
                        row["Happened"] = e.happened;
                        row["Repeatable"] = e.repeatable;
                        row["AfterEventHappened"] = e.AfterEventHappened;
                        row["Chance"] = e.happenChance;
                        row["PersonId"] = e.SavePersonIdToString();
                        row["PersonCond"] = e.SavePersonCondToString();
                        row["ArchitectureID"] = e.architecture.SaveToString();
                        row["ArchitectureCond"] = e.SaveArchitecureCondToString();
                        row["FactionID"] = e.faction.SaveToString();
                        row["FactionCond"] = e.SaveFactionCondToString();
                        row["Dialog"] = e.SaveDialogToString();
                        row["ScenBiography"] = e.SaveScenBiographyToString();
                        row["Effect"] = e.SaveEventEffectToString();
                        row["ArchitectureEffect"] = e.SaveArchitectureEffectToString();
                        row["FactionEffect"] = e.SaveFactionEffectToString();
                        row["ShowImage"] = e.Image;
                        row["ShowSound"] = e.Sound;
                        row["GloballyDisplayed"] = e.GloballyDisplayed;
                        row["StartYear"] = e.StartYear;
                        row["StartMonth"] = e.StartMonth;
                        row["EndYear"] = e.EndYear;
                        row["EndMonth"] = e.EndMonth;
                        row.EndEdit();
                        dataSet.Tables["Event"].Rows.Add(row);
                    }
                    adapter.Update(dataSet, "Event");
                    dataSet.Clear();
                }
                /*new OleDbCommand("Delete from AAPaths", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from AAPaths", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "AAPaths");
                dataSet.Tables["AAPaths"].Rows.Clear();
                foreach (KeyValuePair<PathCacheKey, List<Point>> kv in this.pathCache)
                {
                    row = dataSet.Tables["AAPaths"].NewRow();
                    row.BeginEdit();
                    row["Architecture1"] = kv.Key.a1.ID;
                    row["Architecture2"] = kv.Key.a2.ID;
                    row["MilitaryKind"] = kv.Key.k.ID;
                    row["Path"] = StaticMethods.SaveToString(kv.Value);
                    row.EndEdit();
                    dataSet.Tables["AAPaths"].Rows.Add(row);
                }
                adapter.Update(dataSet, "AAPaths");
                dataSet.Clear();*/

                //}
                //catch
                //{
                //}
                new OleDbCommand("Delete from GameData", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from GameData", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "GameData");
                row = dataSet.Tables["GameData"].NewRow();
                row.BeginEdit();
                row["CurrentPlayer"] = (this.CurrentPlayer != null) ? this.CurrentPlayer.ID : -1;
                row["PlayerList"] = this.PlayerFactions.SaveToString();
                row["FactionQueue"] = this.Factions.SaveQueueToString();
                row["FireTable"] = this.FireTable.SaveToString();
                row["NoFoodTable"] = this.NoFoodDictionary.SaveToString();
                row["DaySince"] = this.DaySince;
                row.EndEdit();
                dataSet.Tables["GameData"].Rows.Add(row);
                adapter.Update(dataSet, "GameData");
                dataSet.Clear();
                new OleDbCommand("Delete from GameSurvey", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from GameSurvey", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "GameSurvey");
                row = dataSet.Tables["GameSurvey"].NewRow();
                row.BeginEdit();
                row["Title"] = this.ScenarioTitle;
                row["Description"] = this.ScenarioDescription;
                row["GYear"] = (short)this.Date.Year;
                row["GMonth"] = (short)this.Date.Month;
                row["GDay"] = (short)this.Date.Day;
                DateTime now = DateTime.Now;
                row["SaveTime"] = string.Concat(new object[] { now.Year, "/", now.Month, "/", now.Day, " ", now.ToLongTimeString() });
                row["PlayerInfo"] = this.GetPlayerInfo();
                row["JumpPosition"] = StaticMethods.SaveToString(new Point?(this.ScenarioMap.JumpPosition));
                row.EndEdit();
                dataSet.Tables["GameSurvey"].Rows.Add(row);
                adapter.Update(dataSet, "GameSurvey");
                dataSet.Clear();
                if (this.OnAfterSaveScenario != null)
                {
                    this.OnAfterSaveScenario(this);
                }

                new OleDbCommand("Delete from Biography", selectConnection).ExecuteNonQuery();
                adapter = new OleDbDataAdapter("Select * from Biography", selectConnection);
                builder = new OleDbCommandBuilder(adapter);
                adapter.Fill(dataSet, "Biography");
                dataSet.Tables["Biography"].Rows.Clear();
                foreach (Biography i in this.AllBiographies.Biographys.Values)
                {
                    row = dataSet.Tables["Biography"].NewRow();
                    row.BeginEdit();
                    row["ID"] = i.ID;
                    row["Brief"] = i.Brief;
                    row["Romance"] = i.Romance;
                    row["History"] = i.History;
                    row["InGame"] = i.InGame;
                    row["FactionColor"] = i.FactionColor;
                    row["MilitaryKinds"] = i.MilitaryKinds.SaveToString();
                    row.EndEdit();
                    dataSet.Tables["Biography"].Rows.Add(row);
                }
                adapter.Update(dataSet, "Biography");
                dataSet.Clear();

                //}
                if (saveCommonData)
                {
                    GameCommonData.SaveAllToDatabase(connectionString);
                }
                else if (!UsingOwnCommonData)
                {
                    GameCommonData.DeleteCommonDataTables(connectionString);
                }
                selectConnection.Close();
            }
            /*catch 
            {
                //try to free as many memory as possible at this critical state
                this.DisposeLotsOfMemory();
                GC.Collect();
                throw;
            }*/
            ExtensionInterface.call("Save", new Object[] { this });
            return true;
        }

        public void DisposeLotsOfMemory()
        {
            foreach (MilitaryKind kind in this.GameCommonData.AllMilitaryKinds.MilitaryKinds.Values)
            {
                kind.Textures.Dispose();
            }
            foreach (Animation a in this.GameCommonData.AllTroopAnimations.Animations.Values)
            {
                a.disposeTexture();
            }
            foreach (Architecture a in this.Architectures)
            {
                if (a.CaptionTexture != null)
                {
                    a.CaptionTexture.Dispose();
                    a.CaptionTexture = null;
                }
            }
            foreach (ArchitectureKind k in this.GameCommonData.AllArchitectureKinds.ArchitectureKinds.Values)
            {
                if (k.Texture != null)
                {
                    k.ClearTexture();
                }
            }
            foreach (Treasure t in this.Treasures)
            {
                t.disposeTexture();
            }
            foreach (TerrainDetail t in this.GameCommonData.AllTerrainDetails.TerrainDetails.Values)
            {
                if (t.Textures != null)
                {
                    foreach (Texture u in t.Textures.BasicTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomEdgeTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomLeftCornerTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomLeftTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomRightCornerTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomRightTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.BottomTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.CentreTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.LeftEdgeTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.LeftTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.RightEdgeTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.RightTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.LeftEdgeTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopEdgeTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopLeftCornerTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopLeftTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopRightCornerTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopRightTextures)
                    {
                        u.Dispose();
                    }
                    foreach (Texture u in t.Textures.TopTextures)
                    {
                        u.Dispose();
                    }
                }
                t.Textures = null;
            }

            if (this.GameScreen != null)
            {
                this.GameScreen.DisposeMapTileMemory();
            }
        }


        public bool SaveScenarioMapToDatabase(string connectionString)  //地图编辑器用
        {
            OleDbConnection selectConnection = new OleDbConnection(connectionString);
            DataSet dataSet = new DataSet();
            DataRow row = null;
            OleDbDataAdapter adapter = new OleDbDataAdapter("Select * from Map", selectConnection);
            OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
            adapter.Fill(dataSet, "Map");
            dataSet.Tables["Map"].Rows[0].Delete();
            row = dataSet.Tables["Map"].NewRow();

            row.BeginEdit();
            row["TileWidth"] = this.ScenarioMap.TileWidth;
            row["DimensionX"] = this.ScenarioMap.MapDimensions.X;
            row["DimensionY"] = this.ScenarioMap.MapDimensions.Y;
            row["MapData"] = this.ScenarioMap.SaveToString();
            row["FileName"] = this.ScenarioMap.MapName;
            row["kuaishu"] = this.ScenarioMap.NumberOfTiles;
            row["meikuaidexiaokuaishu"] = this.ScenarioMap.NumberOfSquaresInEachTile;
            row["useSimpleArchImages"] = this.ScenarioMap.UseSimpleArchImages;
            row.EndEdit();



            dataSet.Tables["Map"].Rows.Add(row);
            adapter.Update(dataSet, "Map");
            dataSet.Clear();


            /*
            if (this.OnAfterSaveScenario != null)
            {
                this.OnAfterSaveScenario(this);
            }
            */
            return true;
        }

        public void SetMapTileArchitecture(Architecture architecture)
        {
            if (!architecture.AutoRefillFoodInLongViewArea)
            {
                architecture.AddBaseSupplyingArchitecture();
            }
            foreach (Point point in architecture.ViewArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.MapTileData[point.X, point.Y].AddHighViewingArchitecture(architecture);
                }
            }
            foreach (Point point in architecture.LongViewArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.MapTileData[point.X, point.Y].AddViewingArchitecture(architecture);
                }
            }
        }

        public void SetMapTileTroop(Troop troop)
        {
            if (this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TroopCount > 0)
            {
                TileData data1 = this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y];
                data1.TroopCount--;
            }
            if (this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TileTroop == troop)
            {
                this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TileTroop = null;
                /*foreach (Troop t in this.Troops)
                {
                    if (!t.Destroyed && t.Position == troop.PreviousPosition)
                    {
                        this.MapTileData[troop.PreviousPosition.X, troop.PreviousPosition.Y].TileTroop = t;
                        break;
                    }
                }*/
            }
            TileData data2 = this.MapTileData[troop.Position.X, troop.Position.Y];
            data2.TroopCount++;
            if (this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop == null)
            {
                this.MapTileData[troop.Position.X, troop.Position.Y].TileTroop = troop;
            }
        }

        public void SetPenalizedMapDataByArea(GameArea gameArea, int cost)
        {
            foreach (Point point in gameArea.Area)
            {
                if (!this.PositionOutOfRange(point))
                {
                    this.PenalizedMapData[point.X, point.Y] = cost;
                }
            }
            this.SetPenalizedMapDataByPosition(gameArea.Centre, 0xdac);
        }

        public void SetPenalizedMapDataByPosition(Point position, int cost)
        {
            this.PenalizedMapData[position.X, position.Y] = cost;
        }

        public void SetPlayerFactionList(GameObjectList factions)
        {
            this.PlayerFactions.Clear();
            foreach (Faction faction in factions)
            {
                this.PlayerFactions.Add(faction);
            }
        }

        public void SetPositionOnFire(Point position)
        {
            this.FireTable.AddPosition(position);
            this.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.火焰, position, true);
        }

        public void YearPassedEvent()
        {
            ExtensionInterface.call("YearEvent", new Object[] { this });
            foreach (Architecture architecture in this.Architectures.GetRandomList())
            {
                architecture.YearEvent();
            }

            foreach (Faction faction in this.Factions)
            {

               //faction.CreatePersonTimes = 0;
               faction.YearOfficialLimit = 0;
                 
                
            }
        }

        public void YearStartingEvent()
        {
        }

        public bool Animating
        {
            get
            {
                return this.Troops.HasAnimatingTroop;
            }
        }

        public Person NeutralPerson
        {
            get
            {
                if (this.neutralPerson == null)
                {
                    this.neutralPerson = this.Persons.GetGameObject(0x1b5f) as Person;
                }
                return this.neutralPerson;
            }
        }

        public bool NoCurrentPlayer
        {
            get
            {
                return (this.CurrentPlayer == null);
            }
        }

        public TroopAnimation TroopAnimations
        {
            get
            {
                return this.GameCommonData.TroopAnimations;
            }
        }

        public Architecture huangdisuozaijianzhu()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai) return a;
            }
            return null;
        }

        public bool youhuangdi()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai) return true;
            }
            return false;
        }

        public delegate void AfterLoadScenario(GameScenario scenario);

        public delegate void AfterSaveScenario(GameScenario scenario);

        public delegate void NewFactionAppear(Faction faction);



        internal void BecomeNoEmperor()
        {
            foreach (Architecture a in this.Architectures)
            {
                if (a.huangdisuozai)
                {
                    a.huangdisuozai = false;
                }
            }

            Person neutralPerson = this.NeutralPerson;
            if (neutralPerson == null)
            {
                if (this.CurrentPlayer != null)
                {
                    neutralPerson = this.CurrentPlayer.Leader;
                }
                else
                {
                    if (this.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (this.Factions[0] as Faction).Leader;
                }
            }

            this.GameScreen.xianshishijiantupian(neutralPerson, "汉朝", "FactionDestroy", "shilimiewang.jpg", "shilimiewang.wma", true);

        }

        public YearTable getFactionYearTable(Faction f)
        {
            YearTable result = new YearTable();
            foreach (YearTableEntry i in this.YearTable)
            {
                if (i.IsGloballyKnown || i.Factions.GameObjects.Contains(f) || GlobalVariables.SkyEye)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public YearTable getFactionYearTableRecentYears(Faction f, int y)
        {
            YearTable result = new YearTable();
            foreach (YearTableEntry i in this.YearTable)
            {
                if ((i.IsGloballyKnown || i.Factions.GameObjects.Contains(f) || GlobalVariables.SkyEye) &&
                    i.Date.Year > this.Date.Year - y)
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public YearTable getOnlyFactionYearTable(Faction f)
        {
            YearTable result = new YearTable();
            foreach (YearTableEntry i in this.YearTable)
            {
                if (i.Factions.GameObjects.Contains(f))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        public bool runScenarioStart(Architecture triggerArch)
        {
            bool ran = false;
            foreach (Event e in this.AllEvents)
            {
                if ((e.IsStart(this) && e.matchEventPersons(triggerArch)) || e.checkConditions(triggerArch))
                {
                    if (!this.EventsToApply.ContainsKey(e))
                    {
                        this.EventsToApply.Add(e, triggerArch);
                        e.ApplyEventDialogs(triggerArch);
                        ran = true;
                            
                    }

                }
            }
            return ran;
        }

        public bool runScenarioEnd(Architecture triggerArch)
        {
            bool ran = false;
            foreach (Event e in this.AllEvents)
            {
                if ((e.IsEnd(this) && e.matchEventPersons(triggerArch)) || e.checkConditions(triggerArch))
                {
                    if (!this.EventsToApply.ContainsKey(e))
                    {
                        this.EventsToApply.Add(e, triggerArch);
                        e.ApplyEventDialogs(triggerArch);
                        ran = true;

                    }

                }
            }
            return ran;
        }

        public PersonList Officers() //野武将列表
        {
            PersonList result = new PersonList();
            foreach (Person person in this.Persons)
            {
                if (person.Available && person.Alive)
                {
                    if (person.ID >= 25000)
                    {
                        result.Add(person);
                    }
                }
  
            }
         
            return result;
        }


        public int OfficerCount //野武将总数
        {
            get
            {
                return (this.Officers().Count);
            }
        }

       public int OfficerLimit
       {
           get 
           {

               if (this.Factions.Count <= 50)  //剧本野武将上限为800
               {
                   return (this.Factions.Count * 10 + 500);
               }
               else if (this.Factions.Count > 50 && this.Factions .Count <= 100)
               {
                   return ( this.Factions.Count * 5 + 500);
               }
               else 
               {
                   return (this.Factions.Count * 3 + 100 );
               }
               
           }
       }


        public int GetAITroopCount()
        {
            int cnt = 0;
            foreach (Troop t in this.Troops)
            {
                if (!this.IsPlayer(t.BelongedFaction))
                {
                    cnt++;
                }
            }
            return cnt;
        }
    }
}

