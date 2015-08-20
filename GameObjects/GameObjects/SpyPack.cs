namespace GameObjects
{
    using System;

    internal class SpyPack
    {
        internal int Days;
        internal Person SpyPerson;

        internal SpyPack(Person person, int days)
        {
            this.SpyPerson = person;
            this.Days = days;
        }
    }
}

