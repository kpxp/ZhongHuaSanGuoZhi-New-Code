namespace GameObjects.Influences
{
    using GameObjects;
    using System;
    using System.Runtime.InteropServices;
    using Microsoft.Xna.Framework;

    public abstract class InfluenceKind : GameObject
    {
        public bool TroopLeaderValid;
        private InfluenceType type;
        private bool combat;

        public float AIPersonValue { get; set; }
        public float AIPersonValuePow { get; set; }

        private float p1, p2;

        public bool Combat
        {
            get
            {
                return combat;
            }
            set
            {
                combat = value;
            }
        }

        public virtual void ApplyInfluenceKind(Architecture a)
        {
        }

        public void ApplyInfluenceKind(Architecture architecture, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                ApplyInfluenceKind(architecture);
            } 
            else if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in architecture.Persons)
                {
                    ApplyingPerson a = new ApplyingPerson(p, applier, applierID);
                    if (!i.appliedPerson.Contains(a))
                    {
                        i.appliedPerson.Add(a);
                        ApplyInfluenceKind(p, i, applier, applierID, false);
                    }
                }
                foreach (Person p in architecture.MovingPersons)
                {
                    ApplyingPerson a = new ApplyingPerson(p, applier, applierID);
                    if (!i.appliedPerson.Contains(a))
                    {
                        i.appliedPerson.Add(a);
                        ApplyInfluenceKind(p, i, applier, applierID, false);
                    }
                }
            }
        }

        public virtual void ApplyInfluenceKind(Faction f)
        {
        }

        public void ApplyInfluenceKind(Faction faction, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.势力)
            {
                ApplyInfluenceKind(faction);
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                foreach (Architecture a in faction.Architectures)
                {
                    ApplyingArchitecture z = new ApplyingArchitecture(a, applier, applierID);
                    if (!i.appliedArch.Contains(z))
                    {
                        i.appliedArch.Add(z);
                        ApplyInfluenceKind(a, i, applier, applierID);
                    }
                }
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                foreach (Troop t in faction.Troops)
                {
                    ApplyingTroop a = new ApplyingTroop(t, applier, applierID);
                    if (!i.appliedTroop.Contains(a))
                    {
                        i.appliedTroop.Add(a);
                        t.InfluencesApplying.Add(i);
                        ApplyInfluenceKind(t, i, applier, applierID);
                    }
                }
            }
            if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in faction.Persons)
                {
                    ApplyingPerson a = new ApplyingPerson(p, applier, applierID);
                    if (!i.appliedPerson.Contains(a))
                    {
                        i.appliedPerson.Add(a);
                        ApplyInfluenceKind(p, i, applier, applierID, false);
                    }
                }
            }
        }

        public virtual void ApplyInfluenceKind(Person p)
        {
        }

        public void ApplyInfluenceKind(Person person, Influence i, Applier applier, int applierID, bool excludePersonal)
        {
            if (this.Type == InfluenceType.个人 && !excludePersonal)
            {
                ApplyInfluenceKind(person);
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationTroop != null)
                {
                    ApplyingTroop z = new ApplyingTroop(person.LocationTroop, applier, applierID);
                    if (!i.appliedTroop.Contains(z))
                    {
                        i.appliedTroop.Add(z);
                        person.LocationTroop.InfluencesApplying.Add(i);
                        ApplyInfluenceKind(person.LocationTroop, i, applier, applierID);
                    }
                }
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                if (person.LocationArchitecture != null)
                {
                    ApplyingArchitecture z = new ApplyingArchitecture(person.LocationArchitecture, applier, applierID);
                    if (!i.appliedArch.Contains(z))
                    {
                        i.appliedArch.Add(z);
                        ApplyInfluenceKind(person.LocationArchitecture, i, applier, applierID);
                    }
                }
            }
        }

        public virtual void ApplyInfluenceKind(Troop t)
        {
        }

        public void ApplyInfluenceKind(Troop troop, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                ApplyInfluenceKind(troop);
            }
        }

        public virtual void DoWork(Architecture architecture)
        {
        }

        public virtual int GetCredit(Troop source, Troop destination)
        {
            return 0;
        }

        public virtual int GetCreditWithPosition(Troop source, out Point? position)
        {
            //position = 0;
            position = new Point(0, 0);
            return 0;
        }

        public virtual void InitializeParameter(string parameter)
        {
        }

        public virtual void InitializeParameter2(string parameter)
        {
        }

        public virtual bool IsVaild(Person person)
        {
            return true;
        }

        public virtual bool IsVaild(Troop troop)
        {
            return true;
        }

        public virtual void PurifyInfluenceKind(Architecture a)
        {
        }

        public void PurifyInfluenceKind(Architecture architecture, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                PurifyInfluenceKind(architecture);
            }
            else if (this.Type == InfluenceType.个人)
            {
                foreach (Person p in architecture.Persons)
                {
                    i.appliedPerson.Remove(new ApplyingPerson(p, applier, applierID));
                    PurifyInfluenceKind(p, i, applier, applierID, false);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Faction f)
        {
        }

        public void PurifyInfluenceKind(Faction faction, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.势力)
            {
                PurifyInfluenceKind(faction);
                foreach (Architecture a in faction.Architectures)
                {
                    i.appliedArch.Remove(new ApplyingArchitecture(a, applier, applierID));
                    PurifyInfluenceKind(a, i, applier, applierID);
                }
                foreach (Troop t in faction.Troops)
                {
                    PurifyInfluenceKind(t, i, applier, applierID);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Person p)
        {
        }

        public void PurifyInfluenceKind(Person person, Influence i, Applier applier, int applierID, bool excludePersonal)
        {
            if (this.Type == InfluenceType.个人 && !excludePersonal)
            {
                PurifyInfluenceKind(person);
            }
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                ApplyingTroop t = new ApplyingTroop(person.LocationTroop, applier, applierID);
                if (person.LocationTroop != null && i.appliedTroop.Contains(t))
                {
                    i.appliedTroop.Remove(t);
                    PurifyInfluenceKind(person.LocationTroop, i, applier, applierID);
                }
            }
            if (this.Type == InfluenceType.建筑 || this.Type == InfluenceType.建筑战斗)
            {
                ApplyingArchitecture t = new ApplyingArchitecture(person.LocationArchitecture, applier, applierID);
                if (person.LocationTroop != null && i.appliedArch.Contains(t))
                {
                    i.appliedArch.Remove(t);
                    PurifyInfluenceKind(person.LocationArchitecture, i, applier, applierID);
                }
            }
        }

        public virtual void PurifyInfluenceKind(Troop t)
        {
        }

        public void PurifyInfluenceKind(Troop troop, Influence i, Applier applier, int applierID)
        {
            if (this.Type == InfluenceType.战斗 || this.Type == InfluenceType.建筑战斗)
            {
                PurifyInfluenceKind(troop);
            }
        }

        public virtual double AIFacilityValue(Architecture a)
        {
            return 0;
        }

        public InfluenceType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

    }
}

