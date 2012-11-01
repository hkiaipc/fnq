using System;
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
    public partial class UCCondition : UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler QuertyEvent;

        #region UCCondition
        /// <summary>
        /// 
        /// </summary>
        public UCCondition()
        {
            InitializeComponent();
        }
        #endregion //UCCondition

        #region btnOK_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.QuertyEvent != null)
            {
                this.QuertyEvent(this, EventArgs.Empty);
            }
        }
        #endregion //btnOK_Click
       
        #region UCCondition_Load 
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCCondition_Load(object sender, EventArgs e)
        {
            SetDtpStyles();
            BindStatus();
            BindItName();


            this.dtpBegin.Value = DateTime.Now.Date - TimeSpan.FromDays(1);
            this.dtpEnd.Value = DateTime.Now.Date + TimeSpan.FromDays(1);

            this.chkIT.Checked = false;
            this.cmbIt.Enabled = false;

            this.chkStatus.Checked = false;
            this.cmbStatus.Enabled = false;
        }
        #endregion //UCCondition_Load

        #region BindItName
        /// <summary>
        /// 
        /// </summary>
        private void BindItName()
        {
            using (var db = DBFactory.GetBxdbDataContext())
            {
                var its = db.tblIntroducer;
                this.cmbIt.DisplayMember = "it_name";
                this.cmbIt.DataSource = its;
            }
        }
        #endregion //BindItName

        #region GetStatusDataSource
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private object GetStatusDataSource()
        {
            List<KeyValuePair<string, FLStatus>> ds = new List<KeyValuePair<string, FLStatus>>();

            FLStatus[] poss = new FLStatus[] { FLStatus.Created, FLStatus.Received, FLStatus.Completed, FLStatus.Finally, FLStatus.Timeouted };
            foreach (FLStatus item in poss)
            {
                string name = MTStatusHelper.GetFLStatusText(item);
                ds.Add(new KeyValuePair<string, FLStatus>(name, item));
            }
            return ds;
        }
        #endregion //GetStatusDataSource

        #region SelectedFLStatus
        /// <summary>
        /// 
        /// </summary>
        public FLStatus SelectedFLStatus
        {
            get 
            {
                if (this.cmbStatus.SelectedValue != null)
                {
                    return (FLStatus)this.cmbStatus.SelectedValue;
                }
                else
                {
                    return FLStatus.New;
                }
            }
            set
            {
                this.cmbStatus.SelectedValue = value;
                
            }
        }
        #endregion //SelectedFLStatus

        #region BindStatus
        /// <summary>
        /// 
        /// </summary>
        private void BindStatus()
        {
            this.cmbStatus.DisplayMember = "Key";
            this.cmbStatus.ValueMember = "Value";
            this.cmbStatus.DataSource = GetStatusDataSource();
            //using (var db = DBFactory.GetBxdbDataContext())
            //{
            //    var mls = db.tblMaintainLevel.ToArray();
            //    this.cmbStatus.DisplayMember = "ml_name";
            //    this.cmbStatus.DataSource = mls;
            //}
        }
        #endregion //BindStatus

        #region ML
        /// <summary>
        /// 
        /// </summary>
        public tblMaintainLevel ML
        {
            get { return _ml; }
            set { _ml = value; }
        } private tblMaintainLevel _ml;
        #endregion //ML

        #region EnabledDateTime
        /// <summary>
        /// 
        /// </summary>
        public bool EnabledDateTime
        {
            get { return this.chkTime.Checked; }
            set { this.chkTime.Checked = value; }
        }
        #endregion //EnabledDateTime

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
            get { return this.dtpEnd .Value; }
            set { this.dtpEnd.Value = value; }
        }
        #endregion //End

        #region EnabledIt
        /// <summary>
        /// 
        /// </summary>
        public bool EnabledIt
        {
            get { return this.chkIT.Checked; }
            set { this.chkIT.Checked = value; }
        }
        #endregion //EnabledIt

        #region EnabledFLStatus
        /// <summary>
        /// 
        /// </summary>
        public bool EnabledFLStatus
        {
            get { return this.chkStatus.Checked; }
            set { this.chkStatus.Checked = value; }
        }
        #endregion //EnabledFLStatus

        #region ItName
        public string ItName
        {
            get { return this.cmbIt.Text; }
            set { this.cmbIt.Text = value; }
        }
        #endregion //ItName

        #region chkTime_CheckedChanged
        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDtpStyles();
        }
        #endregion //chkTime_CheckedChanged

        #region SetDtpStyles
        private void SetDtpStyles()
        {
            this.dtpBegin.Enabled = this.chkTime.Checked;
            this.dtpEnd.Enabled = this.chkTime.Checked;
        }
        #endregion //SetDtpStyles

        #region chkStatus_CheckedChanged
        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbStatus.Enabled = this.chkStatus.Checked;
        }
        #endregion //chkStatus_CheckedChanged

        #region chkIT_CheckedChanged
        private void chkIT_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbIt.Enabled = this.chkIT.Checked;
        }
        #endregion //chkIT_CheckedChanged
    }
}
