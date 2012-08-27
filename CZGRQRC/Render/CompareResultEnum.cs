using System;
using System.Collections.Generic;
using System.Text;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public enum CompareResultEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        Normal,

        /// <summary>
        /// 高限报警
        /// </summary>
        HighAlarm,

        /// <summary>
        /// 低限报警
        /// </summary>
        LowAlarm,

        /// <summary>
        /// 超高限报警
        /// </summary>
        HighHighAlarm,

        /// <summary>
        /// 超低限报警
        /// </summary>
        LowLowalarm,
    }
}
