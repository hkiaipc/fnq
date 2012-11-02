using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BXDB ;

namespace fnbx
{
    public partial class frmOperator : NUnit.UiKit.SettingsDialogBase
    {
        private tblOperator _op = null;

        /// <summary>
        /// 
        /// </summary>
        public frmOperator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool IsAdd()
        {
            return _op == null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="op"></param>
        public frmOperator(tblOperator op)
        {
            InitializeComponent();

            _op = op;
            Fill();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Fill()
        {
            this.txtName.Text = _op.op_name;
        }


        private void frmOperator_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            if (IsAdd())
            {
                tblOperator op = new tblOperator();
                op.op_name = this.txtName.Text.Trim();
                dc.tblOperator.InsertOnSubmit(op);
            }
            else
            {
                var r = from q in dc.tblOperator
                        where q.op_id == _op.op_id
                        select q;
                tblOperator op = r.First();
                op.op_name = this.txtName.Text.Trim();
            }
            dc.SubmitChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
