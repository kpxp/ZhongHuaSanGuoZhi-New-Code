namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind592 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.NeverBeIntoChaosWhileWaylay = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.NeverBeIntoChaosWhileWaylay = false;
        }
    }
}

