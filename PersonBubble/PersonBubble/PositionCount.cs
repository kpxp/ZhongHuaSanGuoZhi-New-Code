namespace PersonBubble
{
    using Microsoft.Xna.Framework;
    using System;

    internal class PositionCount
    {
        internal int Count;
        internal Point Position;

        public PositionCount(Point position, int count)
        {
            this.Position = position;
            this.Count = count;
        }
    }
}

