using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB;

namespace fnbx
{

    static public class tblFlowExtend
    {
        static public FLStatus GetFLStatus(this tblFlow fl)
        {
            // TODO:
            FLStatus status = (FLStatus)fl.fl_status;
            return status;
            //return FLStatus.Timeouted;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fl"></param>
        /// <param name="status"></param>
        static public void SetFLStatus(this tblFlow  fl, FLStatus status)
        {
            if (fl.GetFLStatus() != status)
            {
                // TODO: check
                //
                fl.fl_status = (int)status;
                fl.OnFLStatusChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fl"></param>
        static public void OnFLStatusChanged(this tblFlow  fl)
        {
            switch (fl.GetFLStatus())
            {
                case FLStatus.Received:
                    {
                        // TODO:
                        //tblReply rp = fl.tblReply;

                        //if (rp == null)
                        //{
                        //    rp = new tblReply();
                        //    fl.tblReply = rp;
                        //}

                        //rp.rp_receive_dt = DateTime.Now;
                        //rp.tblOperator = App.Default.LoginOperator;

                        //DBFactory.GetBxdbDataContext().SubmitChanges();
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fl"></param>
        /// <returns></returns>
        static public string GetFLStatusText(this tblFlow fl)
        {
            return MTStatusHelper.GetFLStatusText(fl.GetFLStatus());
        }

        static public void Refresh(this tblFlow fl)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(
                System.Data.Linq.RefreshMode.OverwriteCurrentValues,
                fl);

            if (fl.tblIntroducer != null)
            {
                fl.tblIntroducer.Refresh();
            }

            if (fl.tblMaintain != null)
            {
                fl.tblMaintain.Refresh();
            }

            if (fl.tblReceive != null)
            {
                fl.tblReceive.Refresh();
            }

            if (fl.tblReply != null)
            {
                fl.tblReply.Refresh();
            }



        }
    }

    static public class tblIntroducerExtend
    {
        static public void Refresh(this tblIntroducer it)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(RefreshMode.OverwriteCurrentValues,
                it);
        }
    }

    static public class tblMaintainExtend
    {
        static public void Refresh(this tblMaintain mt)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(RefreshMode.OverwriteCurrentValues,
                mt);

            if (mt.tblOperator != null)
            {
                mt.tblOperator.Refresh();
                dc.Refresh(RefreshMode.OverwriteCurrentValues, mt.tblMaintainLevel);
            }
        }
    }

    static public class tblReceiveExtend
    {
        static public void Refresh(this tblReceive rc)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(RefreshMode.OverwriteCurrentValues,
                rc);
        }
    }

    static public class tblReplyExtend
    {
        static public void Refresh(this tblReply rp)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(RefreshMode.OverwriteCurrentValues,
                rp);
        }
    }

    static public class tblOperatorExtend
    {
        static public void Refresh(this tblOperator op)
        { 
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.Refresh(RefreshMode.OverwriteCurrentValues,
                op);
        }
    }
}
