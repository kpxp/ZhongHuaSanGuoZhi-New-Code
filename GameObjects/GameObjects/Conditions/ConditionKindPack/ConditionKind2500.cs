namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2500 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture a)
        {
            return a.FrontLine;
        }

    }
}

