namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind609 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.DefenceNoChangeOnChaos = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.DefenceNoChangeOnChaos = false;
        }
    }
}

