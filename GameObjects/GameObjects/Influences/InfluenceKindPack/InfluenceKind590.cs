namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind590 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.InvincibleGongxin = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.InvincibleGongxin = false;
        }
    }
}

