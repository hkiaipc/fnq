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

        /// <summary>
        /// 
        /// </summary>
        public UCCondition()
        {
            InitializeComponent();
        }

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

        

        private void UCCondition_Load(object sender, EventArgs e)
        {
            SetDtpStyles();
            BindStatus();
            BindItName();


            this.dtpBegin.Value = DateTime.Now.Date - TimeSpan.FromDays(1);
            this.dtpEnd.Value = DateTime.Now.Date + TimeSpan.FromDays(1);
        }

        private void BindItName()
        {
            using (var db = DBFactory.GetBxdbDataContext())
            {
                var its = db.tblIntroducer;
                this.cmbIt.DisplayMember = "it_name";
                this.cmbIt.DataSource = its;
            }
        }

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


            //this.cmbNewMTStatus.DisplayMember = "Key";
            //this.cmbNewMTStatus.ValueMember = "Value";
            //this.cmbNewMTStatus.DataSource = ds;
        }

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

        /// <summary>
        /// 
        /// </summary>
        public tblMaintainLevel ML
        {
            get { return _ml; }
            set { _ml = value; }
        } private tblMaintainLevel _ml;

        public bool IsTime
        {
            get { return this.chkTime.Checked; }
            set { this.chkTime.Checked = value; }
        }

        public DateTime Begin
        {
            get { return this.dtpBegin.Value; }
            set { this.dtpBegin.Value = value; }
        }

        public DateTime End
        {
            get { return this.dtpEnd .Value; }
            set { this.dtpEnd.Value = value; }
        }

        public string ItName
        {
            get { return this.cmbIt.Text; }
            set { this.cmbIt.Text = value; }
        }

        private void chkTime_CheckedChanged(object sender, EventArgs e)
        {
            SetDtpStyles();
        }

        private void SetDtpStyles()
        {
            this.dtpBegin.Enabled = this.chkTime.Checked;
            this.dtpEnd.Enabled = this.chkTime.Checked;
        }
    }
}
