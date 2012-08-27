using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using ZedGraph;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class GRDataCurveConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataEnum"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        public GRDataCurveConfig( GRDataEnum dataEnum, int width, Color color )
        {
            this.GRDataEnum = dataEnum;
            this.Width = width;
            this.Color = color;
        }

        #region GRDataEnum
        /// <summary>
        /// 
        /// </summary>
        public GRDataEnum GRDataEnum
        {
            get { return _grDataEnum; }
            set { _grDataEnum = value; }
        } private GRDataEnum _grDataEnum;
        #endregion //GRDataEnum

        #region Width
        /// <summary>
        /// 
        /// </summary>
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        } private int _width = 1;
        #endregion //Width

        #region Color
        /// <summary>
        /// 
        /// </summary>
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        } private Color _color = Color.Black;
        #endregion //Color

        #region SymbolType
        /// <summary>
        /// 
        /// </summary>
        public SymbolType SymbolType
        {
            get { return _symbolType; }
            set { _symbolType = value; }
        } private SymbolType _symbolType = SymbolType.None; 
        #endregion //SymbolType

    }

    /// <summary>
    /// 
    /// </summary>
    public class GRDataCurveConfigCollection : Xdgk.Common.Collection<GRDataCurveConfig>
    {

    }
}
