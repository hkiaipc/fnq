using System;
using System.Diagnostics;
using KDB;
using Xdgk.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.WD
{
    public partial class frmWorkDefineItem : NUnit.UiKit.SettingsDialogBase
    {
        private const int MaxControlCount = 14;


        #region frmWorkDefineItem
        public frmWorkDefineItem()
        {
            InitializeComponent();
            //this.flowLayoutPanel1.SetFlowBreak(this.flowLayoutPanel1, false);
            BindCycleType();
            BindCycleDayCount();
        }
        #endregion //frmWorkDefineItem

        #region frmWorkDefineItem_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmWorkDefineItem_Load(object sender, EventArgs e)
        {
            this.cmbCycleType.SelectedIndex = 0;

            if (this._workDefine != null)
            {
                FillWorkDefineInfo();
            }

            VisibleOrInvisibleControls();

            this.cmbCycleType.SelectedIndexChanged += new EventHandler(cmbCycleType_SelectedIndexChanged);
            this.cmbCycleDayCount.SelectedIndexChanged += new EventHandler(cmbCycleDayCount_SelectedIndexChanged);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCycleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            VisibleOrInvisibleControls();

            if (_cycleTypeLastIndex != this.cmbCycleType.SelectedIndex)
            {
                // clear time defines
                //
                this.flowLayoutPanel1.Controls.Clear();

                //if (this.WorkDefine != null)
                //{

                // 
                //
                //this.WorkDefine.CycleType = SelectedCycleType;
                this.WorkDefine = this.CreateWorkDefine();
                //}
            }

            _cycleTypeLastIndex = this.cmbCycleType.SelectedIndex;
        }

        private void VisibleOrInvisibleControls()
        {
            this.cmbCycleDayCount.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.dtpStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.lblStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
        }
        #endregion //frmWorkDefineItem_Load

        #region BindCycleType
        /// <summary>
        /// 
        /// </summary>
        void BindCycleType()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("周", CycleTypeEnum.Week));
            kvs.Add(new KeyValue("自定义", CycleTypeEnum.UserDefine));

            this.cmbCycleType.DisplayMember = "Key";
            this.cmbCycleType.ValueMember = "Value";

            this.cmbCycleType.DataSource = kvs;
        }
        #endregion //BindCycleType

        #region btnAdd_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Controls.Count >= MaxControlCount)
            {
                // TODO:
                //
                NUnit.UiKit.UserMessage.DisplayFailure("max");
                return;
            }

            UC.UCTimeDefine td = new K.UC.UCTimeDefine();
            td.WorkDefine = this.WorkDefine;
            this.flowLayoutPanel1.Controls.Add(td);
        }
        #endregion //btnAdd_Click

        #region SelectedCycleType
        CycleTypeEnum SelectedCycleType
        {
            get
            {
                return (CycleTypeEnum)this.cmbCycleType.SelectedIndex;
            }
            //set { }
        }
        #endregion //SelectedCycleType

        #region SelectedCycleDayCount
        int SelectedCycleDayCount
        {
            get
            {
                if (SelectedCycleType == CycleTypeEnum.Week)
                {
                    return 7;
                }
                if (SelectedCycleType == CycleTypeEnum.UserDefine)
                {
                    return GetUserDefineCycleDayCount();
                }

                throw new InvalidOperationException(SelectedCycleType.ToString());
            }
        }
        #endregion //SelectedCycleDayCount


        #region GetUserDefineCycleDayCount
        int GetUserDefineCycleDayCount()
        {
            return (int)this.cmbCycleDayCount.SelectedValue;

        }
        #endregion //GetUserDefineCycleDayCount

        #region BindCycleDayCount
        /// <summary>
        /// 
        /// </summary>
        void BindCycleDayCount()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            
            for (int i = 1; i < 11; i++)
            {
                kvs.Add(new KeyValue(string.Format("{0}天", i), i));
            }

            this.cmbCycleDayCount.DisplayMember = "Key";
            this.cmbCycleDayCount.ValueMember = "Value";
            this.cmbCycleDayCount.DataSource = kvs;
        }
        #endregion //BindCycleDayCount

        int _cycleTypeLastIndex = -1;

        #region btnDelete_Click
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Controls.Count > 0)
            {
                Control c = this.flowLayoutPanel1.Controls[this.flowLayoutPanel1.Controls.Count - 1];
                this.flowLayoutPanel1.Controls.Remove(c);
            }
        }
        #endregion //btnDelete_Click

        #region okButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!Verify())
            {
                return;
            }

            WorkDefine wd = null;
            try
            {
                wd = CreateWorkDefine();
            }
            catch (KConfigException kex)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(kex.Message);
                return;
            }

            if (wd.TimeDefines.Count == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("TODO: time defines count == 0");
                return;
            }

            if (IsAdd)
            {
                Add(wd);
            }
            else
            {
                Edit(wd);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion //okButton_Click

        #region Edit
        /// <summary>
        /// 
        /// </summary>
        private void Edit(WorkDefine wd )
        {
            DB db = DBFactory.GetDB();
            tblWorkDefine tblWd = db.tblWorkDefine.First(
                c => c.WorkDefineID == this.TblWorkDefine.WorkDefineID
                );

            tblWd.WorkDefineName = this.txtWorkDefineName.Text.Trim();
            tblWd.WorkDefineContext = WorkDefine.Serialize(wd);
            db.SubmitChanges();
        }
        #endregion //Edit

        #region CreateWorkDefine
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private WorkDefine CreateWorkDefine()
        {
            //WorkDefine wd = new WorkDefine();
            WorkDefine wd = WorkDefine.Create(this.SelectedCycleType);
            wd.Name = this.txtWorkDefineName.Text.Trim();
            wd.Remark = "";

            if (wd is UserWorkDefine)
            {
                UserWorkDefine userWD = wd as UserWorkDefine;
                userWD.DayOfCycle = this.SelectedCycleDayCount;
                userWD.StartDateTime = this.StartDateTime;
            }

            SetTimeDefines(wd);
            return wd;
        }
        #endregion //CreateWorkDefine

        #region Add
        /// <summary>
        /// 
        /// </summary>
        private bool Add(WorkDefine wd)
        {
            //WorkDefine wd = this.WorkDefine;
            //wd.Name = this.txtWorkDefineName.Text.Trim();

            //wd.CycleType = this.SelectedCycleType;

            //wd.DayOfCycle = this.SelectedCycleDayCount;
            //wd.StartDateTime = this.StartDateTime;

            //SetTimeDefines(wd);
            //WorkDefine wd = CreateWorkDefine();


            tblWorkDefine tblWorkDefine = new tblWorkDefine();
            tblWorkDefine.WorkDefineName = wd.Name;
            tblWorkDefine.WorkDefineContext = WorkDefine.Serialize(wd);

            DB db = DBFactory.GetDB();
            db.tblWorkDefine.InsertOnSubmit(tblWorkDefine);

            db.SubmitChanges();

            return true;
        }
        #endregion //Add

        #region SetTimeDefines
        private void SetTimeDefines(WorkDefine wd)
        {
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                UC.UCTimeDefine ucTd = c as UC.UCTimeDefine;
                wd.TimeDefines.Add(ucTd.CreateTimeDefineByUI());
            }
        }
        #endregion //SetTimeDefines

        #region StartDateTime
        DateTime StartDateTime
        {
            get
            { 
                return this.dtpStart.Value;
            }
            set
            {
                this.dtpStart.Value = value;
            }
        }
        #endregion //StartDateTime

        #region IsAdd
        public bool IsAdd
        {
            get { return _isAdd; }
            set { _isAdd = value; }
        } private bool _isAdd;
        #endregion //IsAdd

        #region Verify
        private bool Verify()
        {
            // TODO:
            //
            if (this.txtWorkDefineName.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure("名称不能为空");
                return false;
            }

            

            return true;
        }
        #endregion //Verify

        #region cancelButton_Click
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion //cancelButton_Click

        #region TblWorkDefine
        /// <summary>
        /// 
        /// </summary>
        public tblWorkDefine TblWorkDefine
        {
            get
            {
                return _tblWorkDefine;
            }
            set
            {
                _tblWorkDefine = value;


                WorkDefine wd = null;
                try
                {
                    wd = WorkDefine.Deserialize(_tblWorkDefine.WorkDefineContext);
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                    wd = new WeekWorkDefine();
                }
                this.WorkDefine = wd;
            }
        } private tblWorkDefine _tblWorkDefine;
        #endregion //TblWorkDefine

        #region WorkDefine
        /// <summary>
        /// 
        /// </summary>
        internal WorkDefine WorkDefine
        {
            get { return _workDefine; }
            set
            { 
                Debug.Assert (value != null);
                if (_workDefine != value)
                {
                    _workDefine = value;
                }
            }
        }
        #endregion //WorkDefine

        #region FillWorkDefine
        /// <summary>
        /// 
        /// </summary>
        private void FillWorkDefineInfo()
        {
            // fill
            //
            this.txtWorkDefineName.Text = _workDefine.Name;

            // get cycle type
            //
            CycleTypeEnum cycleType = CycleTypeEnum.UserDefine;
            if (_workDefine is WeekWorkDefine)
            {
                cycleType = CycleTypeEnum.Week;
            }
            else if (_workDefine is UserWorkDefine)
            {
                cycleType = CycleTypeEnum.UserDefine;
            }
            else
            {
                throw new InvalidOperationException();
            }

            this.cmbCycleType.SelectedIndex = (int)cycleType;

            //
            //
            if (_workDefine is UserWorkDefine)
            {
                UserWorkDefine userWD = (UserWorkDefine)_workDefine;
                this.cmbCycleDayCount.SelectedValue = userWD.DayOfCycle;
                this.dtpStart.Value = userWD.StartDateTime;
            }

            foreach (TimeDefine td in _workDefine.TimeDefines)
            {
                UC.UCTimeDefine ucTd = CreateTimeDefineControl(_workDefine, td);
                this.flowLayoutPanel1.Controls.Add(ucTd);
            }
        } private WorkDefine _workDefine;
        #endregion //FillWorkDefine

        #region CreateTimeDefineControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="wd"></param>
        /// <param name="td"></param>
        /// <returns></returns>
        private K.UC.UCTimeDefine CreateTimeDefineControl(WorkDefine wd, TimeDefine td)
        {
            UC.UCTimeDefine ucTd = new K.UC.UCTimeDefine();
            ucTd.WorkDefine = wd;
            ucTd.TimeDefine = td;

            return ucTd;
        }
        #endregion //CreateTimeDefineControl

        #region cmbCycleDayCount_SelectedIndexChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCycleDayCount_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();

            if (this.WorkDefine is UserWorkDefine)
            {
                ((UserWorkDefine)this.WorkDefine).DayOfCycle = this.SelectedCycleDayCount;
            }
        }
        #endregion //cmbCycleDayCount_SelectedIndexChanged
    }
}
