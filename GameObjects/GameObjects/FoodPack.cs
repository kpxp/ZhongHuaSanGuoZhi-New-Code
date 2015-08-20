namespace GameObjects
{
    using System;

    internal class FoodPack
    {
        internal int Days;
        internal int Food;

        internal FoodPack(int food, int days)
        {
            this.Food = food;
            this.Days = days;
        }
    }
}

