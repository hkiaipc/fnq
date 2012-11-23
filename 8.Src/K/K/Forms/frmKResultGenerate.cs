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
    public partial class frmKResultGenerate : Form
    {
        public frmKResultGenerate()
        {
            InitializeComponent();

            this.FillGroup();
        }

        private void frmKResultGenerate_Load(object sender, EventArgs e)
        {

        }

        void FillPerson(int groupID)
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblPerson
                    where q.GroupID == groupID
                    orderby q.PersonName
                    select q;

            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }

        void FillGroup()
        {
            DB db = DBFactory.GetDB();
            List<tblGroup> groupList = db.tblGroup.ToList();

            this.cmbGroup.DisplayMember ="GroupName";
            this.cmbGroup.ValueMember = "GroupID";

            this.cmbGroup.DataSource = groupList;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbGroup.SelectedIndex >= 0)
            {
                int groupID = (int)this.cmbGroup.SelectedValue;
                FillPerson(groupID);
            }
        }

    }
}
