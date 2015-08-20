namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect1250 : EventEffectKind
    {
        private int id;

        public override void ApplyEffectKind(Architecture a, Event e)
        {
            a.Characteristics.PurifyInfluence(a, GameObjects.Influences.Applier.Characteristics, 0);
            a.Characteristics.Influences.Remove(id);
            a.Characteristics.ApplyInfluence(a, GameObjects.Influences.Applier.Characteristics, 0);
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.id = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

