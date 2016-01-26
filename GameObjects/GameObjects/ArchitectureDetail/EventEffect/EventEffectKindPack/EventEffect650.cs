namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect650 : EventEffectKind
    {
        private String tag;

        public override void ApplyEffectKind(Person person, Event e)
        {
            int index = person.Tags.IndexOf(tag + ",");
            if (index >= 0) {
                person.Tags.Remove(index, tag.Length + 2);
            }
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
