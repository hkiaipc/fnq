
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
    public interface IView
    {
        void UpdateModel();
        bool CheckInput();
        //FLStatus[] NotReadonlyStatusArray { get; }
        bool IsReadonly(Right rt, FLStatus status);
    }

}
