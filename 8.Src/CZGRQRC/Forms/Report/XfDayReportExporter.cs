using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FlexCel.XlsAdapter;
using FNGRQRC.Forms.Report;


namespace FNGRQRC.Forms
{
    /// <summary>
    /// 
    /// </summary>
    internal class XfDayReportExporter : ExporterBase
    {
        /// <summary>
        /// 
        /// </summary>
        internal class Config
        {
            #region Members
            static internal Rectangle 
                TitleArea = new Rectangle(1, 1, ColumnCount, 1),
                FirstStationTitleArea = new Rectangle(1, 3, ColumnCount, 1)
                ;

            internal const int ColumnCount = 12,
                StationTitleColumn = 1,
                TitleColumn = 1,
                AreaTitleColumn = 1,
                FirstTitleRow = 4,
                StationDataColumnOffset = 2,
                FirstDataColumnOffset = 2,
                NoColumn = 1
                ;

            static internal string[] FirstColumnNames = new string[] {
                "序号", "热源厂", "一次供温", "一次回温", "一次供压", "一次回压", 
                "一次瞬时", "一次累计", "补水瞬时", "补水累计", "备注", null };

            static internal string[] StationColumnNames = new string[] {
                "序号", "站名", "一次供温", "一次回温", "二次供温", "二次回温", "一次供压", 
                "一次回压", "二次供压", "二次回压", "一次瞬时流量", "阀门开度"
            };
            #endregion //Members
        }

        #region Members
        /// <summary>
        /// 
        /// </summary>
        private string _xlsPath = Path.Combine(
                Application.StartupPath,
                "RT\\Day.xls");

        /// <summary>
        /// 
        /// </summary>
        private XlsFile _xls;
        #endregion //Members

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        internal XfDayReportExporter(DateTime b, DateTime e)
            : base(b, e)
        {
        }
        #endregion //Constructor

        #region Export
        /// <summary>
        /// 
        /// </summary>
        internal override void Export()
        {
            _xls = new XlsFile();
            //_xls.Open(_xlsPath);
            _xls.NewFile (1);

            SetCellValue(_xls, Config.TitleArea,
                string.Format(ReportStrings.Title, B, E), false);
            MergeCells(_xls, Config.TitleArea);

            // set first column names
            //

            int row = ExportFirst(5);
            ExportStations(row);

            string filename = Xdgk.Common.Path.GetTempFileName("xls");
            _xls.Save(filename);
            Open(filename);
        }
        #endregion //Export

        #region ExportStations
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <returns></returns>
        private int ExportStations(int startRow)
        {
            DataTable stationDataTable = ReportHelper.GetStationData(this.B, this.E);
            List<string> columnNameList = new List<string>(new string[]{
                "stationname", "gt1", "bt1", "gt2", "bt2", "gp1", "bp1", 
                "gp2", "bp2", "i1", "od"
            });

            int row = startRow;
            Rectangle a = new Rectangle(1, row, Config.ColumnCount, 1);
            SetCellValue(_xls, a, ReportStrings.StationTitle, true);
            MergeCells(_xls, a);
            SetBorder(_xls, a, true, FlexCel.Core.THFlxAlignment.center);

            row++;

            SetCellValues(_xls, row, 1, Config.StationColumnNames);
            row++;

            string lastStreetName = string.Empty;
            //
            //
            int no = 1;
            foreach (DataRow dr in stationDataTable.Rows)
            {

                string street = dr["street"].ToString().Trim();
                if (street != lastStreetName)
                {
                    lastStreetName = street;
                    Rectangle area = new Rectangle(1, row, Config.ColumnCount, 1);
                    SetCellValue(_xls, area, street, true);
                    MergeCells(_xls, area);
                    SetBorder(_xls, area, true, FlexCel.Core.THFlxAlignment.center);
                    row++;
                }

                List<object> valueList = new List<object>();
                valueList.Add(no++);

                for (int i = 0; i < columnNameList.Count; i++)
                {
                    object value = dr[columnNameList[i]];
                    value = Format(value);
                    int col = Config.StationDataColumnOffset + i;
                    valueList.Add(value);
                }
                SetCellValues(_xls, row, 1, valueList);
                row++;
            }

            return row;
        }
        #endregion //ExportStations

        #region ExportFirst
        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <returns></returns>
        private int ExportFirst(int startRow)
        {
            SetCellValue(_xls, Config.FirstStationTitleArea, ReportStrings.FirstTitle, true);
            MergeCells(_xls, Config.FirstStationTitleArea);
            SetBorder(_xls, Config.FirstStationTitleArea, true, FlexCel.Core.THFlxAlignment.center);

            int lastCol = SetCellValues(_xls, Config.FirstTitleRow, 1, Config.FirstColumnNames);
            if (lastCol < Config.ColumnCount)
            {
                MergeCells(_xls, Config.FirstTitleRow, lastCol, Config.ColumnCount - lastCol);
            }

            DataTable first = ReportHelper.GetFirstStationDataTable(this.B, this.E);

            List<string> columnNameList = new List<string>(new string[]{
                "StationName", "gt1", "bt1", "gp1", "bp1", "ir", "sr", "if1", "sf1", "remark", null});

            // set values
            //
            int row = startRow;

            int no = 1;
            foreach (DataRow dr in first.Rows)
            {
                List<object> valueList = new List<object>();
                valueList.Add(no++);

                for (int i = 0; i < columnNameList.Count; i++)
                {
                    string colName = columnNameList[i];
                    if (colName == null)
                    {
                        valueList.Add(null);
                    }
                    else
                    {
                        object val = Format(dr[colName]);
                        valueList.Add(val);
                    }

                }

                SetCellValues(_xls, row, 1, valueList);
                row++;
            }

            startRow = row;
            return startRow;
        }
        #endregion //ExportFirst
    }

}
