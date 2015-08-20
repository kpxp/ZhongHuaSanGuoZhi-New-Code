namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect1400 : EventEffectKind
    {
        private int kind;

        public override void ApplyEffectKind(Architecture a, Event e)
        {
            a.Kind = a.Scenario.GameCommonData.AllArchitectureKinds.GetArchitectureKind(kind);
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

