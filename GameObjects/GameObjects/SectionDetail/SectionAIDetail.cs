namespace GameObjects.SectionDetail
{
    using GameObjects;
    using System;

    public class SectionAIDetail : GameObject
    {
        private bool allowNewMilitary;
        private bool allowFoodTransfer;
        private bool allowFundTransfer;
        private bool allowInvestigateTactics;
        private bool allowMilitaryTransfer;
        private bool allowOffensiveCampaign;
        private bool allowOffensiveTactics;
        private bool allowPersonTactics;
        private bool autoRun;
        private string description;
        private SectionOrientationKind orientationKind;
        private bool valueAgriculture;
        private bool valueCommerce;
        private bool valueDomination;
        private bool valueEndurance;
        private bool valueMorale;
        private bool valueNewMilitary;
        private bool valueOffensiveCampaign;
        private bool valueRecruitment;
        private bool valueTechnology;
        private bool valueTraining;

        private bool allowFacilityRemoval;

        public bool AllowFoodTransfer
        {
            get
            {
                return this.allowFoodTransfer;
            }
            set
            {
                this.allowFoodTransfer = value;
            }
        }

        public bool AllowFundTransfer
        {
            get
            {
                return this.allowFundTransfer;
            }
            set
            {
                this.allowFundTransfer = value;
            }
        }

        public bool AllowInvestigateTactics
        {
            get
            {
                return this.allowInvestigateTactics;
            }
            set
            {
                this.allowInvestigateTactics = value;
            }
        }

        public bool AllowMilitaryTransfer
        {
            get
            {
                return this.allowMilitaryTransfer;
            }
            set
            {
                this.allowMilitaryTransfer = value;
            }
        }

        public bool AllowOffensiveCampaign
        {
            get
            {
                return this.allowOffensiveCampaign;
            }
            set
            {
                this.allowOffensiveCampaign = value;
            }
        }

        public bool AllowOffensiveTactics
        {
            get
            {
                return this.allowOffensiveTactics;
            }
            set
            {
                this.allowOffensiveTactics = value;
            }
        }

        public bool AllowPersonTactics
        {
            get
            {
                return this.allowPersonTactics;
            }
            set
            {
                this.allowPersonTactics = value;
            }
        }

        public bool AutoRun
        {
            get
            {
                return this.autoRun;
            }
            set
            {
                this.autoRun = value;
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

        public SectionOrientationKind OrientationKind
        {
            get
            {
                return this.orientationKind;
            }
            set
            {
                this.orientationKind = value;
            }
        }

        public string OrientationKindString
        {
            get
            {
                return this.orientationKind.ToString();
            }
        }

        public bool ValueAgriculture
        {
            get
            {
                return this.valueAgriculture;
            }
            set
            {
                this.valueAgriculture = value;
            }
        }

        public bool ValueCommerce
        {
            get
            {
                return this.valueCommerce;
            }
            set
            {
                this.valueCommerce = value;
            }
        }

        public bool ValueDomination
        {
            get
            {
                return this.valueDomination;
            }
            set
            {
                this.valueDomination = value;
            }
        }

        public bool ValueEndurance
        {
            get
            {
                return this.valueEndurance;
            }
            set
            {
                this.valueEndurance = value;
            }
        }

        public bool ValueMorale
        {
            get
            {
                return this.valueMorale;
            }
            set
            {
                this.valueMorale = value;
            }
        }

        public bool ValueNewMilitary
        {
            get
            {
                return this.valueNewMilitary;
            }
            set
            {
                this.valueNewMilitary = value;
            }
        }

        public bool ValueOffensiveCampaign
        {
            get
            {
                return this.valueOffensiveCampaign;
            }
            set
            {
                this.valueOffensiveCampaign = value;
            }
        }

        public bool ValueRecruitment
        {
            get
            {
                return this.valueRecruitment;
            }
            set
            {
                this.valueRecruitment = value;
            }
        }

        public bool ValueTechnology
        {
            get
            {
                return this.valueTechnology;
            }
            set
            {
                this.valueTechnology = value;
            }
        }

        public bool ValueTraining
        {
            get
            {
                return this.valueTraining;
            }
            set
            {
                this.valueTraining = value;
            }
        }

        public bool AllowFacilityRemoval
        {
            get
            {
                return this.allowFacilityRemoval;
            }
            set
            {
                this.allowFacilityRemoval = value;
            }
        }

        public bool AllowNewMilitary
        {
            get
            {
                return this.allowNewMilitary;
            }
            set
            {
                this.allowNewMilitary = value;
            }
        }
    }
}

