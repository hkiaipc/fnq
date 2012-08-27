using System;
using System.Collections.Generic;
using System.Text;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class GRStationCurveInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public string Display
        {
            get
            {
                return this.StationName + " - " + this.GRCurveType.Text;
            }
        }

        #region StationName
        /// <summary>
        /// 
        /// </summary>
        public string StationName
        {
            get { return _stationName; }
            set { _stationName = value; }
        } private string _stationName;
        #endregion //StationName

        #region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get { return _begin; }
            set { _begin = value; }
        } private DateTime _begin;
        #endregion //Begin

        #region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        } private DateTime _end;
        #endregion //End

        #region GRCurve
        /// <summary>
        /// 
        /// </summary>
        public GRCurveType GRCurveType
        {
            get { return _grCurveType; }
            set { _grCurveType = value; }
        } private GRCurveType _grCurveType;
        #endregion //GRCurve

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetDetail()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("站名: {0}", this.StationName));
            sb.AppendLine(string.Format("曲线: {0}", this.GRCurveType.Text));
            sb.AppendLine(string.Format("开始: {0}", this.Begin));
            sb.AppendLine(string.Format("结束: {0}", this.End));

            return sb.ToString();
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private GRDataCurveConfigCollection CurveConfigCollection
        //{
        //    get 
        //    {
        //        if (_curveConfigCollection == null)
        //        {
        //            _curveConfigCollection = new GRDataCurveConfigCollection();
        //        }
        //        return _curveConfigCollection;
        //    }
        //} private GRDataCurveConfigCollection _curveConfigCollection;
    }
}
