namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2840 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture a)
        {
            if (a.BelongedFaction == null) return false;
            foreach (Person p in a.Feiziliebiao)
            {
                if (p == a.BelongedFaction.Leader)
                {
                    return true;
                }
            }
            return false;
        }


    }
}

