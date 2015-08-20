namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind600 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.ChaosLastOneDay = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.ChaosLastOneDay = false;
        }
    }
}

