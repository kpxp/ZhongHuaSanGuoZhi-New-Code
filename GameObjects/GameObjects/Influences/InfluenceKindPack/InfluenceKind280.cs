namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind280 : InfluenceKind
    {
        public override bool IsVaild(Person person)
        {
            return ((person.BelongedFaction != null) && (person.BelongedFaction.Leader == person));
        }
    }
}

