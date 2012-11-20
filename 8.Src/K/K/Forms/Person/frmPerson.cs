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

            this.dataGridView1.DataSource = r;
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
            tblPerson p = this.dataGridView1.CurrentRow.DataBoundItem as tblPerson;
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
