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

        #region NormalBeginTimeSpanString
        /// <summary>
        /// �����ϰ���ǰʱ��
        /// </summary>
        [XmlElement("NormalBeginTimeSpan")]
        public string NormalBeginTimeSpanString
        {
            get { return _normalBeginTimeSpanString; }
            set { _normalBeginTimeSpanString = value; }
        } private string _normalBeginTimeSpanString = Config.Default.NormalStartWorkTimeSpan.ToString ();
        #endregion //NormalBeginTimeSpanString

        #region NormalEndTimeSpanString
        /// <summary>
        /// �����°��Ӻ�ʱ��
        /// </summary>
        [XmlElement("NormalEndTimeSpan")]
        public string NormalEndTimeSpanString
        {
            get { return _normalEndTimeSpanString; }
            set { _normalEndTimeSpanString = value; }
        } private string _normalEndTimeSpanString = Config.Default.NormalStopWorkTimeSpan.ToString();
        #endregion //NormalEndTimeSpanString

        #region IsCrossDay
        /// <summary>
        /// 
        /// </summary>
        public abstract bool IsCrossDay { get; }
        #endregion //IsCrossDay

        #region CreateWeekTimeDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="beginWeek"></param>
        /// <param name="begin"></param>
        /// <param name="endWeek"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static public WeekTimeDefine CreateWeekTimeDefine(DayOfWeek beginWeek, TimeSpan begin, DayOfWeek endWeek, TimeSpan end)
        {
            WeekTimeDefine r = new WeekTimeDefine();
            r.BeginWeek = beginWeek;
            r.Begin = begin;
            r.EndWeek = endWeek;
            r.End = end;

            return r;
        }
        #endregion //CreateWeekTimeDefine

        #region CreateUserTimeDefine
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dayOfCycle"></param>
        /// <param name="beginDayOffset"></param>
        /// <param name="begin"></param>
        /// <param name="endDayOffset"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        static public UserTimeDefine CreateUserTimeDefine(int dayOfCycle, int beginDayOffset, TimeSpan begin, int endDayOffset, TimeSpan end)
        {
            UserTimeDefine r = new UserTimeDefine(dayOfCycle);
            r.BeginDayOffset = beginDayOffset;
            r.Begin = begin;
            r.EndDayOffset = endDayOffset;
            r.End = end;
            return r;
        }
        #endregion //CreateUserTimeDefine
    }
}
