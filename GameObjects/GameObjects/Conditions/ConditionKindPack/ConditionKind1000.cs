namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1000 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return (troop.Status == TroopStatus.混乱);
        }
    }
}

