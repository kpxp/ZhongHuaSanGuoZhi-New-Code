namespace GameObjects.TroopDetail
{
    using GameObjects;
    using GameObjects.Influences;
    using GameObjects.Conditions;
    using System;
    using System.Collections.Generic;

    public class MilitaryKind : GameObject
    {
        private float fireDamageRate;
        private bool airOffence;
        private float architectureCounterDamageRate;
        private float architectureDamageRate;
        private bool arrowOffence;
        private TroopAttackDefaultKind attackDefaultKind;
        private TroopAttackTargetKind attackTargetKind;
        private bool beCountered;
        private bool canLevelUp;
        private TroopCastDefaultKind castDefaultKind;
        private TroopCastTargetKind castTargetKind;
        private int cliffAdaptability;
        private float cliffRate;
        private bool contactOffence;
        private bool counterOffence;
        private bool createBesideWater;
        private int createCost;
        private int createTechnology;
        private int defence;
        private int defencePer100Experience;
        private int defencePerScale;
        private string description;
        private int desertAdaptability;
        private float desertRate;
        private int foodPerSoldier;
        private int forrestAdaptability;
        private float forrestRate;
        private int grasslandAdaptability;
        private float grasslandRate;
        public InfluenceTable Influences = new InfluenceTable();
        private int injuryChance;
        private bool isShell;
        private int levelUpExperience;
        private List<int> levelUpKindID = new List<int>();
        private int marshAdaptability;
        private float marshRate;
        private int maxScale;
        private int merit;
        private int minScale;
        private int mountainAdaptability;
        private float mountainRate;
        private int movability;
        private bool obliqueOffence;
        private bool obliqueStratagem;
        private bool obliqueView;
        private int offence;
        private bool offenceOnlyBeforeMove;
        private int offencePer100Experience;
        private int offencePerScale;
        private int offenceRadius;
        private int oneAdaptabilityKind;
        private int plainAdaptability;
        private float plainRate;
        private int pointsPerSoldier;
        private int rationDays;
        private int ridgeAdaptability;
        private float ridgeRate;
        public TroopSounds Sounds;
        private int speed;
        private int stratagemRadius;
        public TroopTextures Textures;
        private int titleInfluence = -1;
        private MilitaryType type;
        private int recruitLimit;
        private int viewRadius;
        private int wastelandAdaptability;
        private float wastelandRate;
        private int waterAdaptability;
        private float waterRate;
        public int zijinshangxian;

        private int morphToKindId = -1;

        public ConditionTable CreateConditions = new ConditionTable();

        public MilitaryKindTable successor;
        private bool findSuccessor_visited;

        public int MinCommand { get; set; }

        public PersonList Persons = new PersonList();
        public int ObtainProb
        {
            get;
            set;
        }

        public bool LevelUpAvail(Architecture a)
        {
            return !a.BelongedFaction.IsMilitaryKindOverLimit(base.ID) && this.CheckConditions(a);
        }

        public bool CreateAvail(Architecture a)
        {
            if (this.IsShell)
            {
                return false;
            }
            if ((a.Fund < (this.CreateCost * this.GetRateOfNewMilitary(a))) || (a.Technology < this.CreateTechnology))
            {
                return false;
            }
            if (a.BelongedFaction.IsMilitaryKindOverLimit(base.ID))
            {
                return false;
            }
            if (!(!this.CreateBesideWater || a.IsBesideWater))
            {
                return false;
            }
            if (!this.CheckConditions(a))
            {
                return false;
            }
            return true;
        }

        public bool IsTransport
        {
            get
            {
                return this.ID == 29;
            }
        }

        public MilitaryKind findSuccessorCreatable(MilitaryKindList allMilitaryKinds, Architecture recruiter)
        {
            foreach (MilitaryKind i in allMilitaryKinds)
            {
                i.findSuccessor_visited = false;
            }
            return findSuccessorRecruitable_r(allMilitaryKinds, recruiter, this);
        }

        private MilitaryKind findSuccessorRecruitable_r(MilitaryKindList allMilitaryKinds, Architecture recruiter, MilitaryKind prev)
        {
            if (prev.successor.GetMilitaryKindList().Count == 0)
            {
                return prev;
            }
            prev.findSuccessor_visited = true;
            MilitaryKindList toVisit = new MilitaryKindList();
            foreach (MilitaryKind i in prev.successor.GetMilitaryKindList())
            {
                if (!i.findSuccessor_visited && recruiter.GetNewMilitaryKindList().GameObjects.Contains(i) && allMilitaryKinds.GetList().GameObjects.Contains(i))
                {
                    toVisit.Add(i);
                }
            }
            if (toVisit.Count == 0)
            {
                return prev;
            }
            return findSuccessorRecruitable_r(allMilitaryKinds, recruiter, toVisit[GameObject.Random(toVisit.Count)] as MilitaryKind);
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public float GetRateOfNewMilitary(Architecture a)
        {
            switch (this.Type)
            {
                case MilitaryType.步兵:
                    return a.RateOfNewBubingMilitaryFundCost;

                case MilitaryType.弩兵:
                    return a.RateOfNewNubingMilitaryFundCost;

                case MilitaryType.骑兵:
                    return a.RateOfNewQibingMilitaryFundCost;

                case MilitaryType.水军:
                    return a.RateOfNewShuijunMilitaryFundCost;

                case MilitaryType.器械:
                    return a.RateOfNewQixieMilitaryFundCost;
            }
            return 1f;
        }

        public int[] Adaptabilities
        {
            get
            {
                return new int[]{this.PlainAdaptability, this.GrasslandAdaptability, this.ForrestAdaptability, this.WastelandAdaptability, this.MarshAdaptability,
                    this.MountainAdaptability, this.CliffAdaptability, this.RidgeAdaptability, this.WaterAdaptability};
            }
        }

        public bool Movable
        {
            get
            {
                foreach (int i in this.Adaptabilities) 
                {
                    if (this.Movability >= i)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public override string ToString()
        {
            return (base.Name + "  " + this.Type.ToString());
        }

        public float FireDamageRate
        {
            get
            {
                return this.fireDamageRate;
            }
            set
            {
                this.fireDamageRate = value;
            }
        }

        public bool AirOffence
        {
            get
            {
                return this.airOffence;
            }
            set
            {
                this.airOffence = value;
            }
        }

        public float ArchitectureCounterDamageRate
        {
            get
            {
                return this.architectureCounterDamageRate;
            }
            set
            {
                this.architectureCounterDamageRate = value;
            }
        }

        public float ArchitectureDamageRate
        {
            get
            {
                return this.architectureDamageRate;
            }
            set
            {
                this.architectureDamageRate = value;
            }
        }

        public bool ArrowOffence
        {
            get
            {
                return this.arrowOffence;
            }
            set
            {
                this.arrowOffence = value;
            }
        }

        public string ArrowOffenceString
        {
            get
            {
                return (this.arrowOffence ? "○" : "×");
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

        public bool BeCountered
        {
            get
            {
                return this.beCountered;
            }
            set
            {
                this.beCountered = value;
            }
        }

        public string BeCounteredString
        {
            get
            {
                return (this.beCountered ? "○" : "×");
            }
        }

        public bool CanLevelUp
        {
            get
            {
                return this.canLevelUp;
            }
            set
            {
                this.canLevelUp = value;
            }
        }

        public string CanLevelUpString
        {
            get
            {
                return (this.CanLevelUp ? "○" : "×");
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

        public int CliffAdaptability
        {
            get
            {
                return this.cliffAdaptability;
            }
            set
            {
                this.cliffAdaptability = value;
            }
        }

        public float CliffRate
        {
            get
            {
                return this.cliffRate;
            }
            set
            {
                this.cliffRate = value;
            }
        }

        public bool ContactOffence
        {
            get
            {
                return this.contactOffence;
            }
            set
            {
                this.contactOffence = value;
            }
        }

        public string ContactOffenceString
        {
            get
            {
                return (this.contactOffence ? "○" : "×");
            }
        }

        public bool CounterOffence
        {
            get
            {
                return this.counterOffence;
            }
            set
            {
                this.counterOffence = value;
            }
        }

        public string CounterOffenceString
        {
            get
            {
                return (this.counterOffence ? "○" : "×");
            }
        }

        public bool CreateBesideWater
        {
            get
            {
                return this.createBesideWater;
            }
            set
            {
                this.createBesideWater = value;
            }
        }

        public string CreateBesideWaterString
        {
            get
            {
                return (this.CreateBesideWater ? "○" : "×");
            }
        }

        public int CreateCost
        {
            get
            {
                return this.createCost;
            }
            set
            {
                this.createCost = value;
            }
        }

        public int CreateTechnology
        {
            get
            {
                return this.createTechnology;
            }
            set
            {
                this.createTechnology = value;
            }
        }

        public int Defence
        {
            get
            {
                return this.defence;
            }
            set
            {
                this.defence = value;
            }
        }

        public int DefencePer100Experience
        {
            get
            {
                return this.defencePer100Experience;
            }
            set
            {
                this.defencePer100Experience = value;
            }
        }

        public int DefencePerScale
        {
            get
            {
                return this.defencePerScale;
            }
            set
            {
                this.defencePerScale = value;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public int DesertAdaptability
        {
            get
            {
                return this.desertAdaptability;
            }
            set
            {
                this.desertAdaptability = value;
            }
        }

        public float DesertRate
        {
            get
            {
                return this.desertRate;
            }
            set
            {
                this.desertRate = value;
            }
        }

        public int FoodPerSoldier
        {
            get
            {
                return this.foodPerSoldier;
            }
            set
            {
                this.foodPerSoldier = value;
            }
        }

        public int ForrestAdaptability
        {
            get
            {
                return this.forrestAdaptability;
            }
            set
            {
                this.forrestAdaptability = value;
            }
        }

        public float ForrestRate
        {
            get
            {
                return this.forrestRate;
            }
            set
            {
                this.forrestRate = value;
            }
        }

        public int GrasslandAdaptability
        {
            get
            {
                return this.grasslandAdaptability;
            }
            set
            {
                this.grasslandAdaptability = value;
            }
        }

        public float GrasslandRate
        {
            get
            {
                return this.grasslandRate;
            }
            set
            {
                this.grasslandRate = value;
            }
        }

        public int InfluenceCount
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public int InjuryChance
        {
            get
            {
                return this.injuryChance;
            }
            set
            {
                this.injuryChance = value;
            }
        }

        public bool IsShell
        {
            get
            {
                return this.isShell;
            }
            set
            {
                this.isShell = value;
            }
        }

        public string IsShellString
        {
            get
            {
                return (this.IsShell ? "○" : "×");
            }
        }

        public int LevelUpExperience
        {
            get
            {
                return this.levelUpExperience;
            }
            set
            {
                this.levelUpExperience = value;
            }
        }

        public List<int> LevelUpKindID
        {
            get
            {
                return this.levelUpKindID;
            }
            set
            {
                this.levelUpKindID.RemoveAll(i => i == -1);
            }
        }

        public List<MilitaryKind> GetLevelUpKinds()
        {
            List<MilitaryKind> result = new List<MilitaryKind>();
            foreach (int id in LevelUpKindID) 
            {
                result.Add(base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(id));
            }
            return result;
        }

        public int MarshAdaptability
        {
            get
            {
                return this.marshAdaptability;
            }
            set
            {
                this.marshAdaptability = value;
            }
        }

        public float MarshRate
        {
            get
            {
                return this.marshRate;
            }
            set
            {
                this.marshRate = value;
            }
        }

        public int MaxScale
        {
            get
            {
                return this.maxScale;
            }
            set
            {
                this.maxScale = value;
            }
        }

        public int Merit
        {
            get
            {
                return this.merit;
            }
            set
            {
                this.merit = value;
            }
        }

        public int MinScale
        {
            get
            {
                return this.minScale;
            }
            set
            {
                this.minScale = value;
            }
        }

        public int MountainAdaptability
        {
            get
            {
                return this.mountainAdaptability;
            }
            set
            {
                this.mountainAdaptability = value;
            }
        }

        public float MountainRate
        {
            get
            {
                return this.mountainRate;
            }
            set
            {
                this.mountainRate = value;
            }
        }

        public int Movability
        {
            get
            {
                return this.movability;
            }
            set
            {
                this.movability = value;
            }
        }

        public bool ObliqueOffence
        {
            get
            {
                return this.obliqueOffence;
            }
            set
            {
                this.obliqueOffence = value;
            }
        }

        public string ObliqueOffenceString
        {
            get
            {
                return (this.obliqueOffence ? "○" : "×");
            }
        }

        public bool ObliqueStratagem
        {
            get
            {
                return this.obliqueStratagem;
            }
            set
            {
                this.obliqueStratagem = value;
            }
        }

        public string ObliqueStratagemString
        {
            get
            {
                return (this.ObliqueStratagem ? "○" : "×");
            }
        }

        public bool ObliqueView
        {
            get
            {
                return this.obliqueView;
            }
            set
            {
                this.obliqueView = value;
            }
        }

        public string ObliqueViewString
        {
            get
            {
                return (this.obliqueView ? "○" : "×");
            }
        }

        public int Offence
        {
            get
            {
                return this.offence;
            }
            set
            {
                this.offence = value;
            }
        }

        public bool OffenceOnlyBeforeMove
        {
            get
            {
                return this.offenceOnlyBeforeMove;
            }
            set
            {
                this.offenceOnlyBeforeMove = value;
            }
        }

        public string OffenceOnlyBeforeMoveString
        {
            get
            {
                return (this.offenceOnlyBeforeMove ? "○" : "×");
            }
        }

        public int OffencePer100Experience
        {
            get
            {
                return this.offencePer100Experience;
            }
            set
            {
                this.offencePer100Experience = value;
            }
        }

        public int OffencePerScale
        {
            get
            {
                return this.offencePerScale;
            }
            set
            {
                this.offencePerScale = value;
            }
        }

        public int OffenceRadius
        {
            get
            {
                return this.offenceRadius;
            }
            set
            {
                this.offenceRadius = value;
            }
        }

        public int OneAdaptabilityKind
        {
            get
            {
                return this.oneAdaptabilityKind;
            }
            set
            {
                this.oneAdaptabilityKind = value;
            }
        }

        public int PlainAdaptability
        {
            get
            {
                return this.plainAdaptability;
            }
            set
            {
                this.plainAdaptability = value;
            }
        }

        public float PlainRate
        {
            get
            {
                return this.plainRate;
            }
            set
            {
                this.plainRate = value;
            }
        }

        public int PointsPerSoldier
        {
            get
            {
                return this.pointsPerSoldier;
            }
            set
            {
                this.pointsPerSoldier = value;
            }
        }

        public int RationDays
        {
            get
            {
                return this.rationDays;
            }
            set
            {
                this.rationDays = value;
            }
        }

        public int RidgeAdaptability
        {
            get
            {
                return this.ridgeAdaptability;
            }
            set
            {
                this.ridgeAdaptability = value;
            }
        }

        public float RidgeRate
        {
            get
            {
                return this.ridgeRate;
            }
            set
            {
                this.ridgeRate = value;
            }
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public int StratagemRadius
        {
            get
            {
                return this.stratagemRadius;
            }
            set
            {
                this.stratagemRadius = value;
            }
        }

        public int TitleInfluence
        {
            get
            {
                return this.titleInfluence;
            }
            set
            {
                this.titleInfluence = value;
            }
        }

        public MilitaryType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public int RecruitLimit
        {
            get
            {
                return this.recruitLimit;
            }
            set
            {
                this.recruitLimit = value;
            }
        }

        public int ViewRadius
        {
            get
            {
                return this.viewRadius;
            }
            set
            {
                this.viewRadius = value;
            }
        }

        public int WastelandAdaptability
        {
            get
            {
                return this.wastelandAdaptability;
            }
            set
            {
                this.wastelandAdaptability = value;
            }
        }

        public float WastelandRate
        {
            get
            {
                return this.wastelandRate;
            }
            set
            {
                this.wastelandRate = value;
            }
        }

        public int WaterAdaptability
        {
            get
            {
                return this.waterAdaptability;
            }
            set
            {
                this.waterAdaptability = value;
            }
        }

        public float WaterRate
        {
            get
            {
                return this.waterRate;
            }
            set
            {
                this.waterRate = value;
            }
        }

        public int MorphToKindId
        {
            get
            {
                return this.morphToKindId;
            }
            set
            {
                this.morphToKindId = value;
            }
        }

        public MilitaryKind MorphTo
        {
            get
            {
                if (!base.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds.ContainsKey(morphToKindId)) return null;
                return base.Scenario.GameCommonData.AllMilitaryKinds.MilitaryKinds[this.morphToKindId];
            }
        }

        public bool CheckConditions(Architecture a)
        {
            foreach (Condition condition in this.CreateConditions.Conditions.Values)
            {
                if (!condition.CheckCondition(a))
                {
                    return false;
                }
            }
            return true;
        }
        /*
        public int EachMilitaryKindCount(Faction f)
        {
            int count = 0;
           // MilitaryKind mk = base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(id);
            if (f != null)
            {
                foreach (Military military in f.Militaries)
                {
                    if (military.RealKindID == this.ID )
                    {
                        count++;
                    }
                }
            }
            
            return count;
        }
        */
    }
}

