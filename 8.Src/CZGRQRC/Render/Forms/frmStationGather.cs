using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace CZGRQRC
{
    public partial class frmStationGather : Form
    {
        public frmStationGather()
        {
            InitializeComponent();
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_OKEvent(object sender, EventArgs e)
        {
            DateTime b = this.ucCalcHeatCondition21.Begin;
            DateTime end = this.ucCalcHeatCondition21.End;
            string sql = string.Format(
                @"select max(gt2) as 二次供温最大, min(gt2) as 二次供温最小, avg(gt2) as 二次供温平均,
                  max(bt2) as 二次回温最大, min(bt2) as 二次回温最小, avg(bt2) as 二次回温平均,
                  max(gp2) as 二次供压最大, min(gp2) as 二次供压最小, avg(gp2) as 二次供压平均,
                  max(bp2) as 二次回压最大, min(bp2) as 二次回压最小, avg(bp2) as 二次回压平均
                  from vGRData where (DT between '{0}' and '{1}') and 
                    gt2 < 100 and gt2 > 5 and 
                    bt2 < 100 and bt2 > 1 and 
                    gp2 < 1.0 and gp2 > 0.01 and 
                    bp2 < 1.0 and bp2 > 0.01",
                b,end);

            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteDataTable(sql);
            this.dataGridView1.DataSource = tbl;
            foreach( DataGridViewColumn c in dataGridView1.Columns )
            {
                c.DefaultCellStyle.Format = "f2";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucCalcHeatCondition1_ExportEvent(object sender, EventArgs e)
        {
            string filename = CZGRCommon.Path.GetTempFileName(".xls");
            CZGRCommon.ExcelExporter ee = new CZGRCommon.ExcelExporter(
                filename);
            ee.Export(this.dataGridView1);
            
            ProcessStartInfo si = new ProcessStartInfo(filename);
            si.ErrorDialog = true;
            Process.Start(si);
        }

        private void ucCalcHeatCondition21_OKEvent(object sender, EventArgs e)
        {
            ucCalcHeatCondition1_OKEvent(sender, e);
        }

        private void ucCalcHeatCondition21_ExportEvent(object sender, EventArgs e)
        {
            ucCalcHeatCondition1_ExportEvent(sender, e);
        }
    }
}
