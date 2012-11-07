using System;
using System.Diagnostics;
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

        private void btnDetail_Click(object sender, EventArgs e)
        {
            ShowDetail();
        }

        /// <summary>
        /// 
        /// </summary>
        private void ShowDetail()
        {
            if (this.dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }

            int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
            DataRowView rowView = (DataRowView)this.dataGridView1.Rows[rowIndex].DataBoundItem;
            string recuritEx = rowView.Row["REx"].ToString();

            DataTable tbl = CreateRecuritDataTable();

            GetRecuritValues(recuritEx, tbl);

            frmFirstStationDetail f = new frmFirstStationDetail();
            f.DataSource = tbl;
            f.ShowDialog();

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateRecuritDataTable()
        {
            DataTable tbl = new DataTable();

            tbl.Columns.Add("Name", typeof(string));
            tbl.Columns.Add("DT", typeof(DateTime));
            tbl.Columns.Add("IR", typeof(double));
            tbl.Columns.Add("SR", typeof(double));
            return tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="recuritEx"></param>
        /// <param name="tbl"></param>
        private void GetRecuritValues(string recuritEx, DataTable tbl)
        {
            int no = 0;

            string[] items = recuritEx.Split('|');

            foreach (string item in items)
            {
                no++;

                string[] values = item.Split(',');
                Debug.Assert(values.Length == 4);

                DateTime dt = Convert.ToDateTime(values[0]);
                string name = values[1].ToString();
                double ir = Convert.ToDouble(values[2]);
                double sr = Convert.ToDouble(values[3]);

                DataRow row = tbl.NewRow();
                row["DT"] = DateTime.Now;
                row["IR"] = ir;
                row["SR"] = sr;
                row["Name"] = name;

                tbl.Rows.Add(row);
            }
        }
    }
}
