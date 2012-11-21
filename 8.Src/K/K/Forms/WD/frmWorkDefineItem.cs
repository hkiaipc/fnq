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

        public frmWorkDefineItem()
        {
            InitializeComponent();
            this.flowLayoutPanel1.SetFlowBreak(this.flowLayoutPanel1, false);
        }


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

        CycleTypeEnum SelectedCycleType
        {
            get
            {
                return (CycleTypeEnum)this.cmbCycle.SelectedIndex;
            }
            //set { }
        }

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

        private void frmWorkDefineItem_Load(object sender, EventArgs e)
        {
            this.cmbCycle.SelectedIndex = 0;
            FillCycleDayCount();
        }

        int GetUserDefineCycleDayCount()
        {
            return (int)this.cmbCycleDayCount.SelectedValue;

        }
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

        private void cmbCycle_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cmbCycleDayCount.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.dtpStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
            this.lblStart.Visible = (this.SelectedCycleType == CycleTypeEnum.UserDefine);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.flowLayoutPanel1.Controls.Count > 0)
            {
                Control c = this.flowLayoutPanel1.Controls[this.flowLayoutPanel1.Controls.Count - 1];
                this.flowLayoutPanel1.Controls.Remove(c);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            Verify();
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

        private void Edit()
        {
            throw new NotImplementedException();
        }

        private void Add()
        {
            WorkDefine wd = this.WorkDefine;
            wd.CycleType = this.SelectedCycleType;
            wd.DayOfCycle = this.SelectedCycleDayCount;
            wd.Name = this.txtWorkDefineName.Text.Trim();
            wd.StartDateTime = this.StartDateTime;
            SetTimeDefines(wd);

            tblWorkDefine tblWorkDefine = new tblWorkDefine();
            tblWorkDefine.WorkDefineContext = WorkDefine.Serialize(wd);

            DB db = DBFactory.GetDB();
            db.tblWorkDefine.InsertOnSubmit(tblWorkDefine);

            db.SubmitChanges();
        }

        private void SetTimeDefines(WorkDefine wd)
        {
            foreach (Control c in this.flowLayoutPanel1.Controls)
            {
                UC.UCTimeDefine ucTd = c as UC.UCTimeDefine;
                wd.TimeDefines.Add(ucTd.CreateTimeDefineByUI());
            }
        }

        DateTime StartDateTime
        {
            get
            { 
                //TODO:
                //
                return DateTime.Now;
            }
        }

        public bool IsAdd
        {
            get { return _isAdd; }
            set { _isAdd = value; }
        } private bool _isAdd;

        private bool Verify()
        {
            // TODO:
            //
            return true;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
            }
        } private tblWorkDefine _tblWorkDefine;
        #endregion //TblWorkDefine

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

                    this.cmbCycle.SelectedIndex = (int)_workDefine.CycleType;
                    this.cmbCycleDayCount.SelectedValue = _workDefine.DayOfCycle;
                    foreach (TimeDefine td in _workDefine.TimeDefines)
                    {
                        UC.UCTimeDefine ucTd = CreateTimeDefineControl(_workDefine, td);
                        this.flowLayoutPanel1.Controls.Add(ucTd);
                    }
                }
            }
        } private WorkDefine _workDefine;

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
    }
}
