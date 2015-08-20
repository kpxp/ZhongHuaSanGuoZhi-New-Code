namespace GameObjects.TroopDetail
{
    using GameObjects;
    using System;

    public class CastDefaultKind : GameObject
    {
        public void Apply(Troop troop)
        {
            troop.CastDefaultKind = (TroopCastDefaultKind) base.ID;
        }
    }
}

