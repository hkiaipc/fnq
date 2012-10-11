using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace FNGRQRC
{
    /// <summary>
    /// 
    /// </summary>
    public partial class UCCalcHeatCondition : UserControl
    { 
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler OKEvent;
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler ExportEvent;
        /// <summary>
        /// 
        /// </summary>
        public UCCalcHeatCondition()
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
             if (this.OKEvent != null)
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
        private void UCCalcHeatCondition_Load(object sender, EventArgs e)
        {
            this.dtpBegin.Value = DateTime.Now.Date;
            this.dtpBeginTime.Value = Config.Default.CalcHeatStartTime;
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime Begin
        {
            get { return this.dtpBegin.Value.Date + this.dtpBeginTime.Value.TimeOfDay; }
        }


        /// <summary>
        /// 
        /// </summary>
        virtual public DateTime End
        {
            get { return Begin + TimeSpan.FromDays(1); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.ExportEvent != null)
            {
                ExportEvent(this, EventArgs.Empty);
            }
        }
    }
}
