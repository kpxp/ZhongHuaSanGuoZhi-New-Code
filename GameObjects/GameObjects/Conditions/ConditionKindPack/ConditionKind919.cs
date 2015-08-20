namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind919 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return !(person.BelongedFaction != null && (person.Father != null || person.Mother != null) &&
                (person.BelongedFaction.Leader.Father == person.Father || person.BelongedFaction.Leader.Mother == person.Mother));
        }
    }
}

