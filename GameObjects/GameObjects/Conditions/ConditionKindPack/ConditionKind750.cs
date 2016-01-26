namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind750 : ConditionKind
    {
        private String tag;

        public override bool CheckConditionKind(Person person)
        {
            return person.Tags.Contains(tag + ",");
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.tag = parameter;
            }
            catch
            {
            }
        }
    }
}
