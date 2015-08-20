using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameObjects;

namespace GameObjects.PersonDetail
{
    public class PersonGeneratorSetting : GameObject
    {
        public int femaleChance;
        public int bornLo, bornHi;
        public int debutLo, debutHi;
        public int dieLo, dieHi, debutAtLeast;
    }

}