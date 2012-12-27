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
                        TimeStandard s = TimeStandard.CreateWorkTimeStandard(b1, e1,
                            userTD.NormalBeginTimeSpan, userTD.NormalEndTimeSpan);
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

        #region CreateMonthTimeStandarsWithRest
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
        #endregion //CreateMonthTimeStandarsWithRest

        #region Merge
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rests"></param>
        /// <param name="works"></param>
        /// <returns></returns>
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
        #endregion //Merge

        #region CreateNextMonth
        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        private DateTime CreateNextMonth(DateTime month)
        {
            return DateTimeHelper.NextMonth(month);
        }
        #endregion //CreateNextMonth
    }

}
