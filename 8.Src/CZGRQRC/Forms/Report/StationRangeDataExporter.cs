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
                Title = new Point(1, 3),
                AvgOTText = new Point(3, 1),
                      AVGOTValue = new Point(3, 2),
                      AVGGT1 = new Point(3, 4),
                      AVGBT1 = new Point(3, 6),
                      AVGI1 = new Point(3, 8),
                      DT = new Point(2, 8)
                          ;

            internal static int
                BeginRow = 4,
                                HeatCol = 2,
                                RecuritFluxCol = 4,
                                StationNameCol = 1,
                                TotalColumns = 8
                                    ;

            internal static string[] FirstStationHeads = new string[] { 
                "首站名称",
                "平均供温", "平均回温",	
                "平均供压",	"平均回压",
                "平均流量"
            };

            internal static string[] FirstStationColumnNames = new string[] {
                "stationName",
                "gt1", "bt1",
                "gp1", "bp1",
                "i1"
            };

            internal static string[] StationHeads = new string[] { 
                "换热站名称",
                "总热量消耗",
                "总用电量",
                "总补水量",
                "实际供热面",
                "人工费用",
                "用户维修费用",
                "合计" 
            };
        }

        private string _xlsPath = Path.Combine(
                Application.StartupPath,
                "RT\\StationCost.xls");

        internal StationRangeDataExporter(DateTime b, DateTime e)
            : base(b, e)
        {
        }


        override internal void Export()
        {
            // begin first station head row
            //
            int row = ReportConfig.BeginRow;

            XlsFile xls = new XlsFile();
            //xls.Open(_xlsPath);
            xls.NewFile(1);

            string title = string.Format(
                    "热力站供热成本分析 {0} ~ {1}",
                    B, E);

            SetCellValue(xls, ReportConfig.Title, title);
            SetCellValue(xls, ReportConfig.AvgOTText, "室外平均温度", false);
            SetCellValue(xls, ReportConfig.AVGOTValue, ReportHelper.GetAvgOT(B, E));
            //double[] values = ReportHelper.GetAvgValues(B, E);

            // add first station head text
            //
            for (int i = 0; i < ReportConfig.FirstStationHeads.Length; i++)
            {
                string value = ReportConfig.FirstStationHeads[i];
                SetCellValue(xls, row, i + 1, value, true);
            }
            row++;

            DataTable firstStationDataTbl = ReportHelper.GetFirstStationAvgDataTable(B, E);
            foreach (DataRow dataRow in firstStationDataTbl.Rows)
            {
                //foreach (string columnName in ReportConfig.FirstStationColumnNames)
                for (int i = 0; i < ReportConfig.FirstStationColumnNames.Length; i++)
                {
                    string columnName = ReportConfig.FirstStationColumnNames[i];
                    SetCellValue(xls, row, i + 1, dataRow[columnName], true);
                }
                row++;
            }

            // empty line
            //
            row++;


            for (int i = 0; i < ReportConfig.StationHeads.Length; i++)
            {
                SetCellValue(xls, row, i + 1, ReportConfig.StationHeads[i], true);
            }
            row++;

            //SetCellValue(xls, ReportConfig.AVGGT1, values[0]);
            //SetCellValue(xls, ReportConfig.AVGBT1, values[1]);
            //SetCellValue(xls, ReportConfig.AVGI1, values[2]);

            //SetCellValue(xls, ReportConfig.DT, DateTime.Now.ToString("yyyy-MM-dd"));

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
                //int r = ReportConfig.BeginRow + i;

                FillXlsRowWithEmpty(xls, row, ReportConfig.TotalColumns);

                DataRow dataRow = tbl.Rows[i];
                double heatValue = Math.Round(Convert.ToDouble(dataRow["heat"]), ReportHelper.DotNumber);
                if (heatValue < 0)
                {
                    heatValue = 0;
                }

                SetCellValue(xls, row, ReportConfig.HeatCol,
                        heatValue,
                        true);

                SetCellValue(xls, row, ReportConfig.RecuritFluxCol,
                        Math.Round(Convert.ToDouble(dataRow["recurite"]), ReportHelper.DotNumber),
                        true);
                SetCellValue(xls, row, ReportConfig.StationNameCol,
                        dataRow["StationName"].ToString(), true);

                row++;
            }

            double sumHeat = 0d;
            double sumRecurite = 0d;

            foreach (DataRow dataRow in tbl.Rows)
            {
                double val = Convert.ToDouble(dataRow["heat"]);
                sumHeat += val < 0 ? 0 : val;
                sumRecurite += Convert.ToDouble(dataRow["recurite"]);
            }

            FillXlsRowWithEmpty(xls, row, ReportConfig.TotalColumns);
            SetCellValue(xls, row, ReportConfig.HeatCol,
                    Math.Round(sumHeat, ReportHelper.DotNumber),
                    true);

            SetCellValue(xls, row, ReportConfig.RecuritFluxCol,
                    Math.Round(sumRecurite, ReportHelper.DotNumber),
                    true);
            SetCellValue(xls, row, ReportConfig.StationNameCol,
                    "合计", true);

            row++;

            string outputPath = Xdgk.Common.Path.GetTempFileName("xls");
            xls.Save(outputPath);

            Open(outputPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xls"></param>
        /// <param name="row"></param>
        /// <param name="columnCount"></param>
        private void FillXlsRowWithEmpty(XlsFile xls, int row, int columnCount)
        {
            for (int c = 1; c <= columnCount; c++)
            {
                SetCellValue(xls, row, c, string.Empty, true);
            }
        }
    }

}
