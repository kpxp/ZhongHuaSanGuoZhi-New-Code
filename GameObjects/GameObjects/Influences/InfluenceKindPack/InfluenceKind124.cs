namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind124 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.DayAvoidInternalDecrementOnBattle = true;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidInternalDecrementOnBattle = true;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.DayAvoidInternalDecrementOnBattle = false;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidInternalDecrementOnBattle = false;
            }
        }
    }
}

