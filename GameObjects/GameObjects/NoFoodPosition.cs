namespace GameObjects
{
    using Microsoft.Xna.Framework;
    using System;

    public class NoFoodPosition
    {
        public int Days;
        public Point Position;

        public NoFoodPosition(Point position, int days)
        {
            this.Position = position;
            this.Days = days;
        }
    }
}

