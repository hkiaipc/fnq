using System;

namespace K
{
    public class KQDataTimeRangeManager
    {
        /// <summary>
        /// 
        /// </summary>
        private KQDataTimeRangeManager()
        { 
        }

        /// <summary>
        /// 
        /// </summary>
        static public readonly DateTimeRange RestDateTimeRange = new DateTimeRange(
                DateTime.MinValue, 
                DateTime.MinValue + TimeSpan.FromDays(1d));
    }

}
