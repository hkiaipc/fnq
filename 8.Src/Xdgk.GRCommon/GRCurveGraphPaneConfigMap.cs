using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Xdgk.GRCommon
{
    /// <summary>
    /// 
    /// </summary>
    internal class GRCurveGraphPaneConfigMap
    {

        /// <summary>
        /// 
        /// </summary>
        static private Hashtable Table
        {
            get
            {
                if (_table == null)
                {
                    _table = new Hashtable();
                    _table.Add(GRCurveTypeEnum.TemperatureCurve, GetTemperatureGraphPaneConfig());
                    _table.Add(GRCurveTypeEnum.PressureCurve, GetPressGraphPaneConfig());
                    _table.Add(GRCurveTypeEnum.OTCurve, GetOTGraphPaneConfig());
                    _table.Add(GRCurveTypeEnum.FluxCurve,  GetFluxGraphPaneConfig());
                    _table.Add(GRCurveTypeEnum.HeatCurve, GetHeatGraphPaneConfig());
                }
                return _table;
            }

        } static private Hashtable _table;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private GraphPaneConfig GetHeatGraphPaneConfig()
        {
            GraphPaneConfig c = new GraphPaneConfig();
            c.YMin = 0;
            c.YMin = 500;
            c.YMajorStep = 50;
            c.YMinorStep = 25;
            c.YTitle = GraphPaneConfigStrings.HeatAxisTitle ;
            c.XTitle = GraphPaneConfigStrings.DateTimeAxisTitle;
            c.TitleFormat = GraphPaneConfigStrings.HeatTitleFormat;
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private GraphPaneConfig GetFluxGraphPaneConfig()
        {
            GraphPaneConfig c = new GraphPaneConfig();
            c.YMin = 0;
            c.YMax = 500;
            c.YMajorStep = 50;
            c.YMinorStep = 25;

            c.YTitle = GraphPaneConfigStrings.FluxAxisTitle;
            c.XTitle = GraphPaneConfigStrings.DateTimeAxisTitle;
            c.TitleFormat = GraphPaneConfigStrings.FluxTitleFormat;
            
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private GraphPaneConfig GetOTGraphPaneConfig()
        {
            GraphPaneConfig c = new GraphPaneConfig();
            c.YMin = -50;
            c.YMax = 20;
            c.YMajorStep = 10;
            c.YMinorStep = 5;

            c.YTitle = GraphPaneConfigStrings.OTAxisTitle;
            c.XTitle = GraphPaneConfigStrings.DateTimeAxisTitle;
            c.TitleFormat = GraphPaneConfigStrings.OTTitleFormat;
            
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private GraphPaneConfig GetTemperatureGraphPaneConfig()
        {
            GraphPaneConfig c = new GraphPaneConfig();
            c.YMin = 0;
            c.YMax = 100;
            c.YMajorStep = 10;
            c.YMinorStep = 5;

            c.YTitle = GraphPaneConfigStrings.TemperatureAxisTitle;
            c.XTitle = GraphPaneConfigStrings.DateTimeAxisTitle;
            c.TitleFormat = GraphPaneConfigStrings.TemperatureTitleFormat;
            
            return c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static private GraphPaneConfig GetPressGraphPaneConfig()
        {
            GraphPaneConfig c = new GraphPaneConfig();
            c.YMin = 0;
            c.YMax = 1;
            c.YMajorStep = 0.1;
            c.YMinorStep = 0.05;

            c.YTitle = GraphPaneConfigStrings.PressAxisTitle;
            c.XTitle = GraphPaneConfigStrings.DateTimeAxisTitle;
            c.TitleFormat = GraphPaneConfigStrings.PressTitleFormat;
            
            return c;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        static public GraphPaneConfig GetGraphPaneConfig(GRCurveTypeEnum e)
        {
            object obj = Table[e];
            return obj as GraphPaneConfig;
        }
    }
}
