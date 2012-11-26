using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZGRWEBDBI;
using FlexCel;
using FlexCel.XlsAdapter;

namespace FNGRQRC.Forms
{
    public partial class frmReport : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmReport()
        {
            InitializeComponent();

            this.dtpBegin.Value = DateTime.Now.Date - TimeSpan.FromDays(2d);
            this.dtpEnd.Value = DateTime.Now.Date - TimeSpan.FromDays(1d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // 1. all station: avg ot, gt1, bt1, if
            // 2. one station: heat, sum of rf
            // 3. 

            new StationRangeDataExporter(this.dtpBegin.Value,
                this.dtpEnd.Value).Export();
            /*
            string path = "e:\\_\\1.xls";
            string path2 = "e:\\_\\2.xls";
            FlexCel.XlsAdapter.XlsFile xls = new XlsFile(path);
            xls.SetCellValue(1, 1, "a string" + DateTime.Now.ToString());
            xls.Save(path2);
             */

        }
    }

    internal class StationRangeDataExporter
    {
        internal class ReportConfig
        {
            internal static Point
                Title = new Point(1, 1),
                AVGOT = new Point(3, 2),
                AVGGT1 = new Point(3, 4),
                AVGBT1 = new Point(3, 6),
                AVGI1 = new Point(3, 8),
                DT = new Point(2, 8)
                ;

            internal static int
                StationStartRow = 5,
                HeatCol = 2,
                RecuritFluxCol = 4,
                StationNameCol = 1
                ;
        }

        private DateTime _b, _e;
        private string _xlsPath = Path.Combine(
            Application.StartupPath,
            "RT\\StationCost.xls");

        internal StationRangeDataExporter(DateTime b, DateTime e)
        {
            this._b = b;
            this._e = e;
        }

        void SetCellValue(XlsFile xls, Point pt, object value)
        {
            xls.SetCellValue(pt.X, pt.Y, value);
        }

        internal void Export()
        {
            XlsFile xls = new XlsFile();
            xls.Open(_xlsPath);

            string title = string.Format(
                "热力站 {0}-{1} ~ {2}-{3}供热成本分析",
                _b.Month, _b.Day, _e.Month, _e.Day);

            SetCellValue(xls, ReportConfig.Title, title);

            SetCellValue(xls, ReportConfig.AVGOT, ReportHelper.GetAvgOT(_b, _e));
            double[] values = ReportHelper.GetAvgValues(_b, _e);

            SetCellValue(xls, ReportConfig.AVGGT1, values[0]);
            SetCellValue(xls, ReportConfig.AVGBT1, values[1]);
            SetCellValue(xls, ReportConfig.AVGI1, values[2]);

            SetCellValue(xls, ReportConfig.DT, DateTime.Now.ToString("yyyy-MM-dd"));

            // 日耗热量 = 日流量 * ( 一次供温 - 一次回温 ) * 4.1816 / 1000
            //
            DataTable tbl = ReportHelper.GetStationData(_b, _e);
            DataColumn heatCol = new DataColumn(
                "heat",
                typeof(double),
                "(maxs1 - mins1) * (gt1 - bt1) * 4.1816 / 1000");

            tbl.Columns.Add(heatCol);

            DataColumn recuriteCol = new DataColumn("recurite",
                typeof(double),
                "maxsr-minsr");

            tbl.Columns.Add(recuriteCol);

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];
                int r = ReportConfig.StationStartRow + i;
                xls.SetCellValue(r, ReportConfig.HeatCol,
                    Math.Round(Convert.ToDouble(row["heat"]), ReportHelper.DotNumber)
                    );
                xls.SetCellValue(r, ReportConfig.RecuritFluxCol,
                   Math.Round(Convert.ToDouble(row["recurite"]), ReportHelper.DotNumber)
                    );
                xls.SetCellValue(r, ReportConfig.StationNameCol,
                    row["StationName"].ToString());
            }

            string outputPath = Xdgk.Common.Path.GetTempFileName("xls");
            xls.Save(outputPath);

            Open(outputPath);

        }

        internal void Open(string filename)
        {
            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;

            Process process = new Process();
            process.StartInfo = si;
            try
            {
                process.Start();
            }
            catch (Exception ex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
            }
            process.Dispose();
        }

    }

    internal class ReportHelper
    {
        static public int DotNumber = 2;
        static public DBI GetDBI()
        {
            if (_dbi == null)
            {
                //_dbi = CZGRWEBDBI.DBI.Default;
                _dbi = CZGRQRCApp.Default.DBI;
            }
            return _dbi;

        } static private DBI _dbi;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static public double GetAvgOT(DateTime b, DateTime e)
        {
            string s = string.Format(
                "select avg(ot) from tblgrdata where ot > -49 and dt >= '{0}' and dt <= '{1}'",
                b, e);
            object obj = GetDBI().ExecuteScalar(s);
            if (obj != DBNull.Value)
            {
                double ot = Convert.ToDouble(obj);
                ot = Math.Round(ot, DotNumber);
                return ot;
            }
            return 0d;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns>double[]: gt1, bt1, i1</returns>
        static public double[] GetAvgValues(DateTime b, DateTime e)
        {
            string s = string.Format(
                @"select avg(gt1) as gt1, avg(bt1) as bt1, avg(i1) as i1 
                from tblgrdata 
                where gt1 > -90 and dt >='{0}' and dt < '{1}'",
                b, e);

            DataTable tbl = GetDBI().ExecuteDataTable(s);
            List<double> list = new List<double>();
            DataRow r = tbl.Rows[0];
            list.Add(Math.Round(ConvertToDoubleSafe(r["gt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(r["bt1"]), DotNumber));
            list.Add(Math.Round(ConvertToDoubleSafe(r["i1"]), DotNumber));

            return list.ToArray();
        }

        static double ConvertToDoubleSafe(object obj)
        {
            double r = 0d;
            if (obj != null && obj != DBNull.Value)
            {
                r = Convert.ToDouble(obj);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        /// <returns></returns>
        static public DataTable CreateStationDetail(DataTable tbl)
        {
            // add calc column
            //
            //
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static public DataTable GetStationData(DateTime b, DateTime e)
        {
            string s = string.Format(
                @" select stationname, 
                avg(gt1) as gt1, avg(bt1) as bt1, 
                max(s1) as maxs1, min(s1) as mins1,
                max(sr) as maxsr, min(sr) as minsr
                from vgrdata 
                where dt >= '{0}' and dt < '{1}' 
                group by stationname",
                b, e);

            return GetDBI().ExecuteDataTable(s);

        }
    }
}
