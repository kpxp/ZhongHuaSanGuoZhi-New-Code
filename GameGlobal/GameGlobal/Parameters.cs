namespace GameGlobal
{
    using System;
    using System.Xml;
    using System.Collections.Generic;

    public class Parameters
    {
        public static float AIArchitectureDamageRate = 1f;
        public static float AIFoodRate = 1f;
        public static float AIFundRate = 1f;
        public static float AIRecruitmentSpeedRate = 1f;
        public static float AITrainingSpeedRate = 1f;
        public static float AITroopDefenceRate = 1f;
        public static float AITroopOffenceRate = 1f;
        public static float ArchitectureDamageRate = 1f;
        public static int AIAntiStratagem = 0;
        public static int AIAntiSurround = 0;

        public static int BuyFoodAgriculture = 500;
        public static int ChangeCapitalCost = 0x1388;
        public static int ClearFieldAgricultureCostUnit = 3;
        public static int ClearFieldFundCostUnit = 50;
        public static int ConvincePersonCost = 200;
        public static float DefaultPopulationDevelopingRate = 6E-05f;
        public static int DestroyArchitectureCost = 200;
        public static int FindTreasureChance = 10;
        public static float FireDamageScale = 0.5f;
        public static float FollowedLeaderDefenceRateIncrement = 0.2f;
        public static float FollowedLeaderOffenceRateIncrement = 0.2f;
        public static float FoodRate = 1f;
        public static int FoodToFundDivisor = 200;
        public static float FundRate = 1f;
        public static int FundToFoodMultiple = 50;
        public static int GossipArchitectureCost = 200;
        public static int JailBreakArchitectureCost = 200;
        public static int HireNoFactionPersonCost = 100;
        public static int InstigateArchitectureCost = 200;
        public static int InternalFundCost = 5;
        public static float InternalRate = 1f;
        public static int LearnSkillDays = 30;
        public static int LearnStuntDays = 60;
        public static int LearnTitleDays = 90;
        public static int SearchDays = 10;
        public static int RecruitmentDomination = 50;
        public static int RecruitmentFundCost = 20;
        public static int RecruitmentMorale = 100;
        public static float RecruitmentRate = 1f;
        public static int RewardPersonCost = 100;
        public static int SellFoodCommerce = 500;
        public static int SendSpyCost = 200;
        public static int SurroundArchitectureDominationUnit = 2;
        public static float TrainingRate = 1f;
        public static float TroopDamageRate = 1f;

        public static float AIArchitectureDamageYearIncreaseRate = 0f;
        public static float AIFoodYearIncreaseRate = 0f;
        public static float AIFundYearIncreaseRate = 0f;
        public static float AIRecruitmentSpeedYearIncreaseRate = 0f;
        public static float AITrainingSpeedYearIncreaseRate = 0f;
        public static float AITroopDefenceYearIncreaseRate = 0f;
        public static float AITroopOffenceYearIncreaseRate = 0f;
        public static float AIArmyExperienceYearIncreaseRate = 0f;
        public static float AIOfficerExperienceYearIncreaseRate = 0f;
        public static float AIAntiStratagemIncreaseRate = 0f;
        public static float AIAntiSurroundIncreaseRate = 0f;

        public static float AIOfficerExperienceRate = 1f;
        public static float AIArmyExperienceRate = 1f;

        private static float BasicAIArchitectureDamageRate = 1f;
        private static float BasicAIFoodRate = 1f;
        private static float BasicAIFundRate = 1f;
        private static float BasicAIRecruitmentSpeedRate = 1f;
        private static float BasicAITrainingSpeedRate = 1f;
        private static float BasicAITroopDefenceRate = 1f;
        private static float BasicAITroopOffenceRate = 1f;
        private static float BasicAIArmyExperienceRate = 1f;
        private static float BasicAIOfficerExperienceRate = 1f;
        private static int BasicAIAntiStratagem = 0;
        private static int BasicAIAntiSurround = 0;

        public static float AIBackendArmyReserveCalmBraveDifferenceMultiply = 5;
        public static float AIBackendArmyReserveAmbitionMultiply = 10;
        public static float AIBackendArmyReserveAdd = 50;
        public static float AIBackendArmyReserveMultiply = 1;
        public static int AITradePeriod = 10;
        public static int AITreasureChance = 10;
        public static int AITreasureCountMax = 2;
        public static float AITreasureCountCappedTitleLevelAdd = 0;
        public static float AITreasureCountCappedTitleLevelMultiply = 1;
        public static int AIGiveTreasureMaxWorth = 40;
        public static float AIFacilityFundMonthWaitParam = 8;
        public static float AIFacilityDestroyValueRate = 2;
        public static float AIBuildHougongUnambitionProbWeight = 10;
        public static float AIBuildHougongSpaceBuiltProbWeight = 5;
        public static int AIBuildHougongMaxSizeAdd = 0;
        public static int AIBuildHougongSkipSizeChance = 80;
        public static int AINafeiUncreultyProbAdd = -1;
        public static float AINafeiAbilityThresholdRate = 30000;
        public static float AINafeiStealSpouseThresholdRateAdd = 0.5f;
        public static float AINafeiStealSpouseThresholdRateMultiply = 1;
        public static int AINafeiMaxAgeThresholdAdd = 30;
        public static float AINafeiMaxAgeThresholdMultiply = 1;
        public static float AINafeiSkipChanceAdd = 25;
        public static float AINafeiSkipChanceMultiply = 15;
        public static float AIChongxingChanceAdd = 10;
        public static float AIChongxingChanceMultiply = 20;
        public static float AIRecruitPopulationCapMultiply = 90;
        public static float AIRecruitPopulationCapBackendMultiply = 0.5f;
        public static float AIRecruitPopulationCapHostilelineMultiply = 1.2f;
        public static float AIRecruitPopulationCapStrategyTendencyMulitply = 0.2f;
        public static float AIRecruitPopulationCapStrategyTendencyAdd = 0.2f;
        public static int AINewMilitaryPopulationThresholdDivide = 30000;
        public static int AINewMilitaryPersonThresholdDivide = 5;
        public static int AIExecuteMaxUncreulty = 4;
        public static float AIExecutePersonIdealToleranceMultiply = 15;

        public static float AIHougongArchitectureCountProbMultiply = 10;
        public static float AIHougongArchitectureCountProbPower = 0.5f;

        public static int FireStayProb = 20;
        public static float FireSpreadProbMultiply = 1f;

        public static int MinPregnantProb = 0;

        public static float InternalExperienceRate = 1f;
        public static float AbilityExperienceRate = 1f;
        public static float ArmyExperienceRate = 1f;

        public static float AIAttackChanceIfUnfull = 5;
        public static int AIObeyStrategyTendencyChance = 90;
        public static int AIOffendMaxDiplomaticRelationMultiply = 20;
        public static float AIOffendReserveAdd = 0.8f;
        public static float AIOffendReserveBCDiffMultiply = 0.1f;
        public static float AIOffendDefendingTroopRate = 0.75f;
        public static float AIOffendDefendTroopAdd = 1.2f;
        public static float AIOffendDefendTroopMultiply = 0.1f;
        public static int AIOffendIgnoreReserveProbAmbitionMultiply = 5;
        public static int AIOffendIgnoreReserveProbAmbitionAdd = -2;
        public static int AIOffendIgnoreReserveProbBCDiffMultiply = 2;
        public static int AIOffendIgnoreReserveProbBCDiffAdd = 10;
        public static float AIOffendIgnoreReserveChanceTroopRatioAdd = -0.8f;
        public static float AIOffendIgnoreReserveChanceTroopRatioMultiply = 100.0f;

        public static int PrincessMaintainenceCost = 50;

        public static int AIUniqueTroopFightingForceThreshold = 60000;
        public static int LearnSkillSuccessRate = 0;
        public static int LearnStuntSuccessRate = 75;
        public static int LearnTitleSuccessRate = 0;

        public static int AutoLearnSkillSuccessRate = 0;
        public static int AutoLearnStuntSuccessRate = 0;

        public static float MilitaryPopulationCap = 0.1f;
        public static float MilitaryPopulationReloadQuantity = 1.0f;

        public static int CloseThreshold = 500;
        public static int HateThreshold = -500;
        public static int VeryCloseThreshold = 2000;

        public static int MaxAITroopCountCandidates = 1000;
        public static float PopulationDevelopingRate = 1;

        public static float CloseAbilityRate = 1.1F;
        public static float VeryCloseAbilityRate = 1.2F;

        public static int RetainFeiziPersonalLoyalty = 0;
        public static int AIEncirclePlayerRate = 0;
        public static float BasicAIExtraPerson = 0;
        public static float AIExtraPerson = 0;
        public static float AIExtraPersonIncreaseRate = 0;
        public static int AITirednessDecrease = 0;

        public static int InternalSurplusFactor = 10000000;

        public static int MakeMarrigeIdealLimit = 5;
        public static int MakeMarriageCost = 80000;
        public static int NafeiCost = 50000;
        public static int SelectPrinceCost = 50000;

        public static int TransferCostPerMilitary = 2000;
        public static int TransferFoodPerMilitary = 2000;

        public static int AIEncircleRank = 0;
        public static int AIEncircleVar = 0;

        public static List<int> ExpandConditions = new List<int>();

        public static float SearchPersonArchitectureCountPower = 0;

        public void InitializeGameParameters()
        {
            XmlDocument document = new XmlDocument();
            document.Load("GameData/GameParameters.xml");
            XmlNode nextSibling = document.FirstChild.NextSibling;
            FindTreasureChance = int.Parse(nextSibling.Attributes.GetNamedItem("FindTreasureChance").Value);
            LearnSkillDays = int.Parse(nextSibling.Attributes.GetNamedItem("LearnSkillDays").Value);
            LearnStuntDays = int.Parse(nextSibling.Attributes.GetNamedItem("LearnStuntDays").Value);
            LearnTitleDays = int.Parse(nextSibling.Attributes.GetNamedItem("LearnTitleDays").Value);
            SearchDays = int.Parse(nextSibling.Attributes.GetNamedItem("SearchDays").Value);
            FollowedLeaderOffenceRateIncrement = float.Parse(nextSibling.Attributes.GetNamedItem("FollowedLeaderOffenceRateIncrement").Value);
            FollowedLeaderDefenceRateIncrement = float.Parse(nextSibling.Attributes.GetNamedItem("FollowedLeaderDefenceRateIncrement").Value);
            InternalRate = float.Parse(nextSibling.Attributes.GetNamedItem("InternalRate").Value);
            TrainingRate = float.Parse(nextSibling.Attributes.GetNamedItem("TrainingRate").Value);
            RecruitmentRate = float.Parse(nextSibling.Attributes.GetNamedItem("RecruitmentRate").Value);
            FundRate = float.Parse(nextSibling.Attributes.GetNamedItem("FundRate").Value);
            FoodRate = float.Parse(nextSibling.Attributes.GetNamedItem("FoodRate").Value);
            TroopDamageRate = float.Parse(nextSibling.Attributes.GetNamedItem("TroopDamageRate").Value);
            ArchitectureDamageRate = float.Parse(nextSibling.Attributes.GetNamedItem("ArchitectureDamageRate").Value);
            DefaultPopulationDevelopingRate = float.Parse(nextSibling.Attributes.GetNamedItem("DefaultPopulationDevelopingRate").Value);
            BuyFoodAgriculture = int.Parse(nextSibling.Attributes.GetNamedItem("BuyFoodAgriculture").Value);
            SellFoodCommerce = int.Parse(nextSibling.Attributes.GetNamedItem("SellFoodCommerce").Value);
            FundToFoodMultiple = int.Parse(nextSibling.Attributes.GetNamedItem("FundToFoodMultiple").Value);
            FoodToFundDivisor = int.Parse(nextSibling.Attributes.GetNamedItem("FoodToFundDivisor").Value);
            InternalFundCost = int.Parse(nextSibling.Attributes.GetNamedItem("InternalFundCost").Value);
            RecruitmentFundCost = int.Parse(nextSibling.Attributes.GetNamedItem("RecruitmentFundCost").Value);
            RecruitmentDomination = int.Parse(nextSibling.Attributes.GetNamedItem("RecruitmentDomination").Value);
            RecruitmentMorale = int.Parse(nextSibling.Attributes.GetNamedItem("RecruitmentMorale").Value);
            ChangeCapitalCost = int.Parse(nextSibling.Attributes.GetNamedItem("ChangeCapitalCost").Value);
            SelectPrinceCost = int.Parse(nextSibling.Attributes.GetNamedItem("SelectPrinceCost").Value);
            TransferCostPerMilitary = int.Parse(nextSibling.Attributes.GetNamedItem("TransferCostPerMilitary").Value); //运兵耗钱
            TransferFoodPerMilitary = int.Parse(nextSibling.Attributes.GetNamedItem("TransferFoodPerMilitary").Value);  //运兵耗粮
            HireNoFactionPersonCost = int.Parse(nextSibling.Attributes.GetNamedItem("HireNoFactionPersonCost").Value);
            ConvincePersonCost = int.Parse(nextSibling.Attributes.GetNamedItem("ConvincePersonCost").Value);
            RewardPersonCost = int.Parse(nextSibling.Attributes.GetNamedItem("RewardPersonCost").Value);
            SendSpyCost = int.Parse(nextSibling.Attributes.GetNamedItem("SendSpyCost").Value);
            DestroyArchitectureCost = int.Parse(nextSibling.Attributes.GetNamedItem("DestroyArchitectureCost").Value);
            InstigateArchitectureCost = int.Parse(nextSibling.Attributes.GetNamedItem("InstigateArchitectureCost").Value);
            GossipArchitectureCost = int.Parse(nextSibling.Attributes.GetNamedItem("GossipArchitectureCost").Value);
            JailBreakArchitectureCost = int.Parse(nextSibling.Attributes.GetNamedItem("JailBreakArchitectureCost").Value);
            ClearFieldFundCostUnit = int.Parse(nextSibling.Attributes.GetNamedItem("ClearFieldFundCostUnit").Value);
            ClearFieldAgricultureCostUnit = int.Parse(nextSibling.Attributes.GetNamedItem("ClearFieldAgricultureCostUnit").Value);
            SurroundArchitectureDominationUnit = int.Parse(nextSibling.Attributes.GetNamedItem("SurroundArchitectureDominationUnit").Value);
            FireDamageScale = float.Parse(nextSibling.Attributes.GetNamedItem("FireDamageScale").Value);
            AIFundRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIFundRate").Value);
            AIFoodRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIFoodRate").Value);
            AITroopOffenceRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITroopOffenceRate").Value);
            AITroopDefenceRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITroopDefenceRate").Value);
            AIArchitectureDamageRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIArchitectureDamageRate").Value);
            AITrainingSpeedRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITrainingSpeedRate").Value);
            AIRecruitmentSpeedRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedRate").Value);
            AIOfficerExperienceRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIOfficerExperienceRate").Value);
            AIArmyExperienceRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIArmyExperienceRate").Value);
            AIAntiStratagem = int.Parse(nextSibling.Attributes.GetNamedItem("AIAntiStratagem").Value);
            AIAntiSurround = int.Parse(nextSibling.Attributes.GetNamedItem("AIAntiSurround").Value);

            AIFundYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIFundYearIncreaseRate").Value);
            AIFoodYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIFoodYearIncreaseRate").Value);
            AITroopOffenceYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITroopOffenceYearIncreaseRate").Value);
            AITroopDefenceYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITroopDefenceYearIncreaseRate").Value);
            AIArchitectureDamageYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIArchitectureDamageYearIncreaseRate").Value);
            AITrainingSpeedYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AITrainingSpeedYearIncreaseRate").Value);
            AIRecruitmentSpeedYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitmentSpeedYearIncreaseRate").Value);
            AIOfficerExperienceYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIOfficerExperienceYearIncreaseRate").Value);
            AIArmyExperienceYearIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIArmyExperienceYearIncreaseRate").Value);
            AIAntiStratagemIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIAntiStratagemIncreaseRate").Value);
            AIAntiSurroundIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIAntiSurroundIncreaseRate").Value);

            AIBackendArmyReserveCalmBraveDifferenceMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIBackendArmyReserveCalmBraveDifferenceMultiply").Value);
            AIBackendArmyReserveAmbitionMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIBackendArmyReserveAmbitionMultiply").Value);
            AIBackendArmyReserveAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIBackendArmyReserveAdd").Value);
            AIBackendArmyReserveMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIBackendArmyReserveMultiply").Value);
            AITradePeriod = int.Parse(nextSibling.Attributes.GetNamedItem("AITradePeriod").Value);
            AITreasureChance = int.Parse(nextSibling.Attributes.GetNamedItem("AITreasureChance").Value);
            AITreasureCountMax = int.Parse(nextSibling.Attributes.GetNamedItem("AITreasureCountMax").Value);
            AITreasureCountCappedTitleLevelAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AITreasureCountCappedTitleLevelAdd").Value);
            AITreasureCountCappedTitleLevelMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AITreasureCountCappedTitleLevelMultiply").Value);
            AIGiveTreasureMaxWorth = int.Parse(nextSibling.Attributes.GetNamedItem("AIGiveTreasureMaxWorth").Value);
            AIFacilityFundMonthWaitParam = float.Parse(nextSibling.Attributes.GetNamedItem("AIFacilityFundMonthWaitParam").Value);
            AIFacilityDestroyValueRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIFacilityDestroyValueRate").Value);
            AIBuildHougongUnambitionProbWeight = float.Parse(nextSibling.Attributes.GetNamedItem("AIBuildHougongUnambitionProbWeight").Value);
            AIBuildHougongSpaceBuiltProbWeight = float.Parse(nextSibling.Attributes.GetNamedItem("AIBuildHougongSpaceBuiltProbWeight").Value);
            AIBuildHougongMaxSizeAdd = int.Parse(nextSibling.Attributes.GetNamedItem("AIBuildHougongMaxSizeAdd").Value);
            AIBuildHougongSkipSizeChance = int.Parse(nextSibling.Attributes.GetNamedItem("AIBuildHougongSkipSizeChance").Value);
            AINafeiUncreultyProbAdd = int.Parse(nextSibling.Attributes.GetNamedItem("AINafeiUncreultyProbAdd").Value);
            AINafeiAbilityThresholdRate = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiAbilityThresholdRate").Value);
            AINafeiStealSpouseThresholdRateAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiStealSpouseThresholdRateAdd").Value);
            AINafeiStealSpouseThresholdRateMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiStealSpouseThresholdRateMultiply").Value);
            AINafeiMaxAgeThresholdAdd = int.Parse(nextSibling.Attributes.GetNamedItem("AINafeiMaxAgeThresholdAdd").Value);
            AINafeiMaxAgeThresholdMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiMaxAgeThresholdMultiply").Value);
            AINafeiSkipChanceAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiSkipChanceAdd").Value);
            AINafeiSkipChanceMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AINafeiSkipChanceMultiply").Value);
            AIChongxingChanceAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIChongxingChanceAdd").Value);
            AIChongxingChanceMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIChongxingChanceMultiply").Value);
            AIRecruitPopulationCapMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitPopulationCapMultiply").Value);
            AIRecruitPopulationCapBackendMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitPopulationCapBackendMultiply").Value);
            AIRecruitPopulationCapHostilelineMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitPopulationCapHostilelineMultiply").Value);
            AIRecruitPopulationCapStrategyTendencyMulitply = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitPopulationCapStrategyTendencyMulitply").Value);
            AIRecruitPopulationCapStrategyTendencyAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIRecruitPopulationCapStrategyTendencyAdd").Value);
            AINewMilitaryPopulationThresholdDivide = int.Parse(nextSibling.Attributes.GetNamedItem("AINewMilitaryPopulationThresholdDivide").Value);
            AINewMilitaryPersonThresholdDivide = int.Parse(nextSibling.Attributes.GetNamedItem("AINewMilitaryPersonThresholdDivide").Value);
            AIExecuteMaxUncreulty = int.Parse(nextSibling.Attributes.GetNamedItem("AIExecuteMaxUncreulty").Value);
            AIExecutePersonIdealToleranceMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIExecutePersonIdealToleranceMultiply").Value);

            AIHougongArchitectureCountProbMultiply = int.Parse(nextSibling.Attributes.GetNamedItem("AIHougongArchitectureCountProbMultiply").Value);
            AIHougongArchitectureCountProbPower = float.Parse(nextSibling.Attributes.GetNamedItem("AIHougongArchitectureCountProbPower").Value);

            FireStayProb = int.Parse(nextSibling.Attributes.GetNamedItem("FireStayProb").Value);
            FireSpreadProbMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("FireSpreadProbMultiply").Value);

            MinPregnantProb = int.Parse(nextSibling.Attributes.GetNamedItem("MinPregnantProb").Value);

            InternalExperienceRate = float.Parse(nextSibling.Attributes.GetNamedItem("InternalExperienceRate").Value);
            AbilityExperienceRate = float.Parse(nextSibling.Attributes.GetNamedItem("AbilityExperienceRate").Value);
            ArmyExperienceRate = float.Parse(nextSibling.Attributes.GetNamedItem("ArmyExperienceRate").Value);

            AIAttackChanceIfUnfull = float.Parse(nextSibling.Attributes.GetNamedItem("AIAttackChanceIfUnfull").Value);
            AIObeyStrategyTendencyChance = int.Parse(nextSibling.Attributes.GetNamedItem("AIObeyStrategyTendencyChance").Value);
            AIOffendMaxDiplomaticRelationMultiply = int.Parse(nextSibling.Attributes.GetNamedItem("AIOffendMaxDiplomaticRelationMultiply").Value);
            AIOffendReserveAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendReserveAdd").Value);
            AIOffendReserveBCDiffMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendReserveBCDiffMultiply").Value);
            AIOffendDefendingTroopRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendDefendingTroopRate").Value);
            AIOffendDefendTroopAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendDefendTroopAdd").Value);
            AIOffendDefendTroopMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendDefendTroopMultiply").Value);
            AIOffendIgnoreReserveProbAmbitionMultiply = int.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveProbAmbitionMultiply").Value);
            AIOffendIgnoreReserveProbAmbitionAdd = int.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveProbAmbitionAdd").Value);
            AIOffendIgnoreReserveProbBCDiffMultiply = int.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveProbBCDiffMultiply").Value);
            AIOffendIgnoreReserveProbBCDiffAdd = int.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveProbBCDiffAdd").Value);
            AIOffendIgnoreReserveChanceTroopRatioAdd = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveChanceTroopRatioAdd").Value);
            AIOffendIgnoreReserveChanceTroopRatioMultiply = float.Parse(nextSibling.Attributes.GetNamedItem("AIOffendIgnoreReserveChanceTroopRatioMultiply").Value);
            PrincessMaintainenceCost = int.Parse(nextSibling.Attributes.GetNamedItem("PrincessMaintainenceCost").Value);

            AIUniqueTroopFightingForceThreshold = int.Parse(nextSibling.Attributes.GetNamedItem("AIUniqueTroopFightingForceThreshold").Value);
            LearnSkillSuccessRate = int.Parse(nextSibling.Attributes.GetNamedItem("LearnSkillSuccessRate").Value);
            LearnStuntSuccessRate = int.Parse(nextSibling.Attributes.GetNamedItem("LearnStuntSuccessRate").Value);
            LearnTitleSuccessRate = int.Parse(nextSibling.Attributes.GetNamedItem("LearnTitleSuccessRate").Value);

            AutoLearnSkillSuccessRate = int.Parse(nextSibling.Attributes.GetNamedItem("AutoLearnSkillSuccessRate").Value);
            AutoLearnStuntSuccessRate = int.Parse(nextSibling.Attributes.GetNamedItem("AutoLearnStuntSuccessRate").Value);

            MilitaryPopulationCap = float.Parse(nextSibling.Attributes.GetNamedItem("MilitaryPopulationCap").Value);
            MilitaryPopulationReloadQuantity = float.Parse(nextSibling.Attributes.GetNamedItem("MilitaryPopulationReloadQuantity").Value);

            CloseThreshold = int.Parse(nextSibling.Attributes.GetNamedItem("CloseThreshold").Value);
            HateThreshold = int.Parse(nextSibling.Attributes.GetNamedItem("HateThreshold").Value);
            VeryCloseThreshold = int.Parse(nextSibling.Attributes.GetNamedItem("VeryCloseThreshold").Value);

            MaxAITroopCountCandidates = int.Parse(nextSibling.Attributes.GetNamedItem("MaxAITroopCountCandidates").Value);
            PopulationDevelopingRate = float.Parse(nextSibling.Attributes.GetNamedItem("PopulationDevelopingRate").Value);

            CloseAbilityRate = float.Parse(nextSibling.Attributes.GetNamedItem("CloseAbilityRate").Value);
            VeryCloseAbilityRate = float.Parse(nextSibling.Attributes.GetNamedItem("VeryCloseAbilityRate").Value);

            RetainFeiziPersonalLoyalty = int.Parse(nextSibling.Attributes.GetNamedItem("RetainFeiziPersonalLoyalty").Value);

            AIEncirclePlayerRate = int.Parse(nextSibling.Attributes.GetNamedItem("AIEncirclePlayerRate").Value);

            InternalSurplusFactor = int.Parse(nextSibling.Attributes.GetNamedItem("InternalSurplusFactor").Value);
            AIExtraPerson = float.Parse(nextSibling.Attributes.GetNamedItem("AIExtraPerson").Value);
            AIExtraPersonIncreaseRate = float.Parse(nextSibling.Attributes.GetNamedItem("AIExtraPersonIncreaseRate").Value);

            StaticMethods.LoadFromString(ExpandConditions, nextSibling.Attributes.GetNamedItem("ExpandConditions").Value);

            SearchPersonArchitectureCountPower = float.Parse(nextSibling.Attributes.GetNamedItem("SearchPersonArchitectureCountPower").Value);
            AIEncircleRank = int.Parse(nextSibling.Attributes.GetNamedItem("AIEncircleRank").Value);
            AIEncircleVar = int.Parse(nextSibling.Attributes.GetNamedItem("AIEncircleVar").Value);

            BasicAIFundRate = AIFundRate;
            BasicAIFoodRate = AIFoodRate;
            BasicAITroopOffenceRate = AITroopOffenceRate;
            BasicAITroopDefenceRate = AITroopDefenceRate;
            BasicAIArchitectureDamageRate = AIArchitectureDamageRate;
            BasicAITrainingSpeedRate = AITrainingSpeedRate;
            BasicAIRecruitmentSpeedRate = AIRecruitmentSpeedRate;
            BasicAIArmyExperienceRate = AIArmyExperienceRate;
            BasicAIOfficerExperienceRate = AIOfficerExperienceRate;
            BasicAIAntiStratagem = AIAntiStratagem;
            BasicAIAntiSurround = AIAntiSurround;
            BasicAIExtraPerson = AIExtraPerson;
        }

        public static void DayEvent(int year)
        {
            AIFundRate = year * AIFundYearIncreaseRate + BasicAIFundRate;
            AIFoodRate = year * AIFoodYearIncreaseRate + BasicAIFoodRate;
            AITroopOffenceRate = year * AITroopOffenceYearIncreaseRate + BasicAITroopOffenceRate;
            AITroopDefenceRate = year * AITroopDefenceYearIncreaseRate + BasicAITroopDefenceRate;
            AIArchitectureDamageRate = year * AIArchitectureDamageYearIncreaseRate + BasicAIArchitectureDamageRate;
            AITrainingSpeedRate = year * AITrainingSpeedYearIncreaseRate + BasicAITrainingSpeedRate;
            AIRecruitmentSpeedRate = year * AIRecruitmentSpeedYearIncreaseRate + BasicAIRecruitmentSpeedRate;
            AIOfficerExperienceRate = year * AIOfficerExperienceYearIncreaseRate + BasicAIOfficerExperienceRate;
            AIArmyExperienceRate = year * AIArmyExperienceYearIncreaseRate + BasicAIArmyExperienceRate;
            AIAntiSurround = (int) (year * AIAntiSurroundIncreaseRate + BasicAIAntiSurround);
            AIAntiStratagem = (int) (year * AIAntiStratagemIncreaseRate + BasicAIAntiStratagem);
            AIExtraPerson = year * AIExtraPersonIncreaseRate + BasicAIExtraPerson;
        }
    }
}

