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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mt"></param>
        /// <param name="status"></param>
        static public void SetMTStatus(this tblMaintain mt, MTStatus status)
        {
            if (mt.GetMtStatus() != status)
            {
                mt.mt_status = (int)status;
                mt.OnMtStatusChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mt"></param>
        static public void OnMtStatusChanged(this tblMaintain mt)
        {
            switch (mt.GetMtStatus())
            {
                case MTStatus.Received:
                    {
                        tblReply rp = mt.tblReply;

                        if (rp == null)
                        {
                            rp = new tblReply();
                            mt.tblReply = rp;
                        }

                        rp.rp_receive_dt = DateTime.Now;
                        rp.tblOperator = App.Default.LoginOperator;

                        Class1.GetBxdbDataContext().SubmitChanges();
                    }
                    break;
                default:
                    break;
            }
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
