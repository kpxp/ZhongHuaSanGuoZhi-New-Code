namespace GameObjects
{
    using System;
    using System.Runtime.CompilerServices;

    public class Captive : GameObject
    {
        public Faction BelongedFaction;
        public int BelongedFactionID;
        public Faction CaptiveFaction;
        public int CaptiveFactionID;
        public Person CaptivePerson;
        public int CaptivePersonID;
        public Architecture LocationArchitecture;
        public int LocationArchitectureID;
        public Troop LocationTroop;
        public int LocationTroopID;
        public Architecture RansomArchitecture;
        public int RansomArchitectureID;
        public int RansomArriveDays;
        private int ransomFund;

        public event PlayerRelease OnPlayerRelease;

        public event Release OnRelease;

        public event SelfRelease OnSelfRelease;

        public static Captive Create(GameScenario scenario, Person person, Faction faction)
        {
            if (person.BelongedFaction == null)
            {
                return null;
            }
            if (person.BelongedFaction == faction)
            {
                return null;
            }
            Captive captive = new Captive();
            captive.Scenario = scenario;
            captive.ID = scenario.Captives.GetFreeGameObjectID();
            captive.CaptivePerson = person;
            person.BelongedCaptive = captive;
            captive.CaptiveFaction = person.BelongedFaction;
            scenario.Captives.AddCaptiveWithEvent(captive);
            captive.CaptiveFaction.AddSelfCaptive(captive);
            faction.AddCaptive(captive);
            return captive;
        }

        public void DayEvent()
        {
            if (((this.BelongedFaction != null) && (this.CaptiveFaction != null)) && (this.RansomArriveDays > 0))
            {
                this.RansomArriveDays--;
                if (this.RansomArriveDays == 0)
                {
                    if (this.BelongedFaction.Capital != null)
                    {
                        if (this.BelongedFaction.Capital == this.RansomArchitecture)
                        {
                            if (base.Scenario.IsPlayer(this.BelongedFaction))
                            {
                                if (!(!this.BelongedFaction.AutoRefuse || GameObject.Chance(10)))
                                {
                                    this.ReturnRansom();
                                }
                                else if (this.OnPlayerRelease != null)
                                {
                                    this.OnPlayerRelease(this.BelongedFaction, this.CaptiveFaction, this);
                                }
                            }
                            else
                            {
                                int diplomaticRelation = base.Scenario.GetDiplomaticRelation(this.BelongedFaction.ID, this.CaptiveFaction.ID);
                                if (((diplomaticRelation >= 0) || (GameObject.Random(this.RansomFund) > GameObject.Random(this.RansomFund + this.BelongedFaction.Capital.Fund))) || (GameObject.Random(Math.Abs(diplomaticRelation) + 100) < GameObject.Random(100)))
                                {
                                    this.ReleaseCaptive();
                                }
                                else
                                {
                                    this.ReturnRansom();
                                }
                            }
                        }
                        else
                        {
                            this.RansomArriveDays = (int) (base.Scenario.GetDistance(this.RansomArchitecture.ArchitectureArea, this.BelongedFaction.Capital.ArchitectureArea) / 5.0);
                            if (this.RansomArriveDays <= 0)
                            {
                                this.RansomArriveDays = 1;
                            }
                            this.RansomArchitecture = this.BelongedFaction.Capital;
                        }
                    }
                    else
                    {
                        this.ReturnRansom();
                    }
                }
            }
        }

        private void DoRelease()
        {
            this.CaptivePerson.MoveToArchitecture(this.CaptivePerson.BelongedFaction.Capital);
            this.BelongedFaction.RemoveCaptive(this);
            if (this.LocationArchitecture != null)
            {
                this.LocationArchitecture.RemoveCaptive(this);
            }
            else if (this.LocationTroop != null)
            {
                this.LocationTroop.RemoveCaptive(this);
            }
            this.CaptiveFaction.RemoveSelfCaptive(this);
            this.CaptivePerson.BelongedCaptive = null;
            this.RansomArchitecture = null;
            this.RansomFund = 0;
            base.Scenario.Captives.Remove(this);
        }

        private void DoReturn()
        {
            if (((this.RansomFund > 0) && (this.CaptiveFaction.Capital != null)) && (this.BelongedFaction.Capital != null))
            {
                int num = (int) (base.Scenario.GetDistance(this.CaptiveFaction.Capital.ArchitectureArea, this.BelongedFaction.Capital.ArchitectureArea) / 5.0);
                if (num <= 0)
                {
                    num = 1;
                }
                this.CaptiveFaction.Capital.AddFundPack(this.RansomFund, this.RansomArriveDays + num);
            }
        }

        public void ReleaseCaptive()
        {
            if (this.OnRelease != null)
            {
                this.OnRelease(true, this.BelongedFaction, this.CaptiveFaction, this.CaptivePerson);
            }
            this.RansomArchitecture.IncreaseFund(this.RansomFund);
            this.DoRelease();
        }

        public void ReturnRansom()
        {
            if (this.OnRelease != null)
            {
                this.OnRelease(false, this.BelongedFaction, this.CaptiveFaction, this.CaptivePerson);
            }
            this.DoReturn();
        }

        public void SelfReleaseCaptive()
        {
            if (this.OnSelfRelease != null)
            {
                this.OnSelfRelease(this);
            }
            base.Scenario.ChangeDiplomaticRelation(this.BelongedFaction.ID, this.CaptiveFaction.ID, this.ReleaseRelation / 80);
            this.DoReturn();
            this.DoRelease();
        }

        public void SendRansom(Architecture to, Architecture from)
        {
            this.RansomFund = this.Ransom;
            from.DecreaseFund(this.RansomFund);
            this.RansomArchitecture = to;
            this.RansomArriveDays = (int) (base.Scenario.GetDistance(from.ArchitectureArea, to.ArchitectureArea) / 5.0);
            if (this.RansomArriveDays <= 0)
            {
                this.RansomArriveDays = 1;
            }
        }

        public void TransformToNoFaction()
        {
            if ((this.CaptivePerson != null) && (this.CaptivePerson.BelongedFaction != null))
            {
                this.CaptivePerson.Loyalty = 0;
                this.CaptivePerson.BelongedFaction.RemovePerson(this.CaptivePerson);
                this.CaptiveFaction.RemoveSelfCaptive(this);
                if (this.LocationArchitecture != null)
                {
                    this.LocationArchitecture.AddNoFactionPerson(this.CaptivePerson);
                    this.LocationArchitecture.RemoveCaptive(this);
                }
                else if (this.LocationTroop != null)
                {
                    if (this.BelongedFaction.Capital != null)
                    {
                        this.CaptivePerson.MoveToArchitecture(this.BelongedFaction.Capital);
                    }
                    else if (base.Scenario.Architectures.Count > 0)
                    {
                        this.CaptivePerson.MoveToArchitecture(base.Scenario.Architectures[GameObject.Random(base.Scenario.Architectures.Count)] as Architecture);
                    }
                    this.LocationTroop.RemoveCaptive(this);
                }
                this.CaptivePerson.BelongedCaptive = null;
                this.BelongedFaction.RemoveCaptive(this);
                base.Scenario.Captives.Remove(this);
            }
        }

        public string BelongedFactionString
        {
            get
            {
                return ((this.BelongedFaction != null) ? this.BelongedFaction.Name : "----");
            }
        }

        public string CaptiveFactionString
        {
            get
            {
                return ((this.CaptiveFaction != null) ? this.CaptiveFaction.Name : "----");
            }
        }

        public string LocationString
        {
            get
            {
                if (!base.Scenario.IsCurrentPlayer(this.CaptiveFaction))
                {
                    if (this.LocationArchitecture != null)
                    {
                        return this.LocationArchitecture.Name;
                    }
                    if (this.LocationTroop != null)
                    {
                        return this.LocationTroop.DisplayName;
                    }
                }
                return "----";
            }
        }

        public int Loyalty
        {
            get
            {
                if (this.CaptivePerson != null)
                {
                    return this.CaptivePerson.Loyalty;
                }
                return 100;
            }
        }

        public string LoyaltyString
        {
            get
            {
                if (this.CaptivePerson != null)
                {
                    if (base.Scenario.IsCurrentPlayer(this.CaptiveFaction))
                    {
                        return "----";
                    }
                    return this.CaptivePerson.Loyalty.ToString();
                }
                return "----";
            }
        }

        public string Name
        {
            get
            {
                return ((this.CaptivePerson != null) ? this.CaptivePerson.Name : "----");
            }
        }

        public int Ransom
        {
            get
            {
                if (this.CaptivePerson != null)
                {
                    return (int) (((float) ((this.CaptivePerson.Merit * ((this.CaptiveFaction.Leader == this.CaptivePerson) ? 2 : 1)) / 50)) / ((this.CaptiveFaction != null) ? (this.CaptiveFaction.InternalSurplusRate / 2f) : 1f));
                }
                return 0;
            }
        }

        public int RansomFund
        {
            get
            {
                return this.ransomFund;
            }
            set
            {
                this.ransomFund = value;
            }
        }

        public int ReleaseRelation
        {
            get
            {
                if (this.CaptivePerson != null)
                {
                    return (int) (((this.CaptivePerson.Merit * ((this.CaptiveFaction.Leader == this.CaptivePerson) ? 2 : 1)) / 50) * ((this.CaptiveFaction != null) ? Math.Pow((double) this.CaptiveFaction.InternalSurplusRate, 1.7999999523162842) : 1.0));
                }
                return 0;
            }
        }

        public delegate void PlayerRelease(Faction from, Faction to, Captive captive);

        public delegate void Release(bool success, Faction from, Faction to, Person person);

        public delegate void SelfRelease(Captive captive);
    }
}

