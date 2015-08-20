namespace GameObjects.PersonDetail
{
    using GameObjects;
    using GameObjects.TroopDetail;
    using System;

    public class Biography : GameObject
    {
        private string brief = "";
        private int factionColor;
        private string history = "";
        public MilitaryKindTable MilitaryKinds = new MilitaryKindTable();
        private string romance = "";
        private string ingame = "";

        public string Brief
        {
            get
            {
                return this.brief;
            }
            set
            {
                this.brief = value;
            }
        }

        public int FactionColor
        {
            get
            {
                return this.factionColor;
            }
            set
            {
                this.factionColor = value;
            }
        }

        public string History
        {
            get
            {
                return this.history;
            }
            set
            {
                this.history = value;
            }
        }

        public string Romance
        {
            get
            {
                return this.romance;
            }
            set
            {
                this.romance = value;
            }
        }

        public string InGame
        {
            get
            {
                return this.ingame;
            }
            set
            {
                this.ingame = value;
            }
        }
    }
}

