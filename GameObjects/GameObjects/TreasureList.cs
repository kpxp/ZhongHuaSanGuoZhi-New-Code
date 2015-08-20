namespace GameObjects
{
    using System;

    public class TreasureList : GameObjectList
    {
        public void AddTreasure(Treasure treasure)
        {
            base.GameObjects.Add(treasure);
        }
    }
}

