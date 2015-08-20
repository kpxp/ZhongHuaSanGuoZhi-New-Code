namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind990 : ConditionKind
    {
        private string target;

        public override bool CheckConditionKind(Person person)
        {
            return person.GivenName == target;
        }

        public override void InitializeParameter(string parameter)
        {
            this.target = parameter;
        }
    }
}

