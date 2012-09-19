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
    public partial class UCMt : UserControl, IReadonly, IView
    {

        //private BxdbDataContext _dc = null;
        //private BxdbDataContext Dc
        //{
        //    get
        //    {
        //        if (_dc == null)
        //        {
        //            _dc = DBFactory.GetBxdbDataContext();
        //        }
        //        return _dc;
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        public UCMt()
        {
            InitializeComponent();

            this.BindML();
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
            using (var db = DBFactory.GetBxdbDataContext())
            {
                var r = from q in db.tblMaintainLevel
                        orderby q.ml_number
                        select q;

                this.cmbML.DisplayMember = "ml_name";
                this.cmbML.ValueMember = "ml_id";
                this.cmbML.DataSource = r;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="mt"></param>
        /// <returns></returns>
        public tblMaintain UpdateMaintain(BxdbDataContext db, tblMaintain mt)
        {
            tblMaintain old = this.Maintain;

            //tblMaintain mt = new tblMaintain();
            mt.mt_id = old.mt_id;
            mt.mt_create_dt = old.mt_create_dt;
            mt.mt_pose_dt = old.mt_pose_dt;
            mt.mt_begin_dt = old.mt_begin_dt;
            mt.mt_content = old.mt_content;
            mt.mt_timeout_dt = old.mt_timeout_dt;
            mt.tblMaintainLevel = GetMaintainLevel(db, (tblMaintainLevel)this.cmbML.SelectedItem);
            mt.tblOperator = db.tblOperator.First(c => c.op_id == App.Default.LoginOperator.op_id);
            return mt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public tblMaintain GetMaintain(BxdbDataContext db)
        {
            tblMaintain old = this.Maintain;

            tblMaintain mt = new tblMaintain();
            mt.mt_id = old.mt_id;
            mt.mt_create_dt = old.mt_create_dt;
            mt.mt_pose_dt = old.mt_pose_dt;
            mt.mt_begin_dt = old.mt_begin_dt;
            mt.mt_content = old.mt_content;
            mt.mt_timeout_dt = old.mt_timeout_dt;
            mt.tblMaintainLevel = GetMaintainLevel(db, (tblMaintainLevel)this.cmbML.SelectedItem);
            mt.tblOperator = db.tblOperator.First(c => c.op_id == App.Default.LoginOperator.op_id);

            if (mt.mt_id == 0)
            {
                db.tblMaintain.InsertOnSubmit(mt);
            }

            return mt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="db"></param>
        /// <param name="ml"></param>
        /// <returns></returns>
        private tblMaintainLevel GetMaintainLevel(BxdbDataContext db, tblMaintainLevel ml)
        {
            var v = db.tblMaintainLevel.First(c => c.ml_id == ml.ml_id);
            return v;
        }

        /// <summary>
        /// 
        /// </summary>
        public tblMaintain Maintain
        {
            get { return _maintain; }
            set
            {
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

            //tblIntroducer introducer = _maintain.tblIntroducer;
            //if (introducer != null)
            //{
            //    //this.txtIntroducerName.Text = introducer.it_name;
            //    //this.txtAddress.Text = introducer.it_address;
            //    //this.cmdFee .Text = introducer.it_
            //    //this.txtPhone.Text = introducer.it_phone;
            //}

            this.dtpPose.Value = (DateTime)_maintain.mt_pose_dt;
            this.dtpBegin.Value = (DateTime)_maintain.mt_begin_dt;
            this.dtpTimeout.Value = (DateTime)_maintain.mt_timeout_dt;

            this.cmbML.SelectedValue = _maintain.tblMaintainLevel.ml_id;
            this.txtOperatorName.Text = _maintain.tblOperator.op_name;
            this.txtContent.Text = _maintain.mt_content;

            this.Readonly = IsReadonly(App.Default.GetLoginOperatorRight(),
                _maintain.tblFlow[0].GetFLStatus());
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

        #region IReadonly 成员

        public bool Readonly
        {
            get
            {
                return _readonly;
            }
            set
            {
                _readonly = value;

                ReadonlyHelper.SetReadonlyStyle(
                    new Control[] { dtpPose, dtpBegin, cmbML, txtContent },
                    _readonly);

                ReadonlyHelper.SetReadonlyStyle(
                    new Control[] { dtpTimeout, txtOperatorName },
                    true);
            }
        } private bool _readonly;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        internal void UpdateMaintain()
        {
            UpdateModel();
        }

        #region IView 成员

        public void UpdateModel()
        {
            _maintain.mt_pose_dt = this.dtpPose.Value;
            _maintain.mt_begin_dt = this.dtpBegin.Value;
            _maintain.tblMaintainLevel = (tblMaintainLevel)this.cmbML.SelectedItem;
            _maintain.mt_content = this.txtContent.Text;
            _maintain.mt_timeout_dt = this.dtpTimeout.Value;
        }

        public bool CheckInput()
        {
            // TODO: pose dt and begin dt
            //
            bool r = true;
            if (this.txtContent.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.MTContentEmpty);
                r = false;
            }
            else
            {
                bool b = this.dtpBegin.Value > DateTime.Now;
                if (!b)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(Strings.MTBeginOld);
                    r = false;
                }
            }
            return r;
        }

        #endregion

        #region IView 成员


        public bool IsReadonly(Right rt, FLStatus status)
        {
            return !(rt.Value == fnbx.Right.SenderValue &&
                (status == FLStatus.New ||
                status == FLStatus.Created));
        }

        #endregion

    }
}
