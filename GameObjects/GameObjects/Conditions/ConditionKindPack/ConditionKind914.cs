namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind914 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFactionWithPrincess != null && (person.Father == person.BelongedFactionWithPrincess.Leader || person.Mother == person.BelongedFactionWithPrincess.Leader);
        }
    }
}

