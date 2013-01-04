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
            this.cmbReportType.DataSource = new string[] { "热源厂成本对比报表", "热力站成本对比报表","供热运行参数报表"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            int typeIndex = this.cmbReportType.SelectedIndex;
            if (typeIndex < 0)
            {
                return;
            }

            using (new CP.Windows.Forms.WaitCursor())
            {
                switch ( typeIndex )
                {
                    case 0:
                        new FirstStationExporter(this.dtpBegin.Value,
                            this.dtpEnd.Value).Export();
                        break;

                    case 1:
                        new StationRangeDataExporter(this.dtpBegin.Value, 
                            this.dtpEnd.Value).Export();
                        break;

                    case 2:
                        new XfDayReportExporter(this.dtpBegin.Value, 
                            this.dtpEnd.Value).Export();
                        break;
                    default:
                        throw new InvalidOperationException(typeIndex.ToString());
            }
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
