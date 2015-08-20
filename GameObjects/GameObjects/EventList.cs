namespace GameObjects
{
    public class EventList : GameObjectList
    {
        public void AddEventWithEvent(Event te)
        {
            base.Add(te);
            te.OnApplyEvent += new Event.ApplyEvent(this.te_OnApplyEvent);
        }

        private void te_OnApplyEvent(Event te, Architecture a)
        {
            te.Scenario.GameScreen.ApplyEvent(te, a);
        }
    }
}