namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind601 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.NeverBeIntoChaos = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.NeverBeIntoChaos = false;
        }
    }
}

