namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1400 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return (troop.RecentlyFighting > 0);
        }
    }
}

