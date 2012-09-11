using System;
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
    public partial class frmLogin : NUnit.UiKit.SettingsDialogBase
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            string opName = this.txtOperatorName.Text.Trim();
            string pwd = this.txtPwd.Text ;

            BxdbDataContext dc = Class1.GetBxdbDataContext();
            var r = from q in dc.tblOperator
                    where q.op_name == opName && q.op_pwd == pwd 
                    select q;

            if (r.Count() > 0)
            {
                tblOperator op = r.ToArray()[0];
                App.Default.LoginOperator = op;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("login fail");
            }
        }
    }
}
