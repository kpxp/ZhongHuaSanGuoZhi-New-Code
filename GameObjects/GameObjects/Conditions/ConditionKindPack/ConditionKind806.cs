namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind806 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.Status == GameObjects.PersonDetail.PersonStatus.Princess;
        }
    }
}

