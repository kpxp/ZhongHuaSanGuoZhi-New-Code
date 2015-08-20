namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind2310 : InfluenceKind
    {
        private float rate = 0f;

        public override void ApplyInfluenceKind(Faction faction)
        {
            faction.RateIncrementOfTerrainRate += this.rate;
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

        public override void PurifyInfluenceKind(Faction faction)
        {
            faction.RateIncrementOfTerrainRate -= this.rate;
        }
    }
}

