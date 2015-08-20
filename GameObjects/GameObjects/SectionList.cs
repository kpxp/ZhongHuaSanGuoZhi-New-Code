namespace GameObjects
{
    using System;

    public class SectionList : GameObjectList
    {
        public void AddSectionWithEvent(Section section)
        {
            base.Add(section);
        }

        public void RemoveSection(Section section)
        {
            base.Remove(section);
        }
    }
}

