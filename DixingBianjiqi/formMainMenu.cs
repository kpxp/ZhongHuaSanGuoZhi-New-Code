using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using		System.Drawing;
using System.Windows.Forms;

using System.ComponentModel;
//using WMPLib;
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
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        //public MainMenuOption menuState = MainMenuOption.Logo;
        public MainMenuOption menuState = MainMenuOption.Selecting ;

        public formMainMenu()
        {
            this.InitializeComponent();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            //this.menuState = MainMenuOption.About;
            //new formAbout().ShowDialog();
          
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

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            /*
            this.menuState = MainMenuOption.Options;
            formOptions options = new formOptions();
            if (options.ShowDialog() == DialogResult.OK)
            {
            }
            */
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //this.menuState = MainMenuOption.About;
            //new formAbout().ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.menuState = MainMenuOption.ExitGame;
            base.DialogResult = DialogResult.No;
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
            /*
            if (this.menuState == MainMenuOption.Logo)
            {
                this.menuState = MainMenuOption.Selecting;
                
                this.btnStartNewGame.Visible = true;
                this.btnLoadFile.Visible = true;
                this.btnOptions.Visible = true;
                this.btnAbout.Visible = true;
                this.btnExitGame.Visible = true;
                 
 
            }
            */
        }
 

        private void InitializeComponent()
        {
            this.btnStartNewGame = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnExitGame = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartNewGame
            // 
            this.btnStartNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartNewGame.BackColor = System.Drawing.Color.Transparent;
            this.btnStartNewGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartNewGame.FlatAppearance.BorderSize = 0;
            this.btnStartNewGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnStartNewGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnStartNewGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartNewGame.Location = new System.Drawing.Point(250, 126);
            this.btnStartNewGame.Name = "btnStartNewGame";
            this.btnStartNewGame.Size = new System.Drawing.Size(312, 50);
            this.btnStartNewGame.TabIndex = 0;
            this.btnStartNewGame.Text = "开始新游戏";
            this.btnStartNewGame.UseVisualStyleBackColor = false;
            this.btnStartNewGame.Visible = false;
            this.btnStartNewGame.Click += new System.EventHandler(this.btnStartNewGame_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadFile.BackColor = System.Drawing.Color.Transparent;
            this.btnLoadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLoadFile.FlatAppearance.BorderSize = 0;
            this.btnLoadFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnLoadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnLoadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLoadFile.Location = new System.Drawing.Point(250, 182);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(312, 50);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "读取游戏进度";
            this.btnLoadFile.UseVisualStyleBackColor = false;
            this.btnLoadFile.Visible = false;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.BackColor = System.Drawing.Color.Transparent;
            this.btnOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOptions.FlatAppearance.BorderSize = 0;
            this.btnOptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnOptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOptions.Location = new System.Drawing.Point(250, 238);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(312, 50);
            this.btnOptions.TabIndex = 2;
            this.btnOptions.Text = "设置";
            this.btnOptions.UseVisualStyleBackColor = false;
            this.btnOptions.Visible = false;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnExitGame
            // 
            this.btnExitGame.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExitGame.BackColor = System.Drawing.Color.Transparent;
            this.btnExitGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExitGame.FlatAppearance.BorderSize = 0;
            this.btnExitGame.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnExitGame.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnExitGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExitGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExitGame.Location = new System.Drawing.Point(250, 350);
            this.btnExitGame.Name = "btnExitGame";
            this.btnExitGame.Size = new System.Drawing.Size(312, 50);
            this.btnExitGame.TabIndex = 4;
            this.btnExitGame.Text = "离开游戏";
            this.btnExitGame.UseVisualStyleBackColor = false;
            this.btnExitGame.Visible = false;
            this.btnExitGame.Click += new System.EventHandler(this.btnExitGame_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbout.BackColor = System.Drawing.Color.Transparent;
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAbout.Location = new System.Drawing.Point(250, 294);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(312, 50);
            this.btnAbout.TabIndex = 3;
            this.btnAbout.Text = "关于";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Visible = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(464, 223);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 39);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(464, 280);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(178, 39);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(464, 337);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(178, 39);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(464, 394);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(178, 39);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Location = new System.Drawing.Point(464, 451);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(178, 39);
            this.pictureBox5.TabIndex = 9;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // formMainMenu
            // 
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(794, 594);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnExitGame);
            this.Controls.Add(this.btnOptions);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnStartNewGame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "formMainMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "中华三国志";
            this.Load += new System.EventHandler(this.formMainMenu_Load);
            this.Click += new System.EventHandler(this.formMainMenu_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);

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

        private void formMainMenu_Load(object sender, EventArgs e)
        {
            this.BackgroundImage = Image.FromFile("Resources/Start/DixingBianjiqi.jpg");

            /*
            this.btnStartNewGame.BackgroundImage = Image.FromFile("Resources/Start/StartButton.png");
            this.btnLoadFile.BackgroundImage = Image.FromFile("Resources/Start/StartButton.png");
            this.btnOptions.BackgroundImage = Image.FromFile("Resources/Start/StartButton.png");
            this.btnAbout.BackgroundImage = Image.FromFile("Resources/Start/StartButton.png");
            this.btnExitGame.BackgroundImage = Image.FromFile("Resources/Start/StartButton.png");
             */

        }


    }

 

}
