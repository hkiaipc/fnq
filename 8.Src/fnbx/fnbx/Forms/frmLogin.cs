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

            //BxdbDataContext db = DBFactory.GetBxdbDataContext();
            BxdbDataContext dc = DBFactory.CreateDataContext();
            dc.DeferredLoadingEnabled = false;

            var r = from q in dc.tblOperator
                    where q.op_name == opName && q.op_pwd == pwd 
                    select q;

            if (r.Count() > 0)
            {
                tblOperator op = r.ToArray()[0];
                App.Default.LoginOperator = op;

                BxdbDataContext dc2 = DBFactory.CreateDataContext();
                dc2.tblOperator.Attach(op);
                


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure("login fail");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BXDB.BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            //db.ObjectTrackingEnabled = false;

            this.txtOperatorName.Text = "mt";
            this.okButton_Click(null, null);

            //tblFlow f = FlowFactory.Create();

            //f = FlowFactory.Create();

            ////DBFactory.GetBxdbDataContext().tblFlow.InsertOnSubmit(f);
            //DBFactory.GetBxdbDataContext().SubmitChanges( );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtOperatorName.Text = "rp";
            this.okButton_Click(null, null);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.txtOperatorName.Text = "ad";
            this.okButton_Click(null, null);

        }
    }
}
