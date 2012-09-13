using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;
using BXDB;

namespace fnbx
{
    public partial class frmMT : NUnit.UiKit.SettingsDialogBase
    {

        public Xdgk.Common.ADEState AdeStatus
        {
            get { return _adeStatus; }
            set { _adeStatus = value; }
        } private Xdgk.Common.ADEState _adeStatus;

        public tblMaintain Maintain
        {
            get { return _maintain; }
            set
            {
                Debug.Assert(value != null);
                _maintain = value;

                RefreshMaintain();
            }
        }private tblMaintain _maintain;

        /// <summary>
        /// 
        /// </summary>
        private void RefreshMaintain()
        {
            //this.lblStatus.Text = _maintain.mt_status.ToString();
            this.ucMt1.Maintain = _maintain;
            this.txtTMStatus.Text = _maintain.GetMtStatusText();

            // TODO:
            //this.ucRp1.Reply = _maintain.tblReply;
        }

        /// <summary>
        /// 
        /// </summary>
        public frmMT()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetModifyStatusButtonStyle()
        {
            Right rt = App.Default.GetLoginOperatorRight();
            bool b = rt.CanModifyTMStatus(this._maintain.GetMtStatus());
            this.btnModifyStatus.Enabled = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMT_Load(object sender, EventArgs e)
        {
            //this.ucMt1.Enabled = false;

            // set enable status
            //
            Right rt = App.Default.GetLoginOperatorRight();
            if (rt.CanActivateForTm(ADEState.Edit, this.Maintain.GetMtStatus()))
            {
                this.ucMt1.Enabled = true;
            }
            else
            {
                this.ucMt1.Enabled = false;
            }

            if (rt.CanActivateForRp(ADEState.Edit, this.Maintain.GetMtStatus()))
            {
                this.ucRp1.Enabled = true;
            }
            else
            {
                this.ucRp1.Enabled = false;
            }

            //
            //
            this.SetReplyVisibleStyle();

            //
            //
            this.SetModifyStatusButtonStyle();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {

            if (CheckInput())
            {
                if (this.AdeStatus == ADEState.Add)
                {
                    BxdbDataContext dc = Class1.GetBxdbDataContext();
                    ucMt1.UpdateMaintain();
                    _maintain.mt_create_dt = DateTime.Now;

                    dc.tblMaintain.InsertOnSubmit(_maintain);
                    dc.SubmitChanges();

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                }

                if (this.AdeStatus == ADEState.Edit)
                {
                    BxdbDataContext dc = Class1.GetBxdbDataContext();
                    ucMt1.UpdateMaintain();
                    ucRp1.UpdateReply();
                    dc.SubmitChanges();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            bool r = true;
            MTStatus status = this._maintain.GetMtStatus();
            if (status == MTStatus.Received || status == MTStatus.Completed)
            {
                if (!ucRp1.CheckInput())
                {
                    r = false;
                }
            }
            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyStatus_Click(object sender, EventArgs e)
        {
            if (CanModify())
            {
                frmTMStatusModify f = new frmTMStatusModify();
                f.Current = _maintain.GetMtStatus();

                if (f.ShowDialog() == DialogResult.OK)
                {
                    // TODO: refresh tm status 
                    //
                    //_maintain.mt_status =(int) f.NewMtStatus;
                    this.Maintain.SetMTStatus(f.NewMtStatus);

                    this.txtTMStatus.Text = MTStatusHelper.GetMtStatusText(f.NewMtStatus);

                    Class1.GetBxdbDataContext().SubmitChanges();

                    this.SetModifyStatusButtonStyle();
                    SetReplyVisibleStyle();
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotModifyMTStatus);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetReplyVisibleStyle()
        {
            if (this.Maintain.GetMtStatus() == MTStatus.Created)
            {
                this.tabControl1.TabPages.Remove(this.tpRP);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(this.tpRP))
                {
                    this.tabControl1.TabPages.Add(this.tpRP);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CanModify()
        {
            Right right = App.Default.GetLoginOperatorRight();
            //right.
            return right.CanModifyTMStatus(_maintain.GetMtStatus());
        }

        public bool IsViewMode
        {
            get { return _isViewMode; }
            set
            {
                _isViewMode = value;
                //this.Enabled = !_isViewMode;

            }
        } private bool _isViewMode;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            MTStatus status = this.Maintain.GetMtStatus();
            if (status == MTStatus.Created ||
                status == MTStatus.Received)
            {
                TimeSpan ts = (DateTime)this.Maintain.mt_timeout_dt - DateTime.Now;
                string tsString = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                string s = string.Format(Strings.RemainTimespan, tsString); 
                this.tssTimeout.Text = s;
            }
            else if (status == MTStatus.Timeouted)
            {
                this.tssTimeout.Text = Strings.Timeouted;
            }
            else
            {
                this.tssTimeout.Text = string.Empty;
            }
        }
    }
}
