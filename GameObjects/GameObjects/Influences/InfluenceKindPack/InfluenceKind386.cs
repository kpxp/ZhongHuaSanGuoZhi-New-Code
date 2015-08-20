namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind386 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.BaseAttackAllOffenceArea = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.BaseAttackAllOffenceArea = false;
        }

    }
}

