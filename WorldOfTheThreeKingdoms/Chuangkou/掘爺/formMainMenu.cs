using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using		System.Drawing;
using System.Windows.Forms;

using System.ComponentModel;
using WMPLib;
using System.IO;
//using Microsoft.Xna.Framework.Graphics;

namespace WorldOfTheThreeKingdoms.GameForms

{
    public class formMainMenu : Form
    {
        private Button btnAbout;
        private Button btnExitGame;
        private Button btnLoadFile;
        private Button btnOptions;
        private Button btnStartNewGame;
        private IContainer components = null;
        public MainGame mainGame;
        public MainMenuOption menuState = MainMenuOption.Logo;
        //internal  WindowsMediaPlayerClass Player=new WindowsMediaPlayerClass();

        public formMainMenu()
        {
            this.InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.About;
            new formAbout().ShowDialog();
          
        }

        private void btnExitGame_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.ExitGame;
            base.DialogResult = DialogResult.No;
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.LoadGame;
            formSelectSaveFile file = new formSelectSaveFile();
            if (file.ShowDialog() == DialogResult.OK)
            {
                this.mainGame.LoadScenarioInInitialization = false;
                this.mainGame.InitializationFileName = file.SaveFilePath;
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.Options;
            formOptions options = new formOptions();
            if (options.ShowDialog() == DialogResult.OK)
            {
            }
        }

        private void btnStartNewGame_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.StartGame;
            formSelectScenario scenario = new formSelectScenario();
            if (scenario.ShowDialog() == DialogResult.OK)
            {
                this.mainGame.LoadScenarioInInitialization = true;
                this.mainGame.InitializationFileName = scenario.ScenarioPath;
                this.mainGame.InitializationFactionIDs = scenario.SelectedFactionIDs;
                base.DialogResult = DialogResult.OK;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void formMainMenu_Click(object sender, EventArgs e)
        {
            if (this.menuState == MainMenuOption.Logo)
            {
                this.menuState = MainMenuOption.Selecting;
                this.btnStartNewGame.Visible = true;
                this.btnLoadFile.Visible = true;
                this.btnOptions.Visible = true;
                this.btnAbout.Visible = true;
                this.btnExitGame.Visible = true;
            }
        }
        /*
        public void PauseMusic()
        {
            if ((this.Player.playState == WMPPlayState.wmppsPlaying))
            {
                this.Player.pause();
            }
        }



        private void Player_PlayStateChange(int NewState)
        {
            if ( (NewState == 1))
            {
                this.Player.play();
            }
        }

        public void PlayMusic(string musicFileLocation)
        {
            if ( File.Exists(musicFileLocation))
            {
                this.Player.URL = musicFileLocation;
            }
        }
        public void StopMusic()
        {
            if (this.Player.playState == WMPPlayState.wmppsPlaying)
            {
                this.Player.stop();
            }
        }
        */

        private void InitializeComponent()
        {
            //System.Media.SoundPlayer StartMusic = new System.Media.SoundPlayer(@"GameMusic\Start.wav");
            //StartMusic.Play(); 
            //this.Player.PlayStateChange += (new _WMPOCXEvents_PlayStateChangeEventHandler(this.Player_PlayStateChange));



            ComponentResourceManager manager = new ComponentResourceManager(typeof(formMainMenu));
            this.btnStartNewGame = new Button();
            this.btnLoadFile = new Button();
            this.btnOptions = new Button();
            this.btnExitGame = new Button();
            this.btnAbout = new Button();
            base.SuspendLayout();
            this.btnStartNewGame.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnStartNewGame.FlatStyle = FlatStyle.Popup;
            this.btnStartNewGame.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnStartNewGame.Location = new Point(250, 0x7e);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new Size(0x138, 50);
            this.btnStartNewGame.TabIndex = 0;
            this.btnStartNewGame.Text = "开始新游戏";
            this.btnStartNewGame.UseVisualStyleBackColor = true;
            this.btnStartNewGame.Visible = false;
            this.btnStartNewGame.Click += new EventHandler(this.btnStartNewGame_Click);
            this.btnLoadFile.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnLoadFile.FlatStyle = FlatStyle.Popup;
            this.btnLoadFile.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnLoadFile.Location = new Point(250, 0xb6);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new Size(0x138, 50);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "读取游戏进度";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Visible = false;
            this.btnLoadFile.Click += new EventHandler(this.btnLoadFile_Click);
            this.btnOptions.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnOptions.FlatStyle = FlatStyle.Popup;
            this.btnOptions.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnOptions.Location = new Point(250, 0xee);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new Size(0x138, 50);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "设置";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Visible = false;
            this.btnOptions.Click += new EventHandler(this.btnOptions_Click);
            this.btnExitGame.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnExitGame.FlatStyle = FlatStyle.Popup;
            this.btnExitGame.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnExitGame.Location = new Point(250, 350);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new Size(0x138, 50);
            this.btnExitGame.TabIndex = 4;
            this.btnExitGame.Text = "离开游戏";
            this.btnExitGame.UseVisualStyleBackColor = true;
            this.btnExitGame.Visible = false;
            this.btnExitGame.Click += new EventHandler(this.btnExitGame_Click);
            this.btnAbout.Anchor = AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top;
            this.btnAbout.FlatStyle = FlatStyle.Popup;
            this.btnAbout.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnAbout.Location = new Point(250, 0x126);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new Size(0x138, 50);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Visible = false;
            this.btnAbout.Click += new EventHandler(this.btnAbout_Click);
            this.AutoSize = true;
            //this.BackgroundImage = (Image)manager.GetObject("$this.BackgroundImage");
            this.BackgroundImage = Image.FromFile("Resources/logo.bmp");
            this.BackgroundImageLayout = ImageLayout.Center;
            base.ClientSize = new Size(0x31a, 0x252);
            base.Controls.Add(this.btnAbout);
            base.Controls.Add(this.btnExitGame);
            base.Controls.Add(this.btnOptions);
            base.Controls.Add(this.btnLoadFile);
            base.Controls.Add(this.btnStartNewGame);
            base.FormBorderStyle = FormBorderStyle.None;
            //base.Icon = (Icon)manager.GetObject("$this.Icon");
            base.MaximizeBox = false;
            base.Name = "formMainMenu";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "中华三国志";
            base.Click += new EventHandler(this.formMainMenu_Click);
            base.ResumeLayout(false);




        }

        public enum MainMenuOption
        {
            Logo,
            Selecting,
            StartGame,
            LoadGame,
            Options,
            About,
            ExitGame
        }
    }

 

}
