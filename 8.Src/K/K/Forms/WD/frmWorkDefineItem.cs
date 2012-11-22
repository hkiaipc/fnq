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
        }
        #endregion //frmWorkDefineItem

        #region BindCycleType
        void BindCycleType()
        {
            this.cmbCycle.DisplayMember = "Key";
            this.cmbCycle.ValueMember = "Value";

            this.cmbCycle.DataSource = GetCycleTypeDataSource();
        }
        #endregion //BindCycleType

        #region GetCycleTypeDataSource
        object GetCycleTypeDataSource()
        {
            KeyValueCollection kvs = new KeyValueCollection();
            kvs.Add(new KeyValue("周", CycleTypeEnum.Week));
            kvs.Add(new KeyValue("自定义", CycleTypeEnum.UserDefine));
            return kvs;
        }
        #endregion //GetCycleTypeDataSource

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
                return (CycleTypeEnum)this.cmbCycle.SelectedIndex;
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

        #region frmWorkDefineItem_Load
        private void frmWorkDefineItem_Load(object sender, EventArgs e)
        {
            this.cmbCycle.SelectedIndex = 0;
            FillCycleDayCount();
            FillWorkDefine();
        }
        #endregion //frmWorkDefineItem_Load

        #region GetUserDefineCycleDayCount
        int GetUserDefineCycleDayCount()
        {
            return (int)this.cmbCycleDayCount.SelectedValue;

        #region FillCycleDayCount
        }
        #endregion //GetUserDefineCycleDayCount
        /// <summary>
        /// 
        /// </summary>
        void FillCycleDayCount()
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
        #endregion //FillCycleDayCount

        #region cmbCycle_SelectedIndexChanged

        int _cycleTypeLastIndex = -1;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCycleDayCount.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.dtpStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.lblStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);

            if (_cycleTypeLastIndex != this.cmbCycle.SelectedIndex)
            {
                // clear time defines
                //
                this.flowLayoutPanel1.Controls.Clear();

                if (this.WorkDefine != null)
                {
                    this.WorkDefine.CycleType = SelectedCycleType;
                }
            }

            _cycleTypeLastIndex = this.cmbCycle.SelectedIndex;
        }
        #endregion //cmbCycle_SelectedIndexChanged

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
        #endregion //okButton_Click

        #region Edit
        /// <summary>
        /// 
        /// </summary>
        private void Edit()
        {
            DB db = DBFactory.GetDB();
            tblWorkDefine tblWd = db.tblWorkDefine.First(
                c => c.WorkDefineID == this.TblWorkDefine.WorkDefineID
                );

            tblWd.WorkDefineContext = WorkDefine.Serialize(CreateWorkDefine());
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
            WorkDefine wd = new WorkDefine();
            wd.Name = this.txtWorkDefineName.Text.Trim();

            wd.CycleType = this.SelectedCycleType;

            wd.DayOfCycle = this.SelectedCycleDayCount;
            wd.StartDateTime = this.StartDateTime;

            SetTimeDefines(wd);
            return wd;
        }
        #endregion //CreateWorkDefine

        #region Add
        /// <summary>
        /// 
        /// </summary>
        private void Add()
        {
            //WorkDefine wd = this.WorkDefine;
            //wd.Name = this.txtWorkDefineName.Text.Trim();

            //wd.CycleType = this.SelectedCycleType;

            //wd.DayOfCycle = this.SelectedCycleDayCount;
            //wd.StartDateTime = this.StartDateTime;

            //SetTimeDefines(wd);
            WorkDefine wd = CreateWorkDefine();

            tblWorkDefine tblWorkDefine = new tblWorkDefine();
            tblWorkDefine.WorkDefineContext = WorkDefine.Serialize(wd);

            DB db = DBFactory.GetDB();
            db.tblWorkDefine.InsertOnSubmit(tblWorkDefine);

            db.SubmitChanges();
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

                WorkDefine wd = WorkDefine.Deserialize(_tblWorkDefine.WorkDefineContext);
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
        private void FillWorkDefine()
        {
            // fill
            //
            this.txtWorkDefineName.Text = _workDefine.Name;
            this.cmbCycle.SelectedIndex = (int)_workDefine.CycleType;
            this.cmbCycleDayCount.SelectedValue = _workDefine.DayOfCycle;
            this.dtpStart.Value = _workDefine.StartDateTime;

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
            this.WorkDefine.DayOfCycle = this.SelectedCycleDayCount;
        }
        #endregion //cmbCycleDayCount_SelectedIndexChanged
    }
}
