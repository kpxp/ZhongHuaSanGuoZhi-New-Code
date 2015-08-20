namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6600 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniqueReputationRateDecrease.Add(this.increment);
            }
        }

        public override void PurifyInfluenceKind(Architecture a)
        {
            if (a.BelongedFaction != null)
            {
                a.BelongedFaction.techniqueReputationRateDecrease.Remove(this.increment);
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override double AIFacilityValue(Architecture a)
        {
            return this.increment;
        }
    }
}

