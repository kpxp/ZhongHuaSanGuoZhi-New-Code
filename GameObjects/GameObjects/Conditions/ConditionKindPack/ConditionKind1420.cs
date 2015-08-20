namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1420 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            Architecture architectureByPositionNoCheck = troop.Scenario.GetArchitectureByPositionNoCheck(troop.Position);
            return ((architectureByPositionNoCheck != null) && troop.IsFriendly(architectureByPositionNoCheck.BelongedFaction));
        }
    }
}

