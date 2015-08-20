namespace GameObjects.PersonDetail
{
    using GameObjects;
    using System;
    using System.Collections.Generic;

    public class TitleKind : GameObject
    {
        public bool Combat { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int StudyDay { get; set; }
        public int SuccessRate { get; set; }

        private bool? inheritable;
        public bool IsInheritable(TitleTable allTitles)
        {
            if (inheritable.HasValue)
            {
                return inheritable.Value;
            }
            foreach (Title t in allTitles.GetTitleList())
            {
                if (t.Kind == this && t.CanBeBorn())
                {
                    inheritable = true;
                    return true;
                }
            }
            inheritable = false;
            return false;
        }
    }
}

