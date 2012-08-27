using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ZedGraph;
using CZGRCommon;

namespace CZGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmRecruitCurve : Form
    {
        public frmRecruitCurve()
        {
            InitializeComponent();
            this.Text = strings.RecruitCurve;

            this.zedGraphControl1.IsShowPointValues = true;
            this.zedGraphControl1.PointValueEvent += new ZedGraph.ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
            ZedConfig.Default.InitGraphPane(this.zedGraphControl1.MasterPane[0], strings.RecruitCurve);
            ZedConfig.Default.ConfigRecruitLineGraphPane(this.zedGraphControl1.GraphPane, strings.Time, strings.FluxAxisTitle);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pane"></param>
        /// <param name="curve"></param>
        /// <param name="iPt"></param>
        /// <returns></returns>
        string zedGraphControl1_PointValueEvent(ZedGraph.ZedGraphControl sender, ZedGraph.GraphPane pane, ZedGraph.CurveItem curve, 
            int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime dt = XDate.XLDateToDateTime(pt.X);
            string s = string.Format("{0}\r\n{1}\r\n{2}", curve.Label.Text,
                dt, pt.Y.ToString("f2"));
            return s;        
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            DateTime begin = this.ucSelectCondition1.Begin;
            DateTime end = this.ucSelectCondition1.End;
            string stationname = this.ucSelectCondition1.StationName;

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteRecruitData(stationname, begin, end);
            LineHelper[] lines = GetLineHelpers(tbl);

            GraphPane mypane = this.zedGraphControl1.GraphPane;
            mypane.CurveList.Clear();

            foreach (LineHelper l in lines)
            {
                LineItem lineItem = mypane.AddCurve(l.Text, l.PointList, l.Color);
                lineItem.Line.Width = l.LineWidth;
                lineItem.Symbol = l.Symbol;
                lineItem.IsY2Axis = l.IsY2Axis;
                //lineItem.YAxisIndex 
            }
            mypane.Title.Text = GetCurveTitle();
            this.zedGraphControl1.AxisChange();
            this.zedGraphControl1.Invalidate(true);
        }

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
            s += this.ucSelectCondition1.StationName + strings.IR;
            return s;
        }
        #endregion //GetCurveTitle


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private LineHelper [] GetLineHelpers(DataTable tbl)
        {
            LineHelper emLine = new LineHelper(strings.IR, Color.Red, 1, SymbolType.None );
            LineHelper[] lines = new LineHelper[] { emLine };

            foreach (DataRow row in tbl.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["dt"]);
                XDate xdt = XDate.DateTimeToXLDate(dt);
                float ir = Convert.ToSingle(row["IR"]);
                emLine.PointList.Add(xdt, ir);
            }
            return lines;
        }
    }
}
