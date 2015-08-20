namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind387 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.BaseAttackEveryAround = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.BaseAttackEveryAround = false;
        }

    }
}

