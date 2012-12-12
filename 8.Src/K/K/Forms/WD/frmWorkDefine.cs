using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.WD
{
    public partial class frmWorkDefine : Form
    {
        public frmWorkDefine()
        {
            InitializeComponent();
        }

        private void frmWorkDefine_Load(object sender, EventArgs e)
        {
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        void Fill()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblWorkDefine
                    select q;

            this.dataGridView1.DataSource = r;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmWorkDefineItem f = new frmWorkDefineItem();
            f.WorkDefine = WorkDefine.Create(CycleTypeEnum.Week);
            f.IsAdd = true;
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            tblWorkDefine wd = GetSelectedWorkDefine();
            if (wd != null)
            {
                frmWorkDefineItem f = new frmWorkDefineItem();
                f.TblWorkDefine = wd;
                f.IsAdd = false;
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Fill();
                }
            }
        }

        private tblWorkDefine GetSelectedWorkDefine()
        {
            if (this.dataGridView1.CurrentRow != null)
            {
                return this.dataGridView1.CurrentRow.DataBoundItem as tblWorkDefine;
            }
            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            tblWorkDefine wd = this.GetSelectedWorkDefine();
            if (wd != null)
            {
                if (NUnit.UiKit.UserMessage.Ask(Strings.SureDelete) == DialogResult.Yes)
                {

                    DB db = DBFactory.GetDB();
                    tblWorkDefine temp = db.tblWorkDefine.Single(
                        c => c.WorkDefineID == wd.WorkDefineID);

                    db.tblWorkDefine.DeleteOnSubmit(temp);

                    db.SubmitChanges();

                    Fill();
                }
            }
        }
    }
}
