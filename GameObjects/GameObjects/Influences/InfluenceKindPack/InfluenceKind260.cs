namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind260 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.ImmunityOfCaptive = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.ImmunityOfCaptive = false;
        }
    }
}

