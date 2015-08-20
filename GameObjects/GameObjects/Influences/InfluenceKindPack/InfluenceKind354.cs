namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind354 : InfluenceKind
    {
        private float rate = 0f;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.RateIncrementOfRateOnWater += this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.RateIncrementOfRateOnWater -= this.rate;
        }
    }
}

