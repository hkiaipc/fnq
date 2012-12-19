using System;
using Xdgk.Common;
using System.Diagnostics;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.Leave
{
    public partial class frmLeaveItem : NUnit.UiKit.SettingsDialogBase 
    {
        public frmLeaveItem()
        {
            InitializeComponent();

            this.dtpBegin.Value = DateTime.Now.Date;
            this.dtpEnd.Value = DateTime.Now.Date + TimeSpan.FromDays(1d);

            this.cmbGroup.SelectedIndexChanged += new EventHandler(cmbGroup_SelectedIndexChanged);
            BindDataSources();
            this._isAdd = true;
        }

        void cmbGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            DB db = DBFactory.GetDB ();
            var r = db.tblPerson.Where(c => c.tblGroup.GroupID == SelectedGroupID);
            this.cmbPerson.DisplayMember = "PersonName";
            this.cmbPerson.ValueMember = "PersonID";
            this.cmbPerson.DataSource = r;
        }

        private void BindDataSources()
        {
            DB db = DBFactory.GetDB();

            this.cmbGroup.DisplayMember = "GroupName";
            this.cmbGroup.ValueMember = "GroupID";
            this.cmbGroup.DataSource = db.tblGroup;

            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("事假", LeaveEnum.Private));
            kvs.Add(new KeyValue("病假", LeaveEnum.Sick));

            this.cmbType.DisplayMember = "Key";
            this.cmbType.ValueMember = "Value";
            this.cmbType.DataSource = kvs;
        }

        public frmLeaveItem(tblLeave leave)
            : this()
        {
            Debug.Assert(leave != null);

            this._tblLeave = leave ;
            this.SelectedGroupID = leave.tblPerson.tblGroup.GroupID;
            this.SelectedPersonID = leave.tblPerson.PersonID;
            this.SelectedLeaveEnum = (LeaveEnum)leave.LeaveType;
            this.dtpBegin.Value = leave.LeaveBegin;
            this.dtpEnd.Value = leave.LeaveEnd;
            this.txtRemark.Text = leave.LeaveRemark;
            this._isAdd = false;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!VerifyInput())
            {
                return;
            }

            if (IsAdd)
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

        private void Edit()
        {
            DB db = DBFactory.GetDB();

            tblLeave l = db.tblLeave.Single(c => c.LeaveID == _tblLeave.LeaveID);

            l.tblPerson = db.tblPerson.Single(c => c.PersonID == SelectedPersonID);
            l.LeaveType = (int)SelectedLeaveEnum;
            l.LeaveBegin = this.dtpBegin.Value;
            l.LeaveEnd = this.dtpEnd.Value;
            l.LeaveRemark = this.txtRemark.Text.Trim();

            db.SubmitChanges();
        }

        private void Add()
        {
            DB db = DBFactory.GetDB();
            tblLeave l = new tblLeave();

            l.tblPerson = db.tblPerson.Single(c => c.PersonID == SelectedPersonID);
            l.LeaveType = (int)SelectedLeaveEnum;
            l.LeaveBegin = this.dtpBegin.Value;
            l.LeaveEnd = this.dtpEnd.Value;
            l.LeaveRemark = this.txtRemark.Text.Trim();

            db.tblLeave.InsertOnSubmit(l);

            db.SubmitChanges();
        }

        private bool IsAdd
        {
            get { return _isAdd; }
            set { _isAdd = true; }
        } private bool _isAdd = false;

        private tblLeave _tblLeave;


        /// <summary>
        /// 
        /// </summary>
        private bool VerifyInput()
        {
            if (cmbGroup.SelectedIndex < 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("部门不能为空");
                return false;
            }

            if (this.cmbPerson.SelectedIndex < 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("人员不能为空");
                return false;
            }

            if (this.dtpBegin.Value >= this.dtpEnd.Value)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("结束时间必须大于起始时间");
                return false;
            }

            return true;
        }


        private tblGroup SelectedGroup
        {
            get { return this.cmbGroup.SelectedValue as tblGroup; }
            set { this.cmbGroup.SelectedValue = value; }
        }

        private int SelectedGroupID
        {
            get { return (int)this.cmbGroup.SelectedValue; }
            set { this.cmbGroup.SelectedValue = value; }
        }


        private int SelectedPersonID
        {
            get { return (int)this.cmbPerson.SelectedValue ; }
            set { this.cmbPerson.SelectedValue = value; }
        }

        private LeaveEnum SelectedLeaveEnum
        {
            get { return (LeaveEnum)this.cmbType.SelectedValue; }
            set { this.cmbType.SelectedValue = value; }
        }
    }
}
