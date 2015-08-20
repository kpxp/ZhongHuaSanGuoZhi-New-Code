namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind606 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.NotAfraidOfFire = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.NotAfraidOfFire = false;
        }
    }
}

