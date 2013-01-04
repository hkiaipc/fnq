using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Xdgk.Common;

namespace K
{

    class App : AppBase
    {
        public override Form MainForm
        {
            get 
            {
                if (_main == null)
                {
                    _main = new frmMain();
                }
                return _main ; 
            }
        }
        private frmMain _main;
    }

    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            App app = new App();
            app.Run();
        }
    }
}
