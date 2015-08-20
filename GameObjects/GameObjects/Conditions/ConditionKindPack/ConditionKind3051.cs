namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind3051 : ConditionKind
    {

        public override bool CheckConditionKind(Faction faction)
        {
            return !faction.IsAlien;
        }

    }
}

