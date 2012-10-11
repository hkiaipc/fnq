using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class GatherClass
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime MaxDT, MinDT;

        /// <summary>
        /// 
        /// </summary>
        public float Max
        {
            get { return (float)Math.Round(_max, 2); }
            set { _max = value; }
        } private float _max;

        /// <summary>
        /// 
        /// </summary>
        public float Min
        {
            get { return (float)Math.Round(_min, 2); }
            set { _min = value; }
        } private float _min;

        /// <summary>
        /// 
        /// </summary>
        public float Avg
        {
            get { return (float)Math.Round(_avg, 2); }
            set { _avg = value; }
        } private float _avg;

        #region GatherClass
        /// <summary>
        /// 
        /// </summary>
        /// <param name="maxDT"></param>
        /// <param name="max"></param>
        /// <param name="minDT"></param>
        /// <param name="min"></param>
        /// <param name="avg"></param>
        public GatherClass(string name, string text, DateTime maxDT, float max, DateTime minDT, float min, float avg)
        {
            this.Text = text;
            this.Name = name;
            this.MaxDT = maxDT;
            this.Max = max;
            this.MinDT = minDT;
            this.Min = min;
            this.Avg = avg;
        }
        #endregion //GatherClass

        #region Text
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        } private string _text;
        #endregion //Text

        #region This
        /// <summary>
        /// 
        /// </summary>
        public GatherClass This
        {
            get { return this; }
        }
        #endregion //This

        #region Name
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        } private string _name;
        #endregion //Name

        #region ToString
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return
            string.Format(
                "最大值:\r\n{0}\r\n{1}\r\n\r\n" +
                "最小值:\r\n{2}\r\n{3}\r\n\r\n" +
                "平均值:\r\n{4}",
                this.MaxDT, Math.Round(this.Max, 2),
                this.MinDT, Math.Round(this.Min, 2),
                Math.Round(this.Avg, 2));
        }
        #endregion //ToString
    }
}
