using System;
using System.Diagnostics;
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
                var r = from q in DBFactory.GetBxdbDataContext().tblMaintainLevel
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
            mt.mt_timeout_dt = mt.mt_begin_dt + TimeSpan.FromMinutes((int)mt.tblMaintainLevel.ml_arrive_hl);
            //fl.SetMTStatus(FLStatus.Created);

            return mt;
        }
    }

    public class FlowFactory
    {
        private FlowFactory()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public tblFlow Create()
        {
            tblFlow f = new tblFlow();
            f.tblIntroducer = IntroducerFactory.Create();
            f.tblMaintain = MaintainFactory.Create();
            f.SetFLStatus(FLStatus.New);
            //f.fl_status

            Debug.Assert(f.GetFLStatus() == FLStatus.New);
            return f;
        }
    }

    public class IntroducerFactory
    {
        private IntroducerFactory()
        {
        }

        static public tblIntroducer Create()
        {
            tblIntroducer it = new tblIntroducer();

            it.it_name = "unknown name";
            it.it_phone = "unknown phone";
            it.it_address = "unknown address";

            return it;
        }
    }
}
