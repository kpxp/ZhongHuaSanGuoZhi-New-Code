namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind809 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFaction != null && person.BelongedFaction.MayorList.GameObjects.Contains(person);
        }
    }
}