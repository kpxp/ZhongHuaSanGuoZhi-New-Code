namespace GameObjects.PersonDetail
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using GameObjects.TroopDetail;
    using System;
    using System.Collections.Generic;

    public class Skill : GameObject
    {
        private bool combat;
        public ConditionTable Conditions = new ConditionTable();
        private int displayCol;
        private int displayRow;
        public InfluenceTable Influences = new InfluenceTable();
        private int kind;
        private int level;

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

        public virtual bool CanLearn(Person person)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
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
            foreach (Condition condition in this.Conditions.Conditions.Values)
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

        public GameObjectList GetConditionList()
        {
            return this.Conditions.GetConditionList();
        }

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public bool Combat
        {
            get
            {
                return this.combat;
            }
            set
            {
                this.combat = value;
            }
        }

        public int ConditionCount
        {
            get
            {
                return this.Conditions.Count;
            }
        }

        public string Description
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

        public int DisplayCol
        {
            get
            {
                return this.displayCol;
            }
            set
            {
                this.displayCol = value;
            }
        }

        public int DisplayRow
        {
            get
            {
                return this.displayRow;
            }
            set
            {
                this.displayRow = value;
            }
        }

        public int InfluenceCount
        {
            get
            {
                return this.Influences.Count;
            }
        }

        public int Kind
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

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                this.level = value;
            }
        }

        public int Merit
        {
            get
            {
                return (this.Level * 5);
            }
        }

        public string Prerequisite
        {
            get
            {
                string str = "";
                foreach (Condition condition in this.Conditions.Conditions.Values)
                {
                    str = str + "•" + condition.Name;
                }
                return str;
            }
        }

        private int? subOfficerMerit = null;
        public int SubOfficerMerit
        {
            get
            {
                if (subOfficerMerit == null)
                {
                    int subofficerInfluences = 0;
                    foreach (Influence i in this.Influences.Influences.Values)
                    {
                        if (i.Kind.ID == 281) break;
                        if (i.Kind.Combat)
                        {
                            subofficerInfluences++;
                        }
                    }
                    subOfficerMerit = (int)(this.Merit * ((double)subofficerInfluences / this.Influences.Count));
                }
                return subOfficerMerit.Value;
            }
        }

        public bool CanBeChosenForGenerated()
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (condition.Kind.ID == 902) return false;
            }
            return true;
        }
    }
}

