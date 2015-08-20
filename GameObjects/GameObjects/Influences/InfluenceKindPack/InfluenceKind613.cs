namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind613 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.CanAttackAfterRout = true;
        }


        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.CanAttackAfterRout = false;
        }
    }
}

