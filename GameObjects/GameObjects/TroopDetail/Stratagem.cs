namespace GameObjects.TroopDetail
{
    using GameObjects;
    using GameObjects.Animations;
    using GameObjects.Influences;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    public class Stratagem : GameObject
    {
        private TileAnimationKind animationKind;
        private bool architectureTarget;
        private CastDefaultKind castDefault;
        private CastTargetKind castTarget;
        private int chance;
        private int combativity;
        private string description;
        private bool friendly;
        public InfluenceTable Influences = new InfluenceTable();
        private bool self;
        private int techniquePoint;

        private bool requireInfluenceToUse;

        public void Apply(Troop troop)
        {
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                influence.ApplyInfluence(troop, Applier.Stratagem, 0);
            }
        }

        public int GetCredit(Troop source, Troop destination)
        {
            if (!source.HasStratagem(this.ID)) { return 0; }
            int num = 0;
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                num += influence.GetCredit(source, destination);
            }
            return num;
        }

        public int GetCreditWithPosition(Troop source, out Point? position)
        {
            //position = 0;
            position = new Point(0, 0);
            int num = 0;
            List<Point?> list = new List<Point?>();
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                Point? nullable = null;
                num += influence.GetCreditWithPosition(source, out nullable);
                list.Add(nullable);
            }
            if (list.Count > 0)
            {
                position = list[0];
            }
            return num;
        }

        public bool IsValid(Troop troop)
        {
            foreach (Influence influence in this.Influences.Influences.Values)
            {
                if (!influence.IsVaild(troop))
                {
                    return false;
                }
            }
            return true;
        }

        public TileAnimationKind AnimationKind
        {
            get
            {
                return this.animationKind;
            }
            set
            {
                this.animationKind = value;
            }
        }

        public bool ArchitectureTarget
        {
            get
            {
                return this.architectureTarget;
            }
            set
            {
                this.architectureTarget = value;
            }
        }

        public CastDefaultKind CastDefault
        {
            get
            {
                return this.castDefault;
            }
            set
            {
                this.castDefault = value;
            }
        }

        public CastTargetKind CastTarget
        {
            get
            {
                return this.castTarget;
            }
            set
            {
                this.castTarget = value;
            }
        }

        public int Chance
        {
            get
            {
                return this.chance;
            }
            set
            {
                this.chance = value;
            }
        }

        public int Combativity
        {
            get
            {
                return this.combativity;
            }
            set
            {
                this.combativity = value;
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

        public bool Friendly
        {
            get
            {
                return this.friendly;
            }
            set
            {
                this.friendly = value;
            }
        }

        public bool Self
        {
            get
            {
                return this.self;
            }
            set
            {
                this.self = value;
            }
        }

        public int TechniquePoint
        {
            get
            {
                return this.techniquePoint;
            }
            set
            {
                this.techniquePoint = value;
            }
        }

        public bool RequireInfluenceToUse
        {
            get;
            set;
        }
    }
}

