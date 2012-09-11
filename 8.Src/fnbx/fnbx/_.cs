using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;
using BXDB;


namespace fnbx
{
    class _
    {
        void a()
        {
        }
    }

    static public class tblMaintainExtend
    {
        static public MTStatus GetMtStatus(this tblMaintain mt)
        {
            MTStatus status = (MTStatus)mt.mt_status;
            return status;
        }

        static public void SetMTStatus(this tblMaintain mt, MTStatus status)
        {
            mt.mt_status = (int)status;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mt"></param>
        /// <returns></returns>
        static public string GetMtStatusText(this tblMaintain mt)
        {
            return MTStatusHelper.GetMtStatusText(mt.GetMtStatus());
        }
    }

    public class MTStatusHelper
    {
        static public string GetMtStatusText(MTStatus status)
        {
            Type t = typeof(MTStatus);
            FieldInfo fi = t.GetField(status.ToString());
            object[] objs = fi.GetCustomAttributes(typeof(TextAttribute), true);
            if (objs.Length > 0)
            {
                TextAttribute ta = objs[0] as TextAttribute;
                return ta.Text;
            }
            else
            {
                return status.ToString();
            }
        }
    }
}
