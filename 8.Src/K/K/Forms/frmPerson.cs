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

        private void btnAdd_Click(object sender, EventArgs e)
        {

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
    }
}
