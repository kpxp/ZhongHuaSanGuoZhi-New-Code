using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;
using		Microsoft.Xna.Framework;
using PluginInterface;
using GameObjects.ArchitectureDetail;
using GameObjects.FactionDetail;
using GameObjects.TroopDetail;
using GameObjects.SectionDetail;
using GameObjects.PersonDetail;



namespace WorldOfTheThreeKingdoms.GameScreens

{
    public class ScreenManager
    {
        public Troop CreatingTroop;
        public Architecture CurrentArchitecture;
        public ArchitectureWorkKind CurrentArchitectureWorkKind;
        public Faction CurrentFaction;
        public GameObject CurrentGameObject;
        public GameObjectList CurrentGameObjects;
        public Military CurrentMilitary;
        public int CurrentNumber;
        public int Currentzijin;
        public Person CurrentPerson;
        public GameObjectList CurrentPersons;
        public Routeway CurrentRouteway;
        public Troop CurrentTroop;
        private GameScenario gameScenario;
        private FrameFunction lastFrameFunction;
        private MainGameScreen mainGameScreen;

        public ScreenManager(MainGameScreen mainGameScreen)
        {
            this.mainGameScreen = mainGameScreen;
        }

        private void FrameFunction_Architecture_AfterGetAwardTreasure()
        {
            this.CurrentGameObject = this.mainGameScreen.Plugins.TabListPlugin.SelectedItem as GameObject;
            if (this.CurrentGameObject != null)
            {
                Treasure currentGameObject = this.CurrentGameObject as Treasure;
                if (currentGameObject.BelongedPerson != null)
                {
                    this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetAwardTreasurePerson, false, true, true, false, this.CurrentArchitecture.GetPersonListExceptLeader(), null, "", "");
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetAwardTreasurePerson()
        {
            this.CurrentPerson = this.mainGameScreen.Plugins.TabListPlugin.SelectedItem as Person;
            if (this.CurrentPerson != null)
            {
                Treasure currentGameObject = this.CurrentGameObject as Treasure;
                if (currentGameObject.BelongedPerson != null)
                {
                    this.CurrentArchitecture.BelongedFaction.Leader.LoseTreasure(currentGameObject);
                    this.CurrentPerson.AwardedTreasure(currentGameObject);
                }
            }
        }

        private void FrameFunction_Architecture_Afterxuanzemeinv()
        {
            
        }

        private void FrameFunction_Architecture_chongxingmeinv()
        {
            this.CurrentPerson = this.mainGameScreen.Plugins.TabListPlugin.SelectedItem as Person;
            if (this.CurrentPerson != null)
            {

                this.mainGameScreen.xianshishijiantupian(this.CurrentPerson, (this.gameScenario.Persons.GetGameObject(this.CurrentPerson.suoshurenwu) as Person).Name, "chongxing", this.CurrentPerson.ID.ToString() + ".jpg", "hougong.mp3",true );
                if (GameObject.Random(30)==0&& !this.CurrentPerson.huaiyun && (this.CurrentArchitecture.BelongedFaction.Leader.meichushengdehaiziliebiao().Count-this.CurrentArchitecture.yihuaiyundefeiziliebiao().Count>0))
                {
                    this.CurrentPerson.huaiyun = true;
                    this.CurrentPerson.huaiyuntianshu = 0;
                    
                }
                this.mainGameScreen.DateGo(1);
            }
        }

        private void FrameFunction_Architecture_AfterGetBeDisbandedMilitaries()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Militaries.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Military military in this.CurrentGameObjects)
                {
                    this.CurrentArchitecture.DisbandMilitary(military);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetBeMergedMilitaries()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.BeMergedMilitaryList.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Military military in this.CurrentGameObjects)
                {
                    int increment = (military.Quantity + this.CurrentMilitary.Quantity) - this.CurrentMilitary.Kind.MaxScale;
                    if (increment > 0)
                    {
                        this.CurrentMilitary.BelongedArchitecture.IncreasePopulation(increment);
                    }
                    if (military.LeaderID == this.CurrentMilitary.LeaderID)
                    {
                        this.CurrentMilitary.IncreaseQuantity(military.Quantity, military.Morale, military.Combativity, military.Experience, military.LeaderExperience);
                    }
                    else
                    {
                        this.CurrentMilitary.IncreaseQuantity(military.Quantity, military.Morale, military.Combativity, military.Experience, 0);
                    }
                }
                foreach (Military military in this.CurrentGameObjects)
                {
                    this.CurrentArchitecture.RemoveMilitary(military);
                    this.CurrentArchitecture.BelongedFaction.RemoveMilitary(military);
                    this.CurrentArchitecture.Scenario.Militaries.Remove(military);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetConfiscateTreasure()
        {
            this.CurrentGameObject = this.mainGameScreen.Plugins.TabListPlugin.SelectedItem as GameObject;
            if (this.CurrentGameObject != null)
            {
                Treasure currentGameObject = this.CurrentGameObject as Treasure;
                if (currentGameObject.BelongedPerson != null)
                {
                    currentGameObject.BelongedPerson.ConfiscatedTreasure(currentGameObject);
                    this.CurrentArchitecture.BelongedFaction.Leader.ReceiveTreasure(currentGameObject);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetConvinceDestinationPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.ConvinceDestinationPersonList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                foreach (Person person in this.CurrentPersons)
                {
                    person.GoForConvince(this.CurrentGameObjects[0] as Person);
                }
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetConvinceSourcePerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                this.CurrentPersons = this.CurrentGameObjects.GetList();
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.ConvincePersonPosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetDestroyPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                this.CurrentPersons = this.CurrentGameObjects.GetList();
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.DestroyPosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetFacilityToBuild()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.BuildableFacilityKindList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                FacilityKind facilityKind = this.CurrentGameObjects[0] as FacilityKind;
                this.CurrentArchitecture.BeginToBuildAFacility(facilityKind);
            }
        }

        private void FrameFunction_Architecture_AfterGetFacilityToDemolish()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Facilities.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Facility facility in this.CurrentGameObjects)
                {
                    this.CurrentArchitecture.DemolishFacility(facility);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetFriendlyDiplomaticRelation()
        {
            GameObjectList selectedList = this.CurrentArchitecture.ResetDiplomaticRelationList.GetSelectedList();
            if (selectedList != null)
            {
                foreach (DiplomaticRelationDisplay display in selectedList)
                {
                    display.Relation = 0;
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetGossipPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                this.CurrentPersons = this.CurrentGameObjects.GetList();
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.GossipPosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetInformationKind()
        {
            this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetInformationPerson, false, true, true, false, this.CurrentArchitecture.Persons, null, "情报", "情报");
        }

        private void FrameFunction_Architecture_AfterGetInformationPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                this.CurrentPerson = this.CurrentGameObjects[0] as Person;
                this.CurrentPerson.CurrentInformationKind = this.CurrentPerson.Scenario.GameCommonData.AllInformationKinds.GetSelectedList()[0] as InformationKind;
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.InformationPosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetInstigatePerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                this.CurrentPersons = this.CurrentGameObjects.GetList();
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.InstigatePosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetLevelUpMilitaries()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.LevelUpMilitaryList.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Military military in this.CurrentGameObjects)
                {
                    this.CurrentArchitecture.LevelUpMilitary(military);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetMergeMilitary()
        {
            GameObjectList selectedList = this.CurrentArchitecture.MergeMilitaryList.GetSelectedList();
            if ((selectedList != null) && (selectedList.Count == 1))
            {
                this.CurrentMilitary = selectedList[0] as Military;
                this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetBeMergedMilitaries, false, true, true, false, this.CurrentArchitecture.GetBeMergedMilitaryList(this.CurrentMilitary), null, "选择编队", "");
            }
        }

        private void FrameFunction_Architecture_AfterGetNewCapital()
        {
            GameObjectList selectedList = this.CurrentArchitecture.ChangeCapitalArchitectureList.GetSelectedList();
            if ((selectedList != null) && (selectedList.Count == 1))
            {
                this.CurrentArchitecture.DecreaseFund(this.CurrentArchitecture.ChangeCapitalCost);
                this.CurrentArchitecture.BelongedFaction.ChangeCapital(selectedList[0] as Architecture);
            }
        }

        private void FrameFunction_Architecture_AfterGetNewMilitaryKind()
        {
            if (this.CurrentArchitecture != null)
            {
                this.CurrentGameObjects = this.CurrentArchitecture.NewMilitaryKindList.GetSelectedList();
                if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
                {
                    this.CurrentArchitecture.CreateMilitary(this.CurrentGameObjects[0] as MilitaryKind);
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetOneArchitecture()
        {
        }

        private void FrameFunction_Architecture_AfterGetRecruitmentMilitary()
        {
            GameObjectList selectedList = this.CurrentArchitecture.RecruitmentMilitaryList.GetSelectedList();
            if ((selectedList != null) && (selectedList.Count == 1))
            {
                this.CurrentMilitary = selectedList[0] as Military;
                this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetRecruitmentPerson, false, true, true, false, this.CurrentArchitecture.Persons, null, "补充", "补充");
            }
        }

        private void FrameFunction_Architecture_AfterGetRecruitmentPerson()
        {
        }

        private void FrameFunction_Architecture_AfterGetRedeemCaptive()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.RedeemCaptiveList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                (this.CurrentGameObjects[0] as Captive).SendRansom((this.CurrentGameObjects[0] as Captive).BelongedFaction.Capital, this.CurrentArchitecture);
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetReleaseCaptive()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.BelongedFaction.Captives.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Captive captive in this.CurrentGameObjects)
                {
                    captive.SelfReleaseCaptive();
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetRewardPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.RewardPersonList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count > 0))
            {
                this.CurrentArchitecture.RewardByPersonList(this.CurrentGameObjects);
            }
        }

        private void FrameFunction_Architecture_AfterGetSearchPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Person person in this.CurrentGameObjects)
                {
                    person.GoForSearch();
                }
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetSectionToDemolish()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.BelongedFaction.Sections.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                foreach (Section section in this.CurrentGameObjects)
                {
                    this.CurrentArchitecture.BelongedFaction.RemoveSection(section);
                    this.CurrentArchitecture.Scenario.Sections.Remove(section);
                    Section anotherSection = this.CurrentArchitecture.BelongedFaction.GetAnotherSection(section);
                    if (anotherSection != null)
                    {
                        foreach (Architecture architecture in section.Architectures)
                        {
                            anotherSection.AddArchitecture(architecture);
                        }
                    }
                }
                foreach (Section section in this.CurrentArchitecture.BelongedFaction.Sections.GetList())
                {
                    if ((section.OrientationSection != null) && !this.CurrentArchitecture.BelongedFaction.Sections.HasGameObject(section.OrientationSection))
                    {
                        foreach (SectionAIDetail detail in this.CurrentArchitecture.BelongedFaction.Scenario.GameCommonData.AllSectionAIDetails.SectionAIDetails.Values)
                        {
                            if (detail.OrientationKind == SectionOrientationKind.无)
                            {
                                section.AIDetail = detail;
                                break;
                            }
                        }
                        section.OrientationSection = null;
                    }
                    section.RefreshSectionName();
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetShortestNoWaterRouteway()
        {
            this.CurrentGameObjects = this.mainGameScreen.Plugins.TabListPlugin.SelectedItemList as GameObjectList;
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count > 0))
            {
                foreach (Architecture architecture in this.CurrentGameObjects)
                {
                    Routeway routeway = this.CurrentArchitecture.BuildShortestRouteway(architecture, true);
                    if (routeway != null)
                    {
                        routeway.Building = true;
                    }
                }
                GlobalVariables.CurrentMapLayer = MapLayerKind.Routeway;
            }
        }

        private void FrameFunction_Architecture_AfterGetShortestRouteway()   //粮道最短
        {
            this.CurrentGameObjects = this.mainGameScreen.Plugins.TabListPlugin.SelectedItemList as GameObjectList;
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count > 0))
            {
                foreach (Architecture architecture in this.CurrentGameObjects)
                {
                    Routeway routeway = this.CurrentArchitecture.BuildShortestRouteway(architecture, false);
                    if (routeway != null)
                    {
                        routeway.Building = true;
                    }
                }
                GlobalVariables.CurrentMapLayer = MapLayerKind.Routeway;
            }
        }

