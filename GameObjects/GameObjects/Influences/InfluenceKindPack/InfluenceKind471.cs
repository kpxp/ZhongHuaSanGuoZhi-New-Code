namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind471 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfJailBreak = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfJailBreak = false;
        }
    }
}

