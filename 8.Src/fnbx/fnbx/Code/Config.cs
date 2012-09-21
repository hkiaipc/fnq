using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common ;

namespace fnbx
{
    /// <summary>
    /// 
    /// </summary>
    public class Config : SelfSerializer 
    {
        /// <summary>
        /// 
        /// </summary>
        public string[] DisplayFlowColumns
        {
            get 
            {
                if (_displayFlowColumns == null)
                {
                    _displayFlowColumns = new string[] 
                    { 
                        "ItName",
                        "FlStatus"
                    };
                }
                return _displayFlowColumns; 
            }
            set { _displayFlowColumns = value; }
        } private string[] _displayFlowColumns;
    }
}
