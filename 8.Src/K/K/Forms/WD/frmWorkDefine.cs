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
            f.WorkDefine = new WorkDefine();
            f.IsAdd = true; 
            f.ShowDialog();
        }
    }
}
