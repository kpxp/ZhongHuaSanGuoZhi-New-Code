namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect210 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction == null && person.LocationArchitecture != null)
            {
                person.Status = GameObjects.PersonDetail.PersonStatus.Normal;
                person.ChangeFaction(person.LocationArchitecture.BelongedFaction);
            }
            else if (person.LocationArchitecture != null && person.BelongedCaptive != null)
            {
                person.ChangeFaction(person.BelongedCaptive.LocationArchitecture.BelongedFaction);
            }
        }

    }
}

