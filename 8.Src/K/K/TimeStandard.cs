
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
        internal TimeStandard(TypeEnum typeEnum)
        {
            this.Type = typeEnum;
        }

        internal enum TypeEnum
        {
            Work,
                Rest,
        }

        internal TypeEnum Type
        {
            get { return _typeEnum; }
            set { _typeEnum = value; }
        } private TypeEnum _typeEnum;

        //#region Date
        ///// <summary>
        ///// 
        ///// </summary>
        //public DateTime Date
        //{
        //    get
        //    {
        //        return _date;
        //    }
        //    set
        //    {
        //        _date = value;
        //    }
        //} private DateTime _date;
        //#endregion //Date

#region DayOfWeek
        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek DayOfWeek
        {
            get
            {
                return _dayOfWeek;
            }
            set
            {
                _dayOfWeek = value;
            }
        } private DayOfWeek _dayOfWeek;
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
            set
            {
                _begin = value;
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
            set
            {
                _end = value;
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
                //range = new DateTimeRange(
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
                    r.KResultEnum = KResultEnum.Leave;
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
