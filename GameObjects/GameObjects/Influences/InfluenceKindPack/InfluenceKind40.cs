namespace GameObjects.Influences.InfluenceKindPack
{
    using GameObjects;
    using GameObjects.Influences;
    using System;

    internal class InfluenceKind40 : InfluenceKind
    {
        private int multiple = 1;

        public override void ApplyInfluenceKind(Person person)
        {
            person.MultipleOfAgricultureTechniquePoint += this.multiple - 1;
            person.MultipleOfCommerceTechniquePoint += this.multiple - 1;
            person.MultipleOfTechnologyTechniquePoint += this.multiple - 1;
            person.MultipleOfDominationTechniquePoint += this.multiple - 1;
            person.MultipleOfMoraleTechniquePoint += this.multiple - 1;
            person.MultipleOfEnduranceTechniquePoint += this.multiple - 1;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.MultipleOfAgricultureTechniquePoint -= this.multiple - 1;
            person.MultipleOfCommerceTechniquePoint -= this.multiple - 1;
            person.MultipleOfTechnologyTechniquePoint -= this.multiple - 1;
            person.MultipleOfDominationTechniquePoint -= this.multiple - 1;
            person.MultipleOfMoraleTechniquePoint -= this.multiple - 1;
            person.MultipleOfEnduranceTechniquePoint -= this.multiple - 1;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.multiple = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

