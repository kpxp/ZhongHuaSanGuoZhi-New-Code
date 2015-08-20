namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6570 : InfluenceKind
    {
        private float rate = 0;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.StealTroop += this.rate;
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
            troop.StealTroop -= this.rate;
        }
    }
}

