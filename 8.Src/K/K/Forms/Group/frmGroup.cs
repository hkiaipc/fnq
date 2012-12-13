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
        }

        private void frmGroup_Load(object sender, EventArgs e)
        {
            Fill();
        }


        void Fill()
        {
            DB db = DBFactory.GetDB();
            this.dataGridView1.DataSource = db.tblGroup;
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
            frmGroupItem f = new frmGroupItem();
            f.TblGroup = GetSelectedGroup();
            if (f.ShowDialog() == DialogResult.OK)
            {
                Fill();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblGroup GetSelectedGroup()
        {
            int r= this.dataGridView1.SelectedCells[0].RowIndex;
            tblGroup g = this.dataGridView1.Rows[r].DataBoundItem as tblGroup;
            return g;
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            tblGroup gp = GetSelectedGroup();
            if (gp != null)
            {
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
