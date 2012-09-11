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
            this.lblStatus.Text = _maintain.mt_status.ToString();
            this.ucMt1.Maintain = _maintain;
            this.txtTMStatus.Text = _maintain.mt_status.ToString();
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
                dc.SubmitChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
                if (f.ShowDialog() == DialogResult.OK)
                {
                    // TODO: refresh tm status 
                    //
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
            return right.CanModifyTMStatus(MTStatus.Closed);
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
    }
}
