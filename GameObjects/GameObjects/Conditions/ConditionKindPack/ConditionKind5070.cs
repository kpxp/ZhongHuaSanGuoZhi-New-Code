namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind5070 : ConditionKind
    {
        private int val;

        public override bool CheckConditionKind(Faction faction)
        {
            return faction.Scenario.Persons.Count >= val;
        }

        public override bool CheckConditionKind(Architecture architecture)
        {
            return architecture.Scenario.Persons.Count >= val;
        }

        public override bool CheckConditionKind(Person person)
        {
            return person.Scenario.Persons.Count >= val;
        }

        public override bool CheckConditionKind(Troop troop)
        {
            return troop.Scenario.Persons.Count >= val;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.val = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

