namespace GameObjects.TroopDetail
{
    using GameObjects;
    using System;

    public class AttackDefaultKind : GameObject
    {
        public void Apply(Troop troop)
        {
            troop.AttackDefaultKind = (TroopAttackDefaultKind) base.ID;
        }
    }
}

