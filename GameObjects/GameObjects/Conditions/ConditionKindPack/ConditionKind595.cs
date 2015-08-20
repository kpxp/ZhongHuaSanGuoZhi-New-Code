namespace GameObjects.Conditions.ConditionKindPack
{
    using GameObjects;
    using GameObjects.Conditions;
    using System;

    internal class ConditionKind595 : ConditionKind
    {
        private float rate = 0f;

        public override bool CheckConditionKind(Person person)
        {
            return (((person.RoutCount + person.RoutedCount) > 0) && ((((float) person.RoutCount) / ((float) (person.RoutedCount))) < this.rate));
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

