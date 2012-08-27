using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;


namespace CZGRQRC.UC
{
    public partial class UCOTCondition : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OKEvent;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ExportEvent;

        #region CombineDateTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datePart"></param>
        /// <param name="timePart"></param>
        /// <returns></returns>
        private DateTime CombineDateTime(DateTime datePart, DateTime timePart)
        {
            return Xdgk.Common.DateTimeHelper.CombineDateTime(datePart, timePart);
        }
        #endregion //CombineDateTime


        #region Begin
        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get 
            {
                DateTime dt = CombineDateTime(dtpBegin.Value, dtpBeginTime.Value);
                return dt;
            }

            set
            {
                this.dtpBegin.Value = value;
                this.dtpBeginTime.Value = value;
            }
        }
        #endregion //Begin


        #region End
        /// <summary>
        /// 
        /// </summary>
        public DateTime End
        {
            get { return CombineDateTime(dtpEnd.Value, dtpEndTime.Value); }
            set
            {
                this.dtpEnd.Value = value;
                this.dtpEndTime.Value = value;
            }
        }
        #endregion //End
        /// <summary>
        /// 
        /// </summary>
        public UCOTCondition()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (OKEvent != null)
            {
                using (new CP.Windows.Forms.WaitCursor(this))
                {
                    OKEvent(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (ExportEvent != null)
            {
                using (new CP.Windows.Forms.WaitCursor(this))
                {
                    ExportEvent(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UCOTCondition_Load(object sender, EventArgs e)
        {
            DateTime begin = DateTime.Now.Date;
            DateTime end = begin + TimeSpan.FromDays(1);
            this.Begin = begin;
            this.End = end;
        }
    }
}
