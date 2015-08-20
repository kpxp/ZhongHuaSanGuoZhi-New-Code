namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind383 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.BasePierceAttack = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.BasePierceAttack = false;
        }

    }
}

