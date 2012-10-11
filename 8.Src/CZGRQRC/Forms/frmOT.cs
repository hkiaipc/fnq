using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CZGRCommon;

namespace FNGRQRC
{
    public partial class frmOT : Form
    {
        public frmOT()
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
            Utility.DataGridViewColumnFactory.Create(this.dataGridView1, DGVColumnConfigs.OT);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmOT_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucotCondition1_OKEvent(object sender, EventArgs e)
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteOTDataTable(
                this.ucotCondition1.Begin,
                this.ucotCondition1.End);
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucotCondition1_ExportEvent(object sender, EventArgs e)
        {
            if (ExcelExporter.CanExport(dataGridView1))
            {
                string f = ExcelExporter.GenerateFileName();
                ExcelExporter ee = new ExcelExporter(f, DataGridViewFormatters.DefaultDataFormatterCollection);
                ee.Export(dataGridView1);

                ProcessStartInfo si = new ProcessStartInfo(f);
                si.ErrorDialog = true;
                Process.Start(si);
            }
            else
            {
                string s = string.Format(strings.RowCountOutOfRange, ExcelExporter.MaxRowCount);
                NUnit.UiKit.UserMessage.DisplayFailure(s);
            }
        }
    }
}
