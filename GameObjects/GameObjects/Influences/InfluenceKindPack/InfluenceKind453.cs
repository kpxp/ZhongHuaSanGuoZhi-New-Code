namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind453 : InfluenceKind
    {


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.OnlyBeDetectedByHighLevelInformation = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.OnlyBeDetectedByHighLevelInformation = false;
        }
    }
}

