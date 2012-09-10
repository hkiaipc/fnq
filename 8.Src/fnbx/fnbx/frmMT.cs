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

            if ( this.AdeStatus == ADEState.Edit )
            {
                BxdbDataContext dc = Class1.GetBxdbDataContext();
                ucMt1.UpdateMaintain();
                dc.SubmitChanges();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
