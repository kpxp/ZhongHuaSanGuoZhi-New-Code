namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect216 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person, Event e)
        {
            person.huaiyun = false;
            person.huaiyuntianshu = 0;
        }

    }
}

