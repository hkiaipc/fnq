using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmGroup : Form
    {
        public frmGroup()
        {
            InitializeComponent();

            this.dataGridView1.AutoGenerateColumns = false;
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            Fill();
        }


        void Fill()
        {
            DB db = DBFactory.GetDB();
            this.dataGridView1.DataSource = ConvertToGroupDataTable(db.tblGroup.ToList());
        }

        private DataTable ConvertToGroupDataTable(List<tblGroup> groups)
        {
            DataTable r = CreateDataTable();
            foreach (tblGroup item in groups)
            {
                object[] values = new object[] { item.GroupName, item.tblWorkDefine.WorkDefineName, item };
                r.Rows.Add(values);
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataTable CreateDataTable()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add("GroupName", typeof(string));
            tbl.Columns.Add("WorkDefineName", typeof(string));
            tbl.Columns.Add("tblGroup", typeof(object));
            return tbl;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmGroupItem f = new frmGroupItem();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (IsSelectedRow())
            {
                int groupID = GetSelectedGroup().GroupID;
                frmGroupItem f = new frmGroupItem(groupID );
                //f.TblGroup = GetSelectedGroup();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private bool IsSelectedRow()
        {
            if (this.dataGridView1.SelectedCells.Count > 0)
            {
                return this.dataGridView1.SelectedCells[0].RowIndex >= 0;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblGroup GetSelectedGroup()
        {
            int r = this.dataGridView1.SelectedCells[0].RowIndex;
            //tblGroup g = this.dataGridView1.Rows[r].DataBoundItem as tblGroup;
            //return g;
            DataRowView view = this.dataGridView1.Rows[r].DataBoundItem as DataRowView;
            DataRow row = view.Row;
            return row["tblGroup"] as tblGroup;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (IsSelectedRow())
            {
                tblGroup gp = GetSelectedGroup();
                if (gp != null)
                {
                    if (gp.tblPerson.Count > 0)
                    {
                        NUnit.UiKit.UserMessage.DisplayFailure("该部门包含人员, 不能删除");
                        return;
                    }
                    if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
                    {
                        DB db = DBFactory.GetDB();
                        tblGroup target = db.tblGroup.Single(c => c.GroupID == gp.GroupID);

                        db.tblGroup.DeleteOnSubmit(target);
                        db.SubmitChanges();

                        Fill();
                    }
                }
            }
        }
    }
}
