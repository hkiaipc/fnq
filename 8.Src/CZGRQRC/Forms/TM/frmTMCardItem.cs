using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
//using CZGRDBI;
using CZGRWEBDBI;

namespace FNGRQRC
{

    /// <summary>
    /// frmCardItem 的摘要说明。
    /// </summary>
    public class frmTMCardItem : NUnit.UiKit.SettingsDialogBase
    {
        #region Members
        private System.Windows.Forms.Label lblCardSN;
        private System.Windows.Forms.Label lblPerson;
        private System.Windows.Forms.TextBox txtCardSN;
        private System.Windows.Forms.TextBox txtPerson;

        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.Container components = null;

        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label lblAddress;
        private DBCard[] _dbcardlist;
        #endregion //Members

        #region frmCardItem
        /// <summary>
        /// 
        /// </summary>
        public frmTMCardItem(DBCard[] dbcardlist)
        {
            InitializeComponent();
            _dbcardlist = dbcardlist;
        }
        #endregion //frmCardItem

        #region frmCardItem
        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        public frmTMCardItem(DBCard[] dbcardlist, DBCard card)
        {
            InitializeComponent();
            _dbcardlist = dbcardlist;
            this._dbcard = card;
            this.txtCardSN.Text = card.SN;
            this.txtPerson.Text = card.Person;
            this.txtRemark.Text = card.Remark;
        }
        #endregion //frmCardItem

        #region Dispose
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion //Dispose

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCardSN = new System.Windows.Forms.Label();
            this.txtCardSN = new System.Windows.Forms.TextBox();
            this.txtPerson = new System.Windows.Forms.TextBox();
            this.lblPerson = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(229, 158);
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(307, 158);
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // lblCardSN
            // 
            this.lblCardSN.Location = new System.Drawing.Point(15, 14);
            this.lblCardSN.Name = "lblCardSN";
            this.lblCardSN.Size = new System.Drawing.Size(64, 23);
            this.lblCardSN.TabIndex = 5;
            this.lblCardSN.Text = "卡号：";
            // 
            // txtCardSN
            // 
            this.txtCardSN.Location = new System.Drawing.Point(87, 14);
            this.txtCardSN.Name = "txtCardSN";
            this.txtCardSN.Size = new System.Drawing.Size(288, 21);
            this.txtCardSN.TabIndex = 0;
            // 
            // txtPerson
            // 
            this.txtPerson.Location = new System.Drawing.Point(87, 42);
            this.txtPerson.Name = "txtPerson";
            this.txtPerson.Size = new System.Drawing.Size(288, 21);
            this.txtPerson.TabIndex = 1;
            // 
            // lblPerson
            // 
            this.lblPerson.Location = new System.Drawing.Point(15, 42);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(72, 23);
            this.lblPerson.TabIndex = 6;
            this.lblPerson.Text = "持卡人：";
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(87, 69);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRemark.Size = new System.Drawing.Size(288, 80);
            this.txtRemark.TabIndex = 2;
            this.txtRemark.WordWrap = false;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(15, 69);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(60, 23);
            this.lblAddress.TabIndex = 7;
            this.lblAddress.Text = "备注：";
            // 
            // frmCardItem
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(393, 194);
            this.Controls.Add(this.txtPerson);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.txtCardSN);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.lblPerson);
            this.Controls.Add(this.lblCardSN);
            this.Name = "frmCardItem";
            this.Text = "TM卡";
            this.Controls.SetChildIndex(this.lblCardSN, 0);
            this.Controls.SetChildIndex(this.lblPerson, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.txtCardSN, 0);
            this.Controls.SetChildIndex(this.okButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.Controls.SetChildIndex(this.txtRemark, 0);
            this.Controls.SetChildIndex(this.txtPerson, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region DBCard
        /// <summary>
        /// 
        /// </summary>
        public DBCard DBCard
        {
            get { return _dbcard; }
        }private DBCard _dbcard;
        #endregion //DBCard

        #region CardSN
        /// <summary>
        /// 
        /// </summary>
        public string CardSN
        {
            get { return txtCardSN.Text.Trim().ToUpper(); }
            set
            {
                txtCardSN.Text = value;
            }
        }
        #endregion //CardSN

        #region Person
        /// <summary>
        /// 
        /// </summary>
        public string Person
        {
            get { return txtPerson.Text.Trim(); }
            set { txtPerson.Text = value; }
        }
        #endregion //Person

        #region Remark
        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            get { return txtRemark.Text.Trim(); }
            set { this.txtRemark.Text = value; }
        }
        #endregion //Remark

        #region CheckCardSN
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        /// <returns></returns>
        private bool CheckCardSN(string sn)
        {
            sn = sn.Trim().ToUpper();
            if (sn.Length != 16)
                return false;
            foreach (char c in sn)
            {
                // TODO: check c in 0 - F
                if ((c >= (char)'0' && c <= (char)'9') ||
                    (c >= (char)'A' && c <= (char)'F'))
                {
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion //CheckCardSN

        #region cancelButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion //cancelButton_Click

        #region Exist
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        /// <param name="ignore"></param>
        /// <returns></returns>
        private bool Exist(string sn, DBCard ignore)
        {
            return CZGRQRCApp.Default.DBI.ExistTmCard(sn, ignore != null ? ignore.CardID : 0);
            //foreach (object obj in _dbcardlist)
            //{
            //    DBCard card = obj as DBCard;
            //    if (card == ignore)
            //        continue;
            //    if (Xdgk.Common.StringHelper.Equal(card.SN, sn))
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }
        #endregion //Exist

        #region okButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!CheckCardSN(CardSN))
            {
                string s = "卡号错误!" + 
                    Environment.NewLine +
                    "卡号长度必须为16位，并且只能由数字或 A - F 的字母组成!";
                NUnit.UiKit.UserMessage.DisplayFailure(s);
                return;
            }
            bool snExist = Exist(this.CardSN, this._dbcard);

            if (snExist)
            {
                string s = string.Format("卡号 '{0}' 已经存在!", this.CardSN);
                NUnit.UiKit.UserMessage.DisplayFailure(s);
                return;
            }
            DialogResult = DialogResult.OK;
            if (_dbcard == null)
            {
                _dbcard = new DBCard(this.CardSN, this.Person, this.Remark);

                int id = CZGRQRCApp.Default.DBI.InsertTmCard(this.CardSN, this.Person, this.Remark);
                _dbcard.CardID = id;
            }
            else
            {
                _dbcard.SN = this.CardSN;
                _dbcard.Person = this.Person;
                _dbcard.Remark = this.Remark;

                CZGRQRCApp.Default.DBI.UpdateTmCard(_dbcard.CardID, CardSN, Person, Remark);
            }
            Close();
        }
        #endregion //okButton_Click
    }
}
