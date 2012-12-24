using System;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CZGRWEBDBI;
using FlexCel;
using FlexCel.XlsAdapter;

namespace FNGRQRC.Forms
{
    public partial class frmReport : NUnit.UiKit.SettingsDialogBase 
    {
        /// <summary>
        /// 
        /// </summary>
        public frmReport()
        {
            InitializeComponent();

            this.dtpBegin.Value = DateTime.Now.Date - TimeSpan.FromDays(2d);
            this.dtpEnd.Value = DateTime.Now.Date - TimeSpan.FromDays(1d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            new FirstStationExporter(this.dtpBegin.Value,
                       this.dtpEnd.Value).Export();
            return;

            using (new CP.Windows.Forms.WaitCursor())
            {
                new XfDayReportExporter(this.dtpBegin.Value, this.dtpEnd.Value).Export();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmReport_Load(object sender, EventArgs e)
        {
        }
    }
}
