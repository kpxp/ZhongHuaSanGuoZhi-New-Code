namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect212 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.LocationArchitecture != null)
            {
                Captive captive = Captive.Create(base.Scenario, person, person.LocationArchitecture.BelongedFaction);
            }
        }

    }
}

