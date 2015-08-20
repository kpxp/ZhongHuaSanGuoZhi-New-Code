namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;

    public class IdealTendencyKind : GameObject
    {
        private int offset;

        public override string ToString()
        {
            return (base.Name + " " + this.Offset.ToString());
        }

        public int Offset
        {
            get
            {
                return this.offset;
            }
            set
            {
                this.offset = value;
            }
        }
    }
}

