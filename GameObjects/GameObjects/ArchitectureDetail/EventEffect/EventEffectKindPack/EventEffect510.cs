namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;

    internal class EventEffect510 : EventEffectKind
    {
        private int type;

        public override void ApplyEffectKind(Person person, Event e)
        {
            Treasure t = person.Scenario.Treasures.GetGameObject(type) as Treasure;
            if (t.BelongedPerson != null && t.BelongedPerson == person)
            {
                person.LoseTreasure(t);
                t.Available = false;
                t.HidePlace = person.Scenario.Architectures.GameObjects[GameObject.Random(person.Scenario.Architectures.GameObjects.Count)] as Architecture;
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.type = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

