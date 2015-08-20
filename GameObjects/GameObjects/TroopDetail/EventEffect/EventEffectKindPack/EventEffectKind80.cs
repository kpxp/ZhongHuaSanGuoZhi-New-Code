namespace GameObjects.TroopDetail.EventEffect.EventEffectKindPack
{
    using GameObjects;
    using GameObjects.TroopDetail.EventEffect;
    using System;

    internal class EventEffectKind80 : EventEffectKind
    {

        public override void ApplyEffectKind(Person person)
        {
            if (person.LocationTroop != null)
            {
                person.ToDeath(null, person.BelongedFaction);
            }
        }
    }
}