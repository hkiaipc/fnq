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

        #region LeaveEnum
        /// <summary>
        /// 
        /// </summary>
        public LeaveEnum LeaveEnum
        {
            get { return _leaveEnum; }
            set { _leaveEnum = value; }
        } private LeaveEnum _leaveEnum;
        #endregion //LeaveEnum

        /// <summary>
        /// 
        /// </summary>
        public KResultEnum GatherResult
        {
            get
            {
                return KResultEnumMerger.Merge(
                    this.StartWorkResult, this.StopWorkResult);
            }
        }
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

        #region WorkTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan WorkTimeSpan
        {
            get
            {
                if (IsPracticeBeginValid())
                {
                    if (IsPracticeEndValid())
                    {
                        return this.PracticeEnd - this.PracticeBegin;
                    }
                    else
                    {
                        return this.TimeStandard.Middle - this.PracticeBegin;
                    }
                }
                else
                {
                    if (IsPracticeEndValid())
                    {
                        return this.PracticeEnd - this.TimeStandard.Middle;
                    }
                    else
                    {
                        return TimeSpan.Zero;
                    }
                }
            }
        }
        #endregion //WorkTimeSpan

        #region IsPracticeBeginValid
        public bool IsPracticeBeginValid()
        {
            return this._practiceBegin != DateTime.MinValue;
        }
        #endregion //IsPracticeBeginValid

        #region IsPracticeEndValid
        public bool IsPracticeEndValid()
        {
            return this._practiceEnd != DateTime.MinValue;
        }
        #endregion //IsPracticeEndValid

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
