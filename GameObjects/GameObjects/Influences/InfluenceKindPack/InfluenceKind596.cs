namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind596 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.InvincibleAttract = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.InvincibleAttract = false;
        }
    }
}

