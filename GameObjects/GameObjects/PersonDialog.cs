namespace GameObjects
{
    using System;

    public class PersonDialog
    {
        public Person SpeakingPerson;
        public string Text;

        public override string ToString()
        {
            if (this.SpeakingPerson == null)
            {
                return ("---- " + this.Text);
            }
            return (this.SpeakingPerson.Name + " " + this.Text);
        }
    }
}

