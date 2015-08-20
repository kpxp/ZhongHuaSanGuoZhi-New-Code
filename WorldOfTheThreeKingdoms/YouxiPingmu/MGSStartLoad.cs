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
//using GameObjects.PersonDetail.PersonMessages;
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
        public override void Initialize()
        {
            
            this.thisGame.jiazaitishi.jiazaijindu.Value = 10;
            
            base.Initialize();
            this.thisGame.jiazaitishi.jiazaijindu.Value = 20;
            this.Plugins.InitializePlugins(this);
            this.thisGame.jiazaitishi.jiazaijindu.Value = 40;

            this.mainMapLayer.Initialize(base.Scenario, this, base.spriteBatch.GraphicsDevice);
            this.thisGame.jiazaitishi.jiazaijindu.Value = 60;
            
            if (base.LoadScenarioInInitialization)
            {
                this.LoadScenario(base.InitializationFileName, base.InitializationFactionIDs);
                //this.mainMapLayer.jiazaibeijingtupian();


                base.Scenario.InitializeScenarioPlayerFactions(base.InitializationFactionIDs);

                if (base.Scenario.PlayerFactions.Count == 0)
                {
                    oldDialogShowTime = GlobalVariables.DialogShowTime;
                    GlobalVariables.DialogShowTime = 0;
                }
                else
                {
                    if (oldDialogShowTime >= 0)
                    {
                        GlobalVariables.DialogShowTime = oldDialogShowTime;
                    }
                }

                if (base.Scenario.PlayerFactions.Count > 0)   //开始新游戏
                {
                    foreach (Faction faction in base.Scenario.PlayerFactions)
                    {
                        if (faction.FirstSection != null)
                        {
                            //faction.FirstSection.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(0, false, false, false, false, false)[0] as SectionAIDetail;
                            faction.FirstSection.AIDetail = base.Scenario.GameCommonData.AllSectionAIDetails.GetSectionAIDetailsByConditions(SectionOrientationKind.无, false, false, false, false, false)[0] as SectionAIDetail;

                        }
                    }
                    foreach (Architecture jianzhu in base.Scenario.Architectures)
                    {

                        jianzhu.youzainan = false;
                        if (base.Scenario.IsPlayer(jianzhu.BelongedFaction))
                        {
                            jianzhu.AutoHiring = true;
                            jianzhu.AutoRewarding = true;

                        }
                    }
                    /*
                    foreach (Person wujiang in base.Scenario.Persons)
                    {
                        wujiang.huaiyun = false;
                        wujiang.faxianhuaiyun = false;
                        wujiang.huaiyuntianshu = -1;
                        wujiang.suoshurenwu = -1;
                    }*/
                    this.JumpTo((base.Scenario.PlayerFactions[0] as Faction).Leader.Position);        //地图跳到玩家势力的首领处
                    base.Scenario.CurrentPlayer = base.Scenario.PlayerFactions[0] as Faction;
                }

                this.chushihuajianzhubiaotiheqizi();

                if (base.Scenario.CurrentPlayer != null)
                {
                    base.Scenario.runScenarioStart(base.Scenario.CurrentPlayer.Capital);
                }

            }
            else  //从开始菜单读取游戏
            {
                this.LoadFileName = base.InitializationFileName;
                this.LoadGameFromDisk();
            }

            this.thisGame.Player.stop();
            
            this.thisGame.jiazaitishi.jiazaijindu.Value = 80;

            this.architectureLayer.Initialize(this.mainMapLayer, base.Scenario,this);
            this.mapVeilLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.troopLayer.Initialize(this.mainMapLayer, base.Scenario, this);
            this.selectingLayer.Initialize(this.mainMapLayer, this);
            this.tileAnimationLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.routewayLayer.Initialize(this.mainMapLayer, base.Scenario);
            this.screenManager.Initialize(base.Scenario);

            if (base.Scenario.CurrentPlayer != null)
            {
                this.Showyoucelan(UndoneWorkKind.None, FrameKind.Architecture, FrameFunction.Jump, false, true, false, false, base.Scenario.CurrentPlayer.FirstSection.Architectures, null, "", "");
                this.Plugins.youcelanPlugin.IsShowing = true;
            }
            this.thisGame.jiazaitishi.jiazaijindu.Value = 90;

        }

        private void chushihuajianzhubiaotiheqizi()
        {
            System.Drawing.Font fontjianzhu = new System.Drawing.Font("华文中宋", 16f);
            Microsoft.Xna.Framework.Graphics.Color colorjianzhu = new Color();
            colorjianzhu.PackedValue = uint.Parse("4278255615");

            //System.Drawing.Font font1 = new System.Drawing.Font("方正北魏楷书繁体", 30f);   //方正北魏楷书繁体
            //Microsoft.Xna.Framework.Graphics.Color color1 = new Color(1f, 1f, 1f);

            qizidezi = new FreeText(base.spriteBatch.GraphicsDevice, new System.Drawing.Font("方正北魏楷书繁体", 30f), new Color(1f, 1f, 1f));


            foreach (Architecture jianzhu in base.Scenario.Architectures)
            {

                //jianzhu.jianzhubiaoti = new FreeText(spriteBatch.GraphicsDevice, fontjianzhu, colorjianzhu);
                ///////jianzhu.jianzhubiaoti.DisplayOffset = new Point(0, -mainMapLayer.TileWidth / 2);
                //jianzhu.jianzhubiaoti.Text = jianzhu.Name;
                //jianzhu.jianzhubiaoti.Align = TextAlign.Left;
                jianzhu.jianzhuqizi = new qizi();
                //jianzhu.jianzhuqizi.qizidezi = new FreeText(spriteBatch.GraphicsDevice, font1, color1);
                try
                {
                    jianzhu.CaptionTexture = Texture2D.FromFile(base.spriteBatch.GraphicsDevice, "Resources/Architecture/Caption/" +jianzhu.CaptionID + ".png");
                }
                catch
                {
                    jianzhu.CaptionTexture = Texture2D.FromFile(base.spriteBatch.GraphicsDevice, "Resources/Architecture/Caption/None.png");
                }
                /*
                if (jianzhu.BelongedFaction != null)
                {
                    jianzhu.jianzhuqizi.qizidezi.Text = jianzhu.BelongedFaction.ToString().Substring(0, 1);
                }*/

                this.qizidezi.Align = TextAlign.Middle;


                jianzhu.jianzhuqizi.qizipoint = new Point(jianzhu.dingdian.X, jianzhu.dingdian.Y-1);

            }
        }

        public bool LoadAvail()
        {
            return base.Scenario.LoadAvail();
        }

        public bool SaveAvail()
        {
            return base.Scenario.SaveAvail();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void LoadGame()   //从游戏里读取存档
        {
            this.Plugins.OptionDialogPlugin.SetStyle("SaveAndLoad");
            this.Plugins.OptionDialogPlugin.SetTitle("读取进度");
            this.Plugins.OptionDialogPlugin.Clear();
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save01" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition01));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save02" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition02));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save03" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition03));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save04" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition04));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save05" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition05));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save06" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition06));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save07" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition07));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save08" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition08));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save09" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition09));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("Save10" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromPosition10));
            this.Plugins.OptionDialogPlugin.AddOption(this.GetSaveFileDisplayText("AutoSave" + this.SaveFileExtension), null, new GameDelegates.VoidFunction(this.LoadGameFromAutoPosition));

            this.Plugins.OptionDialogPlugin.EndAddOptions();
            this.Plugins.OptionDialogPlugin.ShowOptionDialog(ShowPosition.Center);
        }

        public void LoadGameFromDisk()
        {
            this.LoadGameFromDisk("GameData/Save/" + this.LoadFileName);
        }

        public void LoadGameFromDisk(String fileName)
        {
            base.Scenario.EnableLoadAndSave = false;
            if (!File.Exists(fileName))
            {
                base.Scenario.EnableLoadAndSave = true;
            }
            else
            {
                this.Plugins.DateRunnerPlugin.Reset();
                this.Plugins.GameRecordPlugin.Clear();
                this.Plugins.GameRecordPlugin.RemoveDisableRects();
                this.Plugins.AirViewPlugin.RemoveDisableRects();

                string realPath = fileName.Substring(0, fileName.Length - 4) + ".mdb";

                if (this.LoadFileName.EndsWith(".zhs"))
                {
                    FileEncryptor.DecryptFile(fileName, realPath, GlobalVariables.cryptKey);
                }

                OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
                {
                    DataSource = realPath,
                    Provider = "Microsoft.Jet.OLEDB.4.0"
                };
                base.Scenario.LoadSaveFileFromDatabase(builder.ConnectionString, fileName);

                if (GlobalVariables.EncryptSave)
                {
                    File.Delete(realPath);
                }

                this.ReloadScreenData();

                base.Scenario.EnableLoadAndSave = true;

            }
        }

        public override void ReloadScreenData()
        {
            //this.mainMapLayer.jiazaibeijingtupian();

            this.chushihuajianzhubiaotiheqizi();
            this.gengxinyoucelan();
        }

        private void LoadGameFromAutoPosition()
        {
            this.LoadFileName = "AutoSave" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition01()
        {
            this.LoadFileName = "Save01" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition02()
        {
            this.LoadFileName = "Save02" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition03()
        {
            this.LoadFileName = "Save03" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition04()
        {
            this.LoadFileName = "Save04" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition05()
        {
            this.LoadFileName = "Save05" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition06()
        {
            this.LoadFileName = "Save06" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition07()
        {
            this.LoadFileName = "Save07" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition08()
        {
            this.LoadFileName = "Save08" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition09()
        {
            this.LoadFileName = "Save09" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        private void LoadGameFromPosition10()
        {
            this.LoadFileName = "Save10" + this.SaveFileExtension;
            Thread thread = new Thread(new ThreadStart(this.LoadGameFromDisk));
            thread.Start();
            thread.Join();
            thread = null;
        }

        public bool LoadScenario(string filename, List<int> playerFactions)
        {
            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                DataSource = filename,
                Provider = "Microsoft.Jet.OLEDB.4.0"
            };
            return base.Scenario.LoadGameScenarioFromDatabase(builder.ConnectionString, playerFactions);
        }

        private void Scenario_OnAfterLoadScenario(GameScenario scenario)
        {
            this.Textures.LoadTextures(base.spriteBatch.GraphicsDevice, base.Scenario);
            base.DefaultMouseArrowTexture = this.Textures.MouseArrowTextures[0];

            if (this.mainMapLayer.mainMap != null)
            {
                this.mainMapLayer.PrepareMap();
                this.UpdateViewport();
                this.ResetScreenEdge();
                this.mainMapLayer.ReCalculateTileDestination(base.spriteBatch.GraphicsDevice);
                this.JumpTo(this.mainMapLayer.mainMap.JumpPosition);
            }
            if (this.Plugins.GameRecordPlugin.IsRecordShowing)
            {
                this.Plugins.GameRecordPlugin.AddDisableRects();
            }
            this.Plugins.AirViewPlugin.ResetMapPosition();
            this.Plugins.AirViewPlugin.ResetFramePosition(base.viewportSize, this.mainMapLayer.LeftEdge, this.mainMapLayer.TopEdge, this.mainMapLayer.TotalMapSize);
            if (base.Scenario.ScenarioMap.MapName != null)
            {
                this.Plugins.AirViewPlugin.ReloadAirView(base.Scenario.ScenarioMap.MapName + ".jpg");
            }
            else
            {
                this.Plugins.AirViewPlugin.ReloadAirView();
            }
            if (this.Plugins.AirViewPlugin.IsMapShowing)
            {
                this.Plugins.AirViewPlugin.AddDisableRects();
            }
        }
    }
}
