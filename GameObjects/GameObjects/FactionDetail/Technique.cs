namespace GameObjects.FactionDetail
{
    using GameObjects;
    using GameObjects.Influences;
    using GameObjects.Conditions;
    using System;

    public class Technique : GameObject
    {
        private int days;
        private string description;
        private int displayCol;
        private int displayRow;
        private int fundCost;
        public InfluenceTable Influences = new InfluenceTable();
        public ConditionTable Conditions = new ConditionTable();
        private int kind;
        private int pointCost;
        private int postID;
        private int preID;
        private int reputation;

        public GameObjectList GetInfluenceList()
        {
            return this.Influences.GetInfluenceList();
        }

        public int Days
        {
            get
            {
                return this.days;
            }
            set
            {
                this.days = value;
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

        public int FundCost
        {
            get
            {
                return this.fundCost;
            }
            set
            {
                this.fundCost = value;
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

        public int PointCost
        {
            get
            {
                return this.pointCost;
            }
            set
            {
                this.pointCost = value;
            }
        }

        public int PostID
        {
            get
            {
                return this.postID;
            }
            set
            {
                this.postID = value;
            }
        }

        public int PreID
        {
            get
            {
                return this.preID;
            }
            set
            {
                this.preID = value;
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

        public bool CanResearch(Faction f)
        {
            foreach (Condition condition in this.Conditions.Conditions.Values)
            {
                if (!condition.CheckCondition(f))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

