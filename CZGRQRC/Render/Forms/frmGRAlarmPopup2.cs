using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CZGRQRC
{
    public partial class frmGRAlarmPopup2 : Form
    {
        public frmGRAlarmPopup2()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTable GRAlarmDataTable
        {
            get { return _gralarmDataTable; }
            set { _gralarmDataTable = value; }
        } private DataTable _gralarmDataTable;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmGRAlarmPopup2_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = SystemIcons.Exclamation.ToBitmap();
            Doit();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Doit()
        {
            foreach (DataRow row in this.GRAlarmDataTable.Rows)
            {
                string s = string.Format("{0}\t{1}\t{2}",
                    row["DisplayName"], row["DT"], row["Content"]);
                this.lstAlarm.Items.Add(s);
            }
        }



    }
}
