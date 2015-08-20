namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1296 : ConditionKind
    {
        int number = 0;

        public override bool CheckConditionKind(Troop troop)
        {
            return troop.WillArchitecture != null && troop.WillArchitecture.ID == this.number;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.number = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

