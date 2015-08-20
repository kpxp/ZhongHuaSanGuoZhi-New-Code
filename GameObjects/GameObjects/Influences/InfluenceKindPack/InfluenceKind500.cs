namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind500 : InfluenceKind
    {
        private int increment;


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.ChanceIncrementOfStratagem += this.increment;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            if (troop != null)
            {
                troop.ChanceIncrementOfStratagem -= this.increment;
            }
        }
    }
}