        private void FrameFunction_Architecture_AfterGetSpyPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
            if (this.CurrentGameObjects != null)
            {
                this.CurrentPersons = this.CurrentGameObjects.GetList();
                this.mainGameScreen.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.SpyPosition));
            }
        }

        private void FrameFunction_Architecture_AfterGetStudySkillPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.PersonStudySkillList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count > 0))
            {
                foreach (Person person in this.CurrentGameObjects)
                {
                    person.GoForStudySkill();
                }
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetStudyStunt()
        {
            this.CurrentGameObjects = this.CurrentPerson.StudyStuntList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                this.CurrentPerson.GoForStudyStunt(this.CurrentGameObjects[0] as Stunt);
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetStudyStuntPerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.PersonStudyStuntList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                Person person = this.CurrentGameObjects[0] as Person;
                if (person != null)
                {
                    this.CurrentPerson = person;
                    this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Stunt, FrameFunction.GetStudyStunt, false, true, true, false, person.GetStudyStuntList(), null, "研习", "");
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetStudyTitle()
        {
            this.CurrentGameObjects = this.CurrentPerson.StudyTitleList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                this.CurrentPerson.GoForStudyTitle(this.CurrentGameObjects[0] as Title);
                this.mainGameScreen.PlayNormalSound("GameSound/Tactics/Outside.wav");
            }
        }

        private void FrameFunction_Architecture_AfterGetStudyTitlePerson()
        {
            this.CurrentGameObjects = this.CurrentArchitecture.PersonStudyTitleList.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                Person person = this.CurrentGameObjects[0] as Person;
                if (person != null)
                {
                    this.CurrentPerson = person;
                    this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Title, FrameFunction.GetStudyTitle, false, true, true, false, person.GetStudyTitleList(), null, "研习", "");
                }
            }
        }

        private void FrameFunction_Architecture_AfterGetTrainingMilitary()
        {
            GameObjectList selectedList = this.CurrentArchitecture.TrainingMilitaryList.GetSelectedList();
            if ((selectedList != null) && (selectedList.Count == 1))
            {
                this.CurrentMilitary = selectedList[0] as Military;
                this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetTrainingPerson, false, true, true, false, this.CurrentArchitecture.Persons, null, "训练", "训练");
            }
        }

        private void FrameFunction_Architecture_AfterGetTrainingPerson()
        {
        }

        private void FrameFunction_Architecture_PersonConvene()
        {
        }

        private void FrameFunction_Architecture_PersonTransfer()
        {
            if (this.CurrentArchitecture != null)
            {
                this.CurrentGameObjects = this.CurrentArchitecture.Persons.GetSelectedList();
                if (this.CurrentGameObjects != null)
                {
                    this.mainGameScreen.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.GetOneArchitecture, false, true, true, false, this.CurrentArchitecture.GetTransferArchitectureList(), null, "目标", "");
                }
            }
        }

        private void FrameFunction_Architecture_WorkingList()
        {
            
        }

        private void FrameFunction_Troop_AfterGetAttackDefaultKind()
        {
            this.CurrentGameObjects = this.CurrentTroop.Scenario.GameCommonData.AllAttackDefaultKinds.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                (this.CurrentGameObjects[0] as AttackDefaultKind).Apply(this.CurrentTroop);
            }
        }

        private void FrameFunction_Troop_AfterGetAttackTargetKind()
        {
            this.CurrentGameObjects = this.CurrentTroop.Scenario.GameCommonData.AllAttackTargetKinds.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                (this.CurrentGameObjects[0] as AttackTargetKind).Apply(this.CurrentTroop);
            }
        }

        private void FrameFunction_Troop_AfterGetCastDefaultKind()
        {
            this.CurrentGameObjects = this.CurrentTroop.Scenario.GameCommonData.AllCastDefaultKinds.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                (this.CurrentGameObjects[0] as CastDefaultKind).Apply(this.CurrentTroop);
            }
        }

        private void FrameFunction_Troop_AfterGetCastTargetKind()
        {
            this.CurrentGameObjects = this.CurrentTroop.Scenario.GameCommonData.AllCastTargetKinds.GetSelectedList();
            if ((this.CurrentGameObjects != null) && (this.CurrentGameObjects.Count == 1))
            {
                (this.CurrentGameObjects[0] as CastTargetKind).Apply(this.CurrentTroop);
            }
        }

        public void HandleFrameFunction(FrameFunction function)
        {
            switch (function)
            {
                case FrameFunction.GetOneArchitecture:
                    this.FrameFunction_Architecture_AfterGetOneArchitecture();
                    break;

                case FrameFunction.Architecture_WorkingList:
                    this.FrameFunction_Architecture_WorkingList();
                    break;

                case FrameFunction.PersonTransfer:
                    this.FrameFunction_Architecture_PersonTransfer();
                    break;

                case FrameFunction.PersonConvene:
                    this.FrameFunction_Architecture_PersonConvene();
                    break;

                case FrameFunction.GetConvinceSourcePerson:
                    this.FrameFunction_Architecture_AfterGetConvinceSourcePerson();
                    break;

                case FrameFunction.GetConvinceDestinationPerson:
                    this.FrameFunction_Architecture_AfterGetConvinceDestinationPerson();
                    break;

                case FrameFunction.GetRewardPerson:
                    this.FrameFunction_Architecture_AfterGetRewardPerson();
                    break;

                case FrameFunction.GetRedeemCaptive:
                    this.FrameFunction_Architecture_AfterGetRedeemCaptive();
                    break;

                case FrameFunction.GetReleaseCaptive:
                    this.FrameFunction_Architecture_AfterGetReleaseCaptive();
                    break;

                case FrameFunction.GetStudySkillPerson:
                    this.FrameFunction_Architecture_AfterGetStudySkillPerson();
                    break;

                case FrameFunction.GetStudyTitlePerson:
                    this.FrameFunction_Architecture_AfterGetStudyTitlePerson();
                    break;

                case FrameFunction.GetStudyTitle:
                    this.FrameFunction_Architecture_AfterGetStudyTitle();
                    break;

                case FrameFunction.GetStudyStuntPerson:
                    this.FrameFunction_Architecture_AfterGetStudyStuntPerson();
                    break;

                case FrameFunction.GetStudyStunt:
                    this.FrameFunction_Architecture_AfterGetStudyStunt();
                    break;

                case FrameFunction.GetTrainingMilitary:
                    this.FrameFunction_Architecture_AfterGetTrainingMilitary();
                    break;

                case FrameFunction.GetTrainingPerson:
                    this.FrameFunction_Architecture_AfterGetTrainingPerson();
                    break;

                case FrameFunction.GetNewMilitaryKind:
                    this.FrameFunction_Architecture_AfterGetNewMilitaryKind();
                    break;

                case FrameFunction.GetRecruitmentMilitary:
                    this.FrameFunction_Architecture_AfterGetRecruitmentMilitary();
                    break;

                case FrameFunction.GetRecruitmentPerson:
                    this.FrameFunction_Architecture_AfterGetRecruitmentPerson();
                    break;

                case FrameFunction.GetMergeMilitary:
                    this.FrameFunction_Architecture_AfterGetMergeMilitary();
                    break;

                case FrameFunction.GetBeMergedMilitaries:
                    this.FrameFunction_Architecture_AfterGetBeMergedMilitaries();
                    break;

                case FrameFunction.GetBeDisbandedMilitaries:
                    this.FrameFunction_Architecture_AfterGetBeDisbandedMilitaries();
                    break;

                case FrameFunction.GetLevelUpMilitaries:
                    this.FrameFunction_Architecture_AfterGetLevelUpMilitaries();
                    break;

                case FrameFunction.GetNewCapital:
                    this.FrameFunction_Architecture_AfterGetNewCapital();
                    break;

                case FrameFunction.GetFriendlyDiplomaticRelation:
                    this.FrameFunction_Architecture_AfterGetFriendlyDiplomaticRelation();
                    break;

                case FrameFunction.GetAttackDefaultKind:
                    this.FrameFunction_Troop_AfterGetAttackDefaultKind();
                    break;

                case FrameFunction.GetAttackTargetKind:
                    this.FrameFunction_Troop_AfterGetAttackTargetKind();
                    break;

                case FrameFunction.GetCastDefaultKind:
                    this.FrameFunction_Troop_AfterGetCastDefaultKind();
                    break;

                case FrameFunction.GetCastTargetKind:
                    this.FrameFunction_Troop_AfterGetCastTargetKind();
                    break;

                case FrameFunction.GetInformationKind:
                    this.FrameFunction_Architecture_AfterGetInformationKind();
                    break;

                case FrameFunction.GetInformationPerson:
                    this.FrameFunction_Architecture_AfterGetInformationPerson();
                    break;

                case FrameFunction.GetSpyPerson:
                    this.FrameFunction_Architecture_AfterGetSpyPerson();
                    break;

                case FrameFunction.GetDestroyPerson:
                    this.FrameFunction_Architecture_AfterGetDestroyPerson();
                    break;

                case FrameFunction.GetInstigatePerson:
                    this.FrameFunction_Architecture_AfterGetInstigatePerson();
                    break;

                case FrameFunction.GetGossipPerson:
                    this.FrameFunction_Architecture_AfterGetGossipPerson();
                    break;

                case FrameFunction.GetSearchPerson:
                    this.FrameFunction_Architecture_AfterGetSearchPerson();
                    break;

                case FrameFunction.GetFacilityToBuild:
                    this.FrameFunction_Architecture_AfterGetFacilityToBuild();
                    break;

                case FrameFunction.GetFacilityToDemolish:
                    this.FrameFunction_Architecture_AfterGetFacilityToDemolish();
                    break;

                case FrameFunction.GetSectionToDemolish:
                    this.FrameFunction_Architecture_AfterGetSectionToDemolish();
                    break;

                case FrameFunction.GetShortestRouteway:
                    this.FrameFunction_Architecture_AfterGetShortestRouteway();
                    break;

                case FrameFunction.GetShortestNoWaterRouteway:
                    this.FrameFunction_Architecture_AfterGetShortestNoWaterRouteway();
                    break;

                case FrameFunction.GetConfiscateTreasure:
                    this.FrameFunction_Architecture_AfterGetConfiscateTreasure();
                    break;

                case FrameFunction.GetAwardTreasure:
                    this.FrameFunction_Architecture_AfterGetAwardTreasure();
                    break;

                case FrameFunction.GetAwardTreasurePerson:
                    this.FrameFunction_Architecture_AfterGetAwardTreasurePerson();
                    break;
                case FrameFunction.xuanzemeinv :
                    this.FrameFunction_Architecture_Afterxuanzemeinv();
                    break;
                case FrameFunction.chongxingmeinv:
                    this.FrameFunction_Architecture_chongxingmeinv();
                    break;
            }
            this.lastFrameFunction = function;
        }

        public void Initialize(GameScenario scenario)
        {
            this.gameScenario = scenario;
        }

        public void SetCreatingTroopPosition(Point position)
        {
            this.CurrentTroop = this.CurrentArchitecture.CreateTroop(this.CurrentGameObjects, this.CurrentPerson, this.CurrentMilitary, this.CurrentNumber, position);
            this.CurrentTroop.zijin = this.Currentzijin;
            this.CurrentTroop.mingling = "——";
            this.CurrentArchitecture.DecreaseFund(this.CurrentTroop.zijin);
            if ((this.CurrentArchitecture.DefensiveLegion == null) || (this.CurrentArchitecture.DefensiveLegion.Troops.Count == 0))
            {
                this.CurrentArchitecture.CreateDefensiveLegion();
            }
            this.CurrentArchitecture.DefensiveLegion.AddTroop(this.CurrentTroop);
            this.CurrentArchitecture.PostCreateTroop(this.CurrentTroop, true);
            this.mainGameScreen.Plugins.PersonBubblePlugin.AddPerson(this.CurrentPerson, this.CurrentTroop.Position, "Campaign");
            this.mainGameScreen.Plugins.AirViewPlugin.ReloadTroopView();
        }
    }

 

}
