namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind1040 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.TroopershipAvailable = true;
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.TroopershipAvailable = false;
        }

    }
}

