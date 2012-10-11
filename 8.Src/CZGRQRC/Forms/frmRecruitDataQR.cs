using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmRecruitDataQR : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public frmRecruitDataQR()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            SetDataGridViewColumnConfig();
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.Recruit)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns.Add(column);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            string name = this.ucSelectCondition1.StationName ;

            DateTime b  = this.ucSelectCondition1.Begin ;
            DateTime end  = this.ucSelectCondition1.End ;
            DataTable tbl ;
            if (name == strings.All)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteRecruitData(b, end);
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteRecruitData(name, b, end);
            }
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_ExportEvent(object sender, EventArgs e)
        {
            string filename = Xdgk.Common.Path.GetTempFileName("xls");
            //Xdgk.Common.Export.ExcelExporter ee = new Xdgk.Common.Export.ExcelExporter(filename);
            //ee.Export(this.dataGridView1);
            DataFormatterCollection dfs = new DataFormatterCollection();
            dfs.Add(new SingleFormatter());
            dfs.Add(new Int32Formatter());
            dfs.Add(new DoubleFormatter());
            Xdgk.Common.Export.Exporter.Export(filename, this.dataGridView1, dfs, true);
        }
    }
}
