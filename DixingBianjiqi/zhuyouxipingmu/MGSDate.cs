using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using GameFreeText;
using GameGlobal;
using GameObjects;

using GameObjects.FactionDetail;
using GameObjects.PersonDetail;
using GameObjects.PersonDetail.PersonMessages;
using GameObjects.SectionDetail;
using GameObjects.TroopDetail;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PluginInterface;
using WMPLib;
using WorldOfTheThreeKingdoms.GameLogic;
using WorldOfTheThreeKingdoms.GameScreens;
using WorldOfTheThreeKingdoms.GameScreens.ScreenLayers;
using WorldOfTheThreeKingdoms.Resources;

namespace WorldOfTheThreeKingdoms.GameScreens
{
    partial class MainGameScreen : Screen
    {
        private bool AfterDayPassed(GameTime gameTime)
        {
            return this.RunTheFactions(gameTime);
        }

        private bool AfterDayStarting(GameTime gameTime)
        {

            return this.MoveTheTroops(gameTime);
        }


        private bool Date_OnDayPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.DayPassedEvent();

                this.Plugins.AirViewPlugin.ReloadTroopView();

                this.gengxinyoucelan();

                return true;
            }
            return false;
        }

        private bool Date_OnDayStarting()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.DayStartingEvent();

                return true;
            }
            return false;
        }

        private bool Date_OnMonthPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.MonthPassedEvent();
                return true;
            }
            return false;
        }

        private void Date_OnSeasonChange(GameSeason season)
        {
            switch (season)
            {
                case GameSeason.春:
                    this.PlayMusic("GameMusic/Spring.mp3");
                    break;

                case GameSeason.夏:
                    this.PlayMusic("GameMusic/Summer.mp3");
                    break;

                case GameSeason.秋:
                    this.PlayMusic("GameMusic/Autumn.mp3");
                    break;

                case GameSeason.冬:
                    this.PlayMusic("GameMusic/Winter.mp3");
                    break;
            }

            if (!base.Scenario.Threading&&base.Scenario.Date.Day==1)
            {
                base.Scenario.SeasonChangeEvent();
                
            }
        }

        private bool Date_OnYearPassed()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.YearPassedEvent();
                return true;
            }
            return false;
        }

        private bool Date_OnYearStarting()
        {
            if (!base.Scenario.Threading)
            {
                base.Scenario.YearStartingEvent();
                return true;
            }
            return false;
        }

        public  void DateGo(int Days)
        {
            if (base.Scenario.CurrentPlayer != null)
            {
                base.Scenario.CurrentPlayer.Passed = true;
                if (base.Scenario.IsLastPlayer(base.Scenario.CurrentPlayer))
                {
                    this.Plugins.DateRunnerPlugin.RunDays(Days);
                }
            }
        }

    }
}
