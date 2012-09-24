
using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB;


namespace fnbx
{
    public class FlowConverter
    {
        static public FlowData Convert(tblFlow fl)
        {
            FlowData f = new FlowData();

            f.FlID = fl.fl_id;
            f.FlStatus = fl.GetFLStatusText();   

            tblIntroducer it = fl.tblIntroducer;
            f.ItAddress = it.it_address;
            f.ItName = it.it_name;
            f.ItPhone = it.it_phone ;
            f.ItRemark = it.it_remark;

            tblMaintain mt = fl.tblMaintain ;
            f.MtBeginDT = mt.mt_begin_dt;
            f.MtContent = mt.mt_content;
            f.MTCreateDT = mt.mt_create_dt;
            f.MtLocation = mt.mt_location;
            f.MtPoseDT = mt.mt_pose_dt;
            f.MtRemark = mt.mt_remark;
            f.MtTimeoutDT = mt.mt_timeout_dt;
            f.MtOperatorName = mt.tblOperator.op_name;
            f.MtLevel = mt.tblMaintainLevel.ml_name;
            tblReceive rc = fl.tblReceive;
            if (rc != null)
            {
                f.RcDT = fl.tblReceive.rc_dt;
                f.RcOperatorName = fl.tblReceive.tblOperator.op_name;
            }

            tblReply rp = fl.tblReply;
            if (rp != null)
            {
                f.RpContent = rp.rp_content;
                f.RpEndDT = (DateTime)rp.rp_end_dt;
                f.RpRemark = rp.rp_remark;
                f.RpWorker = rp.rp_worker;
            }

            f.TblFlow = fl;
            return f;

        }

        static public FlowData[] Convert(tblFlow[] flArray)
        {
            FlowData[] array = new FlowData[flArray.Length];
            for (int i = 0; i < flArray.Length; i++)
            {
                tblFlow fl = flArray[i];
                FlowData f = Convert(fl);
                array[i] = f;
            }
            return array;
        }


        static public DataTable Convert(FlowData[] fs)
        {
            DataTable t = new DataTable();
            Type ftp = typeof(FlowData);
            PropertyInfo[] pis = ftp.GetProperties();
            foreach (PropertyInfo pi in pis)
            {
                DataColumn col = new DataColumn(pi.Name, pi.PropertyType);
                t.Columns.Add(col);
            }

            foreach (FlowData item in fs)
            {
                DataRow row = t.NewRow();
                foreach (PropertyInfo pi in pis)
                {
                    string colName = pi.Name ;
                    object value = pi.GetValue(item, null);
                    row[colName] = value;
                }

                t.Rows.Add(row);
            }
            return t;
        }

    }

}
