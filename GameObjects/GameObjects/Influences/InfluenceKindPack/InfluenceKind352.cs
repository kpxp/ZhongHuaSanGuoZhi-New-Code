namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind352 : InfluenceKind
    {
        private float limit = 1f;
        private float rate = 0f;

        public override void ApplyInfluenceKind(Troop troop)
        {
            if (troop.WaterRate <= this.limit)
            {
                if ((troop.WaterRate + this.rate) > this.limit)
                {
                    troop.RateIncrementOfTerrainRateOnWater = this.limit - troop.WaterRate;
                }
                else
                {
                    troop.RateIncrementOfTerrainRateOnWater = this.rate;
                }
            }
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

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.limit = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.RateIncrementOfTerrainRateOnWater = 0;
        }
    }
}

