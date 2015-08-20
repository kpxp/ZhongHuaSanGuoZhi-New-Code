namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect213 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.LocationArchitecture != null)
            {
                person.Status = GameObjects.PersonDetail.PersonStatus.Princess;
            }
        }

    }
}

