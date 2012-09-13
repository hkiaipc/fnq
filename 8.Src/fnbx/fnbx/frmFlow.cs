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
            this.tssTimeout.Text = _fl.GetFLStatusText();

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

                    this.tssTimeout.Text = this.FL.GetFLStatusText();
                }
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.CannotModifyMTStatus);
            }
        }

        #endregion
    }
}
