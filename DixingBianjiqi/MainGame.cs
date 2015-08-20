using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;
using		GameObjects;



using		PluginServices;


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

        public MainGame()
        {
            base.Content.RootDirectory = "Content";
            Content = base.Content;
            this.graphics = new GraphicsDeviceManager(this);
            this.graphics.PreferredBackBufferWidth = this.previousWindowWidth;
            this.graphics.PreferredBackBufferHeight = this.previousWindowHeight;
            base.Window.AllowUserResizing = true;
            base.Window.Title = "中华三国志";

            System.Windows.Forms.Control control = System.Windows.Forms.Control.FromHandle(base.Window.Handle);
            GameForm = (System.Windows.Forms.Form)System.Windows.Forms.Form.FromHandle(this.Window.Handle);
            GameForm.WindowState = System.Windows.Forms.FormWindowState.Maximized;


            this.GameForm = control as System.Windows.Forms.Form;
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
        }

        [DllImport("user32.dll")]
        internal static extern int RemoveMenu(IntPtr hMenu, int uPosition, int uFlags);
        public void ToggleFullScreen()
        {
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
                this.graphics.PreferredBackBufferWidth = adapter.CurrentDisplayMode.Width;
                this.graphics.PreferredBackBufferHeight = adapter.CurrentDisplayMode.Height;
            }
            this.graphics.ToggleFullScreen();
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
            }
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
