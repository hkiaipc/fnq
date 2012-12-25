using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D
{
    public partial class frmMain : Form
    {
        private DB _db;
        public frmMain()
        {
            InitializeComponent();

            _db = DBFactory.GetDB();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.dtpQuery.Value = DateTime.Now.Date ;
            FillGroup(_db);
            FillStation(_db);
        }

        private void FillStation(DB db)
        {
            var r = from q in db.tblDevice
                    where q.DeviceType == "xgdevice"
                    orderby q.tblStation.StationName
                    select new { q.tblStation.StationName, q.DeviceID };

            this.cmbStation.DisplayMember = "StationName";
            this.cmbStation.ValueMember = "DeviceID";
            this.cmbStation.DataSource = r;
        }

        private void FillGroup(DB db)
        {
            // fill group
            //
            var r = from q in db.tblGroup
                    select q;

            this.cmbGroup.DisplayMember = "GroupName";
            this.cmbGroup.ValueMember = "GroupID";
            this.cmbGroup.DataSource = r;
        }

        private void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbGroup.SelectedIndex >= 0)
            {
                int groupID = (int)this.cmbGroup.SelectedValue;
                FillPerson(_db, groupID);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_db"></param>
        /// <param name="groupID"></param>
        private void FillPerson(DB db, int groupID)
        {
            var r = from q in db.tblPerson
                    where q.GroupID == groupID
                    orderby q.PersonName
                    select q;

            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            if ( this.cmbPerson.SelectedIndex < 0 )
            {
                return;
            }

            DB db = DBFactory.GetDB ();
            int personID = (int)this.cmbPerson.SelectedValue;
            int tmid = GetTMID(db, personID);
            if (tmid <= 0)
            {
                return;
            }

            var r = from q in db.tblTmData
                    where q.tblTM.TmID == tmid && q.TmDataDT >= MonthFirst() && q.TmDataDT < MonthLast()
                    orderby q.TmDataDT
                    select new { 时间=q.TmDataDT, 站=q.tblDevice.tblStation.StationName, 人=q.tblTM.tblPerson[0].PersonName };

            this.dataGridView1.DataSource = r;
        }


        private DateTime MonthFirst()
        {
             DateTime dt = this.dtpQuery.Value;
             return new DateTime(dt.Year, dt.Month, 1);
        }

        private DateTime MonthLast()
        {
            DateTime dt = this.dtpQuery.Value;
            int days = DateTime.DaysInMonth(dt.Year, dt.Month);
            return dt.Date + TimeSpan.FromDays(days);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        private int GetTMID(DB db, int personID)
        {
            var r = from q in db.tblPerson
                    where q.PersonID == personID
                    select q;

            tblPerson p = r.First();
            if (p.tblTM != null)
            {
                return p.tblTM.TmID;
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.cmbStation.SelectedIndex < 0)
            {
                return;
            }
            if (this.cmbPerson.SelectedIndex < 0)
            {
                return;
            }

            string text = string.Format("添加 {0}, {1}, {2} ?", cmbPerson.Text, cmbStation.Text, this.dtpInsertDT.Value);
            if (MessageBox.Show(text, "cap", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            DB db = DBFactory.GetDB();

            tblTmData tmdata = new tblTmData();
            tmdata.tblDevice = db.tblDevice.Single(c => c.DeviceID == GetSelectedDeviceID());
            int tmid = GetSelectedTmID(db);
            tmdata.tblTM = db.tblTM.Single(c => c.TmID == tmid);
            tmdata.TmDataDT = this.dtpInsertDT.Value;

            db.tblTmData.InsertOnSubmit(tmdata);
            db.SubmitChanges();

            MessageBox.Show("添加成功");
        }

        private int GetSelectedTmID(DB db)
        {
            int personID = (int)this.cmbPerson.SelectedValue;
            return GetTMID(db, personID);
        }

        private int GetSelectedDeviceID()
        {
            return (int)this.cmbStation.SelectedValue;
        }
    }
}
