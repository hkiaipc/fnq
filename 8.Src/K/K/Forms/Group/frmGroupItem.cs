using System;
using System.Diagnostics;
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
    public partial class frmGroupItem : NUnit.UiKit.SettingsDialogBase 
    {

        public tblGroup TblGroup
        {
            get { return _tblGroup; }
            set { _tblGroup = value; }
        } private tblGroup _tblGroup;

        public frmGroupItem()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (IsAdd())
            {
                Add();
            }
            else
            {
                Edit();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        void Add()
        {
            tblGroup g = new tblGroup();
            g.GroupName = this.txtGroupName.Text.Trim();

            DB db = DBFactory.GetDB();
            db.tblGroup.InsertOnSubmit(g);
            db.SubmitChanges();
        }

        void Edit()
        {
            DB db = DBFactory.GetDB();
            var g = from q in  db.tblGroup
                         where q.GroupID == this.TblGroup.GroupID
                         select q;

            g.First().GroupName = this.txtGroupName.Text.Trim();

            db.SubmitChanges();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsAdd()
        {
            return this._tblGroup == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroupItem_Load(object sender, EventArgs e)
        {
            Fill();
        }

        private void Fill()
        {
            if (this.TblGroup != null)
            {
                DB db = DBFactory.GetDB();
                var rg = from q in db.tblGroup
                         where q.GroupID == this.TblGroup.GroupID
                         select q;

                this.TblGroup = rg.First();

                this.txtGroupName.Text = this.TblGroup.GroupName;

                this.listView1.Items.Clear();
                foreach (tblPerson person in this.TblGroup.tblPerson.ToList())
                {
                    this.listView1.Items.Add(CreateLVI(person));
                }

            }
        }

        private ListViewItem CreateLVI(tblPerson person)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = person.PersonName ;
            lvi.Tag = person;
            return lvi;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmPersonSelect f = new frmPersonSelect();
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<tblPerson> list = f.SelectedPersons;
                Associate(this.TblGroup, list);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblGroup"></param>
        /// <param name="list"></param>
        private void Associate(tblGroup tblGroup, List<tblPerson> list)
        {
            DB db = DBFactory.GetDB();

            var r = from q in db.tblGroup
                    where q.GroupID == tblGroup.GroupID
                    select q;
            tblGroup tmpGroup = r.First();

            foreach (tblPerson person in list)
            {
                var rp = from q in db.tblPerson
                         where q.PersonID == person.PersonID
                         select q;

                tblPerson tmpPerson = rp.First();
                tmpPerson.tblGroup = tmpGroup;
            }
            db.SubmitChanges();
        }

        private void UnAssociate(List<tblPerson> list)
        {
            DB db = DBFactory.GetDB();
            foreach (var person in list)
            {
                var r = from q in db.tblPerson
                        where q.PersonID == person.PersonID
                        select q;
                tblPerson temp = r.First();
                temp.tblGroup = null;
            }
            db.SubmitChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            List<tblPerson> list = GetSelectedPersonList();
            UnAssociate(list);
        }

        private List<tblPerson> GetSelectedPersonList()
        {
            List<tblPerson> list = new List<tblPerson>();
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Checked)
                {
                    tblPerson person = lvi.Tag as tblPerson;
                    Debug.Assert(person != null);
                    list.Add(person);
                }
            }
            return list;
        }
    }
}
