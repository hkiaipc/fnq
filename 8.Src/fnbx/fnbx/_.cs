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
    /// <summary>
    /// 
    /// </summary>
    public interface IView
    {
        void UpdateModel();
        bool CheckInput();
        //FLStatus[] NotReadonlyStatusArray { get; }
        bool IsReadonly(Right rt, FLStatus status);
    }

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

    public interface IReadonly
    {
        bool Readonly { get; set; }
    }
    


    /// <summary>
    /// 
    /// </summary>
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
