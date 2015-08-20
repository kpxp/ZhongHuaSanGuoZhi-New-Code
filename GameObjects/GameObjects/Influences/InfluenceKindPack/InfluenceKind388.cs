namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind388 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.BaseNoCounterAttack = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.BaseNoCounterAttack = false;
        }

    }
}

