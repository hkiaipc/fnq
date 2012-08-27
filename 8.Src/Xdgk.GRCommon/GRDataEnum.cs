using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public enum GRDataEnum
    {
        /// <summary>
        /// 日期时间
        /// </summary>
        DT,

        /// <summary>
        /// 一次供温
        /// </summary>
        GT1,

        /// <summary>
        /// 一次回温度
        /// </summary>
        BT1,

        /// <summary>
        /// 二次供温
        /// </summary>
        GT2,

        /// <summary>
        /// 二次回温
        /// </summary>
        BT2,

        /// <summary>
        /// 一次供压
        /// </summary>
        GP1,

        /// <summary>
        /// 一次回压
        /// </summary>
        BP1,

        /// <summary>
        /// 二次供压
        /// </summary>
        GP2,

        /// <summary>
        /// 二次回压
        /// </summary>
        BP2,

        /// <summary>
        /// 室外温度
        /// </summary>
        OT,

        /// <summary>
        /// 一次瞬时流量
        /// </summary>
        I1,

        /// <summary>
        /// 一次补水瞬时流量
        /// </summary>
        IR,

        /// <summary>
        /// 一次累计流量
        /// </summary>
        S1,

        /// <summary>
        /// 一次累计补水流量
        /// </summary>
        SR,

        /// <summary>
        /// 二次瞬时流量
        /// </summary>
        I2,

        /// <summary>
        /// 二次累计流量
        /// </summary>
        S2,

        /// <summary>
        /// 二次供温基准
        /// </summary>
        GTBase2,

        /// <summary>
        /// 水箱水位
        /// </summary>
        WL,

        /// <summary>
        /// 阀门开度
        /// </summary>
        OD,

        /// <summary>
        /// 二次压差
        /// </summary>
        PA2,

        /// <summary>
        /// 循环泵1
        /// </summary>
        CM1,

        /// <summary>
        /// 循环泵2
        /// </summary>
        CM2,

        /// <summary>
        /// 循环泵3
        /// </summary>
        CM3,

        /// <summary>
        /// 补水泵1
        /// </summary>
        RM1,

        /// <summary>
        /// 补水泵2
        /// </summary>
        RM2,

        /// <summary>
        /// 补水泵3
        /// </summary>
        RM3,
    }

}
