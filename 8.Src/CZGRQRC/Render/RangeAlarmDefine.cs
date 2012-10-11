using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class RangeAlarmDefine : AlarmDefine
    {
        /// <summary>
        /// 
        /// </summary>
        public RangeAlarmDefine()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public RangeAlarmDefine(string name, float min, float max)
            : base(name)
        {
            this.Min = min;
            this.Max = max;
        }     
        
        /// <summary>
        /// 
        /// </summary>
        public float Min
        {
            get { return _min; }
            set
            {
                if (value > this.Max)
                    value = this.Max;
                this._min = value;
            }
        } private float _min = 0;


        /// <summary>
        /// 
        /// </summary>
        public float Max
        {
            get { return _max; }
            set
            {
                if (value < this.Min)
                    value = this.Min;
                _max = value;
            }
        } private float _max = 100;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override CompareResult Compare(object value)
        {
            float v = (float )value;
            if (v < Min)
            {
                return new CompareResult(CompareResultEnum.LowAlarm);
            }
            if (v > Max)
            {
                return new CompareResult(CompareResultEnum.HighAlarm);
            }
            return new CompareResult(CompareResultEnum.Normal);
        }
    }
}
