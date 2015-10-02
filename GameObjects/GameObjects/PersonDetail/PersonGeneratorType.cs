using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameObjects;

namespace GameObjects.PersonDetail
{
    public class PersonGeneratorType : GameObject
    {

        public int commandLo, commandHi;
        public int strengthLo, strengthHi;
        public int intelligenceLo, intelligenceHi;
        public int politicsLo, politicsHi;
        public int glamourLo, glamourHi;
        public int braveLo, braveHi;
        public int calmnessLo, calmnessHi;
        public int personalLoyaltyLo, personalLoyaltyHi;
        public int ambitionLo, ambitionHi;
        public int generationChance;
        public bool affectedByRateParameter;
        public int titleChance;
        public int CostFund { get; set; }
        public int TypeCount { get; set; }
        public int FactionLimit { get; set; }
    }
}