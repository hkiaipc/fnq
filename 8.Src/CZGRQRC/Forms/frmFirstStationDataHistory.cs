using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using Xdgk.Common.Export;

namespace FNGRQRC
{
    public partial class frmFirstStationDataHistory : Form
    {
        public frmFirstStationDataHistory()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFirstStationDataHistory_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.SetDataGridViewColumnConfig();
        }

        #region SetDataGridViewColumnConfig
        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.FirstStation)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.Name = cc.DataPropertyName;
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                this.dataGridView1.Columns.Add(column);
            }
        }
        #endregion //SetDataGridViewColumnConfig

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            DateTime b = this.ucSelectCondition1.Begin;
            DateTime e = this.ucSelectCondition1.End;
            string st = this.ucSelectCondition1.StationName;

            DataTable tbl = null;
            if (st == strings.All)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteXd100eDataTable(b, e);
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteXd100eDataTable(st, b, e);
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
            Export();
        }

        private void Export()
        {
            //throw new NotImplementedException();
            if (!ExcelExporter.CanExport(this.dataGridView1))
            { 
                string s = string.Format("数据行数不能大于 {0}", ExcelExporter.MaxRowCount);
                NUnit.UiKit.UserMessage.DisplayFailure(s);
                return;
            }

                string f = ExcelExporter.GenerateFileName();
                ExcelExporter ee = new ExcelExporter(f, DataGridViewFormatters.DefaultDataFormatterCollection);
                ee.Export(dataGridView1);

                ProcessStartInfo si = new ProcessStartInfo(f);
                si.ErrorDialog = true;
                Process.Start(si);
        }
    }
}
