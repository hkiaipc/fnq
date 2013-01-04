using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace K
{
    /// <summary>
    /// 
    /// </summary>
    public enum CycleTypeEnum
    {
        Week = 0,
        UserDefine = 1,
    }


    /// <summary>
    /// 
    /// </summary>
    public class TimeSpanHelper
    {
        static public DateTime TimeSpanToDateTime(TimeSpan ts)
        {
            return DateTime.Parse("2000-01-01 00:00:00") + ts;
        }

    }
}
