namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class BiographyAdjectives : GameObject
    {
        
        public int Strength { get; set; }
        public int Command { get; set; }
        public int Intelligence { get; set; }
        public int Politics { get; set; }
        public int Glamour { get; set; }
        public int Braveness { get; set; }
        public int Calmness { get; set; }
        public int PersonalLoyalty { get; set; }
        public int Ambition { get; set; }
        public Boolean Male { get; set; }
        public Boolean Female { get; set; }

        private List<String> text = new List<string>();
        public List<String> Text { get { return text; } set { text = value; } }

        private List<String> suffixText = new List<string>();
        public List<String> SuffixText { get { return suffixText; } set { suffixText = value; } }
    }
}

