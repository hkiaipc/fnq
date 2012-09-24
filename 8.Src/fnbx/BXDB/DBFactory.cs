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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public BXDB.BxdbDataContext GetBxdbDataContext()
        {
            return CreateDataContext();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public BxdbDataContext CreateDataContext()
        {
            BxdbDataContext dc = new BxdbDataContext();
            //dc.Log = Console.Out;
            return dc;
        }
    }
}
