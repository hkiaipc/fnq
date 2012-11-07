using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Common;

namespace FNGRQRC
{
    public partial class frmFirstStationDetail : NUnit.UiKit.SettingsDialogBase 
    {

        #region KeyValues
        /// <summary>
        /// 
        /// </summary>
        public DataTable DataSource 
        {
            get
            {
                return _tbl;
            }
            set
            {
                _tbl = value;
                Bind();
            }
        } private DataTable  _tbl;
        #endregion //KeyValues

        private void Bind()
        {
            if (this._tbl != null)
            {
                this.dataGridView1.DataSource = this._tbl;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public frmFirstStationDetail()
        {
            InitializeComponent();
        }

        private void frmFirstStationDetail_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
