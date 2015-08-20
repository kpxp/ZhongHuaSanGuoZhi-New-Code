namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1602 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return troop.Leader == troop.BelongedFaction.Leader;
        }
    }
}

