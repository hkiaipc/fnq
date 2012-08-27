using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class GRCurveType
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEnum"></param>
        /// <returns></returns>
        static public Color GetGRDataCurveColor(GRDataEnum dataEnum)
        {
            return GRDataColorMap.GetGRDataCurveColor(dataEnum);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curveEnum"></param>
        /// <param name="text"></param>
        public GRCurveType(GRCurveTypeEnum curveEnum, string text)
        {
            this.GRCurveTypeEnum = curveEnum;
            this.Text = text;
        }

        #region GRCurveEnum
        /// <summary>
        /// 
        /// </summary>
        public GRCurveTypeEnum GRCurveTypeEnum
        {
            get { return _gRCurveEnum; }
            set { _gRCurveEnum = value; }
        } private GRCurveTypeEnum _gRCurveEnum;
        #endregion //GRCurveEnum

        #region Text
        /// <summary>
        /// 
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        } private string _text;
        #endregion //Text

        /// <summary>
        /// 
        /// </summary>
        public GRDataEnum[] GRDataEnums
        {
            get 
            {
                return GRCurveGRDataMap.GetGRDataEnums(this.GRCurveTypeEnum);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public GRDataCurveConfigCollection GRDataCurveConfigCollection
        {
            get 
            {
                GRDataCurveConfigCollection r = new GRDataCurveConfigCollection();
                GRDataEnum[] dataEnums = this.GRDataEnums;
                foreach (GRDataEnum e in dataEnums)
                {
                    GRDataCurveConfig c = GRDataCurveConfigFactory.Create(e);
                    r.Add(c);
                }
                return r;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public GraphPaneConfig GraphPaneConfig
        {
            get
            {
                return GRCurveGraphPaneConfigMap.GetGraphPaneConfig(this.GRCurveTypeEnum);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class GRDataCurveConfigFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static internal GRDataCurveConfig Create (GRDataEnum e)
        {
            Color c = GRDataColorMap.GetGRDataCurveColor(e);
            return new GRDataCurveConfig(e, 1, c);
        }
    }
}
