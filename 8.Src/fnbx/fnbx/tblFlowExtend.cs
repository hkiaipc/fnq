﻿using System;
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
                fl.fl_status = (int)status;
                fl.OnMtStatusChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fl"></param>
        static public void OnMtStatusChanged(this tblFlow  fl)
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

                        //Class1.GetBxdbDataContext().SubmitChanges();
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
    }
}