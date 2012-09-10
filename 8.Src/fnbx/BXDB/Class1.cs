using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BXDB
{
    public class Class1
    {
        static private BXDB.BxdbDataContext _dc;
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public BXDB.BxdbDataContext GetBxdbDataContext()
        {
            if (_dc == null)
            {
                _dc = new BxdbDataContext();
            }
            return _dc;
        }
    }
}
