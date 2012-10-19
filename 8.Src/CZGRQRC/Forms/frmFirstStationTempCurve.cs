using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZGRCommon;
using ZedGraph;

namespace FNGRQRC
{
    public partial class frmFirstStationTempCurve : Form
    {
        #region frmTempCurve
        /// <summary>
        /// 
        /// </summary>
        public frmFirstStationTempCurve()
        {
            InitializeComponent();
            this.ucSelectCondition1.IsAddAll = false;
            this.Text = strings.FirstStationTempCurve;
            this.ucSelectCondition1.ShowExport = false;
            this.ucSelectCondition1.ShowExport = false;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);

            //SetAxisTitle ( mypane );
            ZedConfig.Default.ConfigTempLineGraphPane(this.zedGraphControl1.MasterPane[0], 
                strings.Time, strings.Temperature + "(℃)");
        }
        #endregion //frmTempCurve


        #region zedGraphControl1_PointValueEvent
        string zedGraphControl1_PointValueEvent(ZedGraph.ZedGraphControl sender, ZedGraph.GraphPane pane, ZedGraph.CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime dt = XDate.XLDateToDateTime( pt.X);
            string s = string.Format("{0}\r\n{1}\r\n{2}", curve.Label.Text,
                dt, pt.Y.ToString("f2"));
            return s;
        }
        #endregion //zedGraphControl1_PointValueEvent


        #region frmTempCurve_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTempCurve_Load(object sender, EventArgs e)
        {
            ZedConfig.Default.InitGraphPane(this.zedGraphControl1.MasterPane[0], "温度曲线");
        }
        #endregion //frmTempCurve_Load


        #region GetLineHelpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="dateTime_2"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        //private LineHelper[] GetLineHelpers(DateTime b, DateTime e, string st)
        private LineHelper[] GetLineHelpers(DataTable tbl)
        {
            LineHelper gt1Line = new LineHelper(strings.GT1, ColorHelper.GetLineColor(strings.GT1),
                ZedConfigValues.Default.GT1Config.Width, SymbolType.None);
            LineHelper bt1Line = new LineHelper(strings.BT1, ColorHelper.GetLineColor(strings.BT1),
                ZedConfigValues.Default.BT1Config.Width, SymbolType.None);


            LineHelper[] lines = new LineHelper[] { gt1Line, bt1Line };

            foreach (DataRow row in tbl.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["dt"]);
                XDate xdt = XDate.DateTimeToXLDate(dt);
                float gt1 = (float)Math.Round(Convert.ToSingle(row["ai1"]), 2);
                float bt1 = (float)Math.Round(Convert.ToSingle(row["ai2"]), 2);

                gt1Line.PointList.Add(xdt, gt1);
                bt1Line.PointList.Add(xdt, bt1);
            }

            return lines;
        }
        #endregion //GetLineHelpers


        #region ucSelectCondition1_OKEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            DrawCurve();
        }
        #endregion //ucSelectCondition1_OKEvent


        #region DrawCurve
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        public void DrawCurve(string stationName)
        {
            this.ucSelectCondition1.StationName = stationName;
            this.DrawCurve();
        }
        #endregion //DrawCurve


        #region DrawCurve
        /// <summary>
        /// 
        /// </summary>
        private void DrawCurve()
        {
            GraphPane mypane = this.zedGraphControl1.MasterPane[0];

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteXd100eDataTable(
                this.ucSelectCondition1.StationName,
                this.ucSelectCondition1.Begin,
                this.ucSelectCondition1.End);

            //DataTable otTbl = CZGRQRCApp.Default.DBI.ExecuteOTDataTable(this.ucSelectCondition1.Begin,
            //    this.ucSelectCondition1.End);

            LineHelper[] lines = this.GetLineHelpers(tbl);

            mypane.CurveList.Clear();
            foreach (LineHelper l in lines)
            {
                LineItem lineItem = mypane.AddCurve(l.Text, l.PointList, l.Color);
                lineItem.Line.Width = l.LineWidth;
                lineItem.Symbol = l.Symbol;
                lineItem.IsY2Axis = l.IsY2Axis;
                //lineItem.YAxisIndex 
            }

            // TODO: 2011-01-04 add ot line
            //

            // title
            //
            //GetCurveTitle(mypane);
            mypane.Title.Text = GetCurveTitle();

            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate(true);

            //Gather(tbl);
        }
        #endregion //DrawCurve


        #region Gather
        ///// <summary>
        ///// 
        ///// </summary>
        //private void Gather(DataTable tbl)
        //{
        //    IList<GatherClass> gathers = new List<GatherClass>();
        //    if (tbl.Rows.Count > 0)
        //    {
        //        gathers.Clear();
        //        string[] columnNames = new string[] { "gt1", "bt1", "gt2", "bt2" };
        //        string[] texts = new string[] { strings.GT1, strings.BT1, strings.GT2, strings.BT2 };

        //        //foreach( string cn in columnNames )
        //        for (int i = 0; i < texts.Length; i++)
        //        {
        //            string cn = columnNames[i];
        //            string text = texts[i];

        //            DateTime maxDT, minDT;
        //            float max, min, avg;
        //            GetGatherValues(tbl, cn, out maxDT, out max, out  minDT, out  min, out  avg);
        //            GatherClass gc = new GatherClass(cn, text, maxDT, max, minDT, min, avg);
        //            gathers.Add(gc);
        //        }
        //    }
        //    this.ucGatherDataGridView1.GatherClasses = gathers;
        //}
        #endregion //Gather


        #region GetGatherValues
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tbl"></param>
        ///// <param name="columnName"></param>
        ///// <param name="maxDT"></param>
        ///// <param name="max"></param>
        ///// <param name="minDT"></param>
        ///// <param name="min"></param>
        ///// <param name="avg"></param>
        ///// <returns></returns>
        //private void GetGatherValues(DataTable tbl, string columnName, 
        //    out DateTime maxDT, out float max,
        //    out DateTime minDT, out float min, 
        //    out float avg)
        //{
        //    maxDT = DateTime.MinValue;
        //    minDT = DateTime.MinValue;
        //    max = 0;
        //    min = 0;
        //    avg = 0;
        //    bool inited = false;

        //    string expression = string.Format("AVG({0})", columnName);
        //    string filter = string.Empty;

        //    avg = (float)tbl.Compute(expression, filter);
        //    foreach (DataRow row in tbl.Rows)
        //    {
        //        float temp = (float)row[columnName];
        //        DateTime dt = (DateTime)row["DT"];

        //        if (!inited)
        //        {
        //            maxDT = dt;
        //            minDT = dt;
        //            max = temp;
        //            min = temp;
        //            inited = true;
        //        }
        //        else
        //        {
        //            if (temp > max)
        //            {
        //                max = temp;
        //                maxDT = dt;
        //            }
        //            else if (temp < min)
        //            {
        //                min = temp;
        //                minDT = dt;
        //            }
        //        }
        //    }
        //}
        #endregion //GetGatherValues

        #region GetCurveTitle
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCurveTitle()
        {
            string s = string.Empty;
            if (Config.Default.IsShowDateTimeCurveTitle)
            {
                s = string.Format("{0} ~ {1} ", this.ucSelectCondition1.Begin, 
                    this.ucSelectCondition1.End );
            }
            s += this.ucSelectCondition1.StationName + " 温度曲线";
            return s;
        }
        #endregion //GetCurveTitle


        #region ucSelectCondition1_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_Load(object sender, EventArgs e)
        {

        }
        #endregion //ucSelectCondition1_Load
    }
}
