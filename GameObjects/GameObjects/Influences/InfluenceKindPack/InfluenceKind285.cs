namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using GameObjects.Conditions;
    using System;

    internal class InfluenceKind285 : InfluenceKind
    {
        private int conditionID;

       
        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.conditionID = int.Parse(parameter);
            }
            catch
            {
            }
        }

        public override bool IsVaild(Person person)
        {
            if (person.BelongedFaction != null)
            {
                Condition t = person.Scenario.GameCommonData.AllConditions.GetCondition(conditionID);
                if (t != null)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
        
        
         




    
