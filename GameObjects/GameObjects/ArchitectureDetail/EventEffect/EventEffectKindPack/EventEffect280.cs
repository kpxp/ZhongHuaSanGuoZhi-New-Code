namespace GameObjects.ArchitectureDetail.EventEffect
{
    using GameObjects;
    using System;


    internal class EventEffect280: EventEffectKind
    {
        private int  mergeFactionID;
        
        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.mergeFactionID = int.Parse(parameter);
                
            }
            catch
            {
                
            }
           
        }

        public override void ApplyEffectKind(Person person, Event e)
        {
            FactionList factionlist = person.Scenario.Factions;
            Faction oldFaction = person .BelongedFaction ;
            Faction mergeFaction = factionlist.GetGameObject(mergeFactionID) as Faction;

            if (oldFaction != null && mergeFaction != null && person == oldFaction.Leader)
            {
                foreach (Person p in oldFaction.Persons.GetList())
                {
                    p.InitialLoyalty();
                }
                oldFaction.ChangeFaction(mergeFaction);
                
                //oldFaction.Leader.InitialLoyalty();
            }
           
        }



    }
}

