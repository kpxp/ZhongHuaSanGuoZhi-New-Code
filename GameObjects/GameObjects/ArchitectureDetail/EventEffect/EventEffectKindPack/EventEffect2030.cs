namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect2030 : EventEffectKind
    {
        private int increment;

        public override void ApplyEffectKind(Faction f, Event e)
        {
            GameObjects.FactionDetail.Technique technique = f.Scenario.GameCommonData.AllTechniques.GetTechnique(increment);
            f.AvailableTechniques.RemoveTechniuqe(increment);
            f.Scenario.NewInfluence = true;
            technique.Influences.PurifyInfluence(f, GameObjects.Influences.Applier.Technique, increment);
            f.Scenario.NewInfluence = false;
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
    }
}

