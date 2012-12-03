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
    internal class XfDayReportExporter : ExporterBase 
    {
        internal XfDayReportExporter(DateTime b, DateTime e)
            : base(b, e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        internal override void Export()
        {
            DataTable first = ReportHelper.GetFirstStationDataTable(this.B, this.E);
            XlsFile xls = null;

            List<string> columnList = new List<string>(new string[]{
                "StationName", "gt1", "bt1", "gp1", "bp1", "ir", "sr", "if1", "sf1"});

            int row=1, col = 1;
            foreach ( DataRow dr in first.Rows )
            {
                foreach (string colName in columnList)
                {
                    xls.SetCellValue(row, col++, dr[colName]);
                }
            }
        }
    }

}
