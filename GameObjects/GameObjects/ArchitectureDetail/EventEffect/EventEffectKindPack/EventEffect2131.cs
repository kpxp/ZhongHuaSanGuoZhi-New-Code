namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect2131 : EventEffectKind
    {
        public override void ApplyEffectKind(Faction f, Event e)
        {
            f.IsAlien = false;
        }
    }
}

