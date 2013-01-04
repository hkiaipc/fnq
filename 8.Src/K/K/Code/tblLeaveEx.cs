
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using KDB;
using Xdgk.Common;


namespace K
{
    internal static class tblLeaveEx
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <param name="dateTimes"></param>
        /// <returns></returns>
        static public bool IsInLeave(this tblLeave leave, params DateTime[] dateTimes)
        {
            bool r = false;
            foreach (DateTime dt in dateTimes)
            {
                if (leave.IsInLeave(dt))
                {
                    r = true;
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        static public bool IsInLeave(this tblLeave leave, DateTime dt)
        {
            return dt >= leave.LeaveBegin && dt <= leave.LeaveEnd;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="leave"></param>
        /// <param name="timeStandard"></param>
        /// <returns></returns>
        static public bool IsInLeave(this tblLeave leave, TimeStandard timeStandard)
        {
            return (leave.IsInLeave(timeStandard.Begin) && leave.IsInLeave(timeStandard.End));
        }
    }

}
