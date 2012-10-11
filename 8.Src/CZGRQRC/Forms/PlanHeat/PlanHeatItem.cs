using System;
using System.Collections.Generic;
using System.Text;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class PlanHeatItem
    {
        #region Month
        /// <summary>
        /// 
        /// </summary>
        public int Month
        {
            get { return _month; }
            set { _month = value; }
        } private int _month;
        #endregion //Month

        #region PlanHeat
        /// <summary>
        /// 
        /// </summary>
        public int PlanHeat
        {
            get { return _planHeat; }
            set { _planHeat = value; }
        } private int _planHeat;
        #endregion //PlanHeat

    }


    /// <summary>
    /// 
    /// </summary>
    public class PlanHeatItemCollection : Collection<PlanHeatItem>
    {
    }
}
