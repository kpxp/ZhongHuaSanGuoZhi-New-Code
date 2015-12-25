namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind530 : ConditionKind
    {
        private int personID;

        public override bool CheckConditionKind(Person person)
        {
            Person p1 = person.Scenario.Persons.GetGameObject(personID) as Person;
            return (person.BelongedFaction != null && p1.BelongedFaction != null && person.BelongedFaction == p1.BelongedFaction);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.personID = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}