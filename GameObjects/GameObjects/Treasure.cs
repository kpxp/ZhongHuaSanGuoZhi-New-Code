namespace GameObjects
{
    using GameObjects.Influences;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class Treasure : GameObject
    {
        private int appearYear;
        private bool available;
        public Person BelongedPerson;
        private string description;
        public Architecture HidePlace;
        public InfluenceTable Influences = new InfluenceTable();
        private int pic;
        private Texture2D picture;
        private int worth;

        public int TreasureGroup
        {
            get;
            set;
        }

        public int AppearYear
        {
            get
            {
                return this.appearYear;
            }
            set
            {
                this.appearYear = value;
            }
        }

        public bool Available
        {
            get
            {
                return this.available;
            }
            set
            {
                this.available = value;
            }
        }

        public string BelongedPersonString
        {
            get
            {
                return ((this.BelongedPerson != null) ? this.BelongedPerson.Name : "----");
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        public string HidePlaceString
        {
            get
            {
                return ((this.HidePlace != null) ? this.HidePlace.Name : "----");
            }
        }

        public string InfluenceString
        {
            get
            {
                string str = "";
                foreach (Influence influence in this.Influences.Influences.Values)
                {
                    str = str + "•" + influence.Description;
                }
                return str;
            }
        }

        public int Pic
        {
            get
            {
                return this.pic;
            }
            set
            {
                this.pic = value;
            }
        }

        public void disposeTexture()
        {
            if (this.picture != null)
            {
                this.picture.Dispose();
                this.picture = null;
            }
        }

        public Texture2D Picture
        {
            get
            {
                if (this.picture == null)
                {
                    try
                    {
                        this.picture = Texture2D.FromFile(base.Scenario.GameScreen.GraphicsDevice, "Resources/Treasure/" + this.Pic.ToString() + ".png");
                    }
                    catch
                    {
                        this.picture = new Texture2D(base.Scenario.GameScreen.GraphicsDevice, 0, 0);
                    }
                }
                return this.picture;
            }
        }

        public int Worth
        {
            get
            {
                return this.worth;
            }
            set
            {
                this.worth = value;
            }
        }
    }
}

