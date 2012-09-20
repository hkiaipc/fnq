using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BXDB;

namespace fnbx
{
    public class _Test
    {
        public _Test()
        {
            TestInsertReply();
            TestInsertReplyAndRelation();
            TestDiffDataContext();

        }

        private void TestInsertReplyAndRelation()
        {
            BxdbDataContext dc = new BxdbDataContext();
            tblReply t = new tblReply();
            t.rp_worker = "work - reply - flow";

            tblFlow flow =dc.tblFlow.Single();
            flow.fl_status = 30;
            Debug.Assert(flow != null);

            flow.tblReply = t;
            //db.tblReply.InsertOnSubmit(t);

            dc.SubmitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        private void TestInsertReply()
        {
            BxdbDataContext dc = new BxdbDataContext();
            tblReply t = new tblReply();
            t.rp_worker = "ww";
            
            dc.tblReply.InsertOnSubmit(t);
            dc.SubmitChanges();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void TestDiffDataContext()
        {
            BxdbDataContext dc1 = new BxdbDataContext();
            BxdbDataContext dc2 = new BxdbDataContext();

            tblOperator opFromDc1 = dc1.tblOperator.ToArray()[0];

            tblReply rp = new tblReply();
            rp.tblOperator = opFromDc1;

            dc2.tblOperator.Attach(opFromDc1);
            //dc2.tblReply.InsertOnSubmit(rp);
            dc2.SubmitChanges();
        }
    }
}
