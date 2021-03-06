﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    ///
    /// </summary>
    public class GRAlarmData
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="stationName"></param>
        /// <param name="content"></param>
        public GRAlarmData(DateTime dt, string displayName, string content)
        {
            this.DT = dt;
            this.DisplayName = displayName;
            this.Content = content;
        }
        #region DT
        /// <summary>
        /// 
        /// </summary>
        public DateTime DT
        {
            get { return _dT; }
            set { _dT = value; }
        } private DateTime _dT;
        #endregion //DT

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        } private string _displayName;
        #endregion //StationName

        #region Content
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        } private string _content;
        #endregion //Content
    }
}
