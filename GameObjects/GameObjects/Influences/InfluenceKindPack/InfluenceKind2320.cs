namespace GameObjects.Influences.InfluenceKindPack
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind2320 : InfluenceKind
    {
        private int increment;

        public override void ApplyInfluenceKind(Faction faction)
        {
            faction.LevelOfView = (InformationLevel) ((int) faction.LevelOfView + this.increment - 3);
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

        public override void PurifyInfluenceKind(Faction faction)
        {
            faction.LevelOfView = (InformationLevel)((int)faction.LevelOfView - this.increment - 3);
        }
    }
}

