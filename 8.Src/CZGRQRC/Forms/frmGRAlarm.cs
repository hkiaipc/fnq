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
//using Lucker.DataPrinter;

namespace FNGRQRC
{



    /// <summary>
    /// 
    /// </summary>
    public partial class frmGRAlarm : Form, IDataGridViewFont
    {
        #region frmGRAlarm
        /// <summary>
        /// 
        /// </summary>
        public frmGRAlarm()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
            //SetDataGridViewColumnConfig();
            DataGridViewColumnHelper.SetDataGridViewColumn(this.dataGridView1, DGVColumnConfigs.Alarm);
            this.Text = strings.GRAlarmData;
            this.dataGridView1.Font = Config.Default.DataGridViewFont;
        }
        #endregion //frmGRAlarm

        #region SetDataGridViewColumnConfig
        /// <summary>
        /// 
        /// </summary>
        private void SetDataGridViewColumnConfig()
        {
            foreach (DGVColumnConfig cc in DGVColumnConfigs.Alarm)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Columns.Add(column);
            }
        }
        #endregion //SetDataGridViewColumnConfig

        #region frmGRAlarm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRAlarm_Load(object sender, EventArgs e)
        {

        }
        #endregion //frmGRAlarm_Load

        #region ucSelectCondition1_OKEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_OKEvent(object sender, EventArgs e)
        {
            Query();
        }
        #endregion //ucSelectCondition1_OKEvent

        #region Query
        /// <summary>
        /// 
        /// </summary>
        private void Query()
        {
            DataTable tbl = null;
            if (this.ucSelectCondition1.StationName == strings.All)
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteGRAlarmDataTable(ucSelectCondition1.Begin,
                    ucSelectCondition1.End);
            }
            else
            {
                tbl = CZGRQRCApp.Default.DBI.ExecuteGRAlarmDataTable(ucSelectCondition1.StationName,
                    ucSelectCondition1.Begin,
                    ucSelectCondition1.End);
            }

            this.dataGridView1.DataSource = tbl;
        }
        #endregion //Query

        #region Query
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationName"></param>
        internal void Query(string stationName)
        {
            this.ucSelectCondition1.StationName = stationName;
            Query();
        }
        #endregion //Query

        #region ucSelectCondition1_ExportEvent
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ucSelectCondition1_ExportEvent(object sender, EventArgs e)
        {
            if (ExcelExporter.CanExport(this.dataGridView1))
            {
                string f = ExcelExporter.GenerateFileName();
                ExcelExporter ee = new ExcelExporter(f, DataGridViewFormatters.DefaultDataFormatterCollection);
                ee.Export(this.dataGridView1);

                ProcessStartInfo si = new ProcessStartInfo();
                si.FileName = f;
                si.ErrorDialog = true;
                Process.Start(si);
            }
            else
            {
                string s = string.Format("数据行数不能大于 {0}", ExcelExporter.MaxRowCount);
                NUnit.UiKit.UserMessage.DisplayFailure(s);
            }
        }
        #endregion //ucSelectCondition1_ExportEvent


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

    /// <summary>
    /// 
    /// </summary>
    public class DataGridViewColumnHelper
    {
        /// <summary>
        /// 设置DataGridView列
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="dgvConfigs"></param>
        static public void SetDataGridViewColumn(DataGridView dgv, DGVColumnConfigCollection dgvConfigs)
        {
            if (dgv == null)
            {
                throw new ArgumentNullException("dgv");
            }
            if (dgvConfigs == null)
            {
                throw new ArgumentNullException("dgvConfigs");
            }

            foreach (DGVColumnConfig cc in dgvConfigs)
            {
                DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                column.HeaderText = cc.Text;
                column.DataPropertyName = cc.DataPropertyName;
                column.DefaultCellStyle.Format = cc.Format;
                //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dgv.Columns.Add(column);
            }
        }
    }
}
