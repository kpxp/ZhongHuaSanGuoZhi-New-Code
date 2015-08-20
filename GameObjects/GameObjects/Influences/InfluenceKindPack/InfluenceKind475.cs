namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind475 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfSearch = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfSearch = false;
        }
    }
}

