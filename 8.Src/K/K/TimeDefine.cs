using System;
using System.Xml;
using System.Xml.Serialization;


namespace K
{
    [Serializable]
    abstract public class TimeDefine
    {
        protected TimeDefine()
        {
        }

        #region Begin
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public TimeSpan Begin
        {
            get
            {
                //return this.BeginTime.TimeOfDay;
                return TimeSpan.Parse(this.BeginTime);
            }
            set
            {
                this.BeginTime = value.ToString();
            }
        }
        #endregion //Begin

        #region End
        /// <summary>
        /// 
        /// </summary>
        [XmlIgnore]
        public TimeSpan End
        {
            get
            {
                return TimeSpan.Parse(this.EndTime);
            }
            set
            {
                this.EndTime = value.ToString();
            }
        }
        #endregion //End

        #region BeginDT
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("Begin")]
        public string BeginTime
        {
            get
            {
                return _beginTime;
            }
            set
            {
                _beginTime = value;
            }
        } private string _beginTime;
        #endregion //BeginDT

        #region EndDT
        /// <summary>
        /// 
        /// </summary>
        [XmlElement("End")]
        public string EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        } private string _endTime;
        #endregion //EndDT


        //#region DayOffset
        ///// <summary>
        ///// 
        ///// </summary>
        //public int DayOffset
        //{
        //    get
        //    {
        //        return _dayOffset;
        //    }
        //    set
        //    {
        //        _dayOffset = value;
        //    }
        //} private int _dayOffset;
        //#endregion //DayOffset

        #region IsCrossDay
        /// <summary>
        /// 
        /// </summary>
        public abstract bool IsCrossDay {get ;}
        //{
        //    get
        //    {
        //        return this.Begin >= this.End;
        //    }
        //    //set
        //    //{
        //    //_isCrossDay = value;
        //    //}
        //} //private bool _isCrossDay;
        #endregion //IsCrossDay

        //#region Hold
        ///// <summary>
        ///// 
        ///// </summary>
        //public TimeSpan Hold
        //{
        //    get
        //    {
        //        TimeSpan ts = this.Begin - this.End;
        //        if (IsCrossDay)
        //        {
        //            ts += TimeSpan.Parse("24:00:00");
        //        }
        //        return ts;
        //    }
        //}
        //#endregion //Hold
        static public WeekTimeDefine CreateWeekTimeDefine(DayOfWeek beginWeek, TimeSpan begin, DayOfWeek endWeek, TimeSpan end)
        {
            WeekTimeDefine r = new WeekTimeDefine();
            r.BeginWeek = beginWeek;
            r.Begin = begin;
            r.EndWeek = endWeek;
            r.End = end;

            return r;
        }

        static public UserTimeDefine CreateUserTimeDefine(int dayOfCycle, int beginDayOffset, TimeSpan begin, int endDayOffset, TimeSpan end)
        {
            UserTimeDefine r = new UserTimeDefine(dayOfCycle);
            r.BeginDayOffset = beginDayOffset;
            r.Begin = begin;
            r.EndDayOffset = endDayOffset;
            r.End = end;
            return r;
        }
    }

    [Serializable]
    public class WeekTimeDefine : TimeDefine 
    {
        #region BeginWeek
        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek BeginWeek
        {
            get
            {
                return _beginWeek;
            }
            set
            {
                _beginWeek = value;
            }
        } private DayOfWeek _beginWeek;
        #endregion //BeginWeek

        #region EndWeek
        /// <summary>
        /// 
        /// </summary>
        public DayOfWeek EndWeek
        {
            get
            {
                return _endWeek;
            }
            set
            {
                _endWeek = value;
            }
        } private DayOfWeek _endWeek;
        #endregion //EndWeek


        public override bool IsCrossDay
        {
            get { return this.BeginWeek != this.EndWeek; }
        }
    }

    [Serializable]
    public class UserTimeDefine : TimeDefine 
    {
        public UserTimeDefine()
        {
        }

        public UserTimeDefine ( int dayOfCycle )
        {
            if (dayOfCycle < 1)
            {
                throw new ArgumentOutOfRangeException("dayOfCycle must >= 1");
            }
            this._dayOfCycle = dayOfCycle ;
        }

        #region DayOfCycle
        /// <summary>
        /// 
        /// </summary>
        public int DayOfCycle
        {
            get
            {
                return _dayOfCycle;
            }
            set
            {
                _dayOfCycle = value;
            }
        } private int _dayOfCycle;
        #endregion //DayOfCycle

        #region BeginDayOffset
        /// <summary>
        /// 
        /// </summary>
        public int BeginDayOffset
        {
            get
            {
                return _beginDayOffset;
            }
            set
            {
                if (value >= 0 && value < this._dayOfCycle)
                {
                    _beginDayOffset = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("BeginDayOffset must in [0, {0})", this._dayOfCycle));
                }
            }
        } private int _beginDayOffset;
        #endregion //BeginDayOffset

        #region EndDayOffset
        /// <summary>
        /// 
        /// </summary>
        public int EndDayOffset
        {
            get
            {
                return _endDayOffset;
            }
            set
            {
                //if (value >= 0 && value < this._dayOfCycle)
                if (value >= 0 && value < this.DayOfCycle )
                {
                    _endDayOffset = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("EndDayOffset must in [0, {0})", this.DayOfCycle));
                }
            }
        } private int _endDayOffset;
        #endregion //EndDayOffset

        public override bool IsCrossDay
        {
            get
            {
                return this.BeginDayOffset != this.EndDayOffset;
            }
        }


    }

}
