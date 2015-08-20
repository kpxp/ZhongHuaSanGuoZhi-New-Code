namespace GameObjects.TroopDetail
{
    using GameObjects;
    using System;

    public class AttackTargetKind : GameObject
    {
        public void Apply(Troop troop)
        {
            troop.AttackTargetKind = (TroopAttackTargetKind) base.ID;
        }
    }
}

