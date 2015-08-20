using System;

using System.Windows.Forms;

using System.Threading;
using WorldOfTheThreeKingdoms.GameProcesses;

namespace WorldOfTheThreeKingdoms
{
#if WINDOWS || XBOX
    internal static class Program
    {
        private static void Main(string[] args)
        {
            
            bool flag;
            Mutex mutex = new Mutex(true, "WorldOfTheThreeKingdoms", out flag);
            if (!flag)
            {
                MessageBox.Show("游戏已经在运行中。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                mutex.ReleaseMutex();
                new MainProcessManager().Processing();
            }
        }
    }

 

#endif
}

