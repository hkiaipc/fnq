using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    public partial class frmUser : NUnit.UiKit.SettingsDialogBase
    {
        public frmUser()
        {
            InitializeComponent();
        }

        #region User
        /// <summary>
        /// 
        /// </summary>
        public string User
        {
            get
            {
                if (_user == null)
                {
                    _user = string.Empty;
                }
                return _user;
            }
            set
            {
                _user = value;
            }
        } private string _user;
        #endregion //User

        #region Role
        /// <summary>
        /// 
        /// </summary>
        public int Role
        {
            get
            {
                return _role;
            }
            set
            {
                _role = value;
            }
        } private int _role;
        #endregion //Role

        #region Edit
        /// <summary>
        /// 
        /// </summary>
        public bool Edit
        {
            get
            {
                return _edit;
            }
            set
            {
                _edit = value;
            }
        } private bool _edit;
        #endregion //Edit

        #region UserID
        /// <summary>
        /// 
        /// </summary>
        public int UserID
        {
            get
            {
                return _userID;
            }
            set
            {
                _userID = value;
            }
        } private int _userID;
        #endregion //UserID


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (CheckUser() && CheckPassword())
            {
                if (!_edit)
                {
                    CZGRQRCApp.Default.DBI.AddUser(
                        this.txtUser.Text,
                        this.txtPwd.Text,
                        GetRole());
                }
                else
                {
                    CZGRQRCApp.Default.DBI.UpdatePassword(
                        this.UserID,
                        this.txtUser.Text.Trim(),
                        this.txtPwd.Text,
                        this.GetRole()
                        );
                }


                    
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckUser()
        {
            if (txtUser.Text.Trim().Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.UserEmpty);
                return false;
            }


            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private int GetRole()
        {
            return this.cmbRight.SelectedIndex;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckPassword()
        {
            if (this.txtPwd.Text != this.txtPwd2.Text)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.PasswordDiff);
                return false;
            }

            if (this.txtPwd.Text.Length == 0)
            {
                NUnit.UiKit.UserMessage.DisplayFailure(strings.PasswordEmpty);
                return false;
            }

            return true;
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            this.cmbRight.SelectedIndex = 0;
            if (Edit)
            {
                this.txtUser.Text = this.User;
                this.cmbRight.SelectedIndex = this.Role;
            }
        }
    }
}
