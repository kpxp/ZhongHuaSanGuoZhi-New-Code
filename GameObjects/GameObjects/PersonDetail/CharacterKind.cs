namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;

    public class CharacterKind : GameObject
    {
        private int challengeChance;
        private int controversyChance;
        private float intelligenceRate;

        public int ChallengeChance
        {
            get
            {
                return this.challengeChance;
            }
            set
            {
                this.challengeChance = value;
            }
        }

        public int ControversyChance
        {
            get
            {
                return this.controversyChance;
            }
            set
            {
                this.controversyChance = value;
            }
        }

        public float IntelligenceRate
        {
            get
            {
                return this.intelligenceRate;
            }
            set
            {
                this.intelligenceRate = value;
            }
        }

        private int[] generationChance = new int[10];
        public int[] GenerationChance
        {
            get
            {
                return generationChance;
            }
        }
    }
}

