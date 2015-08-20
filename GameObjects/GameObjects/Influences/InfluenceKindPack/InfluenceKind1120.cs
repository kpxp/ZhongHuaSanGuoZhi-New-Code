namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind1120 : InfluenceKind
    {
        private int kind = -1;

        public override void ApplyInfluenceKind(Architecture architecture)
        {
            architecture.PrivateMilitaryKinds.AddMilitaryKind(architecture.Scenario, this.kind);
        }

        public override void PurifyInfluenceKind(Architecture architecture)
        {
            architecture.PrivateMilitaryKinds.RemoveMilitaryKind(architecture.Scenario, this.kind);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.kind = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

