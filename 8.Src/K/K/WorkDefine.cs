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
            //XmlSerializer s = new XmlSerializer(typeof(WorkDefine));
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
                    r = new TimeStandard(TimeStandard.TypeEnum.Work);
                    r.Begin = day + weekTD.Begin;
                    r.End = day + weekTD.End + (weekTD.IsCrossDay ? TimeSpan.FromDays(1d) : TimeSpan.Zero);
                    r.DayOfWeek = day.DayOfWeek;

                    break;
                }
                else
                {

                }
            }
            if (r == null)
            {
                r = new TimeStandard(TimeStandard.TypeEnum.Rest);
                r.Begin = day;
                r.End = day;
                r.DayOfWeek = day.DayOfWeek;
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

            do
            {
                foreach (TimeDefine td in this.TimeDefines)
                {
                    UserTimeDefine userTD = (UserTimeDefine)td;
                    DateTime b1 = dt + TimeSpan.FromDays ( userTD.BeginDayOffset) + userTD.Begin;
                    DateTime e1 = dt + TimeSpan.FromDays(userTD.EndDayOffset) + userTD.End; 
                        // + (userTD.IsCrossDay ? TimeSpan.FromDays(1d) : TimeSpan.Zero);

                    if (b1.Month == month.Month)
                    {
                        TimeStandard s = new TimeStandard(TimeStandard.TypeEnum.Work);
                        s.Begin = b1;
                        s.End = e1;
                        s.DayOfWeek = b1.DayOfWeek;

                        r.Add(s);
                    }
                }
            }
            while (dt.Month != exitMonth);
            return r;
        }
    }

}
