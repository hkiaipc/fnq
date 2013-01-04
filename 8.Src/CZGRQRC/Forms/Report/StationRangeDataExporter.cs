using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FlexCel.XlsAdapter;


namespace FNGRQRC.Forms
{
    internal class StationRangeDataExporter : ExporterBase
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
                                StationNameCol = 1,
                                TotalColumns = 8
                                    ;
        }

        private string _xlsPath = Path.Combine(
                Application.StartupPath,
                "RT\\StationCost.xls");

        internal StationRangeDataExporter(DateTime b, DateTime e)
            : base (b,e)
        {
        }


        override internal void Export()
        {
            XlsFile xls = new XlsFile();
            xls.Open(_xlsPath);

            string title = string.Format(
                    "热力站供热成本分析 {0} ~ {1}",
                    B, E);

            SetCellValue(xls, ReportConfig.Title, title);

            SetCellValue(xls, ReportConfig.AVGOT, ReportHelper.GetAvgOT(B, E));
            double[] values = ReportHelper.GetAvgValues(B, E);

            SetCellValue(xls, ReportConfig.AVGGT1, values[0]);
            SetCellValue(xls, ReportConfig.AVGBT1, values[1]);
            SetCellValue(xls, ReportConfig.AVGI1, values[2]);

            SetCellValue(xls, ReportConfig.DT, DateTime.Now.ToString("yyyy-MM-dd"));

            // 日耗热量 = 日流量 * ( 一次供温 - 一次回温 ) * 4.1816 / 1000
            //
            DataTable tbl = ReportHelper.GetStationData(B, E);
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
                int r = ReportConfig.StationStartRow + i;

                FillXlsRowWithEmpty(xls, r, ReportConfig.TotalColumns);

                DataRow row = tbl.Rows[i];
                SetCellValue(xls, r, ReportConfig.HeatCol,
                        Math.Round(Convert.ToDouble(row["heat"]), ReportHelper.DotNumber),
                        true);

                SetCellValue(xls, r, ReportConfig.RecuritFluxCol,
                        Math.Round(Convert.ToDouble(row["recurite"]), ReportHelper.DotNumber),
                        true);
                SetCellValue(xls,r, ReportConfig.StationNameCol,
                        row["StationName"].ToString(), true);
            }

            string outputPath = Xdgk.Common.Path.GetTempFileName("xls");
            xls.Save(outputPath);

            Open(outputPath);
        }

        private void FillXlsRowWithEmpty(XlsFile xls, int row, int columnCount)
        {
            for( int c = 1; c<=columnCount ; c++)
            {
                SetCellValue(xls, row, c, string.Empty, true);
            }
        }
    }

}
