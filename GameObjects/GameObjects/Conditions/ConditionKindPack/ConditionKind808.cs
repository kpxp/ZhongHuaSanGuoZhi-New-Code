namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind808 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFaction != null && person.BelongedFaction.PrinceID == person.ID;
        }
    }
}