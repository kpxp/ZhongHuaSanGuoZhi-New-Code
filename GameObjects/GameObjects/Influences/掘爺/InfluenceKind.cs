namespace GameObjects.Influences
{
    using GameObjects;
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    public class InfluenceKind : GameObject
    {
        public bool TroopLeaderValid;
        private InfluenceType type;

        public virtual void ApplyInfluenceKind(Architecture architecture)
        {
        }

        public virtual void ApplyInfluenceKind(Faction faction)
        {
        }

        public virtual void ApplyInfluenceKind(Person person)
        {
        }

        public virtual void ApplyInfluenceKind(Troop troop)
        {
        }

        public virtual void DoWork(Architecture architecture)
        {
        }

        public virtual int GetCredit(Troop source, Troop destination)
        {
            return 0;
        }

        public virtual int GetCreditWithPosition(Troop source, out Point? position)
        {
            //position = 0;
            position = new Point(0, 0);
            return 0;
        }

        public virtual void InitializeParameter(string parameter)
        {
        }

        public virtual void InitializeParameter2(string parameter)
        {
        }

        public virtual bool IsVaild(Person person)
        {
            return true;
        }

        public virtual bool IsVaild(Troop troop)
        {
            return true;
        }

        public virtual void PurifyInfluenceKind(Architecture architecture)
        {
        }

        public virtual void PurifyInfluenceKind(Faction faction)
        {
        }

        public virtual void PurifyInfluenceKind(Person person)
        {
        }

        public virtual void PurifyInfluenceKind(Troop troop)
        {
        }

        public InfluenceType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
    }
}

