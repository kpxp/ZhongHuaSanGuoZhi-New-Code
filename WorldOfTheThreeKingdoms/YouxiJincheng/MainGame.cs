using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using System.Reflection;

using GameGlobal;
using GameObjects;



using PluginServices;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using WorldOfTheThreeKingdoms.GameScreens;
using System.Runtime.InteropServices;

using System.Windows.Forms;
using WMPLib;

namespace WorldOfTheThreeKingdoms
{
    public class MainGame : Game
    {
        //public static  ContentManager Content;   //原程序，没有new
        public static new ContentManager Content;
        public System.Windows.Forms.Form GameForm;

        private GraphicsDeviceManager graphics;
        //private KeyboardState keyState;  //原程序，由于警告去掉
        private MainGameScreen mainGameScreen;
        private int previousWindowHeight = 720;
        private int previousWindowWidth = 0x438;
        public jiazaitishichuangkou jiazaitishi = new jiazaitishichuangkou();
        internal WindowsMediaPlayerClass Player = new WindowsMediaPlayerClass();
        //标识是否为全屏
        private bool IsFullScreen = false;

        public MainGame()
        {
            base.Content.RootDirectory = "Content";
            Content = base.Content;
            this.graphics = new GraphicsDeviceManager(this);

            //原本的分辨率默认值为720*1080，在其他大小的屏幕上会变形
            //将当前屏幕的分辨率作为默认值……
            this.previousWindowWidth = FullScreenHelper.GetSystemMetrics(FullScreenHelper.SM_CXSCREEN);
            this.previousWindowHeight = FullScreenHelper.GetSystemMetrics(FullScreenHelper.SM_CYSCREEN);

            this.graphics.PreferredBackBufferWidth = this.previousWindowWidth;
            this.graphics.PreferredBackBufferHeight = this.previousWindowHeight;
            base.Window.AllowUserResizing = true;
            DateTime buildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
            base.Window.Title = "中华三国志开发版(已命名修改版 更新补丁1.5 v.29 dev - build-" + buildDate.Year + "-" + buildDate.Month + "-" + buildDate.Day + ")"+ " 祝各位新年快乐！";

            //System.Windows.Forms.Control control = System.Windows.Forms.Control.FromHandle(base.Window.Handle);
            this.GameForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle);
            this.GameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            //this.GameForm = control as System.Windows.Forms.Form;
            this.GameForm.KeyDown += new KeyEventHandler(this.GameForm_KeyDown);
            int uFlags = 0x400;
            IntPtr systemMenu = GetSystemMenu(base.Window.Handle, false);
            int menuItemCount = GetMenuItemCount(systemMenu);
            RemoveMenu(systemMenu, menuItemCount - 1, uFlags);
            RemoveMenu(systemMenu, menuItemCount - 2, uFlags);
            Plugin.Plugins.FindPlugins(AppDomain.CurrentDomain.BaseDirectory + "GameComponents");
            Plugin.Plugins.FindPlugins(AppDomain.CurrentDomain.BaseDirectory + "GamePlugins");
            this.mainGameScreen = new MainGameScreen(this);
            base.Components.Add(this.mainGameScreen);
        }

        private static bool AltComboPressed(KeyboardState state, Microsoft.Xna.Framework.Input.Keys key)
        {
            return (state.IsKeyDown(key) && (state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftAlt) || state.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightAlt)));
        }

        protected override void Dispose(bool disposing)
        {
            Plugin.Plugins.ClosePlugins();
        }

        protected override void Draw(GameTime gameTime)
        {
            this.graphics.GraphicsDevice.Clear(Color.TransparentBlack);
            base.Draw(gameTime);
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && (e.KeyCode == System.Windows.Forms.Keys.F4))
            {
                e.Handled = true;
            }
        }

        [DllImport("user32.dll")]
        internal static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("user32.dll")]
        internal static extern IntPtr GetSystemMenu(IntPtr hwnd, bool bRevert);
        protected override void Initialize()
        {
            base.Initialize();
            
            this.jiazaitishi.Close();

            //全屏的判断放到初始化代码中
            if (GlobalVariables.FullScreen)
            {
                this.ToggleFullScreen();
            }
        }

        [DllImport("user32.dll")]
        internal static extern int RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);
        public void ToggleFullScreen()
        {
            //原来的代码会和单挑程序冲突
            /*
            if (this.graphics.GraphicsDevice.PresentationParameters.IsFullScreen)
            {
                this.graphics.PreferredBackBufferWidth = this.previousWindowWidth;
                this.graphics.PreferredBackBufferHeight = this.previousWindowHeight;
            }
            else
            {
                this.previousWindowWidth = this.graphics.GraphicsDevice.Viewport.Width;
                this.previousWindowHeight = this.graphics.GraphicsDevice.Viewport.Height;
                GraphicsAdapter adapter = this.graphics.GraphicsDevice.CreationParameters.Adapter;
                FullScreenHelper.FullScreen();
                this.graphics.PreferredBackBufferWidth = adapter.CurrentDisplayMode.Width;
                this.graphics.PreferredBackBufferHeight = adapter.CurrentDisplayMode.Height;
            }
            this.graphics.ToggleFullScreen();
            GlobalVariables.FullScreen = this.graphics.GraphicsDevice.PresentationParameters.IsFullScreen;
             */
            //修改后的全屏代码
            if (this.IsFullScreen)
            {
                FullScreenHelper.RestoreFullScreen(this.GameForm.Handle);//传入窗体句柄
                this.IsFullScreen = false;

            }
            else
            {
                FullScreenHelper.FullScreen(this.GameForm.Handle);
                this.IsFullScreen = true;
            }
        }

        private void TryToExit()
        {
            this.mainGameScreen.TryToExit();
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (base.IsActive)
            {
                if (AltComboPressed(this.mainGameScreen.KeyState, Microsoft.Xna.Framework.Input.Keys.F4))
                {
                    this.TryToExit();
                }
                if (AltComboPressed(this.mainGameScreen.KeyState, Microsoft.Xna.Framework.Input.Keys.Enter) && (this.mainGameScreen.PeekUndoneWork().Kind == UndoneWorkKind.None))
                {
                    this.mainGameScreen.ToggleFullScreen();
                }
                //游戏设置中的全屏选项勾选后将多次调用这个方法，界面会闪来闪去
                //只在初始化的时候全屏一次就好啦……
                /*if ((GlobalVariables.FullScreen && !this.mainGameScreen.IsFullScreen) || (!GlobalVariables.FullScreen && this.mainGameScreen.IsFullScreen))
                {
                    this.mainGameScreen.ToggleFullScreen();
                }*/
            }
        }
        
        public void SaveGameWhenCrash(String _savePath)
        {
            this.mainGameScreen.SaveGameWhenCrash(_savePath);
        }

        public List<int> InitializationFactionIDs
        {
            set
            {
                this.mainGameScreen.InitializationFactionIDs = value;
            }
        }

        public string InitializationFileName
        {
            set
            {
                this.mainGameScreen.InitializationFileName = value;
            }
        }

        public bool LoadScenarioInInitialization
        {
            set
            {
                this.mainGameScreen.LoadScenarioInInitialization = value;
            }
        }
    }

 

}
