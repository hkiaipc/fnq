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
    public partial class frmFirstStationDataLast : Form
    {
        public frmFirstStationDataLast()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmShouZhanLast_Load(object sender, EventArgs e)
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.SetDataGridViewColumnConfig();
            Fill();
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
        private void Fill()
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteXD100eLastDataTable();
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// refresh data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Fill();
        }
    }
}
