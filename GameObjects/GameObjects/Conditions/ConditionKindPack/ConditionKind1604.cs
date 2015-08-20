namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1604 : ConditionKind
    {

        public override bool CheckConditionKind(Troop troop)
        {
            return troop.Army.FollowedLeader != null && troop.BelongedFaction != null && 
                troop.Army.FollowedLeader.ID == troop.BelongedFaction.LeaderID;
        }

    }
}

