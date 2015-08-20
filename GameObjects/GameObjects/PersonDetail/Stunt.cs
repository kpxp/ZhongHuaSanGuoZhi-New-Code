namespace GameObjects.PersonDetail
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using GameObjects.TroopDetail;
    using System;
    using System.Collections.Generic;

    public class Stunt : GameObject
    {
        public ConditionTable AIConditions = new ConditionTable();
        private int animation;
        public ConditionTable CastConditions = new ConditionTable();
        private int combativity;
        public InfluenceTable Influences = new InfluenceTable();
        public ConditionTable LearnConditions = new ConditionTable();
        private int period;

        private int[] generationChance = new int[10];
        public int[] GenerationChance
        {
            get
            {
                return generationChance;
            }
        }
        public int RelatedAbility { get; set; }

        public int GetRelatedAbility(Person p)
        {
            switch (RelatedAbility)
            {
                case 0: return p.Strength;
                case 1: return p.Command;
                case 2: return p.Intelligence;
                case 3: return p.Politics;
                case 4: return p.Glamour;
            }
            return 0;
        }

        public MilitaryType MilitaryTypeOnly
        {
            get
            {
                foreach (Influence i in this.Influences.Influences.Values)
                {
                    if (i.Kind.ID == 290)
                    {
                        return (MilitaryType)Enum.Parse(typeof(MilitaryType), i.Parameter);
                    }
                }
                return MilitaryType.其他;
            }
        }

        public void Apply(Troop troop)
        {
            troop.DecreaseCombativity(this.Combativity);
            troop.StuntDayLeft = this.Period;
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                influence.ApplyInfluence(troop.Leader, Applier.Stunt, 0, false);
            }
            troop.RefreshAllData();
        }

        public GameObjectList GetAIConditionList()
        {
            return this.AIConditions.GetConditionList();
        }

        public GameObjectList GetCastConditionList()
        {
            return this.CastConditions.GetConditionList();
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public GameObjectList GetLearnConditionList()
        {
            return this.LearnConditions.GetConditionList();
        }

        public bool IsAIable(Troop troop)
        {
            foreach (Condition condition in this.AIConditions.Conditions.Values)
            {
                if (!condition.CheckCondition(troop))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsCastable(Troop troop)
        {
            foreach (Condition condition in this.CastConditions.Conditions.Values)
            {
                if (!condition.CheckCondition(troop))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsLearnable(Person person)
        {
            foreach (Condition condition in this.LearnConditions.Conditions.Values)
            {
                if (!condition.CheckCondition(person))
                {
                    return false;
                }
            }
            return true;
        }

        public virtual bool CanBeBorn(Person person)
        {
            foreach (Condition condition in this.LearnConditions.Conditions.Values)
            {
                if (condition.Kind.ID == 901) return false;
                if (new List<int> { 600, 610, 970, 971 }.Contains(condition.Kind.ID))
                {
                    if (!condition.CheckCondition(person))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void Purify(Troop troop)
        {
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                influence.PurifyInfluence(troop.Leader, Applier.Stunt, 0, false);
            }
        }

        public string AIConditionString
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.AIConditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }

        public int Animation
        {
            get
            {
                return this.animation;
            }
            set
            {
                this.animation = value;
            }
        }

        public string CastConditionString
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.CastConditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }

        public int Combativity
        {
            get
            {
                return this.combativity;
            }
            set
            {
                this.combativity = value;
            }
        }

        public string InfluenceString
        {
            get
            {
                string str = "";
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    str = str + "•" + influence.Description;
                }
                return str;
            }
        }

        public string LearnConditionString
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.LearnConditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }

        public int Period
        {
            get
            {
                return this.period;
            }
            set
            {
                this.period = value;
            }
        }

        public bool CanBeChosenForGenerated()
        {
            foreach (Condition condition in this.LearnConditions.Conditions.Values)
            {
                if (condition.Kind.ID == 902) return false;
            }
            return true;
        }
    }
}

