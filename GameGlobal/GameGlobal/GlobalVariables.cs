namespace GameGlobal
{
    using System;
    using System.Xml;
    using System.Collections;
    using System.Collections.Generic;

    public class GlobalVariables
    {
        public static bool WujiangYoukenengDuli = true;
        public static bool LiangdaoXitong = false;
        public static bool ShowGrid = false;
        public static bool AdditionalPersonAvailable = false;
        public const float ArchitectureLayerDepth = 0.8f;
        public const float BackgroundDepthOffset = -1E-05f;
        public const float BackTileAnimationLayerDepth = 0.75f;
        public static bool CalculateAverageCostOfTiers = false;
        public static bool CommonPersonAvailable = true;
        public const float ConmentTextDepth = 0.15f;
        public const float ContextMenuDepth = 0.1f;
        public const float ControlDepthOffset = -0.001f;
        public static MapLayerKind CurrentMapLayer;
        public const float DialogDepth = 0.2f;
        public static bool DrawMapVeil = true;
        public static bool DrawTroopAnimation = true;
        public static long FactionRunningTicksLimitInOneFrame = 0x186a0;
        public static int FastBattleSpeed = 1;
        public const float FloatingPartDepth = 0.25f;
        public const float FrameContentDepth = 0.35f;
        public const float FrontTileAnimationLayerDepth = 0.65f;
        public static int GameDifficulty;
        public const float GameFrameDepth = 0.4f;
        public static bool HintPopulation = true;
        public static bool HintPopulationUnder1000 = true;
        public static bool IdealTendencyValid = true;
        public const float LayerDepthOffset = -0.01f;
        public static bool LoadBackGroundMapTexture = false;
        public const float MapLayerDepth = 0.9f;
        public static float MapScrollSpeed;
        public const float MapVeilLayerDepth = 0.6f;
        public const float MapViewSelectorDepth = 0.18f;
        public static int MaxCountOfKnownPaths = 0x3e8;
        public const float MaxDepth = 1f;
        public static int MaxTimeOfAnimationFrame = 0x19;
        public static bool MilitaryKindSpeedValid = true;
        public const float MinDepth = 0f;
        public const float MinDepthOffset = -1E-06f;
        public const float MovableControlDepthOffset = -0.0002f;
        public static bool MultipleResource = false;
        public static bool NoHintOnSmallFacility = true;
        public const float PersonBubbleDepth = 0.45f;
        public static bool PersonNaturalDeath = true;
        public static bool PlayBattleSound = true;
        public static bool PlayerPersonAvailable = true;
        public static bool PlayMusic = true;
        public static bool PlayNormalSound = true;
        public static bool PopulationRecruitmentLimit = true;
        public static InformationLevel RoutewayInformationLevel = InformationLevel.低;
        public const float RoutewayLayerDepth = 0.85f;
        public static bool RunWhileNotFocused = true;
        public static InformationLevel ScoutRoutewayInformationLevel = InformationLevel.高;
        public const float ScreenBlindDepth = 0.43f;
        public const float SelectingLayerDepth = 0.5f;
        public const float SelectorDepth = 0.72f;
        public static bool SingleSelectionOneClick = true;
        public static bool SkyEye = false;
        public const float SurveyDepth = 0.05f;
        public const float TextDepthOffset = -0.0001f;
        public const float ToolBarDepth = 0.1f;
        public const float TroopLayerDepth = 0.7f;
        public static int TroopMoveFrameCount = 10;
        public static int TroopMoveLimitOnce = 5;
        public static int TroopMoveSpeed = 2;
        public const float TroopTitleDepth = 0.47f;

        public static bool PinPointAtPlayer = false;
        public static bool IgnoreStrategyTendency = false;
        public static bool createChildren = true;
        public static int zainanfashengjilv = 3000;
        public static bool doAutoSave = true;
        public static bool createChildrenIgnoreLimit = true;
        public static bool internalSurplusRateForPlayer = true;
        public static bool internalSurplusRateForAI = false;

        public static int getChildrenRate = 90;
        public static int hougongGetChildrenRate = 90;
        public static int getRaisedSoliderRate = 90;
        public static int AIExecutionRate = 500;

        public static bool AIExecuteBetterOfficer = false;
        public static int maxExperience = 10000;

        public static bool lockChildrenLoyalty = true;

        public static bool AIAutoTakeNoFactionCaptives = false;
        public static bool AIAutoTakeNoFactionPerson = false;
        public static bool AIAutoTakePlayerCaptives = false;
        public static bool AIAutoTakePlayerCaptiveOnlyUnfull = false;

        public static float TechniquePointMultiple = 1.0f;
        public static bool PermitFactionMerge = true;

        public static float LeadershipOffenceRate = 0.0f;

        public static int DialogShowTime = 10;

        public static bool AINoTeamTransfer = false;

        public static bool LandArmyCanGoDownWater = true;

        public static bool EnableResposiveThreading = false;

        public static bool EnableCheat = false;
        public static bool HardcoreMode = false;

        public static int MaxAbility = 150;
        public static int TirednessIncrease = 1;
        public static int TirednessDecrease = 1;

        public static bool EnableAgeAbilityFactor = true;
        public static int TabListDetailLevel = 3;
        public static bool EnableExtensions = true;
        public static bool EncryptSave = false;

        public static int AutoSaveFrequency = 30;
        public static bool ShowChallengeAnimation = true;
        public static bool PersonDieInChallenge = true;
        
        public static int OfficerDieInBattleRate = 10;
        public static int OfficerChildrenLimit = 20;
        public static bool StopToControlOnAttack = true;

        public static int MaxMilitaryExperience = 3000;
        public static float ArmyPopulationCap = 1.0f; //兵力上限 

        public static float CreateRandomOfficerChance = 5;
        
        public static int ChildrenAvailableAge = 12;

        public static float CreatedOfficerAbilityFactor = 0.8f;
        public static bool EnablePersonRelations = true;

        public static int FriendlyDiplomacyThreshold = 300;
        public static int SurroundFactor = 5;

        public static bool FullScreen = false;

        public static bool PermitQuanXiang = true;

        public static bool PermitManualAwardTitleAutoLearn = false;

        public const string cryptKey = "A3g0c3%2";

        public static List<String> getFieldsExcludedFromSave()
        {
            List<String> s = new List<string>();
            s.Add("MapScrollSpeed");
            s.Add("TroopMoveSpeed");
            s.Add("RunWhileNotFocused");
            s.Add("PlayMusic");
            s.Add("PlayNormalSound");
            s.Add("PlayBattleSound");
            s.Add("DrawMapVeil");
            s.Add("DrawTroopAnimation");
            s.Add("SingleSelectionOneClick");
            s.Add("NoHintOnSmallFacility");
            s.Add("HintPopulation");
            s.Add("HintPopulationUnder1000");
            s.Add("doAutoSave");
            s.Add("DialogShowTime");
            s.Add("FastBattleSpeed");
            s.Add("AutoSaveFrequency");
            s.Add("ShowChallengeAnimation");
            s.Add("StopToControlOnAttack");

            return s;
        }

        public bool InitialGlobalVariables()
        {
            Exception exception;
            XmlDocument document = new XmlDocument();
            document.Load("GameData/GlobalVariables.xml");
            XmlNode nextSibling = document.FirstChild.NextSibling;
            try
            {
                MapScrollSpeed = float.Parse(nextSibling.Attributes.GetNamedItem("MapScrollSpeed").Value);
            }
            catch (Exception exception1)
            {
                exception = exception1;
                throw new Exception("MapScrollSpeed:\n" + exception.ToString());
            }
            try
            {
                TroopMoveSpeed = int.Parse(nextSibling.Attributes.GetNamedItem("TroopMoveSpeed").Value);
            }
            catch (Exception exception2)
            {
                exception = exception2;
                throw new Exception("TroopMoveSpeed:\n" + exception.ToString());
            }
            try
            {
                RunWhileNotFocused = bool.Parse(nextSibling.Attributes.GetNamedItem("RunWhileNotFocused").Value);
            }
            catch (Exception exception3)
            {
                exception = exception3;
                throw new Exception("RunWhileNotFocused:\n" + exception.ToString());
            }
            try
            {
                PlayMusic = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayMusic").Value);
            }
            catch (Exception exception4)
            {
                exception = exception4;
                throw new Exception("PlayMusic:\n" + exception.ToString());
            }
            try
            {
                PlayNormalSound = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayNormalSound").Value);
            }
            catch (Exception exception5)
            {
                exception = exception5;
                throw new Exception("PlayNormalSound:\n" + exception.ToString());
            }
            try
            {
                PlayBattleSound = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayBattleSound").Value);
            }
            catch (Exception exception6)
            {
                exception = exception6;
                throw new Exception("PlayBattleSound:\n" + exception.ToString());
            }
            try
            {
                DrawMapVeil = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawMapVeil").Value);
            }
            catch (Exception exception7)
            {
                exception = exception7;
                throw new Exception("DrawMapVeil:\n" + exception.ToString());
            }
            try
            {
                DrawTroopAnimation = bool.Parse(nextSibling.Attributes.GetNamedItem("DrawTroopAnimation").Value);
            }
            catch (Exception exception8)
            {
                exception = exception8;
                throw new Exception("DrawTroopAnimation:\n" + exception.ToString());
            }
            try
            {
                SkyEye = bool.Parse(nextSibling.Attributes.GetNamedItem("SkyEye").Value);
            }
            catch (Exception exception9)
            {
                exception = exception9;
                throw new Exception("SkyEye:\n" + exception.ToString());
            }
            try
            {
                MultipleResource = bool.Parse(nextSibling.Attributes.GetNamedItem("MultipleResource").Value);
            }
            catch (Exception exception10)
            {
                exception = exception10;
                throw new Exception("MultipleResource:\n" + exception.ToString());
            }
            try
            {
                SingleSelectionOneClick = bool.Parse(nextSibling.Attributes.GetNamedItem("SingleSelectionOneClick").Value);
            }
            catch (Exception exception11)
            {
                exception = exception11;
                throw new Exception("SingleSelectionOneClick:\n" + exception.ToString());
            }
            try
            {
                NoHintOnSmallFacility = bool.Parse(nextSibling.Attributes.GetNamedItem("NoHintOnSmallFacility").Value);
            }
            catch (Exception exception12)
            {
                exception = exception12;
                throw new Exception("NoHintOnSmallFacility:\n" + exception.ToString());
            }
            try
            {
                HintPopulation = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulation").Value);
            }
            catch (Exception exception13)
            {
                exception = exception13;
                throw new Exception("HintPopulation:\n" + exception.ToString());
            }
            try
            {
                HintPopulationUnder1000 = bool.Parse(nextSibling.Attributes.GetNamedItem("HintPopulationUnder1000").Value);
            }
            catch (Exception exception14)
            {
                exception = exception14;
                throw new Exception("HintPopulationUnder1000:\n" + exception.ToString());
            }
            try
            {
                PopulationRecruitmentLimit = bool.Parse(nextSibling.Attributes.GetNamedItem("PopulationRecruitmentLimit").Value);
            }
            catch (Exception exception15)
            {
                exception = exception15;
                throw new Exception("PopulationRecruitmentLimit:\n" + exception.ToString());
            }
            try
            {
                MilitaryKindSpeedValid = bool.Parse(nextSibling.Attributes.GetNamedItem("MilitaryKindSpeedValid").Value);
            }
            catch (Exception exception16)
            {
                exception = exception16;
                throw new Exception("MilitaryKindSpeedValid:\n" + exception.ToString());
            }
            try
            {
                CommonPersonAvailable = bool.Parse(nextSibling.Attributes.GetNamedItem("CommonPersonAvailable").Value);
            }
            catch (Exception exception17)
            {
                exception = exception17;
                throw new Exception("CommonPersonAvailable:\n" + exception.ToString());
            }
            try
            {
                AdditionalPersonAvailable = bool.Parse(nextSibling.Attributes.GetNamedItem("AdditionalPersonAvailable").Value);
            }
            catch (Exception exception18)
            {
                exception = exception18;
                throw new Exception("AdditionalPersonAvailable:\n" + exception.ToString());
            }
            try
            {
                PlayerPersonAvailable = bool.Parse(nextSibling.Attributes.GetNamedItem("PlayerPersonAvailable").Value);
            }
            catch (Exception exception19)
            {
                exception = exception19;
                throw new Exception("PlayerPersonAvailable:\n" + exception.ToString());
            }
            try
            {
                PersonNaturalDeath = bool.Parse(nextSibling.Attributes.GetNamedItem("PersonNaturalDeath").Value);
            }
            catch (Exception exception20)
            {
                exception = exception20;
                throw new Exception("PersonNaturalDeath:\n" + exception.ToString());
            }
            try
            {
                IdealTendencyValid = bool.Parse(nextSibling.Attributes.GetNamedItem("IdealTendencyValid").Value);
            }
            catch (Exception exception21)
            {
                exception = exception21;
                throw new Exception("IdealTendencyValid:\n" + exception.ToString());
            }
            try
            {
                PinPointAtPlayer = bool.Parse(nextSibling.Attributes.GetNamedItem("PinPointAtPlayer").Value);
            }
            catch (Exception exception22)
            {
                exception = exception22;
                throw new Exception("PinPointAtPlayer:\n" + exception.ToString());
            }
            try
            {
                IgnoreStrategyTendency = bool.Parse(nextSibling.Attributes.GetNamedItem("IgnoreStrategyTendency").Value);
            }
            catch (Exception exception23)
            {
                exception = exception23;
                throw new Exception("IgnoreStrategyTendency:\n" + exception.ToString());
            }
            try
            {
                createChildren = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildren").Value);
            }
            catch (Exception exception23)
            {
                exception = exception23;
                throw new Exception("createChildren:\n" + exception.ToString());
            }
            try
            {
                zainanfashengjilv = int.Parse(nextSibling.Attributes.GetNamedItem("zainanfashengjilv").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("zainanfashengjilv:\n" + exception.ToString());
            }
            try
            {
                doAutoSave = bool.Parse(nextSibling.Attributes.GetNamedItem("doAutoSave").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("doAutoSave:\n" + exception.ToString());
            }
            try
            {
                createChildrenIgnoreLimit = bool.Parse(nextSibling.Attributes.GetNamedItem("createChildrenIgnoreLimit").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("createChildrenIgnoreLimit:\n" + exception.ToString());
            }
            try
            {
                internalSurplusRateForPlayer = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForPlayer").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("internalSurplusRateForPlayer:\n" + exception.ToString());
            }
            try
            {
                internalSurplusRateForAI = bool.Parse(nextSibling.Attributes.GetNamedItem("internalSurplusRateForAI").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("internalSurplusRateForAI:\n" + exception.ToString());
            }
            try
            {
                getChildrenRate = int.Parse(nextSibling.Attributes.GetNamedItem("getChildrenRate").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("getChildrenRate:\n" + exception.ToString());
            }
            try
            {
                hougongGetChildrenRate = int.Parse(nextSibling.Attributes.GetNamedItem("hougongGetChildrenRate").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("hougongGetChildrenRate:\n" + exception.ToString());
            }
            try
            {
                AIExecutionRate = int.Parse(nextSibling.Attributes.GetNamedItem("AIExecutionRate").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIExecutionRate:\n" + exception.ToString());
            }
            try
            {
                AIExecuteBetterOfficer = bool.Parse(nextSibling.Attributes.GetNamedItem("AIExecuteBetterOfficer").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIExecuteBetterOfficer:\n" + exception.ToString());
            }
            try
            {
                maxExperience = int.Parse(nextSibling.Attributes.GetNamedItem("maxExperience").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("maxExperience:\n" + exception.ToString());
            }
            try
            {
                lockChildrenLoyalty = bool.Parse(nextSibling.Attributes.GetNamedItem("lockChildrenLoyalty").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("lockChildrenLoyalty:\n" + exception.ToString());
            }
            try
            {
                AIAutoTakeNoFactionCaptives = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionCaptives").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIAutoTakeNoFactionCaptives:\n" + exception.ToString());
            }
            try
            {
                AIAutoTakeNoFactionPerson = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakeNoFactionPerson").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIAutoTakeNoFactionPerson:\n" + exception.ToString());
            }
            try
            {
                AIAutoTakePlayerCaptives = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptives").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIAutoTakePlayerCaptives:\n" + exception.ToString());
            }
            try
            {
                AIAutoTakePlayerCaptiveOnlyUnfull = bool.Parse(nextSibling.Attributes.GetNamedItem("AIAutoTakePlayerCaptiveOnlyUnfull").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AIAutoTakePlayerCaptiveOnlyUnfull:\n" + exception.ToString());
            }
            try
            {
                DialogShowTime = int.Parse(nextSibling.Attributes.GetNamedItem("DialogShowTime").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("DialogShowTime:\n" + exception.ToString());
            }
            try
            {
                TechniquePointMultiple = float.Parse(nextSibling.Attributes.GetNamedItem("TechniquePointMultiple").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("TechniquePointMultiple:\n" + exception.ToString());
            }
            try
            {
                PermitFactionMerge = bool.Parse(nextSibling.Attributes.GetNamedItem("PermitFactionMerge").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("PermitFactionMerge:\n" + exception.ToString());
            }
            try
            {
                LeadershipOffenceRate = float.Parse(nextSibling.Attributes.GetNamedItem("LeadershipOffenceRate").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("LeadershipOffenceRate:\n" + exception.ToString());
            }
            try
            {
                LiangdaoXitong  = bool.Parse(nextSibling.Attributes.GetNamedItem("LiangdaoXitong").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("LiangdaoXitong:\n" + exception.ToString());
            }
            try
            {
                WujiangYoukenengDuli = bool.Parse(nextSibling.Attributes.GetNamedItem("WujiangYoukenengDuli").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("WujiangYoukenengDuli:\n" + exception.ToString());
            }
            try
            {
                FastBattleSpeed = int.Parse(nextSibling.Attributes.GetNamedItem("FastBattleSpeed").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("FastBattleSpeed:\n" + exception.ToString());
            }
            try
            {
                AINoTeamTransfer = bool.Parse(nextSibling.Attributes.GetNamedItem("AINoTeamTransfer").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AINoTeamTransfer:\n" + exception.ToString());
            }
            try
            {
                EnableCheat = bool.Parse(nextSibling.Attributes.GetNamedItem("EnableCheat").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("EnableCheat:\n" + exception.ToString());
            }
            try
            {
                HardcoreMode = bool.Parse(nextSibling.Attributes.GetNamedItem("HardcoreMode").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("HardcoreMode:\n" + exception.ToString());
            }
            try
            {
                LandArmyCanGoDownWater = bool.Parse(nextSibling.Attributes.GetNamedItem("LandArmyCanGoDownWater").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("LandArmyCanGoDownWater:\n" + exception.ToString());
            }
            try
            {
                MaxAbility = int.Parse(nextSibling.Attributes.GetNamedItem("MaxAbility").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("MaxAbility:\n" + exception.ToString());
            }
            try
            {
                TirednessIncrease = int.Parse(nextSibling.Attributes.GetNamedItem("TirednessIncrease").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("TirednessIncrease:\n" + exception.ToString());
            }
            try
            {
                TirednessDecrease = int.Parse(nextSibling.Attributes.GetNamedItem("TirednessDecrease").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("TirednessDecrease:\n" + exception.ToString());
            }
            try
            {
                EnableAgeAbilityFactor = bool.Parse(nextSibling.Attributes.GetNamedItem("EnableAgeAbilityFactor").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("EnableAgeAbilityFactor:\n" + exception.ToString());
            }
            try
            {
                TabListDetailLevel = int.Parse(nextSibling.Attributes.GetNamedItem("TabListDetailLevel").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("TabListDetailLevel:\n" + exception.ToString());
            }
            try
            {
                EnableExtensions = bool.Parse(nextSibling.Attributes.GetNamedItem("EnableExtensions").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("EnableExtensions:\n" + exception.ToString());
            }
            try
            {
                EncryptSave = bool.Parse(nextSibling.Attributes.GetNamedItem("EncryptSave").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("EncryptSave:\n" + exception.ToString());
            }
            try
            {
                AutoSaveFrequency = int.Parse(nextSibling.Attributes.GetNamedItem("AutoSaveFrequency").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("AutoSaveFrequency:\n" + exception.ToString());
            }
            try
            {
                ShowChallengeAnimation = bool.Parse(nextSibling.Attributes.GetNamedItem("ShowChallengeAnimation").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("ShowChallengeAnimation:\n" + exception.ToString());
            }
            try
            {
                PersonDieInChallenge = bool.Parse(nextSibling.Attributes.GetNamedItem("PersonDieInChallenge").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("PersonDieInChallenge:\n" + exception.ToString());
            }
            try
            {
                OfficerDieInBattleRate = int.Parse(nextSibling.Attributes.GetNamedItem("OfficerDieInBattleRate").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("OfficerDieInBattleRate:\n" + exception.ToString());
            }
            try
            {
                OfficerChildrenLimit = int.Parse(nextSibling.Attributes.GetNamedItem("OfficerChildrenLimit").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("OfficerChildrenLimit:\n" + exception.ToString());
            }
            try
            {
                StopToControlOnAttack = bool.Parse(nextSibling.Attributes.GetNamedItem("StopToControlOnAttack").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("StopToControlOnAttack:\n" + exception.ToString());
            }
            try
            {
                MaxMilitaryExperience = int.Parse(nextSibling.Attributes.GetNamedItem("MaxMilitaryExperience").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("MaxMilitaryExperience:\n" + exception.ToString());
            }
            try
            {
                CreateRandomOfficerChance = float.Parse(nextSibling.Attributes.GetNamedItem("CreateRandomOfficerChance").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("CreateRandomOfficerChance:\n" + exception.ToString());
            }
            
            try
            {
                CreatedOfficerAbilityFactor = float.Parse(nextSibling.Attributes.GetNamedItem("CreatedOfficerAbilityFactor").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("CreatedOfficerAbilityFactor:\n" + exception.ToString());
            }
            try
            {
                EnablePersonRelations = bool.Parse(nextSibling.Attributes.GetNamedItem("EnablePersonRelations").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("EnablePersonRelations:\n" + exception.ToString());
            }
            try
            {
                ChildrenAvailableAge = int.Parse(nextSibling.Attributes.GetNamedItem("ChildrenAvailableAge").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("ChildrenAvailableAge:\n" + exception.ToString());
            }
            try
            {
                FullScreen = bool.Parse(nextSibling.Attributes.GetNamedItem("FullScreen").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("FullScreen:\n" + exception.ToString());
            }
            try
            {
                FriendlyDiplomacyThreshold = int.Parse(nextSibling.Attributes.GetNamedItem("FriendlyDiplomacyThreshold").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("FriendlyDiplomacyThreshold:\n" + exception.ToString());
            }
            try
            {
                SurroundFactor = int.Parse(nextSibling.Attributes.GetNamedItem("SurroundFactor").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("SurroundFactor:\n" + exception.ToString());
            }
            try
            {
                ArmyPopulationCap = float.Parse(nextSibling.Attributes.GetNamedItem("ArmyPopulationCap").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("ArmyPopulationCap:\n" + exception.ToString());
            }
            try 
            {
                PermitQuanXiang = bool.Parse(nextSibling.Attributes.GetNamedItem("PermitQuanXiang").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("PermitQuanXiang:\n" + exception.ToString());
            }
            try
            {
                PermitManualAwardTitleAutoLearn = bool.Parse(nextSibling.Attributes.GetNamedItem("PermitManualAwardTitleAutoLearn").Value);
            }
            catch (Exception exception24)
            {
                exception = exception24;
                throw new Exception("PermitManualAwardTitleAutoLearn:\n" + exception.ToString());
            }
            return true;
        }
    }
}

