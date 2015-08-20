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
    public partial class MainGameScreen : Screen
    {
        private ArchitectureLayer architectureLayer;
        private Keys currentKey;
        private bool drawingSelector;
        private bool tufashijianzantingyinyue=false ;
        private TimeSpan elapsedTime;
        public bool EnableLaterMouseLeftDownEvent;
        public bool EnableLaterMouseLeftUpEvent;
        public bool EnableLaterMouseMoveEvent;
        public bool EnableLaterMouseRightDownEvent;
        public bool EnableLaterMouseRightUpEvent;
        public bool EnableLaterMouseScrollEvent;
        private int frameCounter;
        private int frameRate;
        private Point lastPosition;
        private double lastTime;
        private string LoadFileName;
        private MainMapLayer mainMapLayer;
        private MapVeilLayer mapVeilLayer;
        private int oldScrollWheelValue;
        private WindowsMediaPlayerClass Player;
        internal GamePlugin Plugins;
        private Point position;
        private RoutewayLayer routewayLayer;
        private string SaveFileName;
        private ScreenManager screenManager;
        private float scrollSpeedScale;
        private float scrollSpeedScaleDefault;
        private float scrollSpeedScaleSpeedy;
        private SelectingLayer selectingLayer;
        public Point SelectorStartPosition;
        public TroopList SelectorTroops;
        public GameTextures Textures;
        private MainGame thisGame;
        private TileAnimationLayer tileAnimationLayer;
        private TroopLayer troopLayer;
        private int UpdateCount;
        private ViewMove viewMove;

        public MainGameScreen(MainGame game)
            : base(game)
        {
            this.Player = new WindowsMediaPlayerClass();
            this.Textures = new GameTextures();
            this.mainMapLayer = new MainMapLayer();
            this.architectureLayer = new ArchitectureLayer();
            this.mapVeilLayer = new MapVeilLayer();
            this.troopLayer = new TroopLayer();
            this.selectingLayer = new SelectingLayer();
            this.tileAnimationLayer = new TileAnimationLayer();
            this.routewayLayer = new RoutewayLayer();
            this.Plugins = new GamePlugin();
            this.SelectorTroops = new TroopList();
            this.scrollSpeedScale = 1f;
            this.scrollSpeedScaleDefault = 1f;
            this.scrollSpeedScaleSpeedy = 1.7f;
            this.oldScrollWheelValue = 0;
            this.EnableLaterMouseLeftDownEvent = true;
            this.EnableLaterMouseLeftUpEvent = true;
            this.EnableLaterMouseRightDownEvent = true;
            this.EnableLaterMouseRightUpEvent = true;
            this.EnableLaterMouseMoveEvent = true;
            this.EnableLaterMouseScrollEvent = true;
            this.frameRate = 0;
            this.frameCounter = 0;
            this.elapsedTime = TimeSpan.Zero;
            this.UpdateCount = 0;
            this.thisGame = game;
            this.screenManager = new ScreenManager(this);
            base.Scenario = new GameScenario(this);
            this.LoadCommonData();
            base.Game.Window.ClientSizeChanged += new EventHandler(this.Window_ClientSizeChanged);
            base.Game.Activated += new EventHandler(this.Game_Activated);
            base.Game.Deactivated += new EventHandler(this.Game_Deactivated);
            base.Scenario.OnAfterLoadScenario += new GameScenario.AfterLoadScenario(this.Scenario_OnAfterLoadScenario);
            base.Scenario.OnNewFactionAppear += new GameScenario.NewFactionAppear(this.Scenario_OnNewFactionAppear);
            base.Scenario.Date.OnDayStarting += new GameDate.DayStartingEvent(this.Date_OnDayStarting);
            base.Scenario.Date.OnDayPassed += new GameDate.DayPassedEvent(this.Date_OnDayPassed);
            base.Scenario.Date.OnMonthPassed += new GameDate.MonthPassedEvent(this.Date_OnMonthPassed);
            base.Scenario.Date.OnSeasonChange += new GameDate.SeasonChangeEvent(this.Date_OnSeasonChange);
            base.Scenario.Date.OnYearStarting += new GameDate.YearStartingEvent(this.Date_OnYearStarting);
            base.Scenario.Date.OnYearPassed += new GameDate.YearPassedEvent(this.Date_OnYearPassed);
            //this.Player.add_PlayStateChange(new _WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange));
            this.Player.PlayStateChange+=(new _WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange));
            //this.ShowyoucelanInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "跳转", "");


        }

        private bool AfterDayPassed(GameTime gameTime)
        {
            return this.RunTheFactions(gameTime);
        }

        private bool AfterDayStarting(GameTime gameTime)
        {

            return this.MoveTheTroops(gameTime);
        }

        public override void ArchitectureBeginRecentlyAttacked(Architecture architecture)
        {
            if (base.Scenario.IsCurrentPlayer(architecture.BelongedFaction))
            {
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(architecture.BelongedFaction.Leader, architecture, "ArchitectureBeginRecentlyAttacked");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                if (architecture.BelongedFaction.StopToControl)
                {
                    this.Plugins.DateRunnerPlugin.Pause();
                    architecture.BelongedFaction.StopToControl = false;
                    

                }
            }

        }

        public override void ArchitectureFacilityCompleted(Architecture architecture, Facility facility)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                architecture.TextDestinationString = facility.Name;
                if (base.Scenario.IsCurrentPlayer(architecture.BelongedFaction))
                {
                    if (!((facility.PositionOccupied <= 1) || GlobalVariables.NoHintOnSmallFacility))
                    {
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(architecture.BelongedFaction.Leader, architecture, "ArchitectureFacilityCompleted");
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                    }
                }
                else if (facility.UniqueInArchitecture && (facility.PositionOccupied > 4))
                {
                    this.Plugins.GameRecordPlugin.AddBranch(architecture, "FacilityCompleted", architecture.Position);
                }
            }
        }

        public override void ArchitectureHirePerson(PersonList personList)
        {
            Person person = personList[0] as Person;
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                foreach (Person person2 in personList)
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(person2, person2.Position, "HirePerson");
                    person2.TextDestinationString = person2.BelongedFaction.Name;
                    this.Plugins.GameRecordPlugin.AddBranch(person2, "HirePerson", person2.Position);
                }
            }
        }

        public override void ArchitecturePopulationEnter(Architecture a, int quantity)
        {
            if ((GlobalVariables.HintPopulation && (GlobalVariables.HintPopulationUnder1000 || (quantity >= 0x3e8))) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(a)) || GlobalVariables.SkyEye))
            {
                a.TextResultString = quantity.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(a, "ArchitecturePopulationEnter", a.Position);
            }
        }

        public override void ArchitecturePopulationEscape(Architecture a, int quantity)
        {
            if ((GlobalVariables.HintPopulation && (GlobalVariables.HintPopulationUnder1000 || (quantity >= 0x3e8))) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(a)) || GlobalVariables.SkyEye))
            {
                a.TextResultString = quantity.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(a, "ArchitecturePopulationEscape", a.Position);
            }
        }

        public override void ArchitectureReleaseCaptiveAfterOccupied(Architecture architecture, PersonList persons)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsArchitectureKnown(architecture)) || GlobalVariables.SkyEye)
            {
                Person person = persons[StaticMethods.Random(persons.Count)] as Person;
                architecture.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureReleaseCaptive", architecture.Position);
            }
        }

        public override void ArchitectureRewardPersons(Architecture architecture, GameObjectList personlist)
        {
            if ((personlist.Count > 0) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye))
            {
                this.Plugins.PersonBubblePlugin.AddPerson(personlist[GameObject.Random(personlist.Count)], architecture.Position, "RewardPerson");
            }
        }

        private void CalculateFrameRate(GameTime gameTime)
        {
        }

        public override void CaptivePlayerRelease(Faction from, Faction to, Captive captive)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsPlayer(from))
            {
                this.Plugins.PersonTextDialogPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(captive.ReleaseCaptive), new GameDelegates.VoidFunction(captive.ReturnRansom));
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(from.Leader, captive, "ReleaseCaptive");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void CaptiveRelease(bool success, Faction from, Faction to, Person person)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(from)) || base.Scenario.IsCurrentPlayer(to)) || GlobalVariables.SkyEye)
            {
                to.TextDestinationString = from.Name;
                to.TextResultString = person.Name;
                if (success)
                {
                    this.Plugins.GameRecordPlugin.AddBranch(to, "CaptiveReleaseSuccess", from.Capital.Position);
                }
                else
                {
                    this.Plugins.GameRecordPlugin.AddBranch(to, "CaptiveReleaseFailed", from.Capital.Position);
                }
            }
        }

        private void ContextMenuRightClick()
        {
            if ((this.Plugins.ContextMenuPlugin != null) && (this.PeekUndoneWork().Kind == UndoneWorkKind.None))
            {
                if (((this.CurrentArchitecture != null) && (this.CurrentTroop != null)) && ((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureTroopRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                else if ((((((this.CurrentRouteway != null) && (GlobalVariables.CurrentMapLayer == MapLayerKind.Routeway)) && (base.Scenario.IsCurrentPlayer(this.CurrentRouteway.BelongedFaction) && (this.CurrentRouteway.StartArchitecture != null))) && (((this.CurrentRouteway.DestinationArchitecture == null) || !this.CurrentRouteway.StartArchitecture.BelongedSection.AIDetail.AutoRun) || (this.CurrentRouteway.Building || (this.CurrentRouteway.LastActivePointIndex >= 0)))) && (this.CurrentTroop != null)) && ((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("TroopRoutewayRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                else if ((this.CurrentTroop != null) && ((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentTroop);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("TroopRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                else if ((this.CurrentArchitecture != null) && ((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentArchitecture);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                else if (((((this.CurrentRouteway != null) && (GlobalVariables.CurrentMapLayer == MapLayerKind.Routeway)) && (base.Scenario.IsCurrentPlayer(this.CurrentRouteway.BelongedFaction) && (this.CurrentRouteway.StartArchitecture != null))) && (((this.CurrentRouteway.DestinationArchitecture == null) || !this.CurrentRouteway.StartArchitecture.BelongedSection.AIDetail.AutoRun) || (this.CurrentRouteway.Building || (this.CurrentRouteway.LastActivePointIndex >= 0)))) && ((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentRouteway);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("RoutewayRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                else if (!this.Plugins.ContextMenuPlugin.IsShowing)
                {
                    this.Plugins.ContextMenuPlugin.IsShowing = true;
                    this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this);
                    this.Plugins.ContextMenuPlugin.SetMenuKindByName("MapRightClick");
                    this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                }
            }
        }

        public bool CurrentPlayerHasArchitecture()
        {
            return ((base.Scenario.CurrentPlayer != null) && (base.Scenario.CurrentPlayer.ArchitectureCount > 0));
        }

        public bool CurrentPlayerHasPerson()
        {
            return ((base.Scenario.CurrentPlayer != null) && (base.Scenario.CurrentPlayer.PersonCount > 0));
        }

        public bool CurrentPlayerHasTroop()
        {
            return ((base.Scenario.CurrentPlayer != null) && (base.Scenario.CurrentPlayer.TroopCount > 0));
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
                    this.PlayMusic("GameMusic/Spring.wma");
                    break;

                case GameSeason.夏:
                    this.PlayMusic("GameMusic/Summer.wma");
                    break;

                case GameSeason.秋:
                    this.PlayMusic("GameMusic/Autumn.wma");
                    break;

                case GameSeason.冬:
                    this.PlayMusic("GameMusic/Winter.wma");
                    break;
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

        private void DateGo(int Days)
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

        private void DemolishCurrentRouteway()
        {
            base.Scenario.RemoveRouteway(this.CurrentRouteway);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            base.spriteBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.BackToFront, SaveStateMode.None);
            this.Drawing(gameTime);
            base.spriteBatch.End();
        }

        private void DrawArchitectureSurvey()   //绘制城市情况表
        {
            if ((this.Plugins.ArchitectureSurveyPlugin.Showing && (this.viewMove == ViewMove.Stop)) && (this.Plugins.ArchitectureSurveyPlugin != null))
            {
                this.Plugins.ArchitectureSurveyPlugin.Draw(base.spriteBatch);
            }
        }

        private void DrawCommentText()  //绘制底部地图注释
        {
            if (this.Plugins.ConmentTextPlugin != null)
            {
                this.Plugins.ConmentTextPlugin.Draw(base.spriteBatch);
            }
        }

        public void DrawContextMenu()         //绘制建筑命令菜单
        {
            if (this.Plugins.ContextMenuPlugin.IsShowing)
            {
                this.Plugins.ContextMenuPlugin.Draw(base.spriteBatch);
            }
        }

        public void DrawDialog()
        {
            this.Plugins.HelpPlugin.Draw(base.spriteBatch);
            this.Plugins.OptionDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.SimpleTextDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.PersonTextDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.tupianwenziPlugin.Draw(base.spriteBatch);
            this.Plugins.ConfirmationDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.TransportDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.CreateTroopPlugin.Draw(base.spriteBatch);
            this.Plugins.MarshalSectionDialogPlugin.Draw(base.spriteBatch);
        }

        public void DrawFrameRate()
        {
            this.frameCounter++;
            string str = string.Format("fps: {0}", this.frameRate);
            base.Game.Window.Title = str;
        }

        public void DrawGameFrame()
        {

            if (this.Plugins.GameFramePlugin.IsShowing)
            {
                this.Plugins.GameFramePlugin.Draw(base.spriteBatch);
            }
        }

        private void Drawing(GameTime gameTime)            //绘制游戏屏幕
        {
            this.mainMapLayer.Draw(base.spriteBatch, base.viewportSize);
            this.architectureLayer.Draw(base.spriteBatch, base.viewportSize,this.Textures.qizitupian , gameTime);
            this.routewayLayer.Draw(base.spriteBatch, base.viewportSize);
            this.tileAnimationLayer.Draw(base.spriteBatch, base.viewportSize);
            this.troopLayer.Draw(base.spriteBatch, base.viewportSize, gameTime);
            this.mapVeilLayer.Draw(base.spriteBatch, base.viewportSize);


            switch (base.UndoneWorks.Peek().Kind)
            {
                case UndoneWorkKind.None:
                    if (StaticMethods.PointInViewport(base.MousePosition, base.viewportSize))
                    {
                        this.DrawCommentText();
                        this.DrawArchitectureSurvey();
                        this.DrawTroopSurvey();
                    }
                    this.DrawRoutewayEditor();
                    this.Plugins.ToolBarPlugin.DrawTools = true;
                    //    this.Showyoucelan(UndoneWorkKind.None, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "", "");
                    //this.Plugins.youcelanPlugin.Draw(base.spriteBatch); 

                    //if (!this.Plugins.youcelanPlugin.IsShowing)
                    //{
                        //this.Showyoucelan(UndoneWorkKind.None, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "", "");
                    //}

                    this.Plugins.youcelanPlugin.Draw(base.spriteBatch); 


                    break;

                case UndoneWorkKind.ContextMenu:
                    this.DrawContextMenu();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.Frame:
                    this.DrawGameFrame();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.Dialog:
                    this.DrawDialog();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.SubDialog:
                    this.DrawSubDialog();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.Selecting:
                    this.DrawCommentText();
                    this.selectingLayer.Draw(base.spriteBatch, base.viewportSize);
                    this.Plugins.ToolBarPlugin.DrawTools = true;
                    break;

                case UndoneWorkKind.Inputer:
                    this.DrawInputer();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.Selector:
                    if (StaticMethods.PointInViewport(base.MousePosition, base.viewportSize))
                    {
                        this.DrawCommentText();
                    }
                    this.DrawSelector();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;

                case UndoneWorkKind.MapViewSelector:
                    if (StaticMethods.PointInViewport(base.MousePosition, base.viewportSize))
                    {
                        this.DrawCommentText();
                    }
                    if (this.Plugins.MapViewSelectorPlugin.Kind == MapViewSelectorKind.建筑)
                    {
                        this.DrawArchitectureSurvey();
                    }
                    this.DrawMapViewSelector();
                    break;
            }
            this.DrawScreenBlind();
            this.DrawPersonBubble();
            this.DrawToolBar();


            this.DrawMouseArrow();

        }

        private void DrawInputer()
        {
            this.Plugins.NumberInputerPlugin.Draw(base.spriteBatch);
        }

        private void DrawMapViewSelector()
        {
            if (this.Plugins.MapViewSelectorPlugin != null)
            {
                this.Plugins.MapViewSelectorPlugin.Draw(base.spriteBatch);
            }
        }

        private void DrawMouseArrow()
        {
            if (base.MouseArrowTexture != null)
            {
                base.spriteBatch.Draw(base.MouseArrowTexture, new Vector2((float)this.mouseState.X, (float)this.mouseState.Y), null, Color.White, 0f, Vector2.Zero, (float)1f, SpriteEffects.None, 0f);
            }
        }

        private void DrawPersonBubble()
        {
            if (this.Plugins.PersonBubblePlugin != null)
            {
                this.Plugins.PersonBubblePlugin.Draw(base.spriteBatch);
            }
        }

        private void DrawRoutewayEditor()
        {
            if (this.Plugins.RoutewayEditorPlugin != null)
            {
                this.Plugins.RoutewayEditorPlugin.Draw(base.spriteBatch);
            }
        }

        private void DrawScreenBlind()
        {
            this.Plugins.ScreenBlindPlugin.Draw(base.spriteBatch);
        }

        private void DrawSelector()
        {
            if (this.DrawingSelector)
            {
                base.spriteBatch.Draw(this.Textures.SelectorTexture, new Rectangle(this.SelectorStartPosition.X, this.SelectorStartPosition.Y, base.MousePosition.X - this.SelectorStartPosition.X, base.MousePosition.Y - this.SelectorStartPosition.Y), null, Color.White, 0f, Vector2.Zero, SpriteEffects.None, 0.72f);
            }
        }

        public void DrawSubDialog()
        {
            this.Plugins.PersonDetailPlugin.Draw(base.spriteBatch);
            this.Plugins.TroopDetailPlugin.Draw(base.spriteBatch);
            this.Plugins.ArchitectureDetailPlugin.Draw(base.spriteBatch);
            this.Plugins.FactionTechniquesPlugin.Draw(base.spriteBatch);
            this.Plugins.TreasureDetailPlugin.Draw(base.spriteBatch);
        }

        private void DrawToolBar()
        {
            if (this.Plugins.ToolBarPlugin != null)
            {
                this.Plugins.ToolBarPlugin.Draw(base.spriteBatch);
            }
        }

        private void DrawTroopSurvey()
        {
            if ((this.Plugins.TroopSurveyPlugin.Showing && (this.viewMove == ViewMove.Stop)) && (this.Plugins.TroopSurveyPlugin != null))
            {
                this.Plugins.TroopSurveyPlugin.Draw(base.spriteBatch);
            }
        }

        public override void EarlyMouseLeftDown()
        {
            base.EarlyMouseLeftDown();



            this.scrollSpeedScale = this.scrollSpeedScaleSpeedy;
            if (!base.Scenario.LoadAndSaveAvail())
            {
                GlobalVariables.FastBattleSpeed = this.mouseState.LeftButton == ButtonState.Pressed;
            }
        }

        public override void EarlyMouseLeftUp()
        {
            base.EarlyMouseLeftUp();
            this.DrawingSelector = false;
            this.scrollSpeedScale = this.scrollSpeedScaleDefault;
            GlobalVariables.FastBattleSpeed = false;
        }

        public override void EarlyMouseMove()
        {
            base.EarlyMouseMove();
            if (this.DrawingSelector && ((base.MousePosition.X < this.SelectorStartPosition.X) || (base.MousePosition.Y < this.SelectorStartPosition.Y)))
            {
                this.DrawingSelector = false;
            }
        }

        public override void EarlyMouseRightDown()
        {
            base.EarlyMouseRightDown();
        }

        public override void EarlyMouseRightUp()
        {
            base.EarlyMouseRightUp();
        }

        public override void EarlyMouseScroll()
        {
            base.EarlyMouseScroll();
        }

        public override void FactionAfterCatchLeader(Person leader, Faction faction)
        {
            if (base.Scenario.IsPlayer(faction))
            {
                this.Plugins.PersonTextDialogPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(leader.Killed), null);
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(leader, leader, "FactionAfterCatchLeader");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void FactionDestroy(Faction faction)
        {
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionDestroy", (faction.Capital != null) ? faction.Capital.Position : base.Scenario.ScenarioMap.JumpPosition);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }
            neutralPerson.TextDestinationString = faction.Name;
            this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, neutralPerson, "FactionDestroy");
            this.Plugins.PersonTextDialogPlugin.IsShowing = true;
        }

        public override void FactionForcedChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital)
        {
            faction.TextDestinationString = oldCapital.Name;
            faction.TextResultString = newCapital.Name;
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionForcedChangeCapital", newCapital.Position);
        }

        public override void FactionGetControl(Faction faction)
        {
            base.Scenario.CurrentPlayer = faction;
            this.Plugins.AirViewPlugin.ReloadTroopView();
            if (faction.IsPositionKnown(faction.Leader.Position) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(faction.Leader, faction.Leader.Position, "GetControl");
            }
            base.PlayNormalSound("GameSound/Control/Control.wav");
        }

        public override void FactionInitialtiveChangeCapital(Faction faction, Architecture oldCapital, Architecture newCapital)
        {
            if (oldCapital != null)
            {
                faction.TextDestinationString = oldCapital.Name;
            }
            else
            {
                faction.TextDestinationString = "----";
            }
            faction.TextResultString = newCapital.Name;
            this.Plugins.GameRecordPlugin.AddBranch(faction, "FactionInitialtiveChangeCapital", newCapital.Position);
        }

        public override void FactionTechniqueFinished(Faction faction, Technique technique)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(faction)) || GlobalVariables.SkyEye)
            {
                faction.Leader.TextDestinationString = technique.Name;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(faction.Leader, faction.Leader, "FactionTechniqueFinished");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void FactionUpgradeTechnique(Faction faction, Technique technique, Architecture architecture)
        {
            if (!base.Scenario.IsCurrentPlayer(faction))
            {
                faction.TextDestinationString = technique.Name;
                this.Plugins.GameRecordPlugin.AddBranch(faction, "UpgradeTechnique", faction.Capital.Position);
            }
        }

        private void Game_Activated(object sender, EventArgs e)
        {
            this.UpdateViewport();
            this.ResumeMusic();
            base.EnableMouseEvent = true;
            if (!GlobalVariables.RunWhileNotFocused)
            {
                this.Activate();
            }
        }

        private void Game_Deactivated(object sender, EventArgs e)
        {
            this.PauseMusic();
            base.EnableMouseEvent = false;
            if (!GlobalVariables.RunWhileNotFocused)
            {
                this.Deactivate();
            }
        }

        public override void GameEndWithUnite(Faction faction)
        {
            faction.TextResultString = base.Scenario.Date.ToDateString();
            this.Plugins.GameRecordPlugin.AddBranch(faction, "GameEndWithUnite", faction.Capital.Position);
            this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(faction.Leader, faction.Leader, "GameEndWithUnite");
            this.Plugins.PersonTextDialogPlugin.IsShowing = true;
        }

        public override void GameGo(GameTime gameTime)
        {
            if ((this.viewMove == ViewMove.Stop) && !this.AfterDayPassed(gameTime))
            {
                this.Plugins.DateRunnerPlugin.DateGo();
                if (!this.AfterDayStarting(gameTime))
                {
                    this.Plugins.DateRunnerPlugin.DateStop();
                }
            }
        }

        public override Rectangle GetDestination(Point mapPosition)
        {
            return this.mainMapLayer.GetDestination(mapPosition);
        }

        public override Point GetPointByPosition(Point mapPosition)
        {
            return this.mainMapLayer.GetTopCenterPoint(mapPosition);
        }

        public override Texture2D GetPortrait(int id)
        {
            return this.Plugins.PersonPortraitPlugin.GetPortrait(id);
        }

        public override Point GetPositionByPoint(Point mousePoint)
        {
            return this.mainMapLayer.TranslateCoordinateToTilePosition(mousePoint.X, mousePoint.Y);
        }

        private string GetSaveFileDisplayText(string filename)
        {
            string path = "GameData/Save/" + filename;
            if (File.Exists(path))
            {
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = path,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                return GameScenario.GetGameSaveFileSurveyText(builder.ConnectionString);
            }
            return "空 白 存 档";
        }

        public override Texture2D GetSmallPortrait(int id)
        {
            return this.Plugins.PersonPortraitPlugin.GetSmallPortrait(id);
        }

        private void HandleContextMenuResult(ContextMenuResult result)
        {
            GameDelegates.VoidFunction function = null;
            GameDelegates.VoidFunction function2 = null;
            GameDelegates.VoidFunction function3 = null;
            GameDelegates.VoidFunction function4 = null;
            switch (result)
            {
                case ContextMenuResult.Architecture_Detail:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.GetGameObjectList(), null, "", "");
                    break;

                case ContextMenuResult.Architecture_Persons:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.GetAllPersons(), null, "", "");
                    break;

                case ContextMenuResult.Architecture_Militaries:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.Militaries.GetList(), null, "", "");
                    break;

                case ContextMenuResult.Architecture_NoFactionPersons:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.NoFactionPersons.GetList(), null, "在野人物", "");
                    break;

                case ContextMenuResult.Architecture_Facilities:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Facility, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.Facilities.GetList(), null, "", "");
                    break;

                case ContextMenuResult.Architecture_Captive:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.Browse, true, true, false, false, this.CurrentArchitecture.Captives.GetList(), null, "", "");
                    break;

                case ContextMenuResult.Architecture_Treasure:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.Browse, true, true, false, false, this.CurrentArchitecture.GetAllTreasureInArchitecture(), null, "", "");
                    break;
                //case ContextMenuResult.Architecture_xiangxixinxi:
                //    break;

                case ContextMenuResult.Faction_Detail:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Faction, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.GetGameObjectList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Architectures:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.Architectures.GetList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Troops:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Troop, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.Troops.GetList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Persons:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.Persons.GetList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Militaries:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.Militaries.GetList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_AvailableMilitaryKinds:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.MilitaryKind, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.AvailableMilitaryKinds.GetMilitaryKindList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Captive:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.Browse, true, true, false, false, this.CurrentArchitecture.BelongedFaction.Captives.GetList(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_SelfCaptive:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.Browse, true, true, false, false, this.CurrentArchitecture.BelongedFaction.SelfCaptives.GetList(), null, "被俘虏列表", "");
                    }
                    break;

                case ContextMenuResult.Faction_DiplomaticRelations:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.DiplomaticRelation, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.Scenario.DiplomaticRelations.GetDiplomaticRelationDisplayListByFactionID(this.CurrentArchitecture.BelongedFaction.ID), null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Techniques:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowFactionTechniques(this.CurrentArchitecture.BelongedFaction, this.CurrentArchitecture);
                    }
                    break;

                case ContextMenuResult.Faction_Sections:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Section, FrameFunction.Browse, false, true, false, false, this.CurrentArchitecture.BelongedFaction.Sections, null, "", "");
                    }
                    break;

                case ContextMenuResult.Faction_Treasure:
                    if (this.CurrentArchitecture.BelongedFaction != null)
                    {
                        this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.Browse, true, true, false, false, this.CurrentArchitecture.GetAllTreasureInFaction(), null, "", "");
                    }
                    break;

                case ContextMenuResult.Internal_StopWork:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.无;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, null, "停止工作", "");
                    break;

                case ContextMenuResult.Internal_Agriculture:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.农业;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.AgricultureWorkingPersons, "农业", "农业");
                    break;

                case ContextMenuResult.Internal_Commerce:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.商业;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.CommerceWorkingPersons, "商业", "商业");
                    break;

                case ContextMenuResult.Internal_Technology:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.技术;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.TechnologyWorkingPersons, "技术", "技术");
                    break;

                case ContextMenuResult.Internal_Domination:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.统治;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.DominationWorkingPersons, "统治", "统治");
                    break;

                case ContextMenuResult.Internal_Morale:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.民心;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.MoraleWorkingPersons, "民心", "民心");
                    break;

                case ContextMenuResult.Internal_Endurance:
                    this.screenManager.CurrentArchitectureWorkKind = ArchitectureWorkKind.耐久;
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.Architecture_WorkingList, true, true, true, true, this.CurrentArchitecture.Persons, this.CurrentArchitecture.EnduranceWorkingPersons, "耐久", "耐久");
                    break;

                case ContextMenuResult.Internal_Facility_Build:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Facility, FrameFunction.GetFacilityToBuild, false, true, true, false, this.CurrentArchitecture.GetBuildableFacilityKindList(), null, "选择设施", "");
                    break;

                case ContextMenuResult.Internal_Facility_Demolish:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Facility, FrameFunction.GetFacilityToDemolish, false, true, true, true, this.CurrentArchitecture.Facilities, null, "选择设施", "");
                    break;

                case ContextMenuResult.Internal_Trade_BuyFood:
                    this.Plugins.NumberInputerPlugin.SetMax(this.CurrentArchitecture.Fund);
                    this.Plugins.NumberInputerPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.NumberInputerPlugin.SetDepthOffset(-0.01f);
                    if (function == null)
                    {
                        function = delegate
                        {
                            this.CurrentArchitecture.BuyFood(this.Plugins.NumberInputerPlugin.Number);
                        };
                    }
                    this.Plugins.NumberInputerPlugin.SetEnterFunction(function);
                    this.Plugins.NumberInputerPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Internal_Trade_SellFood:
                    this.Plugins.NumberInputerPlugin.SetMax(this.CurrentArchitecture.Food);
                    this.Plugins.NumberInputerPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.NumberInputerPlugin.SetDepthOffset(-0.01f);
                    if (function2 == null)
                    {
                        function2 = delegate
                        {
                            this.CurrentArchitecture.SellFood(this.Plugins.NumberInputerPlugin.Number);
                        };
                    }
                    this.Plugins.NumberInputerPlugin.SetEnterFunction(function2);
                    this.Plugins.NumberInputerPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Military_Campaign:
                    if (function3 == null)
                    {
                        function3 = delegate
                        {
                            this.CurrentArchitecture = this.Plugins.CreateTroopPlugin.CreatingArchitecture as Architecture;
                            this.CurrentMilitary = this.Plugins.CreateTroopPlugin.CreatingMilitary as Military;
                            this.CurrentGameObjects = this.Plugins.CreateTroopPlugin.CreatingPersons as GameObjectList;
                            this.CurrentPerson = this.Plugins.CreateTroopPlugin.CreatingLeader as Person;
                            this.CurrentNumber = this.Plugins.CreateTroopPlugin.CreatingFood;
                        };
                    }
                    this.Plugins.CreateTroopPlugin.SetCreateFunction(function3);
                    this.Plugins.CreateTroopPlugin.SetShellMilitaryKind(null);
                    this.Plugins.CreateTroopPlugin.SetArchitecture(this.CurrentArchitecture);
                    this.Plugins.CreateTroopPlugin.SetPosition(ShowPosition.Center);
                    this.Plugins.CreateTroopPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Military_Troopership:
                    if (function4 == null)
                    {
                        function4 = delegate
                        {
                            this.CurrentArchitecture = this.Plugins.CreateTroopPlugin.CreatingArchitecture as Architecture;
                            this.CurrentMilitary = this.Plugins.CreateTroopPlugin.CreatingMilitary as Military;
                            this.CurrentGameObjects = this.Plugins.CreateTroopPlugin.CreatingPersons as GameObjectList;
                            this.CurrentPerson = this.Plugins.CreateTroopPlugin.CreatingLeader as Person;
                            this.CurrentNumber = this.Plugins.CreateTroopPlugin.CreatingFood;
                        };
                    }
                    this.Plugins.CreateTroopPlugin.SetCreateFunction(function4);
                    this.Plugins.CreateTroopPlugin.SetShellMilitaryKind(base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKind(0x1c));
                    this.Plugins.CreateTroopPlugin.SetArchitecture(this.CurrentArchitecture);
                    this.Plugins.CreateTroopPlugin.SetPosition(ShowPosition.Center);
                    this.Plugins.CreateTroopPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Military_Training:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetTrainingMilitary, false, true, true, false, this.CurrentArchitecture.GetTrainingMilitaryList(), null, "选择编队", "");
                    break;

                case ContextMenuResult.Military_New:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.MilitaryKind, FrameFunction.GetNewMilitaryKind, false, true, true, false, this.CurrentArchitecture.GetNewMilitaryKindList(), null, "选择兵种", "");
                    break;

                case ContextMenuResult.Military_Recruitment:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetRecruitmentMilitary, false, true, true, false, this.CurrentArchitecture.GetRecruitmentMilitaryList(), null, "选择编队", "");
                    break;

                case ContextMenuResult.Military_Merge:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetMergeMilitary, false, true, true, false, this.CurrentArchitecture.GetMergeMilitaryList(), null, "选择编队", "");
                    break;

                case ContextMenuResult.Military_Disband:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetBeDisbandedMilitaries, false, true, true, true, this.CurrentArchitecture.Militaries, null, "解散编队", "");
                    break;

                case ContextMenuResult.Military_LevelUp:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.GetLevelUpMilitaries, false, true, true, true, this.CurrentArchitecture.GetLevelUpMilitaryList(), null, "选择编队", "");
                    break;

                case ContextMenuResult.Transport_Routeway_Design:
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.ArchitectureRoutewayStartPoint));
                    break;

                case ContextMenuResult.Transport_Routeway_PointShortestNormal:
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.RoutewayPointShortestNormal));
                    break;

                case ContextMenuResult.Transport_Routeway_PointShortestNoWater:
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.RoutewayPointShortestNoWater));
                    break;

                case ContextMenuResult.Transport_Routeway_ArchitectureShortestNormal:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.SimpleArchitecture, FrameFunction.GetShortestRouteway, false, true, true, true, this.CurrentArchitecture.GetAILinks(2), null, "粮道", "");
                    break;

                case ContextMenuResult.Transport_Routeway_ArchitectureShortestNoWater:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.SimpleArchitecture, FrameFunction.GetShortestNoWaterRouteway, false, true, true, true, this.CurrentArchitecture.GetAILinks(2), null, "粮道", "");
                    break;

                case ContextMenuResult.Transport_Routeway_CloseAll:
                    this.CurrentArchitecture.CloseAllRouteways();
                    break;

                case ContextMenuResult.Transport_Routeway_DemolishAll:
                    this.CurrentArchitecture.DemolishAllRouteways();
                    break;

                case ContextMenuResult.Transport_Fund:
                    this.Plugins.TransportDialogPlugin.SetSourceArchiecture(this.CurrentArchitecture);
                    this.Plugins.TransportDialogPlugin.SetKind(TransportKind.Fund);
                    this.Plugins.TransportDialogPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.TransportDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Transport_Food:
                    this.Plugins.TransportDialogPlugin.SetSourceArchiecture(this.CurrentArchitecture);
                    this.Plugins.TransportDialogPlugin.SetKind(TransportKind.Food);
                    this.Plugins.TransportDialogPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.TransportDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Person_Transfer:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.PersonTransfer, false, true, true, true, this.CurrentArchitecture.Persons, null, "调动", "");
                    break;

                case ContextMenuResult.Person_Convene:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.PersonConvene, false, true, true, true, this.CurrentArchitecture.GetPersonConveneList(), null, "召集", "");
                    break;

                case ContextMenuResult.Person_Hire:
                    this.CurrentArchitecture.HireNoFactionPerson();
                    break;

                case ContextMenuResult.Person_Convince:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.ConvincePersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetConvinceSourcePerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "说服", "说服");
                    break;

                case ContextMenuResult.Person_Reward:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.RewardPersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetRewardPerson, false, true, true, true, this.CurrentArchitecture.GetRewardPersons(), null, "褒奖", "Personal");
                    break;

                case ContextMenuResult.Person_RewardAll:
                    this.CurrentArchitecture.RewardAll();
                    break;

                case ContextMenuResult.Person_Redeem:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.GetRedeemCaptive, false, true, true, false, this.CurrentArchitecture.GetRedeemCaptiveList(), null, "赎回俘虏", "");
                    break;

                case ContextMenuResult.Person_Study_Skill:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetStudySkillPerson, false, true, true, true, this.CurrentArchitecture.GetPersonStudySkillList(), null, "研习", "");
                    break;

                case ContextMenuResult.Person_Study_Title:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetStudyTitlePerson, false, true, true, false, this.CurrentArchitecture.GetPersonStudyTitleList(), null, "研习", "");
                    break;

                case ContextMenuResult.Person_Study_Stunt:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetStudyStuntPerson, false, true, true, false, this.CurrentArchitecture.GetPersonStudyStuntList(), null, "研习", "");
                    break;

                case ContextMenuResult.RoutewayEdit:
                    this.Plugins.RoutewayEditorPlugin.SetRouteway(this.CurrentRouteway);
                    this.Plugins.RoutewayEditorPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.RoutewayShowArea:
                    this.CurrentRouteway.ShowArea = !this.CurrentRouteway.ShowArea;
                    break;

                case ContextMenuResult.RoutewayBuild:
                    this.CurrentRouteway.Build();
                    break;

                case ContextMenuResult.RoutewayClose:
                    this.CurrentRouteway.CloseAt(this.position);
                    break;

                case ContextMenuResult.RoutewayDemolish:
                    this.TryToDemolishRouteway();
                    break;

                case ContextMenuResult.Tactics_Information:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.InformationKind, FrameFunction.GetInformationKind, false, true, true, false, base.Scenario.GameCommonData.AllInformationKinds.GetAvailList(this.CurrentArchitecture), null, "情报种类", "");
                    break;

                case ContextMenuResult.Tactics_Spy:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.SpyPersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetSpyPerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "间谍", "间谍");
                    break;

                case ContextMenuResult.Tactics_Destroy:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.DestroyPersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetDestroyPerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "破坏", "破坏");
                    break;

                case ContextMenuResult.Tactics_Instigate:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.InstigatePersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetInstigatePerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "煽动", "煽动");
                    break;

                case ContextMenuResult.Tactics_Gossip:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.GossipPersonMaxCount);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetGossipPerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "流言", "流言");
                    break;

                case ContextMenuResult.Tactics_Search:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Work, FrameFunction.GetSearchPerson, false, true, true, true, this.CurrentArchitecture.Persons, null, "搜索", "搜索");
                    break;

                case ContextMenuResult.Tactics_ClearField:
                    this.Plugins.ConfirmationDialogPlugin.SetSimpleTextDialog(this.Plugins.SimpleTextDialogPlugin);
                    this.Plugins.ConfirmationDialogPlugin.ClearFunctions();
                    this.Plugins.ConfirmationDialogPlugin.AddYesFunction(new GameDelegates.VoidFunction(this.CurrentArchitecture.ClearField));
                    this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                    this.Plugins.SimpleTextDialogPlugin.SetGameObjectBranch(this.CurrentArchitecture, "ClearField");
                    this.Plugins.ConfirmationDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Monarch_ChangeCapital:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.GetNewCapital, false, true, true, false, this.CurrentArchitecture.GetChangeCapitalArchitectureList(), null, "迁都", "");
                    break;

                case ContextMenuResult.Monarch_ResetDiplomaticRelation:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.DiplomaticRelation, FrameFunction.GetFriendlyDiplomaticRelation, false, true, true, true, this.CurrentArchitecture.GetResetDiplomaticRelationList(), null, "断交", "");
                    break;

                case ContextMenuResult.Monarch_Techniques:
                    this.ShowFactionTechniques(this.CurrentArchitecture.BelongedFaction, this.CurrentArchitecture);
                    break;

                case ContextMenuResult.Monarch_ReleaseCaptive:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.GetReleaseCaptive, false, true, true, true, this.CurrentArchitecture.BelongedFaction.Captives, null, "释放俘虏", "");
                    break;

                case ContextMenuResult.Monarch_Refuse:
                    this.CurrentArchitecture.BelongedFaction.AutoRefuse = !this.CurrentArchitecture.BelongedFaction.AutoRefuse;
                    break;

                case ContextMenuResult.Monarch_Treasure_Confiscate:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.GetConfiscateTreasure, false, true, true, false, this.CurrentArchitecture.GetAllTreasureInArchitectureExceptLeader(), null, "", "");
                    break;

                case ContextMenuResult.Monarch_Treasure_Award:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.GetAwardTreasure, false, true, true, false, this.CurrentArchitecture.GetTreasureListOfLeader(), null, "", "");
                    break;

                case ContextMenuResult.Auto_Section_New:
                    this.Plugins.MarshalSectionDialogPlugin.SetFaction(this.CurrentArchitecture.BelongedFaction);
                    this.Plugins.MarshalSectionDialogPlugin.SetSection(null);
                    this.Plugins.MarshalSectionDialogPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.MarshalSectionDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Auto_Section_Regroup:
                    this.Plugins.MarshalSectionDialogPlugin.SetFaction(this.CurrentArchitecture.BelongedFaction);
                    this.Plugins.MarshalSectionDialogPlugin.SetSection(this.CurrentArchitecture.BelongedSection);
                    this.Plugins.MarshalSectionDialogPlugin.SetMapPosition(ShowPosition.Center);
                    this.Plugins.MarshalSectionDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.Auto_Section_Disband:
                    this.Plugins.TabListPlugin.SetSelectedItemMaxCount(this.CurrentArchitecture.BelongedFaction.SectionCount - 1);
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Section, FrameFunction.GetSectionToDemolish, false, true, true, true, this.CurrentArchitecture.BelongedFaction.Sections, null, "", "");
                    break;

                case ContextMenuResult.Auto_Hiring:
                    this.CurrentArchitecture.AutoHiring = !this.CurrentArchitecture.AutoHiring;
                    if (this.CurrentArchitecture.AutoHiring)
                    {
                        this.CurrentArchitecture.PlayerAIHire();
                    }
                    break;

                case ContextMenuResult.Auto_Rewarding:
                    this.CurrentArchitecture.AutoRewarding = !this.CurrentArchitecture.AutoRewarding;
                    if (this.CurrentArchitecture.AutoRewarding)
                    {
                        this.CurrentArchitecture.PlayerAIReward();
                    }
                    break;

                case ContextMenuResult.Auto_Working:
                    this.CurrentArchitecture.AutoWorking = !this.CurrentArchitecture.AutoWorking;
                    if (this.CurrentArchitecture.AutoWorking)
                    {
                        this.CurrentArchitecture.PlayerAIWork();
                    }
                    break;

                case ContextMenuResult.Auto_Searching:
                    this.CurrentArchitecture.AutoSearching = !this.CurrentArchitecture.AutoSearching;
                    if (this.CurrentArchitecture.AutoSearching)
                    {
                        this.CurrentArchitecture.PlayerAISearch();
                    }
                    break;

                case ContextMenuResult.AllEnter:
                    this.CurrentArchitecture.AllEnter();
                    break;

                case ContextMenuResult.DateGo_1Day:
                    this.DateGo(1);
                    break;

                case ContextMenuResult.DateGo_2Days:
                    this.DateGo(2);
                    break;

                case ContextMenuResult.DateGo_5Days:
                    this.DateGo(5);
                    break;

                case ContextMenuResult.DateGo_10Days:
                    this.DateGo(10);
                    break;

                case ContextMenuResult.DateGo_30Days:
                    this.DateGo(30);
                    break;

                case ContextMenuResult.Jump_Architecture:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "跳转", "");

                    break;

                case ContextMenuResult.Jump_Troop:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Troop, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Troops, null, "跳转", "");
                    break;

                case ContextMenuResult.Jump_Person:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Persons, null, "跳转", "");
                    break;

                case ContextMenuResult.Switch_Smog:
                    GlobalVariables.DrawMapVeil = !GlobalVariables.DrawMapVeil;
                    break;

                case ContextMenuResult.Switch_TroopTitle:
                    this.Plugins.TroopTitlePlugin.IsShowing = !this.Plugins.TroopTitlePlugin.IsShowing;
                    break;

                case ContextMenuResult.Switch_Music:
                    GlobalVariables.PlayMusic = !GlobalVariables.PlayMusic;
                    if (GlobalVariables.PlayMusic)
                    {
                        this.Date_OnSeasonChange(base.Scenario.Date.Season);
                    }
                    else
                    {
                        this.StopMusic();
                    }
                    break;

                case ContextMenuResult.Switch_NormalSound:
                    GlobalVariables.PlayNormalSound = !GlobalVariables.PlayNormalSound;
                    break;

                case ContextMenuResult.Switch_BattleSound:
                    GlobalVariables.PlayBattleSound = !GlobalVariables.PlayBattleSound;
                    break;

                case ContextMenuResult.Switch_TroopAnimation:
                    GlobalVariables.DrawTroopAnimation = !GlobalVariables.DrawTroopAnimation;
                    break;

                case ContextMenuResult.Switch_FullScreen:
                    this.ToggleFullScreen();
                    break;

                case ContextMenuResult.Switch_SkyEye:
                    GlobalVariables.SkyEye = !GlobalVariables.SkyEye;
                    break;

                case ContextMenuResult.Switch_MultipleResource:
                    GlobalVariables.MultipleResource = !GlobalVariables.MultipleResource;
                    break;

                case ContextMenuResult.Information_AllSkills:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Skill, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllSkills.GetSkillList(), null, "", "");
                    break;

                case ContextMenuResult.Information_AllTitles:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Title, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllTitles.GetTitleList(), null, "", "");
                    break;

                case ContextMenuResult.Information_AllMilitaryKinds:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.MilitaryKind, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllMilitaryKinds.GetMilitaryKindList(), null, "", "");
                    break;

                case ContextMenuResult.Information_AllStunts:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Stunt, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllStunts.GetStuntList(), null, "", "");
                    break;

                case ContextMenuResult.Information_AllFactions:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Faction, FrameFunction.Browse, false, true, false, false, base.Scenario.Factions, null, "", "");
                    break;

                case ContextMenuResult.Information_AllArchitectures:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Architecture, FrameFunction.Browse, false, true, false, false, base.Scenario.Architectures, null, "", "");
                    break;

                case ContextMenuResult.Information_AllTroops:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Troop, FrameFunction.Browse, false, true, false, false, base.Scenario.Troops, null, "", "");
                    break;

                case ContextMenuResult.Information_AllPersons:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Browse, false, true, false, false, base.Scenario.AvailablePersons, null, "", "");
                    break;

                case ContextMenuResult.Information_AllMilitaries:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.Browse, false, true, false, false, base.Scenario.Militaries, null, "", "");
                    break;

                case ContextMenuResult.Information_AllFacilities:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Facility, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllFacilityKinds.GetFacilityKindList(), null, "设施种类", "");
                    break;

                case ContextMenuResult.Information_AllTerrainDetails:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.TerrainDetail, FrameFunction.Browse, false, true, false, false, base.Scenario.GameCommonData.AllTerrainDetails.GetTerrainDetailList(), null, "", "");
                    break;

                case ContextMenuResult.Information_AllSections:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Section, FrameFunction.Browse, false, true, false, false, base.Scenario.Sections, null, "", "");
                    break;

                case ContextMenuResult.Information_AllRegions:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Region, FrameFunction.Browse, false, true, false, false, base.Scenario.Regions, null, "", "");
                    break;

                case ContextMenuResult.Information_AllStates:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.State, FrameFunction.Browse, false, true, false, false, base.Scenario.States, null, "", "");
                    break;

                case ContextMenuResult.Information_AllTreasures:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.Browse, false, true, false, false, base.Scenario.Treasures, null, "", "");
                    break;

                case ContextMenuResult.Load:
                    this.LoadGame();
                    break;

                case ContextMenuResult.Save:
                    this.SaveGame();
                    break;

                case ContextMenuResult.System:
                    this.Plugins.GameSystemPlugin.ShowOptionDialog(ShowPosition.Center);
                    break;

                case ContextMenuResult.TroopMove:
                    //this.CurrentTroop.Operated = true;
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopDestination));
                    break;

                case ContextMenuResult.TroopTarget:
                    this.CurrentTroop.Operated = true;
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopTarget));
                    break;

                case ContextMenuResult.TroopCombatMethod_Cancel:
                    this.CurrentTroop.CurrentCombatMethod = null;
                    break;

                case ContextMenuResult.TroopCombatMethod:
                    this.SetTroopCombatMethod(this.Plugins.ContextMenuPlugin.CurrentParamID);
                    break;

                case ContextMenuResult.TroopStunt:
                    this.SetTroopStunt(this.Plugins.ContextMenuPlugin.CurrentParamID);
                    break;

                case ContextMenuResult.TroopStratagem_Cancel:
                    this.CurrentTroop.CurrentStratagem = null;
                    if (this.CurrentTroop.Status == TroopStatus.埋伏)
                    {
                        this.CurrentTroop.EndAmbush();
                    }
                    break;

                case ContextMenuResult.TroopStratagem_0:
                    this.SetTroopStratagem(0);
                    break;

                case ContextMenuResult.TroopStratagem_1:
                    this.SetTroopStratagem(1);
                    break;

                case ContextMenuResult.TroopStratagem_2:
                    this.SetTroopStratagem(2);
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopInvestigatePosition));
                    break;

                case ContextMenuResult.TroopStratagem_3:
                    this.SetTroopStratagem(3);
                    break;

                case ContextMenuResult.TroopStratagem_4:
                    this.SetTroopStratagem(4);
                    break;

                case ContextMenuResult.TroopStratagem_5:
                    this.SetTroopStratagem(5);
                    break;

                case ContextMenuResult.TroopStratagem_6:
                    this.SetTroopStratagem(6);
                    this.CurrentTroop.SelfCastPosition = this.CurrentTroop.Position;
                    break;

                case ContextMenuResult.TroopStratagem_7:
                    this.SetTroopStratagem(7);
                    break;

                case ContextMenuResult.TroopStratagem_8:
                    this.SetTroopStratagem(8);
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopSetFirePosition));
                    break;

                case ContextMenuResult.TroopStratagem_9:
                    this.SetTroopStratagem(9);
                    break;

                case ContextMenuResult.TroopEnter:
                    this.CurrentTroop.Enter();
                    this.CurrentTroop = null;
                    break;

                case ContextMenuResult.TroopOccupy:
                    this.CurrentTroop.Occupy();

                    



                    break;

                case ContextMenuResult.TroopAction_LevyFood:
                    this.CurrentTroop.Operated = true;
                    this.CurrentTroop.LevyFood();
                    break;

                case ContextMenuResult.TroopAction_CutRouteway:
                    this.CurrentTroop.Leader.TextDestinationString = this.CurrentTroop.CutRoutewayDaysNeeded.ToString();
                    this.Plugins.PersonTextDialogPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(this.CurrentTroop.CutRouteway), null);
                    this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(this.CurrentTroop.Leader, this.CurrentTroop.Leader, "CutRouteway");
                    this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                    break;

                case ContextMenuResult.TroopConfig_AttackDefaultKind:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.AttackDefaultKind, FrameFunction.GetAttackDefaultKind, false, true, true, false, base.Scenario.GameCommonData.AllAttackDefaultKinds, base.Scenario.GameCommonData.AllAttackDefaultKinds.GetSelectedList(this.CurrentTroop.AttackDefaultKind), "攻击默认", "");
                    break;

                case ContextMenuResult.TroopConfig_AttackTargetKind:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.AttackTargetKind, FrameFunction.GetAttackTargetKind, false, true, true, false, base.Scenario.GameCommonData.AllAttackTargetKinds, base.Scenario.GameCommonData.AllAttackTargetKinds.GetSelectedList(this.CurrentTroop.AttackTargetKind), "攻击目标", "");
                    break;

                case ContextMenuResult.TroopConfig_CastDefaultKind:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.CastDefaultKind, FrameFunction.GetCastDefaultKind, false, true, true, false, base.Scenario.GameCommonData.AllCastDefaultKinds, base.Scenario.GameCommonData.AllCastDefaultKinds.GetSelectedList(this.CurrentTroop.CastDefaultKind), "施展默认", "");
                    break;

                case ContextMenuResult.TroopConfig_CastTargetKind:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.CastTargetKind, FrameFunction.GetCastTargetKind, false, true, true, false, base.Scenario.GameCommonData.AllCastTargetKinds, base.Scenario.GameCommonData.AllCastTargetKinds.GetSelectedList(this.CurrentTroop.CastTargetKind), "施展目标", "");
                    break;

                case ContextMenuResult.TroopConfig_SetAuto:
                    this.CurrentTroop.Auto = !this.CurrentTroop.Auto;
                    if (!this.CurrentTroop.Auto)
                    {
                        this.CurrentTroop.CurrentCombatMethod = null;
                        this.CurrentTroop.CurrentStratagem = null;
                        this.CurrentTroop.TargetTroop = null;
                        this.CurrentTroop.TargetArchitecture = null;
                        this.CurrentTroop.AttackDefaultKind = TroopAttackDefaultKind.防最弱;
                        this.CurrentTroop.AttackTargetKind = TroopAttackTargetKind.遇敌;
                        this.CurrentTroop.CastDefaultKind = TroopCastDefaultKind.智最弱;
                        this.CurrentTroop.CastTargetKind = TroopCastTargetKind.可能;
                        break;
                    }
                    if (this.CurrentTroop.BelongedLegion != null)
                    {
                        this.CurrentTroop.BelongedLegion.ResetCoreTroop();
                        this.CurrentTroop.AI();
                    }
                    break;

                case ContextMenuResult.TroopDetail:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Troop, FrameFunction.Browse, true, true, false, false, this.CurrentTroop.GetGameObjectList(), null, "", "");
                    break;

                case ContextMenuResult.TroopPersons:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.Browse, true, true, false, false, this.CurrentTroop.Persons, null, "", "");
                    break;

                case ContextMenuResult.TroopMilitary:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Military, FrameFunction.Browse, true, true, false, false, this.CurrentTroop.Army.GetGameObjectList(), null, "", "");
                    break;

                case ContextMenuResult.TroopCaptive:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Captive, FrameFunction.Browse, true, true, false, false, this.CurrentTroop.Captives, null, "", "");
                    break;

                case ContextMenuResult.TroopTreasure:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Treasure, FrameFunction.Browse, true, true, false, false, this.CurrentTroop.GetTreasureList(), null, "", "");
                    break;

                case ContextMenuResult.Plugins:
                    this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Plugin, FrameFunction.Browse, true, true, false, false, base.PluginList, null, "", "");
                    break;

                case ContextMenuResult.CurrentArchitectureLeftClick:
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentArchitecture);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureLeftClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                    break;

                case ContextMenuResult.CurrentTroopLeftClick:
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentTroop);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("TroopLeftClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                    break;

                case ContextMenuResult.CurrentArchitectureRightClick:
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentArchitecture);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                    break;

                case ContextMenuResult.CurrentTroopRightClick:
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentTroop);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("TroopRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                    break;

                case ContextMenuResult.CurrentRoutewayRightClick:
                    if (!this.Plugins.ContextMenuPlugin.IsShowing)
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentRouteway);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("RoutewayRightClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                    break;
            }
        }

        private void HandleDialogResult(Enum kind)
        {
            switch (((DialogKind)kind))
            {
                case DialogKind.Confirmation:
                    /*
                    switch (this.Plugins.ConfirmationDialogPlugin.Result)
                    {
                    }
                    */  //原程序，由于警告去掉
                    break;
            }
        }

        private void HandleFrameResult(FrameResult result)
        {
            switch (result)
            {
                case FrameResult.OK:
                    this.screenManager.HandleFrameFunction(this.Plugins.GameFramePlugin.Function);

                    
                    break;
                
            }
        }

        private void HandleKey(GameTime gameTime)
        {
            GameDelegates.VoidFunction function = null;
            if (this.currentKey != Keys.None)
            {
                if (!base.KeyState.IsKeyUp(this.currentKey))
                {
                    return;
                }
                this.currentKey = Keys.None;
            }
            if ((base.Scenario.CurrentPlayer != null) && base.Scenario.CurrentPlayer.Controlling)
            {
                if (this.keyState.IsKeyDown(Keys.D1))
                {
                    this.currentKey = Keys.D1;
                    this.DateGo(1);
                }
                else if (this.keyState.IsKeyDown(Keys.D2))
                {
                    this.currentKey = Keys.D2;
                    this.DateGo(2);
                }
                else if (this.keyState.IsKeyDown(Keys.D3))
                {
                    this.currentKey = Keys.D3;
                    this.DateGo(3);
                }
                else if (this.keyState.IsKeyDown(Keys.D4))
                {
                    this.currentKey = Keys.D4;
                    this.DateGo(4);
                }
                else if (this.keyState.IsKeyDown(Keys.D5))
                {
                    this.currentKey = Keys.D5;
                    this.DateGo(5);
                }
                else if (this.keyState.IsKeyDown(Keys.D6))
                {
                    this.currentKey = Keys.D6;
                    this.DateGo(6);
                }
                else if (this.keyState.IsKeyDown(Keys.D7))
                {
                    this.currentKey = Keys.D7;
                    this.DateGo(7);
                }
                else if (this.keyState.IsKeyDown(Keys.D8))
                {
                    this.currentKey = Keys.D8;
                    this.DateGo(8);
                }
                else if (this.keyState.IsKeyDown(Keys.D9))
                {
                    this.currentKey = Keys.D9;
                    this.DateGo(9);
                }
                else if (this.keyState.IsKeyDown(Keys.D0))
                {
                    this.currentKey = Keys.D0;
                    this.DateGo(10);
                }
                else if (this.keyState.IsKeyDown(Keys.F1))
                {
                    this.currentKey = Keys.F1;
                    this.DateGo(30);
                }
                else if (this.keyState.IsKeyDown(Keys.F2))
                {
                    this.currentKey = Keys.F2;
                    this.DateGo(60);
                }
                else if (this.keyState.IsKeyDown(Keys.F3))
                {
                    this.currentKey = Keys.F3;
                    this.DateGo(90);
                }
            }
            if (this.keyState.IsKeyDown(Keys.Space))
            {
                this.currentKey = Keys.Space;
                this.Plugins.DateRunnerPlugin.Run();
            }
            if (this.keyState.IsKeyDown(Keys.LeftAlt) && this.keyState.IsKeyDown(Keys.C))
            {
                this.currentKey = Keys.C;
                this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Faction, FrameFunction.Browse, true, true, true, true, base.Scenario.Factions, base.Scenario.PlayerFactions, "变更控制", "");
                if (function == null)
                {
                    function = delegate
                    {
                        FacilityList list = new FacilityList();
                        foreach (Faction faction in base.Scenario.PlayerFactions)
                        {
                            list.Add(faction);
                        }
                        base.Scenario.SetPlayerFactionList(this.Plugins.TabListPlugin.SelectedItemList as GameObjectList);
                        foreach (Faction faction in list)
                        {
                            if (!base.Scenario.IsPlayer(faction))
                            {
                                faction.EndControl();
                            }
                        }
                        foreach (Faction faction in base.Scenario.PlayerFactions)
                        {
                            if (!list.HasGameObject(faction))
                            {
                                foreach (Routeway routeway in faction.Routeways.GetList())
                                {
                                    if (!routeway.IsInUsing)
                                    {
                                        base.Scenario.RemoveRouteway(routeway);
                                    }
                                }
                            }
                        }
                        if (!base.Scenario.IsPlayer(base.Scenario.CurrentPlayer))
                        {
                            base.Scenario.CurrentPlayer.Passed = true;
                            base.Scenario.CurrentPlayer.Controlling = false;
                            if (!base.Scenario.Factions.HasFactionInQueue(base.Scenario.PlayerFactions))
                            {
                                this.Plugins.DateRunnerPlugin.Reset();
                                this.Plugins.DateRunnerPlugin.RunDays(1);
                            }
                        }
                    };
                }
                this.Plugins.GameFramePlugin.SetOKFunction(function);
            }
        }

        private void HandleLaterMouseEvent(GameTime gameTime)
        {
            if (base.EnableMouseEvent && base.EnableLaterMouseEvent)
            {
                if (!StaticMethods.PointInViewport(new Point(this.mouseState.X, this.mouseState.Y), base.viewportSize))
                {
                    this.UpdateViewMove();
                }
                else
                {
                    this.ResetCurrentStatus();
                    this.CurrentArchitecture = base.Scenario.GetArchitectureByPosition(this.position);
                    this.CurrentTroop = base.Scenario.GetTroopByPosition(this.position);
                    this.CurrentRouteway = base.Scenario.GetRoutewayByPositionAndFaction(this.position, base.Scenario.CurrentPlayer);
                    this.HandleLaterMouseMove();
                    this.HandleLaterMouseScroll();
                    if (this.viewMove == ViewMove.Stop)
                    {
                        this.HandleLaterMouseLeftDown();
                        this.HandleLaterMouseLeftUp();
                        this.HandleLaterMouseRightDown();
                        this.HandleLaterMouseRightUp();
                        this.UpdateConmentText(gameTime);
                        this.UpdateSurvey(gameTime);
                    }
                }
            }
        }

        private void HandleLaterMouseLeftDown()
        {
            if (((this.previousMouseState.LeftButton == ButtonState.Released) && (this.mouseState.LeftButton == ButtonState.Pressed)) && (this.viewMove == ViewMove.Stop))
            {
                if (((GlobalVariables.SkyEye || base.Scenario.NoCurrentPlayer) || base.Scenario.CurrentPlayer.IsPositionKnown(this.position)) && ((this.Plugins.ContextMenuPlugin != null) && (this.PeekUndoneWork().Kind == UndoneWorkKind.None)))
                {
                    if ((((this.CurrentArchitecture != null) && (this.CurrentTroop != null)) && (this.CurrentTroop.BelongedFaction == base.Scenario.CurrentPlayer)) && (this.CurrentArchitecture.BelongedFaction == base.Scenario.CurrentPlayer))
                    {
                        if (!(this.Plugins.ContextMenuPlugin.IsShowing || !base.Scenario.CurrentPlayer.Controlling))
                        {
                            this.Plugins.ContextMenuPlugin.IsShowing = true;
                            this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this);
                            this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureTroopLeftClick");
                            this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                        }
                    }
                    else if ((this.CurrentTroop != null) && (this.CurrentTroop.BelongedFaction == base.Scenario.CurrentPlayer))
                    {
                        if (!this.Plugins.ContextMenuPlugin.IsShowing && base.Scenario.IsPlayerControlling())
                        {
                            this.Plugins.ContextMenuPlugin.IsShowing = true;
                            this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentTroop);
                            this.Plugins.ContextMenuPlugin.SetMenuKindByName("TroopLeftClick");
                            this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                            if (!this.Plugins.ContextMenuPlugin.IsShowing && (this.CurrentTroop.CutRoutewayDays > 0))
                            {
                                this.CurrentTroop.Leader.TextDestinationString = this.CurrentTroop.CutRoutewayDays.ToString();
                                this.Plugins.PersonTextDialogPlugin.SetConfirmationDialog(this.Plugins.ConfirmationDialogPlugin, new GameDelegates.VoidFunction(this.CurrentTroop.StopCutRouteway), null);
                                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(this.CurrentTroop.Leader, this.CurrentTroop.Leader, "StopCutRouteway");
                                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                            }
                        }
                    }
                    else if (((this.CurrentArchitecture != null) && (this.CurrentArchitecture.BelongedFaction == base.Scenario.CurrentPlayer)) && !(this.Plugins.ContextMenuPlugin.IsShowing || !base.Scenario.IsPlayerControlling()))
                    {
                        this.Plugins.ContextMenuPlugin.IsShowing = true;
                        this.Plugins.ContextMenuPlugin.SetCurrentGameObject(this.CurrentArchitecture);
                        this.Plugins.ContextMenuPlugin.SetMenuKindByName("ArchitectureLeftClick");
                        this.Plugins.ContextMenuPlugin.Prepare(this.mouseState.X, this.mouseState.Y, base.viewportSize);
                    }
                }
                if (((base.Scenario.CurrentPlayer != null) && base.Scenario.LoadAndSaveAvail()) && (this.PeekUndoneWork().Kind == UndoneWorkKind.None))
                {
                    //this.DrawingSelector = !this.Plugins.ContextMenuPlugin.IsShowing && !this.Plugins.RoutewayEditorPlugin.IsShowing;
                }
            }
        }

        private void HandleLaterMouseLeftUp()
        {
            if ((this.previousMouseState.LeftButton == ButtonState.Pressed) && (this.mouseState.LeftButton == ButtonState.Released))
            {
            }
        }

        private void HandleLaterMouseMove()
        {
            if ((this.mouseState.X != this.previousMouseState.X) || (this.mouseState.Y != this.previousMouseState.Y))
            {
                this.UpdateViewMove();
                if ((this.mouseState.LeftButton != ButtonState.Pressed) && (this.mouseState.RightButton != ButtonState.Pressed))
                {
                }
            }
        }

        private void HandleLaterMouseRightDown()
        {
            GameDelegates.VoidFunction optionFunction = null;
            if ((this.previousMouseState.RightButton == ButtonState.Released) && (this.mouseState.RightButton == ButtonState.Pressed))
            {
                if ((this.Plugins.OptionDialogPlugin != null) && (GlobalVariables.CurrentMapLayer == MapLayerKind.Routeway))
                {
                    List<Routeway> routewaysByPositionAndFaction = base.Scenario.GetRoutewaysByPositionAndFaction(this.position, base.Scenario.CurrentPlayer);
                    List<Routeway> list2 = new List<Routeway>();
                    foreach (Routeway routeway in routewaysByPositionAndFaction)
                    {
                        if ((routeway.StartArchitecture == null) || ((((routeway.DestinationArchitecture != null) && routeway.StartArchitecture.BelongedSection.AIDetail.AutoRun) && !routeway.Building) && (routeway.LastActivePointIndex < 0)))
                        {
                            list2.Add(routeway);
                        }
                    }
                    foreach (Routeway routeway in list2)
                    {
                        routewaysByPositionAndFaction.Remove(routeway);
                    }
                    if ((routewaysByPositionAndFaction.Count > 1) && !base.Scenario.PositionIsTroop(this.position))
                    {
                        this.Plugins.OptionDialogPlugin.SetStyle("Small");
                        this.Plugins.OptionDialogPlugin.SetTitle("粮道");
                        this.Plugins.OptionDialogPlugin.Clear();
                        this.Plugins.OptionDialogPlugin.SetReturnObjectFunction(new GameDelegates.ObjectFunction(this.RoutewayOptionDialogClickCallback));
                        foreach (Routeway routeway in routewaysByPositionAndFaction)
                        {
                            if (optionFunction == null)
                            {
                                optionFunction = delegate
                                {
                                    this.ContextMenuRightClick();
                                };
                            }
                            this.Plugins.OptionDialogPlugin.AddOption(routeway.DisplayName, routeway, optionFunction);
                        }
                        this.Plugins.OptionDialogPlugin.EndAddOptions();
                        this.Plugins.OptionDialogPlugin.ShowOptionDialog(ShowPosition.Mouse);
                        return;
                    }
                }
                this.ContextMenuRightClick();
            }
        }

        private void HandleLaterMouseRightUp()
        {
            if ((this.previousMouseState.RightButton == ButtonState.Pressed) && (this.mouseState.RightButton == ButtonState.Released))
            {
            }
        }

        private void HandleLaterMouseScroll()
        {
            if ((this.mouseState.ScrollWheelValue != this.previousMouseState.ScrollWheelValue) && (this.oldScrollWheelValue != this.mouseState.ScrollWheelValue))
            {
                float num = this.mouseState.ScrollWheelValue - this.oldScrollWheelValue;
                this.oldScrollWheelValue = this.mouseState.ScrollWheelValue;
                if (num > 0f)
                {
                    num = 0.1f;
                    if (this.mainMapLayer.TileWidth == this.mainMapLayer.tileWidthMax)
                    {
                        return;
                    }
                }
                if (num < 0f)
                {
                    num = -0.1f;
                    if (this.mainMapLayer.TileWidth == this.mainMapLayer.tileWidthMin)
                    {
                        return;
                    }
                }
                int tileWidthMax = (int)((1f + num) * this.mainMapLayer.TileWidth);
                if (tileWidthMax > this.mainMapLayer.tileWidthMax)
                {
                    tileWidthMax = this.mainMapLayer.tileWidthMax;
                }
                else if (tileWidthMax < this.mainMapLayer.tileWidthMin)
                {
                    tileWidthMax = this.mainMapLayer.tileWidthMin;
                }
                int tileWidth = this.mainMapLayer.TileWidth;
                this.mainMapLayer.TileWidth = tileWidthMax;
                num = (((float)tileWidthMax) / ((float)tileWidth)) - 1f;
                int num4 = this.mainMapLayer.LeftEdge + ((int)(num * (this.mainMapLayer.LeftEdge - this.mouseState.X)));
                int num5 = this.mainMapLayer.TopEdge + ((int)(num * (this.mainMapLayer.TopEdge - this.mouseState.Y)));
                if (((((this.viewportSize.X - num4) <= this.mainMapLayer.TotalTileWidth) && (num4 <= 0)) && ((this.viewportSize.Y - num5) <= this.mainMapLayer.TotalTileHeight)) && (num5 <= 0))
                {
                    this.mainMapLayer.LeftEdge = num4;
                    this.mainMapLayer.TopEdge = num5;
                }
                else
                {
                    this.mainMapLayer.TileWidth = tileWidth;
                }
                this.ResetScreenEdge();
                this.mainMapLayer.ReCalculateTileDestination();
                base.Scenario.TroopAnimations.UpdateDirectionAnimations(this.mainMapLayer.TileWidth);
                this.Plugins.AirViewPlugin.ResetFrameSize(base.viewportSize, this.mainMapLayer.TotalMapSize);
                this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
            }
        }

        private void HandlePushSelectingUndoneWork(Enum kind)
        {
            switch (((SelectingUndoneWorkKind)kind))
            {
                case SelectingUndoneWorkKind.ArchitectureAvailableContactArea:
                    if ((this.CurrentArchitecture != null) && (this.CurrentMilitary != null))
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.ArchitectureAvailableContactArea;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetAllAvailableArea(false);
                        this.CurrentMilitary.ModifyAreaByTerrainAdaptablity(this.selectingLayer.Area);
                    }
                    break;

                case SelectingUndoneWorkKind.ConvincePersonPosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.ConvincePersonPosition;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetConvincePersonArchitectureArea();
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = true;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.InformationPosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.InformationPosition;
                        this.selectingLayer.Area = new GameArea();
                        this.selectingLayer.EffectingAreaRadius = this.CurrentPerson.RadiusIncrementOfInformation + this.CurrentPerson.CurrentInformationKind.Radius;
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = false;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.SpyPosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.SpyPosition;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetSpyArchitectureArea();
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = true;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.DestroyPosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.DestroyPosition;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetDestroyArchitectureArea();
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = true;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.InstigatePosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.InstigatePosition;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetInstigateArchitectureArea();
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = true;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.GossipPosition:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.GossipPosition;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetGossipArchitectureArea();
                        this.selectingLayer.ShowComment = true;
                        this.selectingLayer.SingleWay = true;
                        this.selectingLayer.FromArea = this.CurrentArchitecture.ArchitectureArea;
                    }
                    break;

                case SelectingUndoneWorkKind.TroopDestination:
                    if (this.CurrentTroop != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.TroopDestination;
                        this.selectingLayer.Area = this.CurrentTroop.GetDayArea(1);
                    }
                    break;

                case SelectingUndoneWorkKind.SelectorTroopsDestination:
                    if (this.SelectorTroops.Count > 0)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.SelectorTroopsDestination;
                        this.selectingLayer.Area = new GameArea();
                    }
                    break;

                case SelectingUndoneWorkKind.TroopTarget:
                    if (this.CurrentTroop != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.TroopTarget;
                        if (this.CurrentTroop.CurrentCombatMethod != null)
                        {
                            this.selectingLayer.Area = this.CurrentTroop.GetTargetArea(false, this.CurrentTroop.CurrentCombatMethod.ArchitectureTarget);
                        }
                        else if (this.CurrentTroop.CurrentStratagem != null)
                        {
                            this.selectingLayer.Area = this.CurrentTroop.GetTargetArea(this.CurrentTroop.CurrentStratagem.Friendly, this.CurrentTroop.CurrentStratagem.ArchitectureTarget);
                        }
                        else
                        {
                            this.selectingLayer.Area = this.CurrentTroop.GetTargetArea(false, true);
                        }
                    }
                    break;

                case SelectingUndoneWorkKind.TroopInvestigatePosition:
                    if (this.CurrentTroop != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.TroopInvestigatePosition;
                        this.selectingLayer.Area = base.Scenario.GetAreaWithinDistance(this.CurrentTroop.Position, this.CurrentTroop.ViewRadius + 1, false);
                        this.selectingLayer.EffectingAreaRadius = this.CurrentTroop.InvestigateRadius;
                    }
                    break;

                case SelectingUndoneWorkKind.TroopSetFirePosition:
                    if (this.CurrentTroop != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.TroopSetFirePosition;
                        this.selectingLayer.Area = this.CurrentTroop.GetSetFireArea();
                    }
                    break;

                case SelectingUndoneWorkKind.ArchitectureRoutewayStartPoint:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.ArchitectureRoutewayStartPoint;
                        this.selectingLayer.Area = this.CurrentArchitecture.GetRoutewayStartPoints();
                    }
                    break;

                case SelectingUndoneWorkKind.RoutewayPointShortestNormal:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.RoutewayPointShortestNormal;
                        this.selectingLayer.Area = new GameArea();
                    }
                    break;

                case SelectingUndoneWorkKind.RoutewayPointShortestNoWater:
                    if (this.CurrentArchitecture != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.RoutewayPointShortestNoWater;
                        this.selectingLayer.Area = new GameArea();
                    }
                    break;
            }
            this.selectingLayer.TryToShow();
        }

        private void HandleSelectingResult(Enum kind)
        {
            Architecture architecture2;
            Routeway routeway;


            switch (((SelectingUndoneWorkKind)kind))
            {
                case SelectingUndoneWorkKind.None:
                case SelectingUndoneWorkKind.SearchPosition:
                    return;

                case SelectingUndoneWorkKind.ArchitectureAvailableContactArea:
                    if (!this.selectingLayer.Canceled)
                    {
                        this.screenManager.SetCreatingTroopPosition(this.selectingLayer.SelectedPoint);
                    }
                    return;

                case SelectingUndoneWorkKind.ConvincePersonPosition:
                    if (!this.selectingLayer.Canceled && (this.CurrentPersons.Count > 0))
                    {
                        Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.selectingLayer.SelectedPoint);
                        if (architectureByPosition != null)
                        {
                            this.CurrentArchitecture = architectureByPosition;
                            foreach (Person person in this.CurrentPersons)
                            {
                                person.OutsideDestination = new Point?(this.selectingLayer.SelectedPoint);
                            }
                            this.ShowTabListInFrame(UndoneWorkKind.Frame, FrameKind.Person, FrameFunction.GetConvinceDestinationPerson, false, true, true, false, architectureByPosition.GetConvinceDestinationPersonList((this.CurrentPersons[0] as Person).BelongedFaction), null, "说服", "Personal");
                        }
                    }
                    return;

                case SelectingUndoneWorkKind.InformationPosition:
                    if (!this.selectingLayer.Canceled)
                    {
                        this.CurrentPerson.GoForInformation(this.selectingLayer.SelectedPoint);
                        base.PlayNormalSound("GameSound/Tactics/Outside.wav");
                    }
                    return;

                case SelectingUndoneWorkKind.SpyPosition:
                    if (!this.selectingLayer.Canceled)
                    {
                        foreach (Person person in this.CurrentPersons)
                        {
                            person.GoForSpy(this.selectingLayer.SelectedPoint);
                        }
                        base.PlayNormalSound("GameSound/Tactics/Outside.wav");
                    }
                    return;

                case SelectingUndoneWorkKind.DestroyPosition:
                    if (!this.selectingLayer.Canceled)
                    {
                        foreach (Person person in this.CurrentPersons)
                        {
                            person.GoForDestroy(this.selectingLayer.SelectedPoint);
                        }
                        base.PlayNormalSound("GameSound/Tactics/Outside.wav");
                    }
                    return;

                case SelectingUndoneWorkKind.InstigatePosition:
                    if (!this.selectingLayer.Canceled)
                    {
                        foreach (Person person in this.CurrentPersons)
                        {
                            person.GoForInstigate(this.selectingLayer.SelectedPoint);
                        }
                        base.PlayNormalSound("GameSound/Tactics/Outside.wav");
                    }
                    return;

                case SelectingUndoneWorkKind.GossipPosition:
                    if (!this.selectingLayer.Canceled)
                    {
                        foreach (Person person in this.CurrentPersons)
                        {
                            person.GoForGossip(this.selectingLayer.SelectedPoint);
                        }
                        base.PlayNormalSound("GameSound/Tactics/Outside.wav");
                    }
                    return;

                case SelectingUndoneWorkKind.TroopDestination:
                    if (this.selectingLayer.Canceled)
                    {
                        return;
                    }
                    architecture2 = base.Scenario.GetArchitectureByPosition(this.selectingLayer.SelectedPoint);
                    this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;
                    if (architecture2 != null)
                    {
                        this.CurrentTroop.WillArchitecture = architecture2;
                        this.CurrentTroop.BelongedLegion.WillArchitecture = architecture2;
                        if (this.CurrentTroop.BelongedFaction.IsFriendly(architecture2.BelongedFaction))
                        {
                            this.CurrentTroop.BelongedLegion.Kind = LegionKind.Defensive;
                            break;
                        }
                        this.CurrentTroop.BelongedLegion.Kind = LegionKind.Offensive;
                    }
                    this.CurrentTroop.Operated = true;
                    break;

                case SelectingUndoneWorkKind.SelectorTroopsDestination:
                    if (!this.selectingLayer.Canceled)
                    {
                        architecture2 = base.Scenario.GetArchitectureByPosition(this.selectingLayer.SelectedPoint);
                        foreach (Troop troop in this.SelectorTroops)
                        {
                            troop.Operated = true;
                            if (architecture2 != null)
                            {
                                troop.WillArchitecture = architecture2;
                                troop.BelongedLegion.WillArchitecture = architecture2;
                            }
                            troop.RealDestination = this.selectingLayer.SelectedPoint;
                            if (!((architecture2 == null) || troop.BelongedFaction.IsFriendly(architecture2.BelongedFaction)))
                            {
                                troop.BelongedLegion.Kind = LegionKind.Offensive;
                            }
                            else
                            {
                                troop.BelongedLegion.Kind = LegionKind.Defensive;
                            }
                            this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "Destination");
                        }
                    }
                    this.SelectorTroops.Clear();
                    return;

                case SelectingUndoneWorkKind.TroopTarget:
                    {
                        if (this.selectingLayer.Canceled)
                        {
                            this.CurrentTroop.AttackTargetKind = TroopAttackTargetKind.遇敌;
                            if (this.CurrentTroop.CurrentStratagem != null)
                            {
                                this.CurrentTroop.CastTargetKind = TroopCastTargetKind.可能;
                            }
                            return;
                        }
                        Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        if ((troopByPositionNoCheck == null) || !this.CurrentTroop.BelongedFaction.IsPositionKnown(this.selectingLayer.SelectedPoint))
                        {
                            this.CurrentTroop.TargetTroop = null;
                        }
                        else
                        {
                            this.CurrentTroop.TargetTroop = troopByPositionNoCheck;
                        }
                        Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        if (architectureByPositionNoCheck != null)
                        {
                            this.CurrentTroop.TargetArchitecture = architectureByPositionNoCheck;
                        }
                        else
                        {
                            this.CurrentTroop.TargetArchitecture = null;
                        }
                        this.Plugins.PersonBubblePlugin.AddPerson(this.CurrentTroop.Leader, this.CurrentTroop.Position, "Target");
                        return;
                    }
                case SelectingUndoneWorkKind.TroopInvestigatePosition:
                    if (this.selectingLayer.Canceled)
                    {
                        this.CurrentTroop.CurrentStratagem = null;
                        return;
                    }
                    this.CurrentTroop.SelfCastPosition = this.selectingLayer.SelectedPoint;
                    return;

                case SelectingUndoneWorkKind.TroopSetFirePosition:
                    if (this.selectingLayer.Canceled)
                    {
                        this.CurrentTroop.CurrentStratagem = null;
                        return;
                    }
                    this.CurrentTroop.SelfCastPosition = this.selectingLayer.SelectedPoint;
                    return;

                case SelectingUndoneWorkKind.ArchitectureRoutewayStartPoint:
                    if (!this.selectingLayer.Canceled)
                    {
                        routeway = this.CurrentArchitecture.CreateRouteway(this.selectingLayer.SelectedPoint);
                        if (routeway != null)
                        {
                            this.Plugins.RoutewayEditorPlugin.SetRouteway(routeway);
                            this.Plugins.RoutewayEditorPlugin.IsShowing = true;
                        }
                    }
                    return;

                case SelectingUndoneWorkKind.RoutewayPointShortestNormal:
                    if (!this.selectingLayer.Canceled)
                    {
                        routeway = this.CurrentArchitecture.BuildShortestRouteway(this.selectingLayer.SelectedPoint, false);
                        if (routeway != null)
                        {
                            routeway.Building = true;
                            GlobalVariables.CurrentMapLayer = MapLayerKind.Routeway;
                        }
                    }
                    return;

                case SelectingUndoneWorkKind.RoutewayPointShortestNoWater:
                    if (!this.selectingLayer.Canceled)
                    {
                        routeway = this.CurrentArchitecture.BuildShortestRouteway(this.selectingLayer.SelectedPoint, true);
                        if (routeway != null)
                        {
                            routeway.Building = true;
                            GlobalVariables.CurrentMapLayer = MapLayerKind.Routeway;
                        }
                    }
                    return;

                default:
                    return;
            }
            this.Plugins.PersonBubblePlugin.AddPerson(this.CurrentTroop.Leader, this.CurrentTroop.Position, "Destination");
        }

        public override void Initialize()
        {
            base.Initialize();
            this.Plugins.InitializePlugins(this);
            this.mainMapLayer.Initialize(base.Scenario, this);
            if (base.LoadScenarioInInitialization)
            {
                this.LoadScenario(base.InitializationFileName);
                base.Scenario.InitializeScenarioPlayerFactions(base.InitializationFactionIDs);
                if (base.Scenario.PlayerFactions.Count > 0)
                {
                    foreach (Faction faction in base.Scenario.PlayerFactions)
                    {
                        if (faction.FirstSection != null)
                        {
                            //faction.FirstSection.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(0, false, false, false, false, false)[0] as SectionAIDetail;
                            faction.FirstSection.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, false, false, false, false, false)[0] as SectionAIDetail;

                        }
                    }
                    this.JumpTo((base.Scenario.PlayerFactions[0] as Faction).Leader.Position);        //地图跳到玩家势力的首领处
                    base.Scenario.CurrentPlayer = base.Scenario.PlayerFactions[0] as Faction;
                }
            }
            else
            {
                this.LoadFileName = base.InitializationFileName;
                this.LoadGameFromDisk();
            }
            this.architectureLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.mapVeilLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.troopLayer.Initialize(this.mainMapLayer, base.Scenario, this);
            this.selectingLayer.Initialize(this.mainMapLayer, this);
            this.tileAnimationLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.routewayLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.screenManager.Initialize(base.Scenario);

            this.Showyoucelan(UndoneWorkKind.None, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "", "");
            this.Plugins.youcelanPlugin.IsShowing = true;


        }

        public override void JumpTo(Point mapPosition)    //地图跳转
        {
            int num = (this.mainMapLayer.TileWidth * mapPosition.X) + (this.mainMapLayer.TileWidth / 2);
            int num2 = (this.mainMapLayer.TileHeight * mapPosition.Y) + (this.mainMapLayer.TileHeight / 2);
            this.mainMapLayer.LeftEdge = (this.viewportSize.X / 2) - num;
            if (this.mainMapLayer.LeftEdge > 0)
            {
                this.mainMapLayer.LeftEdge = 0;
            }
            else if (this.mainMapLayer.LeftEdge < (this.viewportSize.X - this.mainMapLayer.TotalTileWidth))
            {
                this.mainMapLayer.LeftEdge = this.viewportSize.X - this.mainMapLayer.TotalTileWidth;
            }
            this.mainMapLayer.TopEdge = (this.viewportSize.Y / 2) - num2;
            if (this.mainMapLayer.TopEdge > 0)
            {
                this.mainMapLayer.TopEdge = 0;
            }
            else if (this.mainMapLayer.TopEdge < (this.viewportSize.Y - this.mainMapLayer.TotalTileHeight))
            {
                this.mainMapLayer.TopEdge = this.viewportSize.Y - this.mainMapLayer.TotalTileHeight;
            }
            this.ResetScreenEdge();
            this.mainMapLayer.ReCalculateTileDestination();
            this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
        }

        public bool LoadAndSaveAvail()
        {
            return base.Scenario.LoadAndSaveAvail();
        }

        public void LoadCommonData()
        {
            string path = "GameData/Common/CommonData.mdb";
            if (!File.Exists(path))
            {
                throw new Exception(path + " .File Does Not Exist.");
            }
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = path,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            base.Scenario.GameCommonData.LoadFromDatabase(builder.ConnectionString);
        }

        protected override void LoadContent()
        {


            base.LoadContent();
            this.Textures.LoadTextures(base.spriteBatch.GraphicsDevice, base.Scenario);

            base.DefaultMouseArrowTexture = this.Textures.MouseArrowTextures[0];
        }

        public override void LoadGame()
        {
            this.Plugins.OptionDialogPlugin.SetStyle("SaveAndLoad");
            this.Plugins.OptionDialogPlugin.SetTitle("读取进度");
            this.Plugins.OptionDialogPlugin.Clear();
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save01.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition01));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save02.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition02));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save03.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition03));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save04.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition04));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save05.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition05));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save06.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition06));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save07.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition07));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save08.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition08));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save09.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition09));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save10.mdb"), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition10));
            this.Plugins.OptionDialogPlugin.EndAddOptions();
            this.Plugins.OptionDialogPlugin.ShowOptionDialog(ShowPosition.Center);
        }

        public void LoadGameFromDisk()
        {
            base.Scenario.EnableLoadAndSave = false;
            if (!File.Exists("GameData/Save/" + this.LoadFileName))
            {
                base.Scenario.EnableLoadAndSave = true;
            }
            else
            {
                this.Plugins.DateRunnerPlugin.Reset();
                this.Plugins.GameRecordPlugin.Clear();
                this.Plugins.GameRecordPlugin.RemoveDisableRects();
                this.Plugins.AirViewPlugin.RemoveDisableRects();
                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = "GameData/Save/" + this.LoadFileName,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                base.Scenario.LoadSaveFileFromDatabase(builder.ConnectionString);
                base.Scenario.EnableLoadAndSave = true;
            }
        }

        private void LoadGameFromPosition01()
        {
            this.LoadFileName = "Save01.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition02()
        {
            this.LoadFileName = "Save02.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition03()
        {
            this.LoadFileName = "Save03.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition04()
        {
            this.LoadFileName = "Save04.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition05()
        {
            this.LoadFileName = "Save05.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition06()
        {
            this.LoadFileName = "Save06.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition07()
        {
            this.LoadFileName = "Save07.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition08()
        {
            this.LoadFileName = "Save08.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition09()
        {
            this.LoadFileName = "Save09.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        private void LoadGameFromPosition10()
        {
            this.LoadFileName = "Save10.mdb";
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
        }

        public bool LoadScenario(string filename)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            return base.Scenario.LoadGameScenarioFromDatabase(builder.ConnectionString);
        }

        private bool MoveTheTroops(GameTime gameTime)
        {
            if (!base.Scenario.Threading)
            {
                if (!base.Scenario.Animating)
                {
                    base.Scenario.Troops.CurrentQueueTroopMove();
                    if (base.Scenario.Troops.TotallyEmpty)
                    {
                        return false;
                    }
                }
                else if (gameTime.ElapsedRealTime.TotalMilliseconds > GlobalVariables.MaxTimeOfAnimationFrame)
                {
                    base.Scenario.Troops.StepAnimationIndex(1);
                }
            }
            return true;
        }

        public void PauseMusic()
        {
            if (GlobalVariables.PlayMusic && (this.Player.playState == WMPPlayState.wmppsPlaying))
            {
                this.Player.pause();
            }
        }

        public override void PersonBeAwardedTreasure(Person person, Treasure t)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = t.Name;
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonBeAwardedTreasure");
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                

            }
        }

        public override void xianshishijiantupian(Troop troop, Architecture architecture)
        {

            if (troop.BelongedFaction == base.Scenario.CurrentPlayer || architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {



                troop.BelongedFaction.TextResultString = architecture.Name;

                this.Plugins.tupianwenziPlugin.SetGameObjectBranch(troop.BelongedFaction, troop.BelongedFaction.Leader, "zhanling");
                this.Plugins.tupianwenziPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.tupianwenziPlugin.IsShowing = true;
                this.PauseMusic();
                this.tufashijianzantingyinyue = true;

            }
        }


        public override void PersonBeConfiscatedTreasure(Person person, Treasure t)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextResultString = t.Name;
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonBeConfiscatedTreasure");
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }


        }







        public override void PersonBeKilled(Person person, Architecture location)
        {
            location.TextDestinationString = person.Name;
            this.Plugins.GameRecordPlugin.AddBranch(location, "PersonBeKilled", location.Position);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }
            this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, location, "PersonBeKilled");
            this.Plugins.PersonTextDialogPlugin.IsShowing = true;
        }

        public override void PersonChangeLeader(Faction faction, Person leader, bool changeName, string oldName)
        {
            if (!changeName)
            {
                leader.TextDestinationString = oldName;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(leader, leader, "FactionChangeLeaderKeepName");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
            else
            {
                leader.TextDestinationString = oldName;
                leader.TextResultString = faction.Name;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(leader, leader, "FactionChangeLeaderChangeName");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonConvinceFailed(Person source, Person destination)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(source.BelongedFaction)) || base.Scenario.IsCurrentPlayer(destination.BelongedFaction))
            {
                source.TextDestinationString = destination.Name;
                this.Plugins.GameRecordPlugin.AddBranch(source, "PersonConvinceFailed", source.OutsideDestination.Value);
            }
        }

        public override void PersonConvinceSuccess(Person source, Person destination, Faction oldFaction)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(source.BelongedFaction)) || base.Scenario.IsCurrentPlayer(oldFaction)) || GlobalVariables.SkyEye)
            {
                source.TextDestinationString = destination.Name;
                this.Plugins.GameRecordPlugin.AddBranch(source, "PersonConvinceSuccess", source.OutsideDestination.Value);
            }
        }

        public override void PersonDeath(Person person, Architecture location)
        {
            location.TextDestinationString = person.Name;
            this.Plugins.GameRecordPlugin.AddBranch(location, "PersonDeath", location.Position);
            Person neutralPerson = base.Scenario.NeutralPerson;
            if (neutralPerson == null)
            {
                if (base.Scenario.CurrentPlayer != null)
                {
                    neutralPerson = base.Scenario.CurrentPlayer.Leader;
                }
                else
                {
                    if (base.Scenario.Factions.Count <= 0)
                    {
                        return;
                    }
                    neutralPerson = (base.Scenario.Factions[0] as Faction).Leader;
                }
            }
            this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, location, "PersonDeath");
            this.Plugins.PersonTextDialogPlugin.IsShowing = true;
        }

        public override void PersonDeathChangeFaction(Person dead, Person leader, string oldName)
        {
            leader.BelongedFaction.TextDestinationString = oldName;
            leader.BelongedFaction.TextResultString = leader.BelongedFaction.Name;
            this.Plugins.GameRecordPlugin.AddBranch(leader.BelongedFaction, "FactionLeaderDeathFactionChange", leader.BelongedFaction.Capital.Position);
            leader.BelongedFaction.TextResultString = dead.RespectfulName;
            this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
            this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(leader, leader.BelongedFaction, "FactionLeaderDeathChangeFaction");
            this.Plugins.PersonTextDialogPlugin.IsShowing = true;
        }

        public override void PersonDestroyFailed(Person person, Architecture architecture)
        {
            if (person.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonDestroyArchitectureFailed", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureDestroyedFailed", architecture.Position);
            }
        }

        public override void PersonDestroySuccess(Person person, Architecture architecture, int down)
        {
            if ((person.BelongedFaction == base.Scenario.CurrentPlayer) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonDestroyArchitectureSuccess", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                architecture.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureDestroyedSuccess", architecture.Position);
            }
        }

        public override void PersonGossipFailed(Person person, Architecture architecture)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction))
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonGossipFailed", person.OutsideDestination.Value);
            }
        }

        public override void PersonGossipSuccess(Person person, Architecture architecture)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || base.Scenario.IsCurrentPlayer(architecture.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonGossipSuccess", person.OutsideDestination.Value);
            }
        }

        public override void PersonInformationObtained(Person person, Information information)
        {
            if (base.Scenario.CurrentPlayer == person.BelongedFaction)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(person, person.Position, "InformationObtained");
            }
        }

        public override void PersonInstigateFailed(Person person, Architecture architecture)
        {
            if (person.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonInstigateArchitectureFailed", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureInstigatedFailed", architecture.Position);
            }
        }

        public override void PersonInstigateSuccess(Person person, Architecture architecture, int down)
        {
            if ((person.BelongedFaction == base.Scenario.CurrentPlayer) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonInstigateArchitectureSuccess", architecture.Position);
            }
            else if (architecture.BelongedFaction == base.Scenario.CurrentPlayer)
            {
                architecture.TextResultString = down.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureInstigatedSuccess", architecture.Position);
            }
        }

        public override void PersonLeave(Person person, Architecture location)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(location.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                location.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(location, "PersonLeave", location.Position);
                person.TextDestinationString = location.BelongedFaction.Name;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonLeave");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonSearchFinished(Person person, Architecture architecture, SearchResultPack resultPack)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                switch (resultPack.Result)
                {
                    case SearchResult.资金:
                        person.TextResultString = resultPack.Number.ToString();
                        this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFundFound");
                        break;

                    case SearchResult.粮草:
                        person.TextResultString = resultPack.Number.ToString();
                        this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchFoodFound");
                        break;

                    case SearchResult.技巧:
                        person.TextResultString = resultPack.Number.ToString();
                        this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchTechniqueFound");
                        break;

                    case SearchResult.间谍:
                        person.TextResultString = resultPack.FoundPerson.Name;
                        this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchSpyFound");
                        this.Plugins.GameRecordPlugin.AddBranch(person, "SearchSpyFound", person.Position);
                        break;

                    case SearchResult.隐士:
                        person.TextResultString = resultPack.FoundPerson.Name;
                        this.Plugins.PersonBubblePlugin.AddPerson(person, architecture.Position, "SearchPersonFound");
                        this.Plugins.GameRecordPlugin.AddBranch(person, "SearchPersonFound", person.Position);
                        break;
                }
            }
        }

        public override void PersonShowMessage(Person person, PersonMessage message)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) && (message is SpyMessage))
            {
                SpyMessage gameObject = message as SpyMessage;
                switch (gameObject.Kind)
                {
                    case SpyMessageKind.NewMilitary:
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewMilitary");
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.MilitaryScale:
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageMilitaryScale");
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.NewFacility:
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewFacility");
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.NewTroop:
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageNewTroop");
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                        break;

                    case SpyMessageKind.HireNewPerson:
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, gameObject, "SpyMessageHireNewPerson");
                        this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                        this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                        break;
                }
            }
        }

        public override void PersonSpyFailed(Person person, Architecture architecture)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                person.TextDestinationString = architecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonSpyFailed", person.OutsideDestination.Value);
            }
        }

        public override void PersonSpyFound(Person person, Person spy)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(spy.BelongedFaction))
            {
                spy.TextDestinationString = person.TargetArchitecture.Name;
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(spy, spy, "PersonSpyFound");
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonSpySuccess(Person person, Architecture architecture)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = architecture.Name;
                person.TextResultString = person.SpyDays.ToString();
                this.Plugins.GameRecordPlugin.AddBranch(person, "PersonSpySuccess", person.OutsideDestination.Value);
            }
        }

        public override void PersonStudySkillFinished(Person person, string skillString, bool success)
        {
            if ((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction))
            {
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    person.TextDestinationString = skillString;
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudySkillSuccess");
                }
                else
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudySkillFailed");
                }
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonStudyStuntFinished(Person person, Stunt stunt, bool success)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = stunt.Name;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudyStuntSuccess");
                }
                else
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudyStuntFailed");
                }
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonStudyTitleFinished(Person person, Title title, bool success)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = title.Name;
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                if (success)
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudyTitleSuccess");
                }
                else
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonStudyTitleFailed");
                }
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void PersonTreasureFound(Person person, Treasure treasure)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(person.BelongedFaction)) || GlobalVariables.SkyEye)
            {
                person.TextDestinationString = person.TargetArchitecture.Name;
                person.TextResultString = treasure.Name;
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(person, person, "PersonTreasureFound");
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                this.Plugins.GameRecordPlugin.AddBranch(person, "SearchTreasureFound", person.Position);
            }
        }

        private void Player_PlayStateChange(int NewState)
        {
            if (GlobalVariables.PlayMusic && (NewState == 1))
            {
                this.Player.play();
            }
        }

        public override void PlayMusic(string musicFileLocation)
        {
            if (GlobalVariables.PlayMusic && File.Exists(musicFileLocation))
            {
                this.Player.URL = musicFileLocation;
            }
        }

        public override UndoneWorkItem PopUndoneWork()
        {
            UndoneWorkItem item = base.PopUndoneWork();
            if (this.PeekUndoneWork().Kind == UndoneWorkKind.None)
            {
                this.Plugins.ToolBarPlugin.Enabled = true;
            }
            base.previousMouseState = base.mouseState;
            switch (item.Kind)
            {

                case UndoneWorkKind.ContextMenu:
                    this.HandleContextMenuResult(this.Plugins.ContextMenuPlugin.Result);
                    this.gengxinyoucelan(); 
                    break;

                case UndoneWorkKind.Frame:
                    this.HandleFrameResult(this.Plugins.GameFramePlugin.Result);


                    this.gengxinyoucelan(); 

                    break;

                case UndoneWorkKind.Dialog:
                    this.HandleDialogResult(item.SubKind);
                    break;

                case UndoneWorkKind.SubDialog:
                    break;

                case UndoneWorkKind.Selecting:
                    this.HandleSelectingResult(item.SubKind);
                    this.gengxinyoucelan(); 

                    break;
            }
            if (this.tufashijianzantingyinyue && this.Plugins.tupianwenziPlugin.IsShowing == false)
            {
                this.ResumeMusic();
                this.tufashijianzantingyinyue = false;
            }
            return item;
        }

        public override void PushUndoneWork(UndoneWorkItem undoneWork)
        {
            base.PushUndoneWork(undoneWork);
            if (this.PeekUndoneWork().Kind != UndoneWorkKind.None)
            {
                this.Plugins.ToolBarPlugin.Enabled = false;
            }
            switch (undoneWork.Kind)
            {
                case UndoneWorkKind.Selecting:
                    this.HandlePushSelectingUndoneWork(undoneWork.SubKind);
                    break;
            }
        }

        public void RefreshDisableRects()
        {
            base.ClearDisableRects();
            if (this.Plugins.AirViewPlugin.IsMapShowing)
            {
                this.Plugins.AirViewPlugin.ResetMapPosition();
                this.Plugins.AirViewPlugin.AddDisableRects();
            }
            if (this.Plugins.GameRecordPlugin.IsRecordShowing)
            {
                this.Plugins.GameRecordPlugin.ResetRecordShowPosition();
                this.Plugins.GameRecordPlugin.AddDisableRects();
            }
            if (this.Plugins.RoutewayEditorPlugin.IsShowing)
            {
                this.Plugins.RoutewayEditorPlugin.AddDisableRects();
            }
            if (this.Plugins.MapViewSelectorPlugin.IsShowing)
            {
                this.Plugins.MapViewSelectorPlugin.AddDisableRects();
            }
        }

        private void ResetCurrentStatus()
        {
            this.lastPosition = this.position;
            this.position = this.mainMapLayer.TranslateCoordinateToTilePosition(this.mouseState.X, this.mouseState.Y);
        }

        public override void ResetMouse()
        {
            base.MouseArrowTexture = base.DefaultMouseArrowTexture;
            this.viewMove = ViewMove.Stop;
        }

        private void ResetScreenEdge()
        {
            this.TopLeftPosition.X = -this.mainMapLayer.LeftEdge / base.Scenario.ScenarioMap.TileWidth;
            this.TopLeftPosition.Y = -this.mainMapLayer.TopEdge / base.Scenario.ScenarioMap.TileHeight;
            this.BottomRightPosition.X = (this.viewportSize.X - this.mainMapLayer.LeftEdge) / base.Scenario.ScenarioMap.TileWidth;
            this.BottomRightPosition.Y = (this.viewportSize.Y - this.mainMapLayer.TopEdge) / base.Scenario.ScenarioMap.TileHeight;
        }

        private void ResetTiles()
        {
            if (this.mainMapLayer.mainMap != null)
            {
                if (this.mainMapLayer.TotalTileWidth < this.viewportSize.X)
                {
                    this.mainMapLayer.TileWidth = (this.viewportSize.X / this.mainMapLayer.mainMap.MapDimensions.X) + (this.mainMapLayer.tileWidthMin / 5);
                }
                if (this.mainMapLayer.TotalTileHeight < this.viewportSize.Y)
                {
                    this.mainMapLayer.TileWidth = (this.viewportSize.Y / this.mainMapLayer.mainMap.MapDimensions.Y) + (this.mainMapLayer.tileWidthMin / 5);
                }
            }
        }

        public void ResumeMusic()
        {
            if (GlobalVariables.PlayMusic && (this.Player.playState == WMPPlayState.wmppsPaused))
            {
                this.Player.play();
            }
        }

        private void RoutewayOptionDialogClickCallback(object obj)
        {
            this.CurrentRouteway = obj as Routeway;
        }

        private bool RunTheFactions(GameTime gameTime)
        {
            base.Scenario.Factions.RunQueue();
            if (base.Scenario.Factions.QueueEmpty)
            {
                return false;
            }
            return true;
        }

        public override void SaveGame()
        {
            this.Plugins.OptionDialogPlugin.SetStyle("SaveAndLoad");
            this.Plugins.OptionDialogPlugin.SetTitle("存储进度");
            this.Plugins.OptionDialogPlugin.Clear();
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save01.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition01));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save02.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition02));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save03.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition03));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save04.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition04));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save05.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition05));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save06.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition06));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save07.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition07));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save08.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition08));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save09.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition09));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save10.mdb"), null, new GameDelegates.VoidFunction(this.SaveGameToPosition10));
            this.Plugins.OptionDialogPlugin.EndAddOptions();
            this.Plugins.OptionDialogPlugin.ShowOptionDialog(ShowPosition.Center);
        }

        public void SaveGameToDisk()
        {
            base.Scenario.EnableLoadAndSave = false;
            if (!Directory.Exists("GameData/Save/"))
            {
                Directory.CreateDirectory("GameData/Save/");
            }
            string path = "GameData/Save/" + this.SaveFileName;
            if (File.Exists(path))
            {
            }
            File.Copy("GameData/Common/SaveTemplate.mdb", path, true);
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = path,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            base.Scenario.ScenarioMap.JumpPosition = this.mainMapLayer.GetCurrentScreenCenter(base.viewportSize);
            if (!base.Scenario.SaveGameScenarioToDatabase(builder.ConnectionString))
            {
                File.Delete(path);
            }
            base.Scenario.EnableLoadAndSave = true;
        }

        private void SaveGameToPosition01()
        {
            this.SaveFileName = "Save01.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition02()
        {
            this.SaveFileName = "Save02.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition03()
        {
            this.SaveFileName = "Save03.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition04()
        {
            this.SaveFileName = "Save04.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition05()
        {
            this.SaveFileName = "Save05.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition06()
        {
            this.SaveFileName = "Save06.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition07()
        {
            this.SaveFileName = "Save07.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition08()
        {
            this.SaveFileName = "Save08.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition09()
        {
            this.SaveFileName = "Save09.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void SaveGameToPosition10()
        {
            this.SaveFileName = "Save10.mdb";
            Thread thread = new Thread(new ThreadStart(this.SaveGameToDisk));
            thread.Start();
            thread.Join();
        }

        private void Scenario_OnAfterLoadScenario(GameScenario scenario)
        {
            if (this.mainMapLayer.mainMap != null)
            {
                this.mainMapLayer.PrepareMap();
                this.UpdateViewport();
                this.ResetScreenEdge();
                this.mainMapLayer.ReCalculateTileDestination();
                this.JumpTo(this.mainMapLayer.mainMap.JumpPosition);
            }
            if (this.Plugins.GameRecordPlugin.IsRecordShowing)
            {
                this.Plugins.GameRecordPlugin.AddDisableRects();
            }
            this.Plugins.AirViewPlugin.ResetMapPosition();
            this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
            this.Plugins.AirViewPlugin.ReloadAirView();
            if (this.Plugins.AirViewPlugin.IsMapShowing)
            {
                this.Plugins.AirViewPlugin.AddDisableRects();
            }
        }

        private void Scenario_OnNewFactionAppear(Faction faction)
        {
            if ((faction.Leader != null) && (faction.Capital != null))
            {
                faction.Leader.TextDestinationString = faction.Capital.Name;
                this.Plugins.GameRecordPlugin.AddBranch(faction.Leader, "NewFactionAppear", faction.Leader.Position);
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(faction.Leader, faction.Leader, "NewFactionAppear");
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        private void ScrollTheMainMap(GameTime gameTime)
        {
            if (base.EnableScroll && (this.viewMove != ViewMove.Stop))
            {
                if ((Math.Abs((int)(this.mouseState.X - this.previousMouseState.X)) <= 2) && (Math.Abs((int)(this.mouseState.Y - this.previousMouseState.Y)) <= 2))
                {
                    if ((gameTime.TotalGameTime.TotalMilliseconds - this.lastTime) < 200.0)
                    {
                        return;
                    }
                    int num = (int)((gameTime.ElapsedGameTime.Milliseconds * GlobalVariables.MapScrollSpeed) * this.scrollSpeedScale);
                    switch (this.viewMove)
                    {
                        case ViewMove.Left:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge += num;
                                if (this.mainMapLayer.LeftEdge > 0)
                                {
                                    this.mainMapLayer.LeftEdge = 0;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.Right:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge -= num;
                                if (this.mainMapLayer.LeftEdge < (this.viewportSize.X - this.mainMapLayer.TotalTileWidth))
                                {
                                    this.mainMapLayer.LeftEdge = this.viewportSize.X - this.mainMapLayer.TotalTileWidth;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.Top:
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge += num;
                                if (this.mainMapLayer.TopEdge > 0)
                                {
                                    this.mainMapLayer.TopEdge = 0;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.Bottom:
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge -= num;
                                if (this.mainMapLayer.TopEdge < (this.viewportSize.Y - this.mainMapLayer.TotalTileHeight))
                                {
                                    this.mainMapLayer.TopEdge = this.viewportSize.Y - this.mainMapLayer.TotalTileHeight;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.TopLeft:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge += num;
                                if (this.mainMapLayer.LeftEdge > 0)
                                {
                                    this.mainMapLayer.LeftEdge = 0;
                                }
                            }
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge += num;
                                if (this.mainMapLayer.TopEdge > 0)
                                {
                                    this.mainMapLayer.TopEdge = 0;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.TopRight:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge -= num;
                                if (this.mainMapLayer.LeftEdge < (this.viewportSize.X - this.mainMapLayer.TotalTileWidth))
                                {
                                    this.mainMapLayer.LeftEdge = this.viewportSize.X - this.mainMapLayer.TotalTileWidth;
                                }
                            }
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge += num;
                                if (this.mainMapLayer.TopEdge > 0)
                                {
                                    this.mainMapLayer.TopEdge = 0;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.BottomLeft:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge += num;
                                if (this.mainMapLayer.LeftEdge > 0)
                                {
                                    this.mainMapLayer.LeftEdge = 0;
                                }
                            }
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge -= num;
                                if (this.mainMapLayer.TopEdge < (this.viewportSize.Y - this.mainMapLayer.TotalTileHeight))
                                {
                                    this.mainMapLayer.TopEdge = this.viewportSize.Y - this.mainMapLayer.TotalTileHeight;
                                }
                            }
                            goto Label_0647;

                        case ViewMove.BottomRight:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge -= num;
                                if (this.mainMapLayer.LeftEdge < (this.viewportSize.X - this.mainMapLayer.TotalTileWidth))
                                {
                                    this.mainMapLayer.LeftEdge = this.viewportSize.X - this.mainMapLayer.TotalTileWidth;
                                }
                            }
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge -= num;
                                if (this.mainMapLayer.TopEdge < (this.viewportSize.Y - this.mainMapLayer.TotalTileHeight))
                                {
                                    this.mainMapLayer.TopEdge = this.viewportSize.Y - this.mainMapLayer.TotalTileHeight;
                                }
                            }
                            goto Label_0647;
                    }
                    goto Label_0647;
                }
                this.lastTime = gameTime.TotalGameTime.TotalMilliseconds;
            }
            return;
        Label_0647:
            this.ResetScreenEdge();
            this.mainMapLayer.ReCalculateTileDestination();
            this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
        }

        public override void SelfCaptiveRelease(Captive captive)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.IsCurrentPlayer(captive.BelongedFaction)) || base.Scenario.IsCurrentPlayer(captive.CaptiveFaction)) || GlobalVariables.SkyEye)
            {
                this.Plugins.GameRecordPlugin.AddBranch(captive, "SelfCaptiveRelease", captive.BelongedFaction.Capital.Position);
            }
        }

        private void SetTroopCombatMethod(int id)
        {
            this.CurrentTroop.Operated = true;
            this.CurrentTroop.CurrentStratagem = null;
            this.CurrentTroop.CurrentCombatMethod = base.Scenario.GameCommonData.AllCombatMethods.GetCombatMethod(id);
            if (this.CurrentTroop.CurrentCombatMethod != null)
            {
                if (this.CurrentTroop.CurrentCombatMethod.AttackDefault != null)
                {
                    this.CurrentTroop.AttackDefaultKind = (TroopAttackDefaultKind)this.CurrentTroop.CurrentCombatMethod.AttackDefault.ID;
                }
                if (this.CurrentTroop.CurrentCombatMethod.AttackTarget != null)
                {
                    this.CurrentTroop.AttackTargetKind = (TroopAttackTargetKind)this.CurrentTroop.CurrentCombatMethod.AttackTarget.ID;
                }
                if ((this.CurrentTroop.AttackTargetKind == TroopAttackTargetKind.目标默认) || (this.CurrentTroop.AttackTargetKind == TroopAttackTargetKind.目标))
                {
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopTarget));
                }
            }
        }

        private void SetTroopStratagem(int id)
        {
            this.CurrentTroop.Operated = true;
            this.CurrentTroop.CurrentCombatMethod = null;
            this.CurrentTroop.CurrentStratagem = base.Scenario.GameCommonData.AllStratagems.GetStratagem(id);
            if (this.CurrentTroop.CurrentStratagem != null)
            {
                if (this.CurrentTroop.CurrentStratagem.CastDefault != null)
                {
                    this.CurrentTroop.CastDefaultKind = (TroopCastDefaultKind)this.CurrentTroop.CurrentStratagem.CastDefault.ID;
                }
                if (this.CurrentTroop.CurrentStratagem.CastTarget != null)
                {
                    this.CurrentTroop.CastTargetKind = (TroopCastTargetKind)this.CurrentTroop.CurrentStratagem.CastTarget.ID;
                }
                if ((this.CurrentTroop.CastTargetKind == TroopCastTargetKind.特定默认) || (this.CurrentTroop.CastTargetKind == TroopCastTargetKind.特定))
                {
                    this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.TroopTarget));
                }
            }
        }

        private void SetTroopStunt(int id)
        {
            this.CurrentTroop.Operated = true;
            this.CurrentTroop.CurrentStunt = base.Scenario.GameCommonData.AllStunts.GetStunt(id);
            this.CurrentTroop.ApplyCurrentStunt();
        }

        public void ShowFactionTechniques(Faction faction, Architecture architecture)
        {
            this.Plugins.FactionTechniquesPlugin.SetArchitecture(architecture);
            this.Plugins.FactionTechniquesPlugin.SetFaction(faction, base.Scenario.CurrentPlayer == faction);
            this.Plugins.FactionTechniquesPlugin.SetPosition(ShowPosition.Center);
            this.Plugins.FactionTechniquesPlugin.IsShowing = true;
        }

        public void ShowTabListInFrame(UndoneWorkKind undoneWork, FrameKind kind, FrameFunction function, bool OKEnabled, bool CancelEnabled, bool showCheckBox, bool multiselecting, GameObjectList gameObjectList, GameObjectList selectedObjectList, string title, string tabName)
        {
            if ((gameObjectList != null) && (gameObjectList.Count != 0))
            {
                this.Plugins.GameFramePlugin.Kind = kind;
                this.Plugins.GameFramePlugin.Function = function;
                this.Plugins.TabListPlugin.InitialValues(gameObjectList, selectedObjectList, this.mouseState.ScrollWheelValue, title);
                this.Plugins.TabListPlugin.SetListKindByName(kind.ToString(), showCheckBox, multiselecting);
                this.Plugins.TabListPlugin.SetSelectedTab(tabName);
                this.Plugins.GameFramePlugin.SetFrameContent(this.Plugins.TabListPlugin.TabList, base.viewportSize);
                
                this.Plugins.GameFramePlugin.OKButtonEnabled = OKEnabled;
                this.Plugins.GameFramePlugin.CancelButtonEnabled = CancelEnabled;
                this.Plugins.GameFramePlugin.IsShowing = true;
            }
        }


        private void gengxinyoucelan()
        {
            this.Showyoucelan(UndoneWorkKind.None  , FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "", "");
        }



        public void Showyoucelan(UndoneWorkKind undoneWork, FrameKind kind, FrameFunction function, bool OKEnabled, bool CancelEnabled, bool showCheckBox, bool multiselecting, GameObjectList gameObjectList, GameObjectList selectedObjectList, string title, string tabName)
        {
            if ((gameObjectList != null) && (gameObjectList.Count != 0))
            {
                this.Plugins.youcelanPlugin.Kind = kind;
                this.Plugins.youcelanPlugin.Function = function;
                this.Plugins.youcelanPlugin.InitialValues(gameObjectList, selectedObjectList, this.mouseState.ScrollWheelValue,title);
                this.Plugins.youcelanPlugin.SetListKindByName(kind.ToString(), showCheckBox, multiselecting);
                this.Plugins.youcelanPlugin.SetSelectedTab(tabName);

                //this.Plugins.GameFramePlugin.SetFrameyoucelanContent(this.Plugins.youcelanPlugin.TabList, base.viewportSize);  //viewportSize  游戏内容窗口的大小
                this.Plugins.youcelanPlugin.SetyoucelanContent(base.viewportSize);  //viewportSize  游戏内容窗口的大小

                //this.Plugins.GameFramePlugin.shiyoucelan = true;
                //this.Plugins.GameFramePlugin.OKButtonEnabled = OKEnabled;
                //this.Plugins.GameFramePlugin.CancelButtonEnabled = CancelEnabled;
                //this.Plugins.GameFramePlugin.IsShowing = true;
                //this.Plugins.youcelanPlugin.IsShowing = true;

            }
        }

        public void StopMusic()
        {
            if (this.Player.playState == WMPPlayState.wmppsPlaying)
            {
                this.Player.stop();
            }
        }

        public void ToggleFullScreen()
        {
            this.thisGame.ToggleFullScreen();
            this.RefreshDisableRects();
        }

        public override void TroopAmbush(Troop troop)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "Ambush");
            }
        }

        public override void TroopAntiArrowAttack(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye)
            {
                if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.AntiAttack.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.AntiAttack[GameObject.Random(receiving.Leader.PersonTextMessage.AntiAttack.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "AntiArrowAttack");
                }
            }
        }

        public override void TroopAntiAttack(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye)
            {
                if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.AntiAttack.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.AntiAttack[GameObject.Random(receiving.Leader.PersonTextMessage.AntiAttack.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "AntiAttack");
                }
            }
        }

        public override void TroopApplyStunt(Troop troop, Stunt stunt)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                if (troop.BelongedFaction != null)
                {
                    troop.Leader.TextDestinationString = stunt.Name;
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "ApplyStunt");
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "ApplyStuntBasic");
                }
            }
        }

        public override void TroopApplyTroopEvent(TroopEvent te, Troop troop)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye) && (te.Dialogs.Count > 0))
            {
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                foreach (PersonDialog dialog in te.Dialogs)
                {
                    if (dialog.SpeakingPerson != null)
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(dialog.SpeakingPerson, null, dialog.Text);
                    }
                    else
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(troop.Leader, null, dialog.Text);
                    }
                }
                base.Scenario.HoldTroopEvents = true;
                this.Plugins.PersonTextDialogPlugin.SetCloseFunction(new GameDelegates.VoidFunction(base.Scenario.ApplyTroopEvents));
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
            }
        }

        public override void TroopBreakWall(Troop troop, Architecture architecture)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                if ((troop.Leader.PersonTextMessage != null) && (troop.Leader.PersonTextMessage.BreakWall.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.BreakWall[GameObject.Random(troop.Leader.PersonTextMessage.BreakWall.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "BreakWall");
                }
            }
        }

        public override void TroopCastDeepChaos(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                if ((sending.Leader.PersonTextMessage != null) && (sending.Leader.PersonTextMessage.CastDeepChaos.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(sending.Leader, sending.Position, sending.Leader.PersonTextMessage.CastDeepChaos[GameObject.Random(sending.Leader.PersonTextMessage.CastDeepChaos.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "CastDeepChaos");
                }
            }
        }

        public override void TroopCastStratagem(Troop sending, Troop receiving, Stratagem stratagem)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                if (sending.BelongedFaction != null)
                {
                    sending.Leader.TextDestinationString = receiving.Leader.Name;
                    sending.Leader.TextResultString = receiving.DisplayName;
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "Stratagem" + stratagem.ID);
                }
                else if (stratagem.Friendly)
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "StratagemFriendly");
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "StratagemHostile");
                }
            }
        }

        public override void TroopChaos(Troop troop, bool deepChaos)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                if (deepChaos)
                {
                    if ((troop.Leader.PersonTextMessage != null) && (troop.Leader.PersonTextMessage.DeepChaos.Count > 0))
                    {
                        this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.DeepChaos[GameObject.Random(troop.Leader.PersonTextMessage.DeepChaos.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "DeepChaos");
                    }
                }
                else if ((troop.Leader.PersonTextMessage != null) && (troop.Leader.PersonTextMessage.Chaos.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.Chaos[GameObject.Random(troop.Leader.PersonTextMessage.Chaos.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "Chaos");
                }
            }
        }

        public override void TroopCombatMethodAttack(Troop sending, Troop receiving, CombatMethod combatMethod)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                if (sending.BelongedFaction != null)
                {
                    sending.Leader.TextDestinationString = receiving.Leader.Name;
                    sending.Leader.TextResultString = receiving.DisplayName;
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "CombatMethod" + combatMethod.ID);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "CombatMethod");
                }
            }
        }

        public override void TroopCreate(Troop troop)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye) && !base.Scenario.IsCurrentPlayer(troop.BelongedFaction))
            {
                troop.TextDestinationString = troop.StartingArchitecture.Name;
                this.Plugins.GameRecordPlugin.AddBranch(troop, "TroopCreate", troop.Position);
            }
        }

        public override void TroopCriticalStrike(Troop sending, Troop receiving)
        {
            if ((((sending.CurrentCombatMethod == null) || (((receiving != null) && (sending.Leader.PersonTextMessage != null)) && (sending.Leader.PersonTextMessage.CriticalStrike.Count > 0))) || (((receiving == null) && (sending.Leader.PersonTextMessage != null)) && (sending.Leader.PersonTextMessage.CriticalStrikeOnArchitecture.Count > 0))) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye))
            {
                if (receiving != null)
                {
                    if ((sending.Leader.PersonTextMessage != null) && (sending.Leader.PersonTextMessage.CriticalStrike.Count > 0))
                    {
                        this.Plugins.PersonBubblePlugin.AddPersonText(sending.Leader, sending.Position, sending.Leader.PersonTextMessage.CriticalStrike[GameObject.Random(sending.Leader.PersonTextMessage.CriticalStrike.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "CriticalStrike");
                    }
                }
                else if ((sending.Leader.PersonTextMessage != null) && (sending.Leader.PersonTextMessage.CriticalStrikeOnArchitecture.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(sending.Leader, sending.Position, sending.Leader.PersonTextMessage.CriticalStrikeOnArchitecture[GameObject.Random(sending.Leader.PersonTextMessage.CriticalStrikeOnArchitecture.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "CriticalStrikeOnArchitecture");
                }
            }
        }

        public override void TroopDiscoverAmbush(Troop sending, Troop receiving)
        {
            if ((sending != null) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye))
            {
                this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "DiscoverAmbush");
            }
            if ((receiving != null) && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye))
            {
                this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "BeDiscoveredAmbush");
            }
        }

        public override void TroopEndCutRouteway(Troop troop, bool success)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                if (success)
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "EndCutRoutewaySuccess");
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "EndCutRoutewayFail");
                }
            }
        }

        public override void TroopEndPath(Troop troop)
        {
        }

        public override void TroopGetNewCaptive(Troop troop, PersonList personlist)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                Person person = personlist[StaticMethods.Random(personlist.Count)] as Person;
                troop.Leader.TextDestinationString = person.Name;
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "TroopGetNewCaptive");
                troop.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(troop, "TroopGetNewCaptive", troop.Position);
            }
        }

        public override void TroopGetSpreadBurnt(Troop troop)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "GetSpreadBurnt");
            }
        }

        public override void TroopLevyFieldFood(Troop troop, int food)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "LevyFieldFood");
            }
        }

        public override void TroopNormalAttack(Troop sending, Troop receiving)
        {
        }

        public override void TroopOccupyArchitecture(Troop troop, Architecture architecture)
        {
            this.Plugins.GameRecordPlugin.AddBranch(architecture, "ArchitectureOccupied", troop.Position);

        }

        public override void TroopOutburst(Troop troop, OutburstKind kind)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                switch (kind)
                {
                    case OutburstKind.愤怒:
                        if ((troop.Leader.PersonTextMessage == null) || (troop.Leader.PersonTextMessage.OutburstAngry.Count <= 0))
                        {
                            this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "TroopOutburstAngry");
                            break;
                        }
                        this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.OutburstAngry[GameObject.Random(troop.Leader.PersonTextMessage.OutburstAngry.Count)]);
                        break;

                    case OutburstKind.沉静:
                        if ((troop.Leader.PersonTextMessage == null) || (troop.Leader.PersonTextMessage.OutburstQuiet.Count <= 0))
                        {
                            this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "TroopOutburstQuiet");
                            break;
                        }
                        this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.OutburstQuiet[GameObject.Random(troop.Leader.PersonTextMessage.OutburstQuiet.Count)]);
                        break;
                }
            }
        }

        public override void TroopPathNotFound(Troop troop)
        {
        }

        public override void TroopPersonChallenge(bool win, Troop sourceTroop, Person source, Troop destinationTroop, Person destination)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sourceTroop.Position)) || base.Scenario.CurrentPlayer.IsPositionKnown(destinationTroop.Position)) || GlobalVariables.SkyEye)
            {
                sourceTroop.TextDestinationString = destinationTroop.DisplayName;
                Person neutralPerson = base.Scenario.NeutralPerson;
                if (neutralPerson == null)
                {
                    neutralPerson = source;
                }
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                if (win)
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, sourceTroop, "TroopPersonChallengeSourceWin");
                    if ((source.PersonTextMessage != null) && (source.PersonTextMessage.DualInitiativeWin.Count > 0))
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(source, null, source.PersonTextMessage.DualInitiativeWin[GameObject.Random(source.PersonTextMessage.DualInitiativeWin.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(source, sourceTroop, "TroopPersonChallengeAfterSourceWin");
                    }
                }
                else
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, sourceTroop, "TroopPersonChallengeSourceLose");
                    if ((destination.PersonTextMessage != null) && (destination.PersonTextMessage.DualPassiveWin.Count > 0))
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(destination, null, destination.PersonTextMessage.DualPassiveWin[GameObject.Random(destination.PersonTextMessage.DualPassiveWin.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(destination, sourceTroop, "TroopPersonChallengeAfterSourceLose");
                    }
                }
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                if (win)
                {
                    this.Plugins.GameRecordPlugin.AddBranch(sourceTroop, "TroopPersonChallengeSourceWin", sourceTroop.Position);
                }
                else
                {
                    this.Plugins.GameRecordPlugin.AddBranch(sourceTroop, "TroopPersonChallengeSourceLose", sourceTroop.Position);
                }
            }
        }

        public override void TroopPersonControversy(bool win, Troop sourceTroop, Person source, Troop destinationTroop, Person destination)
        {
            if ((((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sourceTroop.Position)) || base.Scenario.CurrentPlayer.IsPositionKnown(destinationTroop.Position)) || GlobalVariables.SkyEye)
            {
                sourceTroop.TextDestinationString = destinationTroop.DisplayName;
                Person neutralPerson = base.Scenario.NeutralPerson;
                if (neutralPerson == null)
                {
                    neutralPerson = source;
                }
                this.Plugins.PersonTextDialogPlugin.SetPosition(ShowPosition.Bottom);
                if (win)
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, sourceTroop, "TroopPersonControversySourceWin");
                    if ((source.PersonTextMessage != null) && (source.PersonTextMessage.ControversyInitiativeWin.Count > 0))
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(source, null, source.PersonTextMessage.ControversyInitiativeWin[GameObject.Random(source.PersonTextMessage.ControversyInitiativeWin.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(source, sourceTroop, "TroopPersonControversyAfterSourceWin");
                    }
                }
                else
                {
                    this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(neutralPerson, sourceTroop, "TroopPersonControversySourceLose");
                    if ((destination.PersonTextMessage != null) && (destination.PersonTextMessage.ControversyPassiveWin.Count > 0))
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(destination, null, destination.PersonTextMessage.ControversyPassiveWin[GameObject.Random(destination.PersonTextMessage.ControversyPassiveWin.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonTextDialogPlugin.SetGameObjectBranch(destination, sourceTroop, "TroopPersonControversyAfterSourceLose");
                    }
                }
                this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                if (win)
                {
                    this.Plugins.GameRecordPlugin.AddBranch(sourceTroop, "TroopPersonControversySourceWin", sourceTroop.Position);
                }
                else
                {
                    this.Plugins.GameRecordPlugin.AddBranch(sourceTroop, "TroopPersonControversySourceLose", sourceTroop.Position);
                }
            }
        }

        public override void TroopReceiveCriticalStrike(Troop sending, Troop receiving)
        {
            if (!receiving.Destroyed && ((((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye) && ((receiving.Status != TroopStatus.混乱) && (GameObject.Chance(receiving.Leader.Braveness) || ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.ReceiveCriticalStrike.Count > 0))))))
            {
                if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.ReceiveCriticalStrike.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.ReceiveCriticalStrike[GameObject.Random(receiving.Leader.PersonTextMessage.ReceiveCriticalStrike.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "ReceiveCriticalStrike");
                }
            }
        }

        public override void TroopReceiveWaylay(Troop sending, Troop receiving)
        {
            if (!receiving.Destroyed && (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye))
            {
                this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "ReceiveWaylay");
            }
        }

        public override void TroopRecoverFromChaos(Troop troop)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                if ((troop.Leader.PersonTextMessage != null) && (troop.Leader.PersonTextMessage.RecoverFromChaos.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(troop.Leader, troop.Position, troop.Leader.PersonTextMessage.RecoverFromChaos[GameObject.Random(troop.Leader.PersonTextMessage.RecoverFromChaos.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "RecoverFromChaos");
                }
            }
        }

        public override void TroopReleaseCaptive(Troop troop, PersonList personlist)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                Person person = personlist[StaticMethods.Random(personlist.Count)] as Person;
                troop.TextDestinationString = person.Name;
                this.Plugins.GameRecordPlugin.AddBranch(troop, "TroopReleaseCaptive", troop.Position);
            }
        }

        public override void TroopResistStratagem(Troop sending, Troop receiving, Stratagem stratagem, bool isHarmful)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye)
            {
                if (isHarmful)
                {
                    if (GameObject.Random(receiving.TroopIntelligence) > GameObject.Random(sending.TroopIntelligence))
                    {
                        if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.ResistHarmfulStratagem.Count > 0))
                        {
                            this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.ResistHarmfulStratagem[GameObject.Random(receiving.Leader.PersonTextMessage.ResistHarmfulStratagem.Count)]);
                        }
                        else
                        {
                            this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "ResistHarmfulStratagem");
                        }
                    }
                }
                else if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.ResistHelpfulStratagem.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.ResistHelpfulStratagem[GameObject.Random(receiving.Leader.PersonTextMessage.ResistHelpfulStratagem.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "ResistNoHarmStratagem");
                }
            }
        }

        public override void TroopRout(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                if ((sending.Leader.PersonTextMessage != null) && (sending.Leader.PersonTextMessage.Rout.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(sending.Leader, sending.Position, sending.Leader.PersonTextMessage.Rout[GameObject.Random(sending.Leader.PersonTextMessage.Rout.Count)]);
                }
                else
                {
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "Rout");
                }
            }
        }

        public override void TroopRouted(Troop sending, Troop receiving)
        {
        }

        public override void TroopSetCombatMethod(Troop troop, CombatMethod combatMethod)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                troop.Leader.TextDestinationString = combatMethod.Name;
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "SetCombatMethod");
            }
        }

        public override void TroopSetStratagem(Troop troop, Stratagem stratagem)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                troop.Leader.TextDestinationString = stratagem.Name;
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "SetStratagem");
            }
        }

        public override void TroopStartCutRouteway(Troop troop, int days)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                troop.Leader.TextDestinationString = days.ToString();
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "StartCutRouteway");
            }
        }

        public override void TroopStopAmbush(Troop troop)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(troop.Position)) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(troop.Leader, troop.Position, "StopAmbush");
            }
        }

        public override void TroopStratagemSuccess(Troop sending, Troop receiving, Stratagem stratagem, bool isHarmful)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(receiving.Position)) || GlobalVariables.SkyEye)
            {
                if (isHarmful)
                {
                    if (GameObject.Chance(0x21))
                    {
                        if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.TrappedByStratagem.Count > 0))
                        {
                            this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.TrappedByStratagem[GameObject.Random(receiving.Leader.PersonTextMessage.TrappedByStratagem.Count)]);
                        }
                        else
                        {
                            this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "HarmfulStratagemSuccess");
                        }
                    }
                }
                else if ((sending != receiving) && GameObject.Chance(0x21))
                {
                    if ((receiving.Leader.PersonTextMessage != null) && (receiving.Leader.PersonTextMessage.HelpedByStratagem.Count > 0))
                    {
                        this.Plugins.PersonBubblePlugin.AddPersonText(receiving.Leader, receiving.Position, receiving.Leader.PersonTextMessage.HelpedByStratagem[GameObject.Random(receiving.Leader.PersonTextMessage.HelpedByStratagem.Count)]);
                    }
                    else
                    {
                        this.Plugins.PersonBubblePlugin.AddPerson(receiving.Leader, receiving.Position, "NoHarmStratagemSuccess");
                    }
                }
            }
        }

        public override void TroopSurround(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                if ((sending.Leader.PersonTextMessage != null) && (sending.Leader.PersonTextMessage.Surround.Count > 0))
                {
                    this.Plugins.PersonBubblePlugin.AddPersonText(sending.Leader, sending.Position, sending.Leader.PersonTextMessage.Surround[GameObject.Random(sending.Leader.PersonTextMessage.Surround.Count)]);
                }
                else
                {
                    sending.Leader.TextDestinationString = receiving.Leader.Name;
                    sending.Leader.TextResultString = receiving.DisplayName;
                    this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "Surround");
                }
            }
        }

        public override void TroopWaylay(Troop sending, Troop receiving)
        {
            if (((base.Scenario.CurrentPlayer == null) || base.Scenario.CurrentPlayer.IsPositionKnown(sending.Position)) || GlobalVariables.SkyEye)
            {
                this.Plugins.PersonBubblePlugin.AddPerson(sending.Leader, sending.Position, "Waylay");
            }
        }

        public void TryToDemolishRouteway()
        {
            if (!this.Plugins.PersonTextDialogPlugin.IsShowing)
            {
                this.Plugins.ConfirmationDialogPlugin.SetSimpleTextDialog(this.Plugins.SimpleTextDialogPlugin);
                this.Plugins.ConfirmationDialogPlugin.ClearFunctions();
                this.Plugins.ConfirmationDialogPlugin.AddYesFunction(new GameDelegates.VoidFunction(this.DemolishCurrentRouteway));
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.SimpleTextDialogPlugin.SetBranch("DemolishRouteway");
                this.Plugins.ConfirmationDialogPlugin.IsShowing = true;
            }
        }

        public override void TryToExit()
        {
            if (!this.Plugins.PersonTextDialogPlugin.IsShowing)
            {
                this.Plugins.ConfirmationDialogPlugin.SetSimpleTextDialog(this.Plugins.SimpleTextDialogPlugin);
                this.Plugins.ConfirmationDialogPlugin.ClearFunctions();
                this.Plugins.ConfirmationDialogPlugin.AddYesFunction(new GameDelegates.VoidFunction(base.Game.Exit));
                this.Plugins.ConfirmationDialogPlugin.SetPosition(ShowPosition.Center);
                this.Plugins.SimpleTextDialogPlugin.SetBranch("ExitGame");
                this.Plugins.ConfirmationDialogPlugin.IsShowing = true;
            }
        }

        public override void Update(GameTime gameTime)   //视野内容更新
        {
            if (base.EnableUpdate)
            {
                this.UpdateCount++;
                base.Update(gameTime);
                this.CalculateFrameRate(gameTime);
                this.Plugins.PersonBubblePlugin.Update(gameTime);
                switch (base.UndoneWorks.Peek().Kind)
                {
                    case UndoneWorkKind.None:
                        this.UpdateToolBar(gameTime);
                        this.UpdateScreenBlind(gameTime);
                        //this.Plugins.youcelanPlugin.Update(gameTime);
                        //this.Plugins.youcelanPlugin.IsShowing = false;

                        

                        

                        this.HandleLaterMouseEvent(gameTime);
                        this.ScrollTheMainMap(gameTime);
                        this.HandleKey(gameTime);

                        this.GameGo(gameTime);

                        //if (!this.Plugins.youcelanPlugin.IsShowing)
                        //{
                        //    this.Showyoucelan(UndoneWorkKind.None, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.Architectures, null, "", "");
                        //}
                        break;

                    case UndoneWorkKind.Dialog:
                        this.UpdateDialog(gameTime);

                        break;

                    case UndoneWorkKind.Selecting:
                        if (base.EnableSelecting)
                        {
                            this.ResetCurrentStatus();
                            this.UpdateViewMove();
                            this.HandleLaterMouseScroll();
                            this.ScrollTheMainMap(gameTime);
                            this.UpdateConmentText(gameTime);
                        }
                        break;

                    case UndoneWorkKind.Inputer:
                        this.UpdateInputer(gameTime);
                        break;

                    case UndoneWorkKind.Selector:
                        this.HandleLaterMouseEvent(gameTime);
                        this.ScrollTheMainMap(gameTime);
                        break;

                    case UndoneWorkKind.MapViewSelector:
                        this.ResetCurrentStatus();
                        this.UpdateViewMove();
                        this.HandleLaterMouseScroll();
                        this.ScrollTheMainMap(gameTime);
                        if (base.EnableLaterMouseEvent)
                        {
                            this.UpdateSurvey(gameTime);
                            this.UpdateConmentText(gameTime);
                        }
                        break;
                }


            }
        }

        private void UpdateConmentText(GameTime gameTime)
        {
            if ((this.Plugins.ConmentTextPlugin != null) && (this.lastPosition != this.position))
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.position);
                Troop troopByPosition = base.Scenario.GetTroopByPosition(this.position);
                this.Plugins.ConmentTextPlugin.BuildThirdText(base.Scenario.GetCoordinateString(this.position), true);

                if (base.Scenario.CurrentPlayer != null)
                {
                    this.Plugins.ConmentTextPlugin.BuildSecondText(InformationTile.InformationString(base.Scenario.CurrentPlayer.GetKnownAreaData(this.position)), true);
                }
                else
                {
                    this.Plugins.ConmentTextPlugin.BuildSecondText("", false);
                }
                if ((troopByPosition != null) && (GlobalVariables.SkyEye || ((base.Scenario.CurrentPlayer != null) && base.Scenario.CurrentPlayer.IsPositionKnown(this.position))))
                {
                    this.Plugins.ConmentTextPlugin.BuildFirstText(troopByPosition.DisplayName + " " + this.mainMapLayer.GetTerrainNameByPosition(this.position), true);
                }
                else if (architectureByPosition != null)
                {
                    this.Plugins.ConmentTextPlugin.BuildFirstText(architectureByPosition.Name + " " + this.mainMapLayer.GetTerrainNameByPosition(this.position), true);
                }
                else
                {
                    this.Plugins.ConmentTextPlugin.BuildFirstText(this.mainMapLayer.GetTerrainNameByPosition(this.position), false);
                }
                this.Plugins.ConmentTextPlugin.SetView(this.viewportSize.X, this.viewportSize.Y);
                this.Plugins.ConmentTextPlugin.Update(gameTime);
            }
        }

        private void UpdateDialog(GameTime gameTime)
        {
            if (this.Plugins.SimpleTextDialogPlugin != null)
            {
                this.Plugins.SimpleTextDialogPlugin.Update(gameTime);
            }
            if (this.Plugins.PersonTextDialogPlugin != null)
            {
                this.Plugins.PersonTextDialogPlugin.Update(gameTime);
            }
        }

        private void UpdateInputer(GameTime gameTime)
        {
            this.Plugins.NumberInputerPlugin.Update(gameTime);
        }

        private void UpdateScreenBlind(GameTime gameTime)
        {
            if (this.Plugins.ScreenBlindPlugin != null)
            {
                this.Plugins.ScreenBlindPlugin.Update(gameTime);
            }
        }

        private void UpdateSurvey(GameTime gameTime)       //更新情况表
        {
            if (this.Plugins.ArchitectureSurveyPlugin != null)
            {
                Architecture architectureByPosition = base.Scenario.GetArchitectureByPosition(this.position);
                if ((architectureByPosition != null) && ((this.CurrentTroop == null) || ((!GlobalVariables.SkyEye && (base.Scenario.CurrentPlayer != null)) && !base.Scenario.CurrentPlayer.IsPositionKnown(this.CurrentTroop.Position))))
                {
                    this.Plugins.ArchitectureSurveyPlugin.SetArchitecture(architectureByPosition, this.position);
                    this.Plugins.ArchitectureSurveyPlugin.SetFaction(base.Scenario.CurrentPlayer);
                    this.Plugins.ArchitectureSurveyPlugin.Showing = true;
                    this.Plugins.ArchitectureSurveyPlugin.SetTopLeftPoint(this.mouseState.X, this.mouseState.Y);
                    this.Plugins.ArchitectureSurveyPlugin.Update(gameTime);
                }
                else
                {
                    this.Plugins.ArchitectureSurveyPlugin.SetArchitecture(null, this.position);
                    this.Plugins.ArchitectureSurveyPlugin.Showing = false;
                }
            }
            if (this.Plugins.TroopSurveyPlugin != null)
            {
                if (GlobalVariables.SkyEye || ((base.Scenario.CurrentPlayer != null) && base.Scenario.CurrentPlayer.IsPositionKnown(this.position)))
                {
                    Troop troopByPosition = base.Scenario.GetTroopByPosition(this.position);
                    if (troopByPosition != null)
                    {
                        this.Plugins.TroopSurveyPlugin.SetTroop(troopByPosition);
                        this.Plugins.TroopSurveyPlugin.SetFaction(base.Scenario.CurrentPlayer);
                        this.Plugins.TroopSurveyPlugin.Showing = true;
                        this.Plugins.TroopSurveyPlugin.SetTopLeftPoint(this.mouseState.X, this.mouseState.Y);
                        this.Plugins.TroopSurveyPlugin.Update(gameTime);
                    }
                    else
                    {
                        this.Plugins.TroopSurveyPlugin.SetTroop(null);
                        this.Plugins.TroopSurveyPlugin.Showing = false;
                    }
                }
                else
                {
                    this.Plugins.TroopSurveyPlugin.SetTroop(null);
                    this.Plugins.TroopSurveyPlugin.Showing = false;
                }
            }
        }

        private void UpdateToolBar(GameTime gameTime)
        {
            if (this.Plugins.ToolBarPlugin != null)
            {
                this.Plugins.ToolBarPlugin.Update(gameTime);
            }
        }

        private void UpdateViewMove()          //更新视野移动方向
        {
            this.ResetMouse();
            if (((base.Game.IsActive && base.EnableScroll) && (!this.DrawingSelector && (base.viewportSize != Point.Zero))) && ((((this.mouseState.X >= 0) && (this.mouseState.Y >= 0)) && (this.mouseState.X <= this.viewportSize.X)) && (this.mouseState.Y <= this.viewportSize.Y)))
            {
                if (this.mouseState.X < 50)
                {
                    if (this.mouseState.Y < 50)
                    {
                        if ((this.mainMapLayer.LeftEdge != 0) || (this.mainMapLayer.TopEdge != 0))
                        {
                            base.MouseArrowTexture = this.Textures.MouseArrowTextures[5];
                            this.viewMove = ViewMove.TopLeft;
                        }
                    }
                    else if ((this.viewportSize.Y - this.mouseState.Y) < 50)
                    {
                        if ((this.mainMapLayer.LeftEdge != 0) || ((this.mainMapLayer.TopEdge + this.mainMapLayer.TotalTileHeight) != this.viewportSize.Y))
                        {
                            base.MouseArrowTexture = this.Textures.MouseArrowTextures[7];
                            this.viewMove = ViewMove.BottomLeft;
                        }
                    }
                    else if (this.mainMapLayer.LeftEdge != 0)
                    {
                        base.MouseArrowTexture = this.Textures.MouseArrowTextures[1];
                        this.viewMove = ViewMove.Left;
                    }
                }
                else if ((this.viewportSize.X - this.mouseState.X) < 50)
                {
                    if (this.mouseState.Y < 50)
                    {
                        if (((this.mainMapLayer.LeftEdge + this.mainMapLayer.TotalTileWidth) != this.viewportSize.X) || (this.mainMapLayer.TopEdge != 0))
                        {
                            base.MouseArrowTexture = this.Textures.MouseArrowTextures[6];
                            this.viewMove = ViewMove.TopRight;
                        }
                    }
                    else if ((this.viewportSize.Y - this.mouseState.Y) < 50)
                    {
                        if (((this.mainMapLayer.LeftEdge + this.mainMapLayer.TotalTileWidth) != this.viewportSize.X) || ((this.mainMapLayer.TopEdge + this.mainMapLayer.TotalTileHeight) != this.viewportSize.Y))
                        {
                            base.MouseArrowTexture = this.Textures.MouseArrowTextures[8];
                            this.viewMove = ViewMove.BottomRight;
                        }
                    }
                    else if ((this.mainMapLayer.LeftEdge + this.mainMapLayer.TotalTileWidth) != this.viewportSize.X)
                    {
                        base.MouseArrowTexture = this.Textures.MouseArrowTextures[2];
                        this.viewMove = ViewMove.Right;
                    }
                }
                else if (this.mouseState.Y < 50)
                {
                    if (this.mainMapLayer.TopEdge != 0)
                    {
                        base.MouseArrowTexture = this.Textures.MouseArrowTextures[3];
                        this.viewMove = ViewMove.Top;
                    }
                }
                else if (((this.viewportSize.Y - this.mouseState.Y) < 50) && ((this.mainMapLayer.TopEdge + this.mainMapLayer.TotalTileHeight) != this.viewportSize.Y))
                {
                    base.MouseArrowTexture = this.Textures.MouseArrowTextures[4];
                    this.viewMove = ViewMove.Bottom;
                }
            }
        }

        private void UpdateViewport()
        {
            if (base.Game.GraphicsDevice != null)
            {
                this.viewportSize.X = base.Game.GraphicsDevice.Viewport.Width;
                this.viewportSize.Y = base.Game.GraphicsDevice.Viewport.Height - this.Plugins.ToolBarPlugin.Height;
                this.Plugins.ToolBarPlugin.SetRealViewportSize(new Point(base.Game.GraphicsDevice.Viewport.Width, base.Game.GraphicsDevice.Viewport.Height));
                this.ResetScreenEdge();
                this.mainMapLayer.ReCalculateTileDestination();
            }
        }

        private void Window_ClientSizeChanged(object sender, EventArgs e)
        {
            this.UpdateViewport();
            this.ResetTiles();
            this.RefreshDisableRects();
        }

        public Architecture CurrentArchitecture
        {
            get
            {
                return this.screenManager.CurrentArchitecture;
            }
            set
            {
                this.screenManager.CurrentArchitecture = value;
            }
        }

        public string CurrentArchitectureDisplayName
        {
            get
            {
                return this.CurrentArchitecture.Name;
            }
        }

        public Faction CurrentFaction
        {
            get
            {
                return this.screenManager.CurrentFaction;
            }
            set
            {
                this.screenManager.CurrentFaction = value;
            }
        }

        public GameObjectList CurrentGameObjects
        {
            get
            {
                return this.screenManager.CurrentGameObjects;
            }
            set
            {
                this.screenManager.CurrentGameObjects = value;
            }
        }

        public Military CurrentMilitary
        {
            get
            {
                return this.screenManager.CurrentMilitary;
            }
            set
            {
                this.screenManager.CurrentMilitary = value;
            }
        }

        public int CurrentNumber
        {
            get
            {
                return this.screenManager.CurrentNumber;
            }
            set
            {
                this.screenManager.CurrentNumber = value;
            }
        }

        public Person CurrentPerson
        {
            get
            {
                return this.screenManager.CurrentPerson;
            }
            set
            {
                this.screenManager.CurrentPerson = value;
            }
        }

        public GameObjectList CurrentPersons
        {
            get
            {
                return this.screenManager.CurrentPersons;
            }
        }

        public Routeway CurrentRouteway
        {
            get
            {
                return this.screenManager.CurrentRouteway;
            }
            set
            {
                this.screenManager.CurrentRouteway = value;
            }
        }

        public string CurrentRoutewayDisplayName
        {
            get
            {
                return this.CurrentRouteway.DisplayName;
            }
        }

        public Troop CurrentTroop
        {
            get
            {
                return this.screenManager.CurrentTroop;
            }
            set
            {
                this.screenManager.CurrentTroop = value;
            }
        }

        public string CurrentTroopDisplayName
        {
            get
            {
                return this.CurrentTroop.DisplayName;
            }
        }

        public bool DrawingSelector
        {
            get
            {
                return this.drawingSelector;
            }
            set
            {
                if (this.drawingSelector != value)
                {
                    this.drawingSelector = value;
                    this.SelectorTroops.Clear();
                    if (!value)
                    {
                        this.PopUndoneWork();
                        if (((this.SelectorStartPosition != base.MousePosition) && (base.Scenario.CurrentPlayer != null)) && base.Scenario.CurrentPlayer.Controlling)
                        {
                            Point positionByPoint = this.GetPositionByPoint(this.SelectorStartPosition);
                            Point point2 = this.GetPositionByPoint(base.MousePosition);
                            foreach (Troop troop in base.Scenario.CurrentPlayer.Troops.GetList())
                            {
                                if ((((!troop.Destroyed && (troop.Status == TroopStatus.一般)) && ((troop.Position.X >= positionByPoint.X) && (troop.Position.X <= point2.X))) && (troop.Position.Y >= positionByPoint.Y)) && (troop.Position.Y <= point2.Y))
                                {
                                    this.SelectorTroops.Add(troop);
                                }
                            }
                            this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selecting, SelectingUndoneWorkKind.SelectorTroopsDestination));
                        }
                    }
                    else
                    {
                        this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selector, UndoneWorkSubKind.None ));
                        //this.PushUndoneWork(new UndoneWorkItem(UndoneWorkKind.Selector, ViewMove.Stop ));
                    }
                    this.SelectorStartPosition = base.MousePosition;
                }
            }
        }

        public bool IsFullScreen
        {
            get
            {
                return base.GraphicsDevice.PresentationParameters.IsFullScreen;
            }
        }

        public bool IsMultipleResource
        {
            get
            {
                return GlobalVariables.MultipleResource;
            }
        }

        public bool IsPlayingBattleSound
        {
            get
            {
                return GlobalVariables.PlayBattleSound;
            }
        }

        public bool IsPlayingMusic
        {
            get
            {
                return GlobalVariables.PlayMusic;
            }
        }

        public bool IsPlayingNormalSound
        {
            get
            {
                return GlobalVariables.PlayNormalSound;
            }
        }

        public bool IsPlayingTroopAnimation
        {
            get
            {
                return GlobalVariables.DrawTroopAnimation;
            }
        }

        public bool IsShowingSmog
        {
            get
            {
                return GlobalVariables.DrawMapVeil;
            }
        }

        public bool IsShowingTroopTitle
        {
            get
            {
                return this.Plugins.TroopTitlePlugin.IsShowing;
            }
        }

        public bool IsSkyEye
        {
            get
            {
                return GlobalVariables.SkyEye;
            }
        }

        public ViewMove ViewMoveDirection
        {
            get
            {
                return this.viewMove;
            }
        }
    }

 

}
