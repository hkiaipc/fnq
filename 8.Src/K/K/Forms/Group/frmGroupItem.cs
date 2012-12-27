using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using KDB;

namespace K.Forms
{
    public partial class frmGroupItem : NUnit.UiKit.SettingsDialogBase 
    {

        #region TblGroup
        public tblGroup TblGroup
        {
            get { return _tblGroup; }
            set { _tblGroup = value; }
        } private tblGroup _tblGroup;
        #endregion //TblGroup

        #region frmGroupItem
        public frmGroupItem()
        {
            InitializeComponent();
        }
        #endregion //frmGroupItem

        #region cancelButton_Click
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion //cancelButton_Click

        #region okButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
            {
                return;
            }

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
        #endregion //okButton_Click

        #region CheckInput
        private bool CheckInput()
        {
            if (this.txtGroupName.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("部门名称不能为空");
                return false;
            }
            if (this.cmbWorkDefine.SelectedItem == null)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("必须选择班次");
                return false;
            }
            return true;
        }
        #endregion //CheckInput

        #region Add
        void Add()
        {
            DB db = DBFactory.GetDB();

            tblGroup g = new tblGroup();
            g.GroupName = this.txtGroupName.Text.Trim();
            g.tblWorkDefine = GetSelectedWorkDefine(db);

            db.tblGroup.InsertOnSubmit(g);
            db.SubmitChanges();

            Associate(g, GetPersonListFromListView());
        }
        #endregion //Add

        #region Edit
        void Edit()
        {
            DB db = DBFactory.GetDB();
            var g = from q in  db.tblGroup
                         where q.GroupID == this.TblGroup.GroupID
                         select q;

            tblGroup group = g.First(); 
            group.GroupName = this.txtGroupName.Text.Trim();
            group.tblWorkDefine = GetSelectedWorkDefine(db);

            db.SubmitChanges();
            Associate(group, GetPersonListFromListView());

        }
        #endregion //Edit

        #region GetSelectedWorkDefine
        tblWorkDefine GetSelectedWorkDefine(DB db)
        {
            tblWorkDefine wd = db.tblWorkDefine.First(
                c => c.WorkDefineID == Convert.ToInt32(this.cmbWorkDefine.SelectedValue));
            Debug.Assert(wd != null);
            return wd;
        }
        #endregion //GetSelectedWorkDefine

        #region IsAdd
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsAdd()
        {
            return this._tblGroup == null;
        }
        #endregion //IsAdd

        #region frmGroupItem_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGroupItem_Load(object sender, EventArgs e)
        {
            BindWorkDefineSource();
            Fill();
            
        }
        #endregion //frmGroupItem_Load

        #region BindWorkDefineSource
        private void BindWorkDefineSource()
        {
            DB db = DBFactory.GetDB();
            var wd = from q in db.tblWorkDefine
                     select q;

            //wd.First().WorkDefineID 
            this.cmbWorkDefine.DisplayMember = "WorkDefineName";
            this.cmbWorkDefine.ValueMember = "WorkDefineID";
            this.cmbWorkDefine.DataSource = wd;

                     
        }
        #endregion //BindWorkDefineSource

        #region Fill
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


                tblWorkDefine wd = this.TblGroup.tblWorkDefine;
                if (wd != null)
                {
                    this.cmbWorkDefine.SelectedValue = wd.WorkDefineID;
                }

                //
                //
                var vStations = from q1 in this.TblGroup.tblGroupStation
                                orderby q1.tblStation.StationName
                                select q1.tblStation;
                //this.lvStation.DataBindings.Add("StationName", vStations, "StationID");
                this.lvStation.Items.Clear();
                foreach (tblStation item in vStations.ToList())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.Text = item.StationName;
                    lvi.Tag = item;
                    this.listView1.Items.Add(lvi);
                }
            }
        }
        #endregion //Fill

        #region CreateLVI
        private ListViewItem CreateLVI(tblPerson person)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = person.PersonName ;
            lvi.Tag = person;
            return lvi;
        }
        #endregion //CreateLVI

        #region btnAddPerson_Click
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmPersonSelect f = new frmPersonSelect();
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<tblPerson> list = f.SelectedPersons;
                AddPersonListToListView(list);

                //Associate(this.TblGroup, list);
            }
        }
        #endregion //btnAddPerson_Click

        #region AddPersonListToListView
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persons"></param>
        private void AddPersonListToListView(List<tblPerson> persons)
        {
            foreach (tblPerson p in persons)
            {
                if (ExistInListView(p))
                {
                    continue;
                }

                ListViewItem lvi = CreateLVI(p);
                this.listView1.Items.Add(lvi);
            }
        }
        #endregion //AddPersonListToListView

        #region ExistInListView
        private bool ExistInListView(tblPerson  p)
        {
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                tblPerson person = lvi.Tag as tblPerson;
                if (person.PersonID == p.PersonID)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion //ExistInListView

        #region Associate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblGroup"></param>
        /// <param name="list"></param>
        private void Associate(tblGroup tblGroup, List<tblPerson> list)
        {
            Debug.Assert(tblGroup != null);

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
        #endregion //Associate

        #region UnAssociate
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
        #endregion //UnAssociate

        #region btnDeletePerson_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeletePerson_Click(object sender, EventArgs e)
        {
            List<tblPerson> list = GetSelectedPersonList();
            UnAssociate(list);

            foreach (tblPerson person in list)
            {
                foreach (ListViewItem lvi in this.listView1.Items)
                {
                    if (lvi.Tag == person)
                    {
                        lvi.Remove();
                    }
                }
            }
        }
        #endregion //btnDeletePerson_Click

        #region GetSelectedPersonList
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
        #endregion //GetSelectedPersonList

        #region GetPersonListFromListView
        private List<tblPerson> GetPersonListFromListView()
        {
            List<tblPerson> list = new List<tblPerson>();
            foreach (ListViewItem lvi in this.listView1.Items)
            {
                tblPerson person = lvi.Tag as tblPerson;
                Debug.Assert(person != null);
                list.Add(person);
            }
            return list;

        }
        #endregion //GetPersonListFromListView

        private void btnAddStation_Click(object sender, EventArgs e)
        {
            frmStationSelect f = new frmStationSelect();
            if (f.ShowDialog() == DialogResult.OK)
            {
// TODO:
                //
            }
        }
    }
}
