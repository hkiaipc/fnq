using System;
using System.Collections;
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
using FNGRQRC.Forms.Report;


namespace FNGRQRC.Forms
{
    internal class XfDayReportExporter : ExporterBase
    {
        /// <summary>
        /// 
        /// </summary>
        internal class Config
        {
            static internal Point
                Title = new Point(1, 1),
                Range = new Point(2, ColumnCount),
                FirstStationTitle = new Point(3, 1)
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
                "���", "��Դ��", "һ�ι���", "һ�λ���", "һ�ι�ѹ", "һ�λ�ѹ", 
                "һ��˲ʱ", "һ���ۼ�", "��ˮ˲ʱ", "��ˮ�ۼ�", "��ע" };

            static internal string[] StationColumnNames = new string[] {
                "���", "վ��", "һ�ι���", "һ�λ���", "���ι���", "���λ���", "һ�ι�ѹ", 
                "һ�λ�ѹ", "���ι�ѹ", "���λ�ѹ", "һ��˲ʱ����", "���ſ���"
            };


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="b"></param>
        /// <param name="e"></param>
        internal XfDayReportExporter(DateTime b, DateTime e)
            : base(b, e)
        {
        }

        private string _xlsPath = Path.Combine(
                Application.StartupPath,
                "RT\\Day.xls");

        private XlsFile _xls;

        /// <summary>
        /// 
        /// </summary>
        internal override void Export()
        {
            _xls = new XlsFile();
            _xls.Open(_xlsPath);

            //_xls.SetCellValue (Config.
            SetCellValue(_xls, Config.Title,
                string.Format(ReportStrings.Title, B, E));

            MergeCells(_xls, Config.Title.X, Config.Title.Y,
                Config.ColumnCount, false);

            //SetCellValue(_xls, Config.Range, "TODO: 2012-1-1");


            // set first column names
            //

            int row = ExportFirst(9);
            ExportStations(row);

            string filename = Xdgk.Common.Path.GetTempFileName("xls");
            _xls.Save(filename);
            Open(filename);
        }



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
            //_xls.SetCellValue(row, Config.TitleColumn, ReportStrings.StationTitle);
            SetCellValue(_xls, row, Config.TitleColumn, ReportStrings.StationTitle);
            MergeCells(_xls, row, Config.TitleColumn, Config.ColumnCount);

            row++;

            // 
            //
            //int colOffset = 1;
            //for (int i = 0; i < Config.StationColumnNames.Length; i++)
            //{
            //    string v = Config.StationColumnNames[i];
            //    int col = colOffset + i;
            //    _xls.SetCellValue(row, col, v);
            //}
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
                    SetCellValue(_xls, row, 1, street);
                    MergeCells(_xls, row, 1, Config.ColumnCount);
                    row++;
                }

                //_xls.SetCellValue(row, 1, no++);
                SetCellValue(_xls, row, 1, no++);
                for (int i = 0; i < columnNameList.Count; i++)
                {
                    object value = dr[columnNameList[i]];
                    value = Format(value);
                    int col = Config.StationDataColumnOffset + i;
                    //_xls.SetCellValue(row, col, value);
                    SetCellValue(_xls, row, col, value);
                }
                row++;
            }

            return row;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startRow"></param>
        /// <returns></returns>
        private int ExportFirst(int startRow)
        {
            SetCellValue(_xls, Config.FirstStationTitle, ReportStrings.FirstTitle);
            MergeCells(_xls, Config.FirstStationTitle.X,
                Config.FirstStationTitle.Y, Config.ColumnCount);

            int lastCol = SetCellValues(_xls, Config.FirstTitleRow, 1, Config.FirstColumnNames);
            if (lastCol < Config.ColumnCount)
            {
                MergeCells(_xls, Config.FirstTitleRow, lastCol, Config.ColumnCount - lastCol);
            }

            DataTable first = ReportHelper.GetFirstStationDataTable(this.B, this.E);

            List<string> columnNameList = new List<string>(new string[]{
                "StationName", "gt1", "bt1", "gp1", "bp1", "ir", "sr", "if1", "sf1"});

            // set values
            //
            int row = startRow;

            int no = 1;
            foreach (DataRow dr in first.Rows)
            {
                //_xls.SetCellValue(row, Config.NoColumn, no++);
                SetCellValue(_xls, row, Config.NoColumn, no++);

                for (int i = 0; i < columnNameList.Count; i++)
                {
                    string colName = columnNameList[i];
                    int col = Config.FirstDataColumnOffset + i;
                    object val = Format(dr[colName]);
                    //_xls.SetCellValue(row, col, val);

                    SetCellValue(_xls, row, col, val);

                }
                row++;
            }

            startRow = row;
            return startRow;
        }
    }

}
