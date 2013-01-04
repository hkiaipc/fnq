
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
    internal class TimeResult
    {
        #region TimeStandard
        /// <summary>
        /// 
        /// </summary>
        public TimeStandard TimeStandard
        {
            get
            {
                return _timeStandard;
            }
            set
            {
                _timeStandard = value;
            }
        } private TimeStandard _timeStandard;
        #endregion //TimeStandard

        #region StartWorkResult
        /// <summary>
        /// 
        /// </summary>
        public KResultEnum StartWorkResult
        {
            get
            {
                return _startWorkResult;
            }
            set
            {
                _startWorkResult = value;
            }
        } private KResultEnum _startWorkResult;
        #endregion //StartWorkResult

        #region StopWorkResult
        /// <summary>
        /// 
        /// </summary>
        public KResultEnum StopWorkResult
        {
            get
            {
                return _stopWorkResult;
            }
            set
            {
                _stopWorkResult = value;
            }
        } private KResultEnum _stopWorkResult;
        #endregion //StopWorkResult

        //#region KQResultEnum
        ///// <summary>
        ///// 
        ///// </summary>
        //public KResultEnum KResultEnum
        //{
        //    get
        //    {
        //        return _kResultEnum;
        //    }
        //    set
        //    {
        //        _kResultEnum = value;
        //    }
        //} private KResultEnum _kResultEnum;
        //#endregion //KQResultEnum

        #region PracticeBegin
        /// <summary>
        /// 
        /// </summary>
        public DateTime PracticeBegin
        {
            get
            {
                return _practiceBegin;
            }
            set
            {
                _practiceBegin = value;
            }
        } private DateTime _practiceBegin;
        #endregion //PracticeBegin

        #region PracticeEnd
        /// <summary>
        /// 
        /// </summary>
        public DateTime PracticeEnd
        {
            get
            {
                return _practiceEnd;
            }
            set
            {
                _practiceEnd = value;
            }
        } private DateTime _practiceEnd;
        #endregion //PracticeEnd

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan WorkTimeSpan
        {
            get
            {
                return this.PracticeEnd - PracticeBegin;
            }
        }
        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get
            {
                if (_remark == null)
                {
                    _remark = string.Empty;
                }
                return _remark;
            }
            set
            {
                _remark = value;
            }
        } private string _remark;
        #endregion //Remark
    }

}
