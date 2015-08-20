namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind2600 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture a)
        {
            return a.youzainan;
        }

    }
}

