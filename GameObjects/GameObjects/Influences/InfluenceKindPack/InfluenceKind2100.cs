namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind2100 : InfluenceKind
    {
        private int kind;

        public override void ApplyInfluenceKind(Faction faction)
        {
            faction.AddTechniqueMilitaryKind(this.kind);
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

        public override void PurifyInfluenceKind(Faction faction)
        {
            if (faction.TechniqueMilitaryKinds.MilitaryKinds.ContainsKey(this.kind))
            {
                faction.TechniqueMilitaryKinds.MilitaryKinds.Remove(this.kind);
            }
        }
    }
}

