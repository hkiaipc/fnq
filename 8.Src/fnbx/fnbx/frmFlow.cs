using System;
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
        //private int _flID;
        private FLStatus _oldFLStatus;
        private List<FLStatus> _newStatusList = new List<FLStatus>();
        #endregion //Members

        #region GetDC
        private BxdbDataContext GetDC()
        {
            if (this._dc == null)
            {
                //_dc = new BxdbDataContext();
                _dc = Class1.GetBxdbDataContext();
            }
            return this._dc;
        } private BxdbDataContext _dc;
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

        }
        #endregion //frmFlow_Load

        #region FL
        /// <summary>
        /// 
        /// </summary>
        public tblFlow FL
        {
            get { return _fl; }
            set
            {
                if (_fl != value)
                {
                    _fl = value;
                    if (_fl != null)
                    {
                        UpdateView();
                        this._oldFLStatus = this.FL.GetFLStatus();
                    }
                }
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
            this.tssFLStatus.Text = string.Format (
                Strings.CurrentFLStatus ,
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
                if (this.FL.GetFLStatus() == FLStatus.New)
                {
                    this.FL.SetFLStatus(FLStatus.Created);
                }
                this.GetDC().tblFlow.InsertOnSubmit(this.FL);
                this.GetDC().SubmitChanges();

                Debug.Assert(this.FL.fl_id != 0);
            }
            else
            {
                this.GetDC().SubmitChanges();
            }

            this.DialogResult = DialogResult.OK;
            NUnit.UiKit.UserMessage.DisplayInfo(Strings.SaveSuccess);
        }
        #endregion //保存

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
            for (int i = _newStatusList.Count - 1; i >= 0; i--)
            {
                FLStatus st = _newStatusList[i];
                switch (st)
                {
                    case FLStatus.New:
                        break;

                    case FLStatus.Created:

                        break;

                    case FLStatus.Received:
                        this.FL.tblReceive = null;
                        break;

                    case FLStatus.Completed:
                        this.FL.tblReply = null;
                        break;

                    case FLStatus.Closed:
                        break;

                    case FLStatus.Timeouted:
                        break;

                    default:
                        break;
                }
            }
            this.FL.SetFLStatus(this._oldFLStatus);
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
            if (this.DialogResult != DialogResult.OK)
            {
                RestoreFLStatus();
            }
        }
        #endregion //frmFlow_FormClosed

    }
}
