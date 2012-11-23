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
    public partial class frmTMSelect : NUnit.UiKit.SettingsDialogBase 
    {
        public frmTMSelect()
        {
            InitializeComponent();
            Fill();
        }

        private void frmTMSelect_Load(object sender, EventArgs e)
        {

        }

        void Fill()
        {
            this.listView1.Items.Clear();
            DB db = DBFactory.GetDB();
            var r = from q in db.tblTM
                    where q.tblPerson .Count == 0
                    orderby q.TmSN
                    select q;

            foreach (tblTM tm in r)
            {
                ListViewItem lvi = Create(tm);
                this.listView1.Items.Add(lvi);
            }
        }

        
        private ListViewItem Create(tblTM tm)
        {
            ListViewItem l = new ListViewItem(tm.TmSN);
            l.Tag = tm;
            return l;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public tblTM SelectedTM
        {
            get
            {
                if (this.listView1.SelectedItems.Count > 0)
                {
                    ListViewItem lvi = this.listView1.SelectedItems[0];
                    return lvi.Tag as tblTM;
                }
                return null;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
