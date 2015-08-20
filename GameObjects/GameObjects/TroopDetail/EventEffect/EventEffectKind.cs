namespace GameObjects.TroopDetail.EventEffect
{
    using GameObjects;
    using System;

    public class EventEffectKind : GameObject
    {
        public virtual void ApplyEffectKind(Person person)
        {
        }

        public virtual void ApplyEffectKind(Troop troop)
        {
        }

        public virtual void InitializeParameter(string parameter)
        {
        }
    }
}

