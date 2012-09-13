﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;

namespace fnbx
{
    public partial class UCRp : UserControl, IReadonly, IView
    {
        public UCRp()
        {
            InitializeComponent();


            //this.dtpReceived.Value = DateTime.Now;
            this.dtpEnd.Value = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        public tblReply Reply
        {
            get { return _reply; }
            set
            {
                _reply = value;
                if (_reply != null)
                {
                    FillReply();
                    //SetControlEnableStatus();
                }
            }
        } private tblReply _reply;

        /// <summary>
        /// 
        /// </summary>
        private void FillReply()
        {
            // TODO:
            //this.dtpReceived.Value = (DateTime)this.Reply.rp_receive_dt;
            if (this.Reply.rp_end_dt != null)
            {
                this.dtpEnd.Value = (DateTime)this.Reply.rp_end_dt;
            }

            this.txtWorker.Text = this.Reply.rp_worker;
            this.txtOperatorName.Text = this.Reply.tblOperator.op_name;
            this.txtRpContent.Text = this.Reply.rp_content;

            this.Readonly = IsReadonly(
                App.Default.GetLoginOperatorRight(),
                this.Reply.tblFlow[0].GetMtStatus());
        }

        //public void SetControlEnableStatus()
        //{
        //    //
        //    //FLStatus status = this.Reply.tblMaintain[0].GetMtStatus();
        //    //bool b = status == FLStatus.Received || status == FLStatus.Completed;
        //    bool b = true;

        //    //this.dtpReceived.Enabled = false;
        //    this.dtpEnd.Enabled = b;
        //    this.txtWorker.ReadOnly = !b;
        //    this.txtRpContent.ReadOnly = !b;

        //}


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool CheckInput()
        {
            bool r = true;
            //if (this.dtpEnd.Value <= this.ucRc1.Receive.rc_dt)
            //{
            //    NUnit.UiKit.UserMessage.DisplayFailure(Strings.RPEndDTMustGreaterReceivedDT);
            //    r = false;
            //}
            // TODO:
            //else if (this.dtpEnd.Value >= this.Reply.tblMaintain[0].mt_timeout_dt)
            //{
            //    NUnit.UiKit.UserMessage.DisplayFailure(Strings.RPEndDTMustLessTimeoutDT);
            //    r = false;
            //}
            if (this.txtWorker.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.RPWorkerEmpty);
                r = false;
            }
            else if (this.txtRpContent.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.RPContentEmpty);
                r = false;
            }

            return r;
        }

        private void UCRp_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        internal void UpdateReply()
        {
            UpdateModel();
        }

        #region IView 成员

        public void UpdateModel()
        {
            if (this.Reply != null)
            {
                this.Reply.rp_end_dt = dtpEnd.Value;
                this.Reply.rp_worker = txtWorker.Text;
                this.Reply.rp_content = txtRpContent.Text;
            }
        }

        #endregion

        #region IReadonly 成员

        public bool Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                if (_readonly != value)
                {
                    _readonly = value;
                    this.dtpEnd.Readonly = _readonly;
                    ReadonlyHelper.SetReadonlyStyle(
                        new Control[]{ this.txtWorker, this.txtRpContent},
                        _readonly);
                }
            }
        } private bool _readonly;

        #endregion

        #region IView 成员


        public bool IsReadonly(Right rt, FLStatus status)
        {
            return !(rt.Value == fnbx.Right.ReceiverValue &&
                (status == FLStatus.Received || status == FLStatus.Completed));
        }

        #endregion
    }
}
