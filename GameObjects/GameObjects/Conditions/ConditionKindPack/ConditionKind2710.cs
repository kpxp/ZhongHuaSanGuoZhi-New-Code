namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2710 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture a)
        {
            return a.RecentlyAttacked > 0;
        }

    }
}

