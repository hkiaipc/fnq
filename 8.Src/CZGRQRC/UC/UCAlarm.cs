using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC.UC
{
    public partial class UCAlarm : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public UCAlarm()
        {
            InitializeComponent();
            //this.dataGridView1.row
            this.dataGridView1.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            DataTable tbl = this.dataGridView1.DataSource as DataTable;
            if (tbl != null)
            {
                tbl.Rows.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCAlarm_Load(object sender, EventArgs e)
        {
            DataGridViewColumnHelper.SetDataGridViewColumn(this.dataGridView1, DGVColumnConfigs.Alarm);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbl"></param>
        public void AddGRAlarm(DataTable tbl)
        {
            DataTable s = this.dataGridView1.DataSource as DataTable;
            if (s == null)
            {
                s = tbl.Copy();
                this.dataGridView1.DataSource = s;
            }
            else
            {
                s.Merge(tbl);
            }

            if (dataGridView1.Rows.Count > 0)
            {
                // remove records
                //
                if (dataGridView1.Rows.Count > Config.Default.GRAlarmMaxCount)
                {
                    int n = dataGridView1.Rows.Count - Config.Default.GRAlarmMaxCount;
                    for (int i = 0; i < n; i++)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                        //s.Rows[0].Delete();
                    }
                }

                // move to last record
                //
                DataGridViewCell lastCell = this.dataGridView1[0, this.dataGridView1.Rows.Count - 1];
                this.dataGridView1.CurrentCell = lastCell;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteSelect_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvRow = this.dataGridView1.CurrentRow;
            if (dgvRow != null)
            {
                DataRowView row = dgvRow.DataBoundItem as DataRowView;
                if (row != null)
                {
                    row.Delete();
                }
            }
            //if (this.dataGridView1.SelectedRows.Count > 0)
            //{
            //    DataRow row =  this.dataGridView1.SelectedRows[0].DataBoundItem as DataRow;
            //    if (row != null)
            //    {
            //        row.Delete();
            //    }
            //}
        }

        /// <summary>
        /// 报警列表中是否包含指定报警
        /// </summary>
        /// <returns></returns>
        public bool HasAlarm(string displayName, string dataName)
        {
            DataTable tbl = this.dataGridView1.DataSource as DataTable;
            if (tbl == null)
                return false;

            string dataDisplay = GetDataNameDisplay(dataName);
            if (dataDisplay == "")
            {
                return false;
            }

            foreach (DataRow row in tbl.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    string content = row["content"].ToString();
                    string displayName2 = row["stationName"].ToString();
                    if (Xdgk.Common.StringHelper.Equal(displayName, displayName2))
                    {
                        int index = content.IndexOf(dataDisplay);
                        if (index != -1)
                            return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataName"></param>
        /// <returns></returns>
        private string GetDataNameDisplay(string dataName)
        {
            // dataName
            // gt1 gt2 gp2 bp2
            //
            string[] datanames = new string[] { "gt1", "gt2", "gp2", "bp2" };
            string[] displays = new string[] { "一次供温", "二次供温", "二次供压", "二次回压" };

            for( int i=0; i<datanames.Length ; i++ )
            {
                string s = datanames[i];
                if (Xdgk.Common.StringHelper.Equal(s, dataName))
                {
                    return displays[i];
                }
            }
            return "";
        }
    }
}
