namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind805 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedCaptive == null;
        }
    }
}

