using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace K
{
    /// <summary>
    /// 
    /// </summary>
    public class DateTimeHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private DateTimeHelper ()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        static public DateTime NextMonth(DateTime month)
        {
            int y = month.Year;
            int m = month.Month + 1;
            if (m > 12)
            {
                m -= 12;
                y += 1;
            }
            DateTime r = new DateTime(y, m, 1);

            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ts"></param>
        /// <returns></returns>
        static public DateTime ConvertToDateTime(TimeSpan ts)
        {
            return DateTime.Parse("2000-01-01") + ts;
        }
    }

}
