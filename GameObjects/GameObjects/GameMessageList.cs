namespace GameObjects
{
    using System;

    public class GameMessageList : GameObjectList
    {
        public void AddMessageWithEvent(GameMessage message)
        {
            base.Add(message);
        }
    }
}

