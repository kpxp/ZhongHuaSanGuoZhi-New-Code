namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind611 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.ScatteredShootingOblique = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.ScatteredShootingOblique = false;
        }
    }
}

