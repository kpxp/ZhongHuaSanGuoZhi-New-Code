namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind461 : InfluenceKind
    {
        private float increment;

        public override void ApplyInfluenceKind(Person person)
        {
            person.RateIncrementOfJailBreakAbility += this.increment;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = float.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

