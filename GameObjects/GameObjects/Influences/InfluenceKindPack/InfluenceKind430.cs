namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind430 : InfluenceKind
    {
        private float multiple = 1;


        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.MultipleOfArmyExperience = this.multiple;
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
            troop.MultipleOfArmyExperience = 1;
        }

    }
}

