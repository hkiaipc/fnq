using System;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Runtime.Serialization;
using ZedGraph;

namespace CZGRCommon
{
    /// <summary>
    /// 
    /// </summary>
    public class ZedConfig
    {

        #region Default
        /// <summary>
        /// 
        /// </summary>
        static public ZedConfig Default
        {
            get { return s_default; }
        } static private ZedConfig s_default = new ZedConfig();
        #endregion //Default

        #region InitGraphPane
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public void InitGraphPane(GraphPane gp, string title)
        {
            int fontsize = 14;
            gp.Legend.FontSpec.Size = fontsize;
            gp.XAxis.Title.FontSpec.Size = fontsize;
            //gp.XAxis.MajorGrid.IsVisible = true;

            gp.YAxis.Title.FontSpec.Size = fontsize;
            gp.YAxis.MajorGrid.IsVisible = true;

            gp.Title.FontSpec.Size = fontsize + 4;
            // zi ti suo fang 
            //
            gp.IsFontsScaled = false;


            //gp.Title.Text = "压力曲线";
            gp.Title.Text = title;
        }
        #endregion //InitGraphPane

        #region ConfigTempLineGraphPane
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public void ConfigTempLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        {
            gp.XAxis.Title.Text = strings.Time;
            gp.XAxis.Title.Text = xTitle;
            gp.XAxis.Type = AxisType.Date;
            gp.XAxis.Scale.Format = "d";


            ////gp.YAxis.Title.Text = strings.Temperature;
            YAxisConfig tempconfig = ZedConfigValues.Default.TemperatureCurveConfig;
            gp.YAxis.Title.Text = yTitle;
            gp.YAxis.Scale.Min = tempconfig.Min;
            gp.YAxis.Scale.Max = tempconfig.Max;
            gp.YAxis.Scale.MajorStep = tempconfig.MajorStep;
            gp.YAxis.Scale.MinorStep = tempconfig.MinorStep;
            gp.YAxis.MajorGrid.IsVisible = tempconfig.MajorGridVisible;
            gp.YAxis.MinorGrid.IsVisible = tempconfig.MinorGridVisible;
            //gp.YAxis.Scale.MinorStep = 25;
            gp.YAxis.Scale.Format = "G";


            //gp.AddY2Axis("Flux");
            //gp.Y2Axis.Scale.Min = 0;
            //gp.Y2Axis.Scale.Max = 30;
            //gp.Y2Axis.IsVisible = true;
            //gp.Y2Axis.Title.IsVisible = true;
        }
        #endregion //ConfigTempLineGraphPane

        #region ConfigPressLineGraphPane
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        public void ConfigPressLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        {
            gp.XAxis.Title.Text = xTitle;
            gp.XAxis.Type = AxisType.Date;
            gp.XAxis.Scale.Format = "d";

            YAxisConfig yaxisConfig = ZedConfigValues.Default.PressCurveConfig;
            gp.YAxis.Title.Text = yTitle;
            gp.YAxis.Scale.Min = yaxisConfig.Min;
            gp.YAxis.Scale.Max = yaxisConfig.Max;
            gp.YAxis.Scale.MajorStep = yaxisConfig.MajorStep;
            //gp.YAxis.Scale.Format = "f2";
        }
        #endregion //ConfigPressLineGraphPane

        #region EM
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="xTitle"></param>
        /// <param name="yTitle"></param>
        public void ConfigEMLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        {
            gp.XAxis.Title.Text = xTitle;
            gp.XAxis.Type = AxisType.Date;
            gp.XAxis.Scale.Format = "d";


            gp.YAxis.Title.Text = yTitle;
        }
        #endregion //EM

        #region Recruit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="xTitle"></param>
        /// <param name="yTitle"></param>
        public void ConfigRecruitLineGraphPane(GraphPane gp, string xTitle, string yTitle)
        {
            gp.XAxis.Title.Text = xTitle;
            gp.XAxis.Type = AxisType.Date;
            gp.XAxis.Scale.Format = "d";


            gp.YAxis.Title.Text = yTitle;
        }
        #endregion //Recruit





        #region XAxisScaleFormat
        /// <summary>
        /// 
        /// </summary>
        public string XAxisScaleFormat
        {
            get { return _xaxisScaleFormat; }
            set { _xaxisScaleFormat = value; }
        } private string _xaxisScaleFormat = "yyyy-MM-dd";
        #endregion //XAxisScaleFormat
    }
}
