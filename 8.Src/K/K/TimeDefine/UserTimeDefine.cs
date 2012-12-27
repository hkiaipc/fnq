using System;
using System.Xml;
using System.Xml.Serialization;

namespace K
{
    [Serializable]
    public class UserTimeDefine : TimeDefine
    {
        public UserTimeDefine()
        {
        }

        public UserTimeDefine(int dayOfCycle)
        {
            if (dayOfCycle < 1)
            {
                throw new ArgumentOutOfRangeException("dayOfCycle must >= 1");
            }
            this._dayOfCycle = dayOfCycle;
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
                if (value >= 0 && value < this.DayOfCycle)
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
