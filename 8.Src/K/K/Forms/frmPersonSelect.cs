using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDB;

namespace K.Forms
{
    public partial class frmPersonSelect : NUnit.UiKit.SettingsDialogBase
    {
        public frmPersonSelect()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Checked)
                {
                    Debug.Assert(lvi.Tag as tblPerson != null);
                    this.SelectedPersons.Add(lvi.Tag as tblPerson);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public List<tblPerson> SelectedPersons
        {
            get {
                if (_selectedPersons == null)
                {
                    _selectedPersons = new List<tblPerson>();
                }
                return _selectedPersons;
            }
        } private List<tblPerson> _selectedPersons;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPersonSelect_Load(object sender, EventArgs e)
        {
            DB d = DBFactory.GetDB();
            var r = from q in d.tblPerson
                    where q.GroupID == null 
                    orderby q.PersonName 
                    select q;

            foreach (tblPerson p in r.ToList())
            {
                this.listView1.Items.Add(CreateLVI(p));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private ListViewItem CreateLVI(tblPerson p)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = p.PersonName;
            lvi.Tag = p;
            return lvi;
        }
    }
}
