using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fnbx
{
    public partial class frmTMStatusModify : NUnit.UiKit.SettingsDialogBase 
    {
        public frmTMStatusModify()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public MTStatus Current
        {
            get { return _current; }
            set
            {
                _current = value;
                this.txtCurrentStatus.Text = MTStatusHelper.GetMtStatusText(_current);
            }
        } private MTStatus _current;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTMStatusModify_Load(object sender, EventArgs e)
        {
            Right rt = App.Default.GetLoginOperatorRight();
            MTStatus[] poss = rt.GetPossibles(this.Current);
            List<KeyValuePair<string, MTStatus>> ds = new List<KeyValuePair<string, MTStatus>>();

            foreach (MTStatus item in poss)
            {
                string name = MTStatusHelper.GetMtStatusText(item);
                ds.Add(new KeyValuePair<string, MTStatus>(name, item));
            }


            this.cmbNewMTStatus.DisplayMember = "Key";
            this.cmbNewMTStatus.ValueMember = "Value";
            this.cmbNewMTStatus.DataSource = ds;

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            if (this.cmbNewMTStatus.SelectedIndex >= 0)
            {
                this._newMtStatus = (MTStatus)this.cmbNewMTStatus.SelectedValue;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                NUnit.UiKit.UserMessage.DisplayFailure(Strings.SelectNewStatus);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public MTStatus NewMtStatus
        {
            get { return _newMtStatus; }
        } private MTStatus _newMtStatus;
    }
}
