using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ScenarioGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string exeDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            Directory.SetCurrentDirectory(exeDir);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (System.Diagnostics.Debugger.IsAttached)
            {
                Application.Run(new Form1());
            }
            else
            {
                try
                {
                    Application.Run(new Form1());
                }
                catch (Exception e)
                {

                    DateTime dt = System.DateTime.Now;
                    String dateSuffix = "_" + dt.Year + "_" + dt.Month + "_" + dt.Day + "_" + dt.Hour + "h" + dt.Minute;
                    String logPath = "CrashLog" + dateSuffix + ".log";
                    StreamWriter sw = new StreamWriter(new FileStream(logPath, FileMode.Create));

                    sw.WriteLine("==================== Message ====================");
                    sw.WriteLine(e.Message);
                    sw.WriteLine("=================== StackTrace ==================");
                    sw.WriteLine(e.StackTrace);

                    sw.Close();

                    String savePath = "CrashSave" + dateSuffix + (GameGlobal.GlobalVariables.EncryptSave ? ".zhs" : ".mdb");
                    MessageBox.Show("中华三国志遇到严重错误，请提交游戏目录下的'" + logPath + "'。", "游戏错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
