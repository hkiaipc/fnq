using System;
using System.Collections.Generic;
using System.Linq;
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

            frmLogin f = new frmLogin();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new frmMain());
            }

            App.Default.Config.Save("config.xml");
        }
    }
}
