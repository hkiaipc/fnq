using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xdgk.Common;

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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static public FlStatusColorCollection GetDefaultStatusColors()
        {
            FlStatusColorCollection statusColors = new FlStatusColorCollection();
            statusColors.Add(new FlStatusColor(FLStatus.New, Color.White));
            statusColors.Add(new FlStatusColor(FLStatus.Created, Color.White));
            statusColors.Add(new FlStatusColor(FLStatus.Received, Color.AliceBlue));
            statusColors.Add(new FlStatusColor(FLStatus.Completed, Color.LightBlue));
            statusColors.Add(new FlStatusColor(FLStatus.Closed, Color.Silver));
            statusColors.Add(new FlStatusColor(FLStatus.Finally, Color.Silver));
            statusColors.Add(new FlStatusColor(FLStatus.Timeouted, Color.Salmon));
            return statusColors;
        }

        /// <summary>
        /// 
        /// </summary>
        public FlStatusColorCollection StatusColors
        {
            get
            {
                return _statusColors;
            }
            set
            {
                _statusColors = value;
            }
        } private FlStatusColorCollection _statusColors;
    }
}
