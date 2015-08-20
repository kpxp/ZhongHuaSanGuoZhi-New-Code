namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1249 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return !troop.OffencingWillArchitecture;
        }
    }
}

