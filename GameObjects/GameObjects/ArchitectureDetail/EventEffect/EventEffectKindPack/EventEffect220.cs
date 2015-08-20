namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect220 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null)
            {
                person.BelongedFaction.Leader.Spouse = person;
                person.Spouse = person.BelongedFaction.Leader;
            }
        }

    }
}

