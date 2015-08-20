namespace GameObjects.ArchitectureDetail
{
    using GameObjects;
    using Microsoft.Xna.Framework.Graphics;
    using System;

    public class ArchitectureKind : GameObject
    {
        private int agricultureBase;
        private int agricultureUnit;
        private int commerceBase;
        private int commerceUnit;
        private int dominationBase;
        private int dominationUnit;
        private int enduranceBase;
        private int enduranceUnit;
        private int facilityPositionUnit;
        private int foodMaxUnit;
        private int fundMaxUnit;
        private bool hasAgriculture;
        private bool hasCommerce;
        private bool hasDomination;
        private bool hasEndurance;
        private bool hasHarbor;
        private bool hasLongView;
        private bool hasMorale;
        private bool hasObliqueView;
        private bool hasPopulation;
        private bool hasTechnology;
        private int moraleBase;
        private int moraleUnit;
        private int populationBase;
        private int populationBoundary;
        private int populationUnit;
        private int technologyBase;
        private int technologyUnit;
        private Texture2D texture;
        public String TextureFileName;
        public GraphicsDevice Device;
        private int viewDistance;
        private int viewDistanceIncrementDivisor;
        private bool countToMerit;
        private int expandable;
        private bool shipCanEnter;

        public Texture2D Texture
        {
            get
            {
                if (this.Device == null) return null;
                try
                {
                    if (this.texture == null)
                    {
                        this.texture = Texture2D.FromFile(this.Device, "Resources/Architecture/" + this.ID.ToString() + ".png");
                    }
                }
                catch
                {
                    if (this.texture == null)
                    {
                        this.texture = new Texture2D(this.Device, 1, 1);
                    }
                }
                return this.texture;
            }
        }

        public void ClearTexture()
        {
            if (this.texture != null)
            {
                this.texture.Dispose();
                this.texture = null;
            }
        }

        public int AgricultureBase
        {
            get
            {
                return this.agricultureBase;
            }
            set
            {
                this.agricultureBase = value;
            }
        }

        public int AgricultureUnit
        {
            get
            {
                return this.agricultureUnit;
            }
            set
            {
                this.agricultureUnit = value;
            }
        }

        public int CommerceBase
        {
            get
            {
                return this.commerceBase;
            }
            set
            {
                this.commerceBase = value;
            }
        }

        public int CommerceUnit
        {
            get
            {
                return this.commerceUnit;
            }
            set
            {
                this.commerceUnit = value;
            }
        }

        public int DominationBase
        {
            get
            {
                return this.dominationBase;
            }
            set
            {
                this.dominationBase = value;
            }
        }

        public int DominationUnit
        {
            get
            {
                return this.dominationUnit;
            }
            set
            {
                this.dominationUnit = value;
            }
        }

        public int EnduranceBase
        {
            get
            {
                return this.enduranceBase;
            }
            set
            {
                this.enduranceBase = value;
            }
        }

        public int EnduranceUnit
        {
            get
            {
                return this.enduranceUnit;
            }
            set
            {
                this.enduranceUnit = value;
            }
        }

        public int FacilityPositionUnit
        {
            get
            {
                return this.facilityPositionUnit;
            }
            set
            {
                this.facilityPositionUnit = value;
            }
        }

        public int FoodMaxUnit
        {
            get
            {
                return this.foodMaxUnit;
            }
            set
            {
                this.foodMaxUnit = value;
            }
        }

        public int FundMaxUnit
        {
            get
            {
                return this.fundMaxUnit;
            }
            set
            {
                this.fundMaxUnit = value;
            }
        }

        public bool HasAgriculture
        {
            get
            {
                return this.hasAgriculture;
            }
            set
            {
                this.hasAgriculture = value;
            }
        }

        public string HasAgricultureString
        {
            get
            {
                return (this.hasAgriculture ? "○" : "×");
            }
        }

        public bool HasCommerce
        {
            get
            {
                return this.hasCommerce;
            }
            set
            {
                this.hasCommerce = value;
            }
        }

        public string HasCommerceString
        {
            get
            {
                return (this.hasCommerce ? "○" : "×");
            }
        }

        public bool HasDomination
        {
            get
            {
                return this.hasDomination;
            }
            set
            {
                this.hasDomination = value;
            }
        }

        public string HasDominationString
        {
            get
            {
                return (this.hasDomination ? "○" : "×");
            }
        }

        public bool HasEndurance
        {
            get
            {
                return this.hasEndurance;
            }
            set
            {
                this.hasEndurance = value;
            }
        }

        public string HasEnduranceString
        {
            get
            {
                return (this.hasEndurance ? "○" : "×");
            }
        }

        public bool HasHarbor
        {
            get
            {
                return this.hasHarbor;
            }
            set
            {
                this.hasHarbor = value;
            }
        }

        public string HasHarborString
        {
            get
            {
                return (this.hasHarbor ? "○" : "×");
            }
        }

        public bool HasLongView
        {
            get
            {
                return this.hasLongView;
            }
            set
            {
                this.hasLongView = value;
            }
        }

        public string HasLongViewString
        {
            get
            {
                return (this.hasLongView ? "○" : "×");
            }
        }

        public bool HasMorale
        {
            get
            {
                return this.hasMorale;
            }
            set
            {
                this.hasMorale = value;
            }
        }

        public string HasMoraleString
        {
            get
            {
                return (this.hasMorale ? "○" : "×");
            }
        }

        public bool HasObliqueView
        {
            get
            {
                return this.hasObliqueView;
            }
            set
            {
                this.hasObliqueView = value;
            }
        }

        public string HasObliqueViewString
        {
            get
            {
                return (this.hasObliqueView ? "○" : "×");
            }
        }

        public bool HasPopulation
        {
            get
            {
                return this.hasPopulation;
            }
            set
            {
                this.hasPopulation = value;
            }
        }

        public string HasPopulationString
        {
            get
            {
                return (this.hasPopulation ? "○" : "×");
            }
        }

        public bool HasTechnology
        {
            get
            {
                return this.hasTechnology;
            }
            set
            {
                this.hasTechnology = value;
            }
        }

        public string HasTechnologyString
        {
            get
            {
                return (this.hasTechnology ? "○" : "×");
            }
        }

        public int MoraleBase
        {
            get
            {
                return this.moraleBase;
            }
            set
            {
                this.moraleBase = value;
            }
        }

        public int MoraleUnit
        {
            get
            {
                return this.moraleUnit;
            }
            set
            {
                this.moraleUnit = value;
            }
        }

        public int PopulationBase
        {
            get
            {
                return this.populationBase;
            }
            set
            {
                this.populationBase = value;
            }
        }

        public int PopulationBoundary
        {
            get
            {
                return this.populationBoundary;
            }
            set
            {
                this.populationBoundary = value;
            }
        }

        public int PopulationUnit
        {
            get
            {
                return this.populationUnit;
            }
            set
            {
                this.populationUnit = value;
            }
        }

        public int TechnologyBase
        {
            get
            {
                return this.technologyBase;
            }
            set
            {
                this.technologyBase = value;
            }
        }

        public int TechnologyUnit
        {
            get
            {
                return this.technologyUnit;
            }
            set
            {
                this.technologyUnit = value;
            }
        }

        public int ViewDistance
        {
            get
            {
                return this.viewDistance;
            }
            set
            {
                this.viewDistance = value;
            }
        }

        public int ViewDistanceIncrementDivisor
        {
            get
            {
                return this.viewDistanceIncrementDivisor;
            }
            set
            {
                this.viewDistanceIncrementDivisor = value;
            }
        }

        public bool CountToMerit
        {
            get
            {
                return this.countToMerit;
            }
            set
            {
                this.countToMerit = value;
            }
        }

        public int Expandable
        {
            get
            {
                return this.expandable;
            }
            set
            {
                this.expandable = value;
            }
        }

        public bool ShipCanEnter
        {
            get
            {
                return this.shipCanEnter;
            }
            set
            {
                this.shipCanEnter = value;
            }
        }
    }
}

