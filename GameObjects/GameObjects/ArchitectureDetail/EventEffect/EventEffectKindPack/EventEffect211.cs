namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect211 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.BelongedFaction != null && person.LocationArchitecture != null)
            {
                person.LeaveToNoFaction();
            }
            else if (person.LocationArchitecture != null && person.BelongedCaptive != null)
            {
                person.BelongedCaptive.CaptiveDirectEscape();
            }
        }

    }
}

