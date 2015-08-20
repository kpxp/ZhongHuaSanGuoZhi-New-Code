namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind591 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.InvincibleRaoluan = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.InvincibleRaoluan = false;
        }
    }
}

