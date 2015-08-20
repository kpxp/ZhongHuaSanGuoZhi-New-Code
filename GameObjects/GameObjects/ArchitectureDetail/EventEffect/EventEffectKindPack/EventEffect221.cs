namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect221 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.Spouse.Spouse = null;
            person.Spouse = null;
        }

    }
}

