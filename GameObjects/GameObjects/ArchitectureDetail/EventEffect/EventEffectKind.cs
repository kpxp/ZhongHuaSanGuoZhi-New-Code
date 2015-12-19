namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    public abstract class EventEffectKind : GameObject
    {
        public virtual void ApplyEffectKind(Person person, Event e)
        {
        }
        /*
        public virtual void ApplyEffectKind(FactionList factions,Person person, Event e)
        {
        }
        */
        public virtual void ApplyEffectKind(Architecture architecture, Event e)
        {
            foreach (Person p in architecture.Persons)
            {
                this.ApplyEffectKind(p, e);
            }
        }

        public virtual void ApplyEffectKind(Faction faction, Event e)
        {
            foreach (Person p in faction.Persons)
            {
                this.ApplyEffectKind(p, e);
            }
            foreach (Architecture a in faction.Architectures)
            {
                this.ApplyEffectKind(a, e);
            }
        }

        public virtual void InitializeParameter(string parameter)
        {
        }

        public virtual void InitializeParameter2(string parameter2)
        {
        }
        /*
        public virtual void InitializeParameter3(FactionList factions, string parameter)
        {
        }
        */
    }
}

