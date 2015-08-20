namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind594 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.InvincibleHuogong = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.InvincibleHuogong = false;
        }
    }
}

