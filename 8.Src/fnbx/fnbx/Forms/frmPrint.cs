using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
namespace fnbx
{
    public partial class frmPrint : Form
    {
        public frmPrint()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmPrint_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.DataSources.Add (GetReportDataSource()); 
            this.reportViewer1.RefreshReport();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ReportDataSource GetReportDataSource()
        {
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "FlowData";
            rds.Value = GetReportDataSourceValue();
            return rds;
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private object GetReportDataSourceValue()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = this.FD;
            return bs;
        }

        /// <summary>
        /// 
        /// </summary>
        public FlowData FD
        {
            get { return _fd; }
            set
            {
                this._fd = value;
            }
        } private FlowData _fd;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
