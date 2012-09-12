using System;
using System.Diagnostics;
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
    public partial class UCMt : UserControl
    {

        private BxdbDataContext _dc = null;
        private BxdbDataContext Dc
        {
            get
            {
                if (_dc == null)
                {
                    _dc = Class1.GetBxdbDataContext();
                }
                return _dc;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public UCMt()
        {
            InitializeComponent();
        }

        private void UCMt_Load(object sender, EventArgs e)
        {
            // after load
            //
            this._isUpdateTimeoutDateTimePicker = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void BindML()
        {
            var r = from q in this.Dc.tblMaintainLevel
                    orderby q.ml_number
                    select q;

            this.cmbML.DisplayMember = "ml_name";
            this.cmbML.ValueMember = "ml_id";
            this.cmbML.DataSource = r;
        }

        /// <summary>
        /// 
        /// </summary>
        public tblMaintain Maintain
        {
            get { return _maintain; }
            set {
                //Debug.Assert(value != null);
                _maintain = value;
                if (_maintain != null)
                {
                    RefreshMaintain();
                }
            }
        } private tblMaintain _maintain;

        /// <summary>
        /// 
        /// </summary>
        private void RefreshMaintain()
        {
            if (this.cmbML.DataSource == null)
            {
                BindML();
            }

            tblIntroducer introducer = _maintain.tblIntroducer;
            if (introducer != null)
            {
                this.txtIntroducerName.Text = introducer.it_name;
                this.txtAddress.Text = introducer.it_address;
                //this.cmdFee .Text = introducer.it_
                this.txtPhone.Text = introducer.it_phone;
            }

            this.dtpPose.Value = (DateTime )_maintain.mt_pose_dt;
            this.dtpBegin.Value = (DateTime)_maintain.mt_begin_dt;
            this.dtpTimeout.Value = (DateTime)_maintain.mt_timeout_dt;

            this.cmbML.SelectedValue = _maintain.tblMaintainLevel.ml_id;
            this.txtOperatorName.Text = _maintain.tblOperator.op_name;
            this.txtContent.Text  = _maintain.mt_content;
        }

        /// <summary>
        /// 
        /// </summary>
        internal void UpdateMaintain()
        {
            _maintain.mt_pose_dt = this.dtpPose.Value;
            _maintain.mt_begin_dt = this.dtpBegin.Value;
            _maintain.tblMaintainLevel = (tblMaintainLevel)this.cmbML.SelectedItem;
            _maintain.mt_content = this.txtContent.Text;
            _maintain.mt_timeout_dt = this.dtpTimeout.Value;

            tblIntroducer introducer = _maintain.tblIntroducer;
            if (introducer == null)
            {
                introducer = new tblIntroducer();
                _maintain.tblIntroducer = introducer;
            }

            introducer.it_name = txtIntroducerName.Text;
            introducer.it_phone = txtPhone.Text;
            introducer.it_address = txtAddress.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        private bool _isUpdateTimeoutDateTimePicker = false;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpBegin_ValueChanged(object sender, EventArgs e)
        {
            if (_isUpdateTimeoutDateTimePicker)
            {
                UpdateTimeoutDateTimePicker();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private tblMaintainLevel GetSelectedML()
        {
            tblMaintainLevel ml = (tblMaintainLevel)this.cmbML.SelectedItem;
            Debug.Assert(ml != null);
            return ml;
        }

        private void cmbML_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdateTimeoutDateTimePicker)
            {
                UpdateTimeoutDateTimePicker();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateTimeoutDateTimePicker()
        {
            DateTime dt = this.dtpBegin.Value;
            DateTime timeout = dt + TimeSpan.FromMinutes((int)GetSelectedML().ml_arrive_hl);
            this.dtpTimeout.Value = timeout;
        }
    }
}
