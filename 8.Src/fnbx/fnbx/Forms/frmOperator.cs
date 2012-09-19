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

        public frmOperator()
        {
            InitializeComponent();
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
            if (_op != null)
            {
                _op.op_name = this.txtName.Text.Trim();
            }
            else
            {
                _op = new tblOperator();
                _op.op_name = this.txtName.Text.Trim();
                //_op.tblRight 
                //dc.tblOperator.InsertOnSubmit(_op);
            }
            dc.SubmitChanges();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
