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
            if (person.BelongedFaction != null)
            {
                person.suoshurenwu = person.BelongedFaction.LeaderID;
                person.BelongedFaction.Leader.suoshurenwu = person.ID;
            }
            else
            {
                person.suoshurenwu = person.ID;
            }
        }

    }
}

