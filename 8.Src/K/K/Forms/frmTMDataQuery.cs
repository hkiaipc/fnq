using System;
using KDB;
using Xdgk.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms
{
    public partial class frmTMDataQuery : Form
    {

        #region QueryStyleEnum
        private enum QueryStyleEnum
        {
            ByStation,
            ByPerson,
        }
        #endregion //QueryStyleEnum

        #region frmTMDataQuery
        public frmTMDataQuery(string personName, DateTime b, DateTime e)
            : this()
        {
            this.cmbQueryStyle.SelectedIndex = 1;
            this.SelectedGroupID = GetGroupIDByPersonName(personName);
            this.cmbPerson.Text = personName;
            this.dtpBegin.Value = b;
            this.dtpEnd.Value = e;

            Query();
        }
        #endregion //frmTMDataQuery

        #region frmTMDataQuery
        public frmTMDataQuery()
        {
            InitializeComponent();
            this.Begin = DateTime.Now.Date.AddDays(-1d);
            this.End = DateTime.Now.Date;
            BindGroup();
            BindQueryStyle();
            BindStation();
            //BindPerson();
        }
        #endregion //frmTMDataQuery

        #region frmTMDataQuery_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTMDataQuery_Load(object sender, EventArgs e)
        {
            this.panPerson.Location = this.panStation.Location;
        }
        #endregion //frmTMDataQuery_Load

        #region BindGroup
        /// <summary>
        /// 
        /// </summary>
        private void BindGroup()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblGroup
                    orderby q.GroupName
                    select q;

            this.cmbGroup.DisplayMember = "GroupName";
            this.cmbGroup.ValueMember = "GroupID";
            this.cmbGroup.DataSource = r;
        }
        #endregion //BindGroup

        #region BindPerson
        private void BindPerson(int groupID)
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblPerson
                    where q.tblGroup.GroupID == groupID
                    orderby q.PersonName
                    select q;

            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }
        #endregion //BindPerson

        #region BindStation
        private void BindStation()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblStation
                    where q.tblDevice.Any(c => c.DeviceType == "xgdevice")
                    orderby q.StationName
                    select q;

            this.cmbStation.DisplayMember = "StationName";
            this.cmbStation.ValueMember = "StationID";
            this.cmbStation.DataSource = r;
        }
        #endregion //BindStation

        #region BindQueryStyle
        private void BindQueryStyle()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("按站点", QueryStyleEnum.ByStation));
            kvs.Add(new KeyValue("按人员", QueryStyleEnum.ByPerson));

            this.cmbQueryStyle.DisplayMember = "Key";
            this.cmbQueryStyle.ValueMember = "Value";
            this.cmbQueryStyle.DataSource = kvs;
        }
        #endregion //BindQueryStyle

        #region cmbQueryStyle_SelectedIndexChanged
        private void cmbQueryStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryStyleEnum style = this.SelectedQueryStyleEnum;
            this.panPerson.Visible = style == QueryStyleEnum.ByPerson;
            this.panStation.Visible = style == QueryStyleEnum.ByStation;
        }
        #endregion //cmbQueryStyle_SelectedIndexChanged

        #region SelectedQueryStyleEnum
        /// <summary>
        /// 
        /// </summary>
        private QueryStyleEnum SelectedQueryStyleEnum
        {
            get
            {
                return (QueryStyleEnum)this.cmbQueryStyle.SelectedValue;
            }
            set
            {
                this.cmbQueryStyle.SelectedValue = value;
            }
        }
        #endregion //SelectedQueryStyleEnum

        #region Begin
        public DateTime Begin
        {
            get { return this.dtpBegin.Value; }
            set { this.dtpBegin.Value = value; }
        }
        #endregion //Begin

        #region End
        public DateTime End
        {
            get { return this.dtpEnd.Value; }
            set { this.dtpEnd.Value = value; }
        }
        #endregion //End

        #region SelectedPersonID
        public int SelectedPersonID
        {
            get
            {
                if (this.cmbPerson.Items.Count == 0)
                {
                    return -1;
                }
                return (int)this.cmbPerson.SelectedValue;
            }
            set
            {
                try
                {
                    this.cmbPerson.SelectedValue = value;
                }
                catch
                {
                }
            }
        }
        #endregion //SelectedPersonID

        #region SelectedGroupID
        public int SelectedGroupID
        {
            get
            {
                if (this.cmbGroup.Items.Count == 0)
                {
                    return -1;
                }
                return (int)this.cmbGroup.SelectedValue;
            }
            set
            {
                this.cmbGroup.SelectedValue = value;
            }

        }
        #endregion //SelectedGroupID

        #region GetGroupIDByPersonName
        private int GetGroupIDByPersonName(string personName)
        {
            DB db = DBFactory.GetDB();
            tblPerson p = db.tblPerson.First(c => c.PersonName == personName);
            return p.tblGroup.GroupID;

        }
        #endregion //GetGroupIDByPersonName

        #region SelectedStationID
        public int SelectedStationID
        {
            get
            {
                if (this.cmbStation.Items.Count == 0)
                {
                    return -1;
                }
                return (int)this.cmbStation.SelectedValue;
            }
            set
            {
                try
                {
                    this.cmbStation.SelectedValue = value;
                }
                catch { }

            }
        }
        #endregion //SelectedStationID

        #region Query
        private void Query()
        {
            DB db = DBFactory.GetDB();
            object ds = null;
            if (this.SelectedQueryStyleEnum == QueryStyleEnum.ByStation)
            {
                var r = from q in db.tblTmData
                        where q.TmDataDT >= this.Begin && q.TmDataDT < this.End
                            && q.tblDevice.tblStation.StationID == this.SelectedStationID
                        select q;
                DataTable t = ConvertToDataTable(r.ToList());
                ds = t;
            }
            if (this.SelectedQueryStyleEnum == QueryStyleEnum.ByPerson)
            {

                int tmID = GetSelectedPersonTMID(db);

                var r = from q in db.tblTmData
                        where q.TmDataDT >= this.Begin && q.TmDataDT < this.End
                            && q.tblTM.TmID == tmID
                        select q;
                //select new { datetetttt = q.TmDataDT,
                //snnn= q.tblTM.TmSN };
                DataTable t = ConvertToDataTable(r.ToList());
                ds = t;
            }

            this.dataGridView1.DataSource = ds;
        }
        #endregion //Query

        #region ConvertToDataTable
        private DataTable ConvertToDataTable(IList<tblTmData> list)
        {
            DataTable tbl = new DataTable();

            tbl.Columns.Add("StationName", typeof(string));
            tbl.Columns.Add("PersonName", typeof(string));
            tbl.Columns.Add("TMSN", typeof(string));
            tbl.Columns.Add("DT", typeof(DateTime));

            foreach (tblTmData item in list)
            {
                DataRow row = tbl.NewRow();
                tbl.Rows.Add(
                    item.tblDevice.tblStation.StationName,
                    item.tblTM.tblPerson.Count > 0 ? item.tblTM.tblPerson.First().PersonName : string.Empty,
                    item.tblTM.TmSN,
                    item.TmDataDT);
            }

            return tbl;
        }
        #endregion //ConvertToDataTable

        #region GetSelectedPersonTMID
        private int GetSelectedPersonTMID(DB db)
        {
            var r = from q in db.tblPerson
                    where q.PersonID == SelectedPersonID
                    select q.TmID;

            if (r.Count() > 0 && r.First() != null)
            {
                return (int)r.First();
            }
            else
            {
                return -1;
            }

        }
        #endregion //GetSelectedPersonTMID

        #region btnQuery_Click
        private void btnQuery_Click(object sender, EventArgs e)
        {
            this.Query();
        }
        #endregion //btnQuery_Click

        #region cmbGroup_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedGroupID = this.SelectedGroupID;
            if (selectedGroupID == -1)
            {
                return;
            }
            else
            {
                BindPerson(selectedGroupID);
            }
        }
        #endregion //cmbGroup_SelectedIndexChanged
    }
}
