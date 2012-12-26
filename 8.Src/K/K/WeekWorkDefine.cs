using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class WeekWorkDefine : WorkDefine
    {
        #region CreateTimeStandard
        /// <summary>
        /// 
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        private TimeStandardCollection CreateTimeStandard(DateTime day)
        {
            TimeStandardCollection timeStandards = new TimeStandardCollection();
            //TimeStandard r = null;
            foreach (TimeDefine td in this.TimeDefines)
            {
                WeekTimeDefine weekTD = (WeekTimeDefine)td;
                if (weekTD.BeginWeek == day.DayOfWeek)
                {
                    DateTime b = day + weekTD.Begin;
                    DateTime e = day + weekTD.End + (weekTD.IsCrossDay ? TimeSpan.FromDays(1d) : TimeSpan.Zero);
                    TimeStandard r = TimeStandard.CreateWorkTimeStandard(b, e);
                    timeStandards.Add(r);
                }
                else
                {

                }
            }
            //if (r == null)
            if( timeStandards.Count == 0)
            {
                TimeStandard r = TimeStandard.CreateRestTimeStandard(day);
                timeStandards.Add(r);
            }
            return timeStandards;
        }
        #endregion //CreateTimeStandard

        #region CreateTimeStandards
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        internal override TimeStandardCollection CreateTimeStandards(DateTime month)
        {
            Debug.Assert(month.Day == 1);

            TimeStandardCollection r = new TimeStandardCollection();

            DateTime dt = new DateTime(month.Year, month.Month, month.Day);

            do
            {
                TimeStandardCollection s = CreateTimeStandard(dt);
                r.Add(s);
                dt += TimeSpan.FromDays(1d);
            } while (dt.Month == month.Month);

            return r;
        }
        #endregion //CreateTimeStandards
    }

}
