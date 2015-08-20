namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind6350 : InfluenceKind
    {
        private int increment;
        private int count;

        public override void ApplyInfluenceKind(Person person)
        {
            person.multipleChildrenRate += this.increment;
            person.maxChildren += this.count;
        }


        public override void PurifyInfluenceKind(Person person)
        {
            person.multipleChildrenRate -= this.increment;
            person.maxChildren -= this.count;
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

        public override void InitializeParameter2(string parameter)
        {
            try
            {
                this.count = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

