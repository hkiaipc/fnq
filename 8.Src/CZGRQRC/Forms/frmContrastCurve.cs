using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ZedGraph;
using Xdgk.GRCommon;

namespace CZGRQRC
{
    public partial class frmContrastCurve : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmContrastCurve(GRStationCurveInfoCollection infos)
        {

            // TODO:
            //
            //if( infos.Count >= 2 )

            InitializeComponent();

            if (infos == null)
            {
                throw new ArgumentNullException("infos");
            }
            this._drawCurveInfoCollection = infos;

            this.zedFirst.IsShowPointValues = true;
            this.zedSecond.IsShowPointValues = true;

            this.zedFirst.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
            this.zedSecond.PointValueEvent += new ZedGraphControl.PointValueHandler(zedGraphControl1_PointValueEvent);
        }

        #region zedGraphControl1_PointValueEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="pane"></param>
        /// <param name="curve"></param>
        /// <param name="iPt"></param>
        /// <returns></returns>
        string zedGraphControl1_PointValueEvent(ZedGraph.ZedGraphControl sender, ZedGraph.GraphPane pane, ZedGraph.CurveItem curve, int iPt)
        {
            PointPair pt = curve[iPt];
            DateTime dt = XDate.XLDateToDateTime( pt.X);
            string s = string.Format("{0}\r\n{1}\r\n{2}", curve.Label.Text,
                dt, pt.Y.ToString("f2"));
            return s;
        }
        #endregion //zedGraphControl1_PointValueEvent
        private GRStationCurveInfoCollection _drawCurveInfoCollection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private GraphPane GetGraphPane(int i)
        {
            GraphPane[] arr = new GraphPane[] {
                this.zedFirst.GraphPane ,
                this.zedSecond.GraphPane
                };
            return arr[i];
        }

        /// <summary>
        /// 
        /// </summary>
        private void Draw()
        {
            for (int i = 0; i < 2; i++)
            {
                GRStationCurveInfo info = this._drawCurveInfoCollection[i];
                GraphPaneConfig gpconfig = //GetGraphPaneConfig(info.GRCurveType.GRCurveTypeEnum);
                info.GRCurveType.GraphPaneConfig;
                //CurveConfigCollection ccs = GetCurveConfigCollection(info.GRCurveType.GRCurveTypeEnum);

                GraphPane gp = GetGraphPane(i);
                //Draw(gp, gpconfig, ccs);
                Draw(gp, gpconfig, info);
                //gp.AxisChange();
            }
            zedFirst.AxisChange();
            zedFirst.Invalidate(true);
            zedSecond.AxisChange();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="gpconfig"></param>
        /// <param name="stationInfo"></param>
        private void Draw(GraphPane gp, GraphPaneConfig gpconfig, GRStationCurveInfo stationInfo)
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteGRDataTable(
                stationInfo.StationName, stationInfo.Begin, stationInfo.End);
            gpconfig.ConfigGraphPane(gp, stationInfo);
           

            GRDataCurveConfigCollection ccs = stationInfo.GRCurveType.GRDataCurveConfigCollection;

            foreach (GRDataCurveConfig cc in ccs )
            {
                IPointList pts = GetPointList(tbl, cc);
                string dataCurveName = GRData.GetGRDataText(cc.GRDataEnum);
                gp.AddCurve(dataCurveName, pts, cc.Color, cc.SymbolType);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <param name="cc"></param>
        /// <returns></returns>
        private IPointList GetPointList(DataTable tbl, GRDataCurveConfig cc)
        {
            PointPairList list = new PointPairList();
            foreach (DataRow row in tbl.Rows)
            {
                DateTime dt = Convert.ToDateTime(row["DT"]);
                float value = Convert.ToSingle(row[cc.GRDataEnum.ToString()]);
                XDate xdt = new XDate(dt);
                list.Add(new PointPair(xdt, value));
            }
            return list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmContrastCurve_Load(object sender, EventArgs e)
        {
            this.tsbHorizontal.Checked = true;
            Draw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbVertical_Click(object sender, EventArgs e)
        {
            this.tsbHorizontal.Checked = !this.tsbHorizontal.Checked;
            this.splitContainer1.Orientation = this.tsbHorizontal.Checked ?
                Orientation.Horizontal : Orientation.Vertical;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void splitContainer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int total = this.splitContainer1.Orientation == Orientation.Horizontal ?
                this.splitContainer1.Height : this.splitContainer1.Width;

            int distance = (total - this.splitContainer1.SplitterWidth) / 2;
            if (distance < 0)
                distance = 0;
            this.splitContainer1.SplitterDistance = distance;
        }
    }
}
