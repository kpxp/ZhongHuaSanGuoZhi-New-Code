namespace GameObjects.TroopDetail
{
    using GameObjects;
    using System;

    public class CastTargetKind : GameObject
    {
        public void Apply(Troop troop)
        {
            troop.CastTargetKind = (TroopCastTargetKind) base.ID;
        }
    }
}

