namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind560 : ConditionKind
    {

        public override bool CheckConditionKind(Person person)
        {
            //person.ID = -1;

            if (person.ID == -1)
            {
                person = person.BelongedArchitecture.Persons[GameObject.Random(person.BelongedArchitecture.Persons.Count)] as Person;
            }


            if (person.BelongedArchitecture != null)
            {
                Person p1 = person.BelongedArchitecture.Persons[GameObject.Random(person.BelongedArchitecture.Persons.Count)] as Person;

                if (p1.BelongedArchitecture != null && person.BelongedArchitecture != p1.BelongedArchitecture)
                {
                    return true;

                }
            }
            return false;
        }

    }
}

