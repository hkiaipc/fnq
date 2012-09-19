using System;
using System.Data.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXDB
{
    /// <summary>
    /// 
    /// </summary>
    public class DBFactory
    {
        //static private BXDB.BxdbDataContext _dc;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public BXDB.BxdbDataContext GetBxdbDataContext()
        {
            //if (_dc == null)
            //{
            //    _dc = new BxdbDataContext();
            //    _dc.Log = Console.Out;
            //}
            //return _dc;
            return CreateDataContext();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public BxdbDataContext CreateDataContext()
        {
            //DataLoadOptions option = new DataLoadOptions();
            //option.LoadWith<tblOperator>(c => c.tblRight);

            //option.LoadWith<tblFlow>(c => c.tblMaintain);
            //option.LoadWith<tblFlow>(c => c.tblIntroducer);
            //option.LoadWith<tblFlow>(c => c.tblReceive);
            //option.LoadWith<tblFlow>(c => c.tblReply);

            //option.LoadWith<tblMaintain>(c => c.tblOperator);
            //option.LoadWith<tblMaintain>(c => c.tblMaintainLevel);

            //option.LoadWith<tblReceive>(c => c.tblOperator);
            //option.LoadWith<tblReply>(c => c.tblOperator);

            BxdbDataContext dc = new BxdbDataContext();
            //dc.DeferredLoadingEnabled = false;
            //dc.LoadOptions = option;
            dc.Log = Console.Out;
            return dc;
        }
    }
}
