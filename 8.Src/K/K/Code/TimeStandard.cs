
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
    internal class TimeStandard
    {

        #region TypeEnum
        /// <summary>
        /// 
        /// </summary>
        internal enum TypeEnum
        {
            Work,
            Rest,
        }
        #endregion //TypeEnum

        #region CreateRestTimeStandard
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        static internal TimeStandard CreateRestTimeStandard(DateTime day)
        {
            return new TimeStandard(TypeEnum.Rest, day.Date, day.Date + TimeSpan.FromDays(1d),
                TimeSpan.Zero, TimeSpan.Zero);
        }
        #endregion //CreateRestTimeStandard

        #region CreateWorkTimeStandard
        /// <summary>
        /// 
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static internal TimeStandard CreateWorkTimeStandard(DateTime begin, DateTime end, 
            TimeSpan normalBeginTimeSpan, TimeSpan normalEndTimeSpan)
        {
            return new TimeStandard(TypeEnum.Work, begin, end, normalBeginTimeSpan, normalEndTimeSpan);
        }
        #endregion //CreateWorkTimeStandard

        #region TimeStandard
        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeEnum"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private TimeStandard(TypeEnum typeEnum, DateTime begin, DateTime end, TimeSpan normalBeginTimeSpan, TimeSpan normalEndTimeSpan)
        {
            Debug.Assert(end >= begin);

            this._typeEnum = typeEnum;
            this._begin = begin;
            this._end = end;

            this._middle = this._begin + TimeSpan.FromSeconds((this._end - this._begin).TotalSeconds / 2);


            this.NormalBeginTimeSpan = normalBeginTimeSpan;
            this.NormalEndTimeSpan = normalEndTimeSpan;
        }
        #endregion //TimeStandard

        #region Type
        internal TypeEnum Type
        {
            get { return _typeEnum; }
        } private TypeEnum _typeEnum;
        #endregion //Type

        #region DayOfWeek
        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get
            {
                return _begin.DayOfWeek;
            }
        } 
        #endregion //DayOfWeek

        #region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get
            {
                return _begin;
            }
        } private DateTime _begin;
        #endregion //Begin

        #region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get
            {
                return _end;
            }
        } private DateTime _end;
        #endregion //End


        /// <summary>
        /// 
        /// </summary>
        public DateTime Middle
        {
            get
            {
                return _middle; 
            }
        } private DateTime _middle;


        #region NormalBeginTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalBeginTimeSpan
        {
            get
            {
                return _normalBeginTimeSpan;
            }
            set
            {
                _normalBeginTimeSpan = value;
            }
        } private TimeSpan _normalBeginTimeSpan;
        #endregion //NormalBeginTimeSpan

        #region NormalEndTimeSpan
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan NormalEndTimeSpan
        {
            get
            {
                return _normalEndTimeSpan;
            }
            set
            {
                _normalEndTimeSpan = value;
            }
        } private TimeSpan _normalEndTimeSpan;
        #endregion //NormalEndTimeSpan


        #region GetPunchInDateTimeRange
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public DateTimeRange GetPunchInDateTimeRange(PunchInDateTimeRangeEnum type)
        {
            if (this.Type == TypeEnum.Rest)
            {
                //return DateTimeRange.RestDateTimeRange;
                return KQDataTimeRangeManager.RestDateTimeRange;
            }

            DateTimeRange range = null;
            if (_dict.ContainsKey(type))
            {
                range = _dict[type];
            }

            if (range == null)
            {

                switch (type)
                {
                    case PunchInDateTimeRangeEnum.StartWorkNormal:
                        range = new DateTimeRange(this.Begin - this.NormalBeginTimeSpan, this.Begin);
                        break;

                    case PunchInDateTimeRangeEnum.StartWorkLater:
                        range = new DateTimeRange(this.Begin, this.Begin + Config.Default.LaterEarlyTimeSpan);
                        break;

                    case PunchInDateTimeRangeEnum.StopWorkNormal:
                        range = new DateTimeRange(this.End, this.End + this.NormalEndTimeSpan);
                        break;

                    case PunchInDateTimeRangeEnum.StopWorkEarly:
                        range = new DateTimeRange(this.End - Config.Default.LaterEarlyTimeSpan, this.End);
                        break;

                    default:
                        throw new InvalidOperationException(type.ToString());
                }
                _dict[type] = range;
            }
            return range;
        }
        private Dictionary<PunchInDateTimeRangeEnum, DateTimeRange> _dict =
            new Dictionary<PunchInDateTimeRangeEnum, DateTimeRange>();
        #endregion //GetPunchInDateTimeRange

        static string[] _leaveNames = new string[] { "ÊÂ¼Ù", "²¡¼Ù", "ÐÝ¼Ù" };
        private string GetLeaveName(int leaveType)
        {
            if (leaveType >= 0 && leaveType <= 1)
            {
                return _leaveNames[leaveType];
            }
            else
            {
                return leaveType.ToString();
            }
        }

        #region CreateTimeResult
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leaves"></param>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public TimeResult CreateTimeResult(List<tblLeave> leaves, List<DateTime> dateTimes)
        {
            TimeResult r = new TimeResult();
            r.TimeStandard = this;
            if (this.Type == TypeEnum.Rest)
            {
                r.StartWorkResult = KResultEnum.Rest;
                r.StopWorkResult = KResultEnum.Rest;
                return r;
            }

            bool isLeave = false;

            foreach (tblLeave leave in leaves)
            {
                isLeave = leave.IsInLeave(this);
                if (isLeave)
                {
                    r.StartWorkResult = KResultEnum.Leave;
                    r.StopWorkResult = KResultEnum.Leave;
                    r.LeaveEnum = (LeaveEnum)leave.LeaveType;

                    r.Remark = leave.LeaveType.ToString() + leave.LeaveRemark;
                    r.Remark = GetLeaveName(leave.LeaveType) + (leave.LeaveRemark.Length > 0 ? " : " + leave.LeaveRemark : "");
                    break;
                }
            }

            if (!isLeave)
            {
                KResultEnum startResult = KResultEnum.None;
                DateTime dtInRange;

                DateTimeRange startWorkNormalRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StartWorkNormal);
                bool isInStartNormalRange = startWorkNormalRange.HasInRange(dateTimes, DateTimeRange.PriorityEnum.PriorityFirst, out dtInRange);

                if (isInStartNormalRange)
                {
                    startResult = KResultEnum.Normal;
                }
                else
                {
                    DateTimeRange startWorkLaterRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StartWorkLater);
                    bool isInStartLaterRange = startWorkLaterRange.HasInRange(dateTimes, DateTimeRange.PriorityEnum.PriorityFirst, out dtInRange);
                    if (isInStartLaterRange)
                    {
                        startResult = KResultEnum.Later;
                    }
                }
                r.StartWorkResult = startResult;
                r.PracticeBegin = dtInRange;



                KResultEnum stopResult = KResultEnum.None;
                DateTimeRange stopNormalRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StopWorkNormal);
                if (stopNormalRange.HasInRange(dateTimes, DateTimeRange.PriorityEnum.PriorityLast, out dtInRange))
                {
                    stopResult = KResultEnum.Normal;
                }
                else
                {
                    DateTimeRange stopEarlyRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StopWorkEarly);
                    if (stopEarlyRange.HasInRange(dateTimes, DateTimeRange.PriorityEnum.PriorityLast, out dtInRange))
                    {
                        stopResult = KResultEnum.Early;
                    }
                }
                r.StopWorkResult = stopResult;
                r.PracticeEnd = dtInRange;
                //r.
            }

            return r;
        }
        #endregion //CreateTimeResult

        #region IsInTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsInTime(DateTime dt)
        {
            return dt >= this.Begin && dt < this.End;
        }
        #endregion //IsInTime

        #region ToString
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0}, {1} ~ {2}, {3}", this.DayOfWeek, this.Begin, this.End, this.Type);
        }
        #endregion //ToString
    }

}
