namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect600 : EventEffectKind
    {
        private String tag;

        public override void ApplyEffectKind(Person person, Event e)
        {
            person.Tags += tag + ",";
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.tag = parameter;
            }
            catch
            {
            }
        }
    }
}
