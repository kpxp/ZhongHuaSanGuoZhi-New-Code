namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect215 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.huaiyun = true;
            person.huaiyuntianshu = 0;
            if (person.BelongedFactionWithPrincess != null)
            {
                person.suoshurenwu = person.BelongedFactionWithPrincess.LeaderID;
                person.BelongedFactionWithPrincess.Leader.suoshurenwu = person.ID;
            }
            else
            {
                person.suoshurenwu = person.ID;
            }
        }

    }
}

