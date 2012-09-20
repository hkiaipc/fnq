
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;
using System.Windows.Forms ;
using BXDB;


namespace fnbx
{
    public class MTStatusHelper
    {
        static public string GetFLStatusText(FLStatus status)
        {
            Type t = typeof(FLStatus);
            FieldInfo fi = t.GetField(status.ToString());
            object[] objs = fi.GetCustomAttributes(typeof(TextAttribute), true);
            if (objs.Length > 0)
            {
                TextAttribute ta = objs[0] as TextAttribute;
                return ta.Text;
            }
            else
            {
                return status.ToString();
            }
        }
    }

}
