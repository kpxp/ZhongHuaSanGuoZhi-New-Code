namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind540 : ConditionKind
    {
        
        public override bool CheckConditionKind(Person person)
        {
             person.ID  = -1;
            
               if(person .ID == -1)
               {
                   person = person.Scenario.Persons[GameObject.Random(person.Scenario.Persons.Count)] as Person;
               }


               if (person.LocationArchitecture != null)
               {
                   Person p1 = person.LocationArchitecture.Persons[GameObject.Random(person.LocationArchitecture.Persons.Count)] as Person;

                   if (person.LocationArchitecture == p1.LocationArchitecture)
                   {
                       return true;
                   }
               }
               return false;
        }

    }
}

