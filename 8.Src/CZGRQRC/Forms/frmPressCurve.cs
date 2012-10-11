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
    public partial class frmPressCurve : Form
    {

        #region frmPressCurve
        /// <summary>
        /// 
        /// </summary>
        public frmPressCurve()
        {
            InitializeComponent();
            this.ucSelectCondition1.IsAddAll = false;
            this.Text = strings.PressCurve;
            this.ucSelectCondition1.ShowExport = false;
            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);

            //SetAxisTitle ( mypane );
            ZedConfig.Default.ConfigPressLineGraphPane(this.zedGraphControl1.MasterPane[0], 
                strings.Time, strings.Press + "(MPa)");
        }
        #endregion //frmPressCurve

        #region zedGraphControl1_PointValueEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pane"></param>
        /// <param name="curve"></param>
        /// <param name="iPt"></param>
        /// <returns></returns>
        string zedGraphControl1_PointValueEvent(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt)
        {
			// Get the PointPair that is under the mouse
			PointPair pt = curve[iPt];
            DateTime dt = XDate.XLDateToDateTime( pt.X);
            string s = string.Format("{0}\r\n{1}\r\n{2}", curve.Label.Text,
                dt, pt.Y.ToString("f2"));
            return s;
        }
        #endregion //zedGraphControl1_PointValueEvent

        #region frmPressCurve_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPressCurve_Load(object sender, EventArgs e)
        {
            ZedConfig.Default.InitGraphPane(this.zedGraphControl1.MasterPane[0], "压力曲线");
        }
        #endregion //frmPressCurve_Load


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
            LineHelper gp1Line = new LineHelper(strings.GP1, ColorHelper.GetLineColor(strings.GP1), 
                ZedConfigValues.Default.GP1Config.Width, SymbolType.None);

            LineHelper bp1Line = new LineHelper(strings.BP1, ColorHelper.GetLineColor(strings.BP1),
                ZedConfigValues.Default.BP1Config.Width, SymbolType.None);

            LineHelper gp2Line = new LineHelper(strings.GP2, ColorHelper.GetLineColor(strings.GP2),
                ZedConfigValues.Default.GP2Config.Width, SymbolType.None);
            LineHelper bp2Line = new LineHelper(strings.BP2, ColorHelper.GetLineColor(strings.BP2),
                ZedConfigValues.Default.BP2Config.Width, SymbolType.None);

            LineHelper[] lines = new LineHelper[] { gp1Line, bp1Line, gp2Line, bp2Line };

            //tbl.Compute(
            foreach (DataRow row in tbl.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["dt"]);
                XDate xdt = XDate.DateTimeToXLDate(dt);
                float gp1 = (float)Math.Round(Convert.ToSingle(row["gp1"]), 2);
                float bp1 = (float)Math.Round(Convert.ToSingle(row["bp1"]), 2);
                float gp2 = (float)Math.Round(Convert.ToSingle(row["gp2"]), 2);
                float bp2 = (float)Math.Round(Convert.ToSingle(row["bp2"]), 2);
                //pts.Add(xdt, gt1);

                gp1Line.PointList.Add(xdt, gp1);
                bp1Line.PointList.Add(xdt, bp1);
                gp2Line.PointList.Add(xdt, gp2);
                bp2Line.PointList.Add(xdt, bp2);
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

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecutePressTable(this.ucSelectCondition1.Begin,
                this.ucSelectCondition1.End, this.ucSelectCondition1.StationName);

            LineHelper[] lines = this.GetLineHelpers(tbl);

            mypane.CurveList.Clear();
            foreach (LineHelper l in lines)
            {
                LineItem lineItem = mypane.AddCurve(l.Text, l.PointList, l.Color);
                lineItem.Line.Width = l.LineWidth;
                lineItem.Symbol = l.Symbol;
            }

            // title
            //
            mypane.Title.Text = this.GetCurveTitle();
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate(true);

            Gather(tbl);
        }
        #endregion //DrawCurve

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        private void Gather(DataTable tbl)
        {
            IList<GatherClass> gathers = new List<GatherClass>();
            if (tbl.Rows.Count > 0)
            {
                gathers.Clear();
                string[] columnNames = new string[] { "gp1", "bp1", "gp2", "bp2" };
                string[] texts = new string[] { strings.GP1, strings.BP1, strings.GP2, strings.BP2 };

                //foreach( string cn in columnNames )
                for (int i = 0; i < texts.Length; i++)
                {
                    string cn = columnNames[i];
                    string text = texts[i];

                    DateTime maxDT, minDT;
                    float max, min, avg;
                    GetGatherValues(tbl, cn, out maxDT, out max, out  minDT, out  min, out  avg);
                    GatherClass gc = new GatherClass(cn, text, maxDT, max, minDT, min, avg);
                    gathers.Add(gc);
                }
            }
            this.ucGatherDataGridView1.GatherClasses = gathers;
        }


        #region GetGatherValues
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="columnName"></param>
        /// <param name="maxDT"></param>
        /// <param name="max"></param>
        /// <param name="minDT"></param>
        /// <param name="min"></param>
        /// <param name="avg"></param>
        /// <returns></returns>
        private void GetGatherValues(DataTable tbl, string columnName, 
            out DateTime maxDT, out float max,
            out DateTime minDT, out float min, 
            out float avg)
        {
            maxDT = DateTime.MinValue;
            minDT = DateTime.MinValue;
            max = 0;
            min = 0;
            avg = 0;
            bool inited = false;

            string expression = string.Format("AVG({0})", columnName);
            string filter = string.Empty;

            avg = (float)tbl.Compute(expression, filter);
            foreach (DataRow row in tbl.Rows)
            {
                float temp = (float)row[columnName];
                DateTime dt = (DateTime)row["DT"];

                if (!inited)
                {
                    maxDT = dt;
                    minDT = dt;
                    max = temp;
                    min = temp;
                    inited = true;
                }
                else
                {
                    if (temp > max)
                    {
                        max = temp;
                        maxDT = dt;
                    }
                    else if (temp < min)
                    {
                        min = temp;
                        minDT = dt;
                    }
                }
            }
        }
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
            s += this.ucSelectCondition1.StationName + " 压力曲线";
            return s;
        }
        #endregion //GetCurveTitle


        #region ucSelectCondition1_Load
        private void ucSelectCondition1_Load(object sender, EventArgs e)
        {

        }
        #endregion //ucSelectCondition1_Load
    }


}
