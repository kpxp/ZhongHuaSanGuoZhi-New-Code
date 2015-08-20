namespace GameObjects.TroopDetail
{
    using GameObjects;
    using GameObjects.Conditions;
    using GameObjects.Influences;
    using System;
    using GameObjects.Animations;

    public class CombatMethod : GameObject
    {
        private TileAnimationKind animationKind;
        public Influence AI;
        private bool architectureTarget;
        private AttackDefaultKind attackDefault;
        private AttackTargetKind attackTarget;
        public ConditionTable CastConditions = new ConditionTable();
        private int combativity;
        private string description;
        public InfluenceTable Influences = new InfluenceTable();
        private bool viewingHostile;

        public void Apply(Troop troop)
        {
            if ((troop.Combativity + troop.DecrementOfCombatMethodCombativityConsuming) >= this.Combativity)
            {
                troop.CombatMethodApplied = true;
                troop.DecreaseCombativity(this.Combativity - troop.DecrementOfCombatMethodCombativityConsuming);
                troop.ShowNumber = true;
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    influence.ApplyInfluence(troop.Leader, Applier.CombatMethod, 0, false);
                }
            }
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

        public void Purify(Troop troop)
        {
            if (troop.CombatMethodApplied)
            {
                troop.CombatMethodApplied = false;
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    influence.PurifyInfluence(troop.Leader, Applier.CombatMethod, 0, false);
                }
            }
        }

        public bool SimulateApply(Troop troop)
        {
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                influence.ApplyInfluence(troop.Leader, Applier.CombatMethod, 0, false);
            }
            return true;
        }

        public void SimulatePurify(Troop troop)
        {
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                influence.PurifyInfluence(troop.Leader, Applier.CombatMethod, 0, false);
            }
        }

        public bool ArchitectureTarget
        {
            get
            {
                return this.architectureTarget;
            }
            set
            {
                this.architectureTarget = value;
            }
        }

        public AttackDefaultKind AttackDefault
        {
            get
            {
                return this.attackDefault;
            }
            set
            {
                this.attackDefault = value;
            }
        }

        public AttackTargetKind AttackTarget
        {
            get
            {
                return this.attackTarget;
            }
            set
            {
                this.attackTarget = value;
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

        public bool ViewingHostile
        {
            get
            {
                return this.viewingHostile;
            }
            set
            {
                this.viewingHostile = value;
            }
        }

        public TileAnimationKind AnimationKind
        {
            get
            {
                return this.animationKind;
            }
            set
            {
                this.animationKind = value;
            }
        }
    }
}

