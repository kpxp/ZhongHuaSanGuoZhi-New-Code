namespace GameObjects
{
    using System;

    public class TroopEventList : GameObjectList
    {
        public void AddTroopEventWithEvent(TroopEvent te)
        {
            base.Add(te);
            te.OnApplyTroopEvent += new TroopEvent.ApplyTroopEvent(this.te_OnApplyTroopEvent);
        }

        private void te_OnApplyTroopEvent(TroopEvent te, Troop troop)
        {
            te.Scenario.GameScreen.TroopApplyTroopEvent(te, troop);
        }
    }
}

