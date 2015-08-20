namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1240 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            GameObjectList viewingArchitecturesByPosition = troop.Scenario.GetViewingArchitecturesByPosition(troop.Position);
            if (viewingArchitecturesByPosition.Count > 0)
            {
                foreach (Architecture architecture in viewingArchitecturesByPosition)
                {
                    if (troop.IsFriendly(architecture.BelongedFaction))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}

