namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect223 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            foreach (Person p in person.Scenario.Persons)
            {
                if (p.Brothers.GameObjects.Contains(p))
                {
                    p.Brothers.Remove(p);
                }
            }
            person.Brothers.Clear();
        }

    }
}

