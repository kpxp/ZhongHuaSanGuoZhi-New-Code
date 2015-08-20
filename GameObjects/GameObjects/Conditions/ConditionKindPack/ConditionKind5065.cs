namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind5065 : ConditionKind
    {
        private int val;

        public override bool CheckConditionKind(Faction faction)
        {
            return faction.Scenario.Militaries.Count < val;
        }

        public override bool CheckConditionKind(Architecture architecture)
        {
            return architecture.Scenario.Militaries.Count < val;
        }

        public override bool CheckConditionKind(Person person)
        {
            return person.Scenario.Militaries.Count < val;
        }

        public override bool CheckConditionKind(Troop troop)
        {
            return troop.Scenario.Militaries.Count < val;
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

