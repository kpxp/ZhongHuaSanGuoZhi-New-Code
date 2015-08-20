namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind595 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.InvincibleRumour = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.InvincibleRumour = false;
        }
    }
}

