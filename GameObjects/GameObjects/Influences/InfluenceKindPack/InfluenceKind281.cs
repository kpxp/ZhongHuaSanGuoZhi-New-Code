namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind281 : InfluenceKind
    {
        public InfluenceKind281()
        {
            base.TroopLeaderValid = true;
        }

        public override bool IsVaild(Person person)
        {
            return ((person.LocationTroop != null) && (person.LocationTroop.Leader == person));
        }
    }
}

