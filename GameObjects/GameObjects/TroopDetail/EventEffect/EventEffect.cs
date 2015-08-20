namespace GameObjects.TroopDetail.EventEffect
{
    using GameObjects;
    using System;

    public class EventEffect : GameObject
    {
        public EventEffectKind Kind;
        private string parameter;

        public void ApplyEffect(Person person)
        {
            this.Kind.InitializeParameter(this.Parameter);
            this.Kind.ApplyEffectKind(person);
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
    }
}

