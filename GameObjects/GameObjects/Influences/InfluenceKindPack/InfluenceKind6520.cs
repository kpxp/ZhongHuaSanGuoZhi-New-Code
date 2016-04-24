namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6520 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Troop t)
        {
            t.TirednessDecreaseChanceInViewArea += this.increment;
        }

        public override void PurifyInfluenceKind(Troop t)
        {
            t.TirednessDecreaseChanceInViewArea -= this.increment;
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
    }
}

