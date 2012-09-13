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

        #region frmFlow
        public frmFlow()
        {
            InitializeComponent();
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
            this.tssFLStatus.Text = _fl.GetFLStatusText();

            SetReplyPageStyle();

        }
        #endregion //UpdateView

        #region 保存
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 保存SToolStripButton_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                this.UpdateModel();

                BxdbDataContext dc = Class1.GetBxdbDataContext();
                if (this.FL.fl_id == 0)
                {
                    dc.tblFlow.InsertOnSubmit(this.FL);
                    dc.SubmitChanges();

                    Debug.Assert(this.FL.fl_id != 0);
                }
                else
                {
                    dc.SubmitChanges();
                }

                NUnit.UiKit.UserMessage.DisplayInfo(Strings.SaveSuccess);
            }
        }
        #endregion //保存

        #region IView 成员

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbModifyStatus_Click(object sender, EventArgs e)
        {
            bool b = App.Default.GetLoginOperatorRight().CanModifyTMStatus(this.FL.GetFLStatus());
            if (b)
            {
                frmTMStatusModify f = new frmTMStatusModify();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    FLStatus newStatus = f.NewMtStatus;
                    FL.SetFLStatus(newStatus);

                    this.tssFLStatus.Text = this.FL.GetFLStatusText();
                    //this.tssTimeout.Text = this.FL.GetFLStatusText();
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotModifyMTStatus);
            }
        }

        #endregion

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
    }
}
