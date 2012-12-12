using System;
using System.Xml;
using System.Xml.Serialization;


namespace K
{
    [Serializable]
    public class TimeDefine
    {
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


        #region DayOffset
        /// <summary>
        /// 
        /// </summary>
        public int DayOffset
        {
            get
            {
                return _dayOffset;
            }
            set
            {
                _dayOffset = value;
            }
        } private int _dayOffset;
        #endregion //DayOffset

        #region IsCrossDay
        /// <summary>
        /// 
        /// </summary>
        public bool IsCrossDay
        {
            get
            {
                return this.Begin >= this.End;
            }
            //set
            //{
            //_isCrossDay = value;
            //}
        } //private bool _isCrossDay;
        #endregion //IsCrossDay

        #region Hold
        /// <summary>
        /// 
        /// </summary>
        public TimeSpan Hold
        {
            get
            {
                TimeSpan ts = this.Begin - this.End;
                if (IsCrossDay)
                {
                    ts += TimeSpan.Parse("24:00:00");
                }
                return ts;
            }
        }
        #endregion //Hold

    }

}
