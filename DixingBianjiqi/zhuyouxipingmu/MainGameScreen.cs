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
        private int ditukuaidezhi = 1;
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


        }





        private void CalculateFrameRate(GameTime gameTime)
        {
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
                //this.Plugins.ArchitectureSurveyPlugin.Draw(base.spriteBatch);
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
            //this.Plugins.tupianwenziPlugin.Draw(base.spriteBatch);
            this.Plugins.ConfirmationDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.TransportDialogPlugin.Draw(base.spriteBatch);
            this.Plugins.CreateTroopPlugin.Draw(base.spriteBatch);
            this.Plugins.MarshalSectionDialogPlugin.Draw(base.spriteBatch);
        }

        public void Drawtupianwenzi()
        {

            this.Plugins.tupianwenziPlugin.Draw(base.spriteBatch);

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
            //this.mapVeilLayer.Draw(base.spriteBatch, base.viewportSize);


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
                    this.Plugins.ToolBarPlugin.DrawTools = true ;
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
                case UndoneWorkKind.tupianwenzi:
                    this.Drawtupianwenzi();
                    this.Plugins.ToolBarPlugin.DrawTools = false;
                    break;
                case UndoneWorkKind.liangdaobianji:
                    if (StaticMethods.PointInViewport(base.MousePosition, base.viewportSize))
                    {
                        this.DrawCommentText();
                        this.DrawArchitectureSurvey();
                        this.DrawTroopSurvey();
                    }
                    this.DrawRoutewayEditor();

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
            //this.Plugins.ScreenBlindPlugin.Draw(base.spriteBatch);
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
                    this.ditukuaidezhi = 1;
                }
                else if (this.keyState.IsKeyDown(Keys.D2))
                {
                    this.currentKey = Keys.D2;
                    this.ditukuaidezhi = 2;
                }
                else if (this.keyState.IsKeyDown(Keys.D3))
                {
                    this.currentKey = Keys.D3;
                    this.ditukuaidezhi = 3;
                }
                else if (this.keyState.IsKeyDown(Keys.D4))
                {
                    this.currentKey = Keys.D4;
                    this.ditukuaidezhi = 4;
                }
                else if (this.keyState.IsKeyDown(Keys.D5))
                {
                    this.currentKey = Keys.D5;
                    this.ditukuaidezhi = 5;
                }
                else if (this.keyState.IsKeyDown(Keys.D6))
                {
                    this.currentKey = Keys.D6;
                    this.ditukuaidezhi = 6;
                }
                else if (this.keyState.IsKeyDown(Keys.D7))
                {
                    this.currentKey = Keys.D7;
                    this.ditukuaidezhi =7;
                }
                else if (this.keyState.IsKeyDown(Keys.D8))
                {
                    this.currentKey = Keys.D8;
                    this.ditukuaidezhi = 8;
                }
                else if (this.keyState.IsKeyDown(Keys.D9))
                {
                    this.currentKey = Keys.D9;
                    this.ditukuaidezhi = 9;
                }
                else if (this.keyState.IsKeyDown(Keys.D0))
                {
                    this.currentKey = Keys.D0;
                    this.ditukuaidezhi = 10;
                }
                else if (this.keyState.IsKeyDown(Keys.F1))
                {
                    this.currentKey = Keys.F1;
                    //this.DateGo(30);
                }
                else if (this.keyState.IsKeyDown(Keys.F2))
                {
                    this.currentKey = Keys.F2;
                    //this.DateGo(60);
                }
                else if (this.keyState.IsKeyDown(Keys.F3))
                {
                    this.currentKey = Keys.F3;
                    //this.DateGo(90);
                }
                else if (this.keyState.IsKeyDown(Keys.C))
                {
                    this.currentKey = Keys.C;
                    this.mainMapLayer.xianshidituxiaokuai = !this.mainMapLayer.xianshidituxiaokuai;


                }
            }
            if (this.keyState.IsKeyDown(Keys.Space))
            {
                //this.currentKey = Keys.Space;
                //this.Plugins.DateRunnerPlugin.Run();
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

                case SelectingUndoneWorkKind.Trooprucheng :
                    if (this.CurrentTroop != null)
                    {
                        this.selectingLayer.AreaFrameKind = SelectingUndoneWorkKind.Trooprucheng ;

                        this.selectingLayer.Area = this.CurrentTroop.GetruchengArea(true);
                        
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

                case SelectingUndoneWorkKind.TroopDestination:   //移动
                    if (this.selectingLayer.Canceled)
                    {
                        return;
                    }
                    architecture2 = base.Scenario.GetArchitectureByPosition(this.selectingLayer.SelectedPoint);
                    this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;
                    this.CurrentTroop.TargetTroop = null;
                    this.CurrentTroop.TargetArchitecture  = null;
                    this.CurrentTroop.Operated = true;
                    this.CurrentTroop.mingling = "移动";


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
                    break;

                case SelectingUndoneWorkKind.Trooprucheng :   //入城
                    if (this.selectingLayer.Canceled)
                    {
                        return;
                    }
                    architecture2 = base.Scenario.GetArchitectureByPosition(this.selectingLayer.SelectedPoint);
                    this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;
                    this.CurrentTroop.TargetTroop = null;
                    this.CurrentTroop.TargetArchitecture = null;
                    this.CurrentTroop.mingling = "入城";
                    this.CurrentTroop.minglingweizhi = this.selectingLayer.SelectedPoint;
                    this.CurrentTroop.Operated = true;
                    if (architecture2 != null)
                    {
                        this.CurrentTroop.TargetArchitecture = architecture2;

                    }
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

                case SelectingUndoneWorkKind.TroopTarget:  //选目标
                    {
                        if (this.selectingLayer.Canceled)
                        {
                            /*this.CurrentTroop.AttackTargetKind = TroopAttackTargetKind.遇敌;
                            if (this.CurrentTroop.CurrentStratagem != null)
                            {
                                this.CurrentTroop.CastTargetKind = TroopCastTargetKind.可能;
                            }
                            */
                            this.CurrentTroop.CurrentCombatMethod = null;
                            this.CurrentTroop.CurrentStratagem = null;
                            if (this.CurrentTroop.Status == TroopStatus.埋伏)
                            {
                                this.CurrentTroop.EndAmbush();
                            }
                            return;
                        }
                        //////////////////////////////////////////////////////////////////////////////
                        /*
                        Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        if ((troopByPositionNoCheck == null) || !this.CurrentTroop.BelongedFaction.IsPositionKnown(this.selectingLayer.SelectedPoint))
                        {
                            this.CurrentTroop.TargetTroop = null;
                        }
                        else
                        {
                            this.CurrentTroop.TargetTroop = troopByPositionNoCheck;
                            //this.CurrentTroop.WillTroop = troopByPositionNoCheck;
                            this.CurrentTroop.TargetArchitecture = null;
                            //this.CurrentTroop.WillArchitecture = null;
                        }
                        Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        if (architectureByPositionNoCheck != null && architectureByPositionNoCheck.Endurance >0)
                        {
                            this.CurrentTroop.TargetArchitecture = architectureByPositionNoCheck;
                            //this.CurrentTroop.WillArchitecture  = architectureByPositionNoCheck;
                            this.CurrentTroop.TargetTroop = null;
                            //this.CurrentTroop.WillTroop = null;
                            this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;

                        }
                        else
                        {
                            this.CurrentTroop.TargetArchitecture = null;
                        }
                        */
                        ///////////////////////////////////////////////////////////////////////////////////
                        Troop troopByPositionNoCheck = base.Scenario.GetTroopByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        Architecture architectureByPositionNoCheck = base.Scenario.GetArchitectureByPositionNoCheck(this.selectingLayer.SelectedPoint);
                        bool youjianzhu=false ;
                        bool youdijun = false;
                        youjianzhu = (architectureByPositionNoCheck != null && architectureByPositionNoCheck.Endurance > 0);
                        youdijun = ((troopByPositionNoCheck != null) && this.CurrentTroop.BelongedFaction.IsPositionKnown(this.selectingLayer.SelectedPoint));
                        if (!youjianzhu && !youdijun)
                        {
                            this.CurrentTroop.TargetTroop = null;
                            this.CurrentTroop.TargetArchitecture = null;
                            this.CurrentTroop.mingling = "——";

                            return;
                        }
                        else if (youjianzhu && !youdijun)
                        {
                            this.CurrentTroop.TargetArchitecture = architectureByPositionNoCheck;
                            this.CurrentTroop.TargetTroop = null;
                            this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;
                            this.CurrentTroop.mingling = "攻击建筑";

                        }
                        else if (!youjianzhu && youdijun)
                        {
                            this.CurrentTroop.TargetTroop = troopByPositionNoCheck;
                            this.CurrentTroop.TargetArchitecture = null;
                            this.CurrentTroop.mingling = "攻击军队";

                        }
                        else if (youjianzhu && youdijun)
                        {
                            if (this.CurrentTroop.Army.Kind.Type == MilitaryType.弩兵 || this.CurrentTroop.Army.KindID == 26)
                            {
                                this.CurrentTroop.TargetTroop = troopByPositionNoCheck;
                                this.CurrentTroop.TargetArchitecture = null;
                                this.CurrentTroop.mingling = "攻击军队";

                            }
                            else
                            {
                                this.CurrentTroop.TargetArchitecture = architectureByPositionNoCheck;
                                this.CurrentTroop.TargetTroop = null;
                                this.CurrentTroop.RealDestination = this.selectingLayer.SelectedPoint;
                                this.CurrentTroop.mingling = "攻击建筑";

                            }
                        }
                        /////////////////////////////////////////////////////////////////////////////////////
                        this.CurrentTroop.Operated = true;

                        //this.Plugins.PersonBubblePlugin.AddPerson(this.CurrentTroop.Leader, this.CurrentTroop.Position, "Target");
                        return;
                    }
                case SelectingUndoneWorkKind.TroopInvestigatePosition:  //让军队侦查
                    if (this.selectingLayer.Canceled)
                    {
                        this.CurrentTroop.CurrentStratagem = null;

                        return;
                    }
                    this.CurrentTroop.SelfCastPosition = this.selectingLayer.SelectedPoint;
                    this.CurrentTroop.Operated = true;
                    this.CurrentTroop.mingling = "侦查";

                    return;

                case SelectingUndoneWorkKind.TroopSetFirePosition:
                    if (this.selectingLayer.Canceled)
                    {
                        this.CurrentTroop.CurrentStratagem = null;
                        return;
                    }
                    this.CurrentTroop.SelfCastPosition = this.selectingLayer.SelectedPoint;
                    this.CurrentTroop.Operated = true;
                    this.CurrentTroop.mingling = "——";
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
            this.mainMapLayer.ReCalculateTileDestination(base.GraphicsDevice);
            this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
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
                case UndoneWorkKind.tupianwenzi:
                    break;
                case UndoneWorkKind.liangdaobianji :
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
            if (this.LoadScenarioInInitialization)
            {
                this.Plugins.OptionDialogPlugin.AddOption("存储地图", null, new GameDelegates.VoidFunction(this.SaveScenarioMap));
            }
            else
            {
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
            }
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
            if (!base.Scenario.SaveGameScenarioToDatabase(builder.ConnectionString, true, false))
            {
                File.Delete(path);
            }
            base.Scenario.EnableLoadAndSave = true;
        }


        public void SaveMapToScenario()
        {
            base.Scenario.EnableLoadAndSave = false;

            string path = this.SaveFileName;
            if (!File.Exists(path))
            {
                return;
            }
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = path,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            base.Scenario.ScenarioMap.JumpPosition = this.mainMapLayer.GetCurrentScreenCenter(base.viewportSize);
            if (!base.Scenario.SaveScenarioMapToDatabase(builder.ConnectionString))
            {
            }
            base.Scenario.EnableLoadAndSave = true;
        }


        private void SaveScenarioMap()
        {
            if (this.LoadScenarioInInitialization)
            {
                this.SaveFileName = this.InitializationFileName;
                Thread thread = new Thread(new ThreadStart(this.SaveMapToScenario));
                thread.Start();
                thread.Join();
            }


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
                            break;

                        case ViewMove.Right:
                            if (this.viewportSize.X < this.mainMapLayer.TotalTileWidth)
                            {
                                this.mainMapLayer.LeftEdge -= num;
                                if (this.mainMapLayer.LeftEdge < (this.viewportSize.X - this.mainMapLayer.TotalTileWidth))
                                {
                                    this.mainMapLayer.LeftEdge = this.viewportSize.X - this.mainMapLayer.TotalTileWidth;
                                }
                            }
                            break;

                        case ViewMove.Top:
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge += num;
                                if (this.mainMapLayer.TopEdge > 0)
                                {
                                    this.mainMapLayer.TopEdge = 0;
                                }
                            }
                            break;

                        case ViewMove.Bottom:
                            if (this.viewportSize.Y < this.mainMapLayer.TotalTileHeight)
                            {
                                this.mainMapLayer.TopEdge -= num;
                                if (this.mainMapLayer.TopEdge < (this.viewportSize.Y - this.mainMapLayer.TotalTileHeight))
                                {
                                    this.mainMapLayer.TopEdge = this.viewportSize.Y - this.mainMapLayer.TotalTileHeight;
                                }
                            }
                            break;

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
                            break;

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
                            break;

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
                            break;

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
                            break;
                    }
                    //goto Label_0647;
                    this.ResetScreenEdge();
                    this.mainMapLayer.ReCalculateTileDestination(base.GraphicsDevice);
                    this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
                    return;
                }
                this.lastTime = gameTime.TotalGameTime.TotalMilliseconds;
            }
            return;
        //Label_0647:
            //this.ResetScreenEdge();
            //this.mainMapLayer.ReCalculateTileDestination();
            //this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
        }



        private void SetTroopCombatMethod(int id)
        {
            //this.CurrentTroop.Operated = true;
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
            //this.CurrentTroop.Operated = true;
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
                else
                {
                    if (id==6) //如果是灭火
                    {
                        this.CurrentTroop.Operated = true;
                        this.CurrentTroop.mingling = "——";
                    }

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
            /*
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
             */
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
                if (GlobalVariables.DialogShowTime > 0)
                {
                    this.Plugins.PersonTextDialogPlugin.SetCloseFunction(new GameDelegates.VoidFunction(base.Scenario.ApplyTroopEvents));
                    this.Plugins.PersonTextDialogPlugin.IsShowing = true;
                }
                else
                {
                    base.Scenario.ApplyTroopEvents();
                }
            }
            else
            {
                base.Scenario.ApplyTroopEvents();
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
                    case UndoneWorkKind.tupianwenzi :
                        this.Updatetupianwenzi(gameTime);

                        break;

                    case UndoneWorkKind.liangdaobianji :

                        this.HandleLaterMouseEvent(gameTime);
                        this.ScrollTheMainMap(gameTime);

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
        private void Updatetupianwenzi(GameTime gameTime)
        {


            if (this.Plugins.tupianwenziPlugin != null)
            {
                this.Plugins.tupianwenziPlugin.Update(gameTime);
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
                this.mainMapLayer.ReCalculateTileDestination(base.GraphicsDevice);
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

        public int Currentzijin
        {
            get
            {
                return this.screenManager.Currentzijin;
            }
            set
            {
                this.screenManager.Currentzijin = value;
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
