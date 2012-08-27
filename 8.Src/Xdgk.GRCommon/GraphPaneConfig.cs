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
    public class GraphPaneConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public GraphPaneConfig()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public void ConfigGraphPane(GraphPane gp, GRStationCurveInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            gp.Title.Text = string.Format(this.TitleFormat, info.StationName,
                info.Begin, info.End);
            gp.Title.FontSpec.Size = TitleFontSize;
            gp.Legend.FontSpec.Size = OtherFontSize;
            gp.XAxis.Title.FontSpec.Size = OtherFontSize;
            gp.YAxis.Title.FontSpec.Size = OtherFontSize;
            gp.IsFontsScaled = this.IsFontsScaled;

            gp.XAxis.Title.Text = XTitle;
            gp.YAxis.Title.Text = YTitle;
            //gp.XAxis.Scale.Min = XMin;
            //gp.XAxis.Scale.Max = XMax;
            gp.XAxis.Type = this.XAxisType;
            gp.XAxis.Scale.Format = XAxisScaleFormat;
            gp.XAxis.MajorGrid.IsVisible = XMajorGridVisible;
            gp.XAxis.MinorGrid.IsVisible = XMinorGridVisible;

            gp.YAxis.Scale.Min = YMin;
            gp.YAxis.Scale.Max = YMax;

            gp.XAxis.Scale.MajorStep = XMajorStep;
            gp.XAxis.Scale.MinorStep = XMinorStep;
            gp.YAxis.Scale.MajorStep = YMajorStep;
            gp.YAxis.Scale.MinorStep = YMinorStep;
            gp.YAxis.Scale.Format = YAxisScaleFormat;
            gp.YAxis.MajorGrid.IsVisible = YMajorGridVisible;
            gp.YAxis.MinorGrid.IsVisible = YMinorGridVisible;
        }

        #region Title
        /// <summary>
        /// graphpane title format string
        /// </summary>
        public string TitleFormat
        {
            get { return _titleFormat; }
            set { _titleFormat = value; }
        } private string _titleFormat= "Title";
        #endregion //Title

        #region XTitle
        /// <summary>
        /// 
        /// </summary>
        public string XTitle
        {
            get { return _xTitle; }
            set { _xTitle = value; }
        } private string _xTitle = "XTitle";
        #endregion //XTitle

        #region YTitle
        /// <summary>
        /// 
        /// </summary>
        public string YTitle
        {
            get { return _yTitle; }
            set { _yTitle = value; }
        } private string _yTitle = "YTitle";
        #endregion //YTitle

        #region XMin
        /// <summary>
        /// 
        /// </summary>
        public double XMin
        {
            get { return _xMin; }
            set { _xMin = value; }
        } private double _xMin = 0;
        #endregion //XMin

        #region XMax
        /// <summary>
        /// 
        /// </summary>
        public double XMax
        {
            get { return _xMax; }
            set { _xMax = value; }
        } private double _xMax = 100;
        #endregion //XMax

        #region YMin
        /// <summary>
        /// 
        /// </summary>
        public double YMin
        {
            get { return _yMin; }
            set { _yMin = value; }
        } private double _yMin = 0;
        #endregion //YMin

        #region YMax
        /// <summary>
        /// 
        /// </summary>
        public double YMax
        {
            get { return _yMax; }
            set { _yMax = value; }
        } private double _yMax = 100;
        #endregion //YMax



        #region TitleFontSize
        /// <summary>
        /// 
        /// </summary>
        public int TitleFontSize
        {
            get { return _titleFontSize; }
            set { _titleFontSize = value; }
        } private int _titleFontSize = 18;
        #endregion //TitleFontSize

        #region OtherFontSize
        /// <summary>
        /// 
        /// </summary>
        public int OtherFontSize
        {
            get { return _otherFontSize; }
            set { _otherFontSize = value; }
        } private int _otherFontSize = 14;
        #endregion //OtherFontSize

        #region IsFontsScaled
        /// <summary>
        /// 
        /// </summary>
        public bool IsFontsScaled
        {
            get { return _isFontsScaled; }
            set { _isFontsScaled = value; }
        } private bool _isFontsScaled = false;
        #endregion //IsFontsScaled

        #region XAxisType
        /// <summary>
        /// 
        /// </summary>
        public AxisType XAxisType
        {
            get { return _xAxisType; }
            set { _xAxisType = value; }
        } private AxisType _xAxisType = AxisType.Date;
        #endregion //XAxisType

        #region XAxisScaleFormat
        /// <summary>
        /// 
        /// </summary>
        public string XAxisScaleFormat
        {
            get { return _xAxisScaleFormat; }
            set { _xAxisScaleFormat = value; }
        } private string _xAxisScaleFormat = "d";
        #endregion //XAxisScaleFormat

        #region XMajorStep
        /// <summary>
        /// 
        /// </summary>
        public double XMajorStep
        {
            get { return _xMajorStep; }
            set { _xMajorStep = value; }
        } private double _xMajorStep;
        #endregion //XMajorStep

        #region XMinorStep
        /// <summary>
        /// 
        /// </summary>
        public double XMinorStep
        {
            get { return _xMinorStep; }
            set { _xMinorStep = value; }
        } private double _xMinorStep;
        #endregion //XMinorStep

        #region YMajorStep
        /// <summary>
        /// 
        /// </summary>
        public double YMajorStep
        {
            get { return _yMajorStep; }
            set { _yMajorStep = value; }
        } private double _yMajorStep = 10;
        #endregion //YMajorStep

        #region YMinorStep
        /// <summary>
        /// 
        /// </summary>
        public double YMinorStep
        {
            get { return _yMinorStep; }
            set { _yMinorStep = value; }
        } private double _yMinorStep = 5;
        #endregion //YMinorStep

        #region XMajorGridVisible
        /// <summary>
        /// 
        /// </summary>
        public bool XMajorGridVisible
        {
            get { return _xMajorGridVisible; }
            set { _xMajorGridVisible = value; }
        } private bool _xMajorGridVisible = false;
        #endregion //XMajorGridVisible

        #region XMinorGridVisible
        /// <summary>
        /// 
        /// </summary>
        public bool XMinorGridVisible
        {
            get { return _xMinorGridVisible; }
            set { _xMinorGridVisible = value; }
        } private bool _xMinorGridVisible = false;
        #endregion //XMinorGridVisible

        #region YMajorGridVisible
        /// <summary>
        /// 
        /// </summary>
        public bool YMajorGridVisible
        {
            get { return _yMajorGridVisible; }
            set { _yMajorGridVisible = value; }
        } private bool _yMajorGridVisible = true;
        #endregion //YMajorGridVisible

        #region YMinorGridVisible
        /// <summary>
        /// 
        /// </summary>
        public bool YMinorGridVisible
        {
            get { return _yMinorGridVisible; }
            set { _yMinorGridVisible = value; }
        } private bool _yMinorGridVisible = false;
        #endregion //YMinorGridVisible

        #region YAxisScaleFormat
        /// <summary>
        /// 
        /// </summary>
        public string YAxisScaleFormat
        {
            get { return _yAxisScaleFormat; }
            set { _yAxisScaleFormat = value; }
        } private string _yAxisScaleFormat = "G";
        #endregion //YAxisScaleFormat

    }

    /// <summary>
    /// 
    /// </summary>
    public class GraphPaneConfigCollection : Xdgk.Common.Collection<GraphPaneConfig>
    {
    }
}
