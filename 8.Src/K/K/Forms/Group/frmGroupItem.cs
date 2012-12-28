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
        /// <summary>
        /// 
        /// </summary>
        private bool _isAdd;
        private int _groupIDForEdit;

        #region TblGroup
        public tblGroup TblGroup
        {
            get
            {
                if (_tblGroup == null)
                {
                    if (IsAdd())
                    {
                        _tblGroup = new tblGroup();
                    }
                    else
                    {
                        _tblGroup = GetDB().tblGroup.Single(c => c.GroupID == _groupIDForEdit);
                    }
                }
                return _tblGroup;
            }
            //set { _tblGroup = value; }
        } private tblGroup _tblGroup;
        #endregion //TblGroup

        #region frmGroupItem
        public frmGroupItem()
        {
            InitializeComponent();

            this._isAdd = true;
        }
        #endregion //frmGroupItem

        #region frmGroupItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupID"></param>
        public frmGroupItem(int groupID)
        {
            InitializeComponent();
            this._groupIDForEdit = groupID;
            this._isAdd = false;
        }
        #endregion //frmGroupItem

        #region GetDB
        private DB GetDB()
        {
            if (_db == null)
            {
                _db = DBFactory.GetDB();
            }
            return _db;
        } private DB _db;
        #endregion //GetDB

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

        #region IsAdd
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        bool IsAdd()
        {
            //return this._tblGroup == null;
            return _isAdd;
        }
        #endregion //IsAdd

        #region Add
        /// <summary>
        /// 
        /// </summary>
        void Add()
        {
            DB db = GetDB();

            tblGroup g = this.TblGroup;
            g.GroupName = this.txtGroupName.Text.Trim();
            g.tblWorkDefine = GetSelectedWorkDefine(db);
            //g.tblPerson.AddRange ( this.selected

            db.tblGroup.InsertOnSubmit(g);
            db.SubmitChanges();

            //Associate(g, GetPersonListFromListView());
        }
        #endregion //Add

        #region Edit
        void Edit()
        {
            DB db = GetDB();
            //var g = from q in db.tblGroup
            //        where q.GroupID == this.TblGroup.GroupID
            //        select q;

            tblGroup group = this.TblGroup;
            group.GroupName = this.txtGroupName.Text.Trim();
            group.tblWorkDefine = GetSelectedWorkDefine(db);

            db.SubmitChanges();
            //Associate(group, GetPersonListFromListView());

        }
        #endregion //Edit

        #region GetSelectedWorkDefine
        tblWorkDefine GetSelectedWorkDefine(DB db)
        {
            return this.cmbWorkDefine.SelectedItem as tblWorkDefine;

            //tblWorkDefine wd = db.tblWorkDefine.First(
            //    c => c.WorkDefineID == Convert.ToInt32(this.cmbWorkDefine.SelectedValue));
            //Debug.Assert(wd != null);
            //return wd;
        }
        #endregion //GetSelectedWorkDefine


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
            DB db = GetDB();
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
            Debug.Assert(this.TblGroup != null);

            if (this.TblGroup != null)
            {
                //DB db = DBFactory.GetDB();
                //var rg = from q in db.tblGroup
                //         where q.GroupID == this.TblGroup.GroupID
                //         select q;

                //this.TblGroup = rg.First();

                this.txtGroupName.Text = this.TblGroup.GroupName;

                FillPersonListView(this.TblGroup.tblPerson.ToList());


                tblWorkDefine wd = this.TblGroup.tblWorkDefine;
                if (wd != null)
                {
                    this.cmbWorkDefine.SelectedValue = wd.WorkDefineID;
                }

                FillStationListView();
            }
        }
        #endregion //Fill

        #region FillPersonListView
        /// <summary>
        /// 
        /// </summary>
        private void FillPersonListView(List<tblPerson> list)
        {
            this.lvPerson.Items.Clear();
            foreach (tblPerson person in list)
            {
                this.lvPerson.Items.Add(CreateLVI(person));
            }
        }
        #endregion //FillPersonListView

        #region FillStationListView
        /// <summary>
        /// 
        /// </summary>
        private void FillStationListView()
        {
            this.lvStation.Items.Clear();

            //
            //
            //var vStations = from q1 in this.TblGroup.tblGroupStation
            //                orderby q1.tblStation.StationName
            //                select q1.tblStation;

            //foreach (tblStation item in vStations.ToList())
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    lvi.Text = item.StationName;
            //    lvi.Tag = item;
            //    this.lvStation.Items.Add(lvi);
            //}



            foreach (var item in this.TblGroup.tblGroupStation.ToList())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.tblStation.StationName;
                lvi.Tag = item;

                this.lvStation.Items.Add(lvi);
            }
        }
        #endregion //FillStationListView

        #region CreateLVI
        private ListViewItem CreateLVI(tblPerson person)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Text = person.PersonName;
            lvi.Tag = person;
            return lvi;
        }
        #endregion //CreateLVI

        #region btnAddPerson_Click
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmPersonSelect f = new frmPersonSelect(this.GetCondidatePersonList());
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<tblPerson> list = f.SelectedPersons;
                //_condidatePersonList = _condidatePersonList.Except(list).ToList();

                this.TblGroup.tblPerson.AddRange(list);
                //this.TblGroup.tblPerson.OrderBy(

                FillPersonListView(this.TblGroup.tblPerson.ToList());
                //AddPersonListToListView(list);

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
                this.lvPerson.Items.Add(lvi);
            }
        }
        #endregion //AddPersonListToListView

        #region ExistInListView
        private bool ExistInListView(tblPerson p)
        {
            foreach (ListViewItem lvi in this.lvPerson.Items)
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

        //#region Associate
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="tblGroup"></param>
        ///// <param name="list"></param>
        //private void Associate(tblGroup tblGroup, List<tblPerson> list)
        //{
        //    Debug.Assert(tblGroup != null);

        //    DB db = GetDB();

        //    var r = from q in db.tblGroup
        //            where q.GroupID == tblGroup.GroupID
        //            select q;
        //    tblGroup tmpGroup = r.First();

        //    foreach (tblPerson person in list)
        //    {
        //        var rp = from q in db.tblPerson
        //                 where q.PersonID == person.PersonID
        //                 select q;

        //        tblPerson tmpPerson = rp.First();
        //        tmpPerson.tblGroup = tmpGroup;
        //    }
        //    db.SubmitChanges();
        //}
        //#endregion //Associate

        #region UnAssociate
        private void UnAssociate(List<tblPerson> list)
        {
            DB db = GetDB();
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
            foreach (var item in list)
            {
                item.tblGroup = null;
                this.TblGroup.tblPerson.Remove(item);

                this.GetCondidatePersonList().Add(item);
            }

            FillPersonListView(this.TblGroup.tblPerson.ToList());
            //UnAssociate(list);

            //foreach (tblPerson person in list)
            //{
            //    foreach (ListViewItem lvi in this.lvPerson.Items)
            //    {
            //        if (lvi.Tag == person)
            //        {
            //            lvi.Remove();
            //        }
            //    }
            //}
        }
        #endregion //btnDeletePerson_Click

        #region GetSelectedPersonList
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<tblPerson> GetSelectedPersonList()
        {
            List<tblPerson> list = new List<tblPerson>();
            foreach (ListViewItem lvi in this.lvPerson.Items)
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
            foreach (ListViewItem lvi in this.lvPerson.Items)
            {
                tblPerson person = lvi.Tag as tblPerson;
                Debug.Assert(person != null);
                list.Add(person);
            }
            return list;

        }
        #endregion //GetPersonListFromListView

        #region btnAddStation_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddStation_Click(object sender, EventArgs e)
        {
            frmStationSelect f = new frmStationSelect(this.GetCondidateStationList());
            if (f.ShowDialog() == DialogResult.OK)
            {
                List<tblStation> selectedStationList = f.SelectedTblStationList;
                foreach (var item in selectedStationList)
                {
                    tblGroupStation gs = new tblGroupStation();
                    gs.tblGroup = this.TblGroup;
                    gs.tblStation = item;
                    //{
                    //    tblGroup = this.TblGroup,
                    //    tblStation = item
                    //};

                    this.TblGroup.tblGroupStation.Add(gs);
                }

                FillStationListView();
            }
        }
        #endregion //btnAddStation_Click

        #region btnDeleteStation_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteStation_Click(object sender, EventArgs e)
        {
            //List<tblStation> list = SelectedTblStaionList;
            //if (list.Count == 0)
            //{
            //    NUnit.UiKit.UserMessage.DisplayFailure("请先选择站点");
            //    return;
            //}

            //DB db = GetDB();
            ////db.tblGroupStation.Select( c=>c.groupid           
            //var v = from q in db.tblGroupStation
            //        where q.GroupID == this.TblGroup.GroupID
            //        && list.Any(c => c.StationID == q.StationID)
            //        select q;

            //db.tblGroupStation.DeleteAllOnSubmit(v);
            ////foreach (var item in v)
            ////{
            ////    db.tblGroupStation.DeleteOnSubmit(item);
            ////}
            //db.SubmitChanges();
            //
            //
            List<tblGroupStation> list = SelectedTblGroupStationList;
            foreach (var item in list)
            {
                this.GetCondidateStationList().Add(item.tblStation);

                item.tblStation = null;
                item.tblGroup = null;
                this.TblGroup.tblGroupStation.Remove(item);
            }

            FillStationListView();
        }
        #endregion //btnDeleteStation_Click

        #region SelectedTblStaionList
        private List<tblStation> SelectedTblStaionList
        {
            get
            {
                List<tblStation> r = new List<tblStation>();
                foreach (ListViewItem item in this.lvStation.Items)
                {
                    if (item.Checked)
                    {
                        r.Add((tblStation)item.Tag);
                    }
                }
                return r;
            }
        }
        #endregion //SelectedTblStaionList

        /// <summary>
        /// 
        /// </summary>
        private List<tblGroupStation> SelectedTblGroupStationList
        {
            get
            {
                List<tblGroupStation> r = new List<tblGroupStation>();
                foreach (ListViewItem item in this.lvStation.Items)
                {
                    if (item.Checked)
                    {
                        r.Add((tblGroupStation)item.Tag);
                    }
                }
                return r;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<tblPerson> GetCondidatePersonList()
        {
            if (_condidatePersonList == null)
            {
                var r = from q in GetDB().tblPerson
                        where q.tblGroup == null
                        orderby q.PersonName 
                        select q;
                _condidatePersonList = r.ToList();
            }
            return _condidatePersonList;
        } private List<tblPerson> _condidatePersonList;


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<tblStation> GetCondidateStationList()
        {
            if (_condidateStationList == null)
            {
                DB db = GetDB();
                var stations = from q in db.tblStation
                               where q.tblDevice.Any(c => c.DeviceType == "xgdevice")
                               orderby q.StationName
                               select q;
                _condidateStationList = stations.ToList();
                // remove 
                //
                foreach ( var item in this.TblGroup.tblGroupStation.ToList () )
                {
                    _condidateStationList.Remove(item.tblStation);
                }
            }
            return _condidateStationList;
        } private List<tblStation> _condidateStationList;

    }
}
