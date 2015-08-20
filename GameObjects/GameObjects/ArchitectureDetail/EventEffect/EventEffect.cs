namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    public class EventEffect : GameObject
    {
        public EventEffectKind Kind;
        private string parameter;
        private string parameter2;

        public void ApplyEffect(Person person, Event e)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter(this.Parameter2);
            this.Kind.ApplyEffectKind(person, e);
        }

        public void ApplyEffect(Architecture a, Event e)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter(this.Parameter2);
            this.Kind.ApplyEffectKind(a, e);
        }

        public void ApplyEffect(Faction f, Event e)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.InitializeParameter(this.Parameter2);
            this.Kind.ApplyEffectKind(f, e);
        }

        public string Parameter
        {
            get
            {
                return this.parameter;
            }
            set
            {
                this.parameter = value;
            }
        }

        public string Parameter2
        {
            get
            {
                return this.parameter2;
            }
            set
            {
                this.parameter2 = value;
            }
        }
    }
}

