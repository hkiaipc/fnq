using System;
using System.Data.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB;

namespace fnbx
{
    public partial class frmFlow : Form, IView
    {

        #region Members
        private FLStatus _oldFLStatus;
        private List<FLStatus> _newStatusList = new List<FLStatus>();
        #endregion //Members

        #region GetDC
        //private BxdbDataContext GetDC()
        //{
        //    if (this._dc == null)
        //    {
        //        //_dc = new BxdbDataContext();
        //        _dc = DBFactory.GetBxdbDataContext();
        //    }
        //    return this._dc;
        //} private BxdbDataContext _dc;
        #endregion //GetDC

        #region frmFlow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="flID"></param>
        public frmFlow()
        {
            InitializeComponent();

            //_flID = flID;
            //if (_flID == 0)
            //{
            //    this.FL = new tblFlow();
            //}
            //else
            //{
            //    var v = from p in this.GetDC().tblFlow
            //            where p.fl_id == _flID
            //            select p;
            //    this.FL = v.ToList()[0];
            //}

        }
        #endregion //frmFlow

        #region frmFlow_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFlow_Load(object sender, EventArgs e)
        {
            UpdateToolbarStyles();

            Right rt = App.Default.GetLoginOperatorRight();
            bool b = rt.CanModifyFLStatus(this.FL.GetFLStatus());
            this.tssModifyStatus.Enabled = b;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rt"></param>
        /// <param name="b"></param>
        private void UpdateToolbarStyles()
        {
            Right rt = App.Default.GetLoginOperatorRight();

            bool b = rt.CanActivateForFL(Xdgk.Common.ADEState.Edit, this.FL.GetFLStatus());
            this.保存SToolStripButton.Enabled = b;
        }
        #endregion //frmFlow_Load

        #region FL
        /// <summary>
        /// 
        /// </summary>
        public tblFlow FL
        {
            get
            {
                return _fl;
            }
            set
            {
                //if (_fl != value)
                //{
                _fl = value;
                if (_fl != null)
                {
                    this._oldFLStatus = this.FL.GetFLStatus();
                    UpdateView();
                }
                //}
            }
        } private tblFlow _fl;
        #endregion //FL

        #region UpdateView
        /// <summary>
        /// 
        /// </summary>
        private void UpdateView()
        {
            ucIt1.It = _fl.tblIntroducer;
            ucMt1.Maintain = _fl.tblMaintain;
            ucRc1.Rc = _fl.tblReceive;
            ucRp1.Reply = _fl.tblReply;
            RefreshFLStatusBar();

            SetReplyPageStyle();
        }
        #endregion //UpdateView

        #region RefreshFLStatusBar
        /// <summary>
        /// 
        /// </summary>
        private void RefreshFLStatusBar()
        {
            this.tssFLStatus.Text = string.Format(
                Strings.CurrentFLStatus,
                _fl.GetFLStatusText()
                );

            if (this.FL.GetFLStatus() != _oldFLStatus)
            {
                this.tssFLStatus.Text += string.Format("({0})", Strings.FlStatusChanged);
            }
        }
        #endregion //RefreshFLStatusBar

        #region 保存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            Right rt = App.Default.GetLoginOperatorRight();

            if (!rt.CanActivateForFL(Xdgk.Common.ADEState.Edit, this.FL.GetFLStatus()))
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotEditMT);
                return;
            }

            if (!this.CheckInput())
            {
                return;
            }

            this.UpdateModel();

