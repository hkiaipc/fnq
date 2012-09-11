using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB ;

namespace fnbx
{
    public class MaintainLevelFactory
    {
        private MaintainLevelFactory()
        {
        }

        static public tblMaintainLevel Default
        {
            get
            {
                var r = from q in Class1.GetBxdbDataContext().tblMaintainLevel
                        where q.ml_name == "普通"
                        select q;

                return r.First();
            }
        }
    }

    public class MaintainFactory
    {
        private MaintainFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public tblMaintain Create()
        {
            tblMaintain mt = new tblMaintain();
            mt.tblMaintainLevel = MaintainLevelFactory.Default;
            mt.tblOperator = App.Default.LoginOperator;

            mt.mt_create_dt = DateTime.Now;
            mt.mt_pose_dt = DateTime.Now;
            mt.mt_begin_dt = DateTime.Now;
            mt.SetMTStatus(MTStatus.Created);

            return mt;
        }
    }
}
