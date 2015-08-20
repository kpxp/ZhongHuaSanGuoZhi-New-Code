namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1540 : ConditionKind
    {
        private int terrain = 0;

        public override bool CheckConditionKind(Troop troop)
        {
            return (int) troop.Scenario.GetTerrainKindByPosition(troop.Position) == terrain;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.terrain = int.Parse(parameter);
            }
            catch
            {
            }
        }

    }
}