            if (this.FL.fl_id == 0)
            {
                InsertFL();
            }
            else
            {
                UpdateFL();
            }
        }
        #endregion //保存

        #region InsertFL
        /// <summary>
        /// 
        /// </summary>
        private void InsertFL()
        {
            using (var db = DBFactory.CreateDataContext())
            {
                tblFlow newFL = new tblFlow();
                newFL.fl_status = (int)FLStatus.Created;
                newFL.tblIntroducer = ucIt1.GetIntroducer(db);
                newFL.tblMaintain = ucMt1.GetMaintain(db);
                newFL.tblReceive = ucRc1.Rc;
                newFL.tblReply = ucRp1.Reply;

                if (newFL.fl_id == 0)
                {
                    db.tblFlow.InsertOnSubmit(newFL);
                }

                try
                {
                    db.SubmitChanges();
                    //Debug.Assert(this.FL.fl_id != 0);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    NUnit.UiKit.UserMessage.DisplayFailure(ex.Message);
                }
            }
        }
        #endregion //InsertFL

        #region UpdateFL
        /// <summary>
        /// 
        /// </summary>
        private void UpdateFL()
        {
            using (var db = DBFactory.GetBxdbDataContext())
            {
                tblFlow old = this.FL;

                tblFlow updateFL = db.tblFlow.First(c => c.fl_id == old.fl_id);
                updateFL.SetFLStatus(old.GetFLStatus());
                updateFL.tblIntroducer = ucIt1.UpdateIntroducer(db, updateFL.tblIntroducer);
                //updateFL.tblIntroducer = ucIt1.GetIntroducer(db);
                //updateFL.tblMaintain = ucMt1.GetMaintain(db);
                updateFL.tblMaintain = ucMt1.UpdateMaintain(db, updateFL.tblMaintain);
                updateFL.tblReceive = ucRc1.UpdateReceive(db, updateFL.tblReceive);
                updateFL.tblReply = ucRp1.UpdateReply(db, updateFL.tblReply);

                try
                {
                    db.SubmitChanges();
                    this.DialogResult = DialogResult.OK;
                    NUnit.UiKit.UserMessage.DisplayInfo(Strings.SaveSuccess);
                }
                catch (System.Data.Linq.ChangeConflictException ee)
                {
                    foreach (ObjectChangeConflict occ in db.ChangeConflicts)
                    {
                        Dump(occ);
                        occ.Resolve(RefreshMode.OverwriteCurrentValues);
                    }

                    NUnit.UiKit.UserMessage.DisplayFailure(ee.Message);

                    //this._oldFLStatus = this.FL.GetFLStatus();
                    //this.UpdateView();

                    this.FL = this.FL;
                }
            }
        }
        #endregion //UpdateFL

        #region Dump
        /// <summary>
        /// 
        /// </summary>
        /// <param name="occ"></param>
        private void Dump(ObjectChangeConflict occ)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("------dump occ------\r\n");
            sb.AppendFormat("IsDeleted: {0}\r\n", occ.IsDeleted);
            sb.AppendFormat("IsResolved: {0}\r\n", occ.IsResolved);
            Dump(sb, occ.MemberConflicts);
            sb.AppendFormat("object: {0}\r\n", occ.Object);

            Console.WriteLine(sb.ToString());
        }

        private void Dump(StringBuilder sb, System.Collections.ObjectModel.ReadOnlyCollection<MemberChangeConflict> readOnlyCollection)
        {
            foreach (MemberChangeConflict item in readOnlyCollection)
            {
                sb.Append("--- member ---\r\n");
                sb.AppendFormat("CurrentValue: {0}\r\n", item.CurrentValue);
                sb.AppendFormat("DatabaseValue: {0}\r\n", item.DatabaseValue);
                sb.AppendFormat("IsModified: {0}\r\n", item.IsModified);
                sb.AppendFormat("IsResolved: {0}\r\n", item.IsResolved);
                sb.AppendFormat("OriginalValue: {0}\r\n", item.OriginalValue);
                sb.AppendFormat("Member: {0}\r\n", item.Member.Name);
            }
        }
        #endregion //Dump

        #region UpdateModel
        public void UpdateModel()
        {
            this.ucIt1.UpdateModel();
            this.ucMt1.UpdateModel();
            this.ucRp1.UpdateModel();
            this.ucRc1.UpdateModel();

        }
        #endregion //UpdateModel

        #region CheckInput
        public bool CheckInput()
        {
            return (ucIt1.CheckInput() &&
                ucMt1.CheckInput() &&
                ucRc1.CheckInput() &&
                ucRp1.CheckInput());
        }
        #endregion //CheckInput

        #region IsReadonly
        public bool IsReadonly(Right rt, FLStatus status)
        {
            return false;
        }
        #endregion //IsReadonly

        #region tsbModifyStatus_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbModifyStatus_Click(object sender, EventArgs e)
        {
            bool b = App.Default.GetLoginOperatorRight().CanModifyFLStatus(this.FL.GetFLStatus());
            if (!b)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotModifyMTStatus);
                return;
            }

            frmTMStatusModify f = new frmTMStatusModify(this.FL.GetFLStatus());

            if (f.ShowDialog() == DialogResult.OK)
            {
                FLStatus newStatus = f.NewMtStatus;

                this._newStatusList.Add(f.NewMtStatus);

                if (newStatus == FLStatus.Received)
                {
                    Debug.Assert(this.FL.GetFLStatus() == FLStatus.Created);

                    tblReceive rc = new tblReceive();
                    rc.rc_dt = DateTime.Now;
                    rc.tblOperator = App.Default.LoginOperator;
                    this.FL.tblReceive = rc;

                    this.ucRc1.Rc = this.FL.tblReceive;
                    SetReplyPageStyle();
                    FL.SetFLStatus(newStatus);

                    this.RefreshFLStatusBar();
                }

                if (newStatus == FLStatus.Completed)
                {
                    tblReply rp = new tblReply();
                    rp.tblOperator = App.Default.LoginOperator;

                    this.FL.tblReply = rp;
                    this.FL.SetFLStatus(newStatus);

                    this.ucRp1.Reply = rp;
                    this.RefreshFLStatusBar();
                }

                if (newStatus == FLStatus.Closed)
                {
                    this.FL.SetFLStatus(newStatus);
                    this.RefreshFLStatusBar();
                }

                UpdateToolbarStyles();
            }
        }
        #endregion //tsbModifyStatus_Click

        #region timer1_Tick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            FLStatus status = this.FL.GetFLStatus();
            if (status == FLStatus.Created ||
                status == FLStatus.Received)
            {
                tblMaintain mt = this.FL.tblMaintain;
                TimeSpan ts = mt.mt_timeout_dt - DateTime.Now;
                if (ts > TimeSpan.Zero)
                {
                    string tsString = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
                    if (ts.Days > 0)
                    {
                        tsString = string.Format("{0}天", ts.Days) + tsString;
                    }
                    string s = string.Format(Strings.RemainTimespan, tsString);
                    this.tssTimeout.Text = s;
                }
                else
                {
                    this.tssTimeout.Text = Strings.Timeouted;
                }
            }
            else
            {
                this.tssTimeout.Text = string.Empty;
            }

        }
        #endregion //timer1_Tick

        #region SetReplyPageStyle
        /// <summary>
        /// 
        /// </summary>
        private void SetReplyPageStyle()
        {
            if (this.FL.tblReceive == null)
            {
                this.tabControl1.TabPages.Remove(tpRP);
            }
            else
            {
                if (!this.tabControl1.TabPages.Contains(tpRP))
                {
                    this.tabControl1.TabPages.Add(tpRP);
                }
            }
        }
        #endregion //SetReplyPageStyle

        #region 打印
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 打印PToolStripButton_Click(object sender, EventArgs e)
        {
            NUnit.UiKit.UserMessage.DisplayFailure("NotImplemented");
        }
        #endregion //打印

        #region RestoreFLStatus
        /// <summary>
        /// 
        /// </summary>
        private void RestoreFLStatus()
        {
            if (this.FL.fl_id > 0)
            {
                this.FL.Refresh();
            }
        }
        #endregion //RestoreFLStatus

        #region frmFlow_FormClosed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmFlow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (this.DialogResult != DialogResult.OK)
            //{
            //    RestoreFLStatus();
            //}
        }
        #endregion //frmFlow_FormClosed

        #region tssModifyStatus_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tssModifyStatus_Click(object sender, EventArgs e)
        {
            tsbModifyStatus_Click(null, null);
        }
        #endregion //tssModifyStatus_Click

    }
}
