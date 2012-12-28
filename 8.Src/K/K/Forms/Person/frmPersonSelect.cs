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
        private List<tblPerson> _personList;

        public frmPersonSelect(List<tblPerson> personList)
        {
            Debug.Assert(personList != null);
            InitializeComponent();

            _personList = personList;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                if (lvi.Checked)
                {
                    //Debug.Assert(lvi.Tag as tblPerson != null);
                    tblPerson p = lvi.Tag as tblPerson;
                    this.SelectedPersons.Add(p);

                    this._personList.Remove(p);
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
            //DB d = this._db;
            //var r = from q in d.tblPerson
            //        //where q.GroupID == null 
            //        where q.tblGroup == null
            //        orderby q.PersonName 
            //        select q;

            //Console.WriteLine("get person count: " + r.ToList ().Count );
            //Console.WriteLine(r.ToList());

            this.listView1.Items.Clear();
            foreach (tblPerson p in _personList )
            {
                //Console.WriteLine(p.PersonName + " : " + (p.tblGroup == null ? "null" : p.tblGroup.GroupName));
                //if (p.tblGroup == null)
                //{
                this.listView1.Items.Add(CreateLVI(p));
                //}
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
