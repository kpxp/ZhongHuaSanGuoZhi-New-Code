namespace GameObjects
{
    using System;

    public class MilitaryList : GameObjectList
    {
        public void AddMilitary(Military military)
        {
            base.GameObjects.Add(military);
        }
    }
}

