namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect214 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.ToDeath(null, person.BelongedFaction);
        }

    }
}

