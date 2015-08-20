namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;
    using GameGlobal;

    internal class InfluenceKind120 : InfluenceKind
    {
        private int increment = 0;

        public override void ApplyInfluenceKind(Person person)
        {
            person.DayLearnTitleDay = this.increment;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                person.LocationArchitecture.DayLearnTitleDay = this.increment;
            }
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.DayLearnTitleDay = Parameters.LearnTitleDays;
            person.LocationArchitecture.DayLearnTitleDay = Parameters.LearnTitleDays;
            if ((person.BelongedFaction != null) && (person.LocationArchitecture != null))
            {
                foreach (Person p in person.LocationArchitecture.Persons){
                    if (p.DayLearnTitleDay < person.LocationArchitecture.DayLearnTitleDay)
                    {
                        person.LocationArchitecture.DayLearnTitleDay = p.DayLearnTitleDay;
                    }
                }
            }
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.increment = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

