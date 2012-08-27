using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CZGRCommon;
using Xdgk.Common;

namespace CZGRQRC
{
    public partial class frmXGDataQR : Form , IDataGridViewFont 
    {
        /// <summary>
        /// 
        /// </summary>
        public frmXGDataQR()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            SetDataGridViewColumnConfig();
            this.Text = strings.XGData;
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.XG)
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
            Query();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            DataTable tbl = null;
            DateTime b = ucSelectCondition1.Begin;
            DateTime end = ucSelectCondition1.End;

            if (this.ucSelectCondition1.StationName == strings.All)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteXGDataTable(b, end);
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteXGDataTable(ucSelectCondition1.StationName,
                    b, end);
            }
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        public void Query(string stationName)
        {
            this.ucSelectCondition1.StationName = stationName;
            this.Query();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmXGDataQR_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_ExportEvent(object sender, EventArgs e)
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

        #region IDataGridViewFont 成员

        /// <summary>
        /// 
        /// </summary>
        public Font DataGridViewFont
        {
            get
            {
                return this.dataGridView1.Font;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("DataGridViewFont");
                this.dataGridView1.Font = value;
            }
        }

        #endregion
    }
}
