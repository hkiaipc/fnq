using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
    [Serializable]
    [XmlInclude(typeof(WeekWorkDefine))]
    [XmlInclude(typeof(UserWorkDefine))]
    [XmlInclude(typeof(WeekTimeDefine))]
    [XmlInclude(typeof(UserTimeDefine))]
    public class SerializableObject
    {
        public SerializableObject ()
        {
        }

        public SerializableObject(object obj)
        {
            this.Object = obj;
        }

        #region Object
        /// <summary>
        /// 
        /// </summary>
        public object Object
        {
            get
            {
                return _object;
            }
            set
            {
                _object = value;
            }
        } private object _object;
        #endregion //Object
    }

    [Serializable]
    abstract public class WorkDefine
    {

        #region Create WorkDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cycleType"></param>
        /// <returns></returns>
        static public WorkDefine Create(CycleTypeEnum cycleType)
        {
            WorkDefine r = null;
            switch (cycleType)
            {
                case CycleTypeEnum.Week:
                    r = new WeekWorkDefine();
                    break;

                case CycleTypeEnum.UserDefine:
                    r = new UserWorkDefine();
                    break;

                default:
                    throw new ArgumentException(cycleType.ToString());
            }
            return r;
        }
        #endregion //

        #region Serialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wd"></param>
        /// <returns></returns>
        static public string Serialize(WorkDefine wd)
        {
            XmlSerializer s = new XmlSerializer(typeof(SerializableObject));
            StringWriter sw = new StringWriter();
            s.Serialize(sw, new SerializableObject(wd));
            return sw.ToString();
        }
        #endregion //Serialize

        #region Deserialize
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        static public WorkDefine Deserialize(string context)
        {
            // TODO: 
            //
            //XmlSerializer _kResultEnumNameMap = new XmlSerializer(typeof(WorkDefine));
            XmlSerializer s = new XmlSerializer(typeof(SerializableObject));
            StringReader sr = new StringReader(context);
            SerializableObject serObject = s.Deserialize(sr) as SerializableObject;
            WorkDefine wd = serObject.Object as WorkDefine ;

            Debug.Assert(wd != null, "Deserialize WorkDefine error");
            return wd;

        }
        #endregion //Deserialize

        protected WorkDefine()
        {
        }

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                if (_name == null)
                {
                    _name = string.Empty;
                }
                return _name;
            }
            set
            {
                _name = value;
            }
        } private string _name;
        #endregion //Name

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
                Debug.Assert(_dayOfCycle >= 1);
                _dayOfCycle = value;
            }
        } private int _dayOfCycle = 7;
        #endregion //DayOfCycle
        #region TimeDefines
        /// <summary>
        /// 
        /// </summary>
        public TimeDefineCollection TimeDefines
        {
            get
            {
                if (_timeDefines == null)
                {
                    _timeDefines = new TimeDefineCollection();
                }
                return _timeDefines;
            }
            set
            {
                _timeDefines = value;
            }
        } private TimeDefineCollection _timeDefines;
        #endregion //TimeDefines

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

        #region //CycleType
        ///// <summary>
        ///// 
        ///// </summary>
        //public CycleTypeEnum CycleType
        //{
        //    get
        //    {
        //        return _cycleType;
        //    }
        //    set
        //    {
        //        _cycleType = value;
        //    }
        //} private CycleTypeEnum _cycleType = CycleTypeEnum.Week;
        #endregion //CycleType


        abstract internal TimeStandardCollection CreateTimeStandards(DateTime month);
    }

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WeekWorkDefine : WorkDefine
    {
        private TimeStandard CreateTimeStandard(DateTime day)
        {
            TimeStandard r = null;
            foreach (TimeDefine td in this.TimeDefines)
            {
                WeekTimeDefine weekTD = (WeekTimeDefine)td;
                if (weekTD.BeginWeek == day.DayOfWeek)
                {
                    DateTime b = day + weekTD.Begin ;
                    DateTime e = day + weekTD.End + (weekTD.IsCrossDay ? TimeSpan.FromDays(1d) : TimeSpan.Zero);
                    r = TimeStandard.CreateWorkTimeStandard(b, e);

                    break;
                }
                else
                {

                }
            }
            if (r == null)
            {
                r = TimeStandard.CreateRestTimeStandard(day);
            }
            return r;
        }

        internal override TimeStandardCollection CreateTimeStandards(DateTime month)
        {
            TimeStandardCollection r = new TimeStandardCollection();

            DateTime dt = new DateTime(month.Year, month.Month, month.Day);

            do
            {
                TimeStandard s = CreateTimeStandard(dt);
                r.Add(s);
                dt += TimeSpan.FromDays(1d);
            } while (dt.Month == month.Month);

            return r;
        }
    }

    
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class UserWorkDefine : WorkDefine
    {

        #region StartDateTime
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartDateTime
        {
            get
            {
                return _startDateTime;
            }
            set
            {
                _startDateTime = value;
            }
        } private DateTime _startDateTime = DateTime.Parse("2000-01-01");
        #endregion //StartDateTime

        #region CreateTimeStandards
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        internal override TimeStandardCollection CreateTimeStandards(DateTime month)
        {
            TimeStandardCollection r = new TimeStandardCollection();

            DateTime monthStart = new DateTime(month.Year, month.Month, month.Day);
            DateTime startDT = monthStart - TimeSpan.FromTicks(
                (monthStart - this.StartDateTime).Ticks % TimeSpan.FromDays(this.DayOfCycle).Ticks);

            DateTime dt = startDT;
            int exitMonth = month.Month + 1;
            if (exitMonth > 12)
            {
                exitMonth -= 12;
            }

            int n = 0;
            DateTime b1 = DateTime.MinValue;
            DateTime e1 = DateTime.MinValue;
            do
            {
                foreach (TimeDefine td in this.TimeDefines)
                {
                    UserTimeDefine userTD = (UserTimeDefine)td;
                    b1 = dt + TimeSpan.FromDays(n * this.DayOfCycle) + TimeSpan.FromDays(userTD.BeginDayOffset) + userTD.Begin;
                    e1 = dt + TimeSpan.FromDays(n * this.DayOfCycle) + TimeSpan.FromDays(userTD.EndDayOffset) + userTD.End;

                    if (b1.Month == month.Month)
                    {
                        TimeStandard s = TimeStandard.CreateWorkTimeStandard(b1, e1);
                        r.Add(s);
                    }
                }
                n++;
            }
            while (b1.Month != exitMonth);
            TimeStandardCollection rests = CreateMonthTimeStandarsWithRest(month);
            r = Merge(rests, r);
            return r;
        }
        #endregion //CreateTimeStandards

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private TimeStandardCollection CreateMonthTimeStandarsWithRest(DateTime month)
        {
            TimeStandardCollection r = new TimeStandardCollection();
            DateTime b = new DateTime(month.Year, month.Month, 1);
            DateTime e = CreateNextMonth(month);

            while (b < e)
            {
                TimeStandard s = TimeStandard.CreateRestTimeStandard(b);
                r.Add(s);
                b += TimeSpan.FromDays(1d);
            }
            return r;
        }

        private TimeStandardCollection Merge(TimeStandardCollection rests, TimeStandardCollection works)
        {
            TimeStandardCollection r = new TimeStandardCollection();
            foreach (TimeStandard iRest in rests)
            {
                bool added = false;
                //if (item.begin
                foreach (TimeStandard iWork in works)
                {
                    if (iRest.IsInTime(iWork.Begin))
                    {
                        r.Add(iWork);
                        added = true;
                    }
                }
                if (!added)
                {
                    r.Add(iRest);
                }
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private DateTime CreateNextMonth(DateTime month)
        {
            return DateTimeHelper.NextMonth(month);
        }
    }

    public class DateTimeHelper
    {
        private DateTimeHelper ()
        {
        }

        static public DateTime NextMonth(DateTime month)
        {
            int y = month.Year;
            int m = month.Month + 1;
            if (m > 12)
            {
                m -= 12;
                y += 1;
            }
            DateTime r = new DateTime(y, m, 1);

            return r;

        }
    }

}
