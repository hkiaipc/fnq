
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
    public class ReadonlyHelper
    {
        static public void SetReadonlyStyle( Control c , bool isReadonly )
        {
            if (c is IReadonly)
            {
                ((IReadonly)c).Readonly = isReadonly;
            }
            else if (c is TextBox)
            {
                ((TextBox)c).ReadOnly = isReadonly;
            }
            else
            {
                c.Enabled = !isReadonly;
            }
        }

        static public void SetReadonlyStyle(Control[] controls, bool isReadonly)
        {
            foreach (Control c in controls)
            {
                SetReadonlyStyle(c, isReadonly);
            }
        }
    }

}
