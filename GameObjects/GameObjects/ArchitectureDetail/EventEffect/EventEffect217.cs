namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect217 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            if (person.FeiZiLocationArchitecture != null)
            {
                Architecture originalLocationArch = person.FeiZiLocationArchitecture;
                originalLocationArch.AddPerson(person);
                originalLocationArch.BelongedFaction.AddPerson(person);
                originalLocationArch.feiziliebiao.Remove(person);
                person.LocationArchitecture = originalLocationArch;
                person.suozaijianzhu = null;
            }
        }

    }
}

