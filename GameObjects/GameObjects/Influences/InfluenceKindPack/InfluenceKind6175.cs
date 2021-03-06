﻿namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6175 : InfluenceKind
    {
        private int rate;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.ReputationIncrease += rate;
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.ReputationIncrease -= rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override double AIFacilityValue(Architecture a)
        {
            return this.rate * a.PersonCount / 200;
        }
    }
}

