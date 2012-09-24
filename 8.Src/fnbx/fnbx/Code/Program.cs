using System;
using System.IO;
using System.Windows.Forms;

namespace fnbx
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //new _Test();
            //return;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //new frmPrint().ShowDialog();
            frmLogin f = new frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }

            string path = Path.Combine(Application.StartupPath, "config.xml");
            App.Default.Config.Save(path);
        }
    }
}
