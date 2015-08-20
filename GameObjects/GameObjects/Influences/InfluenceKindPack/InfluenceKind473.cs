namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind473 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfInstigate = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfInstigate = false;
        }
    }
}

