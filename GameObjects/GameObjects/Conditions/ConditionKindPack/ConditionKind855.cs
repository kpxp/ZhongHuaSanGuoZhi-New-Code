namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;
    using System.Collections.Generic;

    internal class ConditionKind855 : ConditionKind
    {
        private int number = 0;

        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFactionWithPrincess != null && person.GetRelation(person.BelongedFactionWithPrincess.Leader) < this.number;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.number = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}
