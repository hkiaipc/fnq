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
    public partial class frmPerson : Form
    {
        public frmPerson()
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
            frmPersonItem f = new frmPersonItem();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        private void frmPerson_Load(object sender, EventArgs e)
        {
            Fill();
        }

        void Fill()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblPerson
                    orderby q.PersonName
                    select q;

            this.dataGridView1.DataSource = ConverToDataTable(r.ToList());
        }

        private object ConverToDataTable(List<tblPerson> list)
        {
            DataTable r = CreateDataTable();
            foreach (var item in list)
            {
                object[] values = new object[] {
                    item.PersonName, item.tblTM.TmSN , item.tblGroup.GroupName , item
                };
                r.Rows.Add(values);
            }
            return r;
        }

        private DataTable CreateDataTable()
        {
            DataTable r = new DataTable();
            r.Columns.Add("PersonName", typeof(string));
            r.Columns.Add("TM", typeof(string));
            r.Columns.Add("GroupName", typeof(string));
            r.Columns.Add("tblPerson", typeof(object));
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                return;
            }

            frmPersonItem f = new frmPersonItem();
            f.TblPerson = GetSelectedPerson();
            if (f.ShowDialog () == DialogResult.OK )
            {
                Fill();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblPerson GetSelectedPerson()
        {
            DataRowView v = this.dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            tblPerson p = v["tblPerson"] as tblPerson;
            return p;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                return;
            }

            if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
            {
                tblPerson p = GetSelectedPerson();


                DB db = DBFactory.GetDB();
                var r = from q in db.tblPerson
                        where q.PersonID == p.PersonID
                        select q;

                tblPerson person = r.First();
                db.tblPerson.DeleteOnSubmit(person);

                db.SubmitChanges();

                Fill();
            }
        }
    }
}
