namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind914 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFaction != null && (person.Father == person.BelongedFaction.Leader || person.Mother == person.BelongedFaction.Leader);
        }
    }
}

