namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind902 : ConditionKind
    {
        public override bool CheckConditionKind(Architecture architecture)
        {
            return true;
        }

        public override bool CheckConditionKind(Faction faction)
        {
            return true;
        }

        public override bool CheckConditionKind(Person person)
        {
            return true;
        }

        public override bool CheckConditionKind(Troop troop)
        {
            return true;
        }
    }
}

