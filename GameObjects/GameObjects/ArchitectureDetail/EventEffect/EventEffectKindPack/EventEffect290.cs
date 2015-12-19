namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using GameObjects.PersonDetail;
    using System;

    internal class EventEffect290 : EventEffectKind
    {
        
        public override void ApplyEffectKind(Person person, Event e)
        {

            if (person.BelongedFaction == null && person.LocationArchitecture != null && person .BelongedCaptive == null )
            {
                person.Scenario.CreateNewFaction (person);
            }
            else if (person.BelongedFaction != null && person != person.BelongedFaction.Leader && person.LocationArchitecture != person.BelongedFaction.Capital)
            {
                person.Scenario.CreateNewFaction(person);
            }

        }



    }
}
