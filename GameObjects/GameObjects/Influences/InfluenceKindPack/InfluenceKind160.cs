namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind160 : InfluenceKind
    {
        private int increment = 0;

        public override void ApplyInfluenceKind(Person person)
        {
            person.MonthIncrementOfFactionReputation += this.increment;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.MonthIncrementOfFactionReputation -= this.increment;
        }
    }
}

