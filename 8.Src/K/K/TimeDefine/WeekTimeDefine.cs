
using System;
using System.Xml;
using System.Xml.Serialization;


namespace K
{

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

}
