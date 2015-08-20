using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using		GameGlobal;


using System.Windows.Forms;
using WorldOfTheThreeKingdoms.GameForms;



namespace WorldOfTheThreeKingdoms.GameProcesses
{
    internal class MainProcessManager
    {
        private Parameters gameParameters = new Parameters();
        private GlobalVariables globalVariables = new GlobalVariables();
        public static MainGame mainGame = new MainGame();

        public void Processing()
        {
            formMainMenu menu = new formMainMenu
            {
                mainGame = MainProcessManager.mainGame
            };
            mainGame.Player.URL = @"GameMusic\Start.mp3";
            mainGame.Player.play();
            if (menu.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.globalVariables.InitialGlobalVariables();
                this.gameParameters.InitializeGameParameters();
                
                mainGame.jiazaitishi.Show();
                mainGame.jiazaitishi.Refresh();
                mainGame.Run();
            }
        }
        
        public void SaveGameWhenCrash(String _savePath)
        {
            mainGame.SaveGameWhenCrash(_savePath);
        }
    }
}
