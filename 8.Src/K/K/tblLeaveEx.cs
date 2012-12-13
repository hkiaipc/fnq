
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

        static public bool IsInLeave(this tblLeave leave, DateTime dt)
        {
            return dt >= leave.LeaveBegin && dt <= leave.LeaveEnd;
        }

        static public bool IsInLeave(this tblLeave leave, TimeStandard timeStandard)
        {
            return (leave.IsInLeave(timeStandard.Begin) || leave.IsInLeave(timeStandard.End));
        }
    }

}
