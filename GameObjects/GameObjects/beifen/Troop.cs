namespace GameObjects
{
    using GameGlobal;
    using GameObjects.Animations;
    using GameObjects.Influences;
    using GameObjects.MapDetail;
    using GameObjects.PersonDetail;
    using GameObjects.TroopDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Threading;

    public class Troop : GameObject
    {
        private TroopAction action;
        public bool AllowCure;
        private int antiCriticalStrikeChance;
        private int antiStratagemChanceIncrement;
        private List<ArchitectureDamage> ArchitectureDamageList = new List<ArchitectureDamage>();
        public int AreaAttackRadius;
        public int AreaStratagemRadius;
        public TroopList AreaStratagemTroops = new TroopList();
        private Military army;
        public int AroundAttackRadius;
        public bool AttackAllOffenceArea;
        public int AttackDecrementOfCombativity;
        private TroopAttackDefaultKind attackDefaultKind;
        private GameObjectList AttackedTroopList = new GameObjectList();
        public bool AttackEveryAround;
        public bool AttackStarted;
        private TroopAttackTargetKind attackTargetKind;
        private bool auto;
        private int avoidSurroundedChance;
        public Person BackupArmyLeader;
        public int BackupArmyLeaderExperience;
        public int BackupArmyLeaderID;
        public int BaseAreaAttackRadius;
        public int BaseAroundAttackRadius;
        public bool BaseAttackAllOffenceArea;
        public bool BaseAttackEveryAround;
        public int BaseChanceOfOnFire;
        public int BaseDefenceConsidered = 0;
        public bool BaseNoAccidentalInjury;
        public bool BaseNoCounterAttack;
        public bool BasePierceAttack;
        public float BaseRateOfQibingDamage = 1f;
        private GameArea baseViewArea = null;
        public Faction BelongedFaction = null;
        public Legion BelongedLegion;
        public bool CanAttackAfterRout;
        public CaptiveList Captives = new CaptiveList();
        private TroopCastDefaultKind castDefaultKind;
        private TroopCastTargetKind castTargetKind;
        public int ChanceDecrementOfCriticalStrike;
        public int ChanceDecrementOfCriticalStrikeByViewArea;
        public int ChanceDecrementOfCriticalStrikeInViewArea;
        public int ChanceDecrementOfStratagem;
        public int ChanceDecrementOfStratagemByViewArea;
        public int ChanceDecrementOfStratagemInViewArea;
        public int ChanceIncrementOfChaosAfterCriticalStrike;
        public int ChanceIncrementOfChaosAfterStratagem;
        public int ChanceIncrementOfCriticalStrike;
        public int ChanceIncrementOfCriticalStrikeByViewArea;
        public int ChanceIncrementOfCriticalStrikeInViewArea;
        public int ChanceIncrementOfStratagem;
        public int ChanceIncrementOfStratagemByViewArea;
        public int ChanceIncrementOfStratagemInViewArea;
        public int ChanceOfBlockArrowAttack;
        public int ChanceOfBlockAttack;
        public int ChanceOfChaosAttack;
        public int ChanceOfDoubleDamage;
        public int ChanceOfFixDefenceAttack;
        public int ChanceOfHalfDamage;
        public int ChanceOfMustCriticalStrike;
        public int ChanceOfOnFire;
        public int ChanceOfTrippleDamage;
        private int chaosAfterCriticalStrikeChance;
        private int chaosAfterStratagemSuccessChance;
        private int chaosAfterSurroundAttackChance;
        private int chaosDayLeft;
        public bool ChaosLastOneDay;
        public int CombativityDecrementOnPower;
        public int CombativityDecrementPerDayByViewArea;
        public int CombativityDecrementPerDayInViewArea;
        public int CombativityIncrementPerDayByViewArea;
        public int CombativityIncrementPerDayInViewArea;
        public bool CombativityNoChanceAfterAttacked;
        public bool CombatMethodApplied;
        public CombatMethodTable CombatMethods = new CombatMethodTable();
        private GameArea contactArea = null;
        public int ContactFriendlyTroopCount;
        public int ContactHostileTroopCount;
        public bool ContactingWillArchitecture;
        private bool controllable = true;
        public int CounterAttackDecrementOfCombativity;
        public int CriticalChanceIncrementOfCliff;
        public int CriticalChanceIncrementOfDesert;
        public int CriticalChanceIncrementOfForrest;
        public int CriticalChanceIncrementOfGrassland;
        public int CriticalChanceIncrementOfMarsh;
        public int CriticalChanceIncrementOfMountain;
        public int CriticalChanceIncrementOfPlain;
        public int CriticalChanceIncrementOfRidge;
        private int CriticalChanceIncrementOfTerrain = 0;
        public int CriticalChanceIncrementOfWasteland;
        public int CriticalChanceIncrementOfWater;
        private int criticalStrikeChance;
        private CombatMethod currentCombatMethod;
        private int currentCombatMethodID = -1;
        private Person CurrentDestinationChallengePerson;
        private Person CurrentDestinationControversyPerson;
        public OutburstKind CurrentOutburstKind;
        private List<Point> CurrentPath;
        private Person CurrentSourceChallengePerson;
        private Person CurrentSourceControversyPerson;
        private Stratagem currentStratagem;
        private int currentStratagemID = -1;
        public Stunt CurrentStunt;
        private int currentTileAnimationIndex;
        public TileAnimationKind CurrentTileAnimationKind = TileAnimationKind.无;
        private int currentTileStayIndex;
        private int currentTroopAnimationIndex;
        private int currentTroopStayIndex;
        private int cutRoutewayDays;
        public bool DayLocationLoyaltyNoChange;
        public CombatNumberItemList DecrementNumberList = new CombatNumberItemList(CombatNumberDirection.下);
        public int DecrementOfCliffAdaptability;
        public int DecrementOfCombatMethodCombativityConsuming;
        public int DecrementOfDesertAdaptability;
        public int DecrementOfForrestAdaptability;
        public int DecrementOfGrasslandAdaptability;
        public int DecrementOfMarshAdaptability;
        public int DecrementOfMountainAdaptability;
        public int DecrementOfPlainAdaptability;
        public int DecrementOfRidgeAdaptability;
        public int DecrementOfStratagemCombativityConsuming;
        public int DecrementOfWastelandAdaptability;
        public int DecrementOfWaterAdaptability;
        public int DecrementPerDayOfCombativity;
        private int defence;
        public int DefenceConsidered = 0;
        public bool DefenceNoChangeOnChaos;
        public float DefenceRateDecrementByViewArea;
        public float DefenceRateDecrementInViewArea;
        public float DefenceRateIncrementByViewArea;
        public float DefenceRateIncrementInViewArea;
        public float DefenceRateOnSubdueBubing = 1f;
        public float DefenceRateOnSubdueNubing = 1f;
        public float DefenceRateOnSubdueQibing = 1f;
        public float DefenceRateOnSubdueQixie = 1f;
        public float DefenceRateOnSubdueShuijun = 1f;
        private Point destination;
        public bool Destroyed;
        private TroopDirection direction = TroopDirection.正东;
        private double DistanceToWillArchitecture;
        public int DominationDecrementOfCriticalStrike;
        private bool drawAnimation = true;
        public TroopEffect Effect;
        private int effectTileAnimationIndex;
        private int effectTileStayIndex;
        public bool EnableOneAdaptablility;
        public ArchitectureList EnterList = new ArchitectureList();
        public InfluenceList EventInfluences = new InfluenceList();
        public List<Point> FirstTierPath;
        private int firstTierPathIndex = 0;
        private int food;
        public FriendlyActionKind FriendlyAction = FriendlyActionKind.NotCare;
        private int fund;
        public bool HasPath = false;
        private bool HasSupply;
        internal bool HasToDoCombatAction;
        public bool HighLevelInformationOnInvestigate;
        public bool HighLevelInformationOnScout;
        public HostileActionKind HostileAction = HostileActionKind.EvadeEffect;
        public bool ImmunityOfCaptive;
        public int IncrementDefencePerReputationUnit;
        public CombatNumberItemList IncrementNumberList = new CombatNumberItemList(CombatNumberDirection.上);
        public int IncrementOfAvoidSurroundedChance;
        public int IncrementOfChaosAfterSurroundAttackChance;
        public int IncrementOfChaosDay;
        public int IncrementOffencePerReputationUnit;
        public int IncrementOfInjuryRate;
        public int IncrementOfInvestigateRadius;
        public int IncrementOfMovability;
        public int IncrementOfRationDays;
        public int IncrementOfStratagemRadius;
        public int IncrementPerDayOfCombativity;
        public bool InevitableChaosOnWaylay;
        public bool InevitableGongxinOnLowerIntelligence;
        public bool InevitableHuogongOnLowerIntelligence;
        public bool InevitableRaoluanOnLowerIntelligence;
        public bool InevitableStratagemOnLowerIntelligence;
        public float InjuryRecoveryPerDayRate;
        public bool InvincibleGongxin;
        public bool InvincibleHuogong;
        public bool InvincibleRaoluan;
        public bool InvincibleStratagemFromLowerIntelligence;
        public Person Leader = null;
        public bool LowerLevelInformationWhileInvestigated;
        private int militaryID = -1;
        public float MoraleChangeRateOnOutOfFood = 1f;
        public int MoraleDecrementOfCriticalStrike;
        public int MoraleDecrementOnPrestige;
        public int MoraleDownOfAttack;
        public bool MoraleNoChanceAfterAttacked;
        public int MovabilityLeft;
        public List<Point> MoveAnimationFrames = new List<Point>();
        private bool moved;
        private int moveFrameIndex = 0;
        private int moveStayCount = 0;
        public int MultipleOfArmyExperience = 1;
        public int MultipleOfCombatTechniquePoint = 1;
        public int MultipleOfDefenceOnArchitecture = 1;
        public int MultipleOfLeaderExperience = 1;
        public int MultipleOfStratagemTechniquePoint = 1;
        public bool NeverBeIntoChaos;
        public bool NeverBeIntoChaosWhileWaylay;
        public bool NoAccidentalInjury;
        public bool NoCounterAttack;
        public bool NotAfraidOfFire;
        private int offence;
        private GameArea offenceArea = null;
        private bool OffenceOnlyBeforeMoveFlag;
        public float OffenceRateDecrementByViewArea;
        public float OffenceRateDecrementInViewArea;
        public float OffenceRateIncrementByViewArea;
        public float OffenceRateIncrementInViewArea;
        public float OffenceRateOnSubdueBubing = 1f;
        public float OffenceRateOnSubdueNubing = 1f;
        public float OffenceRateOnSubdueQibing = 1f;
        public float OffenceRateOnSubdueQixie = 1f;
        public float OffenceRateOnSubdueShuijun = 1f;
        public bool OffencingWillArchitecture;
        public bool OnlyBeDetectedByHighLevelInformation;
        private bool operated;
        private bool operationDone;
        public Architecture OrientationArchitecture;
        public Point OrientationPosition;
        public Troop OrientationTroop;
        public int OutburstDefenceMultiple = 1;
        public bool OutburstNeverBeIntoChaos = false;
        public int OutburstOffenceMultiple = 1;
        public bool OutburstPreventCriticalStrike = false;
        private TroopPathFinder pathFinder;
        public PersonList Persons = new PersonList();
        public bool PierceAttack;
        private Point position;
        private TroopPreAction preAction;
        public Point PreviousPosition;
        public bool ProhibitAllAction;
        public bool ProhibitCombatMethod;
        public bool ProhibitStratagem;
        public bool QueueEnded;
        public float RateIncrementOfRateOnWater = 0f;
        public float RateIncrementOfTerrainRateOnCliff = 0f;
        public float RateIncrementOfTerrainRateOnDesert = 0f;
        public float RateIncrementOfTerrainRateOnForrest = 0f;
        public float RateIncrementOfTerrainRateOnGrassland = 0f;
        public float RateIncrementOfTerrainRateOnMarsh = 0f;
        public float RateIncrementOfTerrainRateOnMountain = 0f;
        public float RateIncrementOfTerrainRateOnPlain = 0f;
        public float RateIncrementOfTerrainRateOnRidge = 0f;
        public float RateIncrementOfTerrainRateOnWasteland = 0f;
        public float RateIncrementOfTerrainRateOnWater = 0f;
        public float RateOfBoost = 1f;
        public float RateOfCriticalArchitectureDamage = 1f;
        public float RateOfCriticalDamageReceived = 1f;
        public float RateOfDefence = 1f;
        public float RateOfFireDamage = 1f;
        public float RateOfFireProtection;
        public float RateOfGongxin = 1f;
        public float RateOfInjuryOnCriticalStrike = 1f;
        public float RateOfMovability = 1f;
        public float RateOfOffence = 1f;
        public float RateOfQibingDamage = 1f;
        private Point realDestination;
        public int RecentlyFighting;
        public int RoutIncrementOfCombativity;
        public bool ScatteredShootingOblique;
        public List<Point> SecondTierPath;
        private int secondTierPathDestinationIndex = 0;
        private Point selfCastPosition;
        private bool showNumber;
        public bool ShowPath = false;
        private TierPathFinder simplepathFinder = new TierPathFinder();
        private bool Simulating;
        public CombatMethod SimulatingCombatMethod;
        private string SoundFileLocation;
        public Architecture StartingArchitecture;
        private TroopStatus status;
        private int statusTileAnimationIndex;
        private int statusTileStayIndex;
        private bool stepFinished = true;
        private int stoppedTroopAnimationIndex;
        private int stoppedTroopStayIndex;
        private bool StratagemApplyed;
        private GameArea stratagemArea = null;
        private int stratagemChanceIncrement;
        public float StuntArchitectureDamageRate = 1f;
        public int StuntAttackRadius;
        public bool StuntAvoidSurround;
        public bool StuntCanAttackAfterRout;
        public int StuntDayDecrementOfAttack;
        private int stuntDayLeft;
        public bool StuntMustSurround;
        public bool StuntRecoverFromChaos;
        public StuntTable Stunts = new StuntTable();
        private int stuntTileAnimationIndex;
        private int stuntTileStayIndex;
        public bool Surrounding;
        private Architecture targetArchitecture;
        private int targetArchitectureID = -1;
        private Troop targetTroop;
        private int targetTroopID = -1;
        private int technologyIncrement;
        private Point? TempDestination;
        public float TempRateOfDefence = 1f;
        public float TempRateOfOffence = 1f;
        private float terrainRate = 1f;
        public List<Point> ThirdTierPath;
        private int thirdTierPathDestinationIndex = 0;
        private int troopCommand;
        private List<TroopDamage> TroopDamageList = new List<TroopDamage>();
        private int troopIntelligence;
        private int troopStrength;
        private GameArea viewArea = null;
        public int ViewingCliffFriendlyTroopCount;
        public int ViewingCliffHostileTroopCount;
        public int ViewingDesertFriendlyTroopCount;
        public int ViewingDesertHostileTroopCount;
        public int ViewingForestFriendlyTroopCount;
        public int ViewingForestHostileTroopCount;
        public int ViewingFriendlyTroopCount;
        public int ViewingGrasslandFriendlyTroopCount;
        public int ViewingGrasslandHostileTroopCount;
        public int ViewingHostileTroopCount;
        public int ViewingMarshFriendlyTroopCount;
        public int ViewingMarshHostileTroopCount;
        public int ViewingMountainFriendlyTroopCount;
        public int ViewingMountainHostileTroopCount;
        public int ViewingPlainFriendlyTroopCount;
        public int ViewingPlainHostileTroopCount;
        public int ViewingRidgeFriendlyTroopCount;
        public int ViewingRidgeHostileTroopCount;
        public int ViewingWastelandFriendlyTroopCount;
        public int ViewingWastelandHostileTroopCount;
        public int ViewingWaterFriendlyTroopCount;
        public int ViewingWaterHostileTroopCount;
        public bool ViewingWillArchitecture;
        public bool WaitForDeepChaos;
        private int waitForDeepChaosFrameCount;
        public bool WaitOnce = false;
        private TroopWill will = TroopWill.行军;
        private Architecture willArchitecture;
        private int willArchitectureID = -1;
        private Troop willTroop;
        private int willTroopID = -1;
        public bool YesOrNoOfObliqueOffence;
        public bool YesOrNoOfObliqueStratagem;
        public bool YesOrNoOfObliqueView;

        public event Ambush OnAmbush;

        public event AntiArrowAttack OnAntiArrowAttack;

        public event AntiAttack OnAntiAttack;

        public event ApplyStunt OnApplyStunt;

        public event BreakWall OnBreakWall;

        public event CastDeepChaos OnCastDeepChaos;

        public event CastStratagem OnCastStratagem;

        public event Chaos OnChaos;

        public event CombatMethodAttack OnCombatMethodAttack;

        public event CriticalStrike OnCriticalStrike;

        public event DiscoverAmbush OnDiscoverAmbush;

        public event EndCutRouteway OnEndCutRouteway;

        public event EndPath OnEndPath;

        public event EnterFactionArea OnEnterFactionArea;

        public event GetNewCaptive OnGetNewCaptive;

        public event GetSpreadBurnt OnGetSpreadBurnt;

        public event LeaveFactionArea OnLeaveFactionArea;

        public event LevyFieldFood OnLevyFieldFood;

        public event NormalAttack OnNormalAttack;

        public event OccupyArchitecture OnOccupyArchitecture;

        public event Outburst OnOutburst;

        public event PathNotFound OnPathNotFound;

        public event PersonChallenge OnPersonChallenge;

        public event PersonControversy OnPersonControversy;

        public event ReceiveCriticalStrike OnReceiveCriticalStrike;

        public event ReceiveWaylay OnReceiveWaylay;

        public event RecoverFromChaos OnRecoverFromChaos;

        public event ReleaseCaptive OnReleaseCaptive;

        public event ResistStratagem OnResistStratagem;

        public event Rout OnRout;

        public event Routed OnRouted;

        public event SetCombatMethod OnSetCombatMethod;

        public event SetStratagem OnSetStratagem;

        public event StartCutRouteway OnStartCutRouteway;

        public event StartPath OnStartPath;

        public event StopAmbush OnStopAmbush;

        public event StratagemSuccess OnStratagemSuccess;

        public event Surround OnSurround;

        public event TroopCreate OnTroopCreate;

        public event TroopFound OnTroopFound;

        public event TroopLost OnTroopLost;

        public event Waylay OnWaylay;

        public Troop()
        {
            this.pathFinder = new TroopPathFinder(this);
            this.simplepathFinder.OnGetCost += new TierPathFinder.GetCost(this.simplepathFinder_OnGetCost);
        }

        private void AddAreaInfluences(Point p)
        {
            if (this.OffenceRateIncrementInViewArea > 0f)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军攻击力增加, 0, this.OffenceRateIncrementInViewArea);
            }
            if (this.OffenceRateDecrementInViewArea > 0f)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.敌军攻击力减少, 0, this.OffenceRateDecrementInViewArea);
            }
            if (this.DefenceRateIncrementInViewArea > 0f)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军防御力增加, 0, this.DefenceRateIncrementInViewArea);
            }
            if (this.DefenceRateDecrementInViewArea > 0f)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.敌军防御力减少, 0, this.DefenceRateDecrementInViewArea);
            }
            if (this.ChanceIncrementOfCriticalStrikeInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军暴击几率增加, this.ChanceIncrementOfCriticalStrikeInViewArea, 0f);
            }
            if (this.ChanceDecrementOfCriticalStrikeInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军暴击抵抗几率增加, this.ChanceDecrementOfCriticalStrikeInViewArea, 0f);
            }
            if (this.ChanceIncrementOfStratagemInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军计略成功几率增加, this.ChanceIncrementOfStratagemInViewArea, 0f);
            }
            if (this.ChanceDecrementOfStratagemInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军计略抵抗几率增加, this.ChanceDecrementOfStratagemInViewArea, 0f);
            }
            if (this.CombativityIncrementPerDayInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.友军战意每天增加, this.CombativityIncrementPerDayInViewArea, 0f);
            }
            if (this.CombativityDecrementPerDayInViewArea > 0)
            {
                base.Scenario.AddPositionAreaInfluence(this, p, AreaInfluenceKind.敌军战意每天减少, this.CombativityDecrementPerDayInViewArea, 0f);
            }
            Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(p);
            if (troopByPositionNoCheck != null)
            {
                troopByPositionNoCheck.RefreshDataOfAreaInfluence();
            }
        }

        public void AddCaptive(Captive captive)
        {
            this.Captives.Add(captive);
            captive.LocationTroop = this;
            captive.CaptivePerson.LocationTroop = this;
            foreach (Treasure treasure in captive.CaptivePerson.Treasures.GetList())
            {
                captive.CaptivePerson.LoseTreasure(treasure);
                this.Leader.ReceiveTreasure(treasure);
            }
        }

        private void AddCastAnimation(Troop troop, bool sound)
        {
            if (this.CurrentStratagem.AnimationKind != TileAnimationKind.无)
            {
                GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(this.CurrentStratagem.AnimationKind, troop.Position, false);
                if ((animation != null) && sound)
                {
                    this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
                }
            }
        }

        private void AddzhanfaAnimation(Troop troop, bool sound)
        {
            if (this.CurrentCombatMethod.AnimationKind != TileAnimationKind.无)
            {
                GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(this.CurrentCombatMethod.AnimationKind, troop.Position, false);
                if ((animation != null) && sound && this.PreAction != TroopPreAction.暴击)
                {
                    this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
                }
            }
        }

        private void AddSelfzhanfaAnimation()
        {
            if (this.CurrentCombatMethod.AnimationKind != TileAnimationKind.无)
            {
                GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(this.CurrentCombatMethod.AnimationKind, this.Position, false);
                if (animation != null && this.PreAction != TroopPreAction.暴击)
                {
                    this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
                }
            }
        }




        public void AddMoveAnimationIndex(int steps)
        {
            if (this.Action == TroopAction.Move)
            {
                this.moveFrameIndex += steps;
                if (this.moveFrameIndex >= GlobalVariables.TroopMoveFrameCount)
                {
                    this.moveFrameIndex = 0;
                    this.Action = TroopAction.Stop;
                }
            }
        }

        public void AddPerson(Person person)
        {
            this.Persons.Add(person);
            person.LocationTroop = this;
        }

        public void AddRoutCount()
        {
            foreach (Person person in this.Persons)
            {
                if (person == this.Leader)
                {
                    person.RoutCount++;
                }
                else if (GameObject.Random(2) > 0)
                {
                    person.RoutCount++;
                }
            }
        }

        public void AddRoutedCount()
        {
            foreach (Person person in this.Persons)
            {
                person.RoutedCount++;
            }
        }

        private void AddSelfCastAnimation()
        {
            if (this.CurrentStratagem.AnimationKind != TileAnimationKind.无)
            {
                GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(this.CurrentStratagem.AnimationKind, this.SelfCastPosition, false);
                if (animation != null)
                {
                    this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
                }
            }
        }





        public void AI()
        {
            if (this.ControlAvail() && !this.Destroyed)
            {
                if (!this.IsRobber)
                {
                    this.PrepareAI();
                    this.PreActionAI();
                }
                this.WillAI();
                if (!this.IsRobber)
                {
                    this.PostActionAI();
                }
            }
        }

        private bool AIResetDestination()
        {
            CreditPack moveCreditByPosition;
            double num4;
            double distance;
            if (!this.IsRobber)
            {
                if (GameObject.Chance(80 + (this.Leader.Calmness * 2)) && ((this.InjuryQuantity > this.Quantity) || (this.Morale < 0x2d)))
                {
                    this.GoBack();
                    if (GameObject.Chance(50))
                    {
                        this.AttackTargetKind = TroopAttackTargetKind.无反;
                    }
                    else
                    {
                        this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                    }
                    this.WillTroop = null;
                    this.TargetTroop = null;
                    this.TargetArchitecture = null;
                    return false;
                }
                if ((((this.WillArchitecture.Endurance >= 30) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction)) && (this.Morale <= 0x4b)) && (((this.BelongedLegion.PreferredRouteway != null) && (this.BelongedLegion.PreferredRouteway.LastActivePointIndex < 0)) || (((this.BelongedLegion.PreferredRouteway != null) && (this.BelongedLegion.PreferredRouteway.LastActivePoint != null)) && !this.BelongedLegion.PreferredRouteway.IsEnough(this.BelongedLegion.PreferredRouteway.LastActivePoint.ConsumptionRate, this.FoodCostPerDay))))
                {
                    this.GoBack();
                    if (GameObject.Chance(50))
                    {
                        this.AttackTargetKind = TroopAttackTargetKind.无反;
                    }
                    else
                    {
                        this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                    }
                    this.WillTroop = null;
                    this.TargetTroop = null;
                    this.TargetArchitecture = null;
                    return false;
                }
                if (!(this.IsFriendly(this.WillArchitecture.BelongedFaction) || (this.BelongedLegion.Kind != LegionKind.Defensive)))
                {
                    this.GoBack();
                    this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                    this.WillTroop = null;
                    this.TargetTroop = null;
                    this.TargetArchitecture = null;
                    return false;
                }
                if (!(((!GameObject.Chance(10 + this.Leader.Calmness) || !this.HasHostileTroopInView()) || (this.WillArchitecture.BelongedFaction == this.BelongedFaction)) || this.WillArchitecture.ViewTroop(this)))
                {
                    this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                    this.WillTroop = null;
                    this.TargetTroop = null;
                    this.TargetArchitecture = null;
                    return false;
                }
                if (!(((this.WillArchitecture.BelongedFaction == this.BelongedFaction) || !this.IsFriendly(this.WillArchitecture.BelongedFaction)) || this.WillArchitecture.HasHostileTroopsInView()))
                {
                    this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                    this.WillTroop = null;
                    this.TargetTroop = null;
                    this.TargetArchitecture = null;
                    this.GoBack();
                    return false;
                }
                this.CallTacticsHelp();
                this.CallRoutewayHelp();
            }
            List<CreditPack> list = new List<CreditPack>();
            int credit = 0;
            bool flag = false;
            bool flag2 = false;
            bool hasUnAttackableTroop = false;
            CreditPack pack = null;
            GameArea dayArea = this.GetDayArea(1);
            if (dayArea.Count <= 10)
            {
                if (this.ViewArea.Count > 10)
                {
                    dayArea = this.ViewArea;
                }
                else
                {
                    dayArea = this.GetDayArea(2);
                    dayArea.AddPoint(this.Position);
                }
            }
            else
            {
                dayArea.AddPoint(this.Position);
            }
            if ((((((!this.IsRobber && !this.ViewingWillArchitecture) && ((this.Army.Kind.Type != MilitaryType.水军) || GameObject.Chance(20))) && (((this.Morale > 0x4b) && (this.BelongedLegion.Kind == LegionKind.Offensive)) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction))) && !this.HasHostileTroopInView()) && !this.BelongedLegion.HasTroopViewingWillArchitecture) && (this.WillArchitecture.BelongedFaction != null))
            {
                foreach (Point point in dayArea.Area)
                {
                    moveCreditByPosition = this.GetMoveCreditByPosition(point);
                    if (moveCreditByPosition != null)
                    {
                        list.Add(moveCreditByPosition);
                        if (moveCreditByPosition.Credit > credit)
                        {
                            credit = moveCreditByPosition.Credit;
                            pack = moveCreditByPosition;
                        }
                    }
                }
            }
            this.OffenceOnlyBeforeMoveFlag = false;
            foreach (Point point in dayArea.Area)
            {
                if ((this.BelongedLegion == null) || (this.BelongedLegion.TakenPositions.IndexOf(point) < 0))
                {
                    moveCreditByPosition = this.GetCreditByPosition(point);
                    list.Add(moveCreditByPosition);
                    if (!flag2)
                    {
                        flag2 = moveCreditByPosition.TargetTroop != null;
                    }
                    if (!hasUnAttackableTroop)
                    {
                        hasUnAttackableTroop = moveCreditByPosition.HasUnAttackableTroop;
                    }
                    if (moveCreditByPosition.Credit > credit)
                    {
                        credit = moveCreditByPosition.Credit;
                        pack = moveCreditByPosition;
                    }
                }
            }
            Point? nullable = null;
            Point? nullable2 = null;
            base.Scenario.GetClosestPointsBetweenTwoAreas(dayArea, this.WillArchitecture.ArchitectureArea, out nullable, out nullable2);
            if ((this.CurrentStunt != null) || (GameObject.Random(this.Stunts.Count + 3) < 3))
            {
                if (flag2 && ((credit < 500) || (GameObject.Chance(this.Combativity) && GameObject.Chance(80))))
                {
                //Label_0712:
                    foreach (CombatMethod method in this.CombatMethods.CombatMethods.Values)
                    {
                        if (!this.HasCombatMethod(method.ID))
                        {
                            continue;
                        }
                        if (method.SimulateApply(this))
                        {
                            this.SimulatingCombatMethod = method;
                            this.RefreshAllData();
                            foreach (Point point in dayArea.Area)
                            {
                                if (((!nullable.HasValue || flag2) || (nullable.Value == point)) && ((this.BelongedLegion == null) || (this.BelongedLegion.TakenPositions.IndexOf(point) < 0)))
                                {
                                    moveCreditByPosition = this.GetCreditByPosition(point);
                                    moveCreditByPosition.CurrentCombatMethod = method;
                                    moveCreditByPosition.Credit -= method.Combativity;
                                    list.Add(moveCreditByPosition);
                                    if (moveCreditByPosition.Credit > credit)
                                    {
                                        credit = moveCreditByPosition.Credit;
                                        pack = moveCreditByPosition;
                                    }
                                }
                            }
                            method.SimulatePurify(this);
                            this.RefreshAllData();
                        }
                    }
                }
                if ((((this.Morale <= 90) || flag2) || ((hasUnAttackableTroop || GameObject.Chance(10)) || this.HasHostileArchitectureInView())) && ((credit < 500) || (GameObject.Chance(this.Combativity) && GameObject.Chance(30))))
                {
                    foreach (Stratagem stratagem in this.Stratagems.Stratagems.Values)
                    {
                        if (this.HasStratagem(stratagem.ID))
                        {
                            if (stratagem.Self)
                            {
                                moveCreditByPosition = this.GetSelfStratagemCredit(stratagem);
                                moveCreditByPosition.Credit -= stratagem.Combativity;
                                list.Add(moveCreditByPosition);
                                if (moveCreditByPosition.Credit > credit)
                                {
                                    credit = moveCreditByPosition.Credit;
                                    pack = moveCreditByPosition;
                                    flag = true;
                                }
                            }
                            else
                            {
                                this.SetCurrentStratagem(stratagem);
                                foreach (Point point in dayArea.Area)
                                {
                                    if (((!nullable.HasValue || flag2) || (nullable.Value == point)) && (((this.BelongedLegion == null) || (this.BelongedLegion.TakenPositions.IndexOf(point) < 0)) && (!this.OffenceOnlyBeforeMove || !(point != this.Position))))
                                    {
                                        moveCreditByPosition = this.GetStratagemCreditByPosition(stratagem, point);
                                        moveCreditByPosition.Credit -= stratagem.Combativity;
                                        list.Add(moveCreditByPosition);
                                        if (moveCreditByPosition.Credit > credit)
                                        {
                                            credit = moveCreditByPosition.Credit;
                                            pack = moveCreditByPosition;
                                            flag = true;
                                        }
                                    }
                                }
                                this.SetCurrentStratagem(null);
                            }
                        }
                    }
                }
            }
            if (this.OffenceOnlyBeforeMove && ((credit <= 0) || ((credit < 100) && GameObject.Chance(100 - credit))))
            {
                this.OffenceOnlyBeforeMoveFlag = true;
                foreach (Point point in dayArea.Area)
                {
                    if ((this.BelongedLegion == null) || (this.BelongedLegion.TakenPositions.IndexOf(point) < 0))
                    {
                        moveCreditByPosition = this.GetCreditByPosition(point);
                        list.Add(moveCreditByPosition);
                        flag2 = moveCreditByPosition.TargetTroop != null;
                        hasUnAttackableTroop = moveCreditByPosition.HasUnAttackableTroop;
                        if (moveCreditByPosition.Credit > credit)
                        {
                            credit = moveCreditByPosition.Credit;
                            pack = moveCreditByPosition;
                        }
                    }
                }
            }
            if (credit <= 0)
            {
                this.AttackTargetKind = TroopAttackTargetKind.攻防皆弱默认;
                this.TargetTroop = null;
                this.TargetArchitecture = null;
                return false;
            }
            List<CreditPack> list2 = new List<CreditPack>();
            bool flag4 = false;
            foreach (CreditPack pack2 in list)
            {
                if (pack2.Credit == credit)
                {
                    list2.Add(pack2);
                }
                if ((!flag4 && (pack2.TargetTroop != null)) && pack2.TargetTroop.AirOffence)
                {
                    flag4 = true;
                }
            }
            CreditPack pack3 = null;
            List<CreditPack> list3 = new List<CreditPack>();
            if (this.Army.Kind.AirOffence || flag)
            {
                double minValue = double.MinValue;
                foreach (CreditPack pack2 in list2)
                {
                    if (pack2.Distance > minValue)
                    {
                        minValue = pack2.Distance;
                        list3.Clear();
                        list3.Add(pack2);
                    }
                    else if (pack2.Distance == minValue)
                    {
                        list3.Add(pack2);
                    }
                }
            }
            else
            {
                double maxValue = double.MaxValue;
                foreach (CreditPack pack2 in list2)
                {
                    if (pack2.Distance < maxValue)
                    {
                        maxValue = pack2.Distance;
                        list3.Clear();
                        list3.Add(pack2);
                    }
                    else if (pack2.Distance == maxValue)
                    {
                        list3.Add(pack2);
                    }
                }
            }
            if (flag4 || GameObject.Chance(20))
            {
                num4 = double.MinValue;
                foreach (CreditPack pack2 in list3)
                {
                    distance = base.Scenario.GetDistance(this.Position, pack2.Position);
                    if ((distance > num4) || (GameObject.Random(list3.Count) == 0))
                    {
                        num4 = distance;
                        pack3 = pack2;
                    }
                }
            }
            else
            {
                num4 = double.MaxValue;
                foreach (CreditPack pack2 in list3)
                {
                    distance = base.Scenario.GetDistance(this.Position, pack2.Position);
                    if ((distance < num4) || (GameObject.Random(list3.Count) == 0))
                    {
                        num4 = distance;
                        pack3 = pack2;
                    }
                }
            }
            this.RealDestination = pack3.Position;
            if (this.BelongedLegion != null)
            {
                this.BelongedLegion.TakenPositions.Add(pack3.Position);
            }
            if (pack3.CurrentCombatMethod != null)
            {
                this.SetCurrentCombatMethod(pack3.CurrentCombatMethod);
            }
            else if (pack3.CurrentStratagem != null)
            {
                this.SetCurrentStratagem(pack3.CurrentStratagem);
                if (pack3.CurrentStratagem.Self)
                {
                    this.SelfCastPosition = pack3.SelfCastPosition;
                }
            }
            if (pack3.TargetTroop != null)
            {
                if (this.CurrentCombatMethod == null)
                {
                    this.AttackDefaultKind = TroopAttackDefaultKind.防最弱;
                    this.AttackTargetKind = TroopAttackTargetKind.目标默认;
                }
                if (this.CurrentStratagem == null)
                {
                    this.CastTargetKind = TroopCastTargetKind.特定默认;
                }
                this.TargetTroop = pack3.TargetTroop;
                this.TargetArchitecture = null;
            }
            else if (pack3.TargetArchitecture != null)
            {
                this.AttackDefaultKind = TroopAttackDefaultKind.耐最低;
                this.AttackTargetKind = TroopAttackTargetKind.目标默认;
                this.CastTargetKind = TroopCastTargetKind.智低默认;
                this.TargetTroop = null;
                this.TargetArchitecture = pack3.TargetArchitecture;
            }
            else
            {
                this.AttackDefaultKind = TroopAttackDefaultKind.防最弱;
                this.AttackTargetKind = TroopAttackTargetKind.无反默认;
                this.CastTargetKind = TroopCastTargetKind.智低默认;
                this.TargetTroop = null;
                this.TargetArchitecture = null;
            }
            return true;
        }

        public bool AmbushAvail(int id)
        {
            if (this.Status != TroopStatus.埋伏)
            {
                if (this.ProhibitAllAction || this.ProhibitStratagem)
                {
                    return false;
                }
                Stratagem stratagem = this.Stratagems.GetStratagem(id);
                if (stratagem != null)
                {
                    if (stratagem.Combativity <= (this.Combativity + this.DecrementOfStratagemCombativityConsuming))
                    {
                        switch (base.Scenario.GetTerrainKindByPosition(this.Position))
                        {
                            case TerrainKind.森林:
                            case TerrainKind.山地:
                            {
                                GameArea area = GameArea.GetViewArea(this.Position, (3 > this.ViewRadius) ? this.ViewRadius : 3, false, base.Scenario, null);
                                foreach (Point point in area.Area)
                                {
                                    if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(point)) || ((this.BelongedFaction != null) && !this.BelongedFaction.IsPositionKnown(point)))
                                    {
                                        continue;
                                    }
                                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                                    if ((troopByPosition != null) && !(this.IsFriendly(troopByPosition.BelongedFaction) || (troopByPosition.Status == TroopStatus.埋伏)))
                                    {
                                        return false;
                                    }
                                    Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(point);
                                    if (((architectureByPosition != null) && (architectureByPosition.BelongedFaction != null)) && !this.IsFriendly(architectureByPosition.BelongedFaction))
                                    {
                                        return false;
                                    }
                                }
                                return true;
                            }
                        }
                    }
                    return false;
                }
            }
            return false;
        }

        public void AmbushDetected(Troop troop)
        {
            troop.Status = TroopStatus.一般;
            troop.OperationDone = true;
            troop.MovabilityLeft = -1;
            if (this.OnDiscoverAmbush != null)
            {
                if (this != troop)
                {
                    this.OnDiscoverAmbush(this, troop);
                }
                else
                {
                    this.OnDiscoverAmbush(null, troop);
                }
            }
        }

        private void ApplyAreaInfluences(Point p)
        {
            if (base.Scenario.MapTileData[p.X, p.Y].AreaInfluenceList != null)
            {
                foreach (AreaInfluenceData data in base.Scenario.MapTileData[p.X, p.Y].AreaInfluenceList)
                {
                    data.ApplyAreaInfluence(this);
                }
            }
        }

        public void ApplyCurrentStunt()
        {
            if (this.CurrentStunt != null)
            {
                this.CurrentStunt.Apply(this);
                if (this.OnApplyStunt != null)
                {
                    this.OnApplyStunt(this, this.CurrentStunt);
                }
            }
        }

        private void ApplyDamageList()
        {
            foreach (TroopDamage damage in this.TroopDamageList)
            {
                this.HandleTroopDamage(damage);
            }
            this.TroopDamageList.Clear();
            foreach (ArchitectureDamage damage2 in this.ArchitectureDamageList)
            {
                this.HandleArchitectureDamage(damage2);
            }
            this.ArchitectureDamageList.Clear();
        }

        public void ApplyEventEffectInfluences()
        {
            foreach (Influence influence in this.EventInfluences)
            {
                influence.ApplyInfluence(this);
            }
        }

        public void ApplyGongxin(Troop troop, int baseDecrement)
        {
            troop.DecreaseMorale(this.GenerateMoraleDecrement(baseDecrement));
            CheckTroopRout(this, troop);
            if (!this.IsFriendly(troop.BelongedFaction) && GameObject.Chance(20))
            {
                Person maxControversyAbilityPerson = this.Persons.GetMaxControversyAbilityPerson();
                Person destination = troop.Persons.GetMaxControversyAbilityPerson();
                if (((maxControversyAbilityPerson != null) && (destination != null)) && (GameObject.Random(GameObject.Square(destination.Braveness)) < GameObject.Random(0x19)))
                {
                    int chance = Person.ControversyWinningChance(maxControversyAbilityPerson, destination);
                    if ((maxControversyAbilityPerson.Character.ControversyChance + chance) >= 60)
                    {
                        bool win = GameObject.Chance(chance);
                        if (win)
                        {
                            this.IncreaseCombativity(30);
                            troop.DecreaseCombativity(30);
                        }
                        else
                        {
                            this.DecreaseCombativity(30);
                            troop.IncreaseCombativity(30);
                        }
                        this.CurrentSourceControversyPerson = maxControversyAbilityPerson;
                        this.CurrentDestinationControversyPerson = destination;
                        if (this.OnPersonControversy != null)
                        {
                            this.OnPersonControversy(win, this, this.CurrentSourceControversyPerson, troop, this.CurrentDestinationControversyPerson);
                        }
                    }
                }
            }
        }

        private void ApplyStratagemEffect()
        {
            if (this.StratagemApplyed)
            {
                this.CurrentStratagem.Apply(this);
                this.StratagemApplyed = false;
                this.AreaStratagemTroops.Clear();
            }
            else if (this.WaitForDeepChaos)
            {
                this.WaitForDeepChaos = false;
                this.OrientationTroop.SetChaos(this.GenerateCastChaosDay(2));
            }
        }

        private void ApplyStuntInfluences()
        {
            if ((this.CurrentStunt != null) && (this.StuntDayLeft > 0))
            {
                foreach (Influence influence in this.CurrentStunt.Influences.Influences.Values)
                {
                    influence.ApplyInfluence(this.Leader);
                }
            }
        }

        private void AttackArchitecture(Architecture architecture)
        {
            if (architecture != null)
            {
                ArchitectureDamage damage = architecture.ReceiveAttackDamage(this.SendAttackDamage(architecture));
                this.StartAttackArchitecture(damage);
                if ((this.BaseAroundAttackRadius > 0) || (this.AroundAttackRadius > 0))
                {
                    foreach (Troop troop in this.GetAreaAttackTroops(this.Position, this.AroundAttackRadius, true))
                    {
                        if ((troop != this) && (!this.TroopNoAccidentalInjury || !this.IsFriendly(troop.BelongedFaction)))
                        {
                            TroopDamage damage2 = troop.ReceiveAttackDamage(this.SendAttackDamage(troop, false));
                            this.StartAttackTroop(troop, damage2, true);
                        }
                    }
                }
            }
        }

        private void AttackTroop(Troop troop)
        {
            if (troop != null)
            {
                TroopDamage damage2;
                TroopDamage damage = troop.ReceiveAttackDamage(this.SendAttackDamage(troop, false));
                if ((!damage.Waylay && !damage.AntiCounterAttack) && this.CounterAttackAvail(troop))
                {
                    damage2 = this.ReceiveAttackDamage(troop.SendAttackDamage(this, true));
                    damage.BeCountered = true;
                    damage.CounterDamage = damage2.Damage;
                    damage.CounterInjury = damage2.Injury;
                    damage.CounterCombativityDown = damage2.CounterCombativityDown;
                }
                if (this.PierceAttack || this.BasePierceAttack)
                {
                    foreach (Troop troop2 in this.GetTroopsBetween(troop))
                    {
                        if (!this.TroopNoAccidentalInjury || !this.IsFriendly(troop2.BelongedFaction))
                        {
                            damage2 = troop2.ReceiveAttackDamage(this.SendAttackDamage(troop2, false));
                            this.StartAttackTroop(troop2, damage2, true);
                        }
                    }
                }
                if (((this.AreaAttackRadius > 0) || (this.BaseAreaAttackRadius > 0)) || (this.StuntAttackRadius > 0))
                {
                    int radius = (this.AreaAttackRadius > this.BaseAreaAttackRadius) ? this.AreaAttackRadius : this.BaseAreaAttackRadius;
                    radius = (this.StuntAttackRadius > radius) ? this.StuntAttackRadius : radius;
                    foreach (Troop troop2 in this.GetAreaAttackTroops(troop.Position, radius, this.ScatteredShootingOblique))
                    {
                        if (((troop2 != troop) && (troop2 != this)) && (!this.TroopNoAccidentalInjury || !this.IsFriendly(troop2.BelongedFaction)))
                        {
                            damage2 = troop2.ReceiveAttackDamage(this.SendAttackDamage(troop2, false));
                            this.StartAttackTroop(troop2, damage2, true);
                        }
                    }
                }
                if ((this.BaseAroundAttackRadius > 0) || (this.AroundAttackRadius > 0))
                {
                    foreach (Troop troop2 in this.GetAreaAttackTroops(this.Position, this.AroundAttackRadius, true))
                    {
                        if (((troop2 != troop) && (troop2 != this)) && (!this.TroopNoAccidentalInjury || !this.IsFriendly(troop2.BelongedFaction)))
                        {
                            damage2 = troop2.ReceiveAttackDamage(this.SendAttackDamage(troop2, false));
                            this.StartAttackTroop(troop2, damage2, true);
                        }
                    }
                }
                if (this.BaseAttackAllOffenceArea || this.AttackAllOffenceArea)
                {
                    foreach (Troop troop2 in this.GetAllOffenceAreaTroops(this.Position))
                    {
                        if (((troop2 != troop) && (troop2 != this)) && (!this.TroopNoAccidentalInjury || !this.IsFriendly(troop2.BelongedFaction)))
                        {
                            damage2 = troop2.ReceiveAttackDamage(this.SendAttackDamage(troop2, false));
                            this.StartAttackTroop(troop2, damage2, true);
                        }
                    }
                }
                this.StartAttackTroop(troop, damage, false);
            }
        }

        public bool AutoAvail()
        {
            return ((((this.StartingArchitecture == null) && (this.BelongedFaction != null)) || ((this.StartingArchitecture != null) && (this.StartingArchitecture.BelongedFaction != this.BelongedFaction))) || ((((this.StartingArchitecture != null) && (this.StartingArchitecture.BelongedFaction == this.BelongedFaction)) && ((this.StartingArchitecture.BelongedSection != null) && (this.StartingArchitecture.BelongedSection.AIDetail != null))) && !this.StartingArchitecture.BelongedSection.AIDetail.AutoRun));
        }

        private void BeAngry()
        {
            this.OutburstOffenceMultiple = 2;
            this.OutburstNeverBeIntoChaos = true;
            this.CurrentOutburstKind = OutburstKind.愤怒;
            if (this.OnOutburst != null)
            {
                this.OnOutburst(this, this.CurrentOutburstKind);
            }
        }

        private void BeQuiet()
        {
            this.OutburstDefenceMultiple = 2;
            this.OutburstPreventCriticalStrike = true;
            this.CurrentOutburstKind = OutburstKind.沉静;
            if (this.OnOutburst != null)
            {
                this.OnOutburst(this, this.CurrentOutburstKind);
            }
        }

        public void BeRouted()
        {
            if (this.BelongedFaction == null)
            {
                this.Destroy();
                base.Scenario.Militaries.Remove(this.Army);
                base.Scenario.Troops.RemoveTroop(this);
                if ((this.StartingArchitecture != null) && (this.StartingArchitecture.RobberTroop == this))
                {
                    this.StartingArchitecture.RobberTroop = null;
                }
                if (this.OrientationTroop != null)
                {
                    this.OrientationTroop.OperationDone = !this.OrientationTroop.CanAttackAfterRout;
                }
            }
            else
            {
                bool flag = false;
                if ((this.BelongedFaction.Leader == this.Leader) && (this.BelongedFaction.ArchitectureCount == 0))
                {
                    flag = true;
                }
                foreach (Person person in this.Persons)
                {
                    if ((this.StartingArchitecture == null) || (this.BelongedFaction != this.StartingArchitecture.BelongedFaction))
                    {
                        if (this.BelongedFaction.Capital != null)
                        {
                            this.StartingArchitecture = this.BelongedFaction.Capital;
                        }
                        else
                        {
                            this.BelongedFaction.RemovePerson(person);
                        }
                    }
                    if (this.StartingArchitecture != null)
                    {
                        person.MoveToArchitecture(this.StartingArchitecture);
                    }
                    else if (base.Scenario.Architectures.Count > 0)
                    {
                        person.MoveToArchitecture(base.Scenario.Architectures[0] as Architecture);
                    }
                    person.LocationTroop = null;
                }
                this.Destroy();
                this.BelongedLegion.RemoveTroop(this);
                if (this.Army.ShelledMilitary == null)
                {
                    this.BelongedFaction.RemoveMilitary(this.Army);
                }
                else
                {
                    this.BelongedFaction.RemoveMilitary(this.Army.ShelledMilitary);
                    base.Scenario.Militaries.Remove(this.Army.ShelledMilitary);
                }
                base.Scenario.Militaries.Remove(this.Army);
                if (flag)
                {
                    TroopList list = new TroopList();
                    foreach (Troop troop in this.BelongedFaction.Troops)
                    {
                        if (troop != this)
                        {
                            list.Add(troop);
                        }
                    }
                    foreach (Troop troop in list)
                    {
                        troop.FactionDestroy();
                    }
                    this.BelongedFaction.Destroy();
                }
                else
                {
                    this.BelongedFaction.RemoveTroop(this);
                }
                base.Scenario.Troops.RemoveTroop(this);
                if ((this.OrientationTroop != null) && !this.ProhibitAllAction)
                {
                    this.OrientationTroop.OperationDone = !this.OrientationTroop.CanAttackAfterRout && !this.OrientationTroop.StuntCanAttackAfterRout;
                    if (!(this.OrientationTroop.OperationDone || this.OrientationTroop.QueueEnded))
                    {
                        this.OrientationTroop.AttackedTroopList.Clear();
                    }
                }
            }
        }

        private bool BuildThreeTierPath()
        {
            bool path = false;
            if (!this.HasPath)
            {
                this.EnableOneAdaptablility = true;
                bool flag2 = false;
                if ((this.BelongedFaction != null) && !GameObject.Chance(0x21))
                {
                    flag2 = true;
                    foreach (Troop troop in this.BelongedFaction.Troops)
                    {
                        if (!((troop == this) || troop.Destroyed))
                        {
                            base.Scenario.SetPenalizedMapDataByPosition(troop.Position, this.RealMovability);
                        }
                    }
                }
                path = this.pathFinder.GetPath(this.Position, this.Destination);
                if ((this.BelongedFaction != null) && flag2)
                {
                    foreach (Troop troop in this.BelongedFaction.Troops)
                    {
                        if (!((troop == this) || troop.Destroyed))
                        {
                            base.Scenario.ClearPenalizedMapDataByPosition(troop.Position);
                        }
                    }
                }
                this.EnableOneAdaptablility = false;
                if ((this.ThirdTierPath != null) && (this.SecondTierPath == null))
                {
                    if (!path)
                    {
                        path = this.pathFinder.GetSecondTierPath(this.Position, this.GetSecondTierDestinationFromThirdTier());
                    }
                    else
                    {
                        this.pathFinder.GetSecondTierPath(this.Position, this.GetSecondTierDestinationFromThirdTier());
                    }
                }
                if ((this.SecondTierPath != null) && (this.FirstTierPath == null))
                {
                    if (!path)
                    {
                        path = this.pathFinder.GetFirstTierPath(this.Position, this.GetFirstTierDestinationFromSecondTier());
                    }
                    else
                    {
                        this.pathFinder.GetFirstTierPath(this.Position, this.GetFirstTierDestinationFromSecondTier());
                    }
                }
                if (this.FirstTierPath != null)
                {
                    if (this.FirstTierPath.Count > 1)
                    {
                        this.HasPath = true;
                    }
                    return path;
                }
                if (this.Status != TroopStatus.一般)
                {
                    return path;
                }
                if (((((this.BelongedFaction != null) && (this.BelongedLegion != null)) && ((this.BelongedLegion.Kind == LegionKind.Offensive) && (this.StartingArchitecture != null))) && (this.StartingArchitecture.BelongedFaction == this.BelongedFaction)) && this.StartingArchitecture.ViewTroop(this))
                {
                    Routeway existingRouteway = this.StartingArchitecture.GetExistingRouteway(this.BelongedLegion.WillArchitecture);
                    if (existingRouteway != null)
                    {
                        base.Scenario.RemoveRouteway(existingRouteway);
                    }
                    Point key = new Point(this.StartingArchitecture.ID, this.BelongedLegion.WillArchitecture.ID);
                    if (!this.BelongedFaction.ClosedRouteways.ContainsKey(key))
                    {
                        this.BelongedFaction.ClosedRouteways.Add(key, null);
                    }
                }
                if (this.CanEnter())
                {
                    this.Enter();
                    return path;
                }
                this.GoBack();
                if (this.OnPathNotFound != null)
                {
                    this.OnPathNotFound(this);
                }
            }
            return path;
        }

        public void BurntBySpreadFire()
        {
            if (this.OnGetSpreadBurnt != null)
            {
                this.OnGetSpreadBurnt(this);
            }
        }

        private void CallDestroy()
        {
            if (this.WillArchitecture.Endurance >= (this.WillArchitecture.EnduranceCeiling * 0.1))
            {
                Person current;
                PersonList list = new PersonList();
                foreach (LinkNode node in this.WillArchitecture.AIAllLinkNodes.Values)
                {
                    if ((((node.A.BelongedFaction == this.BelongedFaction) && (node.A.Fund >= node.A.DestroyArchitectureFund)) && node.A.BelongedSection.AIDetail.AllowOffensiveTactics) && (node.A.RecentlyAttacked <= 0))
                    {
                        //using (IEnumerator enumerator2 = node.A.Persons.GetEnumerator())
                        IEnumerator enumerator2 = node.A.Persons.GetEnumerator();
                        {
                            while (enumerator2.MoveNext())
                            {
                                current = (Person) enumerator2.Current;
                                list.Add(current);
                            }
                        }
                        if (list.Count >= 10)
                        {
                            break;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "DestroyAbility";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    current = list[GameObject.Random(list.Count / 2)] as Person;
                    if (GameObject.Chance(GameObject.Random(current.DestroyAbility - 150)) && (GameObject.Random(current.NonFightingNumber) > GameObject.Random(current.FightingNumber)))
                    {
                        current.GoForDestroy(this.WillArchitecture.Position);
                    }
                }
            }
        }

        private void CallInformation()
        {
            this.BelongedLegion.CallInformation();
        }

        private void CallInstigate()
        {
            if (this.WillArchitecture.Endurance >= (this.WillArchitecture.EnduranceCeiling * 0.2))
            {
                Person current;
                PersonList list = new PersonList();
                foreach (LinkNode node in this.WillArchitecture.AIAllLinkNodes.Values)
                {
                    if ((((node.A.BelongedFaction == this.BelongedFaction) && (node.A.Fund >= node.A.InstigateArchitectureFund)) && node.A.BelongedSection.AIDetail.AllowOffensiveTactics) && (node.A.RecentlyAttacked <= 0))
                    {
                        //using (IEnumerator enumerator2 = node.A.Persons.GetEnumerator())
                        IEnumerator enumerator2 = node.A.Persons.GetEnumerator();
                        {
                            while (enumerator2.MoveNext())
                            {
                                current = (Person) enumerator2.Current;
                                list.Add(current);
                            }
                        }
                        if (list.Count >= 10)
                        {
                            break;
                        }
                    }
                }
                if (list.Count > 0)
                {
                    if (list.Count > 1)
                    {
                        list.PropertyName = "InstigateAbility";
                        list.IsNumber = true;
                        list.ReSort();
                    }
                    current = list[GameObject.Random(list.Count / 2)] as Person;
                    if (GameObject.Chance(GameObject.Random(current.InstigateAbility - 150)) && (GameObject.Random(current.NonFightingNumber) > GameObject.Random(current.FightingNumber)))
                    {
                        current.GoForInstigate(this.WillArchitecture.Position);
                    }
                }
            }
        }

        private void CallRoutewayHelp()
        {
            if (!this.IsFriendly(this.BelongedLegion.WillArchitecture.BelongedFaction) && ((this.BelongedLegion.PreferredRouteway != null) && (this.BelongedLegion.PreferredRouteway.BelongedFaction != null)))
            {
                Architecture destinationArchitecture = this.BelongedLegion.PreferredRouteway.DestinationArchitecture;
                if (((destinationArchitecture != null) && (destinationArchitecture.BelongedFaction != this.BelongedFaction)) && this.IsBaseViewingArchitecture(destinationArchitecture))
                {
                    Point? routewayWaterOrientation;
                    if ((this.Army.Kind.Type == MilitaryType.水军) && destinationArchitecture.IsBesideWater)
                    {
                        routewayWaterOrientation = this.GetRoutewayWaterOrientation(this.BelongedLegion.PreferredRouteway, destinationArchitecture);
                        if (routewayWaterOrientation.HasValue)
                        {
                            this.BelongedLegion.PreferredRouteway.ExtendTo(routewayWaterOrientation.Value);
                        }
                    }
                    else if (destinationArchitecture.AreaCount >= 4)
                    {
                        routewayWaterOrientation = this.GetRoutewayNormalOrientation(this.BelongedLegion.PreferredRouteway, destinationArchitecture);
                        if (routewayWaterOrientation.HasValue)
                        {
                            this.BelongedLegion.PreferredRouteway.ExtendTo(routewayWaterOrientation.Value);
                        }
                    }
                }
            }
        }

        private void CallTacticsHelp()
        {
            if (((this.WillArchitecture.BelongedFaction != null) && !this.IsFriendly(this.WillArchitecture.BelongedFaction)) && (base.Scenario.GetDistance(this.Position, this.WillArchitecture.Position) <= 10.0))
            {
                if (this.BelongedFaction.IsArchitectureKnown(this.WillArchitecture) || GameObject.Chance(0x21))
                {
                    if (GameObject.Chance(15))
                    {
                        if (this.WillArchitecture.Kind.HasDomination)
                        {
                            if (this.WillArchitecture.Domination >= (this.WillArchitecture.DominationCeiling * 0.8))
                            {
                                if ((this.WillArchitecture.Morale >= (this.WillArchitecture.MoraleCeiling * 0.6)) || (this.WillArchitecture.Endurance < (this.WillArchitecture.EnduranceCeiling * 0.2)))
                                {
                                    this.CallDestroy();
                                }
                                else
                                {
                                    this.CallInstigate();
                                }
                            }
                            else if (this.WillArchitecture.Domination >= (this.WillArchitecture.DominationCeiling * 0.5))
                            {
                                if ((this.WillArchitecture.Morale >= (this.WillArchitecture.MoraleCeiling * 0.3)) || (this.WillArchitecture.Endurance < (this.WillArchitecture.EnduranceCeiling * 0.2)))
                                {
                                    this.CallDestroy();
                                }
                                else
                                {
                                    this.CallInstigate();
                                }
                            }
                            else
                            {
                                this.CallInstigate();
                            }
                        }
                        else
                        {
                            this.CallDestroy();
                        }
                    }
                }
                else
                {
                    this.CallInformation();
                }
            }
        }

        public bool CanAttack(Troop troop)
        {
            if (troop.IsInArchitecture)
            {
                return (this.AirOffence && this.OffenceArea.HasPoint(troop.Position));
            }
            return this.OffenceArea.HasPoint(troop.Position);
        }

        public bool CancelCombatMethodAvail()
        {
            return ((this.CurrentCombatMethod != null) && !this.CombatMethodApplied);
        }

        public bool CancelStratagemAvail()
        {
            return ((this.Status == TroopStatus.埋伏) || ((this.CurrentStratagem != null) && !this.StratagemApplyed));
        }

        public bool CancelStuntAvail()
        {
            return ((this.CurrentStunt != null) && (this.StuntDayLeft == 0));
        }

        public bool CanEnter()
        {
            if (this.IsRobber)
            {
                return false;
            }
            if (!this.ControlAvail())
            {
                return false;
            }
            this.EnterList.Clear();
            foreach (Architecture architecture in base.Scenario.GetHighViewingArchitecturesByPosition(this.Position))
            {
                if ((architecture.BelongedFaction == this.BelongedFaction) && architecture.GetTroopEnterableArea(this).HasPoint(this.Position))
                {
                    this.EnterList.Add(architecture);
                }
            }
            return (this.EnterList.Count > 0);
        }

        public bool CanOccupy()
        {
            if (!this.IsRobber)
            {
                if (!this.ControlAvail())
                {
                    return false;
                }
                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.Position);
                if (architectureByPositionNoCheck != null)
                {
                    return (!architectureByPositionNoCheck.IsFriendly(this.BelongedFaction) && !architectureByPositionNoCheck.HasContactHostileTroop(this.BelongedFaction));
                }
            }
            return false;
        }

        private void CastTroop(Troop troop)
        {
            if (troop != null)
            {
                if (this.AreaStratagemRadius > 0)
                {
                    foreach (Troop troop2 in this.GetAreaCastTroops(troop.Position, this.AreaStratagemRadius, false))
                    {
                        if ((troop2 != troop) && (troop2 != this))
                        {
                            this.AreaStratagemTroops.Add(troop2);
                        }
                    }
                }
                this.StartCastTroop(troop);
            }
        }

        public void ChangeFaction(Faction faction)
        {
            if ((faction != null) && (this.BelongedFaction != null))
            {
                if (this.BelongedLegion.BelongedFaction != faction)
                {
                    this.BelongedLegion.BelongedFaction.RemoveLegion(this.BelongedLegion);
                    faction.AddLegion(this.BelongedLegion);
                    if ((this.BelongedLegion.Kind == LegionKind.Offensive) && (this.BelongedLegion.WillArchitecture.BelongedFaction == faction))
                    {
                        this.BelongedLegion.Kind = LegionKind.Defensive;
                    }
                }
                this.BelongedFaction.Troops.Remove(this);
                this.BelongedFaction.RemoveTroopKnownAreaData(this);
                foreach (Person person in this.Persons)
                {
                    this.BelongedFaction.RemovePerson(person);
                }
                foreach (Captive captive in this.Captives)
                {
                    this.BelongedFaction.RemoveCaptive(captive);
                }
                this.BelongedFaction.RemoveMilitary(this.Army);
                this.BelongedFaction = null;
                faction.AddTroop(this);
                faction.AddTroopKnownAreaData(this);
                foreach (Person person in this.Persons)
                {
                    faction.AddPerson(person);
                }
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (captive.CaptiveFaction == faction)
                    {
                        captive.CaptivePerson.MoveToArchitecture(captive.CaptiveFaction.Capital);
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
                faction.AddMilitary(this.Army);
                this.RefreshWithPersonList(this.Persons.GetList());
            }
        }

        public void ChangeMorale(int offset)
        {
            if (offset > 0)
            {
                this.IncreaseMorale(offset);
                if (this.PreAction == TroopPreAction.无)
                {
                    this.PreAction = TroopPreAction.鼓舞;
                }
            }
            else if (offset < 0)
            {
                this.DecreaseMorale(Math.Abs(offset));
            }
        }

        private void CheckCaptiveBeforeRout(Troop troop)
        {
            if ((((this.BelongedFaction != null) && (troop.BelongedFaction != null)) && !troop.ImmunityOfCaptive) && ((this.BelongedFaction != troop.BelongedFaction) && !troop.IsInArchitecture))
            {
                PersonList personlist = new PersonList();
                foreach (Person person in troop.Persons)
                {
                    if (!(person.ImmunityOfCaptive || (GameObject.Chance(person.ChanceOfNoCapture) || (GameObject.Random(this.CaptiveAblility) <= GameObject.Random(person.CaptiveAbility + 200)))))
                    {
                        personlist.Add(person);
                    }
                }
                if (personlist.Count > 0)
                {
                    foreach (Person person in personlist)
                    {
                        troop.RemovePerson(person);
                        Captive captive = Captive.Create(base.Scenario, person, this.BelongedFaction);
                        if (captive != null)
                        {
                            this.AddCaptive(captive);
                        }
                    }
                    if (this.OnGetNewCaptive != null)
                    {
                        this.OnGetNewCaptive(this, personlist);
                    }
                }
            }
        }

        private void CheckCaptiveOnOccupy(Architecture a)
        {
            if ((this.BelongedFaction != null) && (a.BelongedFaction != null))
            {
                PersonList personlist = new PersonList();
                foreach (Person person in a.Persons)
                {
                    if (!(person.ImmunityOfCaptive || (GameObject.Random(this.CaptiveAblility) <= GameObject.Random(person.CaptiveAbility + 200))))
                    {
                        personlist.Add(person);
                    }
                }
                if (personlist.Count > 0)
                {
                    foreach (Person person in personlist)
                    {
                        a.RemovePerson(person);
                        Captive captive = Captive.Create(base.Scenario, person, this.BelongedFaction);
                        if (captive != null)
                        {
                            this.AddCaptive(captive);
                        }
                    }
                    if (this.OnGetNewCaptive != null)
                    {
                        this.OnGetNewCaptive(this, personlist);
                    }
                }
            }
        }

        private void CheckCurrentPosition()
        {
            if (base.Scenario.FireTable.HasPosition(this.Position))
            {
                this.ReceiveFireDamage(Parameters.FireDamageScale * base.Scenario.GetTerrainDetailByPositionNoCheck(this.Position).FireDamageRate);
            }
        }

        private bool CheckPositionRouteway()
        {
            foreach (Routeway routeway in base.Scenario.GetActiveRoutewayListByPosition(this.Position))
            {
                if (!this.IsFriendly(routeway.BelongedFaction))
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckReLaunchPathFinder()
        {
            bool secondTierPath = false;
            if (((((this.SecondTierPath != null) && (this.ThirdTierPath != null)) && (this.SecondTierPath.Count > 0)) && ((this.Movability == this.MovabilityLeft) && (this.SecondTierPath[this.SecondTierPath.Count - 1] != GetSecondTierCoordinate(this.Destination)))) && ReLaunchSecondPathFinder(this.Position, this.GetCentrePointInThirdTierPosition(this.ThirdTierPath[this.thirdTierPathDestinationIndex])))
            {
                if (!secondTierPath)
                {
                    secondTierPath = this.pathFinder.GetSecondTierPath(this.Position, this.GetSecondTierDestinationFromThirdTier());
                }
                else
                {
                    this.pathFinder.GetSecondTierPath(this.Position, this.GetSecondTierDestinationFromThirdTier());
                }
            }
            if (((((this.FirstTierPath != null) && (this.SecondTierPath != null)) && (this.FirstTierPath.Count > 0)) && ((this.Movability == this.MovabilityLeft) && (this.FirstTierPath[this.FirstTierPath.Count - 1] != this.Destination))) && ReLaunchFirstPathFinder(this.Position, this.GetCentrePointInSecondTierPosition(this.SecondTierPath[this.secondTierPathDestinationIndex])))
            {
                if (!secondTierPath)
                {
                    return this.pathFinder.GetFirstTierPath(this.Position, this.GetFirstTierDestinationFromSecondTier());
                }
                this.pathFinder.GetFirstTierPath(this.Position, this.GetFirstTierDestinationFromSecondTier());
            }
            return secondTierPath;
        }

        public static void CheckTroopRout(Troop receiving)
        {
            if (!receiving.Destroyed && ((receiving.Quantity <= 0) || (receiving.Morale <= 0)))
            {
                if (receiving.OnRouted != null)
                {
                    receiving.OnRouted(null, receiving);
                }
                GameObjects.Animations.TileAnimation animation = receiving.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.被击破, receiving.Position, false);
                if (animation != null)
                {
                    receiving.TryToPlaySound(receiving.Position, animation.LinkedAnimation.SoundPath, false);
                }
                if (receiving.BelongedFaction != null)
                {
                    receiving.IncreaseRoutExperience(false);
                    receiving.AddRoutedCount();
                }
                if (receiving.StartingArchitecture != null)
                {
                    receiving.StartingArchitecture.AddPopulationPack((int) (receiving.Scenario.GetDistance(receiving.Position, receiving.StartingArchitecture.ArchitectureArea) / 2.0), receiving.GetPopulation());
                }
                receiving.BeRouted();
            }
        }

        public static void CheckTroopRout(Troop sending, Troop receiving)
        {
            if (!receiving.Destroyed && ((receiving.Quantity <= 0) || (receiving.Morale <= 0)))
            {
                Faction belongedFaction = null;
                Person leader = null;
                if (receiving.BelongedFaction != null)
                {
                    belongedFaction = receiving.BelongedFaction;
                    leader = belongedFaction.Leader;
                }
                if (sending.OnRout != null)
                {
                    sending.OnRout(sending, receiving);
                }
                if (receiving.OnRouted != null)
                {
                    receiving.OnRouted(sending, receiving);
                }
                GameObjects.Animations.TileAnimation animation = sending.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.被击破, receiving.Position, false);
                if (animation != null)
                {
                    receiving.TryToPlaySound(receiving.Position, animation.LinkedAnimation.SoundPath, false);
                }
                if ((sending.BelongedFaction != null) && (belongedFaction != null))
                {
                    sending.Scenario.ChangeDiplomaticRelation(sending.BelongedFaction.ID, receiving.BelongedFaction.ID, -10);
                    sending.Scenario.ReflectDiplomaticRelations(sending.BelongedFaction.ID, receiving.BelongedFaction.ID, -10);
                }
                if (sending.BelongedFaction != null)
                {
                    sending.IncreaseRoutExperience(true);
                    sending.AddRoutCount();
                }
                if (belongedFaction != null)
                {
                    receiving.IncreaseRoutExperience(false);
                    receiving.AddRoutedCount();
                    receiving.ReleaseCaptiveBeforeBeRouted();
                    if (sending.BelongedFaction != null)
                    {
                        sending.CheckCaptiveBeforeRout(receiving);
                    }
                }
                if (sending.StartingArchitecture != null)
                {
                    sending.StartingArchitecture.AddPopulationPack((int) (sending.Scenario.GetDistance(receiving.Position, sending.StartingArchitecture.ArchitectureArea) / 2.0), receiving.GetPopulation());
                }
                receiving.BeRouted();
                if (sending.Combativity < sending.Army.CombativityCeiling)
                {
                    sending.IncreaseCombativity(10 + sending.RoutIncrementOfCombativity);
                    if (sending.PreAction == TroopPreAction.无)
                    {
                        sending.PreAction = TroopPreAction.鼓舞;
                    }
                }
                if (sending.Morale < sending.Army.MoraleCeiling)
                {
                    sending.IncreaseMorale(5);
                    if (sending.PreAction == TroopPreAction.无)
                    {
                        sending.PreAction = TroopPreAction.鼓舞;
                    }
                }
            }
        }

        public void ClearFirstTierPath()
        {
            this.FirstTierPath = null;
            this.firstTierPathIndex = 0;
        }

        public void ClearSecondTierPath()
        {
            this.SecondTierPath = null;
            this.secondTierPathDestinationIndex = 0;
        }

        public void ClearThirdTierPath()
        {
            this.ThirdTierPath = null;
            this.thirdTierPathDestinationIndex = 0;
        }

        public string CombativityInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Combativity, 20);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Combativity, 10);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Combativity, 5);

                case InformationLevel.全:
                    return this.Combativity.ToString();
            }
            return "----";
        }

        public bool CombatMethodAvail()
        {
            return (this.Status == TroopStatus.一般);
        }

        public bool ControlAvail()
        {
            return ((this.Status != TroopStatus.混乱) && this.Controllable);
        }

        public bool CounterAttackAvail(Troop troop)
        {
            return ((((!troop.Destroyed && troop.CounterOffence) && (this.BeCountered && (troop.Offence > 0))) && (!this.BaseNoCounterAttack && !this.NoCounterAttack)) && troop.OffenceArea.HasPoint(this.Position));
        }

        public bool CounterAttackAvail(Troop troop, Point position)
        {
            return ((((!troop.Destroyed && troop.CounterOffence) && (this.BeCountered && (troop.Offence > 0))) && (!this.BaseNoCounterAttack && !this.NoCounterAttack)) && troop.OffenceArea.HasPoint(position));
        }

        public static Troop Create(Architecture from, GameObjectList persons, Person leader, Military military, int food, Point position)
        {
            Troop troop = new Troop();
            troop.Scenario = from.Scenario;
            troop.destination = position;
            troop.realDestination = position;
            troop.StartingArchitecture = from;
            troop.ID = troop.Scenario.Troops.GetFreeGameObjectID();
            foreach (Person person in persons.GetList())
            {
                troop.AddPerson(person);
                from.RemovePerson(person);
            }
            troop.SetLeader(leader);
            if (from.BelongedFaction != null)
            {
                from.BelongedFaction.AddTroop(troop);
                troop.TechnologyIncrement = from.Technology / 50;
                if (military.ShelledMilitary == null)
                {
                    from.RemoveMilitary(military);
                }
                else
                {
                    from.RemoveMilitary(military.ShelledMilitary);
                    from.Scenario.Militaries.AddMilitary(military);
                }
            }
            troop.Army = military;
            if (food < 0)
            {
                if (from.Food > (6 * military.FoodMax))
                {
                    troop.Food = military.FoodMax;
                }
                else if (from.Food > (3 * military.FoodMax))
                {
                    troop.Food = military.FoodCostPerDay * ((int) Math.Ceiling((double) (((float) military.RationDays) / 2f)));
                }
                else if (from.Food > military.FoodMax)
                {
                    troop.Food = military.FoodCostPerDay * (1 + (military.RationDays / 4));
                }
                else if (from.Food > (military.FoodCostPerDay * (1 + (military.RationDays / 6))))
                {
                    troop.Food = military.FoodCostPerDay * (1 + (military.RationDays / 6));
                }
                else if (from.Food > military.FoodCostPerDay)
                {
                    troop.Food = military.FoodCostPerDay;
                }
                else
                {
                    troop.Food = 0;
                }
            }
            else
            {
                troop.Food = food;
            }
            if (troop.Food > 0)
            {
                from.DecreaseFood(troop.Food);
            }
            troop.InitializePosition(position);
            troop.Scenario.Troops.AddTroopWithEvent(troop);
            if (troop.OnTroopCreate != null)
            {
                troop.OnTroopCreate(troop);
            }
            return troop;
        }

        public static Troop CreateSimulateTroop(GameObjectList persons, Military military, Point startPosition)
        {
            Troop troop = new Troop();
            troop.Scenario = military.Scenario;
            troop.Simulating = true;
            if (persons != null)
            {
                foreach (Person person in persons)
                {
                    troop.AddPerson(person);
                }
                troop.SetLeader(persons[0] as Person);
                troop.BackupArmyLeaderID = (military.Leader != null) ? military.Leader.ID : -1;
                troop.BackupArmyLeaderExperience = military.LeaderExperience;
                troop.BackupArmyLeader = military.Leader;
                troop.Army = military;
                troop.SimulateInitializePosition(startPosition);
                foreach (Person person in persons)
                {
                    person.LocationTroop = null;
                }
            }
            troop.Simulating = false;
            military.Leader = troop.BackupArmyLeader;
            military.LeaderExperience = troop.BackupArmyLeaderExperience;
            military.LeaderID = troop.BackupArmyLeaderID;
            return troop;
        }

        public static Troop CreateSimulateTroop(Architecture architecture, GameObjectList persons, Person Leader, Military military, int rationdays, Point startPosition)
        {
            Troop troop = new Troop();
            troop.Scenario = architecture.Scenario;
            troop.BelongedFaction = architecture.BelongedFaction;
            troop.Simulating = true;
            troop.TechnologyIncrement = architecture.Technology / 50;
            troop.StartingArchitecture = architecture;
            if (persons != null)
            {
                foreach (Person person in persons)
                {
                    troop.AddPerson(person);
                }
                troop.SetLeader(Leader);
            }
            if (military != null)
            {
                troop.BackupArmyLeaderID = (military.Leader != null) ? military.Leader.ID : -1;
                troop.BackupArmyLeaderExperience = military.LeaderExperience;
                troop.BackupArmyLeader = military.Leader;
                troop.Army = military;
                troop.Food = military.FoodCostPerDay * rationdays;
            }
            if (persons != null)
            {
                troop.SimulateInitializePosition(startPosition);
                foreach (Person person in persons)
                {
                    person.LocationTroop = null;
                }
            }
            troop.Simulating = false;
            if (military != null)
            {
                military.Leader = troop.BackupArmyLeader;
                military.LeaderExperience = troop.BackupArmyLeaderExperience;
                military.LeaderID = troop.BackupArmyLeaderID;
            }
            return troop;
        }

        public bool CureAvail(int id)
        {
            Stratagem stratagem = this.Stratagems.GetStratagem(id);
            return ((stratagem != null) && ((stratagem.Combativity <= (this.Combativity + this.DecrementOfStratagemCombativityConsuming)) && this.AllowCure));
        }

        private void CutPositionRouteway()
        {
            bool success = false;
            foreach (Routeway routeway in base.Scenario.GetActiveRoutewayListByPosition(this.Position))
            {
                if (!this.IsFriendly(routeway.BelongedFaction))
                {
                    int num = routeway.ShrinkAt(this.Position);
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, routeway.BelongedFaction.ID, -10);
                    this.BelongedFaction.IncreaseTechniquePoint(num * 0x3e8);
                    this.BelongedFaction.IncreaseReputation(num * 5);
                    foreach (Person person in this.Persons)
                    {
                        person.AddStrengthExperience(num * 5);
                        person.AddCommandExperience(num * 5);
                        person.AddIntelligenceExperience(num * 5);
                        if (person == this.Leader)
                        {
                            person.IncreaseReputation((num * 5) * 2);
                        }
                        else
                        {
                            person.IncreaseReputation(num * 5);
                        }
                    }
                    success = true;
                    if (this.Combativity < this.Army.CombativityCeiling)
                    {
                        this.IncreaseCombativity(10);
                        if (this.PreAction == TroopPreAction.无)
                        {
                            this.PreAction = TroopPreAction.鼓舞;
                        }
                    }
                    if (this.Morale < this.Army.MoraleCeiling)
                    {
                        this.IncreaseMorale(10);
                        if (this.PreAction == TroopPreAction.无)
                        {
                            this.PreAction = TroopPreAction.鼓舞;
                        }
                    }
                    int increment = this.FoodMax - this.Food;
                    if (increment > 0)
                    {
                        float num3 = 1f - routeway.GetPoint(this.Position).ConsumptionRate;
                        if (num3 > 0f)
                        {
                            if ((routeway.StartArchitecture.Food * num3) >= increment)
                            {
                                this.IncreaseFood(increment);
                                routeway.StartArchitecture.DecreaseFood((int) (((float) increment) / num3));
                            }
                            else
                            {
                                this.IncreaseFood((int) (routeway.StartArchitecture.Food * num3));
                                routeway.StartArchitecture.Food = 0;
                            }
                            if (this.PreAction == TroopPreAction.无)
                            {
                                this.PreAction = TroopPreAction.鼓舞;
                            }
                        }
                    }
                }
            }
            if (this.OnEndCutRouteway != null)
            {
                this.OnEndCutRouteway(this, success);
            }
        }

        public void CutRouteway()
        {
            this.CutRoutewayDays = this.CutRoutewayDaysNeeded;
            this.Controllable = false;
            this.Operated = true;
            if (this.OnStartCutRouteway != null)
            {
                this.OnStartCutRouteway(this, this.CutRoutewayDays);
            }
        }

        public bool CutRoutewayAvail()
        {
            foreach (Routeway routeway in base.Scenario.GetActiveRoutewayListByPosition(this.Position))
            {
                if (!this.IsFriendly(routeway.BelongedFaction) && (this.BelongedFaction.GetKnownAreaData(this.Position) >= GlobalVariables.ScoutRoutewayInformationLevel))
                {
                    return true;
                }
            }
            return false;
        }

        public void DayEvent()
        {
            if (this.BelongedFaction != null)
            {
                this.ViewingWillArchitecture = this.IsViewingWillArchitecture();
                this.ContactingWillArchitecture = this.IsContactingWillArchitecture();
                this.OffencingWillArchitecture = this.IsOffencingWillArchitecture();
                this.ContactHostileTroopCount = this.GetContactHostileTroops().Count;
                this.ContactFriendlyTroopCount = this.GetContactFriendlyTroops().Count;
                this.SetFriendlyTroopsInView();
                this.SetHostileTroopsInView();
            }
            if (this.StartingArchitecture != null)
            {
            }
            if ((this.IncrementPerDayOfCombativity + this.CombativityIncrementPerDayByViewArea) > 0)
            {
                this.IncreaseCombativity(this.IncrementPerDayOfCombativity + this.CombativityIncrementPerDayByViewArea);
            }
            if ((this.DecrementPerDayOfCombativity + this.CombativityDecrementPerDayByViewArea) > 0)
            {
                this.DecreaseCombativity(this.DecrementPerDayOfCombativity + this.CombativityDecrementPerDayByViewArea);
            }
            if ((this.InjuryRecoveryPerDayRate > 0f) && (this.InjuryQuantity > 0))
            {
                int number = this.Army.Recovery(this.InjuryRecoveryPerDayRate);
                if (number > 0)
                {
                    this.RefreshOffence();
                    this.RefreshDefence();
                    this.IncrementNumberList.AddNumber(number, CombatNumberKind.人数, this.Position);
                    this.ShowNumber = true;
                }
            }
            if (this.ChaosDayLeft > 0)
            {
                this.ChaosDayLeft--;
                if ((this.ChaosDayLeft == 0) || this.StuntRecoverFromChaos)
                {
                    this.SetRecoverFromChaos();
                }
            }
            if (base.Scenario.FireTable.HasPosition(this.Position))
            {
                this.SetOnFire(Parameters.FireDamageScale * base.Scenario.GetTerrainDetailByPositionNoCheck(this.Position).FireDamageRate);
            }
            if (this.CutRoutewayDays > 0)
            {
                this.CutRoutewayDays--;
                if (this.CutRoutewayDays == 0)
                {
                    this.CutPositionRouteway();
                }
                else if (this.CheckPositionRouteway())
                {
                    this.Controllable = false;
                    this.Operated = true;
                }
                else
                {
                    this.CutRoutewayDays = 0;
                    if (this.OnEndCutRouteway != null)
                    {
                        this.OnEndCutRouteway(this, false);
                    }
                }
            }
            if (this.Food >= this.FoodCostPerDay)
            {
                this.Food -= this.FoodCostPerDay;
                this.RefillFoodByArchitecture();
                this.RefillFoodByRouteway();
            }
            else
            {
                this.RefillFoodByArchitecture();
                this.RefillFoodByRouteway();
                if (this.Food < this.FoodCostPerDay)
                {
                    this.Food = 0;
                    if (this.RecentlyFighting > 0)
                    {
                        this.DecreaseCombativity(10);
                        this.DecreaseMorale((int) (10f * this.MoraleChangeRateOnOutOfFood));
                    }
                    else
                    {
                        this.DecreaseCombativity(5);
                        this.DecreaseMorale(5);
                    }
                    CheckTroopRout(this);
                }
                else
                {
                    this.Food -= this.FoodCostPerDay;
                }
            }
            if (this.BelongedFaction != null)
            {
                foreach (TroopEvent event2 in base.Scenario.TroopEvents.GetRandomList())
                {
                    if (event2.CheckTroop(this))
                    {
                        event2.ApplyEventDialogs(this);
                        TroopList list = null;
                        if (base.Scenario.TroopEventsToApply.TryGetValue(event2, out list))
                        {
                            list.Add(this);
                        }
                        else
                        {
                            list = new TroopList();
                            list.Add(this);
                            base.Scenario.TroopEventsToApply.Add(event2, list);
                        }
                    }
                }
            }
            if ((this.CurrentStunt != null) && (this.StuntDayLeft > 0))
            {
                this.StuntDayLeft--;
                if (this.StuntDayLeft == 0)
                {
                    this.CurrentStunt.Purify(this);
                    this.CurrentStunt = null;
                    this.RefreshAllData();
                }
            }
            this.ResetDayInfluence();
        }

        public bool DaysToReachPosition(Point position, int days)
        {
            this.MovabilityLeft = this.Movability;
            List<Point> firstTierSimulatePath = this.pathFinder.GetFirstTierSimulatePath(this.Position, position);
            Point currentPosition = this.Position;
            List<Point> list2 = new List<Point>();
            if (firstTierSimulatePath != null)
            {
                foreach (Point point2 in firstTierSimulatePath)
                {
                    if (this.GetOffenceArea(point2).HasPoint(position))
                    {
                        return (list2.Count <= days);
                    }
                    if (days == 0)
                    {
                        return false;
                    }
                    if (list2.Count > days)
                    {
                        return false;
                    }
                    if (point2 == this.Position)
                    {
                        list2.Add(point2);
                    }
                    else if (point2 != position)
                    {
                        int num = this.NextPositionCost(currentPosition, point2);
                        this.MovabilityLeft -= num;
                        if (this.MovabilityLeft <= 0)
                        {
                            list2.Add(point2);
                            this.MovabilityLeft = this.Movability;
                        }
                    }
                }
            }
            return (list2.Count <= days);
        }

        public void DecreaseCombativity(int decrement)
        {
            decrement = this.Army.DecreaseCombativity(decrement);
            if (decrement > 0)
            {
                this.DecrementNumberList.AddNumber(decrement, CombatNumberKind.战意, this.Position);
                this.ShowNumber = true;
            }
        }

        public void DecreaseInjuryQuantity(int decrement)
        {
            this.Army.DecreaseInjuryQuantity(decrement);
        }

        public void DecreaseMorale(int decrement)
        {
            decrement = this.Army.DecreaseMorale(decrement);
            if (decrement > 0)
            {
                this.RefreshOffence();
                this.RefreshDefence();
                this.DecrementNumberList.AddNumber(decrement, CombatNumberKind.士气, this.Position);
                this.ShowNumber = true;
            }
        }

        public void DecreaseQuantity(int decrement)
        {
            int quantity = 0;
            if (this.Army.Quantity > decrement)
            {
                quantity = decrement;
            }
            else
            {
                quantity = this.Army.Quantity;
            }
            this.Army.DecreaseQuantity(quantity);
            if (quantity > 0)
            {
                this.RefreshOffence();
                this.RefreshDefence();
                if (this.Food > this.FoodMax)
                {
                    this.Food = this.FoodMax;
                }
            }
            this.DecrementNumberList.AddNumber(quantity, CombatNumberKind.人数, this.Position);
            this.ShowNumber = true;
        }

        public void Destroy()
        {
            this.Destroyed = true;
            base.Scenario.ResetMapTileTroop(this.Position);
            this.FinalizeContactArea();
            this.FinalizeOffenceArea();
            this.FinalizeStratagemArea();
            this.FinalizeViewArea();
        }

        public void DetectAmbush(Troop troop)
        {
            int chance = ((15 + (this.TroopIntelligence / 10)) + this.Leader.Calmness) - troop.Leader.Calmness;
            if (this.ScoutLevel <= InformationLevel.中)
            {
                if (troop.OnlyBeDetectedByHighLevelInformation)
                {
                    return;
                }
            }
            else
            {
                chance *= troop.OnlyBeDetectedByHighLevelInformation ? 3 : 1;
            }
            if (GameObject.Chance(chance))
            {
                this.AmbushDetected(troop);
            }
        }

        internal void DoCombatAction()
        {
            switch (this.Will)
            {
                case TroopWill.行军:
                    if (this.CurrentStratagem == null)
                    {
                        if (this.OrientationTroop != null)
                        {
                            this.AttackTroop(this.OrientationTroop);
                        }
                        else if (this.OrientationArchitecture != null)
                        {
                            this.AttackArchitecture(this.OrientationArchitecture);
                        }
                        break;
                    }
                    if (this.CurrentStratagem.Self)
                    {
                        this.StartCastSelf();
                    }
                    else
                    {
                        this.CastTroop(this.OrientationTroop);
                    }
                    break;
            }
        }

        public void EndAmbush()
        {
            this.Status = TroopStatus.一般;
            if (this.OnStopAmbush != null)
            {
                this.OnStopAmbush(this);
            }
        }

        public void Enter()
        {
            if (this.EnterList.Count > 0)
            {
                Architecture a = this.EnterList[GameObject.Random(this.EnterList.Count)] as Architecture;
                this.Enter(a);
            }
        }

        public void Enter(Architecture a)
        {
            if (a.BelongedFaction == this.BelongedFaction)
            {
                PersonList list = new PersonList();
                foreach (Person person in this.Persons)
                {
                    list.Add(person);
                    a.AddPerson(person);
                }
                this.Persons.ApplyInfluences();
                foreach (Person person in list)
                {
                    this.RemovePerson(person);
                }
                if (this.Army.ShelledMilitary == null)
                {
                    a.AddMilitary(this.Army);
                }
                else
                {
                    a.AddMilitary(this.Army.ShelledMilitary);
                    base.Scenario.Militaries.Remove(this.Army);
                }
                if (this.Food > 0)
                {
                    a.IncreaseFood(this.Food);
                }
                this.MoveCaptiveIntoArchitecture(a);
                this.Destroy();
                this.BelongedLegion.RemoveTroop(this);
                this.BelongedFaction.RemoveTroop(this);
                base.Scenario.Troops.RemoveTroop(this);
            }
        }

        public void FactionDestroy()
        {
            GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.被击破, this.Position, false);
            if (animation != null)
            {
                this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
            }
            foreach (Person person in this.Persons)
            {
                if (person.BelongedFaction != null)
                {
                    person.BelongedFaction.RemovePerson(person);
                }
                person.MoveToArchitecture(this.StartingArchitecture);
            }
            this.Destroy();
            if (this.Army.ShelledMilitary == null)
            {
                this.BelongedFaction.RemoveMilitary(this.Army);
            }
            else
            {
                this.BelongedFaction.RemoveMilitary(this.Army.ShelledMilitary);
                base.Scenario.Militaries.Remove(this.Army.ShelledMilitary);
            }
            base.Scenario.Militaries.Remove(this.Army);
            this.BelongedLegion.RemoveTroop(this);
            this.BelongedFaction.RemoveTroop(this);
            base.Scenario.Troops.RemoveTroop(this);
            this.BelongedFaction = null;
        }

        private void FinalizeContactArea()
        {
            foreach (Point point in this.ContactArea.Area)
            {
                base.Scenario.RemovePositionContactingTroop(this, point);
            }
            this.ContactArea = null;
        }

        public void FinalizeInQueue()
        {
            this.ResetOutburstParametres();
            if (this.CurrentCombatMethod != null)
            {
                this.CurrentCombatMethod.Purify(this);
                this.CurrentCombatMethod = null;
            }
            if (this.CurrentStratagem != null)
            {
                this.CurrentStratagem = null;
            }
            if (!this.Moved)
            {
                this.Destination = this.Position;
            }
            this.RefreshAllData();
        }

        private void FinalizeOffenceArea()
        {
            foreach (Point point in this.OffenceArea.Area)
            {
                base.Scenario.RemovePositionOffencingTroop(this, point);
            }
            this.OffenceArea = null;
        }

        private void FinalizeStratagemArea()
        {
            foreach (Point point in this.StratagemArea.Area)
            {
                base.Scenario.RemovePositionStratagemingTroop(this, point);
            }
            this.StratagemArea = null;
        }

        private void FinalizeViewArea()
        {
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.RemoveTroopKnownAreaData(this);
            }
            foreach (Point point in this.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.RemovePositionViewingTroopNoCheck(this, point);
                    this.RemoveAreaInfluences(point);
                }
            }
            this.ViewArea = null;
        }

        public int GenerateAttackChaosDay(int maxDays)
        {
            if (this.BelongedFaction != null)
            {
                return ((1 + this.BelongedFaction.IncrementOfChaosDaysAfterPhisicalAttack) + GameObject.Random(maxDays));
            }
            return (1 + GameObject.Random(maxDays));
        }

        public int GenerateBoostIncrement(int baseIncrement)
        {
            return (int) ((baseIncrement + StaticMethods.GetRandomValue(this.TroopIntelligence, 20)) * this.RateOfBoost);
        }

        public int GenerateCastChaosDay(int maxDays)
        {
            return ((1 + this.IncrementOfChaosDay) + GameObject.Random(maxDays));
        }

        public float GenerateFireDamageScale(float baseScale, TerrainDetail td)
        {
            return (((baseScale + (((float) this.TroopIntelligence) / 200f)) * this.RateOfFireDamage) * td.FireDamageRate);
        }

        public int GenerateMoraleDecrement(int baseDecrement)
        {
            return (int) ((baseDecrement + StaticMethods.GetRandomValue(this.TroopIntelligence, 20)) * this.RateOfGongxin);
        }

        private TroopList GetAllOffenceAreaTroops(Point position)
        {
            TroopList list = new TroopList();
            foreach (Point point in this.GetOffenceArea(position).Area)
            {
                if ((this.BelongedFaction == null) || this.BelongedFaction.IsPositionKnown(point))
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (troopByPosition != null)
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }

        public TroopList GetAllOtherTroopsInView()
        {
            TroopList list = new TroopList();
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (troopByPosition != this))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        private TroopList GetAreaAttackTroops(Point centre, int radius, bool oblique)
        {
            GameArea area = GameArea.GetViewArea(centre, radius, oblique, base.Scenario, null);
            TroopList list = new TroopList();
            foreach (Point point in area.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (troopByPosition != null)
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        private TroopList GetAreaCastTroops(Point centre, int radius, bool oblique)
        {
            GameArea area = GameArea.GetViewArea(centre, radius, oblique, base.Scenario, null);
            TroopList list = new TroopList();
            foreach (Point point in area.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (this.CurrentStratagem.IsValid(troopByPosition) && (this.CurrentStratagem.Friendly || !this.IsFriendly(troopByPosition.BelongedFaction))))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        public TroopList GetAreaStratagemTroops(Troop troop, bool friendly)
        {
            TroopList list = new TroopList();
            foreach (Troop troop2 in this.GetAreaCastTroops(troop.Position, this.AreaStratagemRadius, false))
            {
                if ((!friendly || this.IsFriendly(troop2.BelongedFaction)) && (friendly || ((troop2 != this) && !this.IsFriendly(troop2.BelongedFaction))))
                {
                    list.Add(troop2);
                }
            }
            return list;
        }

        private TroopList GetAreaStratagemTroops(Point centre, int radius, bool oblique)
        {
            GameArea area = GameArea.GetViewArea(centre, radius, oblique, base.Scenario, null);
            TroopList list = new TroopList();
            foreach (Point point in area.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && (this.CurrentStratagem.IsValid(troopByPosition) && (this.CurrentStratagem.Friendly || !this.IsFriendly(troopByPosition.BelongedFaction))))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        private int GetAttackArchitecutreCredit(Architecture architecture)
        {
            int num = 0;
            if (architecture.Domination == 0)
            {
                num = 500;
            }
            int num2 = this.CriticalStrikeChance - (architecture.AreaCount * 3);
            int num3 = architecture.Domination + 1;
            if (num2 > 0)
            {
                num += (int) (((this.Offence * (100 + num2)) * this.ArchitectureDamageRate) / ((float) num3));
            }
            else
            {
                num += (int) (((this.Offence * 100) * this.ArchitectureDamageRate) / ((float) num3));
            }
            if (num <= 0)
            {
                num = 1;
            }
            if (((architecture.RecentlyBreaked <= 0) && (architecture.Endurance < 30)) && GameObject.Chance(50))
            {
                num *= 5;
            }
            if ((architecture.IncrementOfEndurancePerDay > 0) && (architecture.RecentlyBreaked > 0))
            {
                num /= 5;
            }
            if (this.SimulatingCombatMethod != null)
            {
                num /= 2;
            }
            return (num / 2);
        }

        private GameObject GetAttackOrientationObject(bool last)
        {
            TroopList attackPossibleTroops = this.GetAttackPossibleTroops(last);
            Troop minDefenceTroop = null;
            ArchitectureList attackPossibleArchitectures = this.GetAttackPossibleArchitectures(last);
            Architecture minEnduranceArchitecture = null;
            bool flag = true;
            switch (this.AttackDefaultKind)
            {
                case TroopAttackDefaultKind.防最弱:
                    minDefenceTroop = attackPossibleTroops.GetMinDefenceTroop(this.TargetTroop);
                    break;

                case TroopAttackDefaultKind.防最强:
                    minDefenceTroop = attackPossibleTroops.GetMaxDefenceTroop(this.TargetTroop);
                    break;

                case TroopAttackDefaultKind.攻最弱:
                    minDefenceTroop = attackPossibleTroops.GetMinOffenceTroop(this.TargetTroop);
                    break;

                case TroopAttackDefaultKind.攻最强:
                    minDefenceTroop = attackPossibleTroops.GetMaxOffenceTroop(this.TargetTroop);
                    break;

                case TroopAttackDefaultKind.耐最低:
                    flag = false;
                    minEnduranceArchitecture = attackPossibleArchitectures.GetMinEnduranceArchitecture(this.TargetArchitecture);
                    break;

                case TroopAttackDefaultKind.耐最高:
                    flag = false;
                    minEnduranceArchitecture = attackPossibleArchitectures.GetMaxEnduranceArchitecture(this.TargetArchitecture);
                    break;

                case TroopAttackDefaultKind.抗暴最低:
                    minDefenceTroop = attackPossibleTroops.GetMinAntiCriticalAttackTroop(this.TargetTroop);
                    break;

                case TroopAttackDefaultKind.抗暴最高:
                    minDefenceTroop = attackPossibleTroops.GetMaxAntiCriticalAttackTroop(this.TargetTroop);
                    break;
            }
            if (flag)
            {
                if (minDefenceTroop != null)
                {
                    this.OrientationTroop = minDefenceTroop;
                    this.OrientationArchitecture = null;
                    minDefenceTroop.OrientationTroop = this;
                    return minDefenceTroop;
                }
                minEnduranceArchitecture = attackPossibleArchitectures.GetMinEnduranceArchitecture(this.TargetArchitecture);
                if (minEnduranceArchitecture != null)
                {
                    this.OrientationTroop = null;
                    this.OrientationArchitecture = minEnduranceArchitecture;
                    this.OrientationPosition = base.Scenario.GetClosestPoint(minEnduranceArchitecture.ArchitectureArea, this.Position);
                    return minEnduranceArchitecture;
                }
            }
            else
            {
                if (minEnduranceArchitecture != null)
                {
                    this.OrientationTroop = null;
                    this.OrientationArchitecture = minEnduranceArchitecture;
                    this.OrientationPosition = base.Scenario.GetClosestPoint(minEnduranceArchitecture.ArchitectureArea, this.Position);
                    return minEnduranceArchitecture;
                }
                minDefenceTroop = attackPossibleTroops.GetMinDefenceTroop(this.TargetTroop);
                if (minDefenceTroop != null)
                {
                    this.OrientationTroop = minDefenceTroop;
                    this.OrientationArchitecture = null;
                    minDefenceTroop.OrientationTroop = this;
                    return minDefenceTroop;
                }
            }
            return null;
        }

        private ArchitectureList GetAttackPossibleArchitectures(bool last)
        {
            ArchitectureList list = new ArchitectureList();
            foreach (Point point in this.OffenceArea.Area)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(point);
                if (architectureByPosition != null)
                {
                    if ((architectureByPosition.Endurance == 0) || this.IsFriendly(architectureByPosition.BelongedFaction))
                    {
                        continue;
                    }
                    if (this.IfAttackArchitecture(architectureByPosition, last))
                    {
                        list.Add(architectureByPosition);
                    }
                }
            }
            return list;
        }

        private TroopList GetAttackPossibleTroops(bool last)
        {
            TroopList list = new TroopList();
            foreach (Point point in this.OffenceArea.Area)
            {
                if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(point)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(point)))
                {
                    Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point);
                    if ((troopByPositionNoCheck != null) && (troopByPositionNoCheck != this))
                    {
                        if (((this.AttackedTroopList.HasGameObject(troopByPositionNoCheck) || this.IsFriendly(troopByPositionNoCheck.BelongedFaction)) || (troopByPositionNoCheck.Status == TroopStatus.埋伏)) || !(this.AirOffence || !troopByPositionNoCheck.IsInArchitecture))
                        {
                            continue;
                        }
                        if (this.IfAttackTroop(troopByPositionNoCheck, last))
                        {
                            list.Add(troopByPositionNoCheck);
                        }
                    }
                }
            }
            return list;
        }

        private int GetAttackTroopCredit(Troop troop, Point position)
        {
            int pureAttackCredit = this.GetPureAttackCredit(troop);
            if (this.PierceAttack || this.BasePierceAttack)
            {
                foreach (Troop troop2 in this.GetTroopsBetween(position, troop.Position))
                {
                    if (this.TroopNoAccidentalInjury)
                    {
                        if (this.IsFriendly(troop2.BelongedFaction))
                        {
                            continue;
                        }
                    }
                    else if (this.IsFriendly(troop2.BelongedFaction))
                    {
                        pureAttackCredit -= (int) (this.GetPureAttackCredit(troop2) * 1.5f);
                        continue;
                    }
                    pureAttackCredit += this.GetPureAttackCredit(troop2);
                }
            }
            if (((this.AreaAttackRadius > 0) || (this.BaseAreaAttackRadius > 0)) || (this.StuntAttackRadius > 0))
            {
                int radius = (this.AreaAttackRadius > this.BaseAreaAttackRadius) ? this.AreaAttackRadius : this.BaseAreaAttackRadius;
                radius = (this.StuntAttackRadius > radius) ? this.StuntAttackRadius : radius;
                foreach (Troop troop2 in this.GetAreaAttackTroops(troop.Position, radius, this.ScatteredShootingOblique))
                {
                    if ((troop2 != troop) && (troop2 != this))
                    {
                        if (this.TroopNoAccidentalInjury)
                        {
                            if (this.IsFriendly(troop2.BelongedFaction))
                            {
                                continue;
                            }
                        }
                        else if (this.IsFriendly(troop2.BelongedFaction))
                        {
                            pureAttackCredit -= (int) (this.GetPureAttackCredit(troop2) * 1.5f);
                            continue;
                        }
                        pureAttackCredit += this.GetPureAttackCredit(troop2);
                    }
                }
            }
            if ((this.BaseAroundAttackRadius > 0) || (this.AroundAttackRadius > 0))
            {
                foreach (Troop troop2 in this.GetAreaAttackTroops(position, this.AroundAttackRadius, true))
                {
                    if ((troop2 != troop) && (troop2 != this))
                    {
                        if (this.TroopNoAccidentalInjury)
                        {
                            if (this.IsFriendly(troop2.BelongedFaction))
                            {
                                continue;
                            }
                        }
                        else if (this.IsFriendly(troop2.BelongedFaction))
                        {
                            pureAttackCredit -= this.GetPureAttackCredit(troop2);
                            continue;
                        }
                        pureAttackCredit += this.GetPureAttackCredit(troop2);
                    }
                }
            }
            if (this.BaseAttackAllOffenceArea || this.AttackAllOffenceArea)
            {
                foreach (Troop troop2 in this.GetAllOffenceAreaTroops(position))
                {
                    if ((troop2 != troop) && (troop2 != this))
                    {
                        if (this.TroopNoAccidentalInjury)
                        {
                            if (this.IsFriendly(troop2.BelongedFaction))
                            {
                                continue;
                            }
                        }
                        else if (this.IsFriendly(troop2.BelongedFaction))
                        {
                            pureAttackCredit -= (int) (this.GetPureAttackCredit(troop2) * 1.5f);
                            continue;
                        }
                        pureAttackCredit += this.GetPureAttackCredit(troop2);
                    }
                }
            }
            if (this.BaseAttackEveryAround || this.AttackEveryAround)
            {
                foreach (Troop troop2 in this.GetAllOffenceAreaTroops(position))
                {
                    if (((troop2 != troop) && (troop2 != this)) && !this.IsFriendly(troop2.BelongedFaction))
                    {
                        pureAttackCredit += this.GetPureAttackCredit(troop2);
                    }
                }
            }
            int positionHostileOffencingDiscredit = 0;
            Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(position);
            if ((architectureByPositionNoCheck != null) && (architectureByPositionNoCheck.Endurance > 0))
            {
                pureAttackCredit += ((pureAttackCredit * architectureByPositionNoCheck.TotalHostileForce) * 4) / (architectureByPositionNoCheck.TotalFriendlyForce + 1);
            }
            else
            {
                positionHostileOffencingDiscredit = base.Scenario.GetPositionHostileOffencingDiscredit(this, position);
            }
            if (position != this.Position)
            {
                float terranRateByPosition = this.GetTerranRateByPosition(position);
                return (int) ((pureAttackCredit * Math.Pow((double) terranRateByPosition, 2.0)) - (((double) positionHostileOffencingDiscredit) / Math.Pow((double) terranRateByPosition, 2.0)));
            }
            return (pureAttackCredit - positionHostileOffencingDiscredit);
        }

        public int GetAttackTroopDiscredit(Troop troop)
        {
            int num = 0;
            if (troop.Defence == 0)
            {
                num = 0x7fffffff;
            }
            int num2 = this.CriticalStrikeChance - troop.AntiCriticalStrikeChance;
            if (num2 > 0)
            {
                num = (this.Offence * ((100 + num2) + ((int) ((this.ChaosAfterCriticalStrikeChance * num2) / 100f)))) / troop.Defence;
            }
            else
            {
                num = (this.Offence * 100) / troop.Defence;
            }
            return (num / 8);
        }

        private Troop GetCastOrientationTroop(bool last)
        {
            TroopList castPossibleTroops = this.GetCastPossibleTroops(last);
            if (castPossibleTroops.Count == 0)
            {
                return null;
            }
            Troop minIntelligenceTroop = null;
            switch (this.CastDefaultKind)
            {
                case TroopCastDefaultKind.智最弱:
                    minIntelligenceTroop = castPossibleTroops.GetMinIntelligenceTroop(this.TargetTroop);
                    break;

                case TroopCastDefaultKind.智最强:
                    minIntelligenceTroop = castPossibleTroops.GetMaxIntelligenceTroop(this.TargetTroop);
                    break;

                case TroopCastDefaultKind.士最低:
                    minIntelligenceTroop = castPossibleTroops.GetMinMoraleTroop(this.TargetTroop);
                    break;

                case TroopCastDefaultKind.士最高:
                    minIntelligenceTroop = castPossibleTroops.GetMaxMoraleTroop(this.TargetTroop);
                    break;
            }
            if (minIntelligenceTroop != null)
            {
                this.OrientationTroop = minIntelligenceTroop;
                minIntelligenceTroop.OrientationTroop = this;
            }
            return minIntelligenceTroop;
        }

        private TroopList GetCastPossibleTroops(bool last)
        {
            TroopList list = new TroopList();
            foreach (Point point in this.StratagemArea.Area)
            {
                if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(point)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(point)))
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (((troopByPosition == null) || (troopByPosition.Action != TroopAction.Stop)) || (troopByPosition.Status == TroopStatus.埋伏))
                    {
                        continue;
                    }
                    if (this.CurrentStratagem.Friendly)
                    {
                        if (!this.IsFriendly(troopByPosition.BelongedFaction) || !this.CurrentStratagem.IsValid(troopByPosition))
                        {
                            continue;
                        }
                        if (this.IfCastTroop(troopByPosition, last))
                        {
                            list.Add(troopByPosition);
                        }
                    }
                    else
                    {
                        if (this.IsFriendly(troopByPosition.BelongedFaction) || !this.CurrentStratagem.IsValid(troopByPosition))
                        {
                            continue;
                        }
                        if (this.IfCastTroop(troopByPosition, last))
                        {
                            list.Add(troopByPosition);
                        }
                    }
                }
            }
            return list;
        }

        protected Point GetCentrePointInSecondTierPosition(Point position)
        {
            int x = position.X * GameObjectConsts.SecondTierSquareSize;
            int y = position.Y * GameObjectConsts.SecondTierSquareSize;
            if (this.BelongedFaction.SecondTierXResidue > 0)
            {
                x += this.BelongedFaction.SecondTierXResidue / 2;
            }
            else
            {
                x += GameObjectConsts.SecondTierSquareSize / 2;
            }
            if (this.BelongedFaction.SecondTierYResidue > 0)
            {
                y += this.BelongedFaction.SecondTierYResidue / 2;
            }
            else
            {
                y += GameObjectConsts.SecondTierSquareSize / 2;
            }
            return new Point(x, y);
        }

        protected Point GetCentrePointInThirdTierPosition(Point position)
        {
            int x = position.X * GameObjectConsts.ThirdTierSquareSize;
            int y = position.Y * GameObjectConsts.ThirdTierSquareSize;
            if (this.BelongedFaction.ThirdTierXResidue > 0)
            {
                x += this.BelongedFaction.ThirdTierXResidue / 2;
            }
            else
            {
                x += GameObjectConsts.ThirdTierSquareSize / 2;
            }
            if (this.BelongedFaction.ThirdTierYResidue > 0)
            {
                y += this.BelongedFaction.ThirdTierYResidue / 2;
            }
            else
            {
                y += GameObjectConsts.ThirdTierSquareSize / 2;
            }
            return new Point(x, y);
        }

        public string GetCombatMethodDisplayName(int id)
        {
            CombatMethod combatMethod = this.CombatMethods.GetCombatMethod(id);
            if (combatMethod != null)
            {
                int num = combatMethod.Combativity - this.DecrementOfCombatMethodCombativityConsuming;
                return (combatMethod.Name + "(" + num.ToString() + ")");
            }
            return "----";
        }

        public GameArea GetContactArea(Point position)
        {
            return GameArea.GetArea(position, 1, false);
        }

        public TroopList GetContactFriendlyTroops()
        {
            TroopList list = new TroopList();
            foreach (Point point in GameArea.GetArea(this.Position, 1, true).Area)
            {
                if ((point != this.Position) && this.BelongedFaction.IsPositionKnown(point))
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition != null) && this.IsFriendly(troopByPosition.BelongedFaction))
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }

        public TroopList GetContactHostileTroops()
        {
            TroopList list = new TroopList();
            foreach (Point point in GameArea.GetArea(this.Position, 1, true).Area)
            {
                if ((point != this.Position) && this.BelongedFaction.IsPositionKnown(point))
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (!((troopByPosition == null) || this.IsFriendly(troopByPosition.BelongedFaction)))
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }

        public int GetCostByPosition(Point position, bool oblique, int DirectionCost)
        {
            if ((this.EnableOneAdaptablility && (this.Army.Kind.OneAdaptabilityKind > 0)) && (this.Army.Kind.OneAdaptabilityKind ==(int)  base.Scenario.GetTerrainKindByPosition(position)))
            {
                return ((DirectionCost > 1) ? DirectionCost : 1);
            }
            int mapCost = this.GetMapCost(position);
            mapCost = (DirectionCost > mapCost) ? DirectionCost : mapCost;
            if (oblique)
            {
                if (this.MovabilityLeft >= (mapCost * 7))
                {
                    return mapCost;
                }
            }
            else if (this.MovabilityLeft >= (mapCost * 5))
            {
                return mapCost;
            }
            return 0xdac;
        }

        public int GetCostBySecondTierPosition(Point position)
        {
            if ((((position.X < 0) || (position.Y < 0)) || (position.X >= this.SecondTierMapCost.GetLength(0))) || (position.Y >= this.SecondTierMapCost.GetLength(1)))
            {
                return 0xdac;
            }
            return this.SecondTierMapCost[position.X, position.Y];
        }

        public int GetCostByThirdTierPosition(Point position)
        {
            if ((((position.X < 0) || (position.Y < 0)) || (position.X >= this.ThirdTierMapCost.GetLength(0))) || (position.Y >= this.ThirdTierMapCost.GetLength(1)))
            {
                return 0xdac;
            }
            return this.ThirdTierMapCost[position.X, position.Y];
        }

        private int GetCounterStrikeDiscredit(Troop troop, Point position)
        {
            if (!this.CounterAttackAvail(troop, position))
            {
                return 0;
            }
            int num = 0;
            if (this.Defence == 0)
            {
                num = 0x7fffffff;
            }
            num = ((troop.Offence * 100) / this.Defence) / 5;
            if (position != this.Position)
            {
                return (int) (((double) num) / Math.Pow((double) this.GetTerranRateByPosition(position), 2.0));
            }
            return num;
        }

        private CreditPack GetCreditByPosition(Point position)
        {
            int num = -2147483648;
            bool flag = false;
            bool flag2 = false;
            Troop troop = null;
            Architecture architecture = null;
            Point zero = Point.Zero;
            if ((!this.OffenceOnlyBeforeMove || (position == this.Position)) || this.OffenceOnlyBeforeMoveFlag)
            {
                foreach (Point point2 in this.GetOffenceArea(position).Area)
                {
                    if (((this.BelongedFaction == null) || this.BelongedFaction.IsPositionKnown(point2)) || base.Scenario.PositionIsArchitecture(point2))
                    {
                        int attackArchitecutreCredit;
                        Troop troopByPositionNoCheck;
                        int simpleDistance;
                        int surroundingCredit;
                        int num2 = base.Scenario.GetSimpleDistance(position, point2) * 10;
                        Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(point2);
                        if ((((architectureByPositionNoCheck != null) && (architectureByPositionNoCheck.Endurance > 0)) && (architectureByPositionNoCheck == this.WillArchitecture)) && !this.IsFriendly(architectureByPositionNoCheck.BelongedFaction))
                        {
                            flag = true;
                            attackArchitecutreCredit = this.GetAttackArchitecutreCredit(architectureByPositionNoCheck);
                            if ((this.ViewingHostileTroopCount > 0) || GameObject.Chance(0x21))
                            {
                                attackArchitecutreCredit += num2;
                            }
                            if (((this.WillArchitecture != null) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction)) && (this.WillArchitecture.BelongedFaction != architectureByPositionNoCheck.BelongedFaction))
                            {
                                attackArchitecutreCredit /= 2;
                            }
                            float terranRateByPosition = this.GetTerranRateByPosition(position);
                            attackArchitecutreCredit = (int) (attackArchitecutreCredit * Math.Pow((double) terranRateByPosition, 2.0));
                            if (attackArchitecutreCredit > num)
                            {
                                num = attackArchitecutreCredit;
                                troop = null;
                                architecture = architectureByPositionNoCheck;
                                zero = point2;
                            }
                            if ((this.BelongedFaction == null) || this.BelongedFaction.IsPositionKnown(point2))
                            {
                                troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point2);
                                if ((troopByPositionNoCheck != null) && !this.IsFriendly(troopByPositionNoCheck.BelongedFaction))
                                {
                                    if (this.AirOffence)
                                    {
                                        attackArchitecutreCredit = this.GetAttackTroopCredit(troopByPositionNoCheck, position) - this.GetCounterStrikeDiscredit(troopByPositionNoCheck, position);
                                        if ((this.SimulatingCombatMethod != null) && this.SimulatingCombatMethod.ViewingHostile)
                                        {
                                            if (GameObject.Random(5 + this.ViewingHostileTroopCount) > 5)
                                            {
                                                simpleDistance = base.Scenario.GetSimpleDistance(position, this.Position);
                                                if (simpleDistance > 10)
                                                {
                                                    simpleDistance = 10;
                                                }
                                                attackArchitecutreCredit += GameObject.Square(simpleDistance + this.ViewingHostileTroopCount) * 5;
                                            }
                                            else
                                            {
                                                attackArchitecutreCredit /= 2;
                                            }
                                        }
                                        surroundingCredit = this.GetSurroundingCredit(troopByPositionNoCheck);
                                        if (surroundingCredit > 0)
                                        {
                                            attackArchitecutreCredit += surroundingCredit * (100 - troopByPositionNoCheck.AvoidSurroundedChance);
                                        }
                                        attackArchitecutreCredit += num2;
                                        if (((this.WillArchitecture != null) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction)) && (this.WillArchitecture.BelongedFaction != troopByPositionNoCheck.BelongedFaction))
                                        {
                                            attackArchitecutreCredit /= 2;
                                        }
                                        if (attackArchitecutreCredit > num)
                                        {
                                            num = attackArchitecutreCredit;
                                            troop = troopByPositionNoCheck;
                                            architecture = null;
                                        }
                                    }
                                    else
                                    {
                                        flag2 = true;
                                    }
                                }
                            }
                        }
                        else if ((this.BelongedFaction == null) || this.BelongedFaction.IsPositionKnown(point2))
                        {
                            troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point2);
                            if (((troopByPositionNoCheck != null) && !this.IsFriendly(troopByPositionNoCheck.BelongedFaction)) && (troopByPositionNoCheck.Status != TroopStatus.埋伏))
                            {
                                flag = true;
                                attackArchitecutreCredit = this.GetAttackTroopCredit(troopByPositionNoCheck, position) - this.GetCounterStrikeDiscredit(troopByPositionNoCheck, position);
                                if ((this.SimulatingCombatMethod != null) && this.SimulatingCombatMethod.ViewingHostile)
                                {
                                    if (GameObject.Random(5 + this.ViewingHostileTroopCount) > 5)
                                    {
                                        simpleDistance = base.Scenario.GetSimpleDistance(position, this.Position);
                                        if (simpleDistance > 10)
                                        {
                                            simpleDistance = 10;
                                        }
                                        attackArchitecutreCredit += GameObject.Square(simpleDistance + this.ViewingHostileTroopCount) * 5;
                                    }
                                    else
                                    {
                                        attackArchitecutreCredit /= 2;
                                    }
                                }
                                surroundingCredit = this.GetSurroundingCredit(troopByPositionNoCheck);
                                if (surroundingCredit > 0)
                                {
                                    attackArchitecutreCredit += surroundingCredit * (100 - troopByPositionNoCheck.AvoidSurroundedChance);
                                }
                                attackArchitecutreCredit += num2;
                                if (((this.WillArchitecture != null) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction)) && (this.WillArchitecture.BelongedFaction != troopByPositionNoCheck.BelongedFaction))
                                {
                                    attackArchitecutreCredit /= 2;
                                }
                                if (attackArchitecutreCredit > num)
                                {
                                    num = attackArchitecutreCredit;
                                    troop = troopByPositionNoCheck;
                                    architecture = null;
                                }
                            }
                        }
                    }
                }
            }
            if (((num > 0) && base.Scenario.PositionIsOnFire(position)) && (((this.BelongedFaction == null) && this.ViewArea.HasPoint(position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(position))))
            {
                num -= 300;
            }
            CreditPack pack = new CreditPack();
            pack.Position = position;
            if (troop != null)
            {
                pack.Distance = base.Scenario.GetDistance(position, troop.Position);
            }
            if (architecture != null)
            {
                pack.Distance = base.Scenario.GetDistance(position, zero);
            }
            if (flag && (num > 0))
            {
                num += this.GetFoodCredit(position);
                num += this.GetLegionCredit(position);
                num += this.GetHostileRoutewayCredit(position);
                num += this.GetTerrainCredit(position);
                pack.Credit = num;
                pack.TargetTroop = troop;
                pack.TargetArchitecture = architecture;
            }
            else if (this.RationDaysLeft <= GameObject.Random(2))
            {
                pack.Credit = this.GetFoodCredit(position);
            }
            else
            {
                pack.Credit = 0;
            }
            pack.HasUnAttackableTroop = flag2;
            return pack;
        }

        public Rectangle GetCurrentDirectionAnimationRectangle(Rectangle origin)
        {
            if (this.MoveAnimationFrames.Count > this.moveFrameIndex)
            {
                this.moveStayCount++;
                if (this.moveStayCount > (GlobalVariables.FastBattleSpeed ? (GlobalVariables.TroopMoveSpeed / 2) : GlobalVariables.TroopMoveSpeed))
                {
                    this.moveStayCount = 0;
                    this.moveFrameIndex++;
                    if (this.moveFrameIndex >= this.MoveAnimationFrames.Count)
                    {
                        this.moveFrameIndex = 0;
                        this.Action = TroopAction.Stop;
                        return origin;
                    }
                }
                return new Rectangle(origin.X - this.MoveAnimationFrames[(this.MoveAnimationFrames.Count - this.moveFrameIndex) - 1].X, origin.Y - this.MoveAnimationFrames[(this.MoveAnimationFrames.Count - this.moveFrameIndex) - 1].Y, origin.Width, origin.Height);
            }
            this.moveFrameIndex = 0;
            this.Action = TroopAction.Stop;
            return origin;
        }

        public Rectangle GetCurrentDisplayRectangle(int width, bool hold)
        {
            bool flag;
            Rectangle rectangle = this.CurrentAnimation.GetCurrentDisplayRectangle(ref this.currentTroopAnimationIndex, ref this.currentTroopStayIndex, width, (int) this.Direction, out flag, hold);
            if (flag)
            {
                this.currentTroopAnimationIndex = 0;
                this.Action = TroopAction.Stop;
                this.ApplyDamageList();
                this.ApplyStratagemEffect();
            }
            return rectangle;
        }

        public Rectangle GetCurrentPreTroopActionRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.TileAnimation.GetCurrentDisplayRectangle(ref this.currentTileAnimationIndex, ref this.currentTileStayIndex, width, 0, out flag, false);
            if (flag)
            {
                this.PreAction = TroopPreAction.无;
                if (this.Action == TroopAction.Attack)
                {
                    this.AttackStarted = true;
                }
            }
            return rectangle;
        }

        public Rectangle GetCurrentStopDisplayRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.CurrentAnimation.GetCurrentDisplayRectangle(ref this.stoppedTroopAnimationIndex, ref this.stoppedTroopStayIndex, width, (int) this.Direction, out flag, false);
            if (flag)
            {
                this.stoppedTroopAnimationIndex = 0;
            }
            return rectangle;
        }

        public bool GetCurrentStratagemSuccess(Troop troop, bool inevitableSuccess, bool invincible, bool lowerIntelligenceInvincible)
        {
            int num = 0;
            bool flag = false;
            if (!this.CurrentStratagem.Friendly)
            {
                if (invincible)
                {
                    flag = false;
                }
                else if (lowerIntelligenceInvincible && (this.TroopIntelligence < troop.TroopIntelligence))
                {
                    flag = false;
                }
                else if (inevitableSuccess && (this.TroopIntelligence > troop.TroopIntelligence))
                {
                    flag = true;
                }
                else
                {
                    num = ((((this.TroopIntelligence + this.StratagemChanceIncrement) + this.Leader.Calmness) - troop.TroopIntelligence) - troop.ChanceDecrementOfStratagem) - troop.Leader.Calmness;
                    int chance = this.CurrentStratagem.Chance + num;
                    flag = GameObject.Chance(chance);
                }
            }
            else
            {
                flag = GameObject.Chance(this.TroopIntelligence + this.StratagemChanceIncrement);
            }
            if (!this.CurrentStratagem.Friendly)
            {
                if (flag)
                {
                    if (this.OrientationTroop == troop)
                    {
                        this.WaitForDeepChaos = !troop.NeverBeIntoChaos && GameObject.Chance(this.ChaosAfterStratagemSuccessChance);
                        this.WaitForDeepChaosFrameCount = 100;
                    }
                    if (this.OnStratagemSuccess != null)
                    {
                        this.OnStratagemSuccess(this, troop, this.CurrentStratagem, true);
                    }
                }
                else
                {
                    GameObjects.Animations.TileAnimation animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.抵挡, troop.Position, false);
                    if (animation != null)
                    {
                        troop.TryToPlaySound(troop.Position, animation.LinkedAnimation.SoundPath, false);
                    }
                    if (this.OnResistStratagem != null)
                    {
                        this.OnResistStratagem(this, troop, this.CurrentStratagem, true);
                    }
                }
            }
            else if (flag)
            {
                if (((troop != null) && (this.OnStratagemSuccess != null)) && (this != troop))
                {
                    this.OnStratagemSuccess(this, troop, this.CurrentStratagem, false);
                }
            }
            else if ((troop != null) && (this.OnResistStratagem != null))
            {
                this.OnResistStratagem(this, troop, this.CurrentStratagem, false);
            }
            int increment = (2 + (flag ? 1 : 0)) + (this.WaitForDeepChaos ? 2 : 0);
            this.IncreaseStratagemExperience(increment, true);
            if (troop != null)
            {
                troop.IncreaseStratagemExperience(increment, false);
            }
            if (this.BelongedFaction != null)
            {
                if (flag)
                {
                    if (this.BelongedFaction.RateOfCombativityRecoveryAfterStratagemSuccess > 0f)
                    {
                        this.IncreaseCombativity(StaticMethods.GetRandomValue((int) ((this.Leader.Calmness * 100) * this.BelongedFaction.RateOfCombativityRecoveryAfterStratagemSuccess), 100));
                    }
                    return flag;
                }
                if (this.BelongedFaction.RateOfCombativityRecoveryAfterStratagemFail > 0f)
                {
                    this.IncreaseCombativity(StaticMethods.GetRandomValue((int) ((this.Leader.Calmness * 100) * this.BelongedFaction.RateOfCombativityRecoveryAfterStratagemFail), 100));
                }
            }
            return flag;
        }

        public Rectangle GetCurrentTroopTileAnimationRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.TileAnimation.GetCurrentDisplayRectangle(ref this.currentTileAnimationIndex, ref this.currentTileStayIndex, width, 0, out flag, false);
            if (flag)
            {
                this.currentTileAnimationIndex = 0;
            }
            return rectangle;
        }

        public GameArea GetDayArea(int Days)
        {
            return this.pathFinder.GetDayArea(Days);
        }

        public static int GetDistance(Point start, Point end)
        {
            return (Math.Abs((int) (end.X - start.X)) + Math.Abs((int) (end.Y - start.Y)));
        }

        public Rectangle GetEffectTroopTileAnimationRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.EffectTileAnimation.GetCurrentDisplayRectangle(ref this.effectTileAnimationIndex, ref this.effectTileStayIndex, width, 0, out flag, false);
            if (flag)
            {
                this.effectTileAnimationIndex = 0;
            }
            return rectangle;
        }

        public Point GetFirstTierDestinationFromSecondTier()
        {
            if (!LaunchSecondPathFinder(this.Position, this.Destination))
            {
                return this.Destination;
            }
            return this.GetCentrePointInSecondTierPosition(this.GetSecondTierDestination());
        }

        private int GetFoodCredit(Point position)
        {
            bool flag;
            if (this.BelongedFaction == null)
            {
                return 0;
            }
            if (((this.ViewingWillArchitecture && (this.WillArchitecture != null)) && ((this.WillArchitecture.BelongedFaction == this.BelongedFaction) && (this.WillArchitecture.RecentlyAttacked <= 0))) && GameObject.Chance(0x21))
            {
                return 0;
            }
            int num = 0;
            if ((this.RationDaysLeft <= 3) && ((this.RationDaysLeft != 3) || !GameObject.Chance(50)))
            {
                TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(position);
                if (terrainDetailByPosition == null)
                {
                    goto Label_0426;
                }
                if (((this.RationDaysLeft <= 1) && !base.Scenario.NoFoodDictionary.HasPosition(position)) && (base.Scenario.GetArchitectureByPosition(position) == null))
                {
                    num += terrainDetailByPosition.GetFood(base.Scenario.Date.Season) / 0x1388;
                }
                flag = false;
                foreach (Architecture architecture in base.Scenario.GetSupplyArchitecturesByPositionAndFaction(position, this.BelongedFaction))
                {
                    if (architecture.Food >= this.FoodCostPerDay)
                    {
                        num += 0x1f;
                        this.HasSupply = true;
                        flag = true;
                        break;
                    }
                }
            }
            else
            {
                flag = false;
                foreach (Architecture architecture in base.Scenario.GetSupplyArchitecturesByPositionAndFaction(position, this.BelongedFaction))
                {
                    if (architecture.Food >= this.FoodCostPerDay)
                    {
                        num += 0x11;
                        flag = true;
                        this.HasSupply = true;
                        break;
                    }
                }
                if (!flag)
                {
                    if ((this.BelongedLegion.PreferredRouteway != null) && this.BelongedLegion.PreferredRouteway.IsEnough(position, this.FoodCostPerDay))
                    {
                        num += 0x17;
                        this.HasSupply = true;
                    }
                    else
                    {
                        foreach (RoutePoint point in base.Scenario.GetSupplyRoutePointsByPositionAndFaction(position, this.BelongedFaction))
                        {
                            if (point.BelongedRouteway.IsEnough(point.ConsumptionRate, this.FoodCostPerDay))
                            {
                                num += 11;
                                this.HasSupply = true;
                                break;
                            }
                        }
                    }
                }
                if (!this.ViewingWillArchitecture)
                {
                    if (this.CurrentPath == null)
                    {
                        num = (num + base.Scenario.GetSimpleDistance(this.Position, position)) + ((int) ((this.DistanceToWillArchitecture - base.Scenario.GetDistance(position, this.WillArchitecture.ArchitectureArea)) * 1.0));
                    }
                    else
                    {
                        num += (this.GetPositionIndexInCurrentPath(position) * 0x13) + ((int) (this.DistanceToWillArchitecture - base.Scenario.GetDistance(position, this.WillArchitecture.ArchitectureArea)));
                    }
                }
                goto Label_0505;
            }
            if (!flag)
            {
                if ((this.BelongedLegion.PreferredRouteway != null) && this.BelongedLegion.PreferredRouteway.IsEnough(position, this.FoodCostPerDay))
                {
                    num += 0x29;
                    this.HasSupply = true;
                }
                else
                {
                    foreach (RoutePoint point in base.Scenario.GetSupplyRoutePointsByPositionAndFaction(position, this.BelongedFaction))
                    {
                        if (point.BelongedRouteway.IsEnough(point.ConsumptionRate, this.FoodCostPerDay))
                        {
                            num += 20;
                            this.HasSupply = true;
                            break;
                        }
                    }
                }
            }
        Label_0426:
            if (!this.ViewingWillArchitecture)
            {
                if (this.CurrentPath == null)
                {
                    num = ((((num * GameObject.Square(4 - this.RationDaysLeft)) + base.Scenario.GetSimpleDistance(this.Position, position)) + ((int) ((this.DistanceToWillArchitecture - base.Scenario.GetDistance(position, this.WillArchitecture.ArchitectureArea)) * 1.0))) + this.Army.MoraleCeiling) - this.Army.Morale;
                }
                else
                {
                    num += ((((this.GetPositionIndexInCurrentPath(position) * GameObject.Square(4 - this.RationDaysLeft)) * 0x13) + ((int) (this.DistanceToWillArchitecture - base.Scenario.GetDistance(position, this.WillArchitecture.ArchitectureArea)))) + this.Army.MoraleCeiling) - this.Army.Morale;
                }
            }
        Label_0505:
            return GameObject.Random(num * 2);
        }

        public TroopList GetFriendlyTroopsInView()
        {
            TroopList list = new TroopList();
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (((troopByPosition != null) && (troopByPosition != this)) && this.IsFriendly(troopByPosition.BelongedFaction))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        public GameArea GetHighestFightingForceArea(GameArea sourceArea)
        {
            if (sourceArea == null)
            {
                return null;
            }
            int num = -2147483648;
            GameArea area = new GameArea();
            foreach (Point point in sourceArea.Area)
            {
                int fightingForce = CreateSimulateTroop(this.Persons, this.Army, point).FightingForce;
                if (fightingForce > num)
                {
                    num = fightingForce;
                    area.Area.Clear();
                    area.AddPoint(point);
                }
                else if (fightingForce == num)
                {
                    area.AddPoint(point);
                }
            }
            return area;
        }

        private int GetHostileRoutewayCredit(Point position)
        {
            if (this.BelongedFaction == null)
            {
                return 0;
            }
            int num = 0;
            if ((this.BelongedFaction.GetKnownAreaData(position) >= GlobalVariables.ScoutRoutewayInformationLevel) && (this.BelongedLegion.HasCuttingRoutewayTroop || GameObject.Chance(10)))
            {
                foreach (Routeway routeway in base.Scenario.GetActiveRoutewayListByPosition(position))
                {
                    if (!this.IsFriendly(routeway.BelongedFaction))
                    {
                        num += 10;
                    }
                }
            }
            return num;
        }

        public TroopList GetHostileTroopsInView()
        {
            TroopList list = new TroopList();
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if (!((troopByPosition == null) || this.IsFriendly(troopByPosition.BelongedFaction)))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        private int GetLegionCredit(Point position)
        {
            if (this.BelongedLegion != null)
            {
                if (this.BelongedLegion.CoreTroop == this)
                {
                    return 0;
                }
                if (base.Scenario.IsTroopViewingPosition(this.BelongedLegion.CoreTroop, position) && (this.BelongedLegion.WillArchitecture.IsViewing(position) || GameObject.Chance(10)))
                {
                    return 10;
                }
            }
            return 0;
        }

        private int GetMapCost(Point position)
        {
            if (this.BelongedFaction != null)
            {
                return this.BelongedFaction.GetMapCost(this, position);
            }
            if (base.Scenario.PositionOutOfRange(position))
            {
                return 0xdac;
            }
            return ((this.GetTerrainAdaptability((TerrainKind) base.Scenario.ScenarioMap.MapData[position.X, position.Y]) + base.Scenario.GetWaterPositionMapCost(this.Army.Kind.Type, position)) + base.Scenario.GetPositionMapCost(null, position));
        }

        private Architecture GetMovableBaseViewSelfArchitecture()
        {
            foreach (Point point in this.BaseViewArea.Area)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(point);
                if (((architectureByPosition != null) && (architectureByPosition.BelongedFaction == this.BelongedFaction)) && this.IsAccessable(base.Scenario.GetClosestPoint(architectureByPosition.ArchitectureArea, this.Position)))
                {
                    return architectureByPosition;
                }
            }
            return null;
        }

        private CreditPack GetMoveCreditByPosition(Point p)
        {
            List<RoutePoint> supplyRoutePointsByPositionAndFaction = base.Scenario.GetSupplyRoutePointsByPositionAndFaction(p, this.BelongedFaction);
            CreditPack pack = new CreditPack();
            pack.Position = p;
            pack.Credit += this.GetFoodCredit(p);
            pack.Credit += this.GetHostileRoutewayCredit(p);
            pack.Credit += this.GetTerrainCredit(p);
            if (pack.Position == this.Position)
            {
                pack.Credit /= 2;
            }
            double distance = base.Scenario.GetDistance(p, this.WillArchitecture.ArchitectureArea);
            TerrainKind terrainKindByPosition = base.Scenario.GetTerrainKindByPosition(p);
            if (this.BelongedLegion.Troops.Count > 1)
            {
                if (this != this.BelongedLegion.CoreTroop)
                {
                    if ((((this.Army.Kind.Type == MilitaryType.水军) && (terrainKindByPosition == TerrainKind.水域)) || ((this.Army.Kind.Type != MilitaryType.水军) && (terrainKindByPosition != TerrainKind.水域))) && ((((supplyRoutePointsByPositionAndFaction.Count > 0) && (this.Position == p)) && (this.BelongedLegion.GetWillClosestTroop() == this)) && GameObject.Chance((20 + this.Leader.Calmness) - this.Leader.Braveness)))
                    {
                        pack.Credit += 0x2710;
                        return pack;
                    }
                    if ((distance <= this.DistanceToWillArchitecture) && this.BelongedLegion.CoreTroop.ViewArea.HasPoint(p))
                    {
                        pack.Credit += 1 + ((int) ((this.DistanceToWillArchitecture - distance) * 100.0));
                    }
                }
                else if (((this.Position == p) && (((this.Army.Kind.Type == MilitaryType.水军) && (terrainKindByPosition == TerrainKind.水域)) || ((this.Army.Kind.Type != MilitaryType.水军) && (terrainKindByPosition != TerrainKind.水域)))) && (((supplyRoutePointsByPositionAndFaction.Count > 0) && (this.BelongedLegion.GetWillClosestTroop() == this)) && GameObject.Chance((50 + this.Leader.Calmness) - this.Leader.Braveness)))
                {
                    pack.Credit += 0x2710;
                    return pack;
                }
            }
            if (this.BelongedLegion.PreferredRouteway != null)
            {
                if (distance >= this.DistanceToWillArchitecture)
                {
                    return pack;
                }
                if (GameObject.Random(this.RationDaysLeft) > 0)
                {
                    return pack;
                }
                if ((GameObject.Random(this.RationDaysLeft) == 0) && (((this.Army.Kind.Type == MilitaryType.水军) && (terrainKindByPosition == TerrainKind.水域)) || ((this.Army.Kind.Type != MilitaryType.水军) && (terrainKindByPosition != TerrainKind.水域))))
                {
                    foreach (RoutePoint point in supplyRoutePointsByPositionAndFaction)
                    {
                        if ((point.BelongedRouteway == this.BelongedLegion.PreferredRouteway) && (point.BelongedRouteway.DestinationArchitecture == this.WillArchitecture))
                        {
                            double num2 = base.Scenario.GetDistance(point.Position, this.WillArchitecture.ArchitectureArea);
                            if (num2 >= this.DistanceToWillArchitecture)
                            {
                                continue;
                            }
                            if (this.WillArchitecture.BelongedFaction != this.BelongedFaction)
                            {
                                pack.Credit += point.Index + ((int) ((this.DistanceToWillArchitecture - num2) * 100.0));
                            }
                            else
                            {
                                pack.Credit += -point.Index + ((int) ((this.DistanceToWillArchitecture - num2) * 100.0));
                            }
                            return pack;
                        }
                    }
                }
            }
            return pack;
        }

        public GameArea GetOffenceArea(Point position)
        {
            GameArea area = GameArea.GetViewArea(position, this.OffenceRadius, this.ObliqueOffence, base.Scenario, null);
            if (!this.ContactOffence)
            {
                foreach (Point point in this.GetContactArea(position).Area)
                {
                    area.Area.Remove(point);
                }
                return area;
            }
            area.Area.Remove(this.Position);
            return area;
        }

        private bool GetPath()
        {
            bool flag = this.BuildThreeTierPath();
            if (!this.HasPath)
            {
                return flag;
            }
            return this.CheckReLaunchPathFinder();
        }

        public int GetPopulation()
        {
            int totalQuantity = this.TotalQuantity;
            if (totalQuantity > 0)
            {
                return (GameObject.Random(totalQuantity) + 1);
            }
            return 0;
        }

        private int GetPositionIndexInCurrentPath(Point p)
        {
            if (this.CurrentPath != null)
            {
                for (int i = 0; i < this.CurrentPath.Count; i++)
                {
                    if (this.CurrentPath[i] == p)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        public int GetPossibleMoveByPosition(Point position)
        {
            if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(position)))
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(position);
                if ((troopByPosition != null) && !troopByPosition.IsFriendly(this.BelongedFaction))
                {
                    return 0xdac;
                }
            }
            int mapCost = this.GetMapCost(position);
            if (this.Movability >= (mapCost * 5))
            {
                return mapCost;
            }
            return 0xdac;
        }

        private int GetPureAttackCredit(Troop troop)
        {
            int num = 0;
            if (troop.Defence == 0)
            {
                return 0x7fffffff;
            }
            int num2 = this.CriticalStrikeChance - troop.AntiCriticalStrikeChance;
            int defence = troop.Defence;
            if ((this.BaseDefenceConsidered > 0) && (this.DefenceConsidered > 0))
            {
                int num4 = (this.BaseDefenceConsidered < this.DefenceConsidered) ? this.BaseDefenceConsidered : this.DefenceConsidered;
                if (defence > num4)
                {
                    defence = num4;
                }
            }
            else if (this.BaseDefenceConsidered > 0)
            {
                if (defence > this.BaseDefenceConsidered)
                {
                    defence = this.BaseDefenceConsidered;
                }
            }
            else if ((this.DefenceConsidered > 0) && (defence > this.DefenceConsidered))
            {
                defence = this.DefenceConsidered;
            }
            if (num2 > 0)
            {
                num = (this.Offence * ((100 + num2) + ((int) ((this.ChaosAfterCriticalStrikeChance * num2) / 100f)))) / defence;
            }
            else
            {
                num = (this.Offence * 100) / defence;
            }
            if (((this.ChanceOfOnFire > 0) || (this.BaseChanceOfOnFire > 0)) && (num > 0))
            {
                int num5 = (this.ChanceOfOnFire > this.BaseChanceOfOnFire) ? this.ChanceOfOnFire : this.BaseChanceOfOnFire;
                num = (num * (100 + num5)) / 100;
            }
            switch (troop.Army.Kind.Type)
            {
                case MilitaryType.步兵:
                    num = (int) (num * this.OffenceRateOnSubdueBubing);
                    break;

                case MilitaryType.弩兵:
                    num = (int) (num * this.OffenceRateOnSubdueNubing);
                    break;

                case MilitaryType.骑兵:
                    num = (int) ((num * this.OffenceRateOnSubdueQibing) * ((this.RateOfQibingDamage > this.BaseRateOfQibingDamage) ? this.RateOfQibingDamage : this.BaseRateOfQibingDamage));
                    break;

                case MilitaryType.水军:
                    num = (int) (num * this.OffenceRateOnSubdueShuijun);
                    break;

                case MilitaryType.器械:
                    num = (int) (num * this.OffenceRateOnSubdueQixie);
                    break;
            }
            if (troop.Army.Scales < 4)
            {
                num += (4 - troop.Army.Scales) * 60;
            }
            if (troop.Quantity < 0x7d0)
            {
                num += (0x7d0 - troop.Quantity) / 8;
            }
            if (!troop.HasCombatTitle)
            {
                if (this.MoraleDecrementOnPrestige > 0)
                {
                    num += 200;
                }
                if ((this.CombativityDecrementOnPower > 0) && (troop.Combativity >= (this.CombativityDecrementOnPower / 2)))
                {
                    num += 100;
                }
            }
            if ((this.AttackDecrementOfCombativity > 0) && (troop.Combativity >= (this.AttackDecrementOfCombativity / 2)))
            {
                num += this.AttackDecrementOfCombativity * 3;
            }
            if (this.SimulatingCombatMethod != null)
            {
                if ((this.Army.Scales > 4) && (troop.Army.Scales <= 4))
                {
                    num /= 2;
                }
                if (GameObject.Random(this.Offence + this.Defence) > (troop.Offence + troop.defence))
                {
                    num /= 2;
                }
            }
            return num;
        }

        private Point? GetRoutewayNormalOrientation(Routeway routeway, Architecture des)
        {
            GameArea area = new GameArea();
            foreach (Point point in des.ContactArea.Area)
            {
                TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                if (((terrainDetailByPosition != null) && (terrainDetailByPosition.ID != 6)) && (terrainDetailByPosition.RoutewayBuildWorkCost <= this.BelongedFaction.RoutewayWorkForce))
                {
                    if (routeway.GetPoint(point) != null)
                    {
                        continue;
                    }
                    area.AddPoint(point);
                }
            }
            if (area.Count > 0)
            {
                return new Point?(base.Scenario.GetClosestPoint(area, this.Position));
            }
            return null;
        }

        private Point? GetRoutewayWaterOrientation(Routeway routeway, Architecture des)
        {
            GameArea area = new GameArea();
            foreach (Point point in des.ContactArea.Area)
            {
                TerrainDetail terrainDetailByPosition = base.Scenario.GetTerrainDetailByPosition(point);
                if ((terrainDetailByPosition != null) && (terrainDetailByPosition.ID == 6))
                {
                    if (routeway.GetPoint(point) != null)
                    {
                        continue;
                    }
                    area.AddPoint(point);
                }
            }
            if (area.Count > 0)
            {
                return new Point?(base.Scenario.GetClosestPoint(area, this.Position));
            }
            return null;
        }

        public static Point GetSecondTierCoordinate(Point position)
        {
            return new Point(position.X / GameObjectConsts.SecondTierSquareSize, position.Y / GameObjectConsts.SecondTierSquareSize);
        }

        protected Point GetSecondTierDestination()
        {
            if ((this.secondTierPathDestinationIndex + GameObjectConsts.LaunchTierFinderDistance) < this.SecondTierPath.Count)
            {
                this.secondTierPathDestinationIndex += GameObjectConsts.LaunchTierFinderDistance;
                return this.SecondTierPath[this.secondTierPathDestinationIndex];
            }
            this.secondTierPathDestinationIndex = this.SecondTierPath.Count - 1;
            return this.SecondTierPath[this.secondTierPathDestinationIndex];
        }

        public Point GetSecondTierDestinationFromThirdTier()
        {
            if (!LaunchThirdPathFinder(this.Position, this.Destination))
            {
                return this.Destination;
            }
            return this.GetCentrePointInThirdTierPosition(this.GetThirdTierDestination());
        }

        private CreditPack GetSelfStratagemCredit(Stratagem stratagem)
        {
            int creditWithPosition = 0;
            Point? position = null;
            if (stratagem.IsValid(this))
            {
                creditWithPosition = stratagem.GetCreditWithPosition(this, out position);
            }
            if (((creditWithPosition > 0) && base.Scenario.PositionIsOnFire(this.Position)) && (((this.BelongedFaction == null) && this.ViewArea.HasPoint(this.Position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(this.Position))))
            {
                creditWithPosition -= 300;
            }
            CreditPack pack = new CreditPack();
            if (creditWithPosition > 0)
            {
                creditWithPosition += this.GetFoodCredit(this.Position);
                creditWithPosition += this.GetLegionCredit(this.Position);
                creditWithPosition += this.GetHostileRoutewayCredit(this.position);
                creditWithPosition += this.GetTerrainCredit(this.position);
                int positionHostileOffencingDiscredit = 0;
                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.Position);
                if ((architectureByPositionNoCheck == null) || (architectureByPositionNoCheck.Endurance == 0))
                {
                    positionHostileOffencingDiscredit = base.Scenario.GetPositionHostileOffencingDiscredit(this, this.Position);
                }
                pack.Credit = creditWithPosition - positionHostileOffencingDiscredit;
                if (position.HasValue)
                {
                    pack.SelfCastPosition = position.Value;
                }
                pack.CurrentStratagem = stratagem;
            }
            else
            {
                pack.Credit = 0;
            }
            pack.Position = this.Position;
            return pack;
        }

        public GameArea GetSetFireArea()
        {
            GameArea area = new GameArea();
            foreach (Point point in this.StratagemArea.Area)
            {
                if (base.Scenario.IsPositionEmpty(point) && base.Scenario.IsFireVaild(point, false, MilitaryType.步兵))
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

        public Rectangle GetStatusTroopTileAnimationRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.StatusTileAnimation.GetCurrentDisplayRectangle(ref this.statusTileAnimationIndex, ref this.statusTileStayIndex, width, 0, out flag, false);
            if (flag)
            {
                this.statusTileAnimationIndex = 0;
            }
            return rectangle;
        }

        public GameArea GetStratagemArea(Point position)
        {
            return GameArea.GetViewArea(position, this.StratagemRadius, this.ObliqueStratagem, base.Scenario, null);
        }

        private CreditPack GetStratagemCreditByPosition(Stratagem stratagem, Point position)
        {
            int num = -2147483648;
            Troop troop = null;
            foreach (Point point in this.GetStratagemArea(position).Area)
            {
                if ((this.BelongedFaction == null) || this.BelongedFaction.IsPositionKnown(point))
                {
                    int num2 = base.Scenario.GetSimpleDistance(position, point) * 5;
                    Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point);
                    if ((troopByPositionNoCheck != null) && (stratagem.Friendly == this.IsFriendly(troopByPositionNoCheck.BelongedFaction)))
                    {
                        if (!(stratagem.Friendly || (troopByPositionNoCheck.Status != TroopStatus.埋伏)))
                        {
                            continue;
                        }
                        int credit = stratagem.GetCredit(this, troopByPositionNoCheck);
                        if (!stratagem.Friendly && (((this.WillArchitecture != null) && (this.WillArchitecture.BelongedFaction != this.BelongedFaction)) && (this.WillArchitecture.BelongedFaction != troopByPositionNoCheck.BelongedFaction)))
                        {
                            credit /= 2;
                        }
                        if (((troopByPositionNoCheck != this) && (this.Army.Scales > 4)) && (troopByPositionNoCheck.Army.Scales <= 4))
                        {
                            credit /= 2;
                        }
                        if (credit > 0)
                        {
                            credit += num2;
                            if (credit > num)
                            {
                                num = credit;
                                troop = troopByPositionNoCheck;
                            }
                        }
                    }
                }
            }
            if (stratagem.Friendly && (position != this.Position))
            {
                int num4 = stratagem.GetCredit(this, this);
                if (num4 > 0)
                {
                    num4 += base.Scenario.GetSimpleDistance(this.Position, position) * 5;
                    if (num4 > num)
                    {
                        num = num4;
                        troop = this;
                    }
                }
            }
            CreditPack pack = new CreditPack();
            pack.Position = position;
            if (troop != null)
            {
                pack.Distance = base.Scenario.GetDistance(position, troop.Position);
            }
            if (((num > 0) && base.Scenario.PositionIsOnFire(position)) && (((this.BelongedFaction == null) && this.ViewArea.HasPoint(position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(position))))
            {
                num -= 300;
            }
            if (num > 0)
            {
                num += this.GetFoodCredit(position);
                num += this.GetLegionCredit(position);
                num += this.GetHostileRoutewayCredit(position);
                num += this.GetTerrainCredit(position);
                int positionHostileOffencingDiscredit = 0;
                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(position);
                if ((architectureByPositionNoCheck != null) && (architectureByPositionNoCheck.Endurance > 0))
                {
                    if (!stratagem.Friendly)
                    {
                        num *= 4;
                    }
                }
                else
                {
                    positionHostileOffencingDiscredit = base.Scenario.GetPositionHostileOffencingDiscredit(this, position);
                }
                if (position != this.Position)
                {
                    float terranRateByPosition = this.GetTerranRateByPosition(position);
                    num = (int) ((num * Math.Pow((double) terranRateByPosition, 2.0)) - (((double) positionHostileOffencingDiscredit) / Math.Pow((double) terranRateByPosition, 2.0)));
                }
                else
                {
                    num -= positionHostileOffencingDiscredit;
                }
                pack.Credit = num;
                pack.CurrentStratagem = stratagem;
            }
            else
            {
                pack.Credit = 0;
            }
            pack.TargetTroop = troop;
            return pack;
        }

        public string GetStratagemDisplayName(int id)
        {
            Stratagem stratagem = this.Stratagems.GetStratagem(id);
            if (stratagem != null)
            {
                int num = stratagem.Combativity - this.DecrementOfStratagemCombativityConsuming;
                return (stratagem.Name + "(" + num.ToString() + ")");
            }
            return "----";
        }

        public int GetStratagemSuccessChanceCredit(Troop troop, bool inevitableSuccess, bool invincible, bool lowerIntelligenceInvincible)
        {
            int num = 0;
            int num2 = 0;
            if (!this.CurrentStratagem.Friendly)
            {
                if (invincible)
                {
                    num2 = 0;
                }
                else if (lowerIntelligenceInvincible && (this.TroopIntelligence < troop.TroopIntelligence))
                {
                    num2 = 0;
                }
                else if (inevitableSuccess && (this.TroopIntelligence > troop.TroopIntelligence))
                {
                    num2 = 100;
                }
                else
                {
                    num = ((((this.TroopIntelligence + this.StratagemChanceIncrement) + this.Leader.Calmness) - troop.TroopIntelligence) - troop.ChanceDecrementOfStratagem) - troop.Leader.Calmness;
                    num2 = this.CurrentStratagem.Chance + num;
                }
            }
            else
            {
                num2 = this.TroopIntelligence + this.StratagemChanceIncrement;
            }
            if (num2 < 0)
            {
                num2 = 0;
            }
            else if (num2 > 100)
            {
                num2 = 100;
            }
            if (num2 >= 12)
            {
                num2 = GameObject.Square(num2) / 60;
            }
            else
            {
                num2 = 0;
            }
            if (!((num2 <= 0) || this.CurrentStratagem.Friendly))
            {
                num2 += (this.ChaosAfterStratagemSuccessChance * num2) / 100;
            }
            return num2;
        }

        public string GetStuntDisplayName(int id)
        {
            Stunt stunt = this.Stunts.GetStunt(id);
            if (stunt != null)
            {
                return (stunt.Name + "(" + stunt.Combativity.ToString() + ")");
            }
            return "----";
        }

        public Rectangle GetStuntTroopTileAnimationRectangle(int width)
        {
            bool flag;
            Rectangle rectangle = this.StuntTileAnimation.GetCurrentDisplayRectangle(ref this.stuntTileAnimationIndex, ref this.stuntTileStayIndex, width, 0, out flag, false);
            if (flag)
            {
                this.stuntTileAnimationIndex = 0;
            }
            return rectangle;
        }

        public TroopList GetSurroundAttackingTroop(Troop troop)
        {
            TroopList list = new TroopList();
            foreach (Point point in GameArea.GetArea(troop.Position, 1, true).Area)
            {
                if (point == troop.Position)
                {
                    continue;
                }
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && ((troopByPosition == this) || ((this.IsFriendly(troopByPosition.BelongedFaction) && troopByPosition.SurroundAvail()) && troopByPosition.CanAttack(troop))))
                {
                    list.Add(troopByPosition);
                }
            }
            return list;
        }

        public int GetSurroundingCredit(Troop troop)
        {
            return ((this.GetSurroundAttackingTroop(troop).Count - 3) + 1);
        }

        public GameArea GetTargetArea(bool friendly, bool architectureTarget)
        {
            GameArea area = new GameArea();
            foreach (Troop troop in base.Scenario.Troops)
            {
                if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(troop.Position)) || (((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(troop.Position)) && (this.IsFriendly(troop.BelongedFaction) == friendly)))
                {
                    area.AddPoint(troop.Position);
                }
            }
            if (architectureTarget)
            {
                foreach (Architecture architecture in base.Scenario.Architectures)
                {
                    if (this.IsFriendly(architecture.BelongedFaction) == friendly)
                    {
                        foreach (Point point in architecture.ArchitectureArea.Area)
                        {
                            area.AddPoint(point);
                        }
                    }
                }
            }
            return area;
        }

        public int GetTerrainAdaptability(TerrainKind terrain)
        {
            switch (terrain)
            {
                case TerrainKind.无:
                    return 0xdac;

                case TerrainKind.平原:
                    return this.PlainAdaptability;

                case TerrainKind.草原:
                    return this.GrasslandAdaptability;

                case TerrainKind.森林:
                    return this.ForrestAdaptability;

                case TerrainKind.湿地:
                    return this.MarshAdaptability;

                case TerrainKind.山地:
                    return this.MountainAdaptability;

                case TerrainKind.水域:
                    return this.WaterAdaptability;

                case TerrainKind.峻岭:
                    return this.RidgeAdaptability;

                case TerrainKind.荒地:
                    return this.WastelandAdaptability;

                case TerrainKind.沙漠:
                    return this.DesertAdaptability;

                case TerrainKind.栈道:
                    return this.CliffAdaptability;
            }
            return 0xdac;
        }

        private int GetTerrainCredit(Point position)
        {
            if (this.BelongedFaction != null)
            {
                int positionIndexInCurrentPath = this.GetPositionIndexInCurrentPath(position);
                if (positionIndexInCurrentPath > 0)
                {
                    float terranRateByPosition = this.GetTerranRateByPosition(position);
                    if (!(!this.ViewingWillArchitecture || GameObject.Chance(10)))
                    {
                        return (int) ((terranRateByPosition - this.CurrentRate) * 10f);
                    }
                    return ((positionIndexInCurrentPath * 0x1d) + ((int) ((terranRateByPosition - this.CurrentRate) * 10f)));
                }
            }
            return 0;
        }

        private float GetTerranRateByPosition(Point position)
        {
            switch (base.Scenario.GetTerrainKindByPosition(position))
            {
                case TerrainKind.平原:
                    return this.PlainRate;

                case TerrainKind.草原:
                    return this.GrasslandRate;

                case TerrainKind.森林:
                    return this.ForrestRate;

                case TerrainKind.湿地:
                    return this.MarshRate;

                case TerrainKind.山地:
                    return this.MountainRate;

                case TerrainKind.水域:
                    return this.WaterRate;

                case TerrainKind.峻岭:
                    return this.RidgeRate;

                case TerrainKind.荒地:
                    return this.WastelandRate;

                case TerrainKind.沙漠:
                    return this.DesertRate;

                case TerrainKind.栈道:
                    return this.CliffRate;
            }
            return 1f;
        }

        public static Point GetThirdTierCoordinate(Point position)
        {
            return new Point(position.X / GameObjectConsts.ThirdTierSquareSize, position.Y / GameObjectConsts.ThirdTierSquareSize);
        }

        protected Point GetThirdTierDestination()
        {
            if ((this.thirdTierPathDestinationIndex + GameObjectConsts.LaunchTierFinderDistance) < this.ThirdTierPath.Count)
            {
                this.thirdTierPathDestinationIndex += GameObjectConsts.LaunchTierFinderDistance;
                return this.ThirdTierPath[this.thirdTierPathDestinationIndex];
            }
            this.thirdTierPathDestinationIndex = this.ThirdTierPath.Count - 1;
            return this.ThirdTierPath[this.thirdTierPathDestinationIndex];
        }

        public TreasureList GetTreasureList()
        {
            TreasureList list = new TreasureList();
            foreach (Person person in this.Persons)
            {
                if (person.TreasureCount > 0)
                {
                    person.AddTreasureToList(list);
                }
            }
            return list;
        }

        private TroopList GetTroopsBetween(Troop troop)
        {
            return this.GetTroopsBetween(this.Position, troop.Position);
        }

        private TroopList GetTroopsBetween(Point from, Point to)
        {
            TroopList list = new TroopList();
            int num = to.X - from.X;
            int num2 = to.Y - from.Y;
            if ((Math.Abs(num) > 1) || (Math.Abs(num2) > 1))
            {
                int num3;
                Troop troopByPosition;
                if (num == 0)
                {
                    if (num2 > 0)
                    {
                        for (num3 = 1; num3 < num2; num3++)
                        {
                            troopByPosition = base.Scenario.GetTroopByPosition(new Point(from.X, from.Y + num3));
                            if (troopByPosition != null)
                            {
                                list.Add(troopByPosition);
                            }
                        }
                        return list;
                    }
                    num3 = -1;
                    while (num3 > num2)
                    {
                        troopByPosition = base.Scenario.GetTroopByPosition(new Point(from.X, from.Y + num3));
                        if (troopByPosition != null)
                        {
                            list.Add(troopByPosition);
                        }
                        num3--;
                    }
                    return list;
                }
                if (num > 0)
                {
                    for (num3 = 1; num3 < num; num3++)
                    {
                        troopByPosition = base.Scenario.GetTroopByPosition(new Point(from.X + num3, from.Y + ((int) Math.Round((double) ((num3 * num2) / ((double) num))))));
                        if (troopByPosition != null)
                        {
                            list.Add(troopByPosition);
                        }
                    }
                    return list;
                }
                for (num3 = -1; num3 > num; num3--)
                {
                    troopByPosition = base.Scenario.GetTroopByPosition(new Point(from.X + num3, from.Y + ((int) Math.Round((double) ((num3 * num2) / ((double) num))))));
                    if (troopByPosition != null)
                    {
                        list.Add(troopByPosition);
                    }
                }
            }
            return list;
        }

        private Texture2D GetTroopTexture()
        {
            switch (this.Action)
            {
                case TroopAction.Stop:
                    return this.Army.Kind.Textures.MoveTexture;

                case TroopAction.Move:
                    return this.Army.Kind.Textures.MoveTexture;

                case TroopAction.Attack:
                    return this.Army.Kind.Textures.AttackTexture;

                case TroopAction.BeAttacked:
                    return this.Army.Kind.Textures.BeAttackedTexture;

                case TroopAction.Cast:
                    return this.Army.Kind.Textures.CastTexture;

                case TroopAction.BeCasted:
                    return this.Army.Kind.Textures.BeCastedTexture;
            }
            throw new Exception("Invalid Action.");
        }

        private void GoBack()
        {
            if ((this.BelongedFaction != null) && (this.StartingArchitecture != null))
            {
                Architecture currentArchitecture = this.CurrentArchitecture;
                if (((currentArchitecture != null) && (currentArchitecture.BelongedFaction == this.BelongedFaction)) && ((currentArchitecture.Endurance >= (currentArchitecture.EnduranceCeiling * 0.2f)) || (!this.HasHostileTroopInView() && !currentArchitecture.HasHostileTroopsInView())))
                {
                    if (this.CanEnter())
                    {
                        this.Enter();
                    }
                }
                else
                {
                    CreditPack selfStratagemCredit;
                    Architecture movableBaseViewSelfArchitecture = this.GetMovableBaseViewSelfArchitecture();
                    if (movableBaseViewSelfArchitecture != null)
                    {
                        this.WillArchitecture = movableBaseViewSelfArchitecture;
                    }
                    else if (this.StartingArchitecture.BelongedFaction == this.BelongedFaction)
                    {
                        this.WillArchitecture = this.StartingArchitecture;
                    }
                    else if (this.BelongedLegion != null)
                    {
                        Architecture legionTroopFactionStartArchitecture = this.BelongedLegion.GetLegionTroopFactionStartArchitecture();
                        if (legionTroopFactionStartArchitecture != null)
                        {
                            this.WillArchitecture = legionTroopFactionStartArchitecture;
                        }
                        else
                        {
                            this.WillArchitecture = this.BelongedFaction.Capital;
                        }
                    }
                    else
                    {
                        this.WillArchitecture = this.BelongedFaction.Capital;
                    }
                    int credit = 0;
                    CreditPack pack = null;
                    GameArea dayArea = this.GetDayArea(1);
                    if ((((this.Morale < 0x4b) && !this.ViewingWillArchitecture) && !this.HasHostileTroopInView()) && !this.HasHostileArchitectureInView())
                    {
                        foreach (Point point in dayArea.Area)
                        {
                            selfStratagemCredit = new CreditPack();
                            selfStratagemCredit.Position = point;
                            selfStratagemCredit.Credit = this.GetFoodCredit(point);
                            selfStratagemCredit.Credit += this.GetTerrainCredit(point);
                            if (selfStratagemCredit.Credit > credit)
                            {
                                credit = selfStratagemCredit.Credit;
                                pack = selfStratagemCredit;
                            }
                        }
                    }
                    bool flag = false;
                    foreach (Stratagem stratagem in this.Stratagems.Stratagems.Values)
                    {
                        if (this.HasStratagem(stratagem.ID))
                        {
                            if (stratagem.Self)
                            {
                                selfStratagemCredit = this.GetSelfStratagemCredit(stratagem);
                                if (selfStratagemCredit.Credit > credit)
                                {
                                    credit = selfStratagemCredit.Credit;
                                    pack = selfStratagemCredit;
                                    flag = true;
                                }
                            }
                            else
                            {
                                this.SetCurrentStratagem(stratagem);
                                selfStratagemCredit = this.GetStratagemCreditByPosition(stratagem, this.Position);
                                if (selfStratagemCredit.Credit > credit)
                                {
                                    credit = selfStratagemCredit.Credit;
                                    pack = selfStratagemCredit;
                                    flag = true;
                                }
                                this.SetCurrentStratagem(null);
                            }
                        }
                    }
                    if (flag && (pack.CurrentStratagem != null))
                    {
                        this.SetCurrentStratagem(pack.CurrentStratagem);
                        if (pack.CurrentStratagem.Self)
                        {
                            this.SelfCastPosition = pack.SelfCastPosition;
                        }
                    }
                    else if (credit > 0)
                    {
                        this.TempDestination = new Point?(pack.Position);
                    }
                }
            }
        }

        private void GoIntoArchitecture()
        {
            if ((this.BelongedFaction != null) && (this.WillArchitecture != null))
            {
                if (this.CanOccupy())
                {
                    this.Occupy();
                }
                if (this.TempDestination.HasValue)
                {
                    this.RealDestination = this.TempDestination.Value;
                    this.TempDestination = null;
                }
                else if (this.CanEnter())
                {
                    if ((this.WillArchitecture.BelongedFaction == this.BelongedFaction) && this.EnterList.HasGameObject(this.WillArchitecture))
                    {
                        if (!this.WillArchitecture.HasHostileTroopsInView())
                        {
                            this.Enter();
                        }
                        else if (this.WillArchitecture.Endurance > 30)
                        {
                            if (this.Army.Scales == 0)
                            {
                                this.Enter();
                            }
                            else if (this.Army.InjuryQuantity > this.Army.Kind.MinScale)
                            {
                                this.Enter();
                            }
                            else if ((this.CurrentStunt == null) && GameObject.Chance(10))
                            {
                                this.Enter();
                            }
                        }
                    }
                    else
                    {
                        this.RealDestination = base.Scenario.GetClosestPoint(this.WillArchitecture.ArchitectureArea, this.Position);
                    }
                }
                else if (this.WillArchitecture.BelongedFaction == this.BelongedFaction)
                {
                    GameArea realTroopEnterableArea = this.WillArchitecture.GetRealTroopEnterableArea(this);
                    realTroopEnterableArea.RemovePoints(this.BelongedLegion.TakenPositions);
                    if (realTroopEnterableArea.Count > 0)
                    {
                        this.RealDestination = base.Scenario.GetClosestPoint(realTroopEnterableArea, this.Position);
                    }
                    else
                    {
                        this.RealDestination = base.Scenario.GetClosestPoint(this.WillArchitecture.ArchitectureArea, this.Position);
                    }
                }
                else if (!this.IsBaseViewingArchitecture(this.WillArchitecture))
                {
                    Routeway preferredRouteway = this.BelongedLegion.PreferredRouteway;
                    if ((preferredRouteway == null) && (this.StartingArchitecture != null))
                    {
                        preferredRouteway = this.StartingArchitecture.GetExistingRouteway(this.WillArchitecture);
                    }
                    if (((preferredRouteway != null) && (preferredRouteway.LastPoint != null)) && this.WillArchitecture.IsViewing(preferredRouteway.LastPoint.Position))
                    {
                        this.RealDestination = preferredRouteway.LastPoint.Position;
                    }
                    else
                    {
                        this.RealDestination = base.Scenario.GetClosestPoint(this.WillArchitecture.ArchitectureArea, this.Position);
                    }
                }
                else
                {
                    this.RealDestination = base.Scenario.GetClosestPoint(this.WillArchitecture.ArchitectureArea, this.Position);
                }
            }
        }

        private void HandleArchitectureDamage(ArchitectureDamage damage)
        {
            int num;
            if (damage.Damage >= 0)
            {
                num = damage.DestinationArchitecture.DecreaseEndurance(damage.Damage);
                damage.DestinationArchitecture.DecrementNumberList.AddNumber(num, CombatNumberKind.人数, damage.Position);
                if (damage.DestinationArchitecture.Endurance == 0)
                {
                    if (this.OnBreakWall != null)
                    {
                        this.OnBreakWall(damage.SourceTroop, damage.DestinationArchitecture);
                    }
                    GameObjects.Animations.TileAnimation animation = null;
                    foreach (Point point in damage.DestinationArchitecture.ArchitectureArea.Area)
                    {
                        animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.被击破, point, false);
                    }
                    if (animation != null)
                    {
                        this.TryToPlaySound(this.Position, animation.LinkedAnimation.SoundPath, false);
                    }
                    if (damage.DestinationArchitecture.RecentlyBreaked <= 0)
                    {
                        if (damage.SourceTroop.Combativity < damage.SourceTroop.Army.CombativityCeiling)
                        {
                            damage.SourceTroop.IncreaseCombativity(10);
                            if (damage.SourceTroop.PreAction == TroopPreAction.无)
                            {
                                damage.SourceTroop.PreAction = TroopPreAction.鼓舞;
                            }
                        }
                        if (damage.SourceTroop.Morale < damage.SourceTroop.Army.MoraleCeiling)
                        {
                            damage.SourceTroop.IncreaseMorale(5);
                            if (damage.SourceTroop.PreAction == TroopPreAction.无)
                            {
                                damage.SourceTroop.PreAction = TroopPreAction.鼓舞;
                            }
                        }
                    }
                }
            }
            if (damage.DominationDown > 0)
            {
                num = damage.DestinationArchitecture.DecreaseDomination(damage.DominationDown);
                damage.DestinationArchitecture.DecrementNumberList.AddNumber(num, CombatNumberKind.士气, damage.Position);
            }
            if (damage.CounterDamage > 0)
            {
                int num2 = 2;
                damage.SourceTroop.IncreaseBeAttackedExperience(num2 * 2);
                damage.SourceTroop.DecreaseQuantity(damage.CounterDamage);
                damage.SourceTroop.IncreaseInjuryQuantity(damage.CounterInjury);
                CheckTroopRout(damage.SourceTroop);
            }
        }

        private void HandleTroopDamage(TroopDamage damage)
        {
            GameObjects.Animations.TileAnimation animation;
            if (damage.Surround)
            {
                damage.DestinationTroop.Effect = TroopEffect.无;
                foreach (Troop troop in damage.SurroudingList)
                {
                    troop.Surrounding = false;
                }
            }
            int num = (((((2 + (damage.AntiArrowAttack ? 1 : 0)) + (damage.Critical ? 1 : 0)) + (damage.Chaos ? 1 : 0)) + (damage.OnFire ? 1 : 0)) + (damage.Waylay ? 1 : 0)) + (damage.SourceTroop.CombatMethodApplied ? 1 : 0);
            damage.SourceTroop.IncreaseAttackExperience(num * 2);
            damage.DestinationTroop.IncreaseBeAttackedExperience(num * 2);
            if (damage.AntiAttack)
            {
                animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.抵挡, damage.DestinationTroop.Position, false);
                if (animation != null)
                {
                    damage.DestinationTroop.TryToPlaySound(damage.DestinationTroop.Position, animation.LinkedAnimation.SoundPath, false);
                }
                if (this.OnAntiAttack != null)
                {
                    this.OnAntiAttack(damage.SourceTroop, damage.DestinationTroop);
                }
            }
            else if (damage.AntiArrowAttack)
            {
                animation = base.Scenario.GeneratorOfTileAnimation.AddTileAnimation(TileAnimationKind.抵挡, damage.DestinationTroop.Position, false);
                if (animation != null)
                {
                    damage.DestinationTroop.TryToPlaySound(damage.DestinationTroop.Position, animation.LinkedAnimation.SoundPath, false);
                }
                if (this.OnAntiArrowAttack != null)
                {
                    this.OnAntiArrowAttack(damage.SourceTroop, damage.DestinationTroop);
                }
            }
            else
            {
                if (damage.OnFire && base.Scenario.IsFireVaild(damage.DestinationTroop.Position, false, MilitaryType.步兵))
                {
                    base.Scenario.SetPositionOnFire(damage.DestinationTroop.Position);
                }
                if ((damage.SourceTroop.StuntDayDecrementOfAttack > 0) && (damage.DestinationTroop.StuntDayLeft > 0))
                {
                    damage.DestinationTroop.StuntDayLeft -= damage.SourceTroop.StuntDayDecrementOfAttack;
                    if (damage.DestinationTroop.StuntDayLeft < 1)
                    {
                        damage.DestinationTroop.StuntDayLeft = 1;
                    }
                }
                if (!damage.SourceTroop.Destroyed && !damage.DestinationTroop.Destroyed)
                {
                    if (!damage.SourceTroop.MoraleNoChanceAfterAttacked)
                    {
                        damage.SourceTroop.ChangeMorale(damage.SourceMoraleChange);
                        CheckTroopRout(damage.SourceTroop);
                    }
                    damage.DestinationTroop.DecreaseQuantity(damage.Damage);
                    if (damage.OnFire)
                    {
                        damage.DestinationTroop.DecreaseQuantity(damage.FireDamage);
                    }
                    damage.DestinationTroop.IncreaseInjuryQuantity(damage.Injury);
                    if (!damage.DestinationTroop.CombativityNoChanceAfterAttacked)
                    {
                        damage.DestinationTroop.DecreaseCombativity(damage.CombativityDown);
                    }
                    if (!damage.DestinationTroop.MoraleNoChanceAfterAttacked)
                    {
                        damage.DestinationTroop.ChangeMorale(damage.DestinationMoraleChange);
                    }
                    if (!damage.SourceTroop.Destroyed)
                    {
                        CheckTroopRout(damage.SourceTroop, damage.DestinationTroop);
                    }
                    else
                    {
                        CheckTroopRout(damage.DestinationTroop);
                    }
                    if (!damage.DestinationTroop.Destroyed)
                    {
                        if ((damage.DestinationTroop.BelongedFaction != null) && (damage.DestinationTroop.BelongedFaction.RateOfCombativityRecoveryAfterAttacked > 0f))
                        {
                            damage.DestinationTroop.IncreaseCombativity(StaticMethods.GetRandomValue((int) ((damage.DestinationTroop.Leader.Braveness * 100) * damage.DestinationTroop.BelongedFaction.RateOfCombativityRecoveryAfterAttacked), 100));
                        }
                        if (damage.BeCountered && !damage.SourceTroop.Destroyed)
                        {
                            damage.SourceTroop.DecreaseQuantity(damage.CounterDamage);
                            damage.SourceTroop.IncreaseInjuryQuantity(damage.CounterInjury);
                            if (!damage.SourceTroop.CombativityNoChanceAfterAttacked)
                            {
                                damage.SourceTroop.DecreaseCombativity(damage.CounterCombativityDown);
                            }
                            CheckTroopRout(damage.DestinationTroop, damage.SourceTroop);
                        }
                        if (damage.ChallengeHappened)
                        {
                            this.CurrentSourceChallengePerson = damage.ChallengeSourcePerson;
                            this.CurrentDestinationChallengePerson = damage.ChallengeDestinationPerson;
                            if (this.OnPersonChallenge != null)
                            {
                                this.OnPersonChallenge(damage.ChallengeResult, damage.SourceTroop, this.CurrentSourceChallengePerson, damage.DestinationTroop, this.CurrentDestinationChallengePerson);
                            }
                        }
                        if (!damage.SourceTroop.Destroyed)
                        {
                            if (damage.Waylay)
                            {
                                damage.DestinationTroop.OperationDone = true;
                                damage.DestinationTroop.MovabilityLeft = -1;
                                if (this.OnReceiveWaylay != null)
                                {
                                    this.OnReceiveWaylay(damage.SourceTroop, damage.DestinationTroop);
                                }
                            }
                            if (damage.Critical && (!damage.Waylay && (this.OnReceiveCriticalStrike != null)))
                            {
                                this.OnReceiveCriticalStrike(damage.SourceTroop, damage.DestinationTroop);
                            }
                            if (damage.Chaos)
                            {
                                damage.DestinationTroop.SetChaos(damage.SourceTroop.GenerateAttackChaosDay(2));
                            }
                        }
                    }
                }
            }
        }

        public bool HasCaptive()
        {
            return (this.CaptiveCount > 0);
        }

        public bool HasCombatMethod(int id)
        {
            if (!this.ProhibitAllAction && !this.ProhibitCombatMethod)
            {
                CombatMethod combatMethod = this.CombatMethods.GetCombatMethod(id);
                if (combatMethod != null)
                {
                    return (combatMethod.IsCastable(this) && (combatMethod.Combativity <= (this.Combativity + this.DecrementOfCombatMethodCombativityConsuming)));
                }
            }
            return false;
        }

        public bool HasHostileArchitectureInView()
        {
            foreach (Point point in this.BaseViewArea.Area)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(point);
                if ((architectureByPosition != null) && (((this.BelongedFaction == null) && (architectureByPosition.BelongedFaction != null)) || ((this.BelongedFaction != null) && !this.BelongedFaction.IsFriendly(architectureByPosition.BelongedFaction))))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasHostileTroopInView()
        {
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !this.IsFriendly(troopByPosition.BelongedFaction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasStratagem(int id)
        {
            if (this.Status != TroopStatus.埋伏)
            {
                if (this.ProhibitAllAction || this.ProhibitStratagem)
                {
                    return false;
                }
                Stratagem stratagem = this.Stratagems.GetStratagem(id);
                if (stratagem != null)
                {
                    return (stratagem.Combativity <= (this.Combativity + this.DecrementOfStratagemCombativityConsuming));
                }
            }
            return false;
        }

        public bool HasStunt(int id)
        {
            if ((this.CurrentStunt == null) || (this.StuntDayLeft <= 0))
            {
                Stunt stunt = this.Stunts.GetStunt(id);
                if (stunt != null)
                {
                    if (!((stunt.Combativity <= this.Combativity) && stunt.IsCastable(this)))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public bool HasTreasure()
        {
            foreach (Person person in this.Persons)
            {
                if (person.TreasureCount > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool IfAttackArchitecture(Architecture architecture, bool last)
        {
            switch (this.AttackTargetKind)
            {
                case TroopAttackTargetKind.遇敌:
                    return true;

                case TroopAttackTargetKind.无反:
                    return (architecture.BelongedFaction == null);

                case TroopAttackTargetKind.目标:
                    return (architecture == this.TargetArchitecture);

                case TroopAttackTargetKind.攻弱:
                    return true;

                case TroopAttackTargetKind.防弱:
                    return true;

                case TroopAttackTargetKind.攻防皆弱:
                    return true;

                case TroopAttackTargetKind.无反默认:
                    return (last || (architecture.BelongedFaction == null));

                case TroopAttackTargetKind.目标默认:
                    return (last || (architecture == this.TargetArchitecture));

                case TroopAttackTargetKind.攻弱默认:
                    return true;

                case TroopAttackTargetKind.防弱默认:
                    return true;

                case TroopAttackTargetKind.攻防皆弱默认:
                    return true;
            }
            return false;
        }

        private bool IfAttackTroop(Troop troop, bool last)
        {
            switch (this.AttackTargetKind)
            {
                case TroopAttackTargetKind.遇敌:
                    return true;

                case TroopAttackTargetKind.无反:
                    return !this.CounterAttackAvail(troop);

                case TroopAttackTargetKind.目标:
                    return (troop == this.TargetTroop);

                case TroopAttackTargetKind.攻弱:
                    return (troop.Offence < this.Offence);

                case TroopAttackTargetKind.防弱:
                    return (troop.Defence < this.Defence);

                case TroopAttackTargetKind.攻防皆弱:
                    return ((troop.Offence < this.Offence) && (troop.Defence < this.Defence));

                case TroopAttackTargetKind.无反默认:
                    return (last || !this.CounterAttackAvail(troop));

                case TroopAttackTargetKind.目标默认:
                    return (last || (troop == this.TargetTroop));

                case TroopAttackTargetKind.攻弱默认:
                    return (last || (troop.Offence < this.Offence));

                case TroopAttackTargetKind.防弱默认:
                    return (last || (troop.Defence < this.Defence));

                case TroopAttackTargetKind.攻防皆弱默认:
                    return (last || ((troop.Offence < this.Offence) && (troop.Defence < this.Defence)));
            }
            return false;
        }

        private bool IfCastTroop(Troop troop, bool last)
        {
            switch (this.CastTargetKind)
            {
                case TroopCastTargetKind.可能:
                    return true;

                case TroopCastTargetKind.特定:
                    return (troop == this.TargetTroop);

                case TroopCastTargetKind.智低:
                    return (troop.TroopIntelligence < this.TroopIntelligence);

                case TroopCastTargetKind.特定默认:
                    return (last || (troop == this.TargetTroop));

                case TroopCastTargetKind.智低默认:
                    return (last || (troop.TroopIntelligence < this.TroopIntelligence));
            }
            return false;
        }

        private void IncreaseArmyExperience(int increment)
        {
            this.Army.IncreaseExperience(increment * this.MultipleOfArmyExperience);
        }

        private void IncreaseAttackExperience(int increment)
        {
            this.IncreaseArmyExperience(increment);
            if (this.BelongedFaction != null)
            {
                if (this.Army.IncreaseLeaderExperience(increment * this.MultipleOfLeaderExperience))
                {
                    this.Army.ApplyFollowedLeader(this);
                }
                this.IncreasePersonAttackExperience(increment, true);
                this.IncreasePersonAttackReputation(increment);
                this.BelongedFaction.IncreaseReputation(increment * 2);
                this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfCombatTechniquePoint) * 50);
            }
            this.RefreshOffence();
            this.RefreshDefence();
        }

        private void IncreaseBeAttackedExperience(int increment)
        {
            if (this.BelongedFaction != null)
            {
                this.IncreasePersonAttackExperience(increment, false);
            }
            this.IncreaseArmyExperience(increment);
            this.RefreshOffence();
            this.RefreshDefence();
        }

        public void IncreaseCombativity(int increment)
        {
            increment = this.Army.IncreaseCombativity(increment);
            if (increment > 0)
            {
                this.IncrementNumberList.AddNumber(increment, CombatNumberKind.战意, this.Position);
                this.ShowNumber = true;
            }
        }

        public void IncreaseExperience(int increment)
        {
            Military army = this.Army;
            army.Experience += increment * this.MultipleOfArmyExperience;
        }

        public int IncreaseFood(int increment)
        {
            if (increment <= 0)
            {
                return 0;
            }
            int num = this.FoodMax - this.Food;
            if (increment > num)
            {
                increment = num;
            }
            this.Food += increment;
            this.IncrementNumberList.AddNumber(increment, CombatNumberKind.粮草, this.Position);
            this.ShowNumber = true;
            return increment;
        }

        public void IncreaseInjuryQuantity(int increment)
        {
            this.Army.IncreaseInjuryQuantity(increment);
        }

        public void IncreaseMorale(int increment)
        {
            increment = this.Army.IncreaseMorale(increment);
            if (increment > 0)
            {
                this.RefreshOffence();
                this.RefreshDefence();
                this.IncrementNumberList.AddNumber(increment, CombatNumberKind.士气, this.Position);
                this.ShowNumber = true;
            }
        }

        private void IncreasePersonAttackExperience(int increment, bool attack)
        {
            switch (this.Army.Kind.Type)
            {
                case MilitaryType.步兵:
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.AddBubingExperience(increment * 2);
                        }
                        else
                        {
                            person.AddBubingExperience(increment);
                        }
                    }
                    break;

                case MilitaryType.弩兵:
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.AddNubingExperience(increment * 2);
                        }
                        else
                        {
                            person.AddNubingExperience(increment);
                        }
                    }
                    break;

                case MilitaryType.骑兵:
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.AddQibingExperience(increment * 2);
                        }
                        else
                        {
                            person.AddQibingExperience(increment);
                        }
                    }
                    break;

                case MilitaryType.水军:
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.AddShuijunExperience(increment * 2);
                        }
                        else
                        {
                            person.AddShuijunExperience(increment);
                        }
                    }
                    break;

                case MilitaryType.器械:
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.AddQixieExperience(increment * 2);
                        }
                        else
                        {
                            person.AddQixieExperience(increment);
                        }
                    }
                    break;
            }
            if (attack)
            {
                foreach (Person person in this.Persons)
                {
                    if (person == this.Leader)
                    {
                        person.AddStrengthExperience(increment * 2);
                    }
                    else
                    {
                        person.AddStrengthExperience(increment);
                    }
                }
            }
            else
            {
                foreach (Person person in this.Persons)
                {
                    if (person == this.Leader)
                    {
                        person.AddCommandExperience(increment * 2);
                    }
                    else
                    {
                        person.AddCommandExperience(increment);
                    }
                }
            }
        }

        private void IncreasePersonAttackReputation(int increment)
        {
            foreach (Person person in this.Persons)
            {
                if (person == this.Leader)
                {
                    person.IncreaseReputation((increment * 2) * 2);
                }
                else
                {
                    person.IncreaseReputation(increment * 2);
                }
            }
        }

        private void IncreasePersonStratagemExperience(int increment)
        {
            Person maxIntelligencePerson = this.Persons.GetMaxIntelligencePerson();
            foreach (Person person2 in this.Persons)
            {
                if (person2 == maxIntelligencePerson)
                {
                    person2.AddIntelligenceExperience(increment * 2);
                    person2.AddStratagemExperience((increment * 2) * 2);
                    person2.IncreaseReputation((increment * 2) * 2);
                }
                else
                {
                    person2.AddIntelligenceExperience(increment);
                    person2.AddStratagemExperience(increment * 2);
                    person2.IncreaseReputation(increment * 2);
                }
            }
        }

        public void IncreaseQuantity(int increment)
        {
            int num = 0;
            if ((this.Army.Quantity + increment) > this.Army.Kind.MaxScale)
            {
                num = this.Army.Kind.MaxScale - this.Army.Quantity;
            }
            else
            {
                num = increment;
            }
            this.Army.IncreaseQuantity(num);
            if (num > 0)
            {
                this.RefreshOffence();
                this.RefreshDefence();
            }
            this.IncrementNumberList.AddNumber(num, CombatNumberKind.人数, this.Position);
            this.ShowNumber = true;
        }

        private void IncreaseRoutExperience(bool rout)
        {
            if (rout)
            {
                this.Army.IncreaseExperience(20);
                if (this.BelongedFaction != null)
                {
                    if (this.Army.IncreaseLeaderExperience(30 * this.MultipleOfLeaderExperience))
                    {
                        this.Army.ApplyFollowedLeader(this);
                    }
                    this.BelongedFaction.IncreaseReputation(50);
                    this.BelongedFaction.IncreaseTechniquePoint(0x3e8 * this.MultipleOfCombatTechniquePoint);
                    foreach (Person person in this.Persons)
                    {
                        if (person == this.Leader)
                        {
                            person.IncreaseReputation(80);
                        }
                        else
                        {
                            person.IncreaseReputation(40);
                        }
                    }
                }
                this.RefreshOffence();
                this.RefreshDefence();
            }
            else if (this.BelongedFaction != null)
            {
                foreach (Person person in this.Persons)
                {
                    if (person == this.Leader)
                    {
                        person.IncreaseReputation(20);
                    }
                    else
                    {
                        person.IncreaseReputation(10);
                    }
                }
            }
        }

        private void IncreaseStratagemExperience(int increment, bool cast)
        {
            this.Army.IncreaseExperience(increment);
            if (this.BelongedFaction != null)
            {
                this.IncreasePersonStratagemExperience(increment);
                if (cast)
                {
                    if (this.Army.IncreaseLeaderExperience(increment * this.MultipleOfLeaderExperience))
                    {
                        this.Army.ApplyFollowedLeader(this);
                    }
                    this.BelongedFaction.IncreaseReputation(increment * 2);
                    this.BelongedFaction.IncreaseTechniquePoint((increment * this.MultipleOfStratagemTechniquePoint) * this.CurrentStratagem.TechniquePoint);
                }
            }
            this.RefreshOffence();
            this.RefreshDefence();
        }

        public void Initialize()
        {
            base.Scenario.SetMapTileTroop(this);
            this.RefreshTroopAbility();
            this.InitializeInfluences();
            this.ResetTerrainData();
            this.InitializeContactArea();
            this.InitializeOffenceArea();
            this.InitializeStratagemArea();
            this.InitializeViewArea();
            if (base.Scenario.MapTileData[this.Position.X, this.Position.Y].AreaInfluenceList != null)
            {
                foreach (AreaInfluenceData data in base.Scenario.MapTileData[this.Position.X, this.Position.Y].AreaInfluenceList)
                {
                    if (data.Owner != this)
                    {
                        data.ApplyAreaInfluence(this);
                    }
                }
            }
            this.RefreshAllData();
        }

        private void InitializeContactArea()
        {
            foreach (Point point in this.ContactArea.Area)
            {
                base.Scenario.AddPositionContactingTroop(this, point);
            }
        }

        public void InitializeInfluences()
        {
            this.Army.ApplyFollowedLeader(this);
            foreach (Influence influence in this.Army.Kind.Influences.Influences.Values)
            {
                influence.ApplyInfluence(this);
            }
            this.ApplyEventEffectInfluences();
            this.ApplyStuntInfluences();
        }

        public void InitializeInQueue()
        {
            this.Moved = false;
            this.QueueEnded = false;
            this.WaitOnce = false;
            this.OperationDone = false;
            this.AttackedTroopList.Clear();
            if (!this.OperationDone)
            {
                this.MovabilityLeft = this.Movability;
            }
            if (this.ProhibitCombatMethod)
            {
                this.CurrentCombatMethod = null;
            }
            if (this.ProhibitStratagem)
            {
                this.CurrentStratagem = null;
            }
            if (this.ProhibitAllAction)
            {
                this.CurrentCombatMethod = null;
                this.CurrentStratagem = null;
                this.OperationDone = true;
            }
            if ((this.CurrentStunt != null) && (this.StuntDayLeft > 0))
            {
            }
            if (this.CurrentCombatMethod != null)
            {
                this.CurrentCombatMethod.Apply(this);
            }
            this.StratagemApplyed = false;
            if (this.CurrentStratagem != null)
            {
                this.DecreaseCombativity(this.CurrentStratagem.Combativity - this.DecrementOfStratagemCombativityConsuming);
            }
            this.SetOutburst();
            if ((((this.CurrentStunt != null) && (this.StuntDayLeft > 0)) || (this.CurrentCombatMethod != null)) || (this.CurrentOutburstKind != OutburstKind.无))
            {
                this.RefreshAllData();
            }
            if (this.RecentlyFighting > 0)
            {
                this.RecentlyFighting--;
            }
        }

        private void InitializeOffenceArea()
        {
            foreach (Point point in this.OffenceArea.Area)
            {
                base.Scenario.AddPositionOffencingTroop(this, point);
            }
        }

        public void InitializePosition(Point p)
        {
            this.PreviousPosition = this.position = p;
            this.Persons.ApplyInfluences();
            this.Initialize();
        }

        private void InitializeStratagemArea()
        {
            foreach (Point point in this.StratagemArea.Area)
            {
                base.Scenario.AddPositionStratagemingTroop(this, point);
            }
        }

        private void InitializeViewArea()
        {
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.AddTroopKnownAreaData(this);
            }
            foreach (Point point in this.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.AddPositionViewingTroopNoCheck(this, point);
                    this.AddAreaInfluences(point);
                }
            }
        }

        public void Investigate(int days)
        {
            Information information = new Information();
            information.Scenario = base.Scenario;
            information.ID = base.Scenario.Informations.GetFreeGameObjectID();
            information.Level = this.InvestigateLevel;
            information.Radius = this.InvestigateRadius;
            information.Position = this.SelfCastPosition;
            information.Oblique = false;
            information.DaysLeft = days;
            base.Scenario.Informations.AddInformation(information);
            this.BelongedFaction.AddInformation(information);
            information.Apply();
        }

        public bool IsAccessable(Point p)
        {
            return this.simplepathFinder.GetPath(this.Position, p);
        }

        public bool IsBaseViewingArchitecture(Architecture a)
        {
            foreach (Point point in this.BaseViewArea.Area)
            {
                if (a.ArchitectureArea.HasPoint(point))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsContactingWillArchitecture()
        {
            if (this.WillArchitecture != null)
            {
                foreach (Point point in GameArea.GetArea(this.Position, 1, true).Area)
                {
                    if (base.Scenario.GetArchitectureByPosition(point) == this.WillArchitecture)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsCurrentPlayer()
        {
            return (GlobalVariables.SkyEye || (this.BelongedFaction == base.Scenario.CurrentPlayer));
        }

        public bool IsFriendly(Faction faction)
        {
            return ((this.BelongedFaction == faction) || ((this.BelongedFaction != null) && this.BelongedFaction.IsFriendly(faction)));
        }

        public bool IsInHostileArchitectureHighView()
        {
            foreach (Architecture architecture in base.Scenario.GetHighViewingArchitecturesByPosition(this.Position))
            {
                if (!this.IsFriendly(architecture.BelongedFaction))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInHostileTroopView()
        {
            return (base.Scenario.HostileViewingTroopsCount(this.BelongedFaction, this.Position) > 0);
        }

        public bool IsMovableOnPosition(Point position)
        {
            return (this.GetTerrainAdaptability(base.Scenario.GetTerrainKindByPosition(position)) <= this.RealMovability);
        }

        public bool IsOffencingWillArchitecture()
        {
            if (this.WillArchitecture != null)
            {
                foreach (Point point in this.OffenceArea.Area)
                {
                    if (base.Scenario.GetArchitectureByPosition(point) == this.WillArchitecture)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool IsViewingWillArchitecture()
        {
            foreach (Point point in this.BaseViewArea.Area)
            {
                if (base.Scenario.GetArchitectureByPosition(point) == this.WillArchitecture)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool LaunchSecondPathFinder(Point start, Point end)
        {
            return (GetDistance(start, end) > (GameObjectConsts.LaunchTierFinderDistance * GameObjectConsts.SecondTierSquareSize));
        }

        public static bool LaunchThirdPathFinder(Point start, Point end)
        {
            return (GetDistance(start, end) > (GameObjectConsts.LaunchTierFinderDistance * GameObjectConsts.ThirdTierSquareSize));
        }

        public void LevyFood()
        {
            TerrainDetail terrainDetailByPositionNoCheck = base.Scenario.GetTerrainDetailByPositionNoCheck(this.Position);
            if (terrainDetailByPositionNoCheck != null)
            {
                int randomFood = terrainDetailByPositionNoCheck.GetRandomFood(base.Scenario.Date.Season);
                if (randomFood > (this.FoodCostPerDay * 3))
                {
                    randomFood = this.FoodCostPerDay * 3;
                }
                int food = this.IncreaseFood(randomFood);
                foreach (Person person in this.Persons)
                {
                    person.AddCommandExperience(food / 0x2710);
                    person.AddGlamourExperience(food / 0x2710);
                    if (person == this.Leader)
                    {
                        person.IncreaseReputation((2 * food) / 0x2710);
                    }
                    else
                    {
                        person.IncreaseReputation(food / 0x2710);
                    }
                }
                this.BelongedFaction.IncreaseTechniquePoint(food / 200);
                this.BelongedFaction.IncreaseReputation(food / 0x2710);
                base.Scenario.NoFoodDictionary.AddPosition(new NoFoodPosition(this.Position, terrainDetailByPositionNoCheck.RandomRegainDays));
                foreach (Architecture architecture in base.Scenario.GetViewingArchitecturesByPosition(this.Position))
                {
                    if (this.BelongedFaction != architecture.BelongedFaction)
                    {
                        architecture.SetRecentlyAttacked();
                    }
                    architecture.DecreaseAgriculture(food / 0x1388);
                }
                this.Controllable = false;
                if (this.OnLevyFieldFood != null)
                {
                    this.OnLevyFieldFood(this, food);
                }
            }
        }

        public bool LevyFoodAvail()
        {
            
            //return ((((this.Food < this.FoodMax) && !base.Scenario.NoFoodDictionary.HasPosition(this.Position)) && (base.Scenario.GetTerrainDetailByPositionNoCheck(this.Position).FoodDeposit > 0)) && (base.Scenario.GetArchitectureByPositionNoCheck(this.Position) == null));
            return false;

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

        public void LoadPathInformation(int positionX, int positionY, int destinationX, int destinationY, int realDestinationX, int realDestinationY, string firstTierPathData, string secondTierPathData, string thirdTierPathData, int firstIndex, int secondIndex, int thirdIndex)
        {
            this.PreviousPosition = this.position = new Point(positionX, positionY);
            this.destination = new Point(destinationX, destinationY);
            this.realDestination = new Point(realDestinationX, realDestinationY);
            if (firstTierPathData != "")
            {
                this.FirstTierPath = new List<Point>();
                StaticMethods.LoadFromString(this.FirstTierPath, firstTierPathData);
            }
            if (secondTierPathData != "")
            {
                this.SecondTierPath = new List<Point>();
                StaticMethods.LoadFromString(this.SecondTierPath, secondTierPathData);
            }
            if (thirdTierPathData != "")
            {
                this.ThirdTierPath = new List<Point>();
                StaticMethods.LoadFromString(this.ThirdTierPath, thirdTierPathData);
            }
            this.FirstIndex = firstIndex;
            this.SecondIndex = secondIndex;
            this.ThirdIndex = thirdIndex;
        }

        public void LoadPersonsFromString(Dictionary<int, Person> persons, string dataString, int leaderID)
        {
            char[] separator = new char[] { ' ', '\n', '\r' };
            string[] strArray = dataString.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            this.Persons.Clear();
            foreach (string str in strArray)
            {
                Person person = persons[int.Parse(str)];
                if (person != null)
                {
                    this.AddPerson(person);
                    if (person.ID == leaderID)
                    {
                        this.Leader = person;
                    }
                }
            }
        }

        public void MonthEvent()
        {
        }

        public string MoraleInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Morale, 20);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Morale, 10);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Morale, 5);

                case InformationLevel.全:
                    return this.Morale.ToString();
            }
            return "----";
        }

        public void Move()
        {
            bool flag = false;

            if (this.Position != this.Destination)
            {
                flag = this.TryToStepForward();
            }
            else if (this.Position != this.RealDestination)
            {
                this.Destination = this.RealDestination;
                flag = this.TryToStepForward();
            }
            else
            {
                this.MovabilityLeft = -1;
            }
        }

        public bool MoveAvail()
        {
            return (this.Status == TroopStatus.一般);
        }

        private void MoveCaptiveIntoArchitecture(Architecture des)
        {
            foreach (Captive captive in this.Captives.GetList())
            {
                des.AddCaptive(captive);
                this.RemoveCaptive(captive);
            }
        }

        private void MoveContactArea(int XOffset, int YOffset)
        {
            foreach (Point point in this.ContactArea.Area)
            {
                base.Scenario.RemovePositionContactingTroop(this, point);
            }
            this.ContactArea = null;
            foreach (Point point in this.ContactArea.Area)
            {
                base.Scenario.AddPositionContactingTroop(this, point);
            }
        }

        private void MoveOffenceArea(int XOffset, int YOffset)
        {
            foreach (Point point in this.OffenceArea.Area)
            {
                base.Scenario.RemovePositionOffencingTroop(this, point);
            }
            this.OffenceArea = null;
            foreach (Point point in this.OffenceArea.Area)
            {
                base.Scenario.AddPositionOffencingTroop(this, point);
            }
        }

        private void MoveStratagemArea(int XOffset, int YOffset)
        {
            foreach (Point point in this.StratagemArea.Area)
            {
                base.Scenario.RemovePositionStratagemingTroop(this, point);
            }
            this.StratagemArea = null;
            foreach (Point point in this.StratagemArea.Area)
            {
                base.Scenario.AddPositionStratagemingTroop(this, point);
            }
        }

        private void MoveViewArea(int XOffset, int YOffset)
        {
            foreach (Point point in this.ViewArea.Area)
            {
                if (!base.Scenario.PositionOutOfRange(point))
                {
                    base.Scenario.RemovePositionViewingTroopNoCheck(this, point);
                    this.RemoveAreaInfluences(point);
                }
            }
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.RemoveTroopKnownAreaData(this);
            }
            this.ViewArea = null;
            this.BaseViewArea = null;
            if (this.BelongedFaction != null)
            {
                this.BelongedFaction.AddTroopKnownAreaData(this);
            }
            foreach (Point point in this.ViewArea.Area)
            {
                if (base.Scenario.PositionOutOfRange(point))
                {
                    continue;
                }
                Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point);
                if (((troopByPositionNoCheck != null) && !troopByPositionNoCheck.IsFriendly(this.BelongedFaction)) && (troopByPositionNoCheck.Status == TroopStatus.埋伏))
                {
                    this.DetectAmbush(troopByPositionNoCheck);
                }
                base.Scenario.AddPositionViewingTroopNoCheck(this, point);
                this.AddAreaInfluences(point);
            }
            this.PurifyAreaInfluences(this.PreviousPosition);
            this.ApplyAreaInfluences(this.position);
            this.RefreshDataOfAreaInfluence();
        }

        private int NextPositionCost(Point currentPosition, Point nextPosition)
        {
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            switch ((nextPosition.X - currentPosition.X))
            {
                case -1:
                    switch ((nextPosition.Y - currentPosition.Y))
                    {
                        case -1:
                            num = this.GetCostByPosition(new Point(currentPosition.X - 1, currentPosition.Y), false, -1);
                            num2 = this.GetCostByPosition(new Point(currentPosition.X, currentPosition.Y - 1), false, -1);
                            return (this.GetCostByPosition(nextPosition, true, (num > num2) ? num : num2) * 7);

                        case 0:
                            return (this.GetCostByPosition(nextPosition, false, -1) * 5);

                        case 1:
                            num = this.GetCostByPosition(new Point(currentPosition.X - 1, currentPosition.Y), false, -1);
                            num2 = this.GetCostByPosition(new Point(currentPosition.X, currentPosition.Y + 1), false, -1);
                            return (this.GetCostByPosition(nextPosition, true, (num > num2) ? num : num2) * 7);
                    }
                    return num3;

                case 0:
                    switch ((nextPosition.Y - currentPosition.Y))
                    {
                        case -1:
                            return (this.GetCostByPosition(nextPosition, false, -1) * 5);

                        case 0:
                            return 0xdac;

                        case 1:
                            return (this.GetCostByPosition(nextPosition, false, -1) * 5);
                    }
                    return num3;

                case 1:
                    switch ((nextPosition.Y - currentPosition.Y))
                    {
                        case -1:
                            num = this.GetCostByPosition(new Point(currentPosition.X + 1, currentPosition.Y), false, -1);
                            num2 = this.GetCostByPosition(new Point(currentPosition.X, currentPosition.Y - 1), false, -1);
                            return (this.GetCostByPosition(nextPosition, true, (num > num2) ? num : num2) * 7);

                        case 0:
                            return (this.GetCostByPosition(nextPosition, false, -1) * 5);

                        case 1:
                            num = this.GetCostByPosition(new Point(currentPosition.X + 1, currentPosition.Y), false, -1);
                            num2 = this.GetCostByPosition(new Point(currentPosition.X, currentPosition.Y + 1), false, -1);
                            return (this.GetCostByPosition(nextPosition, true, (num > num2) ? num : num2) * 7);
                    }
                    return num3;
            }
            return num3;
        }

        public void Occupy()
        {
            Architecture currentArchitecture = this.CurrentArchitecture;
            if (currentArchitecture != null)
            {
                foreach (Point point in currentArchitecture.ArchitectureArea.Area)
                {
                    Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(point);
                    if ((troopByPositionNoCheck != null) && (troopByPositionNoCheck.BelongedFaction != this.BelongedFaction))
                    {
                        troopByPositionNoCheck.DecreaseMorale(troopByPositionNoCheck.Army.MoraleCeiling);
                        CheckTroopRout(troopByPositionNoCheck);
                    }
                }
                currentArchitecture.BuildingFacility = -1;
                currentArchitecture.BuildingDaysLeft = 0;
                if (currentArchitecture.IsCapital)
                {
                    base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, currentArchitecture.BelongedFaction.ID, -50 * currentArchitecture.AreaCount);
                    base.Scenario.ReflectDiplomaticRelations(this.BelongedFaction.ID, currentArchitecture.BelongedFaction.ID, -50);
                    currentArchitecture.BelongedFaction.HandleForcedChangeCapital();
                }
                if (currentArchitecture.BelongedFaction != this.BelongedFaction)
                {
                    bool flag = false;
                    if (currentArchitecture.BelongedFaction != null)
                    {
                        base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, currentArchitecture.BelongedFaction.ID, (-20 * currentArchitecture.AreaCount) * (currentArchitecture.IsImportant ? 2 : 1));
                        base.Scenario.ReflectDiplomaticRelations(this.BelongedFaction.ID, currentArchitecture.BelongedFaction.ID, -20);
                        foreach (Architecture architecture2 in currentArchitecture.GetAILinks())
                        {
                            if (!(((architecture2.BelongedFaction == null) || (architecture2.BelongedFaction == currentArchitecture.BelongedFaction)) || this.IsFriendly(architecture2.BelongedFaction)))
                            {
                                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID, (-3 * currentArchitecture.AreaCount) * (currentArchitecture.IsImportant ? 2 : 1));
                            }
                        }
                    }
                    else
                    {
                        flag = true;
                        foreach (Architecture architecture2 in currentArchitecture.GetAILinks())
                        {
                            if (!((architecture2.BelongedFaction == null) || this.IsFriendly(architecture2.BelongedFaction)))
                            {
                                base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, architecture2.BelongedFaction.ID, (-5 * currentArchitecture.AreaCount) * (currentArchitecture.IsImportant ? 2 : 1));
                            }
                        }
                    }
                    this.CheckCaptiveOnOccupy(currentArchitecture);
                    foreach (Military military in currentArchitecture.Militaries)
                    {
                        military.Morale /= 2;
                        military.Combativity /= 2;
                    }

                    this.Scenario.GameScreen.xianshishijiantupian(this, currentArchitecture);
                    currentArchitecture.ResetFaction(this.BelongedFaction);
                    if (!flag)
                    {
                        float num = 1f - ((0.5f * currentArchitecture.Morale) / ((float) currentArchitecture.MoraleCeiling));
                        if (currentArchitecture.Kind.HasAgriculture)
                        {
                            currentArchitecture.Agriculture = (int) (currentArchitecture.Agriculture * num);
                            if (currentArchitecture.Agriculture < 0)
                            {
                                currentArchitecture.Agriculture = 0;
                            }
                        }
                        if (currentArchitecture.Kind.HasCommerce)
                        {
                            currentArchitecture.Commerce = (int) (currentArchitecture.Commerce * num);
                            if (currentArchitecture.Commerce < 0)
                            {
                                currentArchitecture.Commerce = 0;
                            }
                        }
                        if (currentArchitecture.Kind.HasTechnology)
                        {
                            currentArchitecture.Technology = (int) (currentArchitecture.Technology * num);
                            if (currentArchitecture.Technology < 0)
                            {
                                currentArchitecture.Technology = 0;
                            }
                        }
                        if (currentArchitecture.Kind.HasMorale)
                        {
                            currentArchitecture.Morale = (currentArchitecture.MoraleCeiling - currentArchitecture.Morale) / 5;
                        }
                    }
                    if (currentArchitecture.Kind.HasDomination)
                    {
                        currentArchitecture.Endurance = 50 * currentArchitecture.AreaCount;
                        if (currentArchitecture.Domination > 50)
                        {
                            currentArchitecture.Domination = 50;
                        }
                    }
                    else
                    {
                        currentArchitecture.Endurance = 50 * currentArchitecture.AreaCount;
                        currentArchitecture.Domination = currentArchitecture.DominationCeiling;
                    }
                    currentArchitecture.Fund /= 10;
                    currentArchitecture.Food /= 10;
                    this.BelongedFaction.AddArchitectureKnownData(currentArchitecture);
                    this.WillArchitecture = currentArchitecture;
                    if (((((this.BelongedLegion.PreferredRouteway != null) && (this.BelongedLegion.PreferredRouteway.Length > 0)) && (this.BelongedLegion.PreferredRouteway.EndArchitecture == null)) && ((this.BelongedLegion.PreferredRouteway.DestinationArchitecture == null) || (this.BelongedLegion.PreferredRouteway.DestinationArchitecture == currentArchitecture))) && currentArchitecture.GetRoutewayStartPoints().HasPoint(this.BelongedLegion.PreferredRouteway.LastPoint.Position))
                    {
                        this.BelongedLegion.PreferredRouteway.EndArchitecture = currentArchitecture;
                    }
                    if (this.BelongedFaction.Capital == null)
                    {
                        this.BelongedFaction.ChangeCapital(currentArchitecture);
                    }
                    if ((currentArchitecture.BelongedSection != null) && (currentArchitecture.BelongedSection.BelongedFaction != this.BelongedFaction))
                    {
                        currentArchitecture.BelongedSection.RemoveArchitecture(currentArchitecture);
                    }
                    if (((this.BelongedLegion.StartArchitecture != null) && (this.BelongedLegion.StartArchitecture.BelongedSection != null)) && (this.BelongedLegion.StartArchitecture.BelongedSection.BelongedFaction == this.BelongedFaction))
                    {
                        this.BelongedLegion.StartArchitecture.BelongedSection.AddArchitecture(currentArchitecture);
                    }
                    else if (this.BelongedFaction.FirstSection != null)
                    {
                        this.BelongedFaction.FirstSection.AddArchitecture(currentArchitecture);
                    }
                    currentArchitecture.CheckIsFrontLine();
                    this.Controllable = false;
                    if (this.OnOccupyArchitecture != null)
                    {
                        this.OnOccupyArchitecture(this, currentArchitecture);
                    }
                }
            }
        }

        public void PlayCriticalAttackSound()
        {
            if (this.AttackStarted)
            {
                this.AttackStarted = false;
                this.TryToPlaySound(this.Position, this.Army.Kind.Sounds.CriticalAttackSoundPath, false);
            }
        }

        private void PlaySound()
        {
            if (File.Exists(this.SoundFileLocation))
            {
                Screen.PlaySound(this.SoundFileLocation);
            }
        }

        private void PlaySound(string soundFileLocation, bool looping)
        {
            if (GlobalVariables.PlayBattleSound && File.Exists(soundFileLocation))
            {
                this.SoundFileLocation = soundFileLocation;
                try
                {
                    Thread thread = new Thread(new ThreadStart(this.PlaySound));
                    thread.Start();
                    thread.Join();
                }
                catch
                {
                }
            }
        }

        private void PostActionAI()
        {
            if (((((!this.HasSupply || !GameObject.Chance(0x21)) && this.ControlAvail()) && ((this.RationDaysLeft == 0) || ((this.RationDaysLeft == 1) && GameObject.Chance(20)))) && this.LevyFoodAvail()) && (GameObject.Chance(50) || !this.HasHostileTroopInView()))
            {
                TerrainDetail terrainDetailByPositionNoCheck = base.Scenario.GetTerrainDetailByPositionNoCheck(this.Position);
                if ((terrainDetailByPositionNoCheck != null) && (terrainDetailByPositionNoCheck.GetFood(base.Scenario.Date.Season) >= (((this.RationDaysLeft + 1.5) * this.FoodCostPerDay) - this.Food)))
                {
                    this.LevyFood();
                }
            }
            if (this.ControlAvail() && ((this.Stunts.Count > 0) && (this.CurrentStunt == null)))
            {
                foreach (Stunt stunt in this.Stunts.GetStuntList().GetRandomList())
                {
                    if (this.HasStunt(stunt.ID) && stunt.IsAIable(this))
                    {
                        this.CurrentStunt = stunt;
                        this.ApplyCurrentStunt();
                        break;
                    }
                }
            }
        }

        private void PreActionAI()
        {
            if (this.CanOccupy())
            {
                this.Occupy();
            }
            if ((this.ControlAvail() && (this.Status == TroopStatus.埋伏)) && ((!this.HasHostileTroopInView() && (GameObject.Random(this.RationDaysLeft) == 0)) || (this.Morale < 0x4b)))
            {
                this.EndAmbush();
            }
            if (this.ControlAvail())
            {
                if (this.CutRoutewayDays <= 0)
                {
                    if (((((this.BelongedLegion.WillArchitecture.BelongedFaction == this.BelongedFaction) && (this.BelongedLegion.Kind == LegionKind.Defensive)) && ((this.RationDaysLeft + 3) > this.CutRoutewayDaysNeeded)) && (((this.CutRoutewayAvail() && !this.HasHostileTroopInView()) && (!this.HasHostileArchitectureInView() && this.BelongedLegion.WillArchitecture.HasHostileTroopsInView())) && !this.BelongedLegion.WillArchitecture.HigtViewTroop(this))) && (GameObject.Random(this.CutRoutewayDaysNeeded) == 0))
                    {
                        this.CutRouteway();
                    }
                }
                else if (GameObject.Random(this.HostileTroopInViewFightingForce * this.CutRoutewayDays) > GameObject.Random(this.FightingForce * 3))
                {
                    this.StopCutRouteway();
                }
            }
        }

        private void PrepareAI()
        {
            this.HasSupply = false;
            this.DistanceToWillArchitecture = base.Scenario.GetDistance(this.Position, this.WillArchitecture.ArchitectureArea);
            this.ViewingWillArchitecture = this.IsViewingWillArchitecture();
            this.ContactingWillArchitecture = this.IsContactingWillArchitecture();
            this.OffencingWillArchitecture = this.IsOffencingWillArchitecture();
            this.ContactHostileTroopCount = this.GetContactHostileTroops().Count;
            this.ContactFriendlyTroopCount = this.GetContactFriendlyTroops().Count;
            this.SetFriendlyTroopsInView();
            this.SetHostileTroopsInView();
            if (this.DistanceToWillArchitecture < 23.0)
            {
                this.CurrentPath = new List<Point>();
                this.EnableOneAdaptablility = true;
                this.pathFinder.FindFirstTierPath(this.Position, base.Scenario.GetClosestPoint(this.WillArchitecture.ArchitectureArea, this.Position), this.CurrentPath);
                this.EnableOneAdaptablility = false;
                if (this.CurrentPath.Count <= 1)
                {
                    this.CurrentPath = null;
                }
            }
            else
            {
                this.CurrentPath = null;
            }
        }

        private void PurifyAreaInfluences(Point p)
        {
            if (base.Scenario.MapTileData[p.X, p.Y].AreaInfluenceList != null)
            {
                foreach (AreaInfluenceData data in base.Scenario.MapTileData[p.X, p.Y].AreaInfluenceList)
                {
                    data.PurifyAreaInfluence(this);
                }
            }
        }

        public void PutOutFire()
        {
            int chance = this.TroopIntelligence + this.StratagemChanceIncrement;
            foreach (Point point in this.StratagemArea.Area)
            {
                if ((((this.BelongedFaction == null) && this.ViewArea.HasPoint(point)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(point))) && GameObject.Chance(chance))
                {
                    base.Scenario.ClearPositionFire(point);
                }
            }
            this.OperationDone = true;
            this.MovabilityLeft = -1;
            this.IncreaseStratagemExperience(2, true);
        }

        public string QuantityInInformationLevel(InformationLevel level)
        {
            switch (level)
            {
                case InformationLevel.未知:
                    return "----";

                case InformationLevel.无:
                    return "----";

                case InformationLevel.低:
                    return StaticMethods.GetNumberStringByGranularity(this.Quantity, 0x1388);

                case InformationLevel.中:
                    return StaticMethods.GetNumberStringByGranularity(this.Quantity, 0x3e8);

                case InformationLevel.高:
                    return StaticMethods.GetNumberStringByGranularity(this.Quantity, 100);

                case InformationLevel.全:
                    return this.Quantity.ToString();
            }
            return "----";
        }

        private TroopDamage ReceiveAttackDamage(TroopDamage receivedDamage)
        {
            int damage = receivedDamage.Damage;
            if (receivedDamage.SourceTroop.Army.Kind.ArrowOffence)
            {
                damage = (int) (damage * this.DefenceRateOnSubdueNubing);
            }
            else
            {
                switch (receivedDamage.SourceTroop.Army.Kind.Type)
                {
                    case MilitaryType.步兵:
                        damage = (int) (damage * this.DefenceRateOnSubdueBubing);
                        break;

                    case MilitaryType.弩兵:
                        damage = (int) (damage * this.DefenceRateOnSubdueNubing);
                        break;

                    case MilitaryType.骑兵:
                        damage = (int) (damage * this.DefenceRateOnSubdueQibing);
                        break;

                    case MilitaryType.水军:
                        damage = (int) (damage * this.DefenceRateOnSubdueShuijun);
                        break;

                    case MilitaryType.器械:
                        damage = (int) (damage * this.DefenceRateOnSubdueQixie);
                        break;

                    case MilitaryType.其他:
                        break;
                }
            }
        Label_00AC:
            receivedDamage.Damage = damage;
            if (receivedDamage.Damage > this.Quantity)
            {
                receivedDamage.Damage = this.Quantity;
            }
            if (receivedDamage.Damage <= 0)
            {
                receivedDamage.Damage = 1;
            }
            receivedDamage.Injury = ((damage + receivedDamage.FireDamage) * this.InjuryChance) / 100;
            if (receivedDamage.Critical && (receivedDamage.SourceTroop.RateOfInjuryOnCriticalStrike < 1f))
            {
                receivedDamage.Injury = (int) (receivedDamage.Injury * receivedDamage.SourceTroop.RateOfInjuryOnCriticalStrike);
            }
            if (receivedDamage.Injury > receivedDamage.DestinationTroop.Quantity)
            {
                receivedDamage.Injury = receivedDamage.DestinationTroop.Quantity;
            }
            return receivedDamage;
        }

        public void ReceiveFireDamage(float scale)
        {
            int decrement = (int) (this.Army.Kind.MinScale * scale);
            if (this.AfraidOfFire)
            {
                decrement *= 3;
            }
            if (this.RateOfFireProtection > 0f)
            {
                decrement = (int) (decrement * this.RateOfFireProtection);
            }
            this.DecreaseQuantity(decrement);
            this.IncreaseInjuryQuantity((decrement * this.InjuryChance) / 100);
            CheckTroopRout(this);
        }

        private void RefillFoodByArchitecture()
        {
            if ((this.BelongedFaction != null) && !this.Destroyed)
            {
                int increment = this.FoodMax - this.Food;
                if (increment > 0)
                {
                    ArchitectureList supplyArchitecturesByPositionAndFaction = base.Scenario.GetSupplyArchitecturesByPositionAndFaction(this.Position, this.BelongedFaction);
                    if (supplyArchitecturesByPositionAndFaction.Count > 0)
                    {
                        if (supplyArchitecturesByPositionAndFaction.Count > 1)
                        {
                            supplyArchitecturesByPositionAndFaction.PropertyName = "Food";
                            supplyArchitecturesByPositionAndFaction.IsNumber = true;
                            supplyArchitecturesByPositionAndFaction.ReSort();
                        }
                        Architecture architecture = supplyArchitecturesByPositionAndFaction[0] as Architecture;
                        if ((architecture.Food > 0) && ((architecture.Food + this.Food) >= this.FoodCostPerDay))
                        {
                            if (architecture.Food >= increment)
                            {
                                this.IncreaseFood(increment);
                                architecture.DecreaseFood(increment);
                            }
                            else
                            {
                                int num2 = (((architecture.Food + this.Food) / this.FoodCostPerDay) * this.FoodCostPerDay) - this.Food;
                                this.IncreaseFood(num2);
                                architecture.DecreaseFood(num2);
                            }
                        }
                    }
                }
            }
        }

        private void RefillFoodByRouteway()
        {
            int num = this.FoodMax - this.Food;
            if (num > 0)
            {
                List<RoutePoint> supplyRoutePointsByPositionAndFaction = base.Scenario.GetSupplyRoutePointsByPositionAndFaction(this.Position, this.BelongedFaction);
                if (supplyRoutePointsByPositionAndFaction.Count != 0)
                {
                    if (supplyRoutePointsByPositionAndFaction.Count == 1)
                    {
                        this.BelongedLegion.AddRoutewayCredit(supplyRoutePointsByPositionAndFaction[0].BelongedRouteway, supplyRoutePointsByPositionAndFaction[0].BelongedRouteway.Refill(this, supplyRoutePointsByPositionAndFaction[0].ConsumptionRate));
                    }
                    else
                    {
                        float consumptionRate = 10f;
                        RoutePoint point = null;
                        foreach (RoutePoint point2 in supplyRoutePointsByPositionAndFaction)
                        {
                            if (point2.BelongedRouteway.IsEnough(point2.ConsumptionRate, this.FoodCostPerDay - this.Food) && (point2.ConsumptionRate < consumptionRate))
                            {
                                consumptionRate = point2.ConsumptionRate;
                                point = point2;
                            }
                        }
                        if (point != null)
                        {
                            this.BelongedLegion.AddRoutewayCredit(point.BelongedRouteway, point.BelongedRouteway.Refill(this, point.ConsumptionRate));
                        }
                    }
                }
            }
        }

        public void RefreshAllData()
        {
            this.RefreshTroopAbility();
            this.RefreshOffence();
            this.RefreshDefence();
            this.RefreshCriticalStrikeChance();
            this.RefreshAntiCriticalStrikeChance();
            this.RefreshChaosAfterCriticalStrikeChance();
            this.RefreshAvoidSurroundedChance();
            this.RefreshChaosAfterSurroundAttackChance();
            this.RefreshStratagemChanceIncrement();
            this.RefreshAntiStratagemChanceIncrement();
            this.RefreshChaosAfterStratagemSuccessChance();
        }

        private void RefreshAntiCriticalStrikeChance()
        {
            this.antiCriticalStrikeChance = SquareChance(this.TroopCommand, 0x3e8) + this.Leader.Calmness;
            this.antiCriticalStrikeChance += this.ChanceDecrementOfCriticalStrike;
            this.antiCriticalStrikeChance += this.ChanceDecrementOfCriticalStrikeByViewArea;
            if (this.BelongedFaction != null)
            {
                this.antiCriticalStrikeChance += this.BelongedFaction.IncrementOfAntiCriticalStrikeChance;
                if (this.CombatMethodApplied)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            this.antiCriticalStrikeChance += this.BelongedFaction.AntiCriticalStrikeChanceIncrementWhileCombatMethodOfBubing;
                            break;

                        case MilitaryType.弩兵:
                            this.antiCriticalStrikeChance += this.BelongedFaction.AntiCriticalStrikeChanceIncrementWhileCombatMethodOfNubing;
                            break;

                        case MilitaryType.骑兵:
                            this.antiCriticalStrikeChance += this.BelongedFaction.AntiCriticalStrikeChanceIncrementWhileCombatMethodOfQibing;
                            break;

                        case MilitaryType.水军:
                            this.antiCriticalStrikeChance += this.BelongedFaction.AntiCriticalStrikeChanceIncrementWhileCombatMethodOfShuijun;
                            break;

                        case MilitaryType.器械:
                            this.antiCriticalStrikeChance += this.BelongedFaction.AntiCriticalStrikeChanceIncrementWhileCombatMethodOfQixie;
                            break;
                    }
                }
            }
            if (this.antiCriticalStrikeChance > 100)
            {
                this.antiCriticalStrikeChance = 100;
            }
        }

        private void RefreshAntiStratagemChanceIncrement()
        {
            this.antiStratagemChanceIncrement = this.ChanceDecrementOfStratagem;
            this.antiStratagemChanceIncrement += this.ChanceDecrementOfStratagemByViewArea;
            if (this.BelongedFaction != null)
            {
                this.antiStratagemChanceIncrement += this.BelongedFaction.IncrementOfResistStratagemChance;
            }
            if (this.antiStratagemChanceIncrement > 100)
            {
                this.antiStratagemChanceIncrement = 100;
            }
        }

        private void RefreshAvoidSurroundedChance()
        {
            this.avoidSurroundedChance = this.IncrementOfAvoidSurroundedChance;
            if (this.avoidSurroundedChance > 100)
            {
                this.avoidSurroundedChance = 100;
            }
        }

        private void RefreshChaosAfterCriticalStrikeChance()
        {
            this.chaosAfterCriticalStrikeChance = this.ChanceIncrementOfChaosAfterCriticalStrike;
            if (this.chaosAfterCriticalStrikeChance > 100)
            {
                this.chaosAfterCriticalStrikeChance = 100;
            }
        }

        private void RefreshChaosAfterStratagemSuccessChance()
        {
            this.chaosAfterStratagemSuccessChance = this.ChanceIncrementOfChaosAfterStratagem;
            if (this.chaosAfterStratagemSuccessChance > 100)
            {
                this.chaosAfterStratagemSuccessChance = 100;
            }
        }

        private void RefreshChaosAfterSurroundAttackChance()
        {
            this.chaosAfterSurroundAttackChance = this.IncrementOfChaosAfterSurroundAttackChance;
            if (this.chaosAfterSurroundAttackChance > 100)
            {
                this.chaosAfterSurroundAttackChance = 100;
            }
        }

        private void RefreshCriticalStrikeChance()
        {
            this.criticalStrikeChance = SquareChance(this.TroopStrength, 0x3e8) + this.Leader.Braveness;
            this.criticalStrikeChance += this.ChanceIncrementOfCriticalStrike;
            this.criticalStrikeChance += this.ChanceIncrementOfCriticalStrikeByViewArea;
            this.criticalStrikeChance += this.CriticalChanceIncrementOfTerrain;
            if (this.BelongedFaction != null)
            {
                this.criticalStrikeChance += this.BelongedFaction.IncrementOfCriticalStrikeChance;
                if (this.CombatMethodApplied)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            this.criticalStrikeChance += this.BelongedFaction.CriticalStrikeChanceIncrementWhileCombatMethodOfBubing;
                            break;

                        case MilitaryType.弩兵:
                            this.criticalStrikeChance += this.BelongedFaction.CriticalStrikeChanceIncrementWhileCombatMethodOfNubing;
                            break;

                        case MilitaryType.骑兵:
                            this.criticalStrikeChance += this.BelongedFaction.CriticalStrikeChanceIncrementWhileCombatMethodOfQibing;
                            break;

                        case MilitaryType.水军:
                            this.criticalStrikeChance += this.BelongedFaction.CriticalStrikeChanceIncrementWhileCombatMethodOfShuijun;
                            break;

                        case MilitaryType.器械:
                            this.criticalStrikeChance += this.BelongedFaction.CriticalStrikeChanceIncrementWhileCombatMethodOfQixie;
                            break;
                    }
                }
            }
            if (this.criticalStrikeChance > 100)
            {
                this.criticalStrikeChance = 100;
            }
        }

        public void RefreshDataOfAreaInfluence()
        {
            this.RefreshOffence();
            this.RefreshDefence();
            this.RefreshCriticalStrikeChance();
            this.RefreshAntiCriticalStrikeChance();
            this.RefreshStratagemChanceIncrement();
            this.RefreshAntiStratagemChanceIncrement();
        }

        internal void RefreshDefence()
        {
            this.defence = this.Army.Defence;
            this.defence += this.TechnologyIncrement;
            this.defence += this.IncrementDefencePerReputationUnit * (this.Leader.Reputation / 0x3e8);
            this.defence = (this.defence * SquareChance(this.TroopCommand + this.Morale, 100)) / 400;
            this.defence = (int) (this.defence * ((this.RateOfDefence + this.DefenceRateIncrementByViewArea) + this.DefenceRateDecrementByViewArea));
            this.defence = (int) (this.defence * this.terrainRate);
            if (this.Army.Quantity < this.Army.Kind.MinScale)
            {
                this.defence = (this.defence * this.Army.Quantity) / this.Army.Kind.MinScale;
            }
            if ((this.StartingArchitecture != null) && ((this.StartingArchitecture.LocationState.LinkedRegion.RegionCore != null) && this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.RegionCoreEffectAvail()))
            {
                if (this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.IsFriendly(this.BelongedFaction))
                {
                    this.defence += (int) (this.defence * 0.2);
                }
                else if (this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.IsHostile(this.BelongedFaction))
                {
                    this.defence -= (int) (this.defence * 0.2);
                }
            }
            if (this.MultipleOfDefenceOnArchitecture > 1)
            {
                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.Position);
                if ((architectureByPositionNoCheck != null) && (architectureByPositionNoCheck.Endurance > 0))
                {
                    this.defence *= this.MultipleOfDefenceOnArchitecture;
                }
            }
            if (!((this.Status != TroopStatus.混乱) || this.DefenceNoChangeOnChaos))
            {
                this.defence = (int) (this.defence * 0.8f);
            }
            this.defence = (int) (this.defence * this.TempRateOfDefence);
            if (this.OutburstDefenceMultiple > 1)
            {
                this.defence *= this.OutburstDefenceMultiple;
            }
            if (this.BelongedFaction != null)
            {
                if (this.CombatMethodApplied)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateWhileCombatMethodOfBubing));
                            break;

                        case MilitaryType.弩兵:
                            this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateWhileCombatMethodOfNubing));
                            break;

                        case MilitaryType.骑兵:
                            this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateWhileCombatMethodOfQibing));
                            break;

                        case MilitaryType.水军:
                            this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateWhileCombatMethodOfShuijun));
                            break;

                        case MilitaryType.器械:
                            this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateWhileCombatMethodOfQixie));
                            break;
                    }
                }
                switch (this.Army.Kind.Type)
                {
                    case MilitaryType.步兵:
                        this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateOfBubing));
                        if (this.StartingArchitecture != null)
                        {
                            this.defence = (int) (this.defence * (1f + this.StartingArchitecture.RateIncrementOfNewBubingTroopDefence));
                        }
                        break;

                    case MilitaryType.弩兵:
                        this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateOfNubing));
                        if (this.StartingArchitecture != null)
                        {
                            this.defence = (int) (this.defence * (1f + this.StartingArchitecture.RateIncrementOfNewNubingTroopDefence));
                        }
                        break;

                    case MilitaryType.骑兵:
                        this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateOfQibing));
                        if (this.StartingArchitecture != null)
                        {
                            this.defence = (int) (this.defence * (1f + this.StartingArchitecture.RateIncrementOfNewQibingTroopDefence));
                        }
                        break;

                    case MilitaryType.水军:
                        this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateOfShuijun));
                        if (this.StartingArchitecture != null)
                        {
                            this.defence = (int) (this.defence * (1f + this.StartingArchitecture.RateIncrementOfNewShuijunTroopDefence));
                        }
                        break;

                    case MilitaryType.器械:
                        this.defence = (int) (this.defence * (1f + this.BelongedFaction.DefenceRateOfQixie));
                        if (this.StartingArchitecture != null)
                        {
                            this.defence = (int) (this.defence * (1f + this.StartingArchitecture.RateIncrementOfNewQixieTroopDefence));
                        }
                        break;
                }
            }
            if (!base.Scenario.IsPlayer(this.BelongedFaction))
            {
                this.defence = (int) (this.defence * Parameters.AITroopDefenceRate);
            }
            if (this.defence <= 0)
            {
                this.defence = 1;
            }
        }

        internal void RefreshOffence()
        {
            this.offence = this.Army.Offence;
            this.offence += this.TechnologyIncrement;
            this.offence += this.IncrementOffencePerReputationUnit * (this.Leader.Reputation / 0x3e8);
            this.offence = (this.offence * SquareChance(this.TroopStrength + this.Morale, 100)) / 400;
            this.offence = (int) (this.offence * ((this.RateOfOffence + this.OffenceRateIncrementByViewArea) + this.OffenceRateDecrementByViewArea));
            this.offence = (int) (this.offence * this.terrainRate);
            if (this.Army.Quantity < this.Army.Kind.MinScale)
            {
                this.offence = (this.offence * this.Army.Quantity) / this.Army.Kind.MinScale;
            }
            if ((this.StartingArchitecture != null) && ((this.StartingArchitecture.LocationState.LinkedRegion.RegionCore != null) && this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.RegionCoreEffectAvail()))
            {
                if (this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.IsFriendly(this.BelongedFaction))
                {
                    this.offence += (int) (this.offence * 0.2);
                }
                else if (this.StartingArchitecture.LocationState.LinkedRegion.RegionCore.IsHostile(this.BelongedFaction))
                {
                    this.offence -= (int) (this.offence * 0.2);
                }
            }
            if (this.Status == TroopStatus.混乱)
            {
                this.offence = (int) (this.offence * 0.5f);
            }
            this.offence = (int) (this.offence * this.TempRateOfOffence);
            if (this.OutburstOffenceMultiple > 1)
            {
                this.offence *= this.OutburstOffenceMultiple;
            }
            if (this.BelongedFaction != null)
            {
                if (this.CombatMethodApplied)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateWhileCombatMethodOfBubing));
                            break;

                        case MilitaryType.弩兵:
                            this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateWhileCombatMethodOfNubing));
                            break;

                        case MilitaryType.骑兵:
                            this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateWhileCombatMethodOfQibing));
                            break;

                        case MilitaryType.水军:
                            this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateWhileCombatMethodOfShuijun));
                            break;

                        case MilitaryType.器械:
                            this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateWhileCombatMethodOfQixie));
                            break;
                    }
                }
                switch (this.Army.Kind.Type)
                {
                    case MilitaryType.步兵:
                        this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateOfBubing));
                        if (this.StartingArchitecture != null)
                        {
                            this.offence = (int) (this.offence * (1f + this.StartingArchitecture.RateIncrementOfNewBubingTroopOffence));
                        }
                        break;

                    case MilitaryType.弩兵:
                        this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateOfNubing));
                        if (this.StartingArchitecture != null)
                        {
                            this.offence = (int) (this.offence * (1f + this.StartingArchitecture.RateIncrementOfNewNubingTroopOffence));
                        }
                        break;

                    case MilitaryType.骑兵:
                        this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateOfQibing));
                        if (this.StartingArchitecture != null)
                        {
                            this.offence = (int) (this.offence * (1f + this.StartingArchitecture.RateIncrementOfNewQibingTroopOffence));
                        }
                        break;

                    case MilitaryType.水军:
                        this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateOfShuijun));
                        if (this.StartingArchitecture != null)
                        {
                            this.offence = (int) (this.offence * (1f + this.StartingArchitecture.RateIncrementOfNewShuijunTroopOffence));
                        }
                        break;

                    case MilitaryType.器械:
                        this.offence = (int) (this.offence * (1f + this.BelongedFaction.OffenceRateOfQixie));
                        if (this.StartingArchitecture != null)
                        {
                            this.offence = (int) (this.offence * (1f + this.StartingArchitecture.RateIncrementOfNewQixieTroopOffence));
                        }
                        break;
                }
            }
            if (!base.Scenario.IsPlayer(this.BelongedFaction))
            {
                this.offence = (int) (this.offence * Parameters.AITroopOffenceRate);
            }
            if (this.offence <= 0)
            {
                this.offence = 1;
            }
        }

        private void RefreshStratagemChanceIncrement()
        {
            this.stratagemChanceIncrement = this.ChanceIncrementOfStratagem;
            this.stratagemChanceIncrement += this.ChanceIncrementOfStratagemByViewArea;
            if (this.BelongedFaction != null)
            {
                this.stratagemChanceIncrement += this.BelongedFaction.IncrementOfStratagemSuccessChance;
            }
            if (this.stratagemChanceIncrement > 100)
            {
                this.stratagemChanceIncrement = 100;
            }
        }

        public void RefreshTerrainRelatedData()
        {
            this.RefreshOffence();
            this.RefreshDefence();
            this.RefreshCriticalStrikeChance();
        }

        public void RefreshTroopAbility()
        {
            this.RefreshTroopStrength();
            this.RefreshTroopCommand();
            this.RefreshTroopIntelligence();
        }

        public void RefreshTroopCommand()
        {
            this.troopCommand = this.Leader.Command;
            if (this.PersonCount > 1)
            {
                Person maxCommandPerson = this.Persons.GetMaxCommandPerson();
                if (maxCommandPerson != this.Leader)
                {
                    if ((maxCommandPerson.Brother >= 0) && (maxCommandPerson.Brother == this.Leader.Brother))
                    {
                        this.troopCommand = maxCommandPerson.Command;
                    }
                    else if (maxCommandPerson.ClosePersons.IndexOf(this.Leader.ID) >= 0)
                    {
                        int num = maxCommandPerson.Command - this.Leader.Command;
                        this.troopCommand += (int) (num * 0.5f);
                    }
                }
            }
        }

        public void RefreshTroopIntelligence()
        {
            this.troopIntelligence = this.Leader.Intelligence;
            if (this.PersonCount > 1)
            {
                Person maxIntelligencePerson = this.Persons.GetMaxIntelligencePerson();
                if (maxIntelligencePerson != this.Leader)
                {
                    int num = maxIntelligencePerson.Intelligence - this.Leader.Intelligence;
                    this.troopIntelligence += (int) (num * this.Leader.Character.IntelligenceRate);
                }
            }
        }

        public void RefreshTroopStrength()
        {
            this.troopStrength = this.Leader.Strength;
            if (this.PersonCount > 1)
            {
                Person maxStrengthPerson = this.Persons.GetMaxStrengthPerson();
                if (maxStrengthPerson != this.Leader)
                {
                    if ((maxStrengthPerson.Brother >= 0) && (maxStrengthPerson.Brother == this.Leader.Brother))
                    {
                        this.troopStrength = maxStrengthPerson.Strength;
                    }
                    else if (maxStrengthPerson.ClosePersons.IndexOf(this.Leader.ID) >= 0)
                    {
                        int num = maxStrengthPerson.Strength - this.Leader.Strength;
                        this.troopStrength += (int) (num * 0.5f);
                    }
                }
            }
        }

        public void RefreshViewArchitectureRelatedArea()
        {
            this.FinalizeViewArea();
            this.InitializeViewArea();
        }

        public void RefreshWithPersonList(GameObjectList personList)
        {
            Point position = this.Position;
            Point destination = this.Destination;
            Point realDestination = this.RealDestination;
            Architecture startingArchitecture = this.StartingArchitecture;
            int iD = base.ID;
            Person leader = this.Leader;
            Stunt currentStunt = this.CurrentStunt;
            int stuntDayLeft = this.StuntDayLeft;
            this.Destroy();
            this.Destroyed = false;
            this.realDestination = realDestination;
            this.destination = destination;
            this.position = position;
            this.StartingArchitecture = startingArchitecture;
            base.ID = iD;
            this.Persons.Clear();
            if (!personList.HasGameObject(leader))
            {
                if (personList.Count > 1)
                {
                    personList.PropertyName = "FightingForce";
                    personList.IsNumber = true;
                    personList.ReSort();
                }
                this.Leader = personList[0] as Person;
            }
            foreach (Person person2 in personList)
            {
                this.AddPerson(person2);
            }
            this.Persons.ApplyInfluences();
            if ((currentStunt != null) && (stuntDayLeft > 0))
            {
                this.CurrentStunt = currentStunt;
                this.StuntDayLeft = stuntDayLeft;
            }
            this.Initialize();
        }

        public static bool ReLaunchFirstPathFinder(Point start, Point end)
        {
            return (GetDistance(start, end) < ((GameObjectConsts.SecondTierSquareSize * GameObjectConsts.LaunchTierFinderDistance) / 2));
        }

        public static bool ReLaunchSecondPathFinder(Point start, Point end)
        {
            return (GetDistance(start, end) < ((GameObjectConsts.ThirdTierSquareSize * GameObjectConsts.LaunchTierFinderDistance) / 2));
        }

        private void ReleaseCaptiveBeforeBeRouted()
        {
            if (this.HasCaptive())
            {
                PersonList personlist = new PersonList();
                foreach (Captive captive in this.Captives.GetList())
                {
                    if (((captive.CaptivePerson != null) && (captive.CaptiveFaction != null)) && (captive.CaptiveFaction.Capital != null))
                    {
                        personlist.Add(captive.CaptivePerson);
                        captive.CaptivePerson.MoveToArchitecture(captive.CaptiveFaction.Capital);
                        captive.CaptivePerson.BelongedCaptive = null;
                        this.RemoveCaptive(captive);
                        this.BelongedFaction.RemoveCaptive(captive);
                        captive.CaptiveFaction.RemoveSelfCaptive(captive);
                        base.Scenario.Captives.Remove(captive);
                    }
                }
                if ((personlist.Count > 0) && (this.OnReleaseCaptive != null))
                {
                    this.OnReleaseCaptive(this, personlist);
                }
            }
        }

        private void RemoveAreaInfluences(Point p)
        {
            base.Scenario.RemovePositionAreaInfluence(this, p);
        }

        public void RemoveCaptive(Captive captive)
        {
            this.Captives.Remove(captive);
            captive.LocationTroop = null;
        }

        public void RemovePerson(Person person)
        {
            this.Persons.Remove(person);
            person.LocationTroop = null;
        }

        public void ResetAnimationIndex()
        {
            this.currentTroopAnimationIndex = 0;
            this.currentTroopStayIndex = 0;
        }

        private void ResetDayInfluence()
        {
            this.DayLocationLoyaltyNoChange = false;
        }

        private void ResetDirection(Point position)
        {
            int num3;
            int num4;
            int num = position.X - this.Position.X;
            int num2 = position.Y - this.Position.Y;
            if (Math.Abs(num) == Math.Abs(num2))
            {
                if (num == 0)
                {
                    num3 = 0;
                    num4 = 0;
                }
                else
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = (num2 > 0) ? 1 : -1;
                }
            }
            else if (Math.Abs(num) > Math.Abs(num2))
            {
                if (num2 == 0)
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = 0;
                }
                else if ((Math.Abs(num) / Math.Abs(num2)) < 2)
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = (num2 > 0) ? 1 : -1;
                }
                else
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = 0;
                }
            }
            else if (num == 0)
            {
                num3 = 0;
                num4 = (num2 > 0) ? 1 : -1;
            }
            else if ((Math.Abs(num2) / Math.Abs(num)) < 2)
            {
                num3 = (num > 0) ? 1 : -1;
                num4 = (num2 > 0) ? 1 : -1;
            }
            else
            {
                num3 = 0;
                num4 = (num2 > 0) ? 1 : -1;
            }
            this.SetDirection(num3, num4);
        }

        private void ResetDirectionArchitecture()
        {
            int num3;
            int num4;
            int num = this.OrientationPosition.X - this.Position.X;
            int num2 = this.OrientationPosition.Y - this.Position.Y;
            if (Math.Abs(num) == Math.Abs(num2))
            {
                if (num == 0)
                {
                    num3 = 0;
                    num4 = 0;
                }
                else
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = (num2 > 0) ? 1 : -1;
                }
            }
            else if (Math.Abs(num) > Math.Abs(num2))
            {
                if (num2 == 0)
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = 0;
                }
                else if ((Math.Abs(num) / Math.Abs(num2)) < 2)
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = (num2 > 0) ? 1 : -1;
                }
                else
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = 0;
                }
            }
            else if (num == 0)
            {
                num3 = 0;
                num4 = (num2 > 0) ? 1 : -1;
            }
            else if ((Math.Abs(num2) / Math.Abs(num)) < 2)
            {
                num3 = (num > 0) ? 1 : -1;
                num4 = (num2 > 0) ? 1 : -1;
            }
            else
            {
                num3 = 0;
                num4 = (num2 > 0) ? 1 : -1;
            }
            this.SetDirection(num3, num4);
        }

        private void ResetDirectionTroop(Troop troop)
        {
            if (this != troop)
            {
                int num3;
                int num4;
                int num = troop.Position.X - this.Position.X;
                int num2 = troop.Position.Y - this.Position.Y;
                if (Math.Abs(num) == Math.Abs(num2))
                {
                    if (num == 0)
                    {
                        num3 = 0;
                        num4 = 0;
                    }
                    else
                    {
                        num3 = (num > 0) ? 1 : -1;
                        num4 = (num2 > 0) ? 1 : -1;
                    }
                }
                else if (Math.Abs(num) > Math.Abs(num2))
                {
                    if (num2 == 0)
                    {
                        num3 = (num > 0) ? 1 : -1;
                        num4 = 0;
                    }
                    else if ((Math.Abs(num) / Math.Abs(num2)) < 2)
                    {
                        num3 = (num > 0) ? 1 : -1;
                        num4 = (num2 > 0) ? 1 : -1;
                    }
                    else
                    {
                        num3 = (num > 0) ? 1 : -1;
                        num4 = 0;
                    }
                }
                else if (num == 0)
                {
                    num3 = 0;
                    num4 = (num2 > 0) ? 1 : -1;
                }
                else if ((Math.Abs(num2) / Math.Abs(num)) < 2)
                {
                    num3 = (num > 0) ? 1 : -1;
                    num4 = (num2 > 0) ? 1 : -1;
                }
                else
                {
                    num3 = 0;
                    num4 = (num2 > 0) ? 1 : -1;
                }
                this.SetDirection(num3, num4);
                troop.SetDirection(-num3, -num4);
            }
        }

        public void ResetOutburstParametres()
        {
            this.CurrentOutburstKind = OutburstKind.无;
            this.OutburstOffenceMultiple = 1;
            this.OutburstDefenceMultiple = 1;
            this.OutburstNeverBeIntoChaos = false;
            this.OutburstPreventCriticalStrike = false;
        }

        private void ResetTerrainData()
        {
            switch (base.Scenario.GetTerrainKindByPosition(this.Position))
            {
                case TerrainKind.平原:
                    this.terrainRate = this.PlainRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfPlain;
                    break;

                case TerrainKind.草原:
                    this.terrainRate = this.GrasslandRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfGrassland;
                    break;

                case TerrainKind.森林:
                    this.terrainRate = this.ForrestRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfForrest;
                    break;

                case TerrainKind.湿地:
                    this.terrainRate = this.MarshRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfMarsh;
                    break;

                case TerrainKind.山地:
                    this.terrainRate = this.MountainRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfMountain;
                    break;

                case TerrainKind.水域:
                    this.terrainRate = this.WaterRate + this.RateIncrementOfTerrainRateOnWater;
                    this.terrainRate += this.RateIncrementOfRateOnWater;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfWater;
                    break;

                case TerrainKind.峻岭:
                    this.terrainRate = this.RidgeRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfRidge;
                    break;

                case TerrainKind.荒地:
                    this.terrainRate = this.WastelandRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfWasteland;
                    break;

                case TerrainKind.沙漠:
                    this.terrainRate = this.DesertRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfDesert;
                    break;

                case TerrainKind.栈道:
                    this.terrainRate = this.CliffRate;
                    this.CriticalChanceIncrementOfTerrain = this.CriticalChanceIncrementOfCliff;
                    break;
            }
            if ((this.BelongedFaction != null) && (this.terrainRate < 1f))
            {
                this.terrainRate += this.BelongedFaction.RateIncrementOfTerrainRate;
                if (this.terrainRate > 1f)
                {
                    this.terrainRate = 1f;
                }
            }
        }

        public string SavePersonsToString()
        {
            string str = "";
            foreach (Person person in this.Persons)
            {
                str = str + person.ID.ToString() + " ";
            }
            return str;
        }

        public void SeasonEvent()
        {
        }

        private ArchitectureDamage SendAttackDamage(Architecture architecture)
        {
            this.RecentlyFighting = 3;
            ArchitectureDamage damage = new ArchitectureDamage();
            damage.SourceTroop = this;
            damage.DestinationArchitecture = architecture;
            damage.Critical = GameObject.Chance(this.CriticalStrikeChance - (architecture.AreaCount * 3));
            damage.Position = this.OrientationPosition;
            if (architecture.Domination > 0)
            {
                int num = (int) (((((this.Offence * 10) * Parameters.ArchitectureDamageRate) * this.ArchitectureDamageRate) * this.StuntArchitectureDamageRate) / ((float) architecture.Domination));
                if (!base.Scenario.IsPlayer(this.BelongedFaction))
                {
                    num = (int) (num * Parameters.AIArchitectureDamageRate);
                }
                if (damage.Critical)
                {
                    this.PreAction = TroopPreAction.暴击;
                    num = (int) ((num * 1.5f) * this.RateOfCriticalArchitectureDamage);
                    if (architecture.Kind.HasDomination)
                    {
                        damage.DominationDown = this.DominationDecrementOfCriticalStrike;
                    }
                    if (this.OnCriticalStrike != null)
                    {
                        this.OnCriticalStrike(this, null);
                    }
                }
                damage.Damage = num;
                if (damage.Damage <= 0)
                {
                    damage.Damage = 1;
                }
            }
            else
            {
                damage.Damage = architecture.Endurance;
            }
            if ((architecture.BelongedFaction != null) && !this.AirOffence)
            {
                damage.CounterDamage = (int) ((((architecture.Endurance + architecture.Morale) * this.Army.Kind.ArchitectureCounterDamageRate) * 15f) / ((float) this.Defence));
                if (damage.CounterDamage > this.Quantity)
                {
                    damage.CounterDamage = this.Quantity;
                }
                damage.CounterInjury = (damage.CounterDamage * this.InjuryChance) / 100;
            }
            int num2 = (2 + (damage.Critical ? 1 : 0)) + (this.CombatMethodApplied ? 1 : 0);
            this.IncreaseAttackExperience(num2 * 2);
            return damage;
        }

        private TroopDamage SendAttackDamage(Troop troop, bool counter)
        {
            this.RecentlyFighting = 3;
            troop.RecentlyFighting = 3;
            TroopDamage damage = new TroopDamage();
            damage.SourceTroop = this;
            damage.DestinationTroop = troop;
            damage.Counter = counter;
            damage.AntiAttack = GameObject.Chance(troop.ChanceOfBlockAttack);
            damage.AntiArrowAttack = this.ArrowOffence && (troop.IsAntiArrowAttack || GameObject.Chance(troop.ChanceOfBlockArrowAttack));
            damage.AntiCounterAttack = !counter && this.IsAntiCounterAttack;
            damage.Critical = (!counter && !troop.OutburstPreventCriticalStrike) && (GameObject.Chance(this.ChanceOfMustCriticalStrike) || GameObject.Chance(this.CriticalStrikeChance - troop.AntiCriticalStrikeChance));
            damage.OnFire = GameObject.Chance((this.ChanceOfOnFire > this.BaseChanceOfOnFire) ? this.ChanceOfOnFire : this.BaseChanceOfOnFire);
            damage.Chaos = GameObject.Chance(this.ChanceOfChaosAttack);
            if (this.Status == TroopStatus.埋伏)
            {
                this.Status = TroopStatus.一般;
                damage.Waylay = true;
                if (!damage.Critical)
                {
                    this.PreAction = TroopPreAction.伏击;
                }
            }
            if (troop.Defence <= 0)
            {
                damage.Damage = troop.Quantity;
                return damage;
            }
            int defence = troop.Defence;
            if ((this.BaseDefenceConsidered > 0) && (this.DefenceConsidered > 0))
            {
                int num2 = (this.BaseDefenceConsidered < this.DefenceConsidered) ? this.BaseDefenceConsidered : this.DefenceConsidered;
                if (defence > num2)
                {
                    defence = num2;
                }
            }
            else if (this.BaseDefenceConsidered > 0)
            {
                if (defence > this.BaseDefenceConsidered)
                {
                    defence = this.BaseDefenceConsidered;
                }
            }
            else if (this.DefenceConsidered > 0)
            {
                if (defence > this.DefenceConsidered)
                {
                    defence = this.DefenceConsidered;
                }
            }
            else if (GameObject.Chance(this.ChanceOfFixDefenceAttack) && (defence > 100))
            {
                defence = 100;
            }
            damage.SourceOffence = this.Offence;
            if ((!troop.StuntAvoidSurround && !counter) && (this.StuntMustSurround || !GameObject.Chance(troop.AvoidSurroundedChance)))
            {
                TroopList surroundAttackingTroop = this.GetSurroundAttackingTroop(troop);
                if (surroundAttackingTroop.Count >= 3)
                {
                    int num3 = 0;
                    damage.Surround = true;
                    damage.DestinationMoraleChange -= 5 * ((surroundAttackingTroop.Count - 3) + 1);
                    troop.Effect = TroopEffect.被包围;
                    foreach (Troop troop2 in surroundAttackingTroop)
                    {
                        if (troop2 != this)
                        {
                            damage.SurroudingList.Add(troop2);
                            troop2.Surrounding = true;
                            damage.SourceOffence += StaticMethods.GetRandomValue(troop2.Offence, 4);
                            num3 += StaticMethods.GetRandomValue(troop2.ChaosAfterSurroundAttackChance, 2);
                        }
                    }
                    damage.Chaos = GameObject.Chance(this.ChaosAfterSurroundAttackChance + num3);
                }
            }
            int num4 = (int) (((damage.SourceOffence * 500) * Parameters.TroopDamageRate) / ((float) defence));
            switch (troop.Army.Kind.Type)
            {
                case MilitaryType.步兵:
                    num4 = (int) (num4 * this.OffenceRateOnSubdueBubing);
                    break;

                case MilitaryType.弩兵:
                    num4 = (int) (num4 * this.OffenceRateOnSubdueNubing);
                    break;

                case MilitaryType.骑兵:
                    num4 = (int) ((num4 * this.OffenceRateOnSubdueQibing) * ((this.RateOfQibingDamage > this.BaseRateOfQibingDamage) ? this.RateOfQibingDamage : this.BaseRateOfQibingDamage));
                    break;

                case MilitaryType.水军:
                    num4 = (int) (num4 * this.OffenceRateOnSubdueShuijun);
                    break;

                case MilitaryType.器械:
                    num4 = (int) (num4 * this.OffenceRateOnSubdueQixie);
                    break;
            }
            if (this.MoraleDownOfAttack > 0)
            {
                damage.DestinationMoraleChange -= this.MoraleDownOfAttack;
            }
            if (damage.OnFire)
            {
                int num5 = (int) ((troop.Army.Kind.MinScale * Parameters.FireDamageScale) * base.Scenario.GetTerrainDetailByPositionNoCheck(troop.Position).FireDamageRate);
                if (troop.AfraidOfFire)
                {
                    num5 *= 3;
                }
                if (troop.RateOfFireProtection > 0f)
                {
                    num5 = (int) (num5 * troop.RateOfFireProtection);
                }
                damage.FireDamage = num5;
            }
            if (damage.Critical)
            {
                this.PreAction = TroopPreAction.暴击;
                num4 = (int) ((num4 * 1.5f) * troop.RateOfCriticalDamageReceived);
                if (!(damage.Chaos || !GameObject.Chance(this.ChaosAfterCriticalStrikeChance)))
                {
                    damage.Chaos = true;
                }
                if (this.MoraleDecrementOfCriticalStrike > 0)
                {
                    damage.DestinationMoraleChange -= this.MoraleDecrementOfCriticalStrike;
                }
                if ((!this.IsFriendly(troop.BelongedFaction) && !this.AirOffence) && GameObject.Chance(20))
                {
                    Person maxStrengthPerson = this.Persons.GetMaxStrengthPerson();
                    Person destination = troop.Persons.GetMaxStrengthPerson();
                    if (((maxStrengthPerson != null) && (destination != null)) && (GameObject.Random(GameObject.Square(destination.Calmness)) < GameObject.Random(0x19)))
                    {
                        int chance = Person.ChanlengeWinningChance(maxStrengthPerson, destination);
                        if ((maxStrengthPerson.Character.ChallengeChance + chance) >= 60)
                        {
                            bool flag = GameObject.Chance(chance);
                            damage.ChallengeHappened = true;
                            damage.ChallengeResult = flag;
                            damage.ChallengeSourcePerson = maxStrengthPerson;
                            damage.ChallengeDestinationPerson = destination;
                            if (flag)
                            {
                                damage.SourceMoraleChange += 20;
                                damage.DestinationMoraleChange -= 20;
                            }
                            else
                            {
                                damage.SourceMoraleChange -= 20;
                                damage.DestinationMoraleChange += 20;
                            }
                        }
                    }
                }
            }
            if (damage.Waylay)
            {
                damage.DestinationMoraleChange -= 10;
                if (troop.NeverBeIntoChaosWhileWaylay)
                {
                    damage.Chaos = false;
                }
                else if (!this.Army.Kind.AirOffence)
                {
                    damage.Chaos = this.InevitableChaosOnWaylay || GameObject.Chance(30);
                }
            }
            if (damage.Counter)
            {
                num4 = (int) (num4 * 0.5f);
            }
            if (!(counter || (this.AttackDecrementOfCombativity <= 0)))
            {
                damage.CombativityDown += this.AttackDecrementOfCombativity;
            }
            if (counter && (this.CounterAttackDecrementOfCombativity > 0))
            {
                damage.CounterCombativityDown += this.CounterAttackDecrementOfCombativity;
            }
            if (!troop.HasCombatTitle)
            {
                if (this.CombativityDecrementOnPower > 0)
                {
                    damage.CombativityDown += this.CombativityDecrementOnPower;
                }
                if (this.MoraleDecrementOnPrestige > 0)
                {
                    damage.DestinationMoraleChange -= this.MoraleDecrementOnPrestige;
                }
            }
            if (GameObject.Chance(this.ChanceOfTrippleDamage))
            {
                num4 *= 3;
            }
            else if (GameObject.Chance(this.ChanceOfDoubleDamage))
            {
                num4 *= 2;
            }
            if (GameObject.Chance(troop.ChanceOfHalfDamage))
            {
                num4 /= 2;
            }
            damage.Damage = num4;
            return damage;
        }

        public void SetAmbush()
        {
            this.Status = TroopStatus.埋伏;
            this.OperationDone = true;
            this.MovabilityLeft = -1;
            this.IncreaseStratagemExperience(2, true);
        }

        public void SetArmy(Military m)
        {
            this.army = m;
        }

        public void SetChaos(int days)
        {
            if (!this.Destroyed && (!this.NeverBeIntoChaos && !this.OutburstNeverBeIntoChaos))
            {
                bool deepChaos = this.Status == TroopStatus.混乱;
                this.Status = TroopStatus.混乱;
                if (this.ChaosLastOneDay)
                {
                    days = 1;
                }
                this.chaosDayLeft += days;
                this.OperationDone = true;
                this.MovabilityLeft = -1;
                this.RefreshOffence();
                this.RefreshDefence();
                this.CutRoutewayDays = 0;
                if (this.OnChaos != null)
                {
                    this.OnChaos(this, deepChaos);
                }
            }
        }

        public void SetCurrentCombatMethod(CombatMethod cm)
        {
            this.currentCombatMethod = cm;
            if (cm != null)
            {
                this.currentCombatMethodID = cm.ID;
                if (cm.AttackDefault != null)
                {
                    this.AttackDefaultKind = (TroopAttackDefaultKind) cm.AttackDefault.ID;
                }
                if (cm.AttackTarget != null)
                {
                    this.AttackTargetKind = (TroopAttackTargetKind) cm.AttackTarget.ID;
                }
            }
            else
            {
                this.currentCombatMethodID = -1;
            }
        }

        public void SetCurrentStratagem(Stratagem s)
        {
            this.currentStratagem = s;
            if (s != null)
            {
                if (s.CastDefault != null)
                {
                    this.CastDefaultKind = (TroopCastDefaultKind) s.CastDefault.ID;
                }
                if (s.CastTarget != null)
                {
                    this.CastTargetKind = (TroopCastTargetKind) s.CastTarget.ID;
                }
                this.currentStratagemID = s.ID;
            }
            else
            {
                this.currentStratagemID = -1;
            }
        }

        private void SetDirection(int offsetX, int offsetY)
        {
            switch (offsetX)
            {
                case -1:
                    switch (offsetY)
                    {
                        case -1:
                            this.Direction = TroopDirection.西北;
                            break;

                        case 0:
                            this.Direction = TroopDirection.正西;
                            break;

                        case 1:
                            this.Direction = TroopDirection.西南;
                            break;
                    }
                    break;

                case 0:
                    switch (offsetY)
                    {
                        case -1:
                            this.Direction = TroopDirection.正北;
                            break;

                        case 0:
                            this.Direction = TroopDirection.正东;
                            break;

                        case 1:
                            this.Direction = TroopDirection.正南;
                            break;
                    }
                    break;

                case 1:
                    switch (offsetY)
                    {
                        case -1:
                            this.Direction = TroopDirection.东北;
                            break;

                        case 0:
                            this.Direction = TroopDirection.正东;
                            break;

                        case 1:
                            this.Direction = TroopDirection.东南;
                            break;
                    }
                    break;
            }
        }

        public bool SetFireAvail(int id)
        {
            if (this.Status != TroopStatus.埋伏)
            {
                if (this.ProhibitAllAction || this.ProhibitStratagem)
                {
                    return false;
                }
                Stratagem stratagem = this.Stratagems.GetStratagem(id);
                if (stratagem != null)
                {
                    if (stratagem.Combativity <= (this.Combativity + this.DecrementOfStratagemCombativityConsuming))
                    {
                        foreach (Point point in this.StratagemArea.Area)
                        {
                            if (base.Scenario.IsPositionEmpty(point) && base.Scenario.IsFireVaild(point, false, MilitaryType.步兵))
                            {
                                return true;
                            }
                        }
                        return false;
                    }
                    return false;
                }
            }
            return false;
        }

        public void SetFriendlyTroopsInView()
        {
            this.ViewingPlainFriendlyTroopCount = 0;
            this.ViewingGrasslandFriendlyTroopCount = 0;
            this.ViewingForestFriendlyTroopCount = 0;
            this.ViewingMarshFriendlyTroopCount = 0;
            this.ViewingMountainFriendlyTroopCount = 0;
            this.ViewingWaterFriendlyTroopCount = 0;
            this.ViewingRidgeFriendlyTroopCount = 0;
            this.ViewingWastelandFriendlyTroopCount = 0;
            this.ViewingDesertFriendlyTroopCount = 0;
            this.ViewingCliffFriendlyTroopCount = 0;
            this.ViewingFriendlyTroopCount = 0;
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && this.IsFriendly(troopByPosition.BelongedFaction))
                {
                    switch (base.Scenario.GetTerrainKindByPositionNoCheck(point))
                    {
                        case TerrainKind.平原:
                            this.ViewingPlainFriendlyTroopCount++;
                            break;

                        case TerrainKind.草原:
                            this.ViewingGrasslandFriendlyTroopCount++;
                            break;

                        case TerrainKind.森林:
                            this.ViewingForestFriendlyTroopCount++;
                            break;

                        case TerrainKind.湿地:
                            this.ViewingMarshFriendlyTroopCount++;
                            break;

                        case TerrainKind.山地:
                            this.ViewingMountainFriendlyTroopCount++;
                            break;

                        case TerrainKind.水域:
                            this.ViewingWaterFriendlyTroopCount++;
                            break;

                        case TerrainKind.峻岭:
                            this.ViewingRidgeFriendlyTroopCount++;
                            break;

                        case TerrainKind.荒地:
                            this.ViewingWastelandFriendlyTroopCount++;
                            break;

                        case TerrainKind.沙漠:
                            this.ViewingDesertFriendlyTroopCount++;
                            break;

                        case TerrainKind.栈道:
                            this.ViewingCliffFriendlyTroopCount++;
                            break;
                    }
                    this.ViewingFriendlyTroopCount++;
                }
            }
        }

        public void SetHostileTroopsInView()
        {
            this.ViewingPlainHostileTroopCount = 0;
            this.ViewingGrasslandHostileTroopCount = 0;
            this.ViewingForestHostileTroopCount = 0;
            this.ViewingMarshHostileTroopCount = 0;
            this.ViewingMountainHostileTroopCount = 0;
            this.ViewingWaterHostileTroopCount = 0;
            this.ViewingRidgeHostileTroopCount = 0;
            this.ViewingWastelandHostileTroopCount = 0;
            this.ViewingDesertHostileTroopCount = 0;
            this.ViewingCliffHostileTroopCount = 0;
            this.ViewingHostileTroopCount = 0;
            foreach (Point point in this.ViewArea.Area)
            {
                Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                if ((troopByPosition != null) && !this.IsFriendly(troopByPosition.BelongedFaction))
                {
                    switch (base.Scenario.GetTerrainKindByPositionNoCheck(point))
                    {
                        case TerrainKind.平原:
                            this.ViewingPlainHostileTroopCount++;
                            break;

                        case TerrainKind.草原:
                            this.ViewingGrasslandHostileTroopCount++;
                            break;

                        case TerrainKind.森林:
                            this.ViewingForestHostileTroopCount++;
                            break;

                        case TerrainKind.湿地:
                            this.ViewingMarshHostileTroopCount++;
                            break;

                        case TerrainKind.山地:
                            this.ViewingMountainHostileTroopCount++;
                            break;

                        case TerrainKind.水域:
                            this.ViewingWaterHostileTroopCount++;
                            break;

                        case TerrainKind.峻岭:
                            this.ViewingRidgeHostileTroopCount++;
                            break;

                        case TerrainKind.荒地:
                            this.ViewingWastelandHostileTroopCount++;
                            break;

                        case TerrainKind.沙漠:
                            this.ViewingDesertHostileTroopCount++;
                            break;

                        case TerrainKind.栈道:
                            this.ViewingCliffHostileTroopCount++;
                            break;
                    }
                    this.ViewingHostileTroopCount++;
                }
            }
        }

        public void SetLeader(Person person)
        {
            this.Leader = person;
        }

        public void SetNotShowing()
        {
            this.Action = TroopAction.Stop;
            this.WaitForDeepChaosFrameCount = 0;
            this.ShowNumber = false;
            this.PreAction = TroopPreAction.无;
            this.ApplyDamageList();
            this.ApplyStratagemEffect();
        }

        public void SetOnFire(float scale)
        {
            this.ReceiveFireDamage(scale);
            if (base.Scenario.IsFireVaild(this.Position, false, MilitaryType.步兵))
            {
                base.Scenario.SetPositionOnFire(this.Position);
            }
        }

        private void SetOutburst()
        {
            if (((this.RecentlyFighting > 0) && (this.Leader != null)) && (this.Status != TroopStatus.混乱))
            {
                if (this.Leader.Braveness > this.Leader.Calmness)
                {
                    if (GameObject.Square((this.Leader.Braveness - this.Leader.Calmness) + 5) >= GameObject.Random(0x3e8))
                    {
                        this.BeAngry();
                    }
                }
                else if (this.Leader.Calmness > this.Leader.Braveness)
                {
                    if (GameObject.Square((this.Leader.Calmness - this.Leader.Braveness) + 5) >= GameObject.Random(0x3e8))
                    {
                        this.BeQuiet();
                    }
                }
                else
                {
                    int braveness = 5;
                    if (this.Leader.Braveness > braveness)
                    {
                        braveness = this.Leader.Braveness;
                    }
                    if (GameObject.Square(braveness) >= GameObject.Random(0x3e8))
                    {
                        if (GameObject.Chance(50))
                        {
                            this.BeAngry();
                        }
                        else
                        {
                            this.BeQuiet();
                        }
                    }
                }
            }
        }

        public void SetRecoverFromChaos()
        {
            if (!this.Destroyed)
            {
                this.chaosDayLeft = 0;
                this.Status = TroopStatus.一般;
                this.PreAction = TroopPreAction.恢复;
                this.RefreshOffence();
                this.RefreshDefence();
                if (this.OnRecoverFromChaos != null)
                {
                    this.OnRecoverFromChaos(this);
                }
            }
        }

        public void SetSimpleChaos(int days)
        {
            this.Status = TroopStatus.混乱;
            this.chaosDayLeft += days;
            this.OperationDone = true;
            this.MovabilityLeft = -1;
            this.RefreshOffence();
            this.RefreshDefence();
            this.CutRoutewayDays = 0;
        }

        public void SetStatus(TroopStatus ts)
        {
            this.status = ts;
            switch (ts)
            {
                case TroopStatus.一般:
                    this.CurrentTileAnimationKind = TileAnimationKind.无;
                    break;

                case TroopStatus.混乱:
                    this.CurrentTileAnimationKind = TileAnimationKind.混乱;
                    break;

                case TroopStatus.埋伏:
                    this.CurrentTileAnimationKind = TileAnimationKind.埋伏;
                    break;
            }
        }

        private int simplepathFinder_OnGetCost(Point position, bool Oblique, int DirectionCost)
        {
            int mapCost = this.GetMapCost(position);
            mapCost = (DirectionCost > mapCost) ? DirectionCost : mapCost;
            if (Oblique)
            {
                if (this.Movability >= (mapCost * 7))
                {
                    return 1;
                }
            }
            else if (this.Movability >= (mapCost * 5))
            {
                return 1;
            }
            return 0xdac;
        }

        public void SimpleRecoverFromChaos()
        {
            this.chaosDayLeft = 0;
            this.Status = TroopStatus.一般;
            this.RefreshOffence();
            this.RefreshDefence();
        }

        private void SimulateInitializePosition(Point startPosition)
        {
            this.PreviousPosition = this.position = startPosition;
            this.RefreshTroopAbility();
            this.Persons.ApplyInfluences();
            this.InitializeInfluences();
            this.ResetTerrainData();
            this.RefreshAllData();
        }

        public static int SquareChance(int num, int divisor)
        {
            return (GameObject.Square(num) / divisor);
        }

        internal void StartAttackArchitecture(ArchitectureDamage damage)
        {
            this.ResetDirectionArchitecture();
            this.Action = TroopAction.Attack;
            if (this.PreAction == TroopPreAction.无)
            {
                this.TryToPlaySound(this.Position, this.Army.Kind.Sounds.NormalAttackSoundPath, false);
            }
            this.AttackStarted = false;
            this.operationDone = true;
            //this.MovabilityLeft = -1;
            this.ArchitectureDamageList.Add(damage);
        }

        internal void StartAttackTroop(Troop troop, TroopDamage damage, bool area)
        {
            if (this.CombatMethodApplied)
            {
                if (this.OnCombatMethodAttack != null)
                {
                    if (this.CurrentCombatMethodID == 0)   // 如果是大盾
                    {
                        this.AddSelfzhanfaAnimation();
                    }
                    else
                    {
                        this.AddzhanfaAnimation(troop, true);
                    }
                    //this.OnCombatMethodAttack(this, troop, this.CurrentCombatMethod);
                }
            }



            if (!area)
            {
                if (!damage.Counter)
                {
                    if ((this.CombatMethodApplied && !damage.Surround) && (!damage.Critical || (this.Leader.PersonTextMessage.CriticalStrike.Count == 0)))
                    {
                        if (this.OnCombatMethodAttack != null)
                        {
                            /*if (this.CurrentCombatMethodID == 0)   // 如果是大盾
                            {
                                this.AddSelfzhanfaAnimation();
                            }
                            else
                            {
                                this.AddzhanfaAnimation(troop, true);
                            }*/
                            this.OnCombatMethodAttack(this, troop, this.CurrentCombatMethod);
                        }
                    }
                    else if (damage.Waylay)                      //这些if判断成立的话仅仅只添加了部队说话
                    {
                        if (this.OnWaylay != null)
                        {
                            this.OnWaylay(this, troop);
                        }
                    }
                    else if (damage.Critical)
                    {
                        if (this.OnCriticalStrike != null)
                        {
                            this.OnCriticalStrike(this, troop);
                        }
                    }
                    else if (damage.Surround)
                    {
                        if (this.OnSurround != null)
                        {
                            this.OnSurround(this, troop);
                        }
                    }
                    else if (this.OnNormalAttack != null)
                    {
                        this.OnNormalAttack(this, troop);
                    }
                }
                this.ResetDirectionTroop(troop);
                this.Action = TroopAction.Attack;
                if (this.PreAction == TroopPreAction.无 && !this.CombatMethodApplied)
                {
                    this.TryToPlaySound(this.Position, this.Army.Kind.Sounds.NormalAttackSoundPath, false);
                }

                this.AttackStarted = false;
            }
            troop.Action = TroopAction.BeAttacked;
            this.operationDone = true;
            if (troop == this.TargetTroop)
            {
               // this.MovabilityLeft = -1;
            }
            if (this.BaseAttackEveryAround || this.AttackEveryAround)
            {
                this.AttackedTroopList.Add(troop);
                this.OperationDone = false;
            }
            this.TroopDamageList.Add(damage);
        }

        private void StartCastSelf()
        {
            this.operationDone = true;
            //this.MovabilityLeft = -1;
            if (this.Position != this.SelfCastPosition)
            {
                this.ResetDirection(this.SelfCastPosition);
            }
            this.Action = TroopAction.Cast;
            this.StratagemApplyed = true;
            this.AddSelfCastAnimation();
            if (this.OnCastStratagem != null)
            {
                this.OnCastStratagem(this, this, this.CurrentStratagem);
            }
        }

        private void StartCastTroop(Troop troop)
        {
            if (troop != null)
            {
                this.operationDone = true;
               // this.MovabilityLeft = -1;
                this.ResetDirectionTroop(troop);
                this.Action = TroopAction.Cast;
                this.StratagemApplyed = true;
                if (!this.CurrentStratagem.Friendly)
                {
                    this.RecentlyFighting = 3;
                    troop.RecentlyFighting = 3;
                    troop.Action = TroopAction.BeCasted;
                    foreach (Troop troop2 in this.AreaStratagemTroops)
                    {
                        troop2.RecentlyFighting = 3;
                        troop2.Action = TroopAction.BeCasted;
                    }
                }
                this.AddCastAnimation(troop, true);
                foreach (Troop troop2 in this.AreaStratagemTroops)
                {
                    this.AddCastAnimation(troop2, false);
                }
                if (this.OnCastStratagem != null)
                {
                    this.OnCastStratagem(this, troop, this.CurrentStratagem);
                }
            }
        }

        public void StopCutRouteway()
        {
            this.CutRoutewayDays = 0;
            this.Controllable = true;
            this.Operated = false;
        }

        public bool SurroundAvail()
        {
            return ((this.Status == TroopStatus.一般) && this.Controllable);
        }

        public bool TargetAvail()
        {
            return ((((this.AttackTargetKind == TroopAttackTargetKind.目标) || (this.AttackTargetKind == TroopAttackTargetKind.目标默认)) || (this.CastTargetKind == TroopCastTargetKind.特定)) || (this.CastTargetKind == TroopCastTargetKind.特定默认));
        }

        internal bool ToDoCombatAction()
        {
            if (this.OperationDone)
            {
                return false;
            }
            bool flag = false;
            switch (this.Will)
            {
                case TroopWill.行军:
                    if (this.CurrentStratagem == null)
                    {
                        flag = this.GetAttackOrientationObject(this.QueueEnded) != null;
                        break;
                    }
                    if (this.CurrentStratagem.Self)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = this.GetCastOrientationTroop(this.QueueEnded) != null;
                    }
                    break;
            }
            if (!(this.OperationDone || (this.MovabilityLeft > 0)))
            {
                this.QueueEnded = true;
            }
            return flag;
        }

        public override string ToString()
        {
            return (this.DisplayName + "  " + this.FactionString);
        }

        public void TryToPlaySound(Point position, string soundFileLocation, bool looping)
        {
            if (GlobalVariables.DrawTroopAnimation)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    if ((GlobalVariables.SkyEye || base.Scenario.CurrentPlayer.IsPositionKnown(position)) && base.Scenario.GameScreen.TileInScreen(position))
                    {
                        this.PlaySound(soundFileLocation, looping);
                    }
                }
                else if (base.Scenario.GameScreen.TileInScreen(position))
                {
                    this.PlaySound(soundFileLocation, looping);
                }
            }
        }

        public bool TryToStepForward()
        {
            bool path = false;
            if (this.StepFinished)
            {
                path = this.GetPath();
                if (this.Destroyed)
                {
                    return false;
                }
                if (this.FirstTierPath == null)
                {
                    this.MovabilityLeft = -1;
                    return path;
                }
                Troop troopByPosition = base.Scenario.GetTroopByPosition(this.NextPosition);
                if (troopByPosition != null)
                {
                    if (!troopByPosition.IsFriendly(this.BelongedFaction))
                    {
                        this.MovabilityLeft = -1;
                        return path;
                    }
                    int firstTierPathIndex = this.firstTierPathIndex;
                    int movabilityLeft = this.MovabilityLeft;
                    while ((firstTierPathIndex + 1) < this.FirstTierPath.Count)
                    {
                        Point currentPosition = this.FirstTierPath[firstTierPathIndex];
                        Point nextPosition = this.FirstTierPath[firstTierPathIndex + 1];
                        int num3 = this.NextPositionCost(currentPosition, nextPosition);
                        if (num3 <= movabilityLeft)
                        {
                            Troop troop2 = base.Scenario.GetTroopByPosition(nextPosition);
                            if (troop2 == null)
                            {
                                this.StepFinished = false;
                                return path;
                            }
                            if (!troop2.IsFriendly(this.BelongedFaction))
                            {
                                this.MovabilityLeft = -1;
                                return path;
                            }
                            movabilityLeft -= num3;
                            firstTierPathIndex++;
                        }
                        else
                        {
                            this.MovabilityLeft = -1;
                            return path;
                        }
                    }
                    if (firstTierPathIndex == (this.FirstTierPath.Count - 1))
                    {
                        this.MovabilityLeft = -1;



                        return path;
                    }
                }//end if (troopByPosition != null)
            } //end  if (this.StepFinished)
            if (this.FirstTierPath != null)
            {
                int num4 = this.NextPositionCost(this.Position, this.NextPosition);
                if (this.MovabilityLeft >= num4)
                {
                    this.MovabilityLeft -= num4;
                    this.firstTierPathIndex++;
                    this.Position = this.FirstTierPath[this.firstTierPathIndex];
                    this.Moved = true;
                    if (this.FirstTierPath != null)
                    {
                        if (this.firstTierPathIndex == (this.FirstTierPath.Count - 1))
                        {
                            this.HasPath = false;
                            this.MovabilityLeft = -1;
                        }
                        return path;
                    }
                    this.HasPath = false;
                    this.MovabilityLeft = -1;
                    return path;
                }
                this.MovabilityLeft = -1;
                return path;
            }
            this.MovabilityLeft = -1;
            return path;
        }

        public void UpdateAnimation()
        {
            int num = this.Position.X - this.PreviousPosition.X;
            int num2 = this.Position.Y - this.PreviousPosition.Y;
            switch (this.Action)
            {
                case TroopAction.Stop:
                    if ((Math.Abs(num) == 1) || (Math.Abs(num2) == 1))
                    {
                        this.SetDirection(num, num2);
                    }
                    break;

                case TroopAction.Move:
                    if ((Math.Abs(num) == 1) || (Math.Abs(num2) == 1))
                    {
                        this.SetDirection(num, num2);
                        this.MoveAnimationFrames = base.Scenario.TroopAnimations.GetDirectionAnimation(new Point(num, num2));
                    }
                    break;
            }
        }

        private void WillAI()
        {
            if (this.Will == TroopWill.行军)
            {
                if (this.AIResetDestination())
                {
                    this.WillTroop = this.TargetTroop;
                }
                else if (!this.Destroyed && (this.BelongedFaction != null))
                {
                    TroopList hostileTroopsInView = null;
                    if (this.WillArchitecture != null)
                    {
                        if (this.IsFriendly(this.WillArchitecture.BelongedFaction))
                        {
                            hostileTroopsInView = this.WillArchitecture.GetHostileTroopsInView();
                            if (hostileTroopsInView.Count > 1)
                            {
                                hostileTroopsInView.IsNumber = true;
                                hostileTroopsInView.PropertyName = "FightingForce";
                                hostileTroopsInView.SmallToBig = true;
                                hostileTroopsInView.ReSort();
                            }
                            if (hostileTroopsInView.Count > 0)
                            {
                                this.WillTroop = hostileTroopsInView[0] as Troop;
                            }
                            if (((this.WillTroop != null) && !this.IsFriendly(this.WillTroop.BelongedFaction)) && (((this.BelongedFaction == null) && this.ViewArea.HasPoint(this.WillTroop.Position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(this.WillTroop.Position))))
                            {
                                if (this.WillTroop.FightingForce < this.FightingForce)
                                {
                                    this.RealDestination = this.WillTroop.Position;
                                }
                                else if (this.WillArchitecture != null)
                                {
                                    this.GoIntoArchitecture();
                                }
                            }
                            else
                            {
                                this.GoIntoArchitecture();
                            }
                        }
                        else
                        {
                            this.GoIntoArchitecture();
                        }
                    }
                }
            }
            else if (this.Will == TroopWill.移动)
            {
                if (this.WillTroop != null)
                {
                    if (((this.BelongedFaction == null) && this.ViewArea.HasPoint(this.WillTroop.Position)) || ((this.BelongedFaction != null) && this.BelongedFaction.IsPositionKnown(this.WillTroop.Position)))
                    {
                        this.RealDestination = this.WillTroop.Position;
                    }
                }
                else if (this.WillArchitecture != null)
                {
                    this.GoIntoArchitecture();
                }
            }
        }

        public void YearEvent()
        {
        }

        public string AccidentalInjuryString
        {
            get
            {
                return (this.TroopNoAccidentalInjury ? "否" : "是");
            }
        }

        public TroopAction Action
        {
            get
            {
                return this.action;
            }
            set
            {
                this.action = value;
                switch (this.action)
                {
                    case TroopAction.Attack:
                        this.ResetAnimationIndex();
                        break;

                    case TroopAction.BeAttacked:
                        this.ResetAnimationIndex();
                        break;

                    case TroopAction.Cast:
                        this.ResetAnimationIndex();
                        break;

                    case TroopAction.BeCasted:
                        this.ResetAnimationIndex();
                        break;
                }
            }
        }

        public bool AfraidOfFire
        {
            get
            {
                return (this.Army.Kind.AfraidOfFire && !this.NotAfraidOfFire);
            }
        }

        public string AfraidOfFireString
        {
            get
            {
                return (this.AfraidOfFire ? "是" : "否");
            }
        }

        public bool AirOffence
        {
            get
            {
                return this.Army.Kind.AirOffence;
            }
        }

        public int AntiCriticalStrikeChance
        {
            get
            {
                return this.antiCriticalStrikeChance;
            }
        }

        public int AntiStratagemChanceIncrement
        {
            get
            {
                return this.antiStratagemChanceIncrement;
            }
        }

        public float ArchitectureCounterDamageRate
        {
            get
            {
                return this.Army.Kind.ArchitectureCounterDamageRate;
            }
        }

        public float ArchitectureDamageRate
        {
            get
            {
                return this.Army.Kind.ArchitectureDamageRate;
            }
        }

        public Military Army
        {
            get
            {
                if (this.army == null)
                {
                    this.army = base.Scenario.Militaries.GetGameObject(this.militaryID) as Military;
                    if (this.army != null)
                    {
                        this.militaryID = this.army.ID;
                        this.army.BelongedTroop = this;
                        if (this.Simulating)
                        {
                            this.army.SimulateSetLeader(this.Leader);
                        }
                        else
                        {
                            this.army.Leader = this.Leader;
                        }
                    }
                }
                return this.army;
            }
            set
            {
                this.army = value;
                if (this.army != null)
                {
                    this.militaryID = this.army.ID;
                    this.army.BelongedTroop = this;
                    if (this.Simulating)
                    {
                        this.army.SimulateSetLeader(this.Leader);
                    }
                    else
                    {
                        this.army.Leader = this.Leader;
                    }
                    this.AttackDefaultKind = this.army.Kind.AttackDefaultKind;
                    this.AttackTargetKind = this.army.Kind.AttackTargetKind;
                    this.CastDefaultKind = this.army.Kind.CastDefaultKind;
                    this.CastTargetKind = this.army.Kind.CastTargetKind;
                }
            }
        }

        public bool ArrowOffence
        {
            get
            {
                return this.Army.Kind.ArrowOffence;
            }
        }

        public string ArrowOffenceString
        {
            get
            {
                return (this.ArrowOffence ? "是" : "否");
            }
        }

        public TroopAttackDefaultKind AttackDefaultKind
        {
            get
            {
                return this.attackDefaultKind;
            }
            set
            {
                this.attackDefaultKind = value;
            }
        }

        public TroopAttackTargetKind AttackTargetKind
        {
            get
            {
                return this.attackTargetKind;
            }
            set
            {
                this.attackTargetKind = value;
            }
        }

        public bool Auto
        {
            get
            {
                return this.auto;
            }
            set
            {
                this.auto = value;
            }
        }

        public int AvoidSurroundedChance
        {
            get
            {
                return this.avoidSurroundedChance;
            }
        }

        public GameArea BaseViewArea
        {
            get
            {
                if (this.baseViewArea == null)
                {
                    this.baseViewArea = GameArea.GetViewArea(this.Position, this.ViewRadius, this.ObliqueView, base.Scenario, null);
                }
                return this.baseViewArea;
            }
            set
            {
                this.baseViewArea = value;
            }
        }

        public bool BeCountered
        {
            get
            {
                return this.Army.Kind.BeCountered;
            }
        }

        public string BeCounteredString
        {
            get
            {
                return this.Army.Kind.BeCounteredString;
            }
        }

        public bool CanMove
        {
            get
            {
                return (this.position != this.destination);
            }
        }

        public int CaptiveAblility
        {
            get
            {
                if (this.AirOffence)
                {
                    return (this.Offence / 4);
                }
                return this.Offence;
            }
        }

        public int CaptiveCount
        {
            get
            {
                return this.Captives.Count;
            }
        }

        public TroopCastDefaultKind CastDefaultKind
        {
            get
            {
                return this.castDefaultKind;
            }
            set
            {
                this.castDefaultKind = value;
            }
        }

        public TroopCastTargetKind CastTargetKind
        {
            get
            {
                return this.castTargetKind;
            }
            set
            {
                this.castTargetKind = value;
            }
        }

        public int ChaosAfterCriticalStrikeChance
        {
            get
            {
                return this.chaosAfterCriticalStrikeChance;
            }
        }

        public int ChaosAfterStratagemSuccessChance
        {
            get
            {
                return this.chaosAfterStratagemSuccessChance;
            }
        }

        public int ChaosAfterSurroundAttackChance
        {
            get
            {
                return this.chaosAfterSurroundAttackChance;
            }
        }

        public int ChaosDayLeft
        {
            get
            {
                return this.chaosDayLeft;
            }
            set
            {
                this.chaosDayLeft = value;
            }
        }

        public int CliffAdaptability
        {
            get
            {
                return (this.Army.Kind.CliffAdaptability - this.DecrementOfCliffAdaptability);
            }
        }

        public float CliffRate
        {
            get
            {
                return this.Army.Kind.CliffRate;
            }
        }

        public int Combativity
        {
            get
            {
                return this.Army.Combativity;
            }
            set
            {
                this.Army.Combativity = value;
            }
        }

        public string CombatTitleString
        {
            get
            {
                if (this.HasCombatTitle)
                {
                    return this.Leader.CombatTitle.Name;
                }
                return "----";
            }
        }

        public GameArea ContactArea
        {
            get
            {
                if (this.contactArea == null)
                {
                    this.contactArea = GameArea.GetArea(this.Position, 1, false);
                }
                return this.contactArea;
            }
            set
            {
                this.contactArea = value;
            }
        }

        public bool ContactOffence
        {
            get
            {
                return this.Army.Kind.ContactOffence;
            }
        }

        public string ContactOffenceString
        {
            get
            {
                return this.Army.Kind.ContactOffenceString;
            }
        }

        public bool Controllable
        {
            get
            {
                return this.controllable;
            }
            set
            {
                this.controllable = value;
            }
        }

        public TroopControlState ControlState
        {
            get
            {
                if (this.Operated || !this.ControlAvail())
                {
                    if (this.Auto)
                    {
                        return TroopControlState.AutoDone;
                    }
                    return TroopControlState.Done;
                }
                if (this.Auto)
                {
                    return TroopControlState.Auto;
                }
                return TroopControlState.Undone;
            }
        }

        public bool CounterOffence
        {
            get
            {
                return this.Army.Kind.CounterOffence;
            }
        }

        public string CounterOffenceString
        {
            get
            {
                return this.Army.Kind.CounterOffenceString;
            }
        }

        public int CriticalStrikeChance
        {
            get
            {
                return this.criticalStrikeChance;
            }
        }

        public Animation CurrentAnimation
        {
            get
            {
                return base.Scenario.GameCommonData.AllTroopAnimations.GetAnimation((int) this.Action);
            }
        }

        public Architecture CurrentArchitecture
        {
            get
            {
                return base.Scenario.GetArchitectureByPositionNoCheck(this.Position);
            }
        }

        public string CurrentCombatAction
        {
            get
            {
                if (this.CurrentCombatMethod != null)
                {
                    return this.CurrentCombatMethod.Name;
                }
                if (this.CurrentStratagem != null)
                {
                    return this.CurrentStratagem.Name;
                }
                return "----";
            }
        }

        public CombatMethod CurrentCombatMethod
        {
            get
            {
                if ((this.currentCombatMethod == null) && (this.currentCombatMethodID >= 0))
                {
                    this.currentCombatMethod = this.CombatMethods.GetCombatMethod(this.currentCombatMethodID);
                }
                return this.currentCombatMethod;
            }
            set
            {
                this.currentCombatMethod = value;
                if (this.currentCombatMethod != null)
                {
                    this.currentCombatMethodID = value.ID;
                    if (this.OnSetCombatMethod != null)
                    {
                        this.OnSetCombatMethod(this, this.currentCombatMethod);
                    }
                }
                else
                {
                    this.currentCombatMethodID = -1;
                }
            }
        }

        public int CurrentCombatMethodID
        {
            get
            {
                return this.currentCombatMethodID;
            }
            set
            {
                this.currentCombatMethodID = value;
            }
        }

        public string CurrentDestinationChallengePersonName
        {
            get
            {
                return this.CurrentDestinationChallengePerson.Name;
            }
        }

        public string CurrentDestinationControversyPersonName
        {
            get
            {
                return this.CurrentDestinationControversyPerson.Name;
            }
        }

        public float CurrentRate
        {
            get
            {
                return this.terrainRate;
            }
        }

        public string CurrentRateString
        {
            get
            {
                return Math.Round((double) this.CurrentRate, 1).ToString();
            }
        }

        public string CurrentSourceChallengePersonName
        {
            get
            {
                return this.CurrentSourceChallengePerson.Name;
            }
        }

        public string CurrentSourceControversyPersonName
        {
            get
            {
                return this.CurrentSourceControversyPerson.Name;
            }
        }

        public Stratagem CurrentStratagem
        {
            get
            {
                if ((this.currentStratagem == null) && (this.currentStratagemID >= 0))
                {
                    this.currentStratagem = base.Scenario.GameCommonData.AllStratagems.GetStratagem(this.currentStratagemID);
                }
                return this.currentStratagem;
            }
            set
            {
                this.currentStratagem = value;
                if (this.currentStratagem != null)
                {
                    this.currentStratagemID = value.ID;
                    if (this.OnSetStratagem != null)
                    {
                        this.OnSetStratagem(this, this.currentStratagem);
                    }
                }
                else
                {
                    this.currentStratagemID = -1;
                }
            }
        }

        public int CurrentStratagemID
        {
            get
            {
                return this.currentStratagemID;
            }
            set
            {
                this.currentStratagemID = value;
            }
        }

        public string CurrentStuntString
        {
            get
            {
                return ((this.CurrentStunt != null) ? this.CurrentStunt.Name : "----");
            }
        }

        public int CutRoutewayDays
        {
            get
            {
                return this.cutRoutewayDays;
            }
            set
            {
                this.cutRoutewayDays = value;
            }
        }

        public int CutRoutewayDaysNeeded
        {
            get
            {
                int num = 10 - this.Army.Scales;
                if (num < 3)
                {
                    num = 3;
                }
                return num;
            }
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }
        }

        public int DesertAdaptability
        {
            get
            {
                return (this.Army.Kind.DesertAdaptability - this.DecrementOfDesertAdaptability);
            }
        }

        public float DesertRate
        {
            get
            {
                return this.Army.Kind.DesertRate;
            }
        }

        public Point Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                this.destination = value;
                this.ClearFirstTierPath();
                this.ClearSecondTierPath();
                this.ClearThirdTierPath();
                this.HasPath = false;
                if ((this.position == this.destination) && (this.OnEndPath != null))
                {
                    this.OnEndPath(this);
                }
            }
        }

        public string DestinationString
        {
            get
            {
                return base.Scenario.PositionString(this.destination);
            }
        }

        public TroopDirection Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        public string DisplayName
        {
            get
            {
                if (this.Leader != null)
                {
                    return (this.Leader.Name + "队");
                }
                return "----";
            }
        }

        public bool DrawAnimation
        {
            get
            {
                return (this.drawAnimation && GlobalVariables.DrawTroopAnimation);
            }
            set
            {
                this.drawAnimation = value;
            }
        }

        public Animation EffectTileAnimation
        {
            get
            {
                if (this.Effect == TroopEffect.被包围)
                {
                    return base.Scenario.GameCommonData.AllTileAnimations.GetAnimation(15);
                }
                return null;
            }
        }

        public int Experience
        {
            get
            {
                return this.Army.Experience;
            }
            set
            {
                this.Army.Experience = value;
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

        public int FightingForce
        {
            get
            {
                return ((this.Offence + this.Defence) * (((((((((((((((((((((((((1 + (((this.CurrentArchitecture != null) && (this.CurrentArchitecture.Endurance > 0)) ? 10 : 0)) + (this.TroopIntelligence / 2)) + (this.Quantity / 500)) + (this.Combativity / 4)) + (this.HasCombatTitle ? (20 * this.Leader.CombatTitle.Level) : 0)) + (this.CombatMethods.Count * 5)) + (this.Stunts.Count * 20)) + this.CriticalStrikeChance) + this.AntiCriticalStrikeChance) + this.ChaosAfterCriticalStrikeChance) + (this.AvoidSurroundedChance / 2)) + this.ChaosAfterSurroundAttackChance) + this.StratagemChanceIncrement) + this.AntiStratagemChanceIncrement) + this.ChaosAfterStratagemSuccessChance) + (this.ChanceIncrementOfCriticalStrikeInViewArea * 4)) + (this.ChanceDecrementOfCriticalStrikeInViewArea * 4)) + (this.CombativityIncrementPerDayInViewArea * 4)) + (this.CombativityDecrementPerDayInViewArea * 4)) + (this.ChanceIncrementOfStratagemInViewArea * 4)) + (this.ChanceDecrementOfStratagemInViewArea * 4)) + ((int) (this.OffenceRateIncrementInViewArea * 100f))) + ((int) (this.OffenceRateDecrementInViewArea * 100f))) + ((int) (this.DefenceRateIncrementInViewArea * 100f))) + ((int) (this.DefenceRateDecrementInViewArea * 100f))));
            }
        }

        public int FirstIndex
        {
            get
            {
                return this.firstTierPathIndex;
            }
            set
            {
                this.firstTierPathIndex = value;
            }
        }

        public Point FirstTierDestination
        {
            get
            {
                if (this.FirstTierPath != null)
                {
                    return this.FirstTierPath[this.FirstTierPath.Count - 1];
                }
                return this.Destination;
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

        public int FoodCostPerDay
        {
            get
            {
                return this.Army.FoodCostPerDay;
            }
        }

        public int FoodMax
        {
            get
            {
                return (this.FoodCostPerDay * this.RationDays);
            }
        }

        public int ForrestAdaptability
        {
            get
            {
                return (this.Army.Kind.ForrestAdaptability - this.DecrementOfForrestAdaptability);
            }
        }

        public float ForrestRate
        {
            get
            {
                return this.Army.Kind.ForrestRate;
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

        public int GrasslandAdaptability
        {
            get
            {
                return (this.Army.Kind.GrasslandAdaptability - this.DecrementOfGrasslandAdaptability);
            }
        }

        public float GrasslandRate
        {
            get
            {
                return this.Army.Kind.GrasslandRate;
            }
        }

        public bool HasCombatTitle
        {
            get
            {
                return ((this.Leader != null) && (this.Leader.CombatTitle != null));
            }
        }

        public bool HasPersonalTitle
        {
            get
            {
                return ((this.Leader != null) && (this.Leader.PersonalTitle != null));
            }
        }

        public int HostileTroopInViewFightingForce
        {
            get
            {
                int num = 0;
                foreach (Point point in this.ViewArea.Area)
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if ((troopByPosition != null) && (((this.BelongedFaction == null) && (troopByPosition.BelongedFaction != null)) || ((this.BelongedFaction != null) && !this.BelongedFaction.IsFriendly(troopByPosition.BelongedFaction))))
                    {
                        num += troopByPosition.FightingForce;
                    }
                }
                return num;
            }
        }

        public int InjuryChance
        {
            get
            {
                return (this.Army.InjuryChance + this.IncrementOfInjuryRate);
            }
        }

        public int InjuryQuantity
        {
            get
            {
                return this.Army.InjuryQuantity;
            }
            set
            {
                this.Army.InjuryQuantity = value;
            }
        }

        public InformationLevel InvestigateLevel
        {
            get
            {
                if (this.HighLevelInformationOnInvestigate)
                {
                    return InformationLevel.高;
                }
                return InformationLevel.中;
            }
        }

        public int InvestigateRadius
        {
            get
            {
                return (2 + this.IncrementOfInvestigateRadius);
            }
        }

        private bool IsAntiArrowAttack
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            return GameObject.Chance(this.BelongedFaction.AntiArrowChanceIncrementOfBubing);

                        case MilitaryType.弩兵:
                            return GameObject.Chance(this.BelongedFaction.AntiArrowChanceIncrementOfNubing);

                        case MilitaryType.骑兵:
                            return GameObject.Chance(this.BelongedFaction.AntiArrowChanceIncrementOfQibing);

                        case MilitaryType.水军:
                            return GameObject.Chance(this.BelongedFaction.AntiArrowChanceIncrementOfShuijun);

                        case MilitaryType.器械:
                            return GameObject.Chance(this.BelongedFaction.AntiArrowChanceIncrementOfQixie);
                    }
                }
                return false;
            }
        }

        private bool IsAntiCounterAttack
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    if (this.IsInArchitecture && this.CurrentArchitecture.NoCounterStrikeInArchitecture)
                    {
                        return true;
                    }
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            return GameObject.Chance(this.BelongedFaction.NoCounterChanceIncrementOfBubing);

                        case MilitaryType.弩兵:
                            return GameObject.Chance(this.BelongedFaction.NoCounterChanceIncrementOfNubing);

                        case MilitaryType.骑兵:
                            return GameObject.Chance(this.BelongedFaction.NoCounterChanceIncrementOfQibing);

                        case MilitaryType.水军:
                            return GameObject.Chance(this.BelongedFaction.NoCounterChanceIncrementOfShuijun);

                        case MilitaryType.器械:
                            return GameObject.Chance(this.BelongedFaction.NoCounterChanceIncrementOfQixie);
                    }
                }
                return false;
            }
        }

        public bool IsInArchitecture
        {
            get
            {
                Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.Position);
                return (((architectureByPositionNoCheck != null) && (architectureByPositionNoCheck.Endurance > 0)) && architectureByPositionNoCheck.IsFriendly(this.BelongedFaction));
            }
        }

        public bool IsRobber
        {
            get
            {
                return (this.BelongedFaction == null);
            }
        }

        public bool IsSurrounded
        {
            get
            {
                FactionList list = new FactionList();
                foreach (Point point in GameArea.GetArea(this.Position, 1, true).Area)
                {
                    if (point == this.Position)
                    {
                        continue;
                    }
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(point);
                    if (troopByPosition != null)
                    {
                        if (list.HasGameObject(troopByPosition.BelongedFaction))
                        {
                            continue;
                        }
                        list.Add(troopByPosition.BelongedFaction);
                        if (troopByPosition.GetSurroundAttackingTroop(this).Count >= 3)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }

        public string KindString
        {
            get
            {
                return this.Army.Kind.Name;
            }
        }

        public int MarshAdaptability
        {
            get
            {
                return (this.Army.Kind.MarshAdaptability - this.DecrementOfMarshAdaptability);
            }
        }

        public float MarshRate
        {
            get
            {
                return this.Army.Kind.MarshRate;
            }
        }

        public int MilitaryID
        {
            get
            {
                return this.militaryID;
            }
            set
            {
                this.militaryID = value;
            }
        }

        public int Morale
        {
            get
            {
                return this.Army.Morale;
            }
            set
            {
                this.Army.Morale = value;
            }
        }

        public int MountainAdaptability
        {
            get
            {
                return (this.Army.Kind.MountainAdaptability - this.DecrementOfMountainAdaptability);
            }
        }

        public float MountainRate
        {
            get
            {
                return this.Army.Kind.MountainRate;
            }
        }

        public int Movability
        {
            get
            {
                return (this.RealMovability * 5);
            }
        }

        public bool Moved
        {
            get
            {
                return this.moved;
            }
            set
            {
                this.moved = value;
            }
        }

        public Point NextPosition
        {
            get
            {
                if ((this.firstTierPathIndex + 1) >= this.FirstTierPath.Count)
                {
                    return this.FirstTierPath[this.firstTierPathIndex];
                }
                return this.FirstTierPath[this.firstTierPathIndex + 1];
            }
        }

        public bool NextPositionHasTroop
        {
            get
            {
                if (base.Scenario.GetTroopByPositionNoCheck(this.NextPosition) == null)
                {
                    return false;
                }
                return true;
            }
        }

        public bool ObliqueOffence
        {
            get
            {
                return (this.Army.Kind.ObliqueOffence || this.YesOrNoOfObliqueOffence);
            }
        }

        public string ObliqueOffenceString
        {
            get
            {
                return (this.ObliqueOffence ? "是" : "否");
            }
        }

        public bool ObliqueStratagem
        {
            get
            {
                return (this.Army.Kind.ObliqueStratagem || this.YesOrNoOfObliqueStratagem);
            }
        }

        public string ObliqueStratagemString
        {
            get
            {
                return (this.ObliqueStratagem ? "是" : "否");
            }
        }

        public bool ObliqueView
        {
            get
            {
                return (this.Army.Kind.ObliqueView || this.YesOrNoOfObliqueView);
            }
        }

        public string ObliqueViewString
        {
            get
            {
                return (this.ObliqueView ? "是" : "否");
            }
        }

        public int Offence
        {
            get
            {
                return this.offence;
            }
        }

        public GameArea OffenceArea
        {
            get
            {
                if (this.offenceArea == null)
                {
                    this.offenceArea = GameArea.GetViewArea(this.Position, this.OffenceRadius, this.ObliqueOffence, base.Scenario, null);
                    if (!this.ContactOffence)
                    {
                        foreach (Point point in this.ContactArea.Area)
                        {
                            this.offenceArea.Area.Remove(point);
                        }
                    }
                    else
                    {
                        this.offenceArea.Area.Remove(this.Position);
                    }
                }
                return this.offenceArea;
            }
            set
            {
                this.offenceArea = value;
            }
        }

        public bool OffenceOnlyBeforeMove
        {
            get
            {
                if (this.Army.Kind.OffenceOnlyBeforeMove && (this.BelongedFaction != null))
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            return !this.BelongedFaction.AllowAttackAfterMoveOfBubing;

                        case MilitaryType.弩兵:
                            return !this.BelongedFaction.AllowAttackAfterMoveOfNubing;

                        case MilitaryType.骑兵:
                            return !this.BelongedFaction.AllowAttackAfterMoveOfQibing;

                        case MilitaryType.水军:
                            return !this.BelongedFaction.AllowAttackAfterMoveOfShuijun;

                        case MilitaryType.器械:
                            return !this.BelongedFaction.AllowAttackAfterMoveOfQixie;
                    }
                }
                return this.Army.Kind.OffenceOnlyBeforeMove;
            }
        }

        public string OffenceOnlyBeforeMoveString
        {
            get
            {
                return (this.OffenceOnlyBeforeMove ? "是" : "否");
            }
        }

        public int OffenceRadius
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    switch (this.Army.Kind.Type)
                    {
                        case MilitaryType.步兵:
                            return (this.Army.Kind.OffenceRadius + this.BelongedFaction.OffenceRadiusIncrementOfBubing);

                        case MilitaryType.弩兵:
                            return (this.Army.Kind.OffenceRadius + this.BelongedFaction.OffenceRadiusIncrementOfNubing);

                        case MilitaryType.骑兵:
                            return (this.Army.Kind.OffenceRadius + this.BelongedFaction.OffenceRadiusIncrementOfQibing);

                        case MilitaryType.水军:
                            return (this.Army.Kind.OffenceRadius + this.BelongedFaction.OffenceRadiusIncrementOfShuijun);

                        case MilitaryType.器械:
                            return (this.Army.Kind.OffenceRadius + this.BelongedFaction.OffenceRadiusIncrementOfQixie);
                    }
                }
                return this.Army.Kind.OffenceRadius;
            }
        }

        public bool Operated
        {
            get
            {
                return this.operated;
            }
            set
            {
                this.operated = value;
            }
        }

        public bool OperationDone
        {
            get
            {
                return this.operationDone;
            }
            set
            {
                this.operationDone = value;
            }
        }

        public int PersonCount
        {
            get
            {
                return this.Persons.Count;
            }
        }

        public int PlainAdaptability
        {
            get
            {
                return (this.Army.Kind.PlainAdaptability - this.DecrementOfPlainAdaptability);
            }
        }

        public float PlainRate
        {
            get
            {
                return this.Army.Kind.PlainRate;
            }
        }

        public Point Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (!this.Destroyed)
                {
                    this.PreviousPosition = this.position;
                    this.position = value;
                    if (this.position != this.PreviousPosition)
                    {
                        this.Action = TroopAction.Move;
                    }
                    if ((this.position == this.destination) && (this.OnEndPath != null))
                    {
                        this.OnEndPath(this);
                    }
                    int num = this.position.X - this.PreviousPosition.X;
                    int num2 = this.position.Y - this.PreviousPosition.Y;
                    base.Scenario.SetMapTileTroop(this);
                    if ((Math.Abs(num) + Math.Abs(num2)) > 0)
                    {
                        this.TryToPlaySound(this.Position, this.Army.Kind.Sounds.MovingSoundPath, false);
                        this.CheckCurrentPosition();
                        if (this.Destroyed)
                        {
                            return;
                        }
                        this.ResetTerrainData();
                        this.RefreshTerrainRelatedData();
                        this.MoveContactArea(num, num2);
                        this.MoveOffenceArea(num, num2);
                        this.MoveStratagemArea(num, num2);
                        this.MoveViewArea(num, num2);
                    }
                    if (base.Scenario.GetTroopByPosition(this.position) == this)
                    {
                        this.StepFinished = true;
                    }
                    else
                    {
                        this.StepFinished = false;
                    }
                    if (this.FirstTierPath != null)
                    {
                        this.UpdateAnimation();
                    }
                }
            }
        }

        public TroopPreAction PreAction
        {
            get
            {
                return this.preAction;
            }
            set
            {
                this.preAction = value;
                this.currentTileAnimationIndex = 0;
                this.currentTileStayIndex = 0;
                switch (value)
                {
                    case TroopPreAction.暴击:
                        this.CurrentTileAnimationKind = TileAnimationKind.暴击;
                        break;

                    case TroopPreAction.伏击:
                        this.CurrentTileAnimationKind = TileAnimationKind.伏击;
                        break;

                    case TroopPreAction.恢复:
                        this.CurrentTileAnimationKind = TileAnimationKind.恢复;
                        break;

                    case TroopPreAction.致乱:
                        this.CurrentTileAnimationKind = TileAnimationKind.致乱;
                        break;

                    case TroopPreAction.鼓舞:
                        this.CurrentTileAnimationKind = TileAnimationKind.鼓舞;
                        break;
                }
                if (this.preAction != TroopPreAction.无)
                {
                    this.TryToPlaySound(this.Position, base.Scenario.GameCommonData.AllTileAnimations.GetAnimation((int) this.CurrentTileAnimationKind).SoundPath, false);
                }
            }
        }

        public int PureFightingForce
        {
            get
            {
                return (((1 + this.Offence) + this.Defence) * (((((((((((1 + (((this.CurrentArchitecture != null) && (this.CurrentArchitecture.Endurance > 0)) ? 10 : 0)) + (this.Quantity / 500)) + (this.Combativity / 4)) + (this.HasCombatTitle ? (20 * this.Leader.CombatTitle.Level) : 0)) + (this.CombatMethods.Count * 5)) + (this.Stunts.Count * 20)) + this.CriticalStrikeChance) + this.AntiCriticalStrikeChance) + this.ChaosAfterCriticalStrikeChance) + (this.AvoidSurroundedChance / 2)) + this.ChaosAfterSurroundAttackChance));
            }
        }

        public int Quantity
        {
            get
            {
                return this.Army.Quantity;
            }
            set
            {
                this.Army.Quantity = value;
            }
        }

        public int RationDays
        {
            get
            {
                return (this.Army.RationDays + this.IncrementOfRationDays);
            }
        }

        public int RationDaysLeft
        {
            get
            {
                if (this.FoodCostPerDay == 0)
                {
                    return this.RationDays;
                }
                return (this.Food / this.FoodCostPerDay);
            }
        }

        public string RationDaysString
        {
            get
            {
                return (this.RationDaysLeft + "/" + this.RationDays);
            }
        }

        public Point RealDestination
        {
            get
            {
                return this.realDestination;
            }
            set
            {
                this.realDestination = value;
                this.Destination = value;
            }
        }

        public string RealDestinationString
        {
            get
            {
                return base.Scenario.PositionString(this.realDestination);
            }
        }

        public int RealMovability
        {
            get
            {
                return (int) ((this.Army.Kind.Movability + this.IncrementOfMovability) * this.RateOfMovability);
            }
        }

        public int RidgeAdaptability
        {
            get
            {
                return (this.Army.Kind.RidgeAdaptability - this.DecrementOfRidgeAdaptability);
            }
        }

        public float RidgeRate
        {
            get
            {
                return this.Army.Kind.RidgeRate;
            }
        }

        public InformationLevel ScoutLevel
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    if (this.BelongedFaction.LevelOfView < InformationLevel.高)
                    {
                        return InformationLevel.中;
                    }
                    return this.BelongedFaction.LevelOfView;
                }
                if (this.HighLevelInformationOnScout)
                {
                    return InformationLevel.高;
                }
                return InformationLevel.中;
            }
        }

        public int SecondIndex
        {
            get
            {
                return this.secondTierPathDestinationIndex;
            }
            set
            {
                this.secondTierPathDestinationIndex = value;
            }
        }

        private int[,] SecondTierMapCost
        {
            get
            {
                return this.BelongedFaction.SecondTierMapCost;
            }
        }

        public string SectionString
        {
            get
            {
                if ((this.StartingArchitecture != null) && (this.StartingArchitecture.BelongedFaction == this.BelongedFaction))
                {
                    return this.StartingArchitecture.SectionString;
                }
                return "----";
            }
        }

        public Point SelfCastPosition
        {
            get
            {
                return this.selfCastPosition;
            }
            set
            {
                this.selfCastPosition = value;
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

        public int SimulatingFightingForce
        {
            get
            {
                return (((1 + this.Offence) + this.Defence) * ((((((((((((((((((((((((((1 + (((this.CurrentArchitecture != null) && (this.CurrentArchitecture.Endurance > 0)) ? 10 : 0)) + (this.TroopIntelligence / 2)) + (this.Quantity / 500)) + (this.Combativity / 4)) + (this.HasPersonalTitle ? (this.Leader.PersonalTitle.Influences.HasInfluence(this.Army.Kind.TitleInfluence) ? 100 : 0) : 0)) + (this.HasCombatTitle ? ((20 * this.Leader.CombatTitle.Level) + (this.Leader.CombatTitle.Influences.HasInfluence(this.Army.Kind.TitleInfluence) ? 100 : 0)) : 0)) + (this.CombatMethods.Count * 5)) + (this.Stunts.Count * 20)) + this.CriticalStrikeChance) + this.AntiCriticalStrikeChance) + this.ChaosAfterCriticalStrikeChance) + (this.AvoidSurroundedChance / 2)) + this.ChaosAfterSurroundAttackChance) + this.StratagemChanceIncrement) + this.AntiStratagemChanceIncrement) + this.ChaosAfterStratagemSuccessChance) + (this.ChanceIncrementOfCriticalStrikeInViewArea * 4)) + (this.ChanceDecrementOfCriticalStrikeInViewArea * 4)) + (this.CombativityIncrementPerDayInViewArea * 4)) + (this.CombativityDecrementPerDayInViewArea * 4)) + (this.ChanceIncrementOfStratagemInViewArea * 4)) + (this.ChanceDecrementOfStratagemInViewArea * 4)) + ((int) (this.OffenceRateIncrementInViewArea * 100f))) + ((int) (this.OffenceRateDecrementInViewArea * 100f))) + ((int) (this.DefenceRateIncrementInViewArea * 100f))) + ((int) (this.DefenceRateDecrementInViewArea * 100f))));
            }
        }

        public int Speed
        {
            get
            {
                return (int) (((this.CurrentRate * this.Army.Kind.Speed) * this.Army.Morale) / ((float) this.Army.MoraleCeiling));
            }
        }

        public TroopStatus Status
        {
            get
            {
                return this.status;
            }
            set
            {
                this.status = value;
                switch (value)
                {
                    case TroopStatus.一般:
                        this.CurrentTileAnimationKind = TileAnimationKind.无;
                        break;

                    case TroopStatus.混乱:
                        this.CurrentTileAnimationKind = TileAnimationKind.混乱;
                        break;

                    case TroopStatus.埋伏:
                        this.CurrentTileAnimationKind = TileAnimationKind.埋伏;
                        break;
                }
                if (this.CurrentTileAnimationKind != TileAnimationKind.无)
                {
                    this.TryToPlaySound(this.Position, base.Scenario.GameCommonData.AllTileAnimations.GetAnimation((int) this.CurrentTileAnimationKind).SoundPath, false);
                }
            }
        }

        public Animation StatusTileAnimation
        {
            get
            {
                switch (this.Status)
                {
                    case TroopStatus.混乱:
                        return base.Scenario.GameCommonData.AllTileAnimations.GetAnimation(7);

                    case TroopStatus.埋伏:
                        return base.Scenario.GameCommonData.AllTileAnimations.GetAnimation(4);
                }
                return null;
            }
        }

        public bool StepFinished
        {
            get
            {
                return this.stepFinished;
            }
            set
            {
                this.stepFinished = value;
            }
        }

        public GameArea StratagemArea
        {
            get
            {
                if (this.stratagemArea == null)
                {
                    this.stratagemArea = GameArea.GetViewArea(this.Position, this.StratagemRadius, this.ObliqueStratagem, base.Scenario, null);
                }
                return this.stratagemArea;
            }
            set
            {
                this.stratagemArea = value;
            }
        }

        public int StratagemChanceIncrement
        {
            get
            {
                return this.stratagemChanceIncrement;
            }
        }

        public int StratagemRadius
        {
            get
            {
                return (this.Army.Kind.StratagemRadius + this.IncrementOfStratagemRadius);
            }
        }

        public StratagemTable Stratagems
        {
            get
            {
                return base.Scenario.GameCommonData.AllStratagems;
            }
        }

        public int StuntDayLeft
        {
            get
            {
                return this.stuntDayLeft;
            }
            set
            {
                this.stuntDayLeft = value;
            }
        }

        public Animation StuntTileAnimation
        {
            get
            {
                if (this.CurrentStunt != null)
                {
                    return base.Scenario.GameCommonData.AllTileAnimations.GetAnimation(this.CurrentStunt.Animation);
                }
                return null;
            }
        }

        public Architecture TargetArchitecture
        {
            get
            {
                if (this.targetArchitecture == null)
                {
                    this.targetArchitecture = base.Scenario.Architectures.GetGameObject(this.targetArchitectureID) as Architecture;
                }
                return this.targetArchitecture;
            }
            set
            {
                this.targetArchitecture = value;
                if (value != null)
                {
                    this.targetArchitectureID = value.ID;
                }
                else
                {
                    this.targetArchitectureID = -1;
                }
            }
        }

        public int TargetArchitectureID
        {
            get
            {
                return this.targetArchitectureID;
            }
            set
            {
                this.targetArchitectureID = value;
            }
        }

        public string TargetArchitectureString
        {
            get
            {
                if (this.targetArchitectureID < 0)
                {
                    return "----";
                }
                return this.TargetArchitecture.Name;
            }
        }

        public string TargetString
        {
            get
            {
                if (this.TargetTroop != null)
                {
                    return this.TargetTroop.DisplayName;
                }
                return this.TargetArchitectureString;
            }
        }

        public Troop TargetTroop
        {
            get
            {
                if (this.targetTroop == null)
                {
                    this.targetTroop = base.Scenario.Troops.GetGameObject(this.targetTroopID) as Troop;
                }
                else if (this.targetTroop.Destroyed)
                {
                    this.targetTroopID = -1;
                    this.targetTroop = null;
                }
                return this.targetTroop;
            }
            set
            {
                this.targetTroop = value;
                if (value != null)
                {
                    this.targetTroopID = value.ID;
                }
                else
                {
                    this.targetTroopID = -1;
                }
            }
        }

        public int TargetTroopID
        {
            get
            {
                return this.targetTroopID;
            }
            set
            {
                this.targetTroopID = value;
            }
        }

        public string TargetTroopString
        {
            get
            {
                return ((this.TargetTroop != null) ? this.TargetTroop.DisplayName : "----");
            }
        }

        public int TechnologyIncrement
        {
            get
            {
                return this.technologyIncrement;
            }
            set
            {
                this.technologyIncrement = value;
            }
        }

        public int ThirdIndex
        {
            get
            {
                return this.thirdTierPathDestinationIndex;
            }
            set
            {
                this.thirdTierPathDestinationIndex = value;
            }
        }

        private int[,] ThirdTierMapCost
        {
            get
            {
                return this.BelongedFaction.ThirdTierMapCost;
            }
        }

        public Animation TileAnimation
        {
            get
            {
                return base.Scenario.GameCommonData.AllTileAnimations.GetAnimation((int) this.CurrentTileAnimationKind);
            }
        }

        public int TotalQuantity
        {
            get
            {
                return this.Army.TotalQuantity;
            }
        }

        public int TroopCommand
        {
            get
            {
                return this.troopCommand;
            }
        }

        public int TroopIntelligence
        {
            get
            {
                return this.troopIntelligence;
            }
        }

        public bool TroopNoAccidentalInjury
        {
            get
            {
                return (this.BaseNoAccidentalInjury || this.NoAccidentalInjury);
            }
        }

        public int TroopStrength
        {
            get
            {
                return this.troopStrength;
            }
        }

        public Texture2D TroopTexture
        {
            get
            {
                return this.GetTroopTexture();
            }
        }

        public List<Point> UnfinishedFirstTierPath
        {
            get
            {
                return this.FirstTierPath.GetRange(this.firstTierPathIndex + 1, (this.FirstTierPath.Count - this.firstTierPathIndex) - 1);
            }
        }

        public List<Point> UnfinishedSecondTierPath
        {
            get
            {
                return this.SecondTierPath.GetRange(this.secondTierPathDestinationIndex, this.SecondTierPath.Count - this.secondTierPathDestinationIndex);
            }
        }

        public List<Point> UnfinishedThirdTierPath
        {
            get
            {
                return this.ThirdTierPath.GetRange(this.thirdTierPathDestinationIndex, this.ThirdTierPath.Count - this.thirdTierPathDestinationIndex);
            }
        }

        public bool Unique
        {
            get
            {
                return this.Army.Kind.Unique;
            }
        }

        public string UniqueString
        {
            get
            {
                return this.Army.Kind.UniqueString;
            }
        }

        public GameArea ViewArea
        {
            get
            {
                if (this.viewArea == null)
                {
                    this.viewArea = GameArea.GetViewArea(this.Position, this.ViewRadius, this.ObliqueView, base.Scenario, this.BelongedFaction);
                }
                return this.viewArea;
            }
            set
            {
                this.viewArea = value;
            }
        }

        public int ViewRadius
        {
            get
            {
                if (this.BelongedFaction != null)
                {
                    return (this.Army.Kind.ViewRadius + this.BelongedFaction.IncrementOfViewRadius);
                }
                return this.Army.Kind.ViewRadius;
            }
        }

        public int WaitForDeepChaosFrameCount
        {
            get
            {
                return this.waitForDeepChaosFrameCount;
            }
            set
            {
                this.waitForDeepChaosFrameCount = value;
                if (((value == 0) && this.WaitForDeepChaos) && ((this.OrientationTroop != null) && !this.OrientationTroop.Destroyed))
                {
                    if (this.OnCastDeepChaos != null)
                    {
                        this.OnCastDeepChaos(this, this.OrientationTroop);
                    }
                    this.PreAction = TroopPreAction.致乱;
                    this.Action = TroopAction.Cast;
                    this.OrientationTroop.Action = TroopAction.BeCasted;
                }
            }
        }

        public int WastelandAdaptability
        {
            get
            {
                return (this.Army.Kind.WastelandAdaptability - this.DecrementOfWastelandAdaptability);
            }
        }

        public float WastelandRate
        {
            get
            {
                return this.Army.Kind.WastelandRate;
            }
        }

        public int WaterAdaptability
        {
            get
            {
                return (this.Army.Kind.WaterAdaptability - this.DecrementOfWaterAdaptability);
            }
        }

        public float WaterRate
        {
            get
            {
                return this.Army.Kind.WaterRate;
            }
        }

        public int Weighing
        {
            get
            {
                int num = 1;
                int num2 = 1;
                if ((((((this.ChanceIncrementOfCriticalStrikeInViewArea > 0) || (this.ChanceDecrementOfCriticalStrikeInViewArea > 0)) || ((this.CombativityIncrementPerDayInViewArea > 0) || (this.CombativityDecrementPerDayInViewArea > 0))) || (((this.ChanceIncrementOfStratagemInViewArea > 0) || (this.ChanceDecrementOfStratagemInViewArea > 0)) || ((this.OffenceRateIncrementInViewArea > 0f) || (this.OffenceRateDecrementInViewArea > 0f)))) || (this.DefenceRateIncrementInViewArea > 0f)) || (this.DefenceRateDecrementInViewArea > 0f))
                {
                    num += 2;
                }
                foreach (Person person in this.Persons)
                {
                    if (person == this.BelongedFaction.Leader)
                    {
                        num++;
                        break;
                    }
                }
                if (!this.ControlAvail())
                {
                    num2++;
                }
                return ((num * this.FightingForce) / num2);
            }
        }

        public TroopWill Will
        {
            get
            {
                return this.will;
            }
            set
            {
                this.will = value;
            }
        }

        public Architecture WillArchitecture
        {
            get
            {
                if (this.willArchitecture == null)
                {
                    this.willArchitecture = base.Scenario.Architectures.GetGameObject(this.willArchitectureID) as Architecture;
                    if (this.willArchitecture == null)
                    {
                        this.WillArchitecture = this.StartingArchitecture;
                    }
                }
                return this.willArchitecture;
            }
            set
            {
                this.willArchitecture = value;
                if (value != null)
                {
                    this.willArchitectureID = value.ID;
                }
                else
                {
                    this.willArchitectureID = -1;
                }
            }
        }

        public int WillArchitectureID
        {
            get
            {
                return this.willArchitectureID;
            }
            set
            {
                this.willArchitectureID = value;
            }
        }

        public string WillArchitectureString
        {
            get
            {
                if (this.willArchitectureID < 0)
                {
                    return "----";
                }
                return this.WillArchitecture.Name;
            }
        }

        public string WillString
        {
            get
            {
                if (this.WillTroop != null)
                {
                    return this.WillTroop.DisplayName;
                }
                return this.WillArchitectureString;
            }
        }

        public Troop WillTroop
        {
            get
            {
                if (this.willTroop == null)
                {
                    this.willTroop = base.Scenario.Troops.GetGameObject(this.willTroopID) as Troop;
                }
                else if (this.willTroop.Destroyed)
                {
                    this.willTroopID = -1;
                    this.willTroop = null;
                }
                return this.willTroop;
            }
            set
            {
                this.willTroop = value;
                if (value != null)
                {
                    this.willTroopID = value.ID;
                }
                else
                {
                    this.willTroopID = -1;
                }
            }
        }

        public int WillTroopID
        {
            get
            {
                return this.willTroopID;
            }
            set
            {
                this.willTroopID = value;
            }
        }

        public string WillTroopString
        {
            get
            {
                return ((this.WillTroop != null) ? this.WillTroop.DisplayName : "----");
            }
        }

        public delegate void Ambush(Troop troop);

        public delegate void AntiArrowAttack(Troop sending, Troop receiving);

        public delegate void AntiAttack(Troop sending, Troop receiving);

        public delegate void ApplyStunt(Troop troop, Stunt stunt);

        public delegate void BreakWall(Troop troop, Architecture architecture);

        public delegate void CastDeepChaos(Troop sending, Troop receiving);

        public delegate void CastStratagem(Troop sending, Troop receiving, Stratagem stratagem);

        public delegate void Chaos(Troop troop, bool deepChaos);

        public delegate void CombatMethodAttack(Troop sending, Troop receiving, CombatMethod combatMethod);

        private class CreditPack
        {
            internal int Credit;
            internal CombatMethod CurrentCombatMethod;
            internal Stratagem CurrentStratagem;
            internal double Distance;
            internal bool HasUnAttackableTroop;
            internal Point Position;
            internal Point SelfCastPosition;
            internal Architecture TargetArchitecture;
            internal Troop TargetTroop;

            public override string ToString()
            {
                return ((string.Concat(new object[] { this.Position.ToString(), " ", this.Credit, this.TargetTroop }) != null) ? this.TargetTroop.DisplayName : (((this.TargetArchitecture) != null) ? this.TargetArchitecture.Name : ""));
            }
        }

        public delegate void CriticalStrike(Troop sending, Troop receiving);

        public delegate void DiscoverAmbush(Troop sending, Troop receiving);

        public delegate void EndCutRouteway(Troop troop, bool success);

        public delegate void EndPath(Troop troop);

        public delegate void EnterFactionArea(Troop troop, Faction factionEntered);

        public delegate void GetNewCaptive(Troop troop, PersonList personlist);

        public delegate void GetSpreadBurnt(Troop troop);

        public delegate void LeaveFactionArea(Troop troop, Faction factionLeft);

        public delegate void LevyFieldFood(Troop troop, int food);

        public delegate void NormalAttack(Troop sending, Troop receiving);

        public delegate void OccupyArchitecture(Troop troop, Architecture architecture);

        public delegate void Outburst(Troop troop, OutburstKind kind);

        public delegate void PathNotFound(Troop troop);

        public delegate void PersonChallenge(bool win, Troop sourceTroop, Person source, Troop destinationTroop, Person destination);

        public delegate void PersonControversy(bool win, Troop sourceTroop, Person source, Troop destinationTroop, Person destination);

        public delegate void ReceiveCriticalStrike(Troop sending, Troop receiving);

        public delegate void ReceiveWaylay(Troop sending, Troop receiving);

        public delegate void RecoverFromChaos(Troop troop);

        public delegate void ReleaseCaptive(Troop troop, PersonList personlist);

        public delegate void ResistStratagem(Troop sending, Troop receiving, Stratagem stratagem, bool isHarmful);

        public delegate void Rout(Troop sending, Troop receiving);

        public delegate void Routed(Troop sending, Troop receiving);

        public delegate void SetCombatMethod(Troop troop, CombatMethod combatMethod);

        public delegate void SetStratagem(Troop troop, Stratagem stratagem);

        public delegate void StartCutRouteway(Troop troop, int days);

        public delegate void StartPath(Troop troop);

        public delegate void StopAmbush(Troop troop);

        public delegate void StratagemSuccess(Troop sending, Troop receiving, Stratagem stratagem, bool isHarmful);

        public delegate void Surround(Troop sending, Troop receiving);

        public delegate void TroopCreate(Troop troop);

        public delegate void TroopFound(Troop troop, Troop troopFound);

        public delegate void TroopLost(Troop troop, Troop troopLost);

        public delegate void Waylay(Troop sending, Troop receiving);
    }
}

