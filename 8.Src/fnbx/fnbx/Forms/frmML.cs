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
    public partial class frmML : NUnit.UiKit.SettingsDialogBase 
    {
        private tblMaintainLevel _ml;

        /// <summary>
        /// 
        /// </summary>
        public frmML(tblMaintainLevel ml )
        {
            InitializeComponent();

            this._ml = ml;
        }

        private void frmML_Load(object sender, EventArgs e)
        {
            this.txtName.Text = _ml.ml_name;
            this.ucArriveHL.Value = (int)_ml.ml_arrive_hl;
            this.ucReplyHL.Value = (int)_ml.ml_reply_hl;

            //tblMaintainLevel ml = new tblMaintainLevel();
            //ml.ml_arrive_hl = 0;
            //ml.ml_arrive_ll = 0;
            //ml.ml_name = "a";
            //ml.ml_number = 0;
            //ml.ml_reply_hl = 22;
            //ml.ml_remark = "rem";
            ////ml.tbl
            //DataClasses1DataContext dd = new DataClasses1DataContext();
            //dd.tblMaintainLevel..InsertOnSubmit(ml);

            //dd.SubmitChanges();

            tblMaintainLevel ml = new tblMaintainLevel();
            //ml.tblMaintain = null;

            tblMaintain mt = new tblMaintain();
            mt.tblMaintainLevel = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            _ml.ml_arrive_hl = this.ucArriveHL.Value;
            _ml.ml_reply_hl = this.ucReplyHL.Value;

            BXDB.BxdbDataContext dc = DBFactory.GetBxdbDataContext();
            dc.SubmitChanges();

            this.Close();
        }
    }
}
