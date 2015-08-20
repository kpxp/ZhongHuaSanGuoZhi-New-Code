namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind474 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfGossip = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.InevitableSuccessOfGossip = false;
        }
    }
}

