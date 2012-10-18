using System;
using System.Collections.Generic;
using System.Text;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public class DataColumnFormulas
    {

        #region S1Diff
        static public string S1Diff
        {
            get
            {
                return string.Format("{0} - {1}", DataColumnNames.S1End, DataColumnNames.S1Begin);
            }
        }
        #endregion //S1Diff

        #region ItemHeat
        /// <summary>
        /// 单位面积整个采暖季的供热量
        /// </summary>
        /// <remarks>
        /// = 日耗热量 / 供热面积 * 供热天数
        /// </remarks>
        static public string ItemHeat
        {
            get
            {
                return string.Format("{0} * {1} / {2}",
                    CZGRQRCApp.Default.DBI.GetHeatingDays(), DataColumnNames.Heat, DataColumnNames.SupportArea);
            }
        }
        #endregion //ItemHeat

        #region PlanHeat
        /// <summary>
        /// 
        /// </summary>
        static public string PlanHeat
        {
            get
            {
                // 日计划耗热量 = 月计划耗热量 * 本站面积 / 总面积 / 当月天数
                //
                return "{0} * " + DataColumnNames.SupportArea + " / {1} / {2}";
            }
        }
        #endregion //PlanHeat


        /// <summary>
        /// 
        /// </summary>
        static public string InstantHeatFormula
        {
            get { return _instantHeatFormula; }
        } static private string _instantHeatFormula = "Heat / 24";


        /// <summary>
        /// 
        /// </summary>
        static public string InstantFluxFormula
        {
            get { return _instantFluxFormula; }
        } static private string _instantFluxFormula = " S1 / 24";


        /// <summary>
        /// 
        /// </summary>
        static public string ShiShuiLiangFormula
        {
            get { return _shiShuiLiangFormula; }
        } static private string _shiShuiLiangFormula = string.Format(
          "{0} - {1}",
          DataColumnNames.SREnd,
          DataColumnNames.SRBegin); 
    }
}
