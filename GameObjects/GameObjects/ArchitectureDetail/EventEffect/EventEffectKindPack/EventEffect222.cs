namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect222 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null)
            {
                person.Brothers.Add(person.BelongedFaction.Leader);
                person.BelongedFaction.Leader.Brothers.Add(person);
            }
        }

    }
}

