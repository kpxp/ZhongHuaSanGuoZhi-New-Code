namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind1210 : ConditionKind
    {
        private float rate = 0f;

        public override bool CheckConditionKind(Troop troop)
        {
            return ((troop.Quantity > 0) && ((((float) troop.InjuryQuantity) / ((float) troop.Quantity)) >= this.rate));
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = float.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

