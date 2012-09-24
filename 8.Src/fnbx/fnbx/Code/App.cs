using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB;

namespace fnbx
{
    /// <summary>
    /// 
    /// </summary>
    public class App
    {
        private App()
        {
        }

        static public App Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new App();
                }
                return _default;
            }
        } static private App _default;

        /// <summary>
        /// 
        /// </summary>
        public tblOperator LoginOperator
        {
            get
            {
                //if (_loginOperator == null)
                //{
                //    using (var db = DBFactory.CreateDataContext())
                //    {
                //        // TODO:
                //        //
                //        //BxdbDataContext db = DBFactory.GetBxdbDataContext();
                //        //_loginOperator = db.tblOperator.ToArray()[0];
                //        _loginOperator = db.tblOperator.First();
                //    }
                //}
                return _loginOperator;
            }
            set
            {
                Debug.Assert(value != null);
                _loginOperator = value;
            }
        } private tblOperator _loginOperator;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Right  GetLoginOperatorRight()
        {
            return Right.GetRight(LoginOperator.tblRight.rt_value);
        }

        /// <summary>
        /// 
        /// </summary>
        public Config Config
        {
            get
            {
                if (_config == null)
                {
                    try
                    {
                        string path = Path.Combine(Application.StartupPath, "config.xml");
                        _config = (Config)Config.Load(typeof(Config), path);

                    }
                    catch (Exception ex)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                        _config = new Config();
                    }
                    if (_config.StatusColors == null || _config.StatusColors.Count == 0)
                    {
                        _config.StatusColors = Config.GetDefaultStatusColors();
                    }
                }
                return _config;
            }
        } private Config _config;
    }
}
