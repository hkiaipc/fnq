
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
        /// <summary>
        /// 
        /// </summary>
        internal enum TypeEnum
        {
            Work,
            Rest,
        }

        static internal TimeStandard CreateRestTimeStandard(DateTime day)
        {
            return new TimeStandard(TypeEnum.Rest, day.Date, day.Date + TimeSpan.FromDays(1d));
        }

        static internal TimeStandard CreateWorkTimeStandard(DateTime begin, DateTime end)
        {
            return new TimeStandard(TypeEnum.Work, begin, end);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeEnum"></param>
        /// <param name="dayOfWeek"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        private TimeStandard(TypeEnum typeEnum, DateTime begin, DateTime end)
        {
            Debug.Assert(end >= begin);

            this._typeEnum = typeEnum;
            this._begin = begin;
            this._end = end;
        }


        internal TypeEnum Type
        {
            get { return _typeEnum; }
        } private TypeEnum _typeEnum;


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
        /// <param name="type"></param>
        /// <returns></returns>
        public DateTimeRange GetPunchInDateTimeRange(PunchInDateTimeRangeEnum type)
        {
            if (this.Type == TypeEnum.Rest)
            {
                return DateTimeRange.RestDateTimeRange;
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
                        range = new DateTimeRange(this.Begin - Config.Default.NormalTimeSpan, this.Begin);
                        break;

                    case PunchInDateTimeRangeEnum.StartWorkLater:
                        range = new DateTimeRange(this.Begin, this.Begin + Config.Default.LaterEarlyTimeSpan);
                        break;

                    case PunchInDateTimeRangeEnum.StopWorkNormal:
                        range = new DateTimeRange(this.End, this.End + Config.Default.NormalTimeSpan);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        public KResultEnum Check(List<DateTime> dateTimes)
        {
            // 1. has dt in begin - 2 hour then normal
            //    not normal: has dt in begin + 2 hour then later
            //
            // 2. has dt in end + 2 hour then normal
            //    not normal: has dt in end - 2 hour then early
            // 
            throw new NotImplementedException();
        }

        public TimeResult CreateTimeResult(List<tblLeave> leaves, List<DateTime> dateTimes)
        {
            TimeResult r = new TimeResult();
            r.TimeStandard = this;

            bool isLeave = false;

            foreach (tblLeave leave in leaves)
            {
                isLeave = leave.IsInLeave(this.Begin, this.End);
                if (isLeave)
                {
                    // TODO: leave type
                    //
                    //r.KResultEnum = KResultEnum.Leave;
                    r.Remark = leave.LeaveType.ToString() + leave.LeaveRemark;
                    break;
                }
            }

            if (!isLeave)
            {
                KResultEnum startResult = KResultEnum.None;
                DateTime dtInRange;

                DateTimeRange startWorkNormalRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StartWorkNormal);
                bool isInStartNormalRange = startWorkNormalRange.IsInRange(dateTimes, out dtInRange);

                if (isInStartNormalRange)
                {
                    startResult = KResultEnum.Normal;
                }
                else
                {
                    DateTimeRange startWorkLaterRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StartWorkLater);
                    bool isInStartLaterRange = startWorkLaterRange.IsInRange(dateTimes, out dtInRange);
                    if (isInStartLaterRange)
                    {
                        startResult = KResultEnum.Later;
                    }
                }
                r.StartWorkResult = startResult;
                r.PracticeBegin = dtInRange;



                KResultEnum stopResult = KResultEnum.None;
                DateTimeRange stopNormalRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StopWorkNormal);
                if (stopNormalRange.IsInRange(dateTimes, out dtInRange))
                {
                    stopResult = KResultEnum.Normal;
                }
                else
                {
                    DateTimeRange stopEarlyRange = this.GetPunchInDateTimeRange(PunchInDateTimeRangeEnum.StopWorkEarly);
                    if (stopEarlyRange.IsInRange(dateTimes, out dtInRange))
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool IsInTime(DateTime dt)
        {
            return dt >= this.Begin && dt <= this.End;
        }
    }

}
