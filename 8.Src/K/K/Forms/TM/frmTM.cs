using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.TM
{
    public partial class frmTM : Form
    {
        public frmTM()
        {
            InitializeComponent();
        }

        private void frmTM_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        void Fill()
        {
            DB db = DBFactory.GetDB();

            var r = from q in db.tblTM
                    select q;

            this.dataGridView1.DataSource = r;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTMItem f = new frmTMItem();
            if(f.ShowDialog () == DialogResult .OK )
            {
                Fill ();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmTMItem f = new frmTMItem();
            f.TblTM = GetSelectedTM();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblTM GetSelectedTM()
        {
            tblTM tm = this.dataGridView1.CurrentRow.DataBoundItem as tblTM;
            return tm;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.CurrentRow == null)
            {
                return;
            }

            if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
            {
                tblTM tm = GetSelectedTM();
                DB db = DBFactory.GetDB();
                var r = from q in db.tblTM 
                        where q.TmID == tm.TmID 
                        select q ;

                tblTM tm2 = r.First();
                db.tblTM.DeleteOnSubmit(tm2);

                db.SubmitChanges();


                Fill();

            }
        }
    }
}
