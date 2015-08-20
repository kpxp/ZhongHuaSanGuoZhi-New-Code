namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind30 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InternalNoFundNeeded = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InternalNoFundNeeded = false;
        }
    }
}

