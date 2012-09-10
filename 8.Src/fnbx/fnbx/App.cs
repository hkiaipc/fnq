using System;
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
                if (_loginOperator == null)
                {
                    // TODO:
                    //
                    BxdbDataContext dc = Class1.GetBxdbDataContext ();
                    _loginOperator = dc.tblOperator.ToArray()[0];
                }
                return _loginOperator;
            }
            set
            {
                Debug.Assert(value != null);
                _loginOperator = value;
            }
        } private tblOperator _loginOperator;
    }
}
