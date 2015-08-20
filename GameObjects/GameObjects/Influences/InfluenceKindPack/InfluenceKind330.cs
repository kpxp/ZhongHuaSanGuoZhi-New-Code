namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind330 : InfluenceKind
    {
        private int combatMethodID;

        public override void ApplyInfluenceKind(Troop troop)
        {
            troop.Stunts.AddStunt(troop.Scenario.GameCommonData.AllStunts.GetStunt(this.combatMethodID));
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.combatMethodID = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override void PurifyInfluenceKind(Troop troop)
        {
            troop.Stunts.RemoveStunt(troop.Scenario.GameCommonData.AllStunts.GetStunt(this.combatMethodID));
        }
    }
}

