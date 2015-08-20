namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind123 : InfluenceKind
    {
        public override void ApplyInfluenceKind(Person person)
        {
            person.DayAvoidPopulationEscape = true;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidPopulationEscape = true;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.DayAvoidPopulationEscape = false;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayAvoidPopulationEscape = false;
            }
        }
    }
}

