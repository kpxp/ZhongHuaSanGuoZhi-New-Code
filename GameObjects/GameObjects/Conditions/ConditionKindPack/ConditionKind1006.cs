namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1006 : ConditionKind
    {
        public override bool CheckConditionKind(Troop troop)
        {
            return (troop.Combativity == troop.Army.CombativityCeiling);
        }
    }
}

