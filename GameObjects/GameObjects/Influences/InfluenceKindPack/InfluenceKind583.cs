namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind583 : InfluenceKind
    {
 
        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.HighLevelInformationOnInvestigate = true;
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.HighLevelInformationOnInvestigate = false;
        }
    }
}

