namespace GameObjects.TroopDetail.EventEffect.EventEffectKindPack
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.TroopDetail.EventEffect;
    using System;

    internal class EventEffectKind60 : EventEffectKind
    {
        public override void ApplyEffectKind(Person person)
        {
            if (person.LocationTroop != null)
            {
                person.LocationTroop.SetOnFire(Parameters.FireDamageScale * person.Scenario.GetTerrainDetailByPositionNoCheck(person.LocationTroop.Position).FireDamageRate);
            }
        }
    }
}

