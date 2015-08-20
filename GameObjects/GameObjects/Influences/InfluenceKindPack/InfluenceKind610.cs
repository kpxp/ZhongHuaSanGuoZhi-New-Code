namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind610 : InfluenceKind
    {

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.BaseNoAccidentalInjury = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.BaseNoAccidentalInjury = false;
        }
    }
}

