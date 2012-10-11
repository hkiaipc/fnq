using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Xdgk.Common;

namespace FNGRQRC
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CommandLineOptions cmdLineOpt = new CommandLineOptions(args);
            IntPtr handle, hwnd;

            bool hasPreInst = Xdgk.Common.Diagnostics.HasPreInstance(out handle, out hwnd);
            //Console.WriteLine("hasPreInst: " + hasPreInst);
            if ( hasPreInst )
            {
                COPYDATASTRUCT cds = CreateCopyDataStruct(cmdLineOpt);

                Win32API.SendMessage(
                    (int)hwnd, 
                    WindowMessageCode.WM_COPYDATA,
                    0, ref cds);

                Win32API.SetForegroundWindow((int)hwnd);
                return;
            }

            NUnit.Core.InternalTrace.Initialize("czgrqrc_%p.log");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin f = new frmLogin();
            DialogResult dr = f.ShowDialog();
            if (dr != DialogResult.OK)
                return;

            frmMain frmmain = new frmMain(cmdLineOpt);
            CZGRQRCApp.Default.frmMain = frmmain;
            Application.Run(frmmain);
            OnExit();
        }

        /// <summary>
        /// 
        /// </summary>
        static private void OnExit()
        {
            Config.Default.Save();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Xdgk.Common.ExceptionHandler.Handle(e.Exception);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cmdLineOpt"></param>
        /// <returns></returns>
        private static COPYDATASTRUCT CreateCopyDataStruct(CommandLineOptions cmdLineOpt)
        {
            //string s = string.Format("/stationName:{0} /data:{1} /appearance:{2}",
            //    cmdLineOpt.StationName, cmdLineOpt.Data, cmdLineOpt.Appearance);

            string s = cmdLineOpt.GetArgsString();
            byte[] bs = System.Text.Encoding.Default.GetBytes(s);

            COPYDATASTRUCT cds = new COPYDATASTRUCT();
            cds.dwData = (IntPtr)100;
            cds.cbData = bs.Length + 1;
            cds.lpData = s;
            return cds;
        }
    }
}
