namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect1230 : EventEffectKind
    {
        public override void ApplyEffectKind(Architecture a, Event e)
        {
            while (a.Facilities.Count > 0)
            {
                a.DemolishFacility(a.Facilities[0] as Facility);
            }
        }
    }
}

