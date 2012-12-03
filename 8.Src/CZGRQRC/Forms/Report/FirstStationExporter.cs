
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FlexCel.XlsAdapter;


namespace FNGRQRC.Forms
{
    internal class FirstStationExporter : ExporterBase 
    {
        internal class ReportConfig
        {
            internal static Point
                Title = new Point(1, 1),
                      AVGOT = new Point(3, 3),
                      AVGGT1 = new Point(3, 5),
                      AVGBT1 = new Point(3, 7),
                      AVGI1 = new Point(3, 9),
                      DT = new Point(2, 9)
                          ;

            internal static int
                StationStartRow = 5,
                                RecuritFluxCol = 3,
                                StationNameCol = 1
                                    ;
        }

        string _xlsPath = Path.Combine(
                Application.StartupPath, 
                "RT\\FirstStationCost.xls");

        internal FirstStationExporter(DateTime b, DateTime e)
            : base(b, e)
        {
        }


        internal override void  Export()
        {
            XlsFile xls = new XlsFile();
            xls.Open(_xlsPath);

            string title = string.Format(
                    "{0}-{1} ~ {2}-{3} 热源厂成本对比",
                    B.Month, B.Day, E.Month, E.Day);

            SetCellValue(xls, ReportConfig.Title, title);
            SetCellValue(xls, ReportConfig.AVGOT, ReportHelper.GetAvgOT(B, E));

            double[] values = ReportHelper.GetFirstValues (B,E);

            SetCellValue(xls, ReportConfig.AVGGT1, values[0]);
            SetCellValue(xls, ReportConfig.AVGBT1, values[1]);
            SetCellValue(xls, ReportConfig.AVGI1, values[2]);

            SetCellValue(xls, ReportConfig.DT, DateTime.Now.ToString("yyyy-MM-dd"));

            DataTable tbl = ReportHelper .GetFirstRecuriteDataTable ( B,E );

            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                DataRow row = tbl.Rows[i];

                string name = row["stationname"].ToString();
                double usedRecurit = Math.Round(
                        Convert.ToDouble(row["usedr"]),
                        ReportHelper.DotNumber);

                int r = ReportConfig.StationStartRow + i;
                xls.SetCellValue(r, ReportConfig.StationNameCol, name);
                xls.SetCellValue(r, ReportConfig.RecuritFluxCol, usedRecurit);
            }


            string output = Xdgk.Common.Path.GetTempFileName("xls");
            xls.Save(output);


            Open(output);

        }


    }

}
