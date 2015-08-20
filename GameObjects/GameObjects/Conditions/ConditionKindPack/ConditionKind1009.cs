namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1009 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return (troop.InjuryQuantity > 0);
        }
    }
}

