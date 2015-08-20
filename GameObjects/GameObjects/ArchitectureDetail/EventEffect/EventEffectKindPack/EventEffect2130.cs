namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect2130 : EventEffectKind
    {
        public override void ApplyEffectKind(Faction f, Event e)
        {
            f.IsAlien = true;
        }
    }
}

