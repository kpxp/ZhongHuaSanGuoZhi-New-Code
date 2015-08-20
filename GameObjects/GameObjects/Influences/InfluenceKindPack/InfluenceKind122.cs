namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind122 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.DayAvoidInfluenceByBattle = true;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidInfluenceByBattle = true;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.DayAvoidInfluenceByBattle = false;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidInfluenceByBattle = false;
            }
        }
    }
}

