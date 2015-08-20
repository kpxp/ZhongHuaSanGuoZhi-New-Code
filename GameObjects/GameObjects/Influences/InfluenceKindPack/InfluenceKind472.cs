namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind472 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfDestroy = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfDestroy = false;
        }
    }
}

