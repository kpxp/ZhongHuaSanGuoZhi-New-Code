namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind5110 : InfluenceKind
    {
        private int chance = 0;

        public override void ApplyInfluenceKind(Person person)
        {
            person.ChanceOfNoCapture += this.chance;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.chance = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.ChanceOfNoCapture -= this.chance;
        }
    }
}

