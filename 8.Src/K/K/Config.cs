
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KDB;
using Xdgk.Common;


namespace K
{
    public class Config
    {
        static public Config Default
        {
            get
            {
                if (_default == null)
                {
                    _default = new Config();
                }
                return _default;
            }
        } static private Config _default;

#region NormalTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalTimeSpan
        {
            get
            {
                return _normalTimeSpan;
            }
            set
            {
                _normalTimeSpan = value;
            }
        } private TimeSpan _normalTimeSpan = TimeSpan.FromHours(2d);
#endregion //NormalTimeSpan

#region LaterEarlyTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan LaterEarlyTimeSpan
        {
            get
            {
                return _laterEarlyTimeSpan;
            }
            set
            {
                _laterEarlyTimeSpan = value;
            }
        } private TimeSpan _laterEarlyTimeSpan = TimeSpan.FromHours(2d);
#endregion //LaterEarlyTimeSpan
    }

}
