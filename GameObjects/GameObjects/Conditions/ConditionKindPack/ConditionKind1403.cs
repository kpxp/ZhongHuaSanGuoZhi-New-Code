namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1403 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return troop.Scenario.GetArchitectureByPosition(troop.Position) != null &&
                troop.Scenario.GetArchitectureByPosition(troop.Position).BelongedFaction == troop.BelongedFaction;
        }
    }
}

