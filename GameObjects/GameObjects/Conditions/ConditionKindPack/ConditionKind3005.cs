namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind3005 : ConditionKind
    {
        private int val;

        public override bool CheckConditionKind(Faction faction)
        {
            return !faction.HasTechnique(val);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.val = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

