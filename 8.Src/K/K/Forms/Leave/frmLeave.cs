using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.Leave
{
    public partial class frmLeave : Form
    {
        public frmLeave()
        {
            InitializeComponent();
            this.dataGridView1.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLeaveItem f = new frmLeaveItem();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        private void Fill()
        {
            DB db = DBFactory.GetDB();
            DataTable tbl = ConvertToDataTable(db.tblLeave.ToList());
            this.dataGridView1.DataSource = tbl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private DataTable ConvertToDataTable(List<tblLeave> list)
        {
            DataTable t = CreateDataTable();
            foreach (var item in list)
            {

                object[] values = new object[] {
                    item.tblPerson.PersonName ,
                    item.LeaveBegin,
                    item.LeaveEnd ,
                    CovertToLeaveTypeName(item.LeaveType ),
                    item.LeaveRemark ,
                    item
                };
                t.Rows.Add(values);
            };

            return t;
        }

        private object CovertToLeaveTypeName(int leaveType)
        {
            LeaveEnum e = (LeaveEnum)leaveType;
            string[] names = new string[] { "事假", "病假", "休假" };
            return names[(int)e];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDataTable()
        {
            DataTable t = new DataTable();
            t.Columns.Add("PersonName", typeof(string));
            t.Columns.Add("Begin", typeof(DateTime));
            t.Columns.Add("End", typeof(DateTime));
            t.Columns.Add("Type", typeof(string));
            t.Columns.Add("Remark", typeof(string));
            t.Columns.Add("tblLeave", typeof(object));
            return t;
        }

        private void frmLeaveItem_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tblLeave leave = GetSelectedLeave();
            if (leave == null)
            {
                return;
            }

            frmLeaveItem f = new frmLeaveItem(leave);
            //f.Leave = leave
            if (f.ShowDialog () == DialogResult.OK )
            {
                Fill();
            }
        }

        private tblLeave GetSelectedLeave()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                DataRowView v = this.dataGridView1.CurrentRow.DataBoundItem as DataRowView;
                return v["tblLeave"] as tblLeave;
            }
            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            tblLeave leave = this.GetSelectedLeave();
            if (leave != null)
            {
                if(NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
                {
                    DB db = DBFactory.GetDB();
                    db.tblLeave.DeleteOnSubmit(
                        db.tblLeave.Single(c => c.LeaveID == leave.LeaveID));
                    db.SubmitChanges();

                    Fill();
                }
            }
        }
    }
}
