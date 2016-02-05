namespace GameObjects
{
    using GameObjects.ArchitectureDetail.EventEffect;
    using GameObjects.Conditions;
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;

    public class PersonIdDialog
    {
        public int id; public string dialog; public string scenBiography;
    }

    public class Event : GameObject
    {
        public int AfterEventHappened = -1;
        public TroopEvent AfterHappenedEvent;
        public int happenChance;
        public bool happened;
        public bool repeatable;
        public String nextScenario;
        public Dictionary<int, List<Person>> person;
        public Dictionary<int, List<Condition>> personCond;
        public ArchitectureList architecture;
        public List<Condition> architectureCond;
        public FactionList faction;
        public List<Condition> factionCond;
        public List<PersonIdDialog> dialog;
        public Dictionary<int, List<EventEffect>> effect;
        public List<PersonDialog> matchedDialog;
        public Dictionary<Person, List<EventEffect>> matchedEffect;
        public List<EventEffect> architectureEffect;
        public List<EventEffect> factionEffect;
        public List<PersonIdDialog> scenBiography = new List<PersonIdDialog>() ;
        public List<PersonDialog> matchedScenBiography = new List<PersonDialog> () ;
        public String Image = "";
        public String Sound = "";
        public bool GloballyDisplayed = false;
        public int StartYear = 0;
        public int StartMonth = 1;
        public int EndYear = 99999;
        public int EndMonth = 12;

        public event ApplyEvent OnApplyEvent;

        public void ApplyEventDialogs(Architecture a)
        {
            this.Scenario = a.Scenario;
            if (this.OnApplyEvent != null)
            {
                this.OnApplyEvent(this, a);
            }
            foreach (PersonDialog i in matchedScenBiography) 
            {
                this.Scenario.YearTable.addPersonInGameBiography(i.SpeakingPerson, this.Scenario.Date, i.Text);
            }
            if (nextScenario.Length > 0)
            {
                base.Scenario.EnableLoadAndSave = false;

                List<int> factionIds = new List<int>();
                foreach (Faction f in this.Scenario.PlayerFactions) 
                {
                    factionIds.Add(f.ID);
                }

                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = "GameData/Scenario/" + nextScenario,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                this.Scenario.LoadGameScenarioFromDatabase(builder.ConnectionString, factionIds);

                this.Scenario.GameScreen.ReloadScreenData();

                base.Scenario.EnableLoadAndSave = true;
            }
        }

        public void DoApplyEvent(Architecture a)
        {
            if (matchedEffect != null)
            {
                foreach (KeyValuePair<Person, List<EventEffect>> i in matchedEffect)
                {
                    foreach (EventEffect j in i.Value)
                    {
                        j.ApplyEffect(i.Key, this);
                    }
                }
            }
            if (architectureEffect != null)
            {
                foreach (EventEffect i in architectureEffect)
                {
                    i.ApplyEffect(a, this);
                }
            }
            if (factionEffect != null)
            {
                foreach (EventEffect i in factionEffect)
                {
                    i.ApplyEffect(a.BelongedFaction, this);
                }
            }
        }

        public bool matchEventPersons(Architecture a)
        {
            GameObjectList allPersons = a.Persons.GetList();
            foreach (Person p in a.NoFactionPersons)
            {
                allPersons.Add(p);
            }
            foreach (Captive p in a.Captives)
            {
                allPersons.Add(p.CaptivePerson);
            }
            foreach (Person p in a.Feiziliebiao)
            {
                allPersons.Add(p);
            }

            HashSet<int> haveCond = new HashSet<int>();
            foreach (KeyValuePair<int, List<Condition>> i in this.personCond)
            {
                haveCond.Add(i.Key);
            }

            HashSet<int> noCond = new HashSet<int>();
            foreach (KeyValuePair<int, List<Person>> i in this.person)
            {
                if (!haveCond.Contains(i.Key) && i.Value.Count == 0)
                {
                    noCond.Add(i.Key);
                }
            }

            Dictionary<int, List<Person>> candidates = new Dictionary<int, List<Person>>();
            foreach (int i in this.person.Keys)
            {
                candidates[i] = new List<Person>();
                if (noCond.Contains(i))
                {
                    foreach (Person p in allPersons.GetList())
                    {
                        candidates[i].Add(p);
                    }
                }
            }

            // check person in the architecture
            foreach (KeyValuePair<int, List<Condition>> i in this.personCond)
            {
                foreach (Person p in allPersons)
                {
                    bool ok = true;
                    foreach (Condition c in i.Value)
                    {
                        if (!c.CheckCondition(p, this))
                        {
                            ok = false;
                            break;
                        }
                    }
                    if (ok)
                    {
                        if (this.person[i.Key].Contains(null) || this.person[i.Key].Contains(p))
                        {
                            candidates[i.Key].Add(p);
                        }
                    }
                }
            }
            // check 7000 - 8000 persons which can be in anywhere
            foreach (KeyValuePair<int, List<Person>> i in this.person)
            {
                foreach (Person p in i.Value)
                {
                    if (p != null /*&& p.ID >= 7000 && p.ID < 8000*/)
                    {
                        bool ok = true;
                        if (this.personCond.ContainsKey(i.Key))
                        {
                            foreach (Condition c in this.personCond[i.Key])
                            {
                                if (!c.CheckCondition(p, this))
                                {
                                    ok = false;
                                    break;
                                }
                            }
                        }
                        if (ok)
                        {
                            if (this.person[i.Key].Contains(null) || this.person[i.Key].Contains(p))
                            {
                                candidates[i.Key].Add(p);
                            }
                        }
                    }
                }
            }

            foreach (List<Person> i in candidates.Values)
            {
                if (i.Count == 0) return false;
            }

            Dictionary<int, Person> matchedPersons = new Dictionary<int, Person>();
            foreach (KeyValuePair<int, List<Person>> i in candidates)
            {
                if (i.Value.Count <= 0) return false;
                Person selected = i.Value[GameObject.Random(i.Value.Count)];
                matchedPersons[i.Key] = selected;
                foreach (List<Person> j in candidates.Values)
                {
                    j.Remove(selected);
                }
            }

            matchedDialog = new List<PersonDialog>();
            foreach (PersonIdDialog i in this.dialog)
            {
                if (!matchedPersons.ContainsKey(i.id)) return false;

                PersonDialog pd = new PersonDialog();
                pd.SpeakingPerson = matchedPersons[i.id];
                pd.Text = i.dialog;
                for (int j = 0; j < matchedPersons.Count; ++j)
                {
                    pd.Text = pd.Text.Replace("%" + j, matchedPersons[j].Name);
                }
                matchedDialog.Add(pd);
            }
            
            matchedScenBiography = new List<PersonDialog>();
            foreach (PersonIdDialog i in this.scenBiography)
            {
                if (!matchedPersons.ContainsKey(i.id)) return false;

                PersonDialog pd = new PersonDialog();
                pd.SpeakingPerson = matchedPersons[i.id];
                pd.Text = i.dialog;
                for (int j = 0; j < matchedPersons.Count; ++j)
                {
                    pd.Text = pd.Text.Replace("%" + j, matchedPersons[j].Name);
                }
                matchedScenBiography.Add(pd);
            }

            matchedEffect = new Dictionary<Person, List<EventEffect>>();
            foreach (KeyValuePair<int, List<EventEffect>> i in this.effect)
            {
                matchedEffect.Add(matchedPersons[i.Key], i.Value);
            }

            return true;
        }

        public bool checkConditions(Architecture a)
        {
            if (this.happened && !this.repeatable) return false;
            if (GameObject.Random(this.happenChance) != 0)
            {
                return false;
            }

            if (this.AfterEventHappened >= 0)
            {
                if (!(base.Scenario.AllEvents.GetGameObject(this.AfterEventHappened) as Event).happened)
                {
                    return false;
                }
            }

            if (this.Scenario.Date.Year < this.StartYear || this.Scenario.Date.Year > this.EndYear) return false;

            if (this.Scenario.Date.Year == this.StartYear)
            {
                if (this.Scenario.Date.Month < this.StartMonth) return false;
            }

            if (this.Scenario.Date.Year == this.EndYear)
            {
                if (this.Scenario.Date.Month > this.EndMonth) return false;
            }

            foreach (Condition i in this.architectureCond)
            {
                if (!i.CheckCondition(a, this))
                {
                    return false;
                }
            }

            foreach (Condition i in this.factionCond)
            {
                if (a.BelongedFaction == null || !i.CheckCondition(a.BelongedFaction, this))
                {
                    return false;
                }
            }

            if (architecture != null || faction != null)
            {
                bool contains = false;
                if (architecture != null)
                {
                    foreach (Architecture archi in this.architecture)
                    {
                        if (archi.ID == a.ID)
                        {
                            contains = true;
                        }
                    }
                }

                if (faction != null)
                {
                    foreach (Faction f in faction)
                    {
                        if (a.BelongedFaction != null)
                        {
                            if (f.ID == a.BelongedFaction.ID)
                            {
                                contains = true;
                            }
                        }
                    }

                }
                if (contains)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
           
            return this.matchEventPersons(a);
        }

        public bool IsStart(GameScenario scenario)
        {
            Condition cstart = scenario.GameCommonData.AllConditions.GetCondition(9998);
            if (cstart == null) return false;
            return this.architectureCond.Contains(cstart) || this.factionCond.Contains(cstart);
        }

        public bool IsEnd(GameScenario scenario)
        {
            Condition cend = scenario.GameCommonData.AllConditions.GetCondition(9999);
            if (cend == null) return false;
            return this.architectureCond.Contains(cend) || this.factionCond.Contains(cend);
        }

        public void LoadPersonIdFromString(PersonList persons, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.person = new Dictionary<int, List<Person>>();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                int n = int.Parse(strArray[i]);
                int pid = int.Parse(strArray[i + 1]);
                if (!this.person.ContainsKey(n))
                {
                    this.person[n] = new List<Person>();
                }
                if (pid != -1)
                {
                    this.person[n].Add(persons.GetGameObject(pid) as Person);
                }
                else
                {
                    this.person[n].Add(null);
                }
            }
        }

        public string SavePersonIdToString()
        {
            string result = "";
            foreach (KeyValuePair<int, List<Person>> i in this.person)
            {
                foreach (Person j in i.Value)
                {
                    result += i.Key + " " + (j == null ? - 1 : j.ID) + " ";
                }
            }
            return result;
        }

        public void LoadPersonCondFromString(ConditionTable allConds, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.personCond = new Dictionary<int, List<Condition>>();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                int n = int.Parse(strArray[i]);
                int id = int.Parse(strArray[i + 1]);
                if (!allConds.Conditions.ContainsKey(id)) continue;
                if (!this.personCond.ContainsKey(n))
                {
                    this.personCond[n] = new List<Condition>();
                }
                this.personCond[n].Add(allConds.Conditions[id]);
            }
        }

        public string SavePersonCondToString()
        {
            string result = "";
            foreach (KeyValuePair<int, List<Condition>> i in this.personCond)
            {
                foreach (Condition j in i.Value)
                {
                    result += i.Key + " " + j.ID + " ";
                }
            }
            return result;
        }

        public void LoadArchitectureFromString(ArchitectureList archs, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.architecture = new ArchitectureList();
            foreach (string i in strArray)
            {
                this.architecture.Add(archs.GetGameObject(int.Parse(i)) as Architecture);
            }
        }

        public void LoadArchitctureCondFromString(ConditionTable c, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.architectureCond = new List<Condition>();
            foreach (string i in strArray)
            {
                if (!c.Conditions.ContainsKey(int.Parse(i))) continue;
                this.architectureCond.Add(c.Conditions[int.Parse(i)]);
            }
        }

        public string SaveArchitecureCondToString()
        {
            string result = "";
            foreach (Condition i in this.architectureCond)
            {
                result += i.ID + " ";
            }
            return result;
        }

        public void LoadFactionFromString(FactionList factions, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.faction = new FactionList();
            foreach (string i in strArray)
            {
                this.faction.Add(factions.GetGameObject(int.Parse(i)) as Faction);
            }
        }

        public void LoadFactionCondFromString(ConditionTable c, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.factionCond = new List<Condition>();
            foreach (string i in strArray)
            {
                if (!c.Conditions.ContainsKey(int.Parse(i))) continue;
                this.factionCond.Add(c.Conditions[int.Parse(i)]);
            }
        }

        public string SaveFactionCondToString()
        {
            string result = "";
            foreach (Condition i in this.factionCond)
            {
                result += i.ID + " ";
            }
            return result;
        }

        public void LoadDialogFromString(string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.dialog = new List<PersonIdDialog>();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                PersonIdDialog d = new PersonIdDialog();
                d.id = int.Parse(strArray[i]);
                d.dialog = strArray[i + 1];
                this.dialog.Add(d);
            }
        }
        
        public void LoadScenBiographyFromString(string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.scenBiography = new List<PersonIdDialog>();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                PersonIdDialog d = new PersonIdDialog();
                d.id = int.Parse(strArray[i]);
                d.dialog = strArray[i + 1];
                this.scenBiography.Add(d);
            }
        }

        public string SaveDialogToString()
        {
            string result = "";
            foreach (PersonIdDialog i in this.dialog)
            {
                result += i.id + " " + i.dialog + " ";
            }
            return result;
        }
        
        public string SaveScenBiographyToString()
        {
            string result = "";
            foreach (PersonIdDialog i in this.scenBiography)
            {
                result += i.id + " " + i.scenBiography + " ";
            }
            return result;
        }

        public void LoadEffectFromString(EventEffectTable allEffect, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.effect = new Dictionary<int, List<EventEffect>>();
            for (int i = 0; i < strArray.Length; i += 2)
            {
                int n = int.Parse(strArray[i]);
                int id = int.Parse(strArray[i + 1]);
                if (!allEffect.EventEffects.ContainsKey(id)) continue;
                if (!this.effect.ContainsKey(n))
                {
                    this.effect[n] = new List<EventEffect>();
                }
                this.effect[n].Add(allEffect.EventEffects[id]);
            }
        }

        public string SaveEventEffectToString()
        {
            string result = "";
            foreach (KeyValuePair<int, List<EventEffect>> i in this.effect)
            {
                foreach (EventEffect j in i.Value)
                {
                    result += i.Key + " " + j.ID + " ";
                }
            }
            return result;
        }

        public void LoadArchitectureEffectFromString(EventEffectTable allEffect, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.architectureEffect = new List<EventEffect>();
            foreach (string i in strArray)
            {
                if (!allEffect.EventEffects.ContainsKey(int.Parse(i))) continue;
                this.architectureEffect.Add(allEffect.EventEffects[int.Parse(i)]);
            }
        }

        public string SaveArchitectureEffectToString()
        {
            string result = "";
            foreach (EventEffect i in this.architectureEffect)
            {
                result += i.ID + " ";
            }
            return result;
        }

        public void LoadFactionEffectFromString(EventEffectTable allEffect, string data)
        {
            char[] separator = new char[] { ' ', '\n', '\r', '\t' };
            string[] strArray = data.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            this.factionEffect = new List<EventEffect>();
            foreach (string i in strArray)
            {
                if (!allEffect.EventEffects.ContainsKey(int.Parse(i))) continue;
                this.factionEffect.Add(allEffect.EventEffects[int.Parse(i)]);
            }
        }

        public string SaveFactionEffectToString()
        {
            string result = "";
            foreach (EventEffect i in this.factionEffect)
            {
                result += i.ID + " ";
            }
            return result;
        }
        
       /*
        public bool CheckFactionEvent(Architecture a)
        {
           if (this.faction != null && this.faction.GameObjects.Contains(a.BelongedFaction) && checkConditions(a))
            {
                return true ;
            }
            return false ;
        }
        */
        public delegate void ApplyEvent(Event te, Architecture a);

    }
}
