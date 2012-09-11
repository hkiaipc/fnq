using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;
using BXDB;


namespace fnbx
{
    class _
    {
    }

    static public class tblMaintainExtend
    {
        static public MTStatus GetMtStatus(this tblMaintain mt)
        {
            MTStatus status = (MTStatus)mt.mt_status;
            return status;
        }
    }
}
