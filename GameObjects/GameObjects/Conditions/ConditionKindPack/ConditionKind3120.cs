namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind3120 : ConditionKind
    {
        private int val;

        public override bool CheckConditionKind(Faction faction)
        {
            int c = 0;
            foreach (Architecture a in faction.Architectures)
            {
                if (a.LocationState.ID == this.val)
                {
                    c++;
                }
            }
            return c >= val;
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

