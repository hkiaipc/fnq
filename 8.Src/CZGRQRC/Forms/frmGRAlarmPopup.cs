using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    public partial class frmGRAlarmPopup : Form
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="grAlarmDatas"></param>
        public frmGRAlarmPopup(GRAlarmDataCollection grAlarmDatas)
        {
            if (grAlarmDatas == null)
                throw new ArgumentNullException("grAlarmDatas");

            InitializeComponent();
            this._gralarmDataCollection = grAlarmDatas;
            FillGRAlarmList();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillGRAlarmList()
        {
            foreach (GRAlarmData grad in _gralarmDataCollection)
            {
                string s = GetGRAlarmDataText(grad);
                this.lstAlarm.Items.Add(s);
            }
            this.lblDeviceName.Text = _gralarmDataCollection[0].DisplayName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grad"></param>
        /// <returns></returns>
        private string GetGRAlarmDataText(GRAlarmData grad)
        {
            string s = string.Format("{0} {1}", grad.DT, grad.Content);
            return s;

        }

        
        /// <summary>
        /// 
        /// </summary>
        private GRAlarmDataCollection _gralarmDataCollection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmGRAlarmPopup_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Image = SystemIcons.Exclamation.ToBitmap();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
