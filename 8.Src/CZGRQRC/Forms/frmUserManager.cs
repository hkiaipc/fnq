using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    public partial class frmUserManager : Form
    {
        public frmUserManager()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void frmUserManager_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            DataTable tbl = CZGRQRCApp.Default.DBI.ExecuteUserDataTable();
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUser f = new frmUser();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }


        }

        private int GetSelectedUserID()
        {
            int r = -1;
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                int id = (int)((DataRowView)row.DataBoundItem)["UserID"];
                return id;
            }
            return r;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = GetSelectedUserID();

            if (id > 0)
            {
                frmUser f = new frmUser();
                f.Edit = true;
                f.UserID = id;
                f.User = GetSelectedUser();
                f.Role = GetSelectedRole();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private int GetSelectedRole()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                int id = Convert.ToInt32(((DataRowView)row.DataBoundItem)["Role"]);
                return id;
            }
            return -1;
        }

        private string GetSelectedUser()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                int rowIndex = this.dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow row = this.dataGridView1.Rows[rowIndex];
                string id = ((DataRowView)row.DataBoundItem)["Name"].ToString();
                return id;
            }
            return string.Empty;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = this.GetSelectedUserID();
            if (id > 0)
            {
                if (NUnit.UiKit.UserMessage.Ask(strings.SureDelete) == DialogResult.Yes)
                {
                    CZGRQRCApp.Default.DBI.DeleteUser(id);
                    Fill();
                }
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dataGridView1.Columns[e.ColumnIndex] == colRole)
            {
                Debug.Assert((Int16)e.Value == 0 || (Int16)e.Value == 1);
                e.Value = (Int16)e.Value == 0 ? "用户" : "管理员";
                e.FormattingApplied = true;
            }
        }
    }
}
