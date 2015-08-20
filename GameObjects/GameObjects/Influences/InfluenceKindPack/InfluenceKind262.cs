namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind262 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.ImmunityOfDieInBattle = true;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.ImmunityOfDieInBattle = false;
        }
    }
}

