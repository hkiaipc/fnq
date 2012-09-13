using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;
using System.Windows.Forms ;
using BXDB;


namespace fnbx
{
    class _
    {
        void a()
        {
        }
    }

    public interface IView
    {
        void UpdateModel();
        bool CheckInput();
        //FLStatus[] NotReadonlyStatusArray { get; }
        bool IsReadonly(Right rt, FLStatus status);
    }

    public class ReadonlyHelper
    {
        static public void SetReadonlyStyle( Control c , bool isReadonly )
        {
            if (c is IReadonly)
            {
                ((IReadonly)c).Readonly = isReadonly;
            }
            else if (c is TextBox)
            {
                ((TextBox)c).ReadOnly = isReadonly;
            }
            else
            {
                c.Enabled = !isReadonly;
            }
        }

        static public void SetReadonlyStyle(Control[] controls, bool isReadonly)
        {
            foreach (Control c in controls)
            {
                SetReadonlyStyle(c, isReadonly);
            }
        }
    }

    public interface IReadonly
    {
        bool Readonly { get; set; }
    }
    

    //static public class tblMaintainExtend
    //{
    //    static public FLStatus GetMtStatus(this tblMaintain fl)
    //    {
    //        // TODO:
    //        //FLStatus status = (FLStatus)fl.mt_status;
    //        //return status;
    //        return FLStatus.Timeouted;
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="fl"></param>
    //    /// <param name="status"></param>
    //    static public void SetMTStatus(this tblMaintain fl, FLStatus status)
    //    {
    //        if (fl.GetMtStatus() != status)
    //        {
    //            // TODO:
    //            //fl.mt_status = (int)status;
    //            fl.OnMtStatusChanged();
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="fl"></param>
    //    static public void OnMtStatusChanged(this tblMaintain fl)
    //    {
    //        switch (fl.GetMtStatus())
    //        {
    //            case FLStatus.Received:
    //                {
    //                    // TODO:
    //                    //tblReply rp = fl.tblReply;

    //                    //if (rp == null)
    //                    //{
    //                    //    rp = new tblReply();
    //                    //    fl.tblReply = rp;
    //                    //}

    //                    //rp.rp_receive_dt = DateTime.Now;
    //                    //rp.tblOperator = App.Default.LoginOperator;

    //                    //Class1.GetBxdbDataContext().SubmitChanges();
    //                }
    //                break;
    //            default:
    //                break;
    //        }
    //    }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    /// <param name="fl"></param>
    //    /// <returns></returns>
    //    static public string GetFLStatusText(this tblMaintain fl)
    //    {
    //        return MTStatusHelper.GetFLStatusText(fl.GetMtStatus());
    //    }
    //}


    public class MTStatusHelper
    {
        static public string GetFLStatusText(FLStatus status)
        {
            Type t = typeof(FLStatus);
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
