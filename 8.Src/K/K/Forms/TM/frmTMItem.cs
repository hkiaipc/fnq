using System;
using KDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace K.Forms.TM
{
    public partial class frmTMItem : NUnit.UiKit.SettingsDialogBase
    {
        #region TblTM
        /// <summary>
        /// 
        /// </summary>
        public tblTM TblTM
        {
            get
            {
                return _tblTM;
            }
            set
            {
                _tblTM = value;
            }
        } private tblTM _tblTM;
        #endregion //TblTM

        public frmTMItem()
        {
            InitializeComponent();
        }

        private void frmTMItem_Load(object sender, EventArgs e)
        {
            if (!IsAdd())
            {
                this.txtTM.Text = this.TblTM.TmSN;
            }
        }

        bool IsAdd()
        {
            return this.TblTM == null;
        }

        void Add()
        {
            DB db = DBFactory.GetDB();
            tblTM tm = new tblTM();
            tm.TmSN = this.txtTM.Text.Trim();
            tm.TmRemark = this.txtRemark.Text.Trim();

            db.tblTM.InsertOnSubmit(tm);
            db.SubmitChanges();
        }

        void Edit()
        {
            DB db = DBFactory.GetDB();
            var r = from q in db.tblTM
                    where q.TmID == this.TblTM.TmID
                    select q;

            tblTM tm = r.First();
            tm.TmSN = this.txtTM.Text.Trim();
            tm.TmRemark = this.txtRemark.Text.Trim();

            db.SubmitChanges();
        }

        int GetIgnoreID()
        {
            if (IsAdd())
            {
                return 0;
            }
            else
            {
                return this.TblTM.TmID;
            }
        }

        bool VerifySN()
        {
            bool r = CheckCardSN(this.txtTM.Text);
            if (!r)
            {
                string s = "卡号错误!" + Environment.NewLine +
                    "卡号长度必须为16位，并且只能由数字或 A - F 的字母组成!";
                NUnit.UiKit.UserMessage.DisplayFailure(s);
            }
            else
            {

                bool isExist = IsExist(this.txtTM.Text, GetIgnoreID());
                if (isExist)
                {
                    r = false;
                    string s = "卡号已经存在";
                    NUnit.UiKit.UserMessage.DisplayFailure(s);
                }
            }

            return r;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool IsExist(string p, int ignoreID)
        {
            p = p.Trim().ToUpper();

            DB db = DBFactory.GetDB();
            var r = from q in db.tblTM
                    where q.TmSN == p && q.TmID != ignoreID 
                    select q;

            int count = r.Count();
            return count > 0;
        }

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
                // check c in 0 - F
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
        private void okButton_Click(object sender, EventArgs e)
        {
            if (!VerifySN())
            {
                return;
            }

            if (IsAdd())
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
    }
}
