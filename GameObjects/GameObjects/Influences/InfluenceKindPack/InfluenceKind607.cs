namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind607 : InfluenceKind
    {
        private float multiple;


        public override void ApplyInfluenceKind(Troop troop)
        {
            if (troop.MultipleOfDefenceOnArchitecture < this.multiple)
            {
                troop.MultipleOfDefenceOnArchitecture = this.multiple;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.multiple = float.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.MultipleOfDefenceOnArchitecture = 1;
        }
    }
}

